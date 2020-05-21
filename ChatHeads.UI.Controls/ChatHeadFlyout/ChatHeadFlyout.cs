using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace ChatHeads.UI.Controls
{
    public class ChatHeadFlyout : DependencyObject
    {
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register(nameof(ItemsSource),
                typeof(IEnumerable), typeof(ChatHeadFlyout));

        public static readonly DependencyProperty PlacementProperty = 
            DependencyProperty.Register(nameof(Placement),
                typeof(ChatHeadFlyoutPlacement), typeof(ChatHeadFlyout), 
                new PropertyMetadata(ChatHeadFlyoutPlacement.Top));

        private ChatHeadFlyoutHost _host;

        public ChatHeadFlyout() => PrepareHost();

        public IEnumerable ItemsSource
        {
            get => (IEnumerable)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public ChatHeadFlyoutPlacement Placement
        {
            get => (ChatHeadFlyoutPlacement)GetValue(PlacementProperty);
            set => SetValue(PlacementProperty, value);
        }

        public void Show() => _host.Show();

        private void PrepareHost()
        {
            var presenter = new ChatHeadFlyoutPresenter();
            BindingOperations.SetBinding(presenter, ItemsControl.ItemsSourceProperty, new Binding
            {
                Source = this,
                Path = new PropertyPath(nameof(ItemsSource))
            });

            _host = new ChatHeadFlyoutHost
            {
                Content = presenter
            };
        }
    }
}