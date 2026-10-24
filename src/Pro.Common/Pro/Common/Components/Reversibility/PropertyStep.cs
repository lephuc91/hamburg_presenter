using Pro.Common.Reflection;

namespace Pro.Common.Components.Reversibility;

public class PropertyStep : Step
{
	public object TargetObject { get; }

	public string TargetProperty { get; }

	public object? UndoValue { get; }

	public object? RedoValue { get; }

	public PropertyStep(object targetObject, string targetProperty, object? undoValue, object? redoValue)
	{
		TargetObject = targetObject;
		TargetProperty = targetProperty;
		UndoValue = undoValue;
		RedoValue = redoValue;
	}

	protected internal override void Undo()
	{
		SetValue(UndoValue);
	}

	protected internal override void Redo()
	{
		SetValue(RedoValue);
	}

	private void SetValue(object? value)
	{
		PropertySetterCache.GetSetter(TargetObject.GetType(), TargetProperty)?.Invoke(TargetObject, value);
	}
}
