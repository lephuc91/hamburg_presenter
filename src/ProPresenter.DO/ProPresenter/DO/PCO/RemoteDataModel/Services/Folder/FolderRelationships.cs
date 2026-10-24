using System.Text.Json.Serialization;
using ProPresenter.DO.PCO.RemoteDataModel.Relationship;

namespace ProPresenter.DO.PCO.RemoteDataModel.Services.Folder;

public class FolderRelationships
{
	[JsonPropertyName("parent")]
	public SingleRelationship? Parent { get; init; }
}
