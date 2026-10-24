using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Logging;

namespace Pro.Common.Components.Reversibility;

public class UndoStack : NotifyPropertyChangedBase, IUndoStack
{
	private readonly Stack<UndoAction> _undoStack = new Stack<UndoAction>();

	private readonly Stack<UndoAction> _redoStack = new Stack<UndoAction>();

	private readonly List<Step> _recordedSteps = new List<Step>();

	private uint _commitStackLevel;

	private uint _ignoreCommitLevel;

	private UndoAction? _pendingAction;

	private Action? _stagedUndoAction;

	private Action? _stagedRedoAction;

	private List<StagedProperty>? _stagedProperties;

	public bool CanUndo => _undoStack.Any();

	public bool CanRedo => _redoStack.Any();

	public UndoAction? NextUndoAction
	{
		get
		{
			if (!CanUndo)
			{
				return null;
			}
			return _undoStack.Peek();
		}
	}

	public UndoAction? NextRedoAction
	{
		get
		{
			if (!CanRedo)
			{
				return null;
			}
			return _redoStack.Peek();
		}
	}

	public bool IgnoreCommits => _ignoreCommitLevel != 0;

	public bool IsRecording => _commitStackLevel != 0;

	public static event Action<Enum?>? Undoing;

	public static event Action<Enum?>? Redoing;

	public static event Action<Enum?>? Doing;

	public void Undo()
	{
		if (CanUndo)
		{
			FinalizeNextAction();
			UndoAction undoAction = _undoStack.Pop();
			UndoStack.Undoing?.Invoke(undoAction.GetType().GetProperty("Tag")?.GetValue(undoAction) as Enum);
			StartIgnoring();
			undoAction.Undo();
			_redoStack.Push(undoAction);
			RaiseStackChanges();
			StopIgnoring();
		}
	}

	public void Redo()
	{
		if (CanRedo)
		{
			FinalizeNextAction();
			UndoAction undoAction = _redoStack.Pop();
			UndoStack.Redoing?.Invoke(undoAction.GetType().GetProperty("Tag")?.GetValue(undoAction) as Enum);
			StartIgnoring();
			undoAction.Redo();
			_undoStack.Push(undoAction);
			RaiseStackChanges();
			StopIgnoring();
		}
	}

	public void StartIgnoring()
	{
		_ignoreCommitLevel++;
	}

	public void StopIgnoring()
	{
		if (!IgnoreCommits)
		{
			throw new InvalidOperationException("Not currently ignoring commits");
		}
		_ignoreCommitLevel--;
	}

	public void Clear()
	{
		_undoStack.Clear();
		_redoStack.Clear();
		RaiseStackChanges();
	}

	public void Commit(Action undoAction, Action redoAction, Action? initialStep = null, Action? finalStep = null, bool autoFinalize = false)
	{
		BeginCommit();
		Commit(undoAction, redoAction);
		EndCommit(initialStep, finalStep, autoFinalize);
	}

	public void Commit(UndoAction action, Action undoAction, Action redoAction, Action? initialStep = null, Action? finalStep = null, bool autoFinalize = false)
	{
		Commit(action, new CallbackStep(undoAction, redoAction), initialStep, finalStep, autoFinalize);
	}

	public void Commit(UndoAction action, Step step, Action? initialStep = null, Action? finalStep = null, bool autoFinalize = false)
	{
		BeginCommit(action);
		Commit(step);
		EndCommit(initialStep, finalStep, autoFinalize);
	}

	public void Commit(UndoAction action, object targetObject, string targetProperty, object? undoValue, object? redoValue, Action? initialStep = null, Action? finalStep = null, bool autoFinalize = false)
	{
		BeginCommit(action);
		Commit(targetObject, targetProperty, undoValue, redoValue);
		EndCommit(initialStep, finalStep, autoFinalize);
	}

	public void Commit(object targetObject, string targetProperty, object? undoValue, object? redoValue)
	{
		Commit(new PropertyStep(targetObject, targetProperty, undoValue, redoValue));
	}

	public void Commit(Action undoAction, Action redoAction)
	{
		Commit(new CallbackStep(undoAction, redoAction));
	}

	public void Commit(Step step)
	{
		if (!IgnoreCommits)
		{
			if (!IsRecording)
			{
				throw new InvalidOperationException("Stack must be recording to commit step");
			}
			if (_stagedUndoAction != null || _stagedRedoAction != null || _stagedProperties != null)
			{
				throw new InvalidOperationException("Last step was not finished");
			}
			_recordedSteps.Add(step);
		}
	}

	public void CommitUndo(Action undoAction)
	{
		if (!IgnoreCommits)
		{
			if (!IsRecording)
			{
				throw new InvalidOperationException("Stack must be recording to commit undo action");
			}
			if (_stagedUndoAction != null)
			{
				throw new InvalidOperationException("An undo action has already been committed");
			}
			if (_stagedProperties != null)
			{
				throw new InvalidOperationException("Last step was not finished");
			}
			_stagedUndoAction = undoAction;
			TryCommitCallback();
		}
	}

	public void CommitUndo(object targetObject, string targetProperty, object undoValue)
	{
		if (!IgnoreCommits)
		{
			if (!IsRecording)
			{
				throw new InvalidOperationException("Stack must be recording to commit undo action");
			}
			if (_stagedUndoAction != null || _stagedRedoAction != null)
			{
				throw new InvalidOperationException("Last step was not finished");
			}
			StagedProperty stagedProperty = GetStagedProperty(targetObject, targetProperty);
			if (stagedProperty.HasUndoValue)
			{
				throw new InvalidOperationException("Property undo value already assigned");
			}
			stagedProperty.SetUndoValue(undoValue);
			TryCommitProperties();
		}
	}

	public void CommitRedo(Action redoAction)
	{
		if (!IgnoreCommits)
		{
			if (!IsRecording)
			{
				throw new InvalidOperationException("Stack must be recording to commit redo action");
			}
			if (_stagedRedoAction != null)
			{
				throw new InvalidOperationException("A redo action has already been committed");
			}
			if (_stagedProperties != null)
			{
				throw new InvalidOperationException("Last step was not finished");
			}
			_stagedRedoAction = redoAction;
			TryCommitCallback();
		}
	}

	public void CommitRedo(object targetObject, string targetProperty, object redoValue)
	{
		if (!IgnoreCommits)
		{
			if (!IsRecording)
			{
				throw new InvalidOperationException("Stack must be recording to commit redo action");
			}
			if (_stagedUndoAction != null || _stagedRedoAction != null)
			{
				throw new InvalidOperationException("Last step was not finished");
			}
			StagedProperty stagedProperty = GetStagedProperty(targetObject, targetProperty);
			if (stagedProperty.HasRedoValue)
			{
				throw new InvalidOperationException("Property redo value already assigned");
			}
			stagedProperty.SetRedoValue(redoValue);
			TryCommitProperties();
		}
	}

	private void TryCommitCallback()
	{
		if (_stagedUndoAction != null && _stagedRedoAction != null)
		{
			_recordedSteps.Add(new CallbackStep(_stagedUndoAction, _stagedRedoAction));
			_stagedUndoAction = null;
			_stagedRedoAction = null;
		}
	}

	private StagedProperty GetStagedProperty(object targetObject, string targetProperty)
	{
		if (_stagedProperties == null)
		{
			_stagedProperties = new List<StagedProperty>();
		}
		StagedProperty stagedProperty = _stagedProperties.FirstOrDefault((StagedProperty p) => p.TargetObject == targetObject && p.TargetProperty == targetProperty);
		if (stagedProperty == null)
		{
			stagedProperty = new StagedProperty(targetObject, targetProperty);
			_stagedProperties.Add(stagedProperty);
		}
		return stagedProperty;
	}

	private void TryCommitProperties()
	{
		if (_stagedProperties == null || !_stagedProperties.All((StagedProperty p) => p.HasUndoValue && p.HasRedoValue))
		{
			return;
		}
		foreach (StagedProperty stagedProperty in _stagedProperties)
		{
			_recordedSteps.Add(new PropertyStep(stagedProperty.TargetObject, stagedProperty.TargetProperty, stagedProperty.UndoValue, stagedProperty.RedoValue));
		}
		_stagedProperties = null;
	}

	public void BeginCommit(UndoAction? pendingAction = null)
	{
		if (!IgnoreCommits)
		{
			if (_stagedUndoAction != null || _stagedRedoAction != null || _stagedProperties != null)
			{
				throw new InvalidOperationException("Last step was not finished");
			}
			if (!IsRecording)
			{
				_pendingAction = pendingAction ?? new UndoAction();
			}
			_commitStackLevel++;
		}
	}

	public void EndCommit(Action? initialStep = null, Action? finalStep = null, bool autoFinalize = false)
	{
		if (IgnoreCommits)
		{
			return;
		}
		if (!IsRecording)
		{
			Log.Error($"{"Stack has not started recording."} IsRecording: {IsRecording},  CommitStackLevel: {_commitStackLevel}");
			return;
		}
		if (_stagedUndoAction != null || _stagedRedoAction != null || _stagedProperties != null)
		{
			throw new InvalidOperationException("Last step was not finished");
		}
		if (_pendingAction == null)
		{
			return;
		}
		if (_commitStackLevel == 1)
		{
			_redoStack.Clear();
			_pendingAction.SetupAction(_recordedSteps, initialStep, finalStep);
			UndoAction nextUndoAction = NextUndoAction;
			if (nextUndoAction != null && !nextUndoAction.IsFinalized && !_pendingAction.IsFinalized && nextUndoAction.CanMerge(_pendingAction))
			{
				nextUndoAction.Merge(_pendingAction);
				if (nextUndoAction.Steps.Empty())
				{
					_undoStack.Pop();
				}
				if (autoFinalize)
				{
					FinalizeNextAction();
				}
			}
			else
			{
				_undoStack.Push(_pendingAction);
				if (autoFinalize)
				{
					_pendingAction.FinalizeAction();
				}
				UndoStack.Doing?.Invoke(_pendingAction.GetType().GetProperty("Tag")?.GetValue(_pendingAction) as Enum);
			}
			_pendingAction = null;
			_recordedSteps.Clear();
			RaiseStackChanges();
		}
		_commitStackLevel--;
	}

	public void FinalizeNextAction()
	{
		NextUndoAction?.FinalizeAction();
	}

	private void RaiseStackChanges()
	{
		OnPropertyChanged("CanUndo");
		OnPropertyChanged("CanRedo");
		OnPropertyChanged("NextUndoAction");
		OnPropertyChanged("NextRedoAction");
	}

	public IDisposable Transaction(UndoAction? pendingAction = null, Action? initialStep = null, Action? finalStep = null, bool autoFinalize = false)
	{
		return new UndoStackTransaction(this, pendingAction, initialStep, finalStep, autoFinalize);
	}
}
