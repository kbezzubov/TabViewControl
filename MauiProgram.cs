using Microsoft.Extensions.Logging;
using TabViewControl.Handlers;

namespace TabViewControl
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Golos Text_Medium.ttf", "GolosMedium");
                    fonts.AddFont("Golos Text_Bold.ttf", "GolosBold");
                    fonts.AddFont("Golos Text_Regular.ttf", "GolosRegular");
                    fonts.AddFont("Golos Text_DemiBold.ttf", "GolosDemiBold");
                    fonts.AddFont("Ubuntu-Medium.ttf", "UbuntuMedium");
                    fonts.AddFont("Ubuntu-Bold.ttf", "UbuntuBold");
                    fonts.AddFont("Ubuntu-Regular.ttf", "UbuntuRegular");
                    fonts.AddFont("Ubuntu-Light.ttf", "UbuntuLight");
                    fonts.AddFont("Font Awesome 5 Free-Solid-900.otf", "FontAwesome");
                });
#if __ANDROID__
            builder.ConfigureMauiHandlers(handlers =>
             {
                 //handlers.AddHandler(typeof(ContentView), typeof(CustomContentViewHandler));
             });
#endif
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
