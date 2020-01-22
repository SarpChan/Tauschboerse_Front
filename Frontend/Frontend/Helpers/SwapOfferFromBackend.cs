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


        private async Task RequestNewsFromServerAsync(long id)
        {

            SwapOfferFilter swapOfferFilter = new SwapOfferFilter
            {
                attribute = "forOwnderId",
                comperatorValue = id,
                comperatorType = "EQUALS"
            };
            List<SwapOfferFrontendModel> swapOffer = new List<SwapOfferFrontendModel>();
            APIClient apiClient = APIClient.Instance;
            var response = await apiClient.NewPOSTRequest("/rest/lists/swapOffer", JsonConvert.SerializeObject(swapOffer, Formatting.Indented));
            if ((int)response.StatusCode >= 400)
            {
                return;
            }
            swapOffer = JsonConvert.DeserializeObject<List<SwapOfferFrontendModel>>(response.Content.ToString());
            swapOfferListModel.SetList(swapOffer);
        }

    }
}
