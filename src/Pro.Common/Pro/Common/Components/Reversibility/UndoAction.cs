using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;

namespace Pro.Common.Components.Reversibility;

public class UndoAction
{
	public bool IsFinalized { get; private set; }

	public Step[] Steps { get; private set; } = Array.Empty<Step>();

	public Action? InitialStep { get; private set; }

	public Action? FinalStep { get; private set; }

	public void FinalizeAction()
	{
		IsFinalized = true;
	}

	protected internal void SetupAction(IEnumerable<Step> steps, Action? initialStep, Action? finalStep)
	{
		if (IsFinalized)
		{
			throw new InvalidOperationException("Action is finalized");
		}
		Steps = steps.ToArray();
		InitialStep = initialStep;
		FinalStep = finalStep;
	}

	internal void Undo()
	{
		if (Steps == null)
		{
			throw new InvalidOperationException("Action's steps were never setup");
		}
		InitialStep?.Invoke();
		Steps.Reverse().ForEach(delegate(Step s)
		{
			s.Undo();
		});
		FinalStep?.Invoke();
	}

	internal void Redo()
	{
		if (Steps == null)
		{
			throw new InvalidOperationException("Action's steps were never setup");
		}
		InitialStep?.Invoke();
		Steps.ForEach(delegate(Step s)
		{
			s.Redo();
		});
		FinalStep?.Invoke();
	}

	protected internal virtual bool CanMerge(UndoAction otherAction)
	{
		return false;
	}

	protected internal virtual void Merge(UndoAction otherAction)
	{
	}
}
