using Frontend.Helpers.Generators;
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
        private ObservableCollection<SwapOffer> _swapOfferList = new ObservableCollection<SwapOffer>();
        public ObservableCollection<SwapOffer> SwapOfferList { get { return _swapOfferList; } }

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

        private void AddSwapOffer(SwapOffer so)
        {
            _swapOfferList.Add(so);
        }

        private void RemoveSwapOffer(SwapOffer so)
        {
            _swapOfferList.Remove(so);
        }

        public void SetSwapOfferList(ObservableCollection<SwapOffer> swapOfferList)
        {
            _swapOfferList = swapOfferList;
        }

        public void RemoveById(long id)
        {   
            SwapOffer rm = FindSwapOfferByID(id);
            RemoveSwapOffer(rm);
        }

        public void AddById(long id)
        {
            SwapOffer add = FindSwapOfferByID(id);
            AddSwapOffer(add);
        }

        private SwapOffer FindSwapOfferByID(long id)
        {
            foreach (var so in SwapOfferList)
            {
                if (so.id == id) { return so; };
            }
            return null;
        }

    }
}