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
using System.IO;
using System.Text.Json;

namespace WPF___Dagens_Väderdata
{
    public partial class MainWindow : Window
    {

        List<Weather> myWeather = new List<Weather>();

        List<string> myTimes = new List<string>();

        public MainWindow()
        {
            InitializeComponent();

            for (DateTime timestart = DateTime.Parse("00:00:00"); timestart <= DateTime.Parse("23:45:00");)
            {
                timestart = timestart.AddMinutes(30);
                myTimes.Add(timestart.AddMinutes(30).ToShortTimeString());
            }

            CB_Time.ItemsSource = myTimes;

            Update();
        }
        private void Update()
        {
            MyDatePicker.SelectedDate = DateTime.Now;
            CB_Time.SelectedIndex = 0;
            City.Text = "";
            Celsius.Text = "";
            CheckBox_Blåsigt.IsChecked = false;
            CheckBox_Soligt.IsChecked = false;

            myListBox.ItemsSource = null;
            myListBox.ItemsSource = myWeather;

        }
        private void AddWeather(object sender, RoutedEventArgs e)
        {
            bool blåsigt = false;
            bool soligt = false;
            int myCelsius = 0;
            bool CelciusWasSuccessful = false;

            if (CheckBox_Blåsigt.IsChecked == true)
            {
                blåsigt = true;
            }
            if (CheckBox_Soligt.IsChecked == true)
            {
                soligt = true;
            }

            try
            {
                myCelsius = int.Parse(Celsius.Text);
                CelciusWasSuccessful = true;
            }
            catch
            {
                MessageBox.Show("Celsius kan bara visas i siffror.", "Varning");
            }

            if (CelciusWasSuccessful)
            {
                if (MyDatePicker.SelectedDate == null)
                {
                    MyDatePicker.SelectedDate = DateTime.Now;
                }

                if (CheckValid(City.Text, MyDatePicker.Text, CB_Time.Text))
                {
                    myWeather.Add(new Weather(City.Text, MyDatePicker.Text, myCelsius, CB_Time.Text, blåsigt, soligt));
                    Update();
                }
                else
                {
                    MessageBox.Show("Du har redan lagt in ett väder på denna stad, datum och tid.", "Fel");
                }
            }     
        }
        private bool CheckValid(string city, string date, string time)
        {
            if (myWeather.Count > 0)
            {
                for (int i = 0; i < myWeather.Count; i++)
                {
                    if (city == myWeather[i].City && date == myWeather[i].Date && time == myWeather[i].Time)
                        return false;
                }
            }
            
            return true;
        }
        private void RemoveWeather(object sender, RoutedEventArgs e)
        {
            if (myListBox.SelectedItem == null)
                return;

            myWeather.RemoveAt(myListBox.SelectedIndex);
            Update();
        }
        private async void Save(object sender, RoutedEventArgs e)
        {
            try
            {
                string fileName = "Weather.json";
                using FileStream fs = File.Create(fileName);
                await JsonSerializer.SerializeAsync(fs, myWeather);
                await fs.DisposeAsync();
            }
            catch
            {
                MessageBox.Show("Någonting gick fel.", "Fel");
            }
        }

        private async void Load(object sender, RoutedEventArgs e)
        {
            try
            {
                string fileName = "Weather.json";
                using FileStream fs = File.OpenRead(fileName);
                myWeather = await JsonSerializer.DeserializeAsync<List<Weather>>(fs);
                Update();
            }
            catch (JsonException ex)
            {
                MessageBox.Show(ex.Message, "Fel");
            }
            catch (NotSupportedException ex)
            {
                MessageBox.Show(ex.Message, "Fel");
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message, "Fel");
            }
        }
    }
}
