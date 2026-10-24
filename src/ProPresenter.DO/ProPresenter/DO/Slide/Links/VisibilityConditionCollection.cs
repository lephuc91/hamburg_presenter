using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;

namespace ProPresenter.DO.Slide.Links;

public class VisibilityConditionCollection : ImmutableObservableCollection<VisibilityCondition>
{
	private UndoStack? _undoStack;

	public UndoStack? UndoStack
	{
		get
		{
			return _undoStack;
		}
		set
		{
			_undoStack = value;
			base.Collection.ForEach(delegate(VisibilityCondition c)
			{
				c.UndoStack = value;
			});
		}
	}

	public event Action? CollectionModified;

	public static ObjectBinder<VisibilityConditionCollection, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink> CreateBinder(IUiScheduler scheduler, IEntityFactory entityFactory, VisibilityConditionCollection left, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink right)
	{
		ObjectBinder<VisibilityConditionCollection, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink> objectBinder = new ObjectBinder<VisibilityConditionCollection, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink>(left, right);
		objectBinder.Bind((VisibilityConditionCollection l) => l.Collection.WhenCollectionChanges(), (ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink r) => r.Conditions.WhenCollectionChanges, delegate(VisibilityConditionCollection l, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink r)
		{
			List<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition> list = new List<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition>();
			foreach (VisibilityCondition item in l.Collection)
			{
				ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition condition = entityFactory.Create<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition>();
				ObjectBinder<VisibilityCondition, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition> objectBinder2 = CreateBinder(scheduler, entityFactory, item, condition);
				objectBinder2.InitializeRightFromLeft();
				condition.RegisterLinkedDisposable(objectBinder2);
				list.Add(condition);
			}
			r.Conditions.Reset(list);
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink r, VisibilityConditionCollection l)
		{
			l.Clear();
			foreach (ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition item2 in r.Conditions.Items)
			{
				VisibilityCondition visibilityCondition = new VisibilityCondition();
				ObjectBinder<VisibilityCondition, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition> objectBinder3 = CreateBinder(scheduler, entityFactory, visibilityCondition, item2);
				objectBinder3.InitializeLeftFromRight();
				item2.RegisterLinkedDisposable(objectBinder3);
				l.AddCondition(visibilityCondition);
			}
		});
		return objectBinder;
	}

	private static ObjectBinder<VisibilityCondition, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition> CreateBinder(IUiScheduler scheduler, IEntityFactory entityFactory, VisibilityCondition left, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition right)
	{
		ObjectBinder<VisibilityCondition, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition> objectBinder = new ObjectBinder<VisibilityCondition, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition>(left, right);
		objectBinder.Bind((VisibilityCondition l) => l.WhenPropertyChanges("LinkedObject"), (ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition r) => r.ConditionType.WhenValueChanges, delegate(VisibilityCondition l, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition r)
		{
			ILinkedVisibilityObject linkedObject = l.LinkedObject;
			if (!(linkedObject is ElementLinkedVisibilityObject left2))
			{
				if (!(linkedObject is TimerLinkedVisibilityObject left3))
				{
					if (!(linkedObject is VideoCountdownLinkedVisibilityObject left4))
					{
						if (!(linkedObject is AudioCountdownLinkedVisibilityObject left5))
						{
							if (!(linkedObject is CaptureSessionLinkedVisibilityObject left6))
							{
								if (linkedObject is VideoInputLinkedVisibilityObject left7)
								{
									ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IConditionType.IVideoInputVisibility videoInputVisibility = entityFactory.Create<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IConditionType.IVideoInputVisibility>();
									ObjectBinder<VideoInputLinkedVisibilityObject, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoInputVisibility> objectBinder2 = VideoInputLinkedVisibilityObject.CreateBinder(left7, videoInputVisibility.Value);
									objectBinder2.InitializeRightFromLeft();
									r.ConditionType.Set(videoInputVisibility);
									videoInputVisibility.Value.RegisterLinkedDisposable(objectBinder2);
								}
							}
							else
							{
								ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IConditionType.ICaptureSessionVisibility captureSessionVisibility = entityFactory.Create<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IConditionType.ICaptureSessionVisibility>();
								ObjectBinder<CaptureSessionLinkedVisibilityObject, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ICaptureSessionVisibility> objectBinder3 = CaptureSessionLinkedVisibilityObject.CreateBinder(left6, captureSessionVisibility.Value);
								objectBinder3.InitializeRightFromLeft();
								r.ConditionType.Set(captureSessionVisibility);
								captureSessionVisibility.Value.RegisterLinkedDisposable(objectBinder3);
							}
						}
						else
						{
							ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IConditionType.IAudioCountdownVisibility audioCountdownVisibility = entityFactory.Create<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IConditionType.IAudioCountdownVisibility>();
							r.ConditionType.Set(audioCountdownVisibility);
							ObjectBinder<AudioCountdownLinkedVisibilityObject, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IAudioCountdownVisibility> objectBinder4 = AudioCountdownLinkedVisibilityObject.CreateBinder(left5, audioCountdownVisibility.Value);
							objectBinder4.InitializeRightFromLeft();
							audioCountdownVisibility.Value.RegisterLinkedDisposable(objectBinder4);
						}
					}
					else
					{
						ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IConditionType.IVideoCountdownVisibility videoCountdownVisibility = entityFactory.Create<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IConditionType.IVideoCountdownVisibility>();
						ObjectBinder<VideoCountdownLinkedVisibilityObject, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoCountdownVisibility> objectBinder5 = VideoCountdownLinkedVisibilityObject.CreateBinder(left4, videoCountdownVisibility.Value);
						objectBinder5.InitializeRightFromLeft();
						r.ConditionType.Set(videoCountdownVisibility);
						videoCountdownVisibility.Value.RegisterLinkedDisposable(objectBinder5);
					}
				}
				else
				{
					ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IConditionType.ITimerVisibility timerVisibility = entityFactory.Create<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IConditionType.ITimerVisibility>();
					ObjectBinder<TimerLinkedVisibilityObject, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ITimerVisibility> objectBinder6 = TimerLinkedVisibilityObject.CreateBinder(left3, timerVisibility.Value);
					objectBinder6.InitializeRightFromLeft();
					r.ConditionType.Set(timerVisibility);
					timerVisibility.Value.RegisterLinkedDisposable(objectBinder6);
				}
			}
			else
			{
				ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IConditionType.IElementVisibility elementVisibility = entityFactory.Create<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IConditionType.IElementVisibility>();
				ObjectBinder<ElementLinkedVisibilityObject, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IElementVisibility> objectBinder7 = ElementLinkedVisibilityObject.CreateBinder(scheduler, left2, elementVisibility.Value);
				objectBinder7.InitializeRightFromLeft();
				r.ConditionType.Set(elementVisibility);
				elementVisibility.Value.RegisterLinkedDisposable(objectBinder7);
			}
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition r, VisibilityCondition l)
		{
			ILinkedVisibilityObject linkedVisibilityObject = null;
			ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IConditionType value = r.ConditionType.Value;
			if (!(value is ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IConditionType.IElementVisibility elementVisibility2))
			{
				if (!(value is ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IConditionType.ITimerVisibility timerVisibility2))
				{
					if (!(value is ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IConditionType.IVideoCountdownVisibility videoCountdownVisibility2))
					{
						if (!(value is ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IConditionType.IAudioCountdownVisibility audioCountdownVisibility2))
						{
							if (!(value is ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IConditionType.ICaptureSessionVisibility captureSessionVisibility2))
							{
								if (value is ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IConditionType.IVideoInputVisibility videoInputVisibility2)
								{
									linkedVisibilityObject = new VideoInputLinkedVisibilityObject();
									ObjectBinder<VideoInputLinkedVisibilityObject, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoInputVisibility> objectBinder8 = VideoInputLinkedVisibilityObject.CreateBinder((VideoInputLinkedVisibilityObject)linkedVisibilityObject, videoInputVisibility2.Value);
									objectBinder8.InitializeLeftFromRight();
									videoInputVisibility2.Value.RegisterLinkedDisposable(objectBinder8);
								}
								else
								{
									linkedVisibilityObject = null;
								}
							}
							else
							{
								linkedVisibilityObject = new CaptureSessionLinkedVisibilityObject();
								ObjectBinder<CaptureSessionLinkedVisibilityObject, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ICaptureSessionVisibility> objectBinder9 = CaptureSessionLinkedVisibilityObject.CreateBinder((CaptureSessionLinkedVisibilityObject)linkedVisibilityObject, captureSessionVisibility2.Value);
								objectBinder9.InitializeLeftFromRight();
								captureSessionVisibility2.Value.RegisterLinkedDisposable(objectBinder9);
							}
						}
						else
						{
							linkedVisibilityObject = new AudioCountdownLinkedVisibilityObject();
							ObjectBinder<AudioCountdownLinkedVisibilityObject, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IAudioCountdownVisibility> objectBinder10 = AudioCountdownLinkedVisibilityObject.CreateBinder((AudioCountdownLinkedVisibilityObject)linkedVisibilityObject, audioCountdownVisibility2.Value);
							objectBinder10.InitializeLeftFromRight();
							audioCountdownVisibility2.Value.RegisterLinkedDisposable(objectBinder10);
						}
					}
					else
					{
						linkedVisibilityObject = new VideoCountdownLinkedVisibilityObject();
						ObjectBinder<VideoCountdownLinkedVisibilityObject, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoCountdownVisibility> objectBinder11 = VideoCountdownLinkedVisibilityObject.CreateBinder((VideoCountdownLinkedVisibilityObject)linkedVisibilityObject, videoCountdownVisibility2.Value);
						objectBinder11.InitializeLeftFromRight();
						videoCountdownVisibility2.Value.RegisterLinkedDisposable(objectBinder11);
					}
				}
				else
				{
					linkedVisibilityObject = new TimerLinkedVisibilityObject(() => DataVault.TimerDocument.Timers);
					ObjectBinder<TimerLinkedVisibilityObject, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ITimerVisibility> objectBinder12 = TimerLinkedVisibilityObject.CreateBinder((TimerLinkedVisibilityObject)linkedVisibilityObject, timerVisibility2.Value);
					objectBinder12.InitializeLeftFromRight();
					timerVisibility2.Value.RegisterLinkedDisposable(objectBinder12);
				}
			}
			else
			{
				linkedVisibilityObject = new ElementLinkedVisibilityObject();
				ObjectBinder<ElementLinkedVisibilityObject, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IElementVisibility> objectBinder13 = ElementLinkedVisibilityObject.CreateBinder(scheduler, (ElementLinkedVisibilityObject)linkedVisibilityObject, elementVisibility2.Value);
				objectBinder13.InitializeLeftFromRight();
				elementVisibility2.Value.RegisterLinkedDisposable(objectBinder13);
			}
			l.LinkedObject = linkedVisibilityObject;
		}, scheduler.Scheduler);
		return objectBinder;
	}

	public VisibilityConditionCollection()
	{
		base.CollectionChanged += delegate
		{
			OnCollectionModified();
		};
	}

	public void AddConditions(IEnumerable<VisibilityCondition> conditions)
	{
		conditions.ForEach(AddCondition);
	}

	public void AddCondition()
	{
		AddCondition(new VisibilityCondition());
	}

	public void AddCondition(VisibilityCondition condition)
	{
		Insert(condition, null);
	}

	private void Insert(VisibilityCondition condition, int? index = null)
	{
		condition.DataModified += OnCollectionModified;
		condition.UndoStack = UndoStack;
		UndoStack?.Commit(UndoActionTypes.VisibilityLinkAddCondition.ToAction(), delegate
		{
			RemoveCondition(condition);
		}, delegate
		{
			AddCondition(condition);
		}, null, null, autoFinalize: true);
		base.Collection.Insert(index ?? base.Collection.Count, condition);
	}

	public void RemoveCondition(VisibilityCondition condition)
	{
		condition.DataModified -= OnCollectionModified;
		UndoStack?.Commit(UndoActionTypes.VisibilityLinkRemoveCondition.ToAction(), delegate
		{
			AddCondition(condition);
		}, delegate
		{
			RemoveCondition(condition);
		}, null, null, autoFinalize: true);
		base.Collection.Remove(condition);
	}

	private VisibilityCondition? RemoveAt(int index)
	{
		VisibilityCondition visibilityCondition = base.Collection.ElementAtOrDefault(index);
		if (visibilityCondition != null)
		{
			RemoveCondition(visibilityCondition);
		}
		return visibilityCondition;
	}

	public void Clear()
	{
		base.Collection.ToArray().ForEach(RemoveCondition);
	}

	private void OnCollectionModified()
	{
		this.CollectionModified?.Invoke();
	}
}
