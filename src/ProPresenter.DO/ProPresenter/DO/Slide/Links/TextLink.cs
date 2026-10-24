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
using ProPresenter.DO.Settings;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Timer;

namespace ProPresenter.DO.Slide.Links;

public class TextLink : LinkBase
{
	private ILinkedTextObject? _linkedObject;

	public override LinkType LinkType => LinkType.Text;

	public override string? DisplayText
	{
		get
		{
			if (base.IsEnabled)
			{
				ILinkedTextObject linkedObject = LinkedObject;
				if (!(linkedObject is RssFeedLinkedObject rssFeedLinkedObject))
				{
					if (!(linkedObject is FileFeedLinkedObject fileFeedLinkedObject))
					{
						if (linkedObject == null)
						{
							return LocalizedStrings.Get("EDITOR_SHAPE_TEXT_LINK_UNCONFIGURED_label");
						}
						return LocalizedStrings.Get("EDITOR_SHAPE_TEXT_LINK_label", new object[1] { LinkedObject.DisplayText });
					}
					return LocalizedStrings.Get("EDITOR_SHAPE_TEXT_LINK_label", new object[1] { fileFeedLinkedObject.DisplayFileTextForLinkedObject });
				}
				return LocalizedStrings.Get("EDITOR_SHAPE_TEXT_LINK_label", new object[1] { rssFeedLinkedObject.DisplayRssTextForLinkedObject });
			}
			return null;
		}
	}

	public ILinkedTextObject? LinkedObject
	{
		get
		{
			return _linkedObject;
		}
		set
		{
			SetValue<ILinkedTextObject>("LinkedObject", ref _linkedObject, value, delegate(ILinkedTextObject o, ILinkedTextObject n)
			{
				if (o != null)
				{
					o.PropertyChanged -= LinkedObjectPropertyChanged;
					o.VisualInvalidated -= base.OnVisualInvalidated;
					o.DataModified -= base.OnLinkObjectUpdated;
				}
				if (n != null)
				{
					n.PropertyChanged += LinkedObjectPropertyChanged;
					n.VisualInvalidated += base.OnVisualInvalidated;
					n.DataModified += base.OnLinkObjectUpdated;
					n.UndoStack = base.UndoStack;
					base.IsEnabled = true;
				}
				base.UndoStack?.Commit(UndoActionTypes.LinkTextObject.ToAction(), this, "LinkedObject", o, n, null, null, autoFinalize: true);
				OnLinkObjectUpdated();
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
			if (IsTextLink(entity.Items[num].PropertyType.Value))
			{
				entity.RemoveAt(num);
			}
		}
		if (closedBezierPath.TextLink.IsEnabled)
		{
			ISlide.Types.IElement.Types.IDataLink dataLink = CreateAndRegisterLinkedObjectBinder(entityFactory, closedBezierPath.TextLink.LinkedObject);
			if (dataLink != null)
			{
				entity.Add(dataLink);
			}
		}
	}

	public static void HandleEntityChanges(IEntityFactory entityFactory, IGeneral general, BezierPath bezierPath, Pro.Entity.Collections.ICollection<ISlide.Types.IElement.Types.IDataLink> entity)
	{
		if (!(bezierPath is ClosedBezierPath closedBezierPath))
		{
			return;
		}
		IEnumerable<ISlide.Types.IElement.Types.IDataLink> enumerable = entity.Items.Where((ISlide.Types.IElement.Types.IDataLink d) => IsTextLink(d.PropertyType.Value));
		closedBezierPath.TextLink.IsEnabled = enumerable.Any();
		foreach (ISlide.Types.IElement.Types.IDataLink item in enumerable)
		{
			closedBezierPath.TextLink.LinkedObject = CreateLinkedObjectAndRegisterBinder(entityFactory, general, item);
		}
	}

	public static bool IsTextLink(ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType propertyType)
	{
		if (!(propertyType is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IAudioCountdown) && !(propertyType is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IAutoAdvanceTimeRemaining) && !(propertyType is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ICaptureStatusText) && !(propertyType is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ICcliText) && !(propertyType is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IClockText) && !(propertyType is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IAlternateText) && !(propertyType is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IFileFeed) && !(propertyType is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IGroupName) && !(propertyType is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IPlaybackMarkerText) && !(propertyType is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IPlaylistItem) && !(propertyType is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IPresentation) && !(propertyType is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IPresentationNotes) && !(propertyType is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IRssFeed) && !(propertyType is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ISlideCount) && !(propertyType is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ISlideLabelText) && !(propertyType is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ISlideText) && !(propertyType is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IStageMessage) && !(propertyType is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ITimecodeText) && !(propertyType is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ITimerText))
		{
			return propertyType is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IVideoCountdown;
		}
		return true;
	}

	private static ILinkedTextObject? CreateLinkedObjectAndRegisterBinder(IEntityFactory entityFactory, IGeneral general, ISlide.Types.IElement.Types.IDataLink fillLink)
	{
		ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType value = fillLink.PropertyType.Value;
		if (!(value is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IAudioCountdown audioCountdown))
		{
			if (!(value is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IAutoAdvanceTimeRemaining autoAdvanceTimeRemaining))
			{
				if (!(value is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ICaptureStatusText captureStatusText))
				{
					if (!(value is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ICcliText))
					{
						if (!(value is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IClockText clockText))
						{
							if (!(value is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IAlternateText alternateText))
							{
								if (!(value is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IFileFeed fileFeed))
								{
									if (!(value is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IGroupName groupName))
									{
										if (!(value is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IPlaybackMarkerText playbackMarkerText))
										{
											if (!(value is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IPlaylistItem playlistItem))
											{
												if (!(value is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IPresentation presentation))
												{
													if (!(value is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IPresentationNotes))
													{
														if (!(value is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IRssFeed rssFeed))
														{
															if (!(value is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ISlideCount slideCount))
															{
																if (!(value is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ISlideLabelText slideLabelText))
																{
																	if (!(value is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ISlideText slideText))
																	{
																		if (!(value is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IStageMessage stageMessage))
																		{
																			if (!(value is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ITimecodeText))
																			{
																				if (!(value is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ITimerText timerText))
																				{
																					if (value is ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IVideoCountdown videoCountdown)
																					{
																						VideoCountdownLinkedObject videoCountdownLinkedObject = new VideoCountdownLinkedObject();
																						ObjectBinder<VideoCountdownLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IVideoCountdown> objectBinder = VideoCountdownLinkedObject.CreateBinder(entityFactory, videoCountdownLinkedObject, videoCountdown.Value);
																						fillLink.RegisterLinkedDisposable(objectBinder);
																						objectBinder.InitializeLeftFromRight();
																						return videoCountdownLinkedObject;
																					}
																					return null;
																				}
																				TimerLinkedObject timerLinkedObject = new TimerLinkedObject(null);
																				ObjectBinder<TimerLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.ITimerText> objectBinder2 = TimerLinkedObject.CreateBinder(entityFactory, timerLinkedObject, timerText.Value);
																				fillLink.RegisterLinkedDisposable(objectBinder2);
																				objectBinder2.InitializeLeftFromRight();
																				return timerLinkedObject;
																			}
																			return new TimecodeTextLinkedObject();
																		}
																		StageMessageLinkedObject stageMessageLinkedObject = new StageMessageLinkedObject();
																		ObjectBinder<StageMessageLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IStageMessage> objectBinder3 = StageMessageLinkedObject.CreateBinder(stageMessageLinkedObject, stageMessage.Value);
																		fillLink.RegisterLinkedDisposable(objectBinder3);
																		objectBinder3.InitializeLeftFromRight();
																		return stageMessageLinkedObject;
																	}
																	SlideTextLinkedObject slideTextLinkedObject = new SlideTextLinkedObject();
																	ObjectBinder<SlideTextLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.ISlideText> objectBinder4 = SlideTextLinkedObject.CreateBinder(slideTextLinkedObject, slideText.Value);
																	fillLink.RegisterLinkedDisposable(objectBinder4);
																	objectBinder4.InitializeLeftFromRight();
																	return slideTextLinkedObject;
																}
																SlideLabelTextLinkedObject slideLabelTextLinkedObject = new SlideLabelTextLinkedObject();
																ObjectBinder<SlideLabelTextLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.ISlideLabelText> objectBinder5 = SlideLabelTextLinkedObject.CreateBinder(slideLabelTextLinkedObject, slideLabelText.Value);
																fillLink.RegisterLinkedDisposable(objectBinder5);
																objectBinder5.InitializeLeftFromRight();
																return slideLabelTextLinkedObject;
															}
															SlideCountTextLinkedObject slideCountTextLinkedObject = new SlideCountTextLinkedObject();
															ObjectBinder<SlideCountTextLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.ISlideCount> objectBinder6 = SlideCountTextLinkedObject.CreateBinder(slideCountTextLinkedObject, slideCount.Value);
															fillLink.RegisterLinkedDisposable(objectBinder6);
															objectBinder6.InitializeLeftFromRight();
															return slideCountTextLinkedObject;
														}
														RssFeedLinkedObject rssFeedLinkedObject = new RssFeedLinkedObject();
														ObjectBinder<RssFeedLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IRssFeed> objectBinder7 = RssFeedLinkedObject.CreateBinder(rssFeedLinkedObject, rssFeed.Value);
														fillLink.RegisterLinkedDisposable(objectBinder7);
														objectBinder7.InitializeLeftFromRight();
														return rssFeedLinkedObject;
													}
													return new PresentationNotesLinkedObject();
												}
												PresentationNameLinkedObject presentationNameLinkedObject = new PresentationNameLinkedObject();
												ObjectBinder<PresentationNameLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IPresentation> objectBinder8 = PresentationNameLinkedObject.CreateBinder(presentationNameLinkedObject, presentation.Value);
												fillLink.RegisterLinkedDisposable(objectBinder8);
												objectBinder8.InitializeLeftFromRight();
												return presentationNameLinkedObject;
											}
											PlaylistItemLinkedObject playlistItemLinkedObject = new PlaylistItemLinkedObject();
											ObjectBinder<PlaylistItemLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IPlaylistItem> objectBinder9 = PlaylistItemLinkedObject.CreateBinder(playlistItemLinkedObject, playlistItem.Value);
											fillLink.RegisterLinkedDisposable(objectBinder9);
											objectBinder9.InitializeLeftFromRight();
											return playlistItemLinkedObject;
										}
										PlaybackMarkerTextLinkedObject playbackMarkerTextLinkedObject = new PlaybackMarkerTextLinkedObject();
										ObjectBinder<PlaybackMarkerTextLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerText> objectBinder10 = PlaybackMarkerTextLinkedObject.CreateBinder(entityFactory, playbackMarkerTextLinkedObject, playbackMarkerText.Value);
										fillLink.RegisterLinkedDisposable(objectBinder10);
										objectBinder10.InitializeLeftFromRight();
										return playbackMarkerTextLinkedObject;
									}
									GroupNameLinkedObject groupNameLinkedObject = new GroupNameLinkedObject();
									ObjectBinder<GroupNameLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IGroupName> objectBinder11 = GroupNameLinkedObject.CreateBinder(groupNameLinkedObject, groupName.Value);
									fillLink.RegisterLinkedDisposable(objectBinder11);
									objectBinder11.InitializeLeftFromRight();
									return groupNameLinkedObject;
								}
								FileFeedLinkedObject fileFeedLinkedObject = new FileFeedLinkedObject();
								ObjectBinder<FileFeedLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IFileFeed> objectBinder12 = FileFeedLinkedObject.CreateBinder(fileFeedLinkedObject, fileFeed.Value);
								fillLink.RegisterLinkedDisposable(objectBinder12);
								objectBinder12.InitializeLeftFromRight();
								return fileFeedLinkedObject;
							}
							ElementTextLinkedObject elementTextLinkedObject = new ElementTextLinkedObject();
							ObjectBinder<ElementTextLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IAlternateElementText> objectBinder13 = ElementTextLinkedObject.CreateBinder(elementTextLinkedObject, alternateText.Value);
							fillLink.RegisterLinkedDisposable(objectBinder13);
							objectBinder13.InitializeLeftFromRight();
							return elementTextLinkedObject;
						}
						ClockTextLinkedObject clockTextLinkedObject = new ClockTextLinkedObject(new ClockData());
						ObjectBinder<ClockTextLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IClockText> objectBinder14 = ClockTextLinkedObject.CreateBinder(entityFactory, clockTextLinkedObject, clockText.Value);
						fillLink.RegisterLinkedDisposable(objectBinder14);
						objectBinder14.InitializeLeftFromRight();
						return clockTextLinkedObject;
					}
					return new CCLITextLinkedObject(general);
				}
				CaptureTextLinkedObject captureTextLinkedObject = new CaptureTextLinkedObject();
				ObjectBinder<CaptureTextLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.ICaptureStatusText> objectBinder15 = CaptureTextLinkedObject.CreateBinder(entityFactory, captureTextLinkedObject, captureStatusText.Value);
				fillLink.RegisterLinkedDisposable(objectBinder15);
				objectBinder15.InitializeLeftFromRight();
				return captureTextLinkedObject;
			}
			AutoAdvanceLinkedObject autoAdvanceLinkedObject = new AutoAdvanceLinkedObject();
			ObjectBinder<AutoAdvanceLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IAutoAdvanceTimeRemaining> objectBinder16 = AutoAdvanceLinkedObject.CreateBinder(entityFactory, autoAdvanceLinkedObject, autoAdvanceTimeRemaining.Value);
			fillLink.RegisterLinkedDisposable(objectBinder16);
			objectBinder16.InitializeLeftFromRight();
			return autoAdvanceLinkedObject;
		}
		AudioCountdownLinkedObject audioCountdownLinkedObject = new AudioCountdownLinkedObject();
		ObjectBinder<AudioCountdownLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IAudioCountdown> objectBinder17 = AudioCountdownLinkedObject.CreateBinder(entityFactory, audioCountdownLinkedObject, audioCountdown.Value);
		fillLink.RegisterLinkedDisposable(objectBinder17);
		objectBinder17.InitializeLeftFromRight();
		return audioCountdownLinkedObject;
	}

	private static ISlide.Types.IElement.Types.IDataLink? CreateAndRegisterLinkedObjectBinder(IEntityFactory entityFactory, ILinkedTextObject? linkedTextObject)
	{
		ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType propertyType = null;
		IDisposable disposable = null;
		if (!(linkedTextObject is AudioCountdownLinkedObject left))
		{
			if (!(linkedTextObject is AutoAdvanceLinkedObject left2))
			{
				if (!(linkedTextObject is CaptureTextLinkedObject left3))
				{
					if (!(linkedTextObject is CCLITextLinkedObject))
					{
						if (!(linkedTextObject is ClockTextLinkedObject left4))
						{
							if (!(linkedTextObject is ElementTextLinkedObject left5))
							{
								if (!(linkedTextObject is FileFeedLinkedObject left6))
								{
									if (!(linkedTextObject is GroupNameLinkedObject left7))
									{
										if (!(linkedTextObject is PlaybackMarkerTextLinkedObject left8))
										{
											if (!(linkedTextObject is PlaylistItemLinkedObject left9))
											{
												if (!(linkedTextObject is PresentationNameLinkedObject left10))
												{
													if (!(linkedTextObject is PresentationNotesLinkedObject))
													{
														if (!(linkedTextObject is RssFeedLinkedObject left11))
														{
															if (!(linkedTextObject is SlideCountTextLinkedObject left12))
															{
																if (!(linkedTextObject is SlideLabelTextLinkedObject left13))
																{
																	if (!(linkedTextObject is SlideTextLinkedObject left14))
																	{
																		if (!(linkedTextObject is StageMessageLinkedObject left15))
																		{
																			if (!(linkedTextObject is TimecodeTextLinkedObject))
																			{
																				if (!(linkedTextObject is TimerLinkedObject left16))
																				{
																					if (linkedTextObject is VideoCountdownLinkedObject left17)
																					{
																						ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IVideoCountdown videoCountdown = entityFactory.Create<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IVideoCountdown>();
																						ObjectBinder<VideoCountdownLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IVideoCountdown> objectBinder = VideoCountdownLinkedObject.CreateBinder(entityFactory, left17, videoCountdown.Value);
																						objectBinder.InitializeRightFromLeft();
																						propertyType = videoCountdown;
																						disposable = objectBinder;
																					}
																				}
																				else
																				{
																					ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ITimerText timerText = entityFactory.Create<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ITimerText>();
																					ObjectBinder<TimerLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.ITimerText> objectBinder2 = TimerLinkedObject.CreateBinder(entityFactory, left16, timerText.Value);
																					objectBinder2.InitializeRightFromLeft();
																					propertyType = timerText;
																					disposable = objectBinder2;
																				}
																			}
																			else
																			{
																				propertyType = entityFactory.Create<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ITimecodeText>();
																			}
																		}
																		else
																		{
																			ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IStageMessage stageMessage = entityFactory.Create<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IStageMessage>();
																			ObjectBinder<StageMessageLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IStageMessage> objectBinder3 = StageMessageLinkedObject.CreateBinder(left15, stageMessage.Value);
																			objectBinder3.InitializeRightFromLeft();
																			propertyType = stageMessage;
																			disposable = objectBinder3;
																		}
																	}
																	else
																	{
																		ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ISlideText slideText = entityFactory.Create<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ISlideText>();
																		ObjectBinder<SlideTextLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.ISlideText> objectBinder4 = SlideTextLinkedObject.CreateBinder(left14, slideText.Value);
																		objectBinder4.InitializeRightFromLeft();
																		propertyType = slideText;
																		disposable = objectBinder4;
																	}
																}
																else
																{
																	ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ISlideLabelText slideLabelText = entityFactory.Create<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ISlideLabelText>();
																	ObjectBinder<SlideLabelTextLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.ISlideLabelText> objectBinder5 = SlideLabelTextLinkedObject.CreateBinder(left13, slideLabelText.Value);
																	objectBinder5.InitializeRightFromLeft();
																	propertyType = slideLabelText;
																	disposable = objectBinder5;
																}
															}
															else
															{
																ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ISlideCount slideCount = entityFactory.Create<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ISlideCount>();
																ObjectBinder<SlideCountTextLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.ISlideCount> objectBinder6 = SlideCountTextLinkedObject.CreateBinder(left12, slideCount.Value);
																objectBinder6.InitializeRightFromLeft();
																propertyType = slideCount;
																disposable = objectBinder6;
															}
														}
														else
														{
															ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IRssFeed rssFeed = entityFactory.Create<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IRssFeed>();
															ObjectBinder<RssFeedLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IRssFeed> objectBinder7 = RssFeedLinkedObject.CreateBinder(left11, rssFeed.Value);
															objectBinder7.InitializeRightFromLeft();
															propertyType = rssFeed;
															disposable = objectBinder7;
														}
													}
													else
													{
														propertyType = entityFactory.Create<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IPresentationNotes>();
													}
												}
												else
												{
													ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IPresentation presentation = entityFactory.Create<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IPresentation>();
													ObjectBinder<PresentationNameLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IPresentation> objectBinder8 = PresentationNameLinkedObject.CreateBinder(left10, presentation.Value);
													objectBinder8.InitializeRightFromLeft();
													propertyType = presentation;
													disposable = objectBinder8;
												}
											}
											else
											{
												ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IPlaylistItem playlistItem = entityFactory.Create<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IPlaylistItem>();
												ObjectBinder<PlaylistItemLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IPlaylistItem> objectBinder9 = PlaylistItemLinkedObject.CreateBinder(left9, playlistItem.Value);
												objectBinder9.InitializeRightFromLeft();
												propertyType = playlistItem;
												disposable = objectBinder9;
											}
										}
										else
										{
											ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IPlaybackMarkerText playbackMarkerText = entityFactory.Create<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IPlaybackMarkerText>();
											ObjectBinder<PlaybackMarkerTextLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerText> objectBinder10 = PlaybackMarkerTextLinkedObject.CreateBinder(entityFactory, left8, playbackMarkerText.Value);
											objectBinder10.InitializeRightFromLeft();
											propertyType = playbackMarkerText;
											disposable = objectBinder10;
										}
									}
									else
									{
										ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IGroupName groupName = entityFactory.Create<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IGroupName>();
										ObjectBinder<GroupNameLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IGroupName> objectBinder11 = GroupNameLinkedObject.CreateBinder(left7, groupName.Value);
										objectBinder11.InitializeRightFromLeft();
										propertyType = groupName;
										disposable = objectBinder11;
									}
								}
								else
								{
									ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IFileFeed fileFeed = entityFactory.Create<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IFileFeed>();
									ObjectBinder<FileFeedLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IFileFeed> objectBinder12 = FileFeedLinkedObject.CreateBinder(left6, fileFeed.Value);
									objectBinder12.InitializeRightFromLeft();
									propertyType = fileFeed;
									disposable = objectBinder12;
								}
							}
							else
							{
								ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IAlternateText alternateText = entityFactory.Create<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IAlternateText>();
								ObjectBinder<ElementTextLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IAlternateElementText> objectBinder13 = ElementTextLinkedObject.CreateBinder(left5, alternateText.Value);
								objectBinder13.InitializeRightFromLeft();
								propertyType = alternateText;
								disposable = objectBinder13;
							}
						}
						else
						{
							ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IClockText clockText = entityFactory.Create<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IClockText>();
							ObjectBinder<ClockTextLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IClockText> objectBinder14 = ClockTextLinkedObject.CreateBinder(entityFactory, left4, clockText.Value);
							objectBinder14.InitializeRightFromLeft();
							propertyType = clockText;
							disposable = objectBinder14;
						}
					}
					else
					{
						propertyType = entityFactory.Create<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ICcliText>();
					}
				}
				else
				{
					ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ICaptureStatusText captureStatusText = entityFactory.Create<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ICaptureStatusText>();
					ObjectBinder<CaptureTextLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.ICaptureStatusText> objectBinder15 = CaptureTextLinkedObject.CreateBinder(entityFactory, left3, captureStatusText.Value);
					objectBinder15.InitializeRightFromLeft();
					propertyType = captureStatusText;
					disposable = objectBinder15;
				}
			}
			else
			{
				ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IAutoAdvanceTimeRemaining autoAdvanceTimeRemaining = entityFactory.Create<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IAutoAdvanceTimeRemaining>();
				ObjectBinder<AutoAdvanceLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IAutoAdvanceTimeRemaining> objectBinder16 = AutoAdvanceLinkedObject.CreateBinder(entityFactory, left2, autoAdvanceTimeRemaining.Value);
				objectBinder16.InitializeRightFromLeft();
				propertyType = autoAdvanceTimeRemaining;
				disposable = objectBinder16;
			}
		}
		else
		{
			ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IAudioCountdown audioCountdown = entityFactory.Create<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IAudioCountdown>();
			ObjectBinder<AudioCountdownLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IAudioCountdown> objectBinder17 = AudioCountdownLinkedObject.CreateBinder(entityFactory, left, audioCountdown.Value);
			objectBinder17.InitializeRightFromLeft();
			propertyType = audioCountdown;
			disposable = objectBinder17;
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
		if (base.RenderEquals(other) && other is TextLink textLink)
		{
			return LinkedObject?.RenderEquals(textLink.LinkedObject) ?? (LinkedObject == textLink.LinkedObject);
		}
		return false;
	}

	public override int GetRenderHashCode()
	{
		return RenderHashCodeHelper.GenerateHashCode(base.GetRenderHashCode(), LinkedObject);
	}

	public override ILink Clone()
	{
		TextLink textLink = new TextLink
		{
			LinkedObject = LinkedObject?.Clone()
		};
		CopyProperties(textLink);
		return textLink;
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
