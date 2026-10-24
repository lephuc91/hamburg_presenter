using System.Text.Json.Serialization;

namespace ProPresenter.DO.CloudOnboarding.Model;

public sealed class ResponseResult
{
	[JsonPropertyName("success")]
	public bool Success { get; init; }

	[JsonPropertyName("error")]
	public string Error { get; init; } = string.Empty;
}
