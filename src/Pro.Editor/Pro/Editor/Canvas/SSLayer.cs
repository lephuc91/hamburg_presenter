using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Pro.Common.Collections;
using Pro.Editor.Canvas.Snapping;
using Pro.Editor.Canvas.Snapping.Sources;

namespace Pro.Editor.Canvas;

internal class SSLayer
{
	private ICanvasElement _sourceParent;

	private ISnappingSource[] _dynamicSnappingSources;

	private EqualSpacingSS _equalSpacingSS;

	private EqualSizingSS _equalSizingSS;

	private CenterSpacingSS _centerSpacingSS;

	private Dictionary<ICanvasElement, ElementSS> _fixedSnappingSources = new Dictionary<ICanvasElement, ElementSS>();

	private bool _centerEnabled = true;

	private bool _edgeEnabled = true;

	private List<SnapController> _activeControllers = new List<SnapController>();

	public SSLayer(ICanvasElement sourceParent)
	{
		ImmutableObservableCollection<ICanvasElement> canvasChildren = sourceParent.CanvasChildren;
		_sourceParent = sourceParent;
		_equalSpacingSS = new EqualSpacingSS(canvasChildren ?? throw new MemberAccessException("sourceElements"));
		_equalSizingSS = new EqualSizingSS(canvasChildren);
		_centerSpacingSS = new CenterSpacingSS(canvasChildren);
		_dynamicSnappingSources = new ISnappingSource[3] { _equalSpacingSS, _equalSizingSS, _centerSpacingSS };
		_fixedSnappingSources.Add(_sourceParent, new ElementSS(_sourceParent, isParent: true));
		foreach (ICanvasElement item in canvasChildren)
		{
			_fixedSnappingSources.Add(item, new ElementSS(item));
		}
		canvasChildren.CollectionChanged += SourceElements_CollectionChanged;
	}

	public void Activate(SnapController controller)
	{
		if (!_activeControllers.Contains(controller))
		{
			_activeControllers.Add(controller);
			controller.SnappingOrigin = _sourceParent.Position;
			controller.SnappingTargets.AddRange(_dynamicSnappingSources);
			controller.SnappingTargets.AddRange(_fixedSnappingSources.Values);
		}
	}

	public void Deactivate(SnapController controller)
	{
		_activeControllers.Remove(controller);
		controller.SnappingTargets.RemoveRange(_dynamicSnappingSources);
		controller.SnappingTargets.RemoveRange(_fixedSnappingSources.Values);
	}

	public void DetachFromSource()
	{
		if (_sourceParent.CanvasChildren != null)
		{
			_sourceParent.CanvasChildren.CollectionChanged -= SourceElements_CollectionChanged;
		}
	}

	public void EnableSnapTypes(bool spacingEnabled, bool sizingEnabled, bool centerEnabled, bool edgeEnabled)
	{
		_equalSpacingSS.IsEnabled = spacingEnabled;
		_equalSizingSS.IsEnabled = sizingEnabled;
		_centerSpacingSS.IsEnabled = spacingEnabled;
		foreach (ElementSS value in _fixedSnappingSources.Values)
		{
			value.IsCenterEnabled = centerEnabled;
			value.IsEdgeEnabled = edgeEnabled;
		}
		_centerEnabled = centerEnabled;
		_edgeEnabled = edgeEnabled;
	}

	private void SourceElements_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		if (e.Action == NotifyCollectionChangedAction.Reset)
		{
			(from c in _fixedSnappingSources.Keys.ToArray()
				where c != _sourceParent
				select c).ForEach(delegate(ICanvasElement c)
			{
				RemoveElementSS(c);
			});
		}
		else
		{
			e.OldItems?.Cast<ICanvasElement>().ForEach(delegate(ICanvasElement c)
			{
				RemoveElementSS(c);
			});
			e.NewItems?.Cast<ICanvasElement>().ForEach(delegate(ICanvasElement c)
			{
				AddElementSS(c);
			});
		}
	}

	private void AddElementSS(ICanvasElement element)
	{
		ElementSS source = new ElementSS(element)
		{
			IsCenterEnabled = _centerEnabled,
			IsEdgeEnabled = _edgeEnabled
		};
		_fixedSnappingSources.Add(element, source);
		_activeControllers.ForEach(delegate(SnapController c)
		{
			c.SnappingTargets.Add(source);
		});
	}

	private void RemoveElementSS(ICanvasElement element)
	{
		ElementSS source = _fixedSnappingSources[element];
		_fixedSnappingSources.Remove(element);
		_activeControllers.ForEach(delegate(SnapController c)
		{
			c.SnappingTargets.Remove(source);
		});
	}
}
