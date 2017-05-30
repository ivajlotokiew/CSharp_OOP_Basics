namespace Keren.Models
{
    public abstract class HouseHold
    {
        private readonly int numberOfRooms;
        private readonly int roomsCost;

        protected HouseHold(int numberOfRooms, int roomsCost)
        {
            this.numberOfRooms = numberOfRooms;
            this.roomsCost = roomsCost;

        }

        public virtual decimal Consumption => this.roomsCost * this.numberOfRooms;

        public virtual decimal Population => 1;

        public abstract void GetSalary();

        public abstract void PayBills();

        public abstract bool IsMonyeEnough();
    }
}