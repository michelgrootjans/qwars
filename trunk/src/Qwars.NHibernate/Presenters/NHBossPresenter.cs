using System;
using QWars.Presentation;

namespace QWars.NHibernate.Presenters
{
    public class NHBossPresenter : IBossPresenter
    {
        private readonly IBossView view;

        public NHBossPresenter(IBossView view)
        {
            this.view = view;
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void CreateRandomTasks()
        {
            throw new NotImplementedException();
        }

        public void IncreaseRewardForAllTasks()
        {
            throw new NotImplementedException();
        }
    }
}