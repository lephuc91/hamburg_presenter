using System;
using System.Diagnostics.CodeAnalysis;
using Pro.Common.Components.Reversibility;
using Pro.Common.Mathematics;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Timer;

namespace ProPresenter.DO.Slide.Links;

public class ClockTextLinkedObject : LinkedTextObjectBase
{
	private const string TokenFormat = "${clock}";

	private string _displayFormat = string.Empty;

	public override LinkedTextType LinkedTextType => LinkedTextType.Clock;

	public override string DisplayText => LocalizedStrings.Get("TEXT_LINK_SYSTEM_CLOCK_title");

	public override FormattingType FormattingType => FormattingType.None;

	public ClockData ClockData { get; }

	public ClockTokenCollection Tokens { get; }

	public string DisplayFormatText
	{
		get
		{
			return _displayFormat;
		}
		set
		{
			SetValue("DisplayFormatText", ref _displayFormat, value, delegate(string o, string n)
			{
				base.UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.LinkFormatText), this, "DisplayFormatText", o, n);
			});
		}
	}

	public static ObjectBinder<ClockTextLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IClockText> CreateBinder(IEntityFactory entityFactory, ClockTextLinkedObject left, ISlide.Types.IElement.Types.IDataLink.Types.IClockText right)
	{
		ObjectBinder<ClockTextLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IClockText> objectBinder = new ObjectBinder<ClockTextLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IClockText>(left, right);
		objectBinder.Bind((ClockTextLinkedObject l) => l.WhenPropertyChanges("DisplayFormatText"), (ISlide.Types.IElement.Types.IDataLink.Types.IClockText r) => r.ClockFormatString.WhenValueChanges, delegate(ClockTextLinkedObject l, ISlide.Types.IElement.Types.IDataLink.Types.IClockText r)
		{
			r.ClockFormatString.Set(l.DisplayFormatText.Insert(l.Tokens.ClockToken.Index.Clamp(0, l.DisplayFormatText.Length), "${clock}"));
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.IClockText r, ClockTextLinkedObject l)
		{
			l.Tokens.ClockToken.Index = r.ClockFormatString.Value.IndexOf("${clock}");
			l.DisplayFormatText = r.ClockFormatString.Value.Replace("${clock}", string.Empty);
		}).Bind((ClockTextLinkedObject l) => l.WhenPropertyChanges("ClockData"), (ISlide.Types.IElement.Types.IDataLink.Types.IClockText r) => r.Format.WhenValueChanges, delegate(ClockTextLinkedObject l, ISlide.Types.IElement.Types.IDataLink.Types.IClockText r)
		{
			IClock.Types.IFormat format = entityFactory.Create<IClock.Types.IFormat>();
			r.Format.Set(format);
			ObjectBinder<ClockData, IClock.Types.IFormat> objectBinder2 = ProPresenter.DO.Timer.ClockData.CreateBinder(l.ClockData, format);
			objectBinder2.InitializeRightFromLeft();
			format.RegisterLinkedDisposable(objectBinder2);
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.IClockText r, ClockTextLinkedObject l)
		{
			ObjectBinder<ClockData, IClock.Types.IFormat> objectBinder3 = ProPresenter.DO.Timer.ClockData.CreateBinder(l.ClockData, r.Format.Value);
			objectBinder3.InitializeLeftFromRight();
			r.Format.Value.RegisterLinkedDisposable(objectBinder3);
		});
		return objectBinder;
	}

	public ClockTextLinkedObject(ClockData clockData)
	{
		ClockData = clockData;
		ClockData.DataModified += delegate
		{
			OnPropertyChanged("ClockData");
		};
		Tokens = new ClockTokenCollection(clockData);
		Tokens.CollectionModified += delegate
		{
			OnPropertyChanged("Tokens");
		};
	}

	public ClockTextLinkedObject()
		: this(new ClockData())
	{
	}

	public override bool RenderEquals([NotNullWhen(true)] ILinkedTextObject? other)
	{
		return other is ClockTextLinkedObject;
	}

	public override int GetRenderHashCode()
	{
		return 0;
	}

	public override string GetText(ILinkData? linkData)
	{
		return FormatDate((linkData == null) ? ProPresenter.DO.Timer.ClockData.SampleDate : DateTime.Now);
	}

	private string FormatDate(DateTime dateTime)
	{
		return DisplayFormatText.Insert(Tokens.ClockToken.Index.Clamp(0, DisplayFormatText.Length), ClockData.FormatDateTime(dateTime));
	}

	protected override void OnUndoStackChanged(UndoStack? undoStack)
	{
		ClockTokenCollection tokens = Tokens;
		UndoStack undoStack3 = (ClockData.UndoStack = undoStack);
		tokens.UndoStack = undoStack3;
	}

	public override ILinkedTextObject Clone()
	{
		ClockTextLinkedObject clockTextLinkedObject = new ClockTextLinkedObject(new ClockData
		{
			DateFormatLength = ClockData.DateFormatLength,
			TimeFormatLength = ClockData.TimeFormatLength,
			Use24HourFormat = ClockData.Use24HourFormat
		});
		clockTextLinkedObject.DisplayFormatText = DisplayFormatText;
		clockTextLinkedObject.Tokens.ClockToken.Index = Tokens.ClockToken.Index;
		return clockTextLinkedObject;
	}

	public override void Serialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink dataLink)
	{
		dataLink.ClockText = new Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.ClockText
		{
			ClockFormatString = DisplayFormatText.Insert(Tokens.ClockToken.Index.Clamp(0, DisplayFormatText.Length), "${clock}"),
			Format = ClockData.Serialize()
		};
	}

	public static ClockTextLinkedObject? Deserialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.ClockText protoClockText)
	{
		if (protoClockText == null)
		{
			return null;
		}
		ClockTextLinkedObject clockTextLinkedObject = new ClockTextLinkedObject(new ClockData
		{
			DateFormatLength = protoClockText.Format.DateType.ToFormatLength(),
			TimeFormatLength = protoClockText.Format.TimeFormat.ToFormatLength(),
			Use24HourFormat = protoClockText.Format.MilitaryTimeEnabled
		});
		clockTextLinkedObject.Tokens.ClockToken.Index = protoClockText.ClockFormatString.IndexOf("${clock}");
		clockTextLinkedObject.DisplayFormatText = protoClockText.ClockFormatString.Replace("${clock}", string.Empty);
		return clockTextLinkedObject;
	}
}
