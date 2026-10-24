using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using ProPresenter.DO.LiveVideo;
using ProPresenter.DO.Slide.Links;

namespace ProPresenter.UI.SlideEditor.Inspectors.Links;

public partial class VisibilityVideoInputSelector : UserControl, IComponentConnector, IStyleConnector
{
	public static readonly DependencyProperty VideoInputIndexProperty = DependencyProperty.Register("VideoInputIndex", typeof(int), typeof(VisibilityVideoInputSelector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnVideoInputIndexChanged)));

	private static readonly DependencyProperty VideoInputNameProperty = DependencyProperty.Register("VideoInputName", typeof(string), typeof(VisibilityVideoInputSelector));

	public static readonly DependencyProperty AvailableLiveVideoInputsProperty = DependencyProperty.Register("AvailableLiveVideoInputs", typeof(LiveVideoInputCollection), typeof(VisibilityVideoInputSelector));

	public int VideoInputIndex
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(VideoInputIndexProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(VideoInputIndexProperty, (object)value);
		}
	}

	private string VideoInputName
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(VideoInputNameProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(VideoInputNameProperty, (object)value);
		}
	}

	public LiveVideoInputCollection? AvailableLiveVideoInputs
	{
		get
		{
			return (LiveVideoInputCollection)((DependencyObject)this).GetValue(AvailableLiveVideoInputsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AvailableLiveVideoInputsProperty, (object)value);
		}
	}

	private static void OnVideoInputIndexChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		(d as VisibilityVideoInputSelector)?.UpdateVideoIname();
	}

	public VisibilityVideoInputSelector()
	{
		InitializeComponent();
	}

	private void SelectInput_Click(object? sender, RoutedEventArgs e)
	{
		if (sender is MenuItem { DataContext: LiveVideoInput dataContext } && base.DataContext is VisibilityCondition { LinkedObject: VideoInputLinkedVisibilityObject linkedObject })
		{
			linkedObject.VideoInputIndex = dataContext.Index;
		}
	}

	private void UpdateVideoIname()
	{
		string text = AvailableLiveVideoInputs?.FirstOrDefault((LiveVideoInput n) => n.Index == VideoInputIndex)?.LongName ?? string.Empty;
		((DependencyObject)this).SetCurrentValue(VideoInputNameProperty, (object)text);
	}
}
