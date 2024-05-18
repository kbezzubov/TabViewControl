using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Input;

namespace TabViewControl
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        int count = 0;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
           
            //SemanticScreenReader.Announce(CounterBtn.Text);
        }

        
    }

}
