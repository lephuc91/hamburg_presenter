using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using ProPresenterClone.Models;
using ProPresenterClone.Rendering;
using ProPresenterClone.Theming;
using ProPresenterClone.Windows;

namespace ProPresenterClone.UI
{
    public sealed partial class MainWindow
    {
        private readonly Dictionary<string, Button> _utilityTabButtons = new Dictionary<string, Button>();

        private FrameworkElement BuildRightDockColumn()
        {
            var rightGrid = new Grid
            {
                Background = ThemeEngine.Instance.GetBrush("OUTLINEDETAIL", Color.FromRgb(0x23, 0x24, 0x29))
            };
            rightGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto }); // ScreenPreviewControl + Clear Layer Bank
            rightGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto }); // TransportStatusControl
            rightGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }); // UtilityView (6 tabs)
            rightGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(32) }); // Status row (ITEMS • MINUTES)

            // 1. Top: ScreenPreviewControl + 8 Layer Clear Buttons
            var previewSection = BuildScreenPreviewAndClearBank();
            Grid.SetRow(previewSection, 0);
            rightGrid.Children.Add(previewSection);

            // 2. Middle: TransportStatusControl
            var transportSection = BuildTransportStatusControl();
            Grid.SetRow(transportSection, 1);
            rightGrid.Children.Add(transportSection);

            // 3. Bottom: UtilityView (Timers, Messages, Props, Stage, Macros, Audio Bin)
            var utilitySection = BuildUtilityViewSection();
            Grid.SetRow(utilitySection, 2);
            rightGrid.Children.Add(utilitySection);

            // 4. Footer: Status row (ITEMS • MINUTES)
            var footerSection = BuildRightColumnFooterBar();
            Grid.SetRow(footerSection, 3);
            rightGrid.Children.Add(footerSection);

            return rightGrid;
        }

        private FrameworkElement BuildRightColumnFooterBar()
        {
            var bar = new Border
            {
                Height = 32,
                Background = ThemeEngine.Instance.GetBrush("HEADER", Color.FromRgb(0x18, 0x18, 0x1B)),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x2D, 0x2D, 0x35)),
                BorderThickness = new Thickness(1, 1, 0, 0),
                Padding = new Thickness(12, 0, 12, 0)
            };

            _rightStatusLabel = new TextBlock
            {
                Text = "2 ITEMS • 12 MINUTES",
                Foreground = new SolidColorBrush(Color.FromRgb(0xDC, 0xDC, 0xE4)),
                FontSize = 10.5,
                FontWeight = FontWeights.SemiBold,
                VerticalAlignment = VerticalAlignment.Center
            };

            bar.Child = _rightStatusLabel;
            UpdateRightColumnBottomStatus();
            return bar;
        }

        public void UpdateRightColumnBottomStatus()
        {
            if (_rightStatusLabel == null) return;
            int itemCount = _selectedPresentation?.Slides?.Count ?? 0;
            if (_selectedPlaylist != null && _selectedPlaylist.Items.Count > 0)
            {
                itemCount = _selectedPlaylist.Items.Count;
            }
            if (itemCount == 0) itemCount = 2;
            int minutes = (itemCount == 2) ? 12 : Math.Max(1, (int)Math.Round(itemCount * 3.5));
            _rightStatusLabel.Text = $"{itemCount} {(itemCount == 1 ? "ITEM" : "ITEMS")} • {minutes} MINUTES";
        }

        private FrameworkElement BuildScreenPreviewAndClearBank()
        {
            var container = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(0x18, 0x19, 0x1D)),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x32, 0x33, 0x3B)),
                BorderThickness = new Thickness(0, 0, 0, 1),
                Padding = new Thickness(10, 8, 10, 8)
            };

            var stack = new StackPanel { Orientation = Orientation.Vertical };

            // Preview Header Row (Output Mode Selector + Popout Screen buttons)
            var hdrDock = new DockPanel { Margin = new Thickness(0, 0, 0, 6) };
            var modeButtons = new StackPanel { Orientation = Orientation.Horizontal };

            var audModeBtn = CreateSmallHeaderButton(
                !_isStagePreviewMode ? "● Audience" : "Audience",
                !_isStagePreviewMode ? Color.FromRgb(0x00, 0x7A, 0xFF) : Color.FromRgb(0x30, 0x31, 0x3A),
                () =>
                {
                    _isStagePreviewMode = false;
                    RefreshPreviewAndOutputs();
                });

            var stgModeBtn = CreateSmallHeaderButton(
                _isStagePreviewMode ? "● Stage" : "Stage",
                _isStagePreviewMode ? Color.FromRgb(0xF7, 0x82, 0x1C) : Color.FromRgb(0x30, 0x31, 0x3A),
                () =>
                {
                    _isStagePreviewMode = true;
                    RefreshPreviewAndOutputs();
                });

            modeButtons.Children.Add(audModeBtn);
            modeButtons.Children.Add(stgModeBtn);
            DockPanel.SetDock(modeButtons, Dock.Right);
            hdrDock.Children.Add(modeButtons);

            _previewPresentationTitleLabel = new TextBlock
            {
                Text = "LIVE OUTPUT PREVIEW",
                Foreground = new SolidColorBrush(Color.FromRgb(0xC8, 0xCE, 0xDC)),
                FontSize = 11,
                FontWeight = FontWeights.Bold,
                VerticalAlignment = VerticalAlignment.Center,
                TextTrimming = TextTrimming.CharacterEllipsis
            };
            hdrDock.Children.Add(_previewPresentationTitleLabel);
            stack.Children.Add(hdrDock);

            // Preview Monitor + Right Clear Layer Bank
            var monitorGrid = new Grid();
            monitorGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            monitorGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(8) });
            monitorGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(76) });

            var monitorBorder = new Border
            {
                Height = 186,
                CornerRadius = new CornerRadius(4),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x42, 0x45, 0x52)),
                BorderThickness = new Thickness(1.5),
                Background = Brushes.Black,
                ClipToBounds = true
            };
            _previewMonitorSurface = new Grid { Width = 312, Height = 176 };
            monitorBorder.Child = new Viewbox
            {
                Stretch = Stretch.Uniform,
                Child = _previewMonitorSurface
            };
            Grid.SetColumn(monitorBorder, 0);
            monitorGrid.Children.Add(monitorBorder);

            // Right Vertical / 2-Column Bank of 8 Clear Layer Buttons (matching ScreenPreviewControl.xaml)
            var clearBank = new UniformGrid
            {
                Columns = 2,
                Rows = 4,
                VerticalAlignment = VerticalAlignment.Stretch
            };
            _clearLayerButtons.Clear();

            var clearDefs = new (string Key, string Label, string IconPath, string ToolTip)[]
            {
                ("All", "All", "clearlayer/clearbuttonall-2x.png", "Clear All Layers [F1]"),
                ("Slide", "Slide", "clearlayer/clearbuttonslide-2x.png", "Clear Slide Layer [F2]"),
                ("Media", "Media", "clearlayer/clearbuttonmedia-2x.png", "Clear Background Media [F3]"),
                ("Props", "Props", "clearlayer/clearbuttonprops-2x.png", "Clear Props Layer [F4]"),
                ("Messages", "Msgs", "clearlayer/clearbuttonmessages-2x.png", "Clear Stage/Audience Messages [F6]"),
                ("Audio", "Audio", "clearlayer/clearbuttonaudio-2x.png", "Clear Audio Track [F7]"),
                ("VideoInput", "Video", "clearlayer/clearbuttonlivevideo-2x.png", "Clear Live Video Input"),
                ("Logo", "Logo", "clearlayer/clearbuttonlogo-2x.png", "Toggle Clear to Church Logo [F8]")
            };

            foreach (var def in clearDefs)
            {
                string capturedKey = def.Key;
                var btnBorder = new Border
                {
                    Margin = new Thickness(1.5),
                    CornerRadius = new CornerRadius(4),
                    Background = new SolidColorBrush(Color.FromRgb(0x28, 0x28, 0x2F)),
                    BorderBrush = new SolidColorBrush(Color.FromRgb(0x3D, 0x3D, 0x46)),
                    BorderThickness = new Thickness(1),
                    Cursor = Cursors.Hand,
                    ToolTip = def.ToolTip
                };

                var btnStack = new StackPanel
                {
                    Orientation = Orientation.Vertical,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };

                var icon = ThemeEngine.Instance.GetIcon(def.IconPath);
                if (icon != null)
                {
                    btnStack.Children.Add(new Image
                    {
                        Source = icon,
                        Width = 17,
                        Height = 17,
                        Margin = new Thickness(0, 1, 0, 1)
                    });
                }

                btnStack.Children.Add(new TextBlock
                {
                    Text = def.Label,
                    Foreground = Brushes.White,
                    FontSize = 9.5,
                    FontWeight = FontWeights.SemiBold,
                    HorizontalAlignment = HorizontalAlignment.Center
                });

                btnBorder.Child = btnStack;
                btnBorder.MouseLeftButtonDown += (_, _) => ClearLayer(capturedKey);
                _clearLayerButtons[capturedKey] = btnBorder;
                clearBank.Children.Add(btnBorder);
            }

            Grid.SetColumn(clearBank, 2);
            monitorGrid.Children.Add(clearBank);

            stack.Children.Add(monitorGrid);
            container.Child = stack;
            return container;
        }

        private FrameworkElement BuildTransportStatusControl()
        {
            var border = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(0x1D, 0x1E, 0x23)),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x32, 0x33, 0x3C)),
                BorderThickness = new Thickness(0, 0, 0, 1),
                Padding = new Thickness(10, 6, 10, 6)
            };

            var stack = new StackPanel { Orientation = Orientation.Vertical };

            var topDock = new DockPanel { Margin = new Thickness(0, 0, 0, 4) };
            _transportTimeLabel = new TextBlock
            {
                Text = "00:00 / 00:30",
                Foreground = new SolidColorBrush(Color.FromRgb(0x9E, 0xA4, 0xB2)),
                FontSize = 11,
                FontFamily = new FontFamily("Consolas"),
                VerticalAlignment = VerticalAlignment.Center
            };
            DockPanel.SetDock(_transportTimeLabel, Dock.Right);
            topDock.Children.Add(_transportTimeLabel);

            _transportTitleLabel = new TextBlock
            {
                Text = "No Active Media / Audio Track",
                Foreground = Brushes.White,
                FontSize = 11.5,
                FontWeight = FontWeights.SemiBold,
                TextTrimming = TextTrimming.CharacterEllipsis
            };
            topDock.Children.Add(_transportTitleLabel);
            stack.Children.Add(topDock);

            var controlsGrid = new Grid();
            controlsGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            controlsGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            controlsGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            _transportPlayPauseBtn = CreateSmallHeaderButton("⏯", Color.FromRgb(0x35, 0x36, 0x42), () =>
            {
                if (_outputState.ActiveAudioTrack != null)
                {
                    _outputState.IsAudioPlaying = !_outputState.IsAudioPlaying;
                    if (_outputState.IsAudioPlaying) _audioPlayer.Play();
                    else _audioPlayer.Pause();
                    RefreshPreviewAndOutputs();
                }
            });
            Grid.SetColumn(_transportPlayPauseBtn, 0);
            controlsGrid.Children.Add(_transportPlayPauseBtn);

            _transportSlider = new Slider
            {
                Minimum = 0,
                Maximum = 100,
                Value = 0,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(6, 0, 6, 0)
            };
            _transportSlider.ValueChanged += (_, e) =>
            {
                if (_transportSlider.IsMouseCaptureWithin && _transportDurationSeconds > 0)
                {
                    _transportProgressSeconds = (e.NewValue / 100.0) * _transportDurationSeconds;
                    UpdateTransportBarLabels();
                }
            };
            Grid.SetColumn(_transportSlider, 1);
            controlsGrid.Children.Add(_transportSlider);

            var stopBtn = CreateSmallHeaderButton("⏹ Clear", Color.FromRgb(0x45, 0x28, 0x28), () =>
            {
                ClearLayer("Media");
                ClearLayer("Audio");
            });
            Grid.SetColumn(stopBtn, 2);
            controlsGrid.Children.Add(stopBtn);

            stack.Children.Add(controlsGrid);
            border.Child = stack;
            return border;
        }

        private void UpdateTransportBarLabels()
        {
            if (_transportTimeLabel == null || _transportSlider == null)
                return;

            var cur = TimeSpan.FromSeconds(_transportProgressSeconds);
            var tot = TimeSpan.FromSeconds(Math.Max(1, _transportDurationSeconds));
            _transportTimeLabel.Text = $"{cur.Minutes:00}:{cur.Seconds:00} / {tot.Minutes:00}:{tot.Seconds:00}";

            if (!_transportSlider.IsMouseCaptureWithin && _transportDurationSeconds > 0)
            {
                _transportSlider.Value = Math.Clamp((_transportProgressSeconds / _transportDurationSeconds) * 100.0, 0, 100);
            }
        }

        private FrameworkElement BuildUtilityViewSection()
        {
            var grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(36) }); // 6 Utility Tab Buttons
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }); // Tab Content

            var tabBar = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(0x16, 0x17, 0x1C)),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x30, 0x31, 0x38)),
                BorderThickness = new Thickness(0, 0, 0, 1),
                Padding = new Thickness(4, 3, 4, 3)
            };

            var tabUniform = new UniformGrid { Columns = 6, Rows = 1 };
            _utilityTabButtons.Clear();

            string[] tabs = { "Timers", "Messages", "Props", "Stage", "Macros", "Audio" };
            foreach (string t in tabs)
            {
                string capturedTab = t;
                var btn = new Button
                {
                    Content = capturedTab,
                    FontSize = 11,
                    FontWeight = FontWeights.SemiBold,
                    Foreground = Brushes.White,
                    BorderThickness = new Thickness(0),
                    Margin = new Thickness(1),
                    Cursor = Cursors.Hand
                };
                btn.Click += (_, _) =>
                {
                    _activeUtilityTab = capturedTab;
                    RebuildUtilityTabContent();
                };
                _utilityTabButtons[capturedTab] = btn;
                tabUniform.Children.Add(btn);
            }

            tabBar.Child = tabUniform;
            Grid.SetRow(tabBar, 0);
            grid.Children.Add(tabBar);

            _utilityTabContentHost = new Grid
            {
                Background = new SolidColorBrush(Color.FromRgb(0x20, 0x21, 0x27))
            };
            Grid.SetRow(_utilityTabContentHost, 1);
            grid.Children.Add(_utilityTabContentHost);

            RebuildUtilityTabContent();
            return grid;
        }

        private void RebuildUtilityTabContent()
        {
            if (_utilityTabContentHost == null)
                return;

            foreach (var kv in _utilityTabButtons)
            {
                kv.Value.Background = kv.Key == _activeUtilityTab
                    ? new SolidColorBrush(Color.FromRgb(0x00, 0x7A, 0xFF))
                    : new SolidColorBrush(Color.FromRgb(0x28, 0x29, 0x32));
            }

            _utilityTabContentHost.Children.Clear();
            var scroll = new ScrollViewer
            {
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                Padding = new Thickness(10)
            };

            switch (_activeUtilityTab)
            {
                case "Timers":
                    scroll.Content = BuildTimersUtilityPane();
                    break;
                case "Messages":
                    scroll.Content = BuildMessagesUtilityPane();
                    break;
                case "Props":
                    scroll.Content = BuildPropsUtilityPane();
                    break;
                case "Stage":
                    scroll.Content = BuildStageUtilityPane();
                    break;
                case "Macros":
                    scroll.Content = BuildMacrosUtilityPane();
                    break;
                case "Audio":
                    scroll.Content = BuildAudioBinUtilityPane();
                    break;
            }

            _utilityTabContentHost.Children.Add(scroll);
        }

        private FrameworkElement BuildTimersUtilityPane()
        {
            var stack = new StackPanel { Orientation = Orientation.Vertical };

            var hdrDock = new DockPanel { Margin = new Thickness(0, 0, 0, 8) };
            var addBtn = CreateSmallHeaderButton("+ New Timer", Color.FromRgb(0x00, 0x7A, 0xFF), () =>
            {
                _timers.Add(new TimerItemModel
                {
                    Name = $"Custom Countdown {_timers.Count + 1}",
                    Mode = TimerMode.Countdown,
                    Duration = TimeSpan.FromMinutes(10),
                    Remaining = TimeSpan.FromMinutes(10),
                    IsRunning = false
                });
                RebuildUtilityTabContent();
            });
            DockPanel.SetDock(addBtn, Dock.Right);
            hdrDock.Children.Add(addBtn);
            hdrDock.Children.Add(new TextBlock
            {
                Text = "SHOW TIMERS & CLOCKS",
                Foreground = new SolidColorBrush(Color.FromRgb(0xF7, 0x82, 0x1C)),
                FontSize = 11,
                FontWeight = FontWeights.Bold,
                VerticalAlignment = VerticalAlignment.Center
            });
            stack.Children.Add(hdrDock);

            foreach (var timer in _timers)
            {
                var captured = timer;
                var card = new Border
                {
                    Background = new SolidColorBrush(Color.FromRgb(0x2A, 0x2B, 0x33)),
                    BorderBrush = new SolidColorBrush(captured.IsRunning ? Color.FromRgb(0x33, 0xFD, 0x00) : Color.FromRgb(0x3E, 0x40, 0x4A)),
                    BorderThickness = new Thickness(captured.IsRunning ? 1.5 : 1),
                    CornerRadius = new CornerRadius(5),
                    Padding = new Thickness(10, 8, 10, 8),
                    Margin = new Thickness(0, 0, 0, 8)
                };

                var cardStack = new StackPanel();
                var topRow = new DockPanel();
                topRow.Children.Add(new TextBlock
                {
                    Text = captured.Name,
                    Foreground = Brushes.White,
                    FontSize = 12.5,
                    FontWeight = FontWeights.Bold,
                    VerticalAlignment = VerticalAlignment.Center
                });

                var readout = new TextBlock
                {
                    Text = captured.FormattedValue,
                    Foreground = new SolidColorBrush(captured.IsRunning ? Color.FromRgb(0x52, 0xFF, 0x78) : Color.FromRgb(0xFF, 0xD5, 0x4F)),
                    FontSize = 20,
                    FontWeight = FontWeights.Bold,
                    FontFamily = new FontFamily("Consolas"),
                    HorizontalAlignment = HorizontalAlignment.Right
                };
                DockPanel.SetDock(readout, Dock.Right);
                topRow.Children.Add(readout);
                cardStack.Children.Add(topRow);

                var btnRow = new WrapPanel { Margin = new Thickness(0, 6, 0, 0) };
                btnRow.Children.Add(CreateSmallHeaderButton(
                    captured.IsRunning ? "⏸ Pause" : "▶ Start",
                    captured.IsRunning ? Color.FromRgb(0xD9, 0x6B, 0x00) : Color.FromRgb(0x2E, 0x8B, 0x57),
                    () =>
                    {
                        captured.IsRunning = !captured.IsRunning;
                        RebuildUtilityTabContent();
                        RefreshPreviewAndOutputs();
                    }));

                btnRow.Children.Add(CreateSmallHeaderButton("↺ Reset", Color.FromRgb(0x3A, 0x3B, 0x45), () =>
                {
                    captured.Remaining = captured.Duration;
                    RebuildUtilityTabContent();
                    RefreshPreviewAndOutputs();
                }));

                btnRow.Children.Add(CreateSmallHeaderButton("+1m", Color.FromRgb(0x3A, 0x3B, 0x45), () =>
                {
                    captured.Remaining += TimeSpan.FromMinutes(1);
                    captured.Duration += TimeSpan.FromMinutes(1);
                    RebuildUtilityTabContent();
                    RefreshPreviewAndOutputs();
                }));

                btnRow.Children.Add(CreateSmallHeaderButton("Project Countdown Slide", Color.FromRgb(0x00, 0x59, 0x99), () =>
                {
                    ProjectTimerSlide(captured);
                }));

                cardStack.Children.Add(btnRow);
                card.Child = cardStack;
                stack.Children.Add(card);
            }

            return stack;
        }

        private void ProjectTimerSlide(TimerItemModel timer)
        {
            var slide = new SlideItemModel
            {
                SlideNumber = 1,
                GroupName = "Countdown",
                GroupColor = Color.FromRgb(0xF7, 0x82, 0x1C),
                Elements = new List<SlideElementModel>
                {
                    new SlideElementModel
                    {
                        Kind = SlideElementKind.TimerToken,
                        Text = $"{timer.Name.ToUpperInvariant()}\n{{Timer}}",
                        X = 0.1,
                        Y = 0.22,
                        Width = 0.8,
                        Height = 0.56,
                        FontSize = 68,
                        IsBold = true,
                        TextColor = Colors.White
                    }
                }
            };
            timer.IsRunning = true;
            _outputState.ActiveSlide = slide;
            RefreshPreviewAndOutputs(animateAudienceTransition: true);
            RebuildUtilityTabContent();
            SetStatus($"Projected Live Countdown Timer '{timer.Name}' to Audience & Stage outputs.");
        }

        private FrameworkElement BuildMessagesUtilityPane()
        {
            var stack = new StackPanel { Orientation = Orientation.Vertical };
            stack.Children.Add(new TextBlock
            {
                Text = "STAGE & AUDIENCE MESSAGES",
                Foreground = new SolidColorBrush(Color.FromRgb(0xF7, 0x82, 0x1C)),
                FontSize = 11,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(0, 0, 0, 8)
            });

            foreach (var msg in _messages)
            {
                var captured = msg;
                var card = new Border
                {
                    Background = new SolidColorBrush(Color.FromRgb(0x2A, 0x2B, 0x33)),
                    BorderBrush = new SolidColorBrush(captured.IsActive ? Color.FromRgb(0xF7, 0x82, 0x1C) : Color.FromRgb(0x3E, 0x40, 0x4A)),
                    BorderThickness = new Thickness(captured.IsActive ? 2 : 1),
                    CornerRadius = new CornerRadius(5),
                    Padding = new Thickness(10),
                    Margin = new Thickness(0, 0, 0, 8)
                };

                var cStack = new StackPanel();
                cStack.Children.Add(new TextBlock
                {
                    Text = captured.Title,
                    Foreground = Brushes.White,
                    FontWeight = FontWeights.Bold,
                    FontSize = 12
                });
                cStack.Children.Add(new TextBlock
                {
                    Text = captured.TemplateText,
                    Foreground = new SolidColorBrush(Color.FromRgb(0xA4, 0xAC, 0xBC)),
                    FontSize = 11,
                    Margin = new Thickness(0, 2, 0, 6)
                });

                var tokenRow = new DockPanel { Margin = new Thickness(0, 0, 0, 6) };
                tokenRow.Children.Add(new TextBlock
                {
                    Text = $"{{{captured.TokenName}}}: ",
                    Foreground = Brushes.White,
                    FontSize = 11.5,
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(0, 0, 6, 0)
                });
                var tokenBox = new TextBox
                {
                    Text = captured.TokenValue,
                    Background = new SolidColorBrush(Color.FromRgb(0x16, 0x17, 0x1C)),
                    Foreground = Brushes.White,
                    CaretBrush = Brushes.White,
                    Padding = new Thickness(5, 3, 5, 3)
                };
                tokenBox.TextChanged += (_, _) =>
                {
                    captured.TokenValue = tokenBox.Text;
                    if (captured.IsActive)
                        RefreshPreviewAndOutputs();
                };
                tokenRow.Children.Add(tokenBox);
                cStack.Children.Add(tokenRow);

                var actionRow = new WrapPanel();
                actionRow.Children.Add(CreateSmallHeaderButton(
                    captured.IsActive ? "● Showing (Click to Hide)" : "Show Message",
                    captured.IsActive ? Color.FromRgb(0xD0, 0x1F, 0x1F) : Color.FromRgb(0x00, 0x7A, 0xFF),
                    () =>
                    {
                        bool nextState = !captured.IsActive;
                        foreach (var m in _messages) m.IsActive = false;
                        captured.IsActive = nextState;
                        _outputState.ActiveMessage = nextState ? captured : null;
                        RefreshPreviewAndOutputs();
                        RebuildUtilityTabContent();
                        SetStatus(nextState ? $"Showing Message: {captured.ResolvedMessage}" : "Cleared Message Layer.");
                    }));

                actionRow.Children.Add(CreateSmallHeaderButton(
                    captured.ShowOnAudience ? "✓ Audience" : "Audience",
                    captured.ShowOnAudience ? Color.FromRgb(0x2E, 0x6F, 0x40) : Color.FromRgb(0x38, 0x38, 0x42),
                    () =>
                    {
                        captured.ShowOnAudience = !captured.ShowOnAudience;
                        RefreshPreviewAndOutputs();
                        RebuildUtilityTabContent();
                    }));

                actionRow.Children.Add(CreateSmallHeaderButton(
                    captured.ShowOnStage ? "✓ Stage" : "Stage",
                    captured.ShowOnStage ? Color.FromRgb(0x2E, 0x6F, 0x40) : Color.FromRgb(0x38, 0x38, 0x42),
                    () =>
                    {
                        captured.ShowOnStage = !captured.ShowOnStage;
                        RefreshPreviewAndOutputs();
                        RebuildUtilityTabContent();
                    }));

                cStack.Children.Add(actionRow);
                card.Child = cStack;
                stack.Children.Add(card);
            }

            return stack;
        }

        private FrameworkElement BuildPropsUtilityPane()
        {
            var stack = new StackPanel { Orientation = Orientation.Vertical };
            stack.Children.Add(new TextBlock
            {
                Text = "PROPS OVERLAY LAYER",
                Foreground = new SolidColorBrush(Color.FromRgb(0xF7, 0x82, 0x1C)),
                FontSize = 11,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(0, 0, 0, 8)
            });

            foreach (var prop in _props)
            {
                var captured = prop;
                var card = new Border
                {
                    Background = new SolidColorBrush(Color.FromRgb(0x2A, 0x2B, 0x33)),
                    BorderBrush = new SolidColorBrush(captured.IsActive ? Color.FromRgb(0xF7, 0x82, 0x1C) : Color.FromRgb(0x3E, 0x40, 0x4A)),
                    BorderThickness = new Thickness(captured.IsActive ? 2 : 1),
                    CornerRadius = new CornerRadius(5),
                    Padding = new Thickness(10),
                    Margin = new Thickness(0, 0, 0, 8),
                    Cursor = Cursors.Hand
                };

                var dock = new DockPanel();
                var toggleBtn = CreateSmallHeaderButton(
                    captured.IsActive ? "ON" : "OFF",
                    captured.IsActive ? Color.FromRgb(0xF7, 0x82, 0x1C) : Color.FromRgb(0x3A, 0x3B, 0x44),
                    () => TogglePropItem(captured));
                DockPanel.SetDock(toggleBtn, Dock.Right);
                dock.Children.Add(toggleBtn);

                var infoStack = new StackPanel();
                infoStack.Children.Add(new TextBlock
                {
                    Text = captured.Name,
                    Foreground = Brushes.White,
                    FontWeight = FontWeights.Bold,
                    FontSize = 12
                });
                infoStack.Children.Add(new TextBlock
                {
                    Text = $"{captured.BadgeText} • {captured.SubText} ({captured.Position})",
                    Foreground = new SolidColorBrush(Color.FromRgb(0xA4, 0xAC, 0xBC)),
                    FontSize = 11,
                    TextTrimming = TextTrimming.CharacterEllipsis
                });
                dock.Children.Add(infoStack);

                card.Child = dock;
                stack.Children.Add(card);
            }

            return stack;
        }

        private void TogglePropItem(PropItemModel prop)
        {
            prop.IsActive = !prop.IsActive;
            _outputState.ActiveProps.Clear();
            _outputState.ActiveProps.AddRange(_props.Where(p => p.IsActive));
            RefreshPreviewAndOutputs();
            RebuildUtilityTabContent();
            SetStatus(prop.IsActive ? $"Enabled Prop Overlay: {prop.Name}" : $"Disabled Prop Overlay: {prop.Name}");
        }

        private FrameworkElement BuildStageUtilityPane()
        {
            var stack = new StackPanel { Orientation = Orientation.Vertical };
            stack.Children.Add(new TextBlock
            {
                Text = "STAGE DISPLAY CONFIDENCE MONITOR",
                Foreground = new SolidColorBrush(Color.FromRgb(0xF7, 0x82, 0x1C)),
                FontSize = 11,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(0, 0, 0, 8)
            });

            stack.Children.Add(CreateSmallHeaderButton(
                _stageWindow?.IsVisible == true ? "✓ Stage Display Window Open (Click to Hide)" : "🖥 Open Live Stage Display Window",
                Color.FromRgb(0x00, 0x7A, 0xFF),
                () => ToggleStageOutputWindow(forceOpenWindow: true)));

            stack.Children.Add(new TextBlock
            {
                Text = "Select Stage Display Layout:",
                Foreground = Brushes.White,
                FontSize = 11.5,
                FontWeight = FontWeights.SemiBold,
                Margin = new Thickness(0, 10, 0, 6)
            });

            foreach (var layout in _stageLayouts)
            {
                var captured = layout;
                bool active = _outputState.ActiveStageLayout == captured;
                var row = new Border
                {
                    Background = new SolidColorBrush(active ? Color.FromRgb(0x26, 0x3B, 0x5E) : Color.FromRgb(0x2A, 0x2B, 0x33)),
                    BorderBrush = new SolidColorBrush(active ? Color.FromRgb(0x00, 0xA8, 0xFF) : Color.FromRgb(0x3E, 0x40, 0x4A)),
                    BorderThickness = new Thickness(1.5),
                    CornerRadius = new CornerRadius(4),
                    Padding = new Thickness(10, 7, 10, 7),
                    Margin = new Thickness(0, 0, 0, 6),
                    Cursor = Cursors.Hand,
                    Child = new TextBlock
                    {
                        Text = (active ? "●  " : "○  ") + captured.Name,
                        Foreground = Brushes.White,
                        FontWeight = FontWeights.SemiBold,
                        FontSize = 12
                    }
                };
                row.MouseLeftButtonDown += (_, _) =>
                {
                    _outputState.ActiveStageLayout = captured;
                    _isStagePreviewMode = true;
                    RefreshPreviewAndOutputs();
                    RebuildUtilityTabContent();
                    SetStatus($"Switched Stage Display Layout to '{captured.Name}'.");
                };
                stack.Children.Add(row);
            }

            return stack;
        }

        private FrameworkElement BuildMacrosUtilityPane()
        {
            var stack = new StackPanel { Orientation = Orientation.Vertical };
            stack.Children.Add(new TextBlock
            {
                Text = "SHOW AUTOMATION MACROS",
                Foreground = new SolidColorBrush(Color.FromRgb(0xF7, 0x82, 0x1C)),
                FontSize = 11,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(0, 0, 0, 8)
            });

            foreach (var macro in _macros)
            {
                var captured = macro;
                var card = new Border
                {
                    Background = new SolidColorBrush(Color.FromRgb(0x2A, 0x2B, 0x33)),
                    BorderBrush = new SolidColorBrush(captured.Color),
                    BorderThickness = new Thickness(3, 1, 1, 1),
                    CornerRadius = new CornerRadius(4),
                    Padding = new Thickness(10, 8, 10, 8),
                    Margin = new Thickness(0, 0, 0, 8),
                    Cursor = Cursors.Hand
                };

                var dock = new DockPanel();
                var triggerBtn = CreateSmallHeaderButton("▶ Run", captured.Color, () => ExecuteMacro(captured));
                DockPanel.SetDock(triggerBtn, Dock.Right);
                dock.Children.Add(triggerBtn);

                var info = new StackPanel();
                info.Children.Add(new TextBlock
                {
                    Text = captured.Name,
                    Foreground = Brushes.White,
                    FontWeight = FontWeights.Bold,
                    FontSize = 12
                });
                info.Children.Add(new TextBlock
                {
                    Text = captured.Description,
                    Foreground = new SolidColorBrush(Color.FromRgb(0xA4, 0xAC, 0xBC)),
                    FontSize = 10.5,
                    TextTrimming = TextTrimming.CharacterEllipsis
                });
                dock.Children.Add(info);

                card.Child = dock;
                stack.Children.Add(card);
            }

            return stack;
        }

        private void ExecuteMacro(MacroItemModel macro)
        {
            switch (macro.ActionType)
            {
                case "PreService":
                    if (_timers.Count > 0) _timers[0].IsRunning = true;
                    if (_mediaBinItems.Count > 1) TriggerMediaItem(_mediaBinItems[1]);
                    if (_props.Count > 1)
                    {
                        _props[1].IsActive = true;
                        _outputState.ActiveProps.Clear();
                        _outputState.ActiveProps.AddRange(_props.Where(p => p.IsActive));
                    }
                    break;

                case "WorshipMode":
                    ApplyLookPreset(_looks[0]);
                    ClearLayer("Props");
                    if (_mediaBinItems.Count > 0) TriggerMediaItem(_mediaBinItems[0]);
                    break;

                case "LowerThirdMode":
                    if (_looks.Count > 1) ApplyLookPreset(_looks[1]);
                    _outputState.IsVideoInputActive = true;
                    if (_props.Count > 0)
                    {
                        _props[0].IsActive = true;
                        _outputState.ActiveProps.Clear();
                        _outputState.ActiveProps.AddRange(_props.Where(p => p.IsActive));
                    }
                    break;

                case "SermonMode":
                    if (_timers.Count > 1) _timers[1].IsRunning = true;
                    if (_props.Count > 2)
                    {
                        _props[2].IsActive = true;
                        _outputState.ActiveProps.Clear();
                        _outputState.ActiveProps.AddRange(_props.Where(p => p.IsActive));
                    }
                    break;

                case "ClearAll":
                    ClearLayer("All");
                    break;
            }

            RefreshPreviewAndOutputs(animateAudienceTransition: true);
            RebuildUtilityTabContent();
            SetStatus($"Executed Macro '{macro.Name}' — {macro.Description}");
        }

        private FrameworkElement BuildAudioBinUtilityPane()
        {
            var stack = new StackPanel { Orientation = Orientation.Vertical };
            var hdrDock = new DockPanel { Margin = new Thickness(0, 0, 0, 8) };
            hdrDock.Children.Add(CreateSmallHeaderButton("⏹ Stop Audio", Color.FromRgb(0x6E, 0x25, 0x25), () => ClearLayer("Audio")));
            hdrDock.Children.Add(new TextBlock
            {
                Text = "AUDIO BIN & WORSHIP PADS",
                Foreground = new SolidColorBrush(Color.FromRgb(0xF7, 0x82, 0x1C)),
                FontSize = 11,
                FontWeight = FontWeights.Bold,
                VerticalAlignment = VerticalAlignment.Center
            });
            stack.Children.Add(hdrDock);

            foreach (var track in _audioTracks)
            {
                var captured = track;
                bool isPlaying = _outputState.IsAudioPlaying && _outputState.ActiveAudioTrack == captured;

                var row = new Border
                {
                    Background = new SolidColorBrush(isPlaying ? Color.FromRgb(0x1E, 0x46, 0x32) : Color.FromRgb(0x2A, 0x2B, 0x33)),
                    BorderBrush = new SolidColorBrush(isPlaying ? Color.FromRgb(0x33, 0xFD, 0x00) : Color.FromRgb(0x3E, 0x40, 0x4A)),
                    BorderThickness = new Thickness(1),
                    CornerRadius = new CornerRadius(4),
                    Padding = new Thickness(8, 6, 8, 6),
                    Margin = new Thickness(0, 0, 0, 6),
                    Cursor = Cursors.Hand
                };

                var dock = new DockPanel();
                dock.Children.Add(new TextBlock
                {
                    Text = captured.DurationText,
                    Foreground = new SolidColorBrush(Color.FromRgb(0x9E, 0xA4, 0xB2)),
                    FontSize = 11,
                    VerticalAlignment = VerticalAlignment.Center
                });
                DockPanel.SetDock(dock.Children[0], Dock.Right);

                dock.Children.Add(new TextBlock
                {
                    Text = (isPlaying ? "🔊 " : "🎵 ") + captured.Name + $" ({captured.PlaylistName})",
                    Foreground = Brushes.White,
                    FontSize = 12,
                    FontWeight = isPlaying ? FontWeights.Bold : FontWeights.Normal,
                    TextTrimming = TextTrimming.CharacterEllipsis
                });

                row.Child = dock;
                row.MouseLeftButtonDown += (_, _) => TriggerAudioTrack(captured);
                stack.Children.Add(row);
            }

            return stack;
        }

        private void RefreshPreviewAndOutputs(bool animateAudienceTransition = false)
        {
            if (_previewMonitorSurface == null)
                return;

            // Update Preview Monitor Header text
            if (_previewPresentationTitleLabel != null)
            {
                if (_isStagePreviewMode)
                {
                    _previewPresentationTitleLabel.Text = $"STAGE DISPLAY • {_outputState.ActiveStageLayout.Name}";
                }
                else if (_outputState.ActiveSlide != null && _outputState.ActivePresentation != null)
                {
                    _previewPresentationTitleLabel.Text = $"{_outputState.ActivePresentation.Name} — Slide #{_outputState.ActiveSlide.SlideNumber}";
                }
                else
                {
                    _previewPresentationTitleLabel.Text = $"AUDIENCE PREVIEW • {_outputState.ActiveLook.Name}";
                }
            }

            // Render 16:9 Live Preview Surface
            _previewMonitorSurface.Children.Clear();
            if (_isStagePreviewMode)
            {
                _previewMonitorSurface.Children.Add(StageWindow.RenderStageView(_outputState, _timers, 312, 176));
            }
            else
            {
                _previewMonitorSurface.Children.Add(SlideCanvasRenderer.RenderCompositeOutput(_outputState, 312, 176, _timers, _motionPhase));
            }

            // Overlay Advanced On-Screen Stats if enabled via Help -> Advanced On-Screen Stats or Settings -> Screens
            if (ProPresenterAppSettings.Instance.ShowAdvancedOnScreenStats)
            {
                var statsOverlay = new Border
                {
                    Background = new SolidColorBrush(Color.FromArgb(0xCC, 0x0D, 0x0D, 0x0D)),
                    BorderBrush = new SolidColorBrush(Color.FromRgb(0x33, 0xFD, 0x00)),
                    BorderThickness = new Thickness(1),
                    CornerRadius = new CornerRadius(3),
                    Padding = new Thickness(6, 3, 6, 3),
                    Margin = new Thickness(6),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Child = new TextBlock
                    {
                        Text = "FPS: 60.0  •  GPU: 1.7 ms  •  1080p60 Rec.709",
                        FontFamily = new FontFamily("Consolas"),
                        FontSize = 9.5,
                        Foreground = new SolidColorBrush(Color.FromRgb(0x33, 0xFD, 0x00))
                    }
                };
                _previewMonitorSurface.Children.Add(statsOverlay);
            }

            // Update Clear Layer Button Active Indicators (Red glow #571B1B / #8D2A2A from dark.theme CLEARLAYERBUTTON_ACTIVE*)
            UpdateClearLayerButtonState("Slide", _outputState.ActiveSlide != null);
            UpdateClearLayerButtonState("Media", _outputState.ActiveMediaBackground != null);
            UpdateClearLayerButtonState("Props", _outputState.ActiveProps.Count > 0);
            UpdateClearLayerButtonState("Messages", _outputState.ActiveMessage is { IsActive: true });
            UpdateClearLayerButtonState("Audio", _outputState.IsAudioPlaying);
            UpdateClearLayerButtonState("VideoInput", _outputState.IsVideoInputActive);
            UpdateClearLayerButtonState("Logo", _outputState.IsClearToLogoActive);
            UpdateClearLayerButtonState("All", _outputState.HasAnyLayerActive);

            // Sync Live Audience Output Window if open
            if (_audienceWindow != null && _audienceWindow.IsVisible && _outputState.IsAudienceEnabled)
            {
                _audienceWindow.UpdateOutput(_outputState, _timers, _motionPhase, animateAudienceTransition);
            }

            // Sync Live Stage Display Window if open
            if (_stageWindow != null && _stageWindow.IsVisible && _outputState.IsStageEnabled)
            {
                _stageWindow.UpdateStage(_outputState, _timers);
            }
        }

        private void UpdateClearLayerButtonState(string key, bool isActive)
        {
            if (!_clearLayerButtons.TryGetValue(key, out var border))
                return;

            if (isActive)
            {
                border.Background = ThemeEngine.Instance.GetBrush("CLEARLAYERBUTTON_ACTIVE", Color.FromRgb(0x57, 0x1B, 0x1B));
                border.BorderBrush = ThemeEngine.Instance.GetBrush("CLEARLAYERBUTTON_ACTIVE_BORDER", Color.FromRgb(0x8D, 0x2A, 0x2A));
            }
            else
            {
                border.Background = new SolidColorBrush(Color.FromRgb(0x28, 0x28, 0x2F));
                border.BorderBrush = new SolidColorBrush(Color.FromRgb(0x3D, 0x3D, 0x46));
            }
        }
    }
}
