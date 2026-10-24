namespace ProPresenter.UI.UserAttachments;

public interface IUserAttachSettings
{
	int MaxAttachments { get; }

	long MaxAttachmentSize { get; }

	UserAttachmentLimits AttachmentLimits { get; }
}
