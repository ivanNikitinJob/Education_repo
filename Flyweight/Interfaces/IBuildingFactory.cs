using Flyweight.Entities;
using System.Collections.Generic;

namespace Flyweight.Interfaces
{
    public interface IBuildingFactory
    {
        Building BuildNewBuilding(string planNameOrId);
        List<string> GetBuildingPlansNames();
        List<string> GetNamesListWithIndexes();
        BuildingPlan GetBuildingPlanByIndex(int index);
    }
}
