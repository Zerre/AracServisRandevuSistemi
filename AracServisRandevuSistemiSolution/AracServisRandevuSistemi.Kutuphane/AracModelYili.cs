using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracServisRandevuSistemi.Kutuphane
{
    public class AracModelYili
    {
        public int yilId { get; set; }
        public string aracinModelYili { get; set; }

        public override string ToString()
        {
            return this.aracinModelYili;
        }
    }
}
