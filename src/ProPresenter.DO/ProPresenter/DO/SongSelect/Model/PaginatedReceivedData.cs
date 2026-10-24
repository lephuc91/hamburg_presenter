using System.Text.Json.Serialization;

namespace ProPresenter.DO.SongSelect.Model;

public class PaginatedReceivedData<TData> : ReceivedData<TData>
{
	[JsonPropertyName("pagination")]
	public Pagination? Pagination { get; init; }
}
