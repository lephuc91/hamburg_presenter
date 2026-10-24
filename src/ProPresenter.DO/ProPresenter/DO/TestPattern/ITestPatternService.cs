using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Mathematics;
using ProPresenter.DO.TestPattern.State;
using ProPresenterCore.ProCore.Interop.SendDataHandlers;

namespace ProPresenter.DO.TestPattern;

public interface ITestPatternService : INotifyPropertyChanged, ISendDataResponseHandler
{
	IEnumerable<ITestPatternDefinition> TestPatterns { get; }

	ITestPatternState CurrentState { get; }

	ITestPatternDefinition? SelectedPattern { get; set; }

	IRelayCommand ShowPatternCommand { get; }

	IRelayCommand HidePatternCommand { get; }

	Task LoadDefinitionsAsync();

	Task LoadThumbnailsAsync();

	void SetCurrentState();

	Task GetCurrentStateAsync();

	void RenderPreview(nint texture, Vector2<int> textureSize);
}
