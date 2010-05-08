using System.Linq;
using NHibernate.Criterion;
using NHibernateDemo.Entities;
using NHibernateDemo.Utilities;
using NUnit.Framework;
using NHibernate.Linq;

namespace NHibernateDemo.Tests
{
    public class PlayerCrudTests : DataAccessTest
    {
        private object michelId;

        protected override void PrepareData()
        {
            var michel = new Player {Name = "Michel"};
            session.Save(michel);
            michelId = session.GetIdentifier(michel);
            session.Save(new Player {Name = "Danny"});
        }

        [Test]
        public void Get_Player_Returns_a_Player()
        {
            var player = session.Get<Player>(michelId);
            Assert.IsNotNull(player);
        }

        [Test]
        public void Get_Player_returns_the_right_player()
        {
            var player = session.Get<Player>(michelId);
            Assert.AreEqual("Michel", player.Name);
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
                .SetParameter("name", "Michel")
                .UniqueResult<Player>();
            Assert.AreEqual("Michel", player.Name);
            Assert.AreEqual(michelId, session.GetIdentifier(player));
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