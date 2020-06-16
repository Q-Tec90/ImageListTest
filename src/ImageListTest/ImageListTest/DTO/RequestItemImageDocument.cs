using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace ImageListTest
{
    [DataContract]
    public class RequestItemImageDocument : INotifyPropertyChanged
    {

        #region Fields
        private Guid _requestItemImageDocId;
        private Guid _orderItemId;
        private byte[] _imagedocData;
        private string _documentDescription;
        private DateTime? _storageDate;
        private byte _isSynced;
        #endregion

        #region Properties
        [DataMember]
        public Guid RequestItemImageDocumentId
        {
            get
            {
                return _requestItemImageDocId;
            }
            set
            {
                _requestItemImageDocId = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("RequestItemImageDocumentId"));
            }
        }
        [DataMember]
        public Guid OrderItemId
        {
            get
            {
                return _orderItemId;
            }
            set
            {
                _orderItemId = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("OrderItemId"));
            }
        }

        [DataMember]
        public byte[] ImageDocumentData
        {
            get
            {
                return _imagedocData;
            }
            set
            {
                _imagedocData = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ImageDocumentData"));
                    //PropertyChanged(this, new PropertyChangedEventArgs("RequestItemImageSource"));
                }
            }
        }
        [DataMember]
        public string DocumentDescription
        {
            get
            {
                return _documentDescription;
            }
            set
            {
                _documentDescription = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("DocumentDescription"));
            }
        }
        [DataMember]
        public DateTime? StorageDate
        {
            get
            {
                return _storageDate;
            }
            set
            {
                _storageDate = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("StorageDate"));
            }
        }
        [DataMember]
        public byte IsSynced
        {
            get
            {
                return _isSynced;
            }
            set
            {
                _isSynced = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("IsSynced"));
            }
        }
        #endregion
        #region Constr
        public RequestItemImageDocument()
        {

        }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
