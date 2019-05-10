using Flyweight;
using System;
using System.Collections.Generic;

namespace WOFlyweight
{
    public class BadFactory : IBuildingFactory
    {
        Building IBuildingFactory.BuildNewBuilding(string address, string planNameOrId)
        {
            throw new NotImplementedException();
        }

        BuildingPlan IBuildingFactory.GetBuildingPlanByIndex(int index)
        {
            throw new NotImplementedException();
        }

        List<string> IBuildingFactory.GetBuildingPlansNames()
        {
            throw new NotImplementedException();
        }

        List<string> IBuildingFactory.GetNamesListWithIndexes()
        {
            throw new NotImplementedException();
        }
    }
}
