using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.Entity.Collections;
using Pro.Entity.Extensions;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Slide.Custom.Elements;

namespace ProPresenter.DO.Slide.Links;

public class VisibilityLink : LinkBase
{
	private VisibilityCriterion _criterion;

	public override LinkType LinkType => LinkType.Visibility;

	public override string? DisplayText
	{
		get
		{
			if (base.IsEnabled)
			{
				return LocalizedStrings.Get("EDITOR_SHAPE_VISIBILITY_LINK_label");
			}
			return null;
		}
	}

	public VisibilityConditionCollection Conditions { get; } = new VisibilityConditionCollection();

	public VisibilityCriterion Criterion
	{
		get
		{
			return _criterion;
		}
		set
		{
			SetValue("Criterion", ref _criterion, value, delegate(VisibilityCriterion o, VisibilityCriterion n)
			{
				base.UndoStack?.Commit(UndoActionTypes.VisibilityLinkCriterion.ToAction(), this, "Criterion", o, n, null, null, autoFinalize: true);
				OnLinkObjectUpdated();
			});
		}
	}

	public static void HandleModelChanges(IUiScheduler scheduler, BezierPath bezierPath, IEntityFactory entityFactory, ICollection<ISlide.Types.IElement.Types.IDataLink> entity)
	{
		for (int num = entity.Items.Count - 1; num >= 0; num--)
		{
			if (entity.Items[num].PropertyType.Value is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IVisibilityLink)
			{
				entity.RemoveAt(num);
			}
		}
		if (bezierPath.VisibilityLink.IsEnabled)
		{
			ISlide.Types.IElement.Types.IDataLink dataLink = entityFactory.Create<ISlide.Types.IElement.Types.IDataLink>();
			ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IVisibilityLink visibilityLink = entityFactory.Create<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IVisibilityLink>();
			dataLink.PropertyType.Set(visibilityLink);
			ObjectBinder<VisibilityLink, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink> objectBinder = CreateCriterionBinder(bezierPath.VisibilityLink, visibilityLink.Value);
			objectBinder.InitializeRightFromLeft();
			dataLink.RegisterLinkedDisposable(objectBinder);
			ObjectBinder<VisibilityConditionCollection, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink> objectBinder2 = VisibilityConditionCollection.CreateBinder(scheduler, entityFactory, bezierPath.VisibilityLink.Conditions, visibilityLink.Value);
			objectBinder2.InitializeRightFromLeft();
			dataLink.RegisterLinkedDisposable(objectBinder2);
			entity.Add(dataLink);
		}
	}

	public static void HandleEntityChanges(IUiScheduler scheduler, BezierPath bezierPath, IEntityFactory entityFactory, ICollection<ISlide.Types.IElement.Types.IDataLink> entity)
	{
		ISlide.Types.IElement.Types.IDataLink dataLink = entity.Items.FirstOrDefault((ISlide.Types.IElement.Types.IDataLink i) => i.PropertyType.Value is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IVisibilityLink);
		bezierPath.VisibilityLink.IsEnabled = dataLink != null;
		if (bezierPath.VisibilityLink.IsEnabled)
		{
			ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IVisibilityLink visibilityLink = (ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IVisibilityLink)dataLink.PropertyType.Value;
			ObjectBinder<VisibilityLink, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink> objectBinder = CreateCriterionBinder(bezierPath.VisibilityLink, visibilityLink.Value);
			objectBinder.InitializeLeftFromRight();
			dataLink.RegisterLinkedDisposable(objectBinder);
			ObjectBinder<VisibilityConditionCollection, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink> objectBinder2 = VisibilityConditionCollection.CreateBinder(scheduler, entityFactory, bezierPath.VisibilityLink.Conditions, visibilityLink.Value);
			objectBinder2.InitializeLeftFromRight();
			dataLink.RegisterLinkedDisposable(objectBinder2);
		}
		else
		{
			bezierPath.VisibilityLink.Conditions.Clear();
		}
	}

	private static ObjectBinder<VisibilityLink, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink> CreateCriterionBinder(VisibilityLink link, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink entity)
	{
		ObjectBinder<VisibilityLink, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink> objectBinder = new ObjectBinder<VisibilityLink, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink>(link, entity);
		objectBinder.Bind((VisibilityLink l) => l.WhenPropertyChanges("Criterion"), (ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink r) => r.VisibilityCriterion.WhenValueChanges, delegate(VisibilityLink l, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink r)
		{
			r.VisibilityCriterion.Set(l.Criterion.ToEntityVisibilityCriterion());
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink r, VisibilityLink l)
		{
			l.Criterion = r.VisibilityCriterion.Value.ToVisibilityCriterion();
		});
		return objectBinder;
	}

	public VisibilityLink(bool addDefaultCondition = true)
	{
		Conditions.CollectionModified += base.OnLinkObjectUpdated;
		if (addDefaultCondition)
		{
			Conditions.AddCondition();
		}
	}

	public override bool RenderEquals([NotNullWhen(true)] ILink? other)
	{
		if (other is VisibilityLink visibilityLink && _criterion == visibilityLink._criterion)
		{
			return Conditions.ContentsMatchExactly(visibilityLink.Conditions, (VisibilityCondition l, VisibilityCondition r) => l.RenderEquals(r));
		}
		return false;
	}

	public override int GetRenderHashCode()
	{
		return RenderHashCodeHelper.GenerateHashCode(new IEnumerable[1] { Conditions }, base.GetRenderHashCode(), _criterion);
	}

	protected override void OnUndoStackChanged(UndoStack? undoStack)
	{
		Conditions.UndoStack = undoStack;
	}

	public override ILink Clone()
	{
		VisibilityLink visibilityLink = new VisibilityLink(addDefaultCondition: false);
		visibilityLink.Criterion = Criterion;
		visibilityLink.Conditions.AddConditions(Conditions.CloneItems());
		CopyProperties(visibilityLink);
		return visibilityLink;
	}

	public override Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink Serialize()
	{
		Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink dataLink = new Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink();
		Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink visibilityLink = new Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink
		{
			VisibilityCriterion = Criterion.ToProtoVisibilityCriterion()
		};
		visibilityLink.Conditions.AddRange(Conditions.Select((VisibilityCondition c) => c.Serialize()));
		dataLink.VisibilityLink = visibilityLink;
		return dataLink;
	}
}
