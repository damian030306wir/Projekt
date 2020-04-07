using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System;

namespace Projekt
{
    [DesignTimeVisible(false)]
    public partial class Mapa : ContentPage
    {
        public ObservableCollection<Position> positions = new ObservableCollection<Position>();
        public Mapa() 
        {   
            InitializeComponent();
        }
        private void OnMapClicked(object sender, MapClickedEventArgs e)
        {
            Pin pin = new Pin
            {
                Label = "Punkt",
                Address = "Adres",
                Type = PinType.SavedPin,
                Position = new Position(e.Position.Latitude, e.Position.Longitude)
            };
            positions.Add(new Position(e.Position.Latitude, e.Position.Longitude));
            Polyline polyline = new Polyline
            {
                StrokeColor = Color.Blue,
                StrokeWidth = 6
            };
            foreach (Position pos in positions)
            {
                polyline.Geopath.Add(pos);
            }
            maps.Pins.Add(pin);
            maps.MapElements.Add(polyline);
        }


    }
}
