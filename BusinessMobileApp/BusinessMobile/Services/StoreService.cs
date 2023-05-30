using BusinessMobile.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BusinessMobile.Services
{
    public class StoreService
    {
        private readonly string _url;
        HttpClient httpClient;
        private readonly string _token;

        //Don't forget this.httpClient !!!
        public StoreService()
        {
           this.httpClient = new HttpClient();
            _url = "https://businessapi.azurewebsites.net/api/business";
            _token= Preferences.Default.Get("token", "Unknown");
        }

        List<StoreInfo> storeInfoList;
        List<StoreMonth> storeMonthList;
        List<StoreYear> storeYearList;

        public async Task<List<StoreInfo>> GetStores()
        {
            if (storeInfoList?.Count > 0)
                return storeInfoList;

            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + _token);
            HttpResponseMessage response = await httpClient.GetAsync($"{_url}");
            if (response.IsSuccessStatusCode)
            {
                storeInfoList = await response.Content.ReadFromJsonAsync<List<StoreInfo>>();
            }

            return storeInfoList;
        }

        public async Task<List<StoreMonth>> GetStoreMonths(int id)
        {
            //if (storeMonthList?.Count > 0)
            //    return storeMonthList;

            
            HttpResponseMessage response = await httpClient.GetAsync($"{_url}/GetStoreInfoByMonths/" + id);
            if (response.IsSuccessStatusCode)
            {
                storeMonthList = await response.Content.ReadFromJsonAsync<List<StoreMonth>>();
            }

            return storeMonthList;
        }

        public async Task<List<StoreYear>> GetStoreYears(int id)
        {
            //if (storeYearList?.Count > 0)
            //    return storeYearList;

 
            HttpResponseMessage response = await httpClient.GetAsync($"{_url}/GetStoreInfoByYears/" + id);
            if (response.IsSuccessStatusCode)
            {
                storeYearList = await response.Content.ReadFromJsonAsync<List<StoreYear>>();

                foreach (var item in storeYearList)
                {
                    item.Smonth = item.Smonth.Remove(4, 2);
                }
            }

            return storeYearList;
        }

    }
}
