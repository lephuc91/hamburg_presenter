using Pro.Common.Components;
using Pro.UI.Controls;
using ProPresenter.DO.Audio;

namespace ProPresenter.UI.Input;

public class AudioInputList : DragDropListBox<AudioInput>
{
	protected override IDragDropCollection<AudioInput>? SourceCollection => base.ItemsSource as IDragDropCollection<AudioInput>;

	public AudioInputList()
	{
		AddDropType<AudioInput>();
	}
}
