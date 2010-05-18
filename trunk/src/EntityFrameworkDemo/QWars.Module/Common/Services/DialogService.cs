using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Practices.Unity;

namespace QWars.Module.Common
{
    public class DialogService : IDialogService
    {
        public IUnityContainer Container { get; private set; }

        public DialogService(IUnityContainer container)
        {
            Container = container;
        }

        public bool? ShowViewModelInDialog<TView, TViewModel>()
            where TView : Control
            where TViewModel : ICloseableViewModel
        {
            var window = new Window
                             {
                                 SizeToContent = SizeToContent.WidthAndHeight,
                                 WindowStartupLocation = WindowStartupLocation.CenterOwner,
                                 WindowStyle = WindowStyle.None,
                                 AllowsTransparency = true,
                                 Background = new SolidColorBrush(Colors.Transparent),
                                 Owner = Application.Current.MainWindow 
                             };
            

            var view = Container.Resolve<TView>();
            var viewModel = Container.Resolve<TViewModel>();

            EventHandler closeHandler = null;
            closeHandler = delegate
                    {
                        if (closeHandler != null) viewModel.RequestClose -= closeHandler;
                        window.Close();
                    };

            viewModel.RequestClose += closeHandler;

            MouseButtonEventHandler moveHandler = null;
            moveHandler = delegate
                              {
                                  window.DragMove(); 
                              };
            window.MouseDown += moveHandler;

            view.DataContext = viewModel;
            window.Content = view;

            return window.ShowDialog();
        }
    }
}
