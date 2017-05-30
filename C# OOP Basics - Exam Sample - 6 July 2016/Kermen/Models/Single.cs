namespace Keren.Models
{
    public abstract class Single : HouseHold
    {
        private decimal salary;
        private decimal increaceBalance;

        protected Single(int numberOfRooms, int roomsCost, decimal salary)
            : base(numberOfRooms, roomsCost)
        {
            this.increaceBalance = 0;
            this.salary = salary;
        }

        public override bool IsMonyeEnough()
        {
            if (this.increaceBalance < this.Consumption)
            {
                return false;
            }

            return true;
        }

        public override void GetSalary()
        {
            this.increaceBalance += this.salary;
        }

        public override void PayBills()
        {
            this.increaceBalance -= base.Consumption;
        }
    }
}