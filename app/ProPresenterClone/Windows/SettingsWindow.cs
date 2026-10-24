using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using ProPresenterClone.Models;
using ProPresenterClone.Theming;
using ProPresenterClone.UI;

namespace ProPresenterClone.Windows
{
    public sealed class SlideGroupDefinition
    {
        public string Name { get; set; } = "";
        public Color Color { get; set; }
        public string Hotkey { get; set; } = "";
    }

    public sealed class SlideLabelDefinition
    {
        public string Text { get; set; } = "";
        public Color Color { get; set; }
    }

    /// <summary>
    /// Shared application settings state backing the 14-page ProPresenter Settings Window
    /// (Account, General, Updates, Screens, Audio, Network, Inputs, Devices, Media, Import, Integrations, Sync, Groups, Slide Labels).
    /// </summary>
    public sealed class ProPresenterAppSettings
    {
        public static ProPresenterAppSettings Instance { get; } = new ProPresenterAppSettings();

        // Account / Registration
        public bool IsActivated { get; set; } = true;
        public string OrganizationName { get; set; } = "Renewed Vision Community Church";
        public string LicenseType { get; set; } = "Campus Subscription (Unlimited Screens)";
        public string SeatName { get; set; } = "FOH-MAIN-PRO7";

        // General
        public bool ShowWelcomeAtStartup { get; set; } = false;
        public bool TriggerOnSingleClick { get; set; } = true;
        public bool DisableCrashReports { get; set; } = false;
        public string AppThemeName { get; set; } = "dark";
        public string Language { get; set; } = "English (Default)";
        public bool EnableCopyrightDisplay { get; set; } = true;
        public string CcliOrganization { get; set; } = "Renewed Vision Church";
        public string CcliLicenseNumber { get; set; } = "11284920";

        // Updates
        public string UpdateChannel { get; set; } = "Production (Recommended)";
        public bool CheckUpdatesAutomatically { get; set; } = true;

        // Screens
        public bool ShowAdvancedOnScreenStats { get; set; } = false;
        public bool EnableAudienceAtStartup { get; set; } = true;
        public bool EnableStageAtStartup { get; set; } = false;
        public bool AutoScaleOutputScreens { get; set; } = true;
        public bool AutomaticallyEnableScreensAtLaunch { get; set; } = false;
        public bool ShowPerformanceStatisticsOnScreen { get; set; } = false;
        public bool IgnoreBackgroundColors { get; set; } = false;
        public string TimingSource { get; set; } = "Automatic";
        public string BitDepth { get; set; } = "Normal (8-bit)";

        // Audio
        public string AudioOutputDevice { get; set; } = "System Default (WASAPI Stereo)";
        public string AudioChannelCount { get; set; } = "2 Channels (L/R Stereo)";
        public double AudioFadeDurationSeconds { get; set; } = 1.5;
        public double MasterAudioGainDb { get; set; } = 0.0;

        // Network
        public bool EnableNetwork { get; set; } = true;
        public string NetworkName { get; set; } = "ProPresenter-FOH-Main";
        public int NetworkPort { get; set; } = 50231;
        public bool EnableProPresenterRemote { get; set; } = true;
        public string RemotePasscode { get; set; } = "7749";
        public bool EnableStageApp { get; set; } = true;
        public string StageAppPasscode { get; set; } = "1200";

        // Media & Import
        public string DefaultMediaScaleBehavior { get; set; } = "Scale to Fill";
        public double DefaultMediaTransitionSeconds { get; set; } = 0.5;
        public string SupportFilesPath { get; set; } = System.IO.Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ProPresenter");

        // Groups & Labels
        public List<SlideGroupDefinition> SlideGroups { get; } = new List<SlideGroupDefinition>
        {
            new SlideGroupDefinition { Name = "Verse 1", Color = Color.FromRgb(0x00, 0x7A, 0xFF), Hotkey = "V" },
            new SlideGroupDefinition { Name = "Verse 2", Color = Color.FromRgb(0x2E, 0x6A, 0xE6), Hotkey = "2" },
            new SlideGroupDefinition { Name = "Verse 3", Color = Color.FromRgb(0x41, 0x83, 0xD7), Hotkey = "3" },
            new SlideGroupDefinition { Name = "Pre-Chorus", Color = Color.FromRgb(0xF5, 0xA6, 0x23), Hotkey = "P" },
            new SlideGroupDefinition { Name = "Chorus", Color = Color.FromRgb(0xD4, 0x38, 0x38), Hotkey = "C" },
            new SlideGroupDefinition { Name = "Chorus 2", Color = Color.FromRgb(0xE0, 0x52, 0x52), Hotkey = "" },
            new SlideGroupDefinition { Name = "Bridge", Color = Color.FromRgb(0x9B, 0x4D, 0xCA), Hotkey = "B" },
            new SlideGroupDefinition { Name = "Tag", Color = Color.FromRgb(0x3C, 0xB3, 0x71), Hotkey = "T" },
            new SlideGroupDefinition { Name = "Intro", Color = Color.FromRgb(0x6A, 0x73, 0x7D), Hotkey = "I" },
            new SlideGroupDefinition { Name = "Turnaround", Color = Color.FromRgb(0x52, 0x8B, 0x8B), Hotkey = "U" },
            new SlideGroupDefinition { Name = "Outro", Color = Color.FromRgb(0x5E, 0x5C, 0xE6), Hotkey = "O" },
            new SlideGroupDefinition { Name = "Blank", Color = Color.FromRgb(0x33, 0x33, 0x33), Hotkey = "K" }
        };

        public List<SlideLabelDefinition> SlideLabels { get; } = new List<SlideLabelDefinition>
        {
            new SlideLabelDefinition { Text = "Worship Leader", Color = Color.FromRgb(0x00, 0x7A, 0xFF) },
            new SlideLabelDefinition { Text = "Full Band Cue", Color = Color.FromRgb(0x3C, 0xB3, 0x71) },
            new SlideLabelDefinition { Text = "Choir Unison", Color = Color.FromRgb(0xF5, 0xA6, 0x23) },
            new SlideLabelDefinition { Text = "Pastor Speaking", Color = Color.FromRgb(0x9B, 0x4D, 0xCA) },
            new SlideLabelDefinition { Text = "Broadcast Camera Cue", Color = Color.FromRgb(0xD4, 0x38, 0x38) },
            new SlideLabelDefinition { Text = "Altar Call / Prayer", Color = Color.FromRgb(0x2E, 0x6A, 0xE6) }
        };
    }

    /// <summary>
    /// Exact replica of ProPresenter.UI.Settings.SettingsWindow (SettingsWindow.xaml)
    /// featuring all 14 settings pages accessible from ProPresenter -> Settings (Ctrl+,).
    /// </summary>
    public sealed class SettingsWindow : Window
    {
        public static readonly string[] PageNames =
        {
            "Account",
            "General",
            "Updates",
            "Screens",
            "Audio",
            "Network",
            "Inputs",
            "Devices",
            "Media",
            "Import",
            "Integrations",
            "Sync",
            "Groups",
            "Slide Labels"
        };

        private readonly Action<string>? _onThemeChanged;
        private readonly Action? _onSettingsApplied;
        private readonly Action? _onOpenConfigureScreens;

        private readonly List<string> _history = new List<string>();
        private int _historyIndex = -1;
        private bool _suppressHistoryPush;
        private string _activePage = "General";

        private TextBox _searchBox = null!;
        private StackPanel _navListPanel = null!;
        private Button _backBtn = null!;
        private Button _forwardBtn = null!;
        private TextBlock _pageTitleText = null!;
        private ScrollViewer _pageContentScroller = null!;
        private readonly Dictionary<string, Border> _navItemBorders = new Dictionary<string, Border>(StringComparer.OrdinalIgnoreCase);

        public SettingsWindow(
            string initialPage = "General",
            Action<string>? onThemeChanged = null,
            Action? onSettingsApplied = null,
            Action? onOpenConfigureScreens = null)
        {
            _onThemeChanged = onThemeChanged;
            _onSettingsApplied = onSettingsApplied;
            _onOpenConfigureScreens = onOpenConfigureScreens;

            Title = "ProPresenter Settings";
            Width = 760;
            Height = 680;
            MinWidth = 680;
            MinHeight = 540;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            Background = new SolidColorBrush(Color.FromRgb(0x32, 0x32, 0x32));
            Foreground = Brushes.White;

            BuildLayout();
            SelectPage(string.IsNullOrWhiteSpace(initialPage) ? "General" : initialPage);
        }

        public void SelectPage(string pageName)
        {
            string matched = PageNames.FirstOrDefault(p => p.Equals(pageName, StringComparison.OrdinalIgnoreCase)) ?? "General";
            _activePage = matched;

            if (!_suppressHistoryPush)
            {
                if (_historyIndex < _history.Count - 1)
                    _history.RemoveRange(_historyIndex + 1, _history.Count - _historyIndex - 1);
                if (_history.Count == 0 || !_history[^1].Equals(matched, StringComparison.OrdinalIgnoreCase))
                {
                    _history.Add(matched);
                    _historyIndex = _history.Count - 1;
                }
            }

            UpdateNavigationVisuals();
            RenderActivePageContent();
        }

        private void BuildLayout()
        {
            var rootGrid = new Grid();
            rootGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(182) });
            rootGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1) });
            rootGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            // Left Sidebar (#282828 matching SettingsWindow.xaml)
            var leftBorder = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(0x28, 0x28, 0x28)),
                Padding = new Thickness(8, 10, 8, 10)
            };
            var leftDock = new DockPanel();

            // Search box in top-left sidebar
            var searchBorder = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(0x1E, 0x1E, 0x1E)),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x42, 0x42, 0x42)),
                BorderThickness = new Thickness(1),
                CornerRadius = new CornerRadius(4),
                Margin = new Thickness(2, 0, 2, 10),
                Padding = new Thickness(6, 3, 6, 3)
            };
            var searchDock = new DockPanel();
            searchDock.Children.Add(new TextBlock
            {
                Text = "🔍",
                FontSize = 11,
                Foreground = new SolidColorBrush(Color.FromRgb(0x9A, 0x9A, 0x9A)),
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 0, 6, 0)
            });
            _searchBox = new TextBox
            {
                Background = Brushes.Transparent,
                BorderThickness = new Thickness(0),
                Foreground = Brushes.White,
                CaretBrush = Brushes.White,
                FontSize = 12,
                VerticalContentAlignment = VerticalAlignment.Center
            };
            _searchBox.TextChanged += (_, _) => FilterNavigationItems(_searchBox.Text);
            searchDock.Children.Add(_searchBox);
            searchBorder.Child = searchDock;
            DockPanel.SetDock(searchBorder, Dock.Top);
            leftDock.Children.Add(searchBorder);

            _navListPanel = new StackPanel();
            foreach (var page in PageNames)
            {
                string capturedPage = page;
                var itemBorder = new Border
                {
                    CornerRadius = new CornerRadius(4),
                    Padding = new Thickness(10, 6, 10, 6),
                    Margin = new Thickness(0, 1, 0, 1),
                    Cursor = Cursors.Hand,
                    Background = Brushes.Transparent
                };

                var row = new StackPanel { Orientation = Orientation.Horizontal };
                row.Children.Add(GetPageIconVisual(capturedPage));
                row.Children.Add(new TextBlock
                {
                    Text = capturedPage,
                    FontSize = 13,
                    Foreground = Brushes.White,
                    VerticalAlignment = VerticalAlignment.Center
                });
                itemBorder.Child = row;
                itemBorder.MouseLeftButtonDown += (_, _) => SelectPage(capturedPage);

                _navItemBorders[capturedPage] = itemBorder;
                _navListPanel.Children.Add(itemBorder);
            }

            var leftScroll = new ScrollViewer
            {
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                Content = _navListPanel
            };
            leftDock.Children.Add(leftScroll);
            leftBorder.Child = leftDock;
            Grid.SetColumn(leftBorder, 0);
            rootGrid.Children.Add(leftBorder);

            // Vertical divider
            var divider = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(0x1C, 0x1C, 0x1C))
            };
            Grid.SetColumn(divider, 1);
            rootGrid.Children.Add(divider);

            // Right Content Area
            var rightGrid = new Grid
            {
                Background = new SolidColorBrush(Color.FromRgb(0x32, 0x32, 0x32))
            };
            rightGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50) });
            rightGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1) });
            rightGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            // Header bar with Back / Forward buttons + Page Title
            var headerBar = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(0x2D, 0x2D, 0x2D)),
                Padding = new Thickness(16, 0, 16, 0)
            };
            var headerStack = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                VerticalAlignment = VerticalAlignment.Center
            };

            _backBtn = CreateNavArrowButton("◀", () =>
            {
                if (_historyIndex > 0)
                {
                    _suppressHistoryPush = true;
                    _historyIndex--;
                    SelectPage(_history[_historyIndex]);
                    _suppressHistoryPush = false;
                }
            });
            _forwardBtn = CreateNavArrowButton("▶", () =>
            {
                if (_historyIndex < _history.Count - 1)
                {
                    _suppressHistoryPush = true;
                    _historyIndex++;
                    SelectPage(_history[_historyIndex]);
                    _suppressHistoryPush = false;
                }
            });

            _pageTitleText = new TextBlock
            {
                Text = "General",
                FontSize = 18,
                FontWeight = FontWeights.SemiBold,
                Foreground = Brushes.White,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(12, 0, 0, 0)
            };

            headerStack.Children.Add(_backBtn);
            headerStack.Children.Add(_forwardBtn);
            headerStack.Children.Add(_pageTitleText);
            headerBar.Child = headerStack;
            Grid.SetRow(headerBar, 0);
            rightGrid.Children.Add(headerBar);

            var headerLine = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(0x22, 0x22, 0x22))
            };
            Grid.SetRow(headerLine, 1);
            rightGrid.Children.Add(headerLine);

            _pageContentScroller = new ScrollViewer
            {
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled,
                Padding = new Thickness(24, 18, 24, 24)
            };
            Grid.SetRow(_pageContentScroller, 2);
            rightGrid.Children.Add(_pageContentScroller);

            Grid.SetColumn(rightGrid, 2);
            rootGrid.Children.Add(rightGrid);

            Content = rootGrid;
        }

        private void FilterNavigationItems(string query)
        {
            string q = (query ?? "").Trim();
            foreach (var kv in _navItemBorders)
            {
                bool visible = string.IsNullOrEmpty(q) ||
                               kv.Key.Contains(q, StringComparison.OrdinalIgnoreCase) ||
                               GetPageKeywords(kv.Key).Contains(q, StringComparison.OrdinalIgnoreCase);
                kv.Value.Visibility = visible ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        private void UpdateNavigationVisuals()
        {
            foreach (var kv in _navItemBorders)
            {
                bool active = kv.Key.Equals(_activePage, StringComparison.OrdinalIgnoreCase);
                kv.Value.Background = active
                    ? new SolidColorBrush(Color.FromRgb(0x00, 0x65, 0xDF))
                    : Brushes.Transparent;
            }

            _pageTitleText.Text = _activePage;
            _backBtn.IsEnabled = _historyIndex > 0;
            _backBtn.Opacity = _backBtn.IsEnabled ? 1.0 : 0.35;
            _forwardBtn.IsEnabled = _historyIndex >= 0 && _historyIndex < _history.Count - 1;
            _forwardBtn.Opacity = _forwardBtn.IsEnabled ? 1.0 : 0.35;
        }

        private void RenderActivePageContent()
        {
            var host = new StackPanel();
            var s = ProPresenterAppSettings.Instance;

            switch (_activePage)
            {
                case "Account":
                    BuildAccountPage(host, s);
                    break;
                case "General":
                    BuildGeneralPage(host, s);
                    break;
                case "Updates":
                    BuildUpdatesPage(host, s);
                    break;
                case "Screens":
                    BuildScreensPage(host, s);
                    break;
                case "Audio":
                    BuildAudioPage(host, s);
                    break;
                case "Network":
                    BuildNetworkPage(host, s);
                    break;
                case "Inputs":
                    BuildInputsPage(host);
                    break;
                case "Devices":
                    BuildDevicesPage(host);
                    break;
                case "Media":
                    BuildMediaPage(host, s);
                    break;
                case "Import":
                    BuildImportPage(host);
                    break;
                case "Integrations":
                    BuildIntegrationsPage(host);
                    break;
                case "Sync":
                    BuildSyncPage(host, s);
                    break;
                case "Groups":
                    BuildGroupsPage(host, s);
                    break;
                case "Slide Labels":
                    BuildSlideLabelsPage(host, s);
                    break;
            }

            _pageContentScroller.Content = host;
        }

        private void BuildAccountPage(StackPanel host, ProPresenterAppSettings s)
        {
            var regCard = CreateSectionCard("ProPresenter Registration & License");
            var statusBanner = new Border
            {
                Background = new SolidColorBrush(s.IsActivated ? Color.FromRgb(0x1E, 0x46, 0x26) : Color.FromRgb(0x4D, 0x33, 0x14)),
                BorderBrush = new SolidColorBrush(s.IsActivated ? Color.FromRgb(0x33, 0xC7, 0x59) : Color.FromRgb(0xFF, 0x95, 0x00)),
                BorderThickness = new Thickness(1),
                CornerRadius = new CornerRadius(5),
                Padding = new Thickness(14, 10, 14, 10),
                Margin = new Thickness(0, 0, 0, 12)
            };
            var bannerDock = new DockPanel();
            var toggleActivateBtn = CreateAccentButton(
                s.IsActivated ? "Deactivate Seat" : "Activate ProPresenter",
                s.IsActivated ? Color.FromRgb(0x4A, 0x4A, 0x50) : Color.FromRgb(0xFF, 0x95, 0x00),
                () =>
                {
                    s.IsActivated = !s.IsActivated;
                    _onSettingsApplied?.Invoke();
                    RenderActivePageContent();
                });
            DockPanel.SetDock(toggleActivateBtn, Dock.Right);
            bannerDock.Children.Add(toggleActivateBtn);

            var statusTextStack = new StackPanel();
            statusTextStack.Children.Add(new TextBlock
            {
                Text = s.IsActivated ? "✓ ProPresenter Activated — Registered Seat" : "⚠ Unregistered Mode (Watermark Free Demo Mode)",
                FontWeight = FontWeights.Bold,
                FontSize = 13,
                Foreground = Brushes.White
            });
            statusTextStack.Children.Add(new TextBlock
            {
                Text = s.IsActivated
                    ? $"{s.OrganizationName} • {s.LicenseType} • Seat: {s.SeatName}"
                    : "Click 'Activate ProPresenter' to register this seat and hide the orange Activate badge in the title bar.",
                FontSize = 11.5,
                Foreground = new SolidColorBrush(Color.FromRgb(0xD6, 0xD6, 0xD6)),
                Margin = new Thickness(0, 3, 0, 0),
                TextWrapping = TextWrapping.Wrap
            });
            bannerDock.Children.Add(statusTextStack);
            statusBanner.Child = bannerDock;
            regCard.Children.Add(statusBanner);

            AddLabeledTextBoxRow(regCard, "Organization Name:", s.OrganizationName, val => { s.OrganizationName = val; _onSettingsApplied?.Invoke(); });
            AddLabeledTextBoxRow(regCard, "Seat Identifier:", s.SeatName, val => { s.SeatName = val; _onSettingsApplied?.Invoke(); });
            AddLabeledTextBoxRow(regCard, "Subscription Plan:", s.LicenseType, val => { s.LicenseType = val; });
            host.Children.Add(regCard);

            var howCard = CreateSectionCard("House of Worship Features");
            AddCheckboxRow(howCard, "Enable Bibles Feature (KJV, ESV, NIV, NLT, Kinh Thánh)", true, _ => { });
            AddCheckboxRow(howCard, "Enable CCLI SongSelect & Copyright Reporting", true, _ => { });
            AddCheckboxRow(howCard, "Enable MultiTracks.com CloudPro & ChartPro Integration", true, _ => { });
            AddCheckboxRow(howCard, "Enable Planning Center Live Services Sync", true, _ => { });
            host.Children.Add(howCard);
        }

        private void BuildGeneralPage(StackPanel host, ProPresenterAppSettings s)
        {
            var appCard = CreateSectionCard("Application Behavior");
            AddCheckboxRow(appCard, "Show Welcome to ProPresenter window at startup", s.ShowWelcomeAtStartup, v =>
            {
                s.ShowWelcomeAtStartup = v;
                _onSettingsApplied?.Invoke();
            });
            AddCheckboxRow(appCard, "Trigger presentations and media on single click", s.TriggerOnSingleClick, v =>
            {
                s.TriggerOnSingleClick = v;
                _onSettingsApplied?.Invoke();
            });
            AddCheckboxRow(appCard, "Disable anonymous crash & usage telemetry", s.DisableCrashReports, v =>
            {
                s.DisableCrashReports = v;
            });

            AddComboRow(appCard, "Application Appearance:", new[] { "Dark (ProPresenter 7 Default)", "Light" },
                s.AppThemeName.Equals("light", StringComparison.OrdinalIgnoreCase) ? 1 : 0,
                idx =>
                {
                    string theme = idx == 1 ? "light" : "dark";
                    s.AppThemeName = theme;
                    _onThemeChanged?.Invoke(theme);
                });

            AddComboRow(appCard, "Language:", new[]
            {
                "English (Default)",
                "Tiếng Việt (Vietnamese)",
                "Español",
                "Português",
                "한국어 (Korean)",
                "Deutsch",
                "Français"
            }, 0, idx => { });

            host.Children.Add(appCard);

            var copyrightCard = CreateSectionCard("Copyright (CCLI)");
            AddCheckboxRow(copyrightCard, "Enable Copyright display on song slides", s.EnableCopyrightDisplay, v =>
            {
                s.EnableCopyrightDisplay = v;
                _onSettingsApplied?.Invoke();
            });
            AddLabeledTextBoxRow(copyrightCard, "Church / Organization:", s.CcliOrganization, val => s.CcliOrganization = val);
            AddLabeledTextBoxRow(copyrightCard, "CCLI License Number:", s.CcliLicenseNumber, val => s.CcliLicenseNumber = val);
            host.Children.Add(copyrightCard);
        }

        private void BuildUpdatesPage(StackPanel host, ProPresenterAppSettings s)
        {
            var updCard = CreateSectionCard("Software Updates");
            updCard.Children.Add(new TextBlock
            {
                Text = "ProPresenter 7 — Version 18.4.1 (Build 118423561)",
                FontSize = 14,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.White,
                Margin = new Thickness(0, 0, 0, 4)
            });
            updCard.Children.Add(new TextBlock
            {
                Text = "✓ Your ProPresenter installation is up to date.",
                FontSize = 12,
                Foreground = new SolidColorBrush(Color.FromRgb(0x4C, 0xD9, 0x64)),
                Margin = new Thickness(0, 0, 0, 12)
            });

            AddComboRow(updCard, "Update Channel:", new[] { "Production (Recommended)", "Beta Channel" }, 0, idx =>
            {
                s.UpdateChannel = idx == 1 ? "Beta Channel" : "Production (Recommended)";
            });
            AddCheckboxRow(updCard, "Automatically check for updates in background", s.CheckUpdatesAutomatically, v =>
            {
                s.CheckUpdatesAutomatically = v;
            });

            var statusLabel = new TextBlock
            {
                Text = $"Last checked: {DateTime.Now:g} • No newer builds found.",
                FontSize = 11.5,
                Foreground = new SolidColorBrush(Color.FromRgb(0xB0, 0xB0, 0xB0)),
                Margin = new Thickness(0, 8, 0, 8)
            };
            updCard.Children.Add(statusLabel);

            updCard.Children.Add(CreateAccentButton("Check for Updates Now", Color.FromRgb(0x00, 0x7A, 0xFF), () =>
            {
                statusLabel.Text = $"Checked at {DateTime.Now:T} — ProPresenter 18.4.1 is the latest release.";
                statusLabel.Foreground = new SolidColorBrush(Color.FromRgb(0x4C, 0xD9, 0x64));
            }));
            host.Children.Add(updCard);

            var notesCard = CreateSectionCard("Recent Release Highlights");
            notesCard.Children.Add(new TextBlock
            {
                Text = "• Improved GPU frame pacing for 1080p60 & 4K60 NDI + SDI Audience outputs\n" +
                       "• Enhanced native Protobuf (.pro) presentation loading & slide transition rendering\n" +
                       "• Integrated Stage Display multi-timer formatting and ChordPro transposition\n" +
                       "• Added Test Patterns generator & Advanced On-Screen GPU performance overlay",
                FontSize = 12,
                Foreground = new SolidColorBrush(Color.FromRgb(0xD0, 0xD0, 0xD0)),
                LineHeight = 20
            });
            host.Children.Add(notesCard);
        }

        private void BuildScreensPage(StackPanel host, ProPresenterAppSettings s)
        {
            // Group 1 Card (GroupedControl replica from ScreenSettingsView.xaml)
            var group1Card = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(0x28, 0x28, 0x2B)),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x38, 0x38, 0x3C)),
                BorderThickness = new Thickness(1),
                CornerRadius = new CornerRadius(6),
                Padding = new Thickness(16, 12, 16, 12),
                Margin = new Thickness(0, 0, 0, 16)
            };
            var group1Stack = new StackPanel();

            // Row 1: Automatically enable screens at launch
            var row1 = new Grid();
            row1.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            row1.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            row1.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            row1.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            row1.Children.Add(new TextBlock
            {
                Text = "Automatically enable screens at launch",
                FontSize = 13,
                FontWeight = FontWeights.SemiBold,
                Foreground = Brushes.White,
                VerticalAlignment = VerticalAlignment.Center
            });

            var switch1 = new ToggleSwitchControl
            {
                IsChecked = s.AutomaticallyEnableScreensAtLaunch,
                VerticalAlignment = VerticalAlignment.Center
            };
            switch1.IsCheckedChanged += (_, val) => s.AutomaticallyEnableScreensAtLaunch = val;
            Grid.SetColumn(switch1, 1);
            row1.Children.Add(switch1);

            var desc1 = new TextBlock
            {
                Text = "When the application is launched, automatically enable stage and audience screens. This setting only affects graphic outputs.",
                FontSize = 11.5,
                Foreground = new SolidColorBrush(Color.FromRgb(0x8E, 0x8E, 0x93)),
                TextWrapping = TextWrapping.Wrap,
                Margin = new Thickness(0, 4, 0, 0)
            };
            Grid.SetRow(desc1, 1);
            Grid.SetColumnSpan(desc1, 2);
            row1.Children.Add(desc1);
            group1Stack.Children.Add(row1);

            // Separator 1
            group1Stack.Children.Add(new Border
            {
                Height = 1,
                Background = new SolidColorBrush(Color.FromRgb(0x38, 0x38, 0x3C)),
                Margin = new Thickness(0, 10, 0, 10)
            });

            // Row 2: Show performance statistics on screen
            var row2 = new Grid();
            row2.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            row2.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            row2.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            row2.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            row2.Children.Add(new TextBlock
            {
                Text = "Show performance statistics on screen",
                FontSize = 13,
                FontWeight = FontWeights.SemiBold,
                Foreground = Brushes.White,
                VerticalAlignment = VerticalAlignment.Center
            });

            var switch2 = new ToggleSwitchControl
            {
                IsChecked = s.ShowPerformanceStatisticsOnScreen,
                VerticalAlignment = VerticalAlignment.Center
            };
            switch2.IsCheckedChanged += (_, val) =>
            {
                s.ShowPerformanceStatisticsOnScreen = val;
                s.ShowAdvancedOnScreenStats = val;
                _onSettingsApplied?.Invoke();
            };
            Grid.SetColumn(switch2, 1);
            row2.Children.Add(switch2);

            var desc2 = new TextBlock
            {
                Text = "Enabling will show the rendered frames per second and video memory utilization on all the screens.",
                FontSize = 11.5,
                Foreground = new SolidColorBrush(Color.FromRgb(0x8E, 0x8E, 0x93)),
                TextWrapping = TextWrapping.Wrap,
                Margin = new Thickness(0, 4, 0, 0)
            };
            Grid.SetRow(desc2, 1);
            Grid.SetColumnSpan(desc2, 2);
            row2.Children.Add(desc2);
            group1Stack.Children.Add(row2);

            // Separator 2
            group1Stack.Children.Add(new Border
            {
                Height = 1,
                Background = new SolidColorBrush(Color.FromRgb(0x38, 0x38, 0x3C)),
                Margin = new Thickness(0, 10, 0, 10)
            });

            // Row 3: Ignore Background Colors
            var row3 = new Grid();
            row3.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            row3.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            row3.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            row3.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            row3.Children.Add(new TextBlock
            {
                Text = "Ignore Background Colors",
                FontSize = 13,
                FontWeight = FontWeights.SemiBold,
                Foreground = Brushes.White,
                VerticalAlignment = VerticalAlignment.Center
            });

            var switch3 = new ToggleSwitchControl
            {
                IsChecked = s.IgnoreBackgroundColors,
                VerticalAlignment = VerticalAlignment.Center
            };
            switch3.IsCheckedChanged += (_, val) =>
            {
                s.IgnoreBackgroundColors = val;
                _onSettingsApplied?.Invoke();
            };
            Grid.SetColumn(switch3, 1);
            row3.Children.Add(switch3);

            var desc3 = new TextBlock
            {
                Text = "Ignores the presentation and slide background colors for all rendered content.",
                FontSize = 11.5,
                Foreground = new SolidColorBrush(Color.FromRgb(0x8E, 0x8E, 0x93)),
                TextWrapping = TextWrapping.Wrap,
                Margin = new Thickness(0, 4, 0, 0)
            };
            Grid.SetRow(desc3, 1);
            Grid.SetColumnSpan(desc3, 2);
            row3.Children.Add(desc3);
            group1Stack.Children.Add(row3);

            group1Card.Child = group1Stack;
            host.Children.Add(group1Card);

            // Rendering Section Header with Help Button
            var renderingHeader = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(0, 8, 0, 8)
            };
            renderingHeader.Children.Add(new TextBlock
            {
                Text = "Rendering",
                FontSize = 13.5,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.White,
                VerticalAlignment = VerticalAlignment.Center
            });

            var helpBtn = new Border
            {
                Width = 16,
                Height = 16,
                CornerRadius = new CornerRadius(8),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x6E, 0x6E, 0x73)),
                BorderThickness = new Thickness(1),
                Margin = new Thickness(6, 0, 0, 0),
                Cursor = Cursors.Hand,
                ToolTip = "Rendering options allow you to configure the timing clock source and bit depth for output rendering pipeline."
            };
            helpBtn.Child = new TextBlock
            {
                Text = "?",
                FontSize = 10,
                FontWeight = FontWeights.SemiBold,
                Foreground = new SolidColorBrush(Color.FromRgb(0xA0, 0xA0, 0xA5)),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            helpBtn.MouseLeftButtonDown += (_, _) =>
            {
                MessageBox.Show(
                    "Rendering options allow you to configure the timing clock source and bit depth for output rendering pipeline.",
                    "Rendering Help",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            };
            renderingHeader.Children.Add(helpBtn);
            host.Children.Add(renderingHeader);

            // Group 2 Card (Rendering Options)
            var group2Card = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(0x28, 0x28, 0x2B)),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x38, 0x38, 0x3C)),
                BorderThickness = new Thickness(1),
                CornerRadius = new CornerRadius(6),
                Padding = new Thickness(16, 12, 16, 12),
                Margin = new Thickness(0, 0, 0, 20)
            };
            var group2Stack = new StackPanel();

            // Timing Source Row
            var timingRow = new Grid();
            timingRow.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            timingRow.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            timingRow.Children.Add(new TextBlock
            {
                Text = "Timing Source",
                FontSize = 13,
                Foreground = Brushes.White,
                VerticalAlignment = VerticalAlignment.Center
            });

            var timingCombo = new ComboBox
            {
                Width = 140,
                Height = 24,
                VerticalAlignment = VerticalAlignment.Center
            };
            timingCombo.Items.Add("Automatic");
            timingCombo.Items.Add("Display 1: Generic PnP Monitor");
            timingCombo.Items.Add("Display 2: Projector Output");
            timingCombo.SelectedIndex = 0;
            timingCombo.SelectionChanged += (_, _) =>
            {
                if (timingCombo.SelectedItem is string t) s.TimingSource = t;
            };
            Grid.SetColumn(timingCombo, 1);
            timingRow.Children.Add(timingCombo);
            group2Stack.Children.Add(timingRow);

            // Separator
            group2Stack.Children.Add(new Border
            {
                Height = 1,
                Background = new SolidColorBrush(Color.FromRgb(0x38, 0x38, 0x3C)),
                Margin = new Thickness(0, 10, 0, 10)
            });

            // Bit Depth Row
            var bitDepthRow = new Grid();
            bitDepthRow.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            bitDepthRow.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            bitDepthRow.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            bitDepthRow.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            bitDepthRow.Children.Add(new TextBlock
            {
                Text = "Bit Depth",
                FontSize = 13,
                Foreground = Brushes.White,
                VerticalAlignment = VerticalAlignment.Center
            });

            var bitDepthCombo = new ComboBox
            {
                Width = 140,
                Height = 24,
                VerticalAlignment = VerticalAlignment.Center
            };
            bitDepthCombo.Items.Add("Normal (8-bit)");
            bitDepthCombo.Items.Add("High (10-bit)");
            bitDepthCombo.SelectedIndex = s.BitDepth.Contains("10") ? 1 : 0;
            bitDepthCombo.SelectionChanged += (_, _) =>
            {
                if (bitDepthCombo.SelectedItem is string bd) s.BitDepth = bd;
            };
            Grid.SetColumn(bitDepthCombo, 1);
            bitDepthRow.Children.Add(bitDepthCombo);

            var bitDepthDesc = new TextBlock
            {
                Text = "Increasing bit depth will improve the render quality but also requires significantly more processing from the computer. This change requires an application restart.",
                FontSize = 11.5,
                Foreground = new SolidColorBrush(Color.FromRgb(0x8E, 0x8E, 0x93)),
                TextWrapping = TextWrapping.Wrap,
                Margin = new Thickness(0, 4, 0, 0)
            };
            Grid.SetRow(bitDepthDesc, 1);
            Grid.SetColumnSpan(bitDepthDesc, 2);
            bitDepthRow.Children.Add(bitDepthDesc);
            group2Stack.Children.Add(bitDepthRow);

            group2Card.Child = group2Stack;
            host.Children.Add(group2Card);

            // Configure Screens button in bottom-right corner
            var btnContainer = new StackPanel
            {
                HorizontalAlignment = HorizontalAlignment.Right,
                Margin = new Thickness(0, 10, 0, 0)
            };
            var cfgBtn = new Button
            {
                Content = "Configure Screens...",
                MinWidth = 150,
                Height = 28,
                Padding = new Thickness(16, 4, 16, 4),
                Background = new SolidColorBrush(Color.FromRgb(0x3C, 0x3C, 0x40)),
                Foreground = Brushes.White,
                FontSize = 12,
                FontWeight = FontWeights.SemiBold,
                Cursor = Cursors.Hand,
                BorderThickness = new Thickness(0)
            };
            cfgBtn.Click += (_, _) => _onOpenConfigureScreens?.Invoke();
            btnContainer.Children.Add(cfgBtn);
            host.Children.Add(btnContainer);
        }

        private void BuildAudioPage(StackPanel host, ProPresenterAppSettings s)
        {
            var audioCard = CreateSectionCard("Audio Routing & Output Device");
            AddComboRow(audioCard, "Audio Output Device:", new[]
            {
                "System Default (WASAPI Stereo)",
                "Dante Virtual Soundcard (16ch ASIO)",
                "Behringer X-USB (32ch ASIO)",
                "Blackmagic DeckLink Duo Embedded Audio"
            }, 0, idx => { });

            AddComboRow(audioCard, "Channel Count:", new[]
            {
                "2 Channels (L/R Stereo)",
                "4 Channels (Main L/R + Click/Guide)",
                "8 Channels (Multitrack Stem Routing)",
                "16 Channels (Dante Broadcast Matrix)"
            }, 0, idx => { });

            AddSliderRow(audioCard, "Audio Clear / Fade Out Duration:", 0.1, 5.0, s.AudioFadeDurationSeconds, "s", val =>
            {
                s.AudioFadeDurationSeconds = val;
            });
            AddSliderRow(audioCard, "Master Output Trim:", -18.0, 6.0, s.MasterAudioGainDb, "dB", val =>
            {
                s.MasterAudioGainDb = val;
            });
            host.Children.Add(audioCard);

            var mapCard = CreateSectionCard("Channel Bus Routing Map");
            mapCard.Children.Add(CreateInfoBadgeRow("Channel 1 (Left)", "Main Left -> Output Bus 1 (0.0 dB)", Color.FromRgb(0x33, 0xC7, 0x59)));
            mapCard.Children.Add(CreateInfoBadgeRow("Channel 2 (Right)", "Main Right -> Output Bus 2 (0.0 dB)", Color.FromRgb(0x33, 0xC7, 0x59)));
            mapCard.Children.Add(CreateInfoBadgeRow("SDI / NDI Audio", "Follows Main Stereo Bus (Embedded)", Color.FromRgb(0x00, 0x7A, 0xFF)));
            host.Children.Add(mapCard);
        }

        private void BuildNetworkPage(StackPanel host, ProPresenterAppSettings s)
        {
            var netCard = CreateSectionCard("Network & Remote Control");
            AddCheckboxRow(netCard, "Enable ProPresenter Network Services", s.EnableNetwork, v => s.EnableNetwork = v);
            AddLabeledTextBoxRow(netCard, "Network Instance Name:", s.NetworkName, val => s.NetworkName = val);
            AddLabeledTextBoxRow(netCard, "TCP API Port:", s.NetworkPort.ToString(), val =>
            {
                if (int.TryParse(val, out int p)) s.NetworkPort = p;
            });
            host.Children.Add(netCard);

            var remoteCard = CreateSectionCard("Mobile & Web Apps");
            AddCheckboxRow(remoteCard, "Enable ProPresenter Remote App (iOS / Android)", s.EnableProPresenterRemote, v => s.EnableProPresenterRemote = v);
            AddLabeledTextBoxRow(remoteCard, "Remote Controller Passcode:", s.RemotePasscode, val => s.RemotePasscode = val);
            AddCheckboxRow(remoteCard, "Enable ProPresenter Stage App", s.EnableStageApp, v => s.EnableStageApp = v);
            AddLabeledTextBoxRow(remoteCard, "Stage App Passcode:", s.StageAppPasscode, val => s.StageAppPasscode = val);
            host.Children.Add(remoteCard);

            var linkCard = CreateSectionCard("Network Link (Main / Backup Mirroring)");
            linkCard.Children.Add(CreateInfoBadgeRow("Link Status", "Listening on 0.0.0.0:50231 (0 Peers Connected)", Color.FromRgb(0x00, 0x7A, 0xFF)));
            host.Children.Add(linkCard);
        }

        private void BuildInputsPage(StackPanel host)
        {
            var videoCard = CreateSectionCard("Live Video Inputs");
            videoCard.Children.Add(CreateInfoBadgeRow("Video Input 1 — Sanctuary Main Cam", "Blackmagic DeckLink SDI 1 • 1080p59.94", Color.FromRgb(0x33, 0xC7, 0x59)));
            videoCard.Children.Add(CreateInfoBadgeRow("Video Input 2 — Stage Roaming PTZ", "NDI® HX • PTZOptics-Stage (192.168.1.42)", Color.FromRgb(0x00, 0x7A, 0xFF)));
            videoCard.Children.Add(CreateInfoBadgeRow("Video Input 3 — Pulpit Overhead", "USB Capture HDMI • 1080p60", Color.FromRgb(0xF5, 0xA6, 0x23)));
            host.Children.Add(videoCard);

            var audioInCard = CreateSectionCard("Audio Inputs");
            audioInCard.Children.Add(CreateInfoBadgeRow("Audio Input 1 — Broadcast Mix", "Dante Rx Ch 1-2 • 48 kHz PCM • -14 dBFS", Color.FromRgb(0x33, 0xC7, 0x59)));
            audioInCard.Children.Add(CreateInfoBadgeRow("Audio Input 2 — LTC Timecode In", "Line In Ch 8 • SMPTE 29.97 fps", Color.FromRgb(0x9B, 0x4D, 0xCA)));
            host.Children.Add(audioInCard);
        }

        private void BuildDevicesPage(StackPanel host)
        {
            var devCard = CreateSectionCard("External Communications & Hardware Devices (MIDI / DMX / RossTalk)");
            devCard.Children.Add(CreateInfoBadgeRow("Ableton Live MIDI Bridge", "loopMIDI Port 1 • Connected (Ch 1 Note Triggers)", Color.FromRgb(0x33, 0xC7, 0x59)));
            devCard.Children.Add(CreateInfoBadgeRow("GrandMA3 Lighting Console", "Art-Net / sACN Universe 1 • Connected", Color.FromRgb(0x00, 0x7A, 0xFF)));
            devCard.Children.Add(CreateInfoBadgeRow("Ross Carbonite Video Switcher", "RossTalk TCP 192.168.1.20:7788 • Standby", Color.FromRgb(0xF5, 0xA6, 0x23)));
            host.Children.Add(devCard);
        }

        private void BuildMediaPage(StackPanel host, ProPresenterAppSettings s)
        {
            var mediaCard = CreateSectionCard("Media Scaling & Playback Defaults");
            AddComboRow(mediaCard, "Foreground Media Scaling:", new[] { "Scale to Fit", "Scale to Fill", "Stretch to Fill" }, 0, _ => { });
            AddComboRow(mediaCard, "Background Media Scaling:", new[] { "Scale to Fill", "Scale to Fit", "Stretch to Fill" }, 0, _ => { });
            AddSliderRow(mediaCard, "Default Media Dissolve Time:", 0.0, 3.0, s.DefaultMediaTransitionSeconds, "s", v => s.DefaultMediaTransitionSeconds = v);
            AddLabeledTextBoxRow(mediaCard, "Support Files Directory:", s.SupportFilesPath, val => s.SupportFilesPath = val);
            host.Children.Add(mediaCard);
        }

        private void BuildImportPage(StackPanel host)
        {
            var impCard = CreateSectionCard("Text & Presentation Import Options");
            AddComboRow(impCard, "Slide Break Delimiter:", new[] { "Paragraph Break (\\n\\n)", "Line Break (\\n)", "Double Slash (//)" }, 0, _ => { });
            AddComboRow(impCard, "Lines per Slide:", new[] { "2 Lines per Slide", "4 Lines per Slide", "6 Lines per Slide", "Unlimited" }, 1, _ => { });
            AddCheckboxRow(impCard, "Automatically resize imported elements to match default screen size", true, _ => { });
            AddCheckboxRow(impCard, "Recognize ChordPro [C] [G] [Am] chord tags during text import", true, _ => { });
            host.Children.Add(impCard);
        }

        private void BuildIntegrationsPage(StackPanel host)
        {
            var pcoCard = CreateSectionCard("Planning Center Services");
            pcoCard.Children.Add(CreateInfoBadgeRow("Planning Center Online", "Connected • Renewed Vision Worship Team", Color.FromRgb(0x33, 0xC7, 0x59)));
            AddCheckboxRow(pcoCard, "Automatically match Planning Center songs to Library presentations", true, _ => { });
            host.Children.Add(pcoCard);

            var ccliCard = CreateSectionCard("SongSelect by CCLI & MultiTracks.com");
            ccliCard.Children.Add(CreateInfoBadgeRow("SongSelect by CCLI", "Connected • License #11284920 (Active)", Color.FromRgb(0x00, 0x7A, 0xFF)));
            ccliCard.Children.Add(CreateInfoBadgeRow("MultiTracks.com Cloud", "Connected • ChartPro + Lyrics Enabled", Color.FromRgb(0xF5, 0xA6, 0x23)));
            host.Children.Add(ccliCard);
        }

        private void BuildSyncPage(StackPanel host, ProPresenterAppSettings s)
        {
            var syncCard = CreateSectionCard("Repository & Local Folder Sync");
            AddLabeledTextBoxRow(syncCard, "Sync Folder Location:", s.SupportFilesPath, _ => { });
            AddCheckboxRow(syncCard, "Sync Libraries & Presentations (.pro)", true, _ => { });
            AddCheckboxRow(syncCard, "Sync Playlists & Headers", true, _ => { });
            AddCheckboxRow(syncCard, "Sync Themes, Props & Masks", true, _ => { });
            AddCheckboxRow(syncCard, "Sync Media Bin Assets", true, _ => { });

            var syncStatus = new TextBlock
            {
                Text = "Ready to synchronize with local repository.",
                FontSize = 11.5,
                Foreground = new SolidColorBrush(Color.FromRgb(0xB0, 0xB0, 0xB0)),
                Margin = new Thickness(0, 8, 0, 8)
            };
            syncCard.Children.Add(syncStatus);
            syncCard.Children.Add(CreateAccentButton("Sync Now", Color.FromRgb(0x00, 0x7A, 0xFF), () =>
            {
                syncStatus.Text = $"✓ Synchronized all Libraries, Themes, and Media at {DateTime.Now:T}.";
                syncStatus.Foreground = new SolidColorBrush(Color.FromRgb(0x4C, 0xD9, 0x64));
            }));
            host.Children.Add(syncCard);
        }

        private void BuildGroupsPage(StackPanel host, ProPresenterAppSettings s)
        {
            var grpCard = CreateSectionCard("Slide Groups & Hotkeys");
            foreach (var g in s.SlideGroups)
            {
                var row = new Border
                {
                    Background = new SolidColorBrush(Color.FromRgb(0x24, 0x24, 0x24)),
                    CornerRadius = new CornerRadius(4),
                    Padding = new Thickness(10, 6, 10, 6),
                    Margin = new Thickness(0, 0, 0, 4)
                };
                var dock = new DockPanel();
                var hotkeyBadge = new Border
                {
                    Background = new SolidColorBrush(Color.FromRgb(0x38, 0x38, 0x38)),
                    CornerRadius = new CornerRadius(3),
                    Padding = new Thickness(8, 2, 8, 2),
                    Child = new TextBlock
                    {
                        Text = string.IsNullOrEmpty(g.Hotkey) ? "—" : $"Key: {g.Hotkey}",
                        FontSize = 11,
                        Foreground = new SolidColorBrush(Color.FromRgb(0xD0, 0xD0, 0xD0))
                    }
                };
                DockPanel.SetDock(hotkeyBadge, Dock.Right);
                dock.Children.Add(hotkeyBadge);

                var left = new StackPanel { Orientation = Orientation.Horizontal };
                left.Children.Add(new Border
                {
                    Width = 14,
                    Height = 14,
                    CornerRadius = new CornerRadius(3),
                    Background = new SolidColorBrush(g.Color),
                    Margin = new Thickness(0, 0, 10, 0),
                    VerticalAlignment = VerticalAlignment.Center
                });
                left.Children.Add(new TextBlock
                {
                    Text = g.Name,
                    FontSize = 12.5,
                    FontWeight = FontWeights.SemiBold,
                    Foreground = Brushes.White,
                    VerticalAlignment = VerticalAlignment.Center
                });
                dock.Children.Add(left);
                row.Child = dock;
                grpCard.Children.Add(row);
            }
            host.Children.Add(grpCard);
        }

        private void BuildSlideLabelsPage(StackPanel host, ProPresenterAppSettings s)
        {
            var lblCard = CreateSectionCard("Custom Slide Labels");
            foreach (var lbl in s.SlideLabels)
            {
                var row = new Border
                {
                    Background = new SolidColorBrush(Color.FromRgb(0x24, 0x24, 0x24)),
                    CornerRadius = new CornerRadius(4),
                    Padding = new Thickness(10, 6, 10, 6),
                    Margin = new Thickness(0, 0, 0, 4)
                };
                var left = new StackPanel { Orientation = Orientation.Horizontal };
                left.Children.Add(new Border
                {
                    Width = 14,
                    Height = 14,
                    CornerRadius = new CornerRadius(7),
                    Background = new SolidColorBrush(lbl.Color),
                    Margin = new Thickness(0, 0, 10, 0),
                    VerticalAlignment = VerticalAlignment.Center
                });
                left.Children.Add(new TextBlock
                {
                    Text = lbl.Text,
                    FontSize = 12.5,
                    Foreground = Brushes.White,
                    VerticalAlignment = VerticalAlignment.Center
                });
                row.Child = left;
                lblCard.Children.Add(row);
            }
            host.Children.Add(lblCard);
        }

        private static StackPanel CreateSectionCard(string title)
        {
            var panel = new StackPanel
            {
                Margin = new Thickness(0, 0, 0, 18)
            };
            panel.Children.Add(new TextBlock
            {
                Text = title,
                FontSize = 13.5,
                FontWeight = FontWeights.Bold,
                Foreground = new SolidColorBrush(Color.FromRgb(0xF7, 0x82, 0x1C)),
                Margin = new Thickness(0, 0, 0, 8)
            });
            return panel;
        }

        private static void AddCheckboxRow(StackPanel card, string label, bool initialValue, Action<bool> onChanged)
        {
            var cb = new CheckBox
            {
                Content = new TextBlock
                {
                    Text = label,
                    Foreground = new SolidColorBrush(Color.FromRgb(0xE8, 0xE8, 0xE8)),
                    FontSize = 12.5
                },
                IsChecked = initialValue,
                Margin = new Thickness(0, 4, 0, 4),
                VerticalContentAlignment = VerticalAlignment.Center
            };
            cb.Checked += (_, _) => onChanged(true);
            cb.Unchecked += (_, _) => onChanged(false);
            card.Children.Add(cb);
        }

        private static void AddLabeledTextBoxRow(StackPanel card, string label, string initialValue, Action<string> onChanged)
        {
            var grid = new Grid { Margin = new Thickness(0, 4, 0, 4) };
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(190) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            grid.Children.Add(new TextBlock
            {
                Text = label,
                Foreground = new SolidColorBrush(Color.FromRgb(0xC8, 0xC8, 0xC8)),
                FontSize = 12,
                VerticalAlignment = VerticalAlignment.Center
            });

            var tb = new TextBox
            {
                Text = initialValue,
                Background = new SolidColorBrush(Color.FromRgb(0x1E, 0x1E, 0x1E)),
                Foreground = Brushes.White,
                CaretBrush = Brushes.White,
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x45, 0x45, 0x45)),
                BorderThickness = new Thickness(1),
                Padding = new Thickness(7, 4, 7, 4),
                FontSize = 12
            };
            tb.TextChanged += (_, _) => onChanged(tb.Text);
            Grid.SetColumn(tb, 1);
            grid.Children.Add(tb);
            card.Children.Add(grid);
        }

        private static void AddComboRow(StackPanel card, string label, string[] options, int selectedIndex, Action<int> onChanged)
        {
            var grid = new Grid { Margin = new Thickness(0, 5, 0, 5) };
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(190) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            grid.Children.Add(new TextBlock
            {
                Text = label,
                Foreground = new SolidColorBrush(Color.FromRgb(0xC8, 0xC8, 0xC8)),
                FontSize = 12,
                VerticalAlignment = VerticalAlignment.Center
            });

            var combo = new ComboBox
            {
                ItemsSource = options,
                SelectedIndex = selectedIndex,
                Padding = new Thickness(7, 4, 7, 4),
                FontSize = 12
            };
            combo.SelectionChanged += (_, _) =>
            {
                if (combo.SelectedIndex >= 0) onChanged(combo.SelectedIndex);
            };
            Grid.SetColumn(combo, 1);
            grid.Children.Add(combo);
            card.Children.Add(grid);
        }

        private static void AddSliderRow(StackPanel card, string label, double min, double max, double value, string unit, Action<double> onChanged)
        {
            var grid = new Grid { Margin = new Thickness(0, 5, 0, 5) };
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(190) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(64) });

            grid.Children.Add(new TextBlock
            {
                Text = label,
                Foreground = new SolidColorBrush(Color.FromRgb(0xC8, 0xC8, 0xC8)),
                FontSize = 12,
                VerticalAlignment = VerticalAlignment.Center
            });

            var valLabel = new TextBlock
            {
                Text = $"{value:0.0} {unit}",
                Foreground = Brushes.White,
                FontSize = 12,
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Center
            };
            Grid.SetColumn(valLabel, 2);

            var slider = new Slider
            {
                Minimum = min,
                Maximum = max,
                Value = value,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 0, 10, 0)
            };
            slider.ValueChanged += (_, _) =>
            {
                valLabel.Text = $"{slider.Value:0.0} {unit}";
                onChanged(slider.Value);
            };
            Grid.SetColumn(slider, 1);

            grid.Children.Add(slider);
            grid.Children.Add(valLabel);
            card.Children.Add(grid);
        }

        private static Border CreateInfoBadgeRow(string title, string detail, Color dotColor)
        {
            var border = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(0x22, 0x22, 0x22)),
                CornerRadius = new CornerRadius(4),
                Padding = new Thickness(10, 7, 10, 7),
                Margin = new Thickness(0, 0, 0, 5)
            };
            var dock = new DockPanel();
            dock.Children.Add(new Ellipse
            {
                Width = 9,
                Height = 9,
                Fill = new SolidColorBrush(dotColor),
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 0, 10, 0)
            });
            var textStack = new StackPanel();
            textStack.Children.Add(new TextBlock
            {
                Text = title,
                FontSize = 12.5,
                FontWeight = FontWeights.SemiBold,
                Foreground = Brushes.White
            });
            textStack.Children.Add(new TextBlock
            {
                Text = detail,
                FontSize = 11,
                Foreground = new SolidColorBrush(Color.FromRgb(0xA8, 0xA8, 0xA8))
            });
            dock.Children.Add(textStack);
            border.Child = dock;
            return border;
        }

        private static Button CreateAccentButton(string text, Color bg, Action onClick)
        {
            var btn = new Button
            {
                Content = text,
                Background = new SolidColorBrush(bg),
                Foreground = Brushes.White,
                FontWeight = FontWeights.SemiBold,
                FontSize = 12,
                BorderThickness = new Thickness(0),
                Padding = new Thickness(14, 6, 14, 6),
                HorizontalAlignment = HorizontalAlignment.Left,
                Cursor = Cursors.Hand
            };
            btn.Click += (_, _) => onClick();
            return btn;
        }

        private static Button CreateNavArrowButton(string glyph, Action onClick)
        {
            var btn = new Button
            {
                Content = glyph,
                Width = 26,
                Height = 24,
                Background = new SolidColorBrush(Color.FromRgb(0x3B, 0x3B, 0x3B)),
                Foreground = Brushes.White,
                BorderThickness = new Thickness(0),
                Margin = new Thickness(0, 0, 4, 0),
                Cursor = Cursors.Hand,
                FontSize = 10
            };
            btn.Click += (_, _) => onClick();
            return btn;
        }

        private static UIElement GetPageIconVisual(string page)
        {
            if (page.Equals("Screens", StringComparison.OrdinalIgnoreCase))
            {
                var canvas = new Canvas
                {
                    Width = 18,
                    Height = 16,
                    Margin = new Thickness(0, 0, 6, 0),
                    VerticalAlignment = VerticalAlignment.Center
                };

                // Monitor frame
                var frame = new Rectangle
                {
                    Width = 16,
                    Height = 11,
                    RadiusX = 1.5,
                    RadiusY = 1.5,
                    Stroke = new SolidColorBrush(Color.FromRgb(0xC0, 0xC0, 0xC5)),
                    StrokeThickness = 1.2,
                    Fill = new SolidColorBrush(Color.FromRgb(0x22, 0x22, 0x26))
                };
                Canvas.SetLeft(frame, 1);
                Canvas.SetTop(frame, 1);
                canvas.Children.Add(frame);

                // Orange screen fill inside monitor (matching Picture 1!)
                var screenFill = new Rectangle
                {
                    Width = 12,
                    Height = 7,
                    Fill = new SolidColorBrush(Color.FromRgb(0xF7, 0x82, 0x1C)) // ProPresenter orange!
                };
                Canvas.SetLeft(screenFill, 3);
                Canvas.SetTop(screenFill, 3);
                canvas.Children.Add(screenFill);

                // Stand neck
                var neck = new Rectangle
                {
                    Width = 3,
                    Height = 2.5,
                    Fill = new SolidColorBrush(Color.FromRgb(0xC0, 0xC0, 0xC5))
                };
                Canvas.SetLeft(neck, 7.5);
                Canvas.SetTop(neck, 12);
                canvas.Children.Add(neck);

                // Base foot
                var foot = new Rectangle
                {
                    Width = 9,
                    Height = 1.2,
                    Fill = new SolidColorBrush(Color.FromRgb(0xC0, 0xC0, 0xC5))
                };
                Canvas.SetLeft(foot, 4.5);
                Canvas.SetTop(foot, 14);
                canvas.Children.Add(foot);

                return canvas;
            }

            return new TextBlock
            {
                Text = GetPageIconGlyph(page),
                Width = 22,
                FontSize = 13,
                Foreground = new SolidColorBrush(Color.FromRgb(0xD8, 0xD8, 0xD8)),
                VerticalAlignment = VerticalAlignment.Center
            };
        }

        private static string GetPageIconGlyph(string page) => page switch
        {
            "Account" => "👤",
            "General" => "⚙",
            "Updates" => "↻",
            "Screens" => "🖥",
            "Audio" => "🔊",
            "Network" => "🌐",
            "Inputs" => "🎥",
            "Devices" => "🎛",
            "Media" => "🎞",
            "Import" => "📥",
            "Integrations" => "🔗",
            "Sync" => "☁",
            "Groups" => "🏷",
            "Slide Labels" => "🔖",
            _ => "•"
        };

        private static string GetPageKeywords(string page) => page switch
        {
            "Account" => "registration license seat activate house of worship bibles",
            "General" => "startup theme dark light language copyright ccli logo",
            "Updates" => "version check beta production changelog",
            "Screens" => "audience stage display configure stats fps resolution",
            "Audio" => "sound output channels fade gain sdi dante",
            "Network" => "remote stage app port link tcp ip",
            "Inputs" => "video camera audio capture sdi ndi",
            "Devices" => "midi dmx rosstalk artnet timecode",
            "Media" => "scale transition repository folder",
            "Import" => "powerpoint text delimiter chord",
            "Integrations" => "planning center songselect multitracks resi",
            "Sync" => "cloud folder library backup",
            "Groups" => "verse chorus bridge intro outro color hotkey",
            "Slide Labels" => "custom label tag color",
            _ => ""
        };
    }
}

