using System;
using System.Diagnostics.CodeAnalysis;
using Pro.Common.Components.Reversibility;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Custom.Elements.Fills;

namespace ProPresenter.DO.Slide.Links;

public class SlideImageLinkedObject : LinkedFillObjectBase
{
	private SlideTargetSourceMode _targetSourceMode;

	public override LinkedFillType LinkedFillType => LinkedFillType.SlidePreview;

	public override string DisplayText => TargetSourceMode switch
	{
		SlideTargetSourceMode.Current => LocalizedStrings.Get("FILL_LINK_CURRENT_SLIDE_IMAGE_title"), 
		SlideTargetSourceMode.Next => LocalizedStrings.Get("FILL_LINK_NEXT_SLIDE_IMAGE_title"), 
		_ => throw new NotSupportedException(), 
	};

	public override SlideTargetSourceMode TargetSourceMode
	{
		get
		{
			return _targetSourceMode;
		}
		set
		{
			SetValue("TargetSourceMode", ref _targetSourceMode, value, delegate(SlideTargetSourceMode o, SlideTargetSourceMode n)
			{
				base.UndoStack?.Commit(UndoActionTypes.LinkSlideImage.ToAction(), this, "TargetSourceMode", o, n, null, null, autoFinalize: true);
				OnPropertyChanged("DisplayText");
			});
		}
	}

	public static ObjectBinder<SlideImageLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.ISlideImage> CreateBinder(SlideImageLinkedObject left, ISlide.Types.IElement.Types.IDataLink.Types.ISlideImage right)
	{
		ObjectBinder<SlideImageLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.ISlideImage> objectBinder = new ObjectBinder<SlideImageLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.ISlideImage>(left, right);
		objectBinder.Bind((SlideImageLinkedObject l) => l.WhenPropertyChanges("TargetSourceMode"), (ISlide.Types.IElement.Types.IDataLink.Types.ISlideImage r) => r.SourceSlide.WhenValueChanges, delegate(SlideImageLinkedObject l, ISlide.Types.IElement.Types.IDataLink.Types.ISlideImage r)
		{
			r.SourceSlide.Set(l.TargetSourceMode.ToEntitySlideSourceType());
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.ISlideImage r, SlideImageLinkedObject l)
		{
			l.TargetSourceMode = r.SourceSlide.Value.ToSlideTargetSourceMode();
		});
		return objectBinder;
	}

	public SlideImageLinkedObject()
	{
	}

	public SlideImageLinkedObject(SlideTargetSourceMode targetSourceMode)
	{
		_targetSourceMode = targetSourceMode;
	}

	public override bool RenderEquals([NotNullWhen(true)] ILinkedFillObject? other)
	{
		if (other is SlideImageLinkedObject slideImageLinkedObject)
		{
			return _targetSourceMode == slideImageLinkedObject._targetSourceMode;
		}
		return false;
	}

	public override int GetRenderHashCode()
	{
		return _targetSourceMode.GetHashCode();
	}

	public override IFill? GetFill(ILinkData? linkData)
	{
		if (!(TargetSourceMode switch
		{
			SlideTargetSourceMode.Current => linkData?.CurrentSlide, 
			SlideTargetSourceMode.Next => linkData?.NextSlide, 
			_ => throw new NotSupportedException(), 
		} is CustomSlide targetSlide))
		{
			return null;
		}
		return new SlidePreviewFill(targetSlide, includeBackground: true, linkData.PresentationBackgroundColor);
	}

	public override ILinkedFillObject Clone()
	{
		return new SlideImageLinkedObject(_targetSourceMode);
	}

	public override void Serialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink dataLink)
	{
		dataLink.SlideImage = new Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.SlideImage
		{
			SourceSlide = TargetSourceMode.ToProtoSlideSourceType()
		};
	}

	public static SlideImageLinkedObject Deserialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.SlideImage protoSlideImage)
	{
		return new SlideImageLinkedObject(protoSlideImage.SourceSlide.ToSlideTargetSourceMode());
	}
}
