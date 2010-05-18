using System.Windows.Controls;

namespace QWars.Module.Common
{
    public interface IDialogService
    {
        bool? ShowViewModelInDialog<TView, TViewModel>() where TView : Control where TViewModel : ICloseableViewModel;
    }
}