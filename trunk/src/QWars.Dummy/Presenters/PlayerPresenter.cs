using System;
using System.Collections.Generic;
using QWars.Dummy.Entities;
using QWars.Presentation;

namespace QWars.Dummy.Presenters
{
    public class PlayerPresenter : IPlayerPresenter
    {
        private readonly Random random;
        private readonly Logger logger;
        private readonly IPlayerView view;

        private int money;
        private int xp;

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
            logger.Log(string.Format("Player {0} mugs a pedestrian", PlayerId));
            xp += random.Next(80, 100);
            money += random.Next(15,20);
            UpdateView();
        }

        public void SellUnusedWeapons()
        {
            logger.Log(string.Format("Player {0} sells his unused weapons", PlayerId));
        }

        private object PlayerId
        {
            get { return view.PlayerId; }
        }
        
        private void UpdateView()
        {
            view.PlayerName = string.Format("Armageddon ({0})", PlayerId);
            view.Money = money;
            view.XP = xp;
            view.Weapons = new List<object> {new Weapon("knife", 1.2), new Weapon("gun", 5.0)};
        }
    }
}