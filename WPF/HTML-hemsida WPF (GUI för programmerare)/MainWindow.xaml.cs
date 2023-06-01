using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace HTML_hemsida_WPF__GUI_för_programmerare_
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NyHemsida_Click(object sender, RoutedEventArgs e)
        {
            Output.Text = "<!DOCTYPE html>\n<html>\n<body>\n<h1>Välkomna KLASSNAMN-HÄR!</h1>\n<p><b>Meddelande 1:</b>" +
                " Klasspecifikt meddelande här.</p>\n<p><b>Meddelande 2:</b> Klasspecifikt meddelande här.</p>\n<main>\n<p>Kurs om C#" +
                "</p>\r\n<p>Kurs om Databaser</p>\n</main>\n</body>\n</html>";
        }

        private void Spara_Click(object sender, RoutedEventArgs e)
        {

            SaveFileDialog dlg = new SaveFileDialog();

            dlg.Filter = "HTML Files|*.html";
            dlg.FilterIndex = 2;
            dlg.RestoreDirectory = true;

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                using (FileStream fs = (FileStream)dlg.OpenFile())
                {
                    using (StreamWriter sw = new StreamWriter(fs, Encoding.Default))
                    {
                        sw.Write(Output.Text);
                    }
                }
            }
        }

        private void LaddaInHemsida_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = ".html";
            dlg.Filter = "Html documents (.html)|*.html";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                using (FileStream fs = (FileStream)dlg.OpenFile())
                {
                    using (StreamReader sr = new StreamReader(fs, Encoding.Default))
                    {
                        Output.Text = sr.ReadToEnd();
                    }
                }
            }
        }
    }
}
