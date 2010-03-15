using System.Windows.Forms;
using QWars.Dummy;
using QWars.Presentation;

namespace QWars.Win
{
    public partial class JoinGangView : Form, IJoinGangView
    {
        private IJoinGangPresenter presenter;

        public JoinGangView()
        {
            InitializeComponent();
            presenter = new JoinGangPresenter(this);
        }
    }
}
