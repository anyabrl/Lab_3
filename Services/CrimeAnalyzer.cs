using System;
using System.Collections.Generic;
using System.Linq;
using Lab3.Models;

namespace Lab3.Services
{
    public class CrimeAnalyzer
    {
        // Главный метод анализа, который вызывает UI при загрузке файла
        public string AnalyzeCrime(List<CrimeRecord> data)
        {
            // Проверка на минимальную наполненность данных (нужны как минимум 2 года)
            if (data == null || data.Count < 2) return "Недостаточно данных за 15 лет";

            // Вычисляем процент снижения для каждого вида преступлений отдельно
            double theftDrop = CalcDrop(data.Select(d => d.Thefts).ToList());
            double assaultDrop = CalcDrop(data.Select(d => d.Assaults).ToList());
            double fraudDrop = CalcDrop(data.Select(d => d.Fraud).ToList());

            // Определяем названия видов с максимальным и минимальным падением
            string maxDrop = GetCrimeName(theftDrop, assaultDrop, fraudDrop, true);
            string minDrop = GetCrimeName(theftDrop, assaultDrop, fraudDrop, false);

            // Находим сами значения для подстановки в итоговую строку
            double maxVal = Math.Max(theftDrop, Math.Max(assaultDrop, fraudDrop));
            double minVal = Math.Min(theftDrop, Math.Min(assaultDrop, fraudDrop));

            // Формируем итоговый отчет для вывода на форму
            return $"Снизилось больше всего: {maxDrop} (на {maxVal:F1}%)\n" +
                   $"Снизилось меньше всего: {minDrop} (на {minVal:F1}%)";
        }

        // Вспомогательный метод для расчета процента снижения конкретного показателя
        private double CalcDrop(List<int> values)
        {
            double first = values.First();
            double last = values.Last();

            // Защита от деления на ноль, если в первом году данных не было
            return first == 0 ? 0 : ((first - last) / first) * 100;
        }

        // Вспомогательный метод для сопоставления процентов с названиями преступлений
        private string GetCrimeName(double t, double a, double f, bool findMax)
        {
            if (findMax)
            {
                // Ищем вид с максимальным процентом снижения
                if (t >= a && t >= f) return "Кражи";
                if (a >= t && a >= f) return "Разбои";
                return "Мошенничество";
            }
            else
            {
                // Ищем вид с минимальным процентом снижения
                if (t <= a && t <= f) return "Кражи";
                if (a <= t && a <= f) return "Разбои";
                return "Мошенничество";
            }
        }
    }
}