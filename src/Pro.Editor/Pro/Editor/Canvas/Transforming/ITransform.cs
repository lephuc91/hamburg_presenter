using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Pro.Common.Mathematics;
using Pro.Editor.Canvas.Snapping;

namespace Pro.Editor.Canvas.Transforming;

public interface ITransform : ITooltipDataSource, INotifyPropertyChanged
{
	void StartTransform(IEnumerable<ICanvasElement> elements, SnapController snapController);

	void TransformElements(Vector2<double> startPoint, Vector2<double> lastPoint, Vector2<double> currentPoint, ModifierKeys modifierKeys);

	void CompleteTransform();
}
