using Flyweight.Enums;
using Flyweight.IO;
using Flyweight.Models;
using System;
using System.Drawing;

namespace Flyweight.Entities
{
    public class BuildingPlan
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public Image Picture { get; set; }
        public Image Schema { get; set; }
        public int HumanCapacity { get; set; }
        public double AverageCost { get; set; }
        public BuildingType BuildingType { get; set; }

        public BuildingPlan(BuildingPlanModel model)
        {
            Name = model.Name;
            Author = model.Author;
            Picture = model.Picture;
            Schema = model.Schema;
            HumanCapacity = model.HumanCapacity;
            AverageCost = model.AverageCost;
            BuildingType = model.BuildingType;
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
