namespace Pro.Common.Components.Reversibility;

internal class StagedProperty
{
	public object TargetObject { get; }

	public string TargetProperty { get; }

	public object? UndoValue { get; private set; }

	public object? RedoValue { get; private set; }

	public bool HasUndoValue { get; private set; }

	public bool HasRedoValue { get; private set; }

	public StagedProperty(object targetObject, string targetProperty)
	{
		TargetObject = targetObject;
		TargetProperty = targetProperty;
	}

	public void SetUndoValue(object value)
	{
		UndoValue = value;
		HasUndoValue = true;
	}

	public void SetRedoValue(object value)
	{
		RedoValue = value;
		HasRedoValue = true;
	}
}
