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

public class AutoAdvanceLinkedObject : LinkedTextObjectBase
{
	private SourceType _autoAdvanceSource;

	public override LinkedTextType LinkedTextType => LinkedTextType.AutoAdvanceTimeRemaing;

	public override string DisplayText => LocalizedStrings.Get(LinkedTextType) + " - " + LocalizedStrings.Get(AutoAdvanceSource);

	public override FormattingType FormattingType => FormattingType.None;

	public SourceType AutoAdvanceSource
	{
		get
		{
			return _autoAdvanceSource;
		}
		set
		{
			SetValue("AutoAdvanceSource", ref _autoAdvanceSource, value, delegate(SourceType o, SourceType n)
			{
				base.UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.AutoAdvanceSource), this, "AutoAdvanceSource", o, n);
				OnDataModified();
			});
		}
	}

	public TimerFormatData TimerFormatData { get; }

	public static ObjectBinder<AutoAdvanceLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IAutoAdvanceTimeRemaining> CreateBinder(IEntityFactory entityFactory, AutoAdvanceLinkedObject left, ISlide.Types.IElement.Types.IDataLink.Types.IAutoAdvanceTimeRemaining right)
	{
		ObjectBinder<AutoAdvanceLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IAutoAdvanceTimeRemaining> objectBinder = new ObjectBinder<AutoAdvanceLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IAutoAdvanceTimeRemaining>(left, right);
		objectBinder.Bind((AutoAdvanceLinkedObject l) => l.WhenPropertyChanges("TimerFormatData"), (ISlide.Types.IElement.Types.IDataLink.Types.IAutoAdvanceTimeRemaining r) => r.TimerFormat.WhenValueChanges, delegate(AutoAdvanceLinkedObject l, ISlide.Types.IElement.Types.IDataLink.Types.IAutoAdvanceTimeRemaining r)
		{
			ITimer.Types.IFormat format = entityFactory.Create<ITimer.Types.IFormat>();
			r.TimerFormat.Set(format);
			ObjectBinder<TimerFormatData, ITimer.Types.IFormat> objectBinder2 = ProPresenter.DO.Timer.TimerFormatData.CreateBinder(l.TimerFormatData, format);
			objectBinder2.InitializeRightFromLeft();
			format.RegisterLinkedDisposable(objectBinder2);
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.IAutoAdvanceTimeRemaining r, AutoAdvanceLinkedObject l)
		{
			ObjectBinder<TimerFormatData, ITimer.Types.IFormat> objectBinder3 = ProPresenter.DO.Timer.TimerFormatData.CreateBinder(left.TimerFormatData, r.TimerFormat.Value);
			objectBinder3.InitializeLeftFromRight();
			r.TimerFormat.Value.RegisterLinkedDisposable(objectBinder3);
		}).Bind((AutoAdvanceLinkedObject l) => l.WhenPropertyChanges("AutoAdvanceSource"), (ISlide.Types.IElement.Types.IDataLink.Types.IAutoAdvanceTimeRemaining r) => r.AutoAdvanceSource.WhenValueChanges, delegate(AutoAdvanceLinkedObject l, ISlide.Types.IElement.Types.IDataLink.Types.IAutoAdvanceTimeRemaining r)
		{
			r.AutoAdvanceSource.Set(l.AutoAdvanceSource.ToEntityAutoAdvanceSource());
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.IAutoAdvanceTimeRemaining r, AutoAdvanceLinkedObject l)
		{
			l.AutoAdvanceSource = r.AutoAdvanceSource.Value.ToSourceType();
		});
		return objectBinder;
	}

	public AutoAdvanceLinkedObject(TimerFormatData timerFormatData)
	{
		TimerFormatData = timerFormatData;
		TimerFormatData.DataModified += base.OnDataModified;
	}

	public AutoAdvanceLinkedObject()
		: this(new TimerFormatData
		{
			MillisecondFormat = TimerFormatStyle.Long
		})
	{
	}

	public override bool RenderEquals([NotNullWhen(true)] ILinkedTextObject? other)
	{
		if (other is AutoAdvanceLinkedObject autoAdvanceLinkedObject)
		{
			return _autoAdvanceSource == autoAdvanceLinkedObject._autoAdvanceSource;
		}
		return false;
	}

	public override int GetRenderHashCode()
	{
		return _autoAdvanceSource.GetHashCode();
	}

	public override ILinkedTextObject Clone()
	{
		return new AutoAdvanceLinkedObject(TimerFormatData.Clone())
		{
			AutoAdvanceSource = AutoAdvanceSource
		};
	}

	public override void Serialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink dataLink)
	{
		dataLink.AutoAdvanceTimeRemaining = new Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.AutoAdvanceTimeRemaining
		{
			AutoAdvanceSource = AutoAdvanceSource.ToProtoAutoAdvanceSource(),
			TimerFormat = TimerFormatData.Serialize()
		};
	}

	public static AutoAdvanceLinkedObject Deserialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.AutoAdvanceTimeRemaining protoAutoAdvance)
	{
		AutoAdvanceLinkedObject autoAdvanceLinkedObject = new AutoAdvanceLinkedObject();
		autoAdvanceLinkedObject.AutoAdvanceSource = protoAutoAdvance.AutoAdvanceSource.ToSourceType();
		autoAdvanceLinkedObject.TimerFormatData.Deserialize(protoAutoAdvance.TimerFormat);
		return autoAdvanceLinkedObject;
	}

	public override string GetText(ILinkData? linkData)
	{
		if (linkData == null)
		{
			return TimerFormatData.FormatTime(ProPresenter.DO.Timer.TimerFormatData.SampleTime);
		}
		return AutoAdvanceSource switch
		{
			SourceType.Presentation => TimerFormatData.FormatTime(linkData.AutoAdvanceTimeInfo?.Presentation), 
			SourceType.Announcement => TimerFormatData.FormatTime(linkData.AutoAdvanceTimeInfo?.Announcement), 
			_ => string.Empty, 
		};
	}
}
