using System.Collections.Generic;
using DataObjects;

namespace LogicLayer
{
    public interface IPlantManager
    {
        bool CreatePlant(Plant plant);
        bool DeletePlant(Plant plant);
        bool EditPlant(Plant oldPlant, Plant newPlant);
        List<Plant> RetrieveAllPlants();
        List<Plant> RetrieveSelectedPlants(string soilType, string growingZone);
        Plant RetrievePlantByID(int plantID);
    }
}