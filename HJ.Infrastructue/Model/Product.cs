//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;

namespace HJ.Infrastructue.Model
{
    [DataContract(IsReference = true)]
    public partial class Product: IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public int ProductID
        {
            get { return _productID; }
            set
            {
                if (_productID != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'ProductID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _productID = value;
                    OnPropertyChanged("ProductID");
                }
            }
        }
        private int _productID;
    
        [DataMember]
        public string ProductName
        {
            get { return _productName; }
            set
            {
                if (_productName != value)
                {
                    _productName = value;
                    OnPropertyChanged("ProductName");
                }
            }
        }
        private string _productName;
    
        [DataMember]
        public string ProductGroup
        {
            get { return _productGroup; }
            set
            {
                if (_productGroup != value)
                {
                    _productGroup = value;
                    OnPropertyChanged("ProductGroup");
                }
            }
        }
        private string _productGroup;
    
        [DataMember]
        public decimal ProductPrice
        {
            get { return _productPrice; }
            set
            {
                if (_productPrice != value)
                {
                    _productPrice = value;
                    OnPropertyChanged("ProductPrice");
                }
            }
        }
        private decimal _productPrice;
    
        [DataMember]
        public string ProductCode
        {
            get { return _productCode; }
            set
            {
                if (_productCode != value)
                {
                    _productCode = value;
                    OnPropertyChanged("ProductCode");
                }
            }
        }
        private string _productCode;
    
        [DataMember]
        public bool isDiscontinued
        {
            get { return _isDiscontinued; }
            set
            {
                if (_isDiscontinued != value)
                {
                    _isDiscontinued = value;
                    OnPropertyChanged("isDiscontinued");
                }
            }
        }
        private bool _isDiscontinued;

        #endregion
        #region ChangeTracking
    
        protected virtual void OnPropertyChanged(String propertyName)
        {
            if (ChangeTracker.State != ObjectState.Added && ChangeTracker.State != ObjectState.Deleted)
            {
                ChangeTracker.State = ObjectState.Modified;
            }
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        protected virtual void OnNavigationPropertyChanged(String propertyName)
        {
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged{ add { _propertyChanged += value; } remove { _propertyChanged -= value; } }
        private event PropertyChangedEventHandler _propertyChanged;
        private ObjectChangeTracker _changeTracker;
    
        [DataMember]
        public ObjectChangeTracker ChangeTracker
        {
            get
            {
                if (_changeTracker == null)
                {
                    _changeTracker = new ObjectChangeTracker();
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
                return _changeTracker;
            }
            set
            {
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging -= HandleObjectStateChanging;
                }
                _changeTracker = value;
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
            }
        }
    
        private void HandleObjectStateChanging(object sender, ObjectStateChangingEventArgs e)
        {
            if (e.NewState == ObjectState.Deleted)
            {
                ClearNavigationProperties();
            }
        }
    
        protected bool IsDeserializing { get; private set; }
    
        [OnDeserializing]
        public void OnDeserializingMethod(StreamingContext context)
        {
            IsDeserializing = true;
        }
    
        [OnDeserialized]
        public void OnDeserializedMethod(StreamingContext context)
        {
            IsDeserializing = false;
            ChangeTracker.ChangeTrackingEnabled = true;
        }
    
        protected virtual void ClearNavigationProperties()
        {
        }

        #endregion
    }
}