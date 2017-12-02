using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracServisRandevuSistemi.Kutuphane
{
    public class Calisan
    {
        public int calisanId { get; set; }
        public string calisanAdi { get; set; }
        public string soyadi { get; set; }
        public string cepNo { get; set; }
        public string sskNo { get; set; }
        public CalisanGorev gorev { get; set; }
    }
}
