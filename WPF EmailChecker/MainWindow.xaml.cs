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

namespace WPF_EmailChecker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Regex r = new Regex(@"^[a-zA-Z0-9]\w*@\w+\.[a-zA-Z]{2,}$");

        public MainWindow()
        {
            InitializeComponent();
        }

        private void clickHere_Click(object sender, RoutedEventArgs e)
        {
            string answer = writeHere.Text;

            if (r.IsMatch(answer))
            {
                boolValidEmail.Content = "Valid Email";
            }
            else
            {
                boolValidEmail.Content = "Non-valid Email";
            }
        }
    }
}
