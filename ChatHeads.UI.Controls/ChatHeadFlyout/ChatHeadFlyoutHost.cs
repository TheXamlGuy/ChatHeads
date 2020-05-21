using ChatHeads.UI.Helpers;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;

namespace ChatHeads.UI.Controls
{
    internal class ChatHeadFlyoutHost : Window
    {
        public static readonly DependencyProperty PlacementProperty =
            DependencyProperty.Register(nameof(Placement),
                typeof(ChatHeadFlyoutPlacement), typeof(ChatHeadFlyoutHost),
                new PropertyMetadata(ChatHeadFlyoutPlacement.Top, OnPlacementPropertyChanged));

        private static void OnPlacementPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            var sender = dependencyObject as ChatHeadFlyoutHost;
            sender?.OnPlacementPropertyChanged();
        }

        private void OnPlacementPropertyChanged() => SetPlacement();

        private void SetPlacement()
        {
            switch (Placement)
            {
                case ChatHeadFlyoutPlacement.Left:
                    Left = 0;
                    break;
                case ChatHeadFlyoutPlacement.Right:
                {
                    var handle = new WindowInteropHelper(this).Handle;
                    var screen = ScreenHelper.FromHandle(handle);

                    var workingArea = screen.WorkingArea;

                    Left = workingArea.Right - Width;
                    break;
                }
            }
        }

        public ChatHeadFlyoutPlacement Placement
        {
            get => (ChatHeadFlyoutPlacement)GetValue(PlacementProperty);
            set => SetValue(PlacementProperty, value);
        }

        public ChatHeadFlyoutHost()
        {
            AllowsTransparency = true;
            WindowStyle = WindowStyle.None;
            ShowActivated = true;
            ShowInTaskbar = false;
            ResizeMode = ResizeMode.NoResize;
            SizeToContent = SizeToContent.WidthAndHeight;
            Background = new SolidColorBrush(Colors.Transparent);
            Topmost = true;
        }

        protected override void OnMouseDown(MouseButtonEventArgs args)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        protected override void OnMouseUp(MouseButtonEventArgs args)
        {
            if (Mouse.LeftButton == MouseButtonState.Released)
            {
                var handle = new WindowInteropHelper(this).Handle;
                var screen = ScreenHelper.FromHandle(handle);

                var workingArea = screen.WorkingArea;

                var windowBounds = WindowHelper.GetBounds(this);

                var topDistance = workingArea.Top + windowBounds.Top + Height / 2;

                var leftDistance = workingArea.Left + windowBounds.Left + Width / 2;
                var rightDistance = workingArea.Width - windowBounds.Left + Width / 2;

                ClearValue(PlacementProperty);

                if (rightDistance < leftDistance)
                {
                    SetValue(PlacementProperty, ChatHeadFlyoutPlacement.Right);
                }
                else
                {
                    SetValue(PlacementProperty, ChatHeadFlyoutPlacement.Left);
                }
            }
        }
    }
}
