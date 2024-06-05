using System;
using System.Collections.Generic;

namespace CMS.DAL.DataModel
{
    public partial class Komentari
    {
        public int Id { get; set; }
        public int ClanakId { get; set; }
        public int CitateljId { get; set; }
        public string Sadrzaj { get; set; }
        public int Ocjena { get; set; }
        public DateTime? DatumKreiranja { get; set; }

        public virtual Citatelji Citatelj { get; set; }
        public virtual Clanci Clanak { get; set; }
    }
}
