using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using BusinessMobile.Model;
using BusinessMobile.Services;
using BusinessMobile.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessMobile.ViewModel
{
    [QueryProperty(nameof(Store), "Store")]
    public partial class MonthsViewModel : BaseViewModel
    {

        StoreService _storeService;
        IConnectivity _connectivity;

        //[ObservableProperty]
        //StoreInfo store;

        public ObservableCollection<StoreMonth> StoreMonths { get; } = new();

        // Load initial data to StoreMonths on Page Load , call with parammeteres that is send with query string
        // https://stackoverflow.com/questions/73293779/how-to-pass-query-parameter-to-net-maui-viewmodel
        private StoreInfo store;
        public StoreInfo Store
        {
            get => store;
            set
            {
                SetProperty(ref store, value);
                Task.Run(async () => await GetStoreMonthsAsync(value.Number));
            }
        }

        public MonthsViewModel(StoreService storeService, IConnectivity connectivity)
        {
            _storeService = storeService;
            _connectivity = connectivity;

            //Added to enable loading data on Page load event
            //Can be used if we do not have parameteres in async method
            //Task.Run(async () => await GetStoreMonthsAsync(1));
            //
            //https://stackoverflow.com/questions/73293779/how-to-pass-query-parameter-to-net-maui-viewmodel
        }



        [RelayCommand]
        async Task GetStoreMonthsAsync(int id)
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

                var storeId = store.Id;

                IsBusy = true;
                var storeMonths = await _storeService.GetStoreMonths(id);

                // Observable collection for MonthsPage
                if (StoreMonths.Count != 0)
                    StoreMonths.Clear();

                foreach (var storeMonth in storeMonths)
                    StoreMonths.Add(storeMonth);

            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }

        [RelayCommand]
        async Task GoToYears(StoreInfo store)
        {
            if (store == null)
                return;

            await Shell.Current.GoToAsync(nameof(YearsPage), false, new Dictionary<string, object>
        {
            {"Store", store }
        });
        }

        [RelayCommand]
        async Task GoToStores()
        {
            try 
            {
                //await Shell.Current.GoToAsync("//MainPage");
                await Shell.Current.GoToAsync("StorePage");
            }
            catch(Exception ex) 
            {
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }   
           
        }


    }
}
