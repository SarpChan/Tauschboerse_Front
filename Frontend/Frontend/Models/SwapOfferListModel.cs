using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Models
{
    class SwapOfferListModel
    {

        private ObservableCollection<SwapOfferFrontendModel> _swapOfferListPersonal = new ObservableCollection<SwapOfferFrontendModel>();

        public ObservableCollection<SwapOfferFrontendModel> SwapOfferListPersonal
        {
            get
            {
                return _swapOfferListPersonal;
            }
        }

        private ObservableCollection<SwapOfferFrontendModel> _swapOfferListPublic = new ObservableCollection<SwapOfferFrontendModel>();

        public ObservableCollection<SwapOfferFrontendModel> SwapOfferListPublic
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

        public void RemoveById(long id)
        {
            foreach (SwapOfferFrontendModel so in _swapOfferListPublic)
            {
                if (id == so.Id)
                {
                    _swapOfferListPublic.Remove(so);
                }
            }
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