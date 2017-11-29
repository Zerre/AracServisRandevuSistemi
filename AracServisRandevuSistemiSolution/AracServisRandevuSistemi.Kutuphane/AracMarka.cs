using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracServisRandevuSistemi.Kutuphane
{
    public class AracMarka
    {
        public int aracMarkaId { get; set; }
        public string markaAdi { get; set; }
        public List<AracModel> modeller { get; set; }
    }
}
