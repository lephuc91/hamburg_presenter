using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.UI.Components;

namespace ProPresenter.UI.CueInspector;

public partial class PlaybackScrubberContextMenuSource : FrameworkCollection, IComponentConnector
{
	public static readonly DependencyProperty AddPlaybackMarkerCommandProperty = DependencyProperty.Register("AddPlaybackMarkerCommand", typeof(ICommand), typeof(PlaybackScrubberContextMenuSource));

	public ICommand? AddPlaybackMarkerCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(AddPlaybackMarkerCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AddPlaybackMarkerCommandProperty, (object)value);
		}
	}

	public PlaybackScrubberContextMenuSource()
	{
		InitializeComponent();
	}
}
