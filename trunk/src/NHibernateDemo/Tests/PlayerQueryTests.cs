using System.Linq;
using NHibernate.Criterion;
using NHibernateDemo.Entities;
using NHibernateDemo.Utilities;
using NUnit.Framework;
using NHibernate.Linq;

namespace NHibernateDemo.Tests
{
    public class PlayerQueryTests : DataAccessTest
    {
        private const int NUMBER_OF_PLAYERS = 100;

        protected override void PrepareData()
        {
            session.Save(new Player {Name = "Michel"});
            session.Save(new Player {Name = "Danny"});
            for (var i = 0; i < NUMBER_OF_PLAYERS; i++)
            {
                session.Save(new Player{Name = "Player " + i});
            }
        }

        [Test]
        public void Query_with_HQL_for_player()
        {
            var players = session.CreateQuery("from Player").List();
            Assert.AreEqual(NUMBER_OF_PLAYERS + 2, players.Count);
        }

        [Test]
        public void Query_specific_player_with_HQL()
        {
            var player = session.CreateQuery("from Player p where p.Name=:name")
                .SetParameter("name", "Michel")
                .UniqueResult<Player>();
            Assert.AreEqual("Michel", player.Name);
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
        public void query_specific_player_with_linq()
        {
            var player = session.Linq<Player>()
                .Where(p => p.Name == "Michel")
                .FirstOrDefault();
            Assert.AreEqual("Michel", player.Name);
        }

        [Test]
        public void future_queries()
        {
            var allPlayers = session.CreateCriteria<Player>()
                .Future<Player>();
            var danny = session.CreateCriteria<Player>()
                .Add(Restrictions.Eq("Name", "Danny"))
                .FutureValue<Player>();
            var michel = session.CreateCriteria<Player>()
                .Add(Restrictions.Eq("Name", "Michel"))
                .FutureValue<Player>();

            Assert.AreEqual(NUMBER_OF_PLAYERS + 2, allPlayers.Count());//all three queries get executed now
            Assert.AreEqual("Danny", danny.Value.Name);
            Assert.AreEqual("Michel", michel.Value.Name);
        }

    }
}