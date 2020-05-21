using System.Windows;
using ChatHeads.Shared.ViewModels;
using ChatHeads.Views;

namespace ChatHeads
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs args)
        {
            Current.Dispatcher.Invoke(() => {
                var flyout = new ChatHeadFlyout
                {
                    ItemsSource = new ChatHeadListViewModel()
                };

                flyout.Show();
            });
      

            base.OnStartup(args);
        }
    }
}
