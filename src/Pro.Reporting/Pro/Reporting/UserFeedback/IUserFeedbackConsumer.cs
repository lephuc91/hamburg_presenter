using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Pro.Common.HTTP;
using Pro.Reporting.UserFeedback.AttachmentUpload.Model;

namespace Pro.Reporting.UserFeedback;

public interface IUserFeedbackConsumer
{
	Task<IRequestResult> PostFeedbackAsync(FeedbackReport report, CancellationToken cancellationToken = default(CancellationToken), IEnumerable<UploadHeader>? additionalHeaders = null);

	Task<IRequestResult> GetFeedbackAttachmentSettingsAsync(CancellationToken cancellationToken = default(CancellationToken));

	Task<IRequestResult> PostCrashReportAsync(CrashReport report, CancellationToken cancellationToken = default(CancellationToken), IEnumerable<UploadHeader>? additionalHeaders = null);

	Task<IRequestResult> GetCrashReportAttachmentSettingsAsync(CancellationToken cancellationToken = default(CancellationToken));

	Task<IRequestResult> PostCreateAttachmentUploadAsync(AttachmentUploadRequest uploadRequest, CancellationToken cancellationToken = default(CancellationToken), IEnumerable<UploadHeader>? additionalHeaders = null);
}
