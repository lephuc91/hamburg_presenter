using System.Reactive.Linq;
using Pro.Reporting.UserFeedback.AttachmentUpload;
using Reactive.Bindings;

namespace ProPresenter.ViewModels.UserFeedback;

public class AttachmentUploadVM : IAttachmentUploadVM
{
	public IReadOnlyReactiveProperty<double> UploadProgress { get; }

	public IReadOnlyReactiveProperty<bool> IsActive { get; }

	public AttachmentUploadVM(IAttachmentsUploader attachmentsUploader)
	{
		UploadProgress = attachmentsUploader.WhenUploadProgressChanges.Select(TransformProgress).ToReadOnlyReactivePropertySlim(0.0);
		IsActive = attachmentsUploader.WhenUploadProgressChanges.Select(IsBusyUploading).ToReadOnlyReactivePropertySlim(initialValue: false);
	}

	private static double TransformProgress(UploadProgress progress)
	{
		if (progress.TotalBytes <= 0)
		{
			return 0.0;
		}
		return (double)progress.BytesUploaded * 100.0 / (double)progress.TotalBytes;
	}

	private static bool IsBusyUploading(UploadProgress progress)
	{
		return progress.TotalBytes > 0;
	}
}
