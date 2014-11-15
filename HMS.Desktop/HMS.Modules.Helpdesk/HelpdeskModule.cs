using System;
using System.ComponentModel;
using Microsoft.Practices.Prism.Logging;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using ModuleTracking;

namespace HMS.Modules.Helpdesk
{
    [Module(ModuleName = "HelpdeskModule",OnDemand = true)]
    public class HelpdeskModule :IModule
    {
        private readonly ILoggerFacade logger;
        private readonly IModuleTracker moduleTracker;
        private readonly IRegionManager regionManager;
        
        public HelpdeskModule(IRegionManager regionManager,ILoggerFacade logger, IModuleTracker moduleTracker)
        {

          this.regionManager = regionManager;
          if (logger == null)
          {
              throw new ArgumentNullException("logger");
          }

          if (moduleTracker == null)
          {
              throw new ArgumentNullException("moduleTracker");
          }

          this.logger = logger;
          this.moduleTracker = moduleTracker;
          this.moduleTracker.RecordModuleConstructed(WellKnownModuleNames.HelpdeskModule);
        }
        public void Initialize()
        {
            this.moduleTracker.RecordModuleInitialized(WellKnownModuleNames.HelpdeskModule);
            IRegionManager regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
            regionManager.Regions.Remove("MainRegion");
            
            regionManager.RegisterViewWithRegion("MainRegion", typeof(Views.MainView));
            

        }
    }
}
