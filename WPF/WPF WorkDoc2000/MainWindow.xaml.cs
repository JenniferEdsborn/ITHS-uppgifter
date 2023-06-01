using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Printing;
using System.Text;
using System.Drawing;
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

namespace WPF_WorkDoc2000
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CountWords(object sender, RoutedEventArgs e)
        {
            string textcounter = MainTextBox.Text.Trim();
            string[] textarray = textcounter.Split(' ', '\n');

            int wordcount = 0;

            foreach (string word in textarray)
            {
                if (word == "" || word == "\n" || word == "\r")
                {
                    continue;
                }               
                wordcount++;
            }

            string meddelande = wordcount + " antal ord!";

            System.Windows.MessageBox.Show(meddelande, "Antal ord", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CapitalLetters(object sender, RoutedEventArgs e)
        {
            string text = MainTextBox.Text;
            MainTextBox.Text = text.ToUpper();
        }

        private void LowerCase(object sender, RoutedEventArgs e)
        {
            string text = MainTextBox.Text;
            MainTextBox.Text = text.ToLower();
        }

        private void CapitalLetAfterDot(object sender, RoutedEventArgs e)
        {
            string text = MainTextBox.Text;
            bool IsNewSentense = true;
            var result = new StringBuilder(text.Length);

            for (int i = 0; i < text.Length; i++)
            {
                if (IsNewSentense && char.IsLetter(text[i]))
                {
                    result.Append(char.ToUpper(text[i]));
                    IsNewSentense = false;
                }
                else
                    result.Append(text[i]);

                if (text[i] == '!' || text[i] == '?' || text[i] == '.')
                {
                    IsNewSentense = true;
                }
            }

            MainTextBox.Text = result.ToString();

        }

        private void l33tsp34k(object sender, RoutedEventArgs e)
        {
            string text = MainTextBox.Text;
            Dictionary<string, string> leetRules = new Dictionary<string, string>();
            leetRules.Add("4", "a");
            leetRules.Add("8", "B");
            leetRules.Add("3", "e");
            leetRules.Add("6", "G");
            leetRules.Add("5", "s");
            leetRules.Add("7", "T");
            leetRules.Add("2", "z");

            foreach (KeyValuePair<string, string> x in leetRules)
            {
                text = text.Replace(x.Value, x.Key);
            }

            MainTextBox.Text = text;
        }

        private void ReadFromFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = ".txt";
            dlg.Filter = "txt documents (.txt)|*.txt";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                using (FileStream fs = (FileStream)dlg.OpenFile())
                {
                    using (StreamReader sr = new StreamReader(fs, Encoding.Default))
                    {
                        MainTextBox.Text = sr.ReadToEnd();
                    }
                }
            }
        }

        private void SaveToFile(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();

            dlg.Filter = "txt Files|*.txt";
            dlg.FilterIndex = 2;
            dlg.RestoreDirectory = true;

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                using (FileStream fs = (FileStream)dlg.OpenFile())
                {
                    using (StreamWriter sw = new StreamWriter(fs, Encoding.Default))
                    {
                        sw.Write(MainTextBox.Text);
                    }
                }
            }
        }

        private void EraseText(object sender, RoutedEventArgs e)
        {
            MainTextBox.Text = "";
        }

        private void Rovarspraket(object sender, RoutedEventArgs e)
        {
            string toTranslate = MainTextBox.Text;
            int LengthOfText = toTranslate.Length;
            string ConvertedText = "";

            for (int i = 0; i < LengthOfText; i++)
            {
                if (toTranslate[i] == 'a' || toTranslate[i] == 'e' || toTranslate[i] == 'i'
                    || toTranslate[i] == 'o' || toTranslate[i] == 'u' || toTranslate[i] == 'å' 
                    || toTranslate[i] == 'ö' || toTranslate[i] == 'ä' || toTranslate[i] == 'y')
                {
                    ConvertedText = ConvertedText + toTranslate[i];
                }

                else if (toTranslate[i] == ' ')
                {
                    ConvertedText = ConvertedText + toTranslate[i];
                }

                else
                {
                    ConvertedText = ConvertedText + toTranslate[i] + 'o' + toTranslate[i];
                }
            }
            MainTextBox.Text = ConvertedText.ToLower();
        }
    }
}
