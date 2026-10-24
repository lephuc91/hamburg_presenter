using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.RegularExpressions;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.Common.Logging;
using Pro.Common.ObjectBinding;
using Pro.Common.Strings;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using Pro.Text;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements;

namespace ProPresenter.DO.Slide.Links;

public class SlideTextLinkedObject : LinkedTextObjectBase
{
	private SlideTextSourceMode _textSourceMode;

	private bool _preserveNotesFormat;

	private string _elementMatchPattern;

	public override LinkedTextType LinkedTextType
	{
		get
		{
			if (TargetSourceMode != 0)
			{
				return LinkedTextType.NextSlide;
			}
			return LinkedTextType.CurrentSlide;
		}
	}

	public override string DisplayText => GetDisplayText();

	public override FormattingType FormattingType
	{
		get
		{
			if (TextSourceMode != SlideTextSourceMode.Notes || !PreserveNotesFormat)
			{
				return FormattingType.Additional;
			}
			return FormattingType.Full;
		}
	}

	public SlideTargetSourceMode TargetSourceMode { get; }

	public SlideTextSourceMode TextSourceMode
	{
		get
		{
			return _textSourceMode;
		}
		set
		{
			SetValue("TextSourceMode", ref _textSourceMode, value, delegate(SlideTextSourceMode o, SlideTextSourceMode n)
			{
				base.UndoStack?.Commit(UndoActionTypes.LinkSlideText.ToAction(), this, "TextSourceMode", o, n);
				OnDataModified();
			});
		}
	}

	public bool PreserveNotesFormat
	{
		get
		{
			return _preserveNotesFormat;
		}
		set
		{
			SetValue("PreserveNotesFormat", ref _preserveNotesFormat, value, delegate(bool o, bool n)
			{
				base.UndoStack?.Commit(UndoActionTypes.PreserveNotesFormat.ToAction(), this, "PreserveNotesFormat", o, n);
				OnDataModified();
			});
		}
	}

	public string ElementMatchPattern
	{
		get
		{
			return _elementMatchPattern;
		}
		set
		{
			SetValue("ElementMatchPattern", ref _elementMatchPattern, value, delegate(string o, string n)
			{
				base.UndoStack?.Commit(UndoActionTypes.LinkElementPattern.ToAction(), this, "ElementMatchPattern", o, n);
				OnDataModified();
			});
		}
	}

	public static ObjectBinder<SlideTextLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.ISlideText> CreateBinder(SlideTextLinkedObject left, ISlide.Types.IElement.Types.IDataLink.Types.ISlideText right)
	{
		ObjectBinder<SlideTextLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.ISlideText> objectBinder = new ObjectBinder<SlideTextLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.ISlideText>(left, right);
		objectBinder.Bind((SlideTextLinkedObject l) => l.WhenPropertyChanges("TargetSourceMode"), (ISlide.Types.IElement.Types.IDataLink.Types.ISlideText r) => r.SourceSlide.WhenValueChanges, delegate(SlideTextLinkedObject l, ISlide.Types.IElement.Types.IDataLink.Types.ISlideText r)
		{
			r.SourceSlide.Set(l.TargetSourceMode.ToEntitySlideSourceType());
		}, delegate
		{
		}).Bind((SlideTextLinkedObject l) => l.WhenPropertyChanges("TextSourceMode"), (ISlide.Types.IElement.Types.IDataLink.Types.ISlideText r) => r.SourceOption.WhenValueChanges, delegate(SlideTextLinkedObject l, ISlide.Types.IElement.Types.IDataLink.Types.ISlideText r)
		{
			r.SourceOption.Set(l.TextSourceMode.ToEntitySlideTextSourceOption());
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.ISlideText r, SlideTextLinkedObject l)
		{
			l.TextSourceMode = r.SourceOption.Value.ToSlideTextSourceMode();
		}).Bind((SlideTextLinkedObject l) => l.WhenPropertyChanges("PreserveNotesFormat"), (ISlide.Types.IElement.Types.IDataLink.Types.ISlideText r) => r.PreserveNotesFormat.WhenValueChanges, delegate(SlideTextLinkedObject l, ISlide.Types.IElement.Types.IDataLink.Types.ISlideText r)
		{
			r.PreserveNotesFormat.Set(l.PreserveNotesFormat);
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.ISlideText r, SlideTextLinkedObject l)
		{
			l.PreserveNotesFormat = r.PreserveNotesFormat.Value;
		})
			.Bind((SlideTextLinkedObject l) => l.WhenPropertyChanges("ElementMatchPattern"), (ISlide.Types.IElement.Types.IDataLink.Types.ISlideText r) => r.NameToMatch.WhenValueChanges, delegate(SlideTextLinkedObject l, ISlide.Types.IElement.Types.IDataLink.Types.ISlideText r)
			{
				r.NameToMatch.Set(l.ElementMatchPattern);
			}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.ISlideText r, SlideTextLinkedObject l)
			{
				l.ElementMatchPattern = r.NameToMatch.Value;
			});
		return objectBinder;
	}

	public SlideTextLinkedObject()
	{
		_elementMatchPattern = string.Empty;
	}

	public SlideTextLinkedObject(SlideTargetSourceMode targetSlide, SlideTextSourceMode mode)
		: this(targetSlide, mode, preserveNotesFormat: false, string.Empty)
	{
	}

	public SlideTextLinkedObject(SlideTargetSourceMode targetSlide, SlideTextSourceMode mode, bool preserveNotesFormat, string? elementMatchPattern)
	{
		TargetSourceMode = targetSlide;
		_textSourceMode = mode;
		PreserveNotesFormat = preserveNotesFormat;
		_elementMatchPattern = elementMatchPattern ?? string.Empty;
	}

	public override bool RenderEquals([NotNullWhen(true)] ILinkedTextObject? other)
	{
		if (other is SlideTextLinkedObject slideTextLinkedObject && TargetSourceMode == slideTextLinkedObject.TargetSourceMode && _textSourceMode == slideTextLinkedObject._textSourceMode && _preserveNotesFormat == slideTextLinkedObject._preserveNotesFormat)
		{
			return _elementMatchPattern == slideTextLinkedObject._elementMatchPattern;
		}
		return false;
	}

	public override int GetRenderHashCode()
	{
		return RenderHashCodeHelper.GenerateHashCode(TargetSourceMode, _textSourceMode, _preserveNotesFormat, _elementMatchPattern);
	}

	public override string GetText(ILinkData? linkData)
	{
		if (linkData == null)
		{
			return GetDisplayText(isLabel: false);
		}
		SlideBase targetSlide = GetTargetSlide(linkData);
		if (targetSlide == null)
		{
			return string.Empty;
		}
		return TextSourceMode switch
		{
			SlideTextSourceMode.TextOnly => GetSlideText(targetSlide)?.AllText ?? string.Empty, 
			SlideTextSourceMode.Notes => targetSlide.Note?.AllText ?? string.Empty, 
			SlideTextSourceMode.ElementMatch => GetMatchingElementText(targetSlide), 
			_ => throw new NotSupportedException(), 
		};
	}

	public override TextDocument? GetFormattedText(ILinkData linkData, TextDocument linkedText)
	{
		if (linkData == null)
		{
			return null;
		}
		SlideBase targetSlide = GetTargetSlide(linkData);
		if (targetSlide == null)
		{
			return null;
		}
		if (TextSourceMode == SlideTextSourceMode.Notes)
		{
			TextDocument textDocument = targetSlide.Note?.Clone();
			if (textDocument != null)
			{
				if (linkedText != null)
				{
					ParagraphAlignment? paragraphAlignment = linkedText.FirstOrDefault()?.Settings.Alignment;
					if (paragraphAlignment.HasValue)
					{
						ParagraphAlignment paragraphAlignment2 = paragraphAlignment.GetValueOrDefault();
						textDocument.IterateAllParagraphs(delegate(Pro.Text.Range range, Paragraph par)
						{
							par.Settings.Alignment = paragraphAlignment2;
						});
					}
					textDocument.Settings.Margins.Left = linkedText.Settings.Margins.Left;
					textDocument.Settings.Margins.Top = linkedText.Settings.Margins.Top;
					textDocument.Settings.Margins.Right = linkedText.Settings.Margins.Right;
					textDocument.Settings.Margins.Bottom = linkedText.Settings.Margins.Bottom;
					textDocument.Settings.Alignment = linkedText.Settings.Alignment;
					textDocument.Settings.ScaleMode = linkedText.Settings.ScaleMode;
					textDocument.Settings.Transform = linkedText.Settings.Transform;
					textDocument.Settings.Shadow.IsEnabled = linkedText.Settings.Shadow.IsEnabled;
					textDocument.Settings.Shadow.BlurRadius = linkedText.Settings.Shadow.BlurRadius;
					textDocument.Settings.Shadow.Opacity = linkedText.Settings.Shadow.Opacity;
					textDocument.Settings.Shadow.Color = linkedText.Settings.Shadow.Color;
					textDocument.Settings.Shadow.Angle = linkedText.Settings.Shadow.Angle;
					textDocument.Settings.Shadow.Offset = linkedText.Settings.Shadow.Offset;
				}
				return textDocument;
			}
			return null;
		}
		throw new NotSupportedException();
	}

	public override void FormatText(ILinkData? linkData, TextDocument? document)
	{
		if (!(document != null))
		{
			return;
		}
		if (linkData != null && (TextSourceMode == SlideTextSourceMode.TextOnly || TextSourceMode == SlideTextSourceMode.Notes))
		{
			SlideBase targetSlide = GetTargetSlide(linkData);
			TextDocument textDocument = TextSourceMode switch
			{
				SlideTextSourceMode.TextOnly => GetSlideText(targetSlide), 
				SlideTextSourceMode.Notes => targetSlide?.Note, 
				_ => null, 
			};
			if (!(textDocument != null))
			{
				return;
			}
			document.ListSettingsCollection.Clear();
			document.ListSettingsCollection = textDocument.ListSettingsCollection.Clone();
			textDocument.IterateAllParagraphs(delegate(Pro.Text.Range range, Paragraph paragraph)
			{
				document.IterateParagraphs(range, delegate(Paragraph _paragraph)
				{
					_paragraph.Settings.LevelIndex = paragraph.Settings.LevelIndex;
					_paragraph.Settings.ListIndex = paragraph.Settings.ListIndex;
				});
			});
			textDocument.IterateAllRuns(delegate(Pro.Text.Range range, RunBase run)
			{
				string originalChord = run.Settings.ChordAnnotation;
				if (!string.IsNullOrWhiteSpace(originalChord))
				{
					document.IterateRuns(range, splitRuns: true, delegate(RunBase r)
					{
						r.Settings.ChordAnnotation = originalChord;
					});
				}
			});
		}
		else
		{
			if (linkData != null)
			{
				return;
			}
			document.IterateRuns(Pro.Text.Range.All, splitRuns: true, delegate(RunBase r)
			{
				r.Settings.ChordAnnotation = null;
			});
			for (int i = 0; i < 3; i++)
			{
				string placeholderChord = i switch
				{
					0 => "C", 
					1 => "G", 
					2 => "Am", 
					_ => null, 
				};
				int num = document.LastCharacterIndex / 3 * i;
				document.IterateRuns(new Pro.Text.Range(num, num + (placeholderChord?.Length ?? 0)), splitRuns: true, delegate(RunBase r)
				{
					r.Settings.ChordAnnotation = placeholderChord;
				});
			}
		}
	}

	public override ILinkedTextObject Clone()
	{
		return new SlideTextLinkedObject(TargetSourceMode, _textSourceMode, _preserveNotesFormat, _elementMatchPattern);
	}

	public override void Serialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink dataLink)
	{
		dataLink.SlideText = new Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.SlideText
		{
			SourceSlide = TargetSourceMode.ToProtoSlideSourceType(),
			SourceOption = TextSourceMode.ToProtoSlideTextSourceOption(),
			PreserveNotesFormat = PreserveNotesFormat,
			NameToMatch = (ElementMatchPattern ?? string.Empty)
		};
	}

	public static SlideTextLinkedObject? Deserialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.SlideText protoSlideText)
	{
		try
		{
			return new SlideTextLinkedObject(protoSlideText.SourceSlide.ToSlideTargetSourceMode(), protoSlideText.SourceOption.ToSlideTextSourceMode(), protoSlideText.PreserveNotesFormat, protoSlideText.NameToMatch);
		}
		catch (NotSupportedException exception)
		{
			Log.Error("Encountered an unknown type");
			Log.Error(exception);
			return null;
		}
	}

	private string GetDisplayText(bool isLabel = true)
	{
		SlideTextSourceMode textSourceMode = TextSourceMode;
		if ((uint)textSourceMode <= 2u)
		{
			return LocalizedStrings.Get((TargetSourceMode == SlideTargetSourceMode.Current) ? "TEXT_LINK_CURRENT_SLIDE_title" : "TEXT_LINK_NEXT_SLIDE_title") + " " + (isLabel ? "- " : string.Empty) + LocalizedStrings.Get(TextSourceMode);
		}
		throw new NotSupportedException();
	}

	private SlideBase? GetTargetSlide(ILinkData linkData)
	{
		return TargetSourceMode switch
		{
			SlideTargetSourceMode.Current => linkData.CurrentSlide, 
			SlideTargetSourceMode.Next => linkData.NextSlide, 
			_ => throw new NotSupportedException(), 
		};
	}

	private static TextDocument? GetSlideText(SlideBase? targetSlide)
	{
		if (targetSlide is CustomSlide customSlide)
		{
			TextDocument textDocument = new TextDocument();
			bool flag = true;
			{
				foreach (ClosedBezierPath item in from e in customSlide.Elements.OfType<ClosedBezierPath>().Where(delegate(ClosedBezierPath e)
					{
						TextDocument displayText = e.DisplayText;
						return (object)displayText != null && displayText.HasText && !(e.TextLink?.IsEnabled ?? false);
					})
					orderby e.ZOrder descending
					select e)
				{
					if (!flag)
					{
						textDocument.AddParagraph();
					}
					textDocument.InsertDocument(textDocument.LastCharacterIndex, item.DisplayText);
					flag = false;
				}
				return textDocument;
			}
		}
		return null;
	}

	private string GetMatchingElementText(SlideBase targetSlide)
	{
		CustomSlide customSlide = targetSlide as CustomSlide;
		if (customSlide == null)
		{
			return string.Empty;
		}
		return matchElement()?.Text?.AllText ?? string.Empty;
		ClosedBezierPath? matchElement()
		{
			IEnumerable<ClosedBezierPath> collection = customSlide.Elements.OfType<ClosedBezierPath>();
			ClosedBezierPath? closedBezierPath = collection.FirstOrDefaultBy((ClosedBezierPath e) => matchNameCaseSensitive(e.Name, ElementMatchPattern), (ClosedBezierPath e) => matchNameCaseInsensitive(e.Name, ElementMatchPattern));
			if (closedBezierPath == null)
			{
				closedBezierPath = collection.FirstOrDefaultBy((ClosedBezierPath e) => matchNameWildCardCaseSensitive(e.Name, ElementMatchPattern.ToWildCardRegex()), (ClosedBezierPath e) => matchNameWildCardCaseInsensitive(e.Name, ElementMatchPattern.ToWildCardRegex()));
				if (closedBezierPath == null)
				{
					if (!ElementMatchPattern.IsValidRegex(out Regex regex))
					{
						return null;
					}
					closedBezierPath = collection.FirstOrDefaultBy((ClosedBezierPath e) => matchNameCaseSensitive(e.Name, regex?.Match(e.Name).Value ?? string.Empty), (ClosedBezierPath e) => matchNameCaseInsensitive(e.Name, regex?.Match(e.Name).Value ?? string.Empty));
				}
			}
			return closedBezierPath;
		}
		static bool matchNameCaseInsensitive(string name, string pattern)
		{
			return name?.Equals(pattern, StringComparison.OrdinalIgnoreCase) ?? false;
		}
		static bool matchNameCaseSensitive(string name, string? pattern)
		{
			return name == pattern;
		}
		static bool matchNameWildCardCaseInsensitive(string name, string pattern)
		{
			if (pattern.IsValidRegex(out Regex regex3))
			{
				return matchNameCaseInsensitive(name, regex3?.Match(name).Value ?? string.Empty);
			}
			return false;
		}
		static bool matchNameWildCardCaseSensitive(string name, string pattern)
		{
			if (pattern.IsValidRegex(out Regex regex2))
			{
				return matchNameCaseSensitive(name, regex2?.Match(name).Value);
			}
			return false;
		}
	}
}
