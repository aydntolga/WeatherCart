using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WeatherCart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            

            string api = "8d84d04fb22f776f8cc53b109ef071cd";
            string url = "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid="+api;
            XDocument weather = XDocument.Load(url);



            label2.Text = DateTime.Now.ToShortDateString();
            //Wind
            var wind = weather.Descendants("speed").ElementAt(0).Attribute("value").Value;
            var windUnit = weather.Descendants("speed").ElementAt(0).Attribute("unit").Value;
           
            label7.Text = wind.ToString();
            //label8.Text = windUnit.ToString();
            //Humidity
            var humidity = weather.Descendants("humidity").ElementAt(0).Attribute("value").Value;
            label10.Text = humidity + " %";
            //Min/Max Temp
            var tempMin = weather.Descendants("temperature").ElementAt(0).Attribute("min").Value;
            label14.Text = tempMin;
            var tempMax = weather.Descendants("temperature").ElementAt(0).Attribute("max").Value;
            label16.Text = tempMax;
            //Tempetrature Today
            var temp = weather.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            label4.Text = temp;
            //Weather
            var durum = weather.Descendants("clouds").ElementAt(0).Attribute("name").Value;
            label15.Text = durum;
            //durum="yağışlı";
            //Change İmage
            if (durum=="açık")
            {
                pictureBox1.ImageLocation=@"C:\Users\90555\Desktop\random.png";
            }
            if(durum=="parçalı bulutlu")
            {
                pictureBox1.ImageLocation = @"C:\Users\90555\Desktop\1555512.png";
            }
            if(durum == "yağışlı")
            {
                pictureBox1.ImageLocation = @"C:\Users\90555\Desktop\980a65fa20c0887a1342d5aa97ef9953.png";
            }
        }
 
    }
}
