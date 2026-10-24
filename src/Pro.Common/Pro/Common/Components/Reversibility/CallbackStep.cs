using System;

namespace Pro.Common.Components.Reversibility;

public class CallbackStep : Step
{
	private Action _undoCallback;

	private Action _redoCallback;

	public CallbackStep(Action undoCallback, Action redoCallback)
	{
		_undoCallback = undoCallback;
		_redoCallback = redoCallback;
	}

	protected internal override void Undo()
	{
		_undoCallback();
	}

	protected internal override void Redo()
	{
		_redoCallback();
	}
}
