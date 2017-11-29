using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracServisRandevuSistemi.Kutuphane
{
    public class Randevu
    {
        public int randevuId { get; set; }
        public Musteri musteri { get; set; }
        public Lift lift { get; set; }
        public RandevuZamani randevuZamani { get; set; }
        public string yapilacakIslem { get; set; }
        public bool saatGectiMi { get; set; }
        public bool bakimYapildiMi { get; set; }
        public Calisan calisan { get; set; }
    }
}
