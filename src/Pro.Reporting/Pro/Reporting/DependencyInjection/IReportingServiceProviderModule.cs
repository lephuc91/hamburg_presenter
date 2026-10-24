using Jab;
using Pro.Common.ErrorReporting;
using Pro.Reporting.BugsnagInternal;
using Pro.Reporting.UserFeedback;
using Pro.Reporting.UserFeedback.AttachmentUpload;

namespace Pro.Reporting.DependencyInjection;

[Jab.ServiceProviderModule]
[Jab.Singleton<IIdProvider, BugsnagUserInfo>(Name = "BugsnagIdProviderKey")]
[Jab.Singleton<IErrorPublisher, HandledErrorReporter>]
[Jab.Transient<IUserFeedbackConsumer, UserFeedbackConsumer>]
[Jab.Singleton<IAttachmentsUploader, AttachmentsUploader>]
[Jab.Transient<IAttachmentUploadJobFactory, AttachmentUploadJobFactory>]
public interface IReportingServiceProviderModule
{
	const string BugsnagIdProviderKey = "BugsnagIdProviderKey";
}
