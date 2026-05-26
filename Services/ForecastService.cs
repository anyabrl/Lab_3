using System.Collections.Generic;
using System.Linq;

namespace Lab3.Services
{
    // SOLID: Единственная ответственность - только математика
    public class ForecastService
    {
        public List<double> Predict(List<double> data, int windowSize, int forecastCount)
        {
            List<double> extendedData = new List<double>(data);
            List<double> forecast = new List<double>();

            for (int i = 0; i < forecastCount; i++)
            {
                // Берем последние N элементов
                var recent = extendedData.Skip(Math.Max(0, extendedData.Count - windowSize)).Take(windowSize).ToList();
                double nextVal = recent.Any() ? recent.Average() : 0;

                forecast.Add(nextVal);
                extendedData.Add(nextVal); // Добавляем для следующего прогноза
            }
            return forecast;
        }
    }
}