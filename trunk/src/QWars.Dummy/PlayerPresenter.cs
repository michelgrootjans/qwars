using System;
using System.Collections.Generic;
using QWars.Presentation;

namespace QWars.Dummy
{
    public class PlayerPresenter : Presenter, IPlayerPresenter
    {
        private readonly IPlayerView view;
        private int money;
        private int xp;
        private readonly Random random;

        public PlayerPresenter(IPlayerView view)
        {
            Log("Constructor");
            this.view = view;
            money = 0;
            xp = 0;
            random = new Random();
        }

        public void Initialize()
        {
            Log("Initialize");
            UpdateView();
        }

        public void MugPedestrian()
        {
            Log("MugPedestrian");
            xp += random.Next(80, 100);
            money += random.Next(15,20);
            UpdateView();
        }

        public void SellUnusedWeapons()
        {
            Log("SellUnusedWeapons");
        }

        public void LeaveGang()
        {
            Log("LeaveGang");
        }

        public void DisbandGang()
        {
            Log("DisbandGang");
        }

        private void UpdateView()
        {
            view.PlayerName = "Armageddon";
            view.Money = money;
            view.XP = xp;
            view.Weapons = new List<object> {new Weapon("knife", 1.2), new Weapon("gun", 5.0)};
        }
    }

    internal class Weapon
    {
        private readonly string name;
        private readonly double xpBonus;

        public Weapon(string name, double xpBonus)
        {
            this.name = name;
            this.xpBonus = xpBonus;
        }

        public double XpBonus
        {
            get { return xpBonus; }
        }

        public string Name
        {
            get { return name; }
        }
    }
}