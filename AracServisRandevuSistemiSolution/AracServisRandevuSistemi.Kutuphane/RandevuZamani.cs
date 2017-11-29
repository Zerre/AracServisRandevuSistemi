using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracServisRandevuSistemi.Kutuphane
{
    public class RandevuZamani
    {
        public int randevuZamanId { get; set; }
        public DateTime randevuGunu { get; set; }
        public RandevuSaati randevuSaati { get; set; }
    }
}
