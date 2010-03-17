using System.Collections;

namespace QWars.Presentation
{
    public interface IAdministratorView
    {
        IEnumerable Data { set; }
        string Title { set; }
    }
}