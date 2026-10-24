using System;
using System.CodeDom.Compiler;
using Pro.Common.SourceGenerator.Attributes;

namespace Pro.Common.Components.Reversibility;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { })]
public class UndoStackTransaction : IDisposable
{
	private readonly bool _autoFinalize;

	private readonly IUndoStack _undoStack;

	private readonly Action? _initialStep;

	private readonly Action? _finalStep;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public UndoStackTransaction(IUndoStack undoStack, UndoAction? pendingAction = null, Action? initialStep = null, Action? finalStep = null, bool autoFinalize = false)
	{
		_undoStack = undoStack;
		_initialStep = initialStep;
		_finalStep = finalStep;
		_autoFinalize = autoFinalize;
		_undoStack.BeginCommit(pendingAction);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			OnDispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		_undoStack.EndCommit(_initialStep, _finalStep, _autoFinalize);
	}
}
