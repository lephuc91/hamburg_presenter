using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ProPresenterClone.Models;
using ProPresenterClone.Theming;

namespace ProPresenterClone.Rendering
{
    /// <summary>
    /// Renders 16:9 ProPresenter slides and composite multi-layer output surfaces
    /// (Video Input -> Media Background -> Slide Elements -> Props -> Messages -> Clear to Logo).
    /// </summary>
    public static class SlideCanvasRenderer
    {
        private static readonly Dictionary<string, BitmapImage> _imageCache = new Dictionary<string, BitmapImage>(StringComparer.OrdinalIgnoreCase);
        private static DrawingBrush? _checkerboardBrush;

        public static DrawingBrush CreateCheckerboardBrush(double squareSize = 10.0)
        {
            if (_checkerboardBrush != null)
                return _checkerboardBrush;

            var c1 = Color.FromRgb(0x14, 0x14, 0x17);
            var c2 = Color.FromRgb(0x21, 0x21, 0x26);

            var group = new DrawingGroup();
            group.Children.Add(new GeometryDrawing(
                new SolidColorBrush(c1),
                null,
                new RectangleGeometry(new Rect(0, 0, squareSize * 2, squareSize * 2))));

            var b2 = new SolidColorBrush(c2);
            group.Children.Add(new GeometryDrawing(
                b2,
                null,
                new RectangleGeometry(new Rect(0, 0, squareSize, squareSize))));
            group.Children.Add(new GeometryDrawing(
                b2,
                null,
                new RectangleGeometry(new Rect(squareSize, squareSize, squareSize, squareSize))));

            var brush = new DrawingBrush(group)
            {
                TileMode = TileMode.Tile,
                Viewport = new Rect(0, 0, squareSize * 2, squareSize * 2),
                ViewportUnits = BrushMappingMode.Absolute,
                Stretch = Stretch.None
            };
            brush.Freeze();
            _checkerboardBrush = brush;
            return brush;
        }

        public static FrameworkElement RenderSlideThumbnail(
            SlideItemModel slide,
            double width,
            double height,
            MediaBinItem? backgroundMedia = null,
            IReadOnlyList<TimerItemModel>? timers = null)
        {
            double scale = width / 1920.0;
            var root = new Grid
            {
                Width = width,
                Height = height,
                ClipToBounds = true,
                Background = new SolidColorBrush(Color.FromRgb(0x0E, 0x0E, 0x12))
            };

            // 1. Optional Media or Slide background
            if (backgroundMedia != null)
            {
                root.Children.Add(CreateMediaLayerVisual(backgroundMedia, width, height));
            }
            else if (!string.IsNullOrEmpty(slide.BackgroundMediaPath) && File.Exists(slide.BackgroundMediaPath))
            {
                var img = TryLoadBitmap(slide.BackgroundMediaPath);
                if (img != null)
                {
                    root.Children.Add(new Image { Source = img, Stretch = Stretch.UniformToFill });
                }
            }
            else if (slide.HasCustomBackground && slide.BackgroundColor.A > 0)
            {
                root.Children.Add(new Border { Background = new SolidColorBrush(slide.BackgroundColor) });
            }
            else
            {
                // Dark transparency checkerboard matching ProPresenter 7
                root.Children.Add(new Border { Background = CreateCheckerboardBrush(11.0) });
            }

            // 2. Slide Elements
            var canvas = new Canvas { Width = width, Height = height };
            foreach (var el in slide.Elements)
            {
                var visual = CreateSlideElementVisual(el, width, height, scale, false, timers);
                canvas.Children.Add(visual);
            }
            root.Children.Add(canvas);

            return root;
        }

        public static FrameworkElement RenderCompositeOutput(
            ActiveOutputState state,
            double width,
            double height,
            IReadOnlyList<TimerItemModel>? timers = null,
            double animationPhase = 0.0)
        {
            double scale = width / 1920.0;
            var root = new Grid
            {
                Width = width,
                Height = height,
                ClipToBounds = true,
                Background = Brushes.Black
            };

            if (!state.IsAudienceEnabled)
            {
                return root;
            }

            // If Clear-to-Logo is active, render the watermark/logo over black
            if (state.IsClearToLogoActive)
            {
                var logoStack = new StackPanel
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };
                string watermarkPath = System.IO.Path.Combine(ThemeEngine.Instance.AssetsRoot, "images", "watermark.png");
                var bmp = TryLoadBitmap(watermarkPath);
                if (bmp != null)
                {
                    logoStack.Children.Add(new Image
                    {
                        Source = bmp,
                        Width = Math.Max(80, 340 * scale),
                        Opacity = 0.9,
                        Stretch = Stretch.Uniform
                    });
                }
                else
                {
                    logoStack.Children.Add(new TextBlock
                    {
                        Text = "PROPRESENTER",
                        Foreground = new SolidColorBrush(Color.FromRgb(0xF7, 0x82, 0x1C)),
                        FontSize = Math.Max(14, 48 * scale),
                        FontWeight = FontWeights.Bold,
                        HorizontalAlignment = HorizontalAlignment.Center
                    });
                }
                root.Children.Add(logoStack);
                return root;
            }

            // Layer 1: Live Video Input Layer
            if (state.IsVideoInputActive && state.ActiveLook.ShowVideoInputLayer)
            {
                var camBrush = new RadialGradientBrush(
                    Color.FromRgb(0x1E, 0x3A, 0x5F),
                    Color.FromRgb(0x09, 0x13, 0x22));
                var camGrid = new Grid { Background = camBrush };
                var camBadge = new Border
                {
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(24 * scale),
                    Padding = new Thickness(12 * scale, 5 * scale, 12 * scale, 5 * scale),
                    CornerRadius = new CornerRadius(4 * scale),
                    Background = new SolidColorBrush(Color.FromArgb(180, 0xD0, 0x1F, 0x1F)),
                    Child = new TextBlock
                    {
                        Text = "CAM 1 • SDI / NDI 1080p60",
                        Foreground = Brushes.White,
                        FontSize = Math.Max(8, 22 * scale),
                        FontWeight = FontWeights.SemiBold
                    }
                };
                camGrid.Children.Add(camBadge);
                root.Children.Add(camGrid);
            }

            // Layer 2: Background Media Layer
            if (state.ActiveMediaBackground != null && state.ActiveLook.ShowMediaLayer)
            {
                root.Children.Add(CreateMediaLayerVisual(state.ActiveMediaBackground, width, height, animationPhase));
            }

            // Layer 3: Slide Layer
            if (state.ActiveSlide != null && state.ActiveLook.ShowSlideLayer)
            {
                var slide = state.ActiveSlide;
                if (state.ActiveMediaBackground == null && slide.HasCustomBackground && slide.BackgroundColor.A > 0)
                {
                    root.Children.Add(new Border { Background = new SolidColorBrush(slide.BackgroundColor) });
                }

                var slideCanvas = new Canvas { Width = width, Height = height };
                bool lowerThirdOverride = state.ActiveLook.UseLowerThirdThemeOverride;

                foreach (var origEl in slide.Elements)
                {
                    var el = origEl;
                    if (lowerThirdOverride && origEl.Kind == SlideElementKind.Text)
                    {
                        el = origEl.Clone();
                        el.X = 0.05;
                        el.Y = 0.72;
                        el.Width = 0.90;
                        el.Height = 0.22;
                        el.FontSize = Math.Min(el.FontSize, 44);
                        el.FillColor = Color.FromArgb(215, 12, 16, 24);
                        el.CornerRadius = 8;
                    }
                    slideCanvas.Children.Add(CreateSlideElementVisual(el, width, height, scale, false, timers));
                }
                root.Children.Add(slideCanvas);
            }

            // Layer 4: Props Layer
            if (state.ActiveProps.Count > 0 && state.ActiveLook.ShowPropsLayer)
            {
                foreach (var prop in state.ActiveProps)
                {
                    if (!prop.IsActive) continue;
                    root.Children.Add(CreatePropOverlayVisual(prop, width, height, scale, timers));
                }
            }

            // Layer 5: Audience Stage Message Layer
            if (state.ActiveMessage != null &&
                state.ActiveMessage.IsActive &&
                state.ActiveMessage.ShowOnAudience &&
                state.ActiveLook.ShowMessagesLayer)
            {
                var msgBanner = new Border
                {
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(40 * scale, 26 * scale, 40 * scale, 0),
                    Padding = new Thickness(24 * scale, 12 * scale, 24 * scale, 12 * scale),
                    CornerRadius = new CornerRadius(6 * scale),
                    Background = new SolidColorBrush(Color.FromArgb(230, 0xB0, 0x00, 0x20)),
                    BorderBrush = new SolidColorBrush(Color.FromArgb(200, 255, 255, 255)),
                    BorderThickness = new Thickness(Math.Max(1, 2 * scale)),
                    Child = new TextBlock
                    {
                        Text = "🔔 " + state.ActiveMessage.ResolvedMessage,
                        Foreground = Brushes.White,
                        FontFamily = new FontFamily("Roboto, Segoe UI"),
                        FontSize = Math.Max(9, 34 * scale),
                        FontWeight = FontWeights.Bold,
                        TextAlignment = TextAlignment.Center,
                        TextWrapping = TextWrapping.Wrap
                    }
                };
                root.Children.Add(msgBanner);
            }

            return root;
        }

        public static FrameworkElement CreateMediaLayerVisual(
            MediaBinItem media,
            double width,
            double height,
            double phase = 0.0)
        {
            if (!string.IsNullOrEmpty(media.FilePath) && File.Exists(media.FilePath))
            {
                string ext = System.IO.Path.GetExtension(media.FilePath).ToLowerInvariant();
                if (ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".bmp")
                {
                    var bmp = TryLoadBitmap(media.FilePath);
                    if (bmp != null)
                    {
                        return new Image
                        {
                            Source = bmp,
                            Width = width,
                            Height = height,
                            Stretch = Stretch.UniformToFill
                        };
                    }
                }
            }

            // Rich procedural worship motion canvas for video/motion presets
            double angle = (25.0 + phase * 36.0) % 360.0;
            var linear = new LinearGradientBrush
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(1, 1)
            };
            linear.GradientStops.Add(new GradientStop(media.PrimaryColor, 0.0));
            linear.GradientStops.Add(new GradientStop(media.SecondaryColor, 0.55));
            linear.GradientStops.Add(new GradientStop(media.AccentColor, 1.0));

            var grid = new Grid { Width = width, Height = height, Background = linear };

            // Subtle glowing light orbs for atmospheric worship motion
            double orbOffset = Math.Sin(phase * Math.PI * 2.0) * (width * 0.08);
            var orb1 = new Ellipse
            {
                Width = width * 0.55,
                Height = height * 0.65,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(width * 0.1 + orbOffset, -height * 0.1, 0, 0),
                Fill = new RadialGradientBrush(
                    Color.FromArgb(95, media.AccentColor.R, media.AccentColor.G, media.AccentColor.B),
                    Colors.Transparent)
            };
            var orb2 = new Ellipse
            {
                Width = width * 0.60,
                Height = height * 0.65,
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Bottom,
                Margin = new Thickness(0, 0, width * 0.08 - orbOffset, -height * 0.12),
                Fill = new RadialGradientBrush(
                    Color.FromArgb(80, 255, 255, 255),
                    Colors.Transparent)
            };
            grid.Children.Add(orb1);
            grid.Children.Add(orb2);

            return grid;
        }

        public static FrameworkElement CreateSlideElementVisual(
            SlideElementModel el,
            double canvasWidth,
            double canvasHeight,
            double scale,
            bool showEditorHandles,
            IReadOnlyList<TimerItemModel>? timers = null)
        {
            double left = el.X * canvasWidth;
            double top = el.Y * canvasHeight;
            double w = Math.Max(16, el.Width * canvasWidth);
            double h = Math.Max(12, el.Height * canvasHeight);

            var container = new Border
            {
                Width = w,
                Height = h,
                Background = new SolidColorBrush(el.FillColor),
                BorderBrush = el.StrokeThickness > 0
                    ? new SolidColorBrush(el.StrokeColor)
                    : (showEditorHandles ? new SolidColorBrush(Color.FromArgb(140, 0x00, 0x7A, 0xFF)) : Brushes.Transparent),
                BorderThickness = new Thickness(
                    el.StrokeThickness > 0 ? Math.Max(1, el.StrokeThickness * scale) : (showEditorHandles ? 1 : 0)),
                CornerRadius = new CornerRadius(el.CornerRadius * scale),
                Padding = new Thickness(Math.Max(2, 18 * scale))
            };

            if (el.Kind == SlideElementKind.Image && !string.IsNullOrEmpty(el.ImagePath) && File.Exists(el.ImagePath))
            {
                var bmp = TryLoadBitmap(el.ImagePath);
                if (bmp != null)
                {
                    container.Child = new Image { Source = bmp, Stretch = Stretch.Uniform };
                }
            }
            else
            {
                string displayText = ResolveTokens(el, timers);
                if (el.IsUppercase)
                    displayText = displayText.ToUpperInvariant();

                double scaledFontSize = Math.Max(6.5, el.FontSize * scale * 1.15);
                var tb = new TextBlock
                {
                    Text = displayText,
                    FontFamily = new FontFamily(el.FontFamily + ", Roboto, Segoe UI, Arial"),
                    FontSize = scaledFontSize,
                    FontWeight = el.IsBold ? FontWeights.Bold : FontWeights.Normal,
                    FontStyle = el.IsItalic ? FontStyles.Italic : FontStyles.Normal,
                    Foreground = new SolidColorBrush(el.TextColor),
                    TextAlignment = el.HorizontalAlignment,
                    VerticalAlignment = el.VerticalAlignment,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    TextWrapping = TextWrapping.Wrap,
                    LineHeight = scaledFontSize * 1.22,
                    LineStackingStrategy = LineStackingStrategy.BlockLineHeight
                };

                if (el.HasShadow)
                {
                    tb.Effect = new DropShadowEffect
                    {
                        Color = Colors.Black,
                        BlurRadius = Math.Max(1.5, 8 * scale),
                        ShadowDepth = Math.Max(1, 2.5 * scale),
                        Opacity = 0.92
                    };
                }

                container.Child = tb;
            }

            Canvas.SetLeft(container, left);
            Canvas.SetTop(container, top);
            return container;
        }

        private static string ResolveTokens(SlideElementModel el, IReadOnlyList<TimerItemModel>? timers)
        {
            if (el.Kind == SlideElementKind.ClockToken)
            {
                return DateTime.Now.ToString("hh:mm:ss tt");
            }
            if (el.Kind == SlideElementKind.TimerToken)
            {
                var t = timers?.FirstOrDefault();
                return t != null ? t.FormattedValue : "05:00";
            }

            string text = el.Text ?? "";
            if (text.Contains("{Clock}", StringComparison.OrdinalIgnoreCase))
            {
                text = text.Replace("{Clock}", DateTime.Now.ToString("h:mm tt"), StringComparison.OrdinalIgnoreCase);
            }
            if (text.Contains("{Timer}", StringComparison.OrdinalIgnoreCase))
            {
                var t = timers?.FirstOrDefault();
                text = text.Replace("{Timer}", t != null ? t.FormattedValue : "05:00", StringComparison.OrdinalIgnoreCase);
            }
            return text;
        }

        private static FrameworkElement CreatePropOverlayVisual(
            PropItemModel prop,
            double width,
            double height,
            double scale,
            IReadOnlyList<TimerItemModel>? timers)
        {
            var stack = new StackPanel { Orientation = Orientation.Vertical };
            string mainText = prop.BadgeText;
            if (mainText.Contains("{Timer}", StringComparison.OrdinalIgnoreCase))
            {
                var firstTimer = timers?.FirstOrDefault();
                mainText = mainText.Replace("{Timer}", firstTimer != null ? firstTimer.FormattedValue : "05:00", StringComparison.OrdinalIgnoreCase);
            }

            stack.Children.Add(new TextBlock
            {
                Text = mainText,
                Foreground = Brushes.White,
                FontFamily = new FontFamily("Roboto, Segoe UI"),
                FontSize = Math.Max(7, 28 * scale),
                FontWeight = FontWeights.Bold
            });

            if (!string.IsNullOrWhiteSpace(prop.SubText))
            {
                stack.Children.Add(new TextBlock
                {
                    Text = prop.SubText,
                    Foreground = new SolidColorBrush(Color.FromArgb(220, 235, 242, 255)),
                    FontFamily = new FontFamily("Roboto, Segoe UI"),
                    FontSize = Math.Max(6, 20 * scale),
                    Margin = new Thickness(0, 2 * scale, 0, 0)
                });
            }

            var badge = new Border
            {
                Background = new SolidColorBrush(Color.FromArgb(225, prop.PrimaryColor.R, prop.PrimaryColor.G, prop.PrimaryColor.B)),
                BorderBrush = new SolidColorBrush(Color.FromArgb(180, 255, 255, 255)),
                BorderThickness = new Thickness(Math.Max(1, 1.5 * scale)),
                CornerRadius = new CornerRadius(6 * scale),
                Padding = new Thickness(20 * scale, 10 * scale, 20 * scale, 10 * scale),
                Margin = new Thickness(36 * scale),
                Child = stack
            };

            switch (prop.Position)
            {
                case "TopRight":
                    badge.HorizontalAlignment = HorizontalAlignment.Right;
                    badge.VerticalAlignment = VerticalAlignment.Top;
                    break;
                case "TopLeft":
                    badge.HorizontalAlignment = HorizontalAlignment.Left;
                    badge.VerticalAlignment = VerticalAlignment.Top;
                    break;
                case "BottomRight":
                    badge.HorizontalAlignment = HorizontalAlignment.Right;
                    badge.VerticalAlignment = VerticalAlignment.Bottom;
                    break;
                default:
                    badge.HorizontalAlignment = HorizontalAlignment.Left;
                    badge.VerticalAlignment = VerticalAlignment.Bottom;
                    break;
            }

            return badge;
        }

        public static BitmapImage? TryLoadBitmap(string path)
        {
            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
                return null;

            if (_imageCache.TryGetValue(path, out var cached))
                return cached;

            try
            {
                var bmp = new BitmapImage();
                bmp.BeginInit();
                bmp.CacheOption = BitmapCacheOption.OnLoad;
                bmp.DecodePixelWidth = 640;
                bmp.UriSource = new Uri(path, UriKind.Absolute);
                bmp.EndInit();
                bmp.Freeze();
                _imageCache[path] = bmp;
                return bmp;
            }
            catch
            {
                return null;
            }
        }
    }
}
