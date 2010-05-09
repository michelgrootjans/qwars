using System;
using NHibernate;
using NHibernate.Criterion;
using NHibernateDemo.Entities;
using NHibernateDemo.Utilities;
using NUnit.Framework;

namespace NHibernateDemo.Tests
{
    public class LazyLoadingPlayerTest : DataAccessTest
    {
        private object playerId;

        protected override void PrepareData()
        {
            var player = new Player {Name = "playerName"};
            player.Weapons.Add(new Gun());
            session.Save(player);
            playerId = session.GetIdentifier(player);
        }

        [Test]
        public void TestLazyLoading()
        {
            var player = session.CreateCriteria<Player>()
                .Add(Restrictions.Eq("Name", "playerName"))
                .UniqueResult<Player>();

            foreach (var weapon in player.Weapons)
                Console.WriteLine(weapon.Name);
        }

        [Test]
        public void Force_eager_fetching()
        {
            var player = session.CreateCriteria<Player>()
                .Add(Restrictions.Eq("Name", "playerName"))
                .SetFetchMode("Weapons", FetchMode.Join)
                .UniqueResult<Player>();

            foreach (var weapon in player.Weapons)
                Console.WriteLine(weapon.Name);
        }
    }
}