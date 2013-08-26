using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;

using Microsoft.Practices.Prism.Logging;
using Microsoft.Practices.ServiceLocation;

using GalaSoft.MvvmLight;

using HJ.Infrastructue.Model;
using HJ.Modules.Customers.CustomerServiceRefernce;
using System.ComponentModel;

namespace HJ.Modules.Customers.ViewModel
{
    class CustomerListViewModel : ViewModelBase
    {
        readonly ILoggerFacade _logger = (ILoggerFacade)ServiceLocator.Current.GetInstance(typeof(ILoggerFacade));
        BindingList<Customer> _customerList;
        bool _busyIndicator;

        #region public properties

        public BindingList<Customer> CustomerList
        {
            get { return this._customerList; }
            set
            {
                this._customerList = value;
                RaisePropertyChanged("CustomerList");
            }
        }

        public bool BusyIndicator
        {
            get { return this._busyIndicator; }
            set
            {
                this._busyIndicator = value;
                RaisePropertyChanged("BusyIndicator");
            }
        }

        #endregion

        public CustomerListViewModel()
        {
            this._customerList = new BindingList<Customer>();
            this.GetCustomers();
        }

        /// <summary>
        /// Fetches Customers from WCF service
        /// Runs process in background worker thread
        /// </summary>
        void GetCustomers()
        {
            BackgroundWorker bgworker = new BackgroundWorker();
            //this is where the long running process should go
            bgworker.DoWork += (o, ea) =>
            {
                _logger.Log("Fetching Customer List", Category.Info, Priority.Low);

                CustomerServiceClient client = new CustomerServiceClient();

                //stop and events that may orrur needing the UI thread
                this._customerList.RaiseListChangedEvents = false;

                foreach (Customer c in client.GetAll())
                    this._customerList.Add(c);

                client.Close();
            };

            bgworker.RunWorkerCompleted += (o, ea) =>
            {
                _logger.Log("Fetched Customer " + ea.Result, Category.Info, Priority.Low);

                //work has completed. you can now interact with the UI
                this.BusyIndicator = false;

                //Should their be an exception we should still
                //relase the UI
                this._customerList.RaiseListChangedEvents = true;
                this._customerList.ResetBindings();
            };

            //set the IsBusy before you start the thread
            this.BusyIndicator = true;
            this._customerList.Clear();
            bgworker.RunWorkerAsync();
        }
    }
}
