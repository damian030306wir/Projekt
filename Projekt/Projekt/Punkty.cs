using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace Projekt
{
    public class Punkty 
    {
        [PrimaryKey, AutoIncrement]
        
        public string Nazwa { get; set; }
        public string Zagadka { get; set; }
        public string Odpowiedz { get; set; }
        public string Opis { get; set; }


    }
}
