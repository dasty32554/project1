using System;
using System.Windows;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Рассчитать при запуске
            CalculateButton_Click(null, null);
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Получаем данные из полей ввода
                double amount = double.Parse(AmountTextBox.Text);
                int term = int.Parse(TermTextBox.Text);
                double rate = double.Parse(RateTextBox.Text);

                // Расчет аннуитетного платежа
                double monthlyRate = rate / 12 / 100; // Месячная ставка
                double coefficient = (monthlyRate * Math.Pow(1 + monthlyRate, term))
                                   / (Math.Pow(1 + monthlyRate, term) - 1);
                double monthlyPayment = amount * coefficient;

                // Расчет результатов
                double totalPayment = monthlyPayment * term;
                double overpayment = totalPayment - amount;

                // Вывод результатов
                MonthlyPaymentText.Text = $"{monthlyPayment:F2} руб.";
                TotalPaymentText.Text = $"{totalPayment:F2} руб.";
                OverpaymentText.Text = $"{overpayment:F2} руб.";
            }
            catch (Exception)
            {
                MessageBox.Show("Пожалуйста, введите корректные числовые значения!",
                              "Ошибка",
                              MessageBoxButton.OK,
                              MessageBoxImage.Error);
            }
        }
    }
}