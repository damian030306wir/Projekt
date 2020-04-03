using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;



using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Xml.Linq;

namespace Projekt
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page3 : ContentPage
    {
        public Page3()
        {
            InitializeComponent();

            GetRoutes();

        }

        private async void GetRoutes()
        {

            HttpClient client = new HttpClient();

            var response = await client.GetStringAsync("http://dearjean.ddns.net:44301/api/Routes");

            var trasy = JsonConvert.DeserializeObject<List<Trasy>>(response);

            listaTras.ItemsSource = trasy;

        }
    }
}