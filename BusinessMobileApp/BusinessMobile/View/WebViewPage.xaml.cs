using BusinessMobile.ViewModel;

namespace BusinessMobile.View;

public partial class WebViewPage : ContentPage
{
	public WebViewPage(LoginViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}