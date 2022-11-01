using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WPF___Dagens_Väderdata
{
    public class Weather
    {
        public string City { get; set; }
        public string Date { get; set; }
        public int Celsius { get; set; }
        public string Time { get; set; }
        public bool Windy { get; set; }
        public bool Sunny { get; set; }

        public Weather(string city, string date, int celsius, string time, bool windy, bool sunny)
        {
            City = city;
            Date = date; 
            Celsius = celsius;
            Time = time;
            Windy = windy;
            Sunny = sunny;
        }
        public override string ToString()
        {
            string IsSunny = "";
            string IsWindy = "";

            if (Windy)
            {
                IsWindy = "Blåsigt";
            }

            if (Sunny)
            {
                IsSunny = "Soligt";
            }

            return $"{City} {Date} {Time} {Celsius} {IsWindy.Trim()} {IsSunny.Trim()}";
        }
    }
}
