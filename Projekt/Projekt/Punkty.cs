using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt
{
    public class Punkty
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Zagadka { get; set; }
        public string Odpowiedz { get; set; }
        public string Opis { get; set; }


    }
}
