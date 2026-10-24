using System;
using System.Collections.Generic;
using System.ComponentModel;
using Pro.Common.Collections;
using Pro.Common.Utility;

namespace Pro.Common.Components;

public class LinkedNotifyPropertyChangedBase : NotifyPropertyChangedBase
{
	private sealed class SourceProperty : IEquatable<SourceProperty?>
	{
		private readonly int _hashCode;

		public string Name { get; }

		public Type? Type { get; }

		public SourceProperty(string name, Type? type)
		{
			Name = name;
			Type = type;
			_hashCode = HashCodeHelper.GenerateHashCode(Name, Type);
		}

		public override int GetHashCode()
		{
			return _hashCode;
		}

		public override bool Equals(object? obj)
		{
			if (obj is SourceProperty other)
			{
				return Equals(other);
			}
			return false;
		}

		public bool Equals(SourceProperty? other)
		{
			if (Name == other?.Name)
			{
				return Type == other.Type;
			}
			return false;
		}

		public static bool operator ==(SourceProperty lhs, SourceProperty rhs)
		{
			return lhs.NullableEquals<SourceProperty>(rhs);
		}

		public static bool operator !=(SourceProperty lhs, SourceProperty rhs)
		{
			return !lhs.NullableEquals<SourceProperty>(rhs);
		}
	}

	private Dictionary<SourceProperty, List<string>>? _linkedPropertiesMap;

	private Dictionary<SourceProperty, Action>? _linkedActionMap;

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
		if (_linkedPropertiesMap == null)
		{
			_linkedPropertiesMap = new Dictionary<SourceProperty, List<string>>();
		}
		foreach (string sourceProperty in sourceProperties)
		{
			SourceProperty key = new SourceProperty(sourceProperty, tag);
			List<string> value = null;
			if (!_linkedPropertiesMap.TryGetValue(key, out value))
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
		if (_linkedPropertiesMap != null && e.PropertyName != null)
		{
			List<string> value = null;
			if (_linkedPropertiesMap.TryGetValue(new SourceProperty(e.PropertyName, tag), out value) || _linkedPropertiesMap.TryGetValue(new SourceProperty(e.PropertyName, null), out value))
			{
				value.ForEach(base.OnPropertyChanged);
			}
		}
	}

	private void RaiseActions(PropertyChangedEventArgs e, Type? tag)
	{
		if (_linkedActionMap != null && e.PropertyName != null && (_linkedActionMap.TryGetValue(new SourceProperty(e.PropertyName, tag), out Action value) || _linkedActionMap.TryGetValue(new SourceProperty(e.PropertyName, null), out value)))
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
		if (_linkedActionMap == null)
		{
			_linkedActionMap = new Dictionary<SourceProperty, Action>();
		}
		sourceProperties.ForEach(delegate(string s)
		{
			_linkedActionMap[new SourceProperty(s, tag)] = targetAction;
		});
	}
}
