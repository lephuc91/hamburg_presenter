using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reactive.Linq;
using Pro.Common.Components.Reversibility;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Custom.Elements.Fills;

namespace ProPresenter.DO.Slide.Links;

public class OutputScreenLinkedObject : LinkedFillObjectBase
{
	private Guid? _screenID;

	private string? _screenName;

	private ScreenArrangementBase? _screen;

	public override LinkedFillType LinkedFillType => LinkedFillType.PreviewScreen;

	public override string DisplayText => LocalizedStrings.Get(LinkedFillType) + " - " + (Screen?.Name ?? _screenName);

	public Guid? ScreenID => _screenID ?? Screen?.ID;

	public string? ScreenName
	{
		get
		{
			string text = _screenName;
			if (text == null)
			{
				ScreenArrangementBase? screen = Screen;
				if (screen == null)
				{
					return null;
				}
				text = screen.Name;
			}
			return text;
		}
	}

	public ScreenArrangementBase? Screen
	{
		get
		{
			return _screen;
		}
		set
		{
			SetValue<ScreenArrangementBase>("Screen", ref _screen, value, delegate(ScreenArrangementBase o, ScreenArrangementBase n)
			{
				if (o != null)
				{
					o.PropertyChanged -= Screen_PropertyChanged;
				}
				if (n != null)
				{
					n.PropertyChanged += Screen_PropertyChanged;
				}
				_screenID = n?.ID;
				_screenName = n?.Name;
				base.UndoStack?.Commit(UndoActionTypes.LinkScreen.ToAction(), this, "Screen", o, n, null, null, autoFinalize: true);
			});
		}
	}

	public static ObjectBinder<OutputScreenLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IOutputScreen> CreateBinder(OutputScreenLinkedObject left, ISlide.Types.IElement.Types.IDataLink.Types.IOutputScreen right)
	{
		ObjectBinder<OutputScreenLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IOutputScreen> objectBinder = new ObjectBinder<OutputScreenLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IOutputScreen>(left, right);
		objectBinder.Bind((OutputScreenLinkedObject l) => l.WhenPropertyChanges("Screen"), (ISlide.Types.IElement.Types.IDataLink.Types.IOutputScreen r) => r.ScreenId.WhenValueChanges.ToUnit().Merge(r.ScreenName.WhenValueChanges.ToUnit()), delegate(OutputScreenLinkedObject l, ISlide.Types.IElement.Types.IDataLink.Types.IOutputScreen r)
		{
			r.ScreenId.Set(l.Screen?.ID);
			r.ScreenName.Set(l.Screen?.Name);
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.IOutputScreen r, OutputScreenLinkedObject l)
		{
			l._screenID = r.ScreenId.ToGuidOrEmpty();
			l._screenName = r.ScreenName.Value;
		});
		return objectBinder;
	}

	private OutputScreenLinkedObject(ScreenArrangementBase? screen, Guid? screenID, string? screenName)
		: this(screen)
	{
		_screenID = ((screen != null) ? new Guid?(screen.ID) : screenID);
		_screenName = screen?.Name ?? screenName;
	}

	public OutputScreenLinkedObject(ScreenArrangementBase? screen)
	{
		base.UndoStack?.StartIgnoring();
		Screen = screen;
		base.UndoStack?.StopIgnoring();
	}

	public override bool RenderEquals([NotNullWhen(true)] ILinkedFillObject? other)
	{
		if (other is OutputScreenLinkedObject outputScreenLinkedObject && _screenID == outputScreenLinkedObject._screenID)
		{
			return _screenName == outputScreenLinkedObject._screenName;
		}
		return false;
	}

	public override int GetRenderHashCode()
	{
		return RenderHashCodeHelper.GenerateHashCode(_screenID, _screenName);
	}

	public override IFill? GetFill(ILinkData? linkData)
	{
		return new OutputScreenFill();
	}

	public override ILinkedFillObject Clone()
	{
		return new OutputScreenLinkedObject(Screen);
	}

	public override void Serialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink dataLink)
	{
		dataLink.OutputScreen = new Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.OutputScreen
		{
			ScreenId = _screenID?.ToUUID(),
			ScreenName = (_screenName ?? string.Empty)
		};
	}

	internal static ILinkedFillObject Deserialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.OutputScreen outputScreen, IEnumerable<ScreenArrangementBase> otherScreens)
	{
		Guid? screenID = outputScreen?.ScreenId.ToGuid();
		string screenName = outputScreen?.ScreenName;
		return new OutputScreenLinkedObject((outputScreen != null) ? (otherScreens.FirstOrDefault(delegate(ScreenArrangementBase s)
		{
			Guid iD = s.ID;
			Guid? guid = screenID;
			return iD == guid;
		}) ?? otherScreens.FirstOrDefault((ScreenArrangementBase s) => s.Name == screenName)) : null, screenID, screenName);
	}

	private void Screen_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "Name")
		{
			OnPropertyChanged("DisplayText");
		}
	}
}
