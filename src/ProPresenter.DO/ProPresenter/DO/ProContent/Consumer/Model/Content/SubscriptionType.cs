using System.Text.Json.Serialization;
using Pro.Common.Serialization.Enum;

namespace ProPresenter.DO.ProContent.Consumer.Model.Content;

[JsonConverter(typeof(CustomStringEnumConverter<SubscriptionType>))]
public enum SubscriptionType
{
	[JsonStringEnumValue("Free")]
	Free,
	[JsonStringEnumDefaultValue]
	[JsonStringEnumValue("Premium")]
	Premium
}
