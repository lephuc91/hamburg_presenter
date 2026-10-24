using System.Collections.Generic;

namespace ProPresenter.DO.PCO.Items;

internal interface IPCOAttachmentsContainer
{
	void LoadAttachments(List<PCOAttachmentDetails> attachments);
}
