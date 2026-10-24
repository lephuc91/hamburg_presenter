using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Reactive.Linq;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Slide.Custom.Elements;

namespace ProPresenter.DO.Slide.Links;

public class ElementLinkedVisibilityObject : NotifyPropertyChangedBase, ILinkedVisibilityObject, ILinkedObject, IRenderEquatable<ILinkedVisibilityObject>, IRenderHashable, ICloneable<ILinkedVisibilityObject>, INotifyPropertyChanged
{
	private ElementVisibilityCriteria _selectedCriterion;

	private SlideElementBase? _element;

	public VisibilityLinkType Type => VisibilityLinkType.SlideObject;

	public string DisplayText => string.Empty;

	public string Content => Element?.Name ?? ElementName ?? string.Empty;

	public UndoStack? UndoStack { get; set; }

	public ElementVisibilityCriteria SelectedCriterion
	{
		get
		{
			return _selectedCriterion;
		}
		set
		{
			SetValue("SelectedCriterion", ref _selectedCriterion, value, delegate(ElementVisibilityCriteria o, ElementVisibilityCriteria n)
			{
				UndoStack?.Commit(UndoActionTypes.VisibilityLinkChangeElementCriterion.ToAction(), this, "SelectedCriterion", o, n, null, null, autoFinalize: true);
				OnDataModified();
			});
		}
	}

	public Guid ElementID { get; private set; }

	public string? ElementName { get; private set; }

	public SlideElementBase? Element
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

	public event System.Action? DataModified;

	public static ObjectBinder<ElementLinkedVisibilityObject, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IElementVisibility> CreateBinder(IUiScheduler scheduler, ElementLinkedVisibilityObject left, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IElementVisibility right)
	{
		ObjectBinder<ElementLinkedVisibilityObject, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IElementVisibility> objectBinder = new ObjectBinder<ElementLinkedVisibilityObject, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IElementVisibility>(left, right);
		objectBinder.Bind((ElementLinkedVisibilityObject l) => l.WhenPropertyChanges("SelectedCriterion"), (ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IElementVisibility r) => r.VisibilityCriterion.WhenValueChanges, delegate(ElementLinkedVisibilityObject l, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IElementVisibility r)
		{
			r.VisibilityCriterion.Set(l.SelectedCriterion.ToEntityCaptureSessionVisibilityCriteria());
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IElementVisibility r, ElementLinkedVisibilityObject l)
		{
			l.SelectedCriterion = r.VisibilityCriterion.Value.ToElementVisibilityCriteria();
		}).Bind((ElementLinkedVisibilityObject l) => l.WhenPropertyChanges("Element"), (ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IElementVisibility r) => r.OtherElementUuid.WhenValueChanges.ToUnit().Merge(r.OtherElementName.WhenValueChanges.ToUnit()), delegate(ElementLinkedVisibilityObject l, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IElementVisibility r)
		{
			r.OtherElementUuid.Set(l.ElementID);
			r.OtherElementName.Set(l.ElementName);
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IElementVisibility r, ElementLinkedVisibilityObject l)
		{
			l.ElementID = r.OtherElementUuid.ToGuidOrEmpty();
			l.ElementName = r.OtherElementName.Value;
		});
		return objectBinder;
	}

	public ElementLinkedVisibilityObject()
	{
	}

	public ElementLinkedVisibilityObject(SlideElementBase element)
	{
		Element = element;
	}

	public bool RenderEquals([NotNullWhen(true)] ILinkedVisibilityObject? other)
	{
		if (other is ElementLinkedVisibilityObject elementLinkedVisibilityObject && ElementID == elementLinkedVisibilityObject.ElementID && ElementName == elementLinkedVisibilityObject.ElementName)
		{
			return _selectedCriterion == elementLinkedVisibilityObject._selectedCriterion;
		}
		return false;
	}

	public int GetRenderHashCode()
	{
		return RenderHashCodeHelper.GenerateHashCode(ElementID, ElementName, _selectedCriterion);
	}

	public ILinkedVisibilityObject Clone()
	{
		return new ElementLinkedVisibilityObject
		{
			ElementID = ElementID,
			ElementName = ElementName,
			Element = Element,
			SelectedCriterion = SelectedCriterion
		};
	}

	public void Serialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition protoVisibilityLinkCondition)
	{
		protoVisibilityLinkCondition.ElementVisibility = new Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.ElementVisibility
		{
			OtherElementUuid = (Element?.ID ?? ElementID).ToUUID(),
			OtherElementName = (Element?.Name ?? ElementName ?? string.Empty),
			VisibilityCriterion = SelectedCriterion.ToProtoElementVisibilityCriterion()
		};
	}

	public static ElementLinkedVisibilityObject Deserialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.ElementVisibility protoElementVisibility, SlideElementBase element)
	{
		return new ElementLinkedVisibilityObject(element)
		{
			SelectedCriterion = protoElementVisibility.VisibilityCriterion.ToElementVisibilityCriteria()
		};
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	private void OnElementChanged(SlideElementBase o, SlideElementBase n)
	{
		UndoStack?.Commit(UndoActionTypes.VisibilityLinkChangeCondition.ToAction(), this, "Element", o, n, null, null, autoFinalize: true);
		OnDataModified();
		if (n != null)
		{
			ElementID = n.ID;
			ElementName = n.Name;
		}
		OnPropertyChanged("ElementID");
		OnPropertyChanged("ElementName");
	}
}
