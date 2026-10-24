using Pro.Common.FileSystem;
using Pro.DO.Storage;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.PCO.RemoteDataModel.Services.Attachment;

namespace ProPresenter.DO.PCO.Items;

public class PCOAttachmentDetails : PCODetailsBase, IPCOContent
{
	private string _filename = string.Empty;

	private string _thumbnailURL = string.Empty;

	public string Filename
	{
		get
		{
			return _filename;
		}
		private set
		{
			_filename = value.SanitizeFilename();
		}
	}

	public RelativePath? LocalDownloadPath { get; set; }

	public RelativePath? LocalWorkingPath { get; set; }

	public long? FileSize { get; }

	public string RemoteDownloadURL => base.Url + "/open";

	public string? SongID { get; set; }

	public string ThumbnailURL
	{
		get
		{
			return _thumbnailURL;
		}
		set
		{
			SetValue("ThumbnailURL", ref _thumbnailURL, value);
		}
	}

	public PCOAttachmentDetails(AttachmentData attachmentDetails, string pcoItemID)
		: base(attachmentDetails.Id, attachmentDetails.Attributes?.UpdatedAt, attachmentDetails.Attributes?.CreatedAt, attachmentDetails.GetLinkToSelf(), pcoItemID)
	{
		FileSize = attachmentDetails.Attributes?.FileSize;
		Filename = attachmentDetails.Attributes?.Filename ?? string.Empty;
		ThumbnailURL = attachmentDetails.Attributes?.ThumbnailUrl ?? string.Empty;
		SongID = attachmentDetails.Relationships?.Attachable?.Data?.Id;
	}

	internal PCOAttachmentDetails(string pcoItemID)
		: base(pcoItemID)
	{
	}

	protected internal override PlanningCenterPlan.Types.PlanItem.Types.Attachment Serialize()
	{
		PlanningCenterPlan.Types.PlanItem.Types.Attachment attachment = base.Serialize();
		attachment.Name = Filename;
		attachment.LinkedPath = LocalWorkingPath?.Serialize();
		return attachment;
	}

	protected internal override void Deserialize(PlanningCenterPlan.Types.PlanItem.Types.Attachment attachment)
	{
		base.Deserialize(attachment);
		Filename = attachment.Name;
		LocalWorkingPath = new RelativePath(attachment.LinkedPath);
	}
}
