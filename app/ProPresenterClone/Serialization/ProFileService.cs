using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Media;
using Google.Protobuf;
using Pro.SerializationInterop.RVProtoData;
using ProPresenterClone.Models;
using ProPresenterClone.Theming;
using WpfColor = System.Windows.Media.Color;
using RvColor = Pro.SerializationInterop.RVProtoData.Color;

namespace ProPresenterClone.Serialization
{
    /// <summary>
    /// Native ProPresenter 7/21 (.pro) and Theme (Template.Document) Protobuf reader and writer
    /// powered directly by Renewed Vision's Pro.SerializationInterop.dll and Google.Protobuf.dll.
    /// </summary>
    public static class ProFileService
    {
        private static readonly WpfColor[] DefaultGroupPalette = new[]
        {
            WpfColor.FromRgb(0x00, 0x77, 0xCC), // Verse 1 Blue
            WpfColor.FromRgb(0xCC, 0x00, 0x4E), // Chorus Magenta/Red
            WpfColor.FromRgb(0x00, 0x59, 0x99), // Verse 2 Deep Blue
            WpfColor.FromRgb(0x76, 0x00, 0xCC), // Bridge Purple
            WpfColor.FromRgb(0x2E, 0x99, 0x00), // Tag / Instrumental Green
            WpfColor.FromRgb(0xD9, 0x6B, 0x00), // Pre-Chorus Orange
            WpfColor.FromRgb(0x00, 0x8B, 0x8B)  // Outro Teal
        };

        public static string GetDefaultHotKey(string groupName)
        {
            if (string.IsNullOrWhiteSpace(groupName)) return "";
            string name = groupName.Trim().ToLowerInvariant();
            if (name.StartsWith("verse 1") || name == "verse") return "A";
            if (name.StartsWith("verse 2")) return "S";
            if (name.StartsWith("verse 3")) return "D";
            if (name.StartsWith("verse 4")) return "F";
            if (name.StartsWith("verse 5")) return "G";
            if (name.StartsWith("verse 6")) return "H";
            if (name.StartsWith("chorus 1") || name == "chorus") return "C";
            if (name.StartsWith("chorus 2")) return "X";
            if (name.StartsWith("bridge 1") || name == "bridge") return "B";
            if (name.StartsWith("bridge 2")) return "W";
            if (name.StartsWith("intro")) return "I";
            if (name.StartsWith("outro")) return "O";
            if (name.StartsWith("pre-chorus") || name.StartsWith("pre chorus")) return "P";
            if (name.StartsWith("tag")) return "T";
            if (name.StartsWith("vamp")) return "V";
            if (name.StartsWith("interlude")) return "L";
            if (name.StartsWith("ending")) return "E";
            if (name.StartsWith("blank")) return "K";
            return "";
        }

        public static List<PresentationDocument> LoadAllLibraryPresentations()
        {
            var results = new List<PresentationDocument>();
            var seenNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            string userDocsLib = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "ProPresenter", "Libraries", "Default");

            string bundledSampleLib = Path.Combine(ThemeEngine.Instance.AssetsRoot, "sample-libraries");

            var searchDirs = new List<(string Dir, string Category)>();
            if (Directory.Exists(userDocsLib))
                searchDirs.Add((userDocsLib, "Default"));
            if (Directory.Exists(bundledSampleLib))
                searchDirs.Add((bundledSampleLib, "Default"));

            foreach (var (dir, category) in searchDirs)
            {
                foreach (string file in Directory.GetFiles(dir, "*.pro").OrderBy(f => Path.GetFileName(f)))
                {
                    string fileKey = Path.GetFileNameWithoutExtension(file);
                    if (seenNames.Contains(fileKey))
                        continue;

                    try
                    {
                        var doc = LoadProFile(file, category);
                        if (doc != null && doc.Slides.Count > 0)
                        {
                            seenNames.Add(fileKey);
                            results.Add(doc);
                        }
                    }
                    catch
                    {
                        // Skip unreadable file
                    }
                }
            }

            if (results.Count == 0)
            {
                results.Add(CreateFallbackWelcomePresentation());
            }

            return results;
        }

        public static PresentationDocument? LoadProFile(string filePath, string category = "Default")
        {
            using var fs = File.OpenRead(filePath);
            var proto = Presentation.Parser.ParseFrom(fs);
            if (proto == null)
                return null;

            var doc = new PresentationDocument
            {
                Id = !string.IsNullOrEmpty(proto.Uuid?.String) ? proto.Uuid.String : Guid.NewGuid().ToString(),
                Name = !string.IsNullOrWhiteSpace(proto.Name) ? proto.Name : Path.GetFileNameWithoutExtension(filePath),
                Category = !string.IsNullOrWhiteSpace(proto.Category) ? proto.Category : category,
                FilePath = filePath
            };

            if (proto.Ccli != null)
            {
                doc.Author = !string.IsNullOrWhiteSpace(proto.Ccli.Author) ? proto.Ccli.Author : proto.Ccli.ArtistCredits;
                doc.Publisher = proto.Ccli.Publisher ?? "";
                if (proto.Ccli.CopyrightYear > 0)
                    doc.CopyrightYear = proto.Ccli.CopyrightYear.ToString();
                if (proto.Ccli.SongNumber > 0)
                    doc.CcliSongNumber = proto.Ccli.SongNumber.ToString();
            }

            // Map Cue UUID -> (GroupId, GroupName, GroupColor, HotKey, IsFirstInGroup)
            var cueToGroup = new Dictionary<string, (string GroupId, string Name, WpfColor Color, string HotKey, bool IsFirst)>(StringComparer.OrdinalIgnoreCase);
            var seenHotKeys = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            int groupIdx = 0;
            foreach (var cg in proto.CueGroups)
            {
                string gId = cg.Group?.Uuid?.String ?? Guid.NewGuid().ToString();
                string gName = cg.Group?.Name ?? "";
                if (string.IsNullOrWhiteSpace(gName) || gName.Equals("Group", StringComparison.OrdinalIgnoreCase))
                {
                    gName = groupIdx == 0 ? "Verse 1" : (groupIdx == 1 ? "Chorus" : $"Verse {groupIdx + 1}");
                }

                WpfColor gColor = ToWpfColor(cg.Group?.Color, DefaultGroupPalette[groupIdx % DefaultGroupPalette.Length]);
                
                string gHotKey = "";
                if (cg.Group?.HotKey != null && cg.Group.HotKey.Code != KeyCode.Unknown)
                {
                    string codeStr = cg.Group.HotKey.Code.ToString();
                    if (codeStr.StartsWith("Ansi", StringComparison.OrdinalIgnoreCase) && codeStr.Length > 4)
                        gHotKey = codeStr.Substring(4).ToUpperInvariant();
                    else if (codeStr.Length == 1)
                        gHotKey = codeStr.ToUpperInvariant();
                    else if (codeStr.StartsWith("Key", StringComparison.OrdinalIgnoreCase) && codeStr.Length > 3)
                        gHotKey = codeStr.Substring(3).ToUpperInvariant();
                    else
                        gHotKey = codeStr.ToUpperInvariant();
                }

                if (string.IsNullOrWhiteSpace(gHotKey) || gHotKey == "NONE" || gHotKey == "UNKNOWN")
                {
                    gHotKey = GetDefaultHotKey(gName);
                }

                if (!string.IsNullOrEmpty(gHotKey) && seenHotKeys.Contains(gHotKey))
                {
                    gHotKey = "";
                }
                else if (!string.IsNullOrEmpty(gHotKey))
                {
                    seenHotKeys.Add(gHotKey);
                }

                var cgModel = new CueGroupModel
                {
                    Id = gId,
                    Name = gName,
                    Color = gColor
                };

                bool isFirstInGroup = true;
                foreach (var cid in cg.CueIdentifiers)
                {
                    if (!string.IsNullOrEmpty(cid.String))
                    {
                        cgModel.CueIds.Add(cid.String);
                        cueToGroup[cid.String] = (gId, gName, gColor, isFirstInGroup ? gHotKey : "", isFirstInGroup);
                        isFirstInGroup = false;
                    }
                }

                doc.Groups.Add(cgModel);
                groupIdx++;
            }

            foreach (var arr in proto.Arrangements)
            {
                var arrModel = new ArrangementModel
                {
                    Id = arr.Uuid?.String ?? Guid.NewGuid().ToString(),
                    Name = !string.IsNullOrWhiteSpace(arr.Name) ? arr.Name : "Default"
                };
                foreach (var gid in arr.GroupIdentifiers)
                {
                    if (!string.IsNullOrEmpty(gid.String))
                        arrModel.GroupOrderIds.Add(gid.String);
                }
                doc.Arrangements.Add(arrModel);
            }

            int slideNum = 1;
            string lastGroupId = "";
            string lastGroupName = "Verse 1";
            WpfColor lastGroupColor = DefaultGroupPalette[0];

            foreach (var cue in proto.Cues)
            {
                string cueId = cue.Uuid?.String ?? Guid.NewGuid().ToString();
                string grpId = lastGroupId;
                string grpName = lastGroupName;
                WpfColor grpColor = lastGroupColor;
                string hotKey = "";
                bool isFirst = false;

                if (cueToGroup.TryGetValue(cueId, out var mappedGroup))
                {
                    grpId = mappedGroup.GroupId;
                    grpName = mappedGroup.Name;
                    grpColor = mappedGroup.Color;
                    hotKey = mappedGroup.HotKey;
                    isFirst = mappedGroup.IsFirst;

                    lastGroupId = grpId;
                    lastGroupName = grpName;
                    lastGroupColor = grpColor;
                }
                else
                {
                    isFirst = slideNum == 1;
                    if (isFirst)
                        hotKey = GetDefaultHotKey(grpName);
                }

                var slideModel = new SlideItemModel
                {
                    Id = cueId,
                    SlideNumber = slideNum++,
                    Label = cue.Name?.Trim() ?? "",
                    GroupId = grpId,
                    GroupName = grpName,
                    GroupColor = grpColor,
                    IsFirstInGroup = isFirst,
                    HotKey = hotKey,
                    IsEnabled = cue.IsEnabled
                };

                foreach (var action in cue.Actions)
                {
                    var presSlide = action.Slide?.Presentation;
                    var baseSlide = presSlide?.BaseSlide;
                    if (baseSlide == null)
                        continue;

                    if (baseSlide.DrawsBackgroundColor && baseSlide.BackgroundColor != null)
                    {
                        slideModel.HasCustomBackground = true;
                        slideModel.BackgroundColor = ToWpfColor(baseSlide.BackgroundColor, Colors.Black);
                    }

                    if (presSlide?.Notes?.RtfData != null && presSlide.Notes.RtfData.Length > 0)
                    {
                        var parsedNotes = ParseRtf(presSlide.Notes.RtfData.ToStringUtf8());
                        slideModel.Notes = parsedNotes.PlainText;
                    }

                    double canvasW = (baseSlide.Size != null && baseSlide.Size.Width > 100) ? baseSlide.Size.Width : 1920.0;
                    double canvasH = (baseSlide.Size != null && baseSlide.Size.Height > 100) ? baseSlide.Size.Height : 1080.0;

                    foreach (var slideEl in baseSlide.Elements)
                    {
                        var gEl = slideEl.Element_;
                        if (gEl == null || gEl.Hidden)
                            continue;

                        var elModel = new SlideElementModel
                        {
                            Id = gEl.Uuid?.String ?? Guid.NewGuid().ToString(),
                            Name = !string.IsNullOrWhiteSpace(gEl.Name) ? gEl.Name : "TextBox",
                            Kind = SlideElementKind.Text
                        };

                        if (gEl.Bounds?.Origin != null && gEl.Bounds?.Size != null && gEl.Bounds.Size.Width > 0 && gEl.Bounds.Size.Height > 0)
                        {
                            elModel.X = Math.Clamp(gEl.Bounds.Origin.X / canvasW, 0.0, 0.95);
                            elModel.Y = Math.Clamp(gEl.Bounds.Origin.Y / canvasH, 0.0, 0.95);
                            elModel.Width = Math.Clamp(gEl.Bounds.Size.Width / canvasW, 0.05, 1.0);
                            elModel.Height = Math.Clamp(gEl.Bounds.Size.Height / canvasH, 0.05, 1.0);
                        }

                        if (gEl.Fill != null && gEl.Fill.Enable && gEl.Fill.Color != null)
                        {
                            elModel.FillColor = ToWpfColor(gEl.Fill.Color, Colors.Transparent);
                        }

                        if (gEl.Stroke != null && gEl.Stroke.Enable && gEl.Stroke.Color != null)
                        {
                            elModel.StrokeColor = ToWpfColor(gEl.Stroke.Color, Colors.Black);
                            elModel.StrokeThickness = Math.Max(0, gEl.Stroke.Width);
                        }

                        if (gEl.Shadow != null)
                        {
                            elModel.HasShadow = gEl.Shadow.Enable;
                        }

                        if (gEl.Text?.RtfData != null && gEl.Text.RtfData.Length > 0)
                        {
                            string rawRtf = gEl.Text.RtfData.ToStringUtf8();
                            var rtfResult = ParseRtf(rawRtf);
                            elModel.Text = rtfResult.PlainText;
                            elModel.FontSize = Math.Clamp(rtfResult.FontSizePoints, 24.0, 120.0);
                            elModel.FontFamily = rtfResult.FontFamily;
                            elModel.IsBold = rtfResult.IsBold;
                            elModel.IsItalic = rtfResult.IsItalic;
                            elModel.HorizontalAlignment = rtfResult.Alignment;
                            elModel.TextColor = rtfResult.TextColor;
                        }

                        slideModel.Elements.Add(elModel);
                    }
                }

                if (slideModel.Elements.Count == 0)
                {
                    slideModel.Elements.Add(new SlideElementModel
                    {
                        Kind = SlideElementKind.Text,
                        Name = "Slide Text",
                        Text = ""
                    });
                }

                doc.Slides.Add(slideModel);
            }

            return doc;
        }

        public static void SaveProFile(PresentationDocument doc, string filePath)
        {
            var proto = new Presentation
            {
                Uuid = new UUID { String = doc.Id },
                Name = doc.Name,
                Category = doc.Category,
                ApplicationInfo = new ApplicationInfo
                {
                    Platform = ApplicationInfo.Types.Platform.Windows,
                    Application = ApplicationInfo.Types.Application.Propresenter,
                    ApplicationVersion = new Pro.SerializationInterop.RVProtoData.Version
                    {
                        MajorVersion = 21,
                        MinorVersion = 4,
                        PatchVersion = 2
                    }
                },
                Ccli = new Presentation.Types.CCLI
                {
                    Author = doc.Author ?? "",
                    SongTitle = doc.Name ?? "",
                    Publisher = doc.Publisher ?? "",
                    Display = !string.IsNullOrWhiteSpace(doc.Author)
                }
            };

            var groupsByName = new Dictionary<string, Presentation.Types.CueGroup>(StringComparer.OrdinalIgnoreCase);

            foreach (var slide in doc.Slides)
            {
                string cueUuid = !string.IsNullOrWhiteSpace(slide.Id) ? slide.Id : Guid.NewGuid().ToString();
                var cue = new Cue
                {
                    Uuid = new UUID { String = cueUuid },
                    Name = slide.Label ?? "",
                    IsEnabled = true
                };

                var rvSlide = new Slide
                {
                    Uuid = new UUID { String = Guid.NewGuid().ToString() },
                    DrawsBackgroundColor = slide.HasCustomBackground,
                    BackgroundColor = FromWpfColor(slide.BackgroundColor),
                    Size = new Graphics.Types.Size { Width = 1920, Height = 1080 }
                };

                foreach (var el in slide.Elements)
                {
                    string rtf = BuildRtfFromElement(el);
                    var gEl = new Graphics.Types.Element
                    {
                        Uuid = new UUID { String = el.Id },
                        Name = el.Name,
                        Opacity = 1.0,
                        Bounds = new Graphics.Types.Rect
                        {
                            Origin = new Graphics.Types.Point { X = el.X * 1920.0, Y = el.Y * 1080.0 },
                            Size = new Graphics.Types.Size { Width = el.Width * 1920.0, Height = el.Height * 1080.0 }
                        },
                        Fill = new Graphics.Types.Fill
                        {
                            Enable = el.FillColor.A > 0,
                            Color = FromWpfColor(el.FillColor)
                        },
                        Shadow = new Graphics.Types.Shadow
                        {
                            Enable = el.HasShadow,
                            Radius = 6,
                            Opacity = 0.75
                        },
                        Text = new Graphics.Types.Text
                        {
                            RtfData = ByteString.CopyFromUtf8(rtf)
                        }
                    };

                    rvSlide.Elements.Add(new Slide.Types.Element
                    {
                        Element_ = gEl,
                        Info = (uint)Slide.Types.Element.Types.Info.IsTextElement
                    });
                }

                var action = new Pro.SerializationInterop.RVProtoData.Action
                {
                    Uuid = new UUID { String = Guid.NewGuid().ToString() },
                    Name = slide.Label ?? "",
                    IsEnabled = true,
                    Type = Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.PresentationSlide,
                    Slide = new Pro.SerializationInterop.RVProtoData.Action.Types.SlideType
                    {
                        Presentation = new PresentationSlide
                        {
                            BaseSlide = rvSlide
                        }
                    }
                };

                cue.Actions.Add(action);
                proto.Cues.Add(cue);

                string grpKey = string.IsNullOrWhiteSpace(slide.GroupName) ? "Verse 1" : slide.GroupName;
                if (!groupsByName.TryGetValue(grpKey, out var cg))
                {
                    cg = new Presentation.Types.CueGroup
                    {
                        Group = new Pro.SerializationInterop.RVProtoData.Group
                        {
                            Uuid = new UUID { String = Guid.NewGuid().ToString() },
                            Name = grpKey,
                            Color = FromWpfColor(slide.GroupColor)
                        }
                    };
                    groupsByName[grpKey] = cg;
                    proto.CueGroups.Add(cg);
                }
                cg.CueIdentifiers.Add(new UUID { String = cueUuid });
            }

            Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);
            using var outStream = File.Create(filePath);
            proto.WriteTo(outStream);
            doc.FilePath = filePath;
        }

        public static List<ThemeTemplateModel> LoadSampleThemes()
        {
            var themes = new List<ThemeTemplateModel>();

            string sampleThemesRoot = Path.Combine(ThemeEngine.Instance.AssetsRoot, "resources", "Sample Content", "Themes");
            string userThemesRoot = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "ProPresenter", "Themes");

            var themeFiles = new List<string>();
            if (Directory.Exists(sampleThemesRoot))
                themeFiles.AddRange(Directory.GetFiles(sampleThemesRoot, "Theme", SearchOption.AllDirectories));
            if (Directory.Exists(userThemesRoot))
                themeFiles.AddRange(Directory.GetFiles(userThemesRoot, "Theme", SearchOption.AllDirectories));

            var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (string tf in themeFiles)
            {
                string folderName = Path.GetFileName(Path.GetDirectoryName(tf)!) ?? "Theme";
                if (seen.Contains(folderName))
                    continue;

                try
                {
                    using var fs = File.OpenRead(tf);
                    var doc = Template.Types.Document.Parser.ParseFrom(fs);
                    if (doc != null && doc.Slides.Count > 0)
                    {
                        seen.Add(folderName);
                        var firstSlide = doc.Slides[0];
                        var baseSlide = firstSlide.BaseSlide;

                        var tm = new ThemeTemplateModel
                        {
                            Name = !string.IsNullOrWhiteSpace(firstSlide.Name) ? $"{folderName} — {firstSlide.Name}" : folderName,
                            Category = folderName,
                            SlideBackgroundColor = (baseSlide != null && baseSlide.DrawsBackgroundColor)
                                ? ToWpfColor(baseSlide.BackgroundColor, Colors.Transparent)
                                : Colors.Transparent
                        };

                        var firstTextEl = baseSlide?.Elements.FirstOrDefault(e => e.Element_?.Text?.RtfData != null);
                        if (firstTextEl?.Element_ != null)
                        {
                            var gEl = firstTextEl.Element_;
                            if (gEl.Bounds?.Origin != null && gEl.Bounds?.Size != null && baseSlide?.Size?.Height > 0)
                            {
                                tm.BoxY = Math.Clamp(gEl.Bounds.Origin.Y / baseSlide.Size.Height, 0.05, 0.85);
                                tm.BoxHeight = Math.Clamp(gEl.Bounds.Size.Height / baseSlide.Size.Height, 0.12, 0.90);
                            }
                            if (gEl.Fill != null && gEl.Fill.Enable && gEl.Fill.Color != null)
                            {
                                tm.BoxFillColor = ToWpfColor(gEl.Fill.Color, Colors.Transparent);
                            }
                            if (gEl.Text?.RtfData != null)
                            {
                                var parsed = ParseRtf(gEl.Text.RtfData.ToStringUtf8());
                                tm.FontSize = Math.Clamp(parsed.FontSizePoints, 32, 96);
                                tm.FontFamily = parsed.FontFamily;
                                tm.TextColor = parsed.TextColor;
                            }
                        }

                        themes.Add(tm);
                    }
                }
                catch
                {
                    // Continue if a theme file uses a different format
                }
            }

            // Ensure core built-in themes are always available
            themes.Insert(0, new ThemeTemplateModel
            {
                Name = "Pro7 Center Worship (Default)",
                Category = "Built-in",
                FontSize = 58,
                FontFamily = "Roboto",
                IsBold = true,
                TextColor = Colors.White,
                BoxFillColor = Colors.Transparent,
                BoxY = 0.12,
                BoxHeight = 0.76
            });
            themes.Insert(1, new ThemeTemplateModel
            {
                Name = "Broadcast Lower Third — Black Box",
                Category = "Lower Thirds",
                FontSize = 44,
                FontFamily = "Roboto",
                IsBold = true,
                TextColor = Colors.White,
                BoxFillColor = WpfColor.FromArgb(210, 14, 18, 26),
                BoxY = 0.70,
                BoxHeight = 0.23
            });
            themes.Insert(2, new ThemeTemplateModel
            {
                Name = "Broadcast Lower Third — White Box",
                Category = "Lower Thirds",
                FontSize = 44,
                FontFamily = "Roboto",
                IsBold = true,
                TextColor = WpfColor.FromRgb(18, 22, 30),
                BoxFillColor = WpfColor.FromArgb(235, 255, 255, 255),
                BoxY = 0.70,
                BoxHeight = 0.23
            });
            themes.Insert(3, new ThemeTemplateModel
            {
                Name = "Sermon Scripture Gold",
                Category = "Sermon",
                FontSize = 50,
                FontFamily = "Georgia",
                IsBold = false,
                TextColor = WpfColor.FromRgb(255, 240, 195),
                BoxFillColor = WpfColor.FromArgb(145, 10, 15, 28),
                BoxY = 0.16,
                BoxHeight = 0.68
            });

            return themes;
        }

        private static WpfColor ToWpfColor(RvColor? c, WpfColor fallback)
        {
            if (c == null)
                return fallback;
            if (c.Red == 0 && c.Green == 0 && c.Blue == 0 && c.Alpha == 0)
                return fallback;

            byte a = (byte)Math.Clamp(Math.Round((c.Alpha > 0 ? c.Alpha : 1.0f) * 255.0f), 0, 255);
            byte r = (byte)Math.Clamp(Math.Round(c.Red * 255.0f), 0, 255);
            byte g = (byte)Math.Clamp(Math.Round(c.Green * 255.0f), 0, 255);
            byte b = (byte)Math.Clamp(Math.Round(c.Blue * 255.0f), 0, 255);
            return WpfColor.FromArgb(a, r, g, b);
        }

        private static RvColor FromWpfColor(WpfColor c)
        {
            return new RvColor
            {
                Red = c.R / 255.0f,
                Green = c.G / 255.0f,
                Blue = c.B / 255.0f,
                Alpha = c.A / 255.0f
            };
        }

        private sealed class RtfParseInfo
        {
            public string PlainText { get; set; } = "";
            public double FontSizePoints { get; set; } = 54.0;
            public string FontFamily { get; set; } = "Roboto";
            public bool IsBold { get; set; } = true;
            public bool IsItalic { get; set; } = false;
            public TextAlignment Alignment { get; set; } = TextAlignment.Center;
            public WpfColor TextColor { get; set; } = Colors.White;
        }

        /// <summary>
        /// High-accuracy RTF parser tailored for ProPresenter's Cocoa/Windows RTF strings,
        /// supporting \ucN and \uN? Unicode codepoints (Vietnamese, German, etc.).
        /// </summary>
        private static RtfParseInfo ParseRtf(string rtf)
        {
            var info = new RtfParseInfo();
            if (string.IsNullOrWhiteSpace(rtf))
                return info;

            if (!rtf.TrimStart().StartsWith(@"{\rtf", StringComparison.Ordinal))
            {
                info.PlainText = rtf.Trim();
                return info;
            }

            // Extract font size (\fs100 -> 50pt)
            var fsMatch = Regex.Match(rtf, @"\\fs(\d+)");
            if (fsMatch.Success && int.TryParse(fsMatch.Groups[1].Value, out int halfPts) && halfPts > 10)
            {
                info.FontSizePoints = halfPts / 2.0;
            }

            if (rtf.Contains(@"\ql")) info.Alignment = TextAlignment.Left;
            else if (rtf.Contains(@"\qr")) info.Alignment = TextAlignment.Right;
            else info.Alignment = TextAlignment.Center;

            if (rtf.Contains(@"\b1") || (rtf.Contains(@"\b ") && !rtf.Contains(@"\b0")))
                info.IsBold = true;

            var sb = new StringBuilder();
            int i = 0;
            int len = rtf.Length;
            int ucSkip = 1;
            int braceDepth = 0;
            int skipGroupDepth = -1;

            while (i < len)
            {
                char ch = rtf[i];

                if (ch == '{')
                {
                    braceDepth++;
                    // Check if this group is a metadata table (\fonttbl, \colortbl, \*\..., \stylesheet, \info)
                    string lookahead = rtf.Substring(i + 1, Math.Min(28, len - i - 1));
                    if (skipGroupDepth < 0 &&
                        (lookahead.StartsWith(@"\*", StringComparison.Ordinal) ||
                         lookahead.StartsWith(@"\fonttbl", StringComparison.Ordinal) ||
                         lookahead.StartsWith(@"\colortbl", StringComparison.Ordinal) ||
                         lookahead.StartsWith(@"\stylesheet", StringComparison.Ordinal) ||
                         lookahead.StartsWith(@"\info", StringComparison.Ordinal) ||
                         lookahead.StartsWith(@"\listtable", StringComparison.Ordinal)))
                    {
                        skipGroupDepth = braceDepth;
                    }
                    i++;
                    continue;
                }

                if (ch == '}')
                {
                    if (skipGroupDepth == braceDepth)
                        skipGroupDepth = -1;
                    braceDepth--;
                    i++;
                    continue;
                }

                if (skipGroupDepth > 0)
                {
                    i++;
                    continue;
                }

                if (ch == '\\')
                {
                    i++;
                    if (i >= len) break;

                    char next = rtf[i];
                    if (next == '\\' || next == '{' || next == '}')
                    {
                        sb.Append(next);
                        i++;
                        continue;
                    }
                    if (next == '\n' || next == '\r')
                    {
                        sb.Append('\n');
                        i++;
                        continue;
                    }
                    if (next == '~')
                    {
                        sb.Append(' ');
                        i++;
                        continue;
                    }
                    if (next == '\'' && i + 2 < len)
                    {
                        string hex = rtf.Substring(i + 1, 2);
                        if (byte.TryParse(hex, NumberStyles.HexNumber, null, out byte b))
                        {
                            sb.Append((char)b);
                        }
                        i += 3;
                        continue;
                    }

                    // Parse control word
                    int wordStart = i;
                    while (i < len && char.IsLetter(rtf[i]))
                        i++;

                    string word = rtf.Substring(wordStart, i - wordStart);

                    int paramStart = i;
                    if (i < len && (rtf[i] == '-' || char.IsDigit(rtf[i])))
                    {
                        i++;
                        while (i < len && char.IsDigit(rtf[i]))
                            i++;
                    }
                    string paramStr = rtf.Substring(paramStart, i - paramStart);

                    // Optional space delimiter after control word
                    if (i < len && rtf[i] == ' ')
                        i++;

                    if (word == "par" || word == "line")
                    {
                        sb.Append('\n');
                    }
                    else if (word == "tab")
                    {
                        sb.Append('\t');
                    }
                    else if (word == "uc" && int.TryParse(paramStr, out int newUc))
                    {
                        ucSkip = Math.Max(0, newUc);
                    }
                    else if (word == "u" && int.TryParse(paramStr, out int codeVal))
                    {
                        if (codeVal < 0)
                            codeVal += 65536;
                        sb.Append((char)codeVal);

                        // Skip fallback character(s) after \uN
                        int skipped = 0;
                        while (skipped < ucSkip && i < len)
                        {
                            if (rtf[i] == '\\' && i + 3 < len && rtf[i + 1] == '\'')
                            {
                                i += 4;
                                skipped++;
                            }
                            else if (rtf[i] != '{' && rtf[i] != '}')
                            {
                                i++;
                                skipped++;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    continue;
                }

                if (ch != '\r' && ch != '\n')
                {
                    sb.Append(ch);
                }
                i++;
            }

            string cleaned = sb.ToString();
            // Normalize multiple trailing blank lines while keeping intentional stanza breaks
            var lines = cleaned.Split('\n').Select(l => l.TrimEnd()).ToList();
            while (lines.Count > 0 && string.IsNullOrWhiteSpace(lines[0]))
                lines.RemoveAt(0);
            while (lines.Count > 0 && string.IsNullOrWhiteSpace(lines[lines.Count - 1]))
                lines.RemoveAt(lines.Count - 1);

            info.PlainText = string.Join("\n", lines);
            return info;
        }

        private static string BuildRtfFromElement(SlideElementModel el)
        {
            int halfPts = (int)Math.Round(el.FontSize * 2);
            string alignCtrl = el.HorizontalAlignment == TextAlignment.Left ? @"\ql"
                : (el.HorizontalAlignment == TextAlignment.Right ? @"\qr" : @"\qc");
            string boldCtrl = el.IsBold ? @"\b" : @"\b0";
            string italicCtrl = el.IsItalic ? @"\i" : @"\i0";

            var body = new StringBuilder();
            string[] lines = (el.Text ?? "").Replace("\r\n", "\n").Split('\n');
            for (int idx = 0; idx < lines.Length; idx++)
            {
                if (idx > 0)
                    body.Append(@"\par ");

                foreach (char c in lines[idx])
                {
                    if (c == '\\' || c == '{' || c == '}')
                    {
                        body.Append('\\').Append(c);
                    }
                    else if (c <= 127)
                    {
                        body.Append(c);
                    }
                    else
                    {
                        body.Append(@"\u").Append((int)c).Append(" ?");
                    }
                }
            }

            return @"{\rtf0\ansi\ansicpg1252{\fonttbl\f0\fnil ArialMT;}" +
                   @"{\colortbl;\red" + el.TextColor.R + @"\green" + el.TextColor.G + @"\blue" + el.TextColor.B + @";}" +
                   @"\uc1\pard" + alignCtrl + @"\f0" + boldCtrl + italicCtrl + @"\fs" + halfPts + @"\cf1 " +
                   body.ToString() + "}";
        }

        private static PresentationDocument CreateFallbackWelcomePresentation()
        {
            var doc = new PresentationDocument
            {
                Name = "Amazing Grace",
                Author = "John Newton",
                Category = "Default"
            };
            doc.Slides.Add(new SlideItemModel
            {
                SlideNumber = 1,
                GroupName = "Verse 1",
                GroupColor = DefaultGroupPalette[0],
                PrimaryText = "Amazing grace how sweet the sound\nThat saved a wretch like me"
            });
            doc.Slides.Add(new SlideItemModel
            {
                SlideNumber = 2,
                GroupName = "Verse 1",
                GroupColor = DefaultGroupPalette[0],
                PrimaryText = "I once was lost, but now am found\nWas blind, but now I see"
            });
            return doc;
        }
    }
}
