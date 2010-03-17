using System;
using System.Collections.Generic;
using QWars.Dummy.Entities;
using QWars.Presentation;
using QWars.Presentation.Entities;

namespace QWars.Dummy.Presenters
{
    public class PlayerPresenter : IPlayerPresenter
    {
        private readonly Random random;
        private readonly Logger logger;
        private readonly IPlayerView view;

        public PlayerPresenter(IPlayerView view)
        {
            logger = new Logger(this); 
            this.view = view;
            random = new Random();
        }

        public void Initialize()
        {
            logger.Log("Initialize");
            UpdateView();
        }

        public void MugPedestrian()
        {
            logger.Log(string.Format("Player {0} mugs a pedestrian", view.Player));
            GetPlayer().AddXp(random.Next(80, 100));
            GetPlayer().AddMoney(random.Next(15, 20));
            UpdateView();
        }

        private IPlayer GetPlayer()
        {
            return view.Player as IPlayer;
        }

        public void SellUnusedWeapons()
        {
            logger.Log(string.Format("Player {0} sells his unused weapons", view.Player));
        }

        public void UpdateView()
        {
            view.PlayerName = string.Format("Armageddon ({0})", view.Player);
            view.Money = GetPlayer().Money;
            view.XP = GetPlayer().XP;
            view.Weapons = GetPlayer().Weapons;
        }
    }
}