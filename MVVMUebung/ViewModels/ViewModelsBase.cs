using Common.Command.NotifyPropertyChanged;
using Microsoft.Practices.Prism.Events;

namespace MVVMUebung.ViewModels
{
    /// <summary>
    /// Base class for all view models
    /// </summary>
    public class ViewModelsBase : NotifyPropertyChanged
    {
        #region ------------------------- Constructors, Destructors, Dispose, Clone ---------------------------------------
        public ViewModelsBase(IEventAggregator eventAggregator) 
        {
            this.EventAggregator = eventAggregator;
        }
        #endregion

        #region ------------------------- Properties, Indexers ------------------------------------------------------------
        protected IEventAggregator EventAggregator { get; set; }
        #endregion
    }
}
