using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.Logging;
using Microsoft.Practices.ServiceLocation;

using HJ.Modules.Customers.Views;

namespace HJ.Modules.Customers
{
    [Module(ModuleName = "Customers")]
    public class CustomersModule : IModule
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;
        private readonly ILoggerFacade _logger;

        public CustomersModule(IUnityContainer Container, IRegionManager RegionManager)
        {
            this._container = Container;
            this._regionManager = RegionManager;
            this._logger = (ILoggerFacade)ServiceLocator.Current.GetInstance(typeof(ILoggerFacade));
        }

        #region IModule Members

        public void Initialize()
        {
           this._logger.Log("CustomersModule.Initialize ...", Category.Info, Priority.None);

            // Register other view objects with DI Container (Unity)
            //var container = ServiceLocator.Current.GetInstance<IUnityContainer>();
            _container.RegisterType<Object, CustomerRibbonTab>("CustomerRibbonTab");
            _regionManager.AddToRegion("ShellRibbon", _container.Resolve<CustomerRibbonTab>());

            _container.RegisterType<Object, CustomersListView>("CustomersListView");
            _regionManager.AddToRegion("WorkspaceRegion", _container.Resolve<CustomersListView>());
        }

        #endregion
    }
}
