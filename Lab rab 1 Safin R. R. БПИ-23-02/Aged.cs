using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_rab_1_Safin_R.R.БПИ_23_02
{
    public class AgeCalculation
    {
        public int Age { get; set; }
        public int DaysToFiftieth { get; set; }
        public bool IsFiftiethPassed => DaysToFiftieth < 0;
    }

    public class Aged
    {
        public AgeCalculation CalculateAgeAndDaysTo50(DateTime birthDate, DateTime currentDate)
        {
            int age = currentDate.Year - birthDate.Year;
            if (birthDate.Date > currentDate.AddYears(-age)) age--;

            DateTime fiftiethBirthday = birthDate.AddYears(50);
            int daysTo50 = (fiftiethBirthday - currentDate).Days;

            return new AgeCalculation
            {
                Age = age,
                DaysToFiftieth = daysTo50
            };
        }
    }
}
