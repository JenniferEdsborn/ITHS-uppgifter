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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HTML_hemsida_WPF__GUI_för_managers_
{
    interface WebsiteGenerator
    {
        void handleCourses(List<string> courses);
        void handleMessages(List<string> messages);
    }

    public partial class MainWindow : WebsiteGenerator
    {
        protected List<string> messages = new List<string>();
        protected List<string> courses = new List<string>();

        string color = "blue";

        public void handleCourses(List<string> courses)
        {
            if (courses.Count > 0)
            {
                foreach (string course in courses)
                {
                    MainOutput.AppendText($"<p>Kurs i {course.Trim().ToUpper().Substring(0, 1) + course.Trim().Substring(1).ToLower()}<p/>\n");
                }
            }
            MainOutput.AppendText("\n");
        }
        public void handleMessages(List<string> messages)
        {
            if (messages.Count > 0)
            {
                int x = 1;
                foreach (string message in messages)
                {
                    MainOutput.AppendText($"<p><b>Meddelande {x}: {message}</b></p>\n");
                }
            }

            MainOutput.AppendText("\n");
        }
        public void colorTheme()
        {
            if (RedRadioButton.IsChecked == true)
            {
                color = "red";
            }
            else if (TurquoiseRadioButton.IsChecked == true)
            {
                color = "turquoise";
            }
            else if (GreenRadioButton.IsChecked == true)
            {
                color = "green";
            }
            else
            {
                color = "blue";
            }

            MainOutput.AppendText($"{{color: {color} }}");
        }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            MainOutput.Text = $"<!DOCTYPE html>\n<html>\n<head>\n<style>p ";
            colorTheme();
            MainOutput.AppendText($"\n</style>\n</head>\n<body>\n<main>\n\n<h1>Välkomna {TextBoxClassname.Text}!</h1>\n");
            handleMessages(messages);
            handleCourses(courses);
            MainOutput.AppendText("</main>\n</body>\n</html>");
        }
        private void ButtonRestart_Click(object sender, RoutedEventArgs e)
        {
            MainOutput.Text = "<!DOCTYPE html>\n<html>\n<head>\n<style>\np { color: blue }" +
                "\n</style>\n</head>\n<body>\n<main>\n\n<h1>Välkomna 4C!</h1>\n<p><b>Meddelande 1:" +
                "</b> Glöm inte läxan.</p>\n<p><b>Meddelande 2:</b> Ha en bra dag!</p>\n\n<p>Kurs om C#" +
                "</p>\n<p>Kurs om Databaser</p>\n\n</main>\n</body>\n</html>";
            messages.Clear();
            courses.Clear();
            TextBoxMessage.Text = "Ha en bra dag!";
            TextBoxCourses.Text = "Databaser";
            TextBoxClassname.Text = "4C";
        }

        private void ButtonAddMessage_Click(object sender, RoutedEventArgs e)
        {
            messages.Add(TextBoxMessage.Text);
            TextBoxMessage.Text = "";
        }

        private void ButtonAddCourse_Click(object sender, RoutedEventArgs e)
        {
            courses.Add(TextBoxCourses.Text);
            TextBoxCourses.Text = "";
        }

        private void ButtonSaveFile_Click(object sender, RoutedEventArgs e)
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
                        sw.Write(MainOutput.Text);
                    }
                }
            }
        }

        private void ButtonLoadFile_Click(object sender, RoutedEventArgs e)
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
                        MainOutput.Text = sr.ReadToEnd();
                    }
                }
            }
        }
    }
}
