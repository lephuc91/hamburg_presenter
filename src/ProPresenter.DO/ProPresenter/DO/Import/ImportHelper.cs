using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Text.RegularExpressions.Generated;
using System.Windows;
using System.Windows.Media.Imaging;
using Pro.Common.Collections;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using Pro.Common.Mathematics;
using Pro.Common.Strings;
using Pro.Common.Utility;
using Pro.DO.Label;
using Pro.DO.Storage;
using Pro.DO.Utility;
using Pro.Localization;
using Pro.PDF;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using Pro.Text;
using Pro.UI.DialogService;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Import.Requests;
using ProPresenter.DO.Label;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Media;
using ProPresenter.DO.MultiTracks;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Themes;

namespace ProPresenter.DO.Import;

public static class ImportHelper
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003C_003Ec__DisplayClass13_0
	{
		public string group;
	}

	[CompilerGenerated]
	private sealed class _003CSplitText_003Ed__13 : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private string? _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private BreakMode breakMode;

		public BreakMode _003C_003E3__breakMode;

		private string text;

		public string _003C_003E3__text;

		private string customDelimiter;

		public string _003C_003E3__customDelimiter;

		private string[] _003C_003E7__wrap1;

		private int _003C_003E7__wrap2;

		string? IEnumerator<string>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CSplitText_003Ed__13(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003C_003E7__wrap1 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			_003C_003Ec__DisplayClass13_0 _003C_003Ec__DisplayClass13_ = default(_003C_003Ec__DisplayClass13_0);
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
			{
				_003C_003E1__state = -1;
				if (breakMode == BreakMode.Custom)
				{
					_003C_003E7__wrap1 = this.text.Split(new string[1] { customDelimiter }, StringSplitOptions.RemoveEmptyEntries);
					_003C_003E7__wrap2 = 0;
					goto IL_0090;
				}
				string[] array = this.text.Split(LineBreaks.All, StringSplitOptions.None);
				if (breakMode == BreakMode.NewLine)
				{
					_003C_003E7__wrap1 = array;
					_003C_003E7__wrap2 = 0;
					goto IL_011d;
				}
				_003C_003Ec__DisplayClass13_.group = string.Empty;
				_003C_003E7__wrap1 = array;
				_003C_003E7__wrap2 = 0;
				goto IL_01e8;
			}
			case 1:
				_003C_003E1__state = -1;
				_003C_003E7__wrap2++;
				goto IL_0090;
			case 2:
				_003C_003E1__state = -1;
				_003C_003E7__wrap2++;
				goto IL_011d;
			case 3:
				_003C_003E1__state = -1;
				goto IL_0196;
			case 4:
				{
					_003C_003E1__state = -1;
					break;
				}
				IL_011d:
				if (_003C_003E7__wrap2 < _003C_003E7__wrap1.Length)
				{
					string text = _003C_003E7__wrap1[_003C_003E7__wrap2];
					_003C_003E2__current = ((!string.IsNullOrWhiteSpace(text) && !Metadata.IsMetadata(text)) ? text : null);
					_003C_003E1__state = 2;
					return true;
				}
				_003C_003E7__wrap1 = null;
				break;
				IL_0090:
				if (_003C_003E7__wrap2 < _003C_003E7__wrap1.Length)
				{
					string text2 = _003C_003E7__wrap1[_003C_003E7__wrap2];
					_003C_003E2__current = text2;
					_003C_003E1__state = 1;
					return true;
				}
				_003C_003E7__wrap1 = null;
				break;
				IL_01da:
				_003C_003E7__wrap2++;
				goto IL_01e8;
				IL_01e8:
				if (_003C_003E7__wrap2 < _003C_003E7__wrap1.Length)
				{
					string text3 = _003C_003E7__wrap1[_003C_003E7__wrap2];
					if (string.IsNullOrWhiteSpace(text3))
					{
						if (_003CSplitText_003Eg__isGroupValid_007C13_0(ref _003C_003Ec__DisplayClass13_))
						{
							_003C_003E2__current = _003C_003Ec__DisplayClass13_.group;
							_003C_003E1__state = 3;
							return true;
						}
						goto IL_0196;
					}
					if (_003CSplitText_003Eg__isGroupValid_007C13_0(ref _003C_003Ec__DisplayClass13_))
					{
						_003C_003Ec__DisplayClass13_.group += LineBreaks.NewLine;
					}
					_003C_003Ec__DisplayClass13_.group += text3;
					goto IL_01da;
				}
				_003C_003E7__wrap1 = null;
				if (_003CSplitText_003Eg__isGroupValid_007C13_0(ref _003C_003Ec__DisplayClass13_))
				{
					_003C_003E2__current = _003C_003Ec__DisplayClass13_.group;
					_003C_003E1__state = 4;
					return true;
				}
				break;
				IL_0196:
				_003C_003Ec__DisplayClass13_.group = string.Empty;
				goto IL_01da;
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<string> IEnumerable<string>.GetEnumerator()
		{
			_003CSplitText_003Ed__13 _003CSplitText_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CSplitText_003Ed__ = this;
			}
			else
			{
				_003CSplitText_003Ed__ = new _003CSplitText_003Ed__13(0);
			}
			_003CSplitText_003Ed__.text = _003C_003E3__text;
			_003CSplitText_003Ed__.breakMode = _003C_003E3__breakMode;
			_003CSplitText_003Ed__.customDelimiter = _003C_003E3__customDelimiter;
			return _003CSplitText_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<string>)this).GetEnumerator();
		}
	}

	private static bool _labelsInitialized;

	private static GroupLabelCollection? _groupLabels;

	private static IThemeCollection _themes;

	private static readonly string TempImportDirectory;

	[GeneratedRegex("^[\\(\\{\\[]([^\\(|\\)]+)[\\)\\}\\]]$")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex HeaderRegex()
	{
		return _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__HeaderRegex_5.Instance;
	}

	static ImportHelper()
	{
		_labelsInitialized = false;
		_themes = null;
		TempImportDirectory = Path.Combine(CommonPaths.Temp, "Import");
		FileHelper.DeleteDirectory(TempImportDirectory);
		Directory.CreateDirectory(TempImportDirectory);
	}

	public static void InitializeData(GroupLabelCollection groupLabels, IThemeCollection themes)
	{
		if (_labelsInitialized)
		{
			throw new InvalidOperationException();
		}
		_labelsInitialized = true;
		_groupLabels = groupLabels;
		_themes = themes;
	}

	public static void UninitializeData()
	{
		_labelsInitialized = false;
		_groupLabels = null;
		_themes = null;
	}

	public static string GetTempFile(string extension)
	{
		return FileHelper.GetTempFile(TempImportDirectory, extension);
	}

	public static string GetTempDirectory()
	{
		return FileHelper.GetTempDirectory(TempImportDirectory);
	}

	public static void GetRequestData(IImportRequest request, string textComponent, out string name, out string notes, out CCLIData ccliData)
	{
		name = request.Name;
		notes = string.Empty;
		ccliData = request.CCLIInfo;
		if (Metadata.TryParse(textComponent, out Metadata metadata))
		{
			ccliData = new CCLIData();
			ccliData.Copy(request.CCLIInfo);
			name = metadata.Title?.SanitizeFilename() ?? name;
			notes = metadata.Notes ?? notes;
			ccliData.Title = metadata.Title ?? string.Empty;
			ccliData.Author = metadata.Author ?? string.Empty;
			ccliData.SongNumber = metadata.CCLI ?? string.Empty;
			ccliData.Copyright = metadata.Copyright ?? string.Empty;
		}
	}

	public static GroupLabel? FindExistingLabel(string labelText)
	{
		if (labelText.EndsWith(':'))
		{
			labelText = labelText.Substring(0, labelText.Length - 1);
		}
		return _groupLabels?.FirstOrDefault((GroupLabel g) => g.Text.Equals(labelText, StringComparison.OrdinalIgnoreCase));
	}

	public static CustomPresentation GeneratePresentation(string name, string plainText, CCLIData? ccliInfo, string notes, TemplateSlide? template, BreakMode breakMode, string? customDelimiter, int linesPerSlide, Vector2<double> documentSize, IPresentationFactory presentationFactory, bool strictGroupMatching = true, Regex? altHeaderPattern = null, MultiTracksLicenseData? multiTracksInfo = null, bool applyTemplateMediaAction = false)
	{
		CustomPresentation presentation = ((multiTracksInfo == null) ? presentationFactory.CreateCustom(template) : presentationFactory.CreateMultiTracks(template, multiTracksInfo));
		presentation.Name = name;
		presentation.Notes = notes;
		presentation.UndoStack.StartIgnoring();
		presentation.CCLIInfo.Artist = ccliInfo?.Artist ?? string.Empty;
		presentation.CCLIInfo.Author = ccliInfo?.Author ?? string.Empty;
		presentation.CCLIInfo.Album = ccliInfo?.Album ?? string.Empty;
		presentation.CCLIInfo.Copyright = ccliInfo?.Copyright ?? string.Empty;
		presentation.CCLIInfo.Display = ccliInfo?.Display ?? false;
		presentation.CCLIInfo.Publisher = ccliInfo?.Publisher ?? string.Empty;
		presentation.CCLIInfo.SongNumber = ccliInfo?.SongNumber ?? string.Empty;
		presentation.CCLIInfo.Title = ccliInfo?.Title ?? string.Empty;
		presentation.CCLIInfo.ArtworkImageData = ccliInfo?.ArtworkImageData;
		if (linesPerSlide <= 0)
		{
			return presentation;
		}
		int num = 0;
		bool flag = true;
		bool needsNewSlide = false;
		SlideCue cue = null;
		CustomSlide slide = null;
		GroupLabel label = null;
		GroupLabel assignedLabel = null;
		ClosedBezierPath element = null;
		TextDocument textDocument = null;
		try
		{
			string[] array = SplitText(plainText, breakMode, customDelimiter ?? string.Empty).ToArray();
			foreach (string text in array)
			{
				if (text == null)
				{
					if (needsNewSlide)
					{
						startNewSlide();
					}
					num = 0;
					flag = true;
					continue;
				}
				needsNewSlide = false;
				string text2 = text;
				bool flag2 = num == 0;
				string[] array2 = text2.Split(LineBreaks.All, 2, StringSplitOptions.RemoveEmptyEntries);
				array2[0] = array2[0].Trim();
				Match match = HeaderRegex().Match(array2[0]);
				if (!match.Success && altHeaderPattern != null)
				{
					match = altHeaderPattern.Match(array2[0]);
				}
				if (flag)
				{
					GroupLabel groupLabel = null;
					if (match.Success)
					{
						string text3 = match.Groups.OfType<System.Text.RegularExpressions.Group>().Skip(1).First((System.Text.RegularExpressions.Group g) => g.Success)
							.Value.Trim();
						groupLabel = ((label?.Text == text3) ? label : FindExistingLabel(text3));
						if (groupLabel == null && !strictGroupMatching)
						{
							groupLabel = new GroupLabel(text3);
						}
						if (!flag2 && groupLabel != null)
						{
							num = 0;
							flag2 = true;
						}
					}
					if (flag2 && groupLabel == null)
					{
						groupLabel = FindExistingLabel(array2[0]);
					}
					if (groupLabel != null)
					{
						needsNewSlide = true;
						label = groupLabel.Clone();
						if (array2.Length != 2)
						{
							flag = false;
							continue;
						}
						text2 = array2[1];
					}
				}
				if (flag2)
				{
					startNewSlide();
				}
				if (element == null)
				{
					continue;
				}
				if ((object)textDocument != null)
				{
					if (textDocument.HasText)
					{
						textDocument.InsertParagraph(textDocument.LastCharacterIndex);
					}
					textDocument.InsertTextAndParagraphs(textDocument.LastCharacterIndex, text2);
				}
				num = (num + 1) % linesPerSlide;
			}
		}
		catch (Exception value)
		{
			Log.Error($"Error in parsing the text document - \n {plainText} \n with error - {value}");
		}
		presentation.ChangeSize(documentSize);
		presentation.UndoStack.StopIgnoring();
		return presentation;
		void startNewSlide()
		{
			needsNewSlide = false;
			cue = presentation.AddCue();
			if (applyTemplateMediaAction)
			{
				cue.ApplyTemplateMediaAction(template);
			}
			slide = (CustomSlide)(cue.SlideAction?.Slide);
			element = slide?.GetPrimaryTextElement(useDisplayText: false);
			if (element != null)
			{
				textDocument = element.Text;
				textDocument?.Clear();
				if (label != null && label != assignedLabel)
				{
					presentation.AssignGroupLabel(label, new global::_003C_003Ez__ReadOnlySingleElementList<ArrangedCue>(presentation.DefaultArrangement.ArrangedCues.First((ArrangedCue a) => a.Source == cue)));
					assignedLabel = label;
				}
			}
		}
	}

	[IteratorStateMachine(typeof(_003CSplitText_003Ed__13))]
	private static IEnumerable<string?> SplitText(string text, BreakMode breakMode, string customDelimiter)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CSplitText_003Ed__13(-2)
		{
			_003C_003E3__text = text,
			_003C_003E3__breakMode = breakMode,
			_003C_003E3__customDelimiter = customDelimiter
		};
	}

	public static void ResolveConflict(string name, string folder, out bool applyToAll, out bool skip, out bool overwrite, out bool abort, FileExistsResult? buttonsOverride = null)
	{
		skip = false;
		overwrite = false;
		abort = false;
		CheckboxDialogContent checkboxDialogContent = new CheckboxDialogContent();
		checkboxDialogContent.Message = LocalizedStrings.Get("FILE_CONFLICT_label", new object[1] { Path.Combine(folder, name) });
		checkboxDialogContent.CheckboxText = LocalizedStrings.Get("FILE_CONFLICT_APPLY_TO_ALL_title");
		CheckboxDialogContent checkboxDialogContent2 = checkboxDialogContent;
		FileExistsResult buttons = buttonsOverride ?? (FileExistsResult.UseExisting | FileExistsResult.AddNewVersion | FileExistsResult.WriteOver);
		FileExistsResult? fileExistsResult = MessageDialogService.ShowDialog(LocalizedStrings.Get("FILE_CONFLICT_title"), (DependencyObject)(object)checkboxDialogContent2, buttons, FileExistsResult.WriteOver);
		applyToAll = checkboxDialogContent2.Checked;
		if (fileExistsResult.HasValue)
		{
			switch (fileExistsResult.Value)
			{
			case FileExistsResult.UseExisting:
			case FileExistsResult.Skip:
				skip = true;
				break;
			case FileExistsResult.AddNewVersion:
				overwrite = false;
				break;
			case FileExistsResult.WriteOver:
				overwrite = true;
				break;
			}
		}
		else
		{
			abort = true;
		}
	}

	public static void FindMedia(this Playlist protoPlaylist, Action<Pro.SerializationInterop.RVProtoData.Media> mediaElementCallback, Action<PlaylistItem.Types.Presentation>? presentationCallback)
	{
		if (protoPlaylist.SmartDirectory != null)
		{
			return;
		}
		switch (protoPlaylist.ChildrenTypeCase)
		{
		case Playlist.ChildrenTypeOneofCase.Playlists:
			protoPlaylist.Playlists.Playlists.ForEach(delegate(Playlist p)
			{
				p.FindMedia(mediaElementCallback, presentationCallback);
			});
			break;
		case Playlist.ChildrenTypeOneofCase.Items:
			protoPlaylist.Items.Items.ForEach(delegate(PlaylistItem i)
			{
				i.FindMedia(mediaElementCallback, presentationCallback);
			});
			break;
		}
	}

	public static void FindMedia(this Pro.SerializationInterop.RVProtoData.Presentation protoPresentation, Action<Pro.SerializationInterop.RVProtoData.Media> mediaElementCallback)
	{
		protoPresentation.Cues.FindMedia(mediaElementCallback);
		Pro.SerializationInterop.RVProtoData.Presentation.Types.Timeline timeline = protoPresentation.Timeline;
		if (timeline == null)
		{
			return;
		}
		Pro.SerializationInterop.RVProtoData.Action audioAction = timeline.AudioAction;
		if (audioAction != null)
		{
			mediaElementCallback?.Invoke(audioAction.Media.Element);
		}
		foreach (Pro.SerializationInterop.RVProtoData.Action item in from c in timeline.Cues
			select c.Action into a
			where a != null && a.Type == Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.Media
			select a)
		{
			mediaElementCallback?.Invoke(item.Media.Element);
		}
	}

	public static void FindMedia(this IEnumerable<Cue> cues, Action<Pro.SerializationInterop.RVProtoData.Media> mediaElementCallback)
	{
		IEnumerable<Pro.SerializationInterop.RVProtoData.Slide> slides = cues.SelectMany((Cue c) => c.Actions.Select((Pro.SerializationInterop.RVProtoData.Action a) => getBaseSlide(a.Slide))).NonNull();
		foreach (Pro.SerializationInterop.RVProtoData.Action.Types.MediaType item in cues.SelectMany((Cue c) => c.Actions.Select((Pro.SerializationInterop.RVProtoData.Action a) => a.Media).NonNull()))
		{
			mediaElementCallback?.Invoke(item.Element);
		}
		if (mediaElementCallback != null)
		{
			slides.FindMedia(mediaElementCallback);
		}
		static Pro.SerializationInterop.RVProtoData.Slide? getBaseSlide(Pro.SerializationInterop.RVProtoData.Action.Types.SlideType s)
		{
			if (s == null)
			{
				return null;
			}
			return s.SlideCase switch
			{
				Pro.SerializationInterop.RVProtoData.Action.Types.SlideType.SlideOneofCase.Presentation => s.Presentation.BaseSlide, 
				Pro.SerializationInterop.RVProtoData.Action.Types.SlideType.SlideOneofCase.Prop => s.Prop.BaseSlide, 
				_ => null, 
			};
		}
	}

	public static void FindMedia(this IEnumerable<Pro.SerializationInterop.RVProtoData.Slide> slides, Action<Pro.SerializationInterop.RVProtoData.Media> mediaElementCallback)
	{
		List<Pro.SerializationInterop.RVProtoData.Slide> source = slides.ToList();
		IEnumerable<Pro.SerializationInterop.RVProtoData.Media> first = source.SelectMany((Pro.SerializationInterop.RVProtoData.Slide s) => s?.Elements?.Select((Pro.SerializationInterop.RVProtoData.Slide.Types.Element e) => e?.Element_?.Fill?.Media) ?? Enumerable.Empty<Pro.SerializationInterop.RVProtoData.Media>()).NonNull();
		IEnumerable<Pro.SerializationInterop.RVProtoData.Media> second = source.SelectMany((Pro.SerializationInterop.RVProtoData.Slide s) => s?.Elements?.Where((Pro.SerializationInterop.RVProtoData.Slide.Types.Element e) => e.Element_?.Text?.Attributes?.CustomAttributes != null).SelectMany((Pro.SerializationInterop.RVProtoData.Slide.Types.Element e) => e.Element_.Text.Attributes.CustomAttributes.Select((Graphics.Types.Text.Types.Attributes.Types.CustomAttribute a) => a.MediaFill?.Media)) ?? Enumerable.Empty<Pro.SerializationInterop.RVProtoData.Media>()).NonNull();
		first = first.Concat(second);
		foreach (Pro.SerializationInterop.RVProtoData.Media item in first)
		{
			mediaElementCallback?.Invoke(item);
		}
	}

	public static void FindMedia(this PlaylistItem protoPlaylistItem, Action<Pro.SerializationInterop.RVProtoData.Media> mediaElementCallback, Action<PlaylistItem.Types.Presentation>? presentationCallback)
	{
		switch (protoPlaylistItem.ItemTypeCase)
		{
		case PlaylistItem.ItemTypeOneofCase.Cue:
		{
			foreach (Pro.SerializationInterop.RVProtoData.Action.Types.MediaType item in protoPlaylistItem.Cue.Actions.Select((Pro.SerializationInterop.RVProtoData.Action a) => a.Media).NonNull())
			{
				mediaElementCallback?.Invoke(item.Element);
			}
			break;
		}
		case PlaylistItem.ItemTypeOneofCase.PlanningCenter:
			protoPlaylistItem.PlanningCenter.LinkedData.FindMedia(mediaElementCallback, presentationCallback);
			break;
		case PlaylistItem.ItemTypeOneofCase.Presentation:
			presentationCallback?.Invoke(protoPlaylistItem.Presentation);
			break;
		}
	}

	public static void FindPlaceholders(this Playlist protoPlaylist, Action<PlaylistItem.Types.Presentation>? presentationCallback)
	{
		if (protoPlaylist.SmartDirectory != null)
		{
			return;
		}
		switch (protoPlaylist.ChildrenTypeCase)
		{
		case Playlist.ChildrenTypeOneofCase.Playlists:
			protoPlaylist.Playlists.Playlists.ForEach(delegate(Playlist p)
			{
				p.FindPlaceholders(presentationCallback);
			});
			break;
		case Playlist.ChildrenTypeOneofCase.Items:
			protoPlaylist.Items.Items.ForEach(delegate(PlaylistItem i)
			{
				i.FindPlaceholders(presentationCallback);
			});
			break;
		}
	}

	public static void FindPlaceholders(this PlaylistItem protoPlaylistItem, Action<PlaylistItem.Types.Presentation>? presentationCallback)
	{
		if (protoPlaylistItem.Placeholder?.LinkedData != null && protoPlaylistItem.ItemTypeCase == PlaylistItem.ItemTypeOneofCase.Placeholder && protoPlaylistItem.Placeholder.LinkedData.ItemTypeCase == PlaylistItem.ItemTypeOneofCase.Presentation)
		{
			presentationCallback?.Invoke(protoPlaylistItem.Placeholder.LinkedData.Presentation);
		}
	}

	public static void ReGuidMedia(this Pro.SerializationInterop.RVProtoData.Presentation protoPresentation)
	{
		protoPresentation.FindMedia(delegate(Pro.SerializationInterop.RVProtoData.Media element)
		{
			element.Uuid = Guid.NewGuid().ToUUID();
		});
	}

	public static void Relink(this Pro.SerializationInterop.RVProtoData.Presentation protoPresentation, Func<string, string> getName)
	{
		IEnumerable<PresentationSlide> source = (from a in protoPresentation.Cues.SelectMany((Cue c) => c.Actions)
			select a.Slide?.Presentation).NonNull();
		protoPresentation.FindMedia(delegate(Pro.SerializationInterop.RVProtoData.Media element)
		{
			element.Uuid = Guid.NewGuid().ToUUID();
			element.Url = element.Url.ConvertToLocal(CommonPaths.MediaAssets, getName);
		});
		protoPresentation.ChordChart = ChangeChordChart(protoPresentation.ChordChart, 1, getName);
		source.ForEach(delegate(PresentationSlide s)
		{
			s.ChordChart = ChangeChordChart(s.ChordChart, 1, getName);
		});
	}

	public static void Relink(this IEnumerable<Cue> cues, Func<string, string> getName)
	{
		cues.FindMedia(delegate(Pro.SerializationInterop.RVProtoData.Media element)
		{
			element.Url = element.Url.ConvertToLocal(CommonPaths.MediaAssets, getName);
		});
	}

	public static void Relink(this Playlist protoPlaylist, Func<string, string> getName, Func<string>? libraryNameCallback = null)
	{
		Action<PlaylistItem.Types.Presentation> presentationCallback = delegate(PlaylistItem.Types.Presentation p)
		{
			string text = libraryNameCallback?.Invoke();
			text = ((!string.IsNullOrWhiteSpace(text)) ? text : "Default");
			p.DocumentPath = p.DocumentPath.ConvertToLocal(Path.Combine(CommonPaths.Libraries, text), (string path) => getName(Path.GetFileName(path)));
		};
		protoPlaylist.FindMedia(delegate(Pro.SerializationInterop.RVProtoData.Media e)
		{
			e.Url = e.Url.ConvertToLocal(CommonPaths.MediaAssets, getName);
		}, presentationCallback);
		protoPlaylist.FindPlaceholders(presentationCallback);
	}

	public static void RelinkThemeAssets(this string themefile, string themeFolder, string assetsFolder, Action<Pro.SerializationInterop.RVProtoData.Media>? copyMediaCallback = null)
	{
		if ((bool)ProtoHelper.TryReadFile<Template.Types.Document>(themefile, out Template.Types.Document data))
		{
			using (RelativePath.SetCurrentResourceRoot(themeFolder))
			{
				Directory.CreateDirectory(assetsFolder);
				RelinkThemeAssets(data, assetsFolder, copyMediaCallback);
				ProtoHelper.WriteFile(themefile, data);
			}
		}
	}

	public static void ImportThemeAssets(this string themeFile, string assetsFolder, IFileSystem fileSystem, IMediaFactory mediaFactory, string containerId)
	{
		if (!ProtoHelper.TryReadFile<Template.Types.Document>(themeFile, out Template.Types.Document data))
		{
			return;
		}
		data.Slides.Select((Template.Types.Slide s) => s.BaseSlide).FindMedia(delegate(Pro.SerializationInterop.RVProtoData.Media m)
		{
			m.Url = m.Url.ConvertToLocal(assetsFolder, null);
			if (m.Url != null && fileSystem.File.Exists(m.Url.AbsoluteString))
			{
				FileMediaBase fileMediaBase = mediaFactory.CreateEmptyFileMedia(m.Url.AbsoluteString, containerId, null);
				fileMediaBase.DisconnectMediaNotifications();
				fileMediaBase.ProtoDeserialize(m, containerId);
			}
		});
	}

	public static void RelinkThemeAssets(Template.Types.Document templateDocument, string assetsFolder, Action<Pro.SerializationInterop.RVProtoData.Media>? copyMediaCallback = null)
	{
		templateDocument.Slides.Select((Template.Types.Slide s) => s.BaseSlide).FindMedia(delegate(Pro.SerializationInterop.RVProtoData.Media m)
		{
			copyMediaCallback?.Invoke(m);
			m.Url = m.Url.ConvertToLocal(assetsFolder, null);
		});
		(from action in templateDocument.Slides.SelectMany((Template.Types.Slide protoTemplate) => protoTemplate.Actions)
			select action.Media).NonNull().ForEach(delegate(Pro.SerializationInterop.RVProtoData.Action.Types.MediaType media)
		{
			copyMediaCallback?.Invoke(media.Element);
			media.Element.Url = media.Element.Url.ConvertToLocal(assetsFolder, null);
		});
	}

	public static URL? ConvertToLocal(this URL protoUrl, string? targetFolder, Func<string, string>? getName)
	{
		if (protoUrl == null)
		{
			return protoUrl;
		}
		string text = protoUrl.AbsoluteString;
		if (string.IsNullOrWhiteSpace(text))
		{
			text = protoUrl.RelativePath;
		}
		if (string.IsNullOrWhiteSpace(text))
		{
			text = protoUrl.Local?.Path;
		}
		text = Uri.UnescapeDataString(text ?? string.Empty).SanitizeFilePath("_").Normalize();
		text = getName?.Invoke(text) ?? text;
		if (!string.IsNullOrWhiteSpace(text))
		{
			return new RelativePath(Path.Combine(targetFolder ?? string.Empty, Path.GetFileName(text))).Serialize();
		}
		return protoUrl;
	}

	public static URL? ChangeChordChart(URL protoChordChartUrl, int pageNumber, Func<string, string>? getName, string? folder = null)
	{
		RelativePath relativePath = RelativePath.Empty();
		folder = folder ?? CommonPaths.MediaAssets;
		if (protoChordChartUrl == null)
		{
			return relativePath.Serialize();
		}
		if (protoChordChartUrl.AbsoluteString.IsPDFFile())
		{
			string text = Uri.UnescapeDataString(protoChordChartUrl.AbsoluteString);
			if (File.Exists(text))
			{
				RelativePath relativePath2 = new RelativePath(text);
				if (relativePath2.FullPath != null && !relativePath2.FullPath.Contains(folder) && (bool)FileHelper.WaitForFileAccess(relativePath2, enforceFileExists: false, null))
				{
					URL uRL = relativePath2.Serialize().ConvertToLocal(folder, getName);
					if (uRL != null)
					{
						string text2 = uRL.AbsoluteString;
						if ((bool)FileHelper.WaitForFileAccess(text2, enforceFileExists: false, null))
						{
							if (File.Exists(folder))
							{
								File.Copy(relativePath2.FullPath, text2);
							}
							else
							{
								text2 = text;
							}
							using PdfRenderer pdfRenderer = new PdfRenderer(text2);
							try
							{
								BitmapSource source = pdfRenderer.RenderPageToImage(pageNumber, 1.0);
								RelativePath relativePath3 = (RelativePath)Path.Combine(folder, Guid.NewGuid().ToString().ToUpperInvariant() + ".png");
								relativePath = (UnitTestDetector.IsInUnitTest ? new RelativePath(relativePath3) : (source.TryWriteImage(relativePath3) ? new RelativePath(relativePath3) : RelativePath.Empty()));
							}
							catch (Exception ex)
							{
								Log.Error(ex.Message);
								relativePath = RelativePath.Empty();
							}
						}
					}
				}
				else
				{
					relativePath = relativePath2;
				}
			}
		}
		else if (protoChordChartUrl.AbsoluteString.IsImageFile())
		{
			return protoChordChartUrl.ConvertToLocal(folder, getName);
		}
		return relativePath.Serialize();
	}

	public static void SetImportDelegates()
	{
		ImportPrompt.RegisterResolveConflictPrompt(RequestHandlerType.Presentation, ResolvePresentationConflict);
		ImportPrompt.RegisterResolveConflictPrompt(RequestHandlerType.Theme, ResolveThemeConflict);
		ImportPrompt.RegisterResolveConflictPrompt(RequestHandlerType.Media, ResolveMediaConflict);
		ImportPrompt.RegisterItemExistsPrompt(RequestHandlerType.Presentation, DoesPresentationExist);
		ImportPrompt.RegisterItemExistsPrompt(RequestHandlerType.Theme, DoesThemeExist);
		ImportPrompt.RegisterItemExistsPrompt(RequestHandlerType.Media, DoesMediaExist);
		ImportPrompt.RegisterDuplicateNamePrompt(RequestHandlerType.Presentation, DuplicatePresentationName);
		ImportPrompt.RegisterDuplicateNamePrompt(RequestHandlerType.Theme, DuplicateThemeName);
		ImportPrompt.RegisterDuplicateNamePrompt(RequestHandlerType.Media, DuplicateMediaName);
	}

	public static void ShowImportFileNotSupportedDialog(IEnumerable<IImportRequest> requests)
	{
		List<FileImportRequest> source = requests.Where((IImportRequest r) => r is FileImportRequest).Cast<FileImportRequest>().ToList();
		if (source.Any())
		{
			MessageDialogService.ShowSimpleContent(LocalizedStrings.Get("IMPORT_ERROR_UNSUPPORTED_FILES_description"), LocalizedStrings.Get("IMPORT_ERROR_UNSUPPORTED_FILES_info", new object[1] { string.Join(",", source.Select((FileImportRequest r) => r.Filename)) }), canCancel: false);
		}
	}

	private static void ResolvePresentationConflict(IImportRequest request, string name, out bool applyToAll, out bool skip, out bool overwrite, out bool abort)
	{
		ResolveConflict(name, CommonPaths.Libraries, out applyToAll, out skip, out overwrite, out abort, null);
	}

	private static void ResolveThemeConflict(IImportRequest request, string name, out bool applyToAll, out bool skip, out bool overwrite, out bool abort)
	{
		ResolveConflict(name, CommonPaths.Themes, out applyToAll, out skip, out overwrite, out abort, null);
	}

	private static void ResolveMediaConflict(IImportRequest request, string name, out bool applyToAll, out bool skip, out bool overwrite, out bool abort)
	{
		ResolveConflict(name, (request as FileImportRequest)?.TargetFolder ?? CommonPaths.MediaAssets, out applyToAll, out skip, out overwrite, out abort, null);
	}

	private static bool DoesPresentationExist(ImportProcess process, string name, IImportRequest request)
	{
		if (!(request is FileImportRequest fileImportRequest))
		{
			return process.SelectedLibrary?.DoesPresentationExist(name) ?? false;
		}
		return fileImportRequest.TargetLibrary?.DoesPresentationExist(name) ?? process.SelectedLibrary?.DoesPresentationExist(name) ?? false;
	}

	private static bool DoesThemeExist(ImportProcess process, string name, IImportRequest request)
	{
		return _themes.DoesThemeExist(name);
	}

	private static bool DoesMediaExist(ImportProcess process, string name, IImportRequest request)
	{
		if (request is FileImportRequest fileImportRequest)
		{
			if (fileImportRequest.SkipFileExistCheck || fileImportRequest.OverWriteOnConflict)
			{
				return false;
			}
			if (!string.IsNullOrEmpty(fileImportRequest.TargetFolder))
			{
				string? targetFolder = fileImportRequest.TargetFolder;
				if (targetFolder != null && targetFolder.Contains(CommonPaths.Themes))
				{
					return false;
				}
				return DoesMediaExist(fileImportRequest.TargetFolder ?? string.Empty, name + fileImportRequest.FileExtension);
			}
			if (fileImportRequest.ForceManageMedia || Advanced.Settings.ManageMediaAutomatically)
			{
				return DoesMediaExist(CommonPaths.MediaAssets, name + fileImportRequest.FileExtension);
			}
			return false;
		}
		return false;
	}

	private static bool DoesMediaExist(string folder, string filename)
	{
		if (Directory.Exists(folder))
		{
			return (from f in Directory.GetFiles(folder)
				where f.IsMediaFile()
				select f).Select(Path.GetFileName).Contains<string>(filename);
		}
		return false;
	}

	private static string DuplicateMediaName(ImportProcess process, string name, IImportRequest request)
	{
		return name.DuplicateName(from f in Directory.GetFiles(CommonPaths.MediaAssets)
			where f.IsMediaFile()
			select f, Path.GetFileNameWithoutExtension);
	}

	private static string DuplicatePresentationName(ImportProcess process, string name, IImportRequest request)
	{
		ILibrary library = ((request is FileImportRequest fileImportRequest) ? (fileImportRequest.TargetLibrary ?? process.SelectedLibrary) : process.SelectedLibrary);
		if (library != null)
		{
			return Path.GetFileNameWithoutExtension(name).DuplicateName(library.Select((DocumentCue c) => c.Name), Path.GetFileNameWithoutExtension);
		}
		return name;
	}

	private static string DuplicateThemeName(ImportProcess process, string name, IImportRequest request)
	{
		return Path.GetFileNameWithoutExtension(name).DuplicateName(_themes.Select((Theme c) => c.Name), Path.GetFileNameWithoutExtension);
	}

	[CompilerGenerated]
	internal static bool _003CSplitText_003Eg__isGroupValid_007C13_0(ref _003C_003Ec__DisplayClass13_0 P_0)
	{
		if (!string.IsNullOrWhiteSpace(P_0.group))
		{
			return !Metadata.IsMetadata(P_0.group);
		}
		return false;
	}
}
