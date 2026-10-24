using System.Collections.Generic;
using System.ComponentModel;
using ProPresenter.DO.PanelSourcing;

namespace ProPresenter.UI.ViewModels.ProContent.Asset;

public interface IProContentPackAssetVM : IProContentAssetVM, INotifyPropertyChanged, IUniformViewSource
{
	int LoopCount { get; }

	int CountdownCount { get; }

	int StillCount { get; }

	IReadOnlyList<IProContentPackAssetContainsVM> DownloadContainsTooltip { get; }
}
