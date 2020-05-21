using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Threading;

namespace ChatHeads.Shared.ViewModels
{
    public class ListViewModel<TItemViewModel> : ObservableCollection<TItemViewModel> where TItemViewModel : class
    {
        private SynchronizationContext _synchronizationContext = SynchronizationContext.Current;

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs args)
        {
            if (SynchronizationContext.Current == _synchronizationContext)
            {
                RaiseCollectionChanged(args);
            }
            else
            {
                _synchronizationContext.Send(RaiseCollectionChanged, args);
            }
        }

        private void RaiseCollectionChanged(object param) => base.OnCollectionChanged((NotifyCollectionChangedEventArgs)param);

        protected override void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            if (SynchronizationContext.Current == _synchronizationContext)
            {
                RaisePropertyChanged(args);
            }
            else
            {
                _synchronizationContext.Send(RaisePropertyChanged, args);
            }
        }

        private void RaisePropertyChanged(object param) => base.OnPropertyChanged((PropertyChangedEventArgs)param);
    }
}
