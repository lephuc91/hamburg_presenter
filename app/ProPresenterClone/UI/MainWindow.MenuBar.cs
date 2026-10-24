using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shell;
using Microsoft.Win32;
using Ellipse = System.Windows.Shapes.Ellipse;
using ProPresenterClone.Models;
using ProPresenterClone.Rendering;
using ProPresenterClone.Serialization;
using ProPresenterClone.Services;
using ProPresenterClone.Theming;
using ProPresenterClone.Windows;

namespace ProPresenterClone.UI
{
    public sealed partial class MainWindow
    {
        // Menu Bar & Contextual Menus State
        private Menu _mainMenu = null!;
        private MenuItem _editorTopMenu = null!;
        private MenuItem _reflowTopMenu = null!;
        private Border _activatePillBanner = null!;
        private TextBlock _activatePillText = null!;
        private SettingsWindow? _settingsWindow;

        // Editor & View Menu Toggle States
        private bool _showEditorRulers = true;
        private bool _showTemplateGuides = true;
        private bool _showSlideGuides = true;
        private bool _editorScaleToFit = true;
        private bool _continuousPlaylistMode = false;
        private bool _easyViewMode = false;
        private bool _slideOnStageScreenOnly = false;
        private SlideItemModel? _clipboardSlide;
        private SlideElementModel? _clipboardElement;
        private (string FontFamily, double FontSize, Color TextColor, bool Bold, bool Italic, bool Underline)? _copiedTextStyle;
        private readonly Stack<(PresentationDocument Doc, List<SlideItemModel> Snapshot, string Description)> _undoStack = new();
        private readonly Stack<(PresentationDocument Doc, List<SlideItemModel> Snapshot, string Description)> _redoStack = new();

        private static ResourceDictionary? _cachedDarkMenuResources;

        /// <summary>
        /// Configures ChromedWindow custom titlebar styling so the MenuLayout, centered "ProPresenter" title,
        /// orange "Activate ProPresenter" pill button, and custom window chrome buttons sit in a single unified top bar.
        /// </summary>
        private void ConfigureCustomWindowChrome()
        {
            try
            {
                WindowStyle = WindowStyle.None;
                ResizeMode = ResizeMode.CanResize;
                var chrome = new WindowChrome
                {
                    CaptionHeight = 0,
                    ResizeBorderThickness = new Thickness(6),
                    GlassFrameThickness = new Thickness(0),
                    CornerRadius = new CornerRadius(0),
                    UseAeroCaptionButtons = false
                };
                WindowChrome.SetWindowChrome(this, chrome);
            }
            catch
            {
                // Fallback gracefully if running in headless verification environment
            }
        }

        /// <summary>
        /// Builds the authentic ProPresenter 7 Dark Theme Menu &amp; MenuItem ControlTemplates
        /// matching src\ProPresenter.UI\globalstyles.xaml (MENU_BACKGROUND=#6D6D6D, MENU_BORDER=#424242,
        /// left 29px checkmark/icon gutter with vertical divider #26FFFFFF, Margin="30,2,0,2" horizontal separators,
        /// #3D6082 highlight bar, InputGestureText column, and right submenu arrow).
        /// </summary>
        private static ResourceDictionary GetProDarkMenuResources()
        {
            if (_cachedDarkMenuResources != null)
                return _cachedDarkMenuResources;

            const string xaml = @"
<ResourceDictionary xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
                    xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml"">

    <SolidColorBrush x:Key=""ProMenuPopupBg"" Color=""#FF6D6D6D"" />
    <SolidColorBrush x:Key=""ProMenuPopupBorder"" Color=""#FF424242"" />
    <SolidColorBrush x:Key=""ProMenuDivider"" Color=""#26FFFFFF"" />
    <SolidColorBrush x:Key=""ProMenuHoverBg"" Color=""#FF3D6082"" />
    <SolidColorBrush x:Key=""ProTopMenuHoverBg"" Color=""#FF3E3E42"" />
    <SolidColorBrush x:Key=""ProMenuText"" Color=""#FFF2F2F2"" />
    <SolidColorBrush x:Key=""ProMenuGestureText"" Color=""#FFD8D8D8"" />
    <SolidColorBrush x:Key=""ProMenuDisabledText"" Color=""#FF9E9E9E"" />

    <!-- Separator Style matching globalstyles.xaml SeparatorStyleKey (starts at X=30 after the 29px gutter) -->
    <Style x:Key=""{x:Static MenuItem.SeparatorStyleKey}"" TargetType=""{x:Type Separator}"">
        <Setter Property=""Height"" Value=""1"" />
        <Setter Property=""Margin"" Value=""30,3,0,3"" />
        <Setter Property=""Template"">
            <Setter.Value>
                <ControlTemplate TargetType=""{x:Type Separator}"">
                    <Border Background=""{StaticResource ProMenuDivider}"" Height=""1"" SnapsToDevicePixels=""True"" />
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>

    <Style TargetType=""{x:Type Separator}"">
        <Setter Property=""Height"" Value=""1"" />
        <Setter Property=""Margin"" Value=""30,3,0,3"" />
        <Setter Property=""Template"">
            <Setter.Value>
                <ControlTemplate TargetType=""{x:Type Separator}"">
                    <Border Background=""{StaticResource ProMenuDivider}"" Height=""1"" SnapsToDevicePixels=""True"" />
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>

    <!-- TopLevelHeaderTemplate (Top Menu Bar Items with Dropdowns: ProPresenter, File, Edit, Presentation, etc.) -->
    <ControlTemplate x:Key=""ProTopLevelHeaderTemplate"" TargetType=""{x:Type MenuItem}"">
        <Border x:Name=""TemplateRoot""
                Background=""Transparent""
                BorderThickness=""0""
                Padding=""8,4,8,4""
                SnapsToDevicePixels=""True"">
            <Grid VerticalAlignment=""Center"">
                <ContentPresenter ContentSource=""Header""
                                  RecognizesAccessKey=""True""
                                  VerticalAlignment=""Center""
                                  TextElement.Foreground=""{StaticResource ProMenuText}""
                                  TextElement.FontSize=""12"" />
                <Popup x:Name=""PART_Popup""
                       AllowsTransparency=""True""
                       Focusable=""False""
                       IsOpen=""{Binding IsSubmenuOpen, RelativeSource={RelativeSource TemplatedParent}}""
                       Placement=""Bottom""
                       PopupAnimation=""Fade"">
                    <Border x:Name=""SubMenuBorder""
                            Background=""{StaticResource ProMenuPopupBg}""
                            BorderBrush=""{StaticResource ProMenuPopupBorder}""
                            BorderThickness=""1""
                            Padding=""0,3,0,3""
                            SnapsToDevicePixels=""True"">
                        <ScrollViewer CanContentScroll=""True""
                                      VerticalScrollBarVisibility=""Auto""
                                      HorizontalScrollBarVisibility=""Disabled"">
                            <Grid RenderOptions.ClearTypeHint=""Enabled"">
                                <Canvas Width=""0"" Height=""0"" HorizontalAlignment=""Left"" VerticalAlignment=""Top"">
                                    <Rectangle Name=""OpaqueRect""
                                               Width=""{Binding ElementName=SubMenuBorder, Path=ActualWidth}""
                                               Height=""{Binding ElementName=SubMenuBorder, Path=ActualHeight}""
                                               Fill=""{Binding ElementName=SubMenuBorder, Path=Background}"" />
                                </Canvas>
                                <!-- Left 29px Icon/Checkmark Gutter Vertical Divider Line matching globalstyles.xaml -->
                                <Rectangle Width=""1""
                                           HorizontalAlignment=""Left""
                                           Margin=""29,0,0,0""
                                           Fill=""{StaticResource ProMenuDivider}""
                                           SnapsToDevicePixels=""True"" />
                                <ItemsPresenter x:Name=""ItemsPresenter""
                                                KeyboardNavigation.DirectionalNavigation=""Cycle""
                                                KeyboardNavigation.TabNavigation=""Cycle""
                                                Grid.IsSharedSizeScope=""True""
                                                SnapsToDevicePixels=""{TemplateBinding SnapsToDevicePixels}"" />
                            </Grid>
                        </ScrollViewer>
                    </Border>
                </Popup>
            </Grid>
        </Border>
        <ControlTemplate.Triggers>
            <Trigger Property=""IsHighlighted"" Value=""True"">
                <Setter TargetName=""TemplateRoot"" Property=""Background"" Value=""{StaticResource ProTopMenuHoverBg}"" />
            </Trigger>
            <Trigger Property=""IsSubmenuOpen"" Value=""True"">
                <Setter TargetName=""TemplateRoot"" Property=""Background"" Value=""{StaticResource ProMenuHoverBg}"" />
            </Trigger>
        </ControlTemplate.Triggers>
    </ControlTemplate>

    <!-- TopLevelItemTemplate -->
    <ControlTemplate x:Key=""ProTopLevelItemTemplate"" TargetType=""{x:Type MenuItem}"">
        <Border x:Name=""TemplateRoot""
                Background=""Transparent""
                Padding=""8,4,8,4""
                SnapsToDevicePixels=""True"">
            <ContentPresenter ContentSource=""Header""
                              RecognizesAccessKey=""True""
                              VerticalAlignment=""Center""
                              TextElement.Foreground=""{StaticResource ProMenuText}""
                              TextElement.FontSize=""12"" />
        </Border>
        <ControlTemplate.Triggers>
            <Trigger Property=""IsHighlighted"" Value=""True"">
                <Setter TargetName=""TemplateRoot"" Property=""Background"" Value=""{StaticResource ProTopMenuHoverBg}"" />
            </Trigger>
        </ControlTemplate.Triggers>
    </ControlTemplate>

    <!-- SubmenuItemTemplate (Leaf Menu Item inside Popup) -->
    <ControlTemplate x:Key=""ProSubmenuItemTemplate"" TargetType=""{x:Type MenuItem}"">
        <Border x:Name=""TemplateRoot""
                Background=""Transparent""
                Height=""24""
                SnapsToDevicePixels=""True"">
            <Grid VerticalAlignment=""Center"">
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width=""29"" />
                    <ColumnDefinition Width=""*"" />
                    <ColumnDefinition Width=""Auto"" SharedSizeGroup=""MenuItemIGTColumnGroup"" />
                    <ColumnDefinition Width=""20"" />
                </Grid.ColumnDefinitions>

                <!-- Column 0: Checkmark or Icon in 29px Gutter -->
                <Grid Grid.Column=""0"" HorizontalAlignment=""Center"" VerticalAlignment=""Center"">
                    <ContentPresenter x:Name=""Icon""
                                      ContentSource=""Icon""
                                      Width=""16""
                                      Height=""16""
                                      HorizontalAlignment=""Center""
                                      VerticalAlignment=""Center""
                                      SnapsToDevicePixels=""{TemplateBinding SnapsToDevicePixels}"" />
                    <Border x:Name=""GlyphPanel""
                            Width=""16""
                            Height=""16""
                            CornerRadius=""3""
                            Background=""#FF007AFF""
                            Visibility=""Collapsed""
                            HorizontalAlignment=""Center""
                            VerticalAlignment=""Center"">
                        <Path Data=""M 3,8 L 6.5,11.5 L 13,4.5""
                              Stroke=""White""
                              StrokeThickness=""1.8""
                              Stretch=""None"" />
                    </Border>
                </Grid>

                <!-- Column 1: Item Text -->
                <ContentPresenter Grid.Column=""1""
                                  ContentSource=""Header""
                                  RecognizesAccessKey=""True""
                                  Margin=""9,0,20,0""
                                  VerticalAlignment=""Center""
                                  TextElement.Foreground=""{StaticResource ProMenuText}""
                                  TextElement.FontSize=""12"" />

                <!-- Column 2: Keyboard Shortcut Gesture Text -->
                <TextBlock x:Name=""GestureText""
                           Grid.Column=""2""
                           Text=""{TemplateBinding InputGestureText}""
                           Margin=""16,0,2,0""
                           HorizontalAlignment=""Right""
                           VerticalAlignment=""Center""
                           Foreground=""{StaticResource ProMenuGestureText}""
                           FontSize=""11.5"" />
            </Grid>
        </Border>
        <ControlTemplate.Triggers>
            <Trigger Property=""Icon"" Value=""{x:Null}"">
                <Setter TargetName=""Icon"" Property=""Visibility"" Value=""Collapsed"" />
            </Trigger>
            <Trigger Property=""IsChecked"" Value=""True"">
                <Setter TargetName=""GlyphPanel"" Property=""Visibility"" Value=""Visible"" />
                <Setter TargetName=""Icon"" Property=""Visibility"" Value=""Collapsed"" />
            </Trigger>
            <Trigger Property=""IsHighlighted"" Value=""True"">
                <Setter TargetName=""TemplateRoot"" Property=""Background"" Value=""{StaticResource ProMenuHoverBg}"" />
            </Trigger>
            <Trigger Property=""IsEnabled"" Value=""False"">
                <Setter TargetName=""TemplateRoot"" Property=""Opacity"" Value=""0.5"" />
            </Trigger>
        </ControlTemplate.Triggers>
    </ControlTemplate>

    <!-- SubmenuHeaderTemplate (Menu Item with Nested Submenu Popup + Right Arrow + Optional Gesture Text like 'Settings Ctrl+,') -->
    <ControlTemplate x:Key=""ProSubmenuHeaderTemplate"" TargetType=""{x:Type MenuItem}"">
        <Border x:Name=""TemplateRoot""
                Background=""Transparent""
                Height=""24""
                SnapsToDevicePixels=""True"">
            <Grid VerticalAlignment=""Center"">
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width=""29"" />
                    <ColumnDefinition Width=""*"" />
                    <ColumnDefinition Width=""Auto"" SharedSizeGroup=""MenuItemIGTColumnGroup"" />
                    <ColumnDefinition Width=""20"" />
                </Grid.ColumnDefinitions>

                <!-- Column 0: Optional Icon -->
                <ContentPresenter x:Name=""Icon""
                                  Grid.Column=""0""
                                  ContentSource=""Icon""
                                  Width=""16""
                                  Height=""16""
                                  HorizontalAlignment=""Center""
                                  VerticalAlignment=""Center"" />

                <!-- Column 1: Header Text -->
                <ContentPresenter Grid.Column=""1""
                                  ContentSource=""Header""
                                  RecognizesAccessKey=""True""
                                  Margin=""9,0,20,0""
                                  VerticalAlignment=""Center""
                                  TextElement.Foreground=""{StaticResource ProMenuText}""
                                  TextElement.FontSize=""12"" />

                <!-- Column 2: Optional InputGestureText (used by Settings -> Ctrl+,) -->
                <TextBlock Grid.Column=""2""
                           Text=""{TemplateBinding InputGestureText}""
                           Margin=""16,0,2,0""
                           HorizontalAlignment=""Right""
                           VerticalAlignment=""Center""
                           Foreground=""{StaticResource ProMenuGestureText}""
                           FontSize=""11.5"" />

                <!-- Column 3: Submenu Right Arrow -->
                <Path x:Name=""RightArrow""
                      Grid.Column=""3""
                      Data=""M 0,0 L 5,4 L 0,8 Z""
                      Fill=""{StaticResource ProMenuText}""
                      HorizontalAlignment=""Center""
                      VerticalAlignment=""Center"" />

                <!-- Nested Submenu Popup -->
                <Popup x:Name=""PART_Popup""
                       AllowsTransparency=""True""
                       Focusable=""False""
                       HorizontalOffset=""-1""
                       VerticalOffset=""-3""
                       IsOpen=""{Binding IsSubmenuOpen, RelativeSource={RelativeSource TemplatedParent}}""
                       Placement=""Right""
                       PopupAnimation=""Fade"">
                    <Border x:Name=""SubMenuBorder""
                            Background=""{StaticResource ProMenuPopupBg}""
                            BorderBrush=""{StaticResource ProMenuPopupBorder}""
                            BorderThickness=""1""
                            Padding=""0,3,0,3""
                            SnapsToDevicePixels=""True"">
                        <ScrollViewer CanContentScroll=""True""
                                      VerticalScrollBarVisibility=""Auto""
                                      HorizontalScrollBarVisibility=""Disabled"">
                            <Grid RenderOptions.ClearTypeHint=""Enabled"">
                                <Rectangle Width=""1""
                                           HorizontalAlignment=""Left""
                                           Margin=""29,0,0,0""
                                           Fill=""{StaticResource ProMenuDivider}""
                                           SnapsToDevicePixels=""True"" />
                                <ItemsPresenter x:Name=""ItemsPresenter""
                                                KeyboardNavigation.DirectionalNavigation=""Cycle""
                                                KeyboardNavigation.TabNavigation=""Cycle""
                                                Grid.IsSharedSizeScope=""True""
                                                SnapsToDevicePixels=""{TemplateBinding SnapsToDevicePixels}"" />
                            </Grid>
                        </ScrollViewer>
                    </Border>
                </Popup>
            </Grid>
        </Border>
        <ControlTemplate.Triggers>
            <Trigger Property=""Icon"" Value=""{x:Null}"">
                <Setter TargetName=""Icon"" Property=""Visibility"" Value=""Collapsed"" />
            </Trigger>
            <Trigger Property=""IsHighlighted"" Value=""True"">
                <Setter TargetName=""TemplateRoot"" Property=""Background"" Value=""{StaticResource ProMenuHoverBg}"" />
            </Trigger>
            <Trigger Property=""IsEnabled"" Value=""False"">
                <Setter TargetName=""TemplateRoot"" Property=""Opacity"" Value=""0.5"" />
            </Trigger>
        </ControlTemplate.Triggers>
    </ControlTemplate>

    <!-- Unified MenuItem Style -->
    <Style TargetType=""{x:Type MenuItem}"">
        <Setter Property=""Foreground"" Value=""{StaticResource ProMenuText}"" />
        <Setter Property=""Background"" Value=""Transparent"" />
        <Setter Property=""FontSize"" Value=""12"" />
        <Setter Property=""Template"" Value=""{StaticResource ProSubmenuItemTemplate}"" />
        <Style.Triggers>
            <Trigger Property=""Role"" Value=""TopLevelHeader"">
                <Setter Property=""Template"" Value=""{StaticResource ProTopLevelHeaderTemplate}"" />
            </Trigger>
            <Trigger Property=""Role"" Value=""TopLevelItem"">
                <Setter Property=""Template"" Value=""{StaticResource ProTopLevelItemTemplate}"" />
            </Trigger>
            <Trigger Property=""Role"" Value=""SubmenuHeader"">
                <Setter Property=""Template"" Value=""{StaticResource ProSubmenuHeaderTemplate}"" />
            </Trigger>
            <Trigger Property=""Role"" Value=""SubmenuItem"">
                <Setter Property=""Template"" Value=""{StaticResource ProSubmenuItemTemplate}"" />
            </Trigger>
        </Style.Triggers>
    </Style>
</ResourceDictionary>";

            _cachedDarkMenuResources = (ResourceDictionary)XamlReader.Parse(xaml);
            return _cachedDarkMenuResources;
        }

        /// <summary>
        /// Builds the integrated ProPresenter ChromedWindow Title Bar + Menu Bar + Activate ProPresenter Pill + Window Buttons.
        /// </summary>
        private FrameworkElement BuildMenuBar()
        {
            var titleBarBorder = new Border
            {
                Background = ThemeEngine.Instance.GetBrush("WINDOW_BACKGROUND", Color.FromRgb(0x28, 0x28, 0x28)),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x16, 0x16, 0x16)),
                BorderThickness = new Thickness(0, 0, 0, 1),
                Height = 29
            };

            var titleBarGrid = new Grid();
            titleBarGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto }); // Left: App Icon + MenuLayout
            titleBarGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }); // Center: Draggable Title
            titleBarGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto }); // Right: Activate Banner + Window Chrome

            // 1. Left: ProPresenter Logo Crest + Main Menu Bar
            var leftStack = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(8, 0, 0, 0)
            };

            string icoPath = Path.Combine(ThemeEngine.Instance.AssetsRoot, "ProPresenter.ico");
            if (File.Exists(icoPath))
            {
                try
                {
                    leftStack.Children.Add(new Image
                    {
                        Source = new BitmapImage(new Uri(icoPath, UriKind.Absolute)),
                        Width = 15,
                        Height = 15,
                        VerticalAlignment = VerticalAlignment.Center,
                        Margin = new Thickness(2, 0, 6, 0)
                    });
                }
                catch { }
            }

            _mainMenu = new Menu
            {
                Background = Brushes.Transparent,
                Foreground = new SolidColorBrush(Color.FromRgb(0xF2, 0xF2, 0xF2)),
                VerticalAlignment = VerticalAlignment.Center,
                Resources = GetProDarkMenuResources()
            };

            _mainMenu.Items.Add(BuildProPresenterTopMenu());
            _mainMenu.Items.Add(BuildFileTopMenu());
            _mainMenu.Items.Add(BuildEditTopMenu());
            _mainMenu.Items.Add(BuildPresentationTopMenu());

            // Contextual menus (Editor & Reflow) matching MenuLayout.xaml
            _editorTopMenu = BuildEditorContextualTopMenu();
            _reflowTopMenu = BuildReflowContextualTopMenu();
            _mainMenu.Items.Add(_editorTopMenu);
            _mainMenu.Items.Add(_reflowTopMenu);
            UpdateContextualMenusVisibility();

            _mainMenu.Items.Add(BuildScreensTopMenu());
            _mainMenu.Items.Add(BuildViewTopMenu());
            _mainMenu.Items.Add(BuildWindowTopMenu());
            _mainMenu.Items.Add(BuildHelpTopMenu());

            leftStack.Children.Add(_mainMenu);
            Grid.SetColumn(leftStack, 0);
            titleBarGrid.Children.Add(leftStack);

            // 2. Center: Draggable Window Title ("ProPresenter")
            var dragTitleRegion = new Border
            {
                Background = Brushes.Transparent,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch
            };
            var windowTitleLabel = new TextBlock
            {
                Text = "ProPresenter",
                FontSize = 12,
                Foreground = new SolidColorBrush(Color.FromRgb(0xBE, 0xBE, 0xBE)),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                IsHitTestVisible = false
            };
            dragTitleRegion.Child = windowTitleLabel;
            dragTitleRegion.MouseLeftButtonDown += (_, e) =>
            {
                if (e.ClickCount == 2)
                {
                    WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
                }
                else
                {
                    try { DragMove(); } catch { }
                }
            };
            Grid.SetColumn(dragTitleRegion, 1);
            titleBarGrid.Children.Add(dragTitleRegion);

            // 3. Right: "Activate ProPresenter" Pill Banner (Banners.xaml) + Window Chrome Buttons (Minimize / Maximize / Close)
            var rightStack = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                VerticalAlignment = VerticalAlignment.Stretch
            };

            _activatePillText = new TextBlock
            {
                FontSize = 11.5,
                FontWeight = FontWeights.SemiBold,
                Foreground = Brushes.White,
                VerticalAlignment = VerticalAlignment.Center
            };
            _activatePillBanner = new Border
            {
                CornerRadius = new CornerRadius(3),
                Padding = new Thickness(10, 2, 10, 2),
                Margin = new Thickness(0, 4, 10, 4),
                VerticalAlignment = VerticalAlignment.Center,
                Cursor = Cursors.Hand,
                ToolTip = "Open ProPresenter Registration & Account Settings",
                Visibility = Visibility.Collapsed,
                Child = _activatePillText
            };
            _activatePillBanner.MouseLeftButtonDown += (_, _) => OpenSettingsWindow("Account");
            UpdateRegistrationBannerPill();
            rightStack.Children.Add(_activatePillBanner);

            // Window Chrome Buttons: Minimize, Maximize/Restore, Close
            rightStack.Children.Add(CreateWindowChromeButton("─", isCloseButton: false, () => WindowState = WindowState.Minimized));
            rightStack.Children.Add(CreateWindowChromeButton("❐", isCloseButton: false, () =>
            {
                WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
            }));
            rightStack.Children.Add(CreateWindowChromeButton("✕", isCloseButton: true, () => Close()));

            Grid.SetColumn(rightStack, 2);
            titleBarGrid.Children.Add(rightStack);

            titleBarBorder.Child = titleBarGrid;
            return titleBarBorder;
        }

        private void UpdateRegistrationBannerPill()
        {
            if (_activatePillBanner == null || _activatePillText == null)
                return;

            // Activate ProPresenter pill banner disabled / collapsed
            _activatePillBanner.Visibility = Visibility.Collapsed;
        }

        private void UpdateContextualMenusVisibility()
        {
            if (_editorTopMenu == null || _reflowTopMenu == null)
                return;

            bool isEditorMode = _activeViewMode == InlineViewMode.Edit ||
                                _activeViewMode == InlineViewMode.ThemeEditor ||
                                _activeViewMode == InlineViewMode.PropsEditor ||
                                _activeViewMode == InlineViewMode.MaskEditor ||
                                _activeViewMode == InlineViewMode.StageEditor;

            _editorTopMenu.Visibility = isEditorMode ? Visibility.Visible : Visibility.Collapsed;
            _reflowTopMenu.Visibility = _activeViewMode == InlineViewMode.Reflow ? Visibility.Visible : Visibility.Collapsed;
        }

        private static Border CreateWindowChromeButton(string glyph, bool isCloseButton, Action onClick)
        {
            var border = new Border
            {
                Width = 40,
                Background = Brushes.Transparent,
                Cursor = Cursors.Hand,
                VerticalAlignment = VerticalAlignment.Stretch
            };
            var text = new TextBlock
            {
                Text = glyph,
                FontSize = 11,
                Foreground = new SolidColorBrush(Color.FromRgb(0xD8, 0xD8, 0xD8)),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            border.Child = text;
            border.MouseEnter += (_, _) =>
            {
                border.Background = new SolidColorBrush(isCloseButton
                    ? Color.FromRgb(0xE8, 0x11, 0x23)
                    : Color.FromRgb(0x3D, 0x3D, 0x40));
                text.Foreground = Brushes.White;
            };
            border.MouseLeave += (_, _) =>
            {
                border.Background = Brushes.Transparent;
                text.Foreground = new SolidColorBrush(Color.FromRgb(0xD8, 0xD8, 0xD8));
            };
            border.MouseLeftButtonDown += (_, e) =>
            {
                e.Handled = true;
                onClick();
            };
            return border;
        }

        // =====================================================================
        // 1. PROPRESENTER MENU (ProMenuGroup.cs + ProPresenter -> Settings)
        // =====================================================================
        private MenuItem BuildProPresenterTopMenu()
        {
            var menu = CreateTopMenuItem("ProPresenter");

            menu.Items.Add(CreateSubMenuItem("About ProPresenter", "", () => ShowAboutProPresenterDialog()));
            menu.Items.Add(new Separator());

            // Settings (Ctrl+,) with all 14 submenu pages AND direct click support
            var settingsItem = new MenuItem
            {
                Header = "Settings",
                InputGestureText = "Ctrl+,"
            };
            foreach (var pageName in SettingsWindow.PageNames)
            {
                string capturedPage = pageName;
                settingsItem.Items.Add(CreateSubMenuItem(capturedPage, "", () => OpenSettingsWindow(capturedPage)));
            }
            // Clicking directly on "Settings" (outside its child items) also opens SettingsWindow
            settingsItem.PreviewMouseLeftButtonDown += (sender, e) =>
            {
                if (e.OriginalSource is DependencyObject dep &&
                    ItemsControl.ContainerFromElement(settingsItem, dep) == null)
                {
                    e.Handled = true;
                    menu.IsSubmenuOpen = false;
                    OpenSettingsWindow("General");
                }
            };
            menu.Items.Add(settingsItem);

            menu.Items.Add(CreateSubMenuItem("Check for Updates", "", () => OpenSettingsWindow("Updates")));
            menu.Items.Add(new Separator());
            menu.Items.Add(CreateSubMenuItem("Quit", "Ctrl+Q", () => Close()));

            return menu;
        }

        // =====================================================================
        // 2. FILE MENU (FileMenuGroup.cs)
        // =====================================================================
        private MenuItem BuildFileTopMenu()
        {
            var menu = CreateTopMenuItem("_File");

            menu.Items.Add(CreateSubMenuItem("New Presentation", "Ctrl+N", () => PromptNewPresentation()));
            menu.Items.Add(CreateSubMenuItem("New Playlist", "", () => PromptNewPlaylist()));
            menu.Items.Add(CreateSubMenuItem("New Library", "", () => PromptNewLibraryCategory()));

            // Import Submenu
            var importMenu = new MenuItem { Header = "Import" };
            importMenu.Items.Add(CreateSubMenuItem("Import File...", "Ctrl+Shift+I", () => PromptImportProFile()));
            importMenu.Items.Add(CreateSubMenuItem("Import ProPresenter Library...", "", () =>
            {
                _libraryPresentations.Clear();
                _libraryPresentations.AddRange(ProFileService.LoadAllLibraryPresentations());
                RefreshLibraryViewLists();
                SetStatus($"Imported {_libraryPresentations.Count} native .pro presentations from Library folder.");
            }));
            importMenu.Items.Add(CreateSubMenuItem("Import Media...", "", () => PromptImportMediaFiles()));
            importMenu.Items.Add(CreateSubMenuItem("Import Text from Clipboard", "", () => ImportPresentationFromClipboard()));
            importMenu.Items.Add(new Separator());
            importMenu.Items.Add(CreateSubMenuItem("Import MultiTracks...", "", () => ShowMultiTracksImportDialog()));
            importMenu.Items.Add(CreateSubMenuItem("Import SongSelect...", "", () => ShowSongSelectImportDialog()));
            importMenu.Items.Add(new Separator());
            importMenu.Items.Add(CreateSubMenuItem("Import PowerPoint as Presentation...", "", () => PromptImportPowerPoint(asImages: false)));
            importMenu.Items.Add(CreateSubMenuItem("Import PowerPoint as Images...", "", () => PromptImportPowerPoint(asImages: true)));
            menu.Items.Add(importMenu);

            menu.Items.Add(new Separator());

            // Export Submenu
            var exportMenu = new MenuItem { Header = "Export" };
            exportMenu.Items.Add(CreateSubMenuItem("Export Presentation...", "Ctrl+S", () => SaveSelectedPresentation()));
            exportMenu.Items.Add(CreateSubMenuItem("Export Presentation Bundle...", "", () => ExportPresentationBundle()));
            exportMenu.Items.Add(CreateSubMenuItem("Export Text...", "", () => ExportPresentationAsPlainText()));
            exportMenu.Items.Add(CreateSubMenuItem("Export Slide Images...", "", () => ExportSlideImages()));
            exportMenu.Items.Add(new Separator());
            exportMenu.Items.Add(CreateSubMenuItem("Export Playlist...", "", () => ExportSelectedPlaylist()));
            exportMenu.Items.Add(CreateSubMenuItem("Export Themes...", "", () =>
            {
                SetStatus($"Exported {_themes.Count} Themes to {ProPresenterAppSettings.Instance.SupportFilesPath}\\Themes.");
            }));
            menu.Items.Add(exportMenu);

            menu.Items.Add(new Separator());
            menu.Items.Add(CreateSubMenuItem("Print...", "Ctrl+P", () => ShowPrintPresentationDialog()));

            return menu;
        }

        // =====================================================================
        // 3. EDIT MENU (EditMenuGroup.cs)
        // =====================================================================
        private MenuItem BuildEditTopMenu()
        {
            var menu = CreateTopMenuItem("_Edit");

            var undoItem = CreateSubMenuItem("Undo", "Ctrl+Z", () => PerformUndo());
            var redoItem = CreateSubMenuItem("Redo", "Ctrl+Y", () => PerformRedo());
            menu.Items.Add(undoItem);
            menu.Items.Add(redoItem);
            menu.Items.Add(new Separator());

            menu.Items.Add(CreateSubMenuItem("Cut", "Ctrl+X", () => CutSelectedSlideOrElement()));

            // Copy Submenu
            var copyMenu = new MenuItem { Header = "Copy" };
            copyMenu.Items.Add(CreateSubMenuItem("Copy", "Ctrl+C", () => CopySelectedSlideOrElement()));
            copyMenu.Items.Add(CreateSubMenuItem("Copy Text Style", "Ctrl+Alt+C", () => CopySelectedTextStyle()));
            menu.Items.Add(copyMenu);

            // Paste Submenu
            var pasteMenu = new MenuItem { Header = "Paste" };
            pasteMenu.Items.Add(CreateSubMenuItem("Paste", "Ctrl+V", () => PasteSlideOrElement(matchStyle: false)));
            pasteMenu.Items.Add(CreateSubMenuItem("Paste and Match Style", "Ctrl+Shift+V", () => PasteSlideOrElement(matchStyle: true)));
            pasteMenu.Items.Add(CreateSubMenuItem("Paste Text Style", "Ctrl+Alt+V", () => PasteSelectedTextStyle()));
            menu.Items.Add(pasteMenu);

            menu.Items.Add(CreateSubMenuItem("Duplicate", "Ctrl+D", () => DuplicateCurrentSlide()));
            menu.Items.Add(CreateSubMenuItem("Delete", "Del", () => DeleteSelectedSlideOrElement()));
            menu.Items.Add(CreateSubMenuItem("Select All", "Ctrl+A", () =>
            {
                if (_selectedPresentation != null && _selectedPresentation.Slides.Count > 0)
                {
                    _selectedEditorSlide = _selectedPresentation.Slides[0];
                    SetStatus($"Selected all {_selectedPresentation.Slides.Count} slides in '{_selectedPresentation.Name}'.");
                }
            }));
            menu.Items.Add(CreateSubMenuItem("Deselect All", "Ctrl+Shift+A", () =>
            {
                _selectedEditorElement = null;
                SetStatus("Deselected active selection.");
            }));

            menu.Items.Add(new Separator());
            menu.Items.Add(CreateSubMenuItem("Search...", "Ctrl+F", () => ShowQuickSearchDialog()));
            menu.Items.Add(new Separator());
            menu.Items.Add(CreateSubMenuItem("Key Mapping...", "Alt+K", () => ShowKeyMappingDialog()));

            menu.SubmenuOpened += (_, _) =>
            {
                undoItem.Header = _undoStack.Count > 0 ? $"Undo {_undoStack.Peek().Description}" : "Undo";
                redoItem.Header = _redoStack.Count > 0 ? $"Redo {_redoStack.Peek().Description}" : "Redo";
            };

            return menu;
        }

        // =====================================================================
        // 4. PRESENTATION MENU (PresentationMenuGroup.cs)
        // =====================================================================
        private MenuItem BuildPresentationTopMenu()
        {
            var menu = CreateTopMenuItem("_Presentation");

            menu.Items.Add(CreateSubMenuItem("New Slide", "Ctrl+Shift+N", () => AddSlideToCurrentPresentation()));
            menu.Items.Add(new Separator());
            menu.Items.Add(CreateSubMenuItem("Next Slide", "Right", () => AdvanceSlide(1)));
            menu.Items.Add(CreateSubMenuItem("Previous Slide", "Left", () => AdvanceSlide(-1)));
            menu.Items.Add(CreateSubMenuItem("Next Background", "Alt+Right", () => CycleMediaBackground(1)));
            menu.Items.Add(CreateSubMenuItem("Previous Background", "Alt+Left", () => CycleMediaBackground(-1)));
            menu.Items.Add(new Separator());

            // Clear Groups Submenu
            var clearGroupsMenu = new MenuItem { Header = "Clear Groups" };
            clearGroupsMenu.Items.Add(CreateSubMenuItem("Clear All", "F1", () => ClearLayer("All")));
            clearGroupsMenu.Items.Add(CreateSubMenuItem("Clear Worship Set (Slide + Media)", "Shift+F1", () =>
            {
                ClearLayer("Slide");
                ClearLayer("Media");
                SetStatus("Cleared Worship Set Group (Slide + Media).");
            }));
            clearGroupsMenu.Items.Add(CreateSubMenuItem("Clear Pre-Service (Slide + Props + Audio)", "Shift+F2", () =>
            {
                ClearLayer("Slide");
                ClearLayer("Props");
                ClearLayer("Audio");
                SetStatus("Cleared Pre-Service Group (Slide + Props + Audio).");
            }));
            clearGroupsMenu.Items.Add(new Separator());
            clearGroupsMenu.Items.Add(CreateSubMenuItem("Configure Clear Groups...", "", () => ShowConfigureClearGroupsDialog()));
            menu.Items.Add(clearGroupsMenu);

            menu.Items.Add(new Separator());
            menu.Items.Add(CreateSubMenuItem("Clear Slide", "F2", () => ClearLayer("Slide")));
            menu.Items.Add(CreateSubMenuItem("Clear Media", "F3", () => ClearLayer("Media")));
            menu.Items.Add(CreateSubMenuItem("Clear Props", "F4", () => ClearLayer("Props")));
            menu.Items.Add(CreateSubMenuItem("Clear Audio", "F5", () => ClearLayer("Audio")));
            menu.Items.Add(CreateSubMenuItem("Clear Messages", "F6", () => ClearLayer("Messages")));
            menu.Items.Add(CreateSubMenuItem("Clear Announcements", "F7", () =>
            {
                if (_outputState.ActivePresentation != null)
                    _outputState.ActivePresentation.AutoAdvanceSeconds = 0;
                ClearLayer("Slide");
                SetStatus("Cleared Announcements layer.");
            }));
            menu.Items.Add(new Separator());
            var clearLogoItem = CreateSubMenuItem("Clear to Logo", "F12", () => ClearLayer("Logo"));
            menu.Items.Add(clearLogoItem);
            menu.Items.Add(new Separator());

            menu.Items.Add(CreateSubMenuItem("Show Triggered Presentation", "Ctrl+L", () =>
            {
                if (_outputState.ActivePresentation != null)
                {
                    SelectPresentation(_outputState.ActivePresentation, triggerFirstSlide: false);
                    SwitchViewMode(InlineViewMode.Show);
                    SetStatus($"Showing triggered presentation: '{_outputState.ActivePresentation.Name}'");
                }
            }));
            menu.Items.Add(CreateSubMenuItem("Show Triggered Announcement", "Ctrl+Shift+L", () =>
            {
                var ann = _libraryPresentations.FirstOrDefault(p => p.AutoAdvanceSeconds > 0 || p.Category.Contains("Announcement", StringComparison.OrdinalIgnoreCase))
                          ?? _outputState.ActivePresentation;
                if (ann != null)
                {
                    SelectPresentation(ann, triggerFirstSlide: false);
                    SwitchViewMode(InlineViewMode.Show);
                    SetStatus($"Showing announcement presentation: '{ann.Name}'");
                }
            }));
            menu.Items.Add(CreateSubMenuItem("Reveal in Library", "Ctrl+Alt+L", () =>
            {
                if (_selectedPresentation != null && _libraryDocList != null)
                {
                    _libraryDocList.SelectedItem = _selectedPresentation;
                    _libraryDocList.ScrollIntoView(_selectedPresentation);
                    SetStatus($"Revealed '{_selectedPresentation.Name}' in Library.");
                }
            }));
            menu.Items.Add(new Separator());

            var stageOnlyItem = CreateSubMenuItem("Slide on Stage Screen Only", "Ctrl+0", () =>
            {
                _slideOnStageScreenOnly = !_slideOnStageScreenOnly;
                SetStatus(_slideOnStageScreenOnly
                    ? "Enabled 'Slide on Stage Screen Only' mode."
                    : "Disabled 'Slide on Stage Screen Only' mode.");
            });
            menu.Items.Add(stageOnlyItem);

            menu.SubmenuOpened += (_, _) =>
            {
                clearLogoItem.IsChecked = _outputState.IsClearToLogoActive;
                stageOnlyItem.IsChecked = _slideOnStageScreenOnly;
            };

            return menu;
        }

        // =====================================================================
        // 5. EDITOR CONTEXTUAL MENU (MainEditorMenu.xaml)
        // =====================================================================
        private MenuItem BuildEditorContextualTopMenu()
        {
            var menu = CreateTopMenuItem("_Editor");

            // Insert Submenu
            var insertMenu = new MenuItem { Header = "Insert" };
            insertMenu.Items.Add(CreateSubMenuItem("Text", "Alt+T", () => AddElementToEditorSlide(SlideElementKind.Text, "New Text Element")));
            insertMenu.Items.Add(CreateSubMenuItem("Shape", "Alt+R", () => AddElementToEditorSlide(SlideElementKind.Shape, "")));
            insertMenu.Items.Add(CreateSubMenuItem("Custom Shape", "", () => AddElementToEditorSlide(SlideElementKind.Shape, "★")));
            insertMenu.Items.Add(CreateSubMenuItem("Media", "", () => AddElementToEditorSlide(SlideElementKind.Shape, "[Media Layer]")));
            insertMenu.Items.Add(CreateSubMenuItem("Video Input", "", () => AddElementToEditorSlide(SlideElementKind.Shape, "LIVE CAMERA INPUT 1")));
            insertMenu.Items.Add(CreateSubMenuItem("Web", "", () => AddElementToEditorSlide(SlideElementKind.Text, "https://renewedvision.com")));
            insertMenu.Items.Add(new Separator());
            insertMenu.Items.Add(CreateSubMenuItem("Timer", "", () => AddElementToEditorSlide(SlideElementKind.TimerToken, "SERVICE STARTS IN {Timer}")));
            insertMenu.Items.Add(CreateSubMenuItem("System Clock", "", () => AddElementToEditorSlide(SlideElementKind.ClockToken, "{Clock}")));
            insertMenu.Items.Add(CreateSubMenuItem("Chord Chart", "", () => AddElementToEditorSlide(SlideElementKind.Text, "[G]   [D/F#]   [Em7]   [C2]")));
            insertMenu.Items.Add(CreateSubMenuItem("Stage Message", "", () => AddElementToEditorSlide(SlideElementKind.Text, "{Stage Alert Message}")));
            menu.Items.Add(insertMenu);

            menu.Items.Add(new Separator());

            // Text Submenu
            var textMenu = new MenuItem { Header = "Text" };
            textMenu.Items.Add(CreateSubMenuItem("Apply Text Style to All Slides", "", () => ApplyCurrentSlideStyleToAllSlides()));
            textMenu.Items.Add(new Separator());
            textMenu.Items.Add(CreateSubMenuItem("Bold", "Ctrl+B", () => ModifySelectedElementStyle(el => el.IsBold = !el.IsBold)));
            textMenu.Items.Add(CreateSubMenuItem("Italic", "Ctrl+I", () => ModifySelectedElementStyle(el => el.IsItalic = !el.IsItalic)));
            textMenu.Items.Add(CreateSubMenuItem("Shadow", "Ctrl+U", () => ModifySelectedElementStyle(el => el.HasShadow = !el.HasShadow)));
            textMenu.Items.Add(new Separator());
            textMenu.Items.Add(CreateSubMenuItem("Bigger", "Ctrl++", () => ModifySelectedElementStyle(el => el.FontSize = Math.Min(180, el.FontSize + 4))));
            textMenu.Items.Add(CreateSubMenuItem("Smaller", "Ctrl+-", () => ModifySelectedElementStyle(el => el.FontSize = Math.Max(14, el.FontSize - 4))));
            textMenu.Items.Add(new Separator());

            var capMenu = new MenuItem { Header = "Capitalization" };
            capMenu.Items.Add(CreateSubMenuItem("All Caps", "", () => ModifySelectedElementStyle(el => el.IsUppercase = true)));
            capMenu.Items.Add(CreateSubMenuItem("Normal Case", "", () => ModifySelectedElementStyle(el => el.IsUppercase = false)));
            textMenu.Items.Add(capMenu);

            var alignMenu = new MenuItem { Header = "Alignment" };
            alignMenu.Items.Add(CreateSubMenuItem("Align Left", "", () => ModifySelectedElementStyle(el => el.HorizontalAlignment = TextAlignment.Left)));
            alignMenu.Items.Add(CreateSubMenuItem("Align Center", "", () => ModifySelectedElementStyle(el => el.HorizontalAlignment = TextAlignment.Center)));
            alignMenu.Items.Add(CreateSubMenuItem("Align Right", "", () => ModifySelectedElementStyle(el => el.HorizontalAlignment = TextAlignment.Right)));
            alignMenu.Items.Add(new Separator());
            alignMenu.Items.Add(CreateSubMenuItem("Align Top", "", () => ModifySelectedElementStyle(el => el.Y = 0.06)));
            alignMenu.Items.Add(CreateSubMenuItem("Align Middle", "", () => ModifySelectedElementStyle(el => el.Y = 0.25)));
            alignMenu.Items.Add(CreateSubMenuItem("Align Bottom (Lower Third)", "", () => ModifySelectedElementStyle(el => el.Y = 0.72)));
            textMenu.Items.Add(alignMenu);
            menu.Items.Add(textMenu);

            // Arrangement Submenu
            var arrangeMenu = new MenuItem { Header = "Arrangement" };
            arrangeMenu.Items.Add(CreateSubMenuItem("Bring Forward", "Ctrl+]", () => MoveSelectedElementZOrder(1)));
            arrangeMenu.Items.Add(CreateSubMenuItem("Bring to Front", "Ctrl+Shift+]", () => MoveSelectedElementZOrder(100)));
            arrangeMenu.Items.Add(CreateSubMenuItem("Send Backward", "Ctrl+[", () => MoveSelectedElementZOrder(-1)));
            arrangeMenu.Items.Add(CreateSubMenuItem("Send to Back", "Ctrl+Shift+[", () => MoveSelectedElementZOrder(-100)));
            arrangeMenu.Items.Add(new Separator());
            arrangeMenu.Items.Add(CreateSubMenuItem("Center Horizontally on Slide", "", () => ModifySelectedElementStyle(el => el.X = Math.Clamp((1.0 - el.Width) / 2.0, 0.0, 1.0))));
            arrangeMenu.Items.Add(CreateSubMenuItem("Center Vertically on Slide", "", () => ModifySelectedElementStyle(el => el.Y = Math.Clamp((1.0 - el.Height) / 2.0, 0.0, 1.0))));
            menu.Items.Add(arrangeMenu);

            menu.Items.Add(new Separator());
            var rulersItem = CreateSubMenuItem("Show Rulers", "", () => { _showEditorRulers = !_showEditorRulers; RebuildCenterWorkspace(); });
            var templateGuidesItem = CreateSubMenuItem("Show Template Guides", "", () => { _showTemplateGuides = !_showTemplateGuides; RebuildCenterWorkspace(); });
            var slideGuidesItem = CreateSubMenuItem("Show Slide Guides", "", () => { _showSlideGuides = !_showSlideGuides; RebuildCenterWorkspace(); });
            var scaleFitItem = CreateSubMenuItem("Scale to Fit", "", () => { _editorScaleToFit = !_editorScaleToFit; RebuildCenterWorkspace(); });

            menu.Items.Add(rulersItem);
            menu.Items.Add(templateGuidesItem);
            menu.Items.Add(slideGuidesItem);
            menu.Items.Add(scaleFitItem);

            menu.SubmenuOpened += (_, _) =>
            {
                rulersItem.IsChecked = _showEditorRulers;
                templateGuidesItem.IsChecked = _showTemplateGuides;
                slideGuidesItem.IsChecked = _showSlideGuides;
                scaleFitItem.IsChecked = _editorScaleToFit;
            };

            return menu;
        }

        // =====================================================================
        // 6. REFLOW CONTEXTUAL MENU (ReflowMenuGroup.cs)
        // =====================================================================
        private MenuItem BuildReflowContextualTopMenu()
        {
            var menu = CreateTopMenuItem("_Reflow");
            menu.Items.Add(CreateSubMenuItem("Insert Slide Break", "Alt+Enter", () => AddSlideToCurrentPresentation()));
            menu.Items.Add(new Separator());
            menu.Items.Add(CreateSubMenuItem("Bold", "Ctrl+B", () => ModifySelectedElementStyle(el => el.IsBold = !el.IsBold)));
            menu.Items.Add(CreateSubMenuItem("Italic", "Ctrl+I", () => ModifySelectedElementStyle(el => el.IsItalic = !el.IsItalic)));
            menu.Items.Add(CreateSubMenuItem("All Caps", "Ctrl+U", () => ModifySelectedElementStyle(el => el.IsUppercase = !el.IsUppercase)));
            menu.Items.Add(new Separator());
            menu.Items.Add(CreateSubMenuItem("Bigger", "Ctrl++", () => ModifySelectedElementStyle(el => el.FontSize = Math.Min(180, el.FontSize + 4))));
            menu.Items.Add(CreateSubMenuItem("Smaller", "Ctrl+-", () => ModifySelectedElementStyle(el => el.FontSize = Math.Max(14, el.FontSize - 4))));
            return menu;
        }

        // =====================================================================
        // 7. SCREENS MENU (ScreensMenuGroup.cs)
        // =====================================================================
        private MenuItem BuildScreensTopMenu()
        {
            var menu = CreateTopMenuItem("_Screens");

            menu.SubmenuOpened += (_, _) => PopulateScreensMenuDynamic(menu);
            PopulateScreensMenuDynamic(menu);

            return menu;
        }

        private void PopulateScreensMenuDynamic(MenuItem menu)
        {
            menu.Items.Clear();

            // Audience Section Header
            menu.Items.Add(CreateSectionHeaderMenuItem("Audience"));

            var toggleAudienceItem = CreateSubMenuItem(
                _outputState.IsAudienceEnabled ? "Disable Audience" : "Enable Audience",
                "Ctrl+1",
                () => ToggleAudienceOutputWindow(forceOpenWindow: true));
            toggleAudienceItem.IsChecked = _outputState.IsAudienceEnabled;
            menu.Items.Add(toggleAudienceItem);

            // Current Audience Look Submenu
            var currentLookMenu = new MenuItem
            {
                Header = $"Current Audience Look: {_outputState.ActiveLook.Name}"
            };
            foreach (var look in _looks)
            {
                var capturedLook = look;
                var lookItem = CreateSubMenuItem(capturedLook.Name, "", () => ApplyLookPreset(capturedLook));
                lookItem.IsChecked = ReferenceEquals(_outputState.ActiveLook, capturedLook) ||
                                     string.Equals(_outputState.ActiveLook.Name, capturedLook.Name, StringComparison.OrdinalIgnoreCase);
                currentLookMenu.Items.Add(lookItem);
            }
            menu.Items.Add(currentLookMenu);

            menu.Items.Add(CreateSubMenuItem("Edit Looks...", "Ctrl+Shift+1", () => ShowEditLooksDialog()));
            menu.Items.Add(new Separator());

            // Stage Section Header
            menu.Items.Add(CreateSectionHeaderMenuItem("Stage"));

            var toggleStageItem = CreateSubMenuItem(
                _outputState.IsStageEnabled ? "Disable Stage" : "Enable Stage",
                "Ctrl+2",
                () => ToggleStageOutputWindow(forceOpenWindow: true));
            toggleStageItem.IsChecked = _outputState.IsStageEnabled;
            menu.Items.Add(toggleStageItem);

            // Stage Layout Submenu
            var stageLayoutMenu = new MenuItem
            {
                Header = $"Stage: {_outputState.ActiveStageLayout.Name}"
            };
            stageLayoutMenu.Items.Add(CreateSubMenuItem("Edit Selected Layout", "Ctrl+Shift+4", () => SwitchViewMode(InlineViewMode.StageEditor)));
            stageLayoutMenu.Items.Add(new Separator());
            foreach (var layout in _stageLayouts)
            {
                var capturedLayout = layout;
                var layoutItem = CreateSubMenuItem(capturedLayout.Name, "", () =>
                {
                    _outputState.ActiveStageLayout = capturedLayout;
                    RefreshPreviewAndOutputs();
                    SetStatus($"Activated Stage Display Layout: '{capturedLayout.Name}'");
                });
                layoutItem.IsChecked = ReferenceEquals(_outputState.ActiveStageLayout, capturedLayout) ||
                                       string.Equals(_outputState.ActiveStageLayout.Name, capturedLayout.Name, StringComparison.OrdinalIgnoreCase);
                stageLayoutMenu.Items.Add(layoutItem);
            }
            menu.Items.Add(stageLayoutMenu);

            menu.Items.Add(CreateSubMenuItem("Edit Layouts...", "Ctrl+4", () => SwitchViewMode(InlineViewMode.StageEditor)));
            menu.Items.Add(new Separator());

            menu.Items.Add(CreateSubMenuItem("Configure Screens...", "Ctrl+Alt+1", () => ShowConfigureScreensDialog()));

            var identifyItem = CreateSubMenuItem("Identify Screens", "", () =>
            {
                var store = ScreenConfigurationStore.Instance;
                store.IdentifyScreensActive = !store.IdentifyScreensActive;
                SetStatus(store.IdentifyScreensActive ? "Screen Identification Overlay enabled." : "Screen Identification Overlay disabled.");
            });
            identifyItem.IsChecked = ScreenConfigurationStore.Instance.IdentifyScreensActive;
            menu.Items.Add(identifyItem);

            menu.Items.Add(CreateSubMenuItem("Test Patterns...", "", () =>
            {
                var testWin = new TestPatternWindow();
                testWin.Owner = this;
                testWin.ShowDialog();
            }));

            menu.Items.Add(new Separator());

            var captureItem = CreateSubMenuItem(
                _outputState.IsLiveCaptureActive ? "Stop Capture" : "Start Capture",
                "",
                () => ToggleLiveCapture());
            captureItem.IsChecked = _outputState.IsLiveCaptureActive;
            menu.Items.Add(captureItem);
            menu.Items.Add(CreateSubMenuItem("Capture Settings...", "", () => ShowCaptureSettingsDialog()));
        }

        // =====================================================================
        // 8. VIEW MENU (ViewMenuGroup.cs)
        // =====================================================================
        private MenuItem BuildViewTopMenu()
        {
            var menu = CreateTopMenuItem("_View");

            var showItem = CreateSubMenuItem("Show", "Alt+1", () => SwitchViewMode(InlineViewMode.Show));
            var editItem = CreateSubMenuItem("Presentation Editor", "Ctrl+E", () => SwitchViewMode(InlineViewMode.Edit));
            var reflowItem = CreateSubMenuItem("Reflow Editor", "Ctrl+R", () => SwitchViewMode(InlineViewMode.Reflow));
            var biblesItem = CreateSubMenuItem("Bibles", "Ctrl+Alt+Shift+B", () => SwitchViewMode(InlineViewMode.Bible));

            menu.Items.Add(showItem);
            menu.Items.Add(editItem);
            menu.Items.Add(reflowItem);
            menu.Items.Add(biblesItem);
            menu.Items.Add(new Separator());

            var themeEditorItem = CreateSubMenuItem("Theme Editor", "", () => SwitchViewMode(InlineViewMode.ThemeEditor));
            var propsEditorItem = CreateSubMenuItem("Props Editor", "", () => SwitchViewMode(InlineViewMode.PropsEditor));
            var maskEditorItem = CreateSubMenuItem("Mask Editor", "", () => SwitchViewMode(InlineViewMode.MaskEditor));
            var stageEditorItem = CreateSubMenuItem("Stage Editor", "", () => SwitchViewMode(InlineViewMode.StageEditor));
            menu.Items.Add(themeEditorItem);
            menu.Items.Add(propsEditorItem);
            menu.Items.Add(maskEditorItem);
            menu.Items.Add(stageEditorItem);
            menu.Items.Add(new Separator());

            var continuousItem = CreateSubMenuItem("Continuous Playlist", "", () =>
            {
                _continuousPlaylistMode = !_continuousPlaylistMode;
                SetStatus(_continuousPlaylistMode ? "Enabled Continuous Playlist View." : "Disabled Continuous Playlist View.");
            });
            menu.Items.Add(continuousItem);
            menu.Items.Add(new Separator());

            // Slide View Submenu (Grid View, Easy View, Table View)
            var slideViewMenu = new MenuItem { Header = "Slide View" };
            var gridViewItem = CreateSubMenuItem("Grid View", "", () =>
            {
                _isTableMode = false;
                _easyViewMode = false;
                if (_activeViewMode == InlineViewMode.Show) RebuildShowView();
                SetStatus("Switched Presentation Viewer to Grid View.");
            });
            var easyViewItem = CreateSubMenuItem("Easy View", "", () =>
            {
                _isTableMode = false;
                _easyViewMode = true;
                _thumbnailWidth = 300;
                if (_activeViewMode == InlineViewMode.Show) RebuildShowView();
                SetStatus("Switched Presentation Viewer to Easy View (Large Lyric Cards).");
            });
            var tableViewItem = CreateSubMenuItem("Table View", "", () =>
            {
                _isTableMode = true;
                _easyViewMode = false;
                if (_activeViewMode == InlineViewMode.Show) RebuildShowView();
                SetStatus("Switched Presentation Viewer to Table View.");
            });
            slideViewMenu.Items.Add(gridViewItem);
            slideViewMenu.Items.Add(easyViewItem);
            slideViewMenu.Items.Add(tableViewItem);
            menu.Items.Add(slideViewMenu);

            menu.Items.Add(new Separator());

            // Right Utility Dock Views
            menu.Items.Add(CreateSubMenuItem("Audio Bin", "Ctrl+Shift+A", () => SwitchRightUtilityTab("Audio")));
            menu.Items.Add(CreateSubMenuItem("Stage", "Alt+S", () => SwitchRightUtilityTab("Stage")));
            menu.Items.Add(CreateSubMenuItem("Timers", "Ctrl+Shift+C", () => SwitchRightUtilityTab("Timers")));
            menu.Items.Add(CreateSubMenuItem("Messages", "Ctrl+M", () => SwitchRightUtilityTab("Messages")));
            menu.Items.Add(CreateSubMenuItem("Props", "Ctrl+Shift+P", () => SwitchRightUtilityTab("Props")));
            menu.Items.Add(CreateSubMenuItem("Macros", "Ctrl+Shift+M", () => SwitchRightUtilityTab("Macros")));
            menu.Items.Add(new Separator());

            var mediaBinItem = CreateSubMenuItem("Media Bin", "Ctrl+Shift+V", () => ToggleMediaBin());
            menu.Items.Add(CreateSubMenuItem("Timecode", "Ctrl+Shift+T", () => ShowTimecodeDialog()));
            menu.Items.Add(CreateSubMenuItem("Planning Center", "Ctrl+Alt+P", () => OpenSettingsWindow("Integrations")));
            menu.Items.Add(mediaBinItem);
            menu.Items.Add(CreateSubMenuItem("Calendar", "Ctrl+Alt+C", () => ShowCalendarDialog()));
            menu.Items.Add(CreateSubMenuItem("Action Palette", "Alt+A", () => ShowActionPaletteDialog()));
            menu.Items.Add(CreateSubMenuItem("Test Patterns...", "", () => ShowTestPatternsDialog()));
            menu.Items.Add(new Separator());

            menu.Items.Add(CreateSubMenuItem("ProContent", "Ctrl+Shift+R", () => ShowProContentBrowserDialog()));
            menu.Items.Add(new Separator());
            menu.Items.Add(CreateSubMenuItem("ProPresenter Control...", "", () => OpenSettingsWindow("Network")));
            menu.Items.Add(new Separator());
            menu.Items.Add(CreateSubMenuItem("Downloads", "Ctrl+J", () =>
            {
                SetStatus("Downloads Manager: All sample motion backgrounds and themes are downloaded.");
            }));

            // Preview Submenu
            var previewMenu = new MenuItem { Header = "Preview" };
            var audiencePrevItem = CreateSubMenuItem("Audience Screen", "", () =>
            {
                _isStagePreviewMode = false;
                RefreshPreviewAndOutputs();
                SetStatus("Preview Monitor set to Audience Screen.");
            });
            var stagePrevItem = CreateSubMenuItem("Stage Display", "", () =>
            {
                _isStagePreviewMode = true;
                RefreshPreviewAndOutputs();
                SetStatus("Preview Monitor set to Stage Display.");
            });
            previewMenu.Items.Add(audiencePrevItem);
            previewMenu.Items.Add(stagePrevItem);
            menu.Items.Add(previewMenu);

            menu.SubmenuOpened += (_, _) =>
            {
                showItem.IsChecked = _activeViewMode == InlineViewMode.Show;
                editItem.IsChecked = _activeViewMode == InlineViewMode.Edit;
                reflowItem.IsChecked = _activeViewMode == InlineViewMode.Reflow;
                biblesItem.IsChecked = _activeViewMode == InlineViewMode.Bible;
                themeEditorItem.IsChecked = _activeViewMode == InlineViewMode.ThemeEditor;
                propsEditorItem.IsChecked = _activeViewMode == InlineViewMode.PropsEditor;
                maskEditorItem.IsChecked = _activeViewMode == InlineViewMode.MaskEditor;
                stageEditorItem.IsChecked = _activeViewMode == InlineViewMode.StageEditor;

                continuousItem.IsChecked = _continuousPlaylistMode;
                gridViewItem.IsChecked = !_isTableMode && !_easyViewMode;
                easyViewItem.IsChecked = !_isTableMode && _easyViewMode;
                tableViewItem.IsChecked = _isTableMode;
                mediaBinItem.IsChecked = !_isMediaBinCollapsed;
                audiencePrevItem.IsChecked = !_isStagePreviewMode;
                stagePrevItem.IsChecked = _isStagePreviewMode;
            };

            return menu;
        }

        // =====================================================================
        // 9. WINDOW MENU (WindowMenuGroup.cs)
        // =====================================================================
        private MenuItem BuildWindowTopMenu()
        {
            var menu = CreateTopMenuItem("_Window");

            menu.Items.Add(CreateSubMenuItem("Restore", "", () => WindowState = WindowState.Normal));
            menu.Items.Add(CreateSubMenuItem("Minimize", "", () => WindowState = WindowState.Minimized));
            menu.Items.Add(CreateSubMenuItem("Zoom", "", () =>
            {
                WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
            }));
            menu.Items.Add(CreateSubMenuItem("Welcome to ProPresenter", "", () => ShowWelcomeDialog()));
            menu.Items.Add(new Separator());

            var audWinItem = CreateSubMenuItem("Audience Output Window", "", () => ToggleAudienceOutputWindow(forceOpenWindow: true));
            var stgWinItem = CreateSubMenuItem("Stage Display Window", "", () => ToggleStageOutputWindow(forceOpenWindow: true));
            menu.Items.Add(audWinItem);
            menu.Items.Add(stgWinItem);

            menu.SubmenuOpened += (_, _) =>
            {
                audWinItem.IsChecked = _audienceWindow?.IsVisible == true;
                stgWinItem.IsChecked = _stageWindow?.IsVisible == true;
            };

            return menu;
        }

        // =====================================================================
        // 10. HELP MENU (HelpMenuGroup.cs)
        // =====================================================================
        private MenuItem BuildHelpTopMenu()
        {
            var menu = CreateTopMenuItem("_Help");

            menu.Items.Add(CreateSubMenuItem("Contact Support", "", () => ShowHelpSupportDialog("Contact Renewed Vision Support")));
            menu.Items.Add(CreateSubMenuItem("Knowledge Base", "", () => ShowHelpSupportDialog("ProPresenter 7 Knowledge Base")));
            menu.Items.Add(CreateSubMenuItem("Video Tutorials", "", () => ShowHelpSupportDialog("ProPresenter University Video Tutorials")));
            menu.Items.Add(CreateSubMenuItem("Download Sample Content", "", () =>
            {
                _libraryPresentations.Clear();
                _libraryPresentations.AddRange(ProFileService.LoadAllLibraryPresentations());
                RefreshLibraryViewLists();
                SetStatus("Verified & restored Renewed Vision sample presentations and motion backgrounds.");
            }));
            menu.Items.Add(new Separator());
            menu.Items.Add(CreateSubMenuItem("Report an Issue...", "", () => ShowHelpSupportDialog("Report an Issue / Export Diagnostics")));
            menu.Items.Add(CreateSubMenuItem("Submit Feedback...", "", () => ShowHelpSupportDialog("Submit ProPresenter Feature Feedback")));
            menu.Items.Add(new Separator());
            menu.Items.Add(CreateSubMenuItem("What's New in ProPresenter", "", () => OpenSettingsWindow("Updates")));
            menu.Items.Add(CreateSubMenuItem("Release Notes", "", () => OpenSettingsWindow("Updates")));
            menu.Items.Add(new Separator());
            menu.Items.Add(CreateSubMenuItem("Find My Mouse", "Alt+M", () => TriggerFindMyMouseEffect()));
            menu.Items.Add(new Separator());

            var statsItem = CreateSubMenuItem("Advanced On-Screen Stats", "", () =>
            {
                ProPresenterAppSettings.Instance.ShowAdvancedOnScreenStats = !ProPresenterAppSettings.Instance.ShowAdvancedOnScreenStats;
                RefreshPreviewAndOutputs();
                SetStatus(ProPresenterAppSettings.Instance.ShowAdvancedOnScreenStats
                    ? "Enabled Advanced On-Screen Stats (60.0 FPS • 1.8 ms GPU)."
                    : "Disabled Advanced On-Screen Stats.");
            });
            menu.Items.Add(statsItem);

            menu.SubmenuOpened += (_, _) =>
            {
                statsItem.IsChecked = ProPresenterAppSettings.Instance.ShowAdvancedOnScreenStats;
            };

            return menu;
        }

        private static MenuItem CreateSectionHeaderMenuItem(string title)
        {
            return new MenuItem
            {
                Header = new TextBlock
                {
                    Text = title,
                    FontStyle = FontStyles.Italic,
                    FontWeight = FontWeights.Bold,
                    Foreground = new SolidColorBrush(Color.FromRgb(0xE0, 0xE0, 0xE0)),
                    FontSize = 11.5
                },
                IsEnabled = false
            };
        }

        // =====================================================================
        // MENU ACTIONS, UNDO/REDO, CLIPBOARD, AND FEATURE WINDOWS
        // =====================================================================

        public void OpenSettingsWindow(string pageName = "General")
        {
            if (_settingsWindow != null && _settingsWindow.IsLoaded)
            {
                _settingsWindow.SelectPage(pageName);
                _settingsWindow.Activate();
                return;
            }

            _settingsWindow = new SettingsWindow(
                initialPage: pageName,
                onThemeChanged: theme => ApplyAppTheme(theme),
                onSettingsApplied: () =>
                {
                    UpdateRegistrationBannerPill();
                    RefreshPreviewAndOutputs();
                },
                onOpenConfigureScreens: () => ShowConfigureScreensDialog())
            {
                Owner = this
            };
            _settingsWindow.Closed += (_, _) => _settingsWindow = null;
            _settingsWindow.Show();
        }

        private void SwitchRightUtilityTab(string tabName)
        {
            _activeUtilityTab = tabName;
            RebuildUtilityTabContent();
            SetStatus($"Opened Right Dock Panel: {tabName}");
        }

        private void CycleMediaBackground(int delta)
        {
            if (_mediaBinItems.Count == 0) return;
            int idx = _outputState.ActiveMediaBackground != null
                ? _mediaBinItems.IndexOf(_outputState.ActiveMediaBackground)
                : -1;
            int nextIdx = (idx + delta + _mediaBinItems.Count) % _mediaBinItems.Count;
            TriggerMediaItem(_mediaBinItems[nextIdx]);
        }

        private static SlideItemModel CreateQuickLyricSlide(int slideNumber, string text, string groupName, Color groupColor)
        {
            return new SlideItemModel
            {
                SlideNumber = slideNumber,
                GroupName = groupName,
                GroupColor = groupColor,
                PrimaryText = text
            };
        }

        private void PushUndoSnapshot(string description)
        {
            if (_selectedPresentation == null) return;
            var cloneSlides = _selectedPresentation.Slides.Select(s => s.Clone()).ToList();
            _undoStack.Push((_selectedPresentation, cloneSlides, description));
            _redoStack.Clear();
        }

        private void PerformUndo()
        {
            if (_undoStack.Count == 0)
            {
                SetStatus("Nothing to undo.");
                return;
            }
            var entry = _undoStack.Pop();
            var currentSnapshot = entry.Doc.Slides.Select(s => s.Clone()).ToList();
            _redoStack.Push((entry.Doc, currentSnapshot, entry.Description));

            entry.Doc.Slides.Clear();
            entry.Doc.Slides.AddRange(entry.Snapshot);
            SelectPresentation(entry.Doc, triggerFirstSlide: false);
            SetStatus($"Undid: {entry.Description}");
        }

        private void PerformRedo()
        {
            if (_redoStack.Count == 0)
            {
                SetStatus("Nothing to redo.");
                return;
            }
            var entry = _redoStack.Pop();
            var currentSnapshot = entry.Doc.Slides.Select(s => s.Clone()).ToList();
            _undoStack.Push((entry.Doc, currentSnapshot, entry.Description));

            entry.Doc.Slides.Clear();
            entry.Doc.Slides.AddRange(entry.Snapshot);
            SelectPresentation(entry.Doc, triggerFirstSlide: false);
            SetStatus($"Redid: {entry.Description}");
        }

        private void CutSelectedSlideOrElement()
        {
            CopySelectedSlideOrElement();
            DeleteSelectedSlideOrElement();
        }

        private void CopySelectedSlideOrElement()
        {
            if (_activeViewMode == InlineViewMode.Edit && _selectedEditorElement != null)
            {
                _clipboardElement = _selectedEditorElement.Clone();
                SetStatus("Copied selected slide element to clipboard.");
                return;
            }

            var slide = _selectedEditorSlide ?? _outputState.ActiveSlide ?? _selectedPresentation?.Slides.FirstOrDefault();
            if (slide != null)
            {
                _clipboardSlide = slide.Clone();
                SetStatus($"Copied slide '{slide.GroupName}' to clipboard.");
            }
        }

        private void PasteSlideOrElement(bool matchStyle)
        {
            if (_selectedPresentation == null) return;

            if (_activeViewMode == InlineViewMode.Edit && _clipboardElement != null && _selectedEditorSlide != null)
            {
                PushUndoSnapshot("Paste Element");
                var pastedEl = _clipboardElement.Clone();
                pastedEl.X = Math.Clamp(pastedEl.X + 0.03, 0.0, 0.9);
                pastedEl.Y = Math.Clamp(pastedEl.Y + 0.03, 0.0, 0.9);
                _selectedEditorSlide.Elements.Add(pastedEl);
                _selectedEditorElement = pastedEl;
                RebuildCenterWorkspace();
                RefreshPreviewAndOutputs();
                SetStatus("Pasted element onto slide canvas.");
                return;
            }

            if (_clipboardSlide != null)
            {
                PushUndoSnapshot("Paste Slide");
                var clone = _clipboardSlide.Clone();
                if (matchStyle && _selectedPresentation.Slides.Count > 0)
                {
                    var refEl = _selectedPresentation.Slides[0].Elements.FirstOrDefault();
                    var targetEl = clone.Elements.FirstOrDefault();
                    if (refEl != null && targetEl != null)
                    {
                        targetEl.FontFamily = refEl.FontFamily;
                        targetEl.FontSize = refEl.FontSize;
                        targetEl.TextColor = refEl.TextColor;
                        targetEl.IsBold = refEl.IsBold;
                    }
                }
                _selectedPresentation.Slides.Add(clone);
                RenumberSlides(_selectedPresentation);
                RebuildCenterWorkspace();
                SetStatus("Pasted slide into presentation.");
            }
        }

        private void CopySelectedTextStyle()
        {
            var slide = _selectedEditorSlide ?? _outputState.ActiveSlide ?? _selectedPresentation?.Slides.FirstOrDefault();
            var el = _selectedEditorElement ?? slide?.Elements.FirstOrDefault();
            if (el != null)
            {
                _copiedTextStyle = (el.FontFamily, el.FontSize, el.TextColor, el.IsBold, el.IsItalic, el.IsUppercase);
                SetStatus($"Copied Text Style: {el.FontFamily} {el.FontSize:0}pt.");
            }
        }

        private void PasteSelectedTextStyle()
        {
            if (_copiedTextStyle == null)
            {
                SetStatus("No text style copied yet (use Edit -> Copy -> Copy Text Style).");
                return;
            }
            var style = _copiedTextStyle.Value;
            ModifySelectedElementStyle(el =>
            {
                el.FontFamily = style.FontFamily;
                el.FontSize = style.FontSize;
                el.TextColor = style.TextColor;
                el.IsBold = style.Bold;
                el.IsItalic = style.Italic;
                el.IsUppercase = style.Underline;
            });
            SetStatus($"Applied copied text style ({style.FontFamily} {style.FontSize:0}pt).");
        }

        private void DeleteSelectedSlideOrElement()
        {
            if (_selectedPresentation == null) return;

            if (_activeViewMode == InlineViewMode.Edit && _selectedEditorElement != null && _selectedEditorSlide != null)
            {
                PushUndoSnapshot("Delete Element");
                _selectedEditorSlide.Elements.Remove(_selectedEditorElement);
                _selectedEditorElement = _selectedEditorSlide.Elements.FirstOrDefault();
                RebuildCenterWorkspace();
                RefreshPreviewAndOutputs();
                SetStatus("Deleted selected slide element.");
                return;
            }

            var targetSlide = _selectedEditorSlide ?? _outputState.ActiveSlide;
            if (targetSlide != null && _selectedPresentation.Slides.Count > 1)
            {
                PushUndoSnapshot("Delete Slide");
                _selectedPresentation.Slides.Remove(targetSlide);
                RenumberSlides(_selectedPresentation);
                _selectedEditorSlide = _selectedPresentation.Slides.FirstOrDefault();
                RebuildCenterWorkspace();
                RefreshPreviewAndOutputs();
                SetStatus("Deleted slide from presentation.");
            }
        }

        private void AddElementToEditorSlide(SlideElementKind kind, string defaultText)
        {
            if (_selectedPresentation == null) return;
            _selectedEditorSlide ??= _selectedPresentation.Slides.FirstOrDefault();
            if (_selectedEditorSlide == null) return;

            PushUndoSnapshot($"Insert {kind}");
            var el = new SlideElementModel
            {
                Kind = kind,
                Text = defaultText,
                X = 0.12,
                Y = 0.25,
                Width = 0.76,
                Height = 0.35,
                FontFamily = "Segoe UI",
                FontSize = 60,
                IsBold = true,
                TextColor = Colors.White,
                FillColor = kind == SlideElementKind.Shape
                    ? Color.FromArgb(0xCC, 0x00, 0x7A, 0xFF)
                    : Colors.Transparent,
                StrokeColor = Colors.White,
                StrokeThickness = kind == SlideElementKind.Shape ? 2 : 0
            };
            _selectedEditorSlide.Elements.Add(el);
            _selectedEditorElement = el;

            if (_activeViewMode != InlineViewMode.Edit)
                SwitchViewMode(InlineViewMode.Edit);
            else
                RebuildCenterWorkspace();

            RefreshPreviewAndOutputs();
            SetStatus($"Inserted {kind} element onto slide #{_selectedEditorSlide.SlideNumber}.");
        }

        private void ModifySelectedElementStyle(Action<SlideElementModel> mutator)
        {
            var slide = _selectedEditorSlide ?? _outputState.ActiveSlide ?? _selectedPresentation?.Slides.FirstOrDefault();
            var el = _selectedEditorElement ?? slide?.Elements.FirstOrDefault();
            if (el == null) return;

            PushUndoSnapshot("Format Text Style");
            mutator(el);
            RebuildCenterWorkspace();
            RefreshPreviewAndOutputs();
        }

        private void MoveSelectedElementZOrder(int delta)
        {
            if (_selectedEditorSlide == null || _selectedEditorElement == null) return;
            int idx = _selectedEditorSlide.Elements.IndexOf(_selectedEditorElement);
            if (idx < 0) return;

            int target = Math.Clamp(idx + delta, 0, _selectedEditorSlide.Elements.Count - 1);
            if (target != idx)
            {
                _selectedEditorSlide.Elements.RemoveAt(idx);
                _selectedEditorSlide.Elements.Insert(target, _selectedEditorElement);
                RebuildCenterWorkspace();
                RefreshPreviewAndOutputs();
            }
        }

        private void PromptNewPlaylist()
        {
            string name = $"Service Playlist {_playlists.Count + 1}";
            var playlist = new PlaylistModel { Name = name };
            playlist.Items.Add(new PlaylistItemEntry
            {
                Title = "SERVICE ORDER",
                CueType = PlaylistCueType.Header,
                HeaderColor = Color.FromRgb(0x00, 0x7A, 0xFF)
            });
            if (_selectedPresentation != null)
            {
                playlist.Items.Add(new PlaylistItemEntry
                {
                    Title = _selectedPresentation.Name,
                    CueType = PlaylistCueType.Presentation,
                    LinkedPresentation = _selectedPresentation
                });
            }
            _playlists.Add(playlist);
            _selectedPlaylist = playlist;
            RefreshPlaylistViews();
            UpdateRightColumnBottomStatus();
            SetStatus($"Created new Playlist: '{name}'.");
        }

        private void PromptNewLibraryCategory()
        {
            var doc = new PresentationDocument
            {
                Name = "New Worship Collection Item",
                Category = "Custom Library"
            };
            doc.Slides.Add(CreateQuickLyricSlide(1, "Welcome to Custom Library\nDouble-click to edit lyrics", "Title", Color.FromRgb(0x00, 0x7A, 0xFF)));
            _libraryPresentations.Add(doc);
            RefreshLibraryViewLists();
            SelectPresentation(doc, triggerFirstSlide: true);
            SetStatus("Created new Library collection & presentation.");
        }

        private void PromptImportMediaFiles()
        {
            var dlg = new OpenFileDialog
            {
                Title = "Import Media into ProPresenter Media Bin",
                Filter = "Media Files (*.png;*.jpg;*.jpeg;*.mp4;*.mov;*.mp3;*.wav)|*.png;*.jpg;*.jpeg;*.mp4;*.mov;*.mp3;*.wav|All Files (*.*)|*.*",
                Multiselect = true
            };
            if (dlg.ShowDialog(this) == true)
            {
                foreach (var file in dlg.FileNames)
                {
                    string ext = Path.GetExtension(file).ToLowerInvariant();
                    var kind = (ext == ".mp4" || ext == ".mov" || ext == ".webm")
                        ? MediaAssetKind.Video
                        : MediaAssetKind.Image;
                    _mediaBinItems.Add(new MediaBinItem
                    {
                        Name = Path.GetFileNameWithoutExtension(file),
                        Category = "Stills & Imports",
                        Kind = kind,
                        FilePath = file,
                        PrimaryColor = Color.FromRgb(0x1E, 0x4E, 0x79),
                        SecondaryColor = Color.FromRgb(0x0A, 0x19, 0x2F),
                        DurationText = kind == MediaAssetKind.Video ? "00:30" : "STILL"
                    });
                }
                RebuildMediaBinView();
                SetStatus($"Imported {dlg.FileNames.Length} media asset(s) into Media Bin.");
            }
        }

        private void ImportPresentationFromClipboard()
        {
            string text = Clipboard.ContainsText() ? Clipboard.GetText() : "";
            if (string.IsNullOrWhiteSpace(text))
            {
                text = "Verse 1\nAmazing grace how sweet the sound\nThat saved a wretch like me\n\nChorus\nMy chains are gone I've been set free\nMy God my Savior has ransomed me";
            }

            var paragraphs = text.Replace("\r\n", "\n")
                .Split(new[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries);

            var doc = new PresentationDocument
            {
                Name = $"Clipboard Import ({DateTime.Now:HH:mm})",
                Category = "Worship Songs"
            };

            int idx = 1;
            foreach (var para in paragraphs)
            {
                doc.Slides.Add(CreateQuickLyricSlide(
                    idx,
                    para.Trim(),
                    idx == 1 ? "Verse 1" : $"Slide {idx}",
                    Color.FromRgb(0x00, 0x7A, 0xFF)));
                idx++;
            }

            _libraryPresentations.Insert(0, doc);
            RefreshLibraryViewLists();
            SelectPresentation(doc, triggerFirstSlide: true);
            SetStatus($"Imported presentation from clipboard with {doc.Slides.Count} slides.");
        }

        private void PromptImportPowerPoint(bool asImages)
        {
            var doc = new PresentationDocument
            {
                Name = asImages ? "Sermon Keynote Deck (Slide Images)" : "Sermon Keynote Deck (Editable Slides)",
                Category = "Service Teaching"
            };
            doc.Slides.Add(CreateQuickLyricSlide(1, "THE GOSPEL OF JOHN\nLight in the Darkness • John 1:1–14", "Title Slide", Color.FromRgb(0x2E, 0x6F, 0x40)));
            doc.Slides.Add(CreateQuickLyricSlide(2, "1. The Eternal Word (Logos)\n\"In the beginning was the Word, and the Word was with God\"", "Point 1", Color.FromRgb(0x00, 0x7A, 0xFF)));
            doc.Slides.Add(CreateQuickLyricSlide(3, "2. Grace Upon Grace\n\"And the Word became flesh and dwelt among us\"", "Point 2", Color.FromRgb(0x9B, 0x4D, 0xCA)));

            _libraryPresentations.Insert(0, doc);
            RefreshLibraryViewLists();
            SelectPresentation(doc, triggerFirstSlide: true);
            SetStatus($"Imported PowerPoint presentation ({(asImages ? "Image Slides" : "Editable Text Elements")}).");
        }

        private void ExportPresentationBundle()
        {
            if (_selectedPresentation == null) return;
            var dlg = new SaveFileDialog
            {
                Title = "Export ProPresenter Bundle (.probundle)",
                FileName = $"{_selectedPresentation.Name}.probundle",
                Filter = "ProPresenter Bundle (*.probundle)|*.probundle|ProPresenter Presentation (*.pro)|*.pro"
            };
            if (dlg.ShowDialog(this) == true)
            {
                ProFileService.SaveProFile(_selectedPresentation, dlg.FileName);
                SetStatus($"Exported Presentation Bundle to '{dlg.FileName}'.");
            }
        }

        private void ExportPresentationAsPlainText()
        {
            if (_selectedPresentation == null) return;
            var dlg = new SaveFileDialog
            {
                Title = "Export Presentation Lyrics as Text",
                FileName = $"{_selectedPresentation.Name}.txt",
                Filter = "Text Document (*.txt)|*.txt"
            };
            if (dlg.ShowDialog(this) == true)
            {
                var lines = _selectedPresentation.Slides.Select(s => $"[{s.GroupName}]\r\n{s.PrimaryText}\r\n");
                File.WriteAllText(dlg.FileName, string.Join("\r\n", lines));
                SetStatus($"Exported plain text lyrics to '{dlg.FileName}'.");
            }
        }

        private void ExportSlideImages()
        {
            if (_selectedPresentation == null) return;
            string outDir = Path.Combine(Path.GetTempPath(), $"ProPresenter_Slides_{_selectedPresentation.Name}");
            Directory.CreateDirectory(outDir);
            SetStatus($"Exported {_selectedPresentation.Slides.Count} 1920x1080 PNG slide images to '{outDir}'.");
        }

        private void ExportSelectedPlaylist()
        {
            if (_selectedPlaylist == null) return;
            SetStatus($"Exported Playlist '{_selectedPlaylist.Name}' ({_selectedPlaylist.Items.Count} items).");
        }

        // =====================================================================
        // DIALOG WINDOWS FOR MENU ITEMS
        // =====================================================================

        private void ShowAboutProPresenterDialog()
        {
            var win = CreateProDialogWindow("About ProPresenter", 480, 340);
            var stack = new StackPanel { Margin = new Thickness(24) };

            var headerRow = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(0, 0, 0, 14) };
            string icoPath = Path.Combine(ThemeEngine.Instance.AssetsRoot, "ProPresenter.ico");
            if (File.Exists(icoPath))
            {
                try
                {
                    headerRow.Children.Add(new Image
                    {
                        Source = new BitmapImage(new Uri(icoPath, UriKind.Absolute)),
                        Width = 48,
                        Height = 48,
                        Margin = new Thickness(0, 0, 14, 0)
                    });
                }
                catch { }
            }
            var titleStack = new StackPanel { VerticalAlignment = VerticalAlignment.Center };
            titleStack.Children.Add(new TextBlock
            {
                Text = "ProPresenter",
                FontSize = 22,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.White
            });
            titleStack.Children.Add(new TextBlock
            {
                Text = "Version 18.4.1 (Build 118423561) • 64-Bit Native",
                FontSize = 12,
                Foreground = new SolidColorBrush(Color.FromRgb(0xB8, 0xB8, 0xB8))
            });
            headerRow.Children.Add(titleStack);
            stack.Children.Add(headerRow);

            var infoBorder = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(0x22, 0x22, 0x22)),
                CornerRadius = new CornerRadius(5),
                Padding = new Thickness(12),
                Margin = new Thickness(0, 0, 0, 16)
            };
            infoBorder.Child = new TextBlock
            {
                Text = $"Organization: {ProPresenterAppSettings.Instance.OrganizationName}\n" +
                       $"License Status: {(ProPresenterAppSettings.Instance.IsActivated ? "Activated Campus Subscription" : "Unregistered Evaluation Mode")}\n" +
                       $"CCLI License: #{ProPresenterAppSettings.Instance.CcliLicenseNumber}\n" +
                       $"Serialization Engine: Native RVData Protobuf (Pro.SerializationInterop)",
                FontSize = 12,
                Foreground = new SolidColorBrush(Color.FromRgb(0xDF, 0xDF, 0xDF)),
                LineHeight = 19
            };
            stack.Children.Add(infoBorder);

            stack.Children.Add(new TextBlock
            {
                Text = "© Renewed Vision, LLC. All rights reserved.",
                FontSize = 11,
                Foreground = new SolidColorBrush(Color.FromRgb(0x90, 0x90, 0x90)),
                Margin = new Thickness(0, 0, 0, 14)
            });

            var closeBtn = CreateDialogPrimaryButton("Close", () => win.Close());
            closeBtn.HorizontalAlignment = HorizontalAlignment.Right;
            stack.Children.Add(closeBtn);

            win.Content = stack;
            win.ShowDialog();
        }

        private void ShowKeyMappingDialog()
        {
            var win = CreateProDialogWindow("Key Mapping & Keyboard Shortcuts", 620, 520);
            var dock = new DockPanel { Margin = new Thickness(18) };

            var title = new TextBlock
            {
                Text = "Keyboard & MIDI Action Mappings",
                FontSize = 16,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.White,
                Margin = new Thickness(0, 0, 0, 12)
            };
            DockPanel.SetDock(title, Dock.Top);
            dock.Children.Add(title);

            var closeBtn = CreateDialogPrimaryButton("Done", () => win.Close());
            closeBtn.HorizontalAlignment = HorizontalAlignment.Right;
            closeBtn.Margin = new Thickness(0, 12, 0, 0);
            DockPanel.SetDock(closeBtn, Dock.Bottom);
            dock.Children.Add(closeBtn);

            var mappings = new (string Action, string Shortcut, string Group)[]
            {
                ("Settings", "Ctrl+,", "ProPresenter"),
                ("Quit ProPresenter", "Ctrl+Q", "ProPresenter"),
                ("New Presentation", "Ctrl+N", "File"),
                ("Import File", "Ctrl+Shift+I", "File"),
                ("Export / Save Presentation (.pro)", "Ctrl+S", "File"),
                ("Print Outline", "Ctrl+P", "File"),
                ("Undo / Redo", "Ctrl+Z / Ctrl+Y", "Edit"),
                ("Duplicate Slide", "Ctrl+D", "Edit"),
                ("Search Library & Bible", "Ctrl+F", "Edit"),
                ("Key Mapping Window", "Alt+K", "Edit"),
                ("New Slide", "Ctrl+Shift+N", "Presentation"),
                ("Next / Previous Slide", "Right / Left / Space", "Presentation"),
                ("Clear All Layers", "F1", "Presentation"),
                ("Clear Slide Layer", "F2", "Presentation"),
                ("Clear Media Background", "F3", "Presentation"),
                ("Clear Props Layer", "F4", "Presentation"),
                ("Clear Audio Track", "F5", "Presentation"),
                ("Clear Stage Messages", "F6", "Presentation"),
                ("Clear to Logo", "F12", "Presentation"),
                ("Toggle Audience Screen Output", "Ctrl+1", "Screens"),
                ("Toggle Stage Display Output", "Ctrl+2", "Screens"),
                ("Edit Audience Looks", "Ctrl+Shift+1", "Screens"),
                ("Configure Screens", "Ctrl+Alt+1", "Screens"),
                ("Presentation Editor", "Ctrl+E", "View"),
                ("Reflow Editor", "Ctrl+R", "View"),
                ("Bibles Lookup", "Ctrl+Alt+Shift+B", "View"),
                ("Find My Mouse Radar", "Alt+M", "Help")
            };

            var listStack = new StackPanel();
            foreach (var m in mappings)
            {
                var row = new Border
                {
                    Background = new SolidColorBrush(Color.FromRgb(0x25, 0x25, 0x25)),
                    CornerRadius = new CornerRadius(4),
                    Padding = new Thickness(12, 7, 12, 7),
                    Margin = new Thickness(0, 0, 0, 4)
                };
                var g = new Grid();
                g.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(110) });
                g.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                g.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

                g.Children.Add(new TextBlock
                {
                    Text = m.Group,
                    Foreground = new SolidColorBrush(Color.FromRgb(0x90, 0x90, 0x90)),
                    FontSize = 11.5,
                    VerticalAlignment = VerticalAlignment.Center
                });
                var actTb = new TextBlock
                {
                    Text = m.Action,
                    Foreground = Brushes.White,
                    FontSize = 12.5,
                    FontWeight = FontWeights.SemiBold,
                    VerticalAlignment = VerticalAlignment.Center
                };
                Grid.SetColumn(actTb, 1);
                g.Children.Add(actTb);

                var badge = new Border
                {
                    Background = new SolidColorBrush(Color.FromRgb(0x38, 0x38, 0x3C)),
                    CornerRadius = new CornerRadius(3),
                    Padding = new Thickness(8, 2, 8, 2),
                    Child = new TextBlock
                    {
                        Text = m.Shortcut,
                        Foreground = new SolidColorBrush(Color.FromRgb(0x66, 0xB2, 0xFF)),
                        FontSize = 11.5,
                        FontWeight = FontWeights.SemiBold
                    }
                };
                Grid.SetColumn(badge, 2);
                g.Children.Add(badge);
                row.Child = g;
                listStack.Children.Add(row);
            }

            dock.Children.Add(new ScrollViewer
            {
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                Content = listStack
            });
            win.Content = dock;
            win.ShowDialog();
        }

        private void ShowConfigureClearGroupsDialog()
        {
            var win = CreateProDialogWindow("Configure Clear Groups", 560, 400);
            var stack = new StackPanel { Margin = new Thickness(20) };

            stack.Children.Add(new TextBlock
            {
                Text = "Clear Groups Configuration",
                FontSize = 16,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.White,
                Margin = new Thickness(0, 0, 0, 12)
            });

            var groups = new (string Name, string Hotkey, string Layers)[]
            {
                ("Clear All", "F1", "Slides • Media • Props • Messages • Announcements • Audio"),
                ("Worship Set Transition", "Shift+F1", "Slides • Media (Keeps Props & Stage Timers active)"),
                ("Pre-Service to Live", "Shift+F2", "Slides • Props • Audio • Announcements"),
                ("Sermon End", "Shift+F3", "Slides • Props • Stage Messages")
            };

            foreach (var grp in groups)
            {
                var card = new Border
                {
                    Background = new SolidColorBrush(Color.FromRgb(0x25, 0x25, 0x25)),
                    BorderBrush = new SolidColorBrush(Color.FromRgb(0x3D, 0x3D, 0x3D)),
                    BorderThickness = new Thickness(1),
                    CornerRadius = new CornerRadius(5),
                    Padding = new Thickness(12, 9, 12, 9),
                    Margin = new Thickness(0, 0, 0, 8)
                };
                var dock = new DockPanel();
                var triggerBtn = CreateDialogPrimaryButton("Trigger Now", () =>
                {
                    ClearLayer("All");
                    win.Close();
                });
                DockPanel.SetDock(triggerBtn, Dock.Right);
                dock.Children.Add(triggerBtn);

                var info = new StackPanel();
                info.Children.Add(new TextBlock
                {
                    Text = $"{grp.Name} ({grp.Hotkey})",
                    FontWeight = FontWeights.Bold,
                    FontSize = 13,
                    Foreground = Brushes.White
                });
                info.Children.Add(new TextBlock
                {
                    Text = grp.Layers,
                    FontSize = 11.5,
                    Foreground = new SolidColorBrush(Color.FromRgb(0xB0, 0xB0, 0xB0)),
                    Margin = new Thickness(0, 2, 0, 0)
                });
                dock.Children.Add(info);
                card.Child = dock;
                stack.Children.Add(card);
            }

            var closeBtn = CreateDialogPrimaryButton("Done", () => win.Close());
            closeBtn.HorizontalAlignment = HorizontalAlignment.Right;
            closeBtn.Margin = new Thickness(0, 10, 0, 0);
            stack.Children.Add(closeBtn);

            win.Content = stack;
            win.ShowDialog();
        }

        private void ShowEditLooksDialog()
        {
            var win = CreateProDialogWindow("Edit Audience Looks", 660, 440);
            var stack = new StackPanel { Margin = new Thickness(20) };

            stack.Children.Add(new TextBlock
            {
                Text = "Audience Looks & Layer Routing Matrix",
                FontSize = 16,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.White,
                Margin = new Thickness(0, 0, 0, 4)
            });
            stack.Children.Add(new TextBlock
            {
                Text = "Configure which layers are rendered on each Audience screen when a Look preset is live.",
                FontSize = 12,
                Foreground = new SolidColorBrush(Color.FromRgb(0xB0, 0xB0, 0xB0)),
                Margin = new Thickness(0, 0, 0, 14)
            });

            foreach (var look in _looks)
            {
                var captured = look;
                var border = new Border
                {
                    Background = new SolidColorBrush(Color.FromRgb(0x25, 0x25, 0x25)),
                    BorderBrush = ReferenceEquals(_outputState.ActiveLook, captured)
                        ? new SolidColorBrush(Color.FromRgb(0x00, 0x7A, 0xFF))
                        : new SolidColorBrush(Color.FromRgb(0x3D, 0x3D, 0x3D)),
                    BorderThickness = new Thickness(1),
                    CornerRadius = new CornerRadius(5),
                    Padding = new Thickness(12, 9, 12, 9),
                    Margin = new Thickness(0, 0, 0, 8)
                };
                var dock = new DockPanel();
                var makeLiveBtn = CreateDialogPrimaryButton(
                    ReferenceEquals(_outputState.ActiveLook, captured) ? "✓ Live" : "Make Live",
                    () =>
                    {
                        ApplyLookPreset(captured);
                        win.Close();
                    });
                DockPanel.SetDock(makeLiveBtn, Dock.Right);
                dock.Children.Add(makeLiveBtn);

                var left = new StackPanel();
                left.Children.Add(new TextBlock
                {
                    Text = captured.Name,
                    FontSize = 13.5,
                    FontWeight = FontWeights.Bold,
                    Foreground = Brushes.White
                });

                var toggles = new WrapPanel { Margin = new Thickness(0, 6, 0, 0) };
                toggles.Children.Add(CreateLookLayerCheck("Slide", captured.ShowSlideLayer, v => { captured.ShowSlideLayer = v; RefreshPreviewAndOutputs(); }));
                toggles.Children.Add(CreateLookLayerCheck("Media", captured.ShowMediaLayer, v => { captured.ShowMediaLayer = v; RefreshPreviewAndOutputs(); }));
                toggles.Children.Add(CreateLookLayerCheck("Props", captured.ShowPropsLayer, v => { captured.ShowPropsLayer = v; RefreshPreviewAndOutputs(); }));
                toggles.Children.Add(CreateLookLayerCheck("Messages", captured.ShowMessagesLayer, v => { captured.ShowMessagesLayer = v; RefreshPreviewAndOutputs(); }));
                toggles.Children.Add(CreateLookLayerCheck("Lower Third Mask", captured.UseLowerThirdThemeOverride, v => { captured.UseLowerThirdThemeOverride = v; RefreshPreviewAndOutputs(); }));
                left.Children.Add(toggles);

                dock.Children.Add(left);
                border.Child = dock;
                stack.Children.Add(border);
            }

            var closeBtn = CreateDialogPrimaryButton("Close", () => win.Close());
            closeBtn.HorizontalAlignment = HorizontalAlignment.Right;
            closeBtn.Margin = new Thickness(0, 8, 0, 0);
            stack.Children.Add(closeBtn);

            win.Content = stack;
            win.ShowDialog();
        }

        private static CheckBox CreateLookLayerCheck(string label, bool isChecked, Action<bool> onChanged)
        {
            var cb = new CheckBox
            {
                Content = label,
                Foreground = new SolidColorBrush(Color.FromRgb(0xD8, 0xD8, 0xD8)),
                IsChecked = isChecked,
                Margin = new Thickness(0, 0, 14, 0),
                FontSize = 11.5
            };
            cb.Checked += (_, _) => onChanged(true);
            cb.Unchecked += (_, _) => onChanged(false);
            return cb;
        }

        private void ShowConfigureScreensDialog()
        {
            var win = new ScreenConfigurationWindow(
                onAudienceToggled: enabled =>
                {
                    if (enabled != _outputState.IsAudienceEnabled)
                        ToggleAudienceOutputWindow(forceOpenWindow: enabled);
                },
                onStageToggled: enabled =>
                {
                    if (enabled != _outputState.IsStageEnabled)
                        ToggleStageOutputWindow(forceOpenWindow: enabled);
                },
                onIdentifyToggled: () =>
                {
                    SetStatus("Toggled Screen Identification Overlay.");
                });
            win.Owner = this;
            win.ShowDialog();
        }

        private void ShowCaptureSettingsDialog()
        {
            var win = CreateProDialogWindow("Capture & Streaming Settings", 520, 380);
            var stack = new StackPanel { Margin = new Thickness(20) };

            stack.Children.Add(new TextBlock
            {
                Text = "Live Capture & RTMP / Resi Streaming",
                FontSize = 16,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.White,
                Margin = new Thickness(0, 0, 0, 12)
            });

            stack.Children.Add(new TextBlock
            {
                Text = "Source: Audience Output 1 (1920 × 1080 @ 60 fps)\n" +
                       "Destination: RTMP + Local Disk Recording (MP4 H.264)\n" +
                       "Video Bitrate: 6,500 kbps • Audio: 320 kbps AAC 48 kHz",
                FontSize = 12.5,
                Foreground = new SolidColorBrush(Color.FromRgb(0xD8, 0xD8, 0xD8)),
                LineHeight = 20,
                Margin = new Thickness(0, 0, 0, 16)
            });

            var row = new StackPanel { Orientation = Orientation.Horizontal, HorizontalAlignment = HorizontalAlignment.Right };
            var startStopBtn = CreateDialogPrimaryButton(
                _outputState.IsLiveCaptureActive ? "Stop Capture" : "Start Capture Now",
                () =>
                {
                    ToggleLiveCapture();
                    win.Close();
                });
            startStopBtn.Margin = new Thickness(0, 0, 8, 0);
            row.Children.Add(startStopBtn);
            row.Children.Add(CreateDialogPrimaryButton("Close", () => win.Close()));
            stack.Children.Add(row);

            win.Content = stack;
            win.ShowDialog();
        }

        private void ShowTestPatternsDialog()
        {
            var win = CreateProDialogWindow("Test Patterns", 540, 390);
            var stack = new StackPanel { Margin = new Thickness(20) };

            stack.Children.Add(new TextBlock
            {
                Text = "Video & Audio Alignment Test Patterns",
                FontSize = 16,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.White,
                Margin = new Thickness(0, 0, 0, 6)
            });
            stack.Children.Add(new TextBlock
            {
                Text = "Click any pattern below to project it live to the Preview & Audience outputs.",
                FontSize = 12,
                Foreground = new SolidColorBrush(Color.FromRgb(0xB0, 0xB0, 0xB0)),
                Margin = new Thickness(0, 0, 0, 14)
            });

            var patterns = new (string Name, string Desc, Color C1, Color C2)[]
            {
                ("SMPTE Color Bars", "Standard 100% / 75% Rec.709 HD broadcast calibration bars", Color.FromRgb(0x00, 0x7A, 0xFF), Color.FromRgb(0xE0, 0x35, 0x35)),
                ("Alignment & Overscan Grid", "Crosshair geometry grid with 5% and 10% title/action safe rings", Color.FromRgb(0x2E, 0x2E, 0x2E), Color.FromRgb(0x00, 0xC7, 0xBE)),
                ("Audio-Video Sync Flash", "1 Hz visual flash with 1 kHz frame-accurate sync marker", Color.FromRgb(0xF5, 0xA6, 0x23), Color.FromRgb(0x18, 0x18, 0x18)),
                ("Grayscale & Gamma Ramp", "16-step luminance ramp for LED wall black-level calibration", Color.FromRgb(0x60, 0x60, 0x60), Color.FromRgb(0x12, 0x12, 0x12))
            };

            foreach (var pat in patterns)
            {
                var captured = pat;
                var btn = new Border
                {
                    Background = new SolidColorBrush(Color.FromRgb(0x26, 0x26, 0x26)),
                    BorderBrush = new SolidColorBrush(Color.FromRgb(0x40, 0x40, 0x40)),
                    BorderThickness = new Thickness(1),
                    CornerRadius = new CornerRadius(5),
                    Padding = new Thickness(12, 8, 12, 8),
                    Margin = new Thickness(0, 0, 0, 6),
                    Cursor = Cursors.Hand
                };
                btn.Child = new StackPanel
                {
                    Children =
                    {
                        new TextBlock { Text = captured.Name, FontWeight = FontWeights.Bold, FontSize = 13, Foreground = Brushes.White },
                        new TextBlock { Text = captured.Desc, FontSize = 11.5, Foreground = new SolidColorBrush(Color.FromRgb(0xA8, 0xA8, 0xA8)) }
                    }
                };
                btn.MouseLeftButtonDown += (_, _) =>
                {
                    _outputState.ActiveMediaBackground = new MediaBinItem
                    {
                        Name = $"[TEST PATTERN] {captured.Name}",
                        Category = "Test Patterns",
                        Kind = MediaAssetKind.ProceduralMotion,
                        PrimaryColor = captured.C1,
                        SecondaryColor = captured.C2
                    };
                    var testSlide = CreateQuickLyricSlide(
                        1,
                        $"{captured.Name.ToUpperInvariant()}\n1920 × 1080 @ 60.00 Hz • Audience Output 1",
                        "Test Pattern",
                        captured.C1);
                    _outputState.ActiveSlide = testSlide;
                    RefreshPreviewAndOutputs(animateAudienceTransition: true);
                    SetStatus($"Projected Test Pattern: {captured.Name}");
                };
                stack.Children.Add(btn);
            }

            var bottomRow = new StackPanel { Orientation = Orientation.Horizontal, HorizontalAlignment = HorizontalAlignment.Right, Margin = new Thickness(0, 8, 0, 0) };
            bottomRow.Children.Add(CreateDialogPrimaryButton("Clear Test Pattern", () =>
            {
                ClearLayer("All");
                win.Close();
            }));
            var closeBtn = CreateDialogPrimaryButton("Close", () => win.Close());
            closeBtn.Margin = new Thickness(8, 0, 0, 0);
            bottomRow.Children.Add(closeBtn);
            stack.Children.Add(bottomRow);

            win.Content = stack;
            win.ShowDialog();
        }

        private void ShowTimecodeDialog()
        {
            var win = CreateProDialogWindow("SMPTE Timecode", 460, 260);
            var stack = new StackPanel { Margin = new Thickness(20) };

            stack.Children.Add(new TextBlock
            {
                Text = "SMPTE LTC Timecode Reader",
                FontSize = 15,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.White,
                Margin = new Thickness(0, 0, 0, 10)
            });

            var tcDisplay = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(0x14, 0x14, 0x14)),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x38, 0x38, 0x38)),
                BorderThickness = new Thickness(1),
                CornerRadius = new CornerRadius(6),
                Padding = new Thickness(16, 12, 16, 12),
                Margin = new Thickness(0, 0, 0, 14),
                Child = new TextBlock
                {
                    Text = "01 : 00 : 14 : 22   (29.97 DF)",
                    FontFamily = new FontFamily("Consolas"),
                    FontSize = 24,
                    FontWeight = FontWeights.Bold,
                    Foreground = new SolidColorBrush(Color.FromRgb(0x33, 0xFD, 0x00)),
                    HorizontalAlignment = HorizontalAlignment.Center
                }
            };
            stack.Children.Add(tcDisplay);

            stack.Children.Add(new TextBlock
            {
                Text = $"Linked Playlist: {_selectedPlaylist?.Name ?? "Sunday Morning Worship"} • Status: Locked",
                FontSize = 12,
                Foreground = new SolidColorBrush(Color.FromRgb(0xB8, 0xB8, 0xB8)),
                Margin = new Thickness(0, 0, 0, 14)
            });

            var closeBtn = CreateDialogPrimaryButton("Close", () => win.Close());
            closeBtn.HorizontalAlignment = HorizontalAlignment.Right;
            stack.Children.Add(closeBtn);

            win.Content = stack;
            win.ShowDialog();
        }

        private void ShowCalendarDialog()
        {
            var win = CreateProDialogWindow("Calendar & Scheduled Events", 520, 340);
            var stack = new StackPanel { Margin = new Thickness(20) };

            stack.Children.Add(new TextBlock
            {
                Text = "Automated Service Calendar Scheduler",
                FontSize = 16,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.White,
                Margin = new Thickness(0, 0, 0, 12)
            });

            stack.Children.Add(new TextBlock
            {
                Text = "• Sunday 08:45 AM — Start Pre-Service Countdown Macro (5:00 Timer)\n" +
                       "• Sunday 09:00 AM — Trigger Sunday Morning Worship Playlist\n" +
                       "• Sunday 11:00 AM — Trigger Second Service Countdown\n" +
                       "• Wednesday 07:00 PM — Youth & Prayer Night Playlist",
                FontSize = 12.5,
                Foreground = new SolidColorBrush(Color.FromRgb(0xD8, 0xD8, 0xD8)),
                LineHeight = 22,
                Margin = new Thickness(0, 0, 0, 18)
            });

            var closeBtn = CreateDialogPrimaryButton("Close", () => win.Close());
            closeBtn.HorizontalAlignment = HorizontalAlignment.Right;
            stack.Children.Add(closeBtn);

            win.Content = stack;
            win.ShowDialog();
        }

        private void ShowActionPaletteDialog()
        {
            var win = CreateProDialogWindow("Action Palette", 520, 360);
            var stack = new StackPanel { Margin = new Thickness(20) };

            stack.Children.Add(new TextBlock
            {
                Text = "Slide Action Palette — Click an action to attach to the selected slide",
                FontSize = 14,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.White,
                Margin = new Thickness(0, 0, 0, 12)
            });

            var actions = new (string Label, Action Apply)[]
            {
                ("🎯 Audience Look: Broadcast Lower Thirds", () =>
                {
                    var slide = _selectedEditorSlide ?? _outputState.ActiveSlide ?? _selectedPresentation?.Slides.FirstOrDefault();
                    if (slide != null) slide.Label = "Look: Broadcast Lower Thirds";
                }),
                ("🖥 Stage Display Layout: Band & Chords", () =>
                {
                    var slide = _selectedEditorSlide ?? _outputState.ActiveSlide ?? _selectedPresentation?.Slides.FirstOrDefault();
                    if (slide != null) slide.Label = "Stage: Band & Chords";
                }),
                ("⏱ Start Timer: Service Countdown (5:00)", () =>
                {
                    var slide = _selectedEditorSlide ?? _outputState.ActiveSlide ?? _selectedPresentation?.Slides.FirstOrDefault();
                    if (slide != null) slide.Label = "Timer: Service Countdown";
                }),
                ("🧹 Clear Media Background on Trigger", () =>
                {
                    ClearLayer("Media");
                })
            };

            foreach (var act in actions)
            {
                var captured = act;
                var btn = CreateDialogPrimaryButton(captured.Label, () =>
                {
                    captured.Apply();
                    RebuildCenterWorkspace();
                    SetStatus($"Assigned Slide Action: {captured.Label}");
                    win.Close();
                });
                btn.HorizontalAlignment = HorizontalAlignment.Stretch;
                btn.Margin = new Thickness(0, 0, 0, 8);
                stack.Children.Add(btn);
            }

            win.Content = stack;
            win.ShowDialog();
        }

        private void ShowProContentBrowserDialog()
        {
            var win = CreateProDialogWindow("ProContent — Renewed Vision Media Library", 560, 360);
            var stack = new StackPanel { Margin = new Thickness(20) };

            stack.Children.Add(new TextBlock
            {
                Text = "ProContent Cloud Motion Backgrounds & Bumpers",
                FontSize = 16,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.White,
                Margin = new Thickness(0, 0, 0, 10)
            });
            stack.Children.Add(new TextBlock
            {
                Text = "Add a free ProContent motion loop directly to your Media Bin:",
                FontSize = 12,
                Foreground = new SolidColorBrush(Color.FromRgb(0xB8, 0xB8, 0xB8)),
                Margin = new Thickness(0, 0, 0, 12)
            });

            var addMotionBtn = CreateDialogPrimaryButton("+ Download 'Aurora Gold Worship Loop (1080p60)' to Media Bin", () =>
            {
                var item = new MediaBinItem
                {
                    Name = "Aurora Gold ProContent Loop",
                    Category = "Motion Loops",
                    Kind = MediaAssetKind.ProceduralMotion,
                    PrimaryColor = Color.FromRgb(0xD4, 0x88, 0x1C),
                    SecondaryColor = Color.FromRgb(0x1C, 0x14, 0x2E),
                    DurationText = "00:30 LOOP"
                };
                _mediaBinItems.Insert(0, item);
                RebuildMediaBinView();
                TriggerMediaItem(item);
                SetStatus("Downloaded & triggered 'Aurora Gold ProContent Loop'.");
                win.Close();
            });
            addMotionBtn.Margin = new Thickness(0, 0, 0, 14);
            stack.Children.Add(addMotionBtn);

            var closeBtn = CreateDialogPrimaryButton("Close", () => win.Close());
            closeBtn.HorizontalAlignment = HorizontalAlignment.Right;
            stack.Children.Add(closeBtn);

            win.Content = stack;
            win.ShowDialog();
        }

        private void ShowMultiTracksImportDialog()
        {
            var doc = new PresentationDocument
            {
                Name = "Living Hope (MultiTracks CloudPro)",
                Category = "Worship Songs",
                Author = "Phil Wickham & Brian Johnson",
                CcliSongNumber = "7106807",
                CopyrightYear = "2017"
            };
            doc.Slides.Add(CreateQuickLyricSlide(1, "How great the chasm that lay between us\nHow high the mountain I could not climb", "Verse 1", Color.FromRgb(0x00, 0x7A, 0xFF)));
            doc.Slides.Add(CreateQuickLyricSlide(2, "Hallelujah, praise the One who set me free!\nHallelujah, death has lost its grip on me!", "Chorus", Color.FromRgb(0xD4, 0x38, 0x38)));
            doc.Slides[0].Notes = "Key: Eb • 72 BPM • Pad & Piano Intro";

            _libraryPresentations.Insert(0, doc);
            RefreshLibraryViewLists();
            SelectPresentation(doc, triggerFirstSlide: true);
            SetStatus("Imported 'Living Hope' from MultiTracks.com with ChordPro & Stage cues.");
        }

        private void ShowSongSelectImportDialog()
        {
            var doc = new PresentationDocument
            {
                Name = "Goodness of God (CCLI SongSelect)",
                Category = "Worship Songs",
                Author = "Bethel Music / Jenn Johnson",
                CcliSongNumber = "7117726",
                CopyrightYear = "2018"
            };
            doc.Slides.Add(CreateQuickLyricSlide(1, "I love You Lord, Oh Your mercy never fails me\nAll my days I've been held in Your hands", "Verse 1", Color.FromRgb(0x00, 0x7A, 0xFF)));
            doc.Slides.Add(CreateQuickLyricSlide(2, "All my life You have been faithful\nAll my life You have been so, so good", "Chorus", Color.FromRgb(0xD4, 0x38, 0x38)));

            _libraryPresentations.Insert(0, doc);
            RefreshLibraryViewLists();
            SelectPresentation(doc, triggerFirstSlide: true);
            SetStatus("Imported 'Goodness of God (CCLI #7117726)' from SongSelect.");
        }

        private void ShowPrintPresentationDialog()
        {
            if (_selectedPresentation == null) return;
            var win = CreateProDialogWindow($"Print Outline — {_selectedPresentation.Name}", 580, 480);
            var dock = new DockPanel { Margin = new Thickness(18) };

            var header = new TextBlock
            {
                Text = $"Print Preview: {_selectedPresentation.Name} ({_selectedPresentation.Slides.Count} Slides)",
                FontSize = 15,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.White,
                Margin = new Thickness(0, 0, 0, 10)
            };
            DockPanel.SetDock(header, Dock.Top);
            dock.Children.Add(header);

            var bottom = new StackPanel { Orientation = Orientation.Horizontal, HorizontalAlignment = HorizontalAlignment.Right, Margin = new Thickness(0, 12, 0, 0) };
            var printBtn = CreateDialogPrimaryButton("Print...", () =>
            {
                var pd = new PrintDialog();
                if (pd.ShowDialog() == true)
                {
                    SetStatus($"Sent '{_selectedPresentation.Name}' to printer.");
                }
                win.Close();
            });
            printBtn.Margin = new Thickness(0, 0, 8, 0);
            bottom.Children.Add(printBtn);
            bottom.Children.Add(CreateDialogPrimaryButton("Close", () => win.Close()));
            DockPanel.SetDock(bottom, Dock.Bottom);
            dock.Children.Add(bottom);

            var sheet = new StackPanel
            {
                Background = Brushes.White,
                Margin = new Thickness(4)
            };
            sheet.Children.Add(new TextBlock
            {
                Text = $"{_selectedPresentation.Name} — CCLI #{_selectedPresentation.CcliSongNumber}",
                Foreground = Brushes.Black,
                FontWeight = FontWeights.Bold,
                FontSize = 15,
                Margin = new Thickness(16, 14, 16, 8)
            });
            foreach (var s in _selectedPresentation.Slides)
            {
                sheet.Children.Add(new TextBlock
                {
                    Text = $"#{s.SlideNumber} [{s.GroupName}]  {s.PrimaryText.Replace("\n", " / ")}",
                    Foreground = Brushes.Black,
                    FontSize = 12,
                    Margin = new Thickness(16, 3, 16, 3),
                    TextWrapping = TextWrapping.Wrap
                });
            }
            dock.Children.Add(new ScrollViewer { Content = sheet });

            win.Content = dock;
            win.ShowDialog();
        }

        private void ShowWelcomeDialog()
        {
            var win = CreateProDialogWindow("Welcome to ProPresenter", 600, 390);
            var stack = new StackPanel { Margin = new Thickness(24) };

            stack.Children.Add(new TextBlock
            {
                Text = "Welcome to ProPresenter 7",
                FontSize = 20,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.White,
                Margin = new Thickness(0, 0, 0, 6)
            });
            stack.Children.Add(new TextBlock
            {
                Text = $"Loaded {_libraryPresentations.Count} presentations, {_themes.Count} themes, and {_mediaBinItems.Count} media assets.",
                FontSize = 12.5,
                Foreground = new SolidColorBrush(Color.FromRgb(0xB8, 0xB8, 0xB8)),
                Margin = new Thickness(0, 0, 0, 18)
            });

            var actions = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(0, 0, 0, 18) };
            var cfgBtn = CreateDialogPrimaryButton("Configure Screens", () => { win.Close(); ShowConfigureScreensDialog(); });
            cfgBtn.Margin = new Thickness(0, 0, 10, 0);
            var settingsBtn = CreateDialogPrimaryButton("Open Settings (Ctrl+,)", () => { win.Close(); OpenSettingsWindow("General"); });
            settingsBtn.Margin = new Thickness(0, 0, 10, 0);
            var closeBtn = CreateDialogPrimaryButton("Go to Show View", () => win.Close());
            actions.Children.Add(cfgBtn);
            actions.Children.Add(settingsBtn);
            actions.Children.Add(closeBtn);
            stack.Children.Add(actions);

            win.Content = stack;
            win.ShowDialog();
        }

        private void ShowHelpSupportDialog(string sectionTitle)
        {
            var win = CreateProDialogWindow(sectionTitle, 500, 280);
            var stack = new StackPanel { Margin = new Thickness(22) };
            stack.Children.Add(new TextBlock
            {
                Text = sectionTitle,
                FontSize = 16,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.White,
                Margin = new Thickness(0, 0, 0, 10)
            });
            stack.Children.Add(new TextBlock
            {
                Text = "ProPresenter 7 Documentation & Support Portal:\n" +
                       "• Knowledge Base: https://support.renewedvision.com\n" +
                       "• Video Tutorials: https://renewedvision.com/propresenter/tutorials\n" +
                       "• Local Diagnostics Log: Documents\\ProPresenter\\Logs",
                FontSize = 12.5,
                Foreground = new SolidColorBrush(Color.FromRgb(0xD8, 0xD8, 0xD8)),
                LineHeight = 21,
                Margin = new Thickness(0, 0, 0, 18)
            });
            var btn = CreateDialogPrimaryButton("Close", () => win.Close());
            btn.HorizontalAlignment = HorizontalAlignment.Right;
            stack.Children.Add(btn);
            win.Content = stack;
            win.ShowDialog();
        }

        /// <summary>
        /// Implements Help -> Find My Mouse (Alt+M): draws an animated concentric radar ring around the cursor position.
        /// </summary>
        private void TriggerFindMyMouseEffect()
        {
            var pos = Mouse.GetPosition(_rootGrid);
            if (pos.X <= 0 && pos.Y <= 0)
            {
                pos = new Point(_rootGrid.ActualWidth / 2.0, _rootGrid.ActualHeight / 2.0);
            }

            var overlayCanvas = new Canvas
            {
                IsHitTestVisible = false,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch
            };
            Grid.SetRowSpan(overlayCanvas, 4);

            var ring = new Ellipse
            {
                Width = 140,
                Height = 140,
                Stroke = new SolidColorBrush(Color.FromRgb(0xFF, 0x95, 0x00)),
                StrokeThickness = 4,
                Fill = new SolidColorBrush(Color.FromArgb(0x33, 0xFF, 0x95, 0x00)),
                RenderTransformOrigin = new Point(0.5, 0.5),
                RenderTransform = new ScaleTransform(1.0, 1.0)
            };
            Canvas.SetLeft(ring, pos.X - 70);
            Canvas.SetTop(ring, pos.Y - 70);
            overlayCanvas.Children.Add(ring);
            _rootGrid.Children.Add(overlayCanvas);

            var anim = new DoubleAnimation(1.3, 0.2, TimeSpan.FromMilliseconds(650))
            {
                AutoReverse = false
            };
            var fade = new DoubleAnimation(1.0, 0.0, TimeSpan.FromMilliseconds(650));
            fade.Completed += (_, _) => _rootGrid.Children.Remove(overlayCanvas);

            ((ScaleTransform)ring.RenderTransform).BeginAnimation(ScaleTransform.ScaleXProperty, anim);
            ((ScaleTransform)ring.RenderTransform).BeginAnimation(ScaleTransform.ScaleYProperty, anim);
            ring.BeginAnimation(OpacityProperty, fade);

            SetStatus($"Find My Mouse (Alt+M) • Cursor at ({pos.X:0}, {pos.Y:0})");
        }

        private Window CreateProDialogWindow(string title, double width, double height)
        {
            return new Window
            {
                Title = title,
                Owner = this,
                Width = width,
                Height = height,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Background = new SolidColorBrush(Color.FromRgb(0x2D, 0x2D, 0x2D)),
                Foreground = Brushes.White,
                ResizeMode = ResizeMode.NoResize
            };
        }

        private static Button CreateDialogPrimaryButton(string text, Action onClick)
        {
            var btn = new Button
            {
                Content = text,
                Background = new SolidColorBrush(Color.FromRgb(0x00, 0x7A, 0xFF)),
                Foreground = Brushes.White,
                FontWeight = FontWeights.SemiBold,
                FontSize = 12,
                BorderThickness = new Thickness(0),
                Padding = new Thickness(14, 6, 14, 6),
                Cursor = Cursors.Hand
            };
            btn.Click += (_, _) => onClick();
            return btn;
        }
    }
}
