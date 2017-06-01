using System.Collections.Generic;
using DataObjects;

namespace LogicLayer
{
    public interface IInsectManager
    {
        List<Insect> RetrieveSelectedInsects(string growingZone);

        List<Insect> RetrieveAllInsects();
    }
}