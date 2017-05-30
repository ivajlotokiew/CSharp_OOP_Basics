namespace Keren.Models
{
    public class YoungCouple : Couple
    {
        private const int NumberOfRooms = 2;
        private const int RoomsCost = 20;
        private readonly decimal laptopCost;

        public YoungCouple(decimal salary1, decimal salary2,
            decimal tvCost, decimal fridgeCost, decimal laptopCost)
            : base(NumberOfRooms, RoomsCost, salary1, salary2, tvCost, fridgeCost)
        {
            this.laptopCost = laptopCost;
        }

        protected YoungCouple(int numberOfRooms, int roomsCost, decimal salary1, decimal salary2, decimal tvCost, 
            decimal fridgeCost, decimal laptopCost) 
            : base(numberOfRooms, roomsCost, salary1, salary2, tvCost, fridgeCost)
        {
            this.laptopCost = laptopCost;
        }

        public override decimal Consumption => base.Consumption + 2 * this.laptopCost;
    }
}
