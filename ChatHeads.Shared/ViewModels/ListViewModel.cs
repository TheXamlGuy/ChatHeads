using System.Collections.ObjectModel;
using System.Threading;

namespace ChatHeads.Shared.ViewModels
{
    public class ListViewModel<TItemViewModel> : ObservableCollection<TItemViewModel> where TItemViewModel : class
    {
        private readonly SynchronizationContext _synchronizationContext = SynchronizationContext.Current;

        protected override void ClearItems() => _synchronizationContext.Send(new SendOrPostCallback((param) => base.ClearItems()), null);

        protected override void InsertItem(int index, TItemViewModel item) => _synchronizationContext.Send(new SendOrPostCallback((param) => base.InsertItem(index, item)), null);

        protected override void RemoveItem(int index) => _synchronizationContext.Send(new SendOrPostCallback((param) => base.RemoveItem(index)), null);

        protected override void SetItem(int index, TItemViewModel item) => _synchronizationContext.Send(new SendOrPostCallback((param) => base.SetItem(index, item)), null);

        protected override void MoveItem(int oldIndex, int newIndex) => _synchronizationContext.Send(new SendOrPostCallback((param) => base.MoveItem(oldIndex, newIndex)), null);
    }
}
