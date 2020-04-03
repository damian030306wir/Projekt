using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace Projekt
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
       public async void OnButtonClicked(object sender, EventArgs e)
        {
            Trasy trasy = new Trasy()
            {
                Name = nazwaEntry.Text,
                Description = opisEntry.Text

            };

            var json = JsonConvert.SerializeObject(trasy);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();

            var result = await client.PostAsync("http://dearjean.ddns.net:44301/api/Routes", content);

            if(result.StatusCode == HttpStatusCode.Created)
            {
                await DisplayAlert("Komunikat", "Dodanie puntku przebiegło pomyślnie", "Anuluj");
            }
           
        }
        void DodajZdjecie(object sender, EventArgs e)
        {
            DisplayAlert("Sukces", "Obrazek został dodany pomyślnie", "Anuluj");
        }
        void ListaPunktowPage2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page2());
        }
        void Map(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Mapa());
        }

    }
}
