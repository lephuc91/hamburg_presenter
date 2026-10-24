using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Reactive.Linq;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;
using Pro.Text;
using ProPresenter.DO.Slide.Custom.Elements;

namespace ProPresenter.DO.Slide.Links;

public class ElementTextLinkedObject : LinkedTextObjectBase
{
	private ClosedBezierPath? _element;

	public override LinkedTextType LinkedTextType => LinkedTextType.Element;

	public override string DisplayText => Element?.Name ?? ElementName ?? string.Empty;

	public override FormattingType FormattingType => FormattingType.None;

	public Guid ElementID { get; private set; }

	public string ElementName { get; private set; } = string.Empty;

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

	public override bool SupportsPlaceholderText
	{
		get
		{
			ClosedBezierPath? element = Element;
			if (element == null)
			{
				return false;
			}
			return element.AdditionalInfo.HasFlag(AdditionalInfo.Text);
		}
	}

	public static ObjectBinder<ElementTextLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IAlternateElementText> CreateBinder(ElementTextLinkedObject left, ISlide.Types.IElement.Types.IDataLink.Types.IAlternateElementText right)
	{
		ObjectBinder<ElementTextLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IAlternateElementText> objectBinder = new ObjectBinder<ElementTextLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IAlternateElementText>(left, right);
		objectBinder.Bind((ElementTextLinkedObject l) => l.WhenPropertyChanges("Element"), (ISlide.Types.IElement.Types.IDataLink.Types.IAlternateElementText r) => r.OtherElementUuid.WhenValueChanges.ToUnit().Merge(r.OtherElementName.WhenValueChanges.ToUnit()), delegate(ElementTextLinkedObject l, ISlide.Types.IElement.Types.IDataLink.Types.IAlternateElementText r)
		{
			r.OtherElementUuid.Set(l.Element?.ID);
			r.OtherElementName.Set(l.Element?.Name);
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.IAlternateElementText r, ElementTextLinkedObject l)
		{
			l.ElementID = r.OtherElementUuid.ToGuidOrEmpty();
			l.ElementName = r.OtherElementName?.Value ?? string.Empty;
		});
		return objectBinder;
	}

	public ElementTextLinkedObject()
	{
	}

	public ElementTextLinkedObject(ClosedBezierPath element)
	{
		Element = element;
	}

	public override bool RenderEquals([NotNullWhen(true)] ILinkedTextObject? other)
	{
		if (other is ElementTextLinkedObject elementTextLinkedObject && ElementID == elementTextLinkedObject.ElementID)
		{
			return ElementName == elementTextLinkedObject.ElementName;
		}
		return false;
	}

	public override int GetRenderHashCode()
	{
		return RenderHashCodeHelper.GenerateHashCode(ElementID, ElementName);
	}

	public override string GetText(ILinkData? linkData)
	{
		return Element?.Text?.AllText ?? string.Empty;
	}

	public override ILinkedTextObject Clone()
	{
		return new ElementTextLinkedObject
		{
			ElementID = ElementID,
			ElementName = ElementName,
			Element = (Element?.CloneWithID() as ClosedBezierPath)
		};
	}

	public override void Serialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink dataLink)
	{
		dataLink.AlternateText = new Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.AlternateElementText
		{
			OtherElementUuid = (Element?.ID ?? ElementID).ToUUID(),
			OtherElementName = (Element?.Name ?? ElementName)
		};
	}

	public static ElementTextLinkedObject Deserialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.AlternateElementText protoElementText, IEnumerable<ClosedBezierPath> otherElements)
	{
		ElementTextLinkedObject link = new ElementTextLinkedObject
		{
			ElementID = (protoElementText.OtherElementUuid?.ToGuid() ?? Guid.Empty),
			ElementName = protoElementText.OtherElementName
		};
		link.Element = otherElements?.FirstOrDefaultBy((ClosedBezierPath e) => e.ID == link.ElementID, (ClosedBezierPath e) => e.Name == link.ElementName);
		return link;
	}

	private void OnElementChanged(ClosedBezierPath o, ClosedBezierPath n)
	{
		if (o != null)
		{
			o.PropertyChanged -= Element_PropertyChanged;
			if (o.Text != null)
			{
				o.Text.DocumentChanged -= Element_TextChanged;
			}
		}
		if (n != null)
		{
			n.PropertyChanged += Element_PropertyChanged;
			if (n.Text != null)
			{
				n.Text.DocumentChanged += Element_TextChanged;
			}
			ElementID = n.ID;
			ElementName = n.Name;
		}
		base.UndoStack?.Commit(UndoActionTypes.LinkElement.ToAction(), this, "Element", o, n, null, null, autoFinalize: true);
	}

	private void Element_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "Name")
		{
			OnVisualInvalidated();
		}
	}

	private void Element_TextChanged(TextDocument document)
	{
		OnPropertyChanged("Element");
	}
}
