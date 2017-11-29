using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracServisRandevuSistemi.Kutuphane
{
    public class Musteri_Arac
    {
        public int musteriAracId { get; set; }
        public Musteri musteri { get; set; }
        public AracModel arac { get; set; }
        public AracModelYili modelYili { get; set; }
        public string plakaNo { get; set; }
    }
}
