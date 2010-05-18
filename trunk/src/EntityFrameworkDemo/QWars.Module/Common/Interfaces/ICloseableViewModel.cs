using System;

namespace QWars.Module.Common
{
    public interface ICloseableViewModel : IViewModel
    {
        EventHandler RequestClose { get; set; }
    }
}