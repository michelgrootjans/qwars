using QWars.Presentation;

namespace QWars.Dummy.Presenters
{
    public class CreateGangPresenter : ICreateGangPresenter
    {
        private readonly ICreateGangView view;
        private readonly Logger logger;

        public CreateGangPresenter(ICreateGangView view)
        {
            this.view = view;
            logger = new Logger(this);
        }

        public void Initialize()
        {
            //Do nothing... nothing to do ;-)
        }

        public void CreateGang()
        {
            logger.Log(string.Format("Player {0} creating gang {1} with {2}% benefits for the boss", 
                                     view.PlayerId, view.GangName, view.BossBenefit));
        }
    }
}