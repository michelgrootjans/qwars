using System;
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
            using (var session = sessionFactory.OpenSession())
            {
                var player = session.Get<Player>(view.Player.Id);
                view.Title = player.Name;
                view.Money = player.Money;
                view.XP = player.XP.ToString();
            }
        }

        public void UpdateView()
        {
            Get(view.Player.Id).AndExecute(p =>
                                               {
                                                   view.Title = p.Name;
                                                   view.Money = p.Money;
                                                   view.XP = p.XP.ToString();
                                                   view.Weapons = p.Weapons.ToList();
                                               });
        }

        public void MugPedestrian()
        {
            Get(view.Player.Id).AndExecute(p => p.Execute(new Mugging()));
            UpdateView();
        }

        public void SellUnusedWeapons()
        {
            Get(view.Player.Id).AndExecute(p => p.SellUnusedWeapons());
        }
    }

    public class Mugging : ITask
    {
        public int Difficulty
        {
            get { return 0; }
        }

        public int Reward
        {
            get { return 10; }
        }

        public int XP
        {
            get { return 10; }
        }

        public void IncreaseRewardWith(double bonus)
        {
            // do nothing
        }
    }
}