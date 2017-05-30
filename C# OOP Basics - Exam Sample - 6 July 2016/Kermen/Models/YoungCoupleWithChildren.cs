using System.Collections.Generic;
using System.Linq;

namespace Keren.Models
{
    public class YoungCoupleWithChildren : YoungCouple
    {
        private const int NumberOfRooms = 2;
        private const int RoomsCost = 30;
        private List<Child> child;

        public YoungCoupleWithChildren(decimal salary1, decimal salary2,
            decimal tvCost, decimal fridgeCost, decimal laptopCost, List<Child> child)
            : base(NumberOfRooms, RoomsCost, salary1, salary2, tvCost, fridgeCost, laptopCost)
        {
            this.child = child;
        }

        public override decimal Population => base.Population + this.child.Count;

        public override decimal Consumption
        {
            get { return base.Consumption + this.child.Sum(x => x.GetTotalConsumption()); }
        }
    }
}