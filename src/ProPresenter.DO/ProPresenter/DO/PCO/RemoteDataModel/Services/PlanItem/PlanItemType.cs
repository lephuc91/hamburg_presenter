using System.Text.Json.Serialization;
using Pro.Common.Serialization.Enum;

namespace ProPresenter.DO.PCO.RemoteDataModel.Services.PlanItem;

[JsonConverter(typeof(CustomStringEnumConverter<PlanItemType>))]
public enum PlanItemType
{
	[JsonStringEnumValue("song")]
	Song,
	[JsonStringEnumValue("header")]
	Header,
	[JsonStringEnumValue("media")]
	Media,
	[JsonStringEnumValue("item")]
	Item
}
