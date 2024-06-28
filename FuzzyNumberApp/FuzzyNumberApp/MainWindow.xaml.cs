using System;
using System.Windows;

namespace FuzzyNumberApp
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
                double x1 = double.Parse(X1TextBox.Text);
                double a1_1 = double.Parse(A1_1TextBox.Text);
                double a2_1 = double.Parse(A2_1TextBox.Text);
                FuzzyNumber fuzzy1 = new FuzzyNumber(x1, a1_1, a2_1);

                double x2 = double.Parse(X2TextBox.Text);
                double a1_2 = double.Parse(A1_2TextBox.Text);
                double a2_2 = double.Parse(A2_2TextBox.Text);
                FuzzyNumber fuzzy2 = new FuzzyNumber(x2, a1_2, a2_2);

                FuzzyNumber result;
                if (AdditionRadioButton.IsChecked == true)
                {
                    result = fuzzy1 + fuzzy2;
                }
                else if (SubtractionRadioButton.IsChecked == true)
                {
                    result = fuzzy1 - fuzzy2;
                }
                else if (MultiplicationRadioButton.IsChecked == true)
                {
                    result = fuzzy1 * fuzzy2;
                }
                else if (DivisionRadioButton.IsChecked == true)
                {
                    result = fuzzy1 / fuzzy2;
                }
                else
                {
                    MessageBox.Show("Выберите операцию", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                ResultTextBlock.Text = $"Результат: {result}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
