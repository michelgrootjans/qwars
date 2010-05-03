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
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var player = Get<IPlayer>(view.Player.Id, session);
                player.Execute(new Mugging());
                transaction.Commit();
                UpdateView(player);
            }
        }

        public void SellUnusedWeapons()
        {
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var player = Get<IPlayer>(view.Player.Id, session);
                player.SellUnusedWeapons();
                transaction.Commit();
                UpdateView(player);
            }
        }

        public void UpdateView()
        {
            using (var session = sessionFactory.OpenSession())
            {
                var player = Get<IPlayer>(view.Player.Id, session);
                UpdateView(player);
            }
        }

        private void UpdateView(IPlayer player)
        {
            view.Title = player.Name;
            view.Money = player.Money;
            view.XP = player.XP.ToString();
            view.Weapons = player.Weapons.ToList();
        }
    }
}