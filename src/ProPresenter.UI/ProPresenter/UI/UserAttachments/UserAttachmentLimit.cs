using Pro.Reporting.UserFeedback.AttachmentUpload.Model;

namespace ProPresenter.UI.UserAttachments;

public class UserAttachmentLimit
{
	public string Extension { get; }

	public long SizeLimit { get; }

	public int MaxQuantity { get; }

	public UserAttachmentLimit(AttachmentLimit limit)
	{
		Extension = limit.Extension;
		SizeLimit = limit.SizeLimit;
		MaxQuantity = limit.MaxQuantity;
	}
}
