using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProPresenter.UI.ViewModels.Settings.Pages.Updates;

namespace ProPresenter.ViewModels.Settings.Pages.Updates;

public class AvailableUpdateVM : ObservableObject, IAvailableUpdateVM, INotifyPropertyChanged
{
	private readonly Action _buttonAction;

	private readonly Action _showReleaseNotes;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? buttonCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? showReleaseNotesCommand;

	public string Title { get; }

	public string Version { get; }

	public string ButtonName { get; }

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand ButtonCommand => buttonCommand ?? (buttonCommand = new RelayCommand(Button));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand ShowReleaseNotesCommand => showReleaseNotesCommand ?? (showReleaseNotesCommand = new RelayCommand(ShowReleaseNotes));

	public AvailableUpdateVM(string title, string version, string buttonName, Action buttonAction, Action showReleaseNotes)
	{
		Title = title;
		Version = version;
		ButtonName = buttonName;
		_buttonAction = buttonAction;
		_showReleaseNotes = showReleaseNotes;
	}

	[RelayCommand]
	private void Button()
	{
		_buttonAction();
	}

	[RelayCommand]
	private void ShowReleaseNotes()
	{
		_showReleaseNotes();
	}
}
