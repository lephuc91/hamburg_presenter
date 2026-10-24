using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Media;
using Pro.DO.Triggering;
using Pro.UI.SVG;

namespace ProPresenter.UI.Macros;

public static class MacroIconHelper
{
	private static List<MacroIcon>? _selectableIcons;

	public static ImageType CustomImageType => ImageType.Custom;

	public static List<MacroIcon> SelectableIcons
	{
		get
		{
			List<ImageType> second = new List<ImageType> { ImageType.Custom };
			return _selectableIcons ?? (_selectableIcons = Enum.GetValues<ImageType>().Except(second).Select(createMacroIcon)
				.ToList());
			static MacroIcon createMacroIcon(ImageType imageType)
			{
				return new MacroIcon(imageType, GetIconFromEnum(imageType));
			}
		}
	}

	public static ImageSource? GetIconFromEnum(ImageType imageType)
	{
		string iconSvgStringFromEnum = GetIconSvgStringFromEnum(imageType);
		if (!(iconSvgStringFromEnum == string.Empty))
		{
			return iconSvgStringFromEnum.ToSvgImageSource();
		}
		return null;
	}

	public static string GetIconSvgStringFromEnum(ImageType imageType)
	{
		return imageType switch
		{
			ImageType.One => ReadEmbeddedSvg("1.svg"), 
			ImageType.Two => ReadEmbeddedSvg("2.svg"), 
			ImageType.Three => ReadEmbeddedSvg("3.svg"), 
			ImageType.Four => ReadEmbeddedSvg("4.svg"), 
			ImageType.Five => ReadEmbeddedSvg("5.svg"), 
			ImageType.Six => ReadEmbeddedSvg("6.svg"), 
			ImageType.Seven => ReadEmbeddedSvg("7.svg"), 
			ImageType.Eight => ReadEmbeddedSvg("8.svg"), 
			ImageType.Nine => ReadEmbeddedSvg("9.svg"), 
			ImageType.Zero => ReadEmbeddedSvg("0.svg"), 
			ImageType.Xclear => ReadEmbeddedSvg("X Clear.svg"), 
			ImageType.Arrow => ReadEmbeddedSvg("Arrow.svg"), 
			ImageType.Audio => ReadEmbeddedSvg("Audio.svg"), 
			ImageType.Bell => ReadEmbeddedSvg("Bell.svg"), 
			ImageType.Bulb => ReadEmbeddedSvg("Bulb.svg"), 
			ImageType.Cloud => ReadEmbeddedSvg("Cloud.svg"), 
			ImageType.Cupcake => ReadEmbeddedSvg("Cupcake.svg"), 
			ImageType.Exclamation => ReadEmbeddedSvg("Exclamation.svg"), 
			ImageType.Flask => ReadEmbeddedSvg("Flask.svg"), 
			ImageType.Flower => ReadEmbeddedSvg("Flower.svg"), 
			ImageType.Glasses => ReadEmbeddedSvg("Glasses.svg"), 
			ImageType.Hashtag => ReadEmbeddedSvg("Hashtag.svg"), 
			ImageType.Hat => ReadEmbeddedSvg("Hat.svg"), 
			ImageType.Heart => ReadEmbeddedSvg("Heart.svg"), 
			ImageType.Megaphone => ReadEmbeddedSvg("Megaphone.svg"), 
			ImageType.Message => ReadEmbeddedSvg("Message.svg"), 
			ImageType.Paperclip => ReadEmbeddedSvg("Paperclip.svg"), 
			ImageType.Play => ReadEmbeddedSvg("Play.svg"), 
			ImageType.Slide => ReadEmbeddedSvg("Slide.svg"), 
			ImageType.Star => ReadEmbeddedSvg("Star.svg"), 
			ImageType.Sun => ReadEmbeddedSvg("Sun.svg"), 
			ImageType.Sunglasses => ReadEmbeddedSvg("Sunglasses.svg"), 
			ImageType.Target => ReadEmbeddedSvg("Target.svg"), 
			ImageType.Timer => ReadEmbeddedSvg("Timer.svg"), 
			ImageType.VideoInput => ReadEmbeddedSvg("Video Input.svg"), 
			ImageType.LetterA => ReadEmbeddedSvg("A.svg"), 
			ImageType.LetterB => ReadEmbeddedSvg("B.svg"), 
			ImageType.LetterC => ReadEmbeddedSvg("C.svg"), 
			ImageType.LetterD => ReadEmbeddedSvg("D.svg"), 
			ImageType.LetterE => ReadEmbeddedSvg("E.svg"), 
			ImageType.LetterF => ReadEmbeddedSvg("F.svg"), 
			ImageType.LetterG => ReadEmbeddedSvg("G.svg"), 
			ImageType.LetterH => ReadEmbeddedSvg("H.svg"), 
			ImageType.LetterI => ReadEmbeddedSvg("I.svg"), 
			ImageType.LetterJ => ReadEmbeddedSvg("J.svg"), 
			ImageType.LetterK => ReadEmbeddedSvg("K.svg"), 
			ImageType.LetterL => ReadEmbeddedSvg("L.svg"), 
			ImageType.LetterM => ReadEmbeddedSvg("M.svg"), 
			ImageType.LetterN => ReadEmbeddedSvg("N.svg"), 
			ImageType.LetterO => ReadEmbeddedSvg("O.svg"), 
			ImageType.LetterP => ReadEmbeddedSvg("P.svg"), 
			ImageType.LetterQ => ReadEmbeddedSvg("Q.svg"), 
			ImageType.LetterR => ReadEmbeddedSvg("R.svg"), 
			ImageType.LetterS => ReadEmbeddedSvg("S.svg"), 
			ImageType.LetterT => ReadEmbeddedSvg("T.svg"), 
			ImageType.LetterU => ReadEmbeddedSvg("U.svg"), 
			ImageType.LetterV => ReadEmbeddedSvg("V.svg"), 
			ImageType.LetterW => ReadEmbeddedSvg("W.svg"), 
			ImageType.LetterX => ReadEmbeddedSvg("X.svg"), 
			ImageType.LetterY => ReadEmbeddedSvg("Y.svg"), 
			ImageType.LetterZ => ReadEmbeddedSvg("Z.svg"), 
			ImageType.Custom => string.Empty, 
			_ => ReadEmbeddedSvg("0 Default.svg"), 
		};
	}

	private static string ReadEmbeddedSvg(string resourceName)
	{
		using Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ProPresenter.UI.Resources.Icons." + resourceName);
		if (stream == null)
		{
			return string.Empty;
		}
		using StreamReader streamReader = new StreamReader(stream);
		return streamReader.ReadToEnd();
	}
}
