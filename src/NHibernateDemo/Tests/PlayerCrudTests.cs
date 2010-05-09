using NHibernateDemo.Entities;
using NHibernateDemo.Utilities;
using NUnit.Framework;

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
    }
}