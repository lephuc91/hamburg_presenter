using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ProPresenterClone.Theming
{
    /// <summary>
    /// Parses Renewed Vision's native .theme files (dark.theme / light.theme) from
    /// C:\Program Files\Renewed Vision\ProPresenter\themes and provides WPF Brushes,
    /// Colors, and extracted UI Icons matching ProPresenter.UI.Theming.AppTheme.
    /// </summary>
    public sealed class ThemeEngine
    {
        public static ThemeEngine Instance { get; } = new ThemeEngine();

        private readonly Dictionary<string, Color> _colors = new Dictionary<string, Color>(StringComparer.OrdinalIgnoreCase);
        private readonly Dictionary<string, SolidColorBrush> _brushes = new Dictionary<string, SolidColorBrush>(StringComparer.OrdinalIgnoreCase);
        private readonly Dictionary<string, ImageSource> _iconCache = new Dictionary<string, ImageSource>(StringComparer.OrdinalIgnoreCase);

        public string ActiveThemeName { get; private set; } = "dark";
        public string AssetsRoot { get; private set; } = "";

        public event EventHandler? ThemeChanged;

        private ThemeEngine()
        {
            AssetsRoot = FindAssetsRoot();
            LoadTheme("dark");
        }

        private static string FindAssetsRoot()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string[] candidates = new[]
            {
                Path.Combine(baseDir, "assets"),
                Path.GetFullPath(Path.Combine(baseDir, "..", "assets")),
                @"d:\ProPresenterClone\assets",
                @"C:\Program Files\Renewed Vision\ProPresenter"
            };
            foreach (var c in candidates)
            {
                if (Directory.Exists(c))
                    return c;
            }
            return @"d:\ProPresenterClone\assets";
        }

        public void LoadTheme(string themeName)
        {
            ActiveThemeName = themeName;
            _colors.Clear();
            _brushes.Clear();

            // Seed default Pro7 Dark Theme values from dark.theme in case any key is missing
            SetDefaultDarkColors();

            string themeFile = Path.Combine(AssetsRoot, "themes", themeName + ".theme");
            if (!File.Exists(themeFile) && Directory.Exists(@"C:\Program Files\Renewed Vision\ProPresenter\themes"))
            {
                themeFile = Path.Combine(@"C:\Program Files\Renewed Vision\ProPresenter\themes", themeName + ".theme");
            }

            if (File.Exists(themeFile))
            {
                ParseThemeFile(themeFile);
            }

            ThemeChanged?.Invoke(this, EventArgs.Empty);
        }

        private void SetDefaultDarkColors()
        {
            _colors["TRANSPARENT"] = Color.FromArgb(0, 255, 255, 255);
            _colors["LIGHTCONTENT"] = Color.FromArgb(217, 255, 255, 255);
            _colors["DARKCONTENT"] = Color.FromArgb(217, 0, 0, 0);
            _colors["SUCCESS"] = Color.FromRgb(0x00, 0xB0, 0x20);
            _colors["ERROR"] = Color.FromRgb(0xB0, 0x00, 0x20);
            _colors["PRIMARY"] = Color.FromRgb(0x42, 0x42, 0x42);
            _colors["PRIMARYLIGHT"] = Color.FromRgb(0x6D, 0x6D, 0x6D);
            _colors["PRIMARYDARK"] = Color.FromRgb(0x1B, 0x1B, 0x1B);
            _colors["SECONDARY"] = Color.FromRgb(0x00, 0x7A, 0xFF);
            _colors["SECONDARYLIGHT"] = Color.FromRgb(0x9B, 0xE7, 0xFF);
            _colors["SECONDARYDARK"] = Color.FromRgb(0x22, 0x86, 0xC3);
            _colors["BACKGROUND"] = Color.FromRgb(0x23, 0x23, 0x23);
            _colors["SURFACE"] = Color.FromRgb(0x23, 0x23, 0x23);
            _colors["HEADER"] = Color.FromRgb(0x12, 0x12, 0x12);
            _colors["MAINCONTENT"] = Color.FromRgb(0x1E, 0x1E, 0x1E);
            _colors["OUTLINEDETAIL"] = Color.FromRgb(0x2F, 0x2F, 0x2F);
            _colors["OUTLINESOURCE"] = Color.FromRgb(0x46, 0x46, 0x46);
            _colors["OUTLINEDETAILHEADER"] = Color.FromRgb(0x23, 0x23, 0x23);
            _colors["CONTAINER"] = Color.FromRgb(0x1B, 0x1B, 0x1B);
            _colors["PANEL"] = Color.FromRgb(0x42, 0x42, 0x42);
            _colors["WINDOW_BACKGROUND"] = Color.FromRgb(0x45, 0x45, 0x45);
            _colors["THUMBNAILPRESENTATION"] = Color.FromRgb(0xF7, 0x82, 0x1C);
            _colors["THUMBNAILANNOUNCEMENT"] = Color.FromRgb(0x61, 0xBA, 0x46);
            _colors["THUMBNAILBUBBLEACTIVEFILL"] = Color.FromRgb(0x33, 0xFD, 0x00);
            _colors["CLEARBUTTONBACKGROUND"] = Color.FromRgb(0x57, 0x1B, 0x1B);
            _colors["CLEARBUTTONHOVER"] = Color.FromRgb(0x8D, 0x2A, 0x2A);
            _colors["UTILITYVIEW_TIMER_RUNNING"] = Color.FromRgb(0x3D, 0x4E, 0x3C);
            _colors["UTILITYVIEW_TIMER_EXPIRED"] = Color.FromRgb(0x3C, 0x47, 0x61);
            _colors["UTILITYVIEW_TIMER_OVERRUN"] = Color.FromRgb(0x63, 0x3E, 0x3E);
        }

        private void ParseThemeFile(string path)
        {
            foreach (string rawLine in File.ReadAllLines(path))
            {
                string line = rawLine.Trim();
                if (string.IsNullOrEmpty(line) || line.StartsWith("#"))
                    continue;

                if (line.EndsWith(";"))
                    line = line.Substring(0, line.Length - 1).Trim();

                int eqIdx = line.IndexOf('=');
                if (eqIdx <= 0)
                    continue;

                string key = line.Substring(0, eqIdx).Trim();
                string expr = line.Substring(eqIdx + 1).Trim();

                if (expr.StartsWith("*"))
                    continue;

                if (TryEvaluateColorExpr(expr, out Color parsed))
                {
                    _colors[key] = parsed;
                }
            }
        }

        private bool TryEvaluateColorExpr(string expr, out Color result)
        {
            result = Colors.Transparent;
            if (string.IsNullOrWhiteSpace(expr))
                return false;

            // Handle blend syntax: $BASE+$OVERLAY@PERCENT
            int plusIdx = expr.IndexOf('+');
            if (plusIdx > 0)
            {
                string leftPart = expr.Substring(0, plusIdx).Trim();
                string rightPart = expr.Substring(plusIdx + 1).Trim();
                if (TryEvaluateSingleColor(leftPart, out Color baseCol) &&
                    TryEvaluateSingleColor(rightPart, out Color overCol))
                {
                    double alpha = overCol.A / 255.0;
                    byte r = (byte)Math.Clamp(baseCol.R * (1 - alpha) + overCol.R * alpha, 0, 255);
                    byte g = (byte)Math.Clamp(baseCol.G * (1 - alpha) + overCol.G * alpha, 0, 255);
                    byte b = (byte)Math.Clamp(baseCol.B * (1 - alpha) + overCol.B * alpha, 0, 255);
                    result = Color.FromArgb(baseCol.A, r, g, b);
                    return true;
                }
            }

            return TryEvaluateSingleColor(expr, out result);
        }

        private bool TryEvaluateSingleColor(string token, out Color color)
        {
            color = Colors.Transparent;
            token = token.Trim().TrimStart('~');

            int atIdx = token.IndexOf('@');
            double? opacityPercent = null;
            if (atIdx > 0)
            {
                string opStr = token.Substring(atIdx + 1).Trim();
                token = token.Substring(0, atIdx).Trim();
                if (double.TryParse(opStr, NumberStyles.Float, CultureInfo.InvariantCulture, out double op))
                {
                    opacityPercent = op;
                }
            }

            if (token.StartsWith("$"))
            {
                string varName = token.Substring(1);
                if (!_colors.TryGetValue(varName, out color))
                    return false;
            }
            else if (_colors.TryGetValue(token, out Color namedVar))
            {
                color = namedVar;
            }
            else if (token.StartsWith("#"))
            {
                string hex = token.Substring(1);
                if (hex.Length == 6 &&
                    byte.TryParse(hex.Substring(0, 2), NumberStyles.HexNumber, null, out byte r) &&
                    byte.TryParse(hex.Substring(2, 2), NumberStyles.HexNumber, null, out byte g) &&
                    byte.TryParse(hex.Substring(4, 2), NumberStyles.HexNumber, null, out byte b))
                {
                    color = Color.FromArgb(255, r, g, b);
                }
                else if (hex.Length == 8 &&
                    byte.TryParse(hex.Substring(0, 2), NumberStyles.HexNumber, null, out byte a) &&
                    byte.TryParse(hex.Substring(2, 2), NumberStyles.HexNumber, null, out byte r8) &&
                    byte.TryParse(hex.Substring(4, 2), NumberStyles.HexNumber, null, out byte g8) &&
                    byte.TryParse(hex.Substring(6, 2), NumberStyles.HexNumber, null, out byte b8))
                {
                    color = Color.FromArgb(a, r8, g8, b8);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            if (opacityPercent.HasValue)
            {
                byte a = (byte)Math.Clamp(Math.Round(255.0 * (opacityPercent.Value / 100.0)), 0, 255);
                color = Color.FromArgb(a, color.R, color.G, color.B);
            }

            return true;
        }

        public Color GetColor(string key, Color? fallback = null)
        {
            if (_colors.TryGetValue(key, out Color c))
                return c;
            return fallback ?? Color.FromRgb(0x2F, 0x2F, 0x2F);
        }

        public SolidColorBrush GetBrush(string key, Color? fallback = null)
        {
            if (_brushes.TryGetValue(key, out SolidColorBrush? cached))
                return cached;

            Color c = GetColor(key, fallback);
            var brush = new SolidColorBrush(c);
            brush.Freeze();
            _brushes[key] = brush;
            return brush;
        }

        public static SolidColorBrush BrushFromHex(string hex)
        {
            hex = hex.TrimStart('#');
            byte a = 255, r = 0, g = 0, b = 0;
            if (hex.Length == 6)
            {
                r = byte.Parse(hex.Substring(0, 2), NumberStyles.HexNumber);
                g = byte.Parse(hex.Substring(2, 2), NumberStyles.HexNumber);
                b = byte.Parse(hex.Substring(4, 2), NumberStyles.HexNumber);
            }
            else if (hex.Length == 8)
            {
                a = byte.Parse(hex.Substring(0, 2), NumberStyles.HexNumber);
                r = byte.Parse(hex.Substring(2, 2), NumberStyles.HexNumber);
                g = byte.Parse(hex.Substring(4, 2), NumberStyles.HexNumber);
                b = byte.Parse(hex.Substring(6, 2), NumberStyles.HexNumber);
            }
            var br = new SolidColorBrush(Color.FromArgb(a, r, g, b));
            br.Freeze();
            return br;
        }

        public ImageSource? GetIcon(string relativeIconPath)
        {
            if (_iconCache.TryGetValue(relativeIconPath, out ImageSource? cached))
                return cached;

            string[] searchRoots = new[]
            {
                Path.Combine(AssetsRoot, "ui-icons", "icons"),
                Path.Combine(AssetsRoot, "icons"),
                @"d:\ProPresenterClone\assets\ui-icons\icons",
                @"d:\ProPresenterClone\src\ProPresenter.UI\resources\icons"
            };

            foreach (var root in searchRoots)
            {
                string fullPath = Path.Combine(root, relativeIconPath.Replace('/', Path.DirectorySeparatorChar));
                if (File.Exists(fullPath))
                {
                    try
                    {
                        var bmp = new BitmapImage();
                        bmp.BeginInit();
                        bmp.CacheOption = BitmapCacheOption.OnLoad;
                        bmp.UriSource = new Uri(fullPath, UriKind.Absolute);
                        bmp.EndInit();
                        bmp.Freeze();
                        _iconCache[relativeIconPath] = bmp;
                        return bmp;
                    }
                    catch
                    {
                        // Ignore malformed image and continue
                    }
                }
            }
            return null;
        }
    }
}

