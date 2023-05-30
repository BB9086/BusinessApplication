using CommunityToolkit.Maui.Core.Views;
using BusinessMobile.Services;
using BusinessMobile.ViewModel;
using Mopups.Pages;

namespace BusinessMobile.View;

public partial class LoginPopupPage : PopupPage
{
   
    public LoginPopupPage()
	{
        InitializeComponent();
    }

    private void LoginButton_Clicked(object sender, EventArgs e)
    {
        
        string username = UsernameEntry.Text;
        string password = PasswordEntry.Text;

        Shell.Current.GoToAsync("StorePage");

    }
}