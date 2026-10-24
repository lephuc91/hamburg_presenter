using System;
using System.Collections.Generic;
using System.Windows.Media;
using CommunityToolkit.Mvvm.Input;
using Pro.UI.Controls.Windowing;

namespace ProPresenter.UI.ViewModels.WhatsNew;

public interface IWhatsNewV2VM
{
	Version? Version { get; }

	Color AccentColor { get; set; }

	IEnumerable<IFeatureItemVM> Features { get; set; }

	IRelayCommand GotoLinkCommand { get; }

	IRelayCommand<ICloseable> GetStartedCommand { get; }

	bool ShouldAutoShowWhatsNew { get; }
}
