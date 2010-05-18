using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Unity;
using QWars.Module.Gangs;
using QWars.Module.Logon;
using QWars.Module.Players;

namespace QWars.Module
{
    public class QWarsModule: IModule
    {
        #region Properties
        public IUnityContainer Container { get; private set; }
        public IRegionManager RegionManager { get; private set; }
        #endregion

        #region Constructors
        public QWarsModule(IRegionManager regionManager, IUnityContainer container)
        {
            RegionManager = regionManager;
            Container = container;
        }
        #endregion

        #region Methods
        public void Initialize()
        {
            //Logon
            var logonView = Container.Resolve<LogonView>();
            var logonViewModel = Container.Resolve<LogonViewModel>();
            logonView.DataContext = logonViewModel;

            RegionManager.AddToRegion("LogonRegion", logonView);

            //Player
            var playerView = Container.Resolve<PlayerView>();
            var playerViewModel = Container.Resolve<PlayerViewModel>();
            playerView.DataContext = playerViewModel;

            RegionManager.AddToRegion("MainRegion", playerView);

            //Gang
            var gangView = Container.Resolve<GangView>();
            var gangViewModel = Container.Resolve<GangViewModel>();
            gangView.DataContext = gangViewModel;

            RegionManager.AddToRegion("GangRegion", gangView);
        }
        #endregion
    }
}
