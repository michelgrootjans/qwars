using System.Linq;
using NHibernate.Criterion;
using NUnit.Framework;
using QWars.NHibernate.Entities;
using QWars.Presentation.Entities;

namespace QWars.NHibernate.Tests
{
    [TestFixture]
    public class PlayerCrudTests : DataAccessTest
    {
        private object playerId;

        protected override void PrepareData()
        {
            var player = new Player("Michel");
            session.Save(player);
            playerId = session.GetIdentifier(player);
        }

        [Test]
        public void get_player_by_polymorphism()
        {
            var o = session.CreateCriteria<object>()
                .Add(Restrictions.IdEq(playerId))
                .UniqueResult();
            
            Assert.IsInstanceOf<Player>(o);
            Assert.AreEqual("Michel", (o as Player).Name);
        }

        [Test]
        public void save_player()
        {
            var player = session.Get<Player>(playerId);
            Assert.IsNotNull(player);
            Assert.AreEqual("Michel", player.Name);
            Assert.AreEqual(0, player.Money);
            Assert.AreEqual(0, player.XP);
            Assert.IsTrue(player.Weapons.Count() == 0);
        }

        [Test]
        public void execute_mugging()
        {
            var player = session.Get<Player>(playerId);
            player.Execute(new TestMugging());
            FlushAndClear();

            var playerFromDb = session.Get<Player>(playerId);
            Assert.IsTrue(playerFromDb.Money > 0);
            Assert.IsTrue((playerFromDb.XP > 0));
        }

        [Test]
        public void buy_weapon()
        {
            var player = session.Get<Player>(playerId);
            player.Buy(new Weapon("Gun", 4000, .4));
            FlushAndClear();

            var playerFromDb = session.Get<Player>(playerId);
            Assert.IsTrue(playerFromDb.Weapons.Count() == 1);
        }

        [Test]
        public void create_gang()
        {
            var player = session.Get<Player>(playerId);
            player.CreateGang("gangName", "20");
            FlushAndClear();

            var boss = session.CreateCriteria<IBoss>()
                .Add(Restrictions.IdEq(playerId))
                .UniqueResult<IBoss>();

            Assert.IsNotNull(boss);
            Assert.AreEqual("gangName", boss.GangName);
        }

    }

    public class TestMugging : ITask
    {
        public int Difficulty
        {
            get { return 0; }
        }

        public int Reward
        {
            get { return 10; }
        }

        public int XP
        {
            get { return 10; }
        }

        public void IncreaseRewardWith(double bonus)
        {
            //Not implemented
        }
    }
}