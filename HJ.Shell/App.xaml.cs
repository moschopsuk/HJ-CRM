using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

using Microsoft.Practices.Prism;
using Microsoft.Practices.Prism.Logging;
using Microsoft.Practices.ServiceLocation;
using HJ.Shell.Adapters;

namespace HJ.Shell
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Bootstrapper bootstrapper = new Bootstrapper();
            bootstrapper.Run();

            var logger = (ILoggerFacade)ServiceLocator.Current.GetInstance(typeof(ILoggerFacade));
            logger.Log("App.OnStartup() completed", Category.Info, Priority.None);
        }
    }
}
