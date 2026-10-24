using System.Text.Json.Serialization;

namespace ProPresenter.DO.PCO.RemoteDataModel.Services.AttachmentActivity;

public class AttachmentActivityAttributes
{
	[JsonPropertyName("attachment_url")]
	public string? AttachmentUrl { get; init; }
}
