using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataObjects;

namespace LogicLayer
{
    public class InsectManager : IInsectManager
    {
        public List<Insect> RetrieveSelectedInsects(string growingZone)
        {
            List<Insect> insects = null;
            try
            {
                insects = InsectAccessor.RetrieveInsectsByZone(growingZone);
            }
            catch (Exception)
            {
                throw;
            }
            return insects;
        }

        public List<Insect> RetrieveAllInsects()
        {
            List<Insect> insects = null;
            try
            {
                insects = InsectAccessor.RetrieveFullInsectList(true);
            }
            catch (Exception)
            {
                throw;
            }
            return insects;
        }
    }




}
