using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Platform;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace TabViewControl.Views.Controls;

public partial class TabViewControl : ContentView
{
    private bool _isBusy = false;
    public static BindableProperty TabTapCommandParameterProperty =
            BindableProperty.Create(nameof(TabTapCommandParameter), typeof(TabViewControlItem), typeof(TopTabItemControl),
                null, BindingMode.OneWay, null, (bindable, oldValue, newValue) =>
                {
                });
    public TabViewControlItem TabTapCommandParameter
    {
        get { return (TabViewControlItem)GetValue(TabTapCommandParameterProperty); }
        set { SetValue(TabTapCommandParameterProperty, value); }
    }
    public static BindableProperty TabTapCommandProperty =
            BindableProperty.Create(nameof(TabTapCommand), typeof(IAsyncRelayCommand<TabViewControlItem>), typeof(TopTabItemControl),
                null, BindingMode.OneWay, null, (bindable, oldValue, newValue) =>
                {
                });
    public IAsyncRelayCommand<TabViewControlItem> TabTapCommand
    {
        get { return (IAsyncRelayCommand<TabViewControlItem>)GetValue(TabTapCommandProperty); }
        set { SetValue(TabTapCommandProperty, value); }
    }
    public static BindableProperty TabStripBackgroundColorProperty =
            BindableProperty.Create(nameof(TabStripBackgroundColor), typeof(Color), typeof(TopTabItemControl),
                Colors.Transparent, BindingMode.OneWay, null, (bindable, oldValue, newValue) =>
                {
                });
    public Color TabStripBackgroundColor
    {
        get { return (Color)GetValue(TabStripBackgroundColorProperty); }
        set { SetValue(TabStripBackgroundColorProperty, value); }
    }
    public static readonly BindableProperty TabStripHeightProperty = BindableProperty.Create(nameof(TabStripHeight), typeof(double), typeof(TabViewControl), 48.0, BindingMode.OneWay, null, null);
    public double TabStripHeight
    {
        get
        {
            return (double)GetValue(TabStripHeightProperty);
        }
        set
        {
            SetValue(TabStripHeightProperty, value);
        }
    }
    public static readonly BindableProperty TabItemsProperty = BindableProperty.Create(nameof(TabItems), typeof(IEnumerable<TabViewControlItem>), typeof(TabViewControl), null, BindingMode.TwoWay, null, null);
    public IEnumerable<TabViewControlItem> TabItems
    {
        get
        {
            return (IEnumerable<TabViewControlItem>)GetValue(TabItemsProperty);
        }
        set
        {
            SetValue(TabItemsProperty, value);
        }
    }
    public TabViewControl()
	{
		InitializeComponent();
        TabTapCommand = new AsyncRelayCommand<TabViewControlItem>(OnTabTapCommandHandler);
        CustomizeTabViewControl();
	}
    private void CustomizeTabViewControl()
    {
    }
    private async Task OnTabTapCommandHandler(TabViewControlItem tab)
    {
        if (_isBusy) return;
        _isBusy = true;
        try
        {
            if (tab.IsSelected)
                return; 
            else
            {
                TabItems.First(t => t.IsSelected).IsSelected = false;
                tab.IsSelected = true;
                int index = -1;
                int i = -1;
                foreach (var t in TabItems)
                {
                    i++;
                    if (t == tab)
                    {
                        index = i;
                        break;
                    }
                }
                MainThread.BeginInvokeOnMainThread(() =>
                    {
                        try
                        {
                            contentView.Position = index;
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine(ex);
                        }
                    }
                );
                await MainThread.InvokeOnMainThreadAsync(async () =>
                {

                    await scrView.ScrollToAsync((Element)((scrView.Content as Border).Content as HorizontalStackLayout).Children[index],
                        ScrollToPosition.Center, true);
                });

            }
        }
        catch(Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
        }
        finally { _isBusy = false; }
    }
    protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);
    }
}