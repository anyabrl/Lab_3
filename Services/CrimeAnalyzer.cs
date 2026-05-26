using System;
using System.Collections.Generic;
using System.Linq;
using Lab3.Models;

namespace Lab3.Services
{
    public class CrimeAnalyzer
    {
        public string AnalyzeCrime(List<CrimeRecord> data)
        {
            if (data == null || data.Count < 2) return "Недостаточно данных за 15 лет";

            double theftDrop = CalcDrop(data.Select(d => d.Thefts).ToList());
            double assaultDrop = CalcDrop(data.Select(d => d.Assaults).ToList());
            double fraudDrop = CalcDrop(data.Select(d => d.Fraud).ToList());

            string maxDrop = GetCrimeName(theftDrop, assaultDrop, fraudDrop, true);
            string minDrop = GetCrimeName(theftDrop, assaultDrop, fraudDrop, false);

            double maxVal = Math.Max(theftDrop, Math.Max(assaultDrop, fraudDrop));
            double minVal = Math.Min(theftDrop, Math.Min(assaultDrop, fraudDrop));

            return $"Снизилось больше всего: {maxDrop} (на {maxVal:F1}%)\n" +
                   $"Снизилось меньше всего: {minDrop} (на {minVal:F1}%)";
        }

        private double CalcDrop(List<int> values)
        {
            double first = values.First();
            double last = values.Last();
            return first == 0 ? 0 : ((first - last) / first) * 100;
        }

        private string GetCrimeName(double t, double a, double f, bool findMax)
        {
            if (findMax)
            {
                if (t >= a && t >= f) return "Кражи";
                if (a >= t && a >= f) return "Разбои";
                return "Мошенничество";
            }
            else
            {
                if (t <= a && t <= f) return "Кражи";
                if (a <= t && a <= f) return "Разбои";
                return "Мошенничество";
            }
        }
    }
}