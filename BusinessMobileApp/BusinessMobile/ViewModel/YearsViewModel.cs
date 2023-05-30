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
    public partial class YearsViewModel : BaseViewModel
    {

        StoreService _storeService;
        IConnectivity _connectivity;

        //[ObservableProperty]
        //StoreInfo store;

        public ObservableCollection<StoreYear> StoreYears { get; } = new();

        // Load initial data to StoreMonths on Page Load , call with parammeteres that is send with query string
        // https://stackoverflow.com/questions/73293779/how-to-pass-query-parameter-to-net-maui-viewmodel
        private StoreInfo store;
        public StoreInfo Store
        {
            get => store;
            set
            {
                SetProperty(ref store, value);
                Task.Run(async () => await GetStoreYearsAsync(value.Number));
            }
        }

        public YearsViewModel(StoreService storeService, IConnectivity connectivity)
        {
            _storeService = storeService;
            _connectivity = connectivity;
        }


        [RelayCommand]
        async Task GetStoreYearsAsync(int id)
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
                var storeYears = await _storeService.GetStoreYears(id);

                // Observable collection for MonthsPage
                if (StoreYears.Count != 0)
                    StoreYears.Clear();

                foreach (var storeYear in storeYears)
                {
                    //storeYear.Smonth = storeYear.Smonth.Remove(4, 2);
                    StoreYears.Add(storeYear);
                }


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
        async Task GoToMonths(StoreInfo store)
        {
            if (store == null)
                return;

            //false - turn off animation
            await Shell.Current.GoToAsync(nameof(MonthsPage), false, new Dictionary<string, object>
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
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }

        }

    }
}


