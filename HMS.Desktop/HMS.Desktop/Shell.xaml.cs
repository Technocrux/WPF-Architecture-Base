using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using ModuleTracking;

namespace HMS.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Shell : Window
    {
        private IModuleManager moduleManager;
        private IModuleTracker moduleTracker;
        private CallbackLogger logger;
        private ModuleTrackingState moduleTrackingState;

        public Shell(IModuleManager moduleManager, IModuleTracker moduleTracker, CallbackLogger logger)
        {
            WellKnownModuleNames.Load();
            if (moduleManager == null)
            {
                throw new ArgumentNullException("moduleManager");
            }

            if (moduleTracker == null)
            {
                throw new ArgumentNullException("moduleTracker");
            }

            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }

            this.moduleManager = moduleManager;
            this.moduleTracker = moduleTracker;
            this.logger = logger;
            moduleManager.Run();
            InitializeComponent();


            foreach (var names in WellKnownModuleNames.HelpdeskModuleList)
            {
                this.moduleManager.LoadModuleCompleted += this.ModuleManager_LoadModuleCompleted;
                this.moduleManager.ModuleDownloadProgressChanged += this.ModuleManager_ModuleDownloadProgressChanged;
                this.moduleManager.LoadModule(names);
            }

        }

    
        

        /// <summary>
        /// Raised when the user clicks to load the module.
        /// </summary>
        public event EventHandler RequestModuleLoad;

        private void RaiseRequestModuleLoad()
        {
            if (this.RequestModuleLoad != null)
            {
                this.RequestModuleLoad(this, EventArgs.Empty);
            }
        }

        void ModuleControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            this.OnDataContextChanged();
        }
        /// <summary>
        /// Handles the LoadModuleProgressChanged event of the ModuleManager control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Microsoft.Practices.Composite.Modularity.LoadModuleProgressChangedEventArgs"/> instance containing the event data.</param>
        void ModuleManager_ModuleDownloadProgressChanged(object sender, ModuleDownloadProgressChangedEventArgs e)
        {
            this.moduleTracker.RecordModuleDownloading(e.ModuleInfo.ModuleName, e.BytesReceived, e.TotalBytesToReceive);
        }

        /// <summary>
        /// Handles the LoadModuleCompleted event of the ModuleManager control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Microsoft.Practices.Composite.Modularity.LoadModuleCompletedEventArgs"/> instance containing the event data.</param>
        void ModuleManager_LoadModuleCompleted(object sender, LoadModuleCompletedEventArgs e)
        {
            this.moduleTracker.RecordModuleLoaded(e.ModuleInfo.ModuleName);
        }
        private void OnDataContextChanged()
        {
            if (this.moduleTrackingState != null)
            {
                this.moduleTrackingState.PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(ModuleTrackingState_PropertyChanged);
            }

            this.moduleTrackingState = this.DataContext as ModuleTrackingState;

            if (this.moduleTrackingState != null)
            {
                this.moduleTrackingState.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(ModuleTrackingState_PropertyChanged);
            }

            
        }

        void ModuleTrackingState_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          

        }
        
    }
}
