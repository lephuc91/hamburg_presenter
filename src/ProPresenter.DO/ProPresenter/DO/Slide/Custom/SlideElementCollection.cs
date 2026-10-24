using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Dispatcher;
using Pro.Common.ErrorReporting;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Transitions;
using Pro.Entity;
using Pro.Entity.Collections;
using Pro.Entity.Extensions;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Custom.Elements.Shapes;

namespace ProPresenter.DO.Slide.Custom;

public class SlideElementCollection : ImmutableObservableCollection<SlideElementBase>, IDragDropEnumerableCollection<SlideElementBase>, IDragDropCollection<SlideElementBase>, IEnumerable<SlideElementBase>, IEnumerable
{
	public static ObjectBinder<SlideElementCollection, IComplexCollection<ISlide.Types.IElement>> CreateBinder(IUiScheduler scheduler, IProPresenterDOFactoryProvider factoryProvider, ITransitionDescriptionCollection transitionDescriptions, IErrorReporter errorReporter, CustomSlide parent, IComplexCollection<ISlide.Types.IElement> right)
	{
		IEntityFactory entityFactory = factoryProvider.EntityFactory;
		ObjectBinder<SlideElementCollection, IComplexCollection<ISlide.Types.IElement>> objectBinder = new ObjectBinder<SlideElementCollection, IComplexCollection<ISlide.Types.IElement>>(parent.Elements, right);
		objectBinder.Bind((SlideElementCollection l) => l.WhenCollectionChanges(), (IComplexCollection<ISlide.Types.IElement> r) => r.WhenCollectionChanges, delegate(SlideElementCollection l, IComplexCollection<ISlide.Types.IElement> r)
		{
			r.SynchronizeFrom(l.Collection, (SlideElementBase m, ISlide.Types.IElement e) => e?._Element.Value.Uuid.Value == m.ID, delegate(SlideElementBase m)
			{
				ISlide.Types.IElement element = entityFactory.Create<ISlide.Types.IElement>();
				ObjectBinder<BezierPath, ISlide.Types.IElement> objectBinder2 = CreateBinder(scheduler, factoryProvider, transitionDescriptions, errorReporter, m, element);
				if (objectBinder2 != null)
				{
					objectBinder2.InitializeRightFromLeft();
					element.RegisterLinkedDisposable(objectBinder2);
				}
				return element;
			});
		}, delegate(IComplexCollection<ISlide.Types.IElement> r, SlideElementCollection l)
		{
			r.Items.SynchronizeTo(l.Collection, delegate(ISlide.Types.IElement e, SlideElementBase m)
			{
				Guid value = e._Element.Value.Uuid.Value;
				Guid? obj = m?.ID;
				return value == obj;
			}, delegate(ISlide.Types.IElement e, int i)
			{
				BezierPath bezierPath = e._Element.Value.Path.Value.CreateShape(factoryProvider, parent.ContainerId);
				ObjectBinder<BezierPath, ISlide.Types.IElement> objectBinder3 = CreateBinder(scheduler, factoryProvider, transitionDescriptions, errorReporter, bezierPath, e);
				if (objectBinder3 != null)
				{
					objectBinder3.InitializeLeftFromRight();
					e.RegisterLinkedDisposable(objectBinder3);
				}
				l.Collection.Insert(i, bezierPath);
			}, l.Collection.Move, delegate(int i)
			{
				SlideElementBase slideElementBase = l.ElementAtOrDefault(i);
				if (slideElementBase != null)
				{
					l.Remove(slideElementBase);
				}
			});
		}, null, scheduler.Scheduler);
		return objectBinder;
	}

	private static ObjectBinder<BezierPath, ISlide.Types.IElement>? CreateBinder(IUiScheduler scheduler, IProPresenterDOFactoryProvider factoryProvider, ITransitionDescriptionCollection transitionDescriptions, IErrorReporter errorReporter, SlideElementBase left, ISlide.Types.IElement right)
	{
		if (left is BezierPath bezierPath)
		{
			return bezierPath.CreateBinder(scheduler, factoryProvider, transitionDescriptions, right, errorReporter);
		}
		return null;
	}

	public void Add(SlideElementBase element, bool resetZIndex)
	{
		AddRange(new global::_003C_003Ez__ReadOnlySingleElementList<SlideElementBase>(element), resetZIndex);
	}

	internal void AddRange(IEnumerable<SlideElementBase> elements, bool resetZIndex)
	{
		if (resetZIndex)
		{
			int nextZOrder = GetNextZOrder();
			elements.ForEach(delegate(SlideElementBase e)
			{
				e.ZOrder = nextZOrder++;
			});
		}
		base.Collection.AddRange(elements);
	}

	public bool Remove(SlideElementBase element)
	{
		return base.Collection.Remove(element);
	}

	internal bool RemoveRange(IEnumerable<SlideElementBase> elements)
	{
		return elements.All(Remove);
	}

	private int GetNextZOrder()
	{
		if (!base.Collection.Any())
		{
			return 1;
		}
		return base.Collection.Max((SlideElementBase e) => e.ZOrder) + 1;
	}

	IEnumerator<SlideElementBase> IEnumerable<SlideElementBase>.GetEnumerator()
	{
		return GetEnumerator();
	}

	int IDragDropCollection<SlideElementBase>.IndexOf(SlideElementBase item)
	{
		return item.ZOrder;
	}

	public void DraggedFrom(IEnumerable<SlideElementBase> items)
	{
	}

	public void DroppedInto(IEnumerable<SlideElementBase> items, int index, bool isCopy)
	{
		items = (isCopy ? items.CloneItems() : items);
		foreach (SlideElementBase item in items)
		{
			Add(item, resetZIndex: false);
		}
		ElementOrdonnance.ChangeElementZOrder(base.Collection, items, index);
	}

	public void MoveTo(IEnumerable<SlideElementBase> items, int index)
	{
		ElementOrdonnance.ChangeElementZOrder(base.Collection, items, index);
	}
}
