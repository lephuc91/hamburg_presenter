using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.Editor.Canvas.Snapping.Lines;
using Pro.Entity;
using Pro.Entity.Collections;
using Pro.Entity.Extensions;

namespace ProPresenter.DO.Slide.Custom;

public class StaticGuidelineCollection : StaticSLCollection
{
	private sealed record StaticSLBinderData(StaticSL Left, IAlignmentGuide Right, ObjectBinder<StaticSL, IAlignmentGuide> Binder);

	public event Action? DataModified;

	public static ObjectBinder<StaticGuidelineCollection, IComplexCollection<IAlignmentGuide>> CreateBinder(IUiScheduler uiScheduler, IEntityFactory entityFactory, StaticGuidelineCollection? left, IComplexCollection<IAlignmentGuide>? right)
	{
		ObjectBinder<StaticGuidelineCollection, IComplexCollection<IAlignmentGuide>> objectBinder = new ObjectBinder<StaticGuidelineCollection, IComplexCollection<IAlignmentGuide>>(left, right);
		objectBinder.Bind((StaticGuidelineCollection l) => l.Collection.WhenCollectionChanges(), (IComplexCollection<IAlignmentGuide> r) => r.WhenCollectionChanges, delegate(StaticGuidelineCollection l, IComplexCollection<IAlignmentGuide> r)
		{
			r.SynchronizeFrom(l.Collection, (StaticSL m, IAlignmentGuide e) => m.Id == e.Uuid.Value, delegate(StaticSL m)
			{
				IAlignmentGuide alignmentGuide = entityFactory.Create<IAlignmentGuide>();
				ObjectBinder<StaticSL, IAlignmentGuide> objectBinder2 = StaticSL.CreateBinder(m, alignmentGuide);
				alignmentGuide.RegisterLinkedDisposable(objectBinder2);
				objectBinder2.InitializeRightFromLeft();
				return alignmentGuide;
			});
		}, delegate(IComplexCollection<IAlignmentGuide> r, StaticGuidelineCollection l)
		{
			r.Items.SynchronizeTo(l, (IAlignmentGuide e, StaticSL m) => m.Id == e.Uuid.Value, delegate(IAlignmentGuide e, int i)
			{
				StaticSL staticSL = new StaticSL(e.Orientation.Value == IAlignmentGuide.Types.GuidelineOrientation.Horizontal);
				ObjectBinder<StaticSL, IAlignmentGuide> objectBinder3 = StaticSL.CreateBinder(staticSL, e);
				e.RegisterLinkedDisposable(objectBinder3);
				objectBinder3.InitializeLeftFromRight();
				l.Collection.Insert(i, staticSL);
			}, l.Collection.Move, delegate(int i)
			{
				StaticSL staticSL2 = l.ElementAtOrDefault(i);
				if (staticSL2 != null)
				{
					l.RemoveStaticSL(staticSL2);
				}
			});
		}, null, uiScheduler.Scheduler);
		return objectBinder;
	}

	public StaticGuidelineCollection()
	{
		base.CollectionChanged += delegate
		{
			OnDataModified();
		};
	}

	protected override void OnDragStart(IEnumerable<StaticSL> guidelines)
	{
		Dictionary<StaticSL, double> originalPositions = guidelines.ToDictionary((StaticSL g) => g, (StaticSL g) => g.Position);
		base.UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.MoveGuideline));
		base.UndoStack?.Commit(delegate
		{
			originalPositions.ForEach<KeyValuePair<StaticSL, double>>(delegate(KeyValuePair<StaticSL, double> g)
			{
				g.Key.Position = g.Value;
			});
		}, delegate
		{
		});
	}

	protected override void OnDragEnd(IEnumerable<StaticSL> guidelines)
	{
		UndoStack? undoStack = base.UndoStack;
		if (undoStack == null || !undoStack.IsRecording)
		{
			return;
		}
		Dictionary<StaticSL, double> newPositions = guidelines.ToDictionary((StaticSL g) => g, (StaticSL g) => g.Position);
		base.UndoStack?.Commit(delegate
		{
		}, delegate
		{
			newPositions.ForEach<KeyValuePair<StaticSL, double>>(delegate(KeyValuePair<StaticSL, double> g)
			{
				g.Key.Position = g.Value;
			});
		});
		base.UndoStack?.EndCommit(null, base.OnGuidelinesInvalidated, autoFinalize: true);
		OnDataModified();
	}

	protected override void OnAddStaticSLs(IEnumerable<StaticSL> guidelines)
	{
		StaticSL[] guides = guidelines.ToArray();
		base.UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.AddGuideline), delegate
		{
			OnRemoveStaticSLs(guides);
		}, delegate
		{
			OnAddStaticSLs(guides);
		}, null, null, autoFinalize: true);
		base.OnAddStaticSLs(guidelines);
	}

	protected override void OnRemoveStaticSLs(IReadOnlyList<StaticSL> guidelines)
	{
		StaticSL[] guides = guidelines.ToArray();
		base.UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.RemoveGuideline), delegate
		{
			OnAddStaticSLs(guides);
		}, delegate
		{
			OnRemoveStaticSLs(guides);
		}, null, null, autoFinalize: true);
		base.OnRemoveStaticSLs(guidelines);
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}
}
