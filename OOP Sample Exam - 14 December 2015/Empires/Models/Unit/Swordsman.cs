namespace ReallySimpleEngine.Models.Unit
{
    public class Swordsman : Unit
    {
        private const int DefaultHealtValue = 40;
        private const int DefaultDamageValue = 13;

        public Swordsman() 
            : base(DefaultHealtValue, DefaultDamageValue)
        {
        }
    }
}