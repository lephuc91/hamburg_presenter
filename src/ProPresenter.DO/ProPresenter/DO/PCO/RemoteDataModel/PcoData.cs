using System.Collections.Generic;
using System.Text.Json.Serialization;
using ProPresenter.DO.PCO.RemoteDataModel.People.Person;
using ProPresenter.DO.PCO.RemoteDataModel.Services.Arrangement;
using ProPresenter.DO.PCO.RemoteDataModel.Services.Attachment;
using ProPresenter.DO.PCO.RemoteDataModel.Services.Folder;
using ProPresenter.DO.PCO.RemoteDataModel.Services.Media;
using ProPresenter.DO.PCO.RemoteDataModel.Services.Organization;
using ProPresenter.DO.PCO.RemoteDataModel.Services.Plan;
using ProPresenter.DO.PCO.RemoteDataModel.Services.PlanItem;
using ProPresenter.DO.PCO.RemoteDataModel.Services.ServiceType;
using ProPresenter.DO.PCO.RemoteDataModel.Services.Song;

namespace ProPresenter.DO.PCO.RemoteDataModel;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type", UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToBaseType)]
[JsonDerivedType(typeof(PersonData), "Person")]
[JsonDerivedType(typeof(ArrangementData), "Arrangement")]
[JsonDerivedType(typeof(AttachmentData), "Attachment")]
[JsonDerivedType(typeof(FolderData), "Folder")]
[JsonDerivedType(typeof(MediaData), "Media")]
[JsonDerivedType(typeof(OrganizationData), "Organization")]
[JsonDerivedType(typeof(PlanData), "Plan")]
[JsonDerivedType(typeof(PlanItemData), "Item")]
[JsonDerivedType(typeof(ServiceTypeData), "ServiceType")]
[JsonDerivedType(typeof(SongData), "Song")]
public class PcoData
{
	[JsonPropertyName("id")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	[JsonRequired]
	public string? Id { get; init; }

	[JsonPropertyName("links")]
	public IDictionary<string, string>? Links { get; init; }

	public string GetLinkToSelf()
	{
		return Links?["self"] ?? string.Empty;
	}
}
public class PcoData<TAttributes> : PcoData
{
	[JsonPropertyName("attributes")]
	[JsonRequired]
	public TAttributes? Attributes { get; init; }
}
public class PcoData<TAttributes, TRelationships> : PcoData<TAttributes>
{
	[JsonPropertyName("relationships")]
	public TRelationships? Relationships { get; init; }
}
