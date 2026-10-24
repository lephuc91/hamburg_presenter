using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Operations;
using Pro.Common.Utility;

namespace Pro.Common.Components.Reversibility;

public class TaggedUndoAction<T> : UndoAction
{
	private sealed class PropertyStepKey : IEquatable<PropertyStepKey?>
	{
		public object TargetObject { get; }

		public string TargetProperty { get; }

		public PropertyStepKey(PropertyStep propertyStep)
		{
			TargetObject = propertyStep.TargetObject;
			TargetProperty = propertyStep.TargetProperty;
		}

		public override int GetHashCode()
		{
			return HashCodeHelper.GenerateHashCode(TargetObject, TargetProperty);
		}

		public override bool Equals(object? obj)
		{
			if (obj is PropertyStepKey other)
			{
				return Equals(other);
			}
			return false;
		}

		public bool Equals(PropertyStepKey? other)
		{
			if (TargetObject == other?.TargetObject)
			{
				return TargetProperty == other.TargetProperty;
			}
			return false;
		}

		public static bool operator ==(PropertyStepKey lhs, PropertyStepKey rhs)
		{
			return lhs.NullableEquals<PropertyStepKey>(rhs);
		}

		public static bool operator !=(PropertyStepKey lhs, PropertyStepKey rhs)
		{
			return !lhs.NullableEquals<PropertyStepKey>(rhs);
		}
	}

	public T Tag { get; }

	public bool StrictMatching { get; }

	public TaggedUndoAction(T tag, bool strictMatching = false)
	{
		Tag = tag;
		StrictMatching = strictMatching;
	}

	protected internal override bool CanMerge(UndoAction otherAction)
	{
		if (!(otherAction is TaggedUndoAction<T> taggedUndoAction) || !taggedUndoAction.Tag.Equal(Tag))
		{
			return false;
		}
		if (StrictMatching)
		{
			object[] source = FindTargetObjects(this);
			object[] target = FindTargetObjects(taggedUndoAction);
			return source.ContentsMatch(target);
		}
		return true;
	}

	private object[] FindTargetObjects(TaggedUndoAction<T> action)
	{
		return (from s in action.Steps.OfType<PropertyStep>()
			select s.TargetObject).Distinct().ToArray();
	}

	protected internal override void Merge(UndoAction otherAction)
	{
		List<Step> list = base.Steps.Concat(otherAction.Steps).ToList();
		foreach (Step[] item in list.ContiguousGroups((Step a, Step b) => a is PropertyStep && b is PropertyStep))
		{
			PropertyStep[] array = item.OfType<PropertyStep>().ToArray();
			List<PropertyStep> list2 = new List<PropertyStep>();
			foreach (PropertyStepKey property in array.Select((PropertyStep s) => new PropertyStepKey(s)).Distinct())
			{
				Func<PropertyStep, bool> predicate = (PropertyStep s) => s.TargetObject == property.TargetObject && s.TargetProperty.Equals(property.TargetProperty);
				PropertyStep propertyStep = array.Last(predicate);
				PropertyStep propertyStep2 = array.First(predicate);
				if (!object.Equals(propertyStep2.UndoValue, propertyStep.RedoValue))
				{
					list2.Add(new PropertyStep(property.TargetObject, property.TargetProperty, propertyStep2.UndoValue, propertyStep.RedoValue));
				}
			}
			int index = list.IndexOf(item.First());
			list.RemoveRange(index, array.Length);
			list.InsertRange(index, list2);
		}
		SetupAction(list, base.InitialStep, base.FinalStep);
	}
}
