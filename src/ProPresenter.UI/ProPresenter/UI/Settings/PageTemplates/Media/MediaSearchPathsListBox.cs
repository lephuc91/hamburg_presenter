using Pro.Common.Components;
using Pro.UI.Controls;
using ProPresenter.UI.ViewModels.Settings.Pages.Media;

namespace ProPresenter.UI.Settings.PageTemplates.Media;

public class MediaSearchPathsListBox : DragDropItemsControl<IMediaSearchRootVM, MediaSearchPathItemTemplate>
{
	protected override IDragDropCollection<IMediaSearchRootVM>? SourceCollection => base.ItemsSource as IDragDropCollection<IMediaSearchRootVM>;

	public MediaSearchPathsListBox()
	{
		AddDropType<IMediaSearchRootVM>();
	}
}
