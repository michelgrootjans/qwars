using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernateDemo.Entities;
using NUnit.Framework;
using QWars.NHibernate.Tests;

namespace NHibernateDemo.Tests
{
    public class PlayerCrudTests : DataAccessTest
    {
        private object playerId;

        protected override void PrepareData()
        {
            var michel = new Player {Name = "Danny"};
            session.Save(michel);
            playerId = session.GetIdentifier(michel);
            session.Save(new Player {Name = "Michel"});
        }

        [Test]
        public void Get_Player_Returns_a_Player()
        {
            var player = session.Get<Player>(playerId);
            Assert.IsNotNull(player);
        }

        [Test]
        public void Get_Player_returns_the_right_player()
        {
            var player = session.Get<Player>(playerId);
            Assert.AreEqual("Danny", player.Name);
        }

        [Test]
        public void Query_with_HQL_for_player()
        {
            var players = session.CreateQuery("from Player").List();
            Assert.AreEqual(2, players.Count);
        }

        [Test]
        public void Query_specific_player_with_HQL()
        {
            var player = session.CreateQuery("from Player p where p.Name=:name")
                .SetParameter("name", "Danny")
                .UniqueResult<Player>();
            Assert.AreEqual("Danny", player.Name);
        }

        [Test]
        public void Query_specific_player_with_criteria()
        {
            var player = session.CreateCriteria<Player>()
                .Add(Restrictions.Eq("Name", "Danny"))
                .UniqueResult<Player>();
            Assert.AreEqual("Danny", player.Name);
        }

        [Test]
        public void future_queries()
        {
            var danny = session.CreateCriteria<Player>()
                .Add(Restrictions.Eq("Name", "Danny"))
                .FutureValue<Player>();
            var michel = session.CreateCriteria<Player>()
                .Add(Restrictions.Eq("Name", "Michel"))
                .FutureValue<Player>();

            Assert.AreEqual("Danny", danny.Value.Name);
            Assert.AreEqual("Michel", michel.Value.Name);
        }

    }
}