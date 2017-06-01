using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccessLayer;

namespace LogicLayer
{
    public class GardenerManager : IGardenerManager
    {
        private List<Gardener> _gardeners= null;

        public List<Gardener> GetGardenerList(bool active = true)
        {
            try
            {
                return GardenerAccessor.RetrieveUsers(active);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

