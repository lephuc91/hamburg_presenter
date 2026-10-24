using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Collections;
using Pro.DO.Storage;
using Pro.UI.Components;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.TestPattern.State;

namespace ProPresenter.UI.ViewModels.TestPattern;

public interface ITestPatternStateVM : INotifyPropertyChanged
{
	DisplayLocation DisplayLocation { get; set; }

	Guid SpecificScreen { get; set; }

	bool IdentifyScreens { get; set; }

	LogoType LogoType { get; set; }

	bool CanDeselectLogo { get; }

	RelativePath? UserLogoLocation
	{
		get; [param: DisallowNull]
		set;
	}

	INotifyEnumerableChanged<ScreenArrangementBase> AudienceScreens { get; }

	INotifyEnumerableChanged<ScreenArrangementBase> StageScreens { get; }

	ScreenArrangementBase? TargetScreen { get; }

	IRelayCommand ShowPatternCommand { get; }

	IRelayCommand HidePatternCommand { get; }

	ICommand<DisplayLocation> SelectDisplayLocationCommand { get; }

	ICommand<ScreenArrangementBase> SelectScreenCommand { get; }

	ICommand<LogoType> SelectLogoTypeCommand { get; }

	ICommand<RelativePath> SelectCustomLogoCommand { get; }

	void SetState(ITestPatternState state);
}
