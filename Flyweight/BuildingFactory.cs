using System;
using System.Collections.Generic;
using System.Linq;

namespace Flyweight
{
    public class BuildingFactory
    {
        private List<BuildingPlan> _buildingPlans;

        public BuildingFactory()
        {
            _buildingPlans = new List<BuildingPlan>();
        }
        public Building BuildNewBuilding(string address, string planName)
        {
            var selectPlan = _buildingPlans.Where(splan => splan.Name == planName)
                .OrderBy(x => x.AverageCost)
                .FirstOrDefault();

            if (selectPlan == null)
            {

                selectPlan = CreateNewBuildingPlan();
            }

            _buildingPlans.Add(selectPlan);

            var building = new Building(address, selectPlan);

            return building;
        }

        public List<string> GetBuildingPlansNames()
        {
            List<string> namesList = _buildingPlans.Select(x => x.Name).ToList();
            return namesList;
        }

        private BuildingPlan CreateNewBuildingPlan()
        {
            BuildingPlanModel planModel = new BuildingPlanModel();

            planModel.Author = UserIO.GetUserAnswer("Author of plan name?");
            planModel.Name = UserIO.GetUserAnswer("Plan name?");
            planModel.AverageCost = Convert.ToDouble(UserIO.GetUserAnswer("Average building cost?"));
            planModel.HumanCapacity = Convert.ToInt32(UserIO.GetUserAnswer("Human capacity?"));
            planModel.BuildingType = UserIO.GetBuildingType("Select building type");
            planModel.Picture = UserIO.GetImage("Select plan preview image");
            planModel.Schema = UserIO.GetImage("Select plan Schema");

            BuildingPlan buildingPlan = new BuildingPlan(planModel);
            return buildingPlan;
        }

        public List<string> GetNamesListWithIndexes()
        {
            List<string> result = _buildingPlans.Select(x => $"{x.Name} = {_buildingPlans.IndexOf(x)}").ToList();
            return result;
        }

        public BuildingPlan GetBuildingPlanByIndex(int index)
        {
            BuildingPlan plan = _buildingPlans.ElementAt(index);
            return plan;
        }
    }
}
