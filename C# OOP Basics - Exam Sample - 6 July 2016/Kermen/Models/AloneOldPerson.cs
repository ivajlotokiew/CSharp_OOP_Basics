namespace Keren.Models
{
    public class AloneOldPerson : Single
    {
        private const int NumberOfRooms = 1;
        private const int RoomsCost = 15;


        public AloneOldPerson(decimal salary)
            : base(NumberOfRooms, RoomsCost, salary)
        {
        }
    }
}

