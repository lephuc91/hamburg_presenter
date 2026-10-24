using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using ProPresenterClone.Models;
using ProPresenterClone.UI;

namespace ProPresenterClone.Windows
{
    public enum ScreenTargetType
    {
        Audience,
        Stage
    }

    public enum ScreenArrangementType
    {
        Single,
        Mirror,
        Group,
        EdgeBlend
    }

    /// <summary>
    /// Screen arrangement data model matching ProPresenter.DO.OutputConfiguration.ScreenArrangementBase.
    /// Backs both Audience screens and Stage displays.
    /// </summary>
    public sealed class ScreenArrangementModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = "Screen";
        public ScreenTargetType TargetType { get; set; } = ScreenTargetType.Audience;
        public ScreenArrangementType ArrangementType { get; set; } = ScreenArrangementType.Single;
        public int Width { get; set; } = 1920;
        public int Height { get; set; } = 1080;
        public double RefreshRate { get; set; } = 60.0;

        public bool BackgroundEnabled { get; set; } = false;
        public Color BackgroundColor { get; set; } = Colors.Black;

        // Arrangement-specific parameters
        public int MirrorCount { get; set; } = 2;
        public int RowCount { get; set; } = 1;
        public int ColumnCount { get; set; } = 2;
        public double EdgeBlendWidth { get; set; } = 120.0;

        // Hardware Output Tab
        public string OutputDeviceName { get; set; } = "Disconnected: Generic PnP Monitor";
        public string OutputTargetMode { get; set; } = "Full";
        public int SubrectTargetIndex { get; set; } = 0;
        public int VideoDelayFrames { get; set; } = 0;

        // Color Tab
        public double RedLevel { get; set; } = 0.0;
        public double GreenLevel { get; set; } = 0.0;
        public double BlueLevel { get; set; } = 0.0;
        public double Gamma { get; set; } = 0.0;
        public double BlackLevel { get; set; } = 0.0;
        public double BrightnessNits { get; set; } = 100.0;

        // Corner Pin Tab
        public bool CornerPinningEnabled { get; set; } = false;
        public double TopLeftX { get; set; } = 0;
        public double TopLeftY { get; set; } = 0;
        public double TopRightX { get; set; } = 0;
        public double TopRightY { get; set; } = 0;
        public double BottomLeftX { get; set; } = 0;
        public double BottomLeftY { get; set; } = 0;
        public double BottomRightX { get; set; } = 0;
        public double BottomRightY { get; set; } = 0;

        // Alpha Key Tab
        public string AlphaMode { get; set; } = "None";
        public string AlphaFormat { get; set; } = "Straight";
        public double AlphaKeyLevel { get; set; } = 0.5;
        public string AlphaDeviceName { get; set; } = "Blackmagic DeckLink Key Channel";

        public ScreenArrangementModel Clone()
        {
            return (ScreenArrangementModel)MemberwiseClone();
        }
    }

    /// <summary>
    /// Singleton store maintaining active audience and stage screen configurations.
    /// </summary>
    public sealed class ScreenConfigurationStore
    {
        public static ScreenConfigurationStore Instance { get; } = new ScreenConfigurationStore();

        public ObservableCollection<ScreenArrangementModel> AudienceScreens { get; } = new();
        public ObservableCollection<ScreenArrangementModel> StageScreens { get; } = new();

        public bool AudienceEnabled { get; set; } = true;
        public bool StageEnabled { get; set; } = true;
        public bool IdentifyScreensActive { get; set; } = false;

        public event EventHandler? ConfigurationChanged;

        private ScreenConfigurationStore()
        {
            AudienceScreens.Add(new ScreenArrangementModel
            {
                Name = "Screen",
                TargetType = ScreenTargetType.Audience,
                ArrangementType = ScreenArrangementType.Single,
                Width = 1920,
                Height = 1080,
                OutputDeviceName = "Disconnected: Generic PnP Monitor"
            });

            StageScreens.Add(new ScreenArrangementModel
            {
                Name = "Stage Display",
                TargetType = ScreenTargetType.Stage,
                ArrangementType = ScreenArrangementType.Single,
                Width = 1920,
                Height = 1080,
                OutputDeviceName = "Disconnected: Generic PnP Monitor"
            });
        }

        public void NotifyChanged()
        {
            ConfigurationChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    /// <summary>
    /// Exact replica of ProPresenter.UI.OutputConfiguration.OutputConfigurationWindow (OutputConfigurationWindow.xaml).
    /// Width=840, Height=690, Dark Theme (#232326 / #1E1E22).
    /// </summary>
    public sealed class ScreenConfigurationWindow : Window
    {
        private readonly ScreenConfigurationStore _store = ScreenConfigurationStore.Instance;
        private ScreenArrangementModel? _selectedScreen;

        // Left Pane controls
        private StackPanel _audienceListStack = null!;
        private StackPanel _stageListStack = null!;
        private ToggleSwitchControl _audienceSwitch = null!;
        private ToggleSwitchControl _stageSwitch = null!;
        private ToggleSwitchControl _identifySwitch = null!;

        // Right Pane controls
        private TextBox _screenNameBox = null!;
        private TextBlock _resolutionText = null!;
        private CheckBox _screenColorCheckBox = null!;
        private Border _screenColorSwatch = null!;
        private ComboBox _arrangementComboBox = null!;
        private StackPanel _arrangementOptionsPanel = null!;
        private ScreenGridPreviewControl _previewCanvas = null!;
        private TextBlock _tabOutputTitle = null!;
        private TabControl _tabControl = null!;

        // Hardware Tab controls
        private ComboBox _outputDeviceCombo = null!;
        private ComboBox _outputTargetCombo = null!;
        private Border _targetAlignmentContainer = null!;
        private TextBlock _hardwareSpecsBlock = null!;
        private TextBox _videoDelayBox = null!;

        // Color Tab controls
        private Slider _redSlider = null!;
        private Slider _greenSlider = null!;
        private Slider _blueSlider = null!;
        private Slider _gammaSlider = null!;
        private Slider _blackSlider = null!;
        private Slider _nitsSlider = null!;
        private TextBlock _redValText = null!;
        private TextBlock _greenValText = null!;
        private TextBlock _blueValText = null!;
        private TextBlock _gammaValText = null!;
        private TextBlock _blackValText = null!;
        private TextBlock _nitsValText = null!;

        // Corner Pin controls
        private CheckBox _cornerPinEnable = null!;
        private Grid _cornerPinGrid = null!;
        private TextBox _tlXBox = null!, _tlYBox = null!;
        private TextBox _trXBox = null!, _trYBox = null!;
        private TextBox _blXBox = null!, _blYBox = null!;
        private TextBox _brXBox = null!, _brYBox = null!;

        // Alpha Key controls
        private ComboBox _alphaModeCombo = null!;
        private ComboBox _alphaFormatCombo = null!;
        private Slider _alphaKeySlider = null!;
        private TextBlock _alphaKeyValText = null!;
        private StackPanel _externalAlphaPanel = null!;

        // Callback hooks
        private readonly Action<bool>? _onAudienceToggled;
        private readonly Action<bool>? _onStageToggled;
        private readonly Action? _onIdentifyToggled;

        public ScreenConfigurationWindow(
            Action<bool>? onAudienceToggled = null,
            Action<bool>? onStageToggled = null,
            Action? onIdentifyToggled = null)
        {
            _onAudienceToggled = onAudienceToggled;
            _onStageToggled = onStageToggled;
            _onIdentifyToggled = onIdentifyToggled;

            Title = "Screen Configuration";
            Width = 840;
            Height = 690;
            MinWidth = 840;
            MinHeight = 690;
            ResizeMode = ResizeMode.NoResize;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Background = new SolidColorBrush(Color.FromRgb(0x23, 0x23, 0x26));
            Foreground = Brushes.White;
            WindowStyle = WindowStyle.None;

            BuildWindowChromeAndContent();
            SelectScreen(_store.AudienceScreens.FirstOrDefault() ?? _store.StageScreens.FirstOrDefault());
        }

        private void BuildWindowChromeAndContent()
        {
            var rootGrid = new Grid();
            rootGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(32) }); // Title Bar
            rootGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }); // Body

            // Custom ProPresenter Title Bar (#1D1D20)
            var titleBar = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(0x1D, 0x1D, 0x20)),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x32, 0x32, 0x36)),
                BorderThickness = new Thickness(0, 0, 0, 1)
            };
            var titleDock = new DockPanel();

            var closeBtn = new Button
            {
                Content = "✕",
                Width = 32,
                Height = 32,
                Background = Brushes.Transparent,
                BorderThickness = new Thickness(0),
                Foreground = new SolidColorBrush(Color.FromRgb(0xB0, 0xB0, 0xB4)),
                FontSize = 12,
                Cursor = Cursors.Hand
            };
            closeBtn.Click += (_, _) => Close();
            closeBtn.MouseEnter += (_, _) => closeBtn.Background = new SolidColorBrush(Color.FromRgb(0xE8, 0x11, 0x23));
            closeBtn.MouseLeave += (_, _) => closeBtn.Background = Brushes.Transparent;
            DockPanel.SetDock(closeBtn, Dock.Right);
            titleDock.Children.Add(closeBtn);

            var titleStack = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(10, 0, 0, 0) };
            var iconBox = new Border
            {
                Width = 14,
                Height = 11,
                BorderBrush = new SolidColorBrush(Color.FromRgb(0xC0, 0xC0, 0xC5)),
                BorderThickness = new Thickness(1.5),
                CornerRadius = new CornerRadius(1.5),
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 0, 8, 0)
            };
            titleStack.Children.Add(iconBox);
            titleStack.Children.Add(new TextBlock
            {
                Text = "Screen Configuration",
                FontSize = 12.5,
                FontWeight = FontWeights.SemiBold,
                Foreground = new SolidColorBrush(Color.FromRgb(0xD0, 0xD0, 0xD4)),
                VerticalAlignment = VerticalAlignment.Center
            });
            titleDock.Children.Add(titleStack);

            titleBar.Child = titleDock;
            titleBar.MouseLeftButtonDown += (_, e) =>
            {
                if (e.ButtonState == MouseButtonState.Pressed)
                    try { DragMove(); } catch { }
            };
            Grid.SetRow(titleBar, 0);
            rootGrid.Children.Add(titleBar);

            // Body: 2 Columns (240px and 600px)
            var bodyGrid = new Grid();
            bodyGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(240) });
            bodyGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(600) });

            // -------------------------------------------------------------
            // LEFT COLUMN (240px)
            // -------------------------------------------------------------
            var leftGrid = new Grid
            {
                Background = new SolidColorBrush(Color.FromRgb(0x26, 0x26, 0x29))
            };
            leftGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            leftGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(90) }); // Bottom Dock

            // Upper Scrollable Screen Lists
            var screenScroll = new ScrollViewer
            {
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled
            };
            var listStack = new StackPanel();

            // 1. Audience Header
            var audHeader = CreateScreenSectionHeader("Audience", _store.AudienceEnabled,
                toggleAction: isChecked =>
                {
                    _store.AudienceEnabled = isChecked;
                    _onAudienceToggled?.Invoke(isChecked);
                },
                addAction: () => ShowAddScreenMenu(ScreenTargetType.Audience));
            _audienceSwitch = audHeader.Switch;
            listStack.Children.Add(audHeader.HeaderBorder);

            // Audience Screens list container
            _audienceListStack = new StackPanel();
            listStack.Children.Add(_audienceListStack);

            // 2. Stage Header
            var stageHeader = CreateScreenSectionHeader("Stage", _store.StageEnabled,
                toggleAction: isChecked =>
                {
                    _store.StageEnabled = isChecked;
                    _onStageToggled?.Invoke(isChecked);
                },
                addAction: () => ShowAddScreenMenu(ScreenTargetType.Stage));
            _stageSwitch = stageHeader.Switch;
            listStack.Children.Add(stageHeader.HeaderBorder);

            // Stage Screens list container
            _stageListStack = new StackPanel();
            listStack.Children.Add(_stageListStack);

            screenScroll.Content = listStack;
            Grid.SetRow(screenScroll, 0);
            leftGrid.Children.Add(screenScroll);

            // Left Column Bottom Dock (#1E1E21)
            var bottomDock = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(0x1E, 0x1E, 0x21)),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x32, 0x32, 0x36)),
                BorderThickness = new Thickness(0, 1, 0, 0),
                Padding = new Thickness(10, 8, 10, 8)
            };
            var bottomStack = new StackPanel();

            // Identify Screens row
            var identifyGrid = new Grid();
            identifyGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            identifyGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            identifyGrid.Children.Add(new TextBlock
            {
                Text = "Identify Screens",
                FontSize = 13,
                Foreground = Brushes.White,
                VerticalAlignment = VerticalAlignment.Center
            });
            _identifySwitch = new ToggleSwitchControl
            {
                IsChecked = _store.IdentifyScreensActive,
                VerticalAlignment = VerticalAlignment.Center
            };
            _identifySwitch.IsCheckedChanged += (_, isChecked) =>
            {
                _store.IdentifyScreensActive = isChecked;
                ToggleIdentifyScreensOverlay(isChecked);
                _onIdentifyToggled?.Invoke();
            };
            Grid.SetColumn(_identifySwitch, 1);
            identifyGrid.Children.Add(_identifySwitch);
            bottomStack.Children.Add(identifyGrid);

            // Separator
            bottomStack.Children.Add(new Border
            {
                Height = 1,
                Background = new SolidColorBrush(Color.FromRgb(0x32, 0x32, 0x36)),
                Margin = new Thickness(0, 6, 0, 6)
            });

            // Test Patterns button
            var testPatternsBtn = new Button
            {
                Content = "Test Patterns",
                Height = 24,
                Width = 200,
                Background = new SolidColorBrush(Color.FromRgb(0x38, 0x38, 0x3B)),
                Foreground = Brushes.White,
                FontSize = 12,
                Cursor = Cursors.Hand,
                BorderThickness = new Thickness(0),
                HorizontalAlignment = HorizontalAlignment.Center
            };
            testPatternsBtn.Click += (_, _) => OpenTestPatternsDialog();
            bottomStack.Children.Add(testPatternsBtn);

            bottomDock.Child = bottomStack;
            Grid.SetRow(bottomDock, 1);
            leftGrid.Children.Add(bottomDock);

            Grid.SetColumn(leftGrid, 0);
            bodyGrid.Children.Add(leftGrid);

            // -------------------------------------------------------------
            // RIGHT COLUMN (600px)
            // -------------------------------------------------------------
            var rightBorder = new Border
            {
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x32, 0x32, 0x36)),
                BorderThickness = new Thickness(1, 0, 0, 0),
                Background = new SolidColorBrush(Color.FromRgb(0x23, 0x23, 0x26))
            };
            var rightGrid = new Grid();
            rightGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto }); // ScreenControlHeader (approx 75px)
            rightGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(220) }); // Preview Canvas
            rightGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }); // Tabs Area

            // 1. Header (ScreenControlHeader.xaml replica)
            var headerContainer = BuildScreenControlHeader();
            Grid.SetRow(headerContainer, 0);
            rightGrid.Children.Add(headerContainer);

            // 2. Center Preview Canvas (ScreenGridSelector.xaml replica)
            _previewCanvas = new ScreenGridPreviewControl
            {
                Height = 220,
                Margin = new Thickness(0)
            };
            Grid.SetRow(_previewCanvas, 1);
            rightGrid.Children.Add(_previewCanvas);

            // 3. Bottom Tabs (Hardware, Color, Corner Pin, Alpha Key)
            var tabsContainer = BuildTabsContainer();
            Grid.SetRow(tabsContainer, 2);
            rightGrid.Children.Add(tabsContainer);

            rightBorder.Child = rightGrid;
            Grid.SetColumn(rightBorder, 1);
            bodyGrid.Children.Add(rightBorder);

            Grid.SetRow(bodyGrid, 1);
            rootGrid.Children.Add(bodyGrid);

            Content = rootGrid;

            // Re-render screen lists in left column
            RefreshScreenLists();
        }

        private (Border HeaderBorder, ToggleSwitchControl Switch) CreateScreenSectionHeader(
            string title,
            bool isChecked,
            Action<bool> toggleAction,
            Action addAction)
        {
            var border = new Border
            {
                Height = 35,
                Background = new SolidColorBrush(Color.FromRgb(0x1F, 0x1F, 0x22)),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x32, 0x32, 0x36)),
                BorderThickness = new Thickness(0, 0, 0, 1),
                Padding = new Thickness(8, 0, 8, 0)
            };
            var dock = new DockPanel();

            var toggle = new ToggleSwitchControl
            {
                IsChecked = isChecked,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 0, 8, 0)
            };
            toggle.IsCheckedChanged += (_, c) => toggleAction(c);
            dock.Children.Add(toggle);

            var plusBtn = new Button
            {
                Content = "+",
                Width = 24,
                Height = 24,
                Background = Brushes.Transparent,
                BorderThickness = new Thickness(0),
                Foreground = Brushes.White,
                FontSize = 16,
                FontWeight = FontWeights.Bold,
                Cursor = Cursors.Hand,
                VerticalAlignment = VerticalAlignment.Center
            };
            plusBtn.Click += (_, _) => addAction();
            DockPanel.SetDock(plusBtn, Dock.Right);
            dock.Children.Add(plusBtn);

            var titleBlock = new TextBlock
            {
                Text = title,
                FontSize = 18,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.White,
                VerticalAlignment = VerticalAlignment.Center
            };
            dock.Children.Add(titleBlock);

            border.Child = dock;
            return (border, toggle);
        }

        private UIElement BuildScreenControlHeader()
        {
            var headerStack = new StackPanel();

            // Upper bar: Screen Name, Resolution, Screen Color
            var upperBorder = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(0x28, 0x28, 0x2C)),
                Padding = new Thickness(14, 8, 14, 6)
            };
            var upperGrid = new Grid();
            upperBorder.Child = upperGrid;
            upperGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            upperGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            var titleStack = new StackPanel();
            _screenNameBox = new TextBox
            {
                Text = "Screen",
                FontSize = 20,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.White,
                Background = Brushes.Transparent,
                BorderThickness = new Thickness(0),
                CaretBrush = Brushes.White,
                Margin = new Thickness(-2, 0, 0, 0)
            };
            _screenNameBox.TextChanged += (_, _) =>
            {
                if (_selectedScreen != null)
                {
                    _selectedScreen.Name = _screenNameBox.Text;
                    RefreshScreenLists();
                    _previewCanvas.SetScreen(_selectedScreen);
                }
            };
            titleStack.Children.Add(_screenNameBox);

            _resolutionText = new TextBlock
            {
                Text = "1920 x 1080",
                FontSize = 12,
                FontWeight = FontWeights.SemiBold,
                Foreground = new SolidColorBrush(Color.FromRgb(0xA0, 0xA0, 0xA5)),
                Margin = new Thickness(0, 2, 0, 0)
            };
            titleStack.Children.Add(_resolutionText);
            upperGrid.Children.Add(titleStack);

            // Right side: [x] Screen Color + Swatch
            var colorStack = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                VerticalAlignment = VerticalAlignment.Center
            };
            _screenColorCheckBox = new CheckBox
            {
                Content = "Screen Color",
                Foreground = Brushes.White,
                FontSize = 12,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 0, 8, 0)
            };
            _screenColorCheckBox.Checked += (_, _) =>
            {
                if (_selectedScreen != null)
                {
                    _selectedScreen.BackgroundEnabled = true;
                    _previewCanvas.SetScreen(_selectedScreen);
                }
            };
            _screenColorCheckBox.Unchecked += (_, _) =>
            {
                if (_selectedScreen != null)
                {
                    _selectedScreen.BackgroundEnabled = false;
                    _previewCanvas.SetScreen(_selectedScreen);
                }
            };
            colorStack.Children.Add(_screenColorCheckBox);

            _screenColorSwatch = new Border
            {
                Width = 26,
                Height = 20,
                CornerRadius = new CornerRadius(3),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x60, 0x60, 0x65)),
                BorderThickness = new Thickness(1),
                Background = Brushes.Black,
                Cursor = Cursors.Hand
            };
            _screenColorSwatch.MouseLeftButtonDown += (_, _) => ShowColorPickerMenu();
            colorStack.Children.Add(_screenColorSwatch);

            Grid.SetColumn(colorStack, 1);
            upperGrid.Children.Add(colorStack);
            headerStack.Children.Add(upperBorder);

            // Lower bar: Arrangement Type dropdown & mirror/group options
            var lowerBar = new Border
            {
                Height = 35,
                Background = new SolidColorBrush(Color.FromRgb(0x1E, 0x1E, 0x22)),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x32, 0x32, 0x36)),
                BorderThickness = new Thickness(0, 1, 0, 1),
                Padding = new Thickness(14, 0, 14, 0)
            };
            var lowerDock = new DockPanel();

            _arrangementComboBox = new ComboBox
            {
                Width = 110,
                Height = 22,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left
            };
            _arrangementComboBox.Items.Add("Single");
            _arrangementComboBox.Items.Add("Mirror");
            _arrangementComboBox.Items.Add("Group");
            _arrangementComboBox.Items.Add("Edge Blend");
            _arrangementComboBox.SelectedIndex = 0;
            _arrangementComboBox.SelectionChanged += (_, _) =>
            {
                if (_selectedScreen != null && _arrangementComboBox.SelectedIndex >= 0)
                {
                    _selectedScreen.ArrangementType = (ScreenArrangementType)_arrangementComboBox.SelectedIndex;
                    UpdateArrangementOptionsVisibility();
                    _previewCanvas.SetScreen(_selectedScreen);
                }
            };
            lowerDock.Children.Add(_arrangementComboBox);

            _arrangementOptionsPanel = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(14, 0, 0, 0)
            };
            lowerDock.Children.Add(_arrangementOptionsPanel);

            lowerBar.Child = lowerDock;
            headerStack.Children.Add(lowerBar);

            return headerStack;
        }

        private UIElement BuildTabsContainer()
        {
            var tabsHost = new Grid
            {
                Background = new SolidColorBrush(Color.FromRgb(0x23, 0x23, 0x26))
            };
            tabsHost.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto }); // Header (Output title)
            tabsHost.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }); // Tabs

            _tabOutputTitle = new TextBlock
            {
                Text = "Disconnected: Generic PnP Monitor",
                FontSize = 14,
                FontWeight = FontWeights.SemiBold,
                Foreground = Brushes.White,
                Margin = new Thickness(20, 10, 20, 6)
            };
            Grid.SetRow(_tabOutputTitle, 0);
            tabsHost.Children.Add(_tabOutputTitle);

            _tabControl = new TabControl
            {
                Background = new SolidColorBrush(Color.FromRgb(0x26, 0x26, 0x29)),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x32, 0x32, 0x36)),
                Margin = new Thickness(14, 0, 14, 10)
            };

            // Tab 1: Hardware
            var hwTab = new TabItem
            {
                Header = "Hardware",
                Content = BuildHardwareTabContent()
            };
            _tabControl.Items.Add(hwTab);

            // Tab 2: Color
            var colorTab = new TabItem
            {
                Header = "Color",
                Content = BuildColorTabContent()
            };
            _tabControl.Items.Add(colorTab);

            // Tab 3: Corner Pin
            var pinTab = new TabItem
            {
                Header = "Corner Pin",
                Content = BuildCornerPinTabContent()
            };
            _tabControl.Items.Add(pinTab);

            // Tab 4: Alpha Key
            var alphaTab = new TabItem
            {
                Header = "Alpha Key",
                Content = BuildAlphaKeyTabContent()
            };
            _tabControl.Items.Add(alphaTab);

            Grid.SetRow(_tabControl, 1);
            tabsHost.Children.Add(_tabControl);

            return tabsHost;
        }

        private UIElement BuildHardwareTabContent()
        {
            var grid = new Grid { Margin = new Thickness(14) };
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(14) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            // Left Column: Output Selector + Output Card + Video Delay Card
            var leftStack = new StackPanel();
            leftStack.Children.Add(new TextBlock
            {
                Text = "Output",
                FontSize = 12.5,
                FontWeight = FontWeights.SemiBold,
                Foreground = Brushes.White,
                Margin = new Thickness(0, 0, 0, 6)
            });

            _outputDeviceCombo = new ComboBox
            {
                Height = 24,
                Margin = new Thickness(0, 0, 0, 10)
            };
            _outputDeviceCombo.Items.Add("Disconnected: Generic PnP Monitor");
            _outputDeviceCombo.Items.Add("Display 1: Generic PnP Monitor (1920x1080)");
            _outputDeviceCombo.Items.Add("Display 2: Projector Output (1920x1080)");
            _outputDeviceCombo.Items.Add("NDI Output: ProPresenter Main Sanctuary");
            _outputDeviceCombo.Items.Add("Blackmagic DeckLink SDI Output 1");
            _outputDeviceCombo.Items.Add("Spout / Syphon Graphics Output");
            _outputDeviceCombo.Items.Add("Custom Placeholder (1920x1080)");
            _outputDeviceCombo.SelectedIndex = 0;
            _outputDeviceCombo.SelectionChanged += (_, _) =>
            {
                if (_selectedScreen != null && _outputDeviceCombo.SelectedItem is string dev)
                {
                    _selectedScreen.OutputDeviceName = dev;
                    _tabOutputTitle.Text = dev;
                    _previewCanvas.SetScreen(_selectedScreen);
                }
            };
            leftStack.Children.Add(_outputDeviceCombo);

            // Output Card
            var specCard = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(0x1F, 0x1F, 0x22)),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x38, 0x38, 0x3C)),
                BorderThickness = new Thickness(1),
                CornerRadius = new CornerRadius(4),
                Padding = new Thickness(10, 8, 10, 8),
                Margin = new Thickness(0, 0, 0, 10)
            };
            var specGrid = new Grid();
            specGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(90) });
            specGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            specGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            specGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            specGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            specGrid.Children.Add(new TextBlock { Text = "Name:", Foreground = new SolidColorBrush(Color.FromRgb(0x8E, 0x8E, 0x93)), FontSize = 11.5, Margin = new Thickness(0, 2, 0, 2) });
            _hardwareSpecsBlock = new TextBlock { Text = "Generic PnP Monitor", Foreground = Brushes.White, FontSize = 11.5, Margin = new Thickness(0, 2, 0, 2) };
            Grid.SetColumn(_hardwareSpecsBlock, 1);
            specGrid.Children.Add(_hardwareSpecsBlock);

            var boundsLbl = new TextBlock { Text = "Bounds:", Foreground = new SolidColorBrush(Color.FromRgb(0x8E, 0x8E, 0x93)), FontSize = 11.5, Margin = new Thickness(0, 2, 0, 2) };
            Grid.SetRow(boundsLbl, 1);
            specGrid.Children.Add(boundsLbl);
            var boundsVal = new TextBlock { Text = "1920 x 1080", Foreground = Brushes.White, FontSize = 11.5, Margin = new Thickness(0, 2, 0, 2) };
            Grid.SetRow(boundsVal, 1);
            Grid.SetColumn(boundsVal, 1);
            specGrid.Children.Add(boundsVal);

            var aspectLbl = new TextBlock { Text = "Aspect Ratio:", Foreground = new SolidColorBrush(Color.FromRgb(0x8E, 0x8E, 0x93)), FontSize = 11.5, Margin = new Thickness(0, 2, 0, 2) };
            Grid.SetRow(aspectLbl, 2);
            specGrid.Children.Add(aspectLbl);
            var aspectVal = new TextBlock { Text = "16:9", Foreground = Brushes.White, FontSize = 11.5, Margin = new Thickness(0, 2, 0, 2) };
            Grid.SetRow(aspectVal, 2);
            Grid.SetColumn(aspectVal, 1);
            specGrid.Children.Add(aspectVal);

            specCard.Child = specGrid;
            leftStack.Children.Add(specCard);

            // Video Delay Card
            var delayCard = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(0x1F, 0x1F, 0x22)),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x38, 0x38, 0x3C)),
                BorderThickness = new Thickness(1),
                CornerRadius = new CornerRadius(4),
                Padding = new Thickness(10, 6, 10, 6)
            };
            var delayDock = new DockPanel();
            delayDock.Children.Add(new TextBlock
            {
                Text = "Video Delay",
                FontSize = 12,
                Foreground = Brushes.White,
                VerticalAlignment = VerticalAlignment.Center
            });

            var delayStack = new StackPanel { Orientation = Orientation.Horizontal };
            _videoDelayBox = new TextBox
            {
                Text = "0",
                Width = 45,
                Height = 22,
                TextAlignment = TextAlignment.Center,
                Background = new SolidColorBrush(Color.FromRgb(0x2A, 0x2A, 0x2E)),
                Foreground = Brushes.White,
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x44, 0x44, 0x48)),
                VerticalContentAlignment = VerticalAlignment.Center
            };
            _videoDelayBox.TextChanged += (_, _) =>
            {
                if (_selectedScreen != null && int.TryParse(_videoDelayBox.Text, out int d))
                    _selectedScreen.VideoDelayFrames = d;
            };
            delayStack.Children.Add(_videoDelayBox);
            delayStack.Children.Add(new TextBlock
            {
                Text = "Frames",
                FontSize = 11.5,
                Foreground = new SolidColorBrush(Color.FromRgb(0x8E, 0x8E, 0x93)),
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(6, 0, 0, 0)
            });
            DockPanel.SetDock(delayStack, Dock.Right);
            delayDock.Children.Add(delayStack);
            delayCard.Child = delayDock;
            leftStack.Children.Add(delayCard);

            Grid.SetColumn(leftStack, 0);
            grid.Children.Add(leftStack);

            // Right Column: Output Target + Target Alignment grid
            var rightStack = new StackPanel();
            rightStack.Children.Add(new TextBlock
            {
                Text = "Output Target",
                FontSize = 12.5,
                FontWeight = FontWeights.SemiBold,
                Foreground = Brushes.White,
                Margin = new Thickness(0, 0, 0, 6)
            });

            _outputTargetCombo = new ComboBox
            {
                Height = 24,
                Margin = new Thickness(0, 0, 0, 10)
            };
            _outputTargetCombo.Items.Add("Full");
            _outputTargetCombo.Items.Add("2x1");
            _outputTargetCombo.Items.Add("2x2");
            _outputTargetCombo.Items.Add("3x1");
            _outputTargetCombo.Items.Add("Custom");
            _outputTargetCombo.SelectedIndex = 0;
            _outputTargetCombo.SelectionChanged += (_, _) =>
            {
                if (_selectedScreen != null && _outputTargetCombo.SelectedItem is string target)
                {
                    _selectedScreen.OutputTargetMode = target;
                    UpdateTargetAlignmentGrid(target);
                }
            };
            rightStack.Children.Add(_outputTargetCombo);

            _targetAlignmentContainer = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(0x1F, 0x1F, 0x22)),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x38, 0x38, 0x3C)),
                BorderThickness = new Thickness(1),
                CornerRadius = new CornerRadius(4),
                Padding = new Thickness(10, 8, 10, 8),
                Visibility = Visibility.Collapsed
            };
            rightStack.Children.Add(_targetAlignmentContainer);

            Grid.SetColumn(rightStack, 2);
            grid.Children.Add(rightStack);

            return grid;
        }

        private void UpdateTargetAlignmentGrid(string mode)
        {
            if (mode == "Full")
            {
                _targetAlignmentContainer.Visibility = Visibility.Collapsed;
                return;
            }

            _targetAlignmentContainer.Visibility = Visibility.Visible;
            var dock = new DockPanel();
            dock.Children.Add(new TextBlock
            {
                Text = "Output Alignment",
                FontSize = 12,
                Foreground = Brushes.White,
                VerticalAlignment = VerticalAlignment.Center
            });

            var btnStack = new StackPanel { Orientation = Orientation.Horizontal };
            DockPanel.SetDock(btnStack, Dock.Right);

            if (mode == "2x1")
            {
                for (int i = 0; i < 2; i++)
                {
                    int index = i;
                    var btn = new Button
                    {
                        Content = (i + 1).ToString(),
                        Width = 22,
                        Height = 22,
                        Margin = new Thickness(3, 0, 0, 0),
                        Background = _selectedScreen?.SubrectTargetIndex == index ? new SolidColorBrush(Color.FromRgb(0x00, 0x7A, 0xFF)) : new SolidColorBrush(Color.FromRgb(0x32, 0x32, 0x36)),
                        Foreground = Brushes.White,
                        Cursor = Cursors.Hand
                    };
                    btn.Click += (_, _) =>
                    {
                        if (_selectedScreen != null) _selectedScreen.SubrectTargetIndex = index;
                        UpdateTargetAlignmentGrid("2x1");
                    };
                    btnStack.Children.Add(btn);
                }
            }
            else if (mode == "2x2")
            {
                var grid2x2 = new Grid { Width = 48, Height = 48 };
                grid2x2.ColumnDefinitions.Add(new ColumnDefinition());
                grid2x2.ColumnDefinitions.Add(new ColumnDefinition());
                grid2x2.RowDefinitions.Add(new RowDefinition());
                grid2x2.RowDefinitions.Add(new RowDefinition());

                for (int r = 0; r < 2; r++)
                {
                    for (int c = 0; c < 2; c++)
                    {
                        int idx = r * 2 + c;
                        var btn = new Button
                        {
                            Content = (idx + 1).ToString(),
                            Margin = new Thickness(1),
                            Background = _selectedScreen?.SubrectTargetIndex == idx ? new SolidColorBrush(Color.FromRgb(0x00, 0x7A, 0xFF)) : new SolidColorBrush(Color.FromRgb(0x32, 0x32, 0x36)),
                            Foreground = Brushes.White,
                            FontSize = 10,
                            Cursor = Cursors.Hand
                        };
                        btn.Click += (_, _) =>
                        {
                            if (_selectedScreen != null) _selectedScreen.SubrectTargetIndex = idx;
                            UpdateTargetAlignmentGrid("2x2");
                        };
                        Grid.SetRow(btn, r);
                        Grid.SetColumn(btn, c);
                        grid2x2.Children.Add(btn);
                    }
                }
                btnStack.Children.Add(grid2x2);
            }
            else if (mode == "3x1")
            {
                for (int i = 0; i < 3; i++)
                {
                    int index = i;
                    var btn = new Button
                    {
                        Content = (i + 1).ToString(),
                        Width = 20,
                        Height = 22,
                        Margin = new Thickness(2, 0, 0, 0),
                        Background = _selectedScreen?.SubrectTargetIndex == index ? new SolidColorBrush(Color.FromRgb(0x00, 0x7A, 0xFF)) : new SolidColorBrush(Color.FromRgb(0x32, 0x32, 0x36)),
                        Foreground = Brushes.White,
                        Cursor = Cursors.Hand
                    };
                    btn.Click += (_, _) =>
                    {
                        if (_selectedScreen != null) _selectedScreen.SubrectTargetIndex = index;
                        UpdateTargetAlignmentGrid("3x1");
                    };
                    btnStack.Children.Add(btn);
                }
            }
            else if (mode == "Custom")
            {
                var customStack = new StackPanel { Orientation = Orientation.Horizontal };
                customStack.Children.Add(new TextBlock { Text = "X: 0 Y: 0 W: 1920 H: 1080", Foreground = Brushes.White, FontSize = 11, VerticalAlignment = VerticalAlignment.Center });
                btnStack.Children.Add(customStack);
            }

            dock.Children.Add(btnStack);
            _targetAlignmentContainer.Child = dock;
        }

        private UIElement BuildColorTabContent()
        {
            var stack = new StackPanel { Margin = new Thickness(16, 12, 16, 12) };

            (Slider, TextBlock) AddColorRow(string label, double initialVal, Action<double> onVal)
            {
                var g = new Grid { Margin = new Thickness(0, 3, 0, 3) };
                g.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(80) });
                g.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                g.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(50) });

                g.Children.Add(new TextBlock
                {
                    Text = label,
                    Foreground = Brushes.White,
                    FontSize = 12,
                    VerticalAlignment = VerticalAlignment.Center
                });

                var slider = new Slider
                {
                    Minimum = -1.0,
                    Maximum = 1.0,
                    Value = initialVal,
                    TickFrequency = 0.1,
                    IsSnapToTickEnabled = true,
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(8, 0, 8, 0)
                };
                Grid.SetColumn(slider, 1);
                g.Children.Add(slider);

                var valTxt = new TextBlock
                {
                    Text = initialVal.ToString("F1"),
                    Foreground = new SolidColorBrush(Color.FromRgb(0xC0, 0xC0, 0xC5)),
                    FontSize = 12,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Right
                };
                slider.ValueChanged += (_, e) =>
                {
                    valTxt.Text = e.NewValue.ToString("F1");
                    onVal(e.NewValue);
                };
                Grid.SetColumn(valTxt, 2);
                g.Children.Add(valTxt);

                stack.Children.Add(g);
                return (slider, valTxt);
            }

            (_redSlider, _redValText) = AddColorRow("Red", 0.0, v => { if (_selectedScreen != null) _selectedScreen.RedLevel = v; });
            (_greenSlider, _greenValText) = AddColorRow("Green", 0.0, v => { if (_selectedScreen != null) _selectedScreen.GreenLevel = v; });
            (_blueSlider, _blueValText) = AddColorRow("Blue", 0.0, v => { if (_selectedScreen != null) _selectedScreen.BlueLevel = v; });
            (_gammaSlider, _gammaValText) = AddColorRow("Gamma", 0.0, v => { if (_selectedScreen != null) _selectedScreen.Gamma = v; });
            (_blackSlider, _blackValText) = AddColorRow("Black", 0.0, v => { if (_selectedScreen != null) _selectedScreen.BlackLevel = v; });

            // Brightness / HDR Nits
            var hdrGrid = new Grid { Margin = new Thickness(0, 3, 0, 3) };
            hdrGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(80) });
            hdrGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            hdrGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(50) });
            hdrGrid.Children.Add(new TextBlock { Text = "Brightness", Foreground = Brushes.White, FontSize = 12, VerticalAlignment = VerticalAlignment.Center });
            _nitsSlider = new Slider { Minimum = 10, Maximum = 1000, Value = 100, VerticalAlignment = VerticalAlignment.Center, Margin = new Thickness(8, 0, 8, 0) };
            Grid.SetColumn(_nitsSlider, 1);
            hdrGrid.Children.Add(_nitsSlider);
            _nitsValText = new TextBlock { Text = "100%", Foreground = new SolidColorBrush(Color.FromRgb(0xC0, 0xC0, 0xC5)), FontSize = 12, VerticalAlignment = VerticalAlignment.Center, HorizontalAlignment = HorizontalAlignment.Right };
            _nitsSlider.ValueChanged += (_, e) =>
            {
                _nitsValText.Text = $"{(int)e.NewValue}%";
                if (_selectedScreen != null) _selectedScreen.BrightnessNits = e.NewValue;
            };
            Grid.SetColumn(_nitsValText, 2);
            hdrGrid.Children.Add(_nitsValText);
            stack.Children.Add(hdrGrid);

            // Reset button
            var resetBtn = new Button
            {
                Content = "Reset Color Adjustments",
                Height = 24,
                Width = 170,
                Background = new SolidColorBrush(Color.FromRgb(0x38, 0x38, 0x3C)),
                Foreground = Brushes.White,
                FontSize = 11.5,
                Margin = new Thickness(0, 8, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Right,
                Cursor = Cursors.Hand
            };
            resetBtn.Click += (_, _) =>
            {
                _redSlider.Value = 0;
                _greenSlider.Value = 0;
                _blueSlider.Value = 0;
                _gammaSlider.Value = 0;
                _blackSlider.Value = 0;
                _nitsSlider.Value = 100;
            };
            stack.Children.Add(resetBtn);

            return stack;
        }

        private UIElement BuildCornerPinTabContent()
        {
            var stack = new StackPanel { Margin = new Thickness(16, 10, 16, 10) };

            _cornerPinEnable = new CheckBox
            {
                Content = "Enable Corner Pinning",
                Foreground = Brushes.White,
                FontSize = 12.5,
                FontWeight = FontWeights.SemiBold,
                Margin = new Thickness(0, 0, 0, 4)
            };
            _cornerPinEnable.Checked += (_, _) =>
            {
                if (_selectedScreen != null)
                {
                    _selectedScreen.CornerPinningEnabled = true;
                    _cornerPinGrid.IsEnabled = true;
                    _previewCanvas.SetScreen(_selectedScreen);
                }
            };
            _cornerPinEnable.Unchecked += (_, _) =>
            {
                if (_selectedScreen != null)
                {
                    _selectedScreen.CornerPinningEnabled = false;
                    _cornerPinGrid.IsEnabled = false;
                    _previewCanvas.SetScreen(_selectedScreen);
                }
            };
            stack.Children.Add(_cornerPinEnable);

            stack.Children.Add(new TextBlock
            {
                Text = "Adjust corner coordinates to compensate for non-planar or keystoned projection surfaces.",
                Foreground = new SolidColorBrush(Color.FromRgb(0x8E, 0x8E, 0x93)),
                FontSize = 11.5,
                Margin = new Thickness(0, 0, 0, 10)
            });

            _cornerPinGrid = new Grid { IsEnabled = false };
            _cornerPinGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            _cornerPinGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(20) });
            _cornerPinGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            _cornerPinGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            _cornerPinGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            (TextBox xBox, TextBox yBox, Border border) CreatePinQuadrant(string label)
            {
                var qBorder = new Border
                {
                    Background = new SolidColorBrush(Color.FromRgb(0x1F, 0x1F, 0x22)),
                    BorderBrush = new SolidColorBrush(Color.FromRgb(0x38, 0x38, 0x3C)),
                    BorderThickness = new Thickness(1),
                    CornerRadius = new CornerRadius(4),
                    Padding = new Thickness(8, 4, 8, 4),
                    Margin = new Thickness(0, 2, 0, 2)
                };
                var qGrid = new Grid();
                qGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(70) });
                qGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                qGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

                qGrid.Children.Add(new TextBlock
                {
                    Text = label,
                    Foreground = Brushes.White,
                    FontSize = 11.5,
                    VerticalAlignment = VerticalAlignment.Center
                });

                var xStack = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(4, 0, 4, 0) };
                xStack.Children.Add(new TextBlock { Text = "ΔX:", Foreground = new SolidColorBrush(Color.FromRgb(0x8E, 0x8E, 0x93)), FontSize = 10, VerticalAlignment = VerticalAlignment.Center });
                var xIn = new TextBox { Text = "0", Width = 40, Height = 20, TextAlignment = TextAlignment.Center, Background = new SolidColorBrush(Color.FromRgb(0x28, 0x28, 0x2C)), Foreground = Brushes.White, BorderThickness = new Thickness(0) };
                xStack.Children.Add(xIn);
                Grid.SetColumn(xStack, 1);
                qGrid.Children.Add(xStack);

                var yStack = new StackPanel { Orientation = Orientation.Horizontal };
                yStack.Children.Add(new TextBlock { Text = "ΔY:", Foreground = new SolidColorBrush(Color.FromRgb(0x8E, 0x8E, 0x93)), FontSize = 10, VerticalAlignment = VerticalAlignment.Center });
                var yIn = new TextBox { Text = "0", Width = 40, Height = 20, TextAlignment = TextAlignment.Center, Background = new SolidColorBrush(Color.FromRgb(0x28, 0x28, 0x2C)), Foreground = Brushes.White, BorderThickness = new Thickness(0) };
                yStack.Children.Add(yIn);
                Grid.SetColumn(yStack, 2);
                qGrid.Children.Add(yStack);

                qBorder.Child = qGrid;
                return (xIn, yIn, qBorder);
            }

            var (tlX, tlY, tlBorder) = CreatePinQuadrant("Top Left");
            _tlXBox = tlX; _tlYBox = tlY;
            Grid.SetRow(tlBorder, 0);
            Grid.SetColumn(tlBorder, 0);
            _cornerPinGrid.Children.Add(tlBorder);

            var (trX, trY, trBorder) = CreatePinQuadrant("Top Right");
            _trXBox = trX; _trYBox = trY;
            Grid.SetRow(trBorder, 0);
            Grid.SetColumn(trBorder, 2);
            _cornerPinGrid.Children.Add(trBorder);

            var (blX, blY, blBorder) = CreatePinQuadrant("Bottom Left");
            _blXBox = blX; _blYBox = blY;
            Grid.SetRow(blBorder, 1);
            Grid.SetColumn(blBorder, 0);
            _cornerPinGrid.Children.Add(blBorder);

            var (brX, brY, brBorder) = CreatePinQuadrant("Bottom Right");
            _brXBox = brX; _brYBox = brY;
            Grid.SetRow(brBorder, 1);
            Grid.SetColumn(brBorder, 2);
            _cornerPinGrid.Children.Add(brBorder);

            stack.Children.Add(_cornerPinGrid);

            var resetPinBtn = new Button
            {
                Content = "Reset All",
                Height = 22,
                Width = 90,
                Background = new SolidColorBrush(Color.FromRgb(0x38, 0x38, 0x3C)),
                Foreground = Brushes.White,
                FontSize = 11,
                Margin = new Thickness(0, 8, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Center,
                Cursor = Cursors.Hand
            };
            resetPinBtn.Click += (_, _) =>
            {
                _tlXBox.Text = "0"; _tlYBox.Text = "0";
                _trXBox.Text = "0"; _trYBox.Text = "0";
                _blXBox.Text = "0"; _blYBox.Text = "0";
                _brXBox.Text = "0"; _brYBox.Text = "0";
                if (_selectedScreen != null)
                {
                    _selectedScreen.TopLeftX = _selectedScreen.TopLeftY = 0;
                    _selectedScreen.TopRightX = _selectedScreen.TopRightY = 0;
                    _selectedScreen.BottomLeftX = _selectedScreen.BottomLeftY = 0;
                    _selectedScreen.BottomRightX = _selectedScreen.BottomRightY = 0;
                    _previewCanvas.SetScreen(_selectedScreen);
                }
            };
            stack.Children.Add(resetPinBtn);

            return stack;
        }

        private UIElement BuildAlphaKeyTabContent()
        {
            var stack = new StackPanel { Margin = new Thickness(16, 12, 16, 12) };

            var modeGrid = new Grid { Margin = new Thickness(0, 0, 0, 8) };
            modeGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(100) });
            modeGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            modeGrid.Children.Add(new TextBlock { Text = "Keying Mode", Foreground = Brushes.White, FontSize = 12, VerticalAlignment = VerticalAlignment.Center });

            _alphaModeCombo = new ComboBox { Height = 24 };
            _alphaModeCombo.Items.Add("None");
            _alphaModeCombo.Items.Add("Internal (Software Alpha Key)");
            _alphaModeCombo.Items.Add("External (Key & Fill SDI / NDI)");
            _alphaModeCombo.SelectedIndex = 0;
            _alphaModeCombo.SelectionChanged += (_, _) =>
            {
                if (_selectedScreen != null && _alphaModeCombo.SelectedItem is string m)
                {
                    _selectedScreen.AlphaMode = m;
                    _externalAlphaPanel.Visibility = m.StartsWith("External") ? Visibility.Visible : Visibility.Collapsed;
                }
            };
            Grid.SetColumn(_alphaModeCombo, 1);
            modeGrid.Children.Add(_alphaModeCombo);
            stack.Children.Add(modeGrid);

            var formatGrid = new Grid { Margin = new Thickness(0, 0, 0, 8) };
            formatGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(100) });
            formatGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            formatGrid.Children.Add(new TextBlock { Text = "Alpha Format", Foreground = Brushes.White, FontSize = 12, VerticalAlignment = VerticalAlignment.Center });

            _alphaFormatCombo = new ComboBox { Height = 24 };
            _alphaFormatCombo.Items.Add("Straight (Unmatted)");
            _alphaFormatCombo.Items.Add("Premultiplied");
            _alphaFormatCombo.SelectedIndex = 0;
            _alphaFormatCombo.SelectionChanged += (_, _) =>
            {
                if (_selectedScreen != null && _alphaFormatCombo.SelectedItem is string f)
                    _selectedScreen.AlphaFormat = f;
            };
            Grid.SetColumn(_alphaFormatCombo, 1);
            formatGrid.Children.Add(_alphaFormatCombo);
            stack.Children.Add(formatGrid);

            var levelGrid = new Grid { Margin = new Thickness(0, 0, 0, 8) };
            levelGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(100) });
            levelGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            levelGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(45) });
            levelGrid.Children.Add(new TextBlock { Text = "Key Level", Foreground = Brushes.White, FontSize = 12, VerticalAlignment = VerticalAlignment.Center });

            _alphaKeySlider = new Slider { Minimum = 0, Maximum = 100, Value = 50, VerticalAlignment = VerticalAlignment.Center, Margin = new Thickness(8, 0, 8, 0) };
            Grid.SetColumn(_alphaKeySlider, 1);
            levelGrid.Children.Add(_alphaKeySlider);
            _alphaKeyValText = new TextBlock { Text = "50%", Foreground = new SolidColorBrush(Color.FromRgb(0xC0, 0xC0, 0xC5)), FontSize = 12, VerticalAlignment = VerticalAlignment.Center, HorizontalAlignment = HorizontalAlignment.Right };
            _alphaKeySlider.ValueChanged += (_, e) =>
            {
                _alphaKeyValText.Text = $"{(int)e.NewValue}%";
                if (_selectedScreen != null) _selectedScreen.AlphaKeyLevel = e.NewValue / 100.0;
            };
            Grid.SetColumn(_alphaKeyValText, 2);
            levelGrid.Children.Add(_alphaKeyValText);
            stack.Children.Add(levelGrid);

            _externalAlphaPanel = new StackPanel { Visibility = Visibility.Collapsed };
            _externalAlphaPanel.Children.Add(new TextBlock { Text = "Key Output Device (Secondary Channel)", Foreground = Brushes.White, FontSize = 11.5, Margin = new Thickness(0, 4, 0, 4) });
            var extCombo = new ComboBox { Height = 24 };
            extCombo.Items.Add("Blackmagic DeckLink Key Channel 2");
            extCombo.Items.Add("Secondary Display Video Output");
            extCombo.Items.Add("NDI Alpha Channel Alpha stream");
            extCombo.SelectedIndex = 0;
            _externalAlphaPanel.Children.Add(extCombo);
            stack.Children.Add(_externalAlphaPanel);

            return stack;
        }

        public void SelectScreen(ScreenArrangementModel? screen)
        {
            _selectedScreen = screen;
            if (screen == null) return;

            _screenNameBox.Text = screen.Name;
            _resolutionText.Text = $"{screen.Width} x {screen.Height}";
            _screenColorCheckBox.IsChecked = screen.BackgroundEnabled;
            _screenColorSwatch.Background = new SolidColorBrush(screen.BackgroundColor);

            _arrangementComboBox.SelectedIndex = (int)screen.ArrangementType;
            UpdateArrangementOptionsVisibility();

            _tabOutputTitle.Text = screen.OutputDeviceName;
            _previewCanvas.SetScreen(screen);

            RefreshScreenLists();
        }

        private void UpdateArrangementOptionsVisibility()
        {
            _arrangementOptionsPanel.Children.Clear();
            if (_selectedScreen == null) return;

            if (_selectedScreen.ArrangementType == ScreenArrangementType.Mirror)
            {
                _arrangementOptionsPanel.Children.Add(new TextBlock
                {
                    Text = "Output Count:",
                    Foreground = Brushes.White,
                    FontSize = 12,
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(0, 0, 6, 0)
                });
                var countBox = new TextBox
                {
                    Text = _selectedScreen.MirrorCount.ToString(),
                    Width = 40,
                    Height = 22,
                    TextAlignment = TextAlignment.Center,
                    Background = new SolidColorBrush(Color.FromRgb(0x28, 0x28, 0x2C)),
                    Foreground = Brushes.White,
                    BorderThickness = new Thickness(0)
                };
                countBox.TextChanged += (_, _) =>
                {
                    if (int.TryParse(countBox.Text, out int c))
                    {
                        _selectedScreen.MirrorCount = Math.Max(2, Math.Min(8, c));
                        _previewCanvas.SetScreen(_selectedScreen);
                    }
                };
                _arrangementOptionsPanel.Children.Add(countBox);
            }
            else if (_selectedScreen.ArrangementType == ScreenArrangementType.Group)
            {
                _arrangementOptionsPanel.Children.Add(new TextBlock { Text = "Rows:", Foreground = Brushes.White, FontSize = 12, VerticalAlignment = VerticalAlignment.Center, Margin = new Thickness(0, 0, 4, 0) });
                var rowBox = new TextBox { Text = _selectedScreen.RowCount.ToString(), Width = 35, Height = 22, TextAlignment = TextAlignment.Center, Background = new SolidColorBrush(Color.FromRgb(0x28, 0x28, 0x2C)), Foreground = Brushes.White, BorderThickness = new Thickness(0) };
                rowBox.TextChanged += (_, _) => { if (int.TryParse(rowBox.Text, out int r)) { _selectedScreen.RowCount = Math.Max(1, r); _previewCanvas.SetScreen(_selectedScreen); } };
                _arrangementOptionsPanel.Children.Add(rowBox);

                _arrangementOptionsPanel.Children.Add(new TextBlock { Text = "Cols:", Foreground = Brushes.White, FontSize = 12, VerticalAlignment = VerticalAlignment.Center, Margin = new Thickness(8, 0, 4, 0) });
                var colBox = new TextBox { Text = _selectedScreen.ColumnCount.ToString(), Width = 35, Height = 22, TextAlignment = TextAlignment.Center, Background = new SolidColorBrush(Color.FromRgb(0x28, 0x28, 0x2C)), Foreground = Brushes.White, BorderThickness = new Thickness(0) };
                colBox.TextChanged += (_, _) => { if (int.TryParse(colBox.Text, out int c)) { _selectedScreen.ColumnCount = Math.Max(1, c); _previewCanvas.SetScreen(_selectedScreen); } };
                _arrangementOptionsPanel.Children.Add(colBox);
            }
            else if (_selectedScreen.ArrangementType == ScreenArrangementType.EdgeBlend)
            {
                _arrangementOptionsPanel.Children.Add(new TextBlock { Text = "Blend Width (px):", Foreground = Brushes.White, FontSize = 12, VerticalAlignment = VerticalAlignment.Center, Margin = new Thickness(0, 0, 6, 0) });
                var blendBox = new TextBox { Text = _selectedScreen.EdgeBlendWidth.ToString("F0"), Width = 50, Height = 22, TextAlignment = TextAlignment.Center, Background = new SolidColorBrush(Color.FromRgb(0x28, 0x28, 0x2C)), Foreground = Brushes.White, BorderThickness = new Thickness(0) };
                blendBox.TextChanged += (_, _) => { if (double.TryParse(blendBox.Text, out double b)) { _selectedScreen.EdgeBlendWidth = b; _previewCanvas.SetScreen(_selectedScreen); } };
                _arrangementOptionsPanel.Children.Add(blendBox);
            }
        }

        private void RefreshScreenLists()
        {
            _audienceListStack.Children.Clear();
            foreach (var screen in _store.AudienceScreens)
            {
                _audienceListStack.Children.Add(CreateScreenListItem(screen));
            }

            _stageListStack.Children.Clear();
            foreach (var screen in _store.StageScreens)
            {
                _stageListStack.Children.Add(CreateScreenListItem(screen));
            }
        }

        private UIElement CreateScreenListItem(ScreenArrangementModel screen)
        {
            bool isSelected = ReferenceEquals(_selectedScreen, screen);
            var border = new Border
            {
                Background = isSelected
                    ? new SolidColorBrush(Color.FromRgb(0x00, 0x65, 0xDF))
                    : Brushes.Transparent,
                Padding = new Thickness(14, 6, 14, 6),
                Cursor = Cursors.Hand
            };

            var stack = new StackPanel();
            stack.Children.Add(new TextBlock
            {
                Text = screen.Name,
                FontSize = 14,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.White
            });
            stack.Children.Add(new TextBlock
            {
                Text = $"{screen.Width} x {screen.Height}",
                FontSize = 11.5,
                FontWeight = FontWeights.SemiBold,
                Foreground = isSelected
                    ? new SolidColorBrush(Color.FromRgb(0xD0, 0xE4, 0xFF))
                    : new SolidColorBrush(Color.FromRgb(0x8E, 0x8E, 0x93)),
                Margin = new Thickness(0, 2, 0, 0)
            });

            border.Child = stack;

            border.MouseLeftButtonDown += (_, _) => SelectScreen(screen);

            // Context Menu: Rename, Duplicate, Delete
            var ctx = new ContextMenu();
            var renameItem = new MenuItem { Header = "Rename" };
            renameItem.Click += (_, _) =>
            {
                SelectScreen(screen);
                _screenNameBox.Focus();
                _screenNameBox.SelectAll();
            };
            ctx.Items.Add(renameItem);

            var dupItem = new MenuItem { Header = "Duplicate" };
            dupItem.Click += (_, _) =>
            {
                var clone = screen.Clone();
                clone.Name += " Copy";
                if (screen.TargetType == ScreenTargetType.Audience)
                    _store.AudienceScreens.Add(clone);
                else
                    _store.StageScreens.Add(clone);
                SelectScreen(clone);
            };
            ctx.Items.Add(dupItem);

            var delItem = new MenuItem { Header = "Delete" };
            delItem.Click += (_, _) =>
            {
                if (screen.TargetType == ScreenTargetType.Audience && _store.AudienceScreens.Count > 1)
                {
                    _store.AudienceScreens.Remove(screen);
                    SelectScreen(_store.AudienceScreens.FirstOrDefault());
                }
                else if (screen.TargetType == ScreenTargetType.Stage && _store.StageScreens.Count > 1)
                {
                    _store.StageScreens.Remove(screen);
                    SelectScreen(_store.StageScreens.FirstOrDefault());
                }
            };
            ctx.Items.Add(delItem);
            border.ContextMenu = ctx;

            return border;
        }

        private void ShowAddScreenMenu(ScreenTargetType targetType)
        {
            var menu = new ContextMenu();
            var singleItem = new MenuItem { Header = "Single Screen" };
            singleItem.Click += (_, _) => AddNewScreen(targetType, ScreenArrangementType.Single, "New Screen");
            menu.Items.Add(singleItem);

            var mirrorItem = new MenuItem { Header = "Mirror Screen" };
            mirrorItem.Click += (_, _) => AddNewScreen(targetType, ScreenArrangementType.Mirror, "Mirrored Screen");
            menu.Items.Add(mirrorItem);

            var groupItem = new MenuItem { Header = "Group (Combined) Screen" };
            groupItem.Click += (_, _) => AddNewScreen(targetType, ScreenArrangementType.Group, "Combined Screen");
            menu.Items.Add(groupItem);

            var blendItem = new MenuItem { Header = "Edge Blend Screen" };
            blendItem.Click += (_, _) => AddNewScreen(targetType, ScreenArrangementType.EdgeBlend, "Edge Blend Screen");
            menu.Items.Add(blendItem);

            menu.IsOpen = true;
        }

        private void AddNewScreen(ScreenTargetType target, ScreenArrangementType arrangement, string defaultName)
        {
            var newScreen = new ScreenArrangementModel
            {
                Name = defaultName,
                TargetType = target,
                ArrangementType = arrangement,
                Width = 1920,
                Height = 1080
            };
            if (target == ScreenTargetType.Audience)
                _store.AudienceScreens.Add(newScreen);
            else
                _store.StageScreens.Add(newScreen);

            SelectScreen(newScreen);
        }

        private void ShowColorPickerMenu()
        {
            var menu = new ContextMenu();
            var colors = new[] { Colors.Black, Colors.White, Colors.Blue, Colors.Red, Colors.DarkSlateGray };
            foreach (var c in colors)
            {
                var colorItem = new MenuItem { Header = c.ToString() };
                colorItem.Click += (_, _) =>
                {
                    if (_selectedScreen != null)
                    {
                        _selectedScreen.BackgroundColor = c;
                        _screenColorSwatch.Background = new SolidColorBrush(c);
                        _previewCanvas.SetScreen(_selectedScreen);
                    }
                };
                menu.Items.Add(colorItem);
            }
            menu.IsOpen = true;
        }

        private List<IdentifyScreensOverlayWindow> _activeOverlays = new();

        private void ToggleIdentifyScreensOverlay(bool active)
        {
            if (active)
            {
                // Close any existing overlays first
                foreach (var win in _activeOverlays)
                    try { win.Close(); } catch { }
                _activeOverlays.Clear();

                int idx = 1;
                foreach (var aud in _store.AudienceScreens)
                {
                    var ov = new IdentifyScreensOverlayWindow(idx++, aud.Name, "Audience Output", $"{aud.Width} x {aud.Height} @ {aud.RefreshRate:F0}Hz");
                    ov.Show();
                    _activeOverlays.Add(ov);
                }
                foreach (var stg in _store.StageScreens)
                {
                    var ov = new IdentifyScreensOverlayWindow(idx++, stg.Name, "Stage Output", $"{stg.Width} x {stg.Height} @ {stg.RefreshRate:F0}Hz");
                    ov.Show();
                    _activeOverlays.Add(ov);
                }
            }
            else
            {
                foreach (var win in _activeOverlays)
                    try { win.Close(); } catch { }
                _activeOverlays.Clear();
            }
        }

        private void OpenTestPatternsDialog()
        {
            var testWin = new TestPatternWindow();
            testWin.Owner = this;
            testWin.ShowDialog();
        }
    }

    /// <summary>
    /// Preview Canvas mimicking ProPresenter.UI.OutputConfiguration.ScreenGridSelector.
    /// Draws 16:9 monitor representation with white border, arrangement sub-screens, or corner pins.
    /// </summary>
    public sealed class ScreenGridPreviewControl : Canvas
    {
        private ScreenArrangementModel? _screen;

        public ScreenGridPreviewControl()
        {
            Background = new SolidColorBrush(Color.FromRgb(0x14, 0x14, 0x16));
            ClipToBounds = true;
        }

        public void SetScreen(ScreenArrangementModel? screen)
        {
            _screen = screen;
            InvalidateVisual();
        }

        protected override void OnRender(DrawingContext dc)
        {
            base.OnRender(dc);

            double w = ActualWidth > 0 ? ActualWidth : 600;
            double h = ActualHeight > 0 ? ActualHeight : 220;

            // Subtle dark background
            dc.DrawRectangle(new SolidColorBrush(Color.FromRgb(0x14, 0x14, 0x16)), null, new Rect(0, 0, w, h));

            if (_screen == null) return;

            // Draw 16:9 box in center
            double boxW = 280;
            double boxH = 158;
            double boxX = (w - boxW) / 2;
            double boxY = (h - boxH) / 2;

            Brush fillBrush = _screen.BackgroundEnabled
                ? new SolidColorBrush(_screen.BackgroundColor)
                : new SolidColorBrush(Color.FromRgb(0x23, 0x23, 0x27));

            Pen borderPen = new Pen(Brushes.White, 1.5);

            if (_screen.ArrangementType == ScreenArrangementType.Single)
            {
                var r = new Rect(boxX, boxY, boxW, boxH);
                dc.DrawRectangle(fillBrush, borderPen, r);

                DrawCenteredText(dc, _screen.Name, 15, FontWeights.Bold, Brushes.White, boxX, boxY, boxW, boxH - 24);
                DrawCenteredText(dc, $"{_screen.Width} x {_screen.Height}", 12, FontWeights.Normal, new SolidColorBrush(Color.FromRgb(0x9E, 0x9E, 0xA2)), boxX, boxY + 20, boxW, boxH);
            }
            else if (_screen.ArrangementType == ScreenArrangementType.Mirror)
            {
                for (int i = _screen.MirrorCount - 1; i >= 0; i--)
                {
                    double off = i * 16;
                    var r = new Rect(boxX - off, boxY - off, boxW, boxH);
                    dc.DrawRectangle(new SolidColorBrush(Color.FromRgb(0x2A, 0x2A, 0x30)), borderPen, r);
                    DrawCenteredText(dc, $"Mirror {i + 1}", 13, FontWeights.Bold, Brushes.White, boxX - off, boxY - off, boxW, boxH);
                }
            }
            else if (_screen.ArrangementType == ScreenArrangementType.Group)
            {
                int rows = Math.Max(1, _screen.RowCount);
                int cols = Math.Max(1, _screen.ColumnCount);
                double cellW = boxW / cols;
                double cellH = boxH / rows;

                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < cols; c++)
                    {
                        var cellRect = new Rect(boxX + c * cellW, boxY + r * cellH, cellW, cellH);
                        dc.DrawRectangle(fillBrush, borderPen, cellRect);
                        DrawCenteredText(dc, $"{r + 1},{c + 1}", 12, FontWeights.Bold, Brushes.White, cellRect.X, cellRect.Y, cellW, cellH);
                    }
                }
            }
            else if (_screen.ArrangementType == ScreenArrangementType.EdgeBlend)
            {
                double halfW = boxW * 0.55;
                var r1 = new Rect(boxX - 20, boxY, halfW, boxH);
                var r2 = new Rect(boxX + boxW - halfW + 20, boxY, halfW, boxH);

                dc.DrawRectangle(fillBrush, borderPen, r1);
                dc.DrawRectangle(fillBrush, borderPen, r2);

                // Blend zone
                double blendX = r2.Left;
                double blendW = r1.Right - r2.Left;
                if (blendW > 0)
                {
                    var blendBrush = new LinearGradientBrush(
                        Color.FromArgb(120, 0, 122, 255),
                        Color.FromArgb(120, 255, 149, 0),
                        0.0);
                    dc.DrawRectangle(blendBrush, null, new Rect(blendX, boxY, blendW, boxH));
                }

                DrawCenteredText(dc, "Blend Zone", 11, FontWeights.Bold, Brushes.White, boxX, boxY + boxH - 24, boxW, 20);
            }

            // Draw Corner Pin handles if enabled
            if (_screen.CornerPinningEnabled)
            {
                var handleBrush = new SolidColorBrush(Color.FromRgb(0x00, 0xEB, 0xFF));
                dc.DrawEllipse(handleBrush, null, new Point(boxX, boxY), 5, 5);
                dc.DrawEllipse(handleBrush, null, new Point(boxX + boxW, boxY), 5, 5);
                dc.DrawEllipse(handleBrush, null, new Point(boxX, boxY + boxH), 5, 5);
                dc.DrawEllipse(handleBrush, null, new Point(boxX + boxW, boxY + boxH), 5, 5);
            }
        }

        private static void DrawCenteredText(DrawingContext dc, string text, double size, FontWeight weight, Brush brush, double x, double y, double w, double h)
        {
            var formatted = new FormattedText(
                text,
                System.Globalization.CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                new Typeface(new FontFamily("Segoe UI"), FontStyles.Normal, weight, FontStretches.Normal),
                size,
                brush,
                1.0);
            dc.DrawText(formatted, new Point(x + (w - formatted.Width) / 2, y + (h - formatted.Height) / 2));
        }
    }

    /// <summary>
    /// Identify Screens overlay window that displays large number badge and hardware info.
    /// </summary>
    public sealed class IdentifyScreensOverlayWindow : Window
    {
        public IdentifyScreensOverlayWindow(int screenNumber, string screenName, string targetType, string resolution)
        {
            Title = $"Identify Screen {screenNumber}";
            WindowStyle = WindowStyle.None;
            AllowsTransparency = true;
            Background = new SolidColorBrush(Color.FromArgb(200, 18, 18, 22));
            Topmost = true;
            ShowInTaskbar = false;
            Width = 600;
            Height = 380;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            var border = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(0x1F, 0x1F, 0x24)),
                BorderBrush = Brushes.White,
                BorderThickness = new Thickness(2),
                CornerRadius = new CornerRadius(12),
                Margin = new Thickness(20),
                Padding = new Thickness(24)
            };

            var stack = new StackPanel
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            // Giant Screen Number (e.g. 1, 2)
            stack.Children.Add(new TextBlock
            {
                Text = screenNumber.ToString(),
                FontSize = 96,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.White,
                HorizontalAlignment = HorizontalAlignment.Center
            });

            // Screen Name
            stack.Children.Add(new TextBlock
            {
                Text = screenName,
                FontSize = 24,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.White,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 4, 0, 4)
            });

            // Target Type + Resolution
            stack.Children.Add(new TextBlock
            {
                Text = $"{targetType} • {resolution}",
                FontSize = 14,
                FontWeight = FontWeights.SemiBold,
                Foreground = new SolidColorBrush(Color.FromRgb(0x00, 0x7A, 0xFF)),
                HorizontalAlignment = HorizontalAlignment.Center
            });

            border.Child = stack;
            Content = border;

            MouseLeftButtonDown += (_, _) => Close();
        }
    }

    /// <summary>
    /// Test Pattern Generator window matching ProPresenter.UI.TestPattern.
    /// </summary>
    public sealed class TestPatternWindow : Window
    {
        private readonly ListBox _patternList;
        private readonly Canvas _patternCanvas;

        public TestPatternWindow()
        {
            Title = "Test Patterns";
            Width = 720;
            Height = 480;
            ResizeMode = ResizeMode.NoResize;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            Background = new SolidColorBrush(Color.FromRgb(0x23, 0x23, 0x26));
            Foreground = Brushes.White;

            var rootGrid = new Grid();
            rootGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(220) });
            rootGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            // Left: Pattern List
            var leftBorder = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(0x1F, 0x1F, 0x22)),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x32, 0x32, 0x36)),
                BorderThickness = new Thickness(0, 0, 1, 0),
                Padding = new Thickness(10)
            };
            var leftStack = new StackPanel();
            leftStack.Children.Add(new TextBlock
            {
                Text = "Test Patterns",
                FontSize = 16,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.White,
                Margin = new Thickness(4, 4, 4, 10)
            });

            _patternList = new ListBox
            {
                Background = Brushes.Transparent,
                BorderThickness = new Thickness(0),
                Foreground = Brushes.White
            };
            _patternList.Items.Add("SMPTE Color Bars");
            _patternList.Items.Add("Alignment Grid");
            _patternList.Items.Add("Concentric Circles");
            _patternList.Items.Add("Grayscale Ramp (0-255)");
            _patternList.Items.Add("Solid White (100% IRE)");
            _patternList.Items.Add("Solid Black (0% IRE)");
            _patternList.Items.Add("Safe Title / Action Margins");
            _patternList.SelectedIndex = 0;
            _patternList.SelectionChanged += (_, _) => DrawSelectedPattern();
            leftStack.Children.Add(_patternList);

            leftBorder.Child = leftStack;
            Grid.SetColumn(leftBorder, 0);
            rootGrid.Children.Add(leftBorder);

            // Right: Preview & Controls
            var rightGrid = new Grid { Margin = new Thickness(14) };
            rightGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            rightGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            _patternCanvas = new Canvas
            {
                Background = Brushes.Black,
                ClipToBounds = true
            };
            var canvasBorder = new Border
            {
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x40, 0x40, 0x44)),
                BorderThickness = new Thickness(1),
                Child = _patternCanvas
            };
            Grid.SetRow(canvasBorder, 0);
            rightGrid.Children.Add(canvasBorder);

            var bottomDock = new DockPanel { Margin = new Thickness(0, 10, 0, 0) };
            var closeBtn = new Button
            {
                Content = "Close",
                Width = 80,
                Height = 26,
                Background = new SolidColorBrush(Color.FromRgb(0x38, 0x38, 0x3C)),
                Foreground = Brushes.White,
                Cursor = Cursors.Hand
            };
            closeBtn.Click += (_, _) => Close();
            DockPanel.SetDock(closeBtn, Dock.Right);
            bottomDock.Children.Add(closeBtn);

            var applyBtn = new Button
            {
                Content = "Display on Audience Screen",
                Height = 26,
                Padding = new Thickness(12, 0, 12, 0),
                Background = new SolidColorBrush(Color.FromRgb(0x00, 0x7A, 0xFF)),
                Foreground = Brushes.White,
                Cursor = Cursors.Hand,
                HorizontalAlignment = HorizontalAlignment.Left
            };
            applyBtn.Click += (_, _) =>
            {
                MessageBox.Show("Test Pattern displayed on active Audience Output.", "Test Pattern", MessageBoxButton.OK, MessageBoxImage.Information);
            };
            bottomDock.Children.Add(applyBtn);

            Grid.SetRow(bottomDock, 1);
            rightGrid.Children.Add(bottomDock);

            Grid.SetColumn(rightGrid, 1);
            rootGrid.Children.Add(rightGrid);

            Content = rootGrid;

            Loaded += (_, _) => DrawSelectedPattern();
            SizeChanged += (_, _) => DrawSelectedPattern();
        }

        private void DrawSelectedPattern()
        {
            _patternCanvas.Children.Clear();
            double w = _patternCanvas.ActualWidth > 0 ? _patternCanvas.ActualWidth : 440;
            double h = _patternCanvas.ActualHeight > 0 ? _patternCanvas.ActualHeight : 380;
            if (w <= 10 || h <= 10) return;

            string selected = _patternList.SelectedItem as string ?? "SMPTE Color Bars";

            if (selected == "SMPTE Color Bars")
            {
                Color[] barColors = {
                    Color.FromRgb(192, 192, 192), // Gray
                    Color.FromRgb(192, 192, 0),   // Yellow
                    Color.FromRgb(0, 192, 192),   // Cyan
                    Color.FromRgb(0, 192, 0),     // Green
                    Color.FromRgb(192, 0, 192),   // Magenta
                    Color.FromRgb(192, 0, 0),     // Red
                    Color.FromRgb(0, 0, 192)      // Blue
                };
                double barW = w / barColors.Length;
                for (int i = 0; i < barColors.Length; i++)
                {
                    var r = new Rectangle
                    {
                        Width = barW + 1,
                        Height = h * 0.75,
                        Fill = new SolidColorBrush(barColors[i])
                    };
                    Canvas.SetLeft(r, i * barW);
                    Canvas.SetTop(r, 0);
                    _patternCanvas.Children.Add(r);
                }
                // Lower black/white blocks
                var lowerBlock = new Rectangle { Width = w, Height = h * 0.25, Fill = Brushes.Black };
                Canvas.SetLeft(lowerBlock, 0);
                Canvas.SetTop(lowerBlock, h * 0.75);
                _patternCanvas.Children.Add(lowerBlock);
            }
            else if (selected == "Alignment Grid")
            {
                int cols = 16;
                int rows = 9;
                double stepX = w / cols;
                double stepY = h / rows;

                for (int c = 0; c <= cols; c++)
                {
                    var line = new Line
                    {
                        X1 = c * stepX, Y1 = 0,
                        X2 = c * stepX, Y2 = h,
                        Stroke = new SolidColorBrush(Color.FromRgb(0x50, 0x50, 0x55)),
                        StrokeThickness = (c == cols / 2) ? 2 : 1
                    };
                    _patternCanvas.Children.Add(line);
                }
                for (int r = 0; r <= rows; r++)
                {
                    var line = new Line
                    {
                        X1 = 0, Y1 = r * stepY,
                        X2 = w, Y2 = r * stepY,
                        Stroke = new SolidColorBrush(Color.FromRgb(0x50, 0x50, 0x55)),
                        StrokeThickness = (r == rows / 2) ? 2 : 1
                    };
                    _patternCanvas.Children.Add(line);
                }
            }
            else if (selected == "Concentric Circles")
            {
                double centerX = w / 2;
                double centerY = h / 2;
                double maxR = Math.Min(w, h) / 2;
                for (int i = 1; i <= 6; i++)
                {
                    double rad = maxR * (i / 6.0);
                    var ell = new Ellipse
                    {
                        Width = rad * 2,
                        Height = rad * 2,
                        Stroke = Brushes.White,
                        StrokeThickness = 1.5
                    };
                    Canvas.SetLeft(ell, centerX - rad);
                    Canvas.SetTop(ell, centerY - rad);
                    _patternCanvas.Children.Add(ell);
                }
            }
            else if (selected == "Grayscale Ramp (0-255)")
            {
                var ramp = new Rectangle
                {
                    Width = w,
                    Height = h,
                    Fill = new LinearGradientBrush(Colors.Black, Colors.White, 0.0)
                };
                _patternCanvas.Children.Add(ramp);
            }
            else if (selected == "Solid White (100% IRE)")
            {
                var white = new Rectangle { Width = w, Height = h, Fill = Brushes.White };
                _patternCanvas.Children.Add(white);
            }
            else if (selected == "Solid Black (0% IRE)")
            {
                var black = new Rectangle { Width = w, Height = h, Fill = Brushes.Black };
                _patternCanvas.Children.Add(black);
            }
            else if (selected == "Safe Title / Action Margins")
            {
                // Action safe (90%)
                var actionSafe = new Rectangle
                {
                    Width = w * 0.9,
                    Height = h * 0.9,
                    Stroke = new SolidColorBrush(Color.FromRgb(0x00, 0x7A, 0xFF)),
                    StrokeThickness = 2
                };
                Canvas.SetLeft(actionSafe, w * 0.05);
                Canvas.SetTop(actionSafe, h * 0.05);
                _patternCanvas.Children.Add(actionSafe);

                // Title safe (80%)
                var titleSafe = new Rectangle
                {
                    Width = w * 0.8,
                    Height = h * 0.8,
                    Stroke = new SolidColorBrush(Color.FromRgb(0x34, 0xC7, 0x59)),
                    StrokeThickness = 2
                };
                Canvas.SetLeft(titleSafe, w * 0.1);
                Canvas.SetTop(titleSafe, h * 0.1);
                _patternCanvas.Children.Add(titleSafe);
            }
        }
    }

    internal static class ObjectCastExtensions
    {
        public static T CastTo<T>(this object obj) where T : class
        {
            return (T)obj;
        }
    }
}
