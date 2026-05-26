using System;

namespace Lab3.Models
{
    // Модель данных. Свойства защищают данные (Инкапсуляция)
    public class TemperatureRecord
    {
        public DateTime Date { get; set; }
        public double MaxTemp { get; set; }
        public double MinTemp { get; set; }
        public string Description { get; set; }
    }
}