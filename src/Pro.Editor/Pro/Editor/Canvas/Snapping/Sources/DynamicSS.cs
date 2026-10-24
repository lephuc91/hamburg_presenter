using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Mathematics;

namespace Pro.Editor.Canvas.Snapping.Sources;

public abstract class DynamicSS<T> : ISnappingSource where T : IProjectedLine
{
	private ICanvasElement[]? _lastSourceElements;

	private IEnumerable<ICanvasElement>? _ignoredElements;

	private List<ICanvasElement> _updatedElements = new List<ICanvasElement>();

	public abstract DynamicSSType Type { get; }

	public Rect<double> Bounds => Rect<double>.Empty;

	public ImmutableObservableCollection<ICanvasElement> SourceElements { get; }

	public IEnumerable<ICanvasElement> Elements => SourceElements.Where((ICanvasElement e) => e.IsSnappingSource);

	public IEnumerable<ICanvasElement> IgnoredElements => _ignoredElements ?? Enumerable.Empty<ICanvasElement>();

	protected List<T> VerticalLines { get; } = new List<T>();

	protected List<T> HorizontalLines { get; } = new List<T>();

	public DynamicSS(ImmutableObservableCollection<ICanvasElement> sourceElements)
	{
		SourceElements = sourceElements;
		SourceElements.CollectionChanged += SourceElementsChanged;
		foreach (ICanvasElement sourceElement in SourceElements)
		{
			SourceElementAdded(sourceElement);
		}
		_lastSourceElements = SourceElements.ToArray();
	}

	protected abstract void OnSourceElementAdded(ICanvasElement element);

	protected abstract void OnSourceElementRemoved(ICanvasElement element);

	public IEnumerable<ISnapLine> GenerateHorizontalSnapLines(ISnappingSource? targetSource)
	{
		UpdateLines();
		if (targetSource == null)
		{
			return Array.Empty<ISnapLine>();
		}
		return ProjectLines(isHorizontal: true, targetSource);
	}

	public IEnumerable<ISnapLine> GenerateVerticalSnapLines(ISnappingSource? targetSource)
	{
		UpdateLines();
		if (targetSource == null)
		{
			return Array.Empty<ISnapLine>();
		}
		return ProjectLines(isHorizontal: false, targetSource);
	}

	protected abstract IEnumerable<ISnapLine> ProjectLines(bool isHorizontal, ISnappingSource targetSource);

	public void IgnoreElements(IEnumerable<ICanvasElement> elements)
	{
		UnignoreElements();
		foreach (ICanvasElement element in elements)
		{
			_updatedElements.Remove(element);
		}
		_ignoredElements = elements;
	}

	public void UnignoreElements()
	{
		if (_ignoredElements == null)
		{
			return;
		}
		foreach (ICanvasElement ignoredElement in _ignoredElements)
		{
			_updatedElements.Add(ignoredElement);
		}
		_ignoredElements = null;
	}

	private void UpdateLines()
	{
		foreach (ICanvasElement updatedElement in _updatedElements)
		{
			OnSourceElementRemoved(updatedElement);
			if (updatedElement.IsSnappingSource && SourceElements.Contains(updatedElement))
			{
				OnSourceElementAdded(updatedElement);
			}
		}
		RemoveOrphanedLines();
		_updatedElements.Clear();
	}

	protected bool IsSameRegion(bool isHorizontal, Rect<double> sourceBounds, Rect<double> targetBounds)
	{
		double num = (isHorizontal ? sourceBounds.Left : sourceBounds.Top);
		double num2 = (isHorizontal ? sourceBounds.Right : sourceBounds.Bottom);
		double num3 = (isHorizontal ? targetBounds.Left : targetBounds.Top);
		double num4 = (isHorizontal ? targetBounds.Right : targetBounds.Bottom);
		if (!(num3 <= num) || !(num4 >= num))
		{
			if (num <= num3)
			{
				return num2 >= num3;
			}
			return false;
		}
		return true;
	}

	public bool IsTargetValid(ISnappingSource snappingSource)
	{
		return true;
	}

	private void SourceElementsChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		if (e.Action == NotifyCollectionChangedAction.Reset)
		{
			if (_lastSourceElements != null)
			{
				ICanvasElement[] lastSourceElements = _lastSourceElements;
				foreach (ICanvasElement element in lastSourceElements)
				{
					SourceElementRemoved(element);
				}
			}
		}
		else
		{
			if (e.OldItems != null)
			{
				foreach (ICanvasElement oldItem in e.OldItems)
				{
					SourceElementRemoved(oldItem);
				}
			}
			if (e.NewItems != null)
			{
				foreach (ICanvasElement newItem in e.NewItems)
				{
					SourceElementAdded(newItem);
				}
			}
		}
		_lastSourceElements = SourceElements.ToArray();
	}

	private void ElementPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		ICanvasElement canvasElement = sender as ICanvasElement;
		if ((IgnoredElements != null && IgnoredElements.Contains(canvasElement)) || canvasElement == null)
		{
			return;
		}
		switch (e.PropertyName)
		{
		case "Position":
		case "Size":
		case "Rotation":
		case "IsSnappingSource":
			if (!_updatedElements.Contains(canvasElement))
			{
				_updatedElements.Add(canvasElement);
			}
			break;
		}
	}

	protected void SourceElementAdded(ICanvasElement element)
	{
		element.PropertyChanged += ElementPropertyChanged;
		if (element.IsSnappingSource)
		{
			OnSourceElementAdded(element);
		}
	}

	protected void SourceElementRemoved(ICanvasElement element)
	{
		element.PropertyChanged -= ElementPropertyChanged;
		OnSourceElementRemoved(element);
		RemoveOrphanedLines();
	}

	private void RemoveOrphanedLines()
	{
		RemoveOrphanedLines(HorizontalLines);
		RemoveOrphanedLines(VerticalLines);
	}

	private void RemoveOrphanedLines(List<T> lines)
	{
		lines.RemoveIf((T l) => l.Owners.Count == 0);
	}
}
