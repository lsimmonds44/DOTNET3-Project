using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataObjects;

namespace LogicLayer
{
    public class PlantManager : IPlantManager
    {
        public List<Plant> RetrieveAllPlants()
        {
            List<Plant> plants = null;
            try
            {
                plants = PlantAccessor.RetrieveFullPlantList(true);
            }
            catch (Exception)
            {
                throw;
            }
            return plants;
        }

        public List<Plant> RetrieveSelectedPlants(string soilType, string growingZone)
        {
            List<Plant> plants = null;
            try
            {
                plants = PlantAccessor.RetrievePlantsByZoneSoil(soilType, growingZone);
            }
            catch (Exception)
            {
                throw;
            }
            return plants;
        }

        public bool CreatePlant(Plant plant)
        {
            try
            {
                PlantAccessor.InsertPlant(plant);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditPlant(Plant oldPlant, Plant newPlant)
        {
            try
            {
                return (PlantAccessor.UpdatePlant(oldPlant, newPlant) == 1);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeletePlant(Plant plant)
        {
            try
            {
                return (PlantAccessor.DeletePlant(plant.PlantID) == 1);
            }
            catch (Exception)
            {
                return false;
            }
        }


        public Plant RetrievePlantByID(int plantID)
        {
            Plant plant = null;

            try
            {
                plant = PlantAccessor.RetrievePlant(plantID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("There was a problem retrieving the product details.", ex);
            }
            return plant;
        }
    }
}
