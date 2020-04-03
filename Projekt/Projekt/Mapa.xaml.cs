using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;


namespace Projekt
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Mapa : ContentPage
    {
        private bool hasLocationPermission = false;
        public Mapa()
        {
            InitializeComponent();
            GetPermission();
        }

        private async void GetPermission() // wyswietlanie lokalizacji - zezwolenie na dostep
        {
            try {


                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.LocationWhenInUse);
                if (status != PermissionStatus.Granted)
                {
                    if(await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.LocationWhenInUse))
                    {
                        await DisplayAlert("Zapytanie o lokalizację", "Twoja lokalizacja potrzebuje potwierdzenia dostępu", "OK");
                    }
                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.LocationWhenInUse);
                    if (results.ContainsKey(Permission.LocationWhenInUse))
                    {
                        status = results[Permission.LocationWhenInUse];
                    }
                }
                if (status == PermissionStatus.Granted)
                {
                    hasLocationPermission = true;
                    MyMap.IsShowingUser = true;
                    GetLocation();
                }
                else
                {
                    await DisplayAlert("Błąd lokalizacji", "Nie można wyświetlić twojej lokalizacji na mapie", "OK");
                }
            
            }
            catch (Exception ex)
            {

            }
        }

        private async void GetLocation()
        {
            if (hasLocationPermission)
            {

                var locator = CrossGeolocator.Current;
                var position = await locator.GetPositionAsync();
                movemap(position);
            }
        }

        private void movemap(Position position)
        {
            var centermap = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);
            var localmapspan = new Xamarin.Forms.Maps.MapSpan(centermap, 2, 2);
            MyMap.MoveToRegion(localmapspan);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (hasLocationPermission)
            {
                var locator = CrossGeolocator.Current;
                locator.PositionChanged += Locator_PositionChanged;
                await locator.StartListeningAsync(TimeSpan.Zero, 100);
                GetLocation();
            }
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            
            CrossGeolocator.Current.StartListeningAsync(TimeSpan.Zero, 100);
            CrossGeolocator.Current.PositionChanged -= Locator_PositionChanged;
        }
        private void Locator_PositionChanged(object sender, PositionEventArgs e)
        {
            movemap(e.Position);
        }

    }
}