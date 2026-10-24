using System;
using System.ComponentModel;

namespace Pro.Common.Components.Reversibility;

public interface IUndoStack
{
	bool CanUndo { get; }

	bool CanRedo { get; }

	UndoAction? NextUndoAction { get; }

	UndoAction? NextRedoAction { get; }

	bool IgnoreCommits { get; }

	bool IsRecording { get; }

	event PropertyChangedEventHandler? PropertyChanged;

	void Undo();

	void Redo();

	void StartIgnoring();

	void StopIgnoring();

	void Clear();

	void Commit(Action undoAction, Action redoAction, Action? initialStep = null, Action? finalStep = null, bool autoFinalize = false);

	void Commit(UndoAction action, Action undoAction, Action redoAction, Action? initialStep = null, Action? finalStep = null, bool autoFinalize = false);

	void Commit(UndoAction action, Step step, Action? initialStep = null, Action? finalStep = null, bool autoFinalize = false);

	void Commit(UndoAction action, object targetObject, string targetProperty, object? undoValue, object? redoValue, Action? initialStep = null, Action? finalStep = null, bool autoFinalize = false);

	void Commit(object targetObject, string targetProperty, object? undoValue, object? redoValue);

	void Commit(Action undoAction, Action redoAction);

	void Commit(Step step);

	void CommitUndo(Action undoAction);

	void CommitUndo(object targetObject, string targetProperty, object undoValue);

	void CommitRedo(Action redoAction);

	void CommitRedo(object targetObject, string targetProperty, object redoValue);

	void BeginCommit(UndoAction? pendingAction = null);

	void EndCommit(Action? initialStep = null, Action? finalStep = null, bool autoFinalize = false);

	void FinalizeNextAction();

	IDisposable Transaction(UndoAction? pendingAction = null, Action? initialStep = null, Action? finalStep = null, bool autoFinalize = false);
}
