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

namespace Wpf_control_hotel_rent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int peopleNumber = 1;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void check_Click(object sender, RoutedEventArgs e)
        {
            if (check.IsChecked == true)
                order.IsEnabled = true;
            else
                order.IsEnabled = false;
        }

        private void peopleNum_Click(object sender, RoutedEventArgs e)
        {
            if (peopleNumber <= 11)
                peopleNumber++;
            else
                peopleNumber = 1;
            Num.Content = peopleNumber.ToString();
        }

        private void order_Click(object sender, RoutedEventArgs e)
        {
            string result = "Регістраційні дані:\n";
            result += $"Прізвище та ім'я: {fullname.Text}\n";
            result += $"Контактна інформація: {contactInformation.Text}\n";
            result += $"Кількість людей: {peopleNumber}\n";
            if ((bool)econom.IsChecked)
                result += $"Тип номеру: економ\n";
            else if ((bool)standart.IsChecked)
                result += $"Тип номеру: стандарт\n";
            else if ((bool)luxe.IsChecked)
                result += $"Тип номеру: люкс\n";
            result += $"Тривалість перебування: {calendar.SelectedDates[0]} ... {calendar.SelectedDates[calendar.SelectedDates.Count - 1]}\n";
            MessageBox.Show(result);
        }

        private void сancel_Click(object sender, RoutedEventArgs e)
        {
            fullname.Text = "";
            contactInformation.Text = "";
            peopleNumber = 1;
            Num.Content = $"{peopleNumber}";
            econom.IsChecked = false;
            standart.IsChecked = false;
            luxe.IsChecked = false;
            calendar.SelectedDates.Clear();
            check.IsChecked = false;
            order.IsEnabled = false;
        }
    }
}
