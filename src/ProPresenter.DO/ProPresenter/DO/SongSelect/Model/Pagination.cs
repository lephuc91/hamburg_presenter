using System.Text.Json.Serialization;

namespace ProPresenter.DO.SongSelect.Model;

public class Pagination
{
	[JsonPropertyName("pageSize")]
	public int PageSize { get; init; }

	[JsonPropertyName("pageNumber")]
	public int PageNumber { get; init; }

	[JsonPropertyName("totalItems")]
	public int TotalItems { get; init; }

	[JsonPropertyName("lastPage")]
	public int LastPage { get; init; }
}
