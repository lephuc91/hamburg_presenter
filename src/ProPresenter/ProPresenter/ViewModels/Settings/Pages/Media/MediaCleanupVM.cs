using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using ProPresenter.UI.ViewModels.Settings.Pages.Media;

namespace ProPresenter.ViewModels.Settings.Pages.Media;

public class MediaCleanupVM : ObservableObject, IMediaCleanupVM
{
	private readonly IMediaCleanupService _mediaCleanupService;

	[ObservableProperty]
	private bool _cleanupInProgress;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? cleanupCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool CleanupInProgress
	{
		get
		{
			return _cleanupInProgress;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_cleanupInProgress, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.CleanupInProgress);
				_cleanupInProgress = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.CleanupInProgress);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand CleanupCommand => cleanupCommand ?? (cleanupCommand = new AsyncRelayCommand(Cleanup));

	public MediaCleanupVM(IMediaCleanupService mediaCleanupService)
	{
		_mediaCleanupService = mediaCleanupService;
	}

	[RelayCommand]
	private async Task Cleanup()
	{
		CleanupInProgress = true;
		await _mediaCleanupService.CleanUpMediaFilesAsync();
		CleanupInProgress = false;
	}
}
