namespace Empires.Models.Units
{
    public class Archer : Unit
    {
        private const int DefaultArcherDamage = 7;
        private const int DefaultArcherHealth = 25;

        public Archer()
            : base(DefaultArcherDamage, DefaultArcherHealth)
        {
        }
    }
}
