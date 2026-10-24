using System.Text.Json.Serialization;
using ProPresenter.DO.PCO.RemoteDataModel.Relationship;

namespace ProPresenter.DO.PCO.RemoteDataModel.Services.Attachment;

public class AttachmentRelationships
{
	[JsonPropertyName("attachable")]
	public SingleRelationship? Attachable { get; init; }
}
