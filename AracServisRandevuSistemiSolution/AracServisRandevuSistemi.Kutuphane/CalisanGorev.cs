using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracServisRandevuSistemi.Kutuphane
{
    public class CalisanGorev
    {
        public int gorevId { get; set; }
        public string gorevAdi { get; set; }
        public List<Calisan> calisanlar { get; set; }
    }
}
