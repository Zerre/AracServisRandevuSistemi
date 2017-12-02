using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracServisRandevuSistemi.Kutuphane
{
    public class AracModel 
    {

        public AracModel(int id, string model)
        {
            modelId = id;
            modelAdi = model;
        }

        public int modelId { get; set; }
        public string modelAdi { get; set; }

        public override string ToString()
        {
            return this.modelAdi; 
        }
    }
}
