using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Models
{
    class SwapOfferListModel
    {

        private List<SwapOfferFrontendModel> _swapOfferList = new List<SwapOfferFrontendModel>();

        public List<SwapOfferFrontendModel> SwapOfferList
        {
            get
            {
                return _swapOfferList;
            }
        }

        private static SwapOfferListModel _instance;

        public static SwapOfferListModel Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }
                else
                {
                    return new SwapOfferListModel();
                }
            }
        }

        private SwapOfferListModel()
        {
            _instance = this;
        }

        public void addSwapOffer(SwapOfferFrontendModel swapOffer)
        {
            _swapOfferList.Add(swapOffer);
        }

        public void removeSwapOffer(SwapOfferFrontendModel swapOffer)
        {
            _swapOfferList.Remove(swapOffer);
        }


        public void SetList(List<SwapOfferFrontendModel> swapOfferList)
        {
            _swapOfferList = swapOfferList;
        }

    }
}