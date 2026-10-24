using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using ProPresenterClone.Models;

namespace ProPresenterClone.Windows
{
    /// <summary>
    /// Live Stage Display (Confidence Monitor) Window and reusable renderer for Stage Preview.
    /// Shows Wall Clock, Countdown/Sermon Timers, Current Slide, Next Slide, Slide Notes, and Stage Messages.
    /// </summary>
    public sealed class StageWindow : Window
    {
        private readonly Grid _host;
        private bool _isFullscreen;

        public StageWindow()
        {
            Title = "ProPresenter — Stage Display (Double-Click for Fullscreen, Esc to Close)";
            Width = 920;
            Height = 520;
            MinWidth = 480;
            MinHeight = 270;
            Background = new SolidColorBrush(Color.FromRgb(0x0D, 0x0E, 0x11));
            WindowStartupLocation = WindowStartupLocation.Manual;
            Left = Math.Max(40, SystemParameters.WorkArea.Right - 960);
            Top = Math.Max(60, SystemParameters.WorkArea.Bottom - 580);

            _host = new Grid();
            Content = _host;

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
            }
            else
            {
                Topmost = false;
                WindowState = WindowState.Normal;
                WindowStyle = WindowStyle.SingleBorderWindow;
                ResizeMode = ResizeMode.CanResize;
            }
        }

        public void UpdateStage(ActiveOutputState state, IReadOnlyList<TimerItemModel> timers)
        {
            double w = ActualWidth > 50 ? ActualWidth : Width;
            double h = ActualHeight > 50 ? ActualHeight : Height;
            _host.Children.Clear();
            _host.Children.Add(RenderStageView(state, timers, w, h));
        }

        public static FrameworkElement RenderStageView(
            ActiveOutputState state,
            IReadOnlyList<TimerItemModel> timers,
            double width,
            double height)
        {
            double scale = width / 1280.0;
            var layout = state.ActiveStageLayout ?? new StageLayoutModel();

            var root = new Grid
            {
                Width = width,
                Height = height,
                Background = new SolidColorBrush(Color.FromRgb(0x0B, 0x0C, 0x0F))
            };
            root.RowDefinitions.Add(new RowDefinition { Height = new GridLength(Math.Max(34, 86 * scale)) });
            root.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            root.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            // Top Header: Wall Clock + Active Timers + Layout Name
            var topBar = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(0x14, 0x16, 0x1C)),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x2D, 0x31, 0x3C)),
                BorderThickness = new Thickness(0, 0, 0, Math.Max(1, 2 * scale)),
                Padding = new Thickness(20 * scale, 6 * scale, 20 * scale, 6 * scale)
            };

            var topGrid = new Grid();
            topGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            topGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            topGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            if (layout.ShowWallClock)
            {
                var clockStack = new StackPanel { Orientation = Orientation.Horizontal, VerticalAlignment = VerticalAlignment.Center };
                clockStack.Children.Add(new TextBlock
                {
                    Text = "CLOCK  ",
                    Foreground = new SolidColorBrush(Color.FromRgb(0x88, 0x92, 0xA6)),
                    FontSize = Math.Max(8, 16 * scale),
                    FontWeight = FontWeights.SemiBold,
                    VerticalAlignment = VerticalAlignment.Center
                });
                clockStack.Children.Add(new TextBlock
                {
                    Text = DateTime.Now.ToString("hh:mm:ss tt"),
                    Foreground = Brushes.White,
                    FontFamily = new FontFamily("Consolas, Roboto Mono"),
                    FontSize = Math.Max(12, 34 * scale),
                    FontWeight = FontWeights.Bold,
                    VerticalAlignment = VerticalAlignment.Center
                });
                Grid.SetColumn(clockStack, 0);
                topGrid.Children.Add(clockStack);
            }

            var stageTitle = new TextBlock
            {
                Text = "STAGE DISPLAY • " + layout.Name.ToUpperInvariant(),
                Foreground = new SolidColorBrush(Color.FromRgb(0xF7, 0x82, 0x1C)),
                FontSize = Math.Max(7, 14 * scale),
                FontWeight = FontWeights.Bold,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            Grid.SetColumn(stageTitle, 1);
            topGrid.Children.Add(stageTitle);

            if (layout.ShowTimers && timers.Count > 0)
            {
                var timerPanel = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    HorizontalAlignment = HorizontalAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Center
                };
                foreach (var t in timers.Take(2))
                {
                    Color timerCol = t.Remaining.TotalSeconds < 0
                        ? Color.FromRgb(0xFF, 0x45, 0x45)
                        : (t.IsRunning ? Color.FromRgb(0x33, 0xFD, 0x00) : Color.FromRgb(0x9B, 0xE7, 0xFF));

                    var tBox = new Border
                    {
                        Background = new SolidColorBrush(Color.FromRgb(0x1E, 0x22, 0x2B)),
                        BorderBrush = new SolidColorBrush(timerCol),
                        BorderThickness = new Thickness(1),
                        CornerRadius = new CornerRadius(4 * scale),
                        Padding = new Thickness(12 * scale, 3 * scale, 12 * scale, 3 * scale),
                        Margin = new Thickness(10 * scale, 0, 0, 0)
                    };
                    var tStack = new StackPanel { Orientation = Orientation.Horizontal };
                    tStack.Children.Add(new TextBlock
                    {
                        Text = t.Name.ToUpperInvariant() + ": ",
                        Foreground = new SolidColorBrush(Color.FromRgb(0xB0, 0xB8, 0xC8)),
                        FontSize = Math.Max(7, 15 * scale),
                        VerticalAlignment = VerticalAlignment.Center
                    });
                    tStack.Children.Add(new TextBlock
                    {
                        Text = t.FormattedValue,
                        Foreground = new SolidColorBrush(timerCol),
                        FontFamily = new FontFamily("Consolas, Roboto Mono"),
                        FontSize = Math.Max(11, 30 * scale),
                        FontWeight = FontWeights.Bold,
                        VerticalAlignment = VerticalAlignment.Center
                    });
                    tBox.Child = tStack;
                    timerPanel.Children.Add(tBox);
                }
                Grid.SetColumn(timerPanel, 2);
                topGrid.Children.Add(timerPanel);
            }

            topBar.Child = topGrid;
            Grid.SetRow(topBar, 0);
            root.Children.Add(topBar);

            // Body: Current Slide + Next Slide + Slide Notes
            var bodyGrid = new Grid { Margin = new Thickness(18 * scale) };
            if (layout.LargeTimerMode)
            {
                var primaryTimer = timers.FirstOrDefault() ?? new TimerItemModel();
                var giantTimer = new StackPanel
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };
                giantTimer.Children.Add(new TextBlock
                {
                    Text = primaryTimer.Name.ToUpperInvariant(),
                    Foreground = new SolidColorBrush(Color.FromRgb(0x90, 0x99, 0xAA)),
                    FontSize = Math.Max(10, 28 * scale),
                    FontWeight = FontWeights.Bold,
                    HorizontalAlignment = HorizontalAlignment.Center
                });
                giantTimer.Children.Add(new TextBlock
                {
                    Text = primaryTimer.FormattedValue,
                    Foreground = new SolidColorBrush(primaryTimer.Remaining.TotalSeconds < 0
                        ? Color.FromRgb(0xFF, 0x44, 0x44)
                        : Color.FromRgb(0x33, 0xFD, 0x00)),
                    FontFamily = new FontFamily("Consolas"),
                    FontSize = Math.Max(26, 150 * scale),
                    FontWeight = FontWeights.Bold,
                    HorizontalAlignment = HorizontalAlignment.Center
                });
                bodyGrid.Children.Add(giantTimer);
            }
            else
            {
                bodyGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(6.2, GridUnitType.Star) });
                bodyGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(16 * scale) });
                bodyGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(3.8, GridUnitType.Star) });

                // Left: Current Slide
                string curGroup = state.ActiveSlide != null
                    ? $"CURRENT SLIDE  •  {state.ActiveSlide.GroupName.ToUpperInvariant()} (#{state.ActiveSlide.SlideNumber})"
                    : "CURRENT SLIDE  •  [CLEARED]";
                string curText = state.ActiveSlide != null && !string.IsNullOrWhiteSpace(state.ActiveSlide.PrimaryText)
                    ? state.ActiveSlide.PrimaryText
                    : "— No Active Slide —";

                var currentCard = CreateStageCard(
                    curGroup,
                    curText,
                    Color.FromRgb(0xF7, 0x82, 0x1C),
                    Colors.White,
                    Math.Max(11, 38 * scale),
                    scale);
                Grid.SetColumn(currentCard, 0);
                bodyGrid.Children.Add(currentCard);

                // Right: Next Slide + Notes
                var rightGrid = new Grid();
                rightGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(6.5, GridUnitType.Star) });
                rightGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(12 * scale) });
                rightGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(3.5, GridUnitType.Star) });

                string nextGroup = state.NextSlide != null
                    ? $"NEXT SLIDE  •  {state.NextSlide.GroupName.ToUpperInvariant()} (#{state.NextSlide.SlideNumber})"
                    : "NEXT SLIDE";
                string nextText = state.NextSlide != null && !string.IsNullOrWhiteSpace(state.NextSlide.PrimaryText)
                    ? state.NextSlide.PrimaryText
                    : "— End of Presentation —";

                var nextCard = CreateStageCard(
                    nextGroup,
                    nextText,
                    Color.FromRgb(0x00, 0x7A, 0xFF),
                    Color.FromRgb(0xD5, 0xDE, 0xEC),
                    Math.Max(9, 25 * scale),
                    scale);
                Grid.SetRow(nextCard, 0);
                rightGrid.Children.Add(nextCard);

                string notesText = !string.IsNullOrWhiteSpace(state.ActiveSlide?.Notes)
                    ? state.ActiveSlide!.Notes
                    : (state.ActivePresentation != null ? $"Presentation: {state.ActivePresentation.Name} • Key: C Major • Tempo: 72 BPM" : "Stage Notes / Chords");

                var notesCard = CreateStageCard(
                    "SLIDE NOTES & CHORDS",
                    notesText,
                    Color.FromRgb(0x61, 0xBA, 0x46),
                    Color.FromRgb(0xFF, 0xE0, 0x82),
                    Math.Max(8, 20 * scale),
                    scale);
                Grid.SetRow(notesCard, 2);
                rightGrid.Children.Add(notesCard);

                Grid.SetColumn(rightGrid, 2);
                bodyGrid.Children.Add(rightGrid);
            }

            Grid.SetRow(bodyGrid, 1);
            root.Children.Add(bodyGrid);

            // Bottom Stage Message Bar
            if (state.ActiveMessage != null && state.ActiveMessage.IsActive && state.ActiveMessage.ShowOnStage)
            {
                var stageMsgBar = new Border
                {
                    Background = new SolidColorBrush(Color.FromRgb(0xD0, 0x1F, 0x1F)),
                    Padding = new Thickness(20 * scale, 10 * scale, 20 * scale, 10 * scale),
                    Child = new TextBlock
                    {
                        Text = "STAGE MESSAGE:  " + state.ActiveMessage.ResolvedMessage,
                        Foreground = Brushes.White,
                        FontSize = Math.Max(10, 28 * scale),
                        FontWeight = FontWeights.Bold,
                        TextAlignment = TextAlignment.Center
                    }
                };
                Grid.SetRow(stageMsgBar, 2);
                root.Children.Add(stageMsgBar);
            }

            return root;
        }

        private static Border CreateStageCard(
            string headerTitle,
            string contentText,
            Color headerAccent,
            Color textColor,
            double fontSize,
            double scale)
        {
            var card = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(0x15, 0x18, 0x20)),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x2E, 0x33, 0x40)),
                BorderThickness = new Thickness(1),
                CornerRadius = new CornerRadius(6 * scale),
                ClipToBounds = true
            };

            var grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            var header = new Border
            {
                Background = new SolidColorBrush(Color.FromArgb(65, headerAccent.R, headerAccent.G, headerAccent.B)),
                BorderBrush = new SolidColorBrush(headerAccent),
                BorderThickness = new Thickness(0, 0, 0, Math.Max(1, 2 * scale)),
                Padding = new Thickness(14 * scale, 6 * scale, 14 * scale, 6 * scale),
                Child = new TextBlock
                {
                    Text = headerTitle,
                    Foreground = new SolidColorBrush(headerAccent),
                    FontSize = Math.Max(7, 14 * scale),
                    FontWeight = FontWeights.Bold
                }
            };
            Grid.SetRow(header, 0);
            grid.Children.Add(header);

            var body = new TextBlock
            {
                Text = contentText,
                Foreground = new SolidColorBrush(textColor),
                FontFamily = new FontFamily("Roboto, Segoe UI"),
                FontSize = fontSize,
                FontWeight = FontWeights.SemiBold,
                TextAlignment = TextAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                TextWrapping = TextWrapping.Wrap,
                Margin = new Thickness(18 * scale)
            };
            Grid.SetRow(body, 1);
            grid.Children.Add(body);

            card.Child = grid;
            return card;
        }
    }
}

