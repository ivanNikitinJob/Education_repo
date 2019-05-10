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

        public void AddBuildingsAmount(int amount, string planNameOrId)
        {
            for (int i = 0; i < amount; i++)
            {
                var address = new PlaceNameGenerator().GenerateRandomPlaceName();
                Building building = _buildingFactory.BuildNewBuilding(address, planNameOrId);
                if (building == null)
                {
                    UserIO.SayToUser("New building plan added\n");
                    return;
                }

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
                stats.Add($"{property.Name} = {property.GetValue(this)}");
            }
            stats.Add(GetBuildingsCount());
            return stats;
        }

        public List<string> GetPlansAsString()
        {
            return _buildingFactory.GetBuildingPlansNames();
        }

        public BuildingPlan GetBuildingPlanFromFactoryByIndex(int index)
        {
            BuildingPlan plan = null as BuildingPlan;
            try
            {
                plan = _buildingFactory.GetBuildingPlanByIndex(index);
            }
            catch (Exception ex)
            {
                return null;
            }

            return plan;
        }
    }
}
