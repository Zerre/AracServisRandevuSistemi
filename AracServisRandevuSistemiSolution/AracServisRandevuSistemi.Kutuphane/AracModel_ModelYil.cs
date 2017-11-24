using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracServisRandevuSistemi.Kutuphane
{
    public class AracModel_ModelYil
    {
        public int modelYilId { get; set; }
        public AracModelYili aracModelYili { get; set; }
        public AracModel aracModeli { get; set; }
    }
}
