using System.Diagnostics.CodeAnalysis;
using Pro.Common.Components.Reversibility;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.PCO;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Custom.Elements.Fills;

namespace ProPresenter.DO.Slide.Links;

public class PCOLiveLinkedObject : LinkedFillObjectBase
{
	private PCOLiveTheme _theme = PCOLiveTheme.Dark;

	private PCOLiveCountdownType _countdownType;

	public override LinkedFillType LinkedFillType => LinkedFillType.PCOLive;

	public override string DisplayText => LocalizedStrings.Get("FILL_LINK_PLANNING_CENTER_title");

	public PCOLiveTheme Theme
	{
		get
		{
			return _theme;
		}
		set
		{
			SetValue("Theme", ref _theme, value, delegate(PCOLiveTheme o, PCOLiveTheme n)
			{
				base.UndoStack?.Commit(UndoActionTypes.PCOLiveTheme.ToAction(), this, "Theme", o, n, null, null, autoFinalize: true);
			});
		}
	}

	public PCOLiveCountdownType CountdownType
	{
		get
		{
			return _countdownType;
		}
		set
		{
			SetValue("CountdownType", ref _countdownType, value, delegate(PCOLiveCountdownType o, PCOLiveCountdownType n)
			{
				base.UndoStack?.Commit(UndoActionTypes.PCOLiveCountdownType.ToAction(), this, "CountdownType", o, n, null, null, autoFinalize: true);
			});
		}
	}

	public static ObjectBinder<PCOLiveLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IPcoLive> CreateBinder(PCOLiveLinkedObject left, ISlide.Types.IElement.Types.IDataLink.Types.IPcoLive right)
	{
		ObjectBinder<PCOLiveLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IPcoLive> objectBinder = new ObjectBinder<PCOLiveLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IPcoLive>(left, right);
		objectBinder.Bind((PCOLiveLinkedObject l) => l.WhenPropertyChanges("CountdownType"), (ISlide.Types.IElement.Types.IDataLink.Types.IPcoLive r) => r.CountdownType.WhenValueChanges, delegate(PCOLiveLinkedObject l, ISlide.Types.IElement.Types.IDataLink.Types.IPcoLive r)
		{
			r.CountdownType.Set(l.CountdownType.ToEntityPCOLiveCountdownType());
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.IPcoLive r, PCOLiveLinkedObject l)
		{
			l.CountdownType = r.CountdownType.Value.ToPCOLiveCountdownType();
		}).Bind((PCOLiveLinkedObject l) => l.WhenPropertyChanges("Theme"), (ISlide.Types.IElement.Types.IDataLink.Types.IPcoLive r) => r.Theme.WhenValueChanges, delegate(PCOLiveLinkedObject l, ISlide.Types.IElement.Types.IDataLink.Types.IPcoLive r)
		{
			r.Theme.Set(l.Theme.ToEntityPCOLiveTheme());
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.IPcoLive r, PCOLiveLinkedObject l)
		{
			l.Theme = r.Theme.Value.ToPCOLiveTheme();
		});
		return objectBinder;
	}

	public PCOLiveLinkedObject()
		: this(PCOLiveTheme.Light, PCOLiveCountdownType.FullItemLength)
	{
	}

	public PCOLiveLinkedObject(PCOLiveTheme theme, PCOLiveCountdownType countdownType)
	{
		_theme = theme;
		_countdownType = countdownType;
	}

	public override bool RenderEquals([NotNullWhen(true)] ILinkedFillObject? other)
	{
		if (other is PCOLiveLinkedObject pCOLiveLinkedObject && _theme == pCOLiveLinkedObject._theme)
		{
			return _countdownType == pCOLiveLinkedObject._countdownType;
		}
		return false;
	}

	public override int GetRenderHashCode()
	{
		return RenderHashCodeHelper.GenerateHashCode(_theme, _countdownType);
	}

	public override IFill? GetFill(ILinkData? linkData)
	{
		if (linkData?.PCOLiveInformation?.Bitmap == null)
		{
			return null;
		}
		return new BitmapFill(linkData.PCOLiveInformation.Bitmap);
	}

	public override ILinkedFillObject Clone()
	{
		return new PCOLiveLinkedObject(Theme, CountdownType);
	}

	public override void Serialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink dataLink)
	{
		dataLink.PcoLive = new Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PCOLive
		{
			CountdownType = CountdownType.ToProtoPCOLiveCountdownType(),
			Theme = Theme.ToProtoPCOLiveTheme()
		};
	}

	internal static PCOLiveLinkedObject Deserialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PCOLive protoPCOLive)
	{
		return new PCOLiveLinkedObject(protoPCOLive.Theme.ToPCOLiveTheme(), protoPCOLive.CountdownType.ToPCOLiveCountdownType());
	}
}
