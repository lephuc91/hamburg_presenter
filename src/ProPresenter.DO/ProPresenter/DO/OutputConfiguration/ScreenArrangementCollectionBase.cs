using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Strings;
using Pro.DO.Utility;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.OutputConfiguration;

public abstract class ScreenArrangementCollectionBase : ImmutableObservableCollection<ScreenArrangementBase>, IDragDropCollection<ScreenArrangementBase>
{
	private readonly IScreenArrangementFactory _factory;

	private readonly Func<bool> _canAddMoreScreens;

	public abstract ScreenTargetType TargetType { get; }

	public abstract string DefaultScreenArrangementName { get; }

	public UndoStack UndoStack { get; }

	public event Action<ScreenArrangementCollectionBase>? CollectionModified;

	protected ScreenArrangementCollectionBase(IScreenArrangementFactory factory, UndoStack undoStack, Func<bool> canAddMoreScreens)
	{
		_factory = factory;
		UndoStack = undoStack;
		_canAddMoreScreens = canAddMoreScreens;
		base.CollectionChanged += delegate
		{
			OnCollectionModified();
		};
	}

	public ScreenArrangementBase? AddScreenArrangement(IDevice? device)
	{
		SingleScreenArrangement singleScreenArrangement = new SingleScreenArrangement(TargetType, null, 1, null);
		singleScreenArrangement.Name = DefaultScreenArrangementName;
		singleScreenArrangement.Screens[0].MainOutput.OutputDevice = device;
		if (!TryAddScreen(singleScreenArrangement))
		{
			return null;
		}
		return singleScreenArrangement;
	}

	public void AddScreenArrangement(ScreenArrangementBase screenArrangement)
	{
		TryAddScreen(screenArrangement);
	}

	public void InsertScreenArrangement(int index, ScreenArrangementBase m)
	{
		TryInsertScreen(index, m);
	}

	public void RemoveScreen(ScreenArrangementBase screenArrangement)
	{
		OnRemoveScreen(screenArrangement);
	}

	internal void Clear()
	{
		this.ToArray().ForEach(OnRemoveScreen);
	}

	private bool TryAddScreen(ScreenArrangementBase screenArrangement)
	{
		return TryInsertScreen(base.Count, screenArrangement);
	}

	private bool TryInsertScreen(int index, ScreenArrangementBase screenArrangement)
	{
		if (!_canAddMoreScreens())
		{
			return false;
		}
		screenArrangement.ArrangementChanged += OnArrangementModified;
		screenArrangement.Name = screenArrangement.Name.DuplicateName(base.Collection, (ScreenArrangementBase s) => s.Name);
		base.Collection.Insert(index, screenArrangement);
		UndoStack?.Commit(UndoActionTypes.AddScreenArrangement.ToAction(), delegate
		{
			OnRemoveScreen(screenArrangement);
		}, delegate
		{
			TryInsertScreen(index, screenArrangement);
		}, null, null, autoFinalize: true);
		return true;
	}

	internal bool TryInsertScreenArrangementWithoutSideEffects(int index, ScreenArrangementBase screenArrangement)
	{
		if (!_canAddMoreScreens())
		{
			return false;
		}
		screenArrangement.ArrangementChanged += OnArrangementModified;
		base.Collection.Insert(index, screenArrangement);
		return true;
	}

	private void OnRemoveScreen(ScreenArrangementBase screenArrangement)
	{
		screenArrangement.ArrangementChanged -= OnArrangementModified;
		int index = base.Collection.IndexOf(screenArrangement);
		base.Collection.RemoveAt(index);
		UndoStack?.Commit(UndoActionTypes.RemoveScreenArrangement.ToAction(), delegate
		{
			TryInsertScreen(index, screenArrangement);
		}, delegate
		{
			OnRemoveScreen(screenArrangement);
		}, null, null, autoFinalize: true);
	}

	internal void RemoveRange(int fromIndex, int count)
	{
		for (int num = fromIndex + count - 1; num >= fromIndex; num--)
		{
			base.Collection[num].ArrangementChanged -= OnArrangementModified;
			base.Collection.RemoveAt(num);
		}
	}

	public void DraggedFrom(IEnumerable<ScreenArrangementBase> items)
	{
	}

	public void DroppedInto(IEnumerable<ScreenArrangementBase> items, int index, bool isCopy)
	{
	}

	public void MoveTo(IEnumerable<ScreenArrangementBase> items, int index)
	{
		base.Collection.MoveTo(items, index);
	}

	public ScreenArrangementBase ChangeScreenArrangementType(ScreenArrangementBase selectedScreenArrangement, ScreenArrangementType type)
	{
		if (selectedScreenArrangement.ArrangementType == type)
		{
			return selectedScreenArrangement;
		}
		int index = base.Collection.IndexOf(selectedScreenArrangement);
		ScreenArrangementBase screenArrangementBase = _factory.FromArrangementType(type, selectedScreenArrangement.ScreenTargetType, selectedScreenArrangement.Screens.ToArray(), selectedScreenArrangement.ID);
		screenArrangementBase.Name = selectedScreenArrangement.Name;
		OnRemoveScreen(base.Collection[index]);
		TryInsertScreen(index, screenArrangementBase);
		return screenArrangementBase;
	}

	protected internal IEnumerable<ProPresenterScreen> SerializeScreens()
	{
		return this.Select((ScreenArrangementBase s) => s.Serialize());
	}

	protected internal void DeserializeScreens(IEnumerable<ProPresenterScreen> screens, bool removeExisting = true)
	{
		base.Collection.DeserializeCollection(screens, (ScreenArrangementBase s, ProPresenterScreen p) => s.ID == p.Uuid.ToGuid(), _factory.FromProtoScreen, delegate(ScreenArrangementBase arrangment)
		{
			TryAddScreen(arrangment);
		}, delegate(ScreenArrangementBase s)
		{
			if (removeExisting)
			{
				OnRemoveScreen(s);
			}
		}, delegate(ScreenArrangementBase s, ProPresenterScreen p)
		{
			s.ArrangementChanged -= OnArrangementModified;
			s.Deserialize(p);
			s.ArrangementChanged += OnArrangementModified;
		});
	}

	private void OnArrangementModified(ScreenArrangementBase arrangement)
	{
		OnCollectionModified();
	}

	protected virtual void OnCollectionModified()
	{
		this.CollectionModified?.Invoke(this);
	}

	protected ScreenArrangementBase GetDefaultScreen(bool isAudience)
	{
		ScreenArrangementBase screenArrangementBase = base.Collection.FirstOrDefault();
		if (screenArrangementBase == null)
		{
			PhysicalDevice physicalDevice = PhysicalDevice.AttachedPhysicalDevices.Where((PhysicalDevice d) => !d.IsPrimaryMonitor && d.DeviceType != DeviceType.BlackmagicCard).ElementAtOrDefault((!isAudience) ? 1 : 0);
			screenArrangementBase = new SingleScreenArrangement((!isAudience) ? ScreenTargetType.Stage : ScreenTargetType.Audience, null, 1, null)
			{
				Name = DefaultScreenArrangementName
			};
			if (physicalDevice == null && isAudience)
			{
				physicalDevice = PhysicalDevice.AttachedPhysicalDevices.FirstOrDefault((PhysicalDevice d) => d.IsPrimaryMonitor);
			}
			screenArrangementBase.Screens[0].MainOutput.OutputDevice = physicalDevice;
		}
		return screenArrangementBase;
	}

	public virtual ScreenArrangementBase GetDefaultScreen()
	{
		return GetDefaultScreen(isAudience: true);
	}

	internal void Move(int from, int to)
	{
		base.Collection.Move(from, to);
	}
}
