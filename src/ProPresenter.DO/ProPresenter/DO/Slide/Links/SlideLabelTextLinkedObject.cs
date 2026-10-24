using System;
using System.Diagnostics.CodeAnalysis;
using Pro.Common.Components.Reversibility;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Links;

public class SlideLabelTextLinkedObject : LinkedTextObjectBase
{
	private SlideTargetSourceMode _targetSource;

	public override LinkedTextType LinkedTextType => LinkedTextType.SlideLabel;

	public override string DisplayText => LocalizedStrings.Get(LinkedTextType) + " - " + LocalizedStrings.Get(TargetSource);

	public override FormattingType FormattingType => FormattingType.None;

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
				base.UndoStack?.Commit(UndoActionTypes.SlideLabelSource.ToAction(), this, "TargetSource", o, n);
				OnDataModified();
			});
		}
	}

	public static ObjectBinder<SlideLabelTextLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.ISlideLabelText> CreateBinder(SlideLabelTextLinkedObject left, ISlide.Types.IElement.Types.IDataLink.Types.ISlideLabelText right)
	{
		ObjectBinder<SlideLabelTextLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.ISlideLabelText> objectBinder = new ObjectBinder<SlideLabelTextLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.ISlideLabelText>(left, right);
		objectBinder.Bind((SlideLabelTextLinkedObject l) => l.WhenPropertyChanges("TargetSource"), (ISlide.Types.IElement.Types.IDataLink.Types.ISlideLabelText r) => r.SlideLabelSource.WhenValueChanges, delegate(SlideLabelTextLinkedObject l, ISlide.Types.IElement.Types.IDataLink.Types.ISlideLabelText r)
		{
			r.SlideLabelSource.Set(l.TargetSource.ToEntitySlideLabelSource());
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.ISlideLabelText r, SlideLabelTextLinkedObject l)
		{
			l.TargetSource = r.SlideLabelSource.Value.ToSlideTargetSourceMode();
		});
		return objectBinder;
	}

	public SlideLabelTextLinkedObject()
	{
	}

	public SlideLabelTextLinkedObject(SlideTargetSourceMode slideTarget)
	{
		_targetSource = slideTarget;
	}

	public override string GetText(ILinkData? linkData)
	{
		if (linkData == null)
		{
			return LocalizedStrings.Get("TEXT_LINK_SLIDE_LABEL_title");
		}
		return TargetSource switch
		{
			SlideTargetSourceMode.Current => linkData.SlideLabelInfo?.Current?.Text ?? string.Empty, 
			SlideTargetSourceMode.Next => linkData.SlideLabelInfo?.Next?.Text ?? string.Empty, 
			_ => throw new NotSupportedException(), 
		};
	}

	public override bool RenderEquals([NotNullWhen(true)] ILinkedTextObject? other)
	{
		if (other is SlideLabelTextLinkedObject slideLabelTextLinkedObject)
		{
			return slideLabelTextLinkedObject.TargetSource == TargetSource;
		}
		return false;
	}

	public override int GetRenderHashCode()
	{
		return RenderHashCodeHelper.GenerateHashCode(TargetSource);
	}

	public override ILinkedTextObject Clone()
	{
		return new SlideLabelTextLinkedObject(TargetSource);
	}

	public override void Serialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink dataLink)
	{
		dataLink.SlideLabelText = new Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.SlideLabelText
		{
			SlideLabelSource = TargetSource.ToProtoSlideLabelSource()
		};
	}

	public static SlideLabelTextLinkedObject Deserialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.SlideLabelText protoSlideLabel)
	{
		return new SlideLabelTextLinkedObject(protoSlideLabel.SlideLabelSource.ToSlideTargetSourceMode());
	}
}
