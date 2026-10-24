using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using Pro.Common.Background;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Nullability;
using Pro.Localization;
using Pro.UI.Components;
using ProPresenter.DO.PCO;
using ProPresenter.UI.ViewModels.PCO;

namespace ProPresenter.ViewModels.PCO;

public class AttachmentManagerVM : LinkedNotifyPropertyChangedBase, IAttachmentManagerVM, INotifyPropertyChanged
{
	private sealed class AllAttachmentGroup : NotifyPropertyChangedBase, IAttachmentGroupVM, INotifyPropertyChanged
	{
		public string Name { get; } = LocalizedStrings.Get("GLOBAL_ALL");

		public PCOObject? ReferenceObject => null;

		public INotifyEnumerableChanged<IAttachmentVM>? AllAttachments => null;

		public INotifyEnumerableChanged<IAttachmentVM>? FilteredAttachments => null;

		public string FilterText { get; set; } = string.Empty;
	}

	private readonly IPCOConsumer _consumer;

	private PCOPlan? _activePlan;

	private IAttachmentGroupVM _selectedAttachmentGroup;

	private string _filterText = string.Empty;

	private readonly Dispatcher _dispatcher;

	private readonly AllAttachmentGroup _allAttachmentGroup = new AllAttachmentGroup();

	private readonly NotifyObservableCollection<IAttachmentGroupVM> _attachmentGroups = new NotifyObservableCollection<IAttachmentGroupVM>();

	private readonly FilteredObservableCollection<IAttachmentGroupVM> _filteredAttachmentGroups;

	public PCOPlan? ActivePlan
	{
		get
		{
			return _activePlan;
		}
		set
		{
			SetValue<PCOPlan>("ActivePlan", ref _activePlan, value, delegate(PCOPlan o, PCOPlan n)
			{
				if (o != null)
				{
					o.PropertyChanged -= OnActivePlanPropertyChanged;
				}
				if (n != null)
				{
					n.PropertyChanged += OnActivePlanPropertyChanged;
				}
				UpdateAttachmentGroups();
				if (n != null && AllAttachmentGroups.Count() <= 1)
				{
					OnRefreshAttachmentsCommand();
				}
			});
		}
	}

	public INotifyEnumerableChanged<IAttachmentGroupVM> AllAttachmentGroups => _attachmentGroups;

	public INotifyEnumerableChanged<IAttachmentGroupVM> FilteredAttachmentGroups => _filteredAttachmentGroups;

	public IAttachmentGroupVM? SelectedAttachmentGroup
	{
		get
		{
			return _selectedAttachmentGroup;
		}
		set
		{
			SetValue("SelectedAttachmentGroup", ref _selectedAttachmentGroup, value, _filteredAttachmentGroups.Refresh);
		}
	}

	public string FilterText
	{
		get
		{
			return _filterText;
		}
		set
		{
			SetValue("FilterText", ref _filterText, value, (Action)delegate
			{
				_attachmentGroups.ForEach(delegate(IAttachmentGroupVM g)
				{
					g.FilterText = FilterText;
				});
			}, (Predicate<string>?)null, referenceComparison: false);
		}
	}

	public ICommand RefreshAttachmentsCommand => new RelayCommand(OnRefreshAttachmentsCommand, () => ActivePlan != null);

	public bool IsPCOBusy => _consumer.IsPCOBusy;

	public AttachmentManagerVM(IPCOConsumer consumer)
	{
		_consumer = consumer;
		_dispatcher = Dispatcher.CurrentDispatcher;
		_attachmentGroups.Add(_allAttachmentGroup);
		_selectedAttachmentGroup = _allAttachmentGroup;
		_filteredAttachmentGroups = new FilteredObservableCollection<IAttachmentGroupVM>(_attachmentGroups, FilterAttachmentGroup);
		LinkProperties("IsPCOBusy", "IsPCOBusy");
		_consumer.PlanRefreshed += OnPlanRefreshed;
		_consumer.PropertyChanged += base.RaiseLinkedValues;
	}

	private void OnActivePlanPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (sender is PCOPlan)
		{
			string propertyName = e.PropertyName;
			if (propertyName == "Attachments" || propertyName == "PlanItems")
			{
				_dispatcher.Invoke((Action)UpdateAttachmentGroups);
			}
		}
	}

	private void UpdateAttachmentGroups()
	{
		_attachmentGroups.RemoveIf((object? g) => g != _allAttachmentGroup);
		SelectedAttachmentGroup = _allAttachmentGroup;
		if (ActivePlan == null || !ActivePlan.IsPlanItemsLoaded)
		{
			return;
		}
		if (ActivePlan.Attachments.Any())
		{
			_attachmentGroups.Add(new PlanAttachmentGroupVM(_consumer, ActivePlan));
		}
		if (ActivePlan.PlanItems != null)
		{
			_attachmentGroups.AddRange(from i in ActivePlan.PlanItems
				where i.Attachments.Any()
				select new ItemAttachmentGroupVM(_consumer, i));
		}
	}

	private bool FilterAttachmentGroup(IAttachmentGroupVM group)
	{
		if (group != _allAttachmentGroup)
		{
			if (SelectedAttachmentGroup != _allAttachmentGroup)
			{
				return group == SelectedAttachmentGroup;
			}
			return true;
		}
		return false;
	}

	private void OnRefreshAttachmentsCommand()
	{
		ActivePlan.ThrowWhenNull("ActivePlan");
		_consumer.RefreshPCOPlanAsync(ActivePlan).ContinueWith(delegate(Task<PlanRefreshResult> refreshPlanTask)
		{
			PlanRefreshResult result = refreshPlanTask.Result;
			if (result.Success && result.PlanDetail != null)
			{
				ActivePlan = result.PlanDetail;
				_consumer.IsPCOBusy = false;
				_dispatcher.InvokeAsync((Action)UpdateAttachmentGroups);
			}
		}).ExecuteAsync();
	}

	private void OnPlanRefreshed(PCOPlan plan)
	{
		if (plan == ActivePlan)
		{
			_dispatcher.Invoke((Action)UpdateAttachmentGroups);
		}
	}
}
