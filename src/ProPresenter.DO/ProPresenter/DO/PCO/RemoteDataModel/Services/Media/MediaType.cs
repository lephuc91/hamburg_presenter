using System.Text.Json.Serialization;
using Pro.Common.Serialization.Enum;

namespace ProPresenter.DO.PCO.RemoteDataModel.Services.Media;

[JsonConverter(typeof(CustomStringEnumConverter<MediaType>))]
public enum MediaType
{
	[JsonStringEnumValue("audio")]
	Audio,
	[JsonStringEnumValue("background_audio")]
	BackgroundAudio,
	[JsonStringEnumValue("background_image")]
	BackgroundImage,
	[JsonStringEnumValue("background_video")]
	BackgroundVideo,
	[JsonStringEnumValue("countdown")]
	Countdown,
	[JsonStringEnumValue("document")]
	Document,
	[JsonStringEnumValue("drama")]
	Drama,
	[JsonStringEnumValue("image")]
	Image,
	[JsonStringEnumValue("powerpoint")]
	Powerpoint,
	[JsonStringEnumValue("song_video")]
	SongVideo,
	[JsonStringEnumValue("video")]
	Video
}
