using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace ProPresenterClone.Models
{
    public enum InlineViewMode
    {
        Show,
        Edit,
        Reflow,
        Bible,
        StageEditor,
        ThemeEditor,
        PropsEditor,
        MaskEditor
    }

    public enum SlideElementKind
    {
        Text,
        Shape,
        Image,
        TimerToken,
        ClockToken,
        CurrentSlideToken,
        NextSlideToken
    }

    public sealed class SlideElementModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = "Text Element";
        public SlideElementKind Kind { get; set; } = SlideElementKind.Text;

        // Normalized 0..1 coordinates relative to 1920x1080 canvas
        public double X { get; set; } = 0.06;
        public double Y { get; set; } = 0.12;
        public double Width { get; set; } = 0.88;
        public double Height { get; set; } = 0.76;

        public string Text { get; set; } = "";
        public string FontFamily { get; set; } = "Roboto";
        public double FontSize { get; set; } = 58.0;
        public bool IsBold { get; set; } = true;
        public bool IsItalic { get; set; } = false;
        public bool IsUppercase { get; set; } = false;
        public TextAlignment HorizontalAlignment { get; set; } = TextAlignment.Center;
        public VerticalAlignment VerticalAlignment { get; set; } = VerticalAlignment.Center;

        public Color TextColor { get; set; } = Colors.White;
        public Color FillColor { get; set; } = Color.FromArgb(0, 0, 0, 0);
        public Color StrokeColor { get; set; } = Color.FromArgb(190, 0, 0, 0);
        public double StrokeThickness { get; set; } = 0.0;
        public bool HasShadow { get; set; } = true;
        public double CornerRadius { get; set; } = 0.0;
        public string? ImagePath { get; set; }
        public string? LinkedTimerId { get; set; }

        public SlideElementModel Clone()
        {
            return (SlideElementModel)MemberwiseClone();
        }
    }

    public sealed class SlideItemModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int SlideNumber { get; set; } = 1;
        public string Label { get; set; } = "";
        public string GroupId { get; set; } = "";
        public string GroupName { get; set; } = "Verse 1";
        public Color GroupColor { get; set; } = Color.FromRgb(0x00, 0x77, 0xCC);
        public bool IsFirstInGroup { get; set; } = false;
        public Color BackgroundColor { get; set; } = Color.FromArgb(0, 0, 0, 0);
        public bool HasCustomBackground { get; set; } = false;
        public string? BackgroundMediaPath { get; set; }
        public string? AudioActionPath { get; set; }
        public string HotKey { get; set; } = "";
        public string Notes { get; set; } = "";
        public bool IsEnabled { get; set; } = true;
        public string TransitionName { get; set; } = "Dissolve";
        public double TransitionDurationSeconds { get; set; } = 0.45;
        public double NextTimerSeconds { get; set; } = 0.0;
        public string? AttachedAction { get; set; }
        public List<SlideElementModel> Elements { get; set; } = new List<SlideElementModel>();

        public string PrimaryText
        {
            get
            {
                foreach (var el in Elements)
                {
                    if (el.Kind == SlideElementKind.Text && !string.IsNullOrWhiteSpace(el.Text))
                        return el.Text;
                }
                return Elements.Count > 0 ? Elements[0].Text : "";
            }
            set
            {
                var textEl = Elements.Find(e => e.Kind == SlideElementKind.Text);
                if (textEl == null)
                {
                    textEl = new SlideElementModel
                    {
                        Kind = SlideElementKind.Text,
                        Name = "Slide Text",
                        Text = value
                    };
                    Elements.Add(textEl);
                }
                else
                {
                    textEl.Text = value;
                }
            }
        }

        public SlideItemModel Clone()
        {
            var copy = (SlideItemModel)MemberwiseClone();
            copy.Id = Guid.NewGuid().ToString();
            copy.Elements = new List<SlideElementModel>();
            foreach (var el in Elements)
                copy.Elements.Add(el.Clone());
            return copy;
        }
    }

    public sealed class CueGroupModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = "Group";
        public Color Color { get; set; } = Color.FromRgb(0x00, 0x77, 0xCC);
        public List<string> CueIds { get; set; } = new List<string>();
    }

    public sealed class ArrangementModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = "Default";
        public List<string> GroupOrderIds { get; set; } = new List<string>();
    }

    public sealed class PresentationDocument
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = "Untitled Presentation";
        public string Category { get; set; } = "Default";
        public string? FilePath { get; set; }
        public string Author { get; set; } = "";
        public string CopyrightYear { get; set; } = "";
        public string Publisher { get; set; } = "";
        public string CcliSongNumber { get; set; } = "";
        public string TransitionName { get; set; } = "Dissolve";
        public double TransitionDurationSeconds { get; set; } = 0.45;
        public double AutoAdvanceSeconds { get; set; } = 0.0;
        public List<SlideItemModel> Slides { get; set; } = new List<SlideItemModel>();
        public List<CueGroupModel> Groups { get; set; } = new List<CueGroupModel>();
        public List<ArrangementModel> Arrangements { get; set; } = new List<ArrangementModel>();
        public string ActiveArrangementName { get; set; } = "Master";
    }

    public enum PlaylistCueType
    {
        Header,
        Presentation,
        Media,
        Audio
    }

    public sealed class PlaylistItemEntry
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; } = "";
        public PlaylistCueType CueType { get; set; } = PlaylistCueType.Presentation;
        public PresentationDocument? LinkedPresentation { get; set; }
        public MediaBinItem? LinkedMedia { get; set; }
        public AudioTrackItem? LinkedAudio { get; set; }
        public Color HeaderColor { get; set; } = Color.FromRgb(0x55, 0x55, 0x55);
    }

    public sealed class PlaylistModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = "Sunday Service";
        public List<PlaylistItemEntry> Items { get; set; } = new List<PlaylistItemEntry>();
    }

    public enum MediaAssetKind
    {
        Image,
        Video,
        ProceduralMotion,
        LiveVideoInput
    }

    public sealed class MediaBinItem
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = "";
        public string Category { get; set; } = "Assets";
        public MediaAssetKind Kind { get; set; } = MediaAssetKind.Image;
        public string? FilePath { get; set; }
        public Color PrimaryColor { get; set; } = Color.FromRgb(0x10, 0x28, 0x50);
        public Color SecondaryColor { get; set; } = Color.FromRgb(0x45, 0x12, 0x68);
        public Color AccentColor { get; set; } = Color.FromRgb(0x00, 0x88, 0xFF);
        public string DurationText { get; set; } = "LOOP";
        public bool IsForeground { get; set; } = false;
    }

    public sealed class AudioTrackItem
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = "";
        public string PlaylistName { get; set; } = "Worship Pads & Tracks";
        public string? FilePath { get; set; }
        public string DurationText { get; set; } = "03:45";
        public bool IsLooping { get; set; } = true;
    }

    public enum TimerMode
    {
        Countdown,
        CountUp,
        CountdownToTime
    }

    public sealed class TimerItemModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = "Service Countdown";
        public TimerMode Mode { get; set; } = TimerMode.Countdown;
        public TimeSpan Duration { get; set; } = TimeSpan.FromMinutes(5);
        public TimeSpan Remaining { get; set; } = TimeSpan.FromMinutes(5);
        public string TargetTimeOfDay { get; set; } = "11:00 AM";
        public bool IsRunning { get; set; } = false;
        public bool AllowOverrun { get; set; } = true;
        public Color AccentColor { get; set; } = Color.FromRgb(0x33, 0xFD, 0x00);

        public string FormattedValue
        {
            get
            {
                bool neg = Remaining.TotalSeconds < 0;
                TimeSpan abs = TimeSpan.FromSeconds(Math.Abs(Remaining.TotalSeconds));
                string prefix = neg ? "-" : "";
                if (abs.TotalHours >= 1.0)
                    return $"{prefix}{(int)abs.TotalHours:00}:{abs.Minutes:00}:{abs.Seconds:00}";
                return $"{prefix}{abs.Minutes:00}:{abs.Seconds:00}";
            }
        }
    }

    public sealed class StageMessageModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; } = "Parent Pager";
        public string TemplateText { get; set; } = "Childcare Needed: Pager #{Number}";
        public string TokenName { get; set; } = "Number";
        public string TokenValue { get; set; } = "142";
        public bool ShowOnAudience { get; set; } = true;
        public bool ShowOnStage { get; set; } = true;
        public bool IsActive { get; set; } = false;

        public string ResolvedMessage => TemplateText.Replace("{" + TokenName + "}", TokenValue);
    }

    public sealed class PropItemModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = "Lower Third Banner";
        public string BadgeText { get; set; } = "WORSHIP LIVE";
        public string SubText { get; set; } = "ProPresenter 21 Studio";
        public string Position { get; set; } = "BottomLeft"; // TopRight, BottomLeft, TopLeft, LowerThirdBar
        public Color PrimaryColor { get; set; } = Color.FromRgb(0x00, 0x7A, 0xFF);
        public bool IsActive { get; set; } = false;
    }

    public sealed class MacroItemModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = "Pre-Service Countdown";
        public string Description { get; set; } = "Triggers Countdown Timer + Motion Background + Stage Layout";
        public Color Color { get; set; } = Color.FromRgb(0xF7, 0x82, 0x1C);
        public string ActionType { get; set; } = "PreService";
    }

    public sealed class StageLayoutModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = "Standard Stage (Current + Next + Timers)";
        public bool ShowCurrentSlide { get; set; } = true;
        public bool ShowNextSlide { get; set; } = true;
        public bool ShowSlideNotes { get; set; } = true;
        public bool ShowWallClock { get; set; } = true;
        public bool ShowTimers { get; set; } = true;
        public bool LargeTimerMode { get; set; } = false;
    }

    public sealed class ThemeTemplateModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = "Vivid Dark";
        public string Category { get; set; } = "Sample Content";
        public double FontSize { get; set; } = 58.0;
        public string FontFamily { get; set; } = "Roboto";
        public bool IsBold { get; set; } = true;
        public bool IsUppercase { get; set; } = false;
        public Color TextColor { get; set; } = Colors.White;
        public Color BoxFillColor { get; set; } = Colors.Transparent;
        public Color SlideBackgroundColor { get; set; } = Colors.Transparent;
        public double BoxY { get; set; } = 0.12;
        public double BoxHeight { get; set; } = 0.76;
    }

    public sealed class LookPresetModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = "Default Fullscreen";
        public bool ShowVideoInputLayer { get; set; } = true;
        public bool ShowMediaLayer { get; set; } = true;
        public bool ShowSlideLayer { get; set; } = true;
        public bool ShowPropsLayer { get; set; } = true;
        public bool ShowMessagesLayer { get; set; } = true;
        public bool UseLowerThirdThemeOverride { get; set; } = false;
    }

    public sealed class BibleVerseModel
    {
        public string Translation { get; set; } = "KJV";
        public string Book { get; set; } = "John";
        public int Chapter { get; set; } = 3;
        public int Verse { get; set; } = 16;
        public string Text { get; set; } = "";
        public string Reference => $"{Book} {Chapter}:{Verse} ({Translation})";
    }

    /// <summary>
    /// Holds the real-time composite output state across all ProPresenter layers:
    /// Video Input -> Media -> Slide -> Props -> Messages -> Audio -> Clear-to-Logo.
    /// </summary>
    public sealed class ActiveOutputState
    {
        public bool IsAudienceEnabled { get; set; } = true;
        public bool IsStageEnabled { get; set; } = false;
        public bool IsClearToLogoActive { get; set; } = false;
        public bool IsLiveCaptureActive { get; set; } = false;
        public DateTime CaptureStartedAt { get; set; } = DateTime.Now;

        public PresentationDocument? ActivePresentation { get; set; }
        public SlideItemModel? ActiveSlide { get; set; }
        public SlideItemModel? NextSlide { get; set; }
        public MediaBinItem? ActiveMediaBackground { get; set; }
        public bool IsVideoInputActive { get; set; } = false;
        public AudioTrackItem? ActiveAudioTrack { get; set; }
        public bool IsAudioPlaying { get; set; } = false;
        public List<PropItemModel> ActiveProps { get; } = new List<PropItemModel>();
        public StageMessageModel? ActiveMessage { get; set; }
        public LookPresetModel ActiveLook { get; set; } = new LookPresetModel();
        public StageLayoutModel ActiveStageLayout { get; set; } = new StageLayoutModel();

        public bool HasAnyLayerActive =>
            ActiveSlide != null ||
            ActiveMediaBackground != null ||
            IsVideoInputActive ||
            IsAudioPlaying ||
            ActiveProps.Count > 0 ||
            (ActiveMessage != null && ActiveMessage.IsActive) ||
            IsClearToLogoActive;
    }
}

