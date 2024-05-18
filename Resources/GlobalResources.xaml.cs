using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace TabViewControl.Resources
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GlobalResources : ResourceDictionary
    {
        public GlobalResources()
        {
            InitializeComponent();
        }
    }
}