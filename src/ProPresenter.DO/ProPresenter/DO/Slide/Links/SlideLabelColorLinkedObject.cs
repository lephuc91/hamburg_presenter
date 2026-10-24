using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Media;
using Pro.Common.Components.Reversibility;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Custom.Elements.Fills;

namespace ProPresenter.DO.Slide.Links;

public class SlideLabelColorLinkedObject : LinkedFillObjectBase
{
	private SlideTargetSourceMode _targetSource;

	public override LinkedFillType LinkedFillType => LinkedFillType.SlideLabelColor;

	public SlideTargetSourceMode TargetSource
	{
		get
		{
			return _targetSource;
		}
		set
		{
			SetValue("TargetSource", ref _targetSource, value, delegate(SlideTargetSourceMode o, SlideTargetSourceMode n)
			{
				base.UndoStack?.Commit(UndoActionTypes.LinkSlideLabelColor.ToAction(), this, "TargetSource", o, n, null, null, autoFinalize: true);
			});
		}
	}

	public override string DisplayText => LocalizedStrings.Get(LinkedFillType) + " - " + LocalizedStrings.Get(TargetSource);

	public static ObjectBinder<SlideLabelColorLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.ISlideLabelColor> CreateBinder(SlideLabelColorLinkedObject left, ISlide.Types.IElement.Types.IDataLink.Types.ISlideLabelColor right)
	{
		ObjectBinder<SlideLabelColorLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.ISlideLabelColor> objectBinder = new ObjectBinder<SlideLabelColorLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.ISlideLabelColor>(left, right);
		objectBinder.Bind((SlideLabelColorLinkedObject l) => l.WhenPropertyChanges("TargetSource"), (ISlide.Types.IElement.Types.IDataLink.Types.ISlideLabelColor r) => r.SlideLabelSource.WhenValueChanges, delegate(SlideLabelColorLinkedObject l, ISlide.Types.IElement.Types.IDataLink.Types.ISlideLabelColor r)
		{
			r.SlideLabelSource.Set(l.TargetSource.ToEntitySlideLabelSource());
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.ISlideLabelColor r, SlideLabelColorLinkedObject l)
		{
			l.TargetSource = r.SlideLabelSource.Value.ToSlideTargetSourceMode();
		});
		return objectBinder;
	}

	public SlideLabelColorLinkedObject()
	{
	}

	public SlideLabelColorLinkedObject(SlideTargetSourceMode targetSource)
	{
		_targetSource = targetSource;
	}

	public override IFill GetFill(ILinkData? linkData)
	{
		return new SolidColorFill
		{
			Color = (getColor() ?? Colors.Transparent)
		};
		System.Windows.Media.Color? getColor()
		{
			return TargetSource switch
			{
				SlideTargetSourceMode.Current => linkData?.SlideLabelInfo?.Current?.Color, 
				SlideTargetSourceMode.Next => linkData?.SlideLabelInfo?.Next?.Color, 
				_ => throw new NotSupportedException(), 
			};
		}
	}

	public override bool RenderEquals([NotNullWhen(true)] ILinkedFillObject? other)
	{
		if (other is SlideLabelColorLinkedObject slideLabelColorLinkedObject)
		{
			return slideLabelColorLinkedObject.TargetSource == TargetSource;
		}
		return false;
	}

	public override int GetRenderHashCode()
	{
		return RenderHashCodeHelper.GenerateHashCode(TargetSource);
	}

	public override ILinkedFillObject Clone()
	{
		return new SlideLabelColorLinkedObject(TargetSource);
	}

	public override void Serialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink dataLink)
	{
		dataLink.SlideLabelColor = new Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.SlideLabelColor
		{
			SlideLabelSource = TargetSource.ToProtoSlideLabelSource()
		};
	}

	public static SlideLabelColorLinkedObject Deserialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.SlideLabelColor protoSlideLabel)
	{
		return new SlideLabelColorLinkedObject(protoSlideLabel.SlideLabelSource.ToSlideTargetSourceMode());
	}
}
