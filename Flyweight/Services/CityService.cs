using Flyweight.Entities;
using Flyweight.Factories;
using Flyweight.Interfaces;
using Flyweight.IO;
using RandomNameGeneratorLibrary;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;

namespace Flyweight.Services
{
    public class CityService
    {
        private IBuildingFactory _buildingFactory;
        private City _city;
        private RedisClient _redisClient;
        private List<Building> _cityBuildings;

        public CityService(City city)
        {
            _buildingFactory = new BuildingFactory();
            _city = city;
            _cityBuildings = _city.GetBuildings();
            _redisClient = new RedisClient("localhost");
        }

        public void AddBuildingsAmount(int amount, string planNameOrId)
        {
            for (int i = 0; i < amount; i++)
            {
                var address = new PlaceNameGenerator().GenerateRandomPlaceName();
                Building building = _buildingFactory.BuildNewBuilding(planNameOrId);
                if (building == null)
                {
                    UserIO.SayToUser("New building plan added\n");
                    return;
                }

                _cityBuildings.Add(building);
            }

            _redisClient.Set($"{_city.buildingsRedisKey}{_city.Name.ToLower()}", _cityBuildings);
        }

        public string GetBuildingsCount()
        {
            return $"Building count = {_cityBuildings.Count}";
        }

        public List<string> GetStats()
        {
            List<string> stats = new List<string>();

            foreach (var property in _city.GetType().GetProperties())
            {
                stats.Add($"{property.Name} = {property.GetValue(_city)}");
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
