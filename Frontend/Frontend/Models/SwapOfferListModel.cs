using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Models
{
    class SwapOfferListModel
    {

        private List<SwapOfferFrontendModel> _swapOfferListPersonal = new List<SwapOfferFrontendModel>();

        public List<SwapOfferFrontendModel> SwapOfferListPersonal
        {
            get
            {
                return _swapOfferListPersonal;
            }
        }

        private List<SwapOfferFrontendModel> _swapOfferListPublic = new List<SwapOfferFrontendModel>();

        public List<SwapOfferFrontendModel> SwapOfferListPublic
        {
            get
            {
                return _swapOfferListPublic;
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

        public void AddSwapOffer(SwapOfferFrontendModel swapOffer, bool isPublic)
        {
            if (isPublic) _swapOfferListPublic.Add(swapOffer);
            else _swapOfferListPersonal.Add(swapOffer);
        }

        public void RemoveSwapOffer(SwapOfferFrontendModel swapOffer, bool isPublic)
        {
            if (isPublic) _swapOfferListPersonal.Remove(swapOffer);
            else _swapOfferListPersonal.Remove(swapOffer);
        }


        public void SetList(IList<SwapOfferFrontendModel> swapOfferList, bool isPublic)
        {
            if (isPublic)
            {
                _swapOfferListPublic.Clear();
                foreach (SwapOfferFrontendModel swapOffer in swapOfferList)
                {
                    _swapOfferListPublic.Add(swapOffer);
                }

            }
            else
            {
                _swapOfferListPersonal.Clear();
                foreach (SwapOfferFrontendModel swapOffer in swapOfferList)
                {
                    _swapOfferListPersonal.Add(swapOffer);
                }
            }
            
            
        }

    }
}