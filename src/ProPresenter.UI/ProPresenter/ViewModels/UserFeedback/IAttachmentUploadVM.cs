using Reactive.Bindings;

namespace ProPresenter.ViewModels.UserFeedback;

public interface IAttachmentUploadVM
{
	IReadOnlyReactiveProperty<double> UploadProgress { get; }

	IReadOnlyReactiveProperty<bool> IsActive { get; }
}
