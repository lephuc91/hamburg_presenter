using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using Microsoft.Win32;
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
        private FrameworkElement CreateHeaderIconButton(string iconRelativePath, string tooltip, System.Action onClick, bool isToggled = false)
        {
            var border = new Border
            {
                Width = 28,
                Height = 24,
                CornerRadius = new CornerRadius(3),
                Background = isToggled ? new SolidColorBrush(Color.FromArgb(90, 0x00, 0x7A, 0xFF)) : Brushes.Transparent,
                Cursor = Cursors.Hand,
                ToolTip = tooltip,
                Margin = new Thickness(1, 0, 1, 0)
            };

            string fullPath = Path.Combine(ThemeEngine.Instance.AssetsRoot, "ui-icons", "icons", iconRelativePath.Replace('/', Path.DirectorySeparatorChar));
            if (File.Exists(fullPath))
            {
                var bmp = new System.Windows.Media.Imaging.BitmapImage(new Uri(fullPath, UriKind.Absolute));
                var img = new Image
                {
                    Source = bmp,
                    Width = 16,
                    Height = 16,
                    Stretch = Stretch.Uniform,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center
                };
                RenderOptions.SetBitmapScalingMode(img, BitmapScalingMode.HighQuality);
                border.Child = img;
            }
            else
            {
                border.Child = new TextBlock
                {
                    Text = tooltip.Length > 0 ? tooltip.Substring(0, 1) : "•",
                    Foreground = Brushes.White,
                    FontSize = 11,
                    FontWeight = FontWeights.Bold,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };
            }

            border.MouseEnter += (_, _) =>
            {
                if (!isToggled)
                    border.Background = new SolidColorBrush(Color.FromArgb(50, 255, 255, 255));
            };
            border.MouseLeave += (_, _) =>
            {
                if (!isToggled)
                    border.Background = Brushes.Transparent;
            };
            border.MouseLeftButtonDown += (_, e) =>
            {
                e.Handled = true;
                onClick();
            };

            return border;
        }

        private static FrameworkElement CreateHeaderSeparator()
        {
            return new Border
            {
                Width = 1,
                Height = 16,
                Background = new SolidColorBrush(Color.FromRgb(0x38, 0x38, 0x42)),
                Margin = new Thickness(4, 0, 4, 0),
                VerticalAlignment = VerticalAlignment.Center
            };
        }

        private void RebuildShowView()
        {
            _centerContentHost.Children.Clear();
            var doc = _selectedPresentation;
            if (doc == null)
                return;

            var showGrid = new Grid
            {
                Background = ThemeEngine.Instance.GetBrush("PRESENTATION_BACKGROUND", Color.FromRgb(0x14, 0x14, 0x16))
            };
            showGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto }); // Row 0: Presentation Header Bar (+ optional Arrangement Bar)
            showGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }); // Row 1: Slide Grid / Table
            showGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(36) }); // Row 2: Footer Bar

            // Header Container
            var headerContainer = new StackPanel { Orientation = Orientation.Vertical };

            // 1. Sleek Top Presentation Header Bar (36px high, matching ProPresenter 7)
            var titleBar = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(0x1B, 0x1B, 0x1E)),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x2B, 0x2B, 0x30)),
                BorderThickness = new Thickness(0, 0, 0, 1),
                Height = 36,
                Padding = new Thickness(10, 0, 10, 0)
            };
            var titleDock = new DockPanel();

            // Right toolbar icon strip
            var rightBar = new StackPanel { Orientation = Orientation.Horizontal, VerticalAlignment = VerticalAlignment.Center };

            // Timeline Toggle
            rightBar.Children.Add(CreateHeaderIconButton("header/presentationheadertimeline.png", "Timeline", () =>
            {
                _showTimeline = !_showTimeline;
                SetStatus(_showTimeline ? "Presentation Timeline enabled." : "Presentation Timeline hidden.");
            }, isToggled: _showTimeline));

            rightBar.Children.Add(CreateHeaderSeparator());

            // Presentation Notes Toggle
            rightBar.Children.Add(CreateHeaderIconButton("header/presentationheadernotes.png", "Presentation Notes", () =>
            {
                _showNotes = !_showNotes;
                RebuildShowView();
                SetStatus(_showNotes ? "Opened slide notes view." : "Closed slide notes view.");
            }, isToggled: _showNotes));

            // Arrangements Toggle (shows/hides arrangement pills)
            rightBar.Children.Add(CreateHeaderIconButton("header/presentationheaderarrangement.png", "Arrangements", () =>
            {
                _showArrangements = !_showArrangements;
                RebuildShowView();
                SetStatus(_showArrangements ? "Opened arrangement groups bar." : "Closed arrangement groups bar.");
            }, isToggled: _showArrangements));

            // View Mode Toggle (Grid vs Table)
            rightBar.Children.Add(CreateHeaderIconButton(_isTableMode ? "footer/grid.png" : "footer/table.png", _isTableMode ? "Grid View" : "Table View", () =>
            {
                _isTableMode = !_isTableMode;
                RebuildShowView();
            }));

            rightBar.Children.Add(CreateHeaderSeparator());

            // Output Target / Destination
            rightBar.Children.Add(CreateHeaderIconButton("header/headertarget_notarget.png", "Destination: Presentation (Target Audience Screen)", () =>
            {
                SetStatus("Destination: Presentation");
            }));

            rightBar.Children.Add(CreateHeaderSeparator());

            // Slideshow Auto-advance Loop
            rightBar.Children.Add(CreateHeaderIconButton("header/slideshow.png", doc.AutoAdvanceSeconds > 0 ? $"Slideshow: {doc.AutoAdvanceSeconds:0}s per slide" : "Slideshow: Off (Click to toggle 5s)", () =>
            {
                doc.AutoAdvanceSeconds = doc.AutoAdvanceSeconds == 0 ? 5.0 : (doc.AutoAdvanceSeconds == 5.0 ? 8.0 : 0.0);
                RebuildShowView();
                SetStatus(doc.AutoAdvanceSeconds > 0
                    ? $"Enabled Auto-Advance Slideshow ({doc.AutoAdvanceSeconds:0}s per slide)."
                    : "Disabled Auto-Advance Slideshow.");
            }, isToggled: doc.AutoAdvanceSeconds > 0));

            DockPanel.SetDock(rightBar, Dock.Right);
            titleDock.Children.Add(rightBar);

            // Left presentation icon + bold name
            var leftStack = new StackPanel { Orientation = Orientation.Horizontal, VerticalAlignment = VerticalAlignment.Center };

            // ProPresenter folded slide projection icon
            var presIcon = new System.Windows.Shapes.Path
            {
                Data = Geometry.Parse("M2,3.5 L7.5,1.5 L7.5,16.5 L2,14.5 Z M9.5,1.5 L15,1.5 L15,16.5 L9.5,16.5 Z"),
                Fill = Brushes.White,
                Width = 16,
                Height = 16,
                Margin = new Thickness(2, 0, 8, 0),
                VerticalAlignment = VerticalAlignment.Center,
                Stretch = Stretch.Uniform
            };
            leftStack.Children.Add(presIcon);

            leftStack.Children.Add(new TextBlock
            {
                Text = doc.Name,
                Foreground = Brushes.White,
                FontSize = 14,
                FontWeight = FontWeights.Bold,
                VerticalAlignment = VerticalAlignment.Center
            });

            titleDock.Children.Add(leftStack);
            titleBar.Child = titleDock;
            headerContainer.Children.Add(titleBar);

            // Optional Arrangement & Group Pill Bar (only visible when Arrangements button is toggled on)
            if (_showArrangements)
            {
                var arrBar = new Border
                {
                    Background = new SolidColorBrush(Color.FromRgb(0x18, 0x18, 0x1B)),
                    BorderBrush = new SolidColorBrush(Color.FromRgb(0x28, 0x28, 0x2E)),
                    BorderThickness = new Thickness(0, 0, 0, 1),
                    Padding = new Thickness(14, 5, 14, 5)
                };
                var arrWrap = new WrapPanel { VerticalAlignment = VerticalAlignment.Center };
                arrWrap.Children.Add(new TextBlock
                {
                    Text = "ARRANGEMENTS:  ",
                    Foreground = new SolidColorBrush(Color.FromRgb(0x88, 0x90, 0xA0)),
                    FontSize = 10.5,
                    FontWeight = FontWeights.Bold,
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(0, 0, 6, 0)
                });

                var distinctGroups = doc.Slides
                    .GroupBy(s => s.GroupName)
                    .Select(g => (GroupName: g.Key, Color: g.First().GroupColor, FirstSlide: g.First(), Count: g.Count()))
                    .ToList();

                foreach (var grp in distinctGroups)
                {
                    var capturedSlide = grp.FirstSlide;
                    var pill = new Border
                    {
                        Background = new SolidColorBrush(grp.Color),
                        CornerRadius = new CornerRadius(3),
                        Padding = new Thickness(8, 2, 8, 2),
                        Margin = new Thickness(0, 2, 6, 2),
                        Cursor = Cursors.Hand,
                        ToolTip = $"Click to trigger first slide of '{grp.GroupName}' ({grp.Count} slides)",
                        Child = new TextBlock
                        {
                            Text = $"{grp.GroupName} ({grp.Count})",
                            Foreground = Brushes.White,
                            FontSize = 11,
                            FontWeight = FontWeights.SemiBold
                        }
                    };
                    pill.MouseLeftButtonDown += (_, _) => TriggerSlide(doc, capturedSlide);
                    arrWrap.Children.Add(pill);
                }
                arrBar.Child = arrWrap;
                headerContainer.Children.Add(arrBar);
            }

            Grid.SetRow(headerContainer, 0);
            showGrid.Children.Add(headerContainer);

            // Row 1: Slide Grid or Table View
            var scroll = new ScrollViewer
            {
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled,
                Padding = new Thickness(12, 12, 12, 12),
                Background = new SolidColorBrush(Color.FromRgb(0x14, 0x14, 0x16))
            };

            if (_isTableMode)
            {
                var tableStack = new StackPanel { Orientation = Orientation.Vertical };
                foreach (var slide in doc.Slides)
                {
                    tableStack.Children.Add(CreateSlideTableRow(doc, slide));
                }
                scroll.Content = tableStack;
            }
            else
            {
                var wrap = new WrapPanel { Orientation = Orientation.Horizontal };
                foreach (var slide in doc.Slides)
                {
                    wrap.Children.Add(CreateSlideThumbnailCard(doc, slide));
                }
                scroll.Content = wrap;
            }

            Grid.SetRow(scroll, 1);
            showGrid.Children.Add(scroll);

            // Row 2: ViewerStatusBar (Replica of ProPresenter 7 ViewerStatusBar.xaml)
            var footerBar = BuildViewerStatusBar(doc);
            Grid.SetRow(footerBar, 2);
            showGrid.Children.Add(footerBar);

            _centerContentHost.Children.Add(showGrid);
        }

        private static ControlTemplate? _proFillSliderTemplate;

        private static ControlTemplate GetProFillSliderTemplate()
        {
            if (_proFillSliderTemplate != null) return _proFillSliderTemplate;

            const string xaml = @"
<ControlTemplate xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
                 xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""
                 TargetType=""Slider"">
    <Grid VerticalAlignment=""Center"" Height=""18"">
        <Track x:Name=""PART_Track"">
            <Track.DecreaseRepeatButton>
                <RepeatButton Command=""Slider.DecreaseLarge"" Focusable=""False"">
                    <RepeatButton.Template>
                        <ControlTemplate>
                            <Border Height=""3"" Background=""#007AFF"" CornerRadius=""1.5,0,0,1.5"" />
                        </ControlTemplate>
                    </RepeatButton.Template>
                </RepeatButton>
            </Track.DecreaseRepeatButton>
            <Track.Thumb>
                <Thumb Focusable=""False"" Width=""12"" Height=""12"" Cursor=""Hand"">
                    <Thumb.Template>
                        <ControlTemplate>
                            <Ellipse Width=""12"" Height=""12"" Fill=""#ECECEE"" Stroke=""#282830"" StrokeThickness=""1"" />
                        </ControlTemplate>
                    </Thumb.Template>
                </Thumb>
            </Track.Thumb>
            <Track.IncreaseRepeatButton>
                <RepeatButton Command=""Slider.IncreaseLarge"" Focusable=""False"">
                    <RepeatButton.Template>
                        <ControlTemplate>
                            <Border Height=""3"" Background=""#44444E"" CornerRadius=""0,1.5,1.5,0"" />
                        </ControlTemplate>
                    </RepeatButton.Template>
                </RepeatButton>
            </Track.IncreaseRepeatButton>
        </Track>
    </Grid>
</ControlTemplate>";

            _proFillSliderTemplate = (ControlTemplate)System.Windows.Markup.XamlReader.Parse(xaml);
            return _proFillSliderTemplate;
        }

        private FrameworkElement BuildViewerStatusBar(PresentationDocument doc)
        {
            var bar = new Border
            {
                Height = 32,
                Background = ThemeEngine.Instance.GetBrush("HEADER", Color.FromRgb(0x18, 0x18, 0x1B)),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x2D, 0x2D, 0x35)),
                BorderThickness = new Thickness(0, 1, 0, 0),
                Padding = new Thickness(8, 0, 8, 0)
            };

            var grid = new Grid { VerticalAlignment = VerticalAlignment.Center };
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto }); // Left controls
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }); // Spacer
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto }); // Right controls

            // --- Left Section ---
            var leftStack = new StackPanel { Orientation = Orientation.Horizontal, VerticalAlignment = VerticalAlignment.Center };

            // 1. + Add Slide Button
            var addBtn = new Button
            {
                Width = 24,
                Height = 24,
                Background = Brushes.Transparent,
                BorderThickness = new Thickness(0),
                Cursor = Cursors.Hand,
                ToolTip = "Add Slide (Ctrl+N)"
            };
            addBtn.Content = new System.Windows.Shapes.Path
            {
                Width = 12,
                Height = 12,
                Data = Geometry.Parse("M5,0 H7 V5 H12 V7 H7 V12 H5 V7 H0 V5 H5 Z"),
                Fill = new SolidColorBrush(Color.FromRgb(0xCC, 0xD0, 0xDC)),
                Stretch = Stretch.Uniform
            };
            addBtn.Click += (_, _) => AddSlideToCurrentPresentation();
            leftStack.Children.Add(addBtn);

            // Separator |
            leftStack.Children.Add(CreateStatusBarSeparator());

            // 2. Slide Transitions (Foreground - Orange #FF9500)
            bool isSlideCut = string.Equals(doc.TransitionName, "Cut", StringComparison.OrdinalIgnoreCase);
            bool isSlideDissolve = string.Equals(doc.TransitionName, "Dissolve", StringComparison.OrdinalIgnoreCase);
            bool isSlideAdv = !isSlideCut && !isSlideDissolve;
            Color orange = Color.FromRgb(0xFF, 0x95, 0x00);
            Color gray = Color.FromRgb(0x75, 0x76, 0x82);

            const string cutPath = "M8,2L8,16 1,16C0.44771525,16,6.76353751E-17,15.5522847,0,15L0,3C-6.76353751E-17,2.44771525,0.44771525,2,1,2L8,2z M17,2C17.5522847,2,18,2.44771525,18,3L18,15C18,15.5522847,17.5522847,16,17,16L10,16 10,2 17,2z";
            const string dissolvePath = "M10.8,12.5L10.8,9 14.4,9 14.4,5.5 10.8,5.5 10.8,2 14.4,2 14.4,5.5 18,5.5 18,9 14.4,9 14.4,12.5 18,12.5 18,15C18,15.5522847,17.5522847,16,17,16L14.4,16 14.4,12.5 10.8,12.5z M10.8,12.5L10.8,16 7.2,16 1,16C0.44771525,16,6.76353751E-17,15.5522847,0,15L0,3C-6.76353751E-17,2.44771525,0.44771525,2,1,2L7.2,2 7.2,5.5 10.8,5.5 10.8,9 7.2,9 7.2,12.5 10.8,12.5z";
            const string advPath = "M4,2L10.8232233,8.8232233C10.9208544,8.92085438,10.9208544,9.07914562,10.8232233,9.1767767L10.8232233,9.1767767 4,16 1,16C0.44771525,16,-2.12486467E-14,15.5522847,-2.13162821E-14,15L-2.13162821E-14,15 -2.13162821E-14,3C-2.13839174E-14,2.44771525,0.44771525,2,1,2L1,2 4,2z M17,2C17.5522847,2,18,2.44771525,18,3L18,3 18,15C18,15.5522847,17.5522847,16,17,16L17,16 7,16 13.8232233,9.1767767C13.9208544,9.07914562,13.9208544,8.92085438,13.8232233,8.8232233L13.8232233,8.8232233 7,2z";

            var slideCutBtn = CreateIconButton(cutPath, isSlideCut ? orange : gray, "Cut Transition (Slide)", () =>
            {
                doc.TransitionName = "Cut";
                doc.TransitionDurationSeconds = 0.0;
                RebuildShowView();
            });
            var slideDissolveBtn = CreateIconButton(dissolvePath, isSlideDissolve ? orange : gray, "Dissolve Transition (Slide)", () =>
            {
                doc.TransitionName = "Dissolve";
                doc.TransitionDurationSeconds = 0.5;
                RebuildShowView();
            });
            var slideAdvBtn = CreateIconButton(advPath, isSlideAdv ? orange : gray, "Advanced Slide Transitions...", () =>
            {
                ShowSlideTransitionsMenu(doc);
            });

            leftStack.Children.Add(slideCutBtn);
            leftStack.Children.Add(slideDissolveBtn);
            leftStack.Children.Add(slideAdvBtn);

            // Separator |
            leftStack.Children.Add(CreateStatusBarSeparator());

            // 3. Media Transitions (Background - Purple #AF52DE)
            Color purple = Color.FromRgb(0xAF, 0x52, 0xDE);
            bool isMediaCut = string.Equals(_mediaTransitionName, "Cut", StringComparison.OrdinalIgnoreCase);
            bool isMediaDissolve = string.Equals(_mediaTransitionName, "Dissolve", StringComparison.OrdinalIgnoreCase);
            bool isMediaAdv = !isMediaCut && !isMediaDissolve;

            var mediaCutBtn = CreateIconButton(cutPath, isMediaCut ? purple : gray, "Cut Transition (Media)", () =>
            {
                _mediaTransitionName = "Cut";
                RebuildShowView();
            });
            var mediaDissolveBtn = CreateIconButton(dissolvePath, isMediaDissolve ? purple : gray, "Dissolve Transition (Media)", () =>
            {
                _mediaTransitionName = "Dissolve";
                RebuildShowView();
            });
            var mediaAdvBtn = CreateIconButton(advPath, isMediaAdv ? purple : gray, "Advanced Media Transitions...", () =>
            {
                ShowMediaTransitionsMenu();
            });

            leftStack.Children.Add(mediaCutBtn);
            leftStack.Children.Add(mediaDissolveBtn);
            leftStack.Children.Add(mediaAdvBtn);

            Grid.SetColumn(leftStack, 0);
            grid.Children.Add(leftStack);

            // --- Right Section ---
            var rightStack = new StackPanel { Orientation = Orientation.Horizontal, VerticalAlignment = VerticalAlignment.Center };

            Color activeBlue = Color.FromRgb(0x00, 0x7A, 0xFF);

            // Grid View Icon (4 squares)
            const string gridPath = "M1,1 H7 V7 H1 Z M9,1 H15 V7 H9 Z M1,9 H7 V15 H1 Z M9,9 H15 V15 H9 Z";
            var gridBtn = CreateIconButton(gridPath, !_isTableMode ? activeBlue : gray, "Grid View", () =>
            {
                if (_isTableMode)
                {
                    _isTableMode = false;
                    RebuildShowView();
                }
            });
            rightStack.Children.Add(gridBtn);

            // Easy View Icon (T)
            const string easyPath = "M2,2 H14 V5 H9.5 V14 H6.5 V5 H2 Z";
            var easyBtn = CreateIconButton(easyPath, gray, "Easy View", () =>
            {
            });
            rightStack.Children.Add(easyBtn);

            // Table View Icon (3 bars)
            const string tablePath = "M2,3 H14 V5 H2 Z M2,7 H14 V9 H2 Z M2,11 H14 V13 H2 Z";
            var tableBtn = CreateIconButton(tablePath, _isTableMode ? activeBlue : gray, "Table View", () =>
            {
                if (!_isTableMode)
                {
                    _isTableMode = true;
                    RebuildShowView();
                }
            });
            rightStack.Children.Add(tableBtn);

            // Options Icon (3 dots)
            const string optionsPath = "M8,1 A7,7 0 1,0 8,15 A7,7 0 1,0 8,1 Z M4.5,8 A1,1 0 1,1 4.5,8.01 Z M8,8 A1,1 0 1,1 8,8.01 Z M11.5,8 A1,1 0 1,1 11.5,8.01 Z";
            var optionsBtn = CreateIconButton(optionsPath, gray, "Presentation View Options...", () =>
            {
                ShowPresentationViewOptions();
            });
            rightStack.Children.Add(optionsBtn);

            // FillSlider (Zoom Slider)
            var zoomSlider = new Slider
            {
                Width = 100,
                Minimum = 160,
                Maximum = 340,
                Value = _thumbnailWidth,
                IsMoveToPointEnabled = true,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(10, 0, 4, 0),
                Template = GetProFillSliderTemplate()
            };
            zoomSlider.ValueChanged += (_, e) =>
            {
                if (Math.Abs(e.NewValue - _thumbnailWidth) > 8)
                {
                    _thumbnailWidth = e.NewValue;
                    RebuildShowView();
                }
            };
            rightStack.Children.Add(zoomSlider);

            Grid.SetColumn(rightStack, 2);
            grid.Children.Add(rightStack);

            bar.Child = grid;
            return bar;
        }

        private static Border CreateStatusBarSeparator()
        {
            return new Border
            {
                Width = 1,
                Height = 15,
                Background = new SolidColorBrush(Color.FromRgb(0x38, 0x38, 0x42)),
                Margin = new Thickness(7, 0, 7, 0),
                VerticalAlignment = VerticalAlignment.Center
            };
        }

        private static Button CreateIconButton(string pathData, Color iconColor, string tooltip, Action onClick)
        {
            var btn = new Button
            {
                Width = 22,
                Height = 22,
                Background = Brushes.Transparent,
                BorderThickness = new Thickness(0),
                Cursor = Cursors.Hand,
                Margin = new Thickness(2, 0, 2, 0),
                ToolTip = tooltip
            };
            btn.Content = new System.Windows.Shapes.Path
            {
                Width = 14,
                Height = 14,
                Data = Geometry.Parse(pathData),
                Fill = new SolidColorBrush(iconColor),
                Stretch = Stretch.Uniform
            };
            btn.Click += (_, _) => onClick();
            return btn;
        }

        private void ShowSlideTransitionsMenu(PresentationDocument doc)
        {
            var menu = new ContextMenu();
            menu.Resources = GetDarkMenuResourceDictionary();

            string[] presets = { "Cut", "Dissolve", "Wipe", "Push", "Fly In", "Zoom" };

            foreach (var preset in presets)
            {
                var mi = new MenuItem
                {
                    Header = $"{preset} (0.5s)",
                    IsChecked = string.Equals(doc.TransitionName, preset, StringComparison.OrdinalIgnoreCase)
                };
                string p = preset;
                mi.Click += (_, _) =>
                {
                    doc.TransitionName = p;
                    doc.TransitionDurationSeconds = (p == "Cut") ? 0.0 : 0.5;
                    RebuildShowView();
                };
                menu.Items.Add(mi);
            }
            menu.Placement = PlacementMode.MousePoint;
            menu.IsOpen = true;
        }

        private void ShowMediaTransitionsMenu()
        {
            var menu = new ContextMenu();
            menu.Resources = GetDarkMenuResourceDictionary();

            string[] presets = { "Cut", "Dissolve", "Fade to Black" };
            foreach (var preset in presets)
            {
                var mi = new MenuItem
                {
                    Header = preset,
                    IsChecked = string.Equals(_mediaTransitionName, preset, StringComparison.OrdinalIgnoreCase)
                };
                string p = preset;
                mi.Click += (_, _) =>
                {
                    _mediaTransitionName = p;
                    RebuildShowView();
                };
                menu.Items.Add(mi);
            }
            menu.Placement = PlacementMode.MousePoint;
            menu.IsOpen = true;
        }

        private void ShowPresentationViewOptions()
        {
            var menu = new ContextMenu();
            menu.Resources = GetDarkMenuResourceDictionary();

            var miGroup = new MenuItem { Header = "Slides by Group", IsCheckable = true, IsChecked = true };
            var miBg = new MenuItem { Header = "Use Presentation Background Color", IsCheckable = true, IsChecked = true };
            var miEdit = new MenuItem { Header = "Edit Presentation Slide..." };
            miEdit.Click += (_, _) => SwitchViewMode(InlineViewMode.Edit);

            menu.Items.Add(miGroup);
            menu.Items.Add(miBg);
            menu.Items.Add(new Separator());
            menu.Items.Add(miEdit);

            menu.Placement = PlacementMode.MousePoint;
            menu.IsOpen = true;
        }

        private FrameworkElement CreateSlideThumbnailCard(PresentationDocument doc, SlideItemModel slide)
        {
            bool isLive = _outputState.ActiveSlide == slide;
            double cardWidth = _thumbnailWidth;
            double thumbHeight = Math.Round(cardWidth * 9.0 / 16.0);

            // In ProPresenter, cards have an outline matching their group color!
            // When live, the card outline turns vibrant green with a soft drop shadow.
            Color groupColor = slide.GroupColor;
            Color borderColor = isLive ? Color.FromRgb(0x33, 0xFD, 0x00) : groupColor;
            double borderThickness = isLive ? 2.5 : 1.5;

            var outerBorder = new Border
            {
                Width = cardWidth + 4,
                Margin = new Thickness(0, 0, 12, 12),
                CornerRadius = new CornerRadius(3),
                BorderBrush = new SolidColorBrush(borderColor),
                BorderThickness = new Thickness(borderThickness),
                Background = new SolidColorBrush(Color.FromRgb(0x15, 0x15, 0x18)),
                Cursor = Cursors.Hand
            };

            if (isLive)
            {
                outerBorder.Effect = new DropShadowEffect
                {
                    Color = Color.FromRgb(0x33, 0xFD, 0x00),
                    BlurRadius = 10,
                    ShadowDepth = 0,
                    Opacity = 0.8
                };
            }

            var cardGrid = new Grid();
            cardGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(thumbHeight) }); // 16:9 Slide Preview
            cardGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(22) }); // Solid Group Footer Bar

            // 16:9 Slide Canvas Preview (shows dark checkerboard for transparency + centered white lyrics)
            var thumbHost = new Grid { Width = cardWidth, Height = thumbHeight, ClipToBounds = true };
            thumbHost.Children.Add(SlideCanvasRenderer.RenderSlideThumbnail(slide, cardWidth, thumbHeight, null, _timers));

            // Orange Hotkey Badge in Top-Left (only shown on the first slide of the group)
            string hotKey = slide.HotKey;
            if (string.IsNullOrWhiteSpace(hotKey) && slide.IsFirstInGroup)
            {
                hotKey = ProFileService.GetDefaultHotKey(slide.GroupName);
            }

            if (!string.IsNullOrWhiteSpace(hotKey) && slide.IsFirstInGroup)
            {
                var hkBadge = new Border
                {
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(5, 5, 0, 0),
                    Width = 20,
                    Height = 18,
                    CornerRadius = new CornerRadius(3),
                    Background = new SolidColorBrush(Color.FromRgb(0xFF, 0xA5, 0x00)),
                    Child = new TextBlock
                    {
                        Text = hotKey.ToUpperInvariant(),
                        Foreground = Brushes.Black,
                        FontSize = 11,
                        FontWeight = FontWeights.Bold,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center
                    }
                };
                thumbHost.Children.Add(hkBadge);
            }

            Grid.SetRow(thumbHost, 0);
            cardGrid.Children.Add(thumbHost);

            // Bottom Footer Bar (Solid Group Color strip)
            var footer = new Border
            {
                Height = 22,
                Background = new SolidColorBrush(groupColor),
                CornerRadius = new CornerRadius(0, 0, 2, 2)
            };

            string footerLabel = slide.IsFirstInGroup
                ? $"{slide.SlideNumber}  {slide.GroupName}"
                : $"{slide.SlideNumber}";

            var footerTb = new TextBlock
            {
                Text = footerLabel,
                Foreground = Brushes.White,
                FontSize = 11.5,
                FontWeight = FontWeights.SemiBold,
                Margin = new Thickness(8, 0, 0, 0),
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left,
                TextTrimming = TextTrimming.CharacterEllipsis
            };
            footer.Child = footerTb;

            Grid.SetRow(footer, 1);
            cardGrid.Children.Add(footer);

            outerBorder.Child = cardGrid;
            outerBorder.MouseLeftButtonDown += (_, e) =>
            {
                if (e.ClickCount == 2)
                {
                    _selectedEditorSlide = slide;
                    _selectedEditorElement = slide.Elements.FirstOrDefault();
                    SwitchViewMode(InlineViewMode.Edit);
                }
                else
                {
                    TriggerSlide(doc, slide);
                }
            };

            if (!slide.IsEnabled)
            {
                cardGrid.Opacity = 0.42;
            }

            outerBorder.ContextMenu = CreateSlideContextMenu(doc, slide);
            return outerBorder;
        }

        private FrameworkElement CreateSlideTableRow(PresentationDocument doc, SlideItemModel slide)
        {
            bool isLive = _outputState.ActiveSlide == slide;
            var row = new Border
            {
                Background = new SolidColorBrush(isLive ? Color.FromRgb(0x3A, 0x28, 0x18) : Color.FromRgb(0x25, 0x26, 0x2C)),
                BorderBrush = new SolidColorBrush(isLive ? Color.FromRgb(0xF7, 0x82, 0x1C) : Color.FromRgb(0x35, 0x36, 0x3F)),
                BorderThickness = new Thickness(isLive ? 2 : 1),
                CornerRadius = new CornerRadius(4),
                Margin = new Thickness(0, 0, 0, 6),
                Padding = new Thickness(10, 6, 10, 6),
                Cursor = Cursors.Hand
            };

            var grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(36) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(110) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(180) });

            grid.Children.Add(new TextBlock
            {
                Text = $"#{slide.SlideNumber}",
                Foreground = new SolidColorBrush(Color.FromRgb(0x9E, 0xA4, 0xB2)),
                FontWeight = FontWeights.Bold,
                VerticalAlignment = VerticalAlignment.Center
            });

            var grpBadge = new Border
            {
                Background = new SolidColorBrush(slide.GroupColor),
                CornerRadius = new CornerRadius(3),
                Padding = new Thickness(6, 2, 6, 2),
                Margin = new Thickness(0, 0, 10, 0),
                VerticalAlignment = VerticalAlignment.Center,
                Child = new TextBlock
                {
                    Text = slide.GroupName,
                    Foreground = Brushes.White,
                    FontSize = 11,
                    FontWeight = FontWeights.Bold
                }
            };
            Grid.SetColumn(grpBadge, 1);
            grid.Children.Add(grpBadge);

            var lyricsTb = new TextBlock
            {
                Text = slide.PrimaryText.Replace("\n", "  /  "),
                Foreground = Brushes.White,
                FontSize = 13,
                FontWeight = FontWeights.Medium,
                VerticalAlignment = VerticalAlignment.Center,
                TextTrimming = TextTrimming.CharacterEllipsis
            };
            Grid.SetColumn(lyricsTb, 2);
            grid.Children.Add(lyricsTb);

            var notesTb = new TextBlock
            {
                Text = slide.Notes,
                Foreground = new SolidColorBrush(Color.FromRgb(0x9E, 0xA4, 0xB2)),
                FontSize = 11,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Right
            };
            Grid.SetColumn(notesTb, 3);
            grid.Children.Add(notesTb);

            row.Child = grid;
            row.MouseLeftButtonDown += (_, _) => TriggerSlide(doc, slide);
            if (!slide.IsEnabled)
            {
                row.Opacity = 0.42;
            }
            row.ContextMenu = CreateSlideContextMenu(doc, slide);
            return row;
        }

        private void RebuildMediaBinView()
        {
            _mediaBinHost.Children.Clear();

            var grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(30) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            // Top Bar: Media Bin Categories + Live Camera Input Trigger
            var topBar = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(0x16, 0x16, 0x1A)),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x2D, 0x2D, 0x35)),
                BorderThickness = new Thickness(0, 0, 0, 1),
                Padding = new Thickness(10, 3, 10, 3)
            };
            var topDock = new DockPanel();

            var camBtn = CreateSmallHeaderButton(
                _outputState.IsVideoInputActive ? "📹 Live Camera: ON" : "📹 Trigger Live Video Input",
                _outputState.IsVideoInputActive ? Color.FromRgb(0xD0, 0x1F, 0x1F) : Color.FromRgb(0x38, 0x38, 0x42),
                () =>
                {
                    _outputState.IsVideoInputActive = !_outputState.IsVideoInputActive;
                    RebuildMediaBinView();
                    RefreshPreviewAndOutputs();
                    SetStatus(_outputState.IsVideoInputActive ? "Activated Live Camera Video Input Layer." : "Cleared Live Camera Video Input Layer.");
                });
            DockPanel.SetDock(camBtn, Dock.Right);
            topDock.Children.Add(camBtn);

            var catStack = new StackPanel { Orientation = Orientation.Horizontal, VerticalAlignment = VerticalAlignment.Center };
            catStack.Children.Add(new TextBlock
            {
                Text = "MEDIA BIN   ",
                Foreground = new SolidColorBrush(Color.FromRgb(0xF7, 0x82, 0x1C)),
                FontSize = 11,
                FontWeight = FontWeights.Bold,
                VerticalAlignment = VerticalAlignment.Center
            });

            string[] mediaCats = { "All Media", "Motion Loops", "Video Assets", "Stills & Imports" };
            foreach (string mc in mediaCats)
            {
                string captured = mc;
                bool active = _activeMediaCategoryFilter == captured;
                catStack.Children.Add(CreateSmallHeaderButton(
                    captured,
                    active ? Color.FromRgb(0x00, 0x7A, 0xFF) : Color.FromRgb(0x2B, 0x2B, 0x33),
                    () =>
                    {
                        _activeMediaCategoryFilter = captured;
                        RebuildMediaBinView();
                    }));
            }

            topDock.Children.Add(catStack);
            topBar.Child = topDock;
            Grid.SetRow(topBar, 0);
            grid.Children.Add(topBar);

            // Media Cards ScrollViewer
            var scroll = new ScrollViewer
            {
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled,
                Padding = new Thickness(10, 8, 10, 8)
            };
            var wrap = new WrapPanel { Orientation = Orientation.Horizontal };

            IEnumerable<MediaBinItem> items = _mediaBinItems;
            if (_activeMediaCategoryFilter != "All Media")
                items = items.Where(m => m.Category == _activeMediaCategoryFilter);

            foreach (var media in items)
            {
                var capturedMedia = media;
                bool isActive = _outputState.ActiveMediaBackground == capturedMedia;

                var card = new Border
                {
                    Width = 152,
                    Margin = new Thickness(0, 0, 10, 10),
                    CornerRadius = new CornerRadius(4),
                    Background = new SolidColorBrush(Color.FromRgb(0x24, 0x25, 0x2B)),
                    BorderBrush = new SolidColorBrush(isActive ? Color.FromRgb(0xF7, 0x82, 0x1C) : Color.FromRgb(0x3C, 0x3D, 0x45)),
                    BorderThickness = new Thickness(isActive ? 2 : 1),
                    Cursor = Cursors.Hand
                };

                var stack = new StackPanel { Orientation = Orientation.Vertical };
                var previewHost = new Grid { Width = 150, Height = 84, ClipToBounds = true };
                previewHost.Children.Add(SlideCanvasRenderer.CreateMediaLayerVisual(capturedMedia, 150, 84, 0.25));

                var durBadge = new Border
                {
                    HorizontalAlignment = HorizontalAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    Margin = new Thickness(4),
                    Padding = new Thickness(4, 1, 4, 1),
                    CornerRadius = new CornerRadius(3),
                    Background = new SolidColorBrush(Color.FromArgb(190, 0, 0, 0)),
                    Child = new TextBlock
                    {
                        Text = capturedMedia.DurationText,
                        Foreground = Brushes.White,
                        FontSize = 9,
                        FontWeight = FontWeights.SemiBold
                    }
                };
                previewHost.Children.Add(durBadge);
                stack.Children.Add(previewHost);

                stack.Children.Add(new TextBlock
                {
                    Text = capturedMedia.Name,
                    Foreground = Brushes.White,
                    FontSize = 11,
                    FontWeight = FontWeights.Medium,
                    Margin = new Thickness(6, 4, 6, 4),
                    TextTrimming = TextTrimming.CharacterEllipsis
                });

                card.Child = stack;
                card.MouseLeftButtonDown += (_, _) =>
                {
                    TriggerMediaItem(capturedMedia);
                    RebuildMediaBinView();
                };
                wrap.Children.Add(card);
            }

            scroll.Content = wrap;
            Grid.SetRow(scroll, 1);
            grid.Children.Add(scroll);

            _mediaBinHost.Children.Add(grid);
        }

        private static Button CreateSmallHeaderButton(string text, Color bgColor, System.Action onClick)
        {
            var btn = new Button
            {
                Content = text,
                Background = new SolidColorBrush(bgColor),
                Foreground = Brushes.White,
                BorderBrush = new SolidColorBrush(Color.FromArgb(90, 255, 255, 255)),
                BorderThickness = new Thickness(1),
                Padding = new Thickness(9, 3, 9, 3),
                Margin = new Thickness(4, 0, 4, 0),
                FontSize = 11,
                FontWeight = FontWeights.SemiBold,
                Cursor = Cursors.Hand
            };
            btn.Click += (_, _) => onClick();
            return btn;
        }

        private void CyclePresentationTransition(PresentationDocument doc)
        {
            string[] transitions = { "Dissolve", "Cut", "Fade to Black", "Push Left", "Iris Wipe", "Zoom Dissolve" };
            int idx = Array.IndexOf(transitions, doc.TransitionName);
            doc.TransitionName = transitions[(idx + 1) % transitions.Length];
            doc.TransitionDurationSeconds = doc.TransitionName == "Cut" ? 0.05 : 0.45;
            RebuildShowView();
            SetStatus($"Presentation transition set to '{doc.TransitionName}' ({doc.TransitionDurationSeconds:0.00}s).");
        }

        private static void RenumberSlides(PresentationDocument doc)
        {
            string lastGroup = "";
            for (int i = 0; i < doc.Slides.Count; i++)
            {
                doc.Slides[i].SlideNumber = i + 1;
                bool isFirst = (i == 0 || !doc.Slides[i].GroupName.Equals(lastGroup, StringComparison.OrdinalIgnoreCase));
                doc.Slides[i].IsFirstInGroup = isFirst;
                if (isFirst && string.IsNullOrWhiteSpace(doc.Slides[i].HotKey))
                {
                    doc.Slides[i].HotKey = ProFileService.GetDefaultHotKey(doc.Slides[i].GroupName);
                }
                lastGroup = doc.Slides[i].GroupName;
            }
        }

        private void AddSlideToCurrentPresentation()
        {
            if (_selectedPresentation == null) return;
            var newSlide = new SlideItemModel
            {
                SlideNumber = _selectedPresentation.Slides.Count + 1,
                GroupName = _selectedPresentation.Slides.LastOrDefault()?.GroupName ?? "Verse 1",
                GroupColor = _selectedPresentation.Slides.LastOrDefault()?.GroupColor ?? Color.FromRgb(0x00, 0x77, 0xCC),
                PrimaryText = "New Slide Text\nDouble-click to edit"
            };
            _selectedPresentation.Slides.Add(newSlide);
            _selectedEditorSlide = newSlide;
            _selectedEditorElement = newSlide.Elements.FirstOrDefault();
            RebuildCenterWorkspace();
            RefreshLibraryViewLists();
            UpdateRightColumnBottomStatus();
            SetStatus($"Added Slide #{newSlide.SlideNumber} to '{_selectedPresentation.Name}'.");
        }

        private void DuplicateCurrentSlide()
        {
            if (_selectedPresentation == null) return;
            var target = _selectedEditorSlide ?? _outputState.ActiveSlide ?? _selectedPresentation.Slides.LastOrDefault();
            if (target == null) return;

            var clone = target.Clone();
            int idx = _selectedPresentation.Slides.IndexOf(target);
            _selectedPresentation.Slides.Insert(idx + 1, clone);
            RenumberSlides(_selectedPresentation);
            _selectedEditorSlide = clone;
            RebuildCenterWorkspace();
            SetStatus($"Duplicated Slide #{target.SlideNumber}.");
        }

        private void AddSelectedPresentationToPlaylist()
        {
            if (_selectedPresentation == null || _selectedPlaylist == null) return;
            _selectedPlaylist.Items.Add(new PlaylistItemEntry
            {
                Title = _selectedPresentation.Name,
                CueType = PlaylistCueType.Presentation,
                LinkedPresentation = _selectedPresentation
            });
            RefreshPlaylistViews();
            SetStatus($"Added '{_selectedPresentation.Name}' to playlist '{_selectedPlaylist.Name}'.");
        }

        private void PromptNewPresentation()
        {
            var availableLibraries = new List<string> { "Default", "Worship Songs", "Teaching / Sermons", "Youth", "Bible Scripture" };
            foreach (var p in _libraryPresentations)
            {
                if (!string.IsNullOrWhiteSpace(p.Category) && !availableLibraries.Contains(p.Category))
                    availableLibraries.Add(p.Category);
            }

            var availablePlaylists = _playlists.Select(pl => pl.Name).ToList();
            string? currentPl = _selectedPlaylist?.Name;

            var dlg = new NewPresentationDialog(_themes, availableLibraries, availablePlaylists, currentPl)
            {
                Owner = this
            };

            if (dlg.ShowDialog() == true && dlg.Result != null)
            {
                var res = dlg.Result;
                var doc = new PresentationDocument
                {
                    Name = res.Name,
                    Category = res.Library
                };

                var initialSlide = new SlideItemModel
                {
                    SlideNumber = 1,
                    GroupName = "Verse 1",
                    GroupColor = Color.FromRgb(0x00, 0x77, 0xCC),
                    PrimaryText = doc.Name + "\nEnter worship lyrics or sermon notes here"
                };
                initialSlide.Elements.Add(new SlideElementModel
                {
                    Kind = SlideElementKind.Text,
                    Text = initialSlide.PrimaryText
                });
                doc.Slides.Add(initialSlide);

                var chorusSlide = new SlideItemModel
                {
                    SlideNumber = 2,
                    GroupName = "Chorus",
                    GroupColor = Color.FromRgb(0xCC, 0x00, 0x4E),
                    PrimaryText = "Praise the Lord, O my soul\nAll that is within me, bless His holy name"
                };
                chorusSlide.Elements.Add(new SlideElementModel
                {
                    Kind = SlideElementKind.Text,
                    Text = chorusSlide.PrimaryText
                });
                doc.Slides.Add(chorusSlide);

                ApplyThemeToPresentation(doc, res.Theme);

                _libraryPresentations.Insert(0, doc);

                if (res.Playlist != "No Playlist")
                {
                    var targetPl = _playlists.FirstOrDefault(pl => pl.Name.Equals(res.Playlist, StringComparison.OrdinalIgnoreCase));
                    if (targetPl != null)
                    {
                        targetPl.Items.Add(new PlaylistItemEntry
                        {
                            Title = doc.Name,
                            CueType = PlaylistCueType.Presentation,
                            LinkedPresentation = doc
                        });
                        RefreshPlaylistViews();
                    }
                }

                RefreshLibraryViewLists();
                SelectPresentation(doc, triggerFirstSlide: true);
                SetStatus($"Created new Presentation: '{doc.Name}' in Library '{doc.Category}' ({res.SizeString}).");
            }
        }

        private void PromptImportProFile()
        {
            string defaultDir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "ProPresenter", "Libraries", "Default");
            if (!Directory.Exists(defaultDir))
                defaultDir = Path.Combine(ThemeEngine.Instance.AssetsRoot, "sample-libraries");

            var ofd = new OpenFileDialog
            {
                Title = "Import ProPresenter (.pro) Presentation",
                Filter = "ProPresenter Files (*.pro)|*.pro|All Files (*.*)|*.*",
                InitialDirectory = Directory.Exists(defaultDir) ? defaultDir : Environment.CurrentDirectory,
                Multiselect = true
            };

            if (ofd.ShowDialog(this) == true)
            {
                PresentationDocument? lastLoaded = null;
                foreach (string file in ofd.FileNames)
                {
                    var doc = ProFileService.LoadProFile(file);
                    if (doc != null)
                    {
                        _libraryPresentations.Insert(0, doc);
                        lastLoaded = doc;
                    }
                }
                RefreshLibraryViewLists();
                if (lastLoaded != null)
                {
                    SelectPresentation(lastLoaded, triggerFirstSlide: true);
                }
            }
        }

        private void SaveSelectedPresentation()
        {
            if (_selectedPresentation == null) return;

            string savePath = _selectedPresentation.FilePath ?? "";
            if (string.IsNullOrWhiteSpace(savePath))
            {
                string outDir = Path.Combine(ThemeEngine.Instance.AssetsRoot, "sample-libraries");
                Directory.CreateDirectory(outDir);
                var sfd = new SaveFileDialog
                {
                    Title = "Save ProPresenter (.pro) File",
                    Filter = "ProPresenter Presentation (*.pro)|*.pro",
                    InitialDirectory = outDir,
                    FileName = _selectedPresentation.Name + ".pro"
                };
                if (sfd.ShowDialog(this) != true)
                    return;
                savePath = sfd.FileName;
            }

            try
            {
                ProFileService.SaveProFile(_selectedPresentation, savePath);
                SetStatus($"Saved native Protobuf .pro file -> {savePath}");
            }
            catch (Exception ex)
            {
                SetStatus($"Save error: {ex.Message}");
            }
        }

        private void ShowQuickSearchDialog()
        {
            var dlg = new Window
            {
                Title = "ProPresenter Quick Search (Library & Bible)",
                Width = 580,
                Height = 420,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Owner = this,
                Background = new SolidColorBrush(Color.FromRgb(0x23, 0x23, 0x28))
            };

            var grid = new Grid { Margin = new Thickness(14) };
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            var queryBox = new TextBox
            {
                Padding = new Thickness(8),
                FontSize = 14,
                Background = new SolidColorBrush(Color.FromRgb(0x16, 0x17, 0x1C)),
                Foreground = Brushes.White,
                CaretBrush = Brushes.White,
                Margin = new Thickness(0, 0, 0, 10)
            };
            Grid.SetRow(queryBox, 0);
            grid.Children.Add(queryBox);

            var resultsList = new ListBox
            {
                Background = new SolidColorBrush(Color.FromRgb(0x1B, 0x1C, 0x22)),
                Foreground = Brushes.White,
                BorderThickness = new Thickness(0),
                FontSize = 12.5
            };
            Grid.SetRow(resultsList, 1);
            grid.Children.Add(resultsList);

            void PopulateResults(string q)
            {
                resultsList.Items.Clear();
                foreach (var pres in _libraryPresentations)
                {
                    if (string.IsNullOrWhiteSpace(q) ||
                        pres.Name.Contains(q, StringComparison.OrdinalIgnoreCase) ||
                        pres.Slides.Any(s => s.PrimaryText.Contains(q, StringComparison.OrdinalIgnoreCase)))
                    {
                        var item = new ListBoxItem
                        {
                            Content = $"🎵  {pres.Name}   ({pres.Slides.Count} slides)  —  {pres.Slides.FirstOrDefault()?.PrimaryText.Replace("\n", " ")}",
                            Tag = pres,
                            Padding = new Thickness(8, 6, 8, 6)
                        };
                        resultsList.Items.Add(item);
                    }
                }
            }

            queryBox.TextChanged += (_, _) => PopulateResults(queryBox.Text);
            resultsList.MouseDoubleClick += (_, _) =>
            {
                if (resultsList.SelectedItem is ListBoxItem item && item.Tag is PresentationDocument doc)
                {
                    SelectPresentation(doc, triggerFirstSlide: true);
                    dlg.Close();
                }
            };

            PopulateResults("");
            dlg.Content = grid;
            dlg.Loaded += (_, _) => queryBox.Focus();
            dlg.ShowDialog();
        }

        private void ShowQuickTextStylePopover()
        {
            if (_selectedPresentation == null) return;
            SwitchViewMode(InlineViewMode.Edit);
            SetStatus("Opened Slide Editor & Text Style Inspector.");
        }

        private void ShowThemePickerDialog()
        {
            if (_selectedPresentation == null) return;

            var dlg = new Window
            {
                Title = "Apply ProPresenter Theme to Presentation",
                Width = 520,
                Height = 420,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Owner = this,
                Background = new SolidColorBrush(Color.FromRgb(0x24, 0x25, 0x2B))
            };

            var grid = new Grid { Margin = new Thickness(14) };
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            grid.Children.Add(new TextBlock
            {
                Text = $"Select a Theme to apply to '{_selectedPresentation.Name}' (Double-click to apply):",
                Foreground = Brushes.White,
                FontWeight = FontWeights.SemiBold,
                Margin = new Thickness(0, 0, 0, 10)
            });

            var list = new ListBox
            {
                Background = new SolidColorBrush(Color.FromRgb(0x18, 0x19, 0x1E)),
                Foreground = Brushes.White,
                FontSize = 13
            };
            foreach (var th in _themes)
            {
                var item = new ListBoxItem
                {
                    Content = $"🎨  {th.Name}   •   {th.FontFamily} {th.FontSize:0}pt",
                    Tag = th,
                    Padding = new Thickness(10, 7, 10, 7)
                };
                list.Items.Add(item);
            }
            list.MouseDoubleClick += (_, _) =>
            {
                if (list.SelectedItem is ListBoxItem li && li.Tag is ThemeTemplateModel tm && _selectedPresentation != null)
                {
                    ApplyThemeToPresentation(_selectedPresentation, tm);
                    RebuildCenterWorkspace();
                    RefreshPreviewAndOutputs();
                    SetStatus($"Applied theme '{tm.Name}' to '{_selectedPresentation.Name}'.");
                    dlg.Close();
                }
            };

            Grid.SetRow(list, 1);
            grid.Children.Add(list);
            dlg.Content = grid;
            dlg.ShowDialog();
        }

        private static void ApplyThemeToPresentation(PresentationDocument doc, ThemeTemplateModel theme)
        {
            foreach (var slide in doc.Slides)
            {
                if (theme.SlideBackgroundColor.A > 0)
                {
                    slide.HasCustomBackground = true;
                    slide.BackgroundColor = theme.SlideBackgroundColor;
                }
                foreach (var el in slide.Elements)
                {
                    if (el.Kind == SlideElementKind.Text)
                    {
                        el.FontFamily = theme.FontFamily;
                        el.FontSize = theme.FontSize;
                        el.IsBold = theme.IsBold;
                        el.IsUppercase = theme.IsUppercase;
                        el.TextColor = theme.TextColor;
                        el.FillColor = theme.BoxFillColor;
                        el.Y = theme.BoxY;
                        el.Height = theme.BoxHeight;
                    }
                }
            }
        }

        private void ShowMoreEditorsMenu()
        {
            var menu = new ContextMenu();
            menu.Items.Add(CreateSubMenuItem("Stage Display Editor", "", () =>
            {
                _isStagePreviewMode = true;
                _activeUtilityTab = "Stage";
                RebuildUtilityTabContent();
                RefreshPreviewAndOutputs();
                SetStatus("Switched Preview Monitor to Stage Display Editor mode.");
            }));
            menu.Items.Add(CreateSubMenuItem("Theme Editor", "", () => SwitchViewMode(InlineViewMode.ThemeEditor)));
            menu.Items.Add(CreateSubMenuItem("Props Editor", "", () => SwitchViewMode(InlineViewMode.PropsEditor)));
            menu.Items.Add(CreateSubMenuItem("Mask Editor", "", () => SwitchViewMode(InlineViewMode.MaskEditor)));
            menu.IsOpen = true;
        }

        // =========================================================================
        // ProPresenter-grade Slide Context Menu & Actions (Matching SlideMenuSource)
        // =========================================================================

        private static ResourceDictionary? _darkMenuResourceDictionary;
        private static ResourceDictionary GetDarkMenuResourceDictionary()
        {
            if (_darkMenuResourceDictionary != null) return _darkMenuResourceDictionary;

            const string xaml = @"<ResourceDictionary xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
                    xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml"">

    <Style TargetType=""{x:Type Separator}"">
        <Setter Property=""Template"">
            <Setter.Value>
                <ControlTemplate TargetType=""{x:Type Separator}"">
                    <Border Height=""1"" Background=""#52525A"" Margin=""6,3,6,3"" SnapsToDevicePixels=""True"" />
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>

    <Style TargetType=""{x:Type ContextMenu}"">
        <Setter Property=""SnapsToDevicePixels"" Value=""True"" />
        <Setter Property=""OverridesDefaultStyle"" Value=""True"" />
        <Setter Property=""Grid.IsSharedSizeScope"" Value=""True"" />
        <Setter Property=""Template"">
            <Setter.Value>
                <ControlTemplate TargetType=""{x:Type ContextMenu}"">
                    <Border Background=""#3C3C40"" BorderBrush=""#56565C"" BorderThickness=""1"" CornerRadius=""3"" Padding=""2,3,2,3"">
                        <Border.Effect>
                            <DropShadowEffect BlurRadius=""10"" ShadowDepth=""2"" Direction=""315"" Color=""#000000"" Opacity=""0.6"" />
                        </Border.Effect>
                        <StackPanel IsItemsHost=""True"" KeyboardNavigation.DirectionalNavigation=""Cycle"" />
                    </Border>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>

    <Style TargetType=""{x:Type MenuItem}"">
        <Setter Property=""Foreground"" Value=""#EEEEEE"" />
        <Setter Property=""FontSize"" Value=""12"" />
        <Setter Property=""FontFamily"" Value=""Segoe UI"" />
        <Setter Property=""Template"">
            <Setter.Value>
                <ControlTemplate TargetType=""{x:Type MenuItem}"">
                    <Grid SnapsToDevicePixels=""True"">
                        <Border x:Name=""ItemBorder"" Background=""Transparent"" CornerRadius=""2"" Padding=""6,4,6,4"" Margin=""1"">
                            <Grid>
                                <Grid.ColumnDefinitions>
                                    <ColumnDefinition Width=""Auto"" SharedSizeGroup=""MenuItemIconColumn"" />
                                    <ColumnDefinition Width=""*"" />
                                    <ColumnDefinition Width=""20"" />
                                    <ColumnDefinition Width=""Auto"" SharedSizeGroup=""MenuItemGestureColumn"" />
                                    <ColumnDefinition Width=""18"" />
                                </Grid.ColumnDefinitions>

                                <ContentPresenter x:Name=""IconPresenter"" Grid.Column=""0"" ContentSource=""Icon"" Margin=""0,0,8,0"" Width=""14"" Height=""14"" HorizontalAlignment=""Center"" VerticalAlignment=""Center"" SnapsToDevicePixels=""True"" />

                                <ContentPresenter Grid.Column=""1"" ContentSource=""Header"" RecognizesAccessKey=""True"" VerticalAlignment=""Center"" SnapsToDevicePixels=""True"" Margin=""0,0,12,0"" />

                                <TextBlock x:Name=""GestureBlock"" Grid.Column=""3"" Text=""{TemplateBinding InputGestureText}"" Foreground=""#8C8C94"" VerticalAlignment=""Center"" Margin=""8,0,0,0"" />

                                <Path x:Name=""SubmenuArrow"" Grid.Column=""4"" Data=""M0,0 L4,4 L0,8"" Stroke=""#9A9AA2"" StrokeThickness=""1.2"" HorizontalAlignment=""Right"" VerticalAlignment=""Center"" Visibility=""Collapsed"" Margin=""6,0,2,0"" />
                            </Grid>
                        </Border>

                        <Popup x:Name=""PART_Popup"" AllowsTransparency=""True"" Placement=""Right"" HorizontalOffset=""-2"" VerticalOffset=""-3"" IsOpen=""{Binding IsSubmenuOpen, RelativeSource={RelativeSource TemplatedParent}}"" Focusable=""False"" PopupAnimation=""Fade"">
                            <Border Background=""#3C3C40"" BorderBrush=""#56565C"" BorderThickness=""1"" CornerRadius=""3"" Padding=""2,3,2,3"" Grid.IsSharedSizeScope=""True"">
                                <Border.Effect>
                                    <DropShadowEffect BlurRadius=""10"" ShadowDepth=""2"" Direction=""315"" Color=""#000000"" Opacity=""0.6"" />
                                </Border.Effect>
                                <StackPanel IsItemsHost=""True"" KeyboardNavigation.DirectionalNavigation=""Cycle"" />
                            </Border>
                        </Popup>
                    </Grid>

                    <ControlTemplate.Triggers>
                        <Trigger Property=""Icon"" Value=""{x:Null}"">
                            <Setter TargetName=""IconPresenter"" Property=""Visibility"" Value=""Collapsed"" />
                        </Trigger>
                        <Trigger Property=""InputGestureText"" Value="""">
                            <Setter TargetName=""GestureBlock"" Property=""Visibility"" Value=""Collapsed"" />
                        </Trigger>
                        <Trigger Property=""InputGestureText"" Value=""{x:Null}"">
                            <Setter TargetName=""GestureBlock"" Property=""Visibility"" Value=""Collapsed"" />
                        </Trigger>
                        <Trigger Property=""HasItems"" Value=""True"">
                            <Setter TargetName=""SubmenuArrow"" Property=""Visibility"" Value=""Visible"" />
                        </Trigger>
                        <Trigger Property=""IsHighlighted"" Value=""True"">
                            <Setter TargetName=""ItemBorder"" Property=""Background"" Value=""#255999"" />
                            <Setter Property=""Foreground"" Value=""#FFFFFF"" />
                            <Setter TargetName=""SubmenuArrow"" Property=""Stroke"" Value=""#FFFFFF"" />
                            <Setter TargetName=""GestureBlock"" Property=""Foreground"" Value=""#D0E0FF"" />
                        </Trigger>
                        <Trigger Property=""IsEnabled"" Value=""False"">
                            <Setter Property=""Foreground"" Value=""#686870"" />
                            <Setter TargetName=""GestureBlock"" Property=""Foreground"" Value=""#55555C"" />
                            <Setter TargetName=""SubmenuArrow"" Property=""Stroke"" Value=""#55555C"" />
                            <Setter TargetName=""IconPresenter"" Property=""Opacity"" Value=""0.35"" />
                        </Trigger>
                        <MultiTrigger>
                            <MultiTrigger.Conditions>
                                <Condition Property=""IsHighlighted"" Value=""True"" />
                                <Condition Property=""IsEnabled"" Value=""False"" />
                            </MultiTrigger.Conditions>
                            <Setter TargetName=""ItemBorder"" Property=""Background"" Value=""Transparent"" />
                        </MultiTrigger>
                    </ControlTemplate.Triggers>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
</ResourceDictionary>";

            _darkMenuResourceDictionary = (ResourceDictionary)System.Windows.Markup.XamlReader.Parse(xaml);
            return _darkMenuResourceDictionary;
        }

        private static FrameworkElement CreateColorBoxIcon(Color color)
        {
            return new Border
            {
                Width = 13,
                Height = 13,
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x11, 0x11, 0x15)),
                BorderThickness = new Thickness(1),
                Background = new SolidColorBrush(color),
                CornerRadius = new CornerRadius(1.5),
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };
        }

        private static MenuItem CreateProMenuItem(string header, string gesture = "", System.Action? onClick = null, bool isEnabled = true, FrameworkElement? icon = null)
        {
            var item = new MenuItem
            {
                Header = header,
                InputGestureText = gesture,
                IsEnabled = isEnabled
            };
            if (icon != null) item.Icon = icon;
            if (onClick != null) item.Click += (_, _) => onClick();
            return item;
        }

        private static MenuItem CreateProSubMenu(string header, FrameworkElement? icon = null)
        {
            var item = new MenuItem
            {
                Header = header
            };
            if (icon != null) item.Icon = icon;
            return item;
        }

        private static Separator CreateProSeparator()
        {
            return new Separator();
        }

        private static void ApplyThemeToSlide(SlideItemModel slide, ThemeTemplateModel theme)
        {
            if (theme.SlideBackgroundColor.A > 0)
            {
                slide.HasCustomBackground = true;
                slide.BackgroundColor = theme.SlideBackgroundColor;
            }
            foreach (var el in slide.Elements)
            {
                if (el.Kind == SlideElementKind.Text)
                {
                    el.FontFamily = theme.FontFamily;
                    el.FontSize = theme.FontSize;
                    el.IsBold = theme.IsBold;
                    el.IsUppercase = theme.IsUppercase;
                    el.TextColor = theme.TextColor;
                    el.FillColor = theme.BoxFillColor;
                    el.Y = theme.BoxY;
                    el.Height = theme.BoxHeight;
                }
            }
        }

        private ContextMenu CreateSlideContextMenu(PresentationDocument doc, SlideItemModel slide)
        {
            var darkRes = GetDarkMenuResourceDictionary();
            if (Application.Current != null && !Application.Current.Resources.MergedDictionaries.Contains(darkRes))
            {
                Application.Current.Resources.MergedDictionaries.Add(darkRes);
            }

            var ctx = new ContextMenu();
            ctx.Resources.MergedDictionaries.Add(darkRes);

            // 1. Quick Edit
            ctx.Items.Add(CreateProMenuItem("Quick Edit", "", () => ShowQuickEditDialog(doc, slide)));

            // 2. Edit Slide
            ctx.Items.Add(CreateProMenuItem("Edit Slide", "", () =>
            {
                _selectedEditorSlide = slide;
                _selectedEditorElement = slide.Elements.FirstOrDefault();
                SwitchViewMode(InlineViewMode.Edit);
            }));

            // 3. Disable / Enable
            var disableItem = CreateProMenuItem(slide.IsEnabled ? "Disable" : "Enable", "", () =>
            {
                slide.IsEnabled = !slide.IsEnabled;
                RebuildShowView();
                RefreshPreviewAndOutputs();
                SetStatus($"Slide #{slide.SlideNumber} is now {(slide.IsEnabled ? "enabled" : "disabled")}.");
            });
            ctx.Items.Add(disableItem);

            // 4. Separator
            ctx.Items.Add(CreateProSeparator());

            // 5. Themes >
            var themesSubMenu = CreateProSubMenu("Themes");
            if (_themes != null && _themes.Count > 0)
            {
                foreach (var th in _themes)
                {
                    var capturedTheme = th;
                    themesSubMenu.Items.Add(CreateProMenuItem(capturedTheme.Name, "", () =>
                    {
                        ApplyThemeToSlide(slide, capturedTheme);
                        RebuildShowView();
                        RefreshPreviewAndOutputs();
                        SetStatus($"Applied theme '{capturedTheme.Name}' to slide #{slide.SlideNumber}.");
                    }));
                }
            }
            else
            {
                themesSubMenu.Items.Add(CreateProMenuItem("Vivid Dark", "", () => SetStatus("Applied Vivid Dark theme.")));
                themesSubMenu.Items.Add(CreateProMenuItem("Lower Thirds", "", () => SetStatus("Applied Lower Thirds theme.")));
                themesSubMenu.Items.Add(CreateProMenuItem("Scripture Center", "", () => SetStatus("Applied Scripture Center theme.")));
                themesSubMenu.Items.Add(CreateProMenuItem("Minimal Light", "", () => SetStatus("Applied Minimal Light theme.")));
            }
            themesSubMenu.Items.Add(CreateProSeparator());
            themesSubMenu.Items.Add(CreateProMenuItem("Theme Editor...", "", () => SwitchViewMode(InlineViewMode.ThemeEditor)));
            ctx.Items.Add(themesSubMenu);

            // 6. Transitions...
            ctx.Items.Add(CreateProMenuItem("Transitions...", "", () => ShowSlideTransitionDialog(slide)));

            // 7. Hot Key...
            ctx.Items.Add(CreateProMenuItem("Hot Key...", "", () => ShowSlideHotkeyDialog(slide)));

            // 8. Go to Next Timer...
            ctx.Items.Add(CreateProMenuItem("Go to Next Timer...", "", () => ShowSlideGoToNextTimerDialog(slide)));

            // 9. Add Action >
            var addActionMenu = CreateProSubMenu("Add Action");

            // 9a. Clear >
            var clearSub = CreateProSubMenu("Clear");
            clearSub.Items.Add(CreateProMenuItem("Clear All", "", () => { slide.AttachedAction = "Clear All"; SetStatus($"Slide #{slide.SlideNumber}: Attached Clear All Action."); }));
            clearSub.Items.Add(CreateProMenuItem("Clear Audio", "", () => { slide.AttachedAction = "Clear Audio"; SetStatus($"Slide #{slide.SlideNumber}: Attached Clear Audio Action."); }));
            clearSub.Items.Add(CreateProMenuItem("Clear Background", "", () => { slide.AttachedAction = "Clear Background"; SetStatus($"Slide #{slide.SlideNumber}: Attached Clear Background Action."); }));
            clearSub.Items.Add(CreateProMenuItem("Clear Live Video", "", () => { slide.AttachedAction = "Clear Live Video"; SetStatus($"Slide #{slide.SlideNumber}: Attached Clear Live Video Action."); }));
            clearSub.Items.Add(CreateProMenuItem("Clear Props", "", () => { slide.AttachedAction = "Clear Props"; SetStatus($"Slide #{slide.SlideNumber}: Attached Clear Props Action."); }));
            clearSub.Items.Add(CreateProMenuItem("Clear Slide", "", () => { slide.AttachedAction = "Clear Slide"; SetStatus($"Slide #{slide.SlideNumber}: Attached Clear Slide Action."); }));
            clearSub.Items.Add(CreateProMenuItem("Clear Messages", "", () => { slide.AttachedAction = "Clear Messages"; SetStatus($"Slide #{slide.SlideNumber}: Attached Clear Messages Action."); }));
            clearSub.Items.Add(CreateProMenuItem("Clear Announcements", "", () => { slide.AttachedAction = "Clear Announcements"; SetStatus($"Slide #{slide.SlideNumber}: Attached Clear Announcements Action."); }));
            addActionMenu.Items.Add(clearSub);

            // 9b. Audience Look >
            var lookSub = CreateProSubMenu("Audience Look");
            lookSub.Items.Add(CreateProMenuItem("Default Fullscreen", "", () => { slide.AttachedAction = "Look: Default Fullscreen"; SetStatus($"Slide #{slide.SlideNumber}: Attached Default Look Action."); }));
            lookSub.Items.Add(CreateProMenuItem("Lower Thirds Look", "", () => { slide.AttachedAction = "Look: Lower Thirds Look"; SetStatus($"Slide #{slide.SlideNumber}: Attached Lower Thirds Look Action."); }));
            lookSub.Items.Add(CreateProMenuItem("Broadcast Look", "", () => { slide.AttachedAction = "Look: Broadcast Look"; SetStatus($"Slide #{slide.SlideNumber}: Attached Broadcast Look Action."); }));
            lookSub.Items.Add(CreateProMenuItem("Full Stage Look", "", () => { slide.AttachedAction = "Look: Full Stage Look"; SetStatus($"Slide #{slide.SlideNumber}: Attached Full Stage Look Action."); }));
            addActionMenu.Items.Add(lookSub);

            // 9c. Stage Layout >
            var stageSub = CreateProSubMenu("Stage Layout");
            stageSub.Items.Add(CreateProMenuItem("Default Layout", "", () => { slide.AttachedAction = "Stage: Default Layout"; SetStatus($"Slide #{slide.SlideNumber}: Attached Default Stage Layout Action."); }));
            stageSub.Items.Add(CreateProMenuItem("Current & Next", "", () => { slide.AttachedAction = "Stage: Current & Next"; SetStatus($"Slide #{slide.SlideNumber}: Attached Current & Next Stage Action."); }));
            stageSub.Items.Add(CreateProMenuItem("Lyrics Large", "", () => { slide.AttachedAction = "Stage: Lyrics Large"; SetStatus($"Slide #{slide.SlideNumber}: Attached Lyrics Large Stage Action."); }));
            stageSub.Items.Add(CreateProMenuItem("Speaker Clock", "", () => { slide.AttachedAction = "Stage: Speaker Clock"; SetStatus($"Slide #{slide.SlideNumber}: Attached Speaker Clock Stage Action."); }));
            addActionMenu.Items.Add(stageSub);

            // 9d. Slide Destination >
            var destSub = CreateProSubMenu("Slide Destination");
            destSub.Items.Add(CreateProMenuItem("Audience & Stage", "", () => { slide.AttachedAction = "Destination: Audience & Stage"; SetStatus($"Slide #{slide.SlideNumber}: Destination Audience & Stage."); }));
            destSub.Items.Add(CreateProMenuItem("Audience Only", "", () => { slide.AttachedAction = "Destination: Audience Only"; SetStatus($"Slide #{slide.SlideNumber}: Destination Audience Only."); }));
            destSub.Items.Add(CreateProMenuItem("Stage Only", "", () => { slide.AttachedAction = "Destination: Stage Only"; SetStatus($"Slide #{slide.SlideNumber}: Destination Stage Only."); }));
            addActionMenu.Items.Add(destSub);

            // 9e. Timer >
            var timerSub = CreateProSubMenu("Timer");
            timerSub.Items.Add(CreateProMenuItem("Countdown (5:00)", "", () => { slide.AttachedAction = "Timer: 5m Countdown"; SetStatus($"Slide #{slide.SlideNumber}: Attached 5m Countdown Action."); }));
            timerSub.Items.Add(CreateProMenuItem("Elapsed Service Timer", "", () => { slide.AttachedAction = "Timer: Elapsed Service Timer"; SetStatus($"Slide #{slide.SlideNumber}: Attached Elapsed Timer Action."); }));
            timerSub.Items.Add(CreateProMenuItem("Pre-Service Clock", "", () => { slide.AttachedAction = "Timer: Pre-Service Clock"; SetStatus($"Slide #{slide.SlideNumber}: Attached Pre-Service Clock Action."); }));
            addActionMenu.Items.Add(timerSub);

            // 9f. Props >
            var propsSub = CreateProSubMenu("Props");
            propsSub.Items.Add(CreateProMenuItem("Logo Bug", "", () => { slide.AttachedAction = "Prop: Logo Bug"; SetStatus($"Slide #{slide.SlideNumber}: Attached Logo Bug Prop Action."); }));
            propsSub.Items.Add(CreateProMenuItem("Lower Third Bar", "", () => { slide.AttachedAction = "Prop: Lower Third Bar"; SetStatus($"Slide #{slide.SlideNumber}: Attached Lower Third Bar Prop Action."); }));
            propsSub.Items.Add(CreateProMenuItem("Off / Clear Props", "", () => { slide.AttachedAction = "Prop: Clear"; SetStatus($"Slide #{slide.SlideNumber}: Attached Clear Props Action."); }));
            addActionMenu.Items.Add(propsSub);

            // 9g. Messages >
            var msgSub = CreateProSubMenu("Messages");
            msgSub.Items.Add(CreateProMenuItem("Welcome Alert", "", () => { slide.AttachedAction = "Message: Welcome Alert"; SetStatus($"Slide #{slide.SlideNumber}: Attached Welcome Message Action."); }));
            msgSub.Items.Add(CreateProMenuItem("Nursery Alert", "", () => { slide.AttachedAction = "Message: Nursery Alert"; SetStatus($"Slide #{slide.SlideNumber}: Attached Nursery Message Action."); }));
            addActionMenu.Items.Add(msgSub);

            // 9h. Communication >
            var commSub = CreateProSubMenu("Communication");
            commSub.Items.Add(CreateProMenuItem("MIDI Note On (Cue)", "", () => { slide.AttachedAction = "MIDI: Note On"; SetStatus($"Slide #{slide.SlideNumber}: Attached MIDI Cue Action."); }));
            commSub.Items.Add(CreateProMenuItem("OSC Command", "", () => { slide.AttachedAction = "OSC: Command"; SetStatus($"Slide #{slide.SlideNumber}: Attached OSC Command Action."); }));
            addActionMenu.Items.Add(commSub);

            // 9i. Macro >
            var macroSub = CreateProSubMenu("Macro");
            macroSub.Items.Add(CreateProMenuItem("Start Service", "", () => { slide.AttachedAction = "Macro: Start Service"; SetStatus($"Slide #{slide.SlideNumber}: Attached Start Service Macro."); }));
            macroSub.Items.Add(CreateProMenuItem("Sermon Setup", "", () => { slide.AttachedAction = "Macro: Sermon Setup"; SetStatus($"Slide #{slide.SlideNumber}: Attached Sermon Setup Macro."); }));
            addActionMenu.Items.Add(macroSub);

            addActionMenu.Items.Add(CreateProSeparator());
            addActionMenu.Items.Add(CreateProMenuItem("Action Palette...", "", () => SetStatus("Opened Action Palette.")));
            ctx.Items.Add(addActionMenu);

            // 10. Add Media Action...
            ctx.Items.Add(CreateProMenuItem("Add Media Action...", "", () => PromptAddMediaAction(slide)));

            // 11. Group >
            var groupSubMenu = CreateProSubMenu("Group");
            groupSubMenu.Items.Add(CreateProMenuItem("Edit...", "", () => ShowEditGroupDialog(doc, slide)));
            groupSubMenu.Items.Add(CreateProMenuItem("Ungroup", "", () =>
            {
                slide.GroupName = "";
                slide.GroupColor = Colors.Transparent;
                slide.IsFirstInGroup = false;
                RebuildShowView();
                SetStatus($"Slide #{slide.SlideNumber} ungrouped.");
            }));
            groupSubMenu.Items.Add(CreateProSeparator());

            (string gName, Color gColor)[] groupDefs =
            {
                ("Verse 1", Color.FromRgb(0x00, 0x77, 0xCC)),
                ("Verse 2", Color.FromRgb(0x00, 0x59, 0x99)),
                ("Verse 3", Color.FromRgb(0x00, 0x8B, 0x8B)),
                ("Chorus", Color.FromRgb(0xCC, 0x00, 0x4E)),
                ("Pre-Chorus", Color.FromRgb(0xD9, 0x6B, 0x00)),
                ("Bridge", Color.FromRgb(0x76, 0x00, 0xCC)),
                ("Tag", Color.FromRgb(0x2E, 0x99, 0x00)),
                ("Outro", Color.FromRgb(0x8B, 0x00, 0x00)),
                ("Intro", Color.FromRgb(0xD4, 0xAF, 0x37)),
                ("Blank", Color.FromRgb(0x55, 0x55, 0x55))
            };

            foreach (var g in groupDefs)
            {
                var gItem = CreateProMenuItem(g.gName, "", () =>
                {
                    slide.GroupName = g.gName;
                    slide.GroupColor = g.gColor;
                    RenumberSlides(doc);
                    RebuildShowView();
                    SetStatus($"Set Slide #{slide.SlideNumber} group to '{g.gName}'.");
                }, icon: CreateColorBoxIcon(g.gColor));
                groupSubMenu.Items.Add(gItem);
            }
            groupSubMenu.Items.Add(CreateProSeparator());
            groupSubMenu.Items.Add(CreateProMenuItem("Preferences...", "", () => OpenSettingsWindow("Groups")));
            ctx.Items.Add(groupSubMenu);

            // 12. Label >
            var labelSubMenu = CreateProSubMenu("Label");
            labelSubMenu.Items.Add(CreateProMenuItem("Edit...", "", () => ShowEditLabelDialog(doc, slide)));
            labelSubMenu.Items.Add(CreateProMenuItem("None", "", () =>
            {
                slide.Label = "";
                RebuildShowView();
                SetStatus($"Cleared label for slide #{slide.SlideNumber}.");
            }));
            labelSubMenu.Items.Add(CreateProSeparator());

            (string lName, Color lColor)[] labelDefs =
            {
                ("Intro", Color.FromRgb(0xD4, 0xAF, 0x37)),
                ("Verse", Color.FromRgb(0x00, 0x77, 0xCC)),
                ("Chorus", Color.FromRgb(0xCC, 0x00, 0x4E)),
                ("Solo", Color.FromRgb(0xD9, 0x6B, 0x00)),
                ("Ending", Color.FromRgb(0x2E, 0x99, 0x00))
            };

            foreach (var l in labelDefs)
            {
                var lItem = CreateProMenuItem(l.lName, "", () =>
                {
                    slide.Label = l.lName;
                    RebuildShowView();
                    SetStatus($"Set Slide #{slide.SlideNumber} label to '{l.lName}'.");
                }, icon: CreateColorBoxIcon(l.lColor));
                labelSubMenu.Items.Add(lItem);
            }
            labelSubMenu.Items.Add(CreateProSeparator());
            labelSubMenu.Items.Add(CreateProMenuItem("Preferences...", "", () => OpenSettingsWindow("Slide Labels")));
            ctx.Items.Add(labelSubMenu);

            // 13. Separator
            ctx.Items.Add(CreateProSeparator());

            // 14. Copy Text Style (Alt+Shift+C)
            ctx.Items.Add(CreateProMenuItem("Copy Text Style", "Alt+Shift+C", () =>
            {
                var el = slide.Elements.Find(e => e.Kind == SlideElementKind.Text) ?? slide.Elements.FirstOrDefault();
                if (el != null)
                {
                    _copiedTextStyle = (el.FontFamily, el.FontSize, el.TextColor, el.IsBold, el.IsItalic, el.IsUppercase);
                    SetStatus($"Copied Text Style: {el.FontFamily} {el.FontSize:0}pt.");
                }
            }));

            // 15. Paste Text Style (Alt+Shift+V)
            var pasteStyleItem = CreateProMenuItem("Paste Text Style", "Alt+Shift+V", () =>
            {
                if (_copiedTextStyle != null)
                {
                    var style = _copiedTextStyle.Value;
                    foreach (var el in slide.Elements)
                    {
                        if (el.Kind == SlideElementKind.Text)
                        {
                            el.FontFamily = style.FontFamily;
                            el.FontSize = style.FontSize;
                            el.TextColor = style.TextColor;
                            el.IsBold = style.Bold;
                            el.IsItalic = style.Italic;
                            el.IsUppercase = style.Underline;
                        }
                    }
                    RebuildShowView();
                    RefreshPreviewAndOutputs();
                    SetStatus($"Applied copied text style to slide #{slide.SlideNumber}.");
                }
            }, isEnabled: _copiedTextStyle != null);
            ctx.Items.Add(pasteStyleItem);

            // 16. Separator
            ctx.Items.Add(CreateProSeparator());

            // 17. Cut (Ctrl+X)
            ctx.Items.Add(CreateProMenuItem("Cut", "Ctrl+X", () =>
            {
                _clipboardSlide = slide.Clone();
                if (doc.Slides.Count > 1)
                {
                    doc.Slides.Remove(slide);
                    RenumberSlides(doc);
                    RebuildShowView();
                    RefreshPreviewAndOutputs();
                    SetStatus($"Cut slide #{slide.SlideNumber}.");
                }
            }));

            // 18. Copy (Ctrl+C)
            ctx.Items.Add(CreateProMenuItem("Copy", "Ctrl+C", () =>
            {
                _clipboardSlide = slide.Clone();
                SetStatus($"Copied slide #{slide.SlideNumber}.");
            }));

            // 19. Paste (Ctrl+V)
            var pasteItem = CreateProMenuItem("Paste", "Ctrl+V", () =>
            {
                if (_clipboardSlide != null)
                {
                    int idx = doc.Slides.IndexOf(slide);
                    var clone = _clipboardSlide.Clone();
                    if (idx >= 0 && idx < doc.Slides.Count)
                    {
                        doc.Slides.Insert(idx + 1, clone);
                    }
                    else
                    {
                        doc.Slides.Add(clone);
                    }
                    RenumberSlides(doc);
                    RebuildShowView();
                    RefreshPreviewAndOutputs();
                    SetStatus($"Pasted slide after slide #{slide.SlideNumber}.");
                }
            }, isEnabled: _clipboardSlide != null);
            ctx.Items.Add(pasteItem);

            // 20. Delete (Delete)
            ctx.Items.Add(CreateProMenuItem("Delete", "Delete", () =>
            {
                if (doc.Slides.Count > 1)
                {
                    doc.Slides.Remove(slide);
                    RenumberSlides(doc);
                    RebuildShowView();
                    RefreshPreviewAndOutputs();
                    SetStatus($"Deleted slide #{slide.SlideNumber}.");
                }
            }));

            // Dynamically refresh disabled items when menu opens
            ctx.Opened += (_, _) =>
            {
                pasteStyleItem.IsEnabled = (_copiedTextStyle != null);
                pasteItem.IsEnabled = (_clipboardSlide != null);
                disableItem.Header = slide.IsEnabled ? "Disable" : "Enable";
            };

            return ctx;
        }

        // --- Dialog Helpers for Context Menu ---

        private void ShowQuickEditDialog(PresentationDocument doc, SlideItemModel slide)
        {
            var dlg = new Window
            {
                Title = $"Quick Edit — Slide {slide.SlideNumber} ({slide.GroupName})",
                Width = 560,
                Height = 440,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Owner = this,
                Background = new SolidColorBrush(Color.FromRgb(0x22, 0x22, 0x27)),
                Foreground = Brushes.White,
                FontFamily = new FontFamily("Segoe UI")
            };

            var mainDock = new DockPanel { Margin = new Thickness(16) };

            var headerDock = new DockPanel { Margin = new Thickness(0, 0, 0, 12) };
            DockPanel.SetDock(headerDock, Dock.Top);

            var groupBadge = new Border
            {
                Background = new SolidColorBrush(slide.GroupColor),
                CornerRadius = new CornerRadius(3),
                Padding = new Thickness(8, 3, 8, 3),
                VerticalAlignment = VerticalAlignment.Center,
                Child = new TextBlock
                {
                    Text = slide.GroupName,
                    Foreground = Brushes.White,
                    FontSize = 11,
                    FontWeight = FontWeights.Bold
                }
            };
            DockPanel.SetDock(groupBadge, Dock.Right);
            headerDock.Children.Add(groupBadge);

            var titleTb = new TextBlock
            {
                Text = $"Slide #{slide.SlideNumber} Text Content",
                FontSize = 15,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.White,
                VerticalAlignment = VerticalAlignment.Center
            };
            headerDock.Children.Add(titleTb);
            mainDock.Children.Add(headerDock);

            var btnDock = new DockPanel { Margin = new Thickness(0, 12, 0, 0) };
            DockPanel.SetDock(btnDock, Dock.Bottom);

            var hintTb = new TextBlock
            {
                Text = "Press Ctrl+Enter to Save & Apply",
                Foreground = new SolidColorBrush(Color.FromRgb(0x9E, 0x9E, 0xA8)),
                FontSize = 11.5,
                VerticalAlignment = VerticalAlignment.Center
            };
            btnDock.Children.Add(hintTb);

            var btnStack = new StackPanel { Orientation = Orientation.Horizontal, HorizontalAlignment = HorizontalAlignment.Right };
            var cancelBtn = CreateSmallHeaderButton("Cancel", Color.FromRgb(0x3E, 0x3E, 0x46), () => dlg.Close());
            cancelBtn.Margin = new Thickness(0, 0, 8, 0);
            btnStack.Children.Add(cancelBtn);

            var notesBorder = new Border
            {
                Margin = new Thickness(0, 8, 0, 0),
                Background = new SolidColorBrush(Color.FromRgb(0x18, 0x18, 0x1C)),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x3E, 0x3E, 0x46)),
                BorderThickness = new Thickness(1),
                CornerRadius = new CornerRadius(4),
                Padding = new Thickness(6, 4, 6, 4),
                Height = 65
            };
            DockPanel.SetDock(notesBorder, Dock.Bottom);

            var notesBox = new TextBox
            {
                Text = slide.Notes,
                Background = Brushes.Transparent,
                Foreground = new SolidColorBrush(Color.FromRgb(0xDD, 0xDD, 0xE0)),
                CaretBrush = Brushes.White,
                BorderThickness = new Thickness(0),
                FontSize = 12,
                AcceptsReturn = true,
                TextWrapping = TextWrapping.Wrap
            };
            notesBorder.Child = notesBox;

            var textBorder = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(0x16, 0x16, 0x1A)),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x3E, 0x3E, 0x46)),
                BorderThickness = new Thickness(1),
                CornerRadius = new CornerRadius(4),
                Padding = new Thickness(8)
            };
            var textBox = new TextBox
            {
                Text = slide.PrimaryText,
                Background = Brushes.Transparent,
                Foreground = Brushes.White,
                CaretBrush = Brushes.White,
                BorderThickness = new Thickness(0),
                FontSize = 15,
                FontWeight = FontWeights.Medium,
                AcceptsReturn = true,
                TextWrapping = TextWrapping.Wrap,
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto
            };

            var saveBtn = CreateSmallHeaderButton("Save & Close", Color.FromRgb(0x00, 0x7A, 0xFF), () =>
            {
                slide.PrimaryText = textBox.Text;
                slide.Notes = notesBox.Text;
                RebuildShowView();
                RefreshPreviewAndOutputs();
                SetStatus($"Quick Edit updated slide #{slide.SlideNumber}.");
                dlg.Close();
            });
            btnStack.Children.Add(saveBtn);
            DockPanel.SetDock(btnStack, Dock.Right);
            btnDock.Children.Add(btnStack);
            mainDock.Children.Add(btnDock);

            var notesLabel = new TextBlock
            {
                Text = "Slide Notes / Stage Prompter:",
                FontSize = 11,
                Foreground = new SolidColorBrush(Color.FromRgb(0xA8, 0xA8, 0xB2)),
                Margin = new Thickness(0, 8, 0, 2)
            };
            DockPanel.SetDock(notesLabel, Dock.Bottom);
            mainDock.Children.Add(notesLabel);
            mainDock.Children.Add(notesBorder);

            textBox.KeyDown += (_, e) =>
            {
                if (e.Key == Key.Enter && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                {
                    saveBtn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    e.Handled = true;
                }
            };
            textBorder.Child = textBox;
            mainDock.Children.Add(textBorder);

            dlg.Content = mainDock;
            dlg.Loaded += (_, _) =>
            {
                textBox.Focus();
                textBox.SelectAll();
            };
            dlg.ShowDialog();
        }

        private void ShowSlideTransitionDialog(SlideItemModel slide)
        {
            var dlg = new Window
            {
                Title = $"Slide Transition — Slide #{slide.SlideNumber}",
                Width = 420,
                Height = 310,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Owner = this,
                Background = new SolidColorBrush(Color.FromRgb(0x22, 0x22, 0x27)),
                Foreground = Brushes.White
            };

            var stack = new StackPanel { Margin = new Thickness(18) };

            stack.Children.Add(new TextBlock
            {
                Text = "Select Slide Transition Effect:",
                FontSize = 13.5,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.White,
                Margin = new Thickness(0, 0, 0, 10)
            });

            var transitionCombo = new ComboBox
            {
                Height = 30,
                Margin = new Thickness(0, 0, 0, 14),
                FontSize = 12.5
            };
            string[] transitions = { "Cut", "Dissolve", "Wipe (Left to Right)", "Push (Up)", "Spin", "Zoom", "Fly In" };
            foreach (var t in transitions)
            {
                transitionCombo.Items.Add(t);
                if (t.StartsWith(slide.TransitionName, StringComparison.OrdinalIgnoreCase))
                    transitionCombo.SelectedItem = t;
            }
            if (transitionCombo.SelectedItem == null)
                transitionCombo.SelectedIndex = 1;
            stack.Children.Add(transitionCombo);

            stack.Children.Add(new TextBlock
            {
                Text = "Transition Duration (Seconds):",
                FontSize = 12,
                Foreground = new SolidColorBrush(Color.FromRgb(0xC0, 0xC0, 0xCA)),
                Margin = new Thickness(0, 0, 0, 6)
            });

            var durBox = new TextBox
            {
                Text = slide.TransitionDurationSeconds.ToString("0.##"),
                Height = 28,
                Background = new SolidColorBrush(Color.FromRgb(0x18, 0x18, 0x1C)),
                Foreground = Brushes.White,
                CaretBrush = Brushes.White,
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x44, 0x44, 0x4C)),
                Padding = new Thickness(6, 4, 6, 4),
                Margin = new Thickness(0, 0, 0, 18),
                FontSize = 13
            };
            stack.Children.Add(durBox);

            var btnStack = new StackPanel { Orientation = Orientation.Horizontal, HorizontalAlignment = HorizontalAlignment.Right };
            var cancelBtn = CreateSmallHeaderButton("Cancel", Color.FromRgb(0x3E, 0x3E, 0x46), () => dlg.Close());
            cancelBtn.Margin = new Thickness(0, 0, 8, 0);
            btnStack.Children.Add(cancelBtn);

            var applyBtn = CreateSmallHeaderButton("Apply Transition", Color.FromRgb(0x00, 0x7A, 0xFF), () =>
            {
                slide.TransitionName = transitionCombo.SelectedItem?.ToString()?.Split(' ')[0] ?? "Dissolve";
                if (double.TryParse(durBox.Text, out double dur) && dur >= 0)
                {
                    slide.TransitionDurationSeconds = dur;
                }
                SetStatus($"Set Slide #{slide.SlideNumber} transition to {slide.TransitionName} ({slide.TransitionDurationSeconds:0.##}s).");
                dlg.Close();
            });
            btnStack.Children.Add(applyBtn);
            stack.Children.Add(btnStack);

            dlg.Content = stack;
            dlg.ShowDialog();
        }

        private void ShowSlideHotkeyDialog(SlideItemModel slide)
        {
            var dlg = new Window
            {
                Title = $"Assign Hot Key — Slide #{slide.SlideNumber}",
                Width = 430,
                Height = 310,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Owner = this,
                Background = new SolidColorBrush(Color.FromRgb(0x22, 0x22, 0x27)),
                Foreground = Brushes.White
            };

            var stack = new StackPanel { Margin = new Thickness(18) };
            stack.Children.Add(new TextBlock
            {
                Text = $"Assign Hot Key to Slide #{slide.SlideNumber}:",
                FontSize = 14,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.White,
                Margin = new Thickness(0, 0, 0, 6)
            });
            stack.Children.Add(new TextBlock
            {
                Text = "Pressing this key triggers this slide immediately during a live service.",
                FontSize = 11.5,
                Foreground = new SolidColorBrush(Color.FromRgb(0xAA, 0xAA, 0xB4)),
                Margin = new Thickness(0, 0, 0, 14)
            });

            var hkCombo = new ComboBox { Height = 30, Margin = new Thickness(0, 0, 0, 20), FontSize = 13 };
            hkCombo.Items.Add("None (Clear Hot Key)");
            string[] keys = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            foreach (var k in keys)
            {
                hkCombo.Items.Add($"Key: {k}");
                if (string.Equals(slide.HotKey, k, StringComparison.OrdinalIgnoreCase))
                    hkCombo.SelectedItem = $"Key: {k}";
            }
            if (hkCombo.SelectedItem == null)
                hkCombo.SelectedIndex = 0;
            stack.Children.Add(hkCombo);

            var btnStack = new StackPanel { Orientation = Orientation.Horizontal, HorizontalAlignment = HorizontalAlignment.Right };
            var cancelBtn = CreateSmallHeaderButton("Cancel", Color.FromRgb(0x3E, 0x3E, 0x46), () => dlg.Close());
            cancelBtn.Margin = new Thickness(0, 0, 8, 0);
            btnStack.Children.Add(cancelBtn);

            var applyBtn = CreateSmallHeaderButton("Save Hot Key", Color.FromRgb(0x00, 0x7A, 0xFF), () =>
            {
                string sel = hkCombo.SelectedItem?.ToString() ?? "";
                slide.HotKey = sel.StartsWith("Key: ") ? sel.Substring(5).Trim() : "";
                RebuildShowView();
                SetStatus($"Slide #{slide.SlideNumber} hot key set to '{(string.IsNullOrEmpty(slide.HotKey) ? "None" : slide.HotKey)}'.");
                dlg.Close();
            });
            btnStack.Children.Add(applyBtn);
            stack.Children.Add(btnStack);

            dlg.Content = stack;
            dlg.ShowDialog();
        }

        private void ShowSlideGoToNextTimerDialog(SlideItemModel slide)
        {
            var dlg = new Window
            {
                Title = $"Go to Next Timer — Slide #{slide.SlideNumber}",
                Width = 430,
                Height = 310,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Owner = this,
                Background = new SolidColorBrush(Color.FromRgb(0x22, 0x22, 0x27)),
                Foreground = Brushes.White
            };

            var stack = new StackPanel { Margin = new Thickness(18) };
            stack.Children.Add(new TextBlock
            {
                Text = "Automatic Go to Next Slide Timer:",
                FontSize = 14,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.White,
                Margin = new Thickness(0, 0, 0, 6)
            });
            stack.Children.Add(new TextBlock
            {
                Text = "Automatically triggers the next slide after the specified number of seconds.",
                FontSize = 11.5,
                Foreground = new SolidColorBrush(Color.FromRgb(0xAA, 0xAA, 0xB4)),
                Margin = new Thickness(0, 0, 0, 14)
            });

            var timerCombo = new ComboBox { Height = 30, Margin = new Thickness(0, 0, 0, 12), FontSize = 13 };
            timerCombo.Items.Add("Off (No Timer)");
            timerCombo.Items.Add("2 Seconds");
            timerCombo.Items.Add("3 Seconds");
            timerCombo.Items.Add("5 Seconds");
            timerCombo.Items.Add("7 Seconds");
            timerCombo.Items.Add("10 Seconds");
            timerCombo.Items.Add("15 Seconds");
            timerCombo.Items.Add("30 Seconds");
            timerCombo.Items.Add("Custom Seconds...");

            if (slide.NextTimerSeconds <= 0)
                timerCombo.SelectedIndex = 0;
            else if (slide.NextTimerSeconds == 2) timerCombo.SelectedIndex = 1;
            else if (slide.NextTimerSeconds == 3) timerCombo.SelectedIndex = 2;
            else if (slide.NextTimerSeconds == 5) timerCombo.SelectedIndex = 3;
            else if (slide.NextTimerSeconds == 7) timerCombo.SelectedIndex = 4;
            else if (slide.NextTimerSeconds == 10) timerCombo.SelectedIndex = 5;
            else if (slide.NextTimerSeconds == 15) timerCombo.SelectedIndex = 6;
            else if (slide.NextTimerSeconds == 30) timerCombo.SelectedIndex = 7;
            else timerCombo.SelectedIndex = 8;
            stack.Children.Add(timerCombo);

            var customBox = new TextBox
            {
                Text = slide.NextTimerSeconds > 0 ? slide.NextTimerSeconds.ToString("0.#") : "5.0",
                Height = 28,
                Background = new SolidColorBrush(Color.FromRgb(0x18, 0x18, 0x1C)),
                Foreground = Brushes.White,
                CaretBrush = Brushes.White,
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x44, 0x44, 0x4C)),
                Padding = new Thickness(6, 4, 6, 4),
                Margin = new Thickness(0, 0, 0, 16),
                FontSize = 13,
                Visibility = timerCombo.SelectedIndex == 8 ? Visibility.Visible : Visibility.Collapsed
            };
            stack.Children.Add(customBox);

            timerCombo.SelectionChanged += (_, _) =>
            {
                customBox.Visibility = timerCombo.SelectedIndex == 8 ? Visibility.Visible : Visibility.Collapsed;
            };

            var btnStack = new StackPanel { Orientation = Orientation.Horizontal, HorizontalAlignment = HorizontalAlignment.Right };
            var cancelBtn = CreateSmallHeaderButton("Cancel", Color.FromRgb(0x3E, 0x3E, 0x46), () => dlg.Close());
            cancelBtn.Margin = new Thickness(0, 0, 8, 0);
            btnStack.Children.Add(cancelBtn);

            var applyBtn = CreateSmallHeaderButton("Apply Timer", Color.FromRgb(0x00, 0x7A, 0xFF), () =>
            {
                double seconds = 0;
                switch (timerCombo.SelectedIndex)
                {
                    case 0: seconds = 0; break;
                    case 1: seconds = 2; break;
                    case 2: seconds = 3; break;
                    case 3: seconds = 5; break;
                    case 4: seconds = 7; break;
                    case 5: seconds = 10; break;
                    case 6: seconds = 15; break;
                    case 7: seconds = 30; break;
                    case 8:
                        if (double.TryParse(customBox.Text, out double c) && c > 0) seconds = c;
                        break;
                }
                slide.NextTimerSeconds = seconds;
                RebuildShowView();
                SetStatus(seconds > 0
                    ? $"Slide #{slide.SlideNumber} will advance to next slide after {seconds:0.#}s."
                    : $"Disabled Go to Next Timer on slide #{slide.SlideNumber}.");
                dlg.Close();
            });
            btnStack.Children.Add(applyBtn);
            stack.Children.Add(btnStack);

            dlg.Content = stack;
            dlg.ShowDialog();
        }

        private void PromptAddMediaAction(SlideItemModel slide)
        {
            var ofd = new OpenFileDialog
            {
                Title = $"Attach Media Action to Slide #{slide.SlideNumber}",
                Filter = "Media Files (*.mp4;*.mov;*.jpg;*.png;*.jpeg;*.webm)|*.mp4;*.mov;*.jpg;*.png;*.jpeg;*.webm;*.wmv|Images (*.jpg;*.png)|*.jpg;*.jpeg;*.png;*.webp|Videos (*.mp4;*.mov)|*.mp4;*.mov;*.webm|All Files (*.*)|*.*"
            };
            if (ofd.ShowDialog(this) == true)
            {
                slide.BackgroundMediaPath = ofd.FileName;
                slide.HasCustomBackground = true;
                RebuildShowView();
                RefreshPreviewAndOutputs();
                SetStatus($"Attached media action '{Path.GetFileName(ofd.FileName)}' to slide #{slide.SlideNumber}.");
            }
        }

        private void ShowEditGroupDialog(PresentationDocument doc, SlideItemModel slide)
        {
            var dlg = new Window
            {
                Title = "Edit Slide Group",
                Width = 400,
                Height = 310,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Owner = this,
                Background = new SolidColorBrush(Color.FromRgb(0x22, 0x22, 0x27)),
                Foreground = Brushes.White
            };

            var stack = new StackPanel { Margin = new Thickness(18) };
            stack.Children.Add(new TextBlock
            {
                Text = "Group Name:",
                FontSize = 13,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.White,
                Margin = new Thickness(0, 0, 0, 6)
            });

            var nameBox = new TextBox
            {
                Text = slide.GroupName,
                Height = 28,
                Background = new SolidColorBrush(Color.FromRgb(0x18, 0x18, 0x1C)),
                Foreground = Brushes.White,
                CaretBrush = Brushes.White,
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x44, 0x44, 0x4C)),
                Padding = new Thickness(6, 4, 6, 4),
                Margin = new Thickness(0, 0, 0, 14),
                FontSize = 13
            };
            stack.Children.Add(nameBox);

            stack.Children.Add(new TextBlock
            {
                Text = "Group Color:",
                FontSize = 12,
                Foreground = new SolidColorBrush(Color.FromRgb(0xC0, 0xC0, 0xCA)),
                Margin = new Thickness(0, 0, 0, 8)
            });

            Color chosenColor = slide.GroupColor;
            var colorPanel = new WrapPanel { Margin = new Thickness(0, 0, 0, 20) };
            Color[] palette =
            {
                Color.FromRgb(0x00, 0x77, 0xCC), // Blue
                Color.FromRgb(0x00, 0x59, 0x99), // Steel
                Color.FromRgb(0x00, 0x8B, 0x8B), // Teal
                Color.FromRgb(0xCC, 0x00, 0x4E), // Crimson
                Color.FromRgb(0xD9, 0x6B, 0x00), // Orange
                Color.FromRgb(0x76, 0x00, 0xCC), // Purple
                Color.FromRgb(0x2E, 0x99, 0x00), // Green
                Color.FromRgb(0x8B, 0x00, 0x00), // Dark Red
                Color.FromRgb(0xD4, 0xAF, 0x37), // Gold
                Color.FromRgb(0x55, 0x55, 0x55)  // Grey
            };

            Border? selectedBorder = null;
            foreach (var col in palette)
            {
                var swatch = new Border
                {
                    Width = 24,
                    Height = 24,
                    Margin = new Thickness(0, 0, 8, 8),
                    Background = new SolidColorBrush(col),
                    CornerRadius = new CornerRadius(3),
                    BorderBrush = col == chosenColor ? Brushes.White : Brushes.Transparent,
                    BorderThickness = new Thickness(col == chosenColor ? 2 : 1),
                    Cursor = Cursors.Hand
                };
                if (col == chosenColor) selectedBorder = swatch;
                swatch.MouseLeftButtonDown += (_, _) =>
                {
                    chosenColor = col;
                    if (selectedBorder != null)
                    {
                        selectedBorder.BorderBrush = Brushes.Transparent;
                        selectedBorder.BorderThickness = new Thickness(1);
                    }
                    swatch.BorderBrush = Brushes.White;
                    swatch.BorderThickness = new Thickness(2);
                    selectedBorder = swatch;
                };
                colorPanel.Children.Add(swatch);
            }
            stack.Children.Add(colorPanel);

            var btnStack = new StackPanel { Orientation = Orientation.Horizontal, HorizontalAlignment = HorizontalAlignment.Right };
            var cancelBtn = CreateSmallHeaderButton("Cancel", Color.FromRgb(0x3E, 0x3E, 0x46), () => dlg.Close());
            cancelBtn.Margin = new Thickness(0, 0, 8, 0);
            btnStack.Children.Add(cancelBtn);

            var applyBtn = CreateSmallHeaderButton("Save Group", Color.FromRgb(0x00, 0x7A, 0xFF), () =>
            {
                slide.GroupName = string.IsNullOrWhiteSpace(nameBox.Text) ? "Verse 1" : nameBox.Text.Trim();
                slide.GroupColor = chosenColor;
                RenumberSlides(doc);
                RebuildShowView();
                dlg.Close();
            });
            btnStack.Children.Add(applyBtn);
            stack.Children.Add(btnStack);

            dlg.Content = stack;
            dlg.ShowDialog();
        }

        private void ShowEditLabelDialog(PresentationDocument doc, SlideItemModel slide)
        {
            var dlg = new Window
            {
                Title = "Edit Slide Label",
                Width = 380,
                Height = 240,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Owner = this,
                Background = new SolidColorBrush(Color.FromRgb(0x22, 0x22, 0x27)),
                Foreground = Brushes.White
            };

            var stack = new StackPanel { Margin = new Thickness(18) };
            stack.Children.Add(new TextBlock
            {
                Text = "Slide Label / Cue Tag:",
                FontSize = 13,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.White,
                Margin = new Thickness(0, 0, 0, 6)
            });

            var labelBox = new TextBox
            {
                Text = slide.Label,
                Height = 28,
                Background = new SolidColorBrush(Color.FromRgb(0x18, 0x18, 0x1C)),
                Foreground = Brushes.White,
                CaretBrush = Brushes.White,
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x44, 0x44, 0x4C)),
                Padding = new Thickness(6, 4, 6, 4),
                Margin = new Thickness(0, 0, 0, 20),
                FontSize = 13
            };
            stack.Children.Add(labelBox);

            var btnStack = new StackPanel { Orientation = Orientation.Horizontal, HorizontalAlignment = HorizontalAlignment.Right };
            var cancelBtn = CreateSmallHeaderButton("Cancel", Color.FromRgb(0x3E, 0x3E, 0x46), () => dlg.Close());
            cancelBtn.Margin = new Thickness(0, 0, 8, 0);
            btnStack.Children.Add(cancelBtn);

            var applyBtn = CreateSmallHeaderButton("Save Label", Color.FromRgb(0x00, 0x7A, 0xFF), () =>
            {
                slide.Label = labelBox.Text.Trim();
                RebuildShowView();
                SetStatus($"Slide #{slide.SlideNumber} label set to '{(string.IsNullOrEmpty(slide.Label) ? "None" : slide.Label)}'.");
                dlg.Close();
            });
            btnStack.Children.Add(applyBtn);
            stack.Children.Add(btnStack);

            dlg.Content = stack;
            dlg.ShowDialog();
        }
    }
}

