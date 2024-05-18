#nullable enable
#if __IOS__ || MACCATALYST
using PlatformView = Microsoft.Maui.Platform.ContentView;
#elif MONOANDROID
using PlatformView = Microsoft.Maui.Platform.ContentViewGroup;
#elif WINDOWS
using PlatformView = Microsoft.Maui.Platform.ContentPanel;
#elif TIZEN
using PlatformView = Microsoft.Maui.Platform.ContentViewGroup;
#elif (NETSTANDARD || !PLATFORM) || (NET6_0_OR_GREATER && !IOS && !ANDROID && !TIZEN)
using PlatformView = System.Object;
#endif
using Microsoft.Maui.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabViewControl.Handlers
{
    public partial class CustomContentViewHandler: ContentViewHandler
    {
        public CustomContentViewHandler() : base(Mapper, CommandMapper)
        {

        }
        public CustomContentViewHandler(IPropertyMapper? mapper)
            : base(mapper ?? Mapper, CommandMapper)
        {
        }

        public CustomContentViewHandler(IPropertyMapper? mapper, CommandMapper? commandMapper)
            : base(mapper ?? Mapper, commandMapper ?? CommandMapper)
        {
        }
        public static new IPropertyMapper<IContentView, IContentViewHandler> Mapper =
            new PropertyMapper<IContentView, IContentViewHandler>(ViewMapper)
            {
                [nameof(IContentView.Content)] = MapContent,
            };

        public static CommandMapper<IContentView, IContentViewHandler> CommandMapper =
            new(ViewCommandMapper);
        public static partial void MapContent(IContentViewHandler handler, IContentView page);
    }
}
