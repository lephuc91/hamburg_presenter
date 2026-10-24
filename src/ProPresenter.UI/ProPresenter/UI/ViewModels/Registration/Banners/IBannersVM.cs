using System.Collections.Generic;
using System.ComponentModel;

namespace ProPresenter.UI.ViewModels.Registration.Banners;

public interface IBannersVM : INotifyPropertyChanged
{
	IReadOnlyList<IBannerVM> Banners { get; }
}
