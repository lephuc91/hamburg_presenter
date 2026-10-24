using System;
using System.Text.Json.Serialization;
using ProPresenter.DO.PCO.RemoteDataModel.Helper;

namespace ProPresenter.DO.PCO.RemoteDataModel;

public class EncodedData<T>
{
	[JsonPropertyName("data")]
	public T? Data { get; init; }

	[JsonPropertyName("meta")]
	public Meta? Meta { get; init; }

	[JsonPropertyName("included")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public PcoData[] Included { get; init; } = Array.Empty<PcoData>();
}
