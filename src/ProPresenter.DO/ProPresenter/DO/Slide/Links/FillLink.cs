using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Pro.Common.Components.Reversibility;
using Pro.Common.ObjectBinding;
using Pro.Entity;
using Pro.Entity.Collections;
using Pro.Entity.Extensions;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Slide.Custom.Elements;

namespace ProPresenter.DO.Slide.Links;

public class FillLink : LinkBase
{
	private ILinkedFillObject? _linkedObject;

	public override LinkType LinkType => LinkType.Fill;

	public override string? DisplayText
	{
		get
		{
			if (!base.IsEnabled || !(LinkedObject is ElementLinkedFillObject { Element: null }))
			{
				if (LinkedObject != null && base.IsEnabled)
				{
					return LocalizedStrings.Get("EDITOR_SHAPE_FILL_LINK_label", new object[1] { LinkedObject.DisplayText });
				}
				return null;
			}
			return LocalizedStrings.Get("EDITOR_SHAPE_FILL_LINK_UNCONFIGURED_label");
		}
	}

	public ILinkedFillObject? LinkedObject
	{
		get
		{
			return _linkedObject;
		}
		set
		{
			SetValue<ILinkedFillObject>("LinkedObject", ref _linkedObject, value, delegate(ILinkedFillObject o, ILinkedFillObject n)
			{
				base.UndoStack?.BeginCommit(UndoActionTypes.LinkFillObject.ToAction());
				base.UndoStack?.Commit(this, "LinkedObject", o, n);
				if (o != null)
				{
					o.PropertyChanged -= LinkedObjectPropertyChanged;
					o.Teardown();
				}
				if (n != null)
				{
					n.PropertyChanged += LinkedObjectPropertyChanged;
					n.UndoStack = base.UndoStack;
					base.IsEnabled = true;
				}
				OnLinkObjectUpdated();
				base.UndoStack?.EndCommit(null, null, autoFinalize: true);
			});
		}
	}

	public static void HandleModelChanges(IEntityFactory entityFactory, BezierPath bezierPath, Pro.Entity.Collections.ICollection<ISlide.Types.IElement.Types.IDataLink> entity)
	{
		if (!(bezierPath is ClosedBezierPath closedBezierPath))
		{
			return;
		}
		for (int num = entity.Items.Count - 1; num >= 0; num--)
		{
			if (IsFillLink(entity.Items[num].PropertyType.Value))
			{
				entity.RemoveAt(num);
			}
		}
		if (closedBezierPath.FillLink.IsEnabled)
		{
			ISlide.Types.IElement.Types.IDataLink dataLink = CreateAndRegisterLinkedObjectBinder(entityFactory, closedBezierPath.FillLink.LinkedObject);
			if (dataLink != null)
			{
				entity.Add(dataLink);
			}
		}
	}

	public static void HandleEntityChanges(BezierPath bezierPath, Pro.Entity.Collections.ICollection<ISlide.Types.IElement.Types.IDataLink> entity)
	{
		if (!(bezierPath is ClosedBezierPath closedBezierPath))
		{
			return;
		}
		IEnumerable<ISlide.Types.IElement.Types.IDataLink> enumerable = entity.Items.Where((ISlide.Types.IElement.Types.IDataLink d) => IsFillLink(d.PropertyType.Value));
		closedBezierPath.FillLink.IsEnabled = enumerable.Any();
		foreach (ISlide.Types.IElement.Types.IDataLink item in enumerable)
		{
			closedBezierPath.FillLink.LinkedObject = CreateLinkedObjectAndRegisterBinder(item);
		}
	}

	public static bool IsFillLink(ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType propertyType)
	{
		if (!(propertyType is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ICaptureStatusColor) && !(propertyType is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IChordChart) && !(propertyType is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IAlternateFill) && !(propertyType is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IGroupColor) && !(propertyType is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IOutputScreen) && !(propertyType is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IPcoLive) && !(propertyType is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IPlaybackMarkerColor) && !(propertyType is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ISlideImage) && !(propertyType is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ISlideLabelColor))
		{
			return propertyType is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ITimecodeStatus;
		}
		return true;
	}

	private static ILinkedFillObject? CreateLinkedObjectAndRegisterBinder(ISlide.Types.IElement.Types.IDataLink fillLink)
	{
		ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType value = fillLink.PropertyType.Value;
		if (!(value is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ICaptureStatusColor))
		{
			if (!(value is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IChordChart))
			{
				if (!(value is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IAlternateFill alternateFill))
				{
					if (!(value is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IGroupColor groupColor))
					{
						if (!(value is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IOutputScreen outputScreen))
						{
							if (!(value is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IPcoLive pcoLive))
							{
								if (!(value is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IPlaybackMarkerColor playbackMarkerColor))
								{
									if (!(value is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ISlideImage slideImage))
									{
										if (!(value is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ISlideLabelColor slideLabelColor))
										{
											if (value is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ITimecodeStatus)
											{
												return new TimecodeStatusColorLinkedObject();
											}
											return null;
										}
										SlideLabelColorLinkedObject slideLabelColorLinkedObject = new SlideLabelColorLinkedObject();
										ObjectBinder<SlideLabelColorLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.ISlideLabelColor> objectBinder = SlideLabelColorLinkedObject.CreateBinder(slideLabelColorLinkedObject, slideLabelColor.Value);
										fillLink.RegisterLinkedDisposable(objectBinder);
										objectBinder.InitializeLeftFromRight();
										return slideLabelColorLinkedObject;
									}
									SlideImageLinkedObject slideImageLinkedObject = new SlideImageLinkedObject();
									ObjectBinder<SlideImageLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.ISlideImage> objectBinder2 = SlideImageLinkedObject.CreateBinder(slideImageLinkedObject, slideImage.Value);
									fillLink.RegisterLinkedDisposable(objectBinder2);
									objectBinder2.InitializeLeftFromRight();
									return slideImageLinkedObject;
								}
								PlaybackMarkerColorLinkedObject playbackMarkerColorLinkedObject = new PlaybackMarkerColorLinkedObject();
								ObjectBinder<PlaybackMarkerColorLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerIdentifier> objectBinder3 = PlaybackMarkerColorLinkedObject.CreateBinder(playbackMarkerColorLinkedObject, playbackMarkerColor.Value);
								fillLink.RegisterLinkedDisposable(objectBinder3);
								objectBinder3.InitializeLeftFromRight();
								return playbackMarkerColorLinkedObject;
							}
							PCOLiveLinkedObject pCOLiveLinkedObject = new PCOLiveLinkedObject();
							ObjectBinder<PCOLiveLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IPcoLive> objectBinder4 = PCOLiveLinkedObject.CreateBinder(pCOLiveLinkedObject, pcoLive.Value);
							fillLink.RegisterLinkedDisposable(objectBinder4);
							objectBinder4.InitializeLeftFromRight();
							return pCOLiveLinkedObject;
						}
						OutputScreenLinkedObject outputScreenLinkedObject = new OutputScreenLinkedObject(null);
						ObjectBinder<OutputScreenLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IOutputScreen> objectBinder5 = OutputScreenLinkedObject.CreateBinder(outputScreenLinkedObject, outputScreen.Value);
						fillLink.RegisterLinkedDisposable(objectBinder5);
						objectBinder5.InitializeLeftFromRight();
						return outputScreenLinkedObject;
					}
					GroupColorLinkedObject groupColorLinkedObject = new GroupColorLinkedObject();
					ObjectBinder<GroupColorLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IGroupColor> objectBinder6 = GroupColorLinkedObject.CreateBinder(groupColorLinkedObject, groupColor.Value);
					fillLink.RegisterLinkedDisposable(objectBinder6);
					objectBinder6.InitializeLeftFromRight();
					return groupColorLinkedObject;
				}
				ElementLinkedFillObject elementLinkedFillObject = new ElementLinkedFillObject();
				ObjectBinder<ElementLinkedFillObject, ISlide.Types.IElement.Types.IDataLink.Types.IAlternateElementFill> objectBinder7 = ElementLinkedFillObject.CreateBinder(elementLinkedFillObject, alternateFill.Value);
				fillLink.RegisterLinkedDisposable(objectBinder7);
				objectBinder7.InitializeLeftFromRight();
				return elementLinkedFillObject;
			}
			return new ChordChartLinkedObject();
		}
		return new CaptureStatusColorLinkedObject();
	}

	private static ISlide.Types.IElement.Types.IDataLink? CreateAndRegisterLinkedObjectBinder(IEntityFactory entityFactory, ILinkedFillObject? linkedFillObject)
	{
		ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType propertyType = null;
		IDisposable disposable = null;
		if (!(linkedFillObject is CaptureStatusColorLinkedObject))
		{
			if (!(linkedFillObject is ChordChartLinkedObject))
			{
				if (!(linkedFillObject is ElementLinkedFillObject left))
				{
					if (!(linkedFillObject is GroupColorLinkedObject left2))
					{
						if (!(linkedFillObject is OutputScreenLinkedObject left3))
						{
							if (!(linkedFillObject is PCOLiveLinkedObject left4))
							{
								if (!(linkedFillObject is PlaybackMarkerColorLinkedObject left5))
								{
									if (!(linkedFillObject is SlideImageLinkedObject left6))
									{
										if (!(linkedFillObject is SlideLabelColorLinkedObject left7))
										{
											if (linkedFillObject is TimecodeStatusColorLinkedObject)
											{
												propertyType = entityFactory.Create<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ITimecodeStatus>();
											}
										}
										else
										{
											ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ISlideLabelColor slideLabelColor = entityFactory.Create<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ISlideLabelColor>();
											ObjectBinder<SlideLabelColorLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.ISlideLabelColor> objectBinder = SlideLabelColorLinkedObject.CreateBinder(left7, slideLabelColor.Value);
											objectBinder.InitializeRightFromLeft();
											propertyType = slideLabelColor;
											disposable = objectBinder;
										}
									}
									else
									{
										ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ISlideImage slideImage = entityFactory.Create<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ISlideImage>();
										ObjectBinder<SlideImageLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.ISlideImage> objectBinder2 = SlideImageLinkedObject.CreateBinder(left6, slideImage.Value);
										objectBinder2.InitializeRightFromLeft();
										propertyType = slideImage;
										disposable = objectBinder2;
									}
								}
								else
								{
									ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IPlaybackMarkerColor playbackMarkerColor = entityFactory.Create<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IPlaybackMarkerColor>();
									ObjectBinder<PlaybackMarkerColorLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerIdentifier> objectBinder3 = PlaybackMarkerColorLinkedObject.CreateBinder(left5, playbackMarkerColor.Value);
									objectBinder3.InitializeRightFromLeft();
									propertyType = playbackMarkerColor;
									disposable = objectBinder3;
								}
							}
							else
							{
								ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IPcoLive pcoLive = entityFactory.Create<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IPcoLive>();
								ObjectBinder<PCOLiveLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IPcoLive> objectBinder4 = PCOLiveLinkedObject.CreateBinder(left4, pcoLive.Value);
								objectBinder4.InitializeRightFromLeft();
								propertyType = pcoLive;
								disposable = objectBinder4;
							}
						}
						else
						{
							ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IOutputScreen outputScreen = entityFactory.Create<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IOutputScreen>();
							ObjectBinder<OutputScreenLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IOutputScreen> objectBinder5 = OutputScreenLinkedObject.CreateBinder(left3, outputScreen.Value);
							objectBinder5.InitializeRightFromLeft();
							propertyType = outputScreen;
							disposable = objectBinder5;
						}
					}
					else
					{
						ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IGroupColor groupColor = entityFactory.Create<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IGroupColor>();
						ObjectBinder<GroupColorLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IGroupColor> objectBinder6 = GroupColorLinkedObject.CreateBinder(left2, groupColor.Value);
						objectBinder6.InitializeRightFromLeft();
						propertyType = groupColor;
						disposable = objectBinder6;
					}
				}
				else
				{
					ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IAlternateFill alternateFill = entityFactory.Create<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IAlternateFill>();
					ObjectBinder<ElementLinkedFillObject, ISlide.Types.IElement.Types.IDataLink.Types.IAlternateElementFill> objectBinder7 = ElementLinkedFillObject.CreateBinder(left, alternateFill.Value);
					objectBinder7.InitializeRightFromLeft();
					propertyType = alternateFill;
					disposable = objectBinder7;
				}
			}
			else
			{
				propertyType = entityFactory.Create<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IChordChart>();
			}
		}
		else
		{
			propertyType = entityFactory.Create<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ICaptureStatusColor>();
		}
		if (propertyType != null)
		{
			ISlide.Types.IElement.Types.IDataLink dataLink = entityFactory.Create<ISlide.Types.IElement.Types.IDataLink>();
			dataLink.PropertyType.Set(propertyType);
			if (disposable != null)
			{
				dataLink.RegisterLinkedDisposable(disposable);
			}
			return dataLink;
		}
		return null;
	}

	public override bool RenderEquals([NotNullWhen(true)] ILink? other)
	{
		if (base.RenderEquals(other) && other is FillLink fillLink)
		{
			return LinkedObject?.RenderEquals(fillLink.LinkedObject) ?? (LinkedObject == fillLink.LinkedObject);
		}
		return false;
	}

	public override int GetRenderHashCode()
	{
		return RenderHashCodeHelper.GenerateHashCode(base.GetRenderHashCode(), LinkedObject);
	}

	public override ILink Clone()
	{
		FillLink fillLink = new FillLink
		{
			LinkedObject = LinkedObject?.Clone()
		};
		CopyProperties(fillLink);
		return fillLink;
	}

	public override Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink Serialize()
	{
		Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink dataLink = new Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink();
		LinkedObject?.Serialize(dataLink);
		return dataLink;
	}

	protected override void OnUndoStackChanged(UndoStack? undoStack)
	{
		if (LinkedObject != null)
		{
			LinkedObject.UndoStack = undoStack;
		}
	}

	private void LinkedObjectPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		OnLinkObjectUpdated();
	}
}
