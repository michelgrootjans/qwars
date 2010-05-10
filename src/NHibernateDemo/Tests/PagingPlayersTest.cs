using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Criterion;
using NHibernateDemo.Entities;
using NHibernateDemo.Utilities;
using NUnit.Framework;

namespace NHibernateDemo.Tests
{
    [TestFixture]
    public class PagingPlayersTest : DataAccessTest
    {
        protected override void PrepareData()
        {
            for (var i = 100; i < 199; i++)
                session.Save(new Player {Name = "Player " + i});
        }

        [Test]
        public void GetFirstPage()
        {
            var criteria = GetAllPlayers();
            AddPagingTo(criteria, 0, 4);
            var players = criteria.List<Player>();
            Assert.AreEqual(4, players.Count());
            for (var i = 100; i < 104; i++)
                AssertContainsPlayer(players, i);
        }

        [Test]
        public void GetSecondPage()
        {
            var criteria = GetAllPlayers();
            AddPagingTo(criteria, 1, 4);
            var players = criteria.List<Player>();
            Assert.AreEqual(4, players.Count());
            for (var i = 104; i < 108; i++)
                AssertContainsPlayer(players, i);
        }

        [Test]
        public void GetThirdPage()
        {
            var criteria = GetAllPlayers();
            AddPagingTo(criteria, 2, 4);
            var players = criteria.List<Player>();
            Assert.AreEqual(4, players.Count());
            for (var i = 108; i < 112; i++)
                AssertContainsPlayer(players, i);
        }

        private static void AssertContainsPlayer(IEnumerable<Player> players, int playerNumber)
        {
            Assert.IsTrue(players.Any(p => p.Name == "Player " + playerNumber), PrintList(players) + " doesn't contain player " + playerNumber);
        }

        private static string PrintList(IEnumerable<Player> players)
        {
            return string.Format("[{0}]", string.Join(";", players.Select(p => p.Name).ToArray()));
        }

        private void AddPagingTo(ICriteria criteria, int pageNumber, int pageSize)
        {
            criteria.SetFirstResult(pageNumber * pageSize);
            criteria.SetMaxResults(pageSize);
        }

        private ICriteria GetAllPlayers()
        {
            return session.CreateCriteria<Player>()
                .AddOrder(Order.Asc("Name"));
        }
    }
}