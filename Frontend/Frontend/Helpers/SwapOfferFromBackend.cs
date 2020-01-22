using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frontend.Models;

namespace Frontend.Helpers
{
    class SwapOfferFromBackend
    {
        SwapOfferListModel swapOfferListModel;
        public SwapOfferFromBackend()
        {
            swapOfferListModel = SwapOfferListModel.Instance;
        }


        public async Task allSwapOffers()
        {
            List<SwapOfferFrontendModel> swapOffer = new List<SwapOfferFrontendModel>();
            APIClient apiClient = APIClient.Instance;

             var response = await apiClient.NewGETRequest("/rest/lists/swapOffer/all");
            if ((int)response.StatusCode >= 400)
            {
                return;
            }
            swapOffer = JsonConvert.DeserializeObject<List<SwapOfferFrontendModel>>(response.Content.ToString());
            swapOfferListModel.SetList(swapOffer);
            
        }

        public async Task SwapOffersByUser()
        {

            
            List<SwapOfferFrontendModel> swapOffer = new List<SwapOfferFrontendModel>();
            APIClient apiClient = APIClient.Instance;

            var response = await apiClient.NewGETRequest("/rest/lists/swapOffer/me");
            if ((int)response.StatusCode >= 400)
            {
                return;
            }
            swapOffer = JsonConvert.DeserializeObject<List<SwapOfferFrontendModel>>(response.Content.ToString());
            
            
           
            
            swapOfferListModel.SetList(swapOffer);
            
        }




    }
}
