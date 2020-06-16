using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using Xamarin.Forms;
using System.IO;

namespace ImageListTest.ViewModel
{
    public class OrderItemImageDocuViewModel 
    {
        #region Klassenvariablen

        private readonly int _pagingSize = 20;

        private int _itemsToLoadCount;
        private ObservableCollection<RequestItemImageDocument> _orderItemImages = new ObservableCollection<RequestItemImageDocument>();
        #endregion Klassenvariablen

        #region Konstruktor

        public OrderItemImageDocuViewModel()
        {

        }

        #endregion Konstruktor

        #region Properties


        public ObservableCollection<RequestItemImageDocument> OrderItemImages
        {
            get
            {

                return _orderItemImages;
            }
            set
            {
                _orderItemImages = value;
            }
        }
        #endregion Properties

    }
}
