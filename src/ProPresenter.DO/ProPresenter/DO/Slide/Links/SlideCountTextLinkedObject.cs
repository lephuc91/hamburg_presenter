using System;
using System.Diagnostics.CodeAnalysis;
using Pro.Common.Components.Reversibility;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Links;

public class SlideCountTextLinkedObject : LinkedTextObjectBase
{
	private SlideCountType _slideCountType;

	public override LinkedTextType LinkedTextType => LinkedTextType.SlideCount;

	public override string DisplayText => LocalizedStrings.Get(LinkedTextType) + " - " + LocalizedStrings.Get(SlideCountType);

	public override FormattingType FormattingType => FormattingType.None;

	public SlideCountType SlideCountType
	{
		get
		{
			return _slideCountType;
		}
		set
		{
			SetValue("SlideCountType", ref _slideCountType, value, OnSlideCountTypeChanged);
		}
	}

	public static ObjectBinder<SlideCountTextLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.ISlideCount> CreateBinder(SlideCountTextLinkedObject left, ISlide.Types.IElement.Types.IDataLink.Types.ISlideCount right)
	{
		ObjectBinder<SlideCountTextLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.ISlideCount> objectBinder = new ObjectBinder<SlideCountTextLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.ISlideCount>(left, right);
		objectBinder.Bind((SlideCountTextLinkedObject l) => l.WhenPropertyChanges("SlideCountType"), (ISlide.Types.IElement.Types.IDataLink.Types.ISlideCount r) => r.SlideCountSourceType.WhenValueChanges, delegate(SlideCountTextLinkedObject l, ISlide.Types.IElement.Types.IDataLink.Types.ISlideCount r)
		{
			r.SlideCountSourceType.Set(l.SlideCountType.ToEntitySlideCountSourceType());
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.ISlideCount r, SlideCountTextLinkedObject l)
		{
			l.SlideCountType = r.SlideCountSourceType.Value.ToSlideCountType();
		});
		return objectBinder;
	}

	public SlideCountTextLinkedObject()
	{
	}

	public SlideCountTextLinkedObject(SlideCountType slideCountType)
	{
		_slideCountType = slideCountType;
	}

	public override bool RenderEquals([NotNullWhen(true)] ILinkedTextObject? other)
	{
		if (other is SlideCountTextLinkedObject slideCountTextLinkedObject)
		{
			return _slideCountType == slideCountTextLinkedObject._slideCountType;
		}
		return false;
	}

	public override int GetRenderHashCode()
	{
		return _slideCountType.GetHashCode();
	}

	public override string GetText(ILinkData? linkData)
	{
		if (linkData == null)
		{
			return LocalizedStrings.Get(LinkedTextType);
		}
		return SlideCountType switch
		{
			SlideCountType.Current => linkData.ArrangementInformation?.CurrentSlideNumber.ToString() ?? string.Empty, 
			SlideCountType.Remaining => linkData.ArrangementInformation?.SlidesRemaining.ToString() ?? string.Empty, 
			SlideCountType.Total => linkData.ArrangementInformation?.TotalSlideCount.ToString() ?? string.Empty, 
			_ => throw new NotSupportedException(), 
		};
	}

	public override ILinkedTextObject Clone()
	{
		return new SlideCountTextLinkedObject(_slideCountType);
	}

	public override void Serialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink dataLink)
	{
		dataLink.SlideCount = new Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.SlideCount
		{
			SlideCountSourceType = SlideCountType.ToProtoSlideCountSourceType()
		};
	}

	public static SlideCountTextLinkedObject Deserialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.SlideCount protoSlideCount)
	{
		return new SlideCountTextLinkedObject(protoSlideCount.SlideCountSourceType.ToSlideCountType());
	}

	private void OnSlideCountTypeChanged(SlideCountType oldValue, SlideCountType newValue)
	{
		OnDataModified();
		base.UndoStack?.Commit(UndoActionTypes.LinkSlideCount.ToAction(), this, "SlideCountType", oldValue, newValue, null, null, autoFinalize: true);
	}
}
