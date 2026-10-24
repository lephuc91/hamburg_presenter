using System.Windows.Media.Imaging;
using Pro.Common.Mathematics;
using Pro.Common.Nullability;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.SerializationInterop.RVProtoData.MediaManagement.v1;
using Pro.SerializationInterop.RVProtoData.MediaManagement.v2;
using ProPresenter.DO.Media;

namespace ProPresenter.Controller.Media;

public static class MediaServiceExtensions
{
	public static IMetadataLoader.SuccessfulResult ToSuccessfulResult(this Pro.SerializationInterop.RVProtoData.MediaManagement.v1.MediaReferenceInfo referenceInfo, IImageLoader imageLoader)
	{
		referenceInfo.MediaInfo.ThrowWhenNull("referenceInfo.MediaInfo");
		BitmapSource thumbnail = null;
		if (referenceInfo.ThumbnailInfo?.Url != null)
		{
			thumbnail = imageLoader.LoadImage(referenceInfo.ThumbnailInfo.Url);
		}
		Pro.SerializationInterop.RVProtoData.MediaManagement.v1.MediaReferenceInfo.Types.MediaInfo mediaInfo = referenceInfo.MediaInfo;
		string artist = mediaInfo.Artist;
		string codec = mediaInfo.Codec;
		TimeSlice duration = TimeSlice.FromSeconds(mediaInfo.Duration);
		double fPS = mediaInfo.Fps;
		Vector2<int> size = new Vector2<uint>(mediaInfo.Width, mediaInfo.Height).Cast<int>();
		int numAudioChannels = (int)mediaInfo.NumAudioChannels;
		NativeRotation nativeRotation = ((double)mediaInfo.Rotation).GetNativeRotation();
		string title = mediaInfo.Title;
		bool? supportsAlphaChannel = mediaInfo.HasAlphaChannel;
		bool isHdrContent = mediaInfo.ColorFormat != Pro.SerializationInterop.RVProtoData.MediaManagement.v1.MediaReferenceInfo.Types.MediaInfo.Types.ColorFormat.Sdr;
		GammaVariant gammaVariant = ((mediaInfo.ColorFormat != Pro.SerializationInterop.RVProtoData.MediaManagement.v1.MediaReferenceInfo.Types.MediaInfo.Types.ColorFormat.HdrRec2100Hlg) ? GammaVariant.PQ : GammaVariant.HLG);
		return new IMetadataLoader.SuccessfulResult(new MediaMetadata(artist, codec, duration, fPS, size, numAudioChannels, nativeRotation, title, supportsAlphaChannel, isHdrContent, gammaVariant, mediaInfo.Url, MediaAvailability.Unset), thumbnail);
	}

	public static IMetadataLoader.SuccessfulResult ToSuccessfulResult(this Pro.SerializationInterop.RVProtoData.MediaManagement.v2.MediaReferenceInfo referenceInfo, IImageLoader imageLoader)
	{
		referenceInfo.MediaInfo.ThrowWhenNull("referenceInfo.MediaInfo");
		BitmapSource thumbnail = null;
		if (referenceInfo.ThumbnailInfo?.Url != null)
		{
			thumbnail = imageLoader.LoadImage(referenceInfo.ThumbnailInfo.Url);
		}
		Pro.SerializationInterop.RVProtoData.MediaManagement.v2.MediaReferenceInfo.Types.MediaInfo mediaInfo = referenceInfo.MediaInfo;
		string artist = mediaInfo.Artist;
		string codec = mediaInfo.Codec;
		TimeSlice duration = TimeSlice.FromSeconds(mediaInfo.Duration);
		double fPS = mediaInfo.Fps;
		Vector2<int> size = new Vector2<uint>(mediaInfo.Width, mediaInfo.Height).Cast<int>();
		int numAudioChannels = (int)mediaInfo.NumAudioChannels;
		NativeRotation nativeRotation = ((double)mediaInfo.Rotation).GetNativeRotation();
		string title = mediaInfo.Title;
		bool? supportsAlphaChannel = mediaInfo.HasAlphaChannel;
		bool isHdrContent = mediaInfo.ColorFormat != Pro.SerializationInterop.RVProtoData.MediaManagement.v2.MediaReferenceInfo.Types.MediaInfo.Types.ColorFormat.Sdr;
		GammaVariant gammaVariant = ((mediaInfo.ColorFormat != Pro.SerializationInterop.RVProtoData.MediaManagement.v2.MediaReferenceInfo.Types.MediaInfo.Types.ColorFormat.HdrRec2100Hlg) ? GammaVariant.PQ : GammaVariant.HLG);
		return new IMetadataLoader.SuccessfulResult(new MediaMetadata(artist, codec, duration, fPS, size, numAudioChannels, nativeRotation, title, supportsAlphaChannel, isHdrContent, gammaVariant, mediaInfo.Url, mediaInfo.Availability.AvailabilityCase.ToMediaAvailability()), thumbnail);
	}
}
