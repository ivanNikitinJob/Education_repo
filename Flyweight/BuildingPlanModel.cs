using System;
using System.Drawing;

namespace Flyweight
{
    public class BuildingPlanModel
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public Image Picture { get; set; }
        public Image Schema { get; set; }
        public int HumanCapacity { get; set; }
        public double AverageCost { get; set; }
        public BuildingType BuildingType { get; set; }
    }
}
