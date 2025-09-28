using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace Lab_rab_1_Safin_R.R.БПИ_23_02
{
    public partial class MainWindow : Window
    {
        public Validate validation { get; set; } = new Validate();
        public Aged aged { get; set; } = new Aged();
        public static void ShowWarning(string message, string title = "Ошибка")
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SurnameTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !validation.IsTextAllowed(e.Text);
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            string surname = SurnameTextBox.Text.Trim();
            string salaryText = SalaryTextBox.Text.Trim();
            DateTime? birthDate = BirthDatePicker.SelectedDate;

            if (!validation.AreFieldsFilled(surname, salaryText, birthDate.HasValue))
            {
                ShowWarning("Пожалуйста, заполните все поля.");
                return;
            }

            if (!validation.TryParseSalary(salaryText, out decimal salary))
            {
                ShowWarning("Оклад должен быть числом.");
                SalaryTextBox.Focus();
                return;
            }

            var result = aged.CalculateAgeAndDaysTo50(birthDate.Value, DateTime.Today);

            AgeTextBlock.Text = $"Возраст: {result.Age} лет";

            if (result.IsFiftiethPassed)
            {
                DaysTextBlock.Text = $"50-летие было {-result.DaysToFiftieth} дней назад";
            }
            else
            {
                DaysTextBlock.Text = $"До 50-летия: {result.DaysToFiftieth} дней";
            }
        }
    }
}