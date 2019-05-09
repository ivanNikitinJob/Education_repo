using System;
using System.Collections.Generic;
using RandomNameGeneratorLibrary;
using ServiceStack.Redis;

namespace Flyweight
{
    class City
    {
        private BuildingFactory _buildingFactory;
        private List<Building> _buildings;
        private RedisClient _redisClient;

        private readonly string _buildingsRedisKey = "b";

        public string Name { get; set; }
        public string ElPrezedenteName { get; set; }
        public int Population { get; set; }
        public double Budget { get; set; }
        public int Happiness { get; set; }

        public City(string name)
        {
            _buildingFactory = new BuildingFactory();
            _redisClient = new RedisClient("localhost");

            Name = name;
            _buildings = _redisClient.Get<List<Building>>($"{_buildingsRedisKey}{Name.ToLower()}");

            if (_buildings == null)
            {
                _buildings = new List<Building>();
            }
        }

        public void AddBuildingsAmount(int amount, string planName)
        {
            for (int i = 0; i < amount; i++)
            {
                var address = new PlaceNameGenerator().GenerateRandomPlaceName();
                Building building = _buildingFactory.BuildNewBuilding(address, planName);

                _buildings.Add(building);
            }

            _redisClient.Set($"{_buildingsRedisKey}{Name.ToLower()}", _buildings);
        }

        public string GetBuildingsCount()
        {
            return $"Building count = {_buildings.Count}";
        }

        public List<string> GetStats()
        {
            List<string> stats = new List<string>();

            foreach (var property in this.GetType().GetProperties())
            {
                Console.WriteLine($"{property.Name} = {property.GetValue(this)}");
            }

            return stats;
        }

        public List<string> GetPlansAsString()
        {
            return _buildingFactory.GetBuildingPlansNames();
        }

        public BuildingPlan GetBuildingPlanFromFactoryByIndex(int index)
        {
            return _buildingFactory.GetBuildingPlanByIndex(index);
        }
    }
}
