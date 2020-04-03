using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projekt
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        public Page2()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using(SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Punkty>();
                var punktyy = conn.Table<Punkty>().ToList();
                listaPunktow.ItemsSource = punktyy;

            }
        }
        void DodajTrase(object sender, EventArgs e)
        {
            DisplayAlert("Sukces", "Trasa została dodana pomyślnie", "Anuluj");
        }
        void ListaTrasPage3(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page3());
        }
    }
}