namespace Keren.Models
{
    public abstract class Couple : HouseHold
    {
        private decimal salary1;
        private decimal salary2;
        private decimal allSalaries;
        private readonly decimal tvCost;
        private readonly decimal fridgeCost;
        private decimal increaceBalance;

        protected Couple(int numberOfRooms, int roomsCost, decimal salary1, decimal salary2, decimal tvCost,
            decimal fridgeCost)
            : base(numberOfRooms, roomsCost)
        {
            this.increaceBalance = 0;
            this.salary1 = salary1;
            this.salary2 = salary2;
            this.tvCost = tvCost;
            this.fridgeCost = fridgeCost;
        }

        public override decimal Consumption => base.Consumption + this.tvCost + this.fridgeCost;

        public override decimal Population => base.Population + 1;

        public override void GetSalary()
        {
            this.increaceBalance += this.salary2 + this.salary1;
        }

        public override bool IsMonyeEnough()
        {
            if (this.increaceBalance < this.Consumption)
            {
                return false;
            }

            return true;
        }

        public override void PayBills()
        {
            this.increaceBalance -= this.Consumption;
        }
    }
}