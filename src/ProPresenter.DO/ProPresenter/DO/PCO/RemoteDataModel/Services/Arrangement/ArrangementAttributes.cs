using System;
using System.Text.Json.Serialization;

namespace ProPresenter.DO.PCO.RemoteDataModel.Services.Arrangement;

public class ArrangementAttributes
{
	[JsonPropertyName("name")]
	public string? Name { get; init; }

	[JsonPropertyName("sequence")]
	public string[] Sequence { get; init; } = Array.Empty<string>();
}
