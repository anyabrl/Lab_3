using System;

namespace Lab3.Models
{
    public class CrimeRecord
    {
        public int Year { get; set; }
        public int Thefts { get; set; }
        public int Assaults { get; set; }
        public int Fraud { get; set; }

        public int Total => Thefts + Assaults + Fraud;
    }
}