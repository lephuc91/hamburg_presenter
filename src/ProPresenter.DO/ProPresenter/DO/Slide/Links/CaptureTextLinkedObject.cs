using System.Diagnostics.CodeAnalysis;
using Pro.Common.Components.Reversibility;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Timer;

namespace ProPresenter.DO.Slide.Links;

public class CaptureTextLinkedObject : LinkedTextObjectBase
{
	private CaptureTextType _captureTextType;

	public override LinkedTextType LinkedTextType => LinkedTextType.Capture;

	public override string DisplayText => LocalizedStrings.Get(LinkedTextType) + " - " + LocalizedStrings.Get(CaptureTextType);

	public override FormattingType FormattingType => FormattingType.None;

	public CaptureTextType CaptureTextType
	{
		get
		{
			return _captureTextType;
		}
		set
		{
			SetValue("CaptureTextType", ref _captureTextType, value, delegate(CaptureTextType o, CaptureTextType n)
			{
				base.UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.Capture), this, "CaptureTextType", o, n);
				OnDataModified();
			});
		}
	}

	public TimerFormatData TimerFormatData { get; }

	public static ObjectBinder<CaptureTextLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.ICaptureStatusText> CreateBinder(IEntityFactory entityFactory, CaptureTextLinkedObject left, ISlide.Types.IElement.Types.IDataLink.Types.ICaptureStatusText right)
	{
		ObjectBinder<CaptureTextLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.ICaptureStatusText> objectBinder = new ObjectBinder<CaptureTextLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.ICaptureStatusText>(left, right);
		objectBinder.Bind((CaptureTextLinkedObject l) => l.WhenPropertyChanges("CaptureTextType"), (ISlide.Types.IElement.Types.IDataLink.Types.ICaptureStatusText r) => r.TextType.WhenValueChanges, delegate(CaptureTextLinkedObject l, ISlide.Types.IElement.Types.IDataLink.Types.ICaptureStatusText r)
		{
			switch (l.CaptureTextType)
			{
			case CaptureTextType.StatusText:
				r.TextType.Set(entityFactory.Create<ISlide.Types.IElement.Types.IDataLink.Types.ICaptureStatusText.Types.ITextType.IStatusText>());
				break;
			case CaptureTextType.ElapsedTime:
			{
				ISlide.Types.IElement.Types.IDataLink.Types.ICaptureStatusText.Types.ITextType.IElapsedTime elapsedTime = entityFactory.Create<ISlide.Types.IElement.Types.IDataLink.Types.ICaptureStatusText.Types.ITextType.IElapsedTime>();
				r.TextType.Set(elapsedTime);
				ObjectBinder<TimerFormatData, ITimer.Types.IFormat> objectBinder2 = ProPresenter.DO.Timer.TimerFormatData.CreateBinder(l.TimerFormatData, elapsedTime.Value.TimerFormat.Value);
				objectBinder2.InitializeRightFromLeft();
				elapsedTime.Value.TimerFormat.Value.RegisterLinkedDisposable(objectBinder2);
				break;
			}
			}
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.ICaptureStatusText r, CaptureTextLinkedObject l)
		{
			ISlide.Types.IElement.Types.IDataLink.Types.ICaptureStatusText.Types.ITextType value = r.TextType.Value;
			if (!(value is ISlide.Types.IElement.Types.IDataLink.Types.ICaptureStatusText.Types.ITextType.IStatusText))
			{
				if (value is ISlide.Types.IElement.Types.IDataLink.Types.ICaptureStatusText.Types.ITextType.IElapsedTime elapsedTime2)
				{
					l.CaptureTextType = CaptureTextType.ElapsedTime;
					ObjectBinder<TimerFormatData, ITimer.Types.IFormat> objectBinder3 = ProPresenter.DO.Timer.TimerFormatData.CreateBinder(l.TimerFormatData, elapsedTime2.Value.TimerFormat.Value);
					objectBinder3.InitializeLeftFromRight();
					elapsedTime2.Value.TimerFormat.Value.RegisterLinkedDisposable(objectBinder3);
				}
			}
			else
			{
				l.CaptureTextType = CaptureTextType.StatusText;
			}
		});
		return objectBinder;
	}

	public CaptureTextLinkedObject(TimerFormatData timerFormatData)
	{
		TimerFormatData = timerFormatData;
		TimerFormatData.DataModified += base.OnDataModified;
	}

	public CaptureTextLinkedObject()
		: this(new TimerFormatData
		{
			MillisecondFormat = TimerFormatStyle.None
		})
	{
	}

	public override bool RenderEquals([NotNullWhen(true)] ILinkedTextObject? other)
	{
		if (other is CaptureTextLinkedObject captureTextLinkedObject)
		{
			return _captureTextType == captureTextLinkedObject._captureTextType;
		}
		return false;
	}

	public override int GetRenderHashCode()
	{
		return _captureTextType.GetHashCode();
	}

	public override ILinkedTextObject Clone()
	{
		return new CaptureTextLinkedObject(TimerFormatData.Clone())
		{
			CaptureTextType = CaptureTextType
		};
	}

	public override void Serialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink dataLink)
	{
		dataLink.CaptureStatusText = new Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.CaptureStatusText();
		switch (CaptureTextType)
		{
		case CaptureTextType.StatusText:
			dataLink.CaptureStatusText.StatusText = new Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.CaptureStatusText.Types.StatusText();
			break;
		case CaptureTextType.ElapsedTime:
			dataLink.CaptureStatusText.ElapsedTime = new Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.CaptureStatusText.Types.ElapsedTime
			{
				TimerFormat = TimerFormatData.Serialize()
			};
			break;
		}
	}

	public static CaptureTextLinkedObject Deserialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.CaptureStatusText protoCaptureText)
	{
		CaptureTextLinkedObject captureTextLinkedObject = new CaptureTextLinkedObject
		{
			CaptureTextType = protoCaptureText.TextTypeCase.ToCaptureTextType()
		};
		if (captureTextLinkedObject.CaptureTextType == CaptureTextType.ElapsedTime)
		{
			captureTextLinkedObject.TimerFormatData.Deserialize(protoCaptureText.ElapsedTime.TimerFormat);
		}
		return captureTextLinkedObject;
	}

	public override string GetText(ILinkData? linkData)
	{
		switch (CaptureTextType)
		{
		case CaptureTextType.StatusText:
		{
			object obj;
			if (linkData != null)
			{
				obj = linkData.CaptureInformation?.StatusText;
				if (obj == null)
				{
					return LocalizedStrings.Get("TEXT_LINK_CAPTURE_STATUS_INACTIVE_title");
				}
			}
			else
			{
				obj = LocalizedStrings.Get("TEXT_LINK_CAPTURE_STATUS_PLACEHOLDER_title");
			}
			return (string)obj;
		}
		case CaptureTextType.ElapsedTime:
			return TimerFormatData.FormatTime(linkData?.CaptureInformation?.ElapsedTime ?? ProPresenter.DO.Timer.TimerFormatData.SampleTime);
		default:
			return string.Empty;
		}
	}
}
