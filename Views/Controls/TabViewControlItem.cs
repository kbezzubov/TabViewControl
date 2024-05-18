using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabViewControl.Views.Controls
{
    public partial class TabViewControlItem: ObservableObject
    {
        public string TabTitle { get; set; }
        public View Content { get; set; }

        [ObservableProperty]
        private bool isSelected;
        public bool IsFirst { get; set; }
        public bool IsLast { get; set; }
        public Thickness Margin { get; set; }
    }
}
