using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pro.Reporting.UserFeedback.AttachmentUpload.Model;

namespace ProPresenter.UI.ViewModels.UserAttachments;

public interface IUserAttachmentCollectionVM : IEnumerable<IUserAttachment>, IEnumerable
{
	Task AddAsync(string fileName);

	Task AddAsync(IReadOnlyList<string> fileNames);

	void Add(IUserAttachment attachment);

	void Add(IEnumerable<IUserAttachment> attachments);

	void Remove(IUserAttachment attachment);

	List<Attachment> ToFileAttachments();
}
