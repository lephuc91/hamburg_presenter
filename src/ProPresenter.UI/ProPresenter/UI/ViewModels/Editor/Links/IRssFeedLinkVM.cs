using System.ComponentModel;
using ProPresenter.DO.Slide.Links;

namespace ProPresenter.UI.ViewModels.Editor.Links;

public interface IRssFeedLinkVM : INotifyPropertyChanged
{
	RssFeedContentMode ContentMode { get; set; }

	string Url { get; set; }

	string? TextDelimiter { get; set; }
}
