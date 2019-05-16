using System.Collections.Generic;
using Flyweight.Services;
using ServiceStack.Redis;

namespace Flyweight.Entities
{
    public class City
    {
        private List<Building> _buildings;
        private RedisClient _redisClient;
        private CityService _cityService;

        public readonly string buildingsRedisKey = "b";

        public string Name { get; set; }
        public string ElPrezedenteName { get; set; }
        public int Population { get; set; }
        public double Budget { get; set; }
        public int Happiness { get; set; }

        public City(string name)
        {
            _redisClient = new RedisClient("localhost");

            Name = name;
            _buildings = _redisClient.Get<List<Building>>($"{buildingsRedisKey}{Name.ToLower()}");

            if (_buildings == null)
            {
                _buildings = new List<Building>();
            }
            _cityService = new CityService(this);
        }

        public List<Building> GetBuildings()
        {
            return _buildings;
        }

        public void AddBuildingsAmount(int amount, string planNameOrId)
        {
            _cityService.AddBuildingsAmount(amount, planNameOrId);
        }

        public string GetBuildingsCount()
        {
            return _cityService.GetBuildingsCount();
        }

        public List<string> GetStats()
        {
            return _cityService.GetStats();
        }

        public List<string> GetPlansAsString()
        {
            return _cityService.GetPlansAsString();
        }

        public BuildingPlan GetBuildingPlanFromFactoryByIndex(int index)
        {
            return _cityService.GetBuildingPlanFromFactoryByIndex(index);
        }
    }
}
