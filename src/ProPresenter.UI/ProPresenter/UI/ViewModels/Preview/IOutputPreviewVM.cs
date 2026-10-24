using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pro.UI.Controls;

namespace ProPresenter.UI.ViewModels.Preview;

public interface IOutputPreviewVM : INotifyPropertyChanged
{
	double AspectRatio { get; set; }

	bool IsLegacyRenderMode { get; }

	IRelayCommand<RequestRenderParameter> RequestRenderCommand { get; }

	nint LoadPreview(nint hostHandle);

	void UnloadPreview(nint renderViewHandle);
}
