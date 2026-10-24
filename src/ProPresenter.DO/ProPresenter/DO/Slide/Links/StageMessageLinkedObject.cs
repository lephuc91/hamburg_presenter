using System.Diagnostics.CodeAnalysis;
using System.Windows.Media;
using Pro.Common.Components.Reversibility;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Links;

public class StageMessageLinkedObject : LinkedTextObjectBase
{
	private static readonly System.Windows.Media.Color DefaultColor = Colors.Green;

	private bool _shouldFlash = true;

	private System.Windows.Media.Color _flashColor = DefaultColor;

	public override LinkedTextType LinkedTextType => LinkedTextType.StageMessage;

	public override string DisplayText => LocalizedStrings.Get("TEXT_LINK_STAGE_MESSAGE_title");

	public override FormattingType FormattingType => FormattingType.None;

	public bool ShouldFlash
	{
		get
		{
			return _shouldFlash;
		}
		set
		{
			SetValue("ShouldFlash", ref _shouldFlash, value, delegate(bool o, bool n)
			{
				base.UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.StageMessageShouldFlash), this, "ShouldFlash", o, n, null, null, autoFinalize: true);
			});
		}
	}

	public System.Windows.Media.Color FlashColor
	{
		get
		{
			return _flashColor;
		}
		set
		{
			SetValue("FlashColor", ref _flashColor, value, delegate(System.Windows.Media.Color o, System.Windows.Media.Color n)
			{
				base.UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.StageMessageFlashColor), this, "FlashColor", o, n);
			});
		}
	}

	public static ObjectBinder<StageMessageLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IStageMessage> CreateBinder(StageMessageLinkedObject left, ISlide.Types.IElement.Types.IDataLink.Types.IStageMessage right)
	{
		ObjectBinder<StageMessageLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IStageMessage> objectBinder = new ObjectBinder<StageMessageLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IStageMessage>(left, right);
		objectBinder.Bind((StageMessageLinkedObject l) => l.WhenPropertyChanges("FlashColor"), (ISlide.Types.IElement.Types.IDataLink.Types.IStageMessage r) => r.FlashColor.WhenValueChanges, delegate(StageMessageLinkedObject l, ISlide.Types.IElement.Types.IDataLink.Types.IStageMessage r)
		{
			r.FlashColor.Set(l.FlashColor.ToEntityColor());
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.IStageMessage r, StageMessageLinkedObject l)
		{
			l.FlashColor = r.FlashColor.Value.ToColor();
		}).Bind((StageMessageLinkedObject l) => l.WhenPropertyChanges("ShouldFlash"), (ISlide.Types.IElement.Types.IDataLink.Types.IStageMessage r) => r.ShouldFlash.WhenValueChanges, delegate(StageMessageLinkedObject l, ISlide.Types.IElement.Types.IDataLink.Types.IStageMessage r)
		{
			r.ShouldFlash.Set(l.ShouldFlash);
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.IStageMessage r, StageMessageLinkedObject l)
		{
			l.ShouldFlash = r.ShouldFlash.Value;
		});
		return objectBinder;
	}

	public override bool RenderEquals([NotNullWhen(true)] ILinkedTextObject? other)
	{
		if (other is StageMessageLinkedObject stageMessageLinkedObject && _shouldFlash == stageMessageLinkedObject._shouldFlash)
		{
			return _flashColor == stageMessageLinkedObject._flashColor;
		}
		return false;
	}

	public override int GetRenderHashCode()
	{
		return RenderHashCodeHelper.GenerateHashCode(_shouldFlash, _flashColor);
	}

	public override string GetText(ILinkData? linkData)
	{
		return linkData?.StageMessage ?? DisplayText;
	}

	public override ILinkedTextObject Clone()
	{
		return new StageMessageLinkedObject
		{
			ShouldFlash = ShouldFlash,
			FlashColor = FlashColor
		};
	}

	public override void Serialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink dataLink)
	{
		dataLink.StageMessage = new Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.StageMessage
		{
			FlashColor = FlashColor.ToProtoColor(),
			ShouldFlash = ShouldFlash
		};
	}

	public static StageMessageLinkedObject Deserialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.StageMessage protoStageMessage)
	{
		return new StageMessageLinkedObject
		{
			FlashColor = (protoStageMessage.FlashColor?.ToColor() ?? DefaultColor),
			ShouldFlash = protoStageMessage.ShouldFlash
		};
	}
}
