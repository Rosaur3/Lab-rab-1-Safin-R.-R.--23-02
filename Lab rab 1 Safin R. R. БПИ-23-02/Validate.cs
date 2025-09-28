using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab_rab_1_Safin_R.R.БПИ_23_02
{
    public class Validate
    {
        private static readonly Regex LettersOnlyRegex = new Regex(@"^[\p{L}]+$", RegexOptions.Compiled);

        public bool IsTextAllowed(string text)
        {
            return LettersOnlyRegex.IsMatch(text);
        }

        public bool TryParseSalary(string salaryText, out decimal salary)
        {
            return decimal.TryParse(salaryText, out salary);
        }

        public bool AreFieldsFilled(string surname, string salaryText, bool birthDateSelected)
        {
            return !string.IsNullOrWhiteSpace(surname)
                && !string.IsNullOrWhiteSpace(salaryText)
                && birthDateSelected;
        }
    }
}
