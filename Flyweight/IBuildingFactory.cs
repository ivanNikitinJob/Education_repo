using System.Collections.Generic;

namespace Flyweight
{
    public interface IBuildingFactory
    {
        Building BuildNewBuilding(string address, string planNameOrId);
        List<string> GetBuildingPlansNames();
        List<string> GetNamesListWithIndexes();
        BuildingPlan GetBuildingPlanByIndex(int index);
    }
}
