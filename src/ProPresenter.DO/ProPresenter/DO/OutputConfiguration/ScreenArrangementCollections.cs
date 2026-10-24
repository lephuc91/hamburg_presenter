using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using Pro.Common.Dispatcher;
using Pro.Common.ErrorReporting;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.Entity.Merged.Collections;
using Pro.Entity.Merged.Entities;
using Pro.Entity.Merged.Factory;

namespace ProPresenter.DO.OutputConfiguration;

public sealed class ScreenArrangementCollections(ScreenArrangementCollectionBase audience, ScreenArrangementCollectionBase stage, IScreenArrangementFactory factory, IErrorReporter errorReporter)
{
	public ScreenArrangementCollectionBase Audience => audience;

	public ScreenArrangementCollectionBase Stage => stage;

	public IScreenArrangementFactory Factory => factory;

	public static IReadOnlyObjectBinder<ScreenArrangementCollections, IMergedCollection<IMergedScreen>> CreateBinder(IUiScheduler scheduler, IEntityFactory entityFactory, IMergedEntityFactory mergedEntityFactory, IErrorReporter errorReporter, ScreenArrangementCollectionBase audienceArrangementScreens, ScreenArrangementCollectionBase stageArrangementScreens, IScreenArrangementFactory screenArrangementFactory, IMergedCollection<IMergedScreen> mergedScreens)
	{
		ObjectBinder<ScreenArrangementCollections, IMergedCollection<IMergedScreen>> objectBinder = new ObjectBinder<ScreenArrangementCollections, IMergedCollection<IMergedScreen>>(new ScreenArrangementCollections(audienceArrangementScreens, stageArrangementScreens, screenArrangementFactory, errorReporter), mergedScreens);
		objectBinder.Bind((ScreenArrangementCollections l) => l.Audience.WhenCollectionChanges().Merge(l.Stage.WhenCollectionChanges()), (IMergedCollection<IMergedScreen> r) => r.WhenCollectionChanges.ToUnit().Merge((from items in r.WhenCollectionChanges.StartWith(r.Items)
			select items.Select((IMergedScreen item) => item.ScreenType.WhenValueChanges.ToUnit().Merge(item.Arrangement.WhenValueChanges.ToUnit())).Merge()).Switch()), delegate(ScreenArrangementCollections l, IMergedCollection<IMergedScreen> r)
		{
			r.SynchronizeFrom(l.Audience.Concat(l.Stage), (ScreenArrangementBase m, IMergedScreen e) => Equal(e, m), delegate(ScreenArrangementBase m)
			{
				IMergedScreen mergedScreen = mergedEntityFactory.CreateMergedScreen(m.ID, m.ScreenTargetType.ToEntityScreenType());
				ObjectBinder<ScreenArrangementBase, IMergedScreen> objectBinder2 = m.Bind(entityFactory, mergedScreen, errorReporter);
				objectBinder2.InitializeRightFromLeft();
				mergedScreen.RegisterLinkedDisposable(objectBinder2);
				return mergedScreen;
			});
		}, delegate(IMergedCollection<IMergedScreen> r, ScreenArrangementCollections l)
		{
			l.SynchronizeFrom(r.Items, delegate(IMergedScreen e)
			{
				ScreenArrangementBase screenArrangementBase = l.Factory.FromEntity(e);
				ObjectBinder<ScreenArrangementBase, IMergedScreen> objectBinder3 = screenArrangementBase.Bind(entityFactory, e, errorReporter);
				objectBinder3.InitializeLeftFromRight();
				e.RegisterLinkedDisposable(objectBinder3);
				return screenArrangementBase;
			}, (IMergedScreen e) => e.ScreenType.Value.ToScreenTargetType(), Equal);
		}, null, scheduler.Scheduler);
		return objectBinder;
	}

	private static bool Equal(IMergedScreen entity, ScreenArrangementBase model)
	{
		if (model.ID == entity.Uuid.Value && model.ScreenTargetType == entity.ScreenType.Value.ToScreenTargetType())
		{
			return model.ArrangementType == GetArrangementType(entity.Arrangement.Value);
		}
		return false;
	}

	private static ScreenArrangementType GetArrangementType(IProPresenterScreen.Types.IArrangement? arrangement)
	{
		if (!(arrangement is IProPresenterScreen.Types.IArrangement.IArrangementCombined))
		{
			if (arrangement is IProPresenterScreen.Types.IArrangement.IArrangementEdgeBlend)
			{
				return ScreenArrangementType.EdgeBlend;
			}
			return ScreenArrangementType.Single;
		}
		return ScreenArrangementType.Group;
	}

	private void SynchronizeFrom<T>(IReadOnlyList<T> source, Func<T, ScreenArrangementBase> createAndBind, Func<T, ScreenTargetType> targetType, Func<T, ScreenArrangementBase, bool> equal)
	{
		int num = 0;
		int num2 = 0;
		foreach (T item in source)
		{
			switch (targetType(item))
			{
			case ScreenTargetType.Audience:
				if (!FindAndMove(item, audience, num, equal) && !audience.TryInsertScreenArrangementWithoutSideEffects(num, createAndBind(item)))
				{
					errorReporter.Error("Failed to insert synchronized audience screen arrangement.");
				}
				num++;
				break;
			case ScreenTargetType.Stage:
				if (!FindAndMove(item, stage, num2, equal) && !stage.TryInsertScreenArrangementWithoutSideEffects(num2, createAndBind(item)))
				{
					errorReporter.Error("Failed to insert synchronized stage screen arrangement.");
				}
				num2++;
				break;
			}
		}
		if (num < audience.Count)
		{
			int count = audience.Count - num;
			audience.RemoveRange(num, count);
		}
		if (num2 < stage.Count)
		{
			int count2 = stage.Count - num2;
			stage.RemoveRange(num2, count2);
		}
	}

	private static bool FindAndMove<TSource>(TSource source, ScreenArrangementCollectionBase collection, int startIndex, Func<TSource, ScreenArrangementBase, bool> equal)
	{
		for (int i = startIndex; i < collection.Count; i++)
		{
			if (equal(source, collection[i]))
			{
				if (startIndex == i)
				{
					return true;
				}
				collection.Move(i, startIndex);
				return true;
			}
		}
		return false;
	}
}
