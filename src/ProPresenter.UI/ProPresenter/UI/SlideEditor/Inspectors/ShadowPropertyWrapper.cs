using System.Collections;
using Pro.Common.Components.Reversibility;
using Pro.Common.Utility;
using ProPresenter.DO;
using ProPresenter.DO.Slide.Custom.Elements;

namespace ProPresenter.UI.SlideEditor.Inspectors;

public class ShadowPropertyWrapper : CollectionPropertyWrapperBase<BezierPath, ShadowType, IShadow>
{
	public UndoStack? UndoStack { get; set; }

	public ShadowPropertyWrapper(IEnumerable elements)
		: base(elements)
	{
	}

	protected override IShadow GenerateValue(ShadowType type)
	{
		return type.GenerateShadow();
	}

	protected override IShadow GetValue(BezierPath item)
	{
		return item.Shadow;
	}

	protected override ShadowType GetValueType(BezierPath item)
	{
		return item.Shadow?.Type ?? ShadowType.Drop;
	}

	protected override void SetValue(BezierPath item, IShadow value)
	{
		item.Shadow = value;
	}

	protected override void StartPropertyChanged(ShadowType valueType, string propertyName)
	{
		if (valueType == ShadowType.Drop)
		{
			switch (propertyName)
			{
			case "BlurRadius":
				UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ElementShadowBlurRadius));
				break;
			case "Offset":
				UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ElementShadowOffset));
				break;
			case "Opacity":
				UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ElementShadowOpacity));
				break;
			case "Angle":
				UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ElementShadowAngle));
				break;
			case "Color":
				UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ElementShadowColor));
				break;
			}
		}
	}

	protected override void EndPropertyChanged(ShadowType valueType, string propertyName)
	{
		UndoStack? undoStack = UndoStack;
		if (undoStack != null && undoStack.IsRecording)
		{
			UndoStack.EndCommit();
		}
	}
}
