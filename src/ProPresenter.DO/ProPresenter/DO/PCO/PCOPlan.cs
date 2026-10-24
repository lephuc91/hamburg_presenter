using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using Pro.Common.Nullability;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.PCO.Extensions;
using ProPresenter.DO.PCO.Items;

namespace ProPresenter.DO.PCO;

public class PCOPlan : PCOObject, IPCOAttachmentsContainer
{
	private string? _dates;

	private string? _seriesTitle;

	private DateTime? _lastUpdated;

	private DateTime? _created;

	private PCOItem[]? _planItems;

	private List<PCOAttachmentDetails> _attachments = new List<PCOAttachmentDetails>();

	private string _serviceTypeId;

	public Guid UUID { get; } = Guid.NewGuid();

	public string ServiceTypeID
	{
		get
		{
			return _serviceTypeId;
		}
		private set
		{
			SetValue("ServiceTypeID", ref _serviceTypeId, value);
		}
	}

	public bool IsPlanItemsLoaded => PlanItems?.Any() ?? false;

	public PCOItem[]? PlanItems
	{
		get
		{
			return _planItems;
		}
		private set
		{
			SetValue("PlanItems", ref _planItems, value);
		}
	}

	public IEnumerable<PCOAttachmentDetails> Attachments => _attachments;

	public DateTime? LastUpdated
	{
		get
		{
			return _lastUpdated;
		}
		private set
		{
			SetValue("LastUpdated", ref _lastUpdated, value);
		}
	}

	public DateTime? Created
	{
		get
		{
			return _created;
		}
		private set
		{
			SetValue("Created", ref _created, value);
		}
	}

	public string? Dates
	{
		get
		{
			return _dates;
		}
		private set
		{
			SetValue("Dates", ref _dates, value);
		}
	}

	public string? SeriesTitle
	{
		get
		{
			return _seriesTitle;
		}
		private set
		{
			SetValue("SeriesTitle", ref _seriesTitle, value);
		}
	}

	public event Action<PCOPlan>? DataModified;

	public static ObjectBinder<PCOPlan, IPlanningCenterPlan> CreateBinder(PCOPlan? left, IPlanningCenterPlan right)
	{
		ObjectBinder<PCOPlan, IPlanningCenterPlan> objectBinder = new ObjectBinder<PCOPlan, IPlanningCenterPlan>(left, right);
		objectBinder.Bind((PCOPlan l) => l.WhenPropertyChanges("ID"), (IPlanningCenterPlan r) => r.PlanIdNum.WhenValueChanges.ToUnit().Merge(r.PlanIdStr.WhenValueChanges.ToUnit()), delegate(PCOPlan l, IPlanningCenterPlan r)
		{
			r.PlanIdNum.Set(l.ID.ToUintId());
			r.PlanIdStr.Set(l.ID ?? string.Empty);
		}, delegate(IPlanningCenterPlan r, PCOPlan l)
		{
			l.ID = (string.IsNullOrEmpty(r.PlanIdStr.Value) ? r.PlanIdNum.Value.ToString() : r.PlanIdStr.Value);
		}).Bind((PCOPlan l) => l.WhenPropertyChanges("ServiceTypeID"), (IPlanningCenterPlan r) => r.ParentIdNum.WhenValueChanges.ToUnit().Merge(r.ParentIdStr.WhenValueChanges.ToUnit()), delegate(PCOPlan l, IPlanningCenterPlan r)
		{
			r.ParentIdNum.Set(l.ServiceTypeID.ToUintId());
			r.ParentIdStr.Set(l.ServiceTypeID ?? string.Empty);
		}, delegate(IPlanningCenterPlan r, PCOPlan l)
		{
			l.ServiceTypeID = (string.IsNullOrEmpty(r.ParentIdStr.Value) ? (r.ParentIdNum.Value.ToString() ?? string.Empty) : r.ParentIdStr.Value);
		}).Bind((PCOPlan l) => l.WhenPropertyChanges("SeriesTitle"), (IPlanningCenterPlan r) => r.SeriesTitle.WhenValueChanges.ToUnit(), delegate(PCOPlan l, IPlanningCenterPlan r)
		{
			r.SeriesTitle.Set(l.SeriesTitle ?? string.Empty);
		}, delegate(IPlanningCenterPlan r, PCOPlan l)
		{
			l.SeriesTitle = r.SeriesTitle.Value ?? string.Empty;
		})
			.Bind((PCOPlan l) => l.WhenPropertyChanges("Name"), (IPlanningCenterPlan r) => r.PlanTitle.WhenValueChanges, delegate(PCOPlan l, IPlanningCenterPlan r)
			{
				r.PlanTitle.Set(l.Name ?? string.Empty);
			}, delegate(IPlanningCenterPlan r, PCOPlan l)
			{
				l.Name = r.PlanTitle.Value;
			})
			.Bind((PCOPlan l) => l.WhenPropertyChanges("Dates"), (IPlanningCenterPlan r) => r.DateList.WhenValueChanges.ToUnit(), delegate(PCOPlan l, IPlanningCenterPlan r)
			{
				r.DateList.Set(l.Dates ?? string.Empty);
			}, delegate(IPlanningCenterPlan r, PCOPlan l)
			{
				l.Dates = r.DateList.Value;
			})
			.Bind((PCOPlan l) => l.WhenPropertyChanges("Created"), (IPlanningCenterPlan r) => r.CreatedDate.WhenValueChanges.ToUnit(), delegate(PCOPlan l, IPlanningCenterPlan r)
			{
				r.CreatedDate.Set(new Pro.Entity.Timestamp(l.Created?.ToUnixTimestamp() ?? 0, 0));
			}, delegate(IPlanningCenterPlan r, PCOPlan l)
			{
				l.Created = r.CreatedDate.Value.Seconds.FromUnixTimestamp();
			})
			.Bind((PCOPlan l) => l.WhenPropertyChanges("LastUpdated"), (IPlanningCenterPlan r) => r.UpdateDate.WhenValueChanges.ToUnit(), delegate(PCOPlan l, IPlanningCenterPlan r)
			{
				r.UpdateDate.Set(new Pro.Entity.Timestamp(l.LastUpdated?.ToUnixTimestamp() ?? 0, 0));
			}, delegate(IPlanningCenterPlan r, PCOPlan l)
			{
				l.LastUpdated = r.UpdateDate.Value.Seconds.FromUnixTimestamp();
			});
		return objectBinder;
	}

	protected internal PCOPlan()
		: this(string.Empty, string.Empty, string.Empty, null, string.Empty, string.Empty, null)
	{
	}

	public PCOPlan(string serviceTypeID, string? id, string? name, DateTime? lastUpdated, string? dates, string? seriesTitle, DateTime? created)
		: base(id, GetName(seriesTitle, name, dates))
	{
		_serviceTypeId = serviceTypeID;
		LastUpdated = lastUpdated;
		_dates = dates;
		_seriesTitle = seriesTitle;
		_created = created;
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke(this);
	}

	public void LoadItems(PCOItem[] items)
	{
		_planItems = items;
		OnDataModified();
	}

	public void LoadAttachments(List<PCOAttachmentDetails> attachments)
	{
		_attachments = attachments;
	}

	public void UpdatePlanDetails(string dates, string seriesTitle, string name, DateTime? lastUpdated)
	{
		Dates = dates;
		SeriesTitle = seriesTitle;
		base.Name = GetName(seriesTitle, name, dates);
		LastUpdated = lastUpdated;
		OnDataModified();
	}

	private static string GetName(string? seriesTitle, string? planTitle, string? planDates)
	{
		return string.Join(" - ", new string[3] { seriesTitle, planTitle, planDates }.Where((string s) => !s.NullableIsNullOrEmpty()));
	}

	internal PlanningCenterPlan ProtoSerialize()
	{
		return new PlanningCenterPlan
		{
			PlanIdNum = base.ID.ToUintId(),
			PlanIdStr = base.ID,
			ParentIdNum = ServiceTypeID.ToUintId(),
			ParentIdStr = ServiceTypeID,
			SeriesTitle = (_seriesTitle ?? string.Empty),
			PlanTitle = (base.Name ?? string.Empty),
			DateList = (_dates ?? string.Empty),
			CreatedDate = _created?.ToTimeStamp(),
			UpdateDate = LastUpdated?.ToTimeStamp()
		};
	}

	public void ProtoDeserialize(PlanningCenterPlan pcoPlan)
	{
		base.ID = IdExtensions.FromProto(pcoPlan.PlanIdStr, pcoPlan.PlanIdNum);
		ServiceTypeID = IdExtensions.FromProto(pcoPlan.ParentIdStr, pcoPlan.ParentIdNum);
		Dates = pcoPlan.DateList;
		SeriesTitle = pcoPlan.SeriesTitle;
		base.Name = pcoPlan.PlanTitle;
		Created = pcoPlan.CreatedDate?.ToDateTime().ToLocalTime();
		LastUpdated = pcoPlan.UpdateDate?.ToDateTime().ToLocalTime();
	}
}
