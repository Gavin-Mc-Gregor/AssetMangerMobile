using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagerMobile.Models
{
    class CItemManager
    {

        public async Task<IEnumerable<CItem>> GetAll()
        {
            HttpClient client = GetClient();
            HttpResponseMessage response = await client.GetAsync(CConstants.GetItemsUrl);
            HttpContent content = response.Content;

            string result = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<CItem>>(result);
        }

        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
           
            return client;
        }
    }

}
