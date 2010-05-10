using System;
using NHibernate.Criterion;
using NHibernateDemo.Entities;
using NHibernateDemo.Utilities;
using NUnit.Framework;

namespace NHibernateDemo.Tests
{
    public class TestPolymorphism : DataAccessTest
    {
        protected override void PrepareData()
        {
            var player = new Player {Name = "Danny"};
            player.Buy(new Gun());
            player.Buy(new Sword());
            player.Buy(new Knife());
            session.Save(player);
        }

        [Test]
        public void query_danny()
        {
            var danny = session.CreateCriteria<Player>()
                .Add(Restrictions.Eq("Name", "Danny"))
                .UniqueResult<Player>();

            foreach (var weapon in danny.Weapons)
            {
                Console.WriteLine(weapon.Name);
            }
        }

        [Test]
        public void query_weapon()
        {
            var dannysWeapons = session.CreateCriteria<Weapon>()
                .CreateAlias("Owner", "o")
                .Add(Restrictions.Eq("o.Name", "Danny"))
                .List<Weapon>();

            foreach (var weapon in dannysWeapons)
            {
                Console.WriteLine(weapon.Name);
            }
        }


    }
}