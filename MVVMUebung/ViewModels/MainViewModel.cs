using Common.Command;
using Common.Command.NotifyPropertyChanged;
using Microsoft.Practices.Prism.Events;
using MVVMUebung.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace MVVMUebung.ViewModels
{
    /// <summary>
    /// Main ViewModel of the application
    /// </summary>
    public class MainViewModel : ViewModelsBase
    {
        #region ------------------------- Fields, Constants, Delegates, Events --------------------------------------------
        /// <summary>
        /// View that is currently bound to the <see cref="ContentControl"/> left.
        /// </summary>
        private UserControl currentViewLeft;
        private PAYDAY payday;
        #endregion

        #region ------------------------- Constructors, Destructors, Dispose, Clone ---------------------------------------
        /// <summary>
        /// Initialize a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        public MainViewModel(IEventAggregator eventAggregator) : base(eventAggregator)
        {
            payday = new PAYDAY();
            PAYDAYModel payDayModel = new PAYDAYModel(this.EventAggregator);
            payday.DataContext = payDayModel;
            PayDayViewComman = new ActionCommand(this.GameCommandExecute, this.GameCommandCanExecute);
        }
        #endregion

        #region ------------------------- Properties, Indexers ------------------------------------------------------------
        /// <summary>
        /// Gets the students view button command.
        /// </summary>
        public ICommand PayDayViewComman { get; private set; }

        /// <summary>
        /// Gets and sets the view that is currently bound to the <see cref="ContentControl"/> left.
        /// </summary>
        public UserControl CurrentViewLeft
        {
            get 
            { 
                return this.currentViewLeft; 
            }

            set 
            { 
                if (this.currentViewLeft != value)
                {
                    this.currentViewLeft = value;
                    this.OnPropertyChanged(nameof(this.CurrentViewLeft));
                }
            }
        }

        #endregion

        #region ------------------------- Private helper ------------------------------------------------------------------

        #endregion

        #region ------------------------- Commands ------------------------------------------------------------------------
        private bool GameCommandCanExecute(object parameter)
        {
            return true;
        }

        private void GameCommandExecute(object parameter)
        {
           
            this.CurrentViewLeft = this.CurrentViewLeft == null ? this.payday : null;
        }
        #endregion
    }
}
