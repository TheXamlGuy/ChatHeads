using System;
using System.Windows;
using ChatHeads.Shared.ViewModels;
using ChatHeads.UI.Controls;

namespace ChatHeads
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs args)
        {
            App.Current.Dispatcher.Invoke(() => {
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
