using System;
using Pro.Common.Dispatcher;
using Pro.Common.Logging;
using Pro.Common.ObjectBinding;
using Pro.DO.Triggering;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Actions.Playlist;
using ProPresenter.DO.DependencyInjection;

namespace ProPresenter.DO.Actions;

public class ActionBinderFactory : IActionBinderFactory
{
	private readonly ILogger _logger;

	private readonly IProPresenterDOFactoryProvider _factoryProvider;

	private readonly IUiScheduler _scheduler;

	public ActionBinderFactory(ILogger logger, IProPresenterDOFactoryProvider factoryProvider, IUiScheduler scheduler)
	{
		_logger = logger;
		_factoryProvider = factoryProvider;
		_scheduler = scheduler;
	}

	public Pro.DO.Triggering.IAction CreateAction(Pro.Entity.IAction right, string containerId)
	{
		ActionType num = ToActionType(right.Type.Value);
		Pro.SerializationInterop.RVProtoData.Action data = null;
		if (num == ActionType.Media)
		{
			data = EntityMediaToProtoMedia(right);
		}
		return num.ConstructAction(data, containerId);
	}

	private Pro.SerializationInterop.RVProtoData.Action EntityMediaToProtoMedia(Pro.Entity.IAction right)
	{
		Pro.SerializationInterop.RVProtoData.Action action = new Pro.SerializationInterop.RVProtoData.Action
		{
			Media = new Pro.SerializationInterop.RVProtoData.Action.Types.MediaType
			{
				Element = new Pro.SerializationInterop.RVProtoData.Media()
			}
		};
		if (right.ActionTypeData.Value is Pro.Entity.IAction.Types.IActionTypeData.IMedia media)
		{
			if (media.Value.Element.Value.TypeProperties.Value is IMedia.Types.ITypeProperties.IAudio)
			{
				action.Media.Element.Audio = new Pro.SerializationInterop.RVProtoData.Media.Types.AudioTypeProperties();
			}
			else if (media.Value.Element.Value.TypeProperties.Value is IMedia.Types.ITypeProperties.IImage)
			{
				action.Media.Element.Image = new Pro.SerializationInterop.RVProtoData.Media.Types.ImageTypeProperties();
			}
			else if (media.Value.Element.Value.TypeProperties.Value is IMedia.Types.ITypeProperties.IVideo)
			{
				action.Media.Element.Video = new Pro.SerializationInterop.RVProtoData.Media.Types.VideoTypeProperties();
			}
			else if (media.Value.Element.Value.TypeProperties.Value is IMedia.Types.ITypeProperties.ILiveVideo)
			{
				action.Media.Element.LiveVideo = new Pro.SerializationInterop.RVProtoData.Media.Types.LiveVideoTypeProperties();
			}
			else if (media.Value.Element.Value.TypeProperties.Value is IMedia.Types.ITypeProperties.IWebContent)
			{
				action.Media.Element.WebContent = new Pro.SerializationInterop.RVProtoData.Media.Types.WebContentTypeProperties();
			}
		}
		return action;
	}

	public IReadOnlyObjectBinder<Pro.DO.Triggering.IAction, Pro.Entity.IAction> CreateBinder(Pro.DO.Triggering.IAction left, Pro.Entity.IAction right)
	{
		if (!(left is AudienceLookAction left2))
		{
			if (!(left is AudioInputAction left3))
			{
				if (!(left is AudioPlaylistAction left4))
				{
					if (!(left is CaptureAction left5))
					{
						if (!(left is ClearAction left6))
						{
							if (!(left is ClearGroupAction left7))
							{
								if (!(left is CommunicationAction left8))
								{
									if (!(left is DocumentAction documentAction))
									{
										if (!(left is LibraryPlaylistAction left9))
										{
											if (!(left is MacroAction left10))
											{
												if (!(left is MediaAction left11))
												{
													if (!(left is MessageAction left12))
													{
														if (!(left is PropAction left13))
														{
															if (!(left is SlideAction left14))
															{
																if (!(left is SlideDestinationAction left15))
																{
																	if (!(left is StageAction left16))
																	{
																		if (!(left is TimerAction left17))
																		{
																			if (left is VisualPlaylistAction left18)
																			{
																				return VisualPlaylistAction.CreateBinder(_scheduler, _factoryProvider.EntityFactory, left18, right);
																			}
																			throw new NotSupportedException($"Action - {left} Not Supported");
																		}
																		return TimerAction.CreateBinder(_scheduler, _factoryProvider.EntityFactory, left17, right);
																	}
																	return StageAction.CreateBinder(_scheduler, _factoryProvider.EntityFactory, left16, right, DefaultActionTypeChangedHandler);
																}
																return SlideDestinationAction.CreateBinder(_scheduler, _factoryProvider.EntityFactory, left15, right);
															}
															return SlideAction.CreateBinder(_scheduler, _factoryProvider, left14, right);
														}
														return PropAction.CreateBinder(_scheduler, _factoryProvider.EntityFactory, left13, right);
													}
													return MessageAction.CreateBinder(_scheduler, _factoryProvider.EntityFactory, left12, right);
												}
												return MediaAction.CreateBinder(_scheduler, _factoryProvider.EntityFactory, this, left11, right);
											}
											return MacroAction.CreateBinder(_scheduler, _factoryProvider.EntityFactory, left10, right);
										}
										return LibraryPlaylistAction.CreateBinder(_scheduler, _factoryProvider.EntityFactory, left9, right);
									}
									return documentAction.CreateBinder(_scheduler, _factoryProvider.EntityFactory, right);
								}
								return CommunicationAction.CreateBinder(_scheduler, _factoryProvider.EntityFactory, left8, right, DefaultActionTypeChangedHandler);
							}
							return ClearGroupAction.CreateBinder(_scheduler, _factoryProvider.EntityFactory, left7, right);
						}
						return ClearAction.CreateBinder(_scheduler, _factoryProvider.EntityFactory, left6, right);
					}
					return CaptureAction.CreateBinder(_scheduler, _factoryProvider.EntityFactory, left5, right);
				}
				return AudioPlaylistAction.CreateBinder(_scheduler, _factoryProvider.EntityFactory, left4, right);
			}
			return AudioInputAction.CreateBinder(_scheduler, _factoryProvider.EntityFactory, left3, right);
		}
		return AudienceLookAction.CreateBinder(_scheduler, _factoryProvider.EntityFactory, left2, right);
		void DefaultActionTypeChangedHandler(Pro.DO.Triggering.IAction modelAction, Pro.Entity.IAction entityAction)
		{
			_logger.Info("Action Type unexpectedly changed and not handled, Model Action Type: {0} - Entity Action Type: {1}", modelAction.ActionType.ToString(), entityAction.Type.ToString());
		}
	}

	private static ActionType ToActionType(Pro.Entity.IAction.Types.ActionType actionType)
	{
		return actionType switch
		{
			Pro.Entity.IAction.Types.ActionType.StageLayout => ActionType.StageLayout, 
			Pro.Entity.IAction.Types.ActionType.Media => ActionType.Media, 
			Pro.Entity.IAction.Types.ActionType.Timer => ActionType.Timer, 
			Pro.Entity.IAction.Types.ActionType.Communication => ActionType.Communication, 
			Pro.Entity.IAction.Types.ActionType.Clear => ActionType.Clear, 
			Pro.Entity.IAction.Types.ActionType.Prop => ActionType.Prop, 
			Pro.Entity.IAction.Types.ActionType.Message => ActionType.Message, 
			Pro.Entity.IAction.Types.ActionType.PresentationSlide => ActionType.Slide, 
			Pro.Entity.IAction.Types.ActionType.PresentationDocument => ActionType.Document, 
			Pro.Entity.IAction.Types.ActionType.PropSlide => ActionType.PropSlide, 
			Pro.Entity.IAction.Types.ActionType.AudienceLook => ActionType.AudienceLook, 
			Pro.Entity.IAction.Types.ActionType.AudioInput => ActionType.AudioInput, 
			Pro.Entity.IAction.Types.ActionType.AudioBinPlaylist => ActionType.AudioPlaylist, 
			Pro.Entity.IAction.Types.ActionType.MediaBinPlaylist => ActionType.VisualPlaylist, 
			Pro.Entity.IAction.Types.ActionType.SlideDestination => ActionType.SlideDestination, 
			Pro.Entity.IAction.Types.ActionType.Macro => ActionType.Macro, 
			Pro.Entity.IAction.Types.ActionType.ClearGroup => ActionType.ClearGroup, 
			Pro.Entity.IAction.Types.ActionType.Capture => ActionType.Capture, 
			Pro.Entity.IAction.Types.ActionType.LibraryPlaylist => ActionType.LibraryPlaylist, 
			_ => throw new NotSupportedException($"ActionType - {actionType} Not Supported"), 
		};
	}
}
