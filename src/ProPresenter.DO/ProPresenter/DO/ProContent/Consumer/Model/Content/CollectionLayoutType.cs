using System.Text.Json.Serialization;
using Pro.Common.Serialization.Enum;

namespace ProPresenter.DO.ProContent.Consumer.Model.Content;

[JsonConverter(typeof(CustomStringEnumConverter<CollectionLayoutType>))]
public enum CollectionLayoutType
{
	[JsonStringEnumValue("CarouselLarge")]
	CarouselLarge,
	[JsonStringEnumDefaultValue]
	[JsonStringEnumValue("CarouselSmall")]
	CarouselSmall,
	[JsonStringEnumValue("Grid")]
	Grid
}
