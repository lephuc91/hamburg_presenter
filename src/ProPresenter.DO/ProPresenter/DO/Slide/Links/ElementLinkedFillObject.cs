using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reactive.Linq;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Slide.Custom.Elements;

namespace ProPresenter.DO.Slide.Links;

public class ElementLinkedFillObject : LinkedFillObjectBase
{
	private ClosedBezierPath? _element;

	public override LinkedFillType LinkedFillType => LinkedFillType.Element;

	public override bool IsValid => Element != null;

	public override string DisplayText => LocalizedStrings.Get(LinkedFillType) + " - " + (Element?.Name ?? ElementName);

	public Guid ElementID { get; private set; }

	public string? ElementName { get; private set; }

	public ClosedBezierPath? Element
	{
		get
		{
			return _element;
		}
		set
		{
			SetValue("Element", ref _element, value, OnElementChanged);
		}
	}

	public static ObjectBinder<ElementLinkedFillObject, ISlide.Types.IElement.Types.IDataLink.Types.IAlternateElementFill> CreateBinder(ElementLinkedFillObject left, ISlide.Types.IElement.Types.IDataLink.Types.IAlternateElementFill right)
	{
		ObjectBinder<ElementLinkedFillObject, ISlide.Types.IElement.Types.IDataLink.Types.IAlternateElementFill> objectBinder = new ObjectBinder<ElementLinkedFillObject, ISlide.Types.IElement.Types.IDataLink.Types.IAlternateElementFill>(left, right);
		objectBinder.Bind((ElementLinkedFillObject l) => l.WhenPropertyChanges("Element"), (ISlide.Types.IElement.Types.IDataLink.Types.IAlternateElementFill r) => r.OtherElementUuid.WhenValueChanges.ToUnit().Merge(r.OtherElementName.WhenValueChanges.ToUnit()), delegate(ElementLinkedFillObject l, ISlide.Types.IElement.Types.IDataLink.Types.IAlternateElementFill r)
		{
			r.OtherElementUuid.Set(l.Element?.ID);
			r.OtherElementName.Set(l.Element?.Name);
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.IAlternateElementFill r, ElementLinkedFillObject l)
		{
			l.ElementID = r.OtherElementUuid.ToGuidOrEmpty();
			l.ElementName = r.OtherElementName.Value;
		});
		return objectBinder;
	}

	public ElementLinkedFillObject()
	{
	}

	public ElementLinkedFillObject(ClosedBezierPath? element)
	{
		Element = element;
	}

	public override bool RenderEquals([NotNullWhen(true)] ILinkedFillObject? other)
	{
		if (other is ElementLinkedFillObject elementLinkedFillObject && ElementID == elementLinkedFillObject.ElementID)
		{
			return ElementName == elementLinkedFillObject.ElementName;
		}
		return false;
	}

	public override int GetRenderHashCode()
	{
		return RenderHashCodeHelper.GenerateHashCode(ElementID, ElementName);
	}

	public override IFill? GetFill(ILinkData? linkData)
	{
		return Element?.Fill?.Clone();
	}

	public override ILinkedFillObject Clone()
	{
		return new ElementLinkedFillObject
		{
			ElementID = ElementID,
			ElementName = ElementName
		};
	}

	public override void Serialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink dataLink)
	{
		dataLink.AlternateFill = new Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.AlternateElementFill
		{
			OtherElementUuid = (Element?.ID ?? ElementID).ToUUID(),
			OtherElementName = (Element?.Name ?? ElementName ?? string.Empty)
		};
	}

	public static ElementLinkedFillObject Deserialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.AlternateElementFill protoElementLink, IEnumerable<ClosedBezierPath> otherElements)
	{
		ElementLinkedFillObject link = new ElementLinkedFillObject
		{
			ElementID = (protoElementLink?.OtherElementUuid?.ToGuid() ?? Guid.Empty),
			ElementName = protoElementLink?.OtherElementName
		};
		link.Element = otherElements?.FirstOrDefaultBy((ClosedBezierPath e) => e.ID == link.ElementID, (ClosedBezierPath e) => e.Name == link.ElementName);
		return link;
	}

	private void OnElementChanged(ClosedBezierPath oldValue, ClosedBezierPath newValue)
	{
		base.UndoStack?.Commit(UndoActionTypes.LinkElement.ToAction(), this, "Element", oldValue, newValue, null, null, autoFinalize: true);
		if (oldValue != null)
		{
			if (oldValue.Fill != null)
			{
				oldValue.Fill.VisualInvalidated -= Fill_VisualInvalidated;
			}
			oldValue.FillChanged -= Element_FillChanged;
			if (oldValue.FillLink != null)
			{
				oldValue.FillLink.LinkObjectUpdated -= Fill_VisualInvalidated;
			}
		}
		OnPropertyChanged("IsValid");
		if (newValue != null)
		{
			ElementID = newValue.ID;
			ElementName = newValue.Name;
			if (newValue.Fill != null)
			{
				newValue.Fill.VisualInvalidated += Fill_VisualInvalidated;
			}
			newValue.FillChanged += Element_FillChanged;
			if (newValue.FillLink != null)
			{
				newValue.FillLink.LinkObjectUpdated += Fill_VisualInvalidated;
			}
		}
	}

	private void Element_FillChanged(IFill oldValue, IFill newValue)
	{
		if (oldValue != null)
		{
			oldValue.VisualInvalidated -= Fill_VisualInvalidated;
		}
		if (newValue != null)
		{
			newValue.VisualInvalidated += Fill_VisualInvalidated;
		}
		OnPropertyChanged("Element");
	}

	private void Fill_VisualInvalidated()
	{
		OnPropertyChanged("Element");
	}
}
