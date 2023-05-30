using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using BusinessMobile.Model;
using BusinessMobile.Services;
using BusinessMobile.View;
using Mopups.Interfaces;
using Mopups.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessMobile.ViewModel
{
    public partial class LoginViewModel : BaseViewModel
    {
        [ObservableProperty]
        public string source;

        //[ObservableProperty]
        //public Credentials credentials;

        IPopupNavigation popupNavigation;
        UserService _userService;

        public LoginViewModel(IPopupNavigation popupNavigation, UserService userService)
        {

            //Color = Colors.Red;

            this.popupNavigation = popupNavigation;

            Source = "https://www.tripadvisor.com/Attractions-g186338-Activities-c56-t97-London_England.html";

            //Added to enable loading data on page load event
            Task.Run(async () => await ShowCredentialMessage());
            _userService = userService;
        }

        [RelayCommand]
        async Task GoToLoginPage()
        {
            //popupNavigation.PushAsync(new LoginPopupPage());

            await Shell.Current.GoToAsync("LoginPage");
        }

        //Pass two values (username and password) from xaml as command parameters
        //https://learn.microsoft.com/en-us/answers/questions/619166/how-to-use-command-parameter-with-multiple-compone
        [RelayCommand]
        async Task GoToStores(Credentials credentials)
        {
           
            var test = credentials.username;
            var test1 = credentials.password;
            var isUserAvailable = await _userService.GetUser(credentials.username, credentials.password);
           
            if (isUserAvailable)
            {
                try
                {
                    //await Shell.Current.GoToAsync("//MainPage");
                    await Shell.Current.GoToAsync("StorePage");
                }
                catch (Exception ex)
                {
                    await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
                }
            }
            else
            {
                await Shell.Current.DisplayAlert("Error!", "Credentials are incorrect!", "OK");
                await Shell.Current.GoToAsync("LoginPage");
            }
        }

        [RelayCommand]
        async Task ShowCredentialMessage()
        {
            string message = "Please enter your credentials";

            //var toast = Toast.Make(message, CommunityToolkit.Maui.Core.ToastDuration.Long, 30);
            //await toast.Show();

            //App.Current.MainPage.DisplayAlert for .net6 .... DisplayAlert for .net7
            //var snackbar = Snackbar.Make(message, () => App.Current.MainPage.DisplayAlert("Credentials", "Did You enter valid credentials?", "YES"), "OK",
            //TimeSpan.FromSeconds(10), new CommunityToolkit.Maui.Core.SnackbarOptions
            //{
            //    BackgroundColor = Colors.Red,
            //    TextColor = Colors.White,
            //});
            //await snackbar.Show();

            var snackbar = Snackbar.Make(message, null, "OK",
            TimeSpan.FromSeconds(10), new CommunityToolkit.Maui.Core.SnackbarOptions
            {
                BackgroundColor = Colors.Red,
                TextColor = Colors.White,
                CornerRadius = 20
            });

            await snackbar.Show();
        }

        [RelayCommand]
        async Task GoToWebView()
        {
            try
            {
                //await Shell.Current.GoToAsync("//MainPage");
                await Shell.Current.GoToAsync("WebViewPage");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
        }

        [RelayCommand]
        private async void WebViewNavigated(WebNavigatedEventArgs e)
        {
            if (e.Result != WebNavigationResult.Success)
            {
                // TODO: handle failed navigation in an appropriate way
                await Shell.Current.DisplayAlert("Navigation failed", e.Result.ToString(), "OK");
            }
        }

        [RelayCommand]
        private void NavigateBack(WebView webView)
        {
            if (webView.CanGoBack)
            {
                webView.GoBack();
            }
        }

        [RelayCommand]
        private void NavigateForward(WebView webView)
        {
            if (webView.CanGoForward)
            {
                webView.GoForward();
            }
        }

        [RelayCommand]
        private void RefreshPage(WebView webView)
        {
            webView.Reload();
        }

        [RelayCommand]
        private async void OpenInBrowser()
        {
            await Launcher.OpenAsync(Source);
        }

    }
}
