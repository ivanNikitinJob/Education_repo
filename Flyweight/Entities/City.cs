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
        public readonly double starerCash = 10000;

        public string Name { get; set; }
        public string ElPrezedenteName { get; set; }
        public int Population { get; set; }
        public double Budget { get; set; }
        public int Happiness { get; set; }
        public int Day { get; set; }

        public City(string name)
        {
            _redisClient = new RedisClient("localhost");

            Day = 0;
            Name = name;
            Budget = starerCash;
            _buildings = _redisClient.Get<List<Building>>($"{buildingsRedisKey}{Name.ToLower()}");

            if (_buildings == null)
            {
                _buildings = new List<Building>();
            }
            _cityService = new CityService(this);
        }

        public List<Building> GetBuildings() => _buildings;
        public void AddBuildingsAmount(int amount, string planNameOrId) => _cityService.AddBuildingsAmount(amount, planNameOrId);
        public string GetBuildingsCount() => _cityService.GetBuildingsCount();
        public List<string> GetStats() => _cityService.GetStats();
        public List<string> GetPlansAsString() => _cityService.GetPlansAsString();
        public BuildingPlan GetBuildingPlanFromFactoryByIndex(int index) => _cityService.GetBuildingPlanFromFactoryByIndex(index);
        public bool Buy(double money)
        {
            if (Budget < money)
            {
                return false;
            }
            Budget -= money;

            return true;
        }

        public async void GatherTaxes()
        {
            await _cityService.GatherTaxesAsync();
        }

        public async void PayForService()
        {
            await _cityService.PayForBuildingsAsync();
        }
    }
}
