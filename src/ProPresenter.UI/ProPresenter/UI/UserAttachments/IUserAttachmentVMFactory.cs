using ProPresenter.UI.ViewModels.UserAttachments;

namespace ProPresenter.UI.UserAttachments;

public interface IUserAttachmentVMFactory
{
	IUserAttachmentCollectionVM CreateUserAttachmentCollectionVM(IUserAttachSettings userAttachSettings);

	IUserAttachmentsVM CreateUserAttachmentsVM(IUserAttachmentCollectionVM attachments);

	IUserAttachment CreateUserAttachmentVM(string file, bool isReadOnly = false);
}
