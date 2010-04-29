using System;
using System.Linq;
using NUnit.Framework;
using QWars.NHibernate.Entities;

namespace QWars.NHibernate.Tests
{
    [TestFixture]
    public class GangCrudTests : DataAccessTest
    {
        private object gangId;
        private object playerId;
        private const string gangName = "Los Techies";

        protected override void PrepareData()
        {
            var player = new Player("hero");
            var gang = new Gang(player, gangName);
            session.Save(player);
            session.Save(gang);
            gangId = session.GetIdentifier(gang);
            playerId = session.GetIdentifier(player);
        }

        [Test]
        public void should_be_able_to_get_gang_from_db()
        {
            var gang = session.Get<Gang>(gangId);
            Assert.AreEqual(gangName, gang.Name);
        }

        [Test]
        public void gang_boss_should_be_player()
        {
            var player = session.Get<Player>(playerId);
            var gang = session.Get<Gang>(gangId);
            Assert.AreSame(player, gang.Boss);
        }

        [Test]
        public void added_member_should_be_persisted()
        {
            var gang = session.Get<Gang>(gangId);
            var member = new Player("member");
            session.Save(member);
            member.Join(gang);
            session.Flush();
            session.Clear();

            gang = session.Get<Gang>(gangId);
            Assert.AreEqual(1, gang.Members.Count());
        }

    }
}