using System.Collections.Generic;
using System.Linq;
using Pro.Reporting.UserFeedback.AttachmentUpload.Model;

namespace ProPresenter.UI.UserAttachments;

public class UserAttachmentLimits : List<UserAttachmentLimit>
{
	public UserAttachmentLimits(IEnumerable<AttachmentLimit> attachmentLimits)
		: base(attachmentLimits.Select((AttachmentLimit a) => new UserAttachmentLimit(a)))
	{
	}
}
