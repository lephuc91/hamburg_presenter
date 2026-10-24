using System;
using System.Diagnostics.CodeAnalysis;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Application;
using Pro.DO.Triggering;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Actions.Capture;
using ProPresenter.DO.Capture;

namespace ProPresenter.DO.Actions;

public class CaptureAction : ActionBase, IScrimSource, IActionDataIdentifier
{
	private ICapture _capture;

	private readonly ICaptureFactory _captureFactory;

	public override ActionType ActionType => ActionType.Capture;

	public CaptureType CaptureType
	{
		get
		{
			return _capture.CaptureType;
		}
		set
		{
			CaptureType captureType = CaptureType;
			Capture = _captureFactory.Create(value);
			OnPropertyChanged("CaptureType");
			OnPropertyChanged("IsValid");
			OnPropertyChanged("Name");
			base.UndoStack?.Commit(UndoActionTypes.ActionCaptureType.ToAction(), this, "CaptureType", captureType, value);
		}
	}

	protected override string DefaultName => LocalizedStrings.Get(CaptureType);

	protected override bool CanRename => false;

	public ICapture Capture
	{
		get
		{
			return _capture;
		}
		[MemberNotNull("_capture")]
		private set
		{
			SetValue("Capture", ref _capture, value, delegate(ICapture o, ICapture n)
			{
				OnDataModified();
				if (o != null)
				{
					o.DataModified -= base.OnDataModified;
					o.PropertyChanged -= base.RaiseLinkedValues;
					o.Cleanup();
				}
				if (n != null)
				{
					n.DataModified += base.OnDataModified;
					n.PropertyChanged += base.RaiseLinkedValues;
					n.UndoStack = base.UndoStack;
				}
				OnPropertyChanged("CaptureType");
				OnPropertyChanged("IsValid");
			});
		}
	}

	public override bool IsValid => Capture.IsValid;

	public ScrimPosition Position => ScrimPosition.TopLeft;

	public DisplayMode DisplayMode => DisplayMode.Label;

	public bool IsEditable => true;

	public ListViewType ListViewType => ListViewType.Content;

	public static ObjectBinder<Pro.DO.Triggering.IAction, Pro.Entity.IAction> CreateBinder(IUiScheduler scheduler, IEntityFactory entityFactory, CaptureAction left, Pro.Entity.IAction right)
	{
		ObjectBinder<Pro.DO.Triggering.IAction, Pro.Entity.IAction> objectBinder = ActionBase.CreateBinder(scheduler, entityFactory, left, right, delegate
		{
		});
		Pro.Entity.IAction.Types.IActionTypeData.ICapture capture = right.ActionTypeData.Value as Pro.Entity.IAction.Types.IActionTypeData.ICapture;
		if (capture == null)
		{
			capture = entityFactory.Create<Pro.Entity.IAction.Types.IActionTypeData.ICapture>();
			right.ActionTypeData.Set(capture);
		}
		ObjectBinder<CaptureAction, Pro.Entity.IAction.Types.ICaptureType> captureActionBinder = new ObjectBinder<CaptureAction, Pro.Entity.IAction.Types.ICaptureType>(left, capture.Value);
		captureActionBinder.Bind((CaptureAction l) => l.WhenPropertyChanges("Capture"), (Pro.Entity.IAction.Types.ICaptureType r) => r.CaptureAction.WhenValueChanges, delegate(CaptureAction l, Pro.Entity.IAction.Types.ICaptureType r)
		{
			if (l.Capture is CaptureStart captureStart)
			{
				Pro.Entity.IAction.Types.ICaptureType.Types.ICaptureAction.IStart start = entityFactory.Create<Pro.Entity.IAction.Types.ICaptureType.Types.ICaptureAction.IStart>();
				r.CaptureAction.Set(start);
				ObjectBinder<CaptureStart, Pro.Entity.IAction.Types.ICaptureType.Types.ICaptureAction.IStart> objectBinder2 = CreateCaptureStartBinder(scheduler, captureStart, start);
				objectBinder2.InitializeRightFromLeft();
				start.Value.RegisterLinkedDisposable(objectBinder2);
			}
			else if (l.Capture is CaptureStop captureStop)
			{
				Pro.Entity.IAction.Types.ICaptureType.Types.ICaptureAction.IStop stop = entityFactory.Create<Pro.Entity.IAction.Types.ICaptureType.Types.ICaptureAction.IStop>();
				r.CaptureAction.Set(stop);
				ObjectBinder<CaptureStop, Pro.Entity.IAction.Types.ICaptureType.Types.ICaptureAction.IStop> objectBinder3 = CreateCaptureStopBinder(captureStop, stop);
				objectBinder3.InitializeRightFromLeft();
				stop.Value.RegisterLinkedDisposable(objectBinder3);
			}
		}, delegate(Pro.Entity.IAction.Types.ICaptureType r, CaptureAction l)
		{
			if (r.CaptureAction.Value is Pro.Entity.IAction.Types.ICaptureType.Types.ICaptureAction.IStart start2)
			{
				if (l._captureFactory.Create(CaptureType.Start) is CaptureStart captureStart2)
				{
					l.Capture = captureStart2;
					ObjectBinder<CaptureStart, Pro.Entity.IAction.Types.ICaptureType.Types.ICaptureAction.IStart> objectBinder4 = CreateCaptureStartBinder(scheduler, captureStart2, start2);
					objectBinder4.InitializeLeftFromRight();
					start2.Value.RegisterLinkedDisposable(objectBinder4);
				}
			}
			else if (r.CaptureAction.Value is Pro.Entity.IAction.Types.ICaptureType.Types.ICaptureAction.IStop stop2 && l._captureFactory.Create(CaptureType.Stop) is CaptureStop captureStop2)
			{
				l.Capture = captureStop2;
				ObjectBinder<CaptureStop, Pro.Entity.IAction.Types.ICaptureType.Types.ICaptureAction.IStop> objectBinder5 = CreateCaptureStopBinder(captureStop2, stop2);
				objectBinder5.InitializeLeftFromRight();
				stop2.Value.RegisterLinkedDisposable(objectBinder5);
			}
		});
		objectBinder.DoOnInitializeLeftFromRight(captureActionBinder.InitializeLeftFromRight).DoOnInitializeRightFromLeft(captureActionBinder.InitializeRightFromLeft).RegisterChildDisposable(() => captureActionBinder);
		return objectBinder;
	}

	private static ObjectBinder<CaptureStart, Pro.Entity.IAction.Types.ICaptureType.Types.ICaptureAction.IStart> CreateCaptureStartBinder(IUiScheduler scheduler, CaptureStart captureStart, Pro.Entity.IAction.Types.ICaptureType.Types.ICaptureAction.IStart entityStart)
	{
		ObjectBinder<CaptureStart, Pro.Entity.IAction.Types.ICaptureType.Types.ICaptureAction.IStart> objectBinder = new ObjectBinder<CaptureStart, Pro.Entity.IAction.Types.ICaptureType.Types.ICaptureAction.IStart>(captureStart, entityStart);
		objectBinder.Bind((CaptureStart l) => l.WhenPropertyChanges("PresetIdentifier"), (Pro.Entity.IAction.Types.ICaptureType.Types.ICaptureAction.IStart r) => r.Value.PresetIdentification.WhenAnyValueChanges, delegate(CaptureStart l, Pro.Entity.IAction.Types.ICaptureType.Types.ICaptureAction.IStart r)
		{
			r.Value.PresetIdentification.Value?.ParameterUuid.Set(l.PresetIdentifier.ID);
			r.Value.PresetIdentification.Value?.ParameterName.Set(l.PresetIdentifier.Name);
		}, delegate(Pro.Entity.IAction.Types.ICaptureType.Types.ICaptureAction.IStart r, CaptureStart l)
		{
			l.PresetIdentifier = new Identifier(r.Value.PresetIdentification.Value?.ParameterUuid?.ToGuidOrEmpty() ?? Guid.Empty, r.Value.PresetIdentification.Value?.ParameterName.Value ?? string.Empty);
		}, scheduler.Scheduler);
		return objectBinder;
	}

	private static ObjectBinder<CaptureStop, Pro.Entity.IAction.Types.ICaptureType.Types.ICaptureAction.IStop> CreateCaptureStopBinder(CaptureStop captureStop, Pro.Entity.IAction.Types.ICaptureType.Types.ICaptureAction.IStop entityStop)
	{
		ObjectBinder<CaptureStop, Pro.Entity.IAction.Types.ICaptureType.Types.ICaptureAction.IStop> objectBinder = new ObjectBinder<CaptureStop, Pro.Entity.IAction.Types.ICaptureType.Types.ICaptureAction.IStop>(captureStop, entityStop);
		objectBinder.Bind((CaptureStop l) => l.WhenPropertyChanges("ShowAlertBeforeStopping"), (Pro.Entity.IAction.Types.ICaptureType.Types.ICaptureAction.IStop r) => r.Value.ShowsAlertBeforeStopping.WhenValueChanges, delegate(CaptureStop l, Pro.Entity.IAction.Types.ICaptureType.Types.ICaptureAction.IStop r)
		{
			r.Value.ShowsAlertBeforeStopping.Set(l.ShowAlertBeforeStopping);
		}, delegate(Pro.Entity.IAction.Types.ICaptureType.Types.ICaptureAction.IStop r, CaptureStop l)
		{
			l.ShowAlertBeforeStopping = r.Value.ShowsAlertBeforeStopping.Value;
		});
		return objectBinder;
	}

	public CaptureAction(ICaptureSettingsDocument captureSettingsDocument, IResiService resiService)
		: this(new CaptureFactory(captureSettingsDocument, resiService))
	{
	}

	public CaptureAction(ICaptureFactory captureFactory)
	{
		_captureFactory = captureFactory;
		LinkProperties("IsValid", "IsValid");
		Capture = _captureFactory.Create(CaptureType.Start);
	}

	public override Pro.DO.Triggering.IAction Clone()
	{
		CaptureAction captureAction = new CaptureAction(_captureFactory)
		{
			CaptureType = CaptureType
		};
		CopyProperties(captureAction);
		Capture.CopyProperties(captureAction.Capture);
		return captureAction;
	}

	public override Pro.SerializationInterop.RVProtoData.Action Serialize()
	{
		Pro.SerializationInterop.RVProtoData.Action action = base.Serialize();
		action.Capture = new Pro.SerializationInterop.RVProtoData.Action.Types.CaptureType();
		Capture.Serialize(action.Capture);
		return action;
	}

	public override void Deserialize(Pro.SerializationInterop.RVProtoData.Action data, ApplicationData? applicationData, string containerId)
	{
		base.Deserialize(data, applicationData, containerId);
		Capture = _captureFactory.Create(data.Capture);
	}

	protected override void OnUndoStackChanged(UndoStack undoStack)
	{
		Capture.UndoStack = undoStack;
	}

	public void SetIdentifier(Guid id, string name)
	{
		CaptureType = CaptureType.Start;
		if (Capture is CaptureStart captureStart)
		{
			captureStart.PresetIdentifier = new Identifier(id, name);
		}
	}
}
