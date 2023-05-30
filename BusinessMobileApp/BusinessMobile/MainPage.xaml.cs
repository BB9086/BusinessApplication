using BusinessMobile.ViewModel;

namespace BusinessMobile;

public partial class MainPage : ContentPage
{
	//int count = 0;
	public MainPage(LoginViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;

        statusBar.StatusBarColor = Colors.SkyBlue;
        statusBar.StatusBarStyle = CommunityToolkit.Maui.Core.StatusBarStyle.DarkContent;


    }

    private void AnimateBtn_Clicked(object sender, EventArgs e)
    {
        //Animation - Image, Button https://www.youtube.com/watch?v=80sinVHdCSQ
        //AnimateBtn.FadeTo(0, 1000, Easing.Linear);
    }
}

