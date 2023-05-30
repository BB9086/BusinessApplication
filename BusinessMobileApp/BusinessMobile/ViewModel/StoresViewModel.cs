using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using BusinessMobile.Model;
using BusinessMobile.Services;
using BusinessMobile.View;
using Microsoft.Maui.Networking;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace BusinessMobile.ViewModel
{
    public partial class StoresViewModel : BaseViewModel
    {
        //Initialize Store !!!
        public ObservableCollection<StoreInfo> Stores { get; } = new ();
        StoreService _storeService;
        IConnectivity _connectivity;
        ILogger<StoresViewModel> _logger;

        public StoresViewModel(StoreService storeService, IConnectivity connectivity, ILogger<StoresViewModel> logger)
        {
            _storeService = storeService;
            _connectivity = connectivity;
            _logger = logger;

            //Added to enable loading data on page load event
            Task.Run(async () => await GetStoresAsync());
        }

        [RelayCommand]
        async Task GetStoresAsync()
        {
            if (IsBusy)
                return;

            try
            {
                if (_connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlert("No connectivity!",
                        $"Please check your internet connection", "OK");
                    return;
                }

                IsBusy = true;
                var stores = await _storeService.GetStores();


                // Observable collection for MainPage
                if (Stores.Count != 0)
                    Stores.Clear();

                foreach (var store in stores)
                    Stores.Add(store);
            }
            catch (Exception ex)
            {
                //Shake phone to see all log informations
                _logger.LogInformation($"Error with loading stores: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }

        [RelayCommand]
        async Task GoToMonths(StoreInfo store)
        {
            if (store == null)
                return;

            await Shell.Current.GoToAsync(nameof(MonthsPage), true, new Dictionary<string, object>
        {
            {"Store", store }
        });
        }

    }
}
