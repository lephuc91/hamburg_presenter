using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using Google.Protobuf;
using Pro.Common.Collections;
using Pro.Common.Logging;
using Pro.Common.Mathematics;
using Pro.Common.Nullability;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.DO.Application;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using Pro.Text;
using Pro.Text.Fills;

namespace Pro.DO.Utility;

public static class ProtoExtensions
{
	public static Graphics.Types.Point ToProtoPoint<T>(this Vector2<T> point)
	{
		Vector2<double> vector = point.Cast<double>();
		return new Graphics.Types.Point
		{
			X = vector.X,
			Y = vector.Y
		};
	}

	public static Graphics.Types.Size ToProtoSize<T>(this Vector2<T> point)
	{
		Vector2<double> vector = point.Cast<double>();
		return new Graphics.Types.Size
		{
			Width = vector.X,
			Height = vector.Y
		};
	}

	public static Vector2<double> ToVector(this Graphics.Types.Point protoPoint)
	{
		if (protoPoint != null)
		{
			return new Vector2<double>(protoPoint.X.IsReal() ? protoPoint.X : 0.0, protoPoint.Y.IsReal() ? protoPoint.Y : 0.0);
		}
		return Vector2<double>.Zero;
	}

	public static Vector2<double> ToVector(this Graphics.Types.Size protoSize)
	{
		if (protoSize != null)
		{
			return new Vector2<double>(protoSize.Width.IsReal() ? protoSize.Width : 0.0, protoSize.Height.IsReal() ? protoSize.Height : 0.0);
		}
		return Vector2<double>.Zero;
	}

	public static Graphics.Types.Rect ToProtoRect<T>(this Rect<T> bounds)
	{
		return new Graphics.Types.Rect
		{
			Origin = bounds.Position.ToProtoPoint(),
			Size = bounds.Size.ToProtoSize()
		};
	}

	public static Rect<double> ToRect(this Graphics.Types.Rect bounds)
	{
		if (bounds == null)
		{
			return Rect<double>.Empty;
		}
		return new Rect<double>(bounds.Origin.ToVector(), bounds.Size.ToVector());
	}

	public static double ToProtoAngle<T>(this Angle<T> angle)
	{
		return angle.Cast<double>().CartesianValue;
	}

	public static Angle<double> ToAngle(this double protoAngle)
	{
		return new Angle<double>(protoAngle, isCartesian: true);
	}

	public static UUID ToUUID(this Guid id)
	{
		return new UUID
		{
			String = id.ToString()
		};
	}

	public static Guid ToGuid(this UUID uuid)
	{
		if (!Guid.TryParse(uuid?.String, out var result))
		{
			return Guid.NewGuid();
		}
		return result;
	}

	public static Timestamp ToTimeStamp(this DateTime? dateTime)
	{
		return new Timestamp
		{
			Seconds = (dateTime?.ToUnixTimestamp() ?? 0)
		};
	}

	public static Timestamp ToTimeStamp(this DateTime dateTime)
	{
		return new Timestamp
		{
			Seconds = dateTime.ToUnixTimestamp()
		};
	}

	public static Timestamp ToTimeStamp(this TimeSlice time)
	{
		return new Timestamp
		{
			Seconds = (long)time.TotalSeconds
		};
	}

	public static TimeSlice ToTimeSlice(this Timestamp timeStamp)
	{
		return TimeSlice.FromSeconds(timeStamp.Seconds);
	}

	public static DateTime ToDateTime(this Timestamp timeStamp)
	{
		return timeStamp.Seconds.FromUnixTimestamp();
	}

	public static Pro.SerializationInterop.RVProtoData.Color ToProtoColor(this System.Windows.Media.Color color)
	{
		return new Pro.SerializationInterop.RVProtoData.Color
		{
			Alpha = ColorExtensions.NormalizeComponent(color.A),
			Blue = ColorExtensions.NormalizeComponent(color.B),
			Green = ColorExtensions.NormalizeComponent(color.G),
			Red = ColorExtensions.NormalizeComponent(color.R)
		};
	}

	public static Graphics.Types.Gradient.Types.ColorStop ToProtoColorStop(this System.Windows.Media.Color color)
	{
		return new Graphics.Types.Gradient.Types.ColorStop
		{
			Color = color.ToProtoColor()
		};
	}

	public static System.Windows.Media.Color ToColor(this Pro.SerializationInterop.RVProtoData.Color color)
	{
		if (color == null)
		{
			return Colors.Black;
		}
		return ColorExtensions.FromNormalizedRGBA(color.Red, color.Green, color.Blue, color.Alpha);
	}

	public static System.Windows.Media.Color ToColor(this Graphics.Types.Gradient.Types.ColorStop colorStop)
	{
		return colorStop.Color.ToColor();
	}

	public static Graphics.Types.Text ToProtoText(this TextDocument document)
	{
		return new Graphics.Types.Text
		{
			VerticalAlignment = document.Settings.Alignment.ToProtoVerticalAlignment(),
			Transform = document.Settings.Transform.Serialize(),
			TransformDelimiter = document.Settings.TransformDelimiter,
			ScaleBehavior = document.Settings.ScaleMode.ToProtoFontScaleBehavior(),
			RtfData = document.ToRTFData(),
			Margins = document.Settings.Margins.ToProtoEdgeInsets(),
			Shadow = document.Settings.Shadow.ToProtoShadow(),
			Attributes = document.ToProtoAttributes(),
			IsSuperscriptStandardized = true,
			ChordPro = document.Settings.ChordPro.ToProtoChordPro()
		};
	}

	public static string GetAllText(this Graphics.Types.Text protoText)
	{
		TextDocument document = null;
		try
		{
			document = protoText.RtfData?.ToDocument();
		}
		catch (Exception ex) when (!(ex is ThreadAbortException))
		{
			Log.Error("Failed to parse RTF document: {0}", ex);
		}
		if (document == null)
		{
			return string.Empty;
		}
		document.SetIsDeserializing(value: true);
		if (protoText.Attributes?.CustomAttributes != null)
		{
			foreach (Graphics.Types.Text.Types.Attributes.Types.CustomAttribute customAttribute2 in protoText.Attributes.CustomAttributes)
			{
				Graphics.Types.Text.Types.Attributes.Types.CustomAttribute customAttribute = customAttribute2;
				switch (customAttribute.AttributeCase)
				{
				case Graphics.Types.Text.Types.Attributes.Types.CustomAttribute.AttributeOneofCase.Capitalization:
					iterateRunsWithTextAttributesOnly(delegate(RunBase r)
					{
						r.Settings.CapitalizationType = customAttribute.Capitalization.ToCapitalizationType();
					});
					break;
				case Graphics.Types.Text.Types.Attributes.Types.CustomAttribute.AttributeOneofCase.OriginalFont:
					iterateRunsWithTextAttributesOnly(delegate(RunBase r)
					{
						r.Settings.OriginalFont = customAttribute.OriginalFont.ToFontWithoutSubstitution();
					});
					break;
				}
				void iterateRunsWithTextAttributesOnly(Action<RunBase> iterator)
				{
					if (customAttribute.Range.End < 0)
					{
						if (customAttribute.AttributeCase == Graphics.Types.Text.Types.Attributes.Types.CustomAttribute.AttributeOneofCase.Capitalization)
						{
							document.Attributes.RunSettings.CapitalizationType = customAttribute.Capitalization.ToCapitalizationType();
						}
						else
						{
							document.IterateRuns(new Pro.Text.Range(customAttribute.Range.Start, customAttribute.Range.End), splitRuns: true, iterator);
						}
					}
				}
			}
		}
		if (!document.HasText)
		{
			document.First().First().AssignSettings(document.Attributes.RunSettings);
		}
		document.SetIsDeserializing(value: false);
		return document.AllText;
	}

	public static TextDocument? ToDocument(this Graphics.Types.Text protoText, ITextFillMediaFactory textFillMediaFactory, string containerId, ApplicationData? applicationData = null)
	{
		TextDocument document = null;
		try
		{
			document = protoText.RtfData?.ToDocument();
		}
		catch (Exception ex) when (!(ex is ThreadAbortException))
		{
			Log.Error("Failed to parse RTF document: {0}", ex);
		}
		if (document == null)
		{
			return null;
		}
		document.SetIsDeserializing(value: true);
		document.Settings.Alignment = protoText.VerticalAlignment.ToDocumentAlignment();
		document.Settings.Transform = protoText.Transform.Deserialize();
		document.Settings.TransformDelimiter = protoText.TransformDelimiter;
		document.Settings.ScaleMode = protoText.ScaleBehavior.ToFontScaleBehavior();
		if (protoText.Shadow != null)
		{
			document.Settings.Shadow.Angle = protoText.Shadow.Angle.ToAngle();
			document.Settings.Shadow.BlurRadius = protoText.Shadow.Radius;
			document.Settings.Shadow.Color = protoText.Shadow.Color.ToColor();
			document.Settings.Shadow.IsEnabled = protoText.Shadow.Enable;
			document.Settings.Shadow.Offset = protoText.Shadow.Offset;
			document.Settings.Shadow.Opacity = protoText.Shadow.Opacity;
		}
		if (protoText.ChordPro != null)
		{
			document.Settings.ChordPro.Enabled = protoText.ChordPro.Enabled;
			document.Settings.ChordPro.Notation = (ChordProNotationType)protoText.ChordPro.Notation;
			document.Settings.ChordPro.Color = protoText.ChordPro.Color.ToColor();
		}
		if (protoText.Attributes?.CustomAttributes != null)
		{
			foreach (Graphics.Types.Text.Types.Attributes.Types.CustomAttribute customAttribute2 in protoText.Attributes.CustomAttributes)
			{
				Graphics.Types.Text.Types.Attributes.Types.CustomAttribute customAttribute = customAttribute2;
				switch (customAttribute.AttributeCase)
				{
				case Graphics.Types.Text.Types.Attributes.Types.CustomAttribute.AttributeOneofCase.Capitalization:
					iterateRunsWithAllAttributes(delegate(RunBase r)
					{
						r.Settings.CapitalizationType = customAttribute.Capitalization.ToCapitalizationType();
					});
					break;
				case Graphics.Types.Text.Types.Attributes.Types.CustomAttribute.AttributeOneofCase.OriginalFont:
					iterateRunsWithAllAttributes(delegate(RunBase r)
					{
						FontInfo value = customAttribute.OriginalFont.ToFontWithoutSubstitution();
						r.Settings.OriginalFont = value;
					});
					break;
				case Graphics.Types.Text.Types.Attributes.Types.CustomAttribute.AttributeOneofCase.OriginalFontSize:
					iterateRunsWithAllAttributes(delegate(RunBase r)
					{
						r.Settings.CharacterSize = (int)customAttribute.OriginalFontSize;
					});
					break;
				case Graphics.Types.Text.Types.Attributes.Types.CustomAttribute.AttributeOneofCase.TextGradientFill:
					iterateRunsWithAllAttributes(delegate(RunBase r)
					{
						r.Settings.Fill = customAttribute.TextGradientFill.ToGradientTextFill();
					});
					break;
				case Graphics.Types.Text.Types.Attributes.Types.CustomAttribute.AttributeOneofCase.MediaFill:
					iterateRunsWithAllAttributes(delegate(RunBase r)
					{
						r.Settings.Fill = customAttribute.MediaFill.ToMediaTextFill(textFillMediaFactory, containerId);
					});
					break;
				case Graphics.Types.Text.Types.Attributes.Types.CustomAttribute.AttributeOneofCase.CutOutFill:
					iterateRunsWithAllAttributes(delegate(RunBase r)
					{
						r.Settings.Fill = customAttribute.CutOutFill.ToCutOutTextFill();
					});
					break;
				case Graphics.Types.Text.Types.Attributes.Types.CustomAttribute.AttributeOneofCase.BackgroundEffect:
					switch (customAttribute.BackgroundEffect.EffectTypeCase)
					{
					case Graphics.Types.BackgroundEffect.EffectTypeOneofCase.None:
						iterateRunsWithAllAttributes(delegate(RunBase r)
						{
							r.Settings.Fill = new SolidTextFill();
						});
						break;
					case Graphics.Types.BackgroundEffect.EffectTypeOneofCase.BackgroundBlur:
						iterateRunsWithAllAttributes(delegate(RunBase r)
						{
							r.Settings.Fill = customAttribute.BackgroundEffect.BackgroundBlur.ToBackgroundBlurTextFill();
						});
						break;
					case Graphics.Types.BackgroundEffect.EffectTypeOneofCase.BackgroundInvert:
						iterateRunsWithAllAttributes(delegate(RunBase r)
						{
							r.Settings.Fill = customAttribute.BackgroundEffect.BackgroundInvert.ToBackgroundInvertTextFill();
						});
						break;
					}
					break;
				case Graphics.Types.Text.Types.Attributes.Types.CustomAttribute.AttributeOneofCase.Chord:
					iterateRunsWithAllAttributes(delegate(RunBase r)
					{
						r.Settings.ChordAnnotation = customAttribute.Chord;
					});
					break;
				case Graphics.Types.Text.Types.Attributes.Types.CustomAttribute.AttributeOneofCase.ShouldPreserveForegroundColor:
					iterateRunsWithAllAttributes(delegate(RunBase r)
					{
						r.Settings.PreserveFillColor = customAttribute.ShouldPreserveForegroundColor;
					});
					break;
				}
				void iterateRunsWithAllAttributes(Action<RunBase> iterator)
				{
					if (customAttribute.Range.End < 0)
					{
						switch (customAttribute.AttributeCase)
						{
						case Graphics.Types.Text.Types.Attributes.Types.CustomAttribute.AttributeOneofCase.Capitalization:
							document.Attributes.RunSettings.CapitalizationType = customAttribute.Capitalization.ToCapitalizationType();
							break;
						case Graphics.Types.Text.Types.Attributes.Types.CustomAttribute.AttributeOneofCase.OriginalFont:
							document.Attributes.RunSettings.OriginalFont = customAttribute.OriginalFont.ToFontWithoutSubstitution();
							break;
						case Graphics.Types.Text.Types.Attributes.Types.CustomAttribute.AttributeOneofCase.TextGradientFill:
							document.Attributes.RunSettings.Fill = customAttribute.TextGradientFill.ToGradientTextFill();
							break;
						case Graphics.Types.Text.Types.Attributes.Types.CustomAttribute.AttributeOneofCase.MediaFill:
							document.Attributes.RunSettings.Fill = customAttribute.MediaFill.ToMediaTextFill(textFillMediaFactory, containerId);
							break;
						case Graphics.Types.Text.Types.Attributes.Types.CustomAttribute.AttributeOneofCase.CutOutFill:
							document.Attributes.RunSettings.Fill = customAttribute.CutOutFill.ToCutOutTextFill();
							break;
						case Graphics.Types.Text.Types.Attributes.Types.CustomAttribute.AttributeOneofCase.BackgroundEffect:
							switch (customAttribute.BackgroundEffect.EffectTypeCase)
							{
							case Graphics.Types.BackgroundEffect.EffectTypeOneofCase.None:
								document.Attributes.RunSettings.Fill = new SolidTextFill();
								break;
							case Graphics.Types.BackgroundEffect.EffectTypeOneofCase.BackgroundBlur:
							{
								BackgroundBlurTextFill fill2 = customAttribute.BackgroundEffect.BackgroundBlur.ToBackgroundBlurTextFill();
								document.Attributes.RunSettings.Fill = fill2;
								break;
							}
							case Graphics.Types.BackgroundEffect.EffectTypeOneofCase.BackgroundInvert:
							{
								BackgroundInvertTextFill fill = customAttribute.BackgroundEffect.BackgroundInvert.ToBackgroundInvertTextFill();
								document.Attributes.RunSettings.Fill = fill;
								break;
							}
							case (Graphics.Types.BackgroundEffect.EffectTypeOneofCase)1:
								break;
							}
							break;
						case Graphics.Types.Text.Types.Attributes.Types.CustomAttribute.AttributeOneofCase.OriginalFontSize:
						case Graphics.Types.Text.Types.Attributes.Types.CustomAttribute.AttributeOneofCase.FontScaleFactor:
						case Graphics.Types.Text.Types.Attributes.Types.CustomAttribute.AttributeOneofCase.ShouldPreserveForegroundColor:
						case Graphics.Types.Text.Types.Attributes.Types.CustomAttribute.AttributeOneofCase.Chord:
						case Graphics.Types.Text.Types.Attributes.Types.CustomAttribute.AttributeOneofCase.CharacterSizeMode:
							break;
						}
					}
					else
					{
						document.IterateRuns(new Pro.Text.Range(customAttribute.Range.Start, customAttribute.Range.End), splitRuns: true, iterator);
					}
				}
			}
		}
		if (protoText.Margins != null && document.Settings.Margins.Left == 0.0 && document.Settings.Margins.Top == 0.0 && document.Settings.Margins.Right == 0.0 && document.Settings.Margins.Bottom == 0.0)
		{
			document.Settings.Margins.Left = protoText.Margins.Left;
			document.Settings.Margins.Top = protoText.Margins.Top;
			document.Settings.Margins.Right = protoText.Margins.Right;
			document.Settings.Margins.Bottom = protoText.Margins.Bottom;
		}
		if (protoText.Attributes?.ParagraphStyle != null)
		{
			ParagraphSettings paragraphSettings = protoText.Attributes.ParagraphStyle.ToParagraphSettings(document);
			document.Attributes.ParagraphSettings = paragraphSettings.Clone();
			if (!document.HasText)
			{
				document.First().AssignSettings(paragraphSettings);
			}
		}
		document.Attributes.RunSettings.Underline = (protoText.Attributes?.UnderlineStyle?.Style).GetValueOrDefault() != Graphics.Types.Text.Types.Attributes.Types.Underline.Types.Style.None;
		document.Attributes.RunSettings.Strikethrough = (protoText.Attributes?.StrikethroughStyle?.Style).GetValueOrDefault() != Graphics.Types.Text.Types.Attributes.Types.Underline.Types.Style.None;
		RunSettings runSettings = document.Attributes.RunSettings;
		Graphics.Types.Text.Types.Attributes attributes = protoText.Attributes;
		runSettings.CapitalizationType = ((attributes != null) ? attributes.Capitalization.ToCapitalizationType() : CapitalizationType.None);
		document.Attributes.RunSettings.ScriptLevel = protoText.Attributes?.Superscript ?? 0;
		RunSettings runSettings2 = document.Attributes.RunSettings;
		Graphics.Types.Text.Types.Attributes attributes2 = protoText.Attributes;
		runSettings2.LigaturesEnabled = attributes2 == null || attributes2.LigatureStyle != Graphics.Types.Text.Types.Attributes.Types.LigatureStyle.None;
		if (protoText.Attributes?.Font != null)
		{
			FontInfo font = protoText.Attributes.Font.ToFont();
			document.Attributes.RunSettings.Font = font;
			document.Attributes.RunSettings.CharacterSize = (int)protoText.Attributes.Font.Size;
		}
		switch (protoText.Attributes?.FillCase ?? Graphics.Types.Text.Types.Attributes.FillOneofCase.None)
		{
		case Graphics.Types.Text.Types.Attributes.FillOneofCase.TextSolidFill:
			if (protoText.Attributes != null)
			{
				document.Attributes.RunSettings.Fill = new SolidTextFill(protoText.Attributes.TextSolidFill.ToColor());
			}
			break;
		case Graphics.Types.Text.Types.Attributes.FillOneofCase.TextGradientFill:
			document.Attributes.RunSettings.Fill = protoText.Attributes.TextGradientFill.ToGradientTextFill();
			break;
		case Graphics.Types.Text.Types.Attributes.FillOneofCase.MediaFill:
			document.Attributes.RunSettings.Fill = protoText.Attributes.MediaFill.ToMediaTextFill(textFillMediaFactory, containerId);
			break;
		case Graphics.Types.Text.Types.Attributes.FillOneofCase.CutOutFill:
			document.Attributes.RunSettings.Fill = protoText.Attributes.CutOutFill.ToCutOutTextFill();
			break;
		case Graphics.Types.Text.Types.Attributes.FillOneofCase.BackgroundEffect:
			if (protoText.Attributes != null)
			{
				switch (protoText.Attributes.BackgroundEffect.EffectTypeCase)
				{
				case Graphics.Types.BackgroundEffect.EffectTypeOneofCase.None:
					document.Attributes.RunSettings.Fill = new SolidTextFill();
					break;
				case Graphics.Types.BackgroundEffect.EffectTypeOneofCase.BackgroundBlur:
					document.Attributes.RunSettings.Fill = protoText.Attributes.BackgroundEffect.BackgroundBlur.ToBackgroundBlurTextFill();
					break;
				case Graphics.Types.BackgroundEffect.EffectTypeOneofCase.BackgroundInvert:
					document.Attributes.RunSettings.Fill = protoText.Attributes.BackgroundEffect.BackgroundInvert.ToBackgroundInvertTextFill();
					break;
				}
			}
			break;
		}
		if (!document.HasText)
		{
			document.First().First().AssignSettings(document.Attributes.RunSettings);
		}
		if (!protoText.IsSuperscriptStandardized && applicationData != null && applicationData.PlatformType == PlatformType.MacOS)
		{
			document.IterateRuns(Pro.Text.Range.All, splitRuns: false, delegate(RunBase run)
			{
				if (run.Settings.ScriptLevel != 0)
				{
					run.Settings.ScriptLevel = (int)Math.Ceiling((double)run.Settings.ScriptLevel / 2.0);
					run.Settings.CharacterSize = (int)((double)run.Settings.CharacterSize * Math.Pow(2.0, Math.Abs(run.Settings.ScriptLevel)));
				}
			});
			if (document.Attributes.RunSettings.ScriptLevel != 0)
			{
				document.Attributes.RunSettings.ScriptLevel = (int)Math.Ceiling((double)document.Attributes.RunSettings.ScriptLevel / 2.0);
				document.Attributes.RunSettings.CharacterSize = (int)((double)document.Attributes.RunSettings.CharacterSize * Math.Pow(2.0, Math.Abs(document.Attributes.RunSettings.ScriptLevel)));
			}
		}
		document.SetIsDeserializing(value: false);
		return document;
	}

	public static ByteString ToRTFData(this TextDocument document)
	{
		return Encoding.UTF8.GetBytes(document.ToRTF()).ToByteString();
	}

	public static TextDocument ToDocument(this ByteString rtfData)
	{
		if (rtfData == null || rtfData.IsEmpty)
		{
			return new TextDocument();
		}
		return Encoding.UTF8.GetString(rtfData.ToByteArray()).ToTextDocument();
	}

	private static Graphics.Types.Text.Types.VerticalAlignment ToProtoVerticalAlignment(this DocumentAlignment alignment)
	{
		return alignment switch
		{
			DocumentAlignment.Top => Graphics.Types.Text.Types.VerticalAlignment.Top, 
			DocumentAlignment.Bottom => Graphics.Types.Text.Types.VerticalAlignment.Bottom, 
			_ => Graphics.Types.Text.Types.VerticalAlignment.Middle, 
		};
	}

	private static DocumentAlignment ToDocumentAlignment(this Graphics.Types.Text.Types.VerticalAlignment alignment)
	{
		return alignment switch
		{
			Graphics.Types.Text.Types.VerticalAlignment.Top => DocumentAlignment.Top, 
			Graphics.Types.Text.Types.VerticalAlignment.Bottom => DocumentAlignment.Bottom, 
			_ => DocumentAlignment.Middle, 
		};
	}

	private static Graphics.Types.Text.Types.ScaleBehavior ToProtoFontScaleBehavior(this ScaleMode fontScaleBehavior)
	{
		return fontScaleBehavior switch
		{
			ScaleMode.AdjustContainerHeight => Graphics.Types.Text.Types.ScaleBehavior.AdjustContainerHeight, 
			ScaleMode.Down => Graphics.Types.Text.Types.ScaleBehavior.ScaleFontDown, 
			ScaleMode.Up => Graphics.Types.Text.Types.ScaleBehavior.ScaleFontUp, 
			ScaleMode.UpOrDown => Graphics.Types.Text.Types.ScaleBehavior.ScaleFontUpDown, 
			_ => Graphics.Types.Text.Types.ScaleBehavior.None, 
		};
	}

	private static ScaleMode ToFontScaleBehavior(this Graphics.Types.Text.Types.ScaleBehavior protoFontScaleBehavior)
	{
		return protoFontScaleBehavior switch
		{
			Graphics.Types.Text.Types.ScaleBehavior.AdjustContainerHeight => ScaleMode.AdjustContainerHeight, 
			Graphics.Types.Text.Types.ScaleBehavior.ScaleFontDown => ScaleMode.Down, 
			Graphics.Types.Text.Types.ScaleBehavior.ScaleFontUp => ScaleMode.Up, 
			Graphics.Types.Text.Types.ScaleBehavior.ScaleFontUpDown => ScaleMode.UpOrDown, 
			_ => ScaleMode.None, 
		};
	}

	private static Graphics.Types.Text.Types.Attributes ToProtoAttributes(this TextDocument document)
	{
		Graphics.Types.Text.Types.Attributes attributes = new Graphics.Types.Text.Types.Attributes
		{
			Capitalization = document.Attributes.RunSettings.CapitalizationType.ToProtoCapitalization(),
			Font = document.Attributes.RunSettings.ToProtoFont(),
			Kerning = document.Attributes.RunSettings.CharacterSpacing,
			ParagraphStyle = document.Attributes.ParagraphSettings.ToProtoParagraph(document),
			StrokeColor = document.Attributes.RunSettings.StrokeColor.ToProtoColor(),
			StrokeWidth = document.Attributes.RunSettings.StrokeThickness,
			Superscript = document.Attributes.RunSettings.ScriptLevel,
			LigatureStyle = ((!document.Attributes.RunSettings.LigaturesEnabled) ? Graphics.Types.Text.Types.Attributes.Types.LigatureStyle.None : Graphics.Types.Text.Types.Attributes.Types.LigatureStyle.Default)
		};
		switch (document.Attributes.RunSettings.Fill.TextFillType)
		{
		case TextFillType.SolidColor:
			attributes.TextSolidFill = ((SolidTextFill)document.Attributes.RunSettings.Fill).Color.ToProtoColor();
			break;
		case TextFillType.Gradient:
			attributes.TextGradientFill = ((GradientTextFill)document.Attributes.RunSettings.Fill).ToProtoGradientFill();
			break;
		case TextFillType.Media:
			attributes.MediaFill = ((MediaTextFill)document.Attributes.RunSettings.Fill).ToProtoMediaFill();
			break;
		case TextFillType.CutOut:
			attributes.CutOutFill = ((CutOutTextFill)document.Attributes.RunSettings.Fill).ToProtoCutOutTextFill();
			break;
		case TextFillType.BackgroundBlur:
		{
			BackgroundBlurTextFill fill2 = (BackgroundBlurTextFill)document.Attributes.RunSettings.Fill;
			attributes.BackgroundEffect = new Graphics.Types.BackgroundEffect
			{
				BackgroundBlur = fill2.ToProtoBackgroundBlurTextFill()
			};
			break;
		}
		case TextFillType.BackgroundInvert:
		{
			BackgroundInvertTextFill fill = (BackgroundInvertTextFill)document.Attributes.RunSettings.Fill;
			attributes.BackgroundEffect = new Graphics.Types.BackgroundEffect
			{
				BackgroundInvert = fill.ToProtoBackgroundInvertTextFill()
			};
			break;
		}
		default:
			attributes.TextSolidFill = Colors.White.ToProtoColor();
			break;
		}
		if (document.Attributes.RunSettings.Strikethrough)
		{
			attributes.StrikethroughStyle = new Graphics.Types.Text.Types.Attributes.Types.Underline
			{
				Pattern = Graphics.Types.Text.Types.Attributes.Types.Underline.Types.Pattern.Solid,
				Style = Graphics.Types.Text.Types.Attributes.Types.Underline.Types.Style.Single
			};
			attributes.StrikethroughColor = document.Attributes.RunSettings.Fill.PrimaryColor.ToProtoColor();
		}
		if (document.Attributes.RunSettings.Underline)
		{
			attributes.UnderlineStyle = new Graphics.Types.Text.Types.Attributes.Types.Underline
			{
				Pattern = Graphics.Types.Text.Types.Attributes.Types.Underline.Types.Pattern.Solid,
				Style = Graphics.Types.Text.Types.Attributes.Types.Underline.Types.Style.Single
			};
			attributes.UnderlineColor = (document.Attributes.RunSettings.UnderlineColor ?? document.Attributes.RunSettings.Fill.PrimaryColor).ToProtoColor();
		}
		attributes.BackgroundColor = document.Attributes.RunSettings.HighlightColor?.ToProtoColor();
		bool serializeOriginalFontSize = document.Settings.ScaleMode.IsAnyOf(ScaleMode.Up, ScaleMode.Down, ScaleMode.UpOrDown);
		document.IterateAllRuns(delegate(Pro.Text.Range range, RunBase run)
		{
			if (serializeOriginalFontSize)
			{
				attributes.CustomAttributes.Add(new Graphics.Types.Text.Types.Attributes.Types.CustomAttribute
				{
					Range = getRange(),
					OriginalFontSize = run.Settings.CharacterSize
				});
			}
			if (run.Settings.OriginalFont.HasValue)
			{
				attributes.CustomAttributes.Add(new Graphics.Types.Text.Types.Attributes.Types.CustomAttribute
				{
					Range = getRange(),
					OriginalFont = run.Settings.OriginalFont.Value.ToProtoFont(run.Settings.CharacterSize)
				});
			}
			if (run.Settings.CapitalizationType != 0)
			{
				attributes.CustomAttributes.Add(new Graphics.Types.Text.Types.Attributes.Types.CustomAttribute
				{
					Range = getRange(),
					Capitalization = run.Settings.CapitalizationType.ToProtoCapitalization()
				});
			}
			if (run.Settings.Fill.TextFillType == TextFillType.Gradient)
			{
				attributes.CustomAttributes.Add(new Graphics.Types.Text.Types.Attributes.Types.CustomAttribute
				{
					Range = getRange(),
					TextGradientFill = ((GradientTextFill)run.Settings.Fill).ToProtoGradientFill()
				});
			}
			if (run.Settings.Fill.TextFillType == TextFillType.Media)
			{
				attributes.CustomAttributes.Add(new Graphics.Types.Text.Types.Attributes.Types.CustomAttribute
				{
					Range = getRange(),
					MediaFill = ((MediaTextFill)run.Settings.Fill).ToProtoMediaFill()
				});
			}
			if (run.Settings.Fill.TextFillType == TextFillType.CutOut)
			{
				attributes.CustomAttributes.Add(new Graphics.Types.Text.Types.Attributes.Types.CustomAttribute
				{
					Range = getRange(),
					CutOutFill = ((CutOutTextFill)run.Settings.Fill).ToProtoCutOutTextFill()
				});
			}
			if (run.Settings.Fill.TextFillType == TextFillType.BackgroundBlur)
			{
				BackgroundBlurTextFill fill3 = (BackgroundBlurTextFill)run.Settings.Fill;
				Graphics.Types.BackgroundEffect backgroundEffect = new Graphics.Types.BackgroundEffect
				{
					BackgroundBlur = fill3.ToProtoBackgroundBlurTextFill()
				};
				attributes.CustomAttributes.Add(new Graphics.Types.Text.Types.Attributes.Types.CustomAttribute
				{
					Range = getRange(),
					BackgroundEffect = backgroundEffect
				});
			}
			if (run.Settings.Fill.TextFillType == TextFillType.BackgroundInvert)
			{
				BackgroundInvertTextFill fill4 = (BackgroundInvertTextFill)run.Settings.Fill;
				Graphics.Types.BackgroundEffect backgroundEffect2 = new Graphics.Types.BackgroundEffect
				{
					BackgroundInvert = fill4.ToProtoBackgroundInvertTextFill()
				};
				attributes.CustomAttributes.Add(new Graphics.Types.Text.Types.Attributes.Types.CustomAttribute
				{
					Range = getRange(),
					BackgroundEffect = backgroundEffect2
				});
			}
			if (!string.IsNullOrWhiteSpace(run.Settings.ChordAnnotation))
			{
				attributes.CustomAttributes.Add(new Graphics.Types.Text.Types.Attributes.Types.CustomAttribute
				{
					Range = getRange(),
					Chord = run.Settings.ChordAnnotation
				});
			}
			if (run.Settings.PreserveFillColor)
			{
				attributes.CustomAttributes.Add(new Graphics.Types.Text.Types.Attributes.Types.CustomAttribute
				{
					Range = getRange(),
					ShouldPreserveForegroundColor = true
				});
			}
			IntRange getRange()
			{
				return new IntRange
				{
					Start = range.Start,
					End = range.End
				};
			}
		});
		return attributes;
	}

	private static Graphics.Types.Text.Types.Attributes.Types.Capitalization ToProtoCapitalization(this CapitalizationType capitalizationType)
	{
		return capitalizationType switch
		{
			CapitalizationType.AllCaps => Graphics.Types.Text.Types.Attributes.Types.Capitalization.AllCaps, 
			CapitalizationType.SmallCaps => Graphics.Types.Text.Types.Attributes.Types.Capitalization.SmallCaps, 
			CapitalizationType.TitleCase => Graphics.Types.Text.Types.Attributes.Types.Capitalization.TitleCase, 
			CapitalizationType.StartCase => Graphics.Types.Text.Types.Attributes.Types.Capitalization.StartCase, 
			_ => Graphics.Types.Text.Types.Attributes.Types.Capitalization.None, 
		};
	}

	private static CapitalizationType ToCapitalizationType(this Graphics.Types.Text.Types.Attributes.Types.Capitalization protoCapitalizationType)
	{
		return protoCapitalizationType switch
		{
			Graphics.Types.Text.Types.Attributes.Types.Capitalization.AllCaps => CapitalizationType.AllCaps, 
			Graphics.Types.Text.Types.Attributes.Types.Capitalization.SmallCaps => CapitalizationType.SmallCaps, 
			Graphics.Types.Text.Types.Attributes.Types.Capitalization.TitleCase => CapitalizationType.TitleCase, 
			Graphics.Types.Text.Types.Attributes.Types.Capitalization.StartCase => CapitalizationType.StartCase, 
			_ => CapitalizationType.None, 
		};
	}

	private static Graphics.Types.Text.Types.GradientFill ToProtoGradientFill(this GradientTextFill gradientTextFill)
	{
		Graphics.Types.Text.Types.GradientFill gradientFill = new Graphics.Types.Text.Types.GradientFill();
		gradientFill.Gradient = new Graphics.Types.Gradient
		{
			Angle = gradientTextFill.Angle.ToProtoAngle()
		};
		gradientFill.StretchToDocumentBounds = gradientTextFill.StretchToDocumentBounds;
		gradientFill.Gradient.Stops.Add(gradientTextFill.StartColor.ToProtoColorStop());
		gradientFill.Gradient.Stops.Add(gradientTextFill.EndColor.ToProtoColorStop());
		return gradientFill;
	}

	public static Graphics.Types.Text.Types.MediaFill ToProtoMediaFill(this MediaTextFill mediaTextFill)
	{
		return new Graphics.Types.Text.Types.MediaFill
		{
			Media = mediaTextFill.Media?.Serialize()
		};
	}

	public static Graphics.Types.Text.Types.CutOutFill ToProtoCutOutTextFill(this CutOutTextFill cutOutTextFill)
	{
		return new Graphics.Types.Text.Types.CutOutFill();
	}

	public static Graphics.Types.BackgroundEffect.Types.BackgroundEffectBlur ToProtoBackgroundBlurTextFill(this BackgroundBlurTextFill fill)
	{
		return new Graphics.Types.BackgroundEffect.Types.BackgroundEffectBlur
		{
			BlurAmount = fill.Blur,
			Saturation = fill.Saturation
		};
	}

	public static Graphics.Types.BackgroundEffect.Types.BackgroundEffectInvert ToProtoBackgroundInvertTextFill(this BackgroundInvertTextFill fill)
	{
		return new Graphics.Types.BackgroundEffect.Types.BackgroundEffectInvert();
	}

	private static GradientTextFill ToGradientTextFill(this Graphics.Types.Text.Types.GradientFill gradientFill)
	{
		return new GradientTextFill(gradientFill.Gradient.Stops[0].Color.ToColor(), gradientFill.Gradient.Stops[1].Color.ToColor(), gradientFill.Gradient.Angle.ToAngle(), gradientFill.StretchToDocumentBounds);
	}

	private static MediaTextFill ToMediaTextFill(this Graphics.Types.Text.Types.MediaFill? mediaFill, ITextFillMediaFactory factory, string containerId)
	{
		if (mediaFill?.Media == null)
		{
			return new MediaTextFill();
		}
		object obj = mediaFill.Media.TypePropertiesCase switch
		{
			Media.TypePropertiesOneofCase.Image => factory.CreateImageMedia(containerId), 
			Media.TypePropertiesOneofCase.Video => factory.CreateVideoMedia(containerId), 
			_ => factory.CreateImageMedia(containerId), 
		};
		((ITextFillMedia)obj).Deserialize(mediaFill.Media);
		return new MediaTextFill((ITextFillMedia?)obj);
	}

	private static CutOutTextFill ToCutOutTextFill(this Graphics.Types.Text.Types.CutOutFill? cutOutFill)
	{
		return new CutOutTextFill();
	}

	private static BackgroundBlurTextFill ToBackgroundBlurTextFill(this Graphics.Types.BackgroundEffect.Types.BackgroundEffectBlur protoFill)
	{
		return new BackgroundBlurTextFill(protoFill.Saturation, protoFill.BlurAmount);
	}

	private static BackgroundInvertTextFill ToBackgroundInvertTextFill(this Graphics.Types.BackgroundEffect.Types.BackgroundEffectInvert protoFill)
	{
		return new BackgroundInvertTextFill();
	}

	private static Graphics.Types.EdgeInsets ToProtoEdgeInsets(this Margins margins)
	{
		return new Graphics.Types.EdgeInsets
		{
			Left = margins.Left,
			Top = margins.Top,
			Right = margins.Right,
			Bottom = margins.Bottom
		};
	}

	private static Graphics.Types.Shadow ToProtoShadow(this Shadow shadow)
	{
		return new Graphics.Types.Shadow
		{
			Angle = shadow.Angle.ToProtoAngle(),
			Color = shadow.Color.ToProtoColor(),
			Enable = shadow.IsEnabled,
			Offset = shadow.Offset,
			Opacity = shadow.Opacity,
			Radius = shadow.BlurRadius,
			Style = Graphics.Types.Shadow.Types.Style.Drop
		};
	}

	private static Graphics.Types.Text.Types.ChordPro ToProtoChordPro(this ChordPro chordPro)
	{
		return new Graphics.Types.Text.Types.ChordPro
		{
			Enabled = chordPro.Enabled,
			Notation = (Graphics.Types.Text.Types.ChordPro.Types.Notation)chordPro.Notation,
			Color = chordPro.Color?.ToProtoColor()
		};
	}

	private static Pro.SerializationInterop.RVProtoData.Font ToProtoFont(this RunSettings runSettings)
	{
		return runSettings.Font.ToProtoFont(runSettings.CharacterSize);
	}

	public static Pro.SerializationInterop.RVProtoData.Font ToProtoFont(this FontInfo fontInfo)
	{
		return new Pro.SerializationInterop.RVProtoData.Font
		{
			Bold = fontInfo.IsBold,
			Italic = fontInfo.IsItalic,
			Name = (fontInfo.PSName ?? fontInfo.FullName ?? string.Empty),
			Face = (fontInfo.SystemFaceName ?? string.Empty),
			Family = (fontInfo.SystemFamilyName ?? string.Empty)
		};
	}

	public static Pro.SerializationInterop.RVProtoData.Font ToProtoFont(this FontInfo fontInfo, double fontSize)
	{
		Pro.SerializationInterop.RVProtoData.Font font = fontInfo.ToProtoFont();
		font.Size = fontSize;
		return font;
	}

	public static FontInfo ToFont(this Pro.SerializationInterop.RVProtoData.Font protoFont)
	{
		FontInfo fontInfo = new FontInfo(protoFont.Family, protoFont.Face, protoFont.Name, protoFont.Bold ? FontWeights.Bold : FontWeights.Regular, FontStretches.Normal, protoFont.Italic);
		bool isFallbackFont;
		Pro.Text.Font font = SharedTypefaceLibrary.Library.FindFont(fontInfo, out isFallbackFont);
		if (!isFallbackFont)
		{
			return font.Info;
		}
		return fontInfo;
	}

	private static FontInfo ToFontWithoutSubstitution(this Pro.SerializationInterop.RVProtoData.Font protoFont)
	{
		return new FontInfo(protoFont.Family, protoFont.Face, protoFont.Name, protoFont.Bold ? FontWeights.Bold : FontWeights.Regular, FontStretches.Normal, protoFont.Italic);
	}

	private static Graphics.Types.Text.Types.Attributes.Types.Paragraph ToProtoParagraph(this ParagraphSettings paragraphSettings, TextDocument document)
	{
		Graphics.Types.Text.Types.Attributes.Types.Paragraph paragraph = new Graphics.Types.Text.Types.Attributes.Types.Paragraph();
		paragraph.Alignment = paragraphSettings.Alignment.ToProtoParagraphAlignment();
		paragraph.FirstLineHeadIndent = paragraphSettings.FirstLineIndent;
		paragraph.HeadIndent = paragraphSettings.LeftIndent;
		paragraph.LineHeightMultiple = ((paragraphSettings.SpacingMode == LineSpacingMode.Multiple) ? paragraphSettings.LineSpacing : 1.0);
		paragraph.LineSpacing = paragraphSettings.AdditionalLineSpacing;
		paragraph.ParagraphSpacing = paragraphSettings.AfterParagraph;
		paragraph.ParagraphSpacingBefore = paragraphSettings.BeforeParagraph;
		paragraph.TailIndent = paragraphSettings.RightIndent;
		paragraph.TextList = ToProtoParagraphTextList(document.ListSettingsCollection, paragraphSettings);
		paragraph.TabStops.AddRange(paragraphSettings.TabStops.Select(ToProtoTabStop));
		return paragraph;
	}

	private static Graphics.Types.Text.Types.Attributes.Types.Paragraph.Types.TextList ToProtoParagraphTextList(ListSettingsCollection listSettingsCollection, ParagraphSettings paragraphSettings)
	{
		LevelSettings levelSettings = listSettingsCollection.ElementAtOrDefault(paragraphSettings.ListIndex)?.Levels.ElementAtOrDefault(paragraphSettings.LevelIndex);
		if (!paragraphSettings.IsPartOfList || (object)levelSettings == null)
		{
			return new Graphics.Types.Text.Types.Attributes.Types.Paragraph.Types.TextList
			{
				IsEnabled = false
			};
		}
		return new Graphics.Types.Text.Types.Attributes.Types.Paragraph.Types.TextList
		{
			IsEnabled = true,
			NumberType = getNumberType(),
			Prefix = levelSettings.Prefix,
			Postfix = levelSettings.Suffix,
			StartingNumber = levelSettings.StartNumber
		};
		Graphics.Types.Text.Types.Attributes.Types.Paragraph.Types.TextList.Types.NumberType getNumberType()
		{
			if (!paragraphSettings.IsPartOfList)
			{
				return Graphics.Types.Text.Types.Attributes.Types.Paragraph.Types.TextList.Types.NumberType.Box;
			}
			if (levelSettings.IsBullet)
			{
				switch (levelSettings.BulletType)
				{
				case BulletType.Dash:
				case BulletType.HyphenDash:
					return Graphics.Types.Text.Types.Attributes.Types.Paragraph.Types.TextList.Types.NumberType.Hyphen;
				case BulletType.SmallCircle:
				case BulletType.Circle:
					return Graphics.Types.Text.Types.Attributes.Types.Paragraph.Types.TextList.Types.NumberType.Disc;
				case BulletType.SmallOpenCircle:
				case BulletType.OpenCircle:
					return Graphics.Types.Text.Types.Attributes.Types.Paragraph.Types.TextList.Types.NumberType.Circle;
				case BulletType.SmallSquare:
				case BulletType.Square:
					return Graphics.Types.Text.Types.Attributes.Types.Paragraph.Types.TextList.Types.NumberType.Square;
				case BulletType.SmallOpenSquare:
				case BulletType.OpenSquare:
					return Graphics.Types.Text.Types.Attributes.Types.Paragraph.Types.TextList.Types.NumberType.Box;
				case BulletType.Checkmark:
				case BulletType.HeavyCheckmark:
					return Graphics.Types.Text.Types.Attributes.Types.Paragraph.Types.TextList.Types.NumberType.Check;
				case BulletType.Diamond:
				case BulletType.OpenDiamond:
					return Graphics.Types.Text.Types.Attributes.Types.Paragraph.Types.TextList.Types.NumberType.Diamond;
				default:
					return Graphics.Types.Text.Types.Attributes.Types.Paragraph.Types.TextList.Types.NumberType.Hyphen;
				}
			}
			switch (levelSettings.NumberingScheme)
			{
			case NumberingScheme.Arabic:
			case NumberingScheme.ArabicWithLeadingZero:
			case NumberingScheme.OrdinalNumber:
				return Graphics.Types.Text.Types.Attributes.Types.Paragraph.Types.TextList.Types.NumberType.Decimal;
			case NumberingScheme.UppercaseRomanNumeral:
				return Graphics.Types.Text.Types.Attributes.Types.Paragraph.Types.TextList.Types.NumberType.UppercaseRoman;
			case NumberingScheme.LowercaseRomanNumeral:
				return Graphics.Types.Text.Types.Attributes.Types.Paragraph.Types.TextList.Types.NumberType.LowercaseRoman;
			case NumberingScheme.UppercaseLetter:
			case NumberingScheme.UppercaseRussianAlphabet:
			case NumberingScheme.UppercaseGreekNumerals:
				return Graphics.Types.Text.Types.Attributes.Types.Paragraph.Types.TextList.Types.NumberType.UppercaseAlpha;
			case NumberingScheme.LowercaseLetter:
			case NumberingScheme.LowercaseRussianAlphabet:
			case NumberingScheme.LowercaseGreekNumerals:
				return Graphics.Types.Text.Types.Attributes.Types.Paragraph.Types.TextList.Types.NumberType.LowercaseAlpha;
			default:
				return Graphics.Types.Text.Types.Attributes.Types.Paragraph.Types.TextList.Types.NumberType.Decimal;
			}
		}
	}

	private static ParagraphSettings ToParagraphSettings(this Graphics.Types.Text.Types.Attributes.Types.Paragraph protoParagraph, TextDocument document)
	{
		ParagraphSettings settings = new ParagraphSettings(protoParagraph.Alignment.ToParagraphAlignment(), LineSpacingMode.Multiple, protoParagraph.LineHeightMultiple, protoParagraph.LineSpacing, protoParagraph.ParagraphSpacingBefore, protoParagraph.ParagraphSpacing, protoParagraph.HeadIndent, protoParagraph.TailIndent, protoParagraph.FirstLineHeadIndent);
		protoParagraph.TabStops.ForEach(delegate(Graphics.Types.Text.Types.Attributes.Types.Paragraph.Types.TabStop t)
		{
			settings.TabStops.AddStop(t.Location);
		});
		Graphics.Types.Text.Types.Attributes.Types.Paragraph.Types.TextList textList = protoParagraph.TextList;
		if (textList != null && textList.IsEnabled)
		{
			bool isBullet = true;
			BulletType bulletType = BulletType.Dash;
			NumberingScheme numberingScheme = NumberingScheme.Arabic;
			switch (protoParagraph.TextList.NumberType)
			{
			case Graphics.Types.Text.Types.Attributes.Types.Paragraph.Types.TextList.Types.NumberType.Box:
				bulletType = BulletType.SmallOpenSquare;
				break;
			case Graphics.Types.Text.Types.Attributes.Types.Paragraph.Types.TextList.Types.NumberType.Check:
				bulletType = BulletType.Checkmark;
				break;
			case Graphics.Types.Text.Types.Attributes.Types.Paragraph.Types.TextList.Types.NumberType.Circle:
				bulletType = BulletType.SmallOpenCircle;
				break;
			case Graphics.Types.Text.Types.Attributes.Types.Paragraph.Types.TextList.Types.NumberType.Diamond:
				bulletType = BulletType.Diamond;
				break;
			case Graphics.Types.Text.Types.Attributes.Types.Paragraph.Types.TextList.Types.NumberType.Disc:
				bulletType = BulletType.SmallCircle;
				break;
			case Graphics.Types.Text.Types.Attributes.Types.Paragraph.Types.TextList.Types.NumberType.Hyphen:
				bulletType = BulletType.HyphenDash;
				break;
			case Graphics.Types.Text.Types.Attributes.Types.Paragraph.Types.TextList.Types.NumberType.Square:
				bulletType = BulletType.SmallSquare;
				break;
			case Graphics.Types.Text.Types.Attributes.Types.Paragraph.Types.TextList.Types.NumberType.Decimal:
				isBullet = false;
				numberingScheme = NumberingScheme.Arabic;
				break;
			case Graphics.Types.Text.Types.Attributes.Types.Paragraph.Types.TextList.Types.NumberType.LowercaseAlpha:
				isBullet = false;
				numberingScheme = NumberingScheme.LowercaseLetter;
				break;
			case Graphics.Types.Text.Types.Attributes.Types.Paragraph.Types.TextList.Types.NumberType.UppercaseAlpha:
				numberingScheme = NumberingScheme.UppercaseLetter;
				isBullet = false;
				break;
			case Graphics.Types.Text.Types.Attributes.Types.Paragraph.Types.TextList.Types.NumberType.LowercaseRoman:
				numberingScheme = NumberingScheme.LowercaseRomanNumeral;
				break;
			case Graphics.Types.Text.Types.Attributes.Types.Paragraph.Types.TextList.Types.NumberType.UppercaseRoman:
				numberingScheme = NumberingScheme.UppercaseRomanNumeral;
				isBullet = false;
				break;
			}
			document.ListSettingsCollection.AddList(ListPreset.None, out var settingsIndex).Levels.AddLevel(new LevelSettings
			{
				IsBullet = isBullet,
				BulletType = bulletType,
				NumberingScheme = numberingScheme
			});
			settings.ListIndex = settingsIndex;
			settings.LevelIndex = 0;
		}
		return settings;
	}

	private static Graphics.Types.Text.Types.Attributes.Types.Paragraph.Types.TabStop ToProtoTabStop(this TabStop tabStop)
	{
		return new Graphics.Types.Text.Types.Attributes.Types.Paragraph.Types.TabStop
		{
			Location = tabStop.Position
		};
	}

	public static Pro.SerializationInterop.RVProtoData.Version ToProtoVersion(this System.Version version)
	{
		return new Pro.SerializationInterop.RVProtoData.Version
		{
			Build = version.Build.ToString(),
			MajorVersion = (uint)version.Major,
			MinorVersion = (uint)version.Minor,
			PatchVersion = (uint)version.Revision
		};
	}

	public static System.Version ToVersion(this Pro.SerializationInterop.RVProtoData.Version protoVersion)
	{
		if (protoVersion == null)
		{
			return new System.Version();
		}
		int result;
		return new System.Version(Math.Max((int)protoVersion.MajorVersion, 0), Math.Max((int)protoVersion.MinorVersion, 0), int.TryParse(protoVersion.Build, out result) ? Math.Max(0, result) : 0, Math.Max((int)protoVersion.PatchVersion, 0));
	}

	public static URL? WebURLToProtoURL(this string? webURL)
	{
		if (webURL.NullableIsNullOrEmpty())
		{
			return null;
		}
		return new URL
		{
			AbsoluteString = webURL,
			Platform = URL.Types.Platform.Web
		};
	}

	public static string? ProtoURLToWebURL(this URL protoURL)
	{
		if (protoURL.Platform != URL.Types.Platform.Web)
		{
			return null;
		}
		return protoURL.AbsoluteString;
	}

	public static CollectionElementType ToProtoCollectionElement(this (Guid id, string name) data)
	{
		return new CollectionElementType
		{
			ParameterUuid = data.id.ToUUID(),
			ParameterName = (data.name ?? string.Empty)
		};
	}

	public static void Deconstruct(this CollectionElementType protoCollectionElement, out Guid id, out string name)
	{
		id = protoCollectionElement.ParameterUuid.ToGuid();
		name = protoCollectionElement.ParameterName;
	}

	public static Slide.Types.Element.Types.DataLink.Types.AlternateElementText.Types.TextTransformOption SerializeForLink(this TextTransform elementTextLinkTransform)
	{
		return elementTextLinkTransform switch
		{
			TextTransform.RemoveLineReturns => Slide.Types.Element.Types.DataLink.Types.AlternateElementText.Types.TextTransformOption.RemoveLineReturns, 
			TextTransform.SingleWordPerLine => Slide.Types.Element.Types.DataLink.Types.AlternateElementText.Types.TextTransformOption.OneWordPerLine, 
			TextTransform.SingleCharacterPerLine => Slide.Types.Element.Types.DataLink.Types.AlternateElementText.Types.TextTransformOption.OneCharacterPerLine, 
			_ => Slide.Types.Element.Types.DataLink.Types.AlternateElementText.Types.TextTransformOption.None, 
		};
	}

	public static Graphics.Types.Text.Types.Transform Serialize(this TextTransform elementTextLinkTransform)
	{
		return elementTextLinkTransform switch
		{
			TextTransform.None => Graphics.Types.Text.Types.Transform.None, 
			TextTransform.RemoveLineReturns => Graphics.Types.Text.Types.Transform.SingleLine, 
			TextTransform.ReplaceLineReturns => Graphics.Types.Text.Types.Transform.ReplaceLineReturns, 
			TextTransform.SingleWordPerLine => Graphics.Types.Text.Types.Transform.OneWordPerLine, 
			TextTransform.SingleCharacterPerLine => Graphics.Types.Text.Types.Transform.OneCharacterPerLine, 
			_ => Graphics.Types.Text.Types.Transform.None, 
		};
	}

	public static TextTransform Deserialize(this Slide.Types.Element.Types.DataLink.Types.AlternateElementText.Types.TextTransformOption protoTextTransformOption)
	{
		return protoTextTransformOption switch
		{
			Slide.Types.Element.Types.DataLink.Types.AlternateElementText.Types.TextTransformOption.None => TextTransform.None, 
			Slide.Types.Element.Types.DataLink.Types.AlternateElementText.Types.TextTransformOption.RemoveLineReturns => TextTransform.RemoveLineReturns, 
			Slide.Types.Element.Types.DataLink.Types.AlternateElementText.Types.TextTransformOption.OneWordPerLine => TextTransform.SingleWordPerLine, 
			Slide.Types.Element.Types.DataLink.Types.AlternateElementText.Types.TextTransformOption.OneCharacterPerLine => TextTransform.SingleCharacterPerLine, 
			_ => TextTransform.None, 
		};
	}

	public static TextTransform Deserialize(this Graphics.Types.Text.Types.Transform protoTextTransform)
	{
		return protoTextTransform switch
		{
			Graphics.Types.Text.Types.Transform.None => TextTransform.None, 
			Graphics.Types.Text.Types.Transform.SingleLine => TextTransform.RemoveLineReturns, 
			Graphics.Types.Text.Types.Transform.ReplaceLineReturns => TextTransform.ReplaceLineReturns, 
			Graphics.Types.Text.Types.Transform.OneWordPerLine => TextTransform.SingleWordPerLine, 
			Graphics.Types.Text.Types.Transform.OneCharacterPerLine => TextTransform.SingleCharacterPerLine, 
			_ => TextTransform.None, 
		};
	}

	public static byte[] ToByteArray(this TextDocument document)
	{
		if ((object)document == null)
		{
			return Array.Empty<byte>();
		}
		try
		{
			return document.ToProtoText().ToByteArray();
		}
		catch
		{
			return Array.Empty<byte>();
		}
	}

	public static TextDocument? FromByteArray(this byte[]? byteArr, ITextFillMediaFactory factory, string containerId)
	{
		if (byteArr == null)
		{
			return null;
		}
		try
		{
			Graphics.Types.Text text = new Graphics.Types.Text();
			text.MergeFrom(byteArr);
			return text.ToDocument(factory, containerId);
		}
		catch
		{
			return null;
		}
	}

	public static IEnumerable<KeyValuePair<string, string>> ParseIdentifierPairs(this IEnumerable<NetworkAPI.Types.IndexOrNameIdentifierPair> identifierPairs)
	{
		List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
		foreach (NetworkAPI.Types.IndexOrNameIdentifierPair identifierPair in identifierPairs)
		{
			KeyValuePair<string, string>? keyValuePair = identifierPair.ParseIdentifierPair();
			if (keyValuePair.HasValue)
			{
				list.Add(keyValuePair.Value);
			}
		}
		return list;
	}

	public static KeyValuePair<string, string>? ParseIdentifierPair(this NetworkAPI.Types.IndexOrNameIdentifierPair identifierPair)
	{
		string text = identifierPair.Key.ParseIdentifier();
		string text2 = identifierPair.Value.ParseIdentifier();
		if (text != null && text2 != null)
		{
			return new KeyValuePair<string, string>(text, text2);
		}
		return null;
	}

	public static string? ParseIdentifier(this NetworkAPI.Types.IndexOrNameIdentifier identifier)
	{
		return identifier.ComponentCase switch
		{
			NetworkAPI.Types.IndexOrNameIdentifier.ComponentOneofCase.Index => identifier.Index.ToString(), 
			NetworkAPI.Types.IndexOrNameIdentifier.ComponentOneofCase.Name => identifier.Name, 
			_ => null, 
		};
	}
}
