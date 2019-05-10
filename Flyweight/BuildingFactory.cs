using System;
using System.Collections.Generic;
using System.Linq;

namespace Flyweight
{
    public class BuildingFactory : IBuildingFactory
    {
        private List<BuildingPlan> _buildingPlans;

        public BuildingFactory()
        {
            _buildingPlans = new List<BuildingPlan>();
        }
        public Building BuildNewBuilding(string address, string planNameOrId)
        {
            int indexOfPlan;
            BuildingPlan selectPlan = null as BuildingPlan;

            if (Int32.TryParse(planNameOrId, out indexOfPlan))
            {
                try
                {
                    selectPlan = _buildingPlans.ElementAt(indexOfPlan);
                }
                catch (Exception ex)
                {
                    selectPlan = null as BuildingPlan;
                    UserIO.SayToUser("No plan with this index");
                }
            }
            if (selectPlan == null)
            {
                selectPlan = _buildingPlans.Where(splan => splan.Name == planNameOrId)
                  .OrderBy(x => x.AverageCost)
                  .FirstOrDefault();
            }
            if (selectPlan == null)
            {
                selectPlan = CreateNewBuildingPlan();
                _buildingPlans.Add(selectPlan);
                return null;
            }

            var building = null as Building;

            if (selectPlan != null)
            {
                building = new Building(address, selectPlan);
            }

            if (selectPlan == null)
            {
                var newPlan = UserIO.GetUserAnswer("Input building plan do you want to build?");
                building = BuildNewBuilding(address, newPlan);
            }

            return building;
        }

        public List<string> GetBuildingPlansNames()
        {
            List<string> namesList = _buildingPlans.Select(x => $"{x.Name}={_buildingPlans.IndexOf(x)}").ToList();
            return namesList;
        }

        private BuildingPlan CreateNewBuildingPlan()
        {
            BuildingPlanModel planModel = new BuildingPlanModel();
            UserIO.SayToUser("No plan found, create new?");
            var answer = UserIO.GetUserYN();

            if ((bool)answer)
            {
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

            return null;
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
