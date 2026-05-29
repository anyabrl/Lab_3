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
    public partial class CrimeControl : UserControl
    {
        // Экземпляры сервисов для выноса бизнес-логики из интерфейса (принцип единственной ответственности)
        private readonly ForecastService _forecaster = new ForecastService();
        private readonly CrimeAnalyzer _analyzer = new CrimeAnalyzer();

        // Локальное хранилище загруженных данных
        private List<CrimeRecord> _data = new List<CrimeRecord>();
        private PlotModel _plotModel;

        public CrimeControl()
        {
            InitializeComponent();
        }

        private void CrimeControl_Load(object sender, EventArgs e)
        {
            // Инициализация модели графика при старте элемента управления
            _plotModel = new PlotModel { Title = "Преступность в РФ (15 лет)" };
            plotView.Model = _plotModel;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "JSON файлы|*.json";
                if (ofd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    // Десериализация данных из файла в список объектов модели
                    string json = File.ReadAllText(ofd.FileName);
                    _data = JsonSerializer.Deserialize<List<CrimeRecord>>(json);

                    // Привязка данных к таблице для удобного отображения
                    dataGridView1.DataSource = _data;

                    // Запуск аналитики и вывод результата в текстовую метку
                    lblResult.Text = _analyzer.AnalyzeCrime(_data);

                    // Построение визуализации по загруженным данным
                    DrawGraph();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }

        private void DrawGraph()
        {
            // Очистка графика от старых линий и осей перед перерисовкой
            _plotModel.Series.Clear();
            _plotModel.Axes.Clear();

            // Настройка стиля линии: сплошная, темно-зеленая, с маркерами-кружками
            var totalSeries = new LineSeries { Title = "Всего преступлений", Color = OxyColors.DarkGreen, MarkerSize = 4, MarkerType = MarkerType.Circle };

            foreach (var d in _data)
            {
                // Добавление точек: по оси X - год (как число), по оси Y - общее количество
                totalSeries.Points.Add(new DataPoint(d.Year, d.Total));
            }

            // Добавление подписанной оси абсцисс
            _plotModel.Axes.Add(new LinearAxis() { Position = AxisPosition.Bottom, Title = "Год" });

            // Добавление линии на модель и команда обновить отрисовку
            _plotModel.Series.Add(totalSeries);
            _plotModel.InvalidatePlot(true);
        }

        private void btnForecast_Click(object sender, EventArgs e)
        {
            // Базовые проверки перед запуском расчетов
            if (_data.Count == 0) { MessageBox.Show("Загрузи данные!"); return; }
            if (!int.TryParse(txtN.Text, out int n) || n <= 0) { MessageBox.Show("Введи N!"); return; }

            var lastYear = _data.Last().Year;

            // Вызов сервиса прогнозирования. Передаем исторические данные и параметры расчета
            var forecast = _forecaster.Predict(_data.Select(d => (double)d.Total).ToList(), n, n);

            // Настройка стиля линии для прогнозных данных (пунктир, оранжевый цвет)
            var fSeries = new LineSeries { Title = "Прогноз", LineStyle = LineStyle.Dash, Color = OxyColors.Orange };

            // Построение точек прогноза, продолжая ось X начиная со следующего года
            for (int i = 0; i < n; i++)
            {
                fSeries.Points.Add(new DataPoint(lastYear + i + 1, forecast[i]));
            }

            // Добавление прогнозной линии к уже существующему графику
            _plotModel.Series.Add(fSeries);
            _plotModel.InvalidatePlot(true);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (_plotModel.Series.Count == 0) { MessageBox.Show("Нет графика!"); return; }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PNG|*.png";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    // Использование встроенного экспортера OxyPlot для сохранения графика в файл
                    var pngExporter = new PngExporter { Width = 1000, Height = 600 };
                    pngExporter.ExportToFile(_plotModel, sfd.FileName);
                    MessageBox.Show("Сохранено!");
                }
            }
        }
    }
}