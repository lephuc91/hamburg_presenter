using System.Windows;
using System.Windows.Controls;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;

namespace ProPresenter.UI.Import;

public class PlaylistTemplateSelector : DataTemplateSelector
{
	public override DataTemplate SelectTemplate(object item, DependencyObject container)
	{
		if (!(item is IPlaylist<ProPresenterCue>))
		{
			return base.SelectTemplate(item, container);
		}
		return (DataTemplate)((FrameworkElement)(object)container).FindResource("PlaylistTemplate");
	}
}
