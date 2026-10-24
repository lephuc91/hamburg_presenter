using System.Text.Json.Serialization;
using Pro.Common.Serialization.Enum;

namespace ProPresenter.DO.ProContent.Consumer.Model.Download;

[JsonConverter(typeof(CustomStringEnumConverter<AssetType>))]
public enum AssetType
{
	[JsonStringEnumValue("Loop")]
	Loop,
	[JsonStringEnumValue("Countdown")]
	Countdown,
	[JsonStringEnumValue("Image")]
	Image,
	[JsonStringEnumValue("MotionTitle")]
	MotionTitle,
	[JsonStringEnumValue("Pack")]
	Pack,
	[JsonStringEnumValue("Theme")]
	Theme
}
