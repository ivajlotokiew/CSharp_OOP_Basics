namespace ReallySimpleEngine.Models.Unit
{
    public class Archer : Unit
    {
        private const int DefaultHealtValue = 25;
        private const int DefaultDamageValue = 7;

        public Archer() 
            : base(DefaultHealtValue, DefaultDamageValue)
        {
        }
    }
}
