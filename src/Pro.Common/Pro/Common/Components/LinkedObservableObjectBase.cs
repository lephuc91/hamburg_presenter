using System;
using System.Collections.Generic;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Pro.Common.Collections;

namespace Pro.Common.Components;

public abstract class LinkedObservableObjectBase : ObservableObject
{
	private sealed record SourceProperty(string Name, Type? Type);

	private readonly Dictionary<SourceProperty, List<string>> _linkedPropertiesMap = new Dictionary<SourceProperty, List<string>>();

	private readonly Dictionary<SourceProperty, Action> _linkedActionMap = new Dictionary<SourceProperty, Action>();

	protected NotifyOrder NotifyOrder { get; set; } = NotifyOrder.PropertyChangesFirst;

	protected void LinkProperties(string sourceProperty, string targetProperty, Type? tag = null)
	{
		LinkProperties(new string[1] { sourceProperty }, new string[1] { targetProperty }, tag);
	}

	protected void LinkProperties(string sourceProperty, IEnumerable<string> targetProperties, Type? tag = null)
	{
		LinkProperties(new string[1] { sourceProperty }, targetProperties, tag);
	}

	protected void LinkProperties(IEnumerable<string> sourceProperties, string targetProperty, Type? tag = null)
	{
		LinkProperties(sourceProperties, new string[1] { targetProperty }, tag);
	}

	protected void LinkProperties(IEnumerable<string> sourceProperties, IEnumerable<string> targetProperties, Type? tag = null)
	{
		foreach (string sourceProperty in sourceProperties)
		{
			SourceProperty key = new SourceProperty(sourceProperty, tag);
			if (!_linkedPropertiesMap.TryGetValue(key, out List<string> value))
			{
				value = new List<string>();
				_linkedPropertiesMap.Add(key, value);
			}
			Pro.Common.Collections.CollectionExtensions.AddRange(value, targetProperties);
		}
	}

	protected void RaiseLinkedValues(object? sender, PropertyChangedEventArgs e)
	{
		RaiseLinkedValues(e, sender?.GetType());
	}

	protected void RaiseLinkedValues(PropertyChangedEventArgs e, Type? tag = null)
	{
		switch (NotifyOrder)
		{
		case NotifyOrder.ActionsFirst:
			RaiseActions(e, tag);
			RaisePropertyChanges(e, tag);
			break;
		case NotifyOrder.PropertyChangesFirst:
			RaisePropertyChanges(e, tag);
			RaiseActions(e, tag);
			break;
		}
	}

	private void RaisePropertyChanges(PropertyChangedEventArgs e, Type? tag)
	{
		if (e.PropertyName != null && (_linkedPropertiesMap.TryGetValue(new SourceProperty(e.PropertyName, tag), out List<string> value) || _linkedPropertiesMap.TryGetValue(new SourceProperty(e.PropertyName, null), out value)))
		{
			value.ForEach(delegate(string p)
			{
				OnPropertyChanged(p);
			});
		}
	}

	private void RaiseActions(PropertyChangedEventArgs e, Type? tag)
	{
		if (e.PropertyName != null && (_linkedActionMap.TryGetValue(new SourceProperty(e.PropertyName, tag), out Action value) || _linkedActionMap.TryGetValue(new SourceProperty(e.PropertyName, null), out value)))
		{
			value?.Invoke();
		}
	}

	protected void LinkAction(string sourceProperty, Action targetAction, Type? tag = null)
	{
		LinkAction(new string[1] { sourceProperty }, targetAction, tag);
	}

	protected void LinkAction(IEnumerable<string> sourceProperties, Action targetAction, Type? tag = null)
	{
		sourceProperties.ForEach(delegate(string s)
		{
			_linkedActionMap[new SourceProperty(s, tag)] = targetAction;
		});
	}
}
