using CommunityToolkit.Maui;
using BusinessMobile.Services;
using BusinessMobile.View;
using BusinessMobile.ViewModel;
using MetroLog.MicrosoftExtensions;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Mopups.Hosting;
using Mopups.Interfaces;
using Mopups.Services;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace BusinessMobile;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseSkiaSharp()
            .ConfigureMopups()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);

        builder.Services.AddSingleton<StoreService>();
        builder.Services.AddSingleton<UserService>();
        builder.Services.AddSingleton<StoresViewModel>();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<LoginPage>();     
        builder.Services.AddSingleton<StorePage>();
		builder.Services.AddSingleton<LoginViewModel>();
		builder.Services.AddSingleton<WebViewPage>();
        builder.Services.AddSingleton<LoginPopupPage>();

        builder.Services.AddTransient<MonthsViewModel>();
        builder.Services.AddTransient<MonthsPage>();

        builder.Services.AddTransient<YearsViewModel>();
        builder.Services.AddTransient<YearsPage>();

        builder.Services.AddSingleton<IPopupNavigation>(MopupService.Instance);

        //App center - for detail analysis of our app on IOS, Android and Windows
        //https://appcenter.ms/
        AppCenter.Start("android=e70e6055-2cbb-43f7-a31f-b143360cffe6;" +
                  "windowsdesktop=05f54923-ba38-4c77-81c5-abb715557a71;" +
                  "ios=77ffc077-5407-4c96-a6db-93bae6e78313;" +
                  "macos={Your macOS App secret here};",
                  typeof(Analytics), typeof(Crashes));


        //Client-Side Logging - MetroLog
        builder.Logging.AddTraceLogger(_ => { });
        builder.Logging.AddInMemoryLogger(_ => { });
        builder.Logging.AddStreamingFileLogger(_ => { });

        return builder.Build();
	}
}
