using System.Linq;
using NHibernate.Criterion;
using NHibernateDemo.Entities;
using NUnit.Framework;
using QWars.NHibernate.Tests;

namespace NHibernateDemo.Tests
{
    public class PlayerBuysWeaponTests : DataAccessTest
    {
        private object playerId;

        protected override void PrepareData()
        {
            var michel = new Player { Name = "Danny", Money = 2000};
            session.Save(michel);
            playerId = session.GetIdentifier(michel);
        }

        [Test]
        public void player_should_be_able_to_buy_a_weapon()
        {
            var player = session.Get<Player>(playerId);
            player.Buy(new Weapon("Gun", 1500));
            FlushAndClear();

            var playerFromDb = session.Get<Player>(playerId);
            Assert.AreEqual(1, playerFromDb.Weapons.Count());
            Assert.AreEqual("Gun", playerFromDb.Weapons.First().Name);
        }

        [Test]
        public void player_money_should_be_less()
        {
            var player = session.Get<Player>(playerId);
            player.Buy(new Weapon("Gun", 1500));
            FlushAndClear();

            var playerFromDb = session.Get<Player>(playerId);
            Assert.AreEqual(500, playerFromDb.Money);
        }

        [Test]
        public void find_players_with_guns_with_HQL()
        {
            var player = session.Get<Player>(playerId);
            player.Buy(new Weapon("Gun", 1500));
            FlushAndClear();

            var players = session.CreateCriteria<Player>()
                .CreateAlias("Weapons", "w")
                .Add(Restrictions.Eq("w.Name", "Gun"))
                .List<Player>();
            Assert.AreEqual(1, players.Count);
        }


    }
}