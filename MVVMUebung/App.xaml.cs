using Microsoft.Practices.Prism.Events;
using MVVMUebung.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMUebung
{
    /// <summary>
    /// Interaction logic for App
    /// </summary>
    public partial class App : Application
    {

        /// <summary>
        /// Raises the <see cref="System.Windows.Application.Startup"/> event.
        /// </summary>
        /// <param name="e">A <see cref="System.Windows.StartupEventArgs"/>the event data.</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            // Get the reference to the current process
            Process thisProc = Process.GetCurrentProcess();

            // Check how many processes have the same name as the current onne
            if(Process.GetProcessesByName(thisProc.ProcessName).Length > 1)
            {
                MessageBox.Show("Application is already running!");
                Application.Current.Shutdown();
                return;
            }

            // Init event aggregator and services
            IEventAggregator eventAggregator = new EventAggregator();
            // Init view and viewmodel
            MainWindow mainWindow = new MainWindow();
            MainViewModel mainViewModel = new MainViewModel(eventAggregator);
            mainWindow.DataContext = mainViewModel;

            mainWindow.Show();
        }
    }
}
