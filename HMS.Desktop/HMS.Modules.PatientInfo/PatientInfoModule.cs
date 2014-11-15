using System;
using System.ComponentModel;
using Microsoft.Practices.Prism.Logging;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using ModuleTracking;

namespace HMS.Modules.PatientInfo
{
    [Module(ModuleName = "PatientInfoModule", OnDemand = true)]
    public class PatientInfoModule : IModule
    {
        private readonly ILoggerFacade logger;
        private readonly IModuleTracker moduleTracker;
        private readonly IRegionManager regionManager;
        
        public PatientInfoModule(IRegionManager regionManager,ILoggerFacade logger, IModuleTracker moduleTracker)
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
          this.moduleTracker.RecordModuleConstructed(WellKnownModuleNames.PatientInfoModule);
        }
        public void Initialize()
        {
            this.moduleTracker.RecordModuleInitialized(WellKnownModuleNames.PatientInfoModule);
            IRegionManager regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
            regionManager.Regions.Remove("MainRegion");
            regionManager.RegisterViewWithRegion("MainRegion", typeof(Views.MainView));
        }
    }
}
