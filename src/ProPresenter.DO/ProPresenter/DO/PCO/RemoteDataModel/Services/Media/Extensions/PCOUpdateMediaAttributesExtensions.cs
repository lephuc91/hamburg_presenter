using System;

namespace ProPresenter.DO.PCO.RemoteDataModel.Services.Media.Extensions;

public static class PCOUpdateMediaAttributesExtensions
{
	public static MediaType ToTransmissionType(this PCOUpdateMediaAttributes.MediaTypeValue mediaType)
	{
		return mediaType switch
		{
			PCOUpdateMediaAttributes.MediaTypeValue.Audio => MediaType.Audio, 
			PCOUpdateMediaAttributes.MediaTypeValue.BackgroundAudio => MediaType.BackgroundAudio, 
			PCOUpdateMediaAttributes.MediaTypeValue.BackgroundImage => MediaType.BackgroundImage, 
			PCOUpdateMediaAttributes.MediaTypeValue.BackgroundVideo => MediaType.BackgroundVideo, 
			PCOUpdateMediaAttributes.MediaTypeValue.Countdown => MediaType.Countdown, 
			PCOUpdateMediaAttributes.MediaTypeValue.Document => MediaType.Document, 
			PCOUpdateMediaAttributes.MediaTypeValue.Drama => MediaType.Drama, 
			PCOUpdateMediaAttributes.MediaTypeValue.Image => MediaType.Image, 
			PCOUpdateMediaAttributes.MediaTypeValue.Powerpoint => MediaType.Powerpoint, 
			PCOUpdateMediaAttributes.MediaTypeValue.SongVideo => MediaType.SongVideo, 
			PCOUpdateMediaAttributes.MediaTypeValue.Video => MediaType.Video, 
			_ => throw new ArgumentOutOfRangeException("mediaType", $"Could not find a value to use for {mediaType}"), 
		};
	}
}
