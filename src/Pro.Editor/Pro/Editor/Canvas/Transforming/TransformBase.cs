using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Pro.Common.Components;
using Pro.Common.Mathematics;
using Pro.Editor.Canvas.Snapping;

namespace Pro.Editor.Canvas.Transforming;

public abstract class TransformBase : NotifyPropertyChangedBase, ITransform, ITooltipDataSource, INotifyPropertyChanged
{
	private string _tooltipLabel = string.Empty;

	protected IEnumerable<ICanvasElement> Elements { get; private set; } = Enumerable.Empty<ICanvasElement>();

	protected SnapController? SnapController { get; private set; }

	public string TooltipLabel
	{
		get
		{
			return _tooltipLabel;
		}
		protected set
		{
			if (_tooltipLabel != value)
			{
				_tooltipLabel = value;
				OnPropertyChanged("TooltipLabel");
			}
		}
	}

	public virtual void StartTransform(IEnumerable<ICanvasElement> elements, SnapController snapController)
	{
		Elements = elements.Where((ICanvasElement e) => !e.IsLocked);
		SnapController = snapController;
		SnapController.IgnoreElements(elements);
	}

	public abstract void TransformElements(Vector2<double> startPoint, Vector2<double> lastPoint, Vector2<double> currentPoint, ModifierKeys modifierKeys);

	public virtual void CompleteTransform()
	{
		SnapController?.ClearResults();
		SnapController?.UnignoreElements();
	}
}
