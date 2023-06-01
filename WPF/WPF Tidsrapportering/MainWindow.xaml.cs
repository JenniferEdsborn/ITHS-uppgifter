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

namespace WPF_Tidsrapportering
{
    public partial class MainWindow : Window
    {
        List<Worker> workers = new List<Worker>();
        List<string> Times = new List<string>();

        public MainWindow()
        {
            InitializeComponent();

            for (DateTime timestart = DateTime.Parse("00:00:00"); timestart <= DateTime.Parse("23:45:00");)
            {
                timestart = timestart.AddMinutes(30);
                Times.Add(timestart.AddMinutes(30).ToShortTimeString());
            }

            TimeBox.ItemsSource = Times;
            this.WorkDate.SelectedDate = DateTime.Now;

        }

        public void UpdateContent()
        {
            Result_ListBox.ItemsSource = null;
            Result_ListBox.ItemsSource = workers;

            BoxWorkerID.Text = "";
            TextBox_Work.Text = "";
        }

        private void AddWork(object sender, RoutedEventArgs e)
        {
            string[] timeArray = TimeBox.Text.Split(":");
            int[] timeInt = { Int32.Parse(timeArray[0]),
                Int32.Parse(timeArray[1])};

            try
            {
                string[] dateArray = WorkDate.Text.Split("-");
                int[] dateInt = { Int32.Parse(dateArray[0]),
                Int32.Parse(dateArray[1]),
                Int32.Parse(dateArray[2]) };

                DateTime dateWorked = new DateTime(dateInt[0],
                     dateInt[1],
                     dateInt[2],
                     timeInt[0],
                     timeInt[1],
                     0);

                workers.Add(new Worker(BoxWorkerID.Text, TextBox_Work.Text, dateWorked));
                MessageBox.Show("Bra jobbat!", "Jobb tillagt", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
            UpdateContent();
        }

        private void RemoveWork(object sender, RoutedEventArgs e)
        {
            try
            {
                workers.RemoveAt(Result_ListBox.SelectedIndex);
            }
            catch
            {
                MessageBox.Show("Något gick fel", "Fel", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            UpdateContent();
        }
    }    
}
