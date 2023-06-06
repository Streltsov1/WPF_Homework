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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum Operation { Add, Sub, Mul, Dev }
        Operation? operation;
        string value = "0";
        double? result = null;
        bool isEqual = false;
        bool isFirstOperation = true;
        string oper;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Numbers(object sender, RoutedEventArgs e)
        {
            string new_value = (sender as Button).Content.ToString();
            if (value == "0")
                value = new_value;
            else
                value += new_value;
            ResultTB.Text = value;
        }

        private void Button_Click_Operations(object sender, RoutedEventArgs e)
        {
            oper = (sender as Button).Content.ToString();
            if (isEqual)
                value = $"{result}";
            if(!isFirstOperation)
            {
                Result();
                History.Text = $"{result}";
                ResultTB.Text = $"{result}";
                value = $"{result}";
            }
            result = double.Parse(value);
            if (oper == "+")
                operation = Operation.Add;
            else if (oper == "-")
                operation = Operation.Sub;
            else if (oper == "*")
                operation = Operation.Mul;
            else if (oper == "/")
                operation = Operation.Dev;
            if (result == 0 && operation == Operation.Dev)
            {
                value = "0";
                result = 0;
                History.Text = "";
                ResultTB.Text = "Error!";
                operation = null;
                return;
            }
            if(isEqual || !isFirstOperation)
                History.Text = "";
            History.Text += $"{value} {oper} ";
            value = "0";
            ResultTB.Text = $"{value}";
            isEqual = false;
            isFirstOperation = false;
        }

        private void Button_Click_Result(object sender, RoutedEventArgs e)
        {
            if (isEqual)
            {
                History.Text = $"{result} {oper} ";
            }
            Result();
            History.Text += $"{value} =";
            isEqual = true;
            ResultTB.Text = $"{result}";
            isFirstOperation = true;
        }
        private void Result()
        {
            if (operation == Operation.Add)
                result += double.Parse(value);
            else if (operation == Operation.Sub)
                result -= double.Parse(value);
            else if (operation == Operation.Mul)
                result *= double.Parse(value);
            else if (operation == Operation.Dev)
                result /= double.Parse(value);
            else if (operation == null)
                result = double.Parse(value);
        }

        private void Button_Click_Erase(object sender, RoutedEventArgs e)
        {
            string new_value = (sender as Button).Content.ToString();
            string new_string;
            if (new_value == "C")
            {
                value = "0";
                History.Text = "";
                ResultTB.Text = value;
                result = null;
                operation = null;
                isEqual = false;
                isFirstOperation = true;
                oper = "";
            }
            else if (new_value == "CE")
            {
                value = "0";
                ResultTB.Text = value;
            }
            else
            {
                value = value.Remove(value.LastIndexOf(value[value.Length - 1]), 1);
                ResultTB.Text = value;
            }
        }

        private void Button_Click_Dot(object sender, RoutedEventArgs e)
        {
            if(value.IndexOf(',') == -1)
                value += ",";
            ResultTB.Text = value;
        }
    }
}
