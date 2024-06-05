using System;
using System.Collections.Generic;

namespace CMS.DAL.DataModel
{
    public partial class Clanci
    {
        public Clanci()
        {
            Komentari = new HashSet<Komentari>();
        }

        public int Id { get; set; }
        public string Naslov { get; set; }
        public string Sadrzaj { get; set; }
        public string Kategorija { get; set; }
        public int NovinarId { get; set; }
        public DateTime? DatumKreiranja { get; set; }
        public DateTime? DatumIzmjene { get; set; }
        public byte[] Slika { get; set; }
        public int? Ocjena { get; set; }

        public virtual Novinari Novinar { get; set; }
        public virtual ICollection<Komentari> Komentari { get; set; }
    }
}
