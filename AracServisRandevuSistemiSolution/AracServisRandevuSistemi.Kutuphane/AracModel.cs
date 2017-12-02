using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracServisRandevuSistemi.Kutuphane
{
    public class AracModel 
    {
        public AracModel(int id,int markaid, string modelisim)
        {
            modelId= id;
            modelAdi = modelisim;
            markaId = markaid;

        }
        public int modelId { get; set; }
        public string modelAdi { get; set; }
        public int markaId { get; set; }
    }
}
