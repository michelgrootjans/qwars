using QWars.Presentation;

namespace QWars.Dummy.Presenters
{
    public class JoinGangPresenter : IJoinGangPresenter
    {
        private readonly IJoinGangView view;

        public JoinGangPresenter(IJoinGangView view)
        {
            this.view = view;
        }
    }
}