using System;
using System.Collections.Generic;
using System.Linq;

namespace ProPresenter.DO.PCO.Items;

public class PCOAttachableDetailsBase : PCODetailsBase, IPCOAttachmentsContainer
{
	private readonly List<PCOAttachmentDetails> _attachments = new List<PCOAttachmentDetails>();

	public IEnumerable<PCOAttachmentDetails> Attachments => _attachments;

	public PCOAttachableDetailsBase(string? id, DateTime? updatedAt, DateTime? created, string? url, string? pcoItemID)
		: base(id, updatedAt, created, url, pcoItemID)
	{
	}

	protected virtual void PostLoadAttachments()
	{
	}

	protected virtual void PostReplaceAttachment(PCOAttachmentDetails newAttachment)
	{
	}

	public void LoadAttachments(List<PCOAttachmentDetails> attachments)
	{
		if (attachments.Any())
		{
			_attachments.AddRange(attachments);
			PostLoadAttachments();
		}
	}

	public void ReplaceAttachment(PCOAttachmentDetails oldAttachment, PCOAttachmentDetails newAttachment)
	{
		if (oldAttachment != null && newAttachment != null)
		{
			_attachments.Remove(oldAttachment);
			_attachments.Add(newAttachment);
			PostReplaceAttachment(newAttachment);
		}
	}

	public PCOAttachmentDetails? FindAttachment(string attachmentID)
	{
		return _attachments.FirstOrDefault((PCOAttachmentDetails a) => a.ID == attachmentID);
	}
}
