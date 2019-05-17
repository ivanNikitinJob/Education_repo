using Flyweight.Enums;
using System;
using System.Drawing;

namespace Flyweight.Models
{
    public class BuildingPlanModel
    {
        public string Name { get; set; }
        public Image Picture { get; set; }
        public Image Schema { get; set; }
        public int HumanCapacity { get; set; }
        public double Cost { get; set; }
        public double Luxury { get; set; }
        public BuildingType BuildingType { get; set; }
    }
}
