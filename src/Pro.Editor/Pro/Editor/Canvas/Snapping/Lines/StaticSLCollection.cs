using System;
using System.Collections.Generic;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;

namespace Pro.Editor.Canvas.Snapping.Lines;

public class StaticSLCollection : ImmutableObservableCollection<StaticSL>
{
	public UndoStack? UndoStack { get; set; }

	public event Action? GuidelinesInvalidated;

	public void AddStaticSLs(IEnumerable<StaticSL> guidelines)
	{
		OnAddStaticSLs(guidelines);
	}

	public void RemoveStaticSLs(IReadOnlyList<StaticSL> guidelines)
	{
		OnRemoveStaticSLs(guidelines);
	}

	public void AddStaticSL(StaticSL guideline)
	{
		AddStaticSLs(new global::_003C_003Ez__ReadOnlySingleElementList<StaticSL>(guideline));
	}

	public void RemoveStaticSL(StaticSL guideline)
	{
		RemoveStaticSLs(new global::_003C_003Ez__ReadOnlySingleElementList<StaticSL>(guideline));
	}

	protected internal virtual void OnDragStart(IEnumerable<StaticSL> guidelines)
	{
	}

	protected internal virtual void OnDragEnd(IEnumerable<StaticSL> guidelines)
	{
	}

	protected virtual void OnAddStaticSLs(IEnumerable<StaticSL> guidelines)
	{
		base.Collection.AddRange(guidelines);
	}

	protected virtual void OnRemoveStaticSLs(IReadOnlyList<StaticSL> guidelines)
	{
		base.Collection.RemoveRange(guidelines);
	}

	protected void OnGuidelinesInvalidated()
	{
		this.GuidelinesInvalidated?.Invoke();
	}
}
