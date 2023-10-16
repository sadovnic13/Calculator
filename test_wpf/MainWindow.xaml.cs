using System;
using System.Data;
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

namespace test_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach (UIElement el in MainRoot.Children)
            {
                if (el is Button)
                {
                    ((Button)el).Click += Button_Click;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = (string)((Button)e.OriginalSource).Content;

            if (str == "AC")
            {
                textLabel1.Text = "";   
            }
            else if (str == "=")
            {
                try
                {
                    string value = new DataTable().Compute(textLabel1.Text, null).ToString();
                    textLabel1.Text = value;
                }
                catch (SyntaxErrorException)
                {
                    textLabel1.Text = "Введите коректные данные";
                }
            }
            else
            {
                if (textLabel1.Text == "Введите коректные данные")
                {
                    textLabel1.Text = "";
                }

                textLabel1.Text += str;
            }
        }
    }
}
