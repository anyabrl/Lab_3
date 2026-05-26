using Lab3.Models;
using Lab3.Services;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace Lab3
{
    public partial class TemperatureControl : UserControl
    {
        // SOLID (DIP): Мы зависим от сервисов, а не пишем логику прямо тут
        private readonly ForecastService _forecaster = new ForecastService();
        private readonly TemperatureAnalyzer _analyzer = new TemperatureAnalyzer();

        private List<TemperatureRecord> _data = new List<TemperatureRecord>();
        private PlotModel _plotModel;

        // КОНСТРУКТОР: Без него ничего не заработает!
        public TemperatureControl()
        {
            InitializeComponent(); // Рисует кнопки и графики из Designer.cs

            // Жестко привязываем кнопки к коду, чтобы точно работало
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            this.btnForecast.Click += new System.EventHandler(this.btnForecast_Click);
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
        }

        // Этот метод вызывается автоматически при старте программы
        private void TemperatureControl_Load(object sender, EventArgs e)
        {
            SetupPlot();
        }

        private void SetupPlot()
        {
            _plotModel = new PlotModel { Title = "Температура за месяц" };
            plotView.Model = _plotModel;
        }

        // Кнопка "Открыть файл"
        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "JSON файлы|*.json";
                if (ofd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    // Читаем файл
                    string json = File.ReadAllText(ofd.FileName);
                    _data = JsonSerializer.Deserialize<List<TemperatureRecord>>(json);

                    // 1. Выводим в таблицу
                    dataGridView1.DataSource = _data;

                    // 2. Показываем результат анализа (перепады)
                    lblResult.Text = _analyzer.FindTemperatureDrops(_data);

                    // 3. Рисуем график
                    DrawGraph();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки файла: " + ex.Message);
                }
            }
        }

        private void DrawGraph()
        {
            _plotModel.Series.Clear();
            _plotModel.Axes.Clear(); // Очищаем оси перед новой отрисовкой

            // Создаем линии для графика
            var maxSeries = new LineSeries { Title = "Макс. темп.", Color = OxyColors.Red, MarkerSize = 4, MarkerType = MarkerType.Circle };
            var minSeries = new LineSeries { Title = "Мин. темп.", Color = OxyColors.Blue, MarkerSize = 4, MarkerType = MarkerType.Circle };

            foreach (var d in _data)
            {
                // Переводим дату в формат OxyPlot
                double x = DateTimeAxis.ToDouble(d.Date);
                maxSeries.Points.Add(new DataPoint(x, d.MaxTemp));
                minSeries.Points.Add(new DataPoint(x, d.MinTemp));
            }

            // Добавляем ось X (Даты)
            _plotModel.Axes.Add(new OxyPlot.Axes.DateTimeAxis()
            {
                Position = OxyPlot.Axes.AxisPosition.Bottom,
                Title = "День месяца",
                StringFormat = "dd.MM"
            });

            // Добавляем линии на график
            _plotModel.Series.Add(maxSeries);
            _plotModel.Series.Add(minSeries);

            _plotModel.InvalidatePlot(true); // Обновляем график
        }

        // Кнопка "Построить прогноз"
        private void btnForecast_Click(object sender, EventArgs e)
        {
            if (_data.Count == 0) { MessageBox.Show("Сначала загрузите данные!"); return; }
            if (!int.TryParse(txtN.Text, out int n) || n <= 0) { MessageBox.Show("Введи корректное число N!"); return; }

            var lastDate = _data.Last().Date;

            // Получаем прогноз от сервиса
            var maxForecast = _forecaster.Predict(_data.Select(d => d.MaxTemp).ToList(), n, n);
            var minForecast = _forecaster.Predict(_data.Select(d => d.MinTemp).ToList(), n, n);

            // Рисуем прогноз пунктирными линиями
            var maxFSeries = new LineSeries { Title = "Прогноз макс.", LineStyle = LineStyle.Dash, Color = OxyColors.OrangeRed };
            var minFSeries = new LineSeries { Title = "Прогноз мин.", LineStyle = LineStyle.Dash, Color = OxyColors.LightBlue };

            for (int i = 0; i < n; i++)
            {
                double x = DateTimeAxis.ToDouble(lastDate.AddDays(i + 1));
                maxFSeries.Points.Add(new DataPoint(x, maxForecast[i]));
                minFSeries.Points.Add(new DataPoint(x, minForecast[i]));
            }

            _plotModel.Series.Add(maxFSeries);
            _plotModel.Series.Add(minFSeries);
            _plotModel.InvalidatePlot(true); // Обновляем
        }

        // Кнопка "Экспорт графика"
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (_plotModel.Series.Count == 0) { MessageBox.Show("Нет графика для экспорта!"); return; }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PNG Изображение|*.png";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var pngExporter = new PngExporter { Width = 1000, Height = 600 };
                    pngExporter.ExportToFile(_plotModel, sfd.FileName);
                    MessageBox.Show("График успешно сохранен!");
                }
            }
        }
    }
}