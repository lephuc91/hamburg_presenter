namespace Pro.Common.Components.Reversibility;

public abstract class Step
{
	protected internal abstract void Undo();

	protected internal abstract void Redo();
}
