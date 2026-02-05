using System;
using System.Windows;

namespace LoanCalculatorWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                double amount = double.Parse(AmountTextBox.Text);
                int term = int.Parse(TermTextBox.Text);
                double rate = double.Parse(RateTextBox.Text);

                
                double monthlyRate = rate / 12 / 100; 
                double coefficient = (monthlyRate * Math.Pow(1 + monthlyRate, term))
                                   / (Math.Pow(1 + monthlyRate, term) - 1);
                double monthlyPayment = amount * coefficient;

                
                double totalPayment = monthlyPayment * term;
                double overpayment = totalPayment - amount;

                
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