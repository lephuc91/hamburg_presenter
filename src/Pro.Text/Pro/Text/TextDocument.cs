using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Mathematics;
using Pro.Common.Strings;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.Text.Fills;
using Pro.Text.Reversibility;
using Pro.Text.Runs;

namespace Pro.Text;

[DebuggerDisplay("{AllText}")]
public class TextDocument : IEquatable<TextDocument>, IEnumerable<Paragraph>, IEnumerable, ICloneable<TextDocument>
{
	private TextDocumentSettings _settings;

	private TextDocumentAttributes _attributes;

	private readonly ObservableCollection<Paragraph> _paragraphs = new ObservableCollection<Paragraph>();

	private int _changeLevel;

	private bool _hasActualChanges;

	private int? _hashCode;

	private UndoStack? _undoStack;

	private ListSettingsCollection _listSettingsCollection;

	public bool IsDeserializing { get; private set; }

	public TextDocumentSettings Settings
	{
		get
		{
			return _settings;
		}
		[MemberNotNull("_settings")]
		set
		{
			if ((object)_settings != null)
			{
				Settings.SettingsChanged -= OnDocumentChanged;
			}
			_settings = value;
			Settings.SettingsChanged += OnDocumentChanged;
			OnDocumentChanged();
		}
	}

	public TextDocumentAttributes Attributes
	{
		get
		{
			return _attributes;
		}
		[MemberNotNull("_attributes")]
		set
		{
			if (_attributes != null)
			{
				Attributes.SettingsChanged -= OnDocumentChanged;
			}
			if (!object.Equals(_attributes, value))
			{
				_attributes = value;
				this.AttributesChanged?.Invoke();
				_attributes.SetUndoStack(UndoStack);
				_attributes.SettingsChanged += OnDocumentChanged;
				OnDocumentChanged();
			}
		}
	}

	public ListSettingsCollection ListSettingsCollection
	{
		get
		{
			return _listSettingsCollection;
		}
		[MemberNotNull("_listSettingsCollection")]
		set
		{
			if (_listSettingsCollection != value)
			{
				if (_listSettingsCollection != null)
				{
					_listSettingsCollection.ListSettingsChanged -= OnListSettingsChanged;
				}
				_listSettingsCollection = value;
				_listSettingsCollection.ListSettingsChanged += OnListSettingsChanged;
			}
		}
	}

	public Range EntireRange => new Range(0, LastCharacterIndex);

	public string AllText => GetText(EntireRange);

	public bool HasText => !string.IsNullOrEmpty(AllText);

	public int ParagraphCount => _paragraphs.Count;

	public Paragraph this[int index] => _paragraphs[index];

	public int LastCharacterIndex => _paragraphs.CountMany((Paragraph p) => p.TextLength + 1) - 1;

	public UndoStack? UndoStack
	{
		get
		{
			return _undoStack;
		}
		set
		{
			_undoStack = value;
			Settings.UndoStack = value;
			ListSettingsCollection.UndoStack = value;
			_paragraphs.ForEach(delegate(Paragraph p)
			{
				p.UndoStack = value;
			});
			_attributes.SetUndoStack(value);
		}
	}

	public event Action<TextDocument>? DocumentChanged;

	public event Action? AttributesChanged;

	public static void SerializeToEntity(IEntityFactory entityFactory, TextDocument textDocument, IGraphics.Types.IText entity)
	{
		entity.VerticalAlignment.Set(textDocument.Settings.Alignment.ToEntityDocumentAlignment());
		entity.Transform.Set(textDocument.Settings.Transform.ToEntityTextTransform());
		entity.TransformDelimiter.Set(textDocument.Settings.TransformDelimiter);
		entity.ScaleBehavior.Set(textDocument.Settings.ScaleMode.ToEntityScaleBehavior());
		entity.RtfData.Set(Encoding.UTF8.GetBytes(textDocument.ToRTF()));
		SerializeMargins(textDocument.Settings.Margins, entity.Margins.Value);
		SerializeShadow(textDocument.Settings.Shadow, entity.Shadow.Value);
		IGraphics.Types.IText.Types.IAttributes attributes = entity.Attributes.Value;
		if (attributes == null)
		{
			attributes = entityFactory.Create<IGraphics.Types.IText.Types.IAttributes>();
			entity.Attributes.Set(attributes);
		}
		SerializeAttributes(entityFactory, textDocument.Attributes, attributes);
		SerializeCustomAttributes(entityFactory, textDocument, attributes);
		SerializeChordPro(entityFactory, textDocument.Settings.ChordPro, entity);
	}

	private static void SerializeMargins(Margins margins, IGraphics.Types.IEdgeInsets entity)
	{
		entity.Left.Set(margins.Left);
		entity.Top.Set(margins.Top);
		entity.Right.Set(margins.Right);
		entity.Bottom.Set(margins.Bottom);
	}

	private static void SerializeAttributes(IEntityFactory entityFactory, TextDocumentAttributes attributes, IGraphics.Types.IText.Types.IAttributes entityAtrributes)
	{
		SerializeParagraphSettingsToAttributes(entityFactory, attributes.ParagraphSettings, entityAtrributes);
		SerializeRunSettingsToAttributes(entityFactory, attributes.RunSettings, entityAtrributes);
	}

	private static void SerializeCustomAttributes(IEntityFactory entityFactory, TextDocument textDocument, IGraphics.Types.IText.Types.IAttributes entityAtrributes)
	{
		entityAtrributes.CustomAttributes.Clear();
		bool serializeOriginalFontSize = textDocument.Settings.ScaleMode.IsAnyOf(ScaleMode.Up, ScaleMode.Down, ScaleMode.UpOrDown);
		textDocument.IterateAllRuns(delegate(Range range, RunBase run)
		{
			IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute customAttribute = entityFactory.Create<IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute>();
			if (serializeOriginalFontSize)
			{
				customAttribute.Range.Set(new IntRange(range.Start, range.End));
				IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.IOriginalFontSize originalFontSize = entityFactory.Create<IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.IOriginalFontSize>();
				originalFontSize.Set(run.Settings.CharacterSize);
				customAttribute.Attribute.Set(originalFontSize);
			}
			if (run.Settings.CapitalizationType != 0)
			{
				customAttribute.Range.Set(new IntRange(range.Start, range.End));
				IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.ICapitalization capitalization = entityFactory.Create<IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.ICapitalization>();
				capitalization.Set(run.Settings.CapitalizationType.ToEntityCapitalizationType());
				customAttribute.Attribute.Set(capitalization);
			}
			if (IsCustomAttributeFill(run.Settings.Fill))
			{
				customAttribute.Range.Set(new IntRange(range.Start, range.End));
				run.Settings.Fill.SerializeToEntity(entityFactory, customAttribute.Attribute);
			}
			if (!string.IsNullOrWhiteSpace(run.Settings.ChordAnnotation))
			{
				customAttribute.Range.Set(new IntRange(range.Start, range.End));
				IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.IChord chord = entityFactory.Create<IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.IChord>();
				chord.Set(run.Settings.ChordAnnotation);
				customAttribute.Attribute.Set(chord);
			}
			if (run.Settings.PreserveFillColor)
			{
				customAttribute.Range.Set(new IntRange(range.Start, range.End));
				IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.IShouldPreserveForegroundColor shouldPreserveForegroundColor = entityFactory.Create<IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.IShouldPreserveForegroundColor>();
				shouldPreserveForegroundColor.Set(value: true);
				customAttribute.Attribute.Set(shouldPreserveForegroundColor);
			}
			entityAtrributes.CustomAttributes.Add(customAttribute);
		});
	}

	private static void SerializeParagraphSettingsToAttributes(IEntityFactory entityFactory, ParagraphSettings paragraphSettings, IGraphics.Types.IText.Types.IAttributes entityAtrributes)
	{
		IGraphics.Types.IText.Types.IAttributes.Types.IParagraph paragraph = entityAtrributes.ParagraphStyle.Value;
		if (paragraph == null)
		{
			paragraph = entityFactory.Create<IGraphics.Types.IText.Types.IAttributes.Types.IParagraph>();
			entityAtrributes.ParagraphStyle.Set(paragraph);
		}
		paragraph.Alignment.Set(paragraphSettings.Alignment.ToEntityParagraphAlignment());
		paragraph.FirstLineHeadIndent.Set(paragraphSettings.FirstLineIndent);
		paragraph.HeadIndent.Set(paragraphSettings.LeftIndent);
		paragraph.LineHeightMultiple.Set((paragraphSettings.SpacingMode == LineSpacingMode.Multiple) ? paragraphSettings.LineSpacing : 1.0);
		paragraph.LineSpacing.Set(paragraphSettings.AdditionalLineSpacing);
		paragraph.ParagraphSpacing.Set(paragraphSettings.AfterParagraph);
		paragraph.ParagraphSpacingBefore.Set(paragraphSettings.BeforeParagraph);
		paragraph.TailIndent.Set(paragraphSettings.RightIndent);
	}

	private static void SerializeRunSettingsToAttributes(IEntityFactory entityFactory, RunSettings runSettings, IGraphics.Types.IText.Types.IAttributes entityAtrributes)
	{
		entityAtrributes.Capitalization.Set(runSettings.CapitalizationType.ToEntityCapitalizationType());
		entityAtrributes.Font.Set(ToFont(runSettings));
		entityAtrributes.Kerning.Set(runSettings.CharacterSpacing);
		entityAtrributes.StrokeColor.Set(runSettings.StrokeColor.ToEntityColor());
		entityAtrributes.StrokeWidth.Set(runSettings.StrokeThickness);
		entityAtrributes.Superscript.Set(runSettings.ScriptLevel);
		entityAtrributes.LigatureStyle.Set((!runSettings.LigaturesEnabled) ? IGraphics.Types.IText.Types.IAttributes.Types.LigatureStyle.None : IGraphics.Types.IText.Types.IAttributes.Types.LigatureStyle.Default);
		runSettings.Fill.SerializeToEntity(entityFactory, entityAtrributes.Fill);
		if (runSettings.Strikethrough)
		{
			IGraphics.Types.IText.Types.IAttributes.Types.IUnderline underline = entityFactory.Create<IGraphics.Types.IText.Types.IAttributes.Types.IUnderline>();
			underline.Pattern.Set(IGraphics.Types.IText.Types.IAttributes.Types.IUnderline.Types.Pattern.Solid);
			underline.Style.Set(IGraphics.Types.IText.Types.IAttributes.Types.IUnderline.Types.Style.Single);
			entityAtrributes.StrikethroughStyle.Set(underline);
			entityAtrributes.StrikethroughColor.Set(runSettings.Fill.PrimaryColor.ToEntityColor());
		}
		else
		{
			entityAtrributes.StrikethroughStyle.Set(null);
			entityAtrributes.StrikethroughColor.Set(null);
		}
		if (runSettings.Underline)
		{
			IGraphics.Types.IText.Types.IAttributes.Types.IUnderline underline2 = entityFactory.Create<IGraphics.Types.IText.Types.IAttributes.Types.IUnderline>();
			underline2.Pattern.Set(IGraphics.Types.IText.Types.IAttributes.Types.IUnderline.Types.Pattern.Solid);
			underline2.Style.Set(IGraphics.Types.IText.Types.IAttributes.Types.IUnderline.Types.Style.Single);
			entityAtrributes.UnderlineStyle.Set(underline2);
			entityAtrributes.UnderlineColor.Set((runSettings.UnderlineColor ?? runSettings.Fill.PrimaryColor).ToEntityColor());
		}
		else
		{
			entityAtrributes.UnderlineStyle.Set(null);
			entityAtrributes.UnderlineColor.Set(null);
		}
		entityAtrributes.BackgroundColor.Set(runSettings.HighlightColor?.ToEntityColor());
	}

	private static void SerializeShadow(Shadow shadow, IGraphics.Types.IShadow entity)
	{
		entity.Angle.Set(shadow.Angle.Value);
		entity.Offset.Set(shadow.Offset);
		entity.Radius.Set(shadow.BlurRadius);
		entity.Color.Set(shadow.Color.ToEntityColor());
		entity.Opacity.Set(shadow.Opacity);
		entity.Enable.Set(shadow.IsEnabled);
		entity.Style.Set(IGraphics.Types.IShadow.Types.Style.Drop);
	}

	private static void SerializeChordPro(IEntityFactory entityFactory, ChordPro chordPro, IGraphics.Types.IText textEntity)
	{
		IGraphics.Types.IText.Types.IChordPro chordPro2 = textEntity.ChordPro.Value;
		if (chordPro2 == null)
		{
			chordPro2 = entityFactory.Create<IGraphics.Types.IText.Types.IChordPro>();
			textEntity.ChordPro.Set(chordPro2);
		}
		chordPro2.Enabled.Set(chordPro.Enabled);
		chordPro2.Notation.Set(chordPro.Notation.ToEntityChordProNotationType());
		chordPro2.Color.Set((chordPro.Color ?? Colors.Transparent).ToEntityColor());
	}

	public static TextDocument DeserializeEntity(ITextFillMediaFactory textFillMediaFactory, IGraphics.Types.IText entity, string containerId)
	{
		TextDocument textDocument = Encoding.UTF8.GetString(entity.RtfData?.Value ?? Array.Empty<byte>()).ToTextDocument();
		textDocument.SetIsDeserializing(value: true);
		textDocument.Settings.Alignment = entity.VerticalAlignment.Value.ToDocumentAlignment();
		textDocument.Settings.Transform = entity.Transform.Value.ToTextTransform();
		textDocument.Settings.TransformDelimiter = entity.TransformDelimiter.Value;
		textDocument.Settings.ScaleMode = entity.ScaleBehavior.Value.ToScaleMode();
		DeserializeShadow(textDocument.Settings.Shadow, entity.Shadow.Value);
		DeserializeChordPro(textDocument.Settings.ChordPro, entity);
		DeserializeCustomAttributes(textFillMediaFactory, textDocument, entity.Attributes.Value, containerId);
		DeserializeMargins(textDocument.Settings.Margins, entity.Margins.Value);
		DeserializeAttributes(textFillMediaFactory, textDocument.Attributes, entity.Attributes.Value, containerId);
		textDocument.SetIsDeserializing(value: false);
		return textDocument;
	}

	private static void DeserializeMargins(Margins margins, IGraphics.Types.IEdgeInsets entity)
	{
		margins.Left = entity.Left.Value;
		margins.Top = entity.Top.Value;
		margins.Right = entity.Right.Value;
		margins.Bottom = entity.Bottom.Value;
	}

	private static void DeserializeShadow(Shadow shadow, IGraphics.Types.IShadow entity)
	{
		shadow.Angle = new Angle<double>(entity.Angle.Value);
		shadow.Offset = entity.Offset.Value;
		shadow.BlurRadius = entity.Radius.Value;
		shadow.Color = entity.Color.ToColor();
		shadow.Opacity = entity.Opacity.Value;
		shadow.IsEnabled = entity.Enable.Value;
	}

	private static void DeserializeAttributes(ITextFillMediaFactory textFillMediaFactory, TextDocumentAttributes attributes, IGraphics.Types.IText.Types.IAttributes? entityAttributes, string containerId)
	{
		if (entityAttributes != null)
		{
			DesrializeAttributesToParagraphSettings(attributes.ParagraphSettings, entityAttributes);
			DeserializeRunSettingsToAttributes(textFillMediaFactory, attributes.RunSettings, entityAttributes, containerId);
		}
	}

	private static void DeserializeCustomAttributes(ITextFillMediaFactory textFillMediaFactory, TextDocument textDocument, IGraphics.Types.IText.Types.IAttributes? entityAttributes, string containerId)
	{
		if (entityAttributes == null)
		{
			return;
		}
		foreach (IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute item in entityAttributes.CustomAttributes.Items)
		{
			IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute customAttribute = item;
			IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute value = customAttribute.Attribute.Value;
			IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.ICapitalization capitalization = value as IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.ICapitalization;
			if (capitalization == null)
			{
				IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.IOriginalFontSize originalFontSize = value as IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.IOriginalFontSize;
				if (originalFontSize == null)
				{
					IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.ITextGradientFill textGradientFill = value as IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.ITextGradientFill;
					if (textGradientFill == null)
					{
						IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.IMediaFill mediaFill = value as IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.IMediaFill;
						if (mediaFill == null)
						{
							IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.ICutOutFill cutOutFill = value as IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.ICutOutFill;
							if (cutOutFill == null)
							{
								IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.IBackgroundEffect backgroundEffect = value as IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.IBackgroundEffect;
								if (backgroundEffect == null)
								{
									IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.IChord chord = value as IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.IChord;
									if (chord == null)
									{
										IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.IShouldPreserveForegroundColor shouldPreserveForegroundColor = value as IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.IShouldPreserveForegroundColor;
										if (shouldPreserveForegroundColor != null)
										{
											iterateRunsWithAllAttributes(delegate(RunBase r)
											{
												r.Settings.PreserveFillColor = shouldPreserveForegroundColor.Value;
											});
										}
									}
									else
									{
										iterateRunsWithAllAttributes(delegate(RunBase r)
										{
											r.Settings.ChordAnnotation = chord.Value;
										});
									}
									continue;
								}
								IGraphics.Types.IBackgroundEffect.Types.IEffectType value2 = backgroundEffect.Value.EffectType.Value;
								IGraphics.Types.IBackgroundEffect.Types.IEffectType.IBackgroundBlur backgroundBlur = value2 as IGraphics.Types.IBackgroundEffect.Types.IEffectType.IBackgroundBlur;
								if (backgroundBlur == null)
								{
									if (value2 is IGraphics.Types.IBackgroundEffect.Types.IEffectType.IBackgroundInvert)
									{
										iterateRunsWithAllAttributes(delegate(RunBase r)
										{
											SetFill(r.Settings, new BackgroundInvertTextFill(), backgroundEffect);
										});
									}
									else
									{
										iterateRunsWithAllAttributes(delegate(RunBase r)
										{
											r.Settings.Fill = new SolidTextFill();
										});
									}
								}
								else
								{
									iterateRunsWithAllAttributes(delegate(RunBase r)
									{
										SetFill(r.Settings, new BackgroundBlurTextFill(backgroundBlur.Value.Saturation.Value, backgroundBlur.Value.BlurAmount.Value), backgroundEffect);
									});
								}
							}
							else
							{
								iterateRunsWithAllAttributes(delegate(RunBase r)
								{
									SetFill(r.Settings, new CutOutTextFill(), cutOutFill);
								});
							}
						}
						else
						{
							IMedia.Types.ITypeProperties value3 = mediaFill.Value.Media.Value.TypeProperties.Value;
							ITextFillMedia textFillMedia = ((value3 is IMedia.Types.ITypeProperties.IImage) ? textFillMediaFactory.CreateImageMedia(containerId) : ((!(value3 is IMedia.Types.ITypeProperties.IVideo)) ? textFillMediaFactory.CreateImageMedia(containerId) : textFillMediaFactory.CreateVideoMedia(containerId)));
							ITextFillMedia media = textFillMedia;
							iterateRunsWithAllAttributes(delegate(RunBase r)
							{
								SetFill(r.Settings, new MediaTextFill(media), mediaFill);
							});
						}
					}
					else
					{
						iterateRunsWithAllAttributes(delegate(RunBase r)
						{
							System.Windows.Media.Color startColor = textGradientFill.Value.Gradient.Value.Stops.Items.ElementAtOrDefault(0)?.Color.Value.ToColor() ?? Colors.Transparent;
							System.Windows.Media.Color endColor = textGradientFill.Value.Gradient.Value.Stops.Items.ElementAtOrDefault(1)?.Color.Value.ToColor() ?? Colors.Transparent;
							Angle<double> angle = new Angle<double>(textGradientFill.Value.Gradient.Value.Angle.Value);
							GradientTextFill fill = new GradientTextFill(startColor, endColor, angle, textGradientFill.Value.StretchToDocumentBounds.Value);
							SetFill(r.Settings, fill, textGradientFill);
						});
					}
				}
				else
				{
					iterateRunsWithAllAttributes(delegate(RunBase r)
					{
						r.Settings.CharacterSize = (int)originalFontSize.Value;
					});
				}
			}
			else
			{
				iterateRunsWithAllAttributes(delegate(RunBase r)
				{
					r.Settings.CapitalizationType = capitalization.Value.ToCapitalizationType();
				});
			}
			void iterateRunsWithAllAttributes(Action<RunBase> iterator)
			{
				if (customAttribute.Range.Value.End < 0)
				{
					IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute value4 = customAttribute.Attribute.Value;
					if (!(value4 is IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.ICapitalization capitalization2))
					{
						if (!(value4 is IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.ITextGradientFill textGradientFill2))
						{
							if (!(value4 is IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.IMediaFill mediaFill2))
							{
								if (!(value4 is IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.ICutOutFill attribute))
								{
									if (value4 is IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.IBackgroundEffect backgroundEffect2)
									{
										IGraphics.Types.IBackgroundEffect.Types.IEffectType value5 = backgroundEffect2.Value.EffectType.Value;
										TextFillBase textFillBase = ((value5 is IGraphics.Types.IBackgroundEffect.Types.IEffectType.IBackgroundBlur backgroundBlur2) ? new BackgroundBlurTextFill(backgroundBlur2.Value.Saturation.Value, backgroundBlur2.Value.BlurAmount.Value) : ((!(value5 is IGraphics.Types.IBackgroundEffect.Types.IEffectType.IBackgroundInvert)) ? ((TextFillBase)new SolidTextFill()) : ((TextFillBase)new BackgroundInvertTextFill())));
										TextFillBase fill2 = textFillBase;
										SetFill(textDocument.Attributes.RunSettings, fill2, backgroundEffect2);
									}
								}
								else
								{
									SetFill(textDocument.Attributes.RunSettings, new CutOutTextFill(), attribute);
								}
							}
							else
							{
								IMedia.Types.ITypeProperties value6 = mediaFill2.Value.Media.Value.TypeProperties.Value;
								ITextFillMedia textFillMedia2 = ((value6 is IMedia.Types.ITypeProperties.IImage) ? textFillMediaFactory.CreateImageMedia(containerId) : ((!(value6 is IMedia.Types.ITypeProperties.IVideo)) ? textFillMediaFactory.CreateImageMedia(containerId) : textFillMediaFactory.CreateVideoMedia(containerId)));
								ITextFillMedia media2 = textFillMedia2;
								SetFill(textDocument.Attributes.RunSettings, new MediaTextFill(media2), mediaFill2);
							}
						}
						else
						{
							System.Windows.Media.Color startColor2 = textGradientFill2.Value.Gradient.Value.Stops.Items.ElementAtOrDefault(0)?.Color.Value.ToColor() ?? Colors.Transparent;
							System.Windows.Media.Color endColor2 = textGradientFill2.Value.Gradient.Value.Stops.Items.ElementAtOrDefault(1)?.Color.Value.ToColor() ?? Colors.Transparent;
							Angle<double> angle2 = new Angle<double>(textGradientFill2.Value.Gradient.Value.Angle.Value);
							GradientTextFill fill3 = new GradientTextFill(startColor2, endColor2, angle2, textGradientFill2.Value.StretchToDocumentBounds.Value);
							SetFill(textDocument.Attributes.RunSettings, fill3, textGradientFill2);
						}
					}
					else
					{
						textDocument.Attributes.RunSettings.CapitalizationType = capitalization2.Value.ToCapitalizationType();
					}
				}
				else
				{
					textDocument.IterateRuns(new Range(customAttribute.Range.Value.Start, customAttribute.Range.Value.End), splitRuns: true, iterator);
				}
			}
		}
	}

	private static void DeserializeChordPro(ChordPro chordPro, IGraphics.Types.IText entity)
	{
		if (entity.ChordPro.Value != null)
		{
			chordPro.Enabled = entity.ChordPro.Value.Enabled.Value;
			chordPro.Notation = entity.ChordPro.Value.Notation.Value.ToChordProNotationType();
			chordPro.Color = entity.ChordPro.Value.Color.Value.ToColor();
		}
	}

	private static void DesrializeAttributesToParagraphSettings(ParagraphSettings paragraphSettings, IGraphics.Types.IText.Types.IAttributes entityAtrributes)
	{
		IGraphics.Types.IText.Types.IAttributes.Types.IParagraph value = entityAtrributes.ParagraphStyle.Value;
		if (value != null)
		{
			paragraphSettings.Alignment = value.Alignment.Value.ToParagraphAlignment();
			paragraphSettings.FirstLineIndent = value.FirstLineHeadIndent.Value;
			paragraphSettings.LeftIndent = value.HeadIndent.Value;
			paragraphSettings.SpacingMode = LineSpacingMode.Multiple;
			paragraphSettings.AdditionalLineSpacing = value.LineSpacing.Value;
			paragraphSettings.AfterParagraph = value.ParagraphSpacing.Value;
			paragraphSettings.BeforeParagraph = value.ParagraphSpacingBefore.Value;
			paragraphSettings.RightIndent = value.TailIndent.Value;
		}
	}

	private static void DeserializeRunSettingsToAttributes(ITextFillMediaFactory textFillMediaFactory, RunSettings runSettings, IGraphics.Types.IText.Types.IAttributes entityAttributes, string containerId)
	{
		runSettings.Underline = entityAttributes.UnderlineStyle.Value != null;
		runSettings.Strikethrough = entityAttributes.StrikethroughStyle.Value != null;
		runSettings.CapitalizationType = entityAttributes.Capitalization.Value.ToCapitalizationType();
		runSettings.ScriptLevel = entityAttributes.Superscript.Value;
		runSettings.LigaturesEnabled = entityAttributes.LigatureStyle.Value == IGraphics.Types.IText.Types.IAttributes.Types.LigatureStyle.Default;
		if ((object)entityAttributes.Font.Value != null)
		{
			runSettings.Font = ToFont(entityAttributes.Font.Value);
			runSettings.CharacterSize = (int)entityAttributes.Font.Value.Size;
		}
		DeserializeRunFill(textFillMediaFactory, runSettings, entityAttributes, containerId);
		runSettings.CharacterSpacing = entityAttributes.Kerning.Value;
		runSettings.StrokeColor = entityAttributes.StrokeColor.Value.ToColor();
		runSettings.StrokeThickness = entityAttributes.StrokeWidth.Value;
		runSettings.HighlightColor = entityAttributes.BackgroundColor.Value.ToColor();
	}

	private static void DeserializeRunFill(ITextFillMediaFactory textFillMediaFactory, RunSettings runSettings, IGraphics.Types.IText.Types.IAttributes entityAttributes, string containerId)
	{
		TextFillBase textFillBase = null;
		if (entityAttributes.Fill.Value is IGraphics.Types.IText.Types.IAttributes.Types.IFill.ITextSolidFill textSolidFill)
		{
			textFillBase = new SolidTextFill(textSolidFill.Value.ToColor());
		}
		else if (entityAttributes.Fill.Value is IGraphics.Types.IText.Types.IAttributes.Types.IFill.ITextGradientFill textGradientFill)
		{
			System.Windows.Media.Color startColor = textGradientFill.Value.Gradient.Value.Stops.Items.ElementAtOrDefault(0)?.Color.Value.ToColor() ?? Colors.Transparent;
			System.Windows.Media.Color endColor = textGradientFill.Value.Gradient.Value.Stops.Items.ElementAtOrDefault(1)?.Color.Value.ToColor() ?? Colors.Transparent;
			Angle<double> angle = new Angle<double>(textGradientFill.Value.Gradient.Value.Angle.Value);
			textFillBase = new GradientTextFill(startColor, endColor, angle, textGradientFill.Value.StretchToDocumentBounds.Value);
		}
		else if (entityAttributes.Fill.Value is IGraphics.Types.IText.Types.IAttributes.Types.IFill.IMediaFill mediaFill)
		{
			IMedia.Types.ITypeProperties value = mediaFill.Value.Media.Value.TypeProperties.Value;
			ITextFillMedia media = ((value is IMedia.Types.ITypeProperties.IImage) ? textFillMediaFactory.CreateImageMedia(containerId) : ((!(value is IMedia.Types.ITypeProperties.IVideo)) ? textFillMediaFactory.CreateImageMedia(containerId) : textFillMediaFactory.CreateVideoMedia(containerId)));
			textFillBase = new MediaTextFill(media);
		}
		else if (entityAttributes.Fill.Value is IGraphics.Types.IText.Types.IAttributes.Types.IFill.ICutOutFill)
		{
			textFillBase = new CutOutTextFill();
		}
		else if (entityAttributes.Fill.Value is IGraphics.Types.IText.Types.IAttributes.Types.IFill.IBackgroundEffect backgroundEffect)
		{
			if (backgroundEffect.Value.EffectType.Value is IGraphics.Types.IBackgroundEffect.Types.IEffectType.IBackgroundBlur)
			{
				textFillBase = new BackgroundBlurTextFill();
			}
			else if (backgroundEffect.Value.EffectType.Value is IGraphics.Types.IBackgroundEffect.Types.IEffectType.IBackgroundInvert)
			{
				textFillBase = new BackgroundInvertTextFill();
			}
		}
		runSettings.Fill = textFillBase ?? new SolidTextFill();
		runSettings.Fill.DeserializeEntity(entityAttributes.Fill.Value);
	}

	private static void SetFill(RunSettings runSettings, TextFillBase fill, IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute attribute)
	{
		runSettings.Fill = fill;
		fill.DeserializeEntity(attribute);
	}

	private static bool IsCustomAttributeFill(TextFillBase fill)
	{
		return fill.TextFillType.IsAnyOf(TextFillType.Gradient, TextFillType.Media, TextFillType.CutOut, TextFillType.BackgroundBlur, TextFillType.BackgroundInvert);
	}

	private static Pro.Entity.Font ToFont(RunSettings runSettings)
	{
		FontInfo font = runSettings.Font;
		return new Pro.Entity.Font(font.PSName ?? font.FullName ?? string.Empty, runSettings.CharacterSize, font.IsItalic, font.IsBold, font.SystemFamilyName ?? string.Empty, font.SystemFaceName ?? string.Empty);
	}

	private static FontInfo ToFont(Pro.Entity.Font entityFont)
	{
		FontInfo fontInfo = new FontInfo(entityFont.Family ?? string.Empty, entityFont.Face, entityFont.Name, entityFont.Bold ? FontWeights.Bold : FontWeights.Regular, FontStretches.Normal, entityFont.Italic);
		bool isFallbackFont;
		Font font = SharedTypefaceLibrary.Library.FindFont(fontInfo, out isFallbackFont);
		if (!isFallbackFont)
		{
			return font.Info;
		}
		return fontInfo;
	}

	public TextDocument()
		: this(insertDefaultParagraph: true)
	{
	}

	private TextDocument(bool insertDefaultParagraph, TextDocumentSettings? settings = null, ListSettingsCollection? listSettingsCollection = null, TextDocumentAttributes? attributes = null)
	{
		Attributes = attributes ?? new TextDocumentAttributes(UndoStack);
		Settings = settings ?? new TextDocumentSettings();
		ListSettingsCollection = listSettingsCollection ?? new ListSettingsCollection();
		_paragraphs.CollectionChanged += delegate(object? s, NotifyCollectionChangedEventArgs e)
		{
			e.OldItems?.OfType<Paragraph>().ForEach(delegate(Paragraph p)
			{
				p.ParagraphChanged -= OnParagraphChanged;
			});
			e.NewItems?.OfType<Paragraph>().ForEach(delegate(Paragraph p)
			{
				p.ParagraphChanged += OnParagraphChanged;
			});
			OnDocumentChanged(hasActualChanges: true);
		};
		if (insertDefaultParagraph)
		{
			InsertParagraph(0);
		}
	}

	public override int GetHashCode()
	{
		if (!_hashCode.HasValue)
		{
			_hashCode = HashCodeHelper.GenerateHashCode(new IEnumerable[2] { _paragraphs, ListSettingsCollection }, Settings);
		}
		return _hashCode.Value;
	}

	public override bool Equals(object? obj)
	{
		if (obj is TextDocument other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(TextDocument? other)
	{
		if ((object)other != null && _paragraphs.Count == other._paragraphs.Count && Settings == other.Settings && _paragraphs.ContentsMatchExactly(other._paragraphs))
		{
			return ListSettingsCollection.ContentsMatchExactly(other.ListSettingsCollection);
		}
		return false;
	}

	public IEnumerator<Paragraph> GetEnumerator()
	{
		return _paragraphs.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public void Clear()
	{
		_paragraphs[0].Clear();
		_paragraphs.RemoveAtRange(1, _paragraphs.Count - 1);
	}

	public RunSettings? GetActiveRunSettings(int characterIndex, Range[] ranges)
	{
		return GetActiveRunSettings(characterIndex, !ranges.ContainsSelection());
	}

	public RunSettings? GetActiveRunSettings(int characterIndex, bool lookBehind = true)
	{
		return FindRun(FindParagraph(ref characterIndex), ref characterIndex, lookBehind)?.Settings;
	}

	public Paragraph AddParagraph(ParagraphSettings? paragraphSettings = null, RunSettings? runSettings = null)
	{
		StartChange();
		paragraphSettings = (((object)paragraphSettings != null) ? paragraphSettings.Clone() : new ParagraphSettings());
		runSettings = (((object)runSettings != null) ? runSettings.Clone() : new RunSettings());
		Paragraph paragraph = new Paragraph(paragraphSettings);
		paragraph.AddRun(new TextRun(string.Empty, runSettings));
		AddParagraph(paragraph);
		FinishChange();
		return paragraph;
	}

	public int InsertParagraph(int characterIndex, ParagraphSettings? paragraphSettings = null)
	{
		StartChange();
		int num = characterIndex;
		Paragraph paragraph = FindParagraph(ref characterIndex);
		if ((object)paragraph != null)
		{
			Paragraph paragraph2 = SplitParagraph(paragraph, Math.Min(characterIndex, paragraph.TextLength), paragraphSettings?.Clone() ?? paragraph.Settings.Clone());
			if (paragraph2 != null)
			{
				num++;
				InsertParagraph(GetParagraphIndex(paragraph) + 1, paragraph2);
			}
		}
		else
		{
			Paragraph paragraph3 = new Paragraph(paragraphSettings?.Clone() ?? new ParagraphSettings());
			TextRun run = new TextRun(string.Empty, new RunSettings());
			paragraph3.AddRun(run);
			AddParagraph(paragraph3);
		}
		FinishChange();
		return num;
	}

	public int InsertTextAndParagraphs(int characterIndex, string text, RunSettings? settings = null)
	{
		UndoStack?.BeginCommit(UndoActionTypes.Text.ToAction());
		StartChange();
		int num = characterIndex;
		string[] array = text.Split(LineBreaks.All, StringSplitOptions.None).ToArray();
		for (int i = 0; i < array.Length; i++)
		{
			num = InsertTextAndTabs(num, array[i], settings);
			if (i + 1 < array.Length)
			{
				num = InsertParagraph(num);
			}
		}
		FinishChange();
		UndoStack?.EndCommit();
		return num;
	}

	public int InsertTextAndTabs(int characterIndex, string text, RunSettings? settings = null)
	{
		StartChange();
		int num = characterIndex;
		string[] array = text.Split(new char[1] { '\t' }, StringSplitOptions.None).ToArray();
		for (int i = 0; i < array.Length; i++)
		{
			num = InsertText(num, array[i], settings);
			if (i + 1 < array.Length)
			{
				num = InsertTabs(num, 1, settings);
			}
		}
		FinishChange();
		return num;
	}

	public int InsertText(int characterIndex, string text, RunSettings? settings = null)
	{
		return InsertRun(characterIndex, (RunSettings newSettings) => new TextRun(text, newSettings), settings);
	}

	public int InsertTabs(int characterIndex, int tabCount, RunSettings? settings = null)
	{
		return InsertRun(characterIndex, (RunSettings newSettings) => new TabRun(tabCount, newSettings), settings);
	}

	public int InsertDocument(int characterIndex, TextDocument other)
	{
		if (!other.HasText)
		{
			return characterIndex;
		}
		UndoStack?.BeginCommit(UndoActionTypes.Text.ToAction());
		StartChange();
		int num = characterIndex;
		int characterIndex2 = characterIndex;
		Paragraph paragraph = FindParagraph(ref characterIndex2);
		bool flag = (object)paragraph != null && (!string.IsNullOrEmpty(paragraph.AllText) || !string.IsNullOrWhiteSpace(paragraph.AllText));
		for (int i = 0; i < other._paragraphs.Count; i++)
		{
			Paragraph paragraph2 = other._paragraphs[i];
			ParagraphSettings paragraphSettings = paragraph2.Settings.Clone();
			int listIndex = paragraphSettings.ListIndex;
			if (listIndex >= 0 && other.ListSettingsCollection.Count > 0 && listIndex < other.ListSettingsCollection.Count)
			{
				ListSettings listSettings = other.ListSettingsCollection[listIndex];
				if (ListSettingsCollection.Contains(listSettings))
				{
					paragraphSettings.ListIndex = ListSettingsCollection.IndexOf(listSettings);
				}
				else
				{
					ListSettingsCollection.AddList(listSettings.Clone(), out var settingsIndex);
					paragraphSettings.ListIndex = settingsIndex;
				}
			}
			if (i == 0 && (object)paragraph != null)
			{
				if (!flag)
				{
					paragraph.AssignSettings(paragraphSettings);
				}
				else if (flag && paragraphSettings.IsPartOfList)
				{
					num = InsertParagraph(num, paragraphSettings);
				}
				foreach (RunBase run in paragraph2)
				{
					num = InsertRun(num, (RunSettings _) => run, run.Settings);
				}
				if (i + 1 < other.ParagraphCount)
				{
					num = InsertParagraph(num);
				}
				continue;
			}
			int characterIndex3 = num;
			FindParagraph(ref characterIndex3).AssignSettings(paragraphSettings);
			foreach (RunBase run2 in paragraph2)
			{
				num = InsertRun(num, (RunSettings _) => run2, run2.Settings);
			}
			if (i + 1 < other.ParagraphCount)
			{
				num = InsertParagraph(num);
			}
		}
		FinishChange();
		UndoStack?.EndCommit();
		return num;
	}

	public void IndentList(Range[] ranges, bool increase)
	{
		if (!ranges.IsEmpty())
		{
			StartChange();
			ranges.ForEach(delegate(Range r)
			{
				IndentList(r, increase);
			});
			FinishChange();
		}
	}

	public void IndentList(Range range, bool increase)
	{
		StartChange();
		IterateParagraphs(range, delegate(Paragraph paragraph)
		{
			ParagraphSettings settings = paragraph.Settings;
			if ((object)settings != null && settings.IsPartOfList && (increase || (!increase && settings.LevelIndex > 0)))
			{
				if (increase)
				{
					settings.LevelIndex++;
					settings.TabStops.AddStopAtNextDefaultPosition();
				}
				else
				{
					settings.LevelIndex--;
				}
				TabStopCollection tabStops = settings.TabStops;
				double num = settings.LeftIndent + settings.FirstLineIndent;
				TabStopType type;
				double num2 = (increase ? tabStops.FindNextStopPosition(num, out type) : tabStops.FindPreviousStopPosition(num, out type)) - num;
				settings.LeftIndent += num2;
			}
		});
		FinishChange();
	}

	public void RemoveList(int characterIndex)
	{
		if (IsPartOfList(characterIndex))
		{
			StartChange();
			ParagraphSettings paragraphSettings = FindParagraph(ref characterIndex)?.Settings;
			if (paragraphSettings != null)
			{
				paragraphSettings.LevelIndex = -1;
				paragraphSettings.ListIndex = -1;
			}
			FinishChange();
		}
	}

	public void RemoveCharacter(int characterIndex)
	{
		UndoStack?.BeginCommit(UndoActionTypes.Text.ToAction());
		StartChange();
		int characterIndex2 = characterIndex;
		Paragraph paragraph = FindParagraph(ref characterIndex2);
		if ((object)paragraph == null)
		{
			return;
		}
		int characterIndex3 = characterIndex2;
		RunBase runBase = FindRun(paragraph, ref characterIndex3, lookBehind: false);
		if ((object)runBase != null)
		{
			runBase.RemoveCharacter(characterIndex3);
		}
		else
		{
			int characterIndex4 = characterIndex + 1;
			Paragraph paragraph2 = FindParagraph(ref characterIndex4);
			if ((object)paragraph2 != null)
			{
				paragraph2.ForEach(paragraph.AddRun);
				RemoveParagraph(GetParagraphIndex(paragraph2));
			}
		}
		CompactRuns();
		FinishChange();
		UndoStack?.EndCommit();
	}

	public int RemoveCharacters(Range range)
	{
		return RemoveCharacters(range.MakeArray());
	}

	public int RemoveCharacters(Range[] ranges)
	{
		UndoStack?.BeginCommit(UndoActionTypes.Text.ToAction());
		StartChange();
		foreach (Range item in ranges.Compact().Sort().Reverse())
		{
			Range range = ((item == Range.All) ? EntireRange : item);
			for (int i = range.Start; i < range.End; i++)
			{
				RemoveCharacter(range.Start);
			}
		}
		FinishChange();
		UndoStack?.EndCommit(null, null, autoFinalize: true);
		return ranges.FirstIndex();
	}

	public void ResetLeftIndenting(int characterIndex)
	{
		StartChange();
		ParagraphSettings paragraphSettings = FindParagraph(ref characterIndex)?.Settings;
		if (paragraphSettings != null)
		{
			paragraphSettings.LeftIndent = 0.0;
			paragraphSettings.FirstLineIndent = 0.0;
		}
		FinishChange();
	}

	public string GetText(Range range)
	{
		ClampRange(range, out var start, out var end);
		string text = string.Empty;
		int characterIndex = start;
		FindParagraph(ref characterIndex);
		int num = start;
		while (num < end)
		{
			int characterIndex2 = num;
			Paragraph paragraph = FindParagraph(ref characterIndex2);
			if (paragraph != null)
			{
				int textLength = paragraph.TextLength;
				if (characterIndex2 == textLength)
				{
					text += "\n";
					num++;
				}
				else
				{
					int num2 = Math.Min(end - num, textLength - characterIndex2);
					text += paragraph.AllText.Substring(characterIndex2, num2);
					num += num2;
				}
			}
		}
		return text;
	}

	public Range FindWord(int characterIndex)
	{
		characterIndex = characterIndex.Clamp(0, LastCharacterIndex - 1);
		string allText = AllText;
		if (characterIndex < 0 || string.IsNullOrEmpty(allText))
		{
			return Range.Empty;
		}
		Predicate<char> predicate = ((!char.IsWhiteSpace(allText[characterIndex])) ? new Predicate<char>(char.IsWhiteSpace) : ((Predicate<char>)((char c) => !char.IsWhiteSpace(c))));
		int num = allText.FindLastIndex(predicate, characterIndex);
		int num2 = allText.FindIndex(predicate, characterIndex);
		return new Range((num != -1) ? (num + 1) : 0, (num2 == -1) ? LastCharacterIndex : num2);
	}

	public int FindWordEnd(int characterIndex)
	{
		characterIndex = characterIndex.Clamp(0, LastCharacterIndex - 1);
		if (characterIndex < 0)
		{
			return 0;
		}
		if (characterIndex == LastCharacterIndex - 1)
		{
			return LastCharacterIndex;
		}
		string text = AllText;
		char c2 = text[characterIndex];
		char c3 = text[characterIndex + 1];
		if (!char.IsWhiteSpace(c2) && !char.IsWhiteSpace(c3))
		{
			return validIndex(findNextWhiteSpace(characterIndex));
		}
		characterIndex = findNextText(characterIndex);
		return validIndex(findNextWhiteSpace(characterIndex));
		int findNextText(int index)
		{
			return text.FindIndex((char c) => !char.IsWhiteSpace(c), index);
		}
		int findNextWhiteSpace(int index)
		{
			return text.FindIndex(char.IsWhiteSpace, index);
		}
		int validIndex(int index)
		{
			if (index >= 0)
			{
				return index;
			}
			return LastCharacterIndex;
		}
	}

	public int FindWordStart(int characterIndex)
	{
		characterIndex = characterIndex.Clamp(0, LastCharacterIndex - 1);
		if (characterIndex <= 0)
		{
			return 0;
		}
		string text = AllText;
		char c2 = text[characterIndex];
		if (!char.IsWhiteSpace(text[characterIndex - 1]) && !char.IsWhiteSpace(c2))
		{
			return Math.Max(0, findPrecedingWhiteSpace(characterIndex) + 1);
		}
		characterIndex = findPrecedingText(characterIndex - 1);
		return Math.Max(0, findPrecedingWhiteSpace(characterIndex) + 1);
		int findPrecedingText(int index)
		{
			return text.FindLastIndex((char c) => !char.IsWhiteSpace(c), index);
		}
		int findPrecedingWhiteSpace(int index)
		{
			return text.FindLastIndex(char.IsWhiteSpace, index);
		}
	}

	public bool IsParagraphStart(int characterIndex)
	{
		if (characterIndex >= 0 && FindParagraph(ref characterIndex) != null)
		{
			return characterIndex == 0;
		}
		return false;
	}

	public bool IsPartOfList(int characterIndex)
	{
		if (characterIndex < 0)
		{
			return false;
		}
		return FindParagraph(ref characterIndex)?.Settings?.IsPartOfList == true;
	}

	public bool IsParagraphLeftIndented(int characterIndex)
	{
		if (characterIndex < 0)
		{
			return false;
		}
		ParagraphSettings paragraphSettings = FindParagraph(ref characterIndex)?.Settings;
		if (paragraphSettings != null)
		{
			if (paragraphSettings.LeftIndent == 0.0)
			{
				return paragraphSettings.FirstLineIndent != 0.0;
			}
			return true;
		}
		return false;
	}

	public bool IsParagraphEmpty(int characterIndex)
	{
		if (characterIndex < 0)
		{
			return true;
		}
		Paragraph paragraph = FindParagraph(ref characterIndex);
		if (!(paragraph == null))
		{
			return paragraph.TextLength == 0;
		}
		return true;
	}

	public void Trim()
	{
		StartChange();
		TrimLeft();
		TrimRight();
		FinishChange();
	}

	public int TrimLeft()
	{
		StartChange();
		int num = 0;
		bool flag = false;
		foreach (Paragraph paragraph in _paragraphs)
		{
			foreach (RunBase item in paragraph)
			{
				string plainText = item.PlainText;
				for (int i = 0; i < plainText.Length; i++)
				{
					if (flag)
					{
						break;
					}
					if (char.IsWhiteSpace(plainText[i]))
					{
						num++;
					}
					else
					{
						flag = true;
					}
				}
				if (flag)
				{
					break;
				}
			}
			if (flag)
			{
				break;
			}
			num++;
		}
		if (num > 0)
		{
			RemoveCharacters(new Range(0, num));
		}
		FinishChange();
		return num;
	}

	public int TrimRight()
	{
		StartChange();
		int num = 0;
		bool flag = false;
		foreach (Paragraph item in _paragraphs.Reverse())
		{
			foreach (RunBase item2 in item.Reverse())
			{
				string plainText = item2.PlainText;
				int num2 = plainText.Length - 1;
				while (num2 >= 0 && !flag)
				{
					if (char.IsWhiteSpace(plainText[num2]))
					{
						num++;
					}
					else
					{
						flag = true;
					}
					num2--;
				}
				if (flag)
				{
					break;
				}
			}
			if (flag)
			{
				break;
			}
			num++;
		}
		if (num > 0)
		{
			int start = LastCharacterIndex - num;
			RemoveCharacters(new Range(start, LastCharacterIndex));
		}
		FinishChange();
		return num;
	}

	public void IterateParagraphs(Range[]? ranges, Action<Paragraph> iterator)
	{
		if (ranges != null && !ranges.IsEmpty())
		{
			StartChange();
			ranges.ForEach(delegate(Range r)
			{
				IterateParagraphs(r, iterator);
			});
			FinishChange();
		}
	}

	public void IterateParagraphs(Range range, Action<Paragraph> iterator)
	{
		if (range == Range.All)
		{
			range = EntireRange;
		}
		StartChange();
		int characterIndex;
		Paragraph paragraph;
		for (int i = range.Start; i <= range.End; i += 1 + paragraph.TextLength - characterIndex)
		{
			characterIndex = i;
			paragraph = FindParagraph(ref characterIndex);
			if (paragraph == null)
			{
				break;
			}
			iterator(paragraph);
		}
		FinishChange();
	}

	public void IterateRuns(Range[]? ranges, bool splitRuns, Action<RunBase> iterator)
	{
		if (ranges != null && !ranges.IsEmpty())
		{
			StartChange();
			ranges.ForEach(delegate(Range r)
			{
				IterateRuns(r, splitRuns, iterator);
			});
			FinishChange();
		}
	}

	public void IterateRuns(Range range, bool splitRuns, Action<RunBase> iterator)
	{
		if (range == Range.All)
		{
			range = EntireRange;
		}
		else if (range.End < 0 || range.Start > LastCharacterIndex)
		{
			return;
		}
		StartChange();
		bool flag = range.Start == range.End;
		int num = range.Start;
		while (num <= range.End)
		{
			int characterIndex = num;
			Paragraph paragraph = FindParagraph(ref characterIndex);
			if (paragraph == null)
			{
				break;
			}
			int textLength = paragraph.TextLength;
			if (characterIndex == textLength && textLength > 0)
			{
				num++;
				continue;
			}
			int characterIndex2 = characterIndex;
			RunBase runBase = FindRun(paragraph, ref characterIndex2, paragraph.TextLength <= 0 || flag);
			if (runBase == null)
			{
				break;
			}
			num += runBase.Length - characterIndex2;
			if (flag || paragraph.TextLength == 0)
			{
				num++;
			}
			if (splitRuns && characterIndex2 > 0)
			{
				RunBase runBase2 = SplitRun(runBase, characterIndex2);
				if (runBase2 != null)
				{
					paragraph.InsertRun(runBase2, paragraph.GetRunIndex(runBase) + 1);
					runBase = runBase2;
				}
			}
			if (splitRuns && num >= range.End)
			{
				RunBase runBase3 = SplitRun(runBase, runBase.Length - (num - range.End));
				if ((object)runBase3 != null)
				{
					paragraph.InsertRun(runBase3, paragraph.GetRunIndex(runBase) + 1);
				}
			}
			iterator(runBase);
		}
		CompactRuns();
		FinishChange();
	}

	public void IterateAllParagraphs(Action<Range, Paragraph> iterator)
	{
		int num = 0;
		foreach (Paragraph paragraph in _paragraphs)
		{
			iterator(new Range(num, num + paragraph.TextLength), paragraph);
			num += paragraph.TextLength + 1;
		}
	}

	public void IterateAllRuns(Action<Range, RunBase> iterator)
	{
		int num = 0;
		foreach (Paragraph paragraph in _paragraphs)
		{
			foreach (RunBase item in paragraph)
			{
				iterator(new Range(num, num + item.Length), item);
				num += item.Length;
			}
			num++;
		}
	}

	public TextDocument SplitDocument(int index)
	{
		UndoStack?.BeginCommit(UndoActionTypes.Text.ToAction());
		StartChange();
		index = index.Clamp(0, LastCharacterIndex);
		TextDocument textDocument = new TextDocument(insertDefaultParagraph: false, Settings.Clone(), ListSettingsCollection.Clone(), Attributes.Clone());
		bool flag = index == 0 || index == LastCharacterIndex;
		if (!flag)
		{
			int characterIndex = index;
			Paragraph paragraph = FindParagraph(ref characterIndex);
			if (paragraph != null)
			{
				flag = characterIndex > 0 && characterIndex < paragraph.TextLength;
				if (!flag && characterIndex == paragraph.TextLength)
				{
					index++;
				}
			}
		}
		if (flag)
		{
			index = InsertParagraph(index);
		}
		int paragraphIndex = GetParagraphIndex(FindParagraph(ref index));
		while (paragraphIndex < _paragraphs.Count)
		{
			textDocument.AddParagraph(_paragraphs[paragraphIndex]);
			RemoveParagraph(paragraphIndex);
		}
		FinishChange();
		UndoStack?.EndCommit(null, null, autoFinalize: true);
		return textDocument;
	}

	public TextDocument Subset(Range range)
	{
		return Subset(range.MakeArray());
	}

	public TextDocument Subset(Range[] ranges)
	{
		TextDocument textDocument = new TextDocument(insertDefaultParagraph: false, Settings.Clone(), ListSettingsCollection.Clone(), Attributes.Clone());
		Paragraph paragraph = null;
		foreach (Range range in ranges)
		{
			ClampRange(range, out var start, out var end);
			int num = start;
			bool flag = false;
			while (num < end)
			{
				int characterIndex = num;
				Paragraph paragraph2 = FindParagraph(ref characterIndex);
				if (paragraph2 == null)
				{
					break;
				}
				if (flag || (object)paragraph == null)
				{
					paragraph = textDocument.AddParagraph(paragraph2.Settings);
				}
				if (characterIndex == 0 && num + paragraph2.TextLength <= end)
				{
					paragraph2.CloneItems().ForEach(paragraph.AddRun);
					num += paragraph2.TextLength + 1;
				}
				else
				{
					int characterIndex2 = characterIndex;
					RunBase runBase = FindRun(paragraph2, ref characterIndex2)?.Clone();
					while (runBase != null && num < end)
					{
						if (characterIndex2 != 0)
						{
							runBase = runBase.Split(characterIndex2);
						}
						if (runBase.Length > end - num)
						{
							runBase.Split(end - num);
						}
						paragraph.AddRun(runBase);
						num += runBase.Length;
						characterIndex += runBase.Length;
						characterIndex2 = characterIndex;
						runBase = FindRun(paragraph2, ref characterIndex2, lookBehind: false)?.Clone();
					}
					num++;
				}
				flag = true;
			}
		}
		return textDocument;
	}

	private void ClampRange(Range range, out int start, out int end)
	{
		if (range == Range.All)
		{
			range = EntireRange;
		}
		start = Math.Max(range.Start, 0);
		end = Math.Min(range.End, LastCharacterIndex);
	}

	public void MergeDocument(TextDocument? other, bool prepend = false)
	{
		if ((object)other != null && !other.Any())
		{
			return;
		}
		UndoStack?.BeginCommit(UndoActionTypes.Text.ToAction());
		StartChange();
		int index = 0;
		if (other != null)
		{
			other.ForEach(delegate(Paragraph p)
			{
				InsertParagraph(prepend ? index++ : _paragraphs.Count, p);
			});
		}
		FinishChange();
		UndoStack?.EndCommit(null, null, autoFinalize: true);
	}

	public TextDocument Clone()
	{
		TextDocument textDocument = new TextDocument(insertDefaultParagraph: false, Settings.Clone(), ListSettingsCollection.Clone(), Attributes.Clone());
		textDocument.StartChange();
		using (IEnumerator<Paragraph> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				Paragraph current = enumerator.Current;
				Paragraph paragraph = new Paragraph(current.Settings.Clone());
				foreach (RunBase item in current)
				{
					paragraph.AddRun(item.Clone());
				}
				textDocument.AddParagraph(paragraph);
			}
		}
		textDocument.FinishChange();
		return textDocument;
	}

	public TextDocument CloneAsEmpty()
	{
		TextDocument textDocument = new TextDocument(insertDefaultParagraph: false, Settings.Clone(), ListSettingsCollection.Clone(), Attributes?.Clone());
		Paragraph paragraph = _paragraphs.First();
		RunBase runBase = paragraph.First();
		Paragraph paragraph2 = new Paragraph(paragraph.Settings.Clone() ?? new ParagraphSettings());
		TextRun run = new TextRun(string.Empty, runBase.Settings.Clone() ?? new RunSettings());
		paragraph2.AddRun(run);
		textDocument.AddParagraph(paragraph2);
		return textDocument;
	}

	public void CompactRuns()
	{
		StartChange();
		foreach (Paragraph paragraph in _paragraphs)
		{
			for (int num = paragraph.RunCount - 1; num >= 0; num--)
			{
				RunBase runBase = paragraph[num];
				RunBase runBase2 = ((num - 1 < 0) ? null : paragraph[num - 1]);
				if (runBase.IsEmpty)
				{
					if (paragraph.RunCount > 1)
					{
						paragraph.RemoveRun(runBase);
					}
				}
				else if ((object)runBase2 != null && runBase2.CanMerge(runBase) && runBase.Settings == runBase2.Settings)
				{
					runBase2.MergeFrom(runBase);
					paragraph.RemoveRun(runBase);
				}
			}
		}
		FinishChange();
	}

	public void AssignSettings(TextDocumentSettings settings, TextDocumentAttributes attributes)
	{
		Settings = settings.Clone();
		Attributes = attributes.Clone();
	}

	public void ForceToDefaultSettings()
	{
		if ((object)_attributes.ParagraphSettings != null)
		{
			foreach (TextDocumentAttributeHelper.PropertyAttributeMap paragraphSettingsPropertiesWithAttribute in TextDocumentAttributeHelper.ParagraphSettingsPropertiesWithAttributes)
			{
				object value = paragraphSettingsPropertiesWithAttribute.Property.GetValue(_attributes.ParagraphSettings);
				foreach (Paragraph item in _paragraphs.Where((Paragraph p) => (object)p.Settings != null))
				{
					SetParagrapSettingsAttributeValue(item.Settings, paragraphSettingsPropertiesWithAttribute.Property, value, paragraphSettingsPropertiesWithAttribute.Attribute);
				}
			}
		}
		if ((object)_attributes.RunSettings == null)
		{
			return;
		}
		foreach (TextDocumentAttributeHelper.PropertyAttributeMap pi in TextDocumentAttributeHelper.RunSettingsPropertiesWithAttributes)
		{
			object value2 = pi.Property.GetValue(_attributes.RunSettings);
			TextAttributeType? textAttributeType = pi.Attribute?.Type;
			if (textAttributeType.HasValue && textAttributeType == TextAttributeType.Fill)
			{
				_paragraphs.SelectMany((Paragraph p) => p).ForEach(delegate(RunBase r)
				{
					pi.Property.SetValue(r.Settings, ((TextFillBase)value2)?.Clone());
				});
			}
			else
			{
				_paragraphs.SelectMany((Paragraph p) => p).ForEach(delegate(RunBase r)
				{
					pi.Property.SetValue(r.Settings, value2);
				});
			}
		}
	}

	public void SetIsDeserializing(bool value)
	{
		IsDeserializing = value;
	}

	private void AddParagraph(Paragraph paragraph)
	{
		InsertParagraph(_paragraphs.Count, paragraph);
	}

	private void InsertParagraph(int index, Paragraph paragraph)
	{
		paragraph.UndoStack = UndoStack;
		_paragraphs.Insert(index, paragraph);
		UndoStack?.Commit(UndoActionTypes.Text.ToAction(), delegate
		{
			RemoveParagraph(index);
		}, delegate
		{
			InsertParagraph(index, paragraph);
		}, null, null, autoFinalize: true);
	}

	private void RemoveParagraph(int index)
	{
		Paragraph paragraph = _paragraphs[index];
		_paragraphs.RemoveAt(index);
		UndoStack?.Commit(UndoActionTypes.Text.ToAction(), delegate
		{
			InsertParagraph(index, paragraph);
		}, delegate
		{
			RemoveParagraph(index);
		}, null, null, autoFinalize: true);
	}

	private Paragraph? FindParagraph(ref int characterIndex)
	{
		if (characterIndex >= 0)
		{
			int num = 0;
			for (int i = 0; i < _paragraphs.Count; i++)
			{
				Paragraph paragraph = _paragraphs[i];
				num += paragraph.TextLength;
				if (num + i >= characterIndex && characterIndex >= 0)
				{
					characterIndex = paragraph.TextLength - (num + i - characterIndex);
					return paragraph;
				}
			}
		}
		return null;
	}

	private static RunBase? FindRun(Paragraph? paragraph, ref int characterIndex, bool lookBehind = true)
	{
		if ((object)paragraph != null && characterIndex >= 0)
		{
			int num = 0;
			for (int i = 0; i < paragraph.RunCount; i++)
			{
				RunBase runBase = paragraph[i];
				num += runBase.Length;
				if ((lookBehind && num >= characterIndex) || (!lookBehind && num > characterIndex))
				{
					characterIndex = runBase.Length - (num - characterIndex);
					return runBase;
				}
			}
		}
		return null;
	}

	private int InsertRun(int characterIndex, Func<RunSettings, RunBase> newRunGenerator, RunSettings? settings = null)
	{
		UndoStack?.BeginCommit(UndoActionTypes.Text.ToAction());
		StartChange();
		int characterIndex2 = characterIndex;
		Paragraph paragraph = FindParagraph(ref characterIndex2);
		int characterIndex3 = characterIndex2;
		RunBase runBase = FindRun(paragraph, ref characterIndex3);
		RunBase runBase2 = newRunGenerator((settings ?? ((runBase?.Settings != null) ? runBase.Settings : new RunSettings())).Clone());
		int num = (((object)runBase != null) ? (paragraph?.GetRunIndex(runBase) ?? 0) : 0);
		if ((object)runBase != null)
		{
			if (characterIndex3 > 0 && characterIndex3 < runBase.Length)
			{
				RunBase runBase3 = SplitRun(runBase, characterIndex3);
				if ((object)runBase3 != null)
				{
					paragraph?.InsertRun(runBase3, num + 1);
				}
			}
			else if (characterIndex2 == 0)
			{
				num--;
			}
		}
		characterIndex += runBase2.Length;
		paragraph?.InsertRun(runBase2, num + 1);
		CompactRuns();
		FinishChange();
		UndoStack?.EndCommit();
		return characterIndex;
	}

	private Paragraph? SplitParagraph(Paragraph? paragraph, int characterIndex, ParagraphSettings? paragraphSettings = null)
	{
		if ((object)paragraph == null || characterIndex > paragraph.TextLength)
		{
			return null;
		}
		RunBase runBase = FindRun(paragraph, ref characterIndex);
		paragraphSettings = ((paragraphSettings != null) ? paragraphSettings.Clone() : (paragraph.Settings?.Clone() ?? new ParagraphSettings()));
		if ((object)runBase == null)
		{
			return null;
		}
		Paragraph paragraph2 = new Paragraph(paragraphSettings);
		int num = paragraph.GetRunIndex(runBase) + 1;
		RunBase runBase2 = SplitRun(runBase, characterIndex);
		if ((object)runBase2 != null)
		{
			paragraph2.AddRun(runBase2);
		}
		while (num < paragraph.RunCount)
		{
			runBase = paragraph[num];
			paragraph.RemoveRunAt(num);
			paragraph2.AddRun(runBase);
		}
		return paragraph2;
	}

	private RunBase? SplitRun(RunBase run, int characterIndex)
	{
		if ((object)run == null || !run.CanSplit(characterIndex))
		{
			return null;
		}
		return run.Split(characterIndex);
	}

	private int GetParagraphIndex(Paragraph paragraph)
	{
		return _paragraphs.FindIndex((Paragraph p) => (object)p == paragraph);
	}

	private void StartChange()
	{
		_changeLevel++;
	}

	private void FinishChange()
	{
		_changeLevel--;
		OnDocumentChanged(hasActualChanges: false);
	}

	private void OnDocumentChanged()
	{
		OnDocumentChanged(hasActualChanges: true);
	}

	private void OnDocumentChanged(bool hasActualChanges)
	{
		if (IsDeserializing)
		{
			return;
		}
		if (hasActualChanges)
		{
			_hasActualChanges = true;
		}
		if (_changeLevel != 0 || !_hasActualChanges)
		{
			return;
		}
		if (UndoStack != null && UndoStack.IsRecording)
		{
			TextDocumentAttributes attributes = Attributes.Clone();
			UndoStack?.Commit(delegate
			{
				Attributes = attributes;
			}, delegate
			{
			});
		}
		Attributes.BeginSuppressOnSettingsChanged();
		Paragraph paragraph = _paragraphs.FirstOrDefault();
		RunBase runBase = _paragraphs.SelectMany((Paragraph p) => p).FirstOrDefault();
		bool flag = false;
		if (runBase?.Settings != null && runBase.Settings.ScriptLevel != 0 && _paragraphs.Sum((Paragraph p) => p.Count()) > 1)
		{
			runBase = _paragraphs.SelectMany((Paragraph p) => p).FirstOrDefault(delegate(RunBase r)
			{
				RunSettings settings = r.Settings;
				return (object)settings != null && settings.ScriptLevel == 0;
			});
			flag = true;
		}
		foreach (TextDocumentAttributeHelper.PropertyAttributeMap pi in TextDocumentAttributeHelper.ParagraphSettingsPropertiesWithAttributes)
		{
			if (paragraph == null)
			{
				break;
			}
			object value = pi.Property.GetValue(paragraph.Settings);
			if (!_paragraphs.Select((Paragraph p) => p.Settings).All((ParagraphSettings s) => object.Equals(s.GetType().GetProperty(pi.Property.Name)?.GetValue(s), value)))
			{
				TextDocumentAttribute? attribute = pi.Attribute;
				if (attribute == null || attribute.Type != TextAttributeType.TabStops)
				{
					continue;
				}
			}
			SetParagrapSettingsAttributeValue(_attributes.ParagraphSettings, pi.Property, value, pi.Attribute ?? new TextDocumentAttribute());
		}
		foreach (TextDocumentAttributeHelper.PropertyAttributeMap pi2 in TextDocumentAttributeHelper.RunSettingsPropertiesWithAttributes)
		{
			if (runBase == null)
			{
				break;
			}
			if (!(pi2.Property.Name != "StrokeColor") && !_attributes.RunSettings.IsStrokeVisible)
			{
				continue;
			}
			object value2 = pi2.Property.GetValue(runBase.Settings);
			if ((from r in _paragraphs.SelectMany((Paragraph p) => p)
				select r.Settings).All((RunSettings s) => object.Equals(s?.GetType().GetProperty(pi2.Property.Name)?.GetValue(s), value2)) || flag)
			{
				TextAttributeType? textAttributeType = pi2.Attribute?.Type;
				if (textAttributeType.HasValue && textAttributeType == TextAttributeType.Fill)
				{
					pi2.Property.SetValue(_attributes.RunSettings, ((TextFillBase)value2)?.Clone());
				}
				else
				{
					pi2.Property.SetValue(_attributes.RunSettings, value2);
				}
			}
		}
		if (UndoStack != null && UndoStack.IsRecording)
		{
			TextDocumentAttributes attributes2 = Attributes?.Clone() ?? new TextDocumentAttributes(UndoStack);
			UndoStack?.Commit(delegate
			{
			}, delegate
			{
				Attributes = attributes2;
			});
		}
		Attributes?.EndSuppressOnSettingsChanged();
		_hasActualChanges = false;
		this.DocumentChanged?.Invoke(this);
	}

	private static void SetParagrapSettingsAttributeValue(ParagraphSettings settings, PropertyInfo pi, object? value, TextDocumentAttribute attribute)
	{
		if (attribute.Type == TextAttributeType.TabStops)
		{
			if (value is TabStopCollection source)
			{
				settings.TabStops.Clear();
				source.ForEach(delegate(TabStop t)
				{
					settings.TabStops.AddStop(t.Position, t.Type);
				});
			}
		}
		else if ((object)pi.GetSetMethod() != null)
		{
			pi.SetValue(settings, value);
		}
	}

	private void OnParagraphChanged(Paragraph paragraph)
	{
		OnDocumentChanged(hasActualChanges: true);
	}

	private void OnListSettingsChanged(ListSettingsCollection listSettings)
	{
		OnDocumentChanged(hasActualChanges: true);
	}

	public static bool operator ==(TextDocument? lhs, TextDocument? rhs)
	{
		return lhs.NullableEquals(rhs);
	}

	public static bool operator !=(TextDocument? lhs, TextDocument? rhs)
	{
		return !lhs.NullableEquals(rhs);
	}
}
