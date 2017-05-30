namespace Keren.Models
{
    public class AloneYoungPerson : Single
    {
        private const int NumberOfRooms = 1;
        private const int RoomsCost = 10;
        private readonly decimal laptopCost;

        public AloneYoungPerson(decimal salary, decimal laptopCost)
            : base(NumberOfRooms, RoomsCost, salary)
        {
            this.laptopCost = laptopCost;
        }

        public override decimal Consumption => base.Consumption + this.laptopCost;
    }
}
