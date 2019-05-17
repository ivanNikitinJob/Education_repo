using Flyweight.Enums;
using Flyweight.IO;
using Flyweight.Models;
using Flyweight.Services;
using System;
using System.Drawing;

namespace Flyweight.Entities
{
    public class BuildingPlan
    {
        public string Name { get; set; }
        public Image Picture { get; set; }
        public Image Schema { get; set; }
        public int HumanCapacity { get; set; }
        public double Cost { get; set; }
        public double ServiceCost { get; set; }
        public double Tax { get; }
        public double Luxury { get; set; }
        public BuildingType BuildingType { get; }

        public BuildingPlan(BuildingPlanModel model)
        {
            Name = model.Name;
            Picture = model.Picture;
            Schema = model.Schema;
            HumanCapacity = model.HumanCapacity;
            Cost = model.Cost;
            BuildingType = model.BuildingType;
            Luxury = model.Luxury;

            ServiceCost = DifficultyService.GetDifficultyAsDouble() * (Luxury * HumanCapacity + Cost) / 100;
            Tax = DifficultyService.GetDifficultyAsDouble() * (Luxury * HumanCapacity + Cost) / HumanCapacity;
        }

        public void PreviewPlan()
        {
            UserIO.ShowImage(Picture);
        }

        public void LookOnSchema()
        {
            UserIO.ShowImage(Schema);
        }
    }
}
