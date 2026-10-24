using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Links;

public class CaptureSessionLinkedVisibilityObject : NotifyPropertyChangedBase, ILinkedVisibilityObject, ILinkedObject, IRenderEquatable<ILinkedVisibilityObject>, IRenderHashable, ICloneable<ILinkedVisibilityObject>, INotifyPropertyChanged
{
	private CaptureSessionVisibilityCriteria _selectedCriterion;

	public VisibilityLinkType Type => VisibilityLinkType.CaptureSession;

	public string Content => LocalizedStrings.Get(Type);

	public UndoStack? UndoStack { get; set; }

	public string DisplayText => LocalizedStrings.Get(Type);

	public CaptureSessionVisibilityCriteria SelectedCriterion
	{
		get
		{
			return _selectedCriterion;
		}
		set
		{
			SetValue("SelectedCriterion", ref _selectedCriterion, value, delegate(CaptureSessionVisibilityCriteria o, CaptureSessionVisibilityCriteria n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.VisibilityLinkChangeCaptureSessionCriterion), this, "SelectedCriterion", o, n);
				OnDataModified();
			});
		}
	}

	public event System.Action? DataModified;

	public static ObjectBinder<CaptureSessionLinkedVisibilityObject, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ICaptureSessionVisibility> CreateBinder(CaptureSessionLinkedVisibilityObject left, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ICaptureSessionVisibility right)
	{
		ObjectBinder<CaptureSessionLinkedVisibilityObject, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ICaptureSessionVisibility> objectBinder = new ObjectBinder<CaptureSessionLinkedVisibilityObject, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ICaptureSessionVisibility>(left, right);
		objectBinder.Bind((CaptureSessionLinkedVisibilityObject l) => l.WhenPropertyChanges("SelectedCriterion"), (ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ICaptureSessionVisibility r) => r.VisibilityCriterion.WhenValueChanges, delegate(CaptureSessionLinkedVisibilityObject l, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ICaptureSessionVisibility r)
		{
			r.VisibilityCriterion.Set(l.SelectedCriterion.ToEntityCaptureSessionVisibilityCriteria());
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ICaptureSessionVisibility r, CaptureSessionLinkedVisibilityObject l)
		{
			l.SelectedCriterion = r.VisibilityCriterion.Value.ToCaptureSessionVisibilityCriteria();
		});
		return objectBinder;
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	public bool RenderEquals([NotNullWhen(true)] ILinkedVisibilityObject? other)
	{
		if (other is CaptureSessionLinkedVisibilityObject captureSessionLinkedVisibilityObject)
		{
			return _selectedCriterion == captureSessionLinkedVisibilityObject._selectedCriterion;
		}
		return false;
	}

	public int GetRenderHashCode()
	{
		return RenderHashCodeHelper.GenerateHashCode(_selectedCriterion);
	}

	public ILinkedVisibilityObject Clone()
	{
		return new CaptureSessionLinkedVisibilityObject
		{
			SelectedCriterion = SelectedCriterion
		};
	}

	public void Serialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition protoVisibilityLinkCondition)
	{
		protoVisibilityLinkCondition.CaptureSessionVisibility = new Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.CaptureSessionVisibility
		{
			VisibilityCriterion = SelectedCriterion.ToProtoCaptureSessionVisibilityCriteria()
		};
	}

	public static CaptureSessionLinkedVisibilityObject Deserialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.CaptureSessionVisibility protoCaptureSessionVisibility)
	{
		return new CaptureSessionLinkedVisibilityObject
		{
			SelectedCriterion = protoCaptureSessionVisibility.VisibilityCriterion.ToCaptureSessionVisibilityCriteria()
		};
	}
}
