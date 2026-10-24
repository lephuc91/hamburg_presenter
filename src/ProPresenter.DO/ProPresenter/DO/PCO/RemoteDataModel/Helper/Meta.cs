using System.Text.Json.Serialization;

namespace ProPresenter.DO.PCO.RemoteDataModel.Helper;

public class Meta
{
	[JsonPropertyName("next")]
	public MetaNext? Next { get; init; }
}
