using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Slide.Custom.Elements;

namespace ProPresenter.DO.Slide.Links;

public class VisibilityCondition : NotifyPropertyChangedBase, IRenderEquatable<VisibilityCondition>, IRenderHashable, ICloneable<VisibilityCondition>
{
	private ILinkedVisibilityObject? _linkedObject;

	private UndoStack? _undoStack;

	public ILinkedVisibilityObject? LinkedObject
	{
		get
		{
			return _linkedObject;
		}
		set
		{
			SetValue<ILinkedVisibilityObject>("LinkedObject", ref _linkedObject, value, delegate(ILinkedVisibilityObject o, ILinkedVisibilityObject n)
			{
				if (o != null)
				{
					o.DataModified -= OnDataModified;
				}
				if (n != null)
				{
					n.DataModified += OnDataModified;
					n.UndoStack = UndoStack;
				}
				OnDataModified();
			});
		}
	}

	public UndoStack? UndoStack
	{
		get
		{
			return _undoStack;
		}
		set
		{
			_undoStack = value;
			if (LinkedObject != null)
			{
				LinkedObject.UndoStack = value;
			}
		}
	}

	public event System.Action? DataModified;

	public bool RenderEquals([NotNullWhen(true)] VisibilityCondition? other)
	{
		return LinkedObject?.RenderEquals(other?.LinkedObject) ?? (LinkedObject == other?.LinkedObject);
	}

	public int GetRenderHashCode()
	{
		if (LinkedObject != null)
		{
			return RenderHashCodeHelper.GenerateHashCode(LinkedObject);
		}
		return 0;
	}

	public VisibilityCondition Clone()
	{
		return new VisibilityCondition
		{
			LinkedObject = LinkedObject?.Clone()
		};
	}

	public Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition Serialize()
	{
		Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition condition = new Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition();
		LinkedObject?.Serialize(condition);
		return condition;
	}

	public static VisibilityCondition Deserialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition protoVisibilityLinkCondition, IEnumerable<SlideElementBase> otherElements)
	{
		return new VisibilityCondition
		{
			LinkedObject = protoVisibilityLinkCondition.GenerateLinkedVisibilityObject(otherElements)
		};
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}
}
