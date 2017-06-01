using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class Plant
    {
        public int PlantID { get; set; }
        public int ContributorID { get; set; }
        public string CommonName { get; set; }
        public string ScientificName { get; set; }
        public string Care { get; set; }
        public string GrowingZone { get; set; }
        public string SoilType { get; set; }
        public bool Active { get; set; }
        //public byte[] Image { get; set; }

    }
}
