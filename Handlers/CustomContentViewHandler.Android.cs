using Android.Views;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabViewControl.Handlers
{
    public partial class CustomContentViewHandler: ContentViewHandler
    {
        protected override void ConnectHandler(ContentViewGroup platformView)
        {
            base.ConnectHandler(platformView);
        }
        static void UpdateContent(IContentViewHandler handler)
        {
            _ = handler.PlatformView ?? throw new InvalidOperationException($"{nameof(PlatformView)} should have been set by base class.");
            _ = handler.MauiContext ?? throw new InvalidOperationException($"{nameof(MauiContext)} should have been set by base class.");
            _ = handler.VirtualView ?? throw new InvalidOperationException($"{nameof(VirtualView)} should have been set by base class.");

            handler.PlatformView.RemoveAllViews();
            System.Diagnostics.Debug.WriteLine("Working my custom!!! handler!!!!");
            if (handler.VirtualView.PresentedContent is IView view)
            {
                var v = view.ToPlatform(handler.MauiContext);
                if(v.Parent is ViewGroup viewGroup)
                {
                    if (viewGroup.ChildCount > 0)
                    {
                        System.Diagnostics.Debug.WriteLine("Congratulation!!! custom!!!!");
                        viewGroup.RemoveView(v);

                    }
                        
                }
                handler.PlatformView.AddView(view.ToPlatform(handler.MauiContext));
            }
        }

        public static partial void MapContent(IContentViewHandler handler, IContentView page)
        {
            CustomContentViewHandler.UpdateContent(handler);
        }
    }
}
