using System.Collections.Generic;
using System.Linq;
using QWars.Dummy.Entities;
using QWars.Presentation.Entities;

namespace QWars.Dummy.Presenters
{
    public static class InMemoryRepository
    {
        private static readonly List<Player> dummyPlayers = new List<Player>();
        private static readonly List<Gang> dummyGangs = new List<Gang>();

        public static Player Create(string name)
        {
            var player = new Player(name.Length, name);
            dummyPlayers.Add(player);
            return player;
        }

        public static IEnumerable<IPlayer> GetAllPlayers()
        {
            return dummyPlayers.Cast<IPlayer>();
        }

        public static IPlayer FindPlayer(int id)
        {
            return dummyPlayers.Where(p => p.Id == id).FirstOrDefault();
        }

        public static IEnumerable<IGang> GetAllGangs()
        {
            return dummyGangs.Cast<IGang>();
        }
    }
}