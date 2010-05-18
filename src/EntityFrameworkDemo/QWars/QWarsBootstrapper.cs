using System.Windows;
using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Composite.UnityExtensions;
using QWars.Module.Common;

namespace QWars
{
    class QWarsBootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            HibernatingRhinos.Profiler.Appender.EntityFramework.EntityFrameworkProfiler.Initialize();
            var window = new MainWindow();

            window.Show();
            return window;
        }

        protected override IModuleCatalog GetModuleCatalog()
        {
            var catalog = new ModuleCatalog();
            catalog.AddModule(typeof(QWars.Module.QWarsModule));
            return catalog;
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            Container.RegisterType<IDialogService, DialogService>();
        }
    }
}
