using System.Runtime.CompilerServices;
using Pro.Common.Mathematics;
using Pro.Common.Time;
using Pro.DO.Utility;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Media;

public record MediaMetadata(string Artist, string Codec, TimeSlice Duration, double FPS, Vector2<int> Size, int AudioChannelCount, NativeRotation Rotation, string Title, bool? SupportsAlphaChannel, bool IsHdrContent, GammaVariant GammaVariant, string SourceUrl, MediaAvailability Availability)
{
	public static readonly MediaMetadata Empty = new MediaMetadata(string.Empty, string.Empty, TimeSlice.Zero, 0.0, Vector2<int>.Zero, 0, NativeRotation.RotateStandard, string.Empty, null, IsHdrContent: false, GammaVariant.HLG, string.Empty, MediaAvailability.Unset);

	public static MediaMetadata FromProtoMedia(Pro.SerializationInterop.RVProtoData.Media protoMedia, bool supportsAlphaChannel)
	{
		string artist = protoMedia.Metadata?.Artist ?? string.Empty;
		string codec = protoMedia.Metadata?.Format ?? string.Empty;
		TimeSlice duration = TimeSlice.FromSeconds(protoMedia.Audio?.Transport.EndPoint ?? protoMedia.Video?.Transport.EndPoint ?? 0.0);
		double fPS = protoMedia.Video?.Video.FrameRate ?? 0.0;
		Vector2<int> size = (protoMedia.Image?.Drawing ?? protoMedia.Video?.Drawing ?? protoMedia.LiveVideo?.Drawing)?.NaturalSize?.ToVector().Cast<int>() ?? Vector2<int>.Zero;
		int valueOrDefault = ((protoMedia.Audio?.Audio ?? protoMedia.Video?.Audio ?? protoMedia.LiveVideo?.Audio)?.AudioChannels?.Count).GetValueOrDefault();
		NativeRotation rotation = (protoMedia.Image?.Drawing ?? protoMedia.Video?.Drawing ?? protoMedia.LiveVideo?.Drawing)?.NativeRotation.ToNativeRotation() ?? NativeRotation.RotateStandard;
		string empty = string.Empty;
		return new MediaMetadata(artist, codec, duration, fPS, size, valueOrDefault, rotation, empty, supportsAlphaChannel, IsHdrContent: false, GammaVariant.HLG, protoMedia.Url?.AbsoluteString ?? string.Empty, MediaAvailability.Unset);
	}

	public Pro.SerializationInterop.RVProtoData.Media.Types.Metadata ToProtoMetadata(string? manufacture = null)
	{
		return new Pro.SerializationInterop.RVProtoData.Media.Types.Metadata
		{
			Artist = (Artist ?? string.Empty),
			ManufactureName = (manufacture ?? Title ?? string.Empty),
			Format = (Codec ?? string.Empty)
		};
	}

	[CompilerGenerated]
	protected MediaMetadata(MediaMetadata original)
	{
		Artist = original.Artist;
		Codec = original.Codec;
		Duration = original.Duration;
		FPS = original.FPS;
		Size = original.Size;
		AudioChannelCount = original.AudioChannelCount;
		Rotation = original.Rotation;
		Title = original.Title;
		SupportsAlphaChannel = original.SupportsAlphaChannel;
		IsHdrContent = original.IsHdrContent;
		GammaVariant = original.GammaVariant;
		SourceUrl = original.SourceUrl;
		Availability = original.Availability;
	}
}
