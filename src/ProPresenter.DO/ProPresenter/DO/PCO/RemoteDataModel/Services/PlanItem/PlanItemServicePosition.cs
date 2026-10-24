using System.Text.Json.Serialization;
using Pro.Common.Serialization.Enum;

namespace ProPresenter.DO.PCO.RemoteDataModel.Services.PlanItem;

[JsonConverter(typeof(CustomStringEnumConverter<PlanItemServicePosition>))]
public enum PlanItemServicePosition
{
	[JsonStringEnumValue("pre")]
	Pre,
	[JsonStringEnumValue("post")]
	Post,
	[JsonStringEnumValue("during")]
	During
}
