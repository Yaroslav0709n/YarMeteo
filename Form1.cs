using System.Net;

using Newtonsoft.Json;
using System.Net;
using System.Text.Json.Serialization;
namespace Weather
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MoreInfo moreInfo = new MoreInfo();
            moreInfo.label4.Text = label1.Text;
            moreInfo.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string city = label1.Text;
                string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&appid=8e64b2a123e77a6185055c5f159710fd";
                HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();

                string response;

                using (StreamReader streamReader = new StreamReader(webresponse.GetResponseStream()))
                {
                    response = streamReader.ReadToEnd();
                }

                WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(response);

                label1.Text = weatherResponse.Name;
                label3.Text = weatherResponse.Main.Temp.ToString() + " °C";
                label13.Text = weatherResponse.Weather[0].description;
                label7.Text = weatherResponse.Weather[0].Main;
                label9.Text = weatherResponse.Main.Temp_min.ToString() + " °C";
                label11.Text = weatherResponse.Main.Temp_max.ToString() + " °C";
                pictureBox1.BackgroundImage = weatherResponse.Weather[0].Icon;
            }
            catch (Exception err)
            {
                Close();
                MessageBox.Show("Can't to find this city");
                new SearchCity().Show();
            }
}

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            SearchCity searchCity = new SearchCity();
            searchCity.Show();
        }


    }
}