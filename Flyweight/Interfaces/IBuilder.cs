using Flyweight.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyweight.Interfaces
{
    interface IBuilder
    {
        void BuildAsync(BuildingPlan selectPlan);
        Building GetBuilding();
    }
}
