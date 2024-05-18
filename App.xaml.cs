using TabViewControl.Handlers;

namespace TabViewControl
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}
