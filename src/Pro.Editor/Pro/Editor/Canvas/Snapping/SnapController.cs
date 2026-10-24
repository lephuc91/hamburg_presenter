using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Pro.Common.Mathematics;

namespace Pro.Editor.Canvas.Snapping;

public class SnapController
{
	public const double DefaultSnappingThreshold = 6.0;

	public const double MinSnappingThreshold = 2.0;

	private Vector2<double> _snappingOrigin;

	private ObservableCollection<ISnappingSource> _snappingTargets = new ObservableCollection<ISnappingSource>();

	private SnapLocator _snapLocator;

	private SnappingResult _latestResult = SnappingResult.EmptyResults;

	private Rect<double> _finalBounds = Rect<double>.Empty;

	private double _snappingThreshold = 6.0;

	public Vector2<double> SnappingOrigin
	{
		get
		{
			return _snappingOrigin;
		}
		set
		{
			_snappingOrigin = value;
		}
	}

	public ObservableCollection<ISnappingSource> SnappingTargets => _snappingTargets;

	public SnappingResult LatestResult => _latestResult;

	public Rect<double> FinalBounds => _finalBounds;

	public double SnappingThreshold
	{
		get
		{
			return _snappingThreshold;
		}
		set
		{
			_snappingThreshold = Math.Max(value, 2.0);
		}
	}

	public event Action<SnapController>? FinalBoundsChanged;

	public SnapController()
	{
		_snapLocator = new SnapLocator(_snappingTargets);
	}

	public void IgnoreElements(IEnumerable<ICanvasElement> elements)
	{
		foreach (ISnappingSource snappingTarget in _snapLocator.SnappingTargets)
		{
			snappingTarget.IgnoreElements(elements);
		}
	}

	public SnappingResult FindMatchingSnaps(ISnappingSource snappingSource)
	{
		SnappingResult snappingResult = _snapLocator.FindMatchingSnaps(SnappingOrigin, snappingSource, SnappingThreshold);
		_latestResult = new SnappingResult(SnapFilter.MergeLines(snappingResult.SnapLines), snappingResult.SnapOrigin, snappingResult.SnapDelta);
		return _latestResult;
	}

	public void UnignoreElements()
	{
		foreach (ISnappingSource snappingTarget in _snapLocator.SnappingTargets)
		{
			snappingTarget.UnignoreElements();
		}
	}

	public void UpdateFinalBounds(Rect<double> bounds)
	{
		_finalBounds = bounds;
		this.FinalBoundsChanged?.Invoke(this);
	}

	public void ClearResults()
	{
		_latestResult = SnappingResult.EmptyResults;
		_finalBounds = Rect<double>.Empty;
		this.FinalBoundsChanged?.Invoke(this);
	}
}
