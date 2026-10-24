using Pro.Reporting.UserFeedback.AttachmentUpload.Model;

namespace ProPresenter.UI.UserAttachments;

public class UserAttachSettings : IUserAttachSettings
{
	public int MaxAttachments { get; }

	public long MaxAttachmentSize { get; }

	public UserAttachmentLimits AttachmentLimits { get; }

	public UserAttachSettings(AttachmentSettings settings)
	{
		AttachmentLimits = new UserAttachmentLimits(settings.AttachmentLimits);
		MaxAttachments = settings.MaxAttachments;
		MaxAttachmentSize = settings.MaxAttachmentSize;
	}
}
