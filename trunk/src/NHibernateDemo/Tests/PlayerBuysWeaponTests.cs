using System.Linq;
using NHibernate.Criterion;
using NHibernateDemo.Entities;
using NHibernateDemo.Utilities;
using NUnit.Framework;

namespace NHibernateDemo.Tests
{
    public class PlayerBuysWeaponTests : DataAccessTest
    {
        private object michelId;

        protected override void PrepareData()
        {
            var michel = new Player { Name = "Danny", Money = 2000};
            session.Save(michel);
            michelId = session.GetIdentifier(michel);
        }

        [Test]
        public void player_should_be_able_to_buy_a_weapon()
        {
            var player = session.Get<Player>(michelId);
            player.Buy(new Gun());
            FlushAndClear();

            var playerFromDb = session.Get<Player>(michelId);
            Assert.AreEqual(1, playerFromDb.Weapons.Count());
            Assert.IsInstanceOf<Gun>(playerFromDb.Weapons.First());
            Assert.AreEqual(1500, playerFromDb.Weapons.First().Price);
        }

        [Test]
        public void player_money_should_be_less()
        {
            var player = session.Get<Player>(michelId);
            player.Buy(new Gun());
            FlushAndClear();

            var playerFromDb = session.Get<Player>(michelId);
            Assert.AreEqual(500, playerFromDb.Money);
        }

        [Test]
        public void find_players_with_guns_with_HQL()
        {
            var player = session.Get<Player>(michelId);
            player.Buy(new Gun());
            FlushAndClear();

            var players = session.CreateCriteria<Player>()
                .CreateAlias("Weapons", "w")
                .Add(Restrictions.Eq("w.Price", 1500))
                .List<Player>();
            Assert.AreEqual(1, players.Count);
        }


    }
}