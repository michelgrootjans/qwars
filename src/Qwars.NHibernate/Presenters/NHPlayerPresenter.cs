using System.Linq;
using QWars.NHibernate.Entities;
using QWars.Presentation;
using QWars.Presentation.Entities;

namespace QWars.NHibernate.Presenters
{
    public class NHPlayerPresenter : NHPresenter, IPlayerPresenter
    {
        private readonly IPlayerView view;

        public NHPlayerPresenter(IPlayerView view)
        {
            this.view = view;
        }

        public void Initialize()
        {
            UpdateView();
        }

        public void MugPedestrian()
        {
            using (var transaction = session.BeginTransaction())
            {
                var player = Get<IPlayer>(view.Player.Id);
                player.Execute(new Mugging());
                UpdateView(player);
                transaction.Commit();
            }
        }

        public void SellUnusedWeapons()
        {
            using (var transaction = session.BeginTransaction())
            {
                var player = Get<IPlayer>(view.Player.Id);
                player.SellUnusedWeapons();
                UpdateView(player);
                transaction.Commit();
            }
        }

        public void UpdateView()
        {
            session.Clear();
            using (var transaction = session.BeginTransaction())
            {
                var player = Get<IPlayer>(view.Player.Id);
                UpdateView(player);
                transaction.Commit();
            }
        }

        private void UpdateView(IPlayer player)
        {
            view.IsBoss = player.IsBoss;
            view.IsMember = player.IsMember;
            view.Title = player.Name;
            view.Money = player.Money;
            view.XP = player.XP.ToString();
            view.Weapons = player.Weapons.ToList();
        }
    }
}