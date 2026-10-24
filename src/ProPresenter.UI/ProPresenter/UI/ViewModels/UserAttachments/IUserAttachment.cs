using System;
using System.Collections.Generic;
using Pro.Reporting.UserFeedback.AttachmentUpload.Model;
using ProPresenter.UI.UserAttachments;

namespace ProPresenter.UI.ViewModels.UserAttachments;

public interface IUserAttachment : IEquatable<IUserAttachment>
{
	string Identifier { get; set; }

	string FileName { get; }

	string Extension { get; }

	string FileNameShort { get; }

	string DisplayName { get; }

	bool IsReadOnly { get; set; }

	bool IsValid { get; }

	string ViewUrl { get; set; }

	string UploadUrl { get; set; }

	bool IsUploaded { get; set; }

	long FileSize { get; }

	string FileShaHash { get; }

	IReadOnlyList<UploadHeader> UploadHeaders { get; set; }

	bool Exists { get; }

	bool IsReadyToSend { get; }

	bool Validate(IUserAttachSettings userAttachSettings);

	Attachment ToFileAttachment();
}
