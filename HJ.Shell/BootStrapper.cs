using System;
using System.Windows;

using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Prism.Regions;

using HJ.Shell.View;
using HJ.Shell.Adapters;
using Microsoft.Practices.Prism.Logging;
using System.Windows.Controls;
using Fluent;
using AvalonDock;
 
namespace HJ.Shell
{
    public partial class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            Shell = Container.TryResolve<ShellView>();       
            return Shell;
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            App.Current.MainWindow = (Window)Shell;
            App.Current.MainWindow.Show();
        }

        protected override ILoggerFacade CreateLogger()
        {
            return new Log4NetAdapter();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            base.CreateModuleCatalog();

            /* Note that each module in this application has a post-build
             * event that copies the module to a 'Modules' subfolder in the 
             * output folder. Prism will use the DirectoryModuleCatalog that 
             * we create here to scan that folder to populate the catalog. */

            // Create a new module catalog and pass it to Prism
            var catalog = new DirectoryModuleCatalog();
            catalog.ModulePath = @".\Modules";
            return catalog;
        }

        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            base.ConfigureDefaultRegionBehaviors();

            var mappings = Container.TryResolve<RegionAdapterMappings>();
            
            if (mappings == null) return null;

            mappings.RegisterMapping(typeof(Ribbon), 
                ServiceLocator.Current.GetInstance<RibbonRegionAdapter>());

            mappings.RegisterMapping(typeof(DockingManager),
                ServiceLocator.Current.GetInstance<AvalonDockRegionAdapter>());

            return mappings;
        } 
    }
}
