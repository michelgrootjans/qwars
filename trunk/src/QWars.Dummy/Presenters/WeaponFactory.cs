using QWars.Dummy.Entities;
using QWars.Presentation.Entities;

namespace QWars.Dummy.Presenters
{
    public class WeaponFactory
    {
        public static IWeapon Club
        {
            get { return new Weapon("Club", 50, 0.05); }
        }

        public static IWeapon Knife
        {
            get { return new Weapon("Knife", 120, 0.10); }
        }

        public static IWeapon Taser
        {
            get { return new Weapon("Taser", 350, 0.20); }
        }

        public static IWeapon Gun
        {
            get { return new Weapon("Gun", 750, 0.45); }
        }

        public static IWeapon Bomb
        {
            get { return new Weapon("Bomb", 1500, 0.75); }
        }
    }
}