using System.Text.Json.Serialization;

namespace ProPresenter.DO.SongSelect.Model;

public class ReceivedData<TData>
{
	[JsonPropertyName("statusCode")]
	public int StatusCode { get; init; }

	[JsonPropertyName("message")]
	public string? Message { get; init; }

	[JsonPropertyName("data")]
	public TData? Data { get; init; }
}
