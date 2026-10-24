using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Pro.Common.Mathematics;
using Pro.UI.Components;
using ProPresenter.DO;
using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.UI.ViewModels;

public interface ISizeSelectorVM : INotifyPropertyChanged
{
	ISizeableTarget? Target { get; set; }

	Vector2<double> SelectedSize { get; }

	bool SizeIsConfigured { get; }

	ScreenArrangementCollectionBase TargetScreens { get; }

	IEnumerable<Vector2<double>> CommonSizes { get; }

	Vector2<double>? CustomSize { get; set; }

	bool SetTargetToDefaultSize { get; set; }

	ICommand<Vector2<double>> SelectSizeCommand { get; }

	ICommand CustomSizeCommand { get; }

	ICommand ResizeToScreenCommand { get; }

	Func<Vector2<double>, bool>? ConfirmResize { get; set; }

	ScreenTargetType ScreenTargetType { get; set; }
}
