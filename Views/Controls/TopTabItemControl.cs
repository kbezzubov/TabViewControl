using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls.Shapes;

namespace TabViewControl.Views.Controls
{
    public class TopTabItemControl : Border
    {
        public static BindableProperty IsSelectedProperty =
            BindableProperty.Create(nameof(IsSelected), typeof(bool), typeof(TopTabItemControl), false,
                BindingMode.OneWay, null, propertyChanged: (bindable, oldValue, newValue) =>
                {
                });
        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }
        public static BindableProperty IsLastProperty =
            BindableProperty.Create(nameof(IsLast), typeof(bool), typeof(TopTabItemControl), false,
                BindingMode.OneWay, null, (bindable, oldValue, newValue) =>
                {
                    
                });
        public bool IsLast
        {
            get { return (bool)GetValue(IsLastProperty); }
            set { SetValue(IsLastProperty, value); }
        }
        public static BindableProperty IsFirstProperty =
           BindableProperty.Create(nameof(IsFirst), typeof(bool), typeof(TopTabItemControl), false,
               BindingMode.OneWay, null, (bindable, oldValue, newValue) =>
               {
               });
        public bool IsFirst
        {
            get { return (bool)GetValue(IsFirstProperty); }
            set { SetValue(IsFirstProperty, value); }
        }
        public static BindableProperty CornerRadiusProperty =
            BindableProperty.Create(nameof(CornerRadius), typeof(int), typeof(TopTabItemControl), 0,
                BindingMode.OneWay, null, (bindable, oldValue, newValue) =>
                {
                });
        public int CornerRadius
        {
            get { return (int)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static new BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(TopTabItemControl),
                Color.FromRgba(0,0,0,0), BindingMode.OneWay, null, (bindable, oldValue, newValue) =>
                {
                });
        public new Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }
        public static BindableProperty SelectedBackgroundColorProperty =
            BindableProperty.Create(nameof(SelectedBackgroundColor), typeof(Color), typeof(TopTabItemControl),
                Color.FromRgba(0,0,0,0), BindingMode.OneWay, null, (bindable, oldValue, newValue) =>
                {
                });
        public Color SelectedBackgroundColor
        {
            get { return (Color)GetValue(SelectedBackgroundColorProperty); }
            set { SetValue(SelectedBackgroundColorProperty, value); }
        }
        public static BindableProperty TapCommandProperty =
            BindableProperty.Create(nameof(TapCommand), typeof(ICommand), typeof(TopTabItemControl), defaultBindingMode: BindingMode.TwoWay,
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    var ctrl = (TopTabItemControl)bindable;
                    ctrl.TapCommand = (ICommand)newValue;
                });

        public ICommand TapCommand
        {
            get { return (ICommand)GetValue(TapCommandProperty); }
            set
            {
                SetValue(TapCommandProperty, value);
            }
        }

        public static BindableProperty CommandParameterProperty =
            BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(TopTabItemControl), defaultBindingMode: BindingMode.TwoWay,
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    var ctrl = (TopTabItemControl)bindable;
                    ctrl.CommandParameter = newValue;
                });

        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set
            {
                SetValue(CommandParameterProperty, value);
            }
        }
        private double _density;
        public TopTabItemControl()
        {
            _density = 1;
            StrokeShape = new RoundRectangle();
            StrokeThickness = 0;
            TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
            GestureRecognizers.Add(tapGestureRecognizer);
        }
        protected override void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            switch (propertyName)
            {
                case nameof(IsSelected):
                case nameof(BackgroundColor):
                case nameof(SelectedBackgroundColor):
                    if (IsSelected)
                    {
                        base.BackgroundColor = SelectedBackgroundColor;
                        ((RoundRectangle)StrokeShape).CornerRadius = new CornerRadius(CornerRadius, CornerRadius, CornerRadius, CornerRadius);
                    }
                    else
                    {
                        base.BackgroundColor = this.BackgroundColor;
                        if (IsFirst)
                            ((RoundRectangle)StrokeShape).CornerRadius = new CornerRadius(CornerRadius, 0, CornerRadius, 0);
                        else if (IsLast)
                            ((RoundRectangle)StrokeShape).CornerRadius = new CornerRadius(0, CornerRadius, 0, CornerRadius);
                        else
                            ((RoundRectangle)StrokeShape).CornerRadius = new CornerRadius(0, 0, 0, 0);
                    }
                    break;
                case nameof(CornerRadius):
                case nameof(IsLast):
                case nameof(IsFirst):
                    if (IsFirst)
                        ((RoundRectangle)StrokeShape).CornerRadius = new CornerRadius(CornerRadius, 0, CornerRadius, 0);
                    else if (IsLast)
                        ((RoundRectangle)StrokeShape).CornerRadius = new CornerRadius(0, CornerRadius, 0, CornerRadius);
                    else
                        ((RoundRectangle)StrokeShape).CornerRadius = new CornerRadius(0, 0, 0, 0);
                    break;
                case nameof(TapCommand):
                    (GestureRecognizers[0] as TapGestureRecognizer).Command = TapCommand;
                    break;
                case nameof(CommandParameter):
                    (GestureRecognizers[0] as TapGestureRecognizer).CommandParameter = CommandParameter; 
                    break;

            }
            base.OnPropertyChanged(propertyName);
        }
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
        }
    }
}
