using System.Collections.Generic;
using DataObjects;

namespace LogicLayer
{
    public interface IGardenerManager
    {
        List<Gardener> GetGardenerList(bool active = true);
    }
}