using System.IO;
using System.Reflection;
using Google.Protobuf;
using Pro.Serialization.Utility;
using ProPresenter.Controller.NetworkAPI;
using ProPresenter.DO.ClearGroups;

namespace ProPresenter.UI.ClearGroups;

public class ClearGroupIconRenderer : IClearGroupIconRenderer
{
	public virtual ByteString Render(ClearGroup group)
	{
		if (group.ImageType != ImageType.Custom)
		{
			return ByteString.CopyFromUtf8(GetIconSvgStringFromEnum(group.ImageType));
		}
		if (group.Icon != null)
		{
			return group.Icon.ToByteString();
		}
		return ByteString.Empty;
	}

	public static string GetIconSvgStringFromEnum(ImageType imageType)
	{
		return imageType switch
		{
			ImageType.Zero => ReadEmbeddedSvg("0.svg"), 
			ImageType.One => ReadEmbeddedSvg("1.svg"), 
			ImageType.Two => ReadEmbeddedSvg("2.svg"), 
			ImageType.Three => ReadEmbeddedSvg("3.svg"), 
			ImageType.Four => ReadEmbeddedSvg("4.svg"), 
			ImageType.Five => ReadEmbeddedSvg("5.svg"), 
			ImageType.Six => ReadEmbeddedSvg("6.svg"), 
			ImageType.Seven => ReadEmbeddedSvg("7.svg"), 
			ImageType.Eight => ReadEmbeddedSvg("8.svg"), 
			ImageType.Nine => ReadEmbeddedSvg("9.svg"), 
			ImageType.All => ReadEmbeddedSvg("X Clear.svg"), 
			ImageType.Megahorn => ReadEmbeddedSvg("Megaphone.svg"), 
			ImageType.Play => ReadEmbeddedSvg("Play.svg"), 
			ImageType.Bulb => ReadEmbeddedSvg("Bulb.svg"), 
			ImageType.Sunglasses => ReadEmbeddedSvg("Sunglasses.svg"), 
			ImageType.Arrow => ReadEmbeddedSvg("Arrow.svg"), 
			ImageType.Target => ReadEmbeddedSvg("Target.svg"), 
			ImageType.Star => ReadEmbeddedSvg("Star.svg"), 
			ImageType.Sun => ReadEmbeddedSvg("Sun.svg"), 
			ImageType.Bell => ReadEmbeddedSvg("Bell.svg"), 
			ImageType.Paperclip => ReadEmbeddedSvg("Paperclip.svg"), 
			ImageType.Flask => ReadEmbeddedSvg("Flask.svg"), 
			ImageType.Eyeglasses => ReadEmbeddedSvg("Glasses.svg"), 
			ImageType.Cupcake => ReadEmbeddedSvg("Cupcake.svg"), 
			ImageType.Slide => ReadEmbeddedSvg("Slide.svg"), 
			ImageType.Hat => ReadEmbeddedSvg("Hat.svg"), 
			ImageType.Flower => ReadEmbeddedSvg("Flower.svg"), 
			ImageType.Heart => ReadEmbeddedSvg("Heart.svg"), 
			ImageType.Message => ReadEmbeddedSvg("Message.svg"), 
			ImageType.Audio => ReadEmbeddedSvg("Audio.svg"), 
			ImageType.Cloud => ReadEmbeddedSvg("Cloud.svg"), 
			ImageType.Exclamation => ReadEmbeddedSvg("Exclamation.svg"), 
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
