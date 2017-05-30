namespace Keren.Models
{
    public class OldCouple : Couple
    {
        private const int NumberOfRooms = 2;
        private const int RoomsCost = 20;
        private readonly decimal stoveCost;

        public OldCouple(decimal salary1, decimal salary2,
            decimal tvCost, decimal fridgeCost, decimal stoveCost)
            : base(NumberOfRooms, RoomsCost, salary1, salary2, tvCost, fridgeCost)
        {
            this.stoveCost = stoveCost;
        }

        public override decimal Consumption => base.Consumption + this.stoveCost ;
    }
}
