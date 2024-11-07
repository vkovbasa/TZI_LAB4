using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnCheckPasswordClick(object sender, RoutedEventArgs e)
        {
            string password = PasswordBox.Password;
            ResultTextBlock.Text = IsPasswordStrong(password);
        }

        private string IsPasswordStrong(string password)
        {
            if (password.Length < 8)
                return "Пароль повинен бути не менше 8 символів.";

            if (!Regex.IsMatch(password, @"[A-Z]"))
                return "Пароль повинен містити хоча б одну велику літеру.";

            if (!Regex.IsMatch(password, @"[a-z]"))
                return "Пароль повинен містити хоча б одну малу літеру.";

            if (!Regex.IsMatch(password, @"\d"))
                return "Пароль повинен містити хоча б одну цифру.";

            return "Пароль надійний.";
        }

        private void ShowPassword_Checked(object sender, RoutedEventArgs e)
        {
            if (PasswordTextBox.Visibility == Visibility.Collapsed)
            {
                // Відображаємо пароль у TextBox і приховуємо PasswordBox
                PasswordTextBox.Visibility = Visibility.Visible;
                PasswordBox.Visibility = Visibility.Collapsed;
                PasswordTextBox.Text = PasswordBox.Password;
            }
            else
            {
                // Приховуємо пароль у PasswordBox і приховуємо TextBox
                PasswordTextBox.Visibility = Visibility.Collapsed;
                PasswordBox.Visibility = Visibility.Visible;
                PasswordBox.Password = PasswordTextBox.Text;
            }
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            // Синхронізуємо текст між PasswordBox і TextBox
            if (PasswordBox.Visibility == Visibility.Visible)
            {
                PasswordTextBox.Text = PasswordBox.Password;
            }
        }
    }
}
