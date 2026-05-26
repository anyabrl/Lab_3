using Lab3.Models;
using Lab3.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab3.Services
{
    // SOLID: Этот класс знает ТОЛЬКО как анализировать температуру
    public class TemperatureAnalyzer
    {
        public string FindTemperatureDrops(List<TemperatureRecord> data)
        {
            if (data == null || data.Count == 0) return "Нет данных";

            // Считаем перепад для каждого дня
            var drops = data.Select(d => Math.Abs(d.MaxTemp - d.MinTemp)).ToList();

            int maxDropIndex = drops.IndexOf(drops.Max());
            int minDropIndex = drops.IndexOf(drops.Min());

            return $"Самый сильный перепад: {data[maxDropIndex].Date:dd.MM} ({drops.Max():F1} град.)\n" +
                   $"Самый слабый перепад: {data[minDropIndex].Date:dd.MM} ({drops.Min():F1} град.)";
        }
    }
}