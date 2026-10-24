using Pro.Common.Components;
using Pro.UI.Controls;
using ProPresenter.DO.LiveVideo;

namespace ProPresenter.UI.Input;

public class VideoInputList : DragDropListBox<LiveVideoInput>
{
	protected override IDragDropCollection<LiveVideoInput>? SourceCollection => base.ItemsSource as IDragDropCollection<LiveVideoInput>;

	public VideoInputList()
	{
		AddDropType<LiveVideoInput>();
	}
}
