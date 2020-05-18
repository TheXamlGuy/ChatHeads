using System.Windows;
using System.Windows.Controls;
using ChatHeads.UI.Controls;

namespace ChatHeads
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs args)
        {
            var flyout = new ChatHeadFlyout();
            flyout.Show();

            base.OnStartup(args);
        }
    }
}
