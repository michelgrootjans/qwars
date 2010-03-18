using System;
using System.Collections.Generic;
using System.Linq;
using QWars.Presentation.Entities;
using QWars.Presentation.Helpers;

namespace QWars.Dummy.Entities
{
    //NOTE: do not implement both IPlayer and PlayerInfo in the same class!
    //They are for different purposes:
    //IPlayer is an entity
    //PlayerInfo is a DTO passsed between different forms
    public class Player : IPlayer
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Money { get; private set; }
        public int XP { get; private set; }
        private readonly List<IWeapon> weapons;

        public Player(int id, string name)
        {
            Id = id;
            Name = name;
            weapons = new List<IWeapon>();
        }

        public override string ToString()
        {
            return Name;
        }

        public IEnumerable<IWeapon> Weapons
        {
            get { return weapons.Cast<IWeapon>(); }
        }

        public void Buy(IWeapon weapon)
        {
            //TODO: price handling
            weapons.Add(weapon);
        }

        public void Execute(ITask task)
        {
            var calculator = new TaskCalculator(this, task);
            Money += calculator.MoneyEarned;
            XP += calculator.XpEarned;
        }

        public void Join(IGang gang)
        {
            throw new NotImplementedException();
        }

        public void SellUnusedWeapons()
        {
            throw new NotImplementedException();
        }
    }
}