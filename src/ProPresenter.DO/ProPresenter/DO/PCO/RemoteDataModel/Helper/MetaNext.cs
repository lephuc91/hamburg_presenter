using System.Text.Json.Serialization;
using Pro.Common.Serialization;

namespace ProPresenter.DO.PCO.RemoteDataModel.Helper;

public class MetaNext
{
	[JsonPropertyName("offset")]
	[JsonConverter(typeof(MayBeNullValueConverter<int>))]
	public int Offset { get; init; }
}
