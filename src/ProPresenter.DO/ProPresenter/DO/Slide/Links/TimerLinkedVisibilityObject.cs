using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Timer;

namespace ProPresenter.DO.Slide.Links;

public class TimerLinkedVisibilityObject : NotifyPropertyChangedBase, ILinkedVisibilityObject, ILinkedObject, IRenderEquatable<ILinkedVisibilityObject>, IRenderHashable, ICloneable<ILinkedVisibilityObject>, INotifyPropertyChanged
{
	private TimerVisibilityCriteria _selectedCriterion;

	private readonly Func<ITimerCollection?> _getTimers;

	private Guid _timerId = Guid.Empty;

	private string? _timerName;

	public VisibilityLinkType Type => VisibilityLinkType.Timer;

	public string DisplayText => string.Empty;

	public string Content => TimerData?.Name ?? string.Empty;

	public UndoStack? UndoStack { get; set; }

	public TimerVisibilityCriteria SelectedCriterion
	{
		get
		{
			return _selectedCriterion;
		}
		set
		{
			SetValue("SelectedCriterion", ref _selectedCriterion, value, delegate(TimerVisibilityCriteria o, TimerVisibilityCriteria n)
			{
				UndoStack?.Commit(UndoActionTypes.VisibilityLinkChangeTimerCondition.ToAction(), this, "SelectedCriterion", o, n, null, null, autoFinalize: true);
				OnDataModified();
			});
		}
	}

	public Guid TimerID
	{
		get
		{
			return _timerId;
		}
		private set
		{
			SetValue("TimerID", ref _timerId, value, (System.Action)delegate
			{
				OnPropertyChanged("TimerData");
			}, (Predicate<Guid>?)null, referenceComparison: false);
		}
	}

	public string? TimerName
	{
		get
		{
			return _timerName;
		}
		private set
		{
			SetValue("TimerName", ref _timerName, value, (System.Action)delegate
			{
				OnPropertyChanged("TimerData");
			}, (Predicate<string>?)null, referenceComparison: false);
		}
	}

	public TimerData? TimerData
	{
		get
		{
			return _getTimers()?.FirstOrDefaultBy((TimerData t) => t.ID == TimerID, (TimerData t) => t.Name == TimerName);
		}
		set
		{
			Guid previousId = TimerID;
			string previousName = TimerName;
			UndoStack?.Commit(UndoActionTypes.VisibilityLinkChangeCondition.ToAction(), delegate
			{
				TimerID = previousId;
				TimerName = previousName;
			}, delegate
			{
				TimerID = value?.ID ?? Guid.Empty;
				TimerName = value?.Name;
			}, null, null, autoFinalize: true);
			TimerID = value?.ID ?? Guid.Empty;
			TimerName = value?.Name;
			OnPropertyChanged("TimerData");
			OnDataModified();
		}
	}

	public event System.Action? DataModified;

	public static ObjectBinder<TimerLinkedVisibilityObject, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ITimerVisibility> CreateBinder(TimerLinkedVisibilityObject left, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ITimerVisibility right)
	{
		ObjectBinder<TimerLinkedVisibilityObject, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ITimerVisibility> objectBinder = new ObjectBinder<TimerLinkedVisibilityObject, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ITimerVisibility>(left, right);
		objectBinder.Bind((TimerLinkedVisibilityObject l) => l.WhenPropertyChanges("SelectedCriterion"), (ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ITimerVisibility r) => r.VisibilityCriterion.WhenValueChanges, delegate(TimerLinkedVisibilityObject l, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ITimerVisibility r)
		{
			r.VisibilityCriterion.Set(l.SelectedCriterion.ToEntityTimerVisibilityCriteria());
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ITimerVisibility r, TimerLinkedVisibilityObject l)
		{
			l.SelectedCriterion = r.VisibilityCriterion.Value.ToTimerVisibilityCriteria();
		}).Bind((TimerLinkedVisibilityObject l) => l.WhenPropertyChanges("TimerID"), (ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ITimerVisibility r) => r.TimerUuid.WhenValueChanges, delegate(TimerLinkedVisibilityObject l, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ITimerVisibility r)
		{
			r.TimerUuid.Set(l.TimerID);
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ITimerVisibility r, TimerLinkedVisibilityObject l)
		{
			l.TimerID = r.TimerUuid.ToGuidOrEmpty();
		}).Bind((TimerLinkedVisibilityObject l) => l.WhenPropertyChanges("TimerName"), (ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ITimerVisibility r) => r.TimerName.WhenValueChanges, delegate(TimerLinkedVisibilityObject l, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ITimerVisibility r)
		{
			r.TimerName.Set(l.TimerName);
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ITimerVisibility r, TimerLinkedVisibilityObject l)
		{
			l.TimerName = r.TimerName.Value;
		});
		return objectBinder;
	}

	public TimerLinkedVisibilityObject(Func<ITimerCollection?> getTimers)
	{
		_getTimers = getTimers;
	}

	public TimerLinkedVisibilityObject(TimerData timerData, Func<ITimerCollection> getTimers)
		: this(getTimers)
	{
		TimerData = timerData;
	}

	public bool RenderEquals([NotNullWhen(true)] ILinkedVisibilityObject? other)
	{
		if (other is TimerLinkedVisibilityObject timerLinkedVisibilityObject && TimerID == timerLinkedVisibilityObject.TimerID)
		{
			return _selectedCriterion == timerLinkedVisibilityObject._selectedCriterion;
		}
		return false;
	}

	public int GetRenderHashCode()
	{
		return RenderHashCodeHelper.GenerateHashCode(TimerID, _selectedCriterion);
	}

	public ILinkedVisibilityObject Clone()
	{
		return new TimerLinkedVisibilityObject(_getTimers)
		{
			SelectedCriterion = SelectedCriterion,
			TimerID = TimerID,
			TimerName = TimerName
		};
	}

	public void Serialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition protoVisibilityLinkCondition)
	{
		protoVisibilityLinkCondition.TimerVisibility = new Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.TimerVisibility
		{
			TimerUuid = TimerID.ToUUID(),
			TimerName = (TimerName ?? string.Empty),
			VisibilityCriterion = SelectedCriterion.ToProtoTimerVisibilityCriterion()
		};
	}

	public static TimerLinkedVisibilityObject Deserialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.TimerVisibility protoTimerVisibility, Func<ITimerCollection?> getTimers)
	{
		return new TimerLinkedVisibilityObject(getTimers)
		{
			SelectedCriterion = protoTimerVisibility.VisibilityCriterion.ToTimerVisibilityCriteria(),
			TimerID = protoTimerVisibility.TimerUuid.ToGuid(),
			TimerName = protoTimerVisibility.TimerName
		};
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}
}
