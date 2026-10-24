using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Microsoft.Win32;
using ProPresenterClone.Models;
using ProPresenterClone.Rendering;
using ProPresenterClone.Serialization;
using ProPresenterClone.Services;
using ProPresenterClone.Theming;
using ProPresenterClone.Windows;

namespace ProPresenterClone.UI
{
    /// <summary>
    /// Main ProPresenter Window replicating ProPresenter.MainWindow, MainLayout, MenuLayout,
    /// ToolbarLayout, LibraryView, PresentationViewer, SlideEditorView, ReflowEditor, BiblesViewer,
    /// MediaView, ScreenPreviewControl, TransportStatusControl, and UtilityView.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        // Core Application State
        private readonly ActiveOutputState _outputState = new ActiveOutputState();
        private readonly List<PresentationDocument> _libraryPresentations = new List<PresentationDocument>();
        private readonly List<PlaylistModel> _playlists = new List<PlaylistModel>();
        private readonly List<MediaBinItem> _mediaBinItems = new List<MediaBinItem>();
        private readonly List<AudioTrackItem> _audioTracks = new List<AudioTrackItem>();
        private readonly List<TimerItemModel> _timers = new List<TimerItemModel>();
        private readonly List<StageMessageModel> _messages = new List<StageMessageModel>();
        private readonly List<PropItemModel> _props = new List<PropItemModel>();
        private readonly List<MacroItemModel> _macros = new List<MacroItemModel>();
        private readonly List<ThemeTemplateModel> _themes = new List<ThemeTemplateModel>();
        private readonly List<LookPresetModel> _looks = new List<LookPresetModel>();
        private readonly List<StageLayoutModel> _stageLayouts = new List<StageLayoutModel>();

        private PresentationDocument? _selectedPresentation;
        private SlideItemModel? _selectedEditorSlide;
        private SlideElementModel? _selectedEditorElement;
        private PlaylistModel? _selectedPlaylist;
        private InlineViewMode _activeViewMode = InlineViewMode.Show;
        private string _activeLibraryCategoryFilter = "All Presentations";
        private string _librarySearchQuery = "";
        private string _activeMediaCategoryFilter = "All Media";
        private double _thumbnailWidth = 250.0;
        private bool _isTableMode = false;
        private bool _showArrangements = false;
        private bool _showNotes = false;
        private bool _showTimeline = false;
        private bool _isMediaBinCollapsed = false;
        private bool _isStagePreviewMode = false;
        private double _motionPhase = 0.0;
        private double _transportProgressSeconds = 0.0;
        private double _transportDurationSeconds = 225.0;
        private double _autoAdvanceAccumulator = 0.0;

        // Secondary Windows & Media Player
        private AudienceWindow? _audienceWindow;
        private StageWindow? _stageWindow;
        private readonly MediaPlayer _audioPlayer = new MediaPlayer();
        private readonly DispatcherTimer _engineTimer;

        // UI Containers updated dynamically
        private Grid _rootGrid = null!;
        private TextBox _librarySearchBox = null!;
        private ListBox _libraryCategoryList = null!;
        private ListBox _libraryDocList = null!;
        private ListBox _playlistSelectorList = null!;
        private ListBox _playlistItemsList = null!;
        private Grid _centerContentHost = null!;
        private Grid _mediaBinHost = null!;
        private RowDefinition _mediaBinRowDef = null!;
        private Grid _previewMonitorSurface = null!;
        private TextBlock _previewPresentationTitleLabel = null!;
        private TextBlock _transportTitleLabel = null!;
        private TextBlock _transportTimeLabel = null!;
        private Slider _transportSlider = null!;
        private Button _transportPlayPauseBtn = null!;
        private Grid _utilityTabContentHost = null!;
        private string _activeUtilityTab = "Timers";
        private TextBlock _statusBarText = null!;
        private TextBlock? _leftActivePresentationLabel;
        private TextBox? _leftFilterBox;
        private TextBlock? _rightStatusLabel;
        private string _mediaTransitionName = "Cut";

        // Toolbar Mode Buttons & Clear Layer Buttons
        private readonly Dictionary<InlineViewMode, Button> _modeButtons = new Dictionary<InlineViewMode, Button>();
        private readonly Dictionary<string, Border> _clearLayerButtons = new Dictionary<string, Border>();
        private Border _audienceIndicatorDot = null!;
        private Border _stageIndicatorDot = null!;
        private TextBlock _liveCaptureButtonLabel = null!;
        private Border _liveCaptureButtonBorder = null!;
        private TextBlock _lookButtonLabel = null!;

        public MainWindow()
        {
            Title = "ProPresenter";
            Width = 1600;
            Height = 940;
            MinWidth = 1180;
            MinHeight = 720;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            WindowState = WindowState.Maximized;
            Background = ThemeEngine.Instance.GetBrush("WINDOW_BACKGROUND");

            TrySetWindowIcon();
            ConfigureCustomWindowChrome();
            InitializeApplicationData();
            BuildMainWindowLayout();

            _engineTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(250)
            };
            _engineTimer.Tick += OnEngineTick;
            _engineTimer.Start();

            PreviewKeyDown += OnMainWindowPreviewKeyDown;
            Closed += (_, _) =>
            {
                _engineTimer.Stop();
                _audioPlayer.Close();
                _audienceWindow?.Close();
                _stageWindow?.Close();
            };

            // Select initial presentation (prefer Christ Is Enough if present)
            if (_libraryPresentations.Count > 0)
            {
                var initialPres = _libraryPresentations.FirstOrDefault(p => p.Name.Contains("Christ Is Enough", StringComparison.OrdinalIgnoreCase)) ?? _libraryPresentations[0];
                SelectPresentation(initialPres, triggerFirstSlide: false);
            }
        }

        private void TrySetWindowIcon()
        {
            string icoPath = Path.Combine(ThemeEngine.Instance.AssetsRoot, "ProPresenter.ico");
            if (!File.Exists(icoPath))
                icoPath = @"C:\Program Files\Renewed Vision\ProPresenter\ProPresenter.ico";

            if (File.Exists(icoPath))
            {
                try
                {
                    Icon = new BitmapImage(new Uri(icoPath, UriKind.Absolute));
                }
                catch { }
            }
        }

        private void InitializeApplicationData()
        {
            // 1. Load real .pro presentations from Documents\ProPresenter\Libraries\Default & assets\sample-libraries
            _libraryPresentations.AddRange(ProFileService.LoadAllLibraryPresentations());

            // 2. Load real Themes from Sample Content\Themes & Documents\ProPresenter\Themes
            _themes.AddRange(ProFileService.LoadSampleThemes());

            // 3. Seed Looks & Stage Layouts
            _looks.Add(new LookPresetModel { Name = "Default Fullscreen", UseLowerThirdThemeOverride = false });
            _looks.Add(new LookPresetModel { Name = "Broadcast Lower Thirds", UseLowerThirdThemeOverride = true });
            _looks.Add(new LookPresetModel { Name = "Lyrics Only (No Media)", ShowMediaLayer = false, ShowPropsLayer = false });
            _looks.Add(new LookPresetModel { Name = "Imagery Only (No Slides)", ShowSlideLayer = false });
            _outputState.ActiveLook = _looks[0];

            _stageLayouts.Add(new StageLayoutModel { Name = "Standard Stage (Current + Next + Timers)", LargeTimerMode = false });
            _stageLayouts.Add(new StageLayoutModel { Name = "Worship Leader + Chords & Notes", LargeTimerMode = false });
            _stageLayouts.Add(new StageLayoutModel { Name = "Speaker Giant Timer Focus", LargeTimerMode = true });
            _outputState.ActiveStageLayout = _stageLayouts[0];

            // 4. Load real Media & Audio assets from C:\Users\Phuc Le\Documents\ProPresenter\Media + procedural loops
            SeedMediaAndAudioBins();

            // 5. Seed Playlists referencing loaded .pro presentations and media
            SeedPlaylists();

            // 6. Seed Show Controls: Timers, Messages, Props, Macros
            SeedShowControls();
        }

        private void SeedMediaAndAudioBins()
        {
            // Procedural motion backgrounds matching ProContent worship loops
            _mediaBinItems.Add(new MediaBinItem
            {
                Name = "Midnight Sapphire Particles",
                Category = "Motion Loops",
                Kind = MediaAssetKind.ProceduralMotion,
                PrimaryColor = Color.FromRgb(0x0B, 0x1D, 0x3A),
                SecondaryColor = Color.FromRgb(0x16, 0x3E, 0x7A),
                AccentColor = Color.FromRgb(0x00, 0xA8, 0xFF),
                DurationText = "00:30 LOOP"
            });
            _mediaBinItems.Add(new MediaBinItem
            {
                Name = "Golden Amber Dust",
                Category = "Motion Loops",
                Kind = MediaAssetKind.ProceduralMotion,
                PrimaryColor = Color.FromRgb(0x2A, 0x16, 0x05),
                SecondaryColor = Color.FromRgb(0x6E, 0x38, 0x0B),
                AccentColor = Color.FromRgb(0xFF, 0x9E, 0x22),
                DurationText = "00:30 LOOP"
            });
            _mediaBinItems.Add(new MediaBinItem
            {
                Name = "Royal Violet Nebula",
                Category = "Motion Loops",
                Kind = MediaAssetKind.ProceduralMotion,
                PrimaryColor = Color.FromRgb(0x1A, 0x0B, 0x2E),
                SecondaryColor = Color.FromRgb(0x4A, 0x15, 0x6B),
                AccentColor = Color.FromRgb(0xC8, 0x50, 0xFF),
                DurationText = "00:45 LOOP"
            });
            _mediaBinItems.Add(new MediaBinItem
            {
                Name = "Emerald Forest Horizon",
                Category = "Motion Loops",
                Kind = MediaAssetKind.ProceduralMotion,
                PrimaryColor = Color.FromRgb(0x07, 0x24, 0x1E),
                SecondaryColor = Color.FromRgb(0x11, 0x52, 0x43),
                AccentColor = Color.FromRgb(0x28, 0xD8, 0xA0),
                DurationText = "00:30 LOOP"
            });
            _mediaBinItems.Add(new MediaBinItem
            {
                Name = "Crimson Cross Glow",
                Category = "Motion Loops",
                Kind = MediaAssetKind.ProceduralMotion,
                PrimaryColor = Color.FromRgb(0x2B, 0x08, 0x12),
                SecondaryColor = Color.FromRgb(0x68, 0x12, 0x28),
                AccentColor = Color.FromRgb(0xFF, 0x45, 0x65),
                DurationText = "00:30 LOOP"
            });

            // Scan user's Documents\ProPresenter\Media folder for real images, videos, and audio
            string userMediaDir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "ProPresenter", "Media");

            if (Directory.Exists(userMediaDir))
            {
                Color[] paletteA = { Color.FromRgb(0x1D, 0x2B, 0x53), Color.FromRgb(0x3B, 0x1D, 0x53), Color.FromRgb(0x1D, 0x4D, 0x4F), Color.FromRgb(0x4F, 0x2D, 0x1D) };
                Color[] paletteB = { Color.FromRgb(0x3A, 0x60, 0x98), Color.FromRgb(0x7E, 0x3A, 0x98), Color.FromRgb(0x2A, 0x8F, 0x88), Color.FromRgb(0xA8, 0x5E, 0x2A) };
                int pIdx = 0;

                foreach (string file in Directory.GetFiles(userMediaDir, "*.*", SearchOption.AllDirectories))
                {
                    string ext = Path.GetExtension(file).ToLowerInvariant();
                    string name = Path.GetFileNameWithoutExtension(file);
                    if (ext == ".jpg" || ext == ".jpeg" || ext == ".png")
                    {
                        _mediaBinItems.Add(new MediaBinItem
                        {
                            Name = name.Length > 22 ? "Stills — " + name.Substring(0, 8) : name,
                            Category = "Stills & Imports",
                            Kind = MediaAssetKind.Image,
                            FilePath = file,
                            DurationText = "STILL"
                        });
                    }
                    else if (ext == ".wmv" || ext == ".mp4" || ext == ".mov")
                    {
                        _mediaBinItems.Add(new MediaBinItem
                        {
                            Name = name,
                            Category = "Video Assets",
                            Kind = MediaAssetKind.Video,
                            FilePath = file,
                            PrimaryColor = paletteA[pIdx % paletteA.Length],
                            SecondaryColor = paletteB[pIdx % paletteB.Length],
                            AccentColor = Color.FromRgb(0xF7, 0x82, 0x1C),
                            DurationText = ext.ToUpperInvariant().TrimStart('.') + " VIDEO"
                        });
                        pIdx++;
                    }
                    else if (ext == ".mp3" || ext == ".wav" || ext == ".m4a")
                    {
                        _audioTracks.Add(new AudioTrackItem
                        {
                            Name = name,
                            PlaylistName = "Service Audio",
                            FilePath = file,
                            DurationText = "04:12"
                        });
                    }
                }
            }

            // Ensure rich audio tracks list
            _audioTracks.Add(new AudioTrackItem { Name = "Warm Atmospheric Pad in C", PlaylistName = "Worship Pads", DurationText = "10:00" });
            _audioTracks.Add(new AudioTrackItem { Name = "Shimmering Ambient Pad in G", PlaylistName = "Worship Pads", DurationText = "10:00" });
            _audioTracks.Add(new AudioTrackItem { Name = "Pre-Service Acoustic Instrumental", PlaylistName = "Pre-Service", DurationText = "03:48" });
            _audioTracks.Add(new AudioTrackItem { Name = "Benediction Piano Outro", PlaylistName = "Post-Service", DurationText = "02:55" });
        }

        private void SeedPlaylists()
        {
            var sunday = new PlaylistModel { Name = "Sunday Morning Worship" };
            sunday.Items.Add(new PlaylistItemEntry
            {
                Title = "PRE-SERVICE & COUNTDOWN",
                CueType = PlaylistCueType.Header,
                HeaderColor = Color.FromRgb(0x3A, 0x50, 0x6B)
            });

            if (_mediaBinItems.Count > 0)
            {
                sunday.Items.Add(new PlaylistItemEntry
                {
                    Title = _mediaBinItems[0].Name,
                    CueType = PlaylistCueType.Media,
                    LinkedMedia = _mediaBinItems[0]
                });
            }

            sunday.Items.Add(new PlaylistItemEntry
            {
                Title = "PRAISE & WORSHIP SET",
                CueType = PlaylistCueType.Header,
                HeaderColor = Color.FromRgb(0x8E, 0x3B, 0x46)
            });

            foreach (var pres in _libraryPresentations.Take(6))
            {
                sunday.Items.Add(new PlaylistItemEntry
                {
                    Title = pres.Name,
                    CueType = PlaylistCueType.Presentation,
                    LinkedPresentation = pres
                });
            }

            sunday.Items.Add(new PlaylistItemEntry
            {
                Title = "SERMON & SCRIPTURE",
                CueType = PlaylistCueType.Header,
                HeaderColor = Color.FromRgb(0x2E, 0x6F, 0x40)
            });

            var john316 = BibleService.CreatePresentationFromVerses(
                "John 3:16-17 (KJV)",
                BibleService.Lookup("KJV", "John 3:16-17"));
            _libraryPresentations.Add(john316);
            sunday.Items.Add(new PlaylistItemEntry
            {
                Title = john316.Name,
                CueType = PlaylistCueType.Presentation,
                LinkedPresentation = john316
            });

            _playlists.Add(sunday);

            var evening = new PlaylistModel { Name = "Vietnamese & International Worship" };
            evening.Items.Add(new PlaylistItemEntry
            {
                Title = "CHƯƠNG TRÌNH THỜ PHƯỢNG",
                CueType = PlaylistCueType.Header,
                HeaderColor = Color.FromRgb(0x6B, 0x3A, 0x8E)
            });
            foreach (var pres in _libraryPresentations.Skip(3).Take(8))
            {
                evening.Items.Add(new PlaylistItemEntry
                {
                    Title = pres.Name,
                    CueType = PlaylistCueType.Presentation,
                    LinkedPresentation = pres
                });
            }
            _playlists.Add(evening);
            _selectedPlaylist = sunday;
        }

        private void SeedShowControls()
        {
            _timers.Add(new TimerItemModel
            {
                Name = "Service Countdown",
                Mode = TimerMode.Countdown,
                Duration = TimeSpan.FromMinutes(5),
                Remaining = TimeSpan.FromMinutes(4) + TimeSpan.FromSeconds(45),
                IsRunning = true
            });
            _timers.Add(new TimerItemModel
            {
                Name = "Sermon Timer",
                Mode = TimerMode.Countdown,
                Duration = TimeSpan.FromMinutes(35),
                Remaining = TimeSpan.FromMinutes(35),
                IsRunning = false
            });
            _timers.Add(new TimerItemModel
            {
                Name = "Worship Elapsed",
                Mode = TimerMode.CountUp,
                Duration = TimeSpan.Zero,
                Remaining = TimeSpan.Zero,
                IsRunning = false
            });

            _messages.Add(new StageMessageModel
            {
                Title = "Childcare Pager Alert",
                TemplateText = "Childcare Needed: Parent Pager #{Number}",
                TokenName = "Number",
                TokenValue = "142",
                ShowOnAudience = true,
                ShowOnStage = true
            });
            _messages.Add(new StageMessageModel
            {
                Title = "Stage Worship Note",
                TemplateText = "Band Cue: {Note}",
                TokenName = "Note",
                TokenValue = "Build into Chorus in C Major",
                ShowOnAudience = false,
                ShowOnStage = true
            });
            _messages.Add(new StageMessageModel
            {
                Title = "Parking Lot Alert",
                TemplateText = "Vehicle Lights On — License Plate: {Plate}",
                TokenName = "Plate",
                TokenValue = "7ABC-892",
                ShowOnAudience = true,
                ShowOnStage = false
            });

            _props.Add(new PropItemModel
            {
                Name = "Church Broadcast Bug",
                BadgeText = "RENEWED VISION CHURCH",
                SubText = "Sunday Live Broadcast",
                Position = "TopRight",
                PrimaryColor = Color.FromRgb(0x00, 0x7A, 0xFF)
            });
            _props.Add(new PropItemModel
            {
                Name = "Countdown Corner Overlay",
                BadgeText = "SERVICE STARTS IN {Timer}",
                SubText = "Welcome! Please find a seat",
                Position = "BottomLeft",
                PrimaryColor = Color.FromRgb(0xF7, 0x82, 0x1C)
            });
            _props.Add(new PropItemModel
            {
                Name = "Lower Third Speaker Title",
                BadgeText = "PASTOR DAVID MILLER",
                SubText = "Series: Grace Upon Grace • John 3:16",
                Position = "BottomLeft",
                PrimaryColor = Color.FromRgb(0x1E, 0x24, 0x32)
            });

            _macros.Add(new MacroItemModel
            {
                Name = "Start Pre-Service Countdown",
                Description = "Starts 5:00 Timer + Motion Loop + Countdown Prop",
                Color = Color.FromRgb(0xF7, 0x82, 0x1C),
                ActionType = "PreService"
            });
            _macros.Add(new MacroItemModel
            {
                Name = "Worship Fullscreen Look",
                Description = "Switches to Fullscreen Look + Clears Props + Triggers Sapphire Motion",
                Color = Color.FromRgb(0x00, 0x7A, 0xFF),
                ActionType = "WorshipMode"
            });
            _macros.Add(new MacroItemModel
            {
                Name = "Broadcast Lower Thirds Look",
                Description = "Activates Lower-Thirds Look + Camera Input + Broadcast Bug",
                Color = Color.FromRgb(0x61, 0xBA, 0x46),
                ActionType = "LowerThirdMode"
            });
            _macros.Add(new MacroItemModel
            {
                Name = "Sermon Stage & Timer",
                Description = "Starts 35:00 Sermon Timer + Speaker Title Prop + Stage Layout",
                Color = Color.FromRgb(0x99, 0x6F, 0xD6),
                ActionType = "SermonMode"
            });
            _macros.Add(new MacroItemModel
            {
                Name = "Clear All & Fade Out",
                Description = "Clears All Layers, Stops Audio, Resets Stage Message",
                Color = Color.FromRgb(0xD0, 0x1F, 0x1F),
                ActionType = "ClearAll"
            });
        }

        private void BuildMainWindowLayout()
        {
            _rootGrid = new Grid
            {
                Background = ThemeEngine.Instance.GetBrush("MAINCONTENT")
            };
            _rootGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto }); // MenuBar
            _rootGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(54) }); // Main ToolbarLayout
            _rootGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }); // Workspace (fills to bottom)

            // Row 0: Menu Bar
            var menuBar = BuildMenuBar();
            Grid.SetRow(menuBar, 0);
            _rootGrid.Children.Add(menuBar);

            // Row 1: Main Toolbar (ToolbarLayout.xaml replica)
            var toolbar = BuildToolbarLayout();
            Grid.SetRow(toolbar, 1);
            _rootGrid.Children.Add(toolbar);

            // Row 2: Main 3-Column Workspace (Left Library/Playlists, Center Presentation/Editors/MediaBin, Right Preview/Transport/UtilityView)
            var workspaceGrid = new Grid();
            workspaceGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(270), MinWidth = 210 });
            workspaceGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(4) });
            workspaceGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star), MinWidth = 480 });
            workspaceGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(4) });
            workspaceGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(410), MinWidth = 340 });

            var leftColumn = BuildLeftLibraryAndPlaylistColumn();
            Grid.SetColumn(leftColumn, 0);
            workspaceGrid.Children.Add(leftColumn);

            var leftSplitter = new GridSplitter
            {
                Width = 4,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Background = Brushes.Black
            };
            Grid.SetColumn(leftSplitter, 1);
            workspaceGrid.Children.Add(leftSplitter);

            // Center Column: Top = Active Inline View (Show / Edit / Reflow / Bible), Bottom = Media Bin
            var centerColumnGrid = new Grid();
            centerColumnGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star), MinHeight = 260 });
            centerColumnGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            _mediaBinRowDef = new RowDefinition { Height = new GridLength(215), MinHeight = 0 };
            centerColumnGrid.RowDefinitions.Add(_mediaBinRowDef);

            _centerContentHost = new Grid
            {
                Background = ThemeEngine.Instance.GetBrush("PRESENTATION_BACKGROUND", Color.FromRgb(0x1E, 0x1E, 0x1E))
            };
            Grid.SetRow(_centerContentHost, 0);
            centerColumnGrid.Children.Add(_centerContentHost);

            var mediaSplitter = new GridSplitter
            {
                Height = 4,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Center,
                Background = Brushes.Black
            };
            Grid.SetRow(mediaSplitter, 1);
            centerColumnGrid.Children.Add(mediaSplitter);

            _mediaBinHost = new Grid
            {
                Background = ThemeEngine.Instance.GetBrush("CONTAINER", Color.FromRgb(0x1B, 0x1B, 0x1B))
            };
            RebuildMediaBinView();
            Grid.SetRow(_mediaBinHost, 2);
            centerColumnGrid.Children.Add(_mediaBinHost);

            Grid.SetColumn(centerColumnGrid, 2);
            workspaceGrid.Children.Add(centerColumnGrid);

            var rightSplitter = new GridSplitter
            {
                Width = 4,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Background = Brushes.Black
            };
            Grid.SetColumn(rightSplitter, 3);
            workspaceGrid.Children.Add(rightSplitter);

            var rightColumn = BuildRightDockColumn();
            Grid.SetColumn(rightColumn, 4);
            workspaceGrid.Children.Add(rightColumn);

            Grid.SetRow(workspaceGrid, 2);
            _rootGrid.Children.Add(workspaceGrid);

            _statusBarText = new TextBlock
            {
                Text = $"Ready • Loaded {_libraryPresentations.Count} native .pro presentations & {_themes.Count} themes from ProPresenter installation",
                Foreground = new SolidColorBrush(Color.FromRgb(0x9E, 0x9E, 0x9E)),
                FontSize = 11,
                Visibility = Visibility.Collapsed
            };

            Content = _rootGrid;
            RefreshLibraryViewLists();
            RefreshPlaylistViews();
            RebuildCenterWorkspace();
            RefreshPreviewAndOutputs();
        }

        private static MenuItem CreateTopMenuItem(string header)
        {
            return new MenuItem
            {
                Header = header,
                Foreground = new SolidColorBrush(Color.FromRgb(0xF2, 0xF2, 0xF2)),
                Background = Brushes.Transparent,
                Padding = new Thickness(8, 3, 8, 3)
            };
        }

        private static MenuItem CreateSubMenuItem(string header, string gesture, System.Action onClick)
        {
            var item = new MenuItem
            {
                Header = header,
                InputGestureText = gesture
            };
            item.Click += (_, _) => onClick();
            return item;
        }

        private FrameworkElement BuildToolbarLayout()
        {
            var bar = new Border
            {
                Background = ThemeEngine.Instance.GetBrush("HEADER", Color.FromRgb(0x12, 0x12, 0x12)),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x2C, 0x2C, 0x2C)),
                BorderThickness = new Thickness(0, 0, 0, 1),
                Padding = new Thickness(10, 4, 10, 4)
            };

            var grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto }); // Search + New
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(18) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto }); // Text + Theme
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(28) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto }); // Show / Edit / Reflow / Bible / More
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto }); // Media / Look / Live
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(18) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto }); // Audience / Stage toggles

            // Column 0: Search & New
            var leftStack = new StackPanel { Orientation = Orientation.Horizontal };
            leftStack.Children.Add(CreateToolbarIconButton("Search", "toolbar/toolbarsearch-2x.png", () => ShowQuickSearchDialog()));
            leftStack.Children.Add(CreateToolbarSeparator());
            leftStack.Children.Add(CreateToolbarIconButton("New .pro", "add_folder.png", () => PromptNewPresentation()));
            leftStack.Children.Add(CreateToolbarIconButton("Import", "saveicon.png", () => PromptImportProFile()));
            Grid.SetColumn(leftStack, 0);
            grid.Children.Add(leftStack);

            // Column 2: Text Style & Theme Picker
            var styleStack = new StackPanel { Orientation = Orientation.Horizontal };
            styleStack.Children.Add(CreateToolbarIconButton("Text", "toolbar/toolbartextstyle-2x.png", () => ShowQuickTextStylePopover()));
            styleStack.Children.Add(CreateToolbarSeparator());
            styleStack.Children.Add(CreateToolbarIconButton("Theme", "toolbar/toolbartheme-2x.png", () => ShowThemePickerDialog()));
            Grid.SetColumn(styleStack, 2);
            grid.Children.Add(styleStack);

            // Column 4: Central View Mode Switcher (Show | Edit | Reflow | Bible | More)
            var viewGroupBorder = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(0x22, 0x22, 0x26)),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x3E, 0x3E, 0x46)),
                BorderThickness = new Thickness(1),
                CornerRadius = new CornerRadius(5),
                Padding = new Thickness(2)
            };
            var viewStack = new StackPanel { Orientation = Orientation.Horizontal };
            _modeButtons.Clear();

            var showBtn = CreateToolbarIconButton("Show", "toolbar/toolbarpresentation.png", () => SwitchViewMode(InlineViewMode.Show));
            var editBtn = CreateToolbarIconButton("Edit", "toolbar/toolbareditor-2x.png", () => SwitchViewMode(InlineViewMode.Edit));
            var reflowBtn = CreateToolbarIconButton("Reflow", "toolbar/toolbarreflow-2x.png", () => SwitchViewMode(InlineViewMode.Reflow));
            var bibleBtn = CreateToolbarIconButton("Bible", "toolbar/toolbarbible-2x.png", () => SwitchViewMode(InlineViewMode.Bible));
            var moreBtn = CreateToolbarIconButton("More ▾", "toolbar/toolbarmore.png", () => ShowMoreEditorsMenu());

            _modeButtons[InlineViewMode.Show] = showBtn;
            _modeButtons[InlineViewMode.Edit] = editBtn;
            _modeButtons[InlineViewMode.Reflow] = reflowBtn;
            _modeButtons[InlineViewMode.Bible] = bibleBtn;

            viewStack.Children.Add(showBtn);
            viewStack.Children.Add(CreateToolbarSeparator());
            viewStack.Children.Add(editBtn);
            viewStack.Children.Add(CreateToolbarSeparator());
            viewStack.Children.Add(reflowBtn);
            viewStack.Children.Add(CreateToolbarSeparator());
            viewStack.Children.Add(bibleBtn);
            viewStack.Children.Add(CreateToolbarSeparator());
            viewStack.Children.Add(moreBtn);

            viewGroupBorder.Child = viewStack;
            Grid.SetColumn(viewGroupBorder, 4);
            grid.Children.Add(viewGroupBorder);

            // Column 6: Media Bin, Look Selector, Live Capture
            var rightToolsStack = new StackPanel { Orientation = Orientation.Horizontal };
            rightToolsStack.Children.Add(CreateToolbarIconButton("Media", "toolbar/toolbarmediabin.png", () => ToggleMediaBin()));
            rightToolsStack.Children.Add(CreateToolbarSeparator());

            var lookBtn = CreateToolbarIconButton("Look", "toolbar/toolbarstage-2x.png", () => CycleLookPreset(), out _lookButtonLabel);
            _lookButtonLabel.Text = _outputState.ActiveLook.Name;
            rightToolsStack.Children.Add(lookBtn);
            rightToolsStack.Children.Add(CreateToolbarSeparator());

            // Live Capture Button
            _liveCaptureButtonBorder = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(0x2B, 0x2B, 0x30)),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x4A, 0x4A, 0x52)),
                BorderThickness = new Thickness(1),
                CornerRadius = new CornerRadius(5),
                Padding = new Thickness(10, 4, 10, 4),
                Margin = new Thickness(3, 0, 3, 0),
                Cursor = Cursors.Hand
            };
            var liveStack = new StackPanel { Orientation = Orientation.Vertical, HorizontalAlignment = HorizontalAlignment.Center };
            liveStack.Children.Add(new TextBlock
            {
                Text = "● REC / LIVE",
                Foreground = Brushes.White,
                FontSize = 11,
                FontWeight = FontWeights.Bold,
                HorizontalAlignment = HorizontalAlignment.Center
            });
            _liveCaptureButtonLabel = new TextBlock
            {
                Text = "Stream Off",
                Foreground = new SolidColorBrush(Color.FromRgb(0xB8, 0xB8, 0xC0)),
                FontSize = 10,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            liveStack.Children.Add(_liveCaptureButtonLabel);
            _liveCaptureButtonBorder.Child = liveStack;
            _liveCaptureButtonBorder.MouseLeftButtonDown += (_, _) => ToggleLiveCapture();
            rightToolsStack.Children.Add(_liveCaptureButtonBorder);

            Grid.SetColumn(rightToolsStack, 6);
            grid.Children.Add(rightToolsStack);

            // Column 8: Audience & Stage Output Screen Toggles (matching ToolbarLayout.xaml TwoStateIcon)
            var screensPanel = new StackPanel { Orientation = Orientation.Horizontal, VerticalAlignment = VerticalAlignment.Center };
            screensPanel.Children.Add(CreateScreenToggleControl("Audience", true, out _audienceIndicatorDot, () => ToggleAudienceOutputWindow(forceOpenWindow: true)));
            screensPanel.Children.Add(CreateScreenToggleControl("Stage", false, out _stageIndicatorDot, () => ToggleStageOutputWindow(forceOpenWindow: true)));
            Grid.SetColumn(screensPanel, 8);
            grid.Children.Add(screensPanel);

            bar.Child = grid;
            UpdateToolbarModeButtonsVisual();
            return bar;
        }

        private Button CreateToolbarIconButton(string label, string iconRelPath, System.Action onClick)
        {
            return CreateToolbarIconButton(label, iconRelPath, onClick, out _);
        }

        private Button CreateToolbarIconButton(string label, string iconRelPath, System.Action onClick, out TextBlock labelBlock)
        {
            var stack = new StackPanel
            {
                Orientation = Orientation.Vertical,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            var iconSrc = ThemeEngine.Instance.GetIcon(iconRelPath);
            if (iconSrc != null)
            {
                stack.Children.Add(new Image
                {
                    Source = iconSrc,
                    Width = 17,
                    Height = 17,
                    Margin = new Thickness(0, 1, 0, 2),
                    HorizontalAlignment = HorizontalAlignment.Center
                });
            }
            else
            {
                stack.Children.Add(new TextBlock
                {
                    Text = "◈",
                    Foreground = Brushes.White,
                    FontSize = 13,
                    HorizontalAlignment = HorizontalAlignment.Center
                });
            }

            labelBlock = new TextBlock
            {
                Text = label,
                Foreground = new SolidColorBrush(Color.FromRgb(0xDC, 0xDC, 0xE2)),
                FontSize = 10.5,
                FontWeight = FontWeights.Medium,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            stack.Children.Add(labelBlock);

            var btn = new Button
            {
                Content = stack,
                Background = Brushes.Transparent,
                BorderBrush = Brushes.Transparent,
                BorderThickness = new Thickness(1),
                Padding = new Thickness(10, 2, 10, 2),
                Cursor = Cursors.Hand
            };
            btn.Click += (_, _) => onClick();
            return btn;
        }

        private static Border CreateToolbarSeparator()
        {
            return new Border
            {
                Width = 1,
                Margin = new Thickness(3, 5, 3, 5),
                Background = new SolidColorBrush(Color.FromRgb(0x3D, 0x3D, 0x45))
            };
        }

        private Border CreateScreenToggleControl(string label, bool initialState, out Border indicatorDot, System.Action onClick)
        {
            indicatorDot = new Border
            {
                Width = 11,
                Height = 11,
                CornerRadius = new CornerRadius(5.5),
                Background = new SolidColorBrush(initialState ? Color.FromRgb(0x33, 0xFD, 0x00) : Color.FromRgb(0xE0, 0x35, 0x35)),
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(1),
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 2, 0, 3)
            };

            var stack = new StackPanel { Orientation = Orientation.Vertical, HorizontalAlignment = HorizontalAlignment.Center };
            stack.Children.Add(indicatorDot);
            stack.Children.Add(new TextBlock
            {
                Text = label,
                Foreground = Brushes.White,
                FontSize = 10.5,
                FontWeight = FontWeights.SemiBold,
                HorizontalAlignment = HorizontalAlignment.Center
            });

            var box = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(0x25, 0x25, 0x2B)),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x42, 0x42, 0x4C)),
                BorderThickness = new Thickness(1),
                CornerRadius = new CornerRadius(5),
                Padding = new Thickness(11, 3, 11, 3),
                Margin = new Thickness(4, 0, 0, 0),
                Cursor = Cursors.Hand,
                ToolTip = $"Click to toggle {label} output window",
                Child = stack
            };
            box.MouseLeftButtonDown += (_, _) => onClick();
            return box;
        }

        private FrameworkElement BuildLeftLibraryAndPlaylistColumn()
        {
            var leftGrid = new Grid
            {
                Background = ThemeEngine.Instance.GetBrush("OUTLINEDETAIL", Color.FromRgb(0x2F, 0x2F, 0x2F))
            };
            leftGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(5.5, GridUnitType.Star), MinHeight = 180 });
            leftGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(4) });
            leftGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(4.5, GridUnitType.Star), MinHeight = 160 });
            leftGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto }); // Row 3: Presentation Selector + Filter Bar

            // Top Half: Library View
            var libGrid = new Grid();
            libGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto }); // Header
            libGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto }); // Search Box
            libGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(95) }); // Library Folders
            libGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }); // Presentations in Library

            var libHeader = CreateSectionHeader("LIBRARIES", "+ New", () => PromptNewPresentation());
            Grid.SetRow(libHeader, 0);
            libGrid.Children.Add(libHeader);

            var searchBorder = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(0x1E, 0x1E, 0x22)),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x44, 0x44, 0x4C)),
                BorderThickness = new Thickness(1),
                CornerRadius = new CornerRadius(4),
                Margin = new Thickness(8, 6, 8, 6),
                Padding = new Thickness(6, 3, 6, 3)
            };
            _librarySearchBox = new TextBox
            {
                Background = Brushes.Transparent,
                Foreground = Brushes.White,
                CaretBrush = Brushes.White,
                BorderThickness = new Thickness(0),
                FontSize = 12,
                ToolTip = "Filter library presentations by title or lyrics..."
            };
            _librarySearchBox.TextChanged += (_, _) =>
            {
                _librarySearchQuery = _librarySearchBox.Text.Trim();
                RefreshLibraryDocumentList();
            };
            searchBorder.Child = _librarySearchBox;
            Grid.SetRow(searchBorder, 1);
            libGrid.Children.Add(searchBorder);

            _libraryCategoryList = new ListBox
            {
                Background = ThemeEngine.Instance.GetBrush("OUTLINESOURCE", Color.FromRgb(0x3B, 0x3B, 0x3F)),
                Foreground = Brushes.White,
                BorderThickness = new Thickness(0, 0, 0, 1),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x22, 0x22, 0x22)),
                FontSize = 12
            };
            _libraryCategoryList.SelectionChanged += (_, _) =>
            {
                if (_libraryCategoryList.SelectedItem is ListBoxItem item && item.Tag is string cat)
                {
                    _activeLibraryCategoryFilter = cat;
                    RefreshLibraryDocumentList();
                }
            };
            Grid.SetRow(_libraryCategoryList, 2);
            libGrid.Children.Add(_libraryCategoryList);

            _libraryDocList = new ListBox
            {
                Background = ThemeEngine.Instance.GetBrush("OUTLINEDETAIL", Color.FromRgb(0x2B, 0x2B, 0x2F)),
                Foreground = Brushes.White,
                BorderThickness = new Thickness(0),
                FontSize = 12.5
            };
            _libraryDocList.SelectionChanged += (_, _) =>
            {
                if (_libraryDocList.SelectedItem is ListBoxItem item && item.Tag is PresentationDocument doc)
                {
                    SelectPresentation(doc, triggerFirstSlide: false);
                }
            };
            Grid.SetRow(_libraryDocList, 3);
            libGrid.Children.Add(_libraryDocList);

            Grid.SetRow(libGrid, 0);
            leftGrid.Children.Add(libGrid);

            var midSplitter = new GridSplitter
            {
                Height = 4,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Background = Brushes.Black
            };
            Grid.SetRow(midSplitter, 1);
            leftGrid.Children.Add(midSplitter);

            // Bottom Half: Playlists View
            var playGrid = new Grid();
            playGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto }); // Header
            playGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(82) }); // Playlist Folders
            playGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }); // Playlist Items

            var playHeader = CreateSectionHeader("PLAYLISTS", "+ Item", () => AddSelectedPresentationToPlaylist());
            Grid.SetRow(playHeader, 0);
            playGrid.Children.Add(playHeader);

            _playlistSelectorList = new ListBox
            {
                Background = ThemeEngine.Instance.GetBrush("OUTLINESOURCE", Color.FromRgb(0x3B, 0x3B, 0x3F)),
                Foreground = Brushes.White,
                BorderThickness = new Thickness(0, 0, 0, 1),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x22, 0x22, 0x22)),
                FontSize = 12
            };
            _playlistSelectorList.SelectionChanged += (_, _) =>
            {
                if (_playlistSelectorList.SelectedItem is ListBoxItem item && item.Tag is PlaylistModel pl)
                {
                    _selectedPlaylist = pl;
                    RefreshPlaylistItemsList();
                    UpdateRightColumnBottomStatus();
                }
            };
            Grid.SetRow(_playlistSelectorList, 1);
            playGrid.Children.Add(_playlistSelectorList);

            _playlistItemsList = new ListBox
            {
                Background = ThemeEngine.Instance.GetBrush("OUTLINEDETAIL", Color.FromRgb(0x26, 0x26, 0x2A)),
                Foreground = Brushes.White,
                BorderThickness = new Thickness(0),
                FontSize = 12
            };
            _playlistItemsList.SelectionChanged += (_, _) =>
            {
                if (_playlistItemsList.SelectedItem is ListBoxItem item && item.Tag is PlaylistItemEntry entry)
                {
                    if (entry.CueType == PlaylistCueType.Presentation && entry.LinkedPresentation != null)
                    {
                        SelectPresentation(entry.LinkedPresentation, triggerFirstSlide: true);
                    }
                    else if (entry.CueType == PlaylistCueType.Media && entry.LinkedMedia != null)
                    {
                        TriggerMediaItem(entry.LinkedMedia);
                    }
                }
            };
            Grid.SetRow(_playlistItemsList, 2);
            playGrid.Children.Add(_playlistItemsList);

            Grid.SetRow(playGrid, 2);
            leftGrid.Children.Add(playGrid);

            var leftFooter = BuildLeftColumnFooterBar();
            Grid.SetRow(leftFooter, 3);
            leftGrid.Children.Add(leftFooter);

            return leftGrid;
        }

        private FrameworkElement BuildLeftColumnFooterBar()
        {
            var footerStack = new StackPanel
            {
                Orientation = Orientation.Vertical,
                Background = ThemeEngine.Instance.GetBrush("OUTLINEDETAILHEADER", Color.FromRgb(0x1B, 0x1B, 0x1E))
            };

            // 1. Presentation Title Dropdown Header
            var presDropdown = new Border
            {
                Height = 27,
                Background = new SolidColorBrush(Color.FromRgb(0x24, 0x24, 0x29)),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x35, 0x35, 0x3E)),
                BorderThickness = new Thickness(0, 1, 0, 1),
                Padding = new Thickness(8, 0, 8, 0),
                Cursor = Cursors.Hand
            };
            var presDock = new DockPanel { VerticalAlignment = VerticalAlignment.Center };

            // Left: Presentation icon
            var presIcon = new System.Windows.Shapes.Path
            {
                Width = 13,
                Height = 13,
                Data = Geometry.Parse("M1,2 H15 V11 H1 Z M4,14 L7,11 M12,14 L9,11"),
                Stroke = new SolidColorBrush(Color.FromRgb(0xDC, 0xDC, 0xE4)),
                StrokeThickness = 1.2,
                Margin = new Thickness(0, 0, 6, 0),
                VerticalAlignment = VerticalAlignment.Center
            };
            presDock.Children.Add(presIcon);

            // Right: Chevron ▾
            var chevron = new TextBlock
            {
                Text = "▾",
                Foreground = new SolidColorBrush(Color.FromRgb(0x9E, 0xA4, 0xB2)),
                FontSize = 10,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(6, 0, 0, 0)
            };
            DockPanel.SetDock(chevron, Dock.Right);
            presDock.Children.Add(chevron);

            _leftActivePresentationLabel = new TextBlock
            {
                Text = _selectedPresentation?.Name ?? "Default Presentation",
                Foreground = new SolidColorBrush(Color.FromRgb(0xEB, 0xEB, 0xF0)),
                FontSize = 11.5,
                FontWeight = FontWeights.Normal,
                VerticalAlignment = VerticalAlignment.Center,
                TextTrimming = TextTrimming.CharacterEllipsis
            };
            presDock.Children.Add(_leftActivePresentationLabel);
            presDropdown.Child = presDock;

            presDropdown.MouseLeftButtonDown += (_, _) =>
            {
                var menu = new ContextMenu();
                menu.Resources = GetDarkMenuResourceDictionary();
                foreach (var p in _libraryPresentations.Take(25))
                {
                    var mi = new MenuItem { Header = p.Name };
                    mi.Click += (_, _) => SelectPresentation(p, false);
                    menu.Items.Add(mi);
                }
                menu.PlacementTarget = presDropdown;
                menu.Placement = PlacementMode.Top;
                menu.IsOpen = true;
            };
            footerStack.Children.Add(presDropdown);

            // 2. Filter Bar + Add Button
            var filterRow = new Border
            {
                Height = 31,
                Background = new SolidColorBrush(Color.FromRgb(0x18, 0x18, 0x1B)),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x2D, 0x2D, 0x35)),
                BorderThickness = new Thickness(0, 0, 0, 0),
                Padding = new Thickness(6, 4, 6, 4)
            };
            var filterDock = new DockPanel { VerticalAlignment = VerticalAlignment.Center };

            // Right: + Button
            var plusBtn = new Button
            {
                Content = "+",
                Width = 22,
                Height = 22,
                Background = Brushes.Transparent,
                Foreground = new SolidColorBrush(Color.FromRgb(0xC8, 0xCE, 0xDC)),
                BorderThickness = new Thickness(0),
                FontSize = 15,
                FontWeight = FontWeights.Normal,
                Cursor = Cursors.Hand,
                Margin = new Thickness(4, 0, 0, 0),
                VerticalContentAlignment = VerticalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center
            };
            plusBtn.Click += (_, _) =>
            {
                var addMenu = new ContextMenu();
                addMenu.Resources = GetDarkMenuResourceDictionary();
                var mi1 = new MenuItem { Header = "+ New Presentation..." };
                mi1.Click += (_, _) => PromptNewPresentation();
                var mi2 = new MenuItem { Header = "+ New Playlist..." };
                mi2.Click += (_, _) => PromptNewPlaylist();
                var mi3 = new MenuItem { Header = "+ Add to Playlist" };
                mi3.Click += (_, _) => AddSelectedPresentationToPlaylist();
                addMenu.Items.Add(mi1);
                addMenu.Items.Add(mi2);
                addMenu.Items.Add(mi3);
                addMenu.PlacementTarget = plusBtn;
                addMenu.Placement = PlacementMode.Top;
                addMenu.IsOpen = true;
            };
            DockPanel.SetDock(plusBtn, Dock.Right);
            filterDock.Children.Add(plusBtn);

            // Filter Box
            var filterBorder = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(0x26, 0x26, 0x2C)),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x3E, 0x3E, 0x48)),
                BorderThickness = new Thickness(1),
                CornerRadius = new CornerRadius(3),
                Height = 22,
                Padding = new Thickness(5, 0, 5, 0)
            };
            var filterGrid = new Grid();
            filterGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            filterGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            var filterIcon = new System.Windows.Shapes.Path
            {
                Width = 11,
                Height = 11,
                Data = Geometry.Parse("M1,2 H11 L7,7 V10 L5,9 V7 Z"),
                Fill = new SolidColorBrush(Color.FromRgb(0x8A, 0x8E, 0x9E)),
                Margin = new Thickness(0, 0, 5, 0),
                VerticalAlignment = VerticalAlignment.Center
            };
            Grid.SetColumn(filterIcon, 0);
            filterGrid.Children.Add(filterIcon);

            var inputOverlay = new Grid();
            var placeholder = new TextBlock
            {
                Text = "Filter",
                Foreground = new SolidColorBrush(Color.FromRgb(0x72, 0x76, 0x86)),
                FontSize = 11,
                VerticalAlignment = VerticalAlignment.Center,
                IsHitTestVisible = false
            };
            _leftFilterBox = new TextBox
            {
                Background = Brushes.Transparent,
                Foreground = Brushes.White,
                CaretBrush = Brushes.White,
                BorderThickness = new Thickness(0),
                FontSize = 11,
                VerticalAlignment = VerticalAlignment.Center
            };
            _leftFilterBox.TextChanged += (_, _) =>
            {
                placeholder.Visibility = string.IsNullOrEmpty(_leftFilterBox.Text) ? Visibility.Visible : Visibility.Collapsed;
                _librarySearchQuery = _leftFilterBox.Text.Trim();
                RefreshLibraryDocumentList();
                RefreshPlaylistItemsList();
            };
            inputOverlay.Children.Add(placeholder);
            inputOverlay.Children.Add(_leftFilterBox);
            Grid.SetColumn(inputOverlay, 1);
            filterGrid.Children.Add(inputOverlay);

            filterBorder.Child = filterGrid;
            filterDock.Children.Add(filterBorder);
            filterRow.Child = filterDock;
            footerStack.Children.Add(filterRow);

            return footerStack;
        }



        private static Border CreateSectionHeader(string title, string actionLabel, System.Action onAction)
        {
            var bar = new Border
            {
                Background = ThemeEngine.Instance.GetBrush("OUTLINEDETAILHEADER", Color.FromRgb(0x1D, 0x1D, 0x20)),
                Padding = new Thickness(10, 6, 8, 6),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x35, 0x35, 0x3A)),
                BorderThickness = new Thickness(0, 0, 0, 1)
            };
            var dock = new DockPanel();
            var btn = new Button
            {
                Content = actionLabel,
                Background = new SolidColorBrush(Color.FromRgb(0x38, 0x38, 0x42)),
                Foreground = Brushes.White,
                BorderThickness = new Thickness(0),
                Padding = new Thickness(7, 2, 7, 2),
                FontSize = 10.5,
                Cursor = Cursors.Hand
            };
            btn.Click += (_, _) => onAction();
            DockPanel.SetDock(btn, Dock.Right);
            dock.Children.Add(btn);

            dock.Children.Add(new TextBlock
            {
                Text = title,
                Foreground = new SolidColorBrush(Color.FromRgb(0xB8, 0xBE, 0xCA)),
                FontSize = 11,
                FontWeight = FontWeights.Bold,
                VerticalAlignment = VerticalAlignment.Center
            });
            bar.Child = dock;
            return bar;
        }

        private void RefreshLibraryViewLists()
        {
            _libraryCategoryList.Items.Clear();

            var categories = new List<(string Label, string Filter)>
            {
                ($"📁 All Presentations ({_libraryPresentations.Count})", "All Presentations"),
                ($"🎵 Default Library ({_libraryPresentations.Count(p => p.Category != "Bible Scripture")})", "Default"),
                ($"📖 Bible Scriptures ({_libraryPresentations.Count(p => p.Category == "Bible Scripture")})", "Bible Scripture")
            };

            foreach (var (label, filter) in categories)
            {
                var item = new ListBoxItem
                {
                    Content = label,
                    Tag = filter,
                    Foreground = Brushes.White,
                    Padding = new Thickness(8, 4, 8, 4)
                };
                _libraryCategoryList.Items.Add(item);
                if (filter == _activeLibraryCategoryFilter)
                    _libraryCategoryList.SelectedItem = item;
            }

            RefreshLibraryDocumentList();
        }

        private void RefreshLibraryDocumentList()
        {
            _libraryDocList.Items.Clear();

            IEnumerable<PresentationDocument> filtered = _libraryPresentations;
            if (_activeLibraryCategoryFilter == "Default")
                filtered = filtered.Where(p => p.Category != "Bible Scripture");
            else if (_activeLibraryCategoryFilter == "Bible Scripture")
                filtered = filtered.Where(p => p.Category == "Bible Scripture");

            if (!string.IsNullOrWhiteSpace(_librarySearchQuery))
            {
                filtered = filtered.Where(p =>
                    p.Name.Contains(_librarySearchQuery, StringComparison.OrdinalIgnoreCase) ||
                    p.Slides.Any(s => s.PrimaryText.Contains(_librarySearchQuery, StringComparison.OrdinalIgnoreCase)));
            }

            foreach (var doc in filtered)
            {
                var dock = new DockPanel { Margin = new Thickness(2, 2, 4, 2) };
                var badge = new Border
                {
                    Background = new SolidColorBrush(Color.FromRgb(0x3B, 0x3D, 0x46)),
                    CornerRadius = new CornerRadius(3),
                    Padding = new Thickness(5, 1, 5, 1),
                    VerticalAlignment = VerticalAlignment.Center,
                    Child = new TextBlock
                    {
                        Text = doc.Slides.Count.ToString(),
                        Foreground = new SolidColorBrush(Color.FromRgb(0xC5, 0xCB, 0xD6)),
                        FontSize = 10
                    }
                };
                DockPanel.SetDock(badge, Dock.Right);
                dock.Children.Add(badge);

                dock.Children.Add(new TextBlock
                {
                    Text = "📄 " + doc.Name,
                    Foreground = Brushes.White,
                    FontSize = 12,
                    TextTrimming = TextTrimming.CharacterEllipsis,
                    VerticalAlignment = VerticalAlignment.Center
                });

                var item = new ListBoxItem
                {
                    Content = dock,
                    Tag = doc,
                    Padding = new Thickness(6, 4, 6, 4)
                };
                _libraryDocList.Items.Add(item);
                if (doc == _selectedPresentation)
                    _libraryDocList.SelectedItem = item;
            }
        }

        private void RefreshPlaylistViews()
        {
            _playlistSelectorList.Items.Clear();
            foreach (var pl in _playlists)
            {
                var item = new ListBoxItem
                {
                    Content = $"📋 {pl.Name} ({pl.Items.Count})",
                    Tag = pl,
                    Foreground = Brushes.White,
                    Padding = new Thickness(8, 4, 8, 4)
                };
                _playlistSelectorList.Items.Add(item);
                if (pl == _selectedPlaylist)
                    _playlistSelectorList.SelectedItem = item;
            }
            RefreshPlaylistItemsList();
        }

        private void RefreshPlaylistItemsList()
        {
            _playlistItemsList.Items.Clear();
            if (_selectedPlaylist == null)
                return;

            int index = 1;
            foreach (var entry in _selectedPlaylist.Items)
            {
                if (entry.CueType == PlaylistCueType.Header)
                {
                    var hdrBorder = new Border
                    {
                        Background = new SolidColorBrush(Color.FromArgb(140, entry.HeaderColor.R, entry.HeaderColor.G, entry.HeaderColor.B)),
                        Padding = new Thickness(8, 4, 8, 4),
                        CornerRadius = new CornerRadius(3),
                        Child = new TextBlock
                        {
                            Text = entry.Title,
                            Foreground = Brushes.White,
                            FontSize = 10.5,
                            FontWeight = FontWeights.Bold
                        }
                    };
                    _playlistItemsList.Items.Add(new ListBoxItem
                    {
                        Content = hdrBorder,
                        Tag = entry,
                        Padding = new Thickness(2, 2, 2, 2)
                    });
                }
                else
                {
                    string icon = entry.CueType == PlaylistCueType.Media ? "🎬" : "🎵";
                    var row = new TextBlock
                    {
                        Text = $"{index++}.  {icon}  {entry.Title}",
                        Foreground = Brushes.White,
                        FontSize = 12,
                        TextTrimming = TextTrimming.CharacterEllipsis
                    };
                    _playlistItemsList.Items.Add(new ListBoxItem
                    {
                        Content = row,
                        Tag = entry,
                        Padding = new Thickness(10, 5, 8, 5)
                    });
                }
            }
        }

        private void SelectPresentation(PresentationDocument doc, bool triggerFirstSlide)
        {
            _selectedPresentation = doc;
            _selectedEditorSlide = doc.Slides.FirstOrDefault();
            _selectedEditorElement = _selectedEditorSlide?.Elements.FirstOrDefault();

            if (_leftActivePresentationLabel != null)
            {
                _leftActivePresentationLabel.Text = doc.Name;
            }
            UpdateRightColumnBottomStatus();

            if (triggerFirstSlide && doc.Slides.Count > 0)
            {
                TriggerSlide(doc, doc.Slides[0]);
            }

            RebuildCenterWorkspace();
            SetStatus($"Selected presentation '{doc.Name}' ({doc.Slides.Count} slides)" +
                      (!string.IsNullOrEmpty(doc.FilePath) ? $" • {Path.GetFileName(doc.FilePath)}" : ""));
        }

        private void TriggerSlide(PresentationDocument doc, SlideItemModel slide)
        {
            _outputState.IsClearToLogoActive = false;
            _outputState.ActivePresentation = doc;
            _outputState.ActiveSlide = slide;

            int idx = doc.Slides.IndexOf(slide);
            _outputState.NextSlide = (idx >= 0 && idx + 1 < doc.Slides.Count) ? doc.Slides[idx + 1] : null;
            _selectedEditorSlide = slide;
            _selectedEditorElement = slide.Elements.FirstOrDefault();
            _autoAdvanceAccumulator = 0.0;

            RefreshPreviewAndOutputs(animateAudienceTransition: true);
            if (_activeViewMode == InlineViewMode.Show)
            {
                RebuildShowView();
            }
            SetStatus($"Live Slide #{slide.SlideNumber} [{slide.GroupName}] — {doc.Name}");
        }

        private void TriggerMediaItem(MediaBinItem media)
        {
            _outputState.IsClearToLogoActive = false;
            _outputState.ActiveMediaBackground = media;
            _transportProgressSeconds = 0;
            _transportDurationSeconds = media.Kind == MediaAssetKind.Image ? 0 : 180;
            _transportTitleLabel.Text = $"🎬 {media.Name} ({media.Category})";

            RefreshPreviewAndOutputs(animateAudienceTransition: true);
            SetStatus($"Triggered Background Media: {media.Name}");
        }

        private void TriggerAudioTrack(AudioTrackItem track)
        {
            _outputState.ActiveAudioTrack = track;
            _outputState.IsAudioPlaying = true;
            _transportProgressSeconds = 0;
            _transportDurationSeconds = 225;
            _transportTitleLabel.Text = $"🎵 {track.Name}";

            if (!string.IsNullOrEmpty(track.FilePath) && File.Exists(track.FilePath))
            {
                try
                {
                    _audioPlayer.Open(new Uri(track.FilePath, UriKind.Absolute));
                    _audioPlayer.Play();
                }
                catch { }
            }

            RefreshPreviewAndOutputs();
            RebuildUtilityTabContent();
            SetStatus($"Playing Audio Track: {track.Name}");
        }

        private void ClearLayer(string layerName)
        {
            switch (layerName)
            {
                case "All":
                    _outputState.ActiveSlide = null;
                    _outputState.NextSlide = null;
                    _outputState.ActiveMediaBackground = null;
                    _outputState.IsVideoInputActive = false;
                    _outputState.IsAudioPlaying = false;
                    _outputState.ActiveAudioTrack = null;
                    _outputState.IsClearToLogoActive = false;
                    _audioPlayer.Stop();
                    foreach (var p in _props) p.IsActive = false;
                    _outputState.ActiveProps.Clear();
                    if (_outputState.ActiveMessage != null) _outputState.ActiveMessage.IsActive = false;
                    break;
                case "Slide":
                    _outputState.ActiveSlide = null;
                    _outputState.NextSlide = null;
                    break;
                case "Media":
                    _outputState.ActiveMediaBackground = null;
                    break;
                case "VideoInput":
                    _outputState.IsVideoInputActive = false;
                    break;
                case "Props":
                    foreach (var p in _props) p.IsActive = false;
                    _outputState.ActiveProps.Clear();
                    break;
                case "Messages":
                    if (_outputState.ActiveMessage != null)
                        _outputState.ActiveMessage.IsActive = false;
                    break;
                case "Audio":
                    _outputState.IsAudioPlaying = false;
                    _outputState.ActiveAudioTrack = null;
                    _audioPlayer.Stop();
                    break;
                case "Logo":
                    _outputState.IsClearToLogoActive = !_outputState.IsClearToLogoActive;
                    break;
            }

            RefreshPreviewAndOutputs(animateAudienceTransition: true);
            if (_activeViewMode == InlineViewMode.Show)
                RebuildShowView();
            RebuildUtilityTabContent();
            SetStatus($"Cleared Layer: {layerName}");
        }

        private void SwitchViewMode(InlineViewMode mode)
        {
            _activeViewMode = mode;
            UpdateToolbarModeButtonsVisual();
            UpdateContextualMenusVisibility();
            RebuildCenterWorkspace();
        }

        private void UpdateToolbarModeButtonsVisual()
        {
            foreach (var kv in _modeButtons)
            {
                bool active = kv.Key == _activeViewMode;
                kv.Value.Background = active
                    ? new SolidColorBrush(Color.FromRgb(0x00, 0x7A, 0xFF))
                    : Brushes.Transparent;
            }
        }

        private void RebuildCenterWorkspace()
        {
            _centerContentHost.Children.Clear();
            switch (_activeViewMode)
            {
                case InlineViewMode.Show:
                    RebuildShowView();
                    break;
                case InlineViewMode.Edit:
                case InlineViewMode.ThemeEditor:
                case InlineViewMode.PropsEditor:
                case InlineViewMode.MaskEditor:
                    RebuildSlideEditorView();
                    break;
                case InlineViewMode.Reflow:
                    RebuildReflowEditorView();
                    break;
                case InlineViewMode.Bible:
                    RebuildBibleView();
                    break;
                case InlineViewMode.StageEditor:
                    _isStagePreviewMode = true;
                    RebuildShowView();
                    RefreshPreviewAndOutputs();
                    break;
            }
        }

        private void ToggleMediaBin()
        {
            _isMediaBinCollapsed = !_isMediaBinCollapsed;
            _mediaBinRowDef.Height = _isMediaBinCollapsed ? new GridLength(0) : new GridLength(215);
        }

        private void ToggleAudienceOutputWindow(bool forceOpenWindow = false)
        {
            if (_audienceWindow == null || !_audienceWindow.IsLoaded)
            {
                _audienceWindow = new AudienceWindow();
                _audienceWindow.Closed += (_, _) =>
                {
                    _audienceWindow = null;
                    _outputState.IsAudienceEnabled = false;
                    UpdateScreenIndicators();
                };
            }

            if (forceOpenWindow)
            {
                if (_audienceWindow.IsVisible)
                {
                    _audienceWindow.Hide();
                    _outputState.IsAudienceEnabled = false;
                }
                else
                {
                    _outputState.IsAudienceEnabled = true;
                    _audienceWindow.Show();
                    _audienceWindow.UpdateOutput(_outputState, _timers, _motionPhase, true);
                }
            }
            else
            {
                _outputState.IsAudienceEnabled = !_outputState.IsAudienceEnabled;
            }

            UpdateScreenIndicators();
            RefreshPreviewAndOutputs();
        }

        private void ToggleStageOutputWindow(bool forceOpenWindow = false)
        {
            if (_stageWindow == null || !_stageWindow.IsLoaded)
            {
                _stageWindow = new StageWindow();
                _stageWindow.Closed += (_, _) =>
                {
                    _stageWindow = null;
                    _outputState.IsStageEnabled = false;
                    UpdateScreenIndicators();
                };
            }

            if (forceOpenWindow)
            {
                if (_stageWindow.IsVisible)
                {
                    _stageWindow.Hide();
                    _outputState.IsStageEnabled = false;
                }
                else
                {
                    _outputState.IsStageEnabled = true;
                    _stageWindow.Show();
                    _stageWindow.UpdateStage(_outputState, _timers);
                }
            }
            else
            {
                _outputState.IsStageEnabled = !_outputState.IsStageEnabled;
            }

            UpdateScreenIndicators();
            RefreshPreviewAndOutputs();
        }

        private void UpdateScreenIndicators()
        {
            if (_audienceIndicatorDot != null)
            {
                _audienceIndicatorDot.Background = new SolidColorBrush(
                    _outputState.IsAudienceEnabled ? Color.FromRgb(0x33, 0xFD, 0x00) : Color.FromRgb(0xE0, 0x35, 0x35));
            }
            if (_stageIndicatorDot != null)
            {
                _stageIndicatorDot.Background = new SolidColorBrush(
                    _outputState.IsStageEnabled ? Color.FromRgb(0x33, 0xFD, 0x00) : Color.FromRgb(0xE0, 0x35, 0x35));
            }
        }

        private void ToggleLiveCapture()
        {
            _outputState.IsLiveCaptureActive = !_outputState.IsLiveCaptureActive;
            if (_outputState.IsLiveCaptureActive)
            {
                _outputState.CaptureStartedAt = DateTime.Now;
                _liveCaptureButtonBorder.Background = new SolidColorBrush(Color.FromRgb(0x26, 0xA5, 0x1C));
                _liveCaptureButtonLabel.Text = "00:00:00";
                SetStatus("Live Capture & RTMP Stream started (1080p60 • 6.5 Mbps).");
            }
            else
            {
                _liveCaptureButtonBorder.Background = new SolidColorBrush(Color.FromRgb(0x2B, 0x2B, 0x30));
                _liveCaptureButtonLabel.Text = "Stream Off";
                SetStatus("Live Capture stopped.");
            }
        }

        private void CycleLookPreset()
        {
            int idx = _looks.IndexOf(_outputState.ActiveLook);
            var next = _looks[(idx + 1) % _looks.Count];
            ApplyLookPreset(next);
        }

        private void ApplyLookPreset(LookPresetModel look)
        {
            _outputState.ActiveLook = look;
            if (_lookButtonLabel != null)
                _lookButtonLabel.Text = look.Name;
            RefreshPreviewAndOutputs(animateAudienceTransition: true);
            SetStatus($"Activated Audience Look: {look.Name}");
        }

        private void ApplyAppTheme(string themeName)
        {
            ThemeEngine.Instance.LoadTheme(themeName);
            Background = ThemeEngine.Instance.GetBrush("WINDOW_BACKGROUND");
            BuildMainWindowLayout();
            SetStatus($"Switched application theme to '{themeName}.theme'.");
        }

        private void OnEngineTick(object? sender, EventArgs e)
        {
            _motionPhase = (_motionPhase + 0.015) % 1.0;

            // Update running timers
            bool anyTimerChanged = false;
            foreach (var t in _timers)
            {
                if (!t.IsRunning) continue;
                anyTimerChanged = true;
                if (t.Mode == TimerMode.Countdown)
                {
                    t.Remaining -= TimeSpan.FromMilliseconds(250);
                    if (!t.AllowOverrun && t.Remaining < TimeSpan.Zero)
                    {
                        t.Remaining = TimeSpan.Zero;
                        t.IsRunning = false;
                    }
                }
                else
                {
                    t.Remaining += TimeSpan.FromMilliseconds(250);
                }
            }

            // Update Live Capture elapsed clock
            if (_outputState.IsLiveCaptureActive && _liveCaptureButtonLabel != null)
            {
                var elapsed = DateTime.Now - _outputState.CaptureStartedAt;
                _liveCaptureButtonLabel.Text = $"{(int)elapsed.TotalHours:00}:{elapsed.Minutes:00}:{elapsed.Seconds:00}";
            }

            // Update transport progress if media or audio is active
            if ((_outputState.ActiveMediaBackground != null && _outputState.ActiveMediaBackground.Kind != MediaAssetKind.Image) ||
                _outputState.IsAudioPlaying)
            {
                _transportProgressSeconds += 0.25;
                if (_transportProgressSeconds > _transportDurationSeconds && _transportDurationSeconds > 0)
                    _transportProgressSeconds = 0;

                UpdateTransportBarLabels();
            }

            // Auto-advance slideshow timer if enabled on active presentation
            if (_outputState.ActivePresentation != null &&
                _outputState.ActivePresentation.AutoAdvanceSeconds > 0 &&
                _outputState.ActiveSlide != null)
            {
                _autoAdvanceAccumulator += 0.25;
                if (_autoAdvanceAccumulator >= _outputState.ActivePresentation.AutoAdvanceSeconds)
                {
                    _autoAdvanceAccumulator = 0;
                    AdvanceSlide(1, wrapAround: true);
                }
            }

            // Refresh live preview and secondary windows if animated layers or timers are active
            if (_outputState.ActiveMediaBackground != null || anyTimerChanged || _isStagePreviewMode || _stageWindow?.IsVisible == true)
            {
                RefreshPreviewAndOutputs(animateAudienceTransition: false);
            }
        }

        private void OnMainWindowPreviewKeyDown(object sender, KeyEventArgs e)
        {
            // Ignore navigation shortcuts while typing inside a TextBox
            if (Keyboard.FocusedElement is TextBox)
                return;

            var mods = Keyboard.Modifiers;
            Key actualKey = e.Key == Key.System ? e.SystemKey : e.Key;

            if (mods == ModifierKeys.Control)
            {
                if (actualKey == Key.OemComma) { OpenSettingsWindow("General"); e.Handled = true; return; }
                if (actualKey == Key.Q) { Close(); e.Handled = true; return; }
                if (actualKey == Key.F) { ShowQuickSearchDialog(); e.Handled = true; return; }
                if (actualKey == Key.N) { PromptNewPresentation(); e.Handled = true; return; }
                if (actualKey == Key.O) { PromptImportProFile(); e.Handled = true; return; }
                if (actualKey == Key.S) { SaveSelectedPresentation(); e.Handled = true; return; }
                if (actualKey == Key.P) { ShowPrintPresentationDialog(); e.Handled = true; return; }
                if (actualKey == Key.D) { DuplicateCurrentSlide(); e.Handled = true; return; }
                if (actualKey == Key.E) { SwitchViewMode(InlineViewMode.Edit); e.Handled = true; return; }
                if (actualKey == Key.R) { SwitchViewMode(InlineViewMode.Reflow); e.Handled = true; return; }
                if (actualKey == Key.Z) { PerformUndo(); e.Handled = true; return; }
                if (actualKey == Key.Y) { PerformRedo(); e.Handled = true; return; }
                if (actualKey == Key.X) { CutSelectedSlideOrElement(); e.Handled = true; return; }
                if (actualKey == Key.C) { CopySelectedSlideOrElement(); e.Handled = true; return; }
                if (actualKey == Key.V) { PasteSlideOrElement(matchStyle: false); e.Handled = true; return; }
                if (actualKey == Key.M) { SwitchRightUtilityTab("Messages"); e.Handled = true; return; }
                if (actualKey == Key.D1) { ToggleAudienceOutputWindow(forceOpenWindow: true); e.Handled = true; return; }
                if (actualKey == Key.D2) { ToggleStageOutputWindow(forceOpenWindow: true); e.Handled = true; return; }
                if (actualKey == Key.D4) { SwitchViewMode(InlineViewMode.StageEditor); e.Handled = true; return; }
                if (actualKey == Key.D0)
                {
                    _slideOnStageScreenOnly = !_slideOnStageScreenOnly;
                    SetStatus(_slideOnStageScreenOnly ? "Enabled 'Slide on Stage Screen Only'." : "Disabled 'Slide on Stage Screen Only'.");
                    e.Handled = true;
                    return;
                }
            }
            else if (mods == (ModifierKeys.Control | ModifierKeys.Shift))
            {
                if (actualKey == Key.N) { AddSlideToCurrentPresentation(); e.Handled = true; return; }
                if (actualKey == Key.I) { PromptImportProFile(); e.Handled = true; return; }
                if (actualKey == Key.V) { ToggleMediaBin(); e.Handled = true; return; }
                if (actualKey == Key.D1) { ShowEditLooksDialog(); e.Handled = true; return; }
                if (actualKey == Key.T) { ShowTimecodeDialog(); e.Handled = true; return; }
                if (actualKey == Key.R) { ShowProContentBrowserDialog(); e.Handled = true; return; }
                if (actualKey == Key.A) { SwitchRightUtilityTab("Audio"); e.Handled = true; return; }
                if (actualKey == Key.C) { SwitchRightUtilityTab("Timers"); e.Handled = true; return; }
                if (actualKey == Key.P) { SwitchRightUtilityTab("Props"); e.Handled = true; return; }
                if (actualKey == Key.M) { SwitchRightUtilityTab("Macros"); e.Handled = true; return; }
            }
            else if (mods == (ModifierKeys.Control | ModifierKeys.Alt))
            {
                if (actualKey == Key.D1) { ShowConfigureScreensDialog(); e.Handled = true; return; }
                if (actualKey == Key.C) { ShowCalendarDialog(); e.Handled = true; return; }
                if (actualKey == Key.P) { OpenSettingsWindow("Integrations"); e.Handled = true; return; }
            }
            else if (mods == ModifierKeys.Alt)
            {
                if (actualKey == Key.K) { ShowKeyMappingDialog(); e.Handled = true; return; }
                if (actualKey == Key.M) { TriggerFindMyMouseEffect(); e.Handled = true; return; }
                if (actualKey == Key.A) { ShowActionPaletteDialog(); e.Handled = true; return; }
                if (actualKey == Key.S) { SwitchRightUtilityTab("Stage"); e.Handled = true; return; }
                if (actualKey == Key.Right) { CycleMediaBackground(1); e.Handled = true; return; }
                if (actualKey == Key.Left) { CycleMediaBackground(-1); e.Handled = true; return; }
            }

            // Group Hotkeys (e.g. 'A' for Verse 1, 'C' for Chorus, 'S' for Verse 2, 'B' for Bridge)
            if (mods == ModifierKeys.None && _selectedPresentation != null && actualKey >= Key.A && actualKey <= Key.Z)
            {
                string keyChar = actualKey.ToString().ToUpperInvariant();
                var targetSlide = _selectedPresentation.Slides.FirstOrDefault(s => s.HotKey.Equals(keyChar, StringComparison.OrdinalIgnoreCase));
                if (targetSlide != null)
                {
                    TriggerSlide(_selectedPresentation, targetSlide);
                    e.Handled = true;
                    return;
                }
            }

            switch (actualKey)
            {
                case Key.Right:
                case Key.Down:
                case Key.Space:
                case Key.PageDown:
                    AdvanceSlide(1);
                    e.Handled = true;
                    break;
                case Key.Left:
                case Key.Up:
                case Key.PageUp:
                    AdvanceSlide(-1);
                    e.Handled = true;
                    break;
                case Key.Delete:
                    DeleteSelectedSlideOrElement();
                    e.Handled = true;
                    break;
                case Key.F1:
                    ClearLayer("All");
                    e.Handled = true;
                    break;
                case Key.F2:
                    ClearLayer("Slide");
                    e.Handled = true;
                    break;
                case Key.F3:
                    ClearLayer("Media");
                    e.Handled = true;
                    break;
                case Key.F4:
                    ClearLayer("Props");
                    e.Handled = true;
                    break;
                case Key.F5:
                    ClearLayer("Audio");
                    e.Handled = true;
                    break;
                case Key.F6:
                    ClearLayer("Messages");
                    e.Handled = true;
                    break;
                case Key.F7:
                    ClearLayer("Slide");
                    e.Handled = true;
                    break;
                case Key.F12:
                    ClearLayer("Logo");
                    e.Handled = true;
                    break;
            }
        }

        private void AdvanceSlide(int delta, bool wrapAround = false)
        {
            var pres = _selectedPresentation ?? _outputState.ActivePresentation;
            if (pres == null || pres.Slides.Count == 0)
                return;

            int curIdx = _outputState.ActiveSlide != null ? pres.Slides.IndexOf(_outputState.ActiveSlide) : -1;
            int nextIdx = curIdx + delta;
            if (wrapAround && nextIdx >= pres.Slides.Count)
                nextIdx = 0;

            if (nextIdx >= 0 && nextIdx < pres.Slides.Count)
            {
                TriggerSlide(pres, pres.Slides[nextIdx]);
            }
        }

        private void SetStatus(string message)
        {
            if (_statusBarText != null)
                _statusBarText.Text = message;
        }
    }
}

