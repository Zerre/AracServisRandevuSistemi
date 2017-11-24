using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracServisRandevuSistemi.Kutuphane
{
    public class AracModel 
    {
        public int modelId { get; set; }
        public string modelAdi { get; set; }
        public AracMarka aracMarkasi { get; set; }
    }
}
