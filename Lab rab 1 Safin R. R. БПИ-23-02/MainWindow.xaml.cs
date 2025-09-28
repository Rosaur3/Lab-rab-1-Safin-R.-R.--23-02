using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace Lab_rab_1_Safin_R.R.БПИ_23_02
{ 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SurnameTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"^[\p{L}]+$");
            if (!regex.IsMatch(e.Text))
            {
                e.Handled = true;
            }
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            string surname = SurnameTextBox.Text.Trim();
            string salaryText = SalaryTextBox.Text.Trim();
            DateTime? birthDate = BirthDatePicker.SelectedDate;

            if (string.IsNullOrWhiteSpace(surname)  ||string.IsNullOrWhiteSpace(salaryText)|| !birthDate.HasValue)
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!decimal.TryParse(salaryText, out decimal salary))
            {
                MessageBox.Show("Оклад должен быть числом.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                SalaryTextBox.Focus();
                return;
            }

            DateTime today = DateTime.Today;

            int age = today.Year - birthDate.Value.Year;
            if (birthDate.Value.Date > today.AddYears(-age)) age--; 

            DateTime fiftiethBirthday = birthDate.Value.AddYears(50);
            TimeSpan daysTo50 = fiftiethBirthday - today;
            int days = daysTo50.Days;

            if (days < 0)
            {
                AgeTextBlock.Text = $"Возраст: {age} лет";
                DaysTo50TextBlock.Text =  $"50-летие было {-days} дней назад";
            }
            else
            {
                AgeTextBlock.Text = $"Возраст: {age} лет";
                DaysTo50TextBlock.Text = $"До 50-летия: {days} дней";
            }
        }
    }
}