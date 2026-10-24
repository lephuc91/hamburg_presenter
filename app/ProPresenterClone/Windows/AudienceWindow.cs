using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using ProPresenterClone.Models;
using ProPresenterClone.Rendering;

namespace ProPresenterClone.Windows
{
    /// <summary>
    /// Live Audience Output Window (Secondary Display / Projector Output).
    /// Supports floating 16:9 preview or borderless fullscreen output with smooth transitions.
    /// </summary>
    public sealed class AudienceWindow : Window
    {
        private readonly Grid _surfaceHost;
        private readonly TextBlock _osdBadge;
        private bool _isFullscreen;

        public AudienceWindow()
        {
            Title = "ProPresenter — Audience Output (Double-Click for Fullscreen, Esc to Close)";
            Width = 960;
            Height = 540;
            MinWidth = 480;
            MinHeight = 270;
            Background = Brushes.Black;
            WindowStartupLocation = WindowStartupLocation.Manual;
            Left = Math.Max(40, SystemParameters.WorkArea.Right - 1000);
            Top = 60;

            var root = new Grid { Background = Brushes.Black };
            _surfaceHost = new Grid { Background = Brushes.Black };
            root.Children.Add(_surfaceHost);

            _osdBadge = new TextBlock
            {
                Text = "AUDIENCE LIVE • Double-click to toggle Fullscreen",
                Foreground = new SolidColorBrush(Color.FromArgb(130, 255, 255, 255)),
                FontSize = 11,
                Margin = new Thickness(12, 8, 12, 8),
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Bottom,
                IsHitTestVisible = false
            };
            root.Children.Add(_osdBadge);

            Content = root;

            MouseDoubleClick += (_, _) => ToggleFullscreen();
            MouseLeftButtonDown += (_, e) =>
            {
                if (!_isFullscreen && e.ButtonState == MouseButtonState.Pressed)
                {
                    try { DragMove(); } catch { }
                }
            };
            KeyDown += (_, e) =>
            {
                if (e.Key == Key.Escape)
                {
                    if (_isFullscreen) ToggleFullscreen();
                    else Hide();
                }
                else if (e.Key == Key.F11)
                {
                    ToggleFullscreen();
                }
            };
            SizeChanged += (_, _) => _osdBadge.Visibility = _isFullscreen ? Visibility.Collapsed : Visibility.Visible;
        }

        public void ToggleFullscreen()
        {
            _isFullscreen = !_isFullscreen;
            if (_isFullscreen)
            {
                WindowStyle = WindowStyle.None;
                ResizeMode = ResizeMode.NoResize;
                WindowState = WindowState.Maximized;
                Topmost = true;
                _osdBadge.Visibility = Visibility.Collapsed;
            }
            else
            {
                Topmost = false;
                WindowState = WindowState.Normal;
                WindowStyle = WindowStyle.SingleBorderWindow;
                ResizeMode = ResizeMode.CanResize;
                _osdBadge.Visibility = Visibility.Visible;
            }
        }

        public void UpdateOutput(
            ActiveOutputState state,
            IReadOnlyList<TimerItemModel> timers,
            double animationPhase,
            bool animateTransition = false)
        {
            double w = ActualWidth > 50 ? ActualWidth : Width;
            double h = ActualHeight > 50 ? ActualHeight : Height;

            var visual = SlideCanvasRenderer.RenderCompositeOutput(state, w, h, timers, animationPhase);

            if (animateTransition && state.ActivePresentation != null)
            {
                double durSec = Math.Clamp(state.ActivePresentation.TransitionDurationSeconds, 0.1, 2.5);
                visual.Opacity = 0.0;
                _surfaceHost.Children.Add(visual);
                while (_surfaceHost.Children.Count > 2)
                    _surfaceHost.Children.RemoveAt(0);

                var anim = new DoubleAnimation(0.0, 1.0, TimeSpan.FromSeconds(durSec))
                {
                    EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
                };
                anim.Completed += (_, _) =>
                {
                    while (_surfaceHost.Children.Count > 1)
                        _surfaceHost.Children.RemoveAt(0);
                };
                visual.BeginAnimation(OpacityProperty, anim);
            }
            else
            {
                _surfaceHost.Children.Clear();
                _surfaceHost.Children.Add(visual);
            }
        }
    }
}

