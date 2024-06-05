using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Model
{
    public class ClanakDomain
    {
        public int Id { get; set; }
        public string Naslov { get; set; }
        public string Sadrzaj { get; set; }
        public string Kategorija { get; set; }
        public int NovinarId { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public DateTime DatumIzmjene { get; set; }
        public byte[] Slika { get; set; }
        public int Ocjena { get; set; }
    }
}
