// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.Globalization;
using HMS.Desktop.Properties;

namespace HMS.Desktop
{
    using Microsoft.Practices.Prism.Logging;
    using Microsoft.Practices.Prism.Modularity;
    using ModuleTracking;
    using System;

    /// <summary>
    /// Provides tracking of modules for the quickstart.
    /// </summary>
    /// <remarks>
    /// This class is for demonstration purposes for the quickstart and not expected to be used in a real world application.
    /// This class exports the interface for modules and the concrete type for the shell.    
    /// </remarks>    
    public class ModuleTracker : IModuleTracker
    {
        private readonly ModuleTrackingState helpdeskModuleTrackingState;
        
        private ILoggerFacade logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleTracker"/> class.
        /// </summary>
        public ModuleTracker(ILoggerFacade logger)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }
            this.logger = logger;

            this.helpdeskModuleTrackingState = new ModuleTrackingState
            {
                ModuleName = WellKnownModuleNames.HelpdeskModule,
                ExpectedDiscoveryMethod = DiscoveryMethod.DirectorySweep,
                ExpectedInitializationMode = InitializationMode.OnDemand,
                ExpectedDownloadTiming = DownloadTiming.InBackground,
            };
            
            
        }

        /// <summary>
        /// Gets the tracking state of module B.
        /// </summary>
        /// <value>A ModuleTrackingState.</value>
        /// <remarks>
        /// This is exposed as a specific property for data-binding purposes in the quickstart UI.
        /// </remarks>
        public ModuleTrackingState HelpdeskModuleTrackingState
        {
            get
            {
                return this.helpdeskModuleTrackingState;
            }
        }

        
        /// <summary>
        /// Records the module is loading.
        /// </summary>
        /// <param name="moduleName">The <see cref="WellKnownModuleNames">well-known name</see> of the module.</param>
        /// <param name="bytesReceived">The number of bytes downloaded.</param>
        /// <param name="totalBytesToReceive">The total number of bytes received.</param>
        public void RecordModuleDownloading(string moduleName, long bytesReceived, long totalBytesToReceive)
        {
            ModuleTrackingState moduleTrackingState = this.GetModuleTrackingState(moduleName);
            if (moduleTrackingState != null)
            {
                moduleTrackingState.BytesReceived = bytesReceived;
                moduleTrackingState.TotalBytesToReceive = totalBytesToReceive;

                if (bytesReceived < totalBytesToReceive)
                {
                    moduleTrackingState.ModuleInitializationStatus = ModuleInitializationStatus.Downloading;
                }
                else
                {
                    moduleTrackingState.ModuleInitializationStatus = ModuleInitializationStatus.Downloaded;
                }
            }

        }        

        /// <summary>
        /// Records the module has been constructed.
        /// </summary>
        /// <param name="moduleName">The <see cref="WellKnownModuleNames">well-known name</see> of the module.</param>
        public void RecordModuleConstructed(string moduleName)
        {
            ModuleTrackingState moduleTrackingState = this.GetModuleTrackingState(moduleName);
            if (moduleTrackingState != null)
            {
                moduleTrackingState.ModuleInitializationStatus = ModuleInitializationStatus.Constructed;
            }

        }

        /// <summary>
        /// Records the module has been initialized.
        /// </summary>
        /// <param name="moduleName">The <see cref="WellKnownModuleNames">well-known name</see> of the module.</param>
        public void RecordModuleInitialized(string moduleName)
        {
            ModuleTrackingState moduleTrackingState = this.GetModuleTrackingState(moduleName);
            if (moduleTrackingState != null)
            {
                moduleTrackingState.ModuleInitializationStatus = ModuleInitializationStatus.Initialized;
            }


        }

        /// <summary>
        /// Records the module is loaded.
        /// </summary>
        /// <param name="moduleName">The <see cref="WellKnownModuleNames">well-known name</see> of the module.</param>
        public void RecordModuleLoaded(string moduleName)
        {
        }

        // A helper to make updating specific property instances by name easier.
        private ModuleTrackingState GetModuleTrackingState(string moduleName)
        {
            switch (moduleName)
            {
                case WellKnownModuleNames.HelpdeskModule:
                    return this.helpdeskModuleTrackingState;
                default:
                    return null;
            }
        }
    }
}
