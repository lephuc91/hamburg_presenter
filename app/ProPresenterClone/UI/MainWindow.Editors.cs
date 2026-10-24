using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using ProPresenterClone.Models;
using ProPresenterClone.Rendering;
using ProPresenterClone.Services;
using ProPresenterClone.Theming;

namespace ProPresenterClone.UI
{
    public sealed partial class MainWindow
    {
        private string _selectedBibleTranslation = "KJV";
        private string _bibleSearchQuery = "John 3:16-17";
        private Point? _dragStartPoint;
        private double _dragStartElemX;
        private double _dragStartElemY;
        private SlideElementModel? _draggingElement;

        // =====================================================================
        // 1. WYSIWYG SLIDE / THEME / PROPS / MASK EDITOR (SlideEditorView.xaml)
        // =====================================================================
        private void RebuildSlideEditorView()
        {
            _centerContentHost.Children.Clear();
            var doc = _selectedPresentation;
            if (doc == null)
                return;

            if (_selectedEditorSlide == null || !doc.Slides.Contains(_selectedEditorSlide))
                _selectedEditorSlide = doc.Slides.FirstOrDefault();

            if (_selectedEditorSlide != null && (_selectedEditorElement == null || !_selectedEditorSlide.Elements.Contains(_selectedEditorElement)))
                _selectedEditorElement = _selectedEditorSlide.Elements.FirstOrDefault();

            var root = new Grid
            {
                Background = new SolidColorBrush(Color.FromRgb(0x18, 0x19, 0x1D))
            };
            root.RowDefinitions.Add(new RowDefinition { Height = new GridLength(40) }); // Editor Toolbar
            root.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }); // 3-Pane Editor Body

            // Top Editor Action Bar
            var topBar = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(0x23, 0x24, 0x2A)),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x36, 0x37, 0x40)),
                BorderThickness = new Thickness(0, 0, 0, 1),
                Padding = new Thickness(12, 5, 12, 5)
            };
            var topDock = new DockPanel();

            string editorModeLabel = _activeViewMode switch
            {
                InlineViewMode.ThemeEditor => "THEME EDITOR",
                InlineViewMode.PropsEditor => "PROPS OVERLAY EDITOR",
                InlineViewMode.MaskEditor => "MASK & KEYING EDITOR",
                _ => "SLIDE CANVAS EDITOR"
            };

            var rightButtons = new StackPanel { Orientation = Orientation.Horizontal, VerticalAlignment = VerticalAlignment.Center };
            rightButtons.Children.Add(CreateSmallHeaderButton("Apply Style to All Slides", Color.FromRgb(0x2E, 0x6F, 0x40), () => ApplyCurrentSlideStyleToAllSlides()));
            rightButtons.Children.Add(CreateSmallHeaderButton("✓ Done (Show View)", Color.FromRgb(0x00, 0x7A, 0xFF), () => SwitchViewMode(InlineViewMode.Show)));
            DockPanel.SetDock(rightButtons, Dock.Right);
            topDock.Children.Add(rightButtons);

            var toolStack = new StackPanel { Orientation = Orientation.Horizontal, VerticalAlignment = VerticalAlignment.Center };
            toolStack.Children.Add(new TextBlock
            {
                Text = $"{editorModeLabel}  •  {doc.Name}   ",
                Foreground = new SolidColorBrush(Color.FromRgb(0xF7, 0x82, 0x1C)),
                FontSize = 12,
                FontWeight = FontWeights.Bold,
                VerticalAlignment = VerticalAlignment.Center
            });

            toolStack.Children.Add(CreateSmallHeaderButton("+ Text Box", Color.FromRgb(0x38, 0x38, 0x44), () => AddEditorElement(SlideElementKind.Text)));
            toolStack.Children.Add(CreateSmallHeaderButton("+ Lower-Third Bar", Color.FromRgb(0x38, 0x38, 0x44), () => AddEditorElement(SlideElementKind.Shape)));
            toolStack.Children.Add(CreateSmallHeaderButton("+ Countdown Token", Color.FromRgb(0x38, 0x38, 0x44), () => AddEditorElement(SlideElementKind.TimerToken)));
            toolStack.Children.Add(CreateSmallHeaderButton("+ Live Clock", Color.FromRgb(0x38, 0x38, 0x44), () => AddEditorElement(SlideElementKind.ClockToken)));
            toolStack.Children.Add(CreateSmallHeaderButton("+ Slide", Color.FromRgb(0x38, 0x38, 0x44), () => AddSlideToCurrentPresentation()));

            topDock.Children.Add(toolStack);
            topBar.Child = topDock;
            Grid.SetRow(topBar, 0);
            root.Children.Add(topBar);

            // 3-Column Editor Workspace: Left Slide Strip (185px) | Center 16:9 Canvas | Right Property Inspector (290px)
            var bodyGrid = new Grid();
            bodyGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(185) });
            bodyGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            bodyGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(305) });

            // Column 0: Slide Thumbnail Strip
            var slideStripBorder = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(0x1E, 0x1F, 0x24)),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x32, 0x33, 0x3C)),
                BorderThickness = new Thickness(0, 0, 1, 0)
            };
            var slideStripScroll = new ScrollViewer
            {
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                Padding = new Thickness(8)
            };
            var slideStripStack = new StackPanel { Orientation = Orientation.Vertical };

            foreach (var slide in doc.Slides)
            {
                var capturedSlide = slide;
                bool isSelected = capturedSlide == _selectedEditorSlide;

                var itemBorder = new Border
                {
                    Margin = new Thickness(0, 0, 0, 8),
                    CornerRadius = new CornerRadius(4),
                    BorderBrush = new SolidColorBrush(isSelected ? Color.FromRgb(0x00, 0x7A, 0xFF) : Color.FromRgb(0x3A, 0x3B, 0x44)),
                    BorderThickness = new Thickness(isSelected ? 2 : 1),
                    Background = new SolidColorBrush(Color.FromRgb(0x14, 0x15, 0x19)),
                    Cursor = Cursors.Hand
                };

                var itemStack = new StackPanel();
                itemStack.Children.Add(SlideCanvasRenderer.RenderSlideThumbnail(capturedSlide, 158, 89, null, _timers));
                itemStack.Children.Add(new Border
                {
                    Background = new SolidColorBrush(Color.FromArgb(140, capturedSlide.GroupColor.R, capturedSlide.GroupColor.G, capturedSlide.GroupColor.B)),
                    Padding = new Thickness(6, 2, 6, 2),
                    Child = new TextBlock
                    {
                        Text = $"{capturedSlide.SlideNumber}. {capturedSlide.GroupName}",
                        Foreground = Brushes.White,
                        FontSize = 10.5,
                        FontWeight = FontWeights.SemiBold,
                        TextTrimming = TextTrimming.CharacterEllipsis
                    }
                });

                itemBorder.Child = itemStack;
                itemBorder.MouseLeftButtonDown += (_, _) =>
                {
                    _selectedEditorSlide = capturedSlide;
                    _selectedEditorElement = capturedSlide.Elements.FirstOrDefault();
                    TriggerSlide(doc, capturedSlide);
                    RebuildSlideEditorView();
                };
                slideStripStack.Children.Add(itemBorder);
            }

            slideStripScroll.Content = slideStripStack;
            slideStripBorder.Child = slideStripScroll;
            Grid.SetColumn(slideStripBorder, 0);
            bodyGrid.Children.Add(slideStripBorder);

            // Column 1: Interactive 16:9 WYSIWYG Canvas Area
            var canvasWorkspace = BuildInteractiveSlideCanvas(doc, _selectedEditorSlide);
            Grid.SetColumn(canvasWorkspace, 1);
            bodyGrid.Children.Add(canvasWorkspace);

            // Column 2: Right Property Inspector
            var inspector = BuildSlidePropertyInspector(doc, _selectedEditorSlide, _selectedEditorElement);
            Grid.SetColumn(inspector, 2);
            bodyGrid.Children.Add(inspector);

            Grid.SetRow(bodyGrid, 1);
            root.Children.Add(bodyGrid);

            _centerContentHost.Children.Add(root);
        }

        private FrameworkElement BuildInteractiveSlideCanvas(PresentationDocument doc, SlideItemModel? slide)
        {
            var outerGrid = new Grid
            {
                Background = new SolidColorBrush(Color.FromRgb(0x13, 0x14, 0x17)),
                ClipToBounds = true
            };

            if (slide == null)
                return outerGrid;

            const double canvasW = 672.0;
            const double canvasH = 378.0; // 16:9 aspect ratio

            var stageContainer = new Border
            {
                Width = canvasW + 4,
                Height = canvasH + 4,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x52, 0x56, 0x66)),
                BorderThickness = new Thickness(2),
                CornerRadius = new CornerRadius(2),
                Background = Brushes.Black
            };

            var canvas = new Canvas
            {
                Width = canvasW,
                Height = canvasH,
                ClipToBounds = true,
                Background = slide.HasCustomBackground
                    ? new SolidColorBrush(slide.BackgroundColor)
                    : new SolidColorBrush(Color.FromRgb(0x10, 0x14, 0x1E))
            };

            // Subtle Rule-of-Thirds & Safe Title Guides
            for (int i = 1; i <= 2; i++)
            {
                canvas.Children.Add(new Line
                {
                    X1 = canvasW * i / 3.0,
                    Y1 = 0,
                    X2 = canvasW * i / 3.0,
                    Y2 = canvasH,
                    Stroke = new SolidColorBrush(Color.FromArgb(35, 255, 255, 255)),
                    StrokeThickness = 1,
                    StrokeDashArray = new DoubleCollection { 4, 4 }
                });
                canvas.Children.Add(new Line
                {
                    X1 = 0,
                    Y1 = canvasH * i / 3.0,
                    X2 = canvasW,
                    Y2 = canvasH * i / 3.0,
                    Stroke = new SolidColorBrush(Color.FromArgb(35, 255, 255, 255)),
                    StrokeThickness = 1,
                    StrokeDashArray = new DoubleCollection { 4, 4 }
                });
            }

            // Render each slide element as an interactive selectable & draggable box
            foreach (var elem in slide.Elements)
            {
                var capturedElem = elem;
                bool isSelected = capturedElem == _selectedEditorElement;

                double x = capturedElem.X * canvasW;
                double y = capturedElem.Y * canvasH;
                double w = Math.Max(40, capturedElem.Width * canvasW);
                double h = Math.Max(30, capturedElem.Height * canvasH);

                var elemVisual = SlideCanvasRenderer.RenderSlideThumbnail(
                    new SlideItemModel
                    {
                        Elements = new List<SlideElementModel>
                        {
                            new SlideElementModel
                            {
                                Kind = capturedElem.Kind,
                                Text = capturedElem.Text,
                                X = 0,
                                Y = 0,
                                Width = 1.0,
                                Height = 1.0,
                                FontFamily = capturedElem.FontFamily,
                                FontSize = capturedElem.FontSize,
                                IsBold = capturedElem.IsBold,
                                IsItalic = capturedElem.IsItalic,
                                IsUppercase = capturedElem.IsUppercase,
                                HorizontalAlignment = capturedElem.HorizontalAlignment,
                                TextColor = capturedElem.TextColor,
                                FillColor = capturedElem.FillColor,
                                StrokeColor = capturedElem.StrokeColor,
                                StrokeThickness = capturedElem.StrokeThickness,
                                HasShadow = capturedElem.HasShadow
                            }
                        }
                    },
                    w,
                    h,
                    null,
                    _timers);

                var selectionBox = new Border
                {
                    Width = w,
                    Height = h,
                    BorderBrush = new SolidColorBrush(isSelected ? Color.FromRgb(0x00, 0xA8, 0xFF) : Color.FromArgb(110, 255, 255, 255)),
                    BorderThickness = new Thickness(isSelected ? 2.0 : 1.0),
                    Cursor = Cursors.SizeAll,
                    Child = elemVisual
                };

                selectionBox.MouseLeftButtonDown += (s, e) =>
                {
                    _selectedEditorElement = capturedElem;
                    _draggingElement = capturedElem;
                    _dragStartPoint = e.GetPosition(canvas);
                    _dragStartElemX = capturedElem.X;
                    _dragStartElemY = capturedElem.Y;
                    selectionBox.CaptureMouse();
                    e.Handled = true;
                };

                selectionBox.MouseMove += (s, e) =>
                {
                    if (_draggingElement == capturedElem && _dragStartPoint.HasValue && e.LeftButton == MouseButtonState.Pressed)
                    {
                        Point cur = e.GetPosition(canvas);
                        double dx = (cur.X - _dragStartPoint.Value.X) / canvasW;
                        double dy = (cur.Y - _dragStartPoint.Value.Y) / canvasH;

                        capturedElem.X = Math.Clamp(_dragStartElemX + dx, 0.0, 1.0 - capturedElem.Width);
                        capturedElem.Y = Math.Clamp(_dragStartElemY + dy, 0.0, 1.0 - capturedElem.Height);

                        Canvas.SetLeft(selectionBox, capturedElem.X * canvasW);
                        Canvas.SetTop(selectionBox, capturedElem.Y * canvasH);
                        RefreshPreviewAndOutputs();
                    }
                };

                selectionBox.MouseLeftButtonUp += (s, e) =>
                {
                    if (_draggingElement == capturedElem)
                    {
                        selectionBox.ReleaseMouseCapture();
                        _draggingElement = null;
                        _dragStartPoint = null;
                        RebuildSlideEditorView();
                        e.Handled = true;
                    }
                };

                Canvas.SetLeft(selectionBox, x);
                Canvas.SetTop(selectionBox, y);
                canvas.Children.Add(selectionBox);
            }

            stageContainer.Child = canvas;
            outerGrid.Children.Add(stageContainer);

            // Overlay hint at bottom of canvas
            outerGrid.Children.Add(new Border
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Bottom,
                Margin = new Thickness(0, 0, 0, 10),
                Padding = new Thickness(10, 3, 10, 3),
                CornerRadius = new CornerRadius(4),
                Background = new SolidColorBrush(Color.FromArgb(190, 24, 25, 30)),
                Child = new TextBlock
                {
                    Text = "1920×1080 (16:9) WYSIWYG Canvas  •  Click & Drag elements to position  •  Changes sync live to Audience Output",
                    Foreground = new SolidColorBrush(Color.FromRgb(0xA4, 0xAC, 0xBC)),
                    FontSize = 11
                }
            });

            return outerGrid;
        }

        private FrameworkElement BuildSlidePropertyInspector(PresentationDocument doc, SlideItemModel? slide, SlideElementModel? elem)
        {
            var border = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(0x21, 0x22, 0x28)),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x34, 0x35, 0x3E)),
                BorderThickness = new Thickness(1, 0, 0, 0)
            };

            var scroll = new ScrollViewer
            {
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                Padding = new Thickness(12)
            };
            var stack = new StackPanel { Orientation = Orientation.Vertical };

            stack.Children.Add(new TextBlock
            {
                Text = "ELEMENT & SLIDE INSPECTOR",
                Foreground = new SolidColorBrush(Color.FromRgb(0xF7, 0x82, 0x1C)),
                FontSize = 11.5,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(0, 0, 0, 10)
            });

            if (slide != null && elem != null)
            {
                // Element Text Content
                stack.Children.Add(CreateInspectorLabel("Element Text / Token Content"));
                var textBox = new TextBox
                {
                    Text = elem.Text,
                    AcceptsReturn = true,
                    TextWrapping = TextWrapping.Wrap,
                    Height = 76,
                    Background = new SolidColorBrush(Color.FromRgb(0x15, 0x16, 0x1A)),
                    Foreground = Brushes.White,
                    CaretBrush = Brushes.White,
                    BorderBrush = new SolidColorBrush(Color.FromRgb(0x3E, 0x40, 0x4A)),
                    Padding = new Thickness(6),
                    Margin = new Thickness(0, 4, 0, 10)
                };
                textBox.TextChanged += (_, _) =>
                {
                    elem.Text = textBox.Text;
                    RefreshPreviewAndOutputs();
                };
                stack.Children.Add(textBox);

                // Font Family
                stack.Children.Add(CreateInspectorLabel("Font Family"));
                var fontCombo = new ComboBox
                {
                    Margin = new Thickness(0, 4, 0, 10),
                    Padding = new Thickness(5)
                };
                string[] fonts = { "Segoe UI", "Arial", "Calibri", "Georgia", "Impact", "Trebuchet MS", "Verdana", "Consolas" };
                foreach (string f in fonts)
                    fontCombo.Items.Add(f);
                fontCombo.SelectedItem = fonts.Contains(elem.FontFamily) ? elem.FontFamily : "Segoe UI";
                fontCombo.SelectionChanged += (_, _) =>
                {
                    if (fontCombo.SelectedItem is string selectedFont)
                    {
                        elem.FontFamily = selectedFont;
                        RefreshPreviewAndOutputs();
                        RebuildSlideEditorView();
                    }
                };
                stack.Children.Add(fontCombo);

                // Font Size Slider
                stack.Children.Add(CreateInspectorLabel($"Font Size ({elem.FontSize:0} pt)"));
                var sizeSlider = new Slider
                {
                    Minimum = 24,
                    Maximum = 120,
                    Value = elem.FontSize,
                    Margin = new Thickness(0, 4, 0, 10)
                };
                sizeSlider.ValueChanged += (_, e) =>
                {
                    elem.FontSize = Math.Round(e.NewValue);
                    RefreshPreviewAndOutputs();
                };
                sizeSlider.PreviewMouseLeftButtonUp += (_, _) => RebuildSlideEditorView();
                stack.Children.Add(sizeSlider);

                // Style Toggles (Bold / Italic / Uppercase / Shadow)
                stack.Children.Add(CreateInspectorLabel("Typography & Effects"));
                var styleWrap = new WrapPanel { Margin = new Thickness(0, 4, 0, 10) };
                styleWrap.Children.Add(CreateSmallHeaderButton(elem.IsBold ? "✓ Bold" : "Bold", elem.IsBold ? Color.FromRgb(0x00, 0x7A, 0xFF) : Color.FromRgb(0x35, 0x36, 0x40), () =>
                {
                    elem.IsBold = !elem.IsBold;
                    RefreshPreviewAndOutputs();
                    RebuildSlideEditorView();
                }));
                styleWrap.Children.Add(CreateSmallHeaderButton(elem.IsItalic ? "✓ Italic" : "Italic", elem.IsItalic ? Color.FromRgb(0x00, 0x7A, 0xFF) : Color.FromRgb(0x35, 0x36, 0x40), () =>
                {
                    elem.IsItalic = !elem.IsItalic;
                    RefreshPreviewAndOutputs();
                    RebuildSlideEditorView();
                }));
                styleWrap.Children.Add(CreateSmallHeaderButton(elem.IsUppercase ? "✓ ALL CAPS" : "ALL CAPS", elem.IsUppercase ? Color.FromRgb(0x00, 0x7A, 0xFF) : Color.FromRgb(0x35, 0x36, 0x40), () =>
                {
                    elem.IsUppercase = !elem.IsUppercase;
                    RefreshPreviewAndOutputs();
                    RebuildSlideEditorView();
                }));
                styleWrap.Children.Add(CreateSmallHeaderButton(elem.HasShadow ? "✓ Shadow" : "Shadow", elem.HasShadow ? Color.FromRgb(0x00, 0x7A, 0xFF) : Color.FromRgb(0x35, 0x36, 0x40), () =>
                {
                    elem.HasShadow = !elem.HasShadow;
                    RefreshPreviewAndOutputs();
                    RebuildSlideEditorView();
                }));
                stack.Children.Add(styleWrap);

                // Alignment
                stack.Children.Add(CreateInspectorLabel("Horizontal Alignment"));
                var alignRow = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(0, 4, 0, 10) };
                foreach (TextAlignment align in new[] { TextAlignment.Left, TextAlignment.Center, TextAlignment.Right })
                {
                    var capturedAlign = align;
                    bool active = elem.HorizontalAlignment == capturedAlign;
                    alignRow.Children.Add(CreateSmallHeaderButton(
                        capturedAlign.ToString(),
                        active ? Color.FromRgb(0x00, 0x7A, 0xFF) : Color.FromRgb(0x35, 0x36, 0x40),
                        () =>
                        {
                            elem.HorizontalAlignment = capturedAlign;
                            RefreshPreviewAndOutputs();
                            RebuildSlideEditorView();
                        }));
                }
                stack.Children.Add(alignRow);

                // Text Color Swatches
                stack.Children.Add(CreateInspectorLabel("Text Color"));
                var textColors = new[]
                {
                    Colors.White,
                    Color.FromRgb(0xFF, 0xE0, 0x66),
                    Color.FromRgb(0x66, 0xD9, 0xFF),
                    Color.FromRgb(0x80, 0xFF, 0xAA),
                    Color.FromRgb(0xFF, 0x99, 0xCC),
                    Color.FromRgb(0xF7, 0x82, 0x1C)
                };
                var textSwatches = new WrapPanel { Margin = new Thickness(0, 4, 0, 10) };
                foreach (var c in textColors)
                {
                    var capturedColor = c;
                    var sw = new Border
                    {
                        Width = 26,
                        Height = 22,
                        Margin = new Thickness(0, 0, 6, 4),
                        CornerRadius = new CornerRadius(3),
                        Background = new SolidColorBrush(capturedColor),
                        BorderBrush = Brushes.White,
                        BorderThickness = new Thickness(elem.TextColor == capturedColor ? 2 : 0.5),
                        Cursor = Cursors.Hand
                    };
                    sw.MouseLeftButtonDown += (_, _) =>
                    {
                        elem.TextColor = capturedColor;
                        RefreshPreviewAndOutputs();
                        RebuildSlideEditorView();
                    };
                    textSwatches.Children.Add(sw);
                }
                stack.Children.Add(textSwatches);

                // Box Fill Swatches (Transparent vs Lower-Third Bars)
                stack.Children.Add(CreateInspectorLabel("Element Box Fill / Backing"));
                var fillColors = new[]
                {
                    Colors.Transparent,
                    Color.FromArgb(190, 0x0A, 0x0E, 0x18),
                    Color.FromArgb(200, 0x00, 0x55, 0xAA),
                    Color.FromArgb(200, 0x8E, 0x1B, 0x3E),
                    Color.FromArgb(200, 0x1E, 0x5E, 0x3A),
                    Color.FromArgb(210, 0xF7, 0x82, 0x1C)
                };
                var fillSwatches = new WrapPanel { Margin = new Thickness(0, 4, 0, 12) };
                foreach (var fc in fillColors)
                {
                    var capturedFill = fc;
                    var sw = new Border
                    {
                        Width = 26,
                        Height = 22,
                        Margin = new Thickness(0, 0, 6, 4),
                        CornerRadius = new CornerRadius(3),
                        Background = capturedFill.A == 0
                            ? new SolidColorBrush(Color.FromRgb(0x2B, 0x2B, 0x2B))
                            : new SolidColorBrush(capturedFill),
                        BorderBrush = Brushes.White,
                        BorderThickness = new Thickness(1),
                        Cursor = Cursors.Hand,
                        ToolTip = capturedFill.A == 0 ? "Transparent Fill" : capturedFill.ToString()
                    };
                    sw.MouseLeftButtonDown += (_, _) =>
                    {
                        elem.FillColor = capturedFill;
                        RefreshPreviewAndOutputs();
                        RebuildSlideEditorView();
                    };
                    fillSwatches.Children.Add(sw);
                }
                stack.Children.Add(fillSwatches);

                // Quick Position Presets (Center Fullscreen vs Lower Third)
                stack.Children.Add(CreateInspectorLabel("Quick Layout Position"));
                var posRow = new WrapPanel { Margin = new Thickness(0, 4, 0, 12) };
                posRow.Children.Add(CreateSmallHeaderButton("Fullscreen Center", Color.FromRgb(0x35, 0x36, 0x40), () =>
                {
                    elem.X = 0.06;
                    elem.Y = 0.14;
                    elem.Width = 0.88;
                    elem.Height = 0.72;
                    RefreshPreviewAndOutputs();
                    RebuildSlideEditorView();
                }));
                posRow.Children.Add(CreateSmallHeaderButton("Lower Third Bar", Color.FromRgb(0x35, 0x36, 0x40), () =>
                {
                    elem.X = 0.04;
                    elem.Y = 0.72;
                    elem.Width = 0.92;
                    elem.Height = 0.22;
                    if (elem.FillColor.A == 0)
                        elem.FillColor = Color.FromArgb(200, 0x0B, 0x13, 0x24);
                    RefreshPreviewAndOutputs();
                    RebuildSlideEditorView();
                }));
                posRow.Children.Add(CreateSmallHeaderButton("Top Banner", Color.FromRgb(0x35, 0x36, 0x40), () =>
                {
                    elem.X = 0.04;
                    elem.Y = 0.05;
                    elem.Width = 0.92;
                    elem.Height = 0.18;
                    RefreshPreviewAndOutputs();
                    RebuildSlideEditorView();
                }));
                stack.Children.Add(posRow);

                // Stage Display Notes
                stack.Children.Add(CreateInspectorLabel("Stage Display Notes / Chord Chart"));
                var notesBox = new TextBox
                {
                    Text = slide.Notes,
                    AcceptsReturn = true,
                    TextWrapping = TextWrapping.Wrap,
                    Height = 54,
                    Background = new SolidColorBrush(Color.FromRgb(0x15, 0x16, 0x1A)),
                    Foreground = new SolidColorBrush(Color.FromRgb(0xFF, 0xD5, 0x4F)),
                    CaretBrush = Brushes.White,
                    BorderBrush = new SolidColorBrush(Color.FromRgb(0x3E, 0x40, 0x4A)),
                    Padding = new Thickness(6),
                    Margin = new Thickness(0, 4, 0, 10)
                };
                notesBox.TextChanged += (_, _) =>
                {
                    slide.Notes = notesBox.Text;
                    RefreshPreviewAndOutputs();
                };
                stack.Children.Add(notesBox);
            }

            scroll.Content = stack;
            border.Child = scroll;
            return border;
        }

        private static TextBlock CreateInspectorLabel(string text)
        {
            return new TextBlock
            {
                Text = text,
                Foreground = new SolidColorBrush(Color.FromRgb(0xB4, 0xBC, 0xCC)),
                FontSize = 11,
                FontWeight = FontWeights.SemiBold
            };
        }

        private void AddEditorElement(SlideElementKind kind)
        {
            if (_selectedEditorSlide == null) return;

            SlideElementModel newElem = kind switch
            {
                SlideElementKind.Shape => new SlideElementModel
                {
                    Kind = SlideElementKind.Shape,
                    Text = "",
                    X = 0.05,
                    Y = 0.73,
                    Width = 0.90,
                    Height = 0.20,
                    FillColor = Color.FromArgb(200, 0x00, 0x55, 0xAA),
                    StrokeColor = Color.FromRgb(0x00, 0xA8, 0xFF),
                    StrokeThickness = 2
                },
                SlideElementKind.TimerToken => new SlideElementModel
                {
                    Kind = SlideElementKind.TimerToken,
                    Text = "SERVICE STARTS IN {Timer}",
                    X = 0.15,
                    Y = 0.35,
                    Width = 0.70,
                    Height = 0.30,
                    FontSize = 68,
                    IsBold = true,
                    TextColor = Color.FromRgb(0xFF, 0xE0, 0x66),
                    FillColor = Color.FromArgb(160, 0, 0, 0)
                },
                SlideElementKind.ClockToken => new SlideElementModel
                {
                    Kind = SlideElementKind.ClockToken,
                    Text = "{Clock}",
                    X = 0.72,
                    Y = 0.05,
                    Width = 0.23,
                    Height = 0.12,
                    FontSize = 42,
                    IsBold = true,
                    TextColor = Brushes.White.Color,
                    FillColor = Color.FromArgb(150, 0, 0, 0)
                },
                _ => new SlideElementModel
                {
                    Kind = SlideElementKind.Text,
                    Text = "New Lyric / Title Box",
                    X = 0.10,
                    Y = 0.25,
                    Width = 0.80,
                    Height = 0.50,
                    FontSize = 56,
                    IsBold = true,
                    TextColor = Colors.White
                }
            };

            _selectedEditorSlide.Elements.Add(newElem);
            _selectedEditorElement = newElem;
            RefreshPreviewAndOutputs();
            RebuildSlideEditorView();
            SetStatus($"Added {kind} element to Slide #{_selectedEditorSlide.SlideNumber}.");
        }

        private void ApplyCurrentSlideStyleToAllSlides()
        {
            if (_selectedPresentation == null || _selectedEditorElement == null)
                return;

            foreach (var slide in _selectedPresentation.Slides)
            {
                foreach (var el in slide.Elements.Where(e => e.Kind == SlideElementKind.Text))
                {
                    el.FontFamily = _selectedEditorElement.FontFamily;
                    el.FontSize = _selectedEditorElement.FontSize;
                    el.IsBold = _selectedEditorElement.IsBold;
                    el.IsItalic = _selectedEditorElement.IsItalic;
                    el.IsUppercase = _selectedEditorElement.IsUppercase;
                    el.HorizontalAlignment = _selectedEditorElement.HorizontalAlignment;
                    el.TextColor = _selectedEditorElement.TextColor;
                    el.FillColor = _selectedEditorElement.FillColor;
                    el.X = _selectedEditorElement.X;
                    el.Y = _selectedEditorElement.Y;
                    el.Width = _selectedEditorElement.Width;
                    el.Height = _selectedEditorElement.Height;
                }
            }

            RefreshPreviewAndOutputs();
            RebuildSlideEditorView();
            SetStatus($"Applied typography & position from Slide #{_selectedEditorSlide?.SlideNumber} to all {_selectedPresentation.Slides.Count} slides.");
        }

        // =====================================================================
        // 2. REFLOW LYRIC SCRIPT EDITOR (ReflowEditor.xaml)
        // =====================================================================
        private void RebuildReflowEditorView()
        {
            _centerContentHost.Children.Clear();
            var doc = _selectedPresentation;
            if (doc == null)
                return;

            var root = new Grid
            {
                Background = new SolidColorBrush(Color.FromRgb(0x19, 0x1A, 0x1F))
            };
            root.RowDefinitions.Add(new RowDefinition { Height = new GridLength(40) });
            root.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            // Top Reflow Bar
            var topBar = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(0x23, 0x24, 0x2A)),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x36, 0x37, 0x40)),
                BorderThickness = new Thickness(0, 0, 0, 1),
                Padding = new Thickness(12, 5, 12, 5)
            };
            var topDock = new DockPanel();
            var rightBtns = new StackPanel { Orientation = Orientation.Horizontal };
            rightBtns.Children.Add(CreateSmallHeaderButton("+ Add Slide Block", Color.FromRgb(0x00, 0x7A, 0xFF), () => AddSlideToCurrentPresentation()));
            rightBtns.Children.Add(CreateSmallHeaderButton("✓ Back to Show View", Color.FromRgb(0x38, 0x38, 0x44), () => SwitchViewMode(InlineViewMode.Show)));
            DockPanel.SetDock(rightBtns, Dock.Right);
            topDock.Children.Add(rightBtns);

            topDock.Children.Add(new TextBlock
            {
                Text = $"REFLOW PRESENTATION EDITOR  •  {doc.Name} ({doc.Slides.Count} Slides)",
                Foreground = new SolidColorBrush(Color.FromRgb(0xF7, 0x82, 0x1C)),
                FontSize = 12,
                FontWeight = FontWeights.Bold,
                VerticalAlignment = VerticalAlignment.Center
            });
            topBar.Child = topDock;
            Grid.SetRow(topBar, 0);
            root.Children.Add(topBar);

            // Split: Left Continuous Lyric Script | Right Live Slide Previews
            var splitGrid = new Grid();
            splitGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1.15, GridUnitType.Star) });
            splitGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            var scriptScroll = new ScrollViewer
            {
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                Padding = new Thickness(14)
            };
            var scriptStack = new StackPanel { Orientation = Orientation.Vertical };

            var previewScroll = new ScrollViewer
            {
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                Padding = new Thickness(14),
                Background = new SolidColorBrush(Color.FromRgb(0x14, 0x15, 0x19))
            };
            var previewWrap = new WrapPanel { Orientation = Orientation.Horizontal };

            foreach (var slide in doc.Slides)
            {
                var capturedSlide = slide;

                // Left Reflow Block
                var blockBorder = new Border
                {
                    Background = new SolidColorBrush(Color.FromRgb(0x23, 0x24, 0x2B)),
                    BorderBrush = new SolidColorBrush(Color.FromRgb(0x38, 0x3A, 0x45)),
                    BorderThickness = new Thickness(1),
                    CornerRadius = new CornerRadius(5),
                    Margin = new Thickness(0, 0, 0, 10),
                    Padding = new Thickness(10)
                };
                var blockStack = new StackPanel();

                var hdrDock = new DockPanel { Margin = new Thickness(0, 0, 0, 6) };
                var blockActions = new StackPanel { Orientation = Orientation.Horizontal };
                blockActions.Children.Add(CreateSmallHeaderButton("Split Slide", Color.FromRgb(0x38, 0x38, 0x45), () =>
                {
                    SplitSlideInReflow(doc, capturedSlide);
                }));
                blockActions.Children.Add(CreateSmallHeaderButton("Trigger Live", Color.FromRgb(0x00, 0x7A, 0xFF), () =>
                {
                    TriggerSlide(doc, capturedSlide);
                }));
                DockPanel.SetDock(blockActions, Dock.Right);
                hdrDock.Children.Add(blockActions);

                hdrDock.Children.Add(new Border
                {
                    Background = new SolidColorBrush(capturedSlide.GroupColor),
                    CornerRadius = new CornerRadius(3),
                    Padding = new Thickness(8, 2, 8, 2),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Child = new TextBlock
                    {
                        Text = $"Slide #{capturedSlide.SlideNumber}  •  {capturedSlide.GroupName}",
                        Foreground = Brushes.White,
                        FontSize = 11,
                        FontWeight = FontWeights.Bold
                    }
                });
                blockStack.Children.Add(hdrDock);

                var lyricEditor = new TextBox
                {
                    Text = capturedSlide.PrimaryText,
                    AcceptsReturn = true,
                    TextWrapping = TextWrapping.Wrap,
                    MinHeight = 58,
                    FontSize = 13.5,
                    Background = new SolidColorBrush(Color.FromRgb(0x16, 0x17, 0x1C)),
                    Foreground = Brushes.White,
                    CaretBrush = Brushes.White,
                    BorderBrush = new SolidColorBrush(Color.FromRgb(0x3E, 0x40, 0x4A)),
                    Padding = new Thickness(8)
                };

                // Corresponding thumbnail host on the right side
                var thumbHost = new Border
                {
                    Width = 228,
                    Margin = new Thickness(0, 0, 12, 12),
                    BorderBrush = new SolidColorBrush(_outputState.ActiveSlide == capturedSlide ? Color.FromRgb(0xF7, 0x82, 0x1C) : Color.FromRgb(0x3A, 0x3C, 0x44)),
                    BorderThickness = new Thickness(2),
                    CornerRadius = new CornerRadius(4),
                    Cursor = Cursors.Hand,
                    Child = SlideCanvasRenderer.RenderSlideThumbnail(capturedSlide, 224, 126, null, _timers)
                };
                thumbHost.MouseLeftButtonDown += (_, _) => TriggerSlide(doc, capturedSlide);
                previewWrap.Children.Add(thumbHost);

                lyricEditor.TextChanged += (_, _) =>
                {
                    capturedSlide.PrimaryText = lyricEditor.Text;
                    thumbHost.Child = SlideCanvasRenderer.RenderSlideThumbnail(capturedSlide, 224, 126, null, _timers);
                    if (_outputState.ActiveSlide == capturedSlide)
                    {
                        RefreshPreviewAndOutputs();
                    }
                };

                blockStack.Children.Add(lyricEditor);
                blockBorder.Child = blockStack;
                scriptStack.Children.Add(blockBorder);
            }

            scriptScroll.Content = scriptStack;
            previewScroll.Content = previewWrap;

            Grid.SetColumn(scriptScroll, 0);
            Grid.SetColumn(previewScroll, 1);
            splitGrid.Children.Add(scriptScroll);
            splitGrid.Children.Add(previewScroll);

            Grid.SetRow(splitGrid, 1);
            root.Children.Add(splitGrid);

            _centerContentHost.Children.Add(root);
        }

        private void SplitSlideInReflow(PresentationDocument doc, SlideItemModel slide)
        {
            var lines = (slide.PrimaryText ?? "").Replace("\r\n", "\n").Split('\n');
            if (lines.Length < 2)
            {
                DuplicateCurrentSlide();
                return;
            }

            int mid = lines.Length / 2;
            string firstHalf = string.Join("\n", lines.Take(mid));
            string secondHalf = string.Join("\n", lines.Skip(mid));

            slide.PrimaryText = firstHalf;
            var secondSlide = slide.Clone();
            secondSlide.PrimaryText = secondHalf;

            int idx = doc.Slides.IndexOf(slide);
            doc.Slides.Insert(idx + 1, secondSlide);
            RenumberSlides(doc);
            RebuildReflowEditorView();
            SetStatus($"Split Slide #{slide.SlideNumber} into two slides in Reflow Editor.");
        }

        // =====================================================================
        // 3. BIBLE SCRIPTURE LOOKUP & PROJECTION VIEW (BiblesViewer.xaml)
        // =====================================================================
        private void RebuildBibleView()
        {
            _centerContentHost.Children.Clear();

            var root = new Grid
            {
                Background = new SolidColorBrush(Color.FromRgb(0x18, 0x19, 0x1E))
            };
            root.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto }); // Bible Search & Translation Header
            root.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }); // Scripture Slide Cards

            var headerBorder = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(0x23, 0x24, 0x2B)),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x36, 0x37, 0x42)),
                BorderThickness = new Thickness(0, 0, 0, 1),
                Padding = new Thickness(12, 8, 12, 8)
            };

            var resultsScroll = new ScrollViewer
            {
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                Padding = new Thickness(14)
            };
            var resultsWrap = new WrapPanel { Orientation = Orientation.Horizontal };

            List<BibleVerseModel> currentResults = BibleService.Lookup(_selectedBibleTranslation, _bibleSearchQuery);

            var hdrStack = new WrapPanel { VerticalAlignment = VerticalAlignment.Center };
            hdrStack.Children.Add(new TextBlock
            {
                Text = "📖 BIBLE SCRIPTURE   ",
                Foreground = new SolidColorBrush(Color.FromRgb(0xF7, 0x82, 0x1C)),
                FontSize = 12,
                FontWeight = FontWeights.Bold,
                VerticalAlignment = VerticalAlignment.Center
            });

            // Translation selector
            var transCombo = new ComboBox
            {
                Width = 225,
                Margin = new Thickness(0, 0, 8, 0),
                Padding = new Thickness(5)
            };
            foreach (string tr in BibleService.Translations)
            {
                string code = tr.Split(' ')[0].Trim();
                transCombo.Items.Add(new ComboBoxItem { Content = tr, Tag = code });
                if (code == _selectedBibleTranslation)
                    transCombo.SelectedIndex = transCombo.Items.Count - 1;
            }

            // Quick Passage Presets
            var presetCombo = new ComboBox
            {
                Width = 145,
                Margin = new Thickness(0, 0, 8, 0),
                Padding = new Thickness(5)
            };
            string[] quickPassages = { "John 3:16-18", "Psalm 23:1-6", "Romans 8:28-39", "Genesis 1:1-5", "Matthew 5:3-9", "Philippians 4:4-13", "Isaiah 40:31" };
            foreach (string p in quickPassages)
                presetCombo.Items.Add(p);
            presetCombo.SelectedIndex = 0;

            // Search / Reference Box
            var queryBox = new TextBox
            {
                Text = _bibleSearchQuery,
                Width = 210,
                Padding = new Thickness(6, 4, 6, 4),
                Background = new SolidColorBrush(Color.FromRgb(0x14, 0x15, 0x19)),
                Foreground = Brushes.White,
                CaretBrush = Brushes.White,
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x45, 0x47, 0x52)),
                Margin = new Thickness(0, 0, 8, 0)
            };

            void RefreshBibleResults()
            {
                currentResults = BibleService.Lookup(_selectedBibleTranslation, _bibleSearchQuery);
                resultsWrap.Children.Clear();

                var tempPres = BibleService.CreatePresentationFromVerses(
                    $"{_bibleSearchQuery} ({_selectedBibleTranslation})",
                    currentResults);

                foreach (var slide in tempPres.Slides)
                {
                    var capturedSlide = slide;
                    var card = new Border
                    {
                        Width = 256,
                        Margin = new Thickness(0, 0, 12, 12),
                        CornerRadius = new CornerRadius(5),
                        Background = new SolidColorBrush(Color.FromRgb(0x16, 0x17, 0x1C)),
                        BorderBrush = new SolidColorBrush(Color.FromRgb(0x3E, 0x42, 0x50)),
                        BorderThickness = new Thickness(1.5),
                        Cursor = Cursors.Hand
                    };

                    var stack = new StackPanel();
                    stack.Children.Add(SlideCanvasRenderer.RenderSlideThumbnail(capturedSlide, 252, 142, null, _timers));
                    stack.Children.Add(new Border
                    {
                        Background = new SolidColorBrush(Color.FromRgb(0x6B, 0x4C, 0x9A)),
                        Padding = new Thickness(8, 4, 8, 4),
                        Child = new TextBlock
                        {
                            Text = $"{capturedSlide.SlideNumber}. {capturedSlide.Label}",
                            Foreground = Brushes.White,
                            FontSize = 11,
                            FontWeight = FontWeights.Bold
                        }
                    });
                    card.Child = stack;
                    card.MouseLeftButtonDown += (_, _) =>
                    {
                        TriggerSlide(tempPres, capturedSlide);
                    };
                    resultsWrap.Children.Add(card);
                }
            }

            transCombo.SelectionChanged += (_, _) =>
            {
                if (transCombo.SelectedItem is ComboBoxItem cbi && cbi.Tag is string code)
                {
                    _selectedBibleTranslation = code;
                    RefreshBibleResults();
                }
            };

            presetCombo.SelectionChanged += (_, _) =>
            {
                if (presetCombo.SelectedItem is string passage)
                {
                    _bibleSearchQuery = passage;
                    queryBox.Text = passage;
                    RefreshBibleResults();
                }
            };

            queryBox.KeyDown += (_, e) =>
            {
                if (e.Key == Key.Enter)
                {
                    _bibleSearchQuery = queryBox.Text.Trim();
                    RefreshBibleResults();
                }
            };

            hdrStack.Children.Add(transCombo);
            hdrStack.Children.Add(presetCombo);
            hdrStack.Children.Add(queryBox);
            hdrStack.Children.Add(CreateSmallHeaderButton("Lookup", Color.FromRgb(0x00, 0x7A, 0xFF), () =>
            {
                _bibleSearchQuery = queryBox.Text.Trim();
                RefreshBibleResults();
            }));
            hdrStack.Children.Add(CreateSmallHeaderButton("+ Save to Library & Open", Color.FromRgb(0x2E, 0x6F, 0x40), () =>
            {
                var pres = BibleService.CreatePresentationFromVerses(
                    $"{_bibleSearchQuery} ({_selectedBibleTranslation})",
                    currentResults);
                _libraryPresentations.Insert(0, pres);
                RefreshLibraryViewLists();
                SelectPresentation(pres, triggerFirstSlide: true);
                SwitchViewMode(InlineViewMode.Show);
            }));

            headerBorder.Child = hdrStack;
            Grid.SetRow(headerBorder, 0);
            root.Children.Add(headerBorder);

            RefreshBibleResults();
            resultsScroll.Content = resultsWrap;
            Grid.SetRow(resultsScroll, 1);
            root.Children.Add(resultsScroll);

            _centerContentHost.Children.Add(root);
        }
    }
}
