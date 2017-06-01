using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class Insect
    {
        public int InsectID { get; set; }
        public int ContributorID { get; set; }
        public string CommonName { get; set; }
        public string ScientificName { get; set; }
        public string InsectType { get; set; }
        public string GrowingZone { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
