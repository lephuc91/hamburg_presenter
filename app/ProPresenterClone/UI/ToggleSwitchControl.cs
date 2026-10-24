using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace ProPresenterClone.UI
{
    /// <summary>
    /// Exact replica of Pro.UI.Controls.ToggleSwitch.
    /// iOS-style animated pill toggle switch (Width=44, Height=22).
    /// Displays green (#34C759) when checked and dark slate (#3A3A3C) when unchecked.
    /// </summary>
    public sealed class ToggleSwitchControl : Control
    {
        public static readonly DependencyProperty IsCheckedProperty =
            DependencyProperty.Register(
                nameof(IsChecked),
                typeof(bool),
                typeof(ToggleSwitchControl),
                new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnIsCheckedChanged));

        public bool IsChecked
        {
            get => (bool)GetValue(IsCheckedProperty);
            set => SetValue(IsCheckedProperty, value);
        }

        public event EventHandler<bool>? IsCheckedChanged;

        private Border? _trackBorder;
        private Ellipse? _thumbEllipse;
        private TranslateTransform? _thumbTransform;

        private static readonly SolidColorBrush OnTrackBrush = new SolidColorBrush(Color.FromRgb(0x34, 0xC7, 0x59));
        private static readonly SolidColorBrush OffTrackBrush = new SolidColorBrush(Color.FromRgb(0x3A, 0x3A, 0x3C));
        private static readonly SolidColorBrush ThumbBrush = new SolidColorBrush(Colors.White);

        static ToggleSwitchControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(ToggleSwitchControl),
                new FrameworkPropertyMetadata(typeof(ToggleSwitchControl)));
        }

        public ToggleSwitchControl()
        {
            Width = 44;
            Height = 22;
            Cursor = Cursors.Hand;
            Focusable = true;

            BuildVisualTree();
        }

        private void BuildVisualTree()
        {
            _trackBorder = new Border
            {
                Width = 44,
                Height = 22,
                CornerRadius = new CornerRadius(11),
                Background = IsChecked ? OnTrackBrush : OffTrackBrush,
                ClipToBounds = true
            };

            var canvas = new Canvas
            {
                Width = 44,
                Height = 22
            };

            _thumbTransform = new TranslateTransform(IsChecked ? 22 : 0, 0);

            _thumbEllipse = new Ellipse
            {
                Width = 18,
                Height = 18,
                Fill = ThumbBrush,
                RenderTransform = _thumbTransform
            };
            Canvas.SetLeft(_thumbEllipse, 2);
            Canvas.SetTop(_thumbEllipse, 2);

            canvas.Children.Add(_thumbEllipse);
            _trackBorder.Child = canvas;

            AddVisualChild(_trackBorder);
            AddLogicalChild(_trackBorder);
        }

        protected override int VisualChildrenCount => _trackBorder != null ? 1 : 0;

        protected override Visual GetVisualChild(int index)
        {
            if (index != 0 || _trackBorder == null)
                throw new ArgumentOutOfRangeException(nameof(index));
            return _trackBorder;
        }

        protected override Size MeasureOverride(Size constraint)
        {
            _trackBorder?.Measure(new Size(44, 22));
            return new Size(44, 22);
        }

        protected override Size ArrangeOverride(Size arrangeBounds)
        {
            _trackBorder?.Arrange(new Rect(0, 0, 44, 22));
            return arrangeBounds;
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            Focus();
            IsChecked = !IsChecked;
            e.Handled = true;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.Key == Key.Space || e.Key == Key.Enter)
            {
                IsChecked = !IsChecked;
                e.Handled = true;
            }
        }

        private static void OnIsCheckedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ToggleSwitchControl ctrl)
            {
                ctrl.UpdateVisualState((bool)e.NewValue, animate: true);
                ctrl.IsCheckedChanged?.Invoke(ctrl, (bool)e.NewValue);
            }
        }

        private void UpdateVisualState(bool isChecked, bool animate)
        {
            if (_trackBorder == null || _thumbTransform == null)
                return;

            double targetX = isChecked ? 22 : 0;
            Brush targetBrush = isChecked ? OnTrackBrush : OffTrackBrush;

            if (animate)
            {
                var anim = new DoubleAnimation(targetX, TimeSpan.FromMilliseconds(150))
                {
                    EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
                };
                _thumbTransform.BeginAnimation(TranslateTransform.XProperty, anim);
                _trackBorder.Background = targetBrush;
            }
            else
            {
                _thumbTransform.BeginAnimation(TranslateTransform.XProperty, null);
                _thumbTransform.X = targetX;
                _trackBorder.Background = targetBrush;
            }
        }
    }
}

