using System.Linq;
using NUnit.Framework;
using QWars.NHibernate.Entities;

namespace QWars.NHibernate.Tests
{
    [TestFixture]
    public class GangCrudTests : DataAccessTest
    {
        private object gangId;
        private object bossId;
        private const string gangName = "Los Techies";

        protected override void PrepareData()
        {
            var boss = new Player("boss");
            var gang = boss.CreateGang(gangName, "yeah");
            session.Save(boss);
            gangId = session.GetIdentifier(gang);
            bossId = session.GetIdentifier(boss);
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
            var player = session.Get<Player>(bossId);
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
            FlushAndClear();

            gang = session.Get<Gang>(gangId);
            Assert.AreEqual(1, gang.Members.Count());
        }

        [Test]
        public void added_task_should_be_persisted()
        {
            var gang = session.Get<Gang>(gangId);
            gang.CreateTask("do it", 1, 2, 3);
            FlushAndClear();

            gang = session.Get<Gang>(gangId);
            Assert.AreEqual(1, gang.Tasks.Count());
        }

    }
}