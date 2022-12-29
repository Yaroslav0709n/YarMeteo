using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Weather
{
    public partial class MoreInfo : Form
    {
        public MoreInfo()
        {
            InitializeComponent();
        }

        private void MoreInfo_Load(object sender, EventArgs e)
        {
            string city = label4.Text;
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&appid=8e64b2a123e77a6185055c5f159710fd";
            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();

            string response;

            using (StreamReader streamReader = new StreamReader(webresponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }
            WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(response);
            label3.Text = weatherResponse.Main.Pressure.ToString() + " mm";
            label6.Text = weatherResponse.Main.Humidity.ToString() + " %";
            sealevel.Text = weatherResponse.Main.Sea_level.ToString();
            groundlevel.Text = weatherResponse.Main.Grnd_level.ToString();
            speedwind.Text = weatherResponse.Wind.Speed.ToString() + " m/s";
            clouds.Text = weatherResponse.Clouds.All.ToString() + " %";
            //sunrise.Text = weatherResponse.Sys.Sunrise.;
            //sunset.Text = weatherResponse.Sys.Sunset.ToString();
            visibility.Text = weatherResponse.Visibility.ToString() + " km";
        }
    }
}
