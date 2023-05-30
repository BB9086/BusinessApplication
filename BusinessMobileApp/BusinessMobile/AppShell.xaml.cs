using BusinessMobile.View;

namespace BusinessMobile;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(StorePage), typeof(StorePage));
        Routing.RegisterRoute(nameof(MonthsPage), typeof(MonthsPage));
		Routing.RegisterRoute(nameof(YearsPage), typeof(YearsPage));
		Routing.RegisterRoute(nameof(WebViewPage), typeof(WebViewPage));
		Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
    }
}
