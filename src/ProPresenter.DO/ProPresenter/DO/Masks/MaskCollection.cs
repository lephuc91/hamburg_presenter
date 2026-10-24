using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Strings;
using Pro.Common.Utility;
using Pro.DO.Application;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Collections;
using Pro.Entity.Extensions;
using Pro.Localization;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Cues;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Slide;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Themes;

namespace ProPresenter.DO.Masks;

public class MaskCollection : ImmutableObservableCollection<SlideCue>, IMaskCollection, IImmutableObservableCollection<SlideCue>, IReadOnlyList<SlideCue>, IEnumerable<SlideCue>, IEnumerable, IReadOnlyCollection<SlideCue>, INotifyEnumerableChanged<SlideCue>, INotifyCollectionChanged, ICutPasteCollection<SlideCue>, ICutCollection<SlideCue>, INotifyPropertyChanged
{
	private readonly IProPresenterDOFactoryProvider _factoryProvider;

	private readonly ITransitionDescriptionCollection _transitionDescriptions;

	public UndoStack UndoStack { get; } = new UndoStack();

	public event System.Action? CollectionModified;

	public IReadOnlyObjectBinder<IMaskCollection, IComplexCollection<IProMask>> CreateBinder(IUiScheduler scheduler, IComplexCollection<IProMask> right)
	{
		IEntityFactory entityFactory = _factoryProvider.EntityFactory;
		ObjectBinder<MaskCollection, IComplexCollection<IProMask>> objectBinder = new ObjectBinder<MaskCollection, IComplexCollection<IProMask>>(this, right);
		objectBinder.Bind((MaskCollection l) => l.WhenCollectionChanges(), (IComplexCollection<IProMask> r) => r.WhenCollectionChanges, delegate(MaskCollection l, IComplexCollection<IProMask> r)
		{
			r.SynchronizeFrom(l, (SlideCue m, IProMask e) => m.ID == e.BaseSlide.Value.Uuid.Value, delegate(SlideCue m)
			{
				IProMask proMask = entityFactory.Create<IProMask>();
				ObjectBinder<SlideCue, IProMask> objectBinder2 = CreateMaskBinder(scheduler, _factoryProvider, m, proMask);
				proMask.RegisterLinkedDisposable(objectBinder2);
				objectBinder2.InitializeRightFromLeft();
				return proMask;
			});
		}, delegate(IComplexCollection<IProMask> r, MaskCollection l)
		{
			r.Items.SynchronizeTo(l, (IProMask e, SlideCue m) => m.ID == e.BaseSlide.Value.Uuid.Value, delegate(IProMask e, int i)
			{
				SlideCue slideCue = GenerateMask(e.Name.Value);
				ObjectBinder<SlideCue, IProMask> objectBinder3 = CreateMaskBinder(scheduler, _factoryProvider, slideCue, e);
				e.RegisterLinkedDisposable(objectBinder3);
				objectBinder3.InitializeLeftFromRight();
				slideCue.DataModified += CueChanged;
				if (slideCue.SlideAction != null)
				{
					slideCue.SlideAction.Slide.UndoStack = UndoStack;
					slideCue.SlideAction.Slide.DataModified += SlideModified;
					base.Collection.Insert(i, slideCue);
				}
			}, l.Collection.Move, delegate(int i)
			{
				SlideCue slideCue2 = l.ElementAtOrDefault(i);
				if (slideCue2 != null)
				{
					OnRemove(new global::_003C_003Ez__ReadOnlySingleElementList<SlideCue>(slideCue2));
				}
			});
		}, null, scheduler.Scheduler);
		return objectBinder;
	}

	private static ObjectBinder<SlideCue, IProMask> CreateMaskBinder(IUiScheduler scheduler, IProPresenterDOFactoryProvider factoryProvider, SlideCue left, IProMask right)
	{
		ObjectBinder<SlideCue, IProMask> objectBinder = new ObjectBinder<SlideCue, IProMask>(left, right);
		objectBinder.Bind((SlideCue l) => l.WhenPropertyChanges("Name"), (IProMask r) => r.Name.WhenValueChanges, delegate(SlideCue l, IProMask r)
		{
			r.Name.Set(l.Name);
		}, delegate(IProMask r, SlideCue l)
		{
			l.Name = r.Name.Value;
		}).Bind((SlideCue l) => l.WhenPropertyChanges("Slide"), (IProMask r) => r.BaseSlide.WhenValueChanges, delegate(SlideCue l, IProMask r)
		{
			if (l.SlideAction?.Slide is CustomSlide left2)
			{
				ISlide slide = factoryProvider.EntityFactory.Create<ISlide>();
				r.BaseSlide.Set(slide);
				ObjectBinder<CustomSlide, ISlide> objectBinder2 = CustomSlide.CreateBinder(scheduler, left2, slide);
				objectBinder2.InitializeRightFromLeft();
				slide.RegisterLinkedDisposable(objectBinder2);
			}
		}, delegate(IProMask r, SlideCue l)
		{
			if (l.SlideAction?.Slide is CustomSlide left3)
			{
				ObjectBinder<CustomSlide, ISlide> objectBinder3 = CustomSlide.CreateBinder(scheduler, left3, r.BaseSlide.Value);
				objectBinder3.InitializeLeftFromRight();
				r.BaseSlide.Value.RegisterLinkedDisposable(objectBinder3);
			}
		});
		return objectBinder;
	}

	public MaskCollection(IProPresenterDOFactoryProvider factoryProvider, ITransitionDescriptionCollection transitionDescriptions)
	{
		_factoryProvider = factoryProvider;
		_transitionDescriptions = transitionDescriptions;
		base.CollectionChanged += OnCollectionChanged;
	}

	private void OnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.NewItems?.OfType<SlideCue>().ForEach(delegate(SlideCue mask)
		{
			mask.UpdateContainerId("Workspace");
		});
		OnCollectionModified();
	}

	public void Add()
	{
		Add(GenerateMask(GetDefaultName()));
	}

	public void Add(TemplateSlide template)
	{
		Insert(base.Collection.Count, template);
	}

	public void Add(SlideCue mask)
	{
		Insert(base.Collection.Count, mask);
	}

	public SlideCue Insert(int index, TemplateSlide template)
	{
		SlideCue slideCue = GenerateMask(GetDefaultName(), template);
		Insert(index, slideCue);
		return slideCue;
	}

	public void Insert(int index, SlideCue mask)
	{
		InsertRange(index, new SlideCue[1] { mask });
	}

	public void InsertRange(int index, IEnumerable<SlideCue> masks)
	{
		OnInsert(index, masks);
		UndoStack.Commit(UndoActionTypes.AddMask.ToAction(), delegate
		{
			OnRemove(masks);
		}, delegate
		{
			OnInsert(index, masks);
		}, null, null, autoFinalize: true);
	}

	private void OnInsert(int index, IEnumerable<SlideCue> masks)
	{
		foreach (SlideCue mask in masks)
		{
			mask.Name = mask.Name.DuplicateName(this, (SlideCue c) => c.Name);
			mask.DataModified += CueChanged;
			if (mask.SlideAction != null)
			{
				mask.SlideAction.Slide.UndoStack = UndoStack;
				mask.SlideAction.Slide.DataModified += SlideModified;
			}
		}
		base.Collection.InsertRange(index, masks);
	}

	public void Remove(SlideCue mask)
	{
		RemoveRange(new global::_003C_003Ez__ReadOnlySingleElementList<SlideCue>(mask));
	}

	public void RemoveRange(IEnumerable<SlideCue> masks)
	{
		UndoStack.BeginCommit(UndoActionTypes.RemoveMask.ToAction());
		Dictionary<int, SlideCue> originalValues = masks.ToDictionary(IndexOf, (SlideCue m) => m);
		OnRemove(masks);
		UndoStack.Commit(delegate
		{
			originalValues.ForEach(delegate(KeyValuePair<int, SlideCue> kv)
			{
				Insert(kv.Key, kv.Value);
			});
		}, delegate
		{
			OnRemove(masks);
		});
		EnsureCollectionIsNonEmpty();
		UndoStack.EndCommit(null, EnsureCollectionIsNonEmpty, autoFinalize: true);
	}

	public void Clear()
	{
		RemoveRange(base.Collection.ToArray());
	}

	private void OnRemove(IEnumerable<SlideCue> masks)
	{
		foreach (SlideCue mask in masks)
		{
			if (mask.SlideAction != null)
			{
				mask.SlideAction.Slide.UndoStack = null;
				mask.SlideAction.Slide.DataModified -= SlideModified;
			}
			mask.DataModified -= CueChanged;
		}
		base.Collection.RemoveRange(masks);
	}

	private void CueChanged(Pro.DO.Triggering.Cue cue)
	{
		OnCollectionModified();
	}

	private void SlideModified(SlideBase slide)
	{
		OnCollectionModified();
	}

	public IEnumerable<ProMask> Serialize()
	{
		return base.Collection.Select((SlideCue m) => new ProMask
		{
			Name = m.Name,
			BaseSlide = m.SlideAction?.Slide.Serialize().BaseSlide
		});
	}

	public void Deserialize(IEnumerable<ProMask> protoMasks, ApplicationData? applicationData, bool removeExisting = true)
	{
		UndoStack.StartIgnoring();
		base.Collection.DeserializeCollection(protoMasks.Where((ProMask m) => m.BaseSlide != null), (SlideCue c, ProMask m) => c.SlideAction?.Slide.ID == m.BaseSlide.Uuid.ToGuid(), (ProMask m) => GenerateMask(m.Name), Add, delegate(SlideCue m)
		{
			if (removeExisting)
			{
				Remove(m);
			}
		}, delegate(SlideCue c, ProMask m)
		{
			c.SlideAction?.Slide.DeserializeSlide(m.BaseSlide, applicationData, "Workspace", null);
		});
		EnsureCollectionIsNonEmpty();
		UndoStack.StopIgnoring();
	}

	private string GetDefaultName()
	{
		return LocalizedStrings.Get("AUDIENCE_LOOKS_DEFAULT_MASK_name").DuplicateName(this, (SlideCue c) => c.Name);
	}

	private SlideCue GenerateMask(string name, TemplateSlide? template = null)
	{
		CustomSlide customSlide = new CustomSlide(_factoryProvider, _transitionDescriptions)
		{
			BackgroundColor = Colors.Transparent
		};
		if (template != null)
		{
			customSlide.ApplyTemplate(template);
		}
		customSlide.UpdateContainerId("Workspace");
		return new SlideCue(_factoryProvider, customSlide, _transitionDescriptions)
		{
			Name = name
		};
	}

	private void EnsureCollectionIsNonEmpty()
	{
		if (!base.Collection.Any())
		{
			Add();
		}
	}

	private void OnCollectionModified()
	{
		this.CollectionModified?.Invoke();
	}

	public void CutFrom(IEnumerable<SlideCue> items)
	{
		RemoveRange(items);
	}

	public void PasteInto(IEnumerable<SlideCue> items, int index)
	{
		InsertRange(index, items);
	}

	public void MoveTo(IEnumerable<SlideCue> items, int index)
	{
		UndoStack.BeginCommit(UndoActionTypes.MoveMask.ToAction());
		base.Collection.MoveTo(items, index, UndoStack);
		UndoStack.EndCommit(null, null, autoFinalize: true);
	}

	public void ReplaceMasks(IEnumerable<SlideCue> masks)
	{
		if (masks.Any())
		{
			SlideCue[] masks2 = base.Collection.ToArray();
			OnRemove(masks2);
			masks.ForEach(Add);
		}
	}
}
