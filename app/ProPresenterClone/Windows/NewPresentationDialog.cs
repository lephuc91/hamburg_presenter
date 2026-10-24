using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using ProPresenterClone.Models;

namespace ProPresenterClone.Windows
{
    public sealed class NewPresentationResult
    {
        public string Name { get; set; } = "Untitled Presentation";
        public ThemeTemplateModel Theme { get; set; } = null!;
        public string SizeString { get; set; } = "1920 x 1080";
        public int Width { get; set; } = 1920;
        public int Height { get; set; } = 1080;
        public string Library { get; set; } = "Default";
        public string Playlist { get; set; } = "No Playlist";
    }

    /// <summary>
    /// Custom styled ProPresenter DropDownButton matching Pro.UI.Controls.DropDownButton.xaml
    /// and the visual design in ProPresenter 7 (medium-gray background #525256, subtle border #626268,
    /// white text, and right-aligned chevron arrow with dark popup menu).
    /// </summary>
    public sealed class ProPresenterDropDownButton : Border
    {
        private readonly TextBlock _textBlock;
        private readonly ContextMenu _menu;
        private readonly List<string> _items = new();
        private string _selectedItem = "";

        public event EventHandler<string>? SelectionChanged;

        public string SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                _textBlock.Text = value;
                UpdateMenuChecks();
            }
        }

        public ProPresenterDropDownButton(IEnumerable<string> items, string defaultItem)
        {
            Height = 26;
            // Medium lighter-slate gray matching ProPresenter 7 DropDownButton (#525256 / #545458)
            Background = new SolidColorBrush(Color.FromRgb(0x52, 0x52, 0x56));
            BorderBrush = new SolidColorBrush(Color.FromRgb(0x62, 0x62, 0x68));
            BorderThickness = new Thickness(1);
            CornerRadius = new CornerRadius(3);
            Cursor = Cursors.Hand;

            var dock = new DockPanel();
            var arrow = new TextBlock
            {
                Text = "▼",
                FontSize = 8,
                Foreground = new SolidColorBrush(Color.FromRgb(0xD2, 0xD2, 0xD6)),
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 0, 8, 0)
            };
            DockPanel.SetDock(arrow, Dock.Right);
            dock.Children.Add(arrow);

            _textBlock = new TextBlock
            {
                Text = defaultItem,
                FontSize = 13,
                Foreground = Brushes.White,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(8, 0, 0, 0),
                TextTrimming = TextTrimming.CharacterEllipsis
            };
            dock.Children.Add(_textBlock);
            Child = dock;

            _menu = new ContextMenu
            {
                Background = new SolidColorBrush(Color.FromRgb(0x4A, 0x4A, 0x4E)),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x66, 0x66, 0x6C)),
                BorderThickness = new Thickness(1),
                PlacementTarget = this,
                Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom
            };

            foreach (var item in items)
            {
                AddItem(item);
            }

            SelectedItem = defaultItem;

            MouseEnter += (_, _) => Background = new SolidColorBrush(Color.FromRgb(0x5D, 0x5D, 0x62));
            MouseLeave += (_, _) => Background = new SolidColorBrush(Color.FromRgb(0x52, 0x52, 0x56));
            MouseLeftButtonDown += (_, e) =>
            {
                _menu.MinWidth = Math.Max(ActualWidth, 160);
                _menu.IsOpen = true;
                e.Handled = true;
            };
        }

        public void AddItem(string text)
        {
            _items.Add(text);
            var mi = new MenuItem
            {
                Header = text,
                Foreground = Brushes.White,
                FontSize = 12.5,
                Padding = new Thickness(6, 4, 10, 4)
            };
            mi.Click += (_, _) =>
            {
                SelectedItem = text;
                SelectionChanged?.Invoke(this, text);
            };
            _menu.Items.Add(mi);
        }

        private void UpdateMenuChecks()
        {
            foreach (var obj in _menu.Items)
            {
                if (obj is MenuItem mi)
                {
                    mi.IsChecked = string.Equals(mi.Header as string, _selectedItem, StringComparison.OrdinalIgnoreCase);
                }
            }
        }
    }

    /// <summary>
    /// Exact replica of ProPresenter.UI.PresentationLibrary.NewPresentationDialog (NewPresentationDialog.xaml).
    /// Clean, modern dark dialog with Filename input, Theme preview swatch & picker, Size selector,
    /// Library dropdown, and Playlist dropdown.
    /// </summary>
    public sealed class NewPresentationDialog : Window
    {
        public NewPresentationResult? Result { get; private set; }

        private readonly IReadOnlyList<ThemeTemplateModel> _availableThemes;
        private readonly IReadOnlyList<string> _availableLibraries;
        private readonly IReadOnlyList<string> _availablePlaylists;

        private ThemeTemplateModel _selectedTheme;
        private TextBox _nameTextBox = null!;
        private TextBlock _placeholderBlock = null!;
        private Border _themePreviewCard = null!;
        private TextBlock _themeSampleText = null!;
        private ProPresenterDropDownButton _sizeDropDown = null!;
        private ProPresenterDropDownButton _libraryDropDown = null!;
        private ProPresenterDropDownButton _playlistDropDown = null!;

        public NewPresentationDialog(
            IReadOnlyList<ThemeTemplateModel> themes,
            IReadOnlyList<string>? libraries = null,
            IReadOnlyList<string>? playlists = null,
            string? defaultPlaylist = null)
        {
            _availableThemes = (themes != null && themes.Count > 0)
                ? themes
                : new List<ThemeTemplateModel> { new ThemeTemplateModel { Name = "Default", TextColor = Colors.White } };

            _selectedTheme = _availableThemes[0];

            _availableLibraries = (libraries != null && libraries.Count > 0)
                ? libraries
                : new List<string> { "Default", "Worship Songs", "Teaching / Sermons", "Youth", "Bible Scripture" };

            _availablePlaylists = playlists ?? new List<string>();

            Title = "New Presentation";
            Width = 420;
            SizeToContent = SizeToContent.Height;
            ResizeMode = ResizeMode.NoResize;
            WindowStyle = WindowStyle.None;
            AllowsTransparency = false;
            ShowInTaskbar = false;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            Background = new SolidColorBrush(Color.FromRgb(0x36, 0x36, 0x39));
            Foreground = Brushes.White;

            BuildDialogLayout(defaultPlaylist);
        }

        private void BuildDialogLayout(string? defaultPlaylist)
        {
            var rootBorder = new Border
            {
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x50, 0x50, 0x55)),
                BorderThickness = new Thickness(1),
                Background = new SolidColorBrush(Color.FromRgb(0x36, 0x36, 0x39)),
                Padding = new Thickness(16, 14, 16, 14)
            };

            // Allow dragging the borderless dialog
            rootBorder.MouseLeftButtonDown += (_, e) =>
            {
                if (e.ButtonState == MouseButtonState.Pressed)
                    try { DragMove(); } catch { }
            };

            var mainGrid = new Grid();
            mainGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto }); // 0: Filename
            mainGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto }); // 1: Theme
            mainGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto }); // 2: Size
            mainGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto }); // 3: Library
            mainGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto }); // 4: Playlist
            mainGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto }); // 5: Action buttons

            // -------------------------------------------------------------
            // Row 0: Filename Box with "Filename" placeholder
            // -------------------------------------------------------------
            var nameContainer = new Grid
            {
                Margin = new Thickness(0, 0, 0, 14)
            };
            var nameBorder = new Border
            {
                Height = 28,
                Background = new SolidColorBrush(Color.FromRgb(0x28, 0x28, 0x2B)),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x00, 0x7A, 0xFF)),
                BorderThickness = new Thickness(1),
                CornerRadius = new CornerRadius(3)
            };
            _placeholderBlock = new TextBlock
            {
                Text = "Filename",
                Foreground = new SolidColorBrush(Color.FromRgb(0x78, 0x78, 0x7E)),
                FontSize = 13,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(8, 0, 0, 0),
                IsHitTestVisible = false
            };
            _nameTextBox = new TextBox
            {
                Background = Brushes.Transparent,
                BorderThickness = new Thickness(0),
                Foreground = Brushes.White,
                CaretBrush = Brushes.White,
                FontSize = 13,
                VerticalContentAlignment = VerticalAlignment.Center,
                Padding = new Thickness(6, 0, 6, 0)
            };
            _nameTextBox.GotFocus += (_, _) =>
            {
                nameBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(0x00, 0x7A, 0xFF));
                _nameTextBox.SelectAll();
            };
            _nameTextBox.LostFocus += (_, _) =>
            {
                nameBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(0x42, 0x42, 0x48));
                _placeholderBlock.Visibility = string.IsNullOrEmpty(_nameTextBox.Text) ? Visibility.Visible : Visibility.Collapsed;
            };
            _nameTextBox.TextChanged += (_, _) =>
            {
                _placeholderBlock.Visibility = string.IsNullOrEmpty(_nameTextBox.Text) ? Visibility.Visible : Visibility.Collapsed;
            };

            var nameGrid = new Grid();
            nameGrid.Children.Add(_placeholderBlock);
            nameGrid.Children.Add(_nameTextBox);
            nameBorder.Child = nameGrid;
            nameContainer.Children.Add(nameBorder);
            Grid.SetRow(nameContainer, 0);
            mainGrid.Children.Add(nameContainer);

            // -------------------------------------------------------------
            // Row 1: Theme Swatch + Dropdown Arrow
            // -------------------------------------------------------------
            var themeGrid = new Grid { Margin = new Thickness(0, 0, 0, 10) };
            themeGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(58) });
            themeGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            themeGrid.Children.Add(new TextBlock
            {
                Text = "Theme:",
                FontSize = 13,
                Foreground = Brushes.White,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            });

            var themeStack = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                VerticalAlignment = VerticalAlignment.Center
            };

            _themePreviewCard = new Border
            {
                Width = 76,
                Height = 44,
                CornerRadius = new CornerRadius(2),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x48, 0x48, 0x4C)),
                BorderThickness = new Thickness(1),
                Background = CreateCheckerboardBrush(),
                Cursor = Cursors.Hand
            };
            _themeSampleText = new TextBlock
            {
                Text = "Text",
                FontSize = 11,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.White,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            _themePreviewCard.Child = _themeSampleText;
            _themePreviewCard.MouseLeftButtonDown += (_, _) => ShowThemePickerMenu();
            themeStack.Children.Add(_themePreviewCard);

            // Dropdown arrow
            var arrowBlock = new TextBlock
            {
                Text = "▼",
                FontSize = 8,
                Foreground = new SolidColorBrush(Color.FromRgb(0xA0, 0xA0, 0xA5)),
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(8, 0, 0, 0),
                Cursor = Cursors.Hand
            };
            arrowBlock.MouseLeftButtonDown += (_, _) => ShowThemePickerMenu();
            themeStack.Children.Add(arrowBlock);

            Grid.SetColumn(themeStack, 1);
            themeGrid.Children.Add(themeStack);
            Grid.SetRow(themeGrid, 1);
            mainGrid.Children.Add(themeGrid);

            // -------------------------------------------------------------
            // Row 2: Size Selector (ProPresenter DropDownButton, #525256)
            // -------------------------------------------------------------
            var sizeGrid = new Grid { Margin = new Thickness(0, 0, 0, 10) };
            sizeGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(58) });
            sizeGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            sizeGrid.Children.Add(new TextBlock
            {
                Text = "Size:",
                FontSize = 13,
                Foreground = Brushes.White,
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 0, 8, 0)
            });

            var sizes = new[] { "1920 x 1080", "1280 x 720", "3840 x 2160", "1920 x 1200", "1024 x 768" };
            _sizeDropDown = new ProPresenterDropDownButton(sizes, "1920 x 1080");
            Grid.SetColumn(_sizeDropDown, 1);
            sizeGrid.Children.Add(_sizeDropDown);
            Grid.SetRow(sizeGrid, 2);
            mainGrid.Children.Add(sizeGrid);

            // -------------------------------------------------------------
            // Row 3: Library Dropdown (ProPresenter DropDownButton, #525256)
            // -------------------------------------------------------------
            var libGrid = new Grid { Margin = new Thickness(0, 0, 0, 10) };
            libGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(58) });
            libGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            libGrid.Children.Add(new TextBlock
            {
                Text = "Library:",
                FontSize = 13,
                Foreground = Brushes.White,
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 0, 8, 0)
            });

            _libraryDropDown = new ProPresenterDropDownButton(_availableLibraries, _availableLibraries[0]);
            Grid.SetColumn(_libraryDropDown, 1);
            libGrid.Children.Add(_libraryDropDown);
            Grid.SetRow(libGrid, 3);
            mainGrid.Children.Add(libGrid);

            // -------------------------------------------------------------
            // Row 4: Playlist Dropdown (ProPresenter DropDownButton, #525256)
            // -------------------------------------------------------------
            var plGrid = new Grid { Margin = new Thickness(0, 0, 0, 16) };
            plGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(58) });
            plGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            plGrid.Children.Add(new TextBlock
            {
                Text = "Playlist:",
                FontSize = 13,
                Foreground = Brushes.White,
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 0, 8, 0)
            });

            var plItems = new List<string> { "No Playlist" };
            plItems.AddRange(_availablePlaylists);
            string chosenDefaultPl = (!string.IsNullOrEmpty(defaultPlaylist) && _availablePlaylists.Contains(defaultPlaylist))
                ? defaultPlaylist
                : "No Playlist";

            _playlistDropDown = new ProPresenterDropDownButton(plItems, chosenDefaultPl);
            Grid.SetColumn(_playlistDropDown, 1);
            plGrid.Children.Add(_playlistDropDown);
            Grid.SetRow(plGrid, 4);
            mainGrid.Children.Add(plGrid);

            // -------------------------------------------------------------
            // Row 5: Action Buttons (Cancel / New)
            // -------------------------------------------------------------
            var btnStack = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Right
            };

            var cancelBtn = new Button
            {
                Content = "Cancel",
                Width = 84,
                Height = 26,
                Background = new SolidColorBrush(Color.FromRgb(0x52, 0x52, 0x56)),
                Foreground = Brushes.White,
                FontSize = 12,
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x64, 0x64, 0x6A)),
                BorderThickness = new Thickness(1),
                Cursor = Cursors.Hand,
                IsCancel = true
            };
            cancelBtn.Click += (_, _) =>
            {
                DialogResult = false;
                Close();
            };
            btnStack.Children.Add(cancelBtn);

            var newBtn = new Button
            {
                Content = "New",
                Width = 84,
                Height = 26,
                Margin = new Thickness(10, 0, 0, 0),
                Background = new SolidColorBrush(Color.FromRgb(0x4E, 0x4E, 0x52)),
                Foreground = Brushes.White,
                FontSize = 12,
                FontWeight = FontWeights.SemiBold,
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x00, 0x7A, 0xFF)),
                BorderThickness = new Thickness(1),
                Cursor = Cursors.Hand,
                IsDefault = true
            };
            newBtn.Click += (_, _) => SubmitDialog();
            btnStack.Children.Add(newBtn);

            Grid.SetRow(btnStack, 5);
            mainGrid.Children.Add(btnStack);

            rootBorder.Child = mainGrid;
            Content = rootBorder;

            UpdateThemePreview();

            Loaded += (_, _) =>
            {
                _nameTextBox.Focus();
                _nameTextBox.SelectAll();
            };
        }

        private void SubmitDialog()
        {
            string name = _nameTextBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
                name = "Untitled Presentation";

            string sizeStr = _sizeDropDown.SelectedItem ?? "1920 x 1080";
            int w = 1920, h = 1080;
            var parts = sizeStr.Split('x');
            if (parts.Length == 2 && int.TryParse(parts[0].Trim(), out int pw) && int.TryParse(parts[1].Trim(), out int ph))
            {
                w = pw;
                h = ph;
            }

            string library = _libraryDropDown.SelectedItem ?? "Default";
            string playlist = _playlistDropDown.SelectedItem ?? "No Playlist";

            Result = new NewPresentationResult
            {
                Name = name,
                Theme = _selectedTheme,
                SizeString = sizeStr,
                Width = w,
                Height = h,
                Library = library,
                Playlist = playlist
            };

            DialogResult = true;
            Close();
        }

        private void UpdateThemePreview()
        {
            if (_selectedTheme == null) return;

            _themeSampleText.Text = _selectedTheme.IsUppercase ? "TEXT" : "Text";
            _themeSampleText.Foreground = new SolidColorBrush(_selectedTheme.TextColor);

            try
            {
                _themeSampleText.FontFamily = new FontFamily(_selectedTheme.FontFamily);
            }
            catch { }

            _themeSampleText.FontWeight = _selectedTheme.IsBold ? FontWeights.Bold : FontWeights.Normal;
        }

        private void ShowThemePickerMenu()
        {
            var menu = new ContextMenu
            {
                Background = new SolidColorBrush(Color.FromRgb(0x4A, 0x4A, 0x4E)),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x66, 0x66, 0x6C)),
                BorderThickness = new Thickness(1),
                PlacementTarget = _themePreviewCard,
                Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom
            };

            foreach (var th in _availableThemes)
            {
                var captured = th;
                var item = new MenuItem
                {
                    Header = captured.Name,
                    Foreground = Brushes.White,
                    FontSize = 12.5,
                    IsChecked = ReferenceEquals(_selectedTheme, captured)
                };

                // Mini preview icon
                var iconBorder = new Border
                {
                    Width = 24,
                    Height = 14,
                    Background = CreateCheckerboardBrush(),
                    BorderBrush = new SolidColorBrush(Color.FromRgb(0x60, 0x60, 0x65)),
                    BorderThickness = new Thickness(1),
                    CornerRadius = new CornerRadius(1.5),
                    Margin = new Thickness(0, 0, 4, 0)
                };
                var iconText = new TextBlock
                {
                    Text = "T",
                    FontSize = 9,
                    FontWeight = captured.IsBold ? FontWeights.Bold : FontWeights.Normal,
                    Foreground = new SolidColorBrush(captured.TextColor),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };
                iconBorder.Child = iconText;
                item.Icon = iconBorder;

                item.Click += (_, _) =>
                {
                    _selectedTheme = captured;
                    UpdateThemePreview();
                };
                menu.Items.Add(item);
            }

            menu.IsOpen = true;
        }

        private static DrawingBrush CreateCheckerboardBrush()
        {
            var brush = new DrawingBrush
            {
                TileMode = TileMode.Tile,
                Viewport = new Rect(0, 0, 12, 12),
                ViewportUnits = BrushMappingMode.Absolute
            };
            var group = new DrawingGroup();
            group.Children.Add(new GeometryDrawing(new SolidColorBrush(Color.FromRgb(0x1E, 0x1E, 0x22)), null, new RectangleGeometry(new Rect(0, 0, 12, 12))));
            group.Children.Add(new GeometryDrawing(new SolidColorBrush(Color.FromRgb(0x2B, 0x2B, 0x30)), null, new RectangleGeometry(new Rect(0, 0, 6, 6))));
            group.Children.Add(new GeometryDrawing(new SolidColorBrush(Color.FromRgb(0x2B, 0x2B, 0x30)), null, new RectangleGeometry(new Rect(6, 6, 6, 6))));
            brush.Drawing = group;
            return brush;
        }
    }
}
