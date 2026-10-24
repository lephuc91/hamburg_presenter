using System.Windows.Input;
using Pro.Common.Components;
using Pro.Text;
using Pro.UI.Components;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Slide.Custom.Elements;

namespace ProPresenter.UI.ViewModels;

public class OverlayEditorVM : LinkedNotifyPropertyChangedBase
{
	private bool _show;

	private ClosedBezierPath? _element;

	private double _zoomFactor = EditorPreferences.Settings.OverlayEditorZoomFactor;

	private Range[]? _selectionRanges;

	private int _caretIndex;

	private RunSettings? _activeRunSettings;

	public bool Show
	{
		get
		{
			return _show;
		}
		private set
		{
			SetValue("Show", ref _show, value);
		}
	}

	public double ZoomFactor
	{
		get
		{
			return _zoomFactor;
		}
		set
		{
			SetValue("ZoomFactor", ref _zoomFactor, value, delegate(double _, double n)
			{
				EditorPreferences.Settings.OverlayEditorZoomFactor = n;
			});
		}
	}

	public Range[]? SelectionRanges
	{
		get
		{
			return _selectionRanges;
		}
		set
		{
			SetValue("SelectionRanges", ref _selectionRanges, value);
		}
	}

	public int CaretIndex
	{
		get
		{
			return _caretIndex;
		}
		set
		{
			SetValue("CaretIndex", ref _caretIndex, value);
		}
	}

	public RunSettings? ActiveRunSettings
	{
		get
		{
			return _activeRunSettings;
		}
		set
		{
			SetValue("ActiveRunSettings", ref _activeRunSettings, value);
		}
	}

	public string? Name => Element?.Name;

	public TextDocument? Text => Element?.Text;

	public ClosedBezierPath? Element
	{
		get
		{
			return _element;
		}
		set
		{
			SetValue<ClosedBezierPath>("Element", ref _element, value, delegate(ClosedBezierPath o, ClosedBezierPath n)
			{
				if (o != null)
				{
					o.PropertyChanged -= base.RaiseLinkedValues;
				}
				if (n != null)
				{
					n.PropertyChanged += base.RaiseLinkedValues;
				}
				Show = n != null;
				OnPropertyChanged("Name");
				OnPropertyChanged("Text");
			});
		}
	}

	public ICommand DoneCommand => new RelayCommand(delegate
	{
		Close(OverlayCloseSource.CloseButton);
	});

	public ICommand EscapeCommand => new RelayCommand(delegate
	{
		Close(OverlayCloseSource.EscapeKey);
	});

	public OverlayEditorVM()
	{
		LinkProperties("Name", "Name");
	}

	private void Close(OverlayCloseSource source)
	{
		OverlayClosedEvent.Publish(source);
		Element = null;
	}
}
