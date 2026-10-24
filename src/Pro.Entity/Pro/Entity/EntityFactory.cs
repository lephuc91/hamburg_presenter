using System.Collections.Generic;
using Pro.Entity.Factory;
using Pro.Loro;

namespace Pro.Entity;

public class EntityFactory : IEntityFactory, IFactory<IAction.Types.IAudienceLookType>, IFactory<IAction.Types.IAudioInputType>, IFactory<IAction.Types.ICaptureType.Types.ICaptureStart>, IFactory<IAction.Types.ICaptureType.Types.ICaptureStop>, IFactory<IAction.Types.ICaptureType>, IFactory<IAction.Types.IClearGroupType>, IFactory<IAction.Types.ClearType>, IFactory<IAction.Types.ICommunicationType.Types.ICommand>, IFactory<IAction.Types.ICommunicationType.Types.IMidiCommand>, IFactory<IAction.Types.ICommunicationType>, IFactory<IAction.Types.IDocumentType>, IFactory<IAction.Types.IExternalPresentationType>, IFactory<IAction.Types.ILabel>, IFactory<IAction.Types.IMacroType>, IFactory<IAction.Types.IMaskType>, IFactory<IAction.Types.IMediaType.Types.IAudio>, IFactory<IAction.Types.IMediaType.Types.IPlaybackMarker>, IFactory<IAction.Types.IMediaType>, IFactory<IAction.Types.IMessageType>, IFactory<IAction.Types.IMultiScreenType>, IFactory<IAction.Types.IPlaylistItemType>, IFactory<IAction.Types.IPropType.Types.IPropClear>, IFactory<IAction.Types.IPropType.Types.IPropTrigger>, IFactory<IAction.Types.IPropType>, IFactory<IAction.Types.ISlideDestinationType>, IFactory<IAction.Types.ISlideType>, IFactory<IAction.Types.IStageLayoutType>, IFactory<IAction.Types.ITimerType>, IFactory<IAction.Types.ITransportControlType.Types.IJumpToTime>, IFactory<IAction.Types.ITransportControlType.Types.IPause>, IFactory<IAction.Types.ITransportControlType.Types.IPlay>, IFactory<IAction.Types.ITransportControlType>, IFactory<IAction>, IFactory<IAlignmentGuide>, IFactory<IAudio.Types.IDevice.Types.IFormat>, IFactory<IAudio.Types.IDevice>, IFactory<IAudio.Types.ILogicalChannel.Types.IOutputChannel>, IFactory<IAudio.Types.ILogicalChannel>, IFactory<IAudio.Types.IOutputSetup>, IFactory<IAudio.Types.IPhysicalChannel>, IFactory<IAudio.Types.ISettingsDocument>, IFactory<IAudio>, IFactory<IAudioInput.Types.IBehaviorMode.Types.IAutoOff>, IFactory<IAudioInput.Types.IBehaviorMode.Types.IAutoOn>, IFactory<IAudioInput.Types.IBehaviorMode.Types.IOff>, IFactory<IAudioInput.Types.IBehaviorMode.Types.IOn>, IFactory<IAudioInput.Types.IBehaviorMode>, IFactory<IAudioInput>, IFactory<IBackground>, IFactory<ICcliDocument>, IFactory<ICalendar.Types.IEvent.Types.IAction.Types.IMacro>, IFactory<ICalendar.Types.IEvent.Types.IAction.Types.IPlaylist>, IFactory<ICalendar.Types.IEvent.Types.IAction>, IFactory<ICalendar.Types.IEvent>, IFactory<ICalendar>, IFactory<IClearGroupsDocument.Types.IClearGroup>, IFactory<IClearGroupsDocument>, IFactory<IClock.Types.IFormat>, IFactory<IClock>, IFactory<ICloudAudioInput>, IFactory<ICloudProPresenterScreen>, IFactory<ICloudVideoInput>, IFactory<ICollectionElementType>, IFactory<Color>, IFactory<ICommunicationCommand.Types.IParameters>, IFactory<ICommunicationCommand>, IFactory<ICommunicationDevice.Types.IArtnetHardware>, IFactory<ICommunicationDevice.Types.IMidiHardware>, IFactory<ICommunicationDevice.Types.ISerialHardware>, IFactory<ICommunicationDevice.Types.ITcpHardware>, IFactory<ICommunicationDevice.Types.IUdpHardware>, IFactory<ICommunicationDevice>, IFactory<ICommunicationDeviceCloud>, IFactory<ICommunicationDeviceLocal>, IFactory<ICommunicationDeviceOption.Types.IOesProMode>, IFactory<ICommunicationDeviceOption>, IFactory<ICopyrightLayout.Types.Token>, IFactory<ICopyrightLayout>, IFactory<ICornerValues>, IFactory<ICue>, IFactory<IDigitalAudio.Types.IBus>, IFactory<IDigitalAudio.Types.IDevice.Types.IChannel>, IFactory<IDigitalAudio.Types.IDevice.Types.IFormat>, IFactory<IDigitalAudio.Types.IDevice.Types.IMap>, IFactory<IDigitalAudio.Types.IDevice.Types.IRouting>, IFactory<IDigitalAudio.Types.IDevice>, IFactory<IDigitalAudio.Types.ISetup>, IFactory<IDigitalAudio>, IFactory<IDisplayMode>, IFactory<IEdgeBlend.Types.IScreen>, IFactory<IEdgeBlend>, IFactory<IEffect.Types.IEffectVariable.Types.IEffectColor>, IFactory<IEffect.Types.IEffectVariable.Types.IEffectDirection>, IFactory<IEffect.Types.IEffectVariable.Types.IEffectDouble>, IFactory<IEffect.Types.IEffectVariable.Types.IEffectFloat>, IFactory<IEffect.Types.IEffectVariable.Types.IEffectInt>, IFactory<IEffect.Types.IEffectVariable>, IFactory<IEffect.Types.IPreset>, IFactory<IEffect>, IFactory<IFileProperties.Types.IRemoteProperties.Types.IProContent>, IFactory<IFileProperties.Types.IRemoteProperties>, IFactory<IFileProperties>, IFactory<Font>, IFactory<IGraphics.Types.IBackgroundEffect.Types.IBackgroundEffectBlur>, IFactory<IGraphics.Types.IBackgroundEffect.Types.IBackgroundEffectInvert>, IFactory<IGraphics.Types.IBackgroundEffect>, IFactory<IGraphics.Types.IEdgeInsets>, IFactory<IGraphics.Types.IElement>, IFactory<IGraphics.Types.IFeather>, IFactory<IGraphics.Types.IFill>, IFactory<IGraphics.Types.IGradient.Types.IColorStop>, IFactory<IGraphics.Types.IGradient>, IFactory<IGraphics.Types.IPath.Types.IBezierPoint>, IFactory<IGraphics.Types.IPath.Types.Shape.Types.Arrow>, IFactory<IGraphics.Types.IPath.Types.Shape.Types.Polygon>, IFactory<IGraphics.Types.IPath.Types.Shape.Types.RoundedRectangle>, IFactory<IGraphics.Types.IPath.Types.Shape.Types.Star>, IFactory<IGraphics.Types.IPath.Types.Shape>, IFactory<IGraphics.Types.IPath>, IFactory<IGraphics.Types.Point>, IFactory<IGraphics.Types.Rect>, IFactory<IGraphics.Types.IShadow>, IFactory<IGraphics.Types.Size>, IFactory<IGraphics.Types.IStroke>, IFactory<IGraphics.Types.IText.Types.IAlternateText>, IFactory<IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute>, IFactory<IGraphics.Types.IText.Types.IAttributes.Types.IParagraph.Types.ITabStop>, IFactory<IGraphics.Types.IText.Types.IAttributes.Types.IParagraph.Types.ITextList>, IFactory<IGraphics.Types.IText.Types.IAttributes.Types.IParagraph>, IFactory<IGraphics.Types.IText.Types.IAttributes.Types.IUnderline>, IFactory<IGraphics.Types.IText.Types.IAttributes>, IFactory<IGraphics.Types.IText.Types.IChordPro>, IFactory<IGraphics.Types.IText.Types.ICutOutFill>, IFactory<IGraphics.Types.IText.Types.IGradientFill>, IFactory<IGraphics.Types.IText.Types.ILineFillMask>, IFactory<IGraphics.Types.IText.Types.IMediaFill>, IFactory<IGraphics.Types.IText>, IFactory<IGraphics>, IFactory<IGroup>, IFactory<IHotKey>, IFactory<IntRange>, IFactory<IKeyMapping.Types.IComputerKeyboard>, IFactory<IKeyMapping.Types.IMidiKeyboard>, IFactory<IKeyMapping>, IFactory<IKeyMappingDocument>, IFactory<ILayer.Types.IBlending.Types.IMatte.Types.IAlpha>, IFactory<ILayer.Types.IBlending.Types.IMatte.Types.ILuma>, IFactory<ILayer.Types.IBlending.Types.IMatte.Types.IWhite>, IFactory<ILayer.Types.IBlending.Types.IMatte>, IFactory<ILayer.Types.IBlending.Types.IStandard>, IFactory<ILayer.Types.IBlending>, IFactory<ILayer>, IFactory<ILibrary.Types.ILibraryArray>, IFactory<ILibrary.Types.ILibraryItems>, IFactory<ILibrary>, IFactory<ILibraryItem>, IFactory<ILocalMessage>, IFactory<ILocalTimer>, IFactory<IMacrosDocument.Types.IMacro>, IFactory<IMacrosDocument.Types.IMacroCollection>, IFactory<IMacrosDocument>, IFactory<IMedia.Types.IAudio.Types.IChannel.Types.IOutput>, IFactory<IMedia.Types.IAudio.Types.IChannel>, IFactory<IMedia.Types.IAudio>, IFactory<IMedia.Types.IAudioProperties>, IFactory<IMedia.Types.IAudioTypeProperties>, IFactory<IMedia.Types.IDrawingProperties>, IFactory<IMedia.Types.IImageTypeProperties>, IFactory<IMedia.Types.ILiveVideoProperties>, IFactory<IMedia.Types.ILiveVideoTypeProperties>, IFactory<IMedia.Types.IMetadata>, IFactory<IMedia.Types.ITransportProperties>, IFactory<IMedia.Types.IVideoDevice.Types.IAirCast>, IFactory<IMedia.Types.IVideoDevice>, IFactory<IMedia.Types.IVideoProperties>, IFactory<IMedia.Types.IVideoTypeProperties>, IFactory<IMedia.Types.IWebContentTypeProperties>, IFactory<IMedia>, IFactory<IMessage.Types.IToken.Types.ITokenTypeClock>, IFactory<IMessage.Types.IToken.Types.ITokenTypeText>, IFactory<IMessage.Types.IToken.Types.ITokenTypeTimer>, IFactory<IMessage.Types.IToken>, IFactory<IMessage.Types.ITokenValue.Types.ITokenValueClock>, IFactory<IMessage.Types.ITokenValue.Types.ITokenValueText>, IFactory<IMessage.Types.ITokenValue.Types.ITokenValueTimer>, IFactory<IMessage.Types.ITokenValue>, IFactory<IMessage>, IFactory<IMessageDocument>, IFactory<IMessageLocalDocument>, IFactory<IMusicKeyScale>, IFactory<IOutputDisplay.Types.IBlackmagic>, IFactory<IOutputDisplay>, IFactory<IPlanningCenterPlan.Types.IPlanItem.Types.IAttachment>, IFactory<IPlanningCenterPlan.Types.IPlanItem.Types.ISongItem.Types.ISequence>, IFactory<IPlanningCenterPlan.Types.IPlanItem.Types.ISongItem>, IFactory<IPlanningCenterPlan.Types.IPlanItem>, IFactory<IPlanningCenterPlan>, IFactory<IPlaylist.Types.IFolderDirectory>, IFactory<IPlaylist.Types.IPlaylistArray>, IFactory<IPlaylist.Types.IPlaylistItems>, IFactory<IPlaylist>, IFactory<IPlaylistDocument>, IFactory<IPlaylistItem.Types.IHeader>, IFactory<IPlaylistItem.Types.IPlaceholder>, IFactory<IPlaylistItem.Types.IPlanningCenter>, IFactory<IPlaylistItem.Types.IPresentation>, IFactory<IPlaylistItem>, IFactory<IPlaylistTemplate.Types.ITemplate>, IFactory<IPlaylistTemplate>, IFactory<IPresentation.Types.IArrangement>, IFactory<IPresentation.Types.IBibleReference>, IFactory<IPresentation.Types.ICcli>, IFactory<IPresentation.Types.ICueGroup>, IFactory<IPresentation.Types.IMultiTracksLicensing>, IFactory<IPresentation.Types.IMusic>, IFactory<IPresentation.Types.ITimeline.Types.ICue>, IFactory<IPresentation.Types.ITimeline>, IFactory<IPresentation>, IFactory<IPresentationSlide.Types.INotes>, IFactory<IPresentationSlide>, IFactory<IProAudienceLook.Types.IProScreenLook>, IFactory<IProAudienceLook>, IFactory<IProGroupsDocument>, IFactory<IProLabelsDocument>, IFactory<IProMask>, IFactory<IProPresenterCommunications>, IFactory<IProPresenterLocalCommunications>, IFactory<IProPresenterLocalWorkspace>, IFactory<IProPresenterScreen.Types.ICombinedArrangement>, IFactory<IProPresenterScreen.Types.IEdgeBlendArrangement>, IFactory<IProPresenterScreen.Types.ISingleArrangement>, IFactory<IProPresenterScreen>, IFactory<IProPresenterWorkspace>, IFactory<IPropDocument.Types.IPropCollection>, IFactory<IPropDocument>, IFactory<IPropSlide>, IFactory<IRecording.Types.IPreset>, IFactory<IRecording.Types.ISettingsDocument>, IFactory<IRecording.Types.IStream.Types.IDestination.Types.IResi>, IFactory<IRecording.Types.IStream.Types.IDestination>, IFactory<IRecording.Types.IStream.Types.IDiskDestination>, IFactory<IRecording.Types.IStream.Types.IEncoder>, IFactory<IRecording.Types.IStream.Types.IOutputScreenSource>, IFactory<IRecording.Types.IStream.Types.IRtmpDestination>, IFactory<IRecording.Types.IStream>, IFactory<IRecording>, IFactory<IScreen.Types.IAlphaSettings.Types.IAlphaDevice>, IFactory<IScreen.Types.IAlphaSettings>, IFactory<IScreen.Types.IBlendCompensation>, IFactory<IScreen.Types.IColorAdjustment>, IFactory<IScreen>, IFactory<ISlide.Types.IElement.Types.IBuild>, IFactory<ISlide.Types.IElement.Types.IChildBuild>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IAlternateElementFill>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IAlternateElementText>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IAudioCountdown>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IAutoAdvanceTimeRemaining>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.ICcliText>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.ICaptureStatusColor>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.ICaptureStatusText.Types.IElapsedTime>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.ICaptureStatusText.Types.IStatusText>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.ICaptureStatusText>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IChordChart>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IChordProChart>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IClockText>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IColorTrigger>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IFileFeed>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IGroupColor>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IGroupName>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IOutputScreen>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPcoLive>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerIdentifier>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerText.Types.IName>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerText.Types.ITime>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerText>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPlaylistItem>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPresentation>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPresentationNotes>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IRssFeed>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.ISlideCount>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.ISlideImage>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.ISlideLabelColor>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.ISlideLabelText>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.ISlideText>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IStageMessage>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.ITicker.Types.IFileType>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.ITicker.Types.IRssType>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.ITicker.Types.ITextType>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.ITicker>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.ITimecodeStatus>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.ITimecodeText>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.ITimerText>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IVideoCountdown>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IAudioCountdownVisibility>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ICaptureSessionVisibility>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IElementVisibility>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ITimerVisibility>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoCountdownVisibility>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoInputVisibility>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink>, IFactory<ISlide.Types.IElement.Types.IDataLink>, IFactory<ISlide.Types.IElement.Types.ITextScroller>, IFactory<ISlide.Types.IElement>, IFactory<ISlide>, IFactory<IStage.Types.IDocument>, IFactory<IStage.Types.ILayout>, IFactory<IStage.Types.IScreenAssignment>, IFactory<IStage>, IFactory<ITemplate.Types.IDocument>, IFactory<ITemplate.Types.ISlide>, IFactory<ITemplate>, IFactory<ITemplateIdentification>, IFactory<ITestPattern.Types.IBlendGrid>, IFactory<ITestPattern.Types.ICustomColor>, IFactory<ITestPattern.Types.IIntensityColor>, IFactory<ITestPattern>, IFactory<ITestPatternDefinition.Types.IBoolProperty>, IFactory<ITestPatternDefinition.Types.IColorProperty>, IFactory<ITestPatternDefinition.Types.IDoubleProperty>, IFactory<ITestPatternDefinition.Types.IFontProperty>, IFactory<ITestPatternDefinition.Types.IIntProperty>, IFactory<ITestPatternDefinition.Types.IProperty>, IFactory<ITestPatternDefinition.Types.ISelectorProperty>, IFactory<ITestPatternDefinition.Types.IStringProperty>, IFactory<ITestPatternDefinition>, IFactory<ITestPatternDocument.Types.ITestPatternData.Types.IBoolProperty>, IFactory<ITestPatternDocument.Types.ITestPatternData.Types.IColorProperty>, IFactory<ITestPatternDocument.Types.ITestPatternData.Types.IDoubleProperty>, IFactory<ITestPatternDocument.Types.ITestPatternData.Types.IFontProperty>, IFactory<ITestPatternDocument.Types.ITestPatternData.Types.IIntProperty>, IFactory<ITestPatternDocument.Types.ITestPatternData.Types.IProperty>, IFactory<ITestPatternDocument.Types.ITestPatternData.Types.ISelectorProperty>, IFactory<ITestPatternDocument.Types.ITestPatternData.Types.IStringProperty>, IFactory<ITestPatternDocument.Types.ITestPatternData>, IFactory<ITestPatternDocument.Types.ITestPatternStateData>, IFactory<ITestPatternDocument>, IFactory<ITestPatternRenderSettings.Types.IOutput>, IFactory<ITestPatternRenderSettings>, IFactory<ITestPatternState>, IFactory<ITimer.Types.IConfiguration.Types.ITimerTypeCountdown>, IFactory<ITimer.Types.IConfiguration.Types.ITimerTypeCountdownToTime>, IFactory<ITimer.Types.IConfiguration.Types.ITimerTypeElapsedTime>, IFactory<ITimer.Types.IConfiguration>, IFactory<ITimer.Types.IFormat>, IFactory<ITimer>, IFactory<ITimersDocument>, IFactory<ITimersLocalDocument>, IFactory<Timestamp>, IFactory<ITransition.Types.IPreset>, IFactory<ITransition>, IFactory<Url.Types.ExternalRelativePath.Types.MacOsExternalVolume>, IFactory<Url.Types.ExternalRelativePath.Types.Win32ExternalVolume>, IFactory<Url.Types.ExternalRelativePath>, IFactory<Url.Types.LocalRelativePath>, IFactory<Url>, IFactory<IVideoInput>, IFactory<IAction.Types.ICaptureType.Types.ICaptureAction.IStart>, IFactory<IAction.Types.ICaptureType.Types.ICaptureAction.IStop>, IFactory<IAction.Types.ICommunicationType.Types.ICommandTypeData.IMidiCommand>, IFactory<IAction.Types.IMediaType.Types.IMediaType.IAudio>, IFactory<IAction.Types.IPropType.Types.ITriggerType.ITrigger>, IFactory<IAction.Types.IPropType.Types.ITriggerType.IClear>, IFactory<IAction.Types.ISlideType.Types.ISlide.IPresentation>, IFactory<IAction.Types.ISlideType.Types.ISlide.IProp>, IFactory<IAction.Types.IActionTypeData.IPlaylistItem>, IFactory<IAction.Types.IActionTypeData.IMedia>, IFactory<IAction.Types.IActionTypeData.ISlide>, IFactory<IAction.Types.IActionTypeData.ITimer>, IFactory<IAction.Types.IActionTypeData.IClear>, IFactory<IAction.Types.IActionTypeData.IStage>, IFactory<IAction.Types.IActionTypeData.IProp>, IFactory<IAction.Types.IActionTypeData.IMask>, IFactory<IAction.Types.IActionTypeData.IMessage>, IFactory<IAction.Types.IActionTypeData.ICommunication>, IFactory<IAction.Types.IActionTypeData.IMultiScreen>, IFactory<IAction.Types.IActionTypeData.IPresentationDocument>, IFactory<IAction.Types.IActionTypeData.IExternalPresentation>, IFactory<IAction.Types.IActionTypeData.IAudienceLook>, IFactory<IAction.Types.IActionTypeData.IAudioInput>, IFactory<IAction.Types.IActionTypeData.ISlideDestination>, IFactory<IAction.Types.IActionTypeData.IMacro>, IFactory<IAction.Types.IActionTypeData.IClearGroup>, IFactory<IAction.Types.IActionTypeData.ICapture>, IFactory<IAudioInput.Types.IBehaviorMode.Types.IMode.IOn>, IFactory<IAudioInput.Types.IBehaviorMode.Types.IMode.IOff>, IFactory<IAudioInput.Types.IBehaviorMode.Types.IMode.IAutoOn>, IFactory<IAudioInput.Types.IBehaviorMode.Types.IMode.IAutoOff>, IFactory<IAudioInput.Types.ISource.IAudioDevice>, IFactory<IAudioInput.Types.ISource.IVideoDevice>, IFactory<IBackground.Types.IFill.IColor>, IFactory<IBackground.Types.IFill.IGradient>, IFactory<ICommunicationDeviceLocal.Types.IHardwareType.ISerial>, IFactory<ICommunicationDeviceLocal.Types.IHardwareType.ITcpNetwork>, IFactory<ICommunicationDeviceLocal.Types.IHardwareType.IUdpNetwork>, IFactory<ICommunicationDeviceLocal.Types.IHardwareType.IArtnet>, IFactory<ICommunicationDeviceLocal.Types.IHardwareType.IMidi>, IFactory<ICommunicationDeviceOption.Types.IOptionType.IOesProMode>, IFactory<IEffect.Types.IEffectVariable.Types.IType.IInt>, IFactory<IEffect.Types.IEffectVariable.Types.IType.IFloat>, IFactory<IEffect.Types.IEffectVariable.Types.IType.IColor>, IFactory<IEffect.Types.IEffectVariable.Types.IType.IDirection>, IFactory<IEffect.Types.IEffectVariable.Types.IType.IDouble>, IFactory<IGraphics.Types.IBackgroundEffect.Types.IEffectType.IBackgroundBlur>, IFactory<IGraphics.Types.IBackgroundEffect.Types.IEffectType.IBackgroundInvert>, IFactory<IGraphics.Types.IElement.Types.IMask.ITextLineMask>, IFactory<IGraphics.Types.IFill.Types.IFillType.IColor>, IFactory<IGraphics.Types.IFill.Types.IFillType.IGradient>, IFactory<IGraphics.Types.IFill.Types.IFillType.IMedia>, IFactory<IGraphics.Types.IFill.Types.IFillType.IBackgroundEffect>, IFactory<IGraphics.Types.IText.Types.IAlternateText.Types.IContentType.IPlainText>, IFactory<IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.ICapitalization>, IFactory<IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.IOriginalFontSize>, IFactory<IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.IFontScaleFactor>, IFactory<IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.ITextGradientFill>, IFactory<IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.IShouldPreserveForegroundColor>, IFactory<IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.IChord>, IFactory<IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.ICutOutFill>, IFactory<IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.IMediaFill>, IFactory<IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.IBackgroundEffect>, IFactory<IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.IOriginalFont>, IFactory<IGraphics.Types.IText.Types.IAttributes.Types.IFill.ITextSolidFill>, IFactory<IGraphics.Types.IText.Types.IAttributes.Types.IFill.ITextGradientFill>, IFactory<IGraphics.Types.IText.Types.IAttributes.Types.IFill.ICutOutFill>, IFactory<IGraphics.Types.IText.Types.IAttributes.Types.IFill.IMediaFill>, IFactory<IGraphics.Types.IText.Types.IAttributes.Types.IFill.IBackgroundEffect>, IFactory<IKeyMapping.Types.ITargetIdentifier.IMenuItem>, IFactory<IKeyMapping.Types.ITargetIdentifier.IClearGroupIdentifier>, IFactory<IKeyMapping.Types.ITargetIdentifier.ICueIdentifier>, IFactory<IKeyMapping.Types.ITargetIdentifier.IGroupIdentifier>, IFactory<IKeyMapping.Types.ITargetIdentifier.IMacroIdentifier>, IFactory<IKeyMapping.Types.ITargetIdentifier.IPropIdentifier>, IFactory<IKeyMapping.Types.ITargetIdentifier.ITimerIdentifier>, IFactory<ILayer.Types.IBlending.Types.IMatte.Types.IMatteType.IAlpha>, IFactory<ILayer.Types.IBlending.Types.IMatte.Types.IMatteType.ILuma>, IFactory<ILayer.Types.IBlending.Types.IMatte.Types.IMatteType.IWhite>, IFactory<ILibrary.Types.IChildType.ILibraryChildren>, IFactory<ILibrary.Types.IChildType.ILibraryItems>, IFactory<IMedia.Types.ITypeProperties.IAudio>, IFactory<IMedia.Types.ITypeProperties.IImage>, IFactory<IMedia.Types.ITypeProperties.IVideo>, IFactory<IMedia.Types.ITypeProperties.ILiveVideo>, IFactory<IMedia.Types.ITypeProperties.IWebContent>, IFactory<IMessage.Types.IToken.Types.ITokenType.IText>, IFactory<IMessage.Types.IToken.Types.ITokenType.ITimer>, IFactory<IMessage.Types.IToken.Types.ITokenType.IClock>, IFactory<IMessage.Types.ITokenValue.Types.ITokenValueType.IText>, IFactory<IMessage.Types.ITokenValue.Types.ITokenValueType.ITimer>, IFactory<IMessage.Types.ITokenValue.Types.ITokenValueType.IClock>, IFactory<IOutputDisplay.Types.IHardwareOptions.IBlackmagic>, IFactory<IPlaylist.Types.IChildrenType.IPlaylists>, IFactory<IPlaylist.Types.IChildrenType.IItems>, IFactory<IPlaylist.Types.ILinkData.ISmartDirectory>, IFactory<IPlaylist.Types.ILinkData.IPcoPlan>, IFactory<IPlaylistItem.Types.IItemType.IHeader>, IFactory<IPlaylistItem.Types.IItemType.IPresentation>, IFactory<IPlaylistItem.Types.IItemType.ICue>, IFactory<IPlaylistItem.Types.IItemType.IPlanningCenter>, IFactory<IPlaylistItem.Types.IItemType.IPlaceholder>, IFactory<IPresentation.Types.ITimeline.Types.ICue.Types.ITriggerInfo.ICueId>, IFactory<IPresentation.Types.ITimeline.Types.ICue.Types.ITriggerInfo.IAction>, IFactory<IPresentation.Types.ISlideShow.ISlideShowDuration>, IFactory<IProPresenterScreen.Types.IArrangement.IArrangementSingle>, IFactory<IProPresenterScreen.Types.IArrangement.IArrangementCombined>, IFactory<IProPresenterScreen.Types.IArrangement.IArrangementEdgeBlend>, IFactory<IProPresenterScreen.Types.IRenderingEnabledOptional.IRenderingEnabled>, IFactory<IRecording.Types.IStream.Types.IDestination.Types.IDestination.IDisk>, IFactory<IRecording.Types.IStream.Types.IDestination.Types.IDestination.IRtmp>, IFactory<IRecording.Types.IStream.Types.IDestination.Types.IDestination.IResi>, IFactory<IRecording.Types.IStream.Types.ISource.IOutputScreen>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.ICaptureStatusText.Types.ITextType.IStatusText>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.ICaptureStatusText.Types.ITextType.IElapsedTime>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerText.Types.ITextType.IName>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerText.Types.ITextType.ITime>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.ITicker.Types.ISourceType.ITextType>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.ITicker.Types.ISourceType.IRssType>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.ITicker.Types.ISourceType.IFileType>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IConditionType.IElementVisibility>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IConditionType.ITimerVisibility>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IConditionType.IVideoCountdownVisibility>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IConditionType.ICaptureSessionVisibility>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IConditionType.IVideoInputVisibility>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IConditionType.IAudioCountdownVisibility>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ITicker>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IAlternateText>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ITimerText>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IClockText>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IChordChart>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IOutputScreen>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IPcoLive>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IAlternateFill>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IVisibilityLink>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ISlideText>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IStageMessage>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IVideoCountdown>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ISlideImage>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ICcliText>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IGroupName>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IGroupColor>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IPresentationNotes>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IPlaylistItem>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IAutoAdvanceTimeRemaining>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ICaptureStatusText>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ICaptureStatusColor>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ISlideCount>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IAudioCountdown>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IPresentation>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ISlideLabelText>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ISlideLabelColor>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IRssFeed>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IFileFeed>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IChordProChart>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IPlaybackMarkerText>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IPlaybackMarkerColor>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ITimecodeText>, IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ITimecodeStatus>, IFactory<ITestPatternDefinition.Types.IProperty.Types.IPropertyType.IColorProperty>, IFactory<ITestPatternDefinition.Types.IProperty.Types.IPropertyType.IDoubleProperty>, IFactory<ITestPatternDefinition.Types.IProperty.Types.IPropertyType.IIntProperty>, IFactory<ITestPatternDefinition.Types.IProperty.Types.IPropertyType.IBoolProperty>, IFactory<ITestPatternDefinition.Types.IProperty.Types.IPropertyType.IStringProperty>, IFactory<ITestPatternDefinition.Types.IProperty.Types.IPropertyType.IFontProperty>, IFactory<ITestPatternDefinition.Types.IProperty.Types.IPropertyType.ISelectorProperty>, IFactory<ITestPatternDocument.Types.ITestPatternData.Types.IProperty.Types.IPropertyType.IColorProperty>, IFactory<ITestPatternDocument.Types.ITestPatternData.Types.IProperty.Types.IPropertyType.IDoubleProperty>, IFactory<ITestPatternDocument.Types.ITestPatternData.Types.IProperty.Types.IPropertyType.IIntProperty>, IFactory<ITestPatternDocument.Types.ITestPatternData.Types.IProperty.Types.IPropertyType.IBoolProperty>, IFactory<ITestPatternDocument.Types.ITestPatternData.Types.IProperty.Types.IPropertyType.IStringProperty>, IFactory<ITestPatternDocument.Types.ITestPatternData.Types.IProperty.Types.IPropertyType.IFontProperty>, IFactory<ITestPatternDocument.Types.ITestPatternData.Types.IProperty.Types.IPropertyType.ISelectorProperty>, IFactory<ITimer.Types.IConfiguration.Types.ITimerType.ICountdown>, IFactory<ITimer.Types.IConfiguration.Types.ITimerType.ICountdownToTime>, IFactory<ITimer.Types.IConfiguration.Types.ITimerType.IElapsedTime>, IFactory<IVideoInput.Types.IAltAudioSource.IAudioDevice>, IFactory<IVideoInput.Types.IAltAudioSource.IVideoDevice>, IAtomicValuesFactory, IAtomicValueFactory<IAction.Types.ClearType>, IAtomicValueFactory<Color>, IAtomicValueFactory<ICopyrightLayout.Types.Token>, IAtomicValueFactory<Font>, IAtomicValueFactory<IGraphics.Types.IPath.Types.Shape.Types.Arrow>, IAtomicValueFactory<IGraphics.Types.IPath.Types.Shape.Types.Polygon>, IAtomicValueFactory<IGraphics.Types.IPath.Types.Shape.Types.RoundedRectangle>, IAtomicValueFactory<IGraphics.Types.IPath.Types.Shape.Types.Star>, IAtomicValueFactory<IGraphics.Types.IPath.Types.Shape>, IAtomicValueFactory<IGraphics.Types.Point>, IAtomicValueFactory<IGraphics.Types.Rect>, IAtomicValueFactory<IGraphics.Types.Size>, IAtomicValueFactory<IntRange>, IAtomicValueFactory<Timestamp>, IAtomicValueFactory<Url.Types.ExternalRelativePath.Types.MacOsExternalVolume>, IAtomicValueFactory<Url.Types.ExternalRelativePath.Types.Win32ExternalVolume>, IAtomicValueFactory<Url.Types.ExternalRelativePath>, IAtomicValueFactory<Url.Types.LocalRelativePath>, IAtomicValueFactory<Url>, IValuesFactory, IValueFactory<IAction.Types.IAudienceLookType>, IValueFactory<IAction.Types.IAudioInputType>, IValueFactory<IAction.Types.ICaptureType.Types.ICaptureStart>, IValueFactory<IAction.Types.ICaptureType.Types.ICaptureStop>, IValueFactory<IAction.Types.ICaptureType>, IValueFactory<IAction.Types.IClearGroupType>, IValueFactory<IAction.Types.ICommunicationType.Types.ICommand>, IValueFactory<IAction.Types.ICommunicationType.Types.IMidiCommand>, IValueFactory<IAction.Types.ICommunicationType>, IValueFactory<IAction.Types.IDocumentType>, IValueFactory<IAction.Types.IExternalPresentationType>, IValueFactory<IAction.Types.ILabel>, IValueFactory<IAction.Types.IMacroType>, IValueFactory<IAction.Types.IMaskType>, IValueFactory<IAction.Types.IMediaType.Types.IAudio>, IValueFactory<IAction.Types.IMediaType.Types.IPlaybackMarker>, IValueFactory<IAction.Types.IMediaType>, IValueFactory<IAction.Types.IMessageType>, IValueFactory<IAction.Types.IMultiScreenType>, IValueFactory<IAction.Types.IPlaylistItemType>, IValueFactory<IAction.Types.IPropType.Types.IPropClear>, IValueFactory<IAction.Types.IPropType.Types.IPropTrigger>, IValueFactory<IAction.Types.IPropType>, IValueFactory<IAction.Types.ISlideDestinationType>, IValueFactory<IAction.Types.ISlideType>, IValueFactory<IAction.Types.IStageLayoutType>, IValueFactory<IAction.Types.ITimerType>, IValueFactory<IAction.Types.ITransportControlType.Types.IJumpToTime>, IValueFactory<IAction.Types.ITransportControlType.Types.IPause>, IValueFactory<IAction.Types.ITransportControlType.Types.IPlay>, IValueFactory<IAction.Types.ITransportControlType>, IValueFactory<IAction>, IValueFactory<IAlignmentGuide>, IValueFactory<IAudio.Types.IDevice.Types.IFormat>, IValueFactory<IAudio.Types.IDevice>, IValueFactory<IAudio.Types.ILogicalChannel.Types.IOutputChannel>, IValueFactory<IAudio.Types.ILogicalChannel>, IValueFactory<IAudio.Types.IOutputSetup>, IValueFactory<IAudio.Types.IPhysicalChannel>, IValueFactory<IAudio.Types.ISettingsDocument>, IValueFactory<IAudio>, IValueFactory<IAudioInput.Types.IBehaviorMode.Types.IAutoOff>, IValueFactory<IAudioInput.Types.IBehaviorMode.Types.IAutoOn>, IValueFactory<IAudioInput.Types.IBehaviorMode.Types.IOff>, IValueFactory<IAudioInput.Types.IBehaviorMode.Types.IOn>, IValueFactory<IAudioInput.Types.IBehaviorMode>, IValueFactory<IAudioInput>, IValueFactory<IBackground>, IValueFactory<ICcliDocument>, IValueFactory<ICalendar.Types.IEvent.Types.IAction.Types.IMacro>, IValueFactory<ICalendar.Types.IEvent.Types.IAction.Types.IPlaylist>, IValueFactory<ICalendar.Types.IEvent.Types.IAction>, IValueFactory<ICalendar.Types.IEvent>, IValueFactory<ICalendar>, IValueFactory<IClearGroupsDocument.Types.IClearGroup>, IValueFactory<IClearGroupsDocument>, IValueFactory<IClock.Types.IFormat>, IValueFactory<IClock>, IValueFactory<ICloudAudioInput>, IValueFactory<ICloudProPresenterScreen>, IValueFactory<ICloudVideoInput>, IValueFactory<ICollectionElementType>, IValueFactory<ICommunicationCommand.Types.IParameters>, IValueFactory<ICommunicationCommand>, IValueFactory<ICommunicationDevice.Types.IArtnetHardware>, IValueFactory<ICommunicationDevice.Types.IMidiHardware>, IValueFactory<ICommunicationDevice.Types.ISerialHardware>, IValueFactory<ICommunicationDevice.Types.ITcpHardware>, IValueFactory<ICommunicationDevice.Types.IUdpHardware>, IValueFactory<ICommunicationDevice>, IValueFactory<ICommunicationDeviceCloud>, IValueFactory<ICommunicationDeviceLocal>, IValueFactory<ICommunicationDeviceOption.Types.IOesProMode>, IValueFactory<ICommunicationDeviceOption>, IValueFactory<ICopyrightLayout>, IValueFactory<ICornerValues>, IValueFactory<ICue>, IValueFactory<IDigitalAudio.Types.IBus>, IValueFactory<IDigitalAudio.Types.IDevice.Types.IChannel>, IValueFactory<IDigitalAudio.Types.IDevice.Types.IFormat>, IValueFactory<IDigitalAudio.Types.IDevice.Types.IMap>, IValueFactory<IDigitalAudio.Types.IDevice.Types.IRouting>, IValueFactory<IDigitalAudio.Types.IDevice>, IValueFactory<IDigitalAudio.Types.ISetup>, IValueFactory<IDigitalAudio>, IValueFactory<IDisplayMode>, IValueFactory<IEdgeBlend.Types.IScreen>, IValueFactory<IEdgeBlend>, IValueFactory<IEffect.Types.IEffectVariable.Types.IEffectColor>, IValueFactory<IEffect.Types.IEffectVariable.Types.IEffectDirection>, IValueFactory<IEffect.Types.IEffectVariable.Types.IEffectDouble>, IValueFactory<IEffect.Types.IEffectVariable.Types.IEffectFloat>, IValueFactory<IEffect.Types.IEffectVariable.Types.IEffectInt>, IValueFactory<IEffect.Types.IEffectVariable>, IValueFactory<IEffect.Types.IPreset>, IValueFactory<IEffect>, IValueFactory<IFileProperties.Types.IRemoteProperties.Types.IProContent>, IValueFactory<IFileProperties.Types.IRemoteProperties>, IValueFactory<IFileProperties>, IValueFactory<IGraphics.Types.IBackgroundEffect.Types.IBackgroundEffectBlur>, IValueFactory<IGraphics.Types.IBackgroundEffect.Types.IBackgroundEffectInvert>, IValueFactory<IGraphics.Types.IBackgroundEffect>, IValueFactory<IGraphics.Types.IEdgeInsets>, IValueFactory<IGraphics.Types.IElement>, IValueFactory<IGraphics.Types.IFeather>, IValueFactory<IGraphics.Types.IFill>, IValueFactory<IGraphics.Types.IGradient.Types.IColorStop>, IValueFactory<IGraphics.Types.IGradient>, IValueFactory<IGraphics.Types.IPath.Types.IBezierPoint>, IValueFactory<IGraphics.Types.IPath>, IValueFactory<IGraphics.Types.IShadow>, IValueFactory<IGraphics.Types.IStroke>, IValueFactory<IGraphics.Types.IText.Types.IAlternateText>, IValueFactory<IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute>, IValueFactory<IGraphics.Types.IText.Types.IAttributes.Types.IParagraph.Types.ITabStop>, IValueFactory<IGraphics.Types.IText.Types.IAttributes.Types.IParagraph.Types.ITextList>, IValueFactory<IGraphics.Types.IText.Types.IAttributes.Types.IParagraph>, IValueFactory<IGraphics.Types.IText.Types.IAttributes.Types.IUnderline>, IValueFactory<IGraphics.Types.IText.Types.IAttributes>, IValueFactory<IGraphics.Types.IText.Types.IChordPro>, IValueFactory<IGraphics.Types.IText.Types.ICutOutFill>, IValueFactory<IGraphics.Types.IText.Types.IGradientFill>, IValueFactory<IGraphics.Types.IText.Types.ILineFillMask>, IValueFactory<IGraphics.Types.IText.Types.IMediaFill>, IValueFactory<IGraphics.Types.IText>, IValueFactory<IGraphics>, IValueFactory<IGroup>, IValueFactory<IHotKey>, IValueFactory<IKeyMapping.Types.IComputerKeyboard>, IValueFactory<IKeyMapping.Types.IMidiKeyboard>, IValueFactory<IKeyMapping>, IValueFactory<IKeyMappingDocument>, IValueFactory<ILayer.Types.IBlending.Types.IMatte.Types.IAlpha>, IValueFactory<ILayer.Types.IBlending.Types.IMatte.Types.ILuma>, IValueFactory<ILayer.Types.IBlending.Types.IMatte.Types.IWhite>, IValueFactory<ILayer.Types.IBlending.Types.IMatte>, IValueFactory<ILayer.Types.IBlending.Types.IStandard>, IValueFactory<ILayer.Types.IBlending>, IValueFactory<ILayer>, IValueFactory<ILibrary.Types.ILibraryArray>, IValueFactory<ILibrary.Types.ILibraryItems>, IValueFactory<ILibrary>, IValueFactory<ILibraryItem>, IValueFactory<ILocalMessage>, IValueFactory<ILocalTimer>, IValueFactory<IMacrosDocument.Types.IMacro>, IValueFactory<IMacrosDocument.Types.IMacroCollection>, IValueFactory<IMacrosDocument>, IValueFactory<IMedia.Types.IAudio.Types.IChannel.Types.IOutput>, IValueFactory<IMedia.Types.IAudio.Types.IChannel>, IValueFactory<IMedia.Types.IAudio>, IValueFactory<IMedia.Types.IAudioProperties>, IValueFactory<IMedia.Types.IAudioTypeProperties>, IValueFactory<IMedia.Types.IDrawingProperties>, IValueFactory<IMedia.Types.IImageTypeProperties>, IValueFactory<IMedia.Types.ILiveVideoProperties>, IValueFactory<IMedia.Types.ILiveVideoTypeProperties>, IValueFactory<IMedia.Types.IMetadata>, IValueFactory<IMedia.Types.ITransportProperties>, IValueFactory<IMedia.Types.IVideoDevice.Types.IAirCast>, IValueFactory<IMedia.Types.IVideoDevice>, IValueFactory<IMedia.Types.IVideoProperties>, IValueFactory<IMedia.Types.IVideoTypeProperties>, IValueFactory<IMedia.Types.IWebContentTypeProperties>, IValueFactory<IMedia>, IValueFactory<IMessage.Types.IToken.Types.ITokenTypeClock>, IValueFactory<IMessage.Types.IToken.Types.ITokenTypeText>, IValueFactory<IMessage.Types.IToken.Types.ITokenTypeTimer>, IValueFactory<IMessage.Types.IToken>, IValueFactory<IMessage.Types.ITokenValue.Types.ITokenValueClock>, IValueFactory<IMessage.Types.ITokenValue.Types.ITokenValueText>, IValueFactory<IMessage.Types.ITokenValue.Types.ITokenValueTimer>, IValueFactory<IMessage.Types.ITokenValue>, IValueFactory<IMessage>, IValueFactory<IMessageDocument>, IValueFactory<IMessageLocalDocument>, IValueFactory<IMusicKeyScale>, IValueFactory<IOutputDisplay.Types.IBlackmagic>, IValueFactory<IOutputDisplay>, IValueFactory<IPlanningCenterPlan.Types.IPlanItem.Types.IAttachment>, IValueFactory<IPlanningCenterPlan.Types.IPlanItem.Types.ISongItem.Types.ISequence>, IValueFactory<IPlanningCenterPlan.Types.IPlanItem.Types.ISongItem>, IValueFactory<IPlanningCenterPlan.Types.IPlanItem>, IValueFactory<IPlanningCenterPlan>, IValueFactory<IPlaylist.Types.IFolderDirectory>, IValueFactory<IPlaylist.Types.IPlaylistArray>, IValueFactory<IPlaylist.Types.IPlaylistItems>, IValueFactory<IPlaylist>, IValueFactory<IPlaylistDocument>, IValueFactory<IPlaylistItem.Types.IHeader>, IValueFactory<IPlaylistItem.Types.IPlaceholder>, IValueFactory<IPlaylistItem.Types.IPlanningCenter>, IValueFactory<IPlaylistItem.Types.IPresentation>, IValueFactory<IPlaylistItem>, IValueFactory<IPlaylistTemplate.Types.ITemplate>, IValueFactory<IPlaylistTemplate>, IValueFactory<IPresentation.Types.IArrangement>, IValueFactory<IPresentation.Types.IBibleReference>, IValueFactory<IPresentation.Types.ICcli>, IValueFactory<IPresentation.Types.ICueGroup>, IValueFactory<IPresentation.Types.IMultiTracksLicensing>, IValueFactory<IPresentation.Types.IMusic>, IValueFactory<IPresentation.Types.ITimeline.Types.ICue>, IValueFactory<IPresentation.Types.ITimeline>, IValueFactory<IPresentation>, IValueFactory<IPresentationSlide.Types.INotes>, IValueFactory<IPresentationSlide>, IValueFactory<IProAudienceLook.Types.IProScreenLook>, IValueFactory<IProAudienceLook>, IValueFactory<IProGroupsDocument>, IValueFactory<IProLabelsDocument>, IValueFactory<IProMask>, IValueFactory<IProPresenterCommunications>, IValueFactory<IProPresenterLocalCommunications>, IValueFactory<IProPresenterLocalWorkspace>, IValueFactory<IProPresenterScreen.Types.ICombinedArrangement>, IValueFactory<IProPresenterScreen.Types.IEdgeBlendArrangement>, IValueFactory<IProPresenterScreen.Types.ISingleArrangement>, IValueFactory<IProPresenterScreen>, IValueFactory<IProPresenterWorkspace>, IValueFactory<IPropDocument.Types.IPropCollection>, IValueFactory<IPropDocument>, IValueFactory<IPropSlide>, IValueFactory<IRecording.Types.IPreset>, IValueFactory<IRecording.Types.ISettingsDocument>, IValueFactory<IRecording.Types.IStream.Types.IDestination.Types.IResi>, IValueFactory<IRecording.Types.IStream.Types.IDestination>, IValueFactory<IRecording.Types.IStream.Types.IDiskDestination>, IValueFactory<IRecording.Types.IStream.Types.IEncoder>, IValueFactory<IRecording.Types.IStream.Types.IOutputScreenSource>, IValueFactory<IRecording.Types.IStream.Types.IRtmpDestination>, IValueFactory<IRecording.Types.IStream>, IValueFactory<IRecording>, IValueFactory<IScreen.Types.IAlphaSettings.Types.IAlphaDevice>, IValueFactory<IScreen.Types.IAlphaSettings>, IValueFactory<IScreen.Types.IBlendCompensation>, IValueFactory<IScreen.Types.IColorAdjustment>, IValueFactory<IScreen>, IValueFactory<ISlide.Types.IElement.Types.IBuild>, IValueFactory<ISlide.Types.IElement.Types.IChildBuild>, IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IAlternateElementFill>, IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IAlternateElementText>, IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IAudioCountdown>, IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IAutoAdvanceTimeRemaining>, IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.ICcliText>, IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.ICaptureStatusColor>, IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.ICaptureStatusText.Types.IElapsedTime>, IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.ICaptureStatusText.Types.IStatusText>, IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.ICaptureStatusText>, IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IChordChart>, IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IChordProChart>, IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IClockText>, IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IColorTrigger>, IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IFileFeed>, IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IGroupColor>, IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IGroupName>, IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IOutputScreen>, IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPcoLive>, IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerIdentifier>, IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerText.Types.IName>, IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerText.Types.ITime>, IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerText>, IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPlaylistItem>, IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPresentation>, IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPresentationNotes>, IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IRssFeed>, IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.ISlideCount>, IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.ISlideImage>, IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.ISlideLabelColor>, IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.ISlideLabelText>, IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.ISlideText>, IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IStageMessage>, IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.ITicker.Types.IFileType>, IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.ITicker.Types.IRssType>, IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.ITicker.Types.ITextType>, IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.ITicker>, IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.ITimecodeStatus>, IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.ITimecodeText>, IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.ITimerText>, IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IVideoCountdown>, IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IAudioCountdownVisibility>, IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ICaptureSessionVisibility>, IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IElementVisibility>, IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ITimerVisibility>, IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoCountdownVisibility>, IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoInputVisibility>, IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition>, IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink>, IValueFactory<ISlide.Types.IElement.Types.IDataLink>, IValueFactory<ISlide.Types.IElement.Types.ITextScroller>, IValueFactory<ISlide.Types.IElement>, IValueFactory<ISlide>, IValueFactory<IStage.Types.IDocument>, IValueFactory<IStage.Types.ILayout>, IValueFactory<IStage.Types.IScreenAssignment>, IValueFactory<IStage>, IValueFactory<ITemplate.Types.IDocument>, IValueFactory<ITemplate.Types.ISlide>, IValueFactory<ITemplate>, IValueFactory<ITemplateIdentification>, IValueFactory<ITestPattern.Types.IBlendGrid>, IValueFactory<ITestPattern.Types.ICustomColor>, IValueFactory<ITestPattern.Types.IIntensityColor>, IValueFactory<ITestPattern>, IValueFactory<ITestPatternDefinition.Types.IBoolProperty>, IValueFactory<ITestPatternDefinition.Types.IColorProperty>, IValueFactory<ITestPatternDefinition.Types.IDoubleProperty>, IValueFactory<ITestPatternDefinition.Types.IFontProperty>, IValueFactory<ITestPatternDefinition.Types.IIntProperty>, IValueFactory<ITestPatternDefinition.Types.IProperty>, IValueFactory<ITestPatternDefinition.Types.ISelectorProperty>, IValueFactory<ITestPatternDefinition.Types.IStringProperty>, IValueFactory<ITestPatternDefinition>, IValueFactory<ITestPatternDocument.Types.ITestPatternData.Types.IBoolProperty>, IValueFactory<ITestPatternDocument.Types.ITestPatternData.Types.IColorProperty>, IValueFactory<ITestPatternDocument.Types.ITestPatternData.Types.IDoubleProperty>, IValueFactory<ITestPatternDocument.Types.ITestPatternData.Types.IFontProperty>, IValueFactory<ITestPatternDocument.Types.ITestPatternData.Types.IIntProperty>, IValueFactory<ITestPatternDocument.Types.ITestPatternData.Types.IProperty>, IValueFactory<ITestPatternDocument.Types.ITestPatternData.Types.ISelectorProperty>, IValueFactory<ITestPatternDocument.Types.ITestPatternData.Types.IStringProperty>, IValueFactory<ITestPatternDocument.Types.ITestPatternData>, IValueFactory<ITestPatternDocument.Types.ITestPatternStateData>, IValueFactory<ITestPatternDocument>, IValueFactory<ITestPatternRenderSettings.Types.IOutput>, IValueFactory<ITestPatternRenderSettings>, IValueFactory<ITestPatternState>, IValueFactory<ITimer.Types.IConfiguration.Types.ITimerTypeCountdown>, IValueFactory<ITimer.Types.IConfiguration.Types.ITimerTypeCountdownToTime>, IValueFactory<ITimer.Types.IConfiguration.Types.ITimerTypeElapsedTime>, IValueFactory<ITimer.Types.IConfiguration>, IValueFactory<ITimer.Types.IFormat>, IValueFactory<ITimer>, IValueFactory<ITimersDocument>, IValueFactory<ITimersLocalDocument>, IValueFactory<ITransition.Types.IPreset>, IValueFactory<ITransition>, IValueFactory<IVideoInput>
{
	IAction.Types.IAudienceLookType IFactory<IAction.Types.IAudienceLookType>.CreateInstance()
	{
		return new IAction.Types.AudienceLookType();
	}

	IAction.Types.IAudioInputType IFactory<IAction.Types.IAudioInputType>.CreateInstance()
	{
		return new IAction.Types.AudioInputType();
	}

	IAction.Types.ICaptureType.Types.ICaptureStart IFactory<IAction.Types.ICaptureType.Types.ICaptureStart>.CreateInstance()
	{
		return new IAction.Types.ICaptureType.Types.CaptureStart();
	}

	IAction.Types.ICaptureType.Types.ICaptureStop IFactory<IAction.Types.ICaptureType.Types.ICaptureStop>.CreateInstance()
	{
		return new IAction.Types.ICaptureType.Types.CaptureStop();
	}

	IAction.Types.ICaptureType IFactory<IAction.Types.ICaptureType>.CreateInstance()
	{
		return new IAction.Types.CaptureType();
	}

	IAction.Types.IClearGroupType IFactory<IAction.Types.IClearGroupType>.CreateInstance()
	{
		return new IAction.Types.ClearGroupType();
	}

	IAction.Types.ClearType IFactory<IAction.Types.ClearType>.CreateInstance()
	{
		return IAction.Types.ClearTypeExtension.CreateDefault();
	}

	IAction.Types.ICommunicationType.Types.ICommand IFactory<IAction.Types.ICommunicationType.Types.ICommand>.CreateInstance()
	{
		return new IAction.Types.ICommunicationType.Types.Command();
	}

	IAction.Types.ICommunicationType.Types.IMidiCommand IFactory<IAction.Types.ICommunicationType.Types.IMidiCommand>.CreateInstance()
	{
		return new IAction.Types.ICommunicationType.Types.MidiCommand();
	}

	IAction.Types.ICommunicationType IFactory<IAction.Types.ICommunicationType>.CreateInstance()
	{
		return new IAction.Types.CommunicationType();
	}

	IAction.Types.IDocumentType IFactory<IAction.Types.IDocumentType>.CreateInstance()
	{
		return new IAction.Types.DocumentType();
	}

	IAction.Types.IExternalPresentationType IFactory<IAction.Types.IExternalPresentationType>.CreateInstance()
	{
		return new IAction.Types.ExternalPresentationType();
	}

	IAction.Types.ILabel IFactory<IAction.Types.ILabel>.CreateInstance()
	{
		return new IAction.Types.Label();
	}

	IAction.Types.IMacroType IFactory<IAction.Types.IMacroType>.CreateInstance()
	{
		return new IAction.Types.MacroType();
	}

	IAction.Types.IMaskType IFactory<IAction.Types.IMaskType>.CreateInstance()
	{
		return new IAction.Types.MaskType();
	}

	IAction.Types.IMediaType.Types.IAudio IFactory<IAction.Types.IMediaType.Types.IAudio>.CreateInstance()
	{
		return new IAction.Types.IMediaType.Types.Audio();
	}

	IAction.Types.IMediaType.Types.IPlaybackMarker IFactory<IAction.Types.IMediaType.Types.IPlaybackMarker>.CreateInstance()
	{
		return new IAction.Types.IMediaType.Types.PlaybackMarker();
	}

	IAction.Types.IMediaType IFactory<IAction.Types.IMediaType>.CreateInstance()
	{
		return new IAction.Types.MediaType();
	}

	IAction.Types.IMessageType IFactory<IAction.Types.IMessageType>.CreateInstance()
	{
		return new IAction.Types.MessageType();
	}

	IAction.Types.IMultiScreenType IFactory<IAction.Types.IMultiScreenType>.CreateInstance()
	{
		return new IAction.Types.MultiScreenType();
	}

	IAction.Types.IPlaylistItemType IFactory<IAction.Types.IPlaylistItemType>.CreateInstance()
	{
		return new IAction.Types.PlaylistItemType();
	}

	IAction.Types.IPropType.Types.IPropClear IFactory<IAction.Types.IPropType.Types.IPropClear>.CreateInstance()
	{
		return new IAction.Types.IPropType.Types.PropClear();
	}

	IAction.Types.IPropType.Types.IPropTrigger IFactory<IAction.Types.IPropType.Types.IPropTrigger>.CreateInstance()
	{
		return new IAction.Types.IPropType.Types.PropTrigger();
	}

	IAction.Types.IPropType IFactory<IAction.Types.IPropType>.CreateInstance()
	{
		return new IAction.Types.PropType();
	}

	IAction.Types.ISlideDestinationType IFactory<IAction.Types.ISlideDestinationType>.CreateInstance()
	{
		return new IAction.Types.SlideDestinationType();
	}

	IAction.Types.ISlideType IFactory<IAction.Types.ISlideType>.CreateInstance()
	{
		return new IAction.Types.SlideType();
	}

	IAction.Types.IStageLayoutType IFactory<IAction.Types.IStageLayoutType>.CreateInstance()
	{
		return new IAction.Types.StageLayoutType();
	}

	IAction.Types.ITimerType IFactory<IAction.Types.ITimerType>.CreateInstance()
	{
		return new IAction.Types.TimerType();
	}

	IAction.Types.ITransportControlType.Types.IJumpToTime IFactory<IAction.Types.ITransportControlType.Types.IJumpToTime>.CreateInstance()
	{
		return new IAction.Types.ITransportControlType.Types.JumpToTime();
	}

	IAction.Types.ITransportControlType.Types.IPause IFactory<IAction.Types.ITransportControlType.Types.IPause>.CreateInstance()
	{
		return new IAction.Types.ITransportControlType.Types.Pause();
	}

	IAction.Types.ITransportControlType.Types.IPlay IFactory<IAction.Types.ITransportControlType.Types.IPlay>.CreateInstance()
	{
		return new IAction.Types.ITransportControlType.Types.Play();
	}

	IAction.Types.ITransportControlType IFactory<IAction.Types.ITransportControlType>.CreateInstance()
	{
		return new IAction.Types.TransportControlType();
	}

	IAction IFactory<IAction>.CreateInstance()
	{
		return new Action();
	}

	IAlignmentGuide IFactory<IAlignmentGuide>.CreateInstance()
	{
		return new AlignmentGuide();
	}

	IAudio.Types.IDevice.Types.IFormat IFactory<IAudio.Types.IDevice.Types.IFormat>.CreateInstance()
	{
		return new IAudio.Types.IDevice.Types.Format();
	}

	IAudio.Types.IDevice IFactory<IAudio.Types.IDevice>.CreateInstance()
	{
		return new IAudio.Types.Device();
	}

	IAudio.Types.ILogicalChannel.Types.IOutputChannel IFactory<IAudio.Types.ILogicalChannel.Types.IOutputChannel>.CreateInstance()
	{
		return new IAudio.Types.ILogicalChannel.Types.OutputChannel();
	}

	IAudio.Types.ILogicalChannel IFactory<IAudio.Types.ILogicalChannel>.CreateInstance()
	{
		return new IAudio.Types.LogicalChannel();
	}

	IAudio.Types.IOutputSetup IFactory<IAudio.Types.IOutputSetup>.CreateInstance()
	{
		return new IAudio.Types.OutputSetup();
	}

	IAudio.Types.IPhysicalChannel IFactory<IAudio.Types.IPhysicalChannel>.CreateInstance()
	{
		return new IAudio.Types.PhysicalChannel();
	}

	IAudio.Types.ISettingsDocument IFactory<IAudio.Types.ISettingsDocument>.CreateInstance()
	{
		return new IAudio.Types.SettingsDocument();
	}

	IAudio IFactory<IAudio>.CreateInstance()
	{
		return new Audio();
	}

	IAudioInput.Types.IBehaviorMode.Types.IAutoOff IFactory<IAudioInput.Types.IBehaviorMode.Types.IAutoOff>.CreateInstance()
	{
		return new IAudioInput.Types.IBehaviorMode.Types.AutoOff();
	}

	IAudioInput.Types.IBehaviorMode.Types.IAutoOn IFactory<IAudioInput.Types.IBehaviorMode.Types.IAutoOn>.CreateInstance()
	{
		return new IAudioInput.Types.IBehaviorMode.Types.AutoOn();
	}

	IAudioInput.Types.IBehaviorMode.Types.IOff IFactory<IAudioInput.Types.IBehaviorMode.Types.IOff>.CreateInstance()
	{
		return new IAudioInput.Types.IBehaviorMode.Types.Off();
	}

	IAudioInput.Types.IBehaviorMode.Types.IOn IFactory<IAudioInput.Types.IBehaviorMode.Types.IOn>.CreateInstance()
	{
		return new IAudioInput.Types.IBehaviorMode.Types.On();
	}

	IAudioInput.Types.IBehaviorMode IFactory<IAudioInput.Types.IBehaviorMode>.CreateInstance()
	{
		return new IAudioInput.Types.BehaviorMode();
	}

	IAudioInput IFactory<IAudioInput>.CreateInstance()
	{
		return new AudioInput();
	}

	IBackground IFactory<IBackground>.CreateInstance()
	{
		return new Background();
	}

	ICcliDocument IFactory<ICcliDocument>.CreateInstance()
	{
		return new CcliDocument();
	}

	ICalendar.Types.IEvent.Types.IAction.Types.IMacro IFactory<ICalendar.Types.IEvent.Types.IAction.Types.IMacro>.CreateInstance()
	{
		return new ICalendar.Types.IEvent.Types.IAction.Types.Macro();
	}

	ICalendar.Types.IEvent.Types.IAction.Types.IPlaylist IFactory<ICalendar.Types.IEvent.Types.IAction.Types.IPlaylist>.CreateInstance()
	{
		return new ICalendar.Types.IEvent.Types.IAction.Types.Playlist();
	}

	ICalendar.Types.IEvent.Types.IAction IFactory<ICalendar.Types.IEvent.Types.IAction>.CreateInstance()
	{
		return new ICalendar.Types.IEvent.Types.Action();
	}

	ICalendar.Types.IEvent IFactory<ICalendar.Types.IEvent>.CreateInstance()
	{
		return new ICalendar.Types.Event();
	}

	ICalendar IFactory<ICalendar>.CreateInstance()
	{
		return new Calendar();
	}

	IClearGroupsDocument.Types.IClearGroup IFactory<IClearGroupsDocument.Types.IClearGroup>.CreateInstance()
	{
		return new IClearGroupsDocument.Types.ClearGroup();
	}

	IClearGroupsDocument IFactory<IClearGroupsDocument>.CreateInstance()
	{
		return new ClearGroupsDocument();
	}

	IClock.Types.IFormat IFactory<IClock.Types.IFormat>.CreateInstance()
	{
		return new IClock.Types.Format();
	}

	IClock IFactory<IClock>.CreateInstance()
	{
		return new Clock();
	}

	ICloudAudioInput IFactory<ICloudAudioInput>.CreateInstance()
	{
		return new CloudAudioInput();
	}

	ICloudProPresenterScreen IFactory<ICloudProPresenterScreen>.CreateInstance()
	{
		return new CloudProPresenterScreen();
	}

	ICloudVideoInput IFactory<ICloudVideoInput>.CreateInstance()
	{
		return new CloudVideoInput();
	}

	ICollectionElementType IFactory<ICollectionElementType>.CreateInstance()
	{
		return new CollectionElementType();
	}

	Color IFactory<Color>.CreateInstance()
	{
		return ColorExtension.CreateDefault();
	}

	ICommunicationCommand.Types.IParameters IFactory<ICommunicationCommand.Types.IParameters>.CreateInstance()
	{
		return new ICommunicationCommand.Types.Parameters();
	}

	ICommunicationCommand IFactory<ICommunicationCommand>.CreateInstance()
	{
		return new CommunicationCommand();
	}

	ICommunicationDevice.Types.IArtnetHardware IFactory<ICommunicationDevice.Types.IArtnetHardware>.CreateInstance()
	{
		return new ICommunicationDevice.Types.ArtnetHardware();
	}

	ICommunicationDevice.Types.IMidiHardware IFactory<ICommunicationDevice.Types.IMidiHardware>.CreateInstance()
	{
		return new ICommunicationDevice.Types.MidiHardware();
	}

	ICommunicationDevice.Types.ISerialHardware IFactory<ICommunicationDevice.Types.ISerialHardware>.CreateInstance()
	{
		return new ICommunicationDevice.Types.SerialHardware();
	}

	ICommunicationDevice.Types.ITcpHardware IFactory<ICommunicationDevice.Types.ITcpHardware>.CreateInstance()
	{
		return new ICommunicationDevice.Types.TcpHardware();
	}

	ICommunicationDevice.Types.IUdpHardware IFactory<ICommunicationDevice.Types.IUdpHardware>.CreateInstance()
	{
		return new ICommunicationDevice.Types.UdpHardware();
	}

	ICommunicationDevice IFactory<ICommunicationDevice>.CreateInstance()
	{
		return new CommunicationDevice();
	}

	ICommunicationDeviceCloud IFactory<ICommunicationDeviceCloud>.CreateInstance()
	{
		return new CommunicationDeviceCloud();
	}

	ICommunicationDeviceLocal IFactory<ICommunicationDeviceLocal>.CreateInstance()
	{
		return new CommunicationDeviceLocal();
	}

	ICommunicationDeviceOption.Types.IOesProMode IFactory<ICommunicationDeviceOption.Types.IOesProMode>.CreateInstance()
	{
		return new ICommunicationDeviceOption.Types.OesProMode();
	}

	ICommunicationDeviceOption IFactory<ICommunicationDeviceOption>.CreateInstance()
	{
		return new CommunicationDeviceOption();
	}

	ICopyrightLayout.Types.Token IFactory<ICopyrightLayout.Types.Token>.CreateInstance()
	{
		return ICopyrightLayout.Types.TokenExtension.CreateDefault();
	}

	ICopyrightLayout IFactory<ICopyrightLayout>.CreateInstance()
	{
		return new CopyrightLayout();
	}

	ICornerValues IFactory<ICornerValues>.CreateInstance()
	{
		return new CornerValues();
	}

	ICue IFactory<ICue>.CreateInstance()
	{
		return new Cue();
	}

	IDigitalAudio.Types.IBus IFactory<IDigitalAudio.Types.IBus>.CreateInstance()
	{
		return new IDigitalAudio.Types.Bus();
	}

	IDigitalAudio.Types.IDevice.Types.IChannel IFactory<IDigitalAudio.Types.IDevice.Types.IChannel>.CreateInstance()
	{
		return new IDigitalAudio.Types.IDevice.Types.Channel();
	}

	IDigitalAudio.Types.IDevice.Types.IFormat IFactory<IDigitalAudio.Types.IDevice.Types.IFormat>.CreateInstance()
	{
		return new IDigitalAudio.Types.IDevice.Types.Format();
	}

	IDigitalAudio.Types.IDevice.Types.IMap IFactory<IDigitalAudio.Types.IDevice.Types.IMap>.CreateInstance()
	{
		return new IDigitalAudio.Types.IDevice.Types.Map();
	}

	IDigitalAudio.Types.IDevice.Types.IRouting IFactory<IDigitalAudio.Types.IDevice.Types.IRouting>.CreateInstance()
	{
		return new IDigitalAudio.Types.IDevice.Types.Routing();
	}

	IDigitalAudio.Types.IDevice IFactory<IDigitalAudio.Types.IDevice>.CreateInstance()
	{
		return new IDigitalAudio.Types.Device();
	}

	IDigitalAudio.Types.ISetup IFactory<IDigitalAudio.Types.ISetup>.CreateInstance()
	{
		return new IDigitalAudio.Types.Setup();
	}

	IDigitalAudio IFactory<IDigitalAudio>.CreateInstance()
	{
		return new DigitalAudio();
	}

	IDisplayMode IFactory<IDisplayMode>.CreateInstance()
	{
		return new DisplayMode();
	}

	IEdgeBlend.Types.IScreen IFactory<IEdgeBlend.Types.IScreen>.CreateInstance()
	{
		return new IEdgeBlend.Types.Screen();
	}

	IEdgeBlend IFactory<IEdgeBlend>.CreateInstance()
	{
		return new EdgeBlend();
	}

	IEffect.Types.IEffectVariable.Types.IEffectColor IFactory<IEffect.Types.IEffectVariable.Types.IEffectColor>.CreateInstance()
	{
		return new IEffect.Types.IEffectVariable.Types.EffectColor();
	}

	IEffect.Types.IEffectVariable.Types.IEffectDirection IFactory<IEffect.Types.IEffectVariable.Types.IEffectDirection>.CreateInstance()
	{
		return new IEffect.Types.IEffectVariable.Types.EffectDirection();
	}

	IEffect.Types.IEffectVariable.Types.IEffectDouble IFactory<IEffect.Types.IEffectVariable.Types.IEffectDouble>.CreateInstance()
	{
		return new IEffect.Types.IEffectVariable.Types.EffectDouble();
	}

	IEffect.Types.IEffectVariable.Types.IEffectFloat IFactory<IEffect.Types.IEffectVariable.Types.IEffectFloat>.CreateInstance()
	{
		return new IEffect.Types.IEffectVariable.Types.EffectFloat();
	}

	IEffect.Types.IEffectVariable.Types.IEffectInt IFactory<IEffect.Types.IEffectVariable.Types.IEffectInt>.CreateInstance()
	{
		return new IEffect.Types.IEffectVariable.Types.EffectInt();
	}

	IEffect.Types.IEffectVariable IFactory<IEffect.Types.IEffectVariable>.CreateInstance()
	{
		return new IEffect.Types.EffectVariable();
	}

	IEffect.Types.IPreset IFactory<IEffect.Types.IPreset>.CreateInstance()
	{
		return new IEffect.Types.Preset();
	}

	IEffect IFactory<IEffect>.CreateInstance()
	{
		return new Effect();
	}

	IFileProperties.Types.IRemoteProperties.Types.IProContent IFactory<IFileProperties.Types.IRemoteProperties.Types.IProContent>.CreateInstance()
	{
		return new IFileProperties.Types.IRemoteProperties.Types.ProContent();
	}

	IFileProperties.Types.IRemoteProperties IFactory<IFileProperties.Types.IRemoteProperties>.CreateInstance()
	{
		return new IFileProperties.Types.RemoteProperties();
	}

	IFileProperties IFactory<IFileProperties>.CreateInstance()
	{
		return new FileProperties();
	}

	Font IFactory<Font>.CreateInstance()
	{
		return FontExtension.CreateDefault();
	}

	IGraphics.Types.IBackgroundEffect.Types.IBackgroundEffectBlur IFactory<IGraphics.Types.IBackgroundEffect.Types.IBackgroundEffectBlur>.CreateInstance()
	{
		return new IGraphics.Types.IBackgroundEffect.Types.BackgroundEffectBlur();
	}

	IGraphics.Types.IBackgroundEffect.Types.IBackgroundEffectInvert IFactory<IGraphics.Types.IBackgroundEffect.Types.IBackgroundEffectInvert>.CreateInstance()
	{
		return new IGraphics.Types.IBackgroundEffect.Types.BackgroundEffectInvert();
	}

	IGraphics.Types.IBackgroundEffect IFactory<IGraphics.Types.IBackgroundEffect>.CreateInstance()
	{
		return new IGraphics.Types.BackgroundEffect();
	}

	IGraphics.Types.IEdgeInsets IFactory<IGraphics.Types.IEdgeInsets>.CreateInstance()
	{
		return new IGraphics.Types.EdgeInsets();
	}

	IGraphics.Types.IElement IFactory<IGraphics.Types.IElement>.CreateInstance()
	{
		return new IGraphics.Types.Element();
	}

	IGraphics.Types.IFeather IFactory<IGraphics.Types.IFeather>.CreateInstance()
	{
		return new IGraphics.Types.Feather();
	}

	IGraphics.Types.IFill IFactory<IGraphics.Types.IFill>.CreateInstance()
	{
		return new IGraphics.Types.Fill();
	}

	IGraphics.Types.IGradient.Types.IColorStop IFactory<IGraphics.Types.IGradient.Types.IColorStop>.CreateInstance()
	{
		return new IGraphics.Types.IGradient.Types.ColorStop();
	}

	IGraphics.Types.IGradient IFactory<IGraphics.Types.IGradient>.CreateInstance()
	{
		return new IGraphics.Types.Gradient();
	}

	IGraphics.Types.IPath.Types.IBezierPoint IFactory<IGraphics.Types.IPath.Types.IBezierPoint>.CreateInstance()
	{
		return new IGraphics.Types.IPath.Types.BezierPoint();
	}

	IGraphics.Types.IPath.Types.Shape.Types.Arrow IFactory<IGraphics.Types.IPath.Types.Shape.Types.Arrow>.CreateInstance()
	{
		return IGraphics.Types.IPath.Types.Shape.Types.ArrowExtension.CreateDefault();
	}

	IGraphics.Types.IPath.Types.Shape.Types.Polygon IFactory<IGraphics.Types.IPath.Types.Shape.Types.Polygon>.CreateInstance()
	{
		return IGraphics.Types.IPath.Types.Shape.Types.PolygonExtension.CreateDefault();
	}

	IGraphics.Types.IPath.Types.Shape.Types.RoundedRectangle IFactory<IGraphics.Types.IPath.Types.Shape.Types.RoundedRectangle>.CreateInstance()
	{
		return IGraphics.Types.IPath.Types.Shape.Types.RoundedRectangleExtension.CreateDefault();
	}

	IGraphics.Types.IPath.Types.Shape.Types.Star IFactory<IGraphics.Types.IPath.Types.Shape.Types.Star>.CreateInstance()
	{
		return IGraphics.Types.IPath.Types.Shape.Types.StarExtension.CreateDefault();
	}

	IGraphics.Types.IPath.Types.Shape IFactory<IGraphics.Types.IPath.Types.Shape>.CreateInstance()
	{
		return IGraphics.Types.IPath.Types.ShapeExtension.CreateDefault();
	}

	IGraphics.Types.IPath IFactory<IGraphics.Types.IPath>.CreateInstance()
	{
		return new IGraphics.Types.Path();
	}

	IGraphics.Types.Point IFactory<IGraphics.Types.Point>.CreateInstance()
	{
		return IGraphics.Types.PointExtension.CreateDefault();
	}

	IGraphics.Types.Rect IFactory<IGraphics.Types.Rect>.CreateInstance()
	{
		return IGraphics.Types.RectExtension.CreateDefault();
	}

	IGraphics.Types.IShadow IFactory<IGraphics.Types.IShadow>.CreateInstance()
	{
		return new IGraphics.Types.Shadow();
	}

	IGraphics.Types.Size IFactory<IGraphics.Types.Size>.CreateInstance()
	{
		return IGraphics.Types.SizeExtension.CreateDefault();
	}

	IGraphics.Types.IStroke IFactory<IGraphics.Types.IStroke>.CreateInstance()
	{
		return new IGraphics.Types.Stroke();
	}

	IGraphics.Types.IText.Types.IAlternateText IFactory<IGraphics.Types.IText.Types.IAlternateText>.CreateInstance()
	{
		return new IGraphics.Types.IText.Types.AlternateText();
	}

	IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute IFactory<IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute>.CreateInstance()
	{
		return new IGraphics.Types.IText.Types.IAttributes.Types.CustomAttribute();
	}

	IGraphics.Types.IText.Types.IAttributes.Types.IParagraph.Types.ITabStop IFactory<IGraphics.Types.IText.Types.IAttributes.Types.IParagraph.Types.ITabStop>.CreateInstance()
	{
		return new IGraphics.Types.IText.Types.IAttributes.Types.IParagraph.Types.TabStop();
	}

	IGraphics.Types.IText.Types.IAttributes.Types.IParagraph.Types.ITextList IFactory<IGraphics.Types.IText.Types.IAttributes.Types.IParagraph.Types.ITextList>.CreateInstance()
	{
		return new IGraphics.Types.IText.Types.IAttributes.Types.IParagraph.Types.TextList();
	}

	IGraphics.Types.IText.Types.IAttributes.Types.IParagraph IFactory<IGraphics.Types.IText.Types.IAttributes.Types.IParagraph>.CreateInstance()
	{
		return new IGraphics.Types.IText.Types.IAttributes.Types.Paragraph();
	}

	IGraphics.Types.IText.Types.IAttributes.Types.IUnderline IFactory<IGraphics.Types.IText.Types.IAttributes.Types.IUnderline>.CreateInstance()
	{
		return new IGraphics.Types.IText.Types.IAttributes.Types.Underline();
	}

	IGraphics.Types.IText.Types.IAttributes IFactory<IGraphics.Types.IText.Types.IAttributes>.CreateInstance()
	{
		return new IGraphics.Types.IText.Types.Attributes();
	}

	IGraphics.Types.IText.Types.IChordPro IFactory<IGraphics.Types.IText.Types.IChordPro>.CreateInstance()
	{
		return new IGraphics.Types.IText.Types.ChordPro();
	}

	IGraphics.Types.IText.Types.ICutOutFill IFactory<IGraphics.Types.IText.Types.ICutOutFill>.CreateInstance()
	{
		return new IGraphics.Types.IText.Types.CutOutFill();
	}

	IGraphics.Types.IText.Types.IGradientFill IFactory<IGraphics.Types.IText.Types.IGradientFill>.CreateInstance()
	{
		return new IGraphics.Types.IText.Types.GradientFill();
	}

	IGraphics.Types.IText.Types.ILineFillMask IFactory<IGraphics.Types.IText.Types.ILineFillMask>.CreateInstance()
	{
		return new IGraphics.Types.IText.Types.LineFillMask();
	}

	IGraphics.Types.IText.Types.IMediaFill IFactory<IGraphics.Types.IText.Types.IMediaFill>.CreateInstance()
	{
		return new IGraphics.Types.IText.Types.MediaFill();
	}

	IGraphics.Types.IText IFactory<IGraphics.Types.IText>.CreateInstance()
	{
		return new IGraphics.Types.Text();
	}

	IGraphics IFactory<IGraphics>.CreateInstance()
	{
		return new Graphics();
	}

	IGroup IFactory<IGroup>.CreateInstance()
	{
		return new Group();
	}

	IHotKey IFactory<IHotKey>.CreateInstance()
	{
		return new HotKey();
	}

	IntRange IFactory<IntRange>.CreateInstance()
	{
		return IntRangeExtension.CreateDefault();
	}

	IKeyMapping.Types.IComputerKeyboard IFactory<IKeyMapping.Types.IComputerKeyboard>.CreateInstance()
	{
		return new IKeyMapping.Types.ComputerKeyboard();
	}

	IKeyMapping.Types.IMidiKeyboard IFactory<IKeyMapping.Types.IMidiKeyboard>.CreateInstance()
	{
		return new IKeyMapping.Types.MidiKeyboard();
	}

	IKeyMapping IFactory<IKeyMapping>.CreateInstance()
	{
		return new KeyMapping();
	}

	IKeyMappingDocument IFactory<IKeyMappingDocument>.CreateInstance()
	{
		return new KeyMappingDocument();
	}

	ILayer.Types.IBlending.Types.IMatte.Types.IAlpha IFactory<ILayer.Types.IBlending.Types.IMatte.Types.IAlpha>.CreateInstance()
	{
		return new ILayer.Types.IBlending.Types.IMatte.Types.Alpha();
	}

	ILayer.Types.IBlending.Types.IMatte.Types.ILuma IFactory<ILayer.Types.IBlending.Types.IMatte.Types.ILuma>.CreateInstance()
	{
		return new ILayer.Types.IBlending.Types.IMatte.Types.Luma();
	}

	ILayer.Types.IBlending.Types.IMatte.Types.IWhite IFactory<ILayer.Types.IBlending.Types.IMatte.Types.IWhite>.CreateInstance()
	{
		return new ILayer.Types.IBlending.Types.IMatte.Types.White();
	}

	ILayer.Types.IBlending.Types.IMatte IFactory<ILayer.Types.IBlending.Types.IMatte>.CreateInstance()
	{
		return new ILayer.Types.IBlending.Types.Matte();
	}

	ILayer.Types.IBlending.Types.IStandard IFactory<ILayer.Types.IBlending.Types.IStandard>.CreateInstance()
	{
		return new ILayer.Types.IBlending.Types.Standard();
	}

	ILayer.Types.IBlending IFactory<ILayer.Types.IBlending>.CreateInstance()
	{
		return new ILayer.Types.Blending();
	}

	ILayer IFactory<ILayer>.CreateInstance()
	{
		return new Layer();
	}

	ILibrary.Types.ILibraryArray IFactory<ILibrary.Types.ILibraryArray>.CreateInstance()
	{
		return new ILibrary.Types.LibraryArray();
	}

	ILibrary.Types.ILibraryItems IFactory<ILibrary.Types.ILibraryItems>.CreateInstance()
	{
		return new ILibrary.Types.LibraryItems();
	}

	ILibrary IFactory<ILibrary>.CreateInstance()
	{
		return new Library();
	}

	ILibraryItem IFactory<ILibraryItem>.CreateInstance()
	{
		return new LibraryItem();
	}

	ILocalMessage IFactory<ILocalMessage>.CreateInstance()
	{
		return new LocalMessage();
	}

	ILocalTimer IFactory<ILocalTimer>.CreateInstance()
	{
		return new LocalTimer();
	}

	IMacrosDocument.Types.IMacro IFactory<IMacrosDocument.Types.IMacro>.CreateInstance()
	{
		return new IMacrosDocument.Types.Macro();
	}

	IMacrosDocument.Types.IMacroCollection IFactory<IMacrosDocument.Types.IMacroCollection>.CreateInstance()
	{
		return new IMacrosDocument.Types.MacroCollection();
	}

	IMacrosDocument IFactory<IMacrosDocument>.CreateInstance()
	{
		return new MacrosDocument();
	}

	IMedia.Types.IAudio.Types.IChannel.Types.IOutput IFactory<IMedia.Types.IAudio.Types.IChannel.Types.IOutput>.CreateInstance()
	{
		return new IMedia.Types.IAudio.Types.IChannel.Types.Output();
	}

	IMedia.Types.IAudio.Types.IChannel IFactory<IMedia.Types.IAudio.Types.IChannel>.CreateInstance()
	{
		return new IMedia.Types.IAudio.Types.Channel();
	}

	IMedia.Types.IAudio IFactory<IMedia.Types.IAudio>.CreateInstance()
	{
		return new IMedia.Types.Audio();
	}

	IMedia.Types.IAudioProperties IFactory<IMedia.Types.IAudioProperties>.CreateInstance()
	{
		return new IMedia.Types.AudioProperties();
	}

	IMedia.Types.IAudioTypeProperties IFactory<IMedia.Types.IAudioTypeProperties>.CreateInstance()
	{
		return new IMedia.Types.AudioTypeProperties();
	}

	IMedia.Types.IDrawingProperties IFactory<IMedia.Types.IDrawingProperties>.CreateInstance()
	{
		return new IMedia.Types.DrawingProperties();
	}

	IMedia.Types.IImageTypeProperties IFactory<IMedia.Types.IImageTypeProperties>.CreateInstance()
	{
		return new IMedia.Types.ImageTypeProperties();
	}

	IMedia.Types.ILiveVideoProperties IFactory<IMedia.Types.ILiveVideoProperties>.CreateInstance()
	{
		return new IMedia.Types.LiveVideoProperties();
	}

	IMedia.Types.ILiveVideoTypeProperties IFactory<IMedia.Types.ILiveVideoTypeProperties>.CreateInstance()
	{
		return new IMedia.Types.LiveVideoTypeProperties();
	}

	IMedia.Types.IMetadata IFactory<IMedia.Types.IMetadata>.CreateInstance()
	{
		return new IMedia.Types.Metadata();
	}

	IMedia.Types.ITransportProperties IFactory<IMedia.Types.ITransportProperties>.CreateInstance()
	{
		return new IMedia.Types.TransportProperties();
	}

	IMedia.Types.IVideoDevice.Types.IAirCast IFactory<IMedia.Types.IVideoDevice.Types.IAirCast>.CreateInstance()
	{
		return new IMedia.Types.IVideoDevice.Types.AirCast();
	}

	IMedia.Types.IVideoDevice IFactory<IMedia.Types.IVideoDevice>.CreateInstance()
	{
		return new IMedia.Types.VideoDevice();
	}

	IMedia.Types.IVideoProperties IFactory<IMedia.Types.IVideoProperties>.CreateInstance()
	{
		return new IMedia.Types.VideoProperties();
	}

	IMedia.Types.IVideoTypeProperties IFactory<IMedia.Types.IVideoTypeProperties>.CreateInstance()
	{
		return new IMedia.Types.VideoTypeProperties();
	}

	IMedia.Types.IWebContentTypeProperties IFactory<IMedia.Types.IWebContentTypeProperties>.CreateInstance()
	{
		return new IMedia.Types.WebContentTypeProperties();
	}

	IMedia IFactory<IMedia>.CreateInstance()
	{
		return new Media();
	}

	IMessage.Types.IToken.Types.ITokenTypeClock IFactory<IMessage.Types.IToken.Types.ITokenTypeClock>.CreateInstance()
	{
		return new IMessage.Types.IToken.Types.TokenTypeClock();
	}

	IMessage.Types.IToken.Types.ITokenTypeText IFactory<IMessage.Types.IToken.Types.ITokenTypeText>.CreateInstance()
	{
		return new IMessage.Types.IToken.Types.TokenTypeText();
	}

	IMessage.Types.IToken.Types.ITokenTypeTimer IFactory<IMessage.Types.IToken.Types.ITokenTypeTimer>.CreateInstance()
	{
		return new IMessage.Types.IToken.Types.TokenTypeTimer();
	}

	IMessage.Types.IToken IFactory<IMessage.Types.IToken>.CreateInstance()
	{
		return new IMessage.Types.Token();
	}

	IMessage.Types.ITokenValue.Types.ITokenValueClock IFactory<IMessage.Types.ITokenValue.Types.ITokenValueClock>.CreateInstance()
	{
		return new IMessage.Types.ITokenValue.Types.TokenValueClock();
	}

	IMessage.Types.ITokenValue.Types.ITokenValueText IFactory<IMessage.Types.ITokenValue.Types.ITokenValueText>.CreateInstance()
	{
		return new IMessage.Types.ITokenValue.Types.TokenValueText();
	}

	IMessage.Types.ITokenValue.Types.ITokenValueTimer IFactory<IMessage.Types.ITokenValue.Types.ITokenValueTimer>.CreateInstance()
	{
		return new IMessage.Types.ITokenValue.Types.TokenValueTimer();
	}

	IMessage.Types.ITokenValue IFactory<IMessage.Types.ITokenValue>.CreateInstance()
	{
		return new IMessage.Types.TokenValue();
	}

	IMessage IFactory<IMessage>.CreateInstance()
	{
		return new Message();
	}

	IMessageDocument IFactory<IMessageDocument>.CreateInstance()
	{
		return new MessageDocument();
	}

	IMessageLocalDocument IFactory<IMessageLocalDocument>.CreateInstance()
	{
		return new MessageLocalDocument();
	}

	IMusicKeyScale IFactory<IMusicKeyScale>.CreateInstance()
	{
		return new MusicKeyScale();
	}

	IOutputDisplay.Types.IBlackmagic IFactory<IOutputDisplay.Types.IBlackmagic>.CreateInstance()
	{
		return new IOutputDisplay.Types.Blackmagic();
	}

	IOutputDisplay IFactory<IOutputDisplay>.CreateInstance()
	{
		return new OutputDisplay();
	}

	IPlanningCenterPlan.Types.IPlanItem.Types.IAttachment IFactory<IPlanningCenterPlan.Types.IPlanItem.Types.IAttachment>.CreateInstance()
	{
		return new IPlanningCenterPlan.Types.IPlanItem.Types.Attachment();
	}

	IPlanningCenterPlan.Types.IPlanItem.Types.ISongItem.Types.ISequence IFactory<IPlanningCenterPlan.Types.IPlanItem.Types.ISongItem.Types.ISequence>.CreateInstance()
	{
		return new IPlanningCenterPlan.Types.IPlanItem.Types.ISongItem.Types.Sequence();
	}

	IPlanningCenterPlan.Types.IPlanItem.Types.ISongItem IFactory<IPlanningCenterPlan.Types.IPlanItem.Types.ISongItem>.CreateInstance()
	{
		return new IPlanningCenterPlan.Types.IPlanItem.Types.SongItem();
	}

	IPlanningCenterPlan.Types.IPlanItem IFactory<IPlanningCenterPlan.Types.IPlanItem>.CreateInstance()
	{
		return new IPlanningCenterPlan.Types.PlanItem();
	}

	IPlanningCenterPlan IFactory<IPlanningCenterPlan>.CreateInstance()
	{
		return new PlanningCenterPlan();
	}

	IPlaylist.Types.IFolderDirectory IFactory<IPlaylist.Types.IFolderDirectory>.CreateInstance()
	{
		return new IPlaylist.Types.FolderDirectory();
	}

	IPlaylist.Types.IPlaylistArray IFactory<IPlaylist.Types.IPlaylistArray>.CreateInstance()
	{
		return new IPlaylist.Types.PlaylistArray();
	}

	IPlaylist.Types.IPlaylistItems IFactory<IPlaylist.Types.IPlaylistItems>.CreateInstance()
	{
		return new IPlaylist.Types.PlaylistItems();
	}

	IPlaylist IFactory<IPlaylist>.CreateInstance()
	{
		return new Playlist();
	}

	IPlaylistDocument IFactory<IPlaylistDocument>.CreateInstance()
	{
		return new PlaylistDocument();
	}

	IPlaylistItem.Types.IHeader IFactory<IPlaylistItem.Types.IHeader>.CreateInstance()
	{
		return new IPlaylistItem.Types.Header();
	}

	IPlaylistItem.Types.IPlaceholder IFactory<IPlaylistItem.Types.IPlaceholder>.CreateInstance()
	{
		return new IPlaylistItem.Types.Placeholder();
	}

	IPlaylistItem.Types.IPlanningCenter IFactory<IPlaylistItem.Types.IPlanningCenter>.CreateInstance()
	{
		return new IPlaylistItem.Types.PlanningCenter();
	}

	IPlaylistItem.Types.IPresentation IFactory<IPlaylistItem.Types.IPresentation>.CreateInstance()
	{
		return new IPlaylistItem.Types.Presentation();
	}

	IPlaylistItem IFactory<IPlaylistItem>.CreateInstance()
	{
		return new PlaylistItem();
	}

	IPlaylistTemplate.Types.ITemplate IFactory<IPlaylistTemplate.Types.ITemplate>.CreateInstance()
	{
		return new IPlaylistTemplate.Types.Template();
	}

	IPlaylistTemplate IFactory<IPlaylistTemplate>.CreateInstance()
	{
		return new PlaylistTemplate();
	}

	IPresentation.Types.IArrangement IFactory<IPresentation.Types.IArrangement>.CreateInstance()
	{
		return new IPresentation.Types.Arrangement();
	}

	IPresentation.Types.IBibleReference IFactory<IPresentation.Types.IBibleReference>.CreateInstance()
	{
		return new IPresentation.Types.BibleReference();
	}

	IPresentation.Types.ICcli IFactory<IPresentation.Types.ICcli>.CreateInstance()
	{
		return new IPresentation.Types.Ccli();
	}

	IPresentation.Types.ICueGroup IFactory<IPresentation.Types.ICueGroup>.CreateInstance()
	{
		return new IPresentation.Types.CueGroup();
	}

	IPresentation.Types.IMultiTracksLicensing IFactory<IPresentation.Types.IMultiTracksLicensing>.CreateInstance()
	{
		return new IPresentation.Types.MultiTracksLicensing();
	}

	IPresentation.Types.IMusic IFactory<IPresentation.Types.IMusic>.CreateInstance()
	{
		return new IPresentation.Types.Music();
	}

	IPresentation.Types.ITimeline.Types.ICue IFactory<IPresentation.Types.ITimeline.Types.ICue>.CreateInstance()
	{
		return new IPresentation.Types.ITimeline.Types.Cue();
	}

	IPresentation.Types.ITimeline IFactory<IPresentation.Types.ITimeline>.CreateInstance()
	{
		return new IPresentation.Types.Timeline();
	}

	IPresentation IFactory<IPresentation>.CreateInstance()
	{
		return new Presentation();
	}

	IPresentationSlide.Types.INotes IFactory<IPresentationSlide.Types.INotes>.CreateInstance()
	{
		return new IPresentationSlide.Types.Notes();
	}

	IPresentationSlide IFactory<IPresentationSlide>.CreateInstance()
	{
		return new PresentationSlide();
	}

	IProAudienceLook.Types.IProScreenLook IFactory<IProAudienceLook.Types.IProScreenLook>.CreateInstance()
	{
		return new IProAudienceLook.Types.ProScreenLook();
	}

	IProAudienceLook IFactory<IProAudienceLook>.CreateInstance()
	{
		return new ProAudienceLook();
	}

	IProGroupsDocument IFactory<IProGroupsDocument>.CreateInstance()
	{
		return new ProGroupsDocument();
	}

	IProLabelsDocument IFactory<IProLabelsDocument>.CreateInstance()
	{
		return new ProLabelsDocument();
	}

	IProMask IFactory<IProMask>.CreateInstance()
	{
		return new ProMask();
	}

	IProPresenterCommunications IFactory<IProPresenterCommunications>.CreateInstance()
	{
		return new ProPresenterCommunications();
	}

	IProPresenterLocalCommunications IFactory<IProPresenterLocalCommunications>.CreateInstance()
	{
		return new ProPresenterLocalCommunications();
	}

	IProPresenterLocalWorkspace IFactory<IProPresenterLocalWorkspace>.CreateInstance()
	{
		return new ProPresenterLocalWorkspace();
	}

	IProPresenterScreen.Types.ICombinedArrangement IFactory<IProPresenterScreen.Types.ICombinedArrangement>.CreateInstance()
	{
		return new IProPresenterScreen.Types.CombinedArrangement();
	}

	IProPresenterScreen.Types.IEdgeBlendArrangement IFactory<IProPresenterScreen.Types.IEdgeBlendArrangement>.CreateInstance()
	{
		return new IProPresenterScreen.Types.EdgeBlendArrangement();
	}

	IProPresenterScreen.Types.ISingleArrangement IFactory<IProPresenterScreen.Types.ISingleArrangement>.CreateInstance()
	{
		return new IProPresenterScreen.Types.SingleArrangement();
	}

	IProPresenterScreen IFactory<IProPresenterScreen>.CreateInstance()
	{
		return new ProPresenterScreen();
	}

	IProPresenterWorkspace IFactory<IProPresenterWorkspace>.CreateInstance()
	{
		return new ProPresenterWorkspace();
	}

	IPropDocument.Types.IPropCollection IFactory<IPropDocument.Types.IPropCollection>.CreateInstance()
	{
		return new IPropDocument.Types.PropCollection();
	}

	IPropDocument IFactory<IPropDocument>.CreateInstance()
	{
		return new PropDocument();
	}

	IPropSlide IFactory<IPropSlide>.CreateInstance()
	{
		return new PropSlide();
	}

	IRecording.Types.IPreset IFactory<IRecording.Types.IPreset>.CreateInstance()
	{
		return new IRecording.Types.Preset();
	}

	IRecording.Types.ISettingsDocument IFactory<IRecording.Types.ISettingsDocument>.CreateInstance()
	{
		return new IRecording.Types.SettingsDocument();
	}

	IRecording.Types.IStream.Types.IDestination.Types.IResi IFactory<IRecording.Types.IStream.Types.IDestination.Types.IResi>.CreateInstance()
	{
		return new IRecording.Types.IStream.Types.IDestination.Types.Resi();
	}

	IRecording.Types.IStream.Types.IDestination IFactory<IRecording.Types.IStream.Types.IDestination>.CreateInstance()
	{
		return new IRecording.Types.IStream.Types.Destination();
	}

	IRecording.Types.IStream.Types.IDiskDestination IFactory<IRecording.Types.IStream.Types.IDiskDestination>.CreateInstance()
	{
		return new IRecording.Types.IStream.Types.DiskDestination();
	}

	IRecording.Types.IStream.Types.IEncoder IFactory<IRecording.Types.IStream.Types.IEncoder>.CreateInstance()
	{
		return new IRecording.Types.IStream.Types.Encoder();
	}

	IRecording.Types.IStream.Types.IOutputScreenSource IFactory<IRecording.Types.IStream.Types.IOutputScreenSource>.CreateInstance()
	{
		return new IRecording.Types.IStream.Types.OutputScreenSource();
	}

	IRecording.Types.IStream.Types.IRtmpDestination IFactory<IRecording.Types.IStream.Types.IRtmpDestination>.CreateInstance()
	{
		return new IRecording.Types.IStream.Types.RtmpDestination();
	}

	IRecording.Types.IStream IFactory<IRecording.Types.IStream>.CreateInstance()
	{
		return new IRecording.Types.Stream();
	}

	IRecording IFactory<IRecording>.CreateInstance()
	{
		return new Recording();
	}

	IScreen.Types.IAlphaSettings.Types.IAlphaDevice IFactory<IScreen.Types.IAlphaSettings.Types.IAlphaDevice>.CreateInstance()
	{
		return new IScreen.Types.IAlphaSettings.Types.AlphaDevice();
	}

	IScreen.Types.IAlphaSettings IFactory<IScreen.Types.IAlphaSettings>.CreateInstance()
	{
		return new IScreen.Types.AlphaSettings();
	}

	IScreen.Types.IBlendCompensation IFactory<IScreen.Types.IBlendCompensation>.CreateInstance()
	{
		return new IScreen.Types.BlendCompensation();
	}

	IScreen.Types.IColorAdjustment IFactory<IScreen.Types.IColorAdjustment>.CreateInstance()
	{
		return new IScreen.Types.ColorAdjustment();
	}

	IScreen IFactory<IScreen>.CreateInstance()
	{
		return new Screen();
	}

	ISlide.Types.IElement.Types.IBuild IFactory<ISlide.Types.IElement.Types.IBuild>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.Build();
	}

	ISlide.Types.IElement.Types.IChildBuild IFactory<ISlide.Types.IElement.Types.IChildBuild>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.ChildBuild();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IAlternateElementFill IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IAlternateElementFill>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.AlternateElementFill();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IAlternateElementText IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IAlternateElementText>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.AlternateElementText();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IAudioCountdown IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IAudioCountdown>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.AudioCountdown();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IAutoAdvanceTimeRemaining IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IAutoAdvanceTimeRemaining>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.AutoAdvanceTimeRemaining();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.ICcliText IFactory<ISlide.Types.IElement.Types.IDataLink.Types.ICcliText>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.CcliText();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.ICaptureStatusColor IFactory<ISlide.Types.IElement.Types.IDataLink.Types.ICaptureStatusColor>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.CaptureStatusColor();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.ICaptureStatusText.Types.IElapsedTime IFactory<ISlide.Types.IElement.Types.IDataLink.Types.ICaptureStatusText.Types.IElapsedTime>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.ICaptureStatusText.Types.ElapsedTime();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.ICaptureStatusText.Types.IStatusText IFactory<ISlide.Types.IElement.Types.IDataLink.Types.ICaptureStatusText.Types.IStatusText>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.ICaptureStatusText.Types.StatusText();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.ICaptureStatusText IFactory<ISlide.Types.IElement.Types.IDataLink.Types.ICaptureStatusText>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.CaptureStatusText();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IChordChart IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IChordChart>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.ChordChart();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IChordProChart IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IChordProChart>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.ChordProChart();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IClockText IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IClockText>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.ClockText();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IColorTrigger IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IColorTrigger>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.ColorTrigger();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IFileFeed IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IFileFeed>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.FileFeed();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IGroupColor IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IGroupColor>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.GroupColor();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IGroupName IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IGroupName>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.GroupName();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IOutputScreen IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IOutputScreen>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.OutputScreen();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IPcoLive IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPcoLive>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.PcoLive();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerIdentifier IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerIdentifier>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.PlaybackMarkerIdentifier();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerText.Types.IName IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerText.Types.IName>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerText.Types.Name();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerText.Types.ITime IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerText.Types.ITime>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerText.Types.Time();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerText IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerText>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.PlaybackMarkerText();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IPlaylistItem IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPlaylistItem>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.PlaylistItem();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IPresentation IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPresentation>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.Presentation();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IPresentationNotes IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPresentationNotes>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.PresentationNotes();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IRssFeed IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IRssFeed>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.RssFeed();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.ISlideCount IFactory<ISlide.Types.IElement.Types.IDataLink.Types.ISlideCount>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.SlideCount();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.ISlideImage IFactory<ISlide.Types.IElement.Types.IDataLink.Types.ISlideImage>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.SlideImage();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.ISlideLabelColor IFactory<ISlide.Types.IElement.Types.IDataLink.Types.ISlideLabelColor>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.SlideLabelColor();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.ISlideLabelText IFactory<ISlide.Types.IElement.Types.IDataLink.Types.ISlideLabelText>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.SlideLabelText();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.ISlideText IFactory<ISlide.Types.IElement.Types.IDataLink.Types.ISlideText>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.SlideText();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IStageMessage IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IStageMessage>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.StageMessage();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.ITicker.Types.IFileType IFactory<ISlide.Types.IElement.Types.IDataLink.Types.ITicker.Types.IFileType>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.ITicker.Types.FileType();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.ITicker.Types.IRssType IFactory<ISlide.Types.IElement.Types.IDataLink.Types.ITicker.Types.IRssType>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.ITicker.Types.RssType();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.ITicker.Types.ITextType IFactory<ISlide.Types.IElement.Types.IDataLink.Types.ITicker.Types.ITextType>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.ITicker.Types.TextType();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.ITicker IFactory<ISlide.Types.IElement.Types.IDataLink.Types.ITicker>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.Ticker();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.ITimecodeStatus IFactory<ISlide.Types.IElement.Types.IDataLink.Types.ITimecodeStatus>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.TimecodeStatus();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.ITimecodeText IFactory<ISlide.Types.IElement.Types.IDataLink.Types.ITimecodeText>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.TimecodeText();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.ITimerText IFactory<ISlide.Types.IElement.Types.IDataLink.Types.ITimerText>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.TimerText();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IVideoCountdown IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IVideoCountdown>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.VideoCountdown();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IAudioCountdownVisibility IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IAudioCountdownVisibility>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.AudioCountdownVisibility();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ICaptureSessionVisibility IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ICaptureSessionVisibility>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.CaptureSessionVisibility();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IElementVisibility IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IElementVisibility>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ElementVisibility();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ITimerVisibility IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ITimerVisibility>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.TimerVisibility();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoCountdownVisibility IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoCountdownVisibility>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.VideoCountdownVisibility();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoInputVisibility IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoInputVisibility>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.VideoInputVisibility();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.Condition();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.VisibilityLink();
	}

	ISlide.Types.IElement.Types.IDataLink IFactory<ISlide.Types.IElement.Types.IDataLink>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.DataLink();
	}

	ISlide.Types.IElement.Types.ITextScroller IFactory<ISlide.Types.IElement.Types.ITextScroller>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.TextScroller();
	}

	ISlide.Types.IElement IFactory<ISlide.Types.IElement>.CreateInstance()
	{
		return new ISlide.Types.Element();
	}

	ISlide IFactory<ISlide>.CreateInstance()
	{
		return new Slide();
	}

	IStage.Types.IDocument IFactory<IStage.Types.IDocument>.CreateInstance()
	{
		return new IStage.Types.Document();
	}

	IStage.Types.ILayout IFactory<IStage.Types.ILayout>.CreateInstance()
	{
		return new IStage.Types.Layout();
	}

	IStage.Types.IScreenAssignment IFactory<IStage.Types.IScreenAssignment>.CreateInstance()
	{
		return new IStage.Types.ScreenAssignment();
	}

	IStage IFactory<IStage>.CreateInstance()
	{
		return new Stage();
	}

	ITemplate.Types.IDocument IFactory<ITemplate.Types.IDocument>.CreateInstance()
	{
		return new ITemplate.Types.Document();
	}

	ITemplate.Types.ISlide IFactory<ITemplate.Types.ISlide>.CreateInstance()
	{
		return new ITemplate.Types.Slide();
	}

	ITemplate IFactory<ITemplate>.CreateInstance()
	{
		return new Template();
	}

	ITemplateIdentification IFactory<ITemplateIdentification>.CreateInstance()
	{
		return new TemplateIdentification();
	}

	ITestPattern.Types.IBlendGrid IFactory<ITestPattern.Types.IBlendGrid>.CreateInstance()
	{
		return new ITestPattern.Types.BlendGrid();
	}

	ITestPattern.Types.ICustomColor IFactory<ITestPattern.Types.ICustomColor>.CreateInstance()
	{
		return new ITestPattern.Types.CustomColor();
	}

	ITestPattern.Types.IIntensityColor IFactory<ITestPattern.Types.IIntensityColor>.CreateInstance()
	{
		return new ITestPattern.Types.IntensityColor();
	}

	ITestPattern IFactory<ITestPattern>.CreateInstance()
	{
		return new TestPattern();
	}

	ITestPatternDefinition.Types.IBoolProperty IFactory<ITestPatternDefinition.Types.IBoolProperty>.CreateInstance()
	{
		return new ITestPatternDefinition.Types.BoolProperty();
	}

	ITestPatternDefinition.Types.IColorProperty IFactory<ITestPatternDefinition.Types.IColorProperty>.CreateInstance()
	{
		return new ITestPatternDefinition.Types.ColorProperty();
	}

	ITestPatternDefinition.Types.IDoubleProperty IFactory<ITestPatternDefinition.Types.IDoubleProperty>.CreateInstance()
	{
		return new ITestPatternDefinition.Types.DoubleProperty();
	}

	ITestPatternDefinition.Types.IFontProperty IFactory<ITestPatternDefinition.Types.IFontProperty>.CreateInstance()
	{
		return new ITestPatternDefinition.Types.FontProperty();
	}

	ITestPatternDefinition.Types.IIntProperty IFactory<ITestPatternDefinition.Types.IIntProperty>.CreateInstance()
	{
		return new ITestPatternDefinition.Types.IntProperty();
	}

	ITestPatternDefinition.Types.IProperty IFactory<ITestPatternDefinition.Types.IProperty>.CreateInstance()
	{
		return new ITestPatternDefinition.Types.Property();
	}

	ITestPatternDefinition.Types.ISelectorProperty IFactory<ITestPatternDefinition.Types.ISelectorProperty>.CreateInstance()
	{
		return new ITestPatternDefinition.Types.SelectorProperty();
	}

	ITestPatternDefinition.Types.IStringProperty IFactory<ITestPatternDefinition.Types.IStringProperty>.CreateInstance()
	{
		return new ITestPatternDefinition.Types.StringProperty();
	}

	ITestPatternDefinition IFactory<ITestPatternDefinition>.CreateInstance()
	{
		return new TestPatternDefinition();
	}

	ITestPatternDocument.Types.ITestPatternData.Types.IBoolProperty IFactory<ITestPatternDocument.Types.ITestPatternData.Types.IBoolProperty>.CreateInstance()
	{
		return new ITestPatternDocument.Types.ITestPatternData.Types.BoolProperty();
	}

	ITestPatternDocument.Types.ITestPatternData.Types.IColorProperty IFactory<ITestPatternDocument.Types.ITestPatternData.Types.IColorProperty>.CreateInstance()
	{
		return new ITestPatternDocument.Types.ITestPatternData.Types.ColorProperty();
	}

	ITestPatternDocument.Types.ITestPatternData.Types.IDoubleProperty IFactory<ITestPatternDocument.Types.ITestPatternData.Types.IDoubleProperty>.CreateInstance()
	{
		return new ITestPatternDocument.Types.ITestPatternData.Types.DoubleProperty();
	}

	ITestPatternDocument.Types.ITestPatternData.Types.IFontProperty IFactory<ITestPatternDocument.Types.ITestPatternData.Types.IFontProperty>.CreateInstance()
	{
		return new ITestPatternDocument.Types.ITestPatternData.Types.FontProperty();
	}

	ITestPatternDocument.Types.ITestPatternData.Types.IIntProperty IFactory<ITestPatternDocument.Types.ITestPatternData.Types.IIntProperty>.CreateInstance()
	{
		return new ITestPatternDocument.Types.ITestPatternData.Types.IntProperty();
	}

	ITestPatternDocument.Types.ITestPatternData.Types.IProperty IFactory<ITestPatternDocument.Types.ITestPatternData.Types.IProperty>.CreateInstance()
	{
		return new ITestPatternDocument.Types.ITestPatternData.Types.Property();
	}

	ITestPatternDocument.Types.ITestPatternData.Types.ISelectorProperty IFactory<ITestPatternDocument.Types.ITestPatternData.Types.ISelectorProperty>.CreateInstance()
	{
		return new ITestPatternDocument.Types.ITestPatternData.Types.SelectorProperty();
	}

	ITestPatternDocument.Types.ITestPatternData.Types.IStringProperty IFactory<ITestPatternDocument.Types.ITestPatternData.Types.IStringProperty>.CreateInstance()
	{
		return new ITestPatternDocument.Types.ITestPatternData.Types.StringProperty();
	}

	ITestPatternDocument.Types.ITestPatternData IFactory<ITestPatternDocument.Types.ITestPatternData>.CreateInstance()
	{
		return new ITestPatternDocument.Types.TestPatternData();
	}

	ITestPatternDocument.Types.ITestPatternStateData IFactory<ITestPatternDocument.Types.ITestPatternStateData>.CreateInstance()
	{
		return new ITestPatternDocument.Types.TestPatternStateData();
	}

	ITestPatternDocument IFactory<ITestPatternDocument>.CreateInstance()
	{
		return new TestPatternDocument();
	}

	ITestPatternRenderSettings.Types.IOutput IFactory<ITestPatternRenderSettings.Types.IOutput>.CreateInstance()
	{
		return new ITestPatternRenderSettings.Types.Output();
	}

	ITestPatternRenderSettings IFactory<ITestPatternRenderSettings>.CreateInstance()
	{
		return new TestPatternRenderSettings();
	}

	ITestPatternState IFactory<ITestPatternState>.CreateInstance()
	{
		return new TestPatternState();
	}

	ITimer.Types.IConfiguration.Types.ITimerTypeCountdown IFactory<ITimer.Types.IConfiguration.Types.ITimerTypeCountdown>.CreateInstance()
	{
		return new ITimer.Types.IConfiguration.Types.TimerTypeCountdown();
	}

	ITimer.Types.IConfiguration.Types.ITimerTypeCountdownToTime IFactory<ITimer.Types.IConfiguration.Types.ITimerTypeCountdownToTime>.CreateInstance()
	{
		return new ITimer.Types.IConfiguration.Types.TimerTypeCountdownToTime();
	}

	ITimer.Types.IConfiguration.Types.ITimerTypeElapsedTime IFactory<ITimer.Types.IConfiguration.Types.ITimerTypeElapsedTime>.CreateInstance()
	{
		return new ITimer.Types.IConfiguration.Types.TimerTypeElapsedTime();
	}

	ITimer.Types.IConfiguration IFactory<ITimer.Types.IConfiguration>.CreateInstance()
	{
		return new ITimer.Types.Configuration();
	}

	ITimer.Types.IFormat IFactory<ITimer.Types.IFormat>.CreateInstance()
	{
		return new ITimer.Types.Format();
	}

	ITimer IFactory<ITimer>.CreateInstance()
	{
		return new Timer();
	}

	ITimersDocument IFactory<ITimersDocument>.CreateInstance()
	{
		return new TimersDocument();
	}

	ITimersLocalDocument IFactory<ITimersLocalDocument>.CreateInstance()
	{
		return new TimersLocalDocument();
	}

	Timestamp IFactory<Timestamp>.CreateInstance()
	{
		return TimestampExtension.CreateDefault();
	}

	ITransition.Types.IPreset IFactory<ITransition.Types.IPreset>.CreateInstance()
	{
		return new ITransition.Types.Preset();
	}

	ITransition IFactory<ITransition>.CreateInstance()
	{
		return new Transition();
	}

	Url.Types.ExternalRelativePath.Types.MacOsExternalVolume IFactory<Url.Types.ExternalRelativePath.Types.MacOsExternalVolume>.CreateInstance()
	{
		return Url.Types.ExternalRelativePath.Types.MacOsExternalVolumeExtension.CreateDefault();
	}

	Url.Types.ExternalRelativePath.Types.Win32ExternalVolume IFactory<Url.Types.ExternalRelativePath.Types.Win32ExternalVolume>.CreateInstance()
	{
		return Url.Types.ExternalRelativePath.Types.Win32ExternalVolumeExtension.CreateDefault();
	}

	Url.Types.ExternalRelativePath IFactory<Url.Types.ExternalRelativePath>.CreateInstance()
	{
		return Url.Types.ExternalRelativePathExtension.CreateDefault();
	}

	Url.Types.LocalRelativePath IFactory<Url.Types.LocalRelativePath>.CreateInstance()
	{
		return Url.Types.LocalRelativePathExtension.CreateDefault();
	}

	Url IFactory<Url>.CreateInstance()
	{
		return UrlExtension.CreateDefault();
	}

	IVideoInput IFactory<IVideoInput>.CreateInstance()
	{
		return new VideoInput();
	}

	IAction.Types.ICaptureType.Types.ICaptureAction.IStart IFactory<IAction.Types.ICaptureType.Types.ICaptureAction.IStart>.CreateInstance()
	{
		return new IAction.Types.ICaptureType.Types.ICaptureAction.Start();
	}

	IAction.Types.ICaptureType.Types.ICaptureAction.IStop IFactory<IAction.Types.ICaptureType.Types.ICaptureAction.IStop>.CreateInstance()
	{
		return new IAction.Types.ICaptureType.Types.ICaptureAction.Stop();
	}

	IAction.Types.ICommunicationType.Types.ICommandTypeData.IMidiCommand IFactory<IAction.Types.ICommunicationType.Types.ICommandTypeData.IMidiCommand>.CreateInstance()
	{
		return new IAction.Types.ICommunicationType.Types.ICommandTypeData.MidiCommand();
	}

	IAction.Types.IMediaType.Types.IMediaType.IAudio IFactory<IAction.Types.IMediaType.Types.IMediaType.IAudio>.CreateInstance()
	{
		return new IAction.Types.IMediaType.Types.IMediaType.Audio();
	}

	IAction.Types.IPropType.Types.ITriggerType.ITrigger IFactory<IAction.Types.IPropType.Types.ITriggerType.ITrigger>.CreateInstance()
	{
		return new IAction.Types.IPropType.Types.ITriggerType.Trigger();
	}

	IAction.Types.IPropType.Types.ITriggerType.IClear IFactory<IAction.Types.IPropType.Types.ITriggerType.IClear>.CreateInstance()
	{
		return new IAction.Types.IPropType.Types.ITriggerType.Clear();
	}

	IAction.Types.ISlideType.Types.ISlide.IPresentation IFactory<IAction.Types.ISlideType.Types.ISlide.IPresentation>.CreateInstance()
	{
		return new IAction.Types.ISlideType.Types.ISlide.Presentation();
	}

	IAction.Types.ISlideType.Types.ISlide.IProp IFactory<IAction.Types.ISlideType.Types.ISlide.IProp>.CreateInstance()
	{
		return new IAction.Types.ISlideType.Types.ISlide.Prop();
	}

	IAction.Types.IActionTypeData.IPlaylistItem IFactory<IAction.Types.IActionTypeData.IPlaylistItem>.CreateInstance()
	{
		return new IAction.Types.IActionTypeData.PlaylistItem();
	}

	IAction.Types.IActionTypeData.IMedia IFactory<IAction.Types.IActionTypeData.IMedia>.CreateInstance()
	{
		return new IAction.Types.IActionTypeData.Media();
	}

	IAction.Types.IActionTypeData.ISlide IFactory<IAction.Types.IActionTypeData.ISlide>.CreateInstance()
	{
		return new IAction.Types.IActionTypeData.Slide();
	}

	IAction.Types.IActionTypeData.ITimer IFactory<IAction.Types.IActionTypeData.ITimer>.CreateInstance()
	{
		return new IAction.Types.IActionTypeData.Timer();
	}

	IAction.Types.IActionTypeData.IClear IFactory<IAction.Types.IActionTypeData.IClear>.CreateInstance()
	{
		return new IAction.Types.IActionTypeData.Clear();
	}

	IAction.Types.IActionTypeData.IStage IFactory<IAction.Types.IActionTypeData.IStage>.CreateInstance()
	{
		return new IAction.Types.IActionTypeData.Stage();
	}

	IAction.Types.IActionTypeData.IProp IFactory<IAction.Types.IActionTypeData.IProp>.CreateInstance()
	{
		return new IAction.Types.IActionTypeData.Prop();
	}

	IAction.Types.IActionTypeData.IMask IFactory<IAction.Types.IActionTypeData.IMask>.CreateInstance()
	{
		return new IAction.Types.IActionTypeData.Mask();
	}

	IAction.Types.IActionTypeData.IMessage IFactory<IAction.Types.IActionTypeData.IMessage>.CreateInstance()
	{
		return new IAction.Types.IActionTypeData.Message();
	}

	IAction.Types.IActionTypeData.ICommunication IFactory<IAction.Types.IActionTypeData.ICommunication>.CreateInstance()
	{
		return new IAction.Types.IActionTypeData.Communication();
	}

	IAction.Types.IActionTypeData.IMultiScreen IFactory<IAction.Types.IActionTypeData.IMultiScreen>.CreateInstance()
	{
		return new IAction.Types.IActionTypeData.MultiScreen();
	}

	IAction.Types.IActionTypeData.IPresentationDocument IFactory<IAction.Types.IActionTypeData.IPresentationDocument>.CreateInstance()
	{
		return new IAction.Types.IActionTypeData.PresentationDocument();
	}

	IAction.Types.IActionTypeData.IExternalPresentation IFactory<IAction.Types.IActionTypeData.IExternalPresentation>.CreateInstance()
	{
		return new IAction.Types.IActionTypeData.ExternalPresentation();
	}

	IAction.Types.IActionTypeData.IAudienceLook IFactory<IAction.Types.IActionTypeData.IAudienceLook>.CreateInstance()
	{
		return new IAction.Types.IActionTypeData.AudienceLook();
	}

	IAction.Types.IActionTypeData.IAudioInput IFactory<IAction.Types.IActionTypeData.IAudioInput>.CreateInstance()
	{
		return new IAction.Types.IActionTypeData.AudioInput();
	}

	IAction.Types.IActionTypeData.ISlideDestination IFactory<IAction.Types.IActionTypeData.ISlideDestination>.CreateInstance()
	{
		return new IAction.Types.IActionTypeData.SlideDestination();
	}

	IAction.Types.IActionTypeData.IMacro IFactory<IAction.Types.IActionTypeData.IMacro>.CreateInstance()
	{
		return new IAction.Types.IActionTypeData.Macro();
	}

	IAction.Types.IActionTypeData.IClearGroup IFactory<IAction.Types.IActionTypeData.IClearGroup>.CreateInstance()
	{
		return new IAction.Types.IActionTypeData.ClearGroup();
	}

	IAction.Types.IActionTypeData.ICapture IFactory<IAction.Types.IActionTypeData.ICapture>.CreateInstance()
	{
		return new IAction.Types.IActionTypeData.Capture();
	}

	IAudioInput.Types.IBehaviorMode.Types.IMode.IOn IFactory<IAudioInput.Types.IBehaviorMode.Types.IMode.IOn>.CreateInstance()
	{
		return new IAudioInput.Types.IBehaviorMode.Types.IMode.On();
	}

	IAudioInput.Types.IBehaviorMode.Types.IMode.IOff IFactory<IAudioInput.Types.IBehaviorMode.Types.IMode.IOff>.CreateInstance()
	{
		return new IAudioInput.Types.IBehaviorMode.Types.IMode.Off();
	}

	IAudioInput.Types.IBehaviorMode.Types.IMode.IAutoOn IFactory<IAudioInput.Types.IBehaviorMode.Types.IMode.IAutoOn>.CreateInstance()
	{
		return new IAudioInput.Types.IBehaviorMode.Types.IMode.AutoOn();
	}

	IAudioInput.Types.IBehaviorMode.Types.IMode.IAutoOff IFactory<IAudioInput.Types.IBehaviorMode.Types.IMode.IAutoOff>.CreateInstance()
	{
		return new IAudioInput.Types.IBehaviorMode.Types.IMode.AutoOff();
	}

	IAudioInput.Types.ISource.IAudioDevice IFactory<IAudioInput.Types.ISource.IAudioDevice>.CreateInstance()
	{
		return new IAudioInput.Types.ISource.AudioDevice();
	}

	IAudioInput.Types.ISource.IVideoDevice IFactory<IAudioInput.Types.ISource.IVideoDevice>.CreateInstance()
	{
		return new IAudioInput.Types.ISource.VideoDevice();
	}

	IBackground.Types.IFill.IColor IFactory<IBackground.Types.IFill.IColor>.CreateInstance()
	{
		return new IBackground.Types.IFill.Color();
	}

	IBackground.Types.IFill.IGradient IFactory<IBackground.Types.IFill.IGradient>.CreateInstance()
	{
		return new IBackground.Types.IFill.Gradient();
	}

	ICommunicationDeviceLocal.Types.IHardwareType.ISerial IFactory<ICommunicationDeviceLocal.Types.IHardwareType.ISerial>.CreateInstance()
	{
		return new ICommunicationDeviceLocal.Types.IHardwareType.Serial();
	}

	ICommunicationDeviceLocal.Types.IHardwareType.ITcpNetwork IFactory<ICommunicationDeviceLocal.Types.IHardwareType.ITcpNetwork>.CreateInstance()
	{
		return new ICommunicationDeviceLocal.Types.IHardwareType.TcpNetwork();
	}

	ICommunicationDeviceLocal.Types.IHardwareType.IUdpNetwork IFactory<ICommunicationDeviceLocal.Types.IHardwareType.IUdpNetwork>.CreateInstance()
	{
		return new ICommunicationDeviceLocal.Types.IHardwareType.UdpNetwork();
	}

	ICommunicationDeviceLocal.Types.IHardwareType.IArtnet IFactory<ICommunicationDeviceLocal.Types.IHardwareType.IArtnet>.CreateInstance()
	{
		return new ICommunicationDeviceLocal.Types.IHardwareType.Artnet();
	}

	ICommunicationDeviceLocal.Types.IHardwareType.IMidi IFactory<ICommunicationDeviceLocal.Types.IHardwareType.IMidi>.CreateInstance()
	{
		return new ICommunicationDeviceLocal.Types.IHardwareType.Midi();
	}

	ICommunicationDeviceOption.Types.IOptionType.IOesProMode IFactory<ICommunicationDeviceOption.Types.IOptionType.IOesProMode>.CreateInstance()
	{
		return new ICommunicationDeviceOption.Types.IOptionType.OesProMode();
	}

	IEffect.Types.IEffectVariable.Types.IType.IInt IFactory<IEffect.Types.IEffectVariable.Types.IType.IInt>.CreateInstance()
	{
		return new IEffect.Types.IEffectVariable.Types.IType.Int();
	}

	IEffect.Types.IEffectVariable.Types.IType.IFloat IFactory<IEffect.Types.IEffectVariable.Types.IType.IFloat>.CreateInstance()
	{
		return new IEffect.Types.IEffectVariable.Types.IType.Float();
	}

	IEffect.Types.IEffectVariable.Types.IType.IColor IFactory<IEffect.Types.IEffectVariable.Types.IType.IColor>.CreateInstance()
	{
		return new IEffect.Types.IEffectVariable.Types.IType.Color();
	}

	IEffect.Types.IEffectVariable.Types.IType.IDirection IFactory<IEffect.Types.IEffectVariable.Types.IType.IDirection>.CreateInstance()
	{
		return new IEffect.Types.IEffectVariable.Types.IType.Direction();
	}

	IEffect.Types.IEffectVariable.Types.IType.IDouble IFactory<IEffect.Types.IEffectVariable.Types.IType.IDouble>.CreateInstance()
	{
		return new IEffect.Types.IEffectVariable.Types.IType.Double();
	}

	IGraphics.Types.IBackgroundEffect.Types.IEffectType.IBackgroundBlur IFactory<IGraphics.Types.IBackgroundEffect.Types.IEffectType.IBackgroundBlur>.CreateInstance()
	{
		return new IGraphics.Types.IBackgroundEffect.Types.IEffectType.BackgroundBlur();
	}

	IGraphics.Types.IBackgroundEffect.Types.IEffectType.IBackgroundInvert IFactory<IGraphics.Types.IBackgroundEffect.Types.IEffectType.IBackgroundInvert>.CreateInstance()
	{
		return new IGraphics.Types.IBackgroundEffect.Types.IEffectType.BackgroundInvert();
	}

	IGraphics.Types.IElement.Types.IMask.ITextLineMask IFactory<IGraphics.Types.IElement.Types.IMask.ITextLineMask>.CreateInstance()
	{
		return new IGraphics.Types.IElement.Types.IMask.TextLineMask();
	}

	IGraphics.Types.IFill.Types.IFillType.IColor IFactory<IGraphics.Types.IFill.Types.IFillType.IColor>.CreateInstance()
	{
		return new IGraphics.Types.IFill.Types.IFillType.Color();
	}

	IGraphics.Types.IFill.Types.IFillType.IGradient IFactory<IGraphics.Types.IFill.Types.IFillType.IGradient>.CreateInstance()
	{
		return new IGraphics.Types.IFill.Types.IFillType.Gradient();
	}

	IGraphics.Types.IFill.Types.IFillType.IMedia IFactory<IGraphics.Types.IFill.Types.IFillType.IMedia>.CreateInstance()
	{
		return new IGraphics.Types.IFill.Types.IFillType.Media();
	}

	IGraphics.Types.IFill.Types.IFillType.IBackgroundEffect IFactory<IGraphics.Types.IFill.Types.IFillType.IBackgroundEffect>.CreateInstance()
	{
		return new IGraphics.Types.IFill.Types.IFillType.BackgroundEffect();
	}

	IGraphics.Types.IText.Types.IAlternateText.Types.IContentType.IPlainText IFactory<IGraphics.Types.IText.Types.IAlternateText.Types.IContentType.IPlainText>.CreateInstance()
	{
		return new IGraphics.Types.IText.Types.IAlternateText.Types.IContentType.PlainText();
	}

	IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.ICapitalization IFactory<IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.ICapitalization>.CreateInstance()
	{
		return new IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.Capitalization();
	}

	IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.IOriginalFontSize IFactory<IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.IOriginalFontSize>.CreateInstance()
	{
		return new IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.OriginalFontSize();
	}

	IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.IFontScaleFactor IFactory<IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.IFontScaleFactor>.CreateInstance()
	{
		return new IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.FontScaleFactor();
	}

	IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.ITextGradientFill IFactory<IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.ITextGradientFill>.CreateInstance()
	{
		return new IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.TextGradientFill();
	}

	IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.IShouldPreserveForegroundColor IFactory<IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.IShouldPreserveForegroundColor>.CreateInstance()
	{
		return new IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.ShouldPreserveForegroundColor();
	}

	IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.IChord IFactory<IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.IChord>.CreateInstance()
	{
		return new IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.Chord();
	}

	IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.ICutOutFill IFactory<IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.ICutOutFill>.CreateInstance()
	{
		return new IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.CutOutFill();
	}

	IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.IMediaFill IFactory<IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.IMediaFill>.CreateInstance()
	{
		return new IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.MediaFill();
	}

	IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.IBackgroundEffect IFactory<IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.IBackgroundEffect>.CreateInstance()
	{
		return new IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.BackgroundEffect();
	}

	IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.IOriginalFont IFactory<IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.IOriginalFont>.CreateInstance()
	{
		return new IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.OriginalFont();
	}

	IGraphics.Types.IText.Types.IAttributes.Types.IFill.ITextSolidFill IFactory<IGraphics.Types.IText.Types.IAttributes.Types.IFill.ITextSolidFill>.CreateInstance()
	{
		return new IGraphics.Types.IText.Types.IAttributes.Types.IFill.TextSolidFill();
	}

	IGraphics.Types.IText.Types.IAttributes.Types.IFill.ITextGradientFill IFactory<IGraphics.Types.IText.Types.IAttributes.Types.IFill.ITextGradientFill>.CreateInstance()
	{
		return new IGraphics.Types.IText.Types.IAttributes.Types.IFill.TextGradientFill();
	}

	IGraphics.Types.IText.Types.IAttributes.Types.IFill.ICutOutFill IFactory<IGraphics.Types.IText.Types.IAttributes.Types.IFill.ICutOutFill>.CreateInstance()
	{
		return new IGraphics.Types.IText.Types.IAttributes.Types.IFill.CutOutFill();
	}

	IGraphics.Types.IText.Types.IAttributes.Types.IFill.IMediaFill IFactory<IGraphics.Types.IText.Types.IAttributes.Types.IFill.IMediaFill>.CreateInstance()
	{
		return new IGraphics.Types.IText.Types.IAttributes.Types.IFill.MediaFill();
	}

	IGraphics.Types.IText.Types.IAttributes.Types.IFill.IBackgroundEffect IFactory<IGraphics.Types.IText.Types.IAttributes.Types.IFill.IBackgroundEffect>.CreateInstance()
	{
		return new IGraphics.Types.IText.Types.IAttributes.Types.IFill.BackgroundEffect();
	}

	IKeyMapping.Types.ITargetIdentifier.IMenuItem IFactory<IKeyMapping.Types.ITargetIdentifier.IMenuItem>.CreateInstance()
	{
		return new IKeyMapping.Types.ITargetIdentifier.MenuItem();
	}

	IKeyMapping.Types.ITargetIdentifier.IClearGroupIdentifier IFactory<IKeyMapping.Types.ITargetIdentifier.IClearGroupIdentifier>.CreateInstance()
	{
		return new IKeyMapping.Types.ITargetIdentifier.ClearGroupIdentifier();
	}

	IKeyMapping.Types.ITargetIdentifier.ICueIdentifier IFactory<IKeyMapping.Types.ITargetIdentifier.ICueIdentifier>.CreateInstance()
	{
		return new IKeyMapping.Types.ITargetIdentifier.CueIdentifier();
	}

	IKeyMapping.Types.ITargetIdentifier.IGroupIdentifier IFactory<IKeyMapping.Types.ITargetIdentifier.IGroupIdentifier>.CreateInstance()
	{
		return new IKeyMapping.Types.ITargetIdentifier.GroupIdentifier();
	}

	IKeyMapping.Types.ITargetIdentifier.IMacroIdentifier IFactory<IKeyMapping.Types.ITargetIdentifier.IMacroIdentifier>.CreateInstance()
	{
		return new IKeyMapping.Types.ITargetIdentifier.MacroIdentifier();
	}

	IKeyMapping.Types.ITargetIdentifier.IPropIdentifier IFactory<IKeyMapping.Types.ITargetIdentifier.IPropIdentifier>.CreateInstance()
	{
		return new IKeyMapping.Types.ITargetIdentifier.PropIdentifier();
	}

	IKeyMapping.Types.ITargetIdentifier.ITimerIdentifier IFactory<IKeyMapping.Types.ITargetIdentifier.ITimerIdentifier>.CreateInstance()
	{
		return new IKeyMapping.Types.ITargetIdentifier.TimerIdentifier();
	}

	ILayer.Types.IBlending.Types.IMatte.Types.IMatteType.IAlpha IFactory<ILayer.Types.IBlending.Types.IMatte.Types.IMatteType.IAlpha>.CreateInstance()
	{
		return new ILayer.Types.IBlending.Types.IMatte.Types.IMatteType.Alpha();
	}

	ILayer.Types.IBlending.Types.IMatte.Types.IMatteType.ILuma IFactory<ILayer.Types.IBlending.Types.IMatte.Types.IMatteType.ILuma>.CreateInstance()
	{
		return new ILayer.Types.IBlending.Types.IMatte.Types.IMatteType.Luma();
	}

	ILayer.Types.IBlending.Types.IMatte.Types.IMatteType.IWhite IFactory<ILayer.Types.IBlending.Types.IMatte.Types.IMatteType.IWhite>.CreateInstance()
	{
		return new ILayer.Types.IBlending.Types.IMatte.Types.IMatteType.White();
	}

	ILibrary.Types.IChildType.ILibraryChildren IFactory<ILibrary.Types.IChildType.ILibraryChildren>.CreateInstance()
	{
		return new ILibrary.Types.IChildType.LibraryChildren();
	}

	ILibrary.Types.IChildType.ILibraryItems IFactory<ILibrary.Types.IChildType.ILibraryItems>.CreateInstance()
	{
		return new ILibrary.Types.IChildType.LibraryItems();
	}

	IMedia.Types.ITypeProperties.IAudio IFactory<IMedia.Types.ITypeProperties.IAudio>.CreateInstance()
	{
		return new IMedia.Types.ITypeProperties.Audio();
	}

	IMedia.Types.ITypeProperties.IImage IFactory<IMedia.Types.ITypeProperties.IImage>.CreateInstance()
	{
		return new IMedia.Types.ITypeProperties.Image();
	}

	IMedia.Types.ITypeProperties.IVideo IFactory<IMedia.Types.ITypeProperties.IVideo>.CreateInstance()
	{
		return new IMedia.Types.ITypeProperties.Video();
	}

	IMedia.Types.ITypeProperties.ILiveVideo IFactory<IMedia.Types.ITypeProperties.ILiveVideo>.CreateInstance()
	{
		return new IMedia.Types.ITypeProperties.LiveVideo();
	}

	IMedia.Types.ITypeProperties.IWebContent IFactory<IMedia.Types.ITypeProperties.IWebContent>.CreateInstance()
	{
		return new IMedia.Types.ITypeProperties.WebContent();
	}

	IMessage.Types.IToken.Types.ITokenType.IText IFactory<IMessage.Types.IToken.Types.ITokenType.IText>.CreateInstance()
	{
		return new IMessage.Types.IToken.Types.ITokenType.Text();
	}

	IMessage.Types.IToken.Types.ITokenType.ITimer IFactory<IMessage.Types.IToken.Types.ITokenType.ITimer>.CreateInstance()
	{
		return new IMessage.Types.IToken.Types.ITokenType.Timer();
	}

	IMessage.Types.IToken.Types.ITokenType.IClock IFactory<IMessage.Types.IToken.Types.ITokenType.IClock>.CreateInstance()
	{
		return new IMessage.Types.IToken.Types.ITokenType.Clock();
	}

	IMessage.Types.ITokenValue.Types.ITokenValueType.IText IFactory<IMessage.Types.ITokenValue.Types.ITokenValueType.IText>.CreateInstance()
	{
		return new IMessage.Types.ITokenValue.Types.ITokenValueType.Text();
	}

	IMessage.Types.ITokenValue.Types.ITokenValueType.ITimer IFactory<IMessage.Types.ITokenValue.Types.ITokenValueType.ITimer>.CreateInstance()
	{
		return new IMessage.Types.ITokenValue.Types.ITokenValueType.Timer();
	}

	IMessage.Types.ITokenValue.Types.ITokenValueType.IClock IFactory<IMessage.Types.ITokenValue.Types.ITokenValueType.IClock>.CreateInstance()
	{
		return new IMessage.Types.ITokenValue.Types.ITokenValueType.Clock();
	}

	IOutputDisplay.Types.IHardwareOptions.IBlackmagic IFactory<IOutputDisplay.Types.IHardwareOptions.IBlackmagic>.CreateInstance()
	{
		return new IOutputDisplay.Types.IHardwareOptions.Blackmagic();
	}

	IPlaylist.Types.IChildrenType.IPlaylists IFactory<IPlaylist.Types.IChildrenType.IPlaylists>.CreateInstance()
	{
		return new IPlaylist.Types.IChildrenType.Playlists();
	}

	IPlaylist.Types.IChildrenType.IItems IFactory<IPlaylist.Types.IChildrenType.IItems>.CreateInstance()
	{
		return new IPlaylist.Types.IChildrenType.Items();
	}

	IPlaylist.Types.ILinkData.ISmartDirectory IFactory<IPlaylist.Types.ILinkData.ISmartDirectory>.CreateInstance()
	{
		return new IPlaylist.Types.ILinkData.SmartDirectory();
	}

	IPlaylist.Types.ILinkData.IPcoPlan IFactory<IPlaylist.Types.ILinkData.IPcoPlan>.CreateInstance()
	{
		return new IPlaylist.Types.ILinkData.PcoPlan();
	}

	IPlaylistItem.Types.IItemType.IHeader IFactory<IPlaylistItem.Types.IItemType.IHeader>.CreateInstance()
	{
		return new IPlaylistItem.Types.IItemType.Header();
	}

	IPlaylistItem.Types.IItemType.IPresentation IFactory<IPlaylistItem.Types.IItemType.IPresentation>.CreateInstance()
	{
		return new IPlaylistItem.Types.IItemType.Presentation();
	}

	IPlaylistItem.Types.IItemType.ICue IFactory<IPlaylistItem.Types.IItemType.ICue>.CreateInstance()
	{
		return new IPlaylistItem.Types.IItemType.Cue();
	}

	IPlaylistItem.Types.IItemType.IPlanningCenter IFactory<IPlaylistItem.Types.IItemType.IPlanningCenter>.CreateInstance()
	{
		return new IPlaylistItem.Types.IItemType.PlanningCenter();
	}

	IPlaylistItem.Types.IItemType.IPlaceholder IFactory<IPlaylistItem.Types.IItemType.IPlaceholder>.CreateInstance()
	{
		return new IPlaylistItem.Types.IItemType.Placeholder();
	}

	IPresentation.Types.ITimeline.Types.ICue.Types.ITriggerInfo.ICueId IFactory<IPresentation.Types.ITimeline.Types.ICue.Types.ITriggerInfo.ICueId>.CreateInstance()
	{
		return new IPresentation.Types.ITimeline.Types.ICue.Types.ITriggerInfo.CueId();
	}

	IPresentation.Types.ITimeline.Types.ICue.Types.ITriggerInfo.IAction IFactory<IPresentation.Types.ITimeline.Types.ICue.Types.ITriggerInfo.IAction>.CreateInstance()
	{
		return new IPresentation.Types.ITimeline.Types.ICue.Types.ITriggerInfo.Action();
	}

	IPresentation.Types.ISlideShow.ISlideShowDuration IFactory<IPresentation.Types.ISlideShow.ISlideShowDuration>.CreateInstance()
	{
		return new IPresentation.Types.ISlideShow.SlideShowDuration();
	}

	IProPresenterScreen.Types.IArrangement.IArrangementSingle IFactory<IProPresenterScreen.Types.IArrangement.IArrangementSingle>.CreateInstance()
	{
		return new IProPresenterScreen.Types.IArrangement.ArrangementSingle();
	}

	IProPresenterScreen.Types.IArrangement.IArrangementCombined IFactory<IProPresenterScreen.Types.IArrangement.IArrangementCombined>.CreateInstance()
	{
		return new IProPresenterScreen.Types.IArrangement.ArrangementCombined();
	}

	IProPresenterScreen.Types.IArrangement.IArrangementEdgeBlend IFactory<IProPresenterScreen.Types.IArrangement.IArrangementEdgeBlend>.CreateInstance()
	{
		return new IProPresenterScreen.Types.IArrangement.ArrangementEdgeBlend();
	}

	IProPresenterScreen.Types.IRenderingEnabledOptional.IRenderingEnabled IFactory<IProPresenterScreen.Types.IRenderingEnabledOptional.IRenderingEnabled>.CreateInstance()
	{
		return new IProPresenterScreen.Types.IRenderingEnabledOptional.RenderingEnabled();
	}

	IRecording.Types.IStream.Types.IDestination.Types.IDestination.IDisk IFactory<IRecording.Types.IStream.Types.IDestination.Types.IDestination.IDisk>.CreateInstance()
	{
		return new IRecording.Types.IStream.Types.IDestination.Types.IDestination.Disk();
	}

	IRecording.Types.IStream.Types.IDestination.Types.IDestination.IRtmp IFactory<IRecording.Types.IStream.Types.IDestination.Types.IDestination.IRtmp>.CreateInstance()
	{
		return new IRecording.Types.IStream.Types.IDestination.Types.IDestination.Rtmp();
	}

	IRecording.Types.IStream.Types.IDestination.Types.IDestination.IResi IFactory<IRecording.Types.IStream.Types.IDestination.Types.IDestination.IResi>.CreateInstance()
	{
		return new IRecording.Types.IStream.Types.IDestination.Types.IDestination.Resi();
	}

	IRecording.Types.IStream.Types.ISource.IOutputScreen IFactory<IRecording.Types.IStream.Types.ISource.IOutputScreen>.CreateInstance()
	{
		return new IRecording.Types.IStream.Types.ISource.OutputScreen();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.ICaptureStatusText.Types.ITextType.IStatusText IFactory<ISlide.Types.IElement.Types.IDataLink.Types.ICaptureStatusText.Types.ITextType.IStatusText>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.ICaptureStatusText.Types.ITextType.StatusText();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.ICaptureStatusText.Types.ITextType.IElapsedTime IFactory<ISlide.Types.IElement.Types.IDataLink.Types.ICaptureStatusText.Types.ITextType.IElapsedTime>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.ICaptureStatusText.Types.ITextType.ElapsedTime();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerText.Types.ITextType.IName IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerText.Types.ITextType.IName>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerText.Types.ITextType.Name();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerText.Types.ITextType.ITime IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerText.Types.ITextType.ITime>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerText.Types.ITextType.Time();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.ITicker.Types.ISourceType.ITextType IFactory<ISlide.Types.IElement.Types.IDataLink.Types.ITicker.Types.ISourceType.ITextType>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.ITicker.Types.ISourceType.TextType();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.ITicker.Types.ISourceType.IRssType IFactory<ISlide.Types.IElement.Types.IDataLink.Types.ITicker.Types.ISourceType.IRssType>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.ITicker.Types.ISourceType.RssType();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.ITicker.Types.ISourceType.IFileType IFactory<ISlide.Types.IElement.Types.IDataLink.Types.ITicker.Types.ISourceType.IFileType>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.ITicker.Types.ISourceType.FileType();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IConditionType.IElementVisibility IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IConditionType.IElementVisibility>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IConditionType.ElementVisibility();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IConditionType.ITimerVisibility IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IConditionType.ITimerVisibility>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IConditionType.TimerVisibility();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IConditionType.IVideoCountdownVisibility IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IConditionType.IVideoCountdownVisibility>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IConditionType.VideoCountdownVisibility();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IConditionType.ICaptureSessionVisibility IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IConditionType.ICaptureSessionVisibility>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IConditionType.CaptureSessionVisibility();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IConditionType.IVideoInputVisibility IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IConditionType.IVideoInputVisibility>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IConditionType.VideoInputVisibility();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IConditionType.IAudioCountdownVisibility IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IConditionType.IAudioCountdownVisibility>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IConditionType.AudioCountdownVisibility();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ITicker IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ITicker>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.Ticker();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IAlternateText IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IAlternateText>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.AlternateText();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ITimerText IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ITimerText>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.TimerText();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IClockText IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IClockText>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ClockText();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IChordChart IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IChordChart>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ChordChart();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IOutputScreen IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IOutputScreen>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.OutputScreen();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IPcoLive IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IPcoLive>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.PcoLive();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IAlternateFill IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IAlternateFill>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.AlternateFill();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IVisibilityLink IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IVisibilityLink>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.VisibilityLink();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ISlideText IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ISlideText>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.SlideText();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IStageMessage IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IStageMessage>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.StageMessage();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IVideoCountdown IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IVideoCountdown>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.VideoCountdown();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ISlideImage IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ISlideImage>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.SlideImage();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ICcliText IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ICcliText>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.CcliText();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IGroupName IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IGroupName>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.GroupName();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IGroupColor IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IGroupColor>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.GroupColor();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IPresentationNotes IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IPresentationNotes>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.PresentationNotes();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IPlaylistItem IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IPlaylistItem>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.PlaylistItem();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IAutoAdvanceTimeRemaining IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IAutoAdvanceTimeRemaining>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.AutoAdvanceTimeRemaining();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ICaptureStatusText IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ICaptureStatusText>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.CaptureStatusText();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ICaptureStatusColor IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ICaptureStatusColor>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.CaptureStatusColor();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ISlideCount IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ISlideCount>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.SlideCount();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IAudioCountdown IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IAudioCountdown>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.AudioCountdown();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IPresentation IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IPresentation>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.Presentation();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ISlideLabelText IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ISlideLabelText>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.SlideLabelText();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ISlideLabelColor IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ISlideLabelColor>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.SlideLabelColor();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IRssFeed IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IRssFeed>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.RssFeed();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IFileFeed IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IFileFeed>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.FileFeed();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IChordProChart IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IChordProChart>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ChordProChart();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IPlaybackMarkerText IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IPlaybackMarkerText>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.PlaybackMarkerText();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IPlaybackMarkerColor IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.IPlaybackMarkerColor>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.PlaybackMarkerColor();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ITimecodeText IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ITimecodeText>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.TimecodeText();
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ITimecodeStatus IFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.ITimecodeStatus>.CreateInstance()
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IPropertyType.TimecodeStatus();
	}

	ITestPatternDefinition.Types.IProperty.Types.IPropertyType.IColorProperty IFactory<ITestPatternDefinition.Types.IProperty.Types.IPropertyType.IColorProperty>.CreateInstance()
	{
		return new ITestPatternDefinition.Types.IProperty.Types.IPropertyType.ColorProperty();
	}

	ITestPatternDefinition.Types.IProperty.Types.IPropertyType.IDoubleProperty IFactory<ITestPatternDefinition.Types.IProperty.Types.IPropertyType.IDoubleProperty>.CreateInstance()
	{
		return new ITestPatternDefinition.Types.IProperty.Types.IPropertyType.DoubleProperty();
	}

	ITestPatternDefinition.Types.IProperty.Types.IPropertyType.IIntProperty IFactory<ITestPatternDefinition.Types.IProperty.Types.IPropertyType.IIntProperty>.CreateInstance()
	{
		return new ITestPatternDefinition.Types.IProperty.Types.IPropertyType.IntProperty();
	}

	ITestPatternDefinition.Types.IProperty.Types.IPropertyType.IBoolProperty IFactory<ITestPatternDefinition.Types.IProperty.Types.IPropertyType.IBoolProperty>.CreateInstance()
	{
		return new ITestPatternDefinition.Types.IProperty.Types.IPropertyType.BoolProperty();
	}

	ITestPatternDefinition.Types.IProperty.Types.IPropertyType.IStringProperty IFactory<ITestPatternDefinition.Types.IProperty.Types.IPropertyType.IStringProperty>.CreateInstance()
	{
		return new ITestPatternDefinition.Types.IProperty.Types.IPropertyType.StringProperty();
	}

	ITestPatternDefinition.Types.IProperty.Types.IPropertyType.IFontProperty IFactory<ITestPatternDefinition.Types.IProperty.Types.IPropertyType.IFontProperty>.CreateInstance()
	{
		return new ITestPatternDefinition.Types.IProperty.Types.IPropertyType.FontProperty();
	}

	ITestPatternDefinition.Types.IProperty.Types.IPropertyType.ISelectorProperty IFactory<ITestPatternDefinition.Types.IProperty.Types.IPropertyType.ISelectorProperty>.CreateInstance()
	{
		return new ITestPatternDefinition.Types.IProperty.Types.IPropertyType.SelectorProperty();
	}

	ITestPatternDocument.Types.ITestPatternData.Types.IProperty.Types.IPropertyType.IColorProperty IFactory<ITestPatternDocument.Types.ITestPatternData.Types.IProperty.Types.IPropertyType.IColorProperty>.CreateInstance()
	{
		return new ITestPatternDocument.Types.ITestPatternData.Types.IProperty.Types.IPropertyType.ColorProperty();
	}

	ITestPatternDocument.Types.ITestPatternData.Types.IProperty.Types.IPropertyType.IDoubleProperty IFactory<ITestPatternDocument.Types.ITestPatternData.Types.IProperty.Types.IPropertyType.IDoubleProperty>.CreateInstance()
	{
		return new ITestPatternDocument.Types.ITestPatternData.Types.IProperty.Types.IPropertyType.DoubleProperty();
	}

	ITestPatternDocument.Types.ITestPatternData.Types.IProperty.Types.IPropertyType.IIntProperty IFactory<ITestPatternDocument.Types.ITestPatternData.Types.IProperty.Types.IPropertyType.IIntProperty>.CreateInstance()
	{
		return new ITestPatternDocument.Types.ITestPatternData.Types.IProperty.Types.IPropertyType.IntProperty();
	}

	ITestPatternDocument.Types.ITestPatternData.Types.IProperty.Types.IPropertyType.IBoolProperty IFactory<ITestPatternDocument.Types.ITestPatternData.Types.IProperty.Types.IPropertyType.IBoolProperty>.CreateInstance()
	{
		return new ITestPatternDocument.Types.ITestPatternData.Types.IProperty.Types.IPropertyType.BoolProperty();
	}

	ITestPatternDocument.Types.ITestPatternData.Types.IProperty.Types.IPropertyType.IStringProperty IFactory<ITestPatternDocument.Types.ITestPatternData.Types.IProperty.Types.IPropertyType.IStringProperty>.CreateInstance()
	{
		return new ITestPatternDocument.Types.ITestPatternData.Types.IProperty.Types.IPropertyType.StringProperty();
	}

	ITestPatternDocument.Types.ITestPatternData.Types.IProperty.Types.IPropertyType.IFontProperty IFactory<ITestPatternDocument.Types.ITestPatternData.Types.IProperty.Types.IPropertyType.IFontProperty>.CreateInstance()
	{
		return new ITestPatternDocument.Types.ITestPatternData.Types.IProperty.Types.IPropertyType.FontProperty();
	}

	ITestPatternDocument.Types.ITestPatternData.Types.IProperty.Types.IPropertyType.ISelectorProperty IFactory<ITestPatternDocument.Types.ITestPatternData.Types.IProperty.Types.IPropertyType.ISelectorProperty>.CreateInstance()
	{
		return new ITestPatternDocument.Types.ITestPatternData.Types.IProperty.Types.IPropertyType.SelectorProperty();
	}

	ITimer.Types.IConfiguration.Types.ITimerType.ICountdown IFactory<ITimer.Types.IConfiguration.Types.ITimerType.ICountdown>.CreateInstance()
	{
		return new ITimer.Types.IConfiguration.Types.ITimerType.Countdown();
	}

	ITimer.Types.IConfiguration.Types.ITimerType.ICountdownToTime IFactory<ITimer.Types.IConfiguration.Types.ITimerType.ICountdownToTime>.CreateInstance()
	{
		return new ITimer.Types.IConfiguration.Types.ITimerType.CountdownToTime();
	}

	ITimer.Types.IConfiguration.Types.ITimerType.IElapsedTime IFactory<ITimer.Types.IConfiguration.Types.ITimerType.IElapsedTime>.CreateInstance()
	{
		return new ITimer.Types.IConfiguration.Types.ITimerType.ElapsedTime();
	}

	IVideoInput.Types.IAltAudioSource.IAudioDevice IFactory<IVideoInput.Types.IAltAudioSource.IAudioDevice>.CreateInstance()
	{
		return new IVideoInput.Types.IAltAudioSource.AudioDevice();
	}

	IVideoInput.Types.IAltAudioSource.IVideoDevice IFactory<IVideoInput.Types.IAltAudioSource.IVideoDevice>.CreateInstance()
	{
		return new IVideoInput.Types.IAltAudioSource.VideoDevice();
	}

	IAction.Types.ClearType IAtomicValueFactory<IAction.Types.ClearType>.CreateInstance(Dictionary<string, LoroValue> values)
	{
		return IAction.Types.ClearTypeExtension.Deserialize(values);
	}

	Color IAtomicValueFactory<Color>.CreateInstance(Dictionary<string, LoroValue> values)
	{
		return ColorExtension.Deserialize(values);
	}

	ICopyrightLayout.Types.Token IAtomicValueFactory<ICopyrightLayout.Types.Token>.CreateInstance(Dictionary<string, LoroValue> values)
	{
		return ICopyrightLayout.Types.TokenExtension.Deserialize(values);
	}

	Font IAtomicValueFactory<Font>.CreateInstance(Dictionary<string, LoroValue> values)
	{
		return FontExtension.Deserialize(values);
	}

	IGraphics.Types.IPath.Types.Shape.Types.Arrow IAtomicValueFactory<IGraphics.Types.IPath.Types.Shape.Types.Arrow>.CreateInstance(Dictionary<string, LoroValue> values)
	{
		return IGraphics.Types.IPath.Types.Shape.Types.ArrowExtension.Deserialize(values);
	}

	IGraphics.Types.IPath.Types.Shape.Types.Polygon IAtomicValueFactory<IGraphics.Types.IPath.Types.Shape.Types.Polygon>.CreateInstance(Dictionary<string, LoroValue> values)
	{
		return IGraphics.Types.IPath.Types.Shape.Types.PolygonExtension.Deserialize(values);
	}

	IGraphics.Types.IPath.Types.Shape.Types.RoundedRectangle IAtomicValueFactory<IGraphics.Types.IPath.Types.Shape.Types.RoundedRectangle>.CreateInstance(Dictionary<string, LoroValue> values)
	{
		return IGraphics.Types.IPath.Types.Shape.Types.RoundedRectangleExtension.Deserialize(values);
	}

	IGraphics.Types.IPath.Types.Shape.Types.Star IAtomicValueFactory<IGraphics.Types.IPath.Types.Shape.Types.Star>.CreateInstance(Dictionary<string, LoroValue> values)
	{
		return IGraphics.Types.IPath.Types.Shape.Types.StarExtension.Deserialize(values);
	}

	IGraphics.Types.IPath.Types.Shape IAtomicValueFactory<IGraphics.Types.IPath.Types.Shape>.CreateInstance(Dictionary<string, LoroValue> values)
	{
		return IGraphics.Types.IPath.Types.ShapeExtension.Deserialize(values);
	}

	IGraphics.Types.Point IAtomicValueFactory<IGraphics.Types.Point>.CreateInstance(Dictionary<string, LoroValue> values)
	{
		return IGraphics.Types.PointExtension.Deserialize(values);
	}

	IGraphics.Types.Rect IAtomicValueFactory<IGraphics.Types.Rect>.CreateInstance(Dictionary<string, LoroValue> values)
	{
		return IGraphics.Types.RectExtension.Deserialize(values);
	}

	IGraphics.Types.Size IAtomicValueFactory<IGraphics.Types.Size>.CreateInstance(Dictionary<string, LoroValue> values)
	{
		return IGraphics.Types.SizeExtension.Deserialize(values);
	}

	IntRange IAtomicValueFactory<IntRange>.CreateInstance(Dictionary<string, LoroValue> values)
	{
		return IntRangeExtension.Deserialize(values);
	}

	Timestamp IAtomicValueFactory<Timestamp>.CreateInstance(Dictionary<string, LoroValue> values)
	{
		return TimestampExtension.Deserialize(values);
	}

	Url.Types.ExternalRelativePath.Types.MacOsExternalVolume IAtomicValueFactory<Url.Types.ExternalRelativePath.Types.MacOsExternalVolume>.CreateInstance(Dictionary<string, LoroValue> values)
	{
		return Url.Types.ExternalRelativePath.Types.MacOsExternalVolumeExtension.Deserialize(values);
	}

	Url.Types.ExternalRelativePath.Types.Win32ExternalVolume IAtomicValueFactory<Url.Types.ExternalRelativePath.Types.Win32ExternalVolume>.CreateInstance(Dictionary<string, LoroValue> values)
	{
		return Url.Types.ExternalRelativePath.Types.Win32ExternalVolumeExtension.Deserialize(values);
	}

	Url.Types.ExternalRelativePath IAtomicValueFactory<Url.Types.ExternalRelativePath>.CreateInstance(Dictionary<string, LoroValue> values)
	{
		return Url.Types.ExternalRelativePathExtension.Deserialize(values);
	}

	Url.Types.LocalRelativePath IAtomicValueFactory<Url.Types.LocalRelativePath>.CreateInstance(Dictionary<string, LoroValue> values)
	{
		return Url.Types.LocalRelativePathExtension.Deserialize(values);
	}

	Url IAtomicValueFactory<Url>.CreateInstance(Dictionary<string, LoroValue> values)
	{
		return UrlExtension.Deserialize(values);
	}

	IAction.Types.IAudienceLookType IValueFactory<IAction.Types.IAudienceLookType>.CreateInstance(LoroMap map)
	{
		return new IAction.Types.AudienceLookType(map);
	}

	IAction.Types.IAudioInputType IValueFactory<IAction.Types.IAudioInputType>.CreateInstance(LoroMap map)
	{
		return new IAction.Types.AudioInputType(map);
	}

	IAction.Types.ICaptureType.Types.ICaptureStart IValueFactory<IAction.Types.ICaptureType.Types.ICaptureStart>.CreateInstance(LoroMap map)
	{
		return new IAction.Types.ICaptureType.Types.CaptureStart(map);
	}

	IAction.Types.ICaptureType.Types.ICaptureStop IValueFactory<IAction.Types.ICaptureType.Types.ICaptureStop>.CreateInstance(LoroMap map)
	{
		return new IAction.Types.ICaptureType.Types.CaptureStop(map);
	}

	IAction.Types.ICaptureType IValueFactory<IAction.Types.ICaptureType>.CreateInstance(LoroMap map)
	{
		return new IAction.Types.CaptureType(map);
	}

	IAction.Types.IClearGroupType IValueFactory<IAction.Types.IClearGroupType>.CreateInstance(LoroMap map)
	{
		return new IAction.Types.ClearGroupType(map);
	}

	IAction.Types.ICommunicationType.Types.ICommand IValueFactory<IAction.Types.ICommunicationType.Types.ICommand>.CreateInstance(LoroMap map)
	{
		return new IAction.Types.ICommunicationType.Types.Command(map);
	}

	IAction.Types.ICommunicationType.Types.IMidiCommand IValueFactory<IAction.Types.ICommunicationType.Types.IMidiCommand>.CreateInstance(LoroMap map)
	{
		return new IAction.Types.ICommunicationType.Types.MidiCommand(map);
	}

	IAction.Types.ICommunicationType IValueFactory<IAction.Types.ICommunicationType>.CreateInstance(LoroMap map)
	{
		return new IAction.Types.CommunicationType(map);
	}

	IAction.Types.IDocumentType IValueFactory<IAction.Types.IDocumentType>.CreateInstance(LoroMap map)
	{
		return new IAction.Types.DocumentType(map);
	}

	IAction.Types.IExternalPresentationType IValueFactory<IAction.Types.IExternalPresentationType>.CreateInstance(LoroMap map)
	{
		return new IAction.Types.ExternalPresentationType(map);
	}

	IAction.Types.ILabel IValueFactory<IAction.Types.ILabel>.CreateInstance(LoroMap map)
	{
		return new IAction.Types.Label(map);
	}

	IAction.Types.IMacroType IValueFactory<IAction.Types.IMacroType>.CreateInstance(LoroMap map)
	{
		return new IAction.Types.MacroType(map);
	}

	IAction.Types.IMaskType IValueFactory<IAction.Types.IMaskType>.CreateInstance(LoroMap map)
	{
		return new IAction.Types.MaskType(map);
	}

	IAction.Types.IMediaType.Types.IAudio IValueFactory<IAction.Types.IMediaType.Types.IAudio>.CreateInstance(LoroMap map)
	{
		return new IAction.Types.IMediaType.Types.Audio(map);
	}

	IAction.Types.IMediaType.Types.IPlaybackMarker IValueFactory<IAction.Types.IMediaType.Types.IPlaybackMarker>.CreateInstance(LoroMap map)
	{
		return new IAction.Types.IMediaType.Types.PlaybackMarker(map);
	}

	IAction.Types.IMediaType IValueFactory<IAction.Types.IMediaType>.CreateInstance(LoroMap map)
	{
		return new IAction.Types.MediaType(map);
	}

	IAction.Types.IMessageType IValueFactory<IAction.Types.IMessageType>.CreateInstance(LoroMap map)
	{
		return new IAction.Types.MessageType(map);
	}

	IAction.Types.IMultiScreenType IValueFactory<IAction.Types.IMultiScreenType>.CreateInstance(LoroMap map)
	{
		return new IAction.Types.MultiScreenType(map);
	}

	IAction.Types.IPlaylistItemType IValueFactory<IAction.Types.IPlaylistItemType>.CreateInstance(LoroMap map)
	{
		return new IAction.Types.PlaylistItemType(map);
	}

	IAction.Types.IPropType.Types.IPropClear IValueFactory<IAction.Types.IPropType.Types.IPropClear>.CreateInstance(LoroMap map)
	{
		return new IAction.Types.IPropType.Types.PropClear(map);
	}

	IAction.Types.IPropType.Types.IPropTrigger IValueFactory<IAction.Types.IPropType.Types.IPropTrigger>.CreateInstance(LoroMap map)
	{
		return new IAction.Types.IPropType.Types.PropTrigger(map);
	}

	IAction.Types.IPropType IValueFactory<IAction.Types.IPropType>.CreateInstance(LoroMap map)
	{
		return new IAction.Types.PropType(map);
	}

	IAction.Types.ISlideDestinationType IValueFactory<IAction.Types.ISlideDestinationType>.CreateInstance(LoroMap map)
	{
		return new IAction.Types.SlideDestinationType(map);
	}

	IAction.Types.ISlideType IValueFactory<IAction.Types.ISlideType>.CreateInstance(LoroMap map)
	{
		return new IAction.Types.SlideType(map);
	}

	IAction.Types.IStageLayoutType IValueFactory<IAction.Types.IStageLayoutType>.CreateInstance(LoroMap map)
	{
		return new IAction.Types.StageLayoutType(map);
	}

	IAction.Types.ITimerType IValueFactory<IAction.Types.ITimerType>.CreateInstance(LoroMap map)
	{
		return new IAction.Types.TimerType(map);
	}

	IAction.Types.ITransportControlType.Types.IJumpToTime IValueFactory<IAction.Types.ITransportControlType.Types.IJumpToTime>.CreateInstance(LoroMap map)
	{
		return new IAction.Types.ITransportControlType.Types.JumpToTime(map);
	}

	IAction.Types.ITransportControlType.Types.IPause IValueFactory<IAction.Types.ITransportControlType.Types.IPause>.CreateInstance(LoroMap map)
	{
		return new IAction.Types.ITransportControlType.Types.Pause(map);
	}

	IAction.Types.ITransportControlType.Types.IPlay IValueFactory<IAction.Types.ITransportControlType.Types.IPlay>.CreateInstance(LoroMap map)
	{
		return new IAction.Types.ITransportControlType.Types.Play(map);
	}

	IAction.Types.ITransportControlType IValueFactory<IAction.Types.ITransportControlType>.CreateInstance(LoroMap map)
	{
		return new IAction.Types.TransportControlType(map);
	}

	IAction IValueFactory<IAction>.CreateInstance(LoroMap map)
	{
		return new Action(map);
	}

	IAlignmentGuide IValueFactory<IAlignmentGuide>.CreateInstance(LoroMap map)
	{
		return new AlignmentGuide(map);
	}

	IAudio.Types.IDevice.Types.IFormat IValueFactory<IAudio.Types.IDevice.Types.IFormat>.CreateInstance(LoroMap map)
	{
		return new IAudio.Types.IDevice.Types.Format(map);
	}

	IAudio.Types.IDevice IValueFactory<IAudio.Types.IDevice>.CreateInstance(LoroMap map)
	{
		return new IAudio.Types.Device(map);
	}

	IAudio.Types.ILogicalChannel.Types.IOutputChannel IValueFactory<IAudio.Types.ILogicalChannel.Types.IOutputChannel>.CreateInstance(LoroMap map)
	{
		return new IAudio.Types.ILogicalChannel.Types.OutputChannel(map);
	}

	IAudio.Types.ILogicalChannel IValueFactory<IAudio.Types.ILogicalChannel>.CreateInstance(LoroMap map)
	{
		return new IAudio.Types.LogicalChannel(map);
	}

	IAudio.Types.IOutputSetup IValueFactory<IAudio.Types.IOutputSetup>.CreateInstance(LoroMap map)
	{
		return new IAudio.Types.OutputSetup(map);
	}

	IAudio.Types.IPhysicalChannel IValueFactory<IAudio.Types.IPhysicalChannel>.CreateInstance(LoroMap map)
	{
		return new IAudio.Types.PhysicalChannel(map);
	}

	IAudio.Types.ISettingsDocument IValueFactory<IAudio.Types.ISettingsDocument>.CreateInstance(LoroMap map)
	{
		return new IAudio.Types.SettingsDocument(map);
	}

	IAudio IValueFactory<IAudio>.CreateInstance(LoroMap map)
	{
		return new Audio(map);
	}

	IAudioInput.Types.IBehaviorMode.Types.IAutoOff IValueFactory<IAudioInput.Types.IBehaviorMode.Types.IAutoOff>.CreateInstance(LoroMap map)
	{
		return new IAudioInput.Types.IBehaviorMode.Types.AutoOff(map);
	}

	IAudioInput.Types.IBehaviorMode.Types.IAutoOn IValueFactory<IAudioInput.Types.IBehaviorMode.Types.IAutoOn>.CreateInstance(LoroMap map)
	{
		return new IAudioInput.Types.IBehaviorMode.Types.AutoOn(map);
	}

	IAudioInput.Types.IBehaviorMode.Types.IOff IValueFactory<IAudioInput.Types.IBehaviorMode.Types.IOff>.CreateInstance(LoroMap map)
	{
		return new IAudioInput.Types.IBehaviorMode.Types.Off(map);
	}

	IAudioInput.Types.IBehaviorMode.Types.IOn IValueFactory<IAudioInput.Types.IBehaviorMode.Types.IOn>.CreateInstance(LoroMap map)
	{
		return new IAudioInput.Types.IBehaviorMode.Types.On(map);
	}

	IAudioInput.Types.IBehaviorMode IValueFactory<IAudioInput.Types.IBehaviorMode>.CreateInstance(LoroMap map)
	{
		return new IAudioInput.Types.BehaviorMode(map);
	}

	IAudioInput IValueFactory<IAudioInput>.CreateInstance(LoroMap map)
	{
		return new AudioInput(map);
	}

	IBackground IValueFactory<IBackground>.CreateInstance(LoroMap map)
	{
		return new Background(map);
	}

	ICcliDocument IValueFactory<ICcliDocument>.CreateInstance(LoroMap map)
	{
		return new CcliDocument(map);
	}

	ICalendar.Types.IEvent.Types.IAction.Types.IMacro IValueFactory<ICalendar.Types.IEvent.Types.IAction.Types.IMacro>.CreateInstance(LoroMap map)
	{
		return new ICalendar.Types.IEvent.Types.IAction.Types.Macro(map);
	}

	ICalendar.Types.IEvent.Types.IAction.Types.IPlaylist IValueFactory<ICalendar.Types.IEvent.Types.IAction.Types.IPlaylist>.CreateInstance(LoroMap map)
	{
		return new ICalendar.Types.IEvent.Types.IAction.Types.Playlist(map);
	}

	ICalendar.Types.IEvent.Types.IAction IValueFactory<ICalendar.Types.IEvent.Types.IAction>.CreateInstance(LoroMap map)
	{
		return new ICalendar.Types.IEvent.Types.Action(map);
	}

	ICalendar.Types.IEvent IValueFactory<ICalendar.Types.IEvent>.CreateInstance(LoroMap map)
	{
		return new ICalendar.Types.Event(map);
	}

	ICalendar IValueFactory<ICalendar>.CreateInstance(LoroMap map)
	{
		return new Calendar(map);
	}

	IClearGroupsDocument.Types.IClearGroup IValueFactory<IClearGroupsDocument.Types.IClearGroup>.CreateInstance(LoroMap map)
	{
		return new IClearGroupsDocument.Types.ClearGroup(map);
	}

	IClearGroupsDocument IValueFactory<IClearGroupsDocument>.CreateInstance(LoroMap map)
	{
		return new ClearGroupsDocument(map);
	}

	IClock.Types.IFormat IValueFactory<IClock.Types.IFormat>.CreateInstance(LoroMap map)
	{
		return new IClock.Types.Format(map);
	}

	IClock IValueFactory<IClock>.CreateInstance(LoroMap map)
	{
		return new Clock(map);
	}

	ICloudAudioInput IValueFactory<ICloudAudioInput>.CreateInstance(LoroMap map)
	{
		return new CloudAudioInput(map);
	}

	ICloudProPresenterScreen IValueFactory<ICloudProPresenterScreen>.CreateInstance(LoroMap map)
	{
		return new CloudProPresenterScreen(map);
	}

	ICloudVideoInput IValueFactory<ICloudVideoInput>.CreateInstance(LoroMap map)
	{
		return new CloudVideoInput(map);
	}

	ICollectionElementType IValueFactory<ICollectionElementType>.CreateInstance(LoroMap map)
	{
		return new CollectionElementType(map);
	}

	ICommunicationCommand.Types.IParameters IValueFactory<ICommunicationCommand.Types.IParameters>.CreateInstance(LoroMap map)
	{
		return new ICommunicationCommand.Types.Parameters(map);
	}

	ICommunicationCommand IValueFactory<ICommunicationCommand>.CreateInstance(LoroMap map)
	{
		return new CommunicationCommand(map);
	}

	ICommunicationDevice.Types.IArtnetHardware IValueFactory<ICommunicationDevice.Types.IArtnetHardware>.CreateInstance(LoroMap map)
	{
		return new ICommunicationDevice.Types.ArtnetHardware(map);
	}

	ICommunicationDevice.Types.IMidiHardware IValueFactory<ICommunicationDevice.Types.IMidiHardware>.CreateInstance(LoroMap map)
	{
		return new ICommunicationDevice.Types.MidiHardware(map);
	}

	ICommunicationDevice.Types.ISerialHardware IValueFactory<ICommunicationDevice.Types.ISerialHardware>.CreateInstance(LoroMap map)
	{
		return new ICommunicationDevice.Types.SerialHardware(map);
	}

	ICommunicationDevice.Types.ITcpHardware IValueFactory<ICommunicationDevice.Types.ITcpHardware>.CreateInstance(LoroMap map)
	{
		return new ICommunicationDevice.Types.TcpHardware(map);
	}

	ICommunicationDevice.Types.IUdpHardware IValueFactory<ICommunicationDevice.Types.IUdpHardware>.CreateInstance(LoroMap map)
	{
		return new ICommunicationDevice.Types.UdpHardware(map);
	}

	ICommunicationDevice IValueFactory<ICommunicationDevice>.CreateInstance(LoroMap map)
	{
		return new CommunicationDevice(map);
	}

	ICommunicationDeviceCloud IValueFactory<ICommunicationDeviceCloud>.CreateInstance(LoroMap map)
	{
		return new CommunicationDeviceCloud(map);
	}

	ICommunicationDeviceLocal IValueFactory<ICommunicationDeviceLocal>.CreateInstance(LoroMap map)
	{
		return new CommunicationDeviceLocal(map);
	}

	ICommunicationDeviceOption.Types.IOesProMode IValueFactory<ICommunicationDeviceOption.Types.IOesProMode>.CreateInstance(LoroMap map)
	{
		return new ICommunicationDeviceOption.Types.OesProMode(map);
	}

	ICommunicationDeviceOption IValueFactory<ICommunicationDeviceOption>.CreateInstance(LoroMap map)
	{
		return new CommunicationDeviceOption(map);
	}

	ICopyrightLayout IValueFactory<ICopyrightLayout>.CreateInstance(LoroMap map)
	{
		return new CopyrightLayout(map);
	}

	ICornerValues IValueFactory<ICornerValues>.CreateInstance(LoroMap map)
	{
		return new CornerValues(map);
	}

	ICue IValueFactory<ICue>.CreateInstance(LoroMap map)
	{
		return new Cue(map);
	}

	IDigitalAudio.Types.IBus IValueFactory<IDigitalAudio.Types.IBus>.CreateInstance(LoroMap map)
	{
		return new IDigitalAudio.Types.Bus(map);
	}

	IDigitalAudio.Types.IDevice.Types.IChannel IValueFactory<IDigitalAudio.Types.IDevice.Types.IChannel>.CreateInstance(LoroMap map)
	{
		return new IDigitalAudio.Types.IDevice.Types.Channel(map);
	}

	IDigitalAudio.Types.IDevice.Types.IFormat IValueFactory<IDigitalAudio.Types.IDevice.Types.IFormat>.CreateInstance(LoroMap map)
	{
		return new IDigitalAudio.Types.IDevice.Types.Format(map);
	}

	IDigitalAudio.Types.IDevice.Types.IMap IValueFactory<IDigitalAudio.Types.IDevice.Types.IMap>.CreateInstance(LoroMap map)
	{
		return new IDigitalAudio.Types.IDevice.Types.Map(map);
	}

	IDigitalAudio.Types.IDevice.Types.IRouting IValueFactory<IDigitalAudio.Types.IDevice.Types.IRouting>.CreateInstance(LoroMap map)
	{
		return new IDigitalAudio.Types.IDevice.Types.Routing(map);
	}

	IDigitalAudio.Types.IDevice IValueFactory<IDigitalAudio.Types.IDevice>.CreateInstance(LoroMap map)
	{
		return new IDigitalAudio.Types.Device(map);
	}

	IDigitalAudio.Types.ISetup IValueFactory<IDigitalAudio.Types.ISetup>.CreateInstance(LoroMap map)
	{
		return new IDigitalAudio.Types.Setup(map);
	}

	IDigitalAudio IValueFactory<IDigitalAudio>.CreateInstance(LoroMap map)
	{
		return new DigitalAudio(map);
	}

	IDisplayMode IValueFactory<IDisplayMode>.CreateInstance(LoroMap map)
	{
		return new DisplayMode(map);
	}

	IEdgeBlend.Types.IScreen IValueFactory<IEdgeBlend.Types.IScreen>.CreateInstance(LoroMap map)
	{
		return new IEdgeBlend.Types.Screen(map);
	}

	IEdgeBlend IValueFactory<IEdgeBlend>.CreateInstance(LoroMap map)
	{
		return new EdgeBlend(map);
	}

	IEffect.Types.IEffectVariable.Types.IEffectColor IValueFactory<IEffect.Types.IEffectVariable.Types.IEffectColor>.CreateInstance(LoroMap map)
	{
		return new IEffect.Types.IEffectVariable.Types.EffectColor(map);
	}

	IEffect.Types.IEffectVariable.Types.IEffectDirection IValueFactory<IEffect.Types.IEffectVariable.Types.IEffectDirection>.CreateInstance(LoroMap map)
	{
		return new IEffect.Types.IEffectVariable.Types.EffectDirection(map);
	}

	IEffect.Types.IEffectVariable.Types.IEffectDouble IValueFactory<IEffect.Types.IEffectVariable.Types.IEffectDouble>.CreateInstance(LoroMap map)
	{
		return new IEffect.Types.IEffectVariable.Types.EffectDouble(map);
	}

	IEffect.Types.IEffectVariable.Types.IEffectFloat IValueFactory<IEffect.Types.IEffectVariable.Types.IEffectFloat>.CreateInstance(LoroMap map)
	{
		return new IEffect.Types.IEffectVariable.Types.EffectFloat(map);
	}

	IEffect.Types.IEffectVariable.Types.IEffectInt IValueFactory<IEffect.Types.IEffectVariable.Types.IEffectInt>.CreateInstance(LoroMap map)
	{
		return new IEffect.Types.IEffectVariable.Types.EffectInt(map);
	}

	IEffect.Types.IEffectVariable IValueFactory<IEffect.Types.IEffectVariable>.CreateInstance(LoroMap map)
	{
		return new IEffect.Types.EffectVariable(map);
	}

	IEffect.Types.IPreset IValueFactory<IEffect.Types.IPreset>.CreateInstance(LoroMap map)
	{
		return new IEffect.Types.Preset(map);
	}

	IEffect IValueFactory<IEffect>.CreateInstance(LoroMap map)
	{
		return new Effect(map);
	}

	IFileProperties.Types.IRemoteProperties.Types.IProContent IValueFactory<IFileProperties.Types.IRemoteProperties.Types.IProContent>.CreateInstance(LoroMap map)
	{
		return new IFileProperties.Types.IRemoteProperties.Types.ProContent(map);
	}

	IFileProperties.Types.IRemoteProperties IValueFactory<IFileProperties.Types.IRemoteProperties>.CreateInstance(LoroMap map)
	{
		return new IFileProperties.Types.RemoteProperties(map);
	}

	IFileProperties IValueFactory<IFileProperties>.CreateInstance(LoroMap map)
	{
		return new FileProperties(map);
	}

	IGraphics.Types.IBackgroundEffect.Types.IBackgroundEffectBlur IValueFactory<IGraphics.Types.IBackgroundEffect.Types.IBackgroundEffectBlur>.CreateInstance(LoroMap map)
	{
		return new IGraphics.Types.IBackgroundEffect.Types.BackgroundEffectBlur(map);
	}

	IGraphics.Types.IBackgroundEffect.Types.IBackgroundEffectInvert IValueFactory<IGraphics.Types.IBackgroundEffect.Types.IBackgroundEffectInvert>.CreateInstance(LoroMap map)
	{
		return new IGraphics.Types.IBackgroundEffect.Types.BackgroundEffectInvert(map);
	}

	IGraphics.Types.IBackgroundEffect IValueFactory<IGraphics.Types.IBackgroundEffect>.CreateInstance(LoroMap map)
	{
		return new IGraphics.Types.BackgroundEffect(map);
	}

	IGraphics.Types.IEdgeInsets IValueFactory<IGraphics.Types.IEdgeInsets>.CreateInstance(LoroMap map)
	{
		return new IGraphics.Types.EdgeInsets(map);
	}

	IGraphics.Types.IElement IValueFactory<IGraphics.Types.IElement>.CreateInstance(LoroMap map)
	{
		return new IGraphics.Types.Element(map);
	}

	IGraphics.Types.IFeather IValueFactory<IGraphics.Types.IFeather>.CreateInstance(LoroMap map)
	{
		return new IGraphics.Types.Feather(map);
	}

	IGraphics.Types.IFill IValueFactory<IGraphics.Types.IFill>.CreateInstance(LoroMap map)
	{
		return new IGraphics.Types.Fill(map);
	}

	IGraphics.Types.IGradient.Types.IColorStop IValueFactory<IGraphics.Types.IGradient.Types.IColorStop>.CreateInstance(LoroMap map)
	{
		return new IGraphics.Types.IGradient.Types.ColorStop(map);
	}

	IGraphics.Types.IGradient IValueFactory<IGraphics.Types.IGradient>.CreateInstance(LoroMap map)
	{
		return new IGraphics.Types.Gradient(map);
	}

	IGraphics.Types.IPath.Types.IBezierPoint IValueFactory<IGraphics.Types.IPath.Types.IBezierPoint>.CreateInstance(LoroMap map)
	{
		return new IGraphics.Types.IPath.Types.BezierPoint(map);
	}

	IGraphics.Types.IPath IValueFactory<IGraphics.Types.IPath>.CreateInstance(LoroMap map)
	{
		return new IGraphics.Types.Path(map);
	}

	IGraphics.Types.IShadow IValueFactory<IGraphics.Types.IShadow>.CreateInstance(LoroMap map)
	{
		return new IGraphics.Types.Shadow(map);
	}

	IGraphics.Types.IStroke IValueFactory<IGraphics.Types.IStroke>.CreateInstance(LoroMap map)
	{
		return new IGraphics.Types.Stroke(map);
	}

	IGraphics.Types.IText.Types.IAlternateText IValueFactory<IGraphics.Types.IText.Types.IAlternateText>.CreateInstance(LoroMap map)
	{
		return new IGraphics.Types.IText.Types.AlternateText(map);
	}

	IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute IValueFactory<IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute>.CreateInstance(LoroMap map)
	{
		return new IGraphics.Types.IText.Types.IAttributes.Types.CustomAttribute(map);
	}

	IGraphics.Types.IText.Types.IAttributes.Types.IParagraph.Types.ITabStop IValueFactory<IGraphics.Types.IText.Types.IAttributes.Types.IParagraph.Types.ITabStop>.CreateInstance(LoroMap map)
	{
		return new IGraphics.Types.IText.Types.IAttributes.Types.IParagraph.Types.TabStop(map);
	}

	IGraphics.Types.IText.Types.IAttributes.Types.IParagraph.Types.ITextList IValueFactory<IGraphics.Types.IText.Types.IAttributes.Types.IParagraph.Types.ITextList>.CreateInstance(LoroMap map)
	{
		return new IGraphics.Types.IText.Types.IAttributes.Types.IParagraph.Types.TextList(map);
	}

	IGraphics.Types.IText.Types.IAttributes.Types.IParagraph IValueFactory<IGraphics.Types.IText.Types.IAttributes.Types.IParagraph>.CreateInstance(LoroMap map)
	{
		return new IGraphics.Types.IText.Types.IAttributes.Types.Paragraph(map);
	}

	IGraphics.Types.IText.Types.IAttributes.Types.IUnderline IValueFactory<IGraphics.Types.IText.Types.IAttributes.Types.IUnderline>.CreateInstance(LoroMap map)
	{
		return new IGraphics.Types.IText.Types.IAttributes.Types.Underline(map);
	}

	IGraphics.Types.IText.Types.IAttributes IValueFactory<IGraphics.Types.IText.Types.IAttributes>.CreateInstance(LoroMap map)
	{
		return new IGraphics.Types.IText.Types.Attributes(map);
	}

	IGraphics.Types.IText.Types.IChordPro IValueFactory<IGraphics.Types.IText.Types.IChordPro>.CreateInstance(LoroMap map)
	{
		return new IGraphics.Types.IText.Types.ChordPro(map);
	}

	IGraphics.Types.IText.Types.ICutOutFill IValueFactory<IGraphics.Types.IText.Types.ICutOutFill>.CreateInstance(LoroMap map)
	{
		return new IGraphics.Types.IText.Types.CutOutFill(map);
	}

	IGraphics.Types.IText.Types.IGradientFill IValueFactory<IGraphics.Types.IText.Types.IGradientFill>.CreateInstance(LoroMap map)
	{
		return new IGraphics.Types.IText.Types.GradientFill(map);
	}

	IGraphics.Types.IText.Types.ILineFillMask IValueFactory<IGraphics.Types.IText.Types.ILineFillMask>.CreateInstance(LoroMap map)
	{
		return new IGraphics.Types.IText.Types.LineFillMask(map);
	}

	IGraphics.Types.IText.Types.IMediaFill IValueFactory<IGraphics.Types.IText.Types.IMediaFill>.CreateInstance(LoroMap map)
	{
		return new IGraphics.Types.IText.Types.MediaFill(map);
	}

	IGraphics.Types.IText IValueFactory<IGraphics.Types.IText>.CreateInstance(LoroMap map)
	{
		return new IGraphics.Types.Text(map);
	}

	IGraphics IValueFactory<IGraphics>.CreateInstance(LoroMap map)
	{
		return new Graphics(map);
	}

	IGroup IValueFactory<IGroup>.CreateInstance(LoroMap map)
	{
		return new Group(map);
	}

	IHotKey IValueFactory<IHotKey>.CreateInstance(LoroMap map)
	{
		return new HotKey(map);
	}

	IKeyMapping.Types.IComputerKeyboard IValueFactory<IKeyMapping.Types.IComputerKeyboard>.CreateInstance(LoroMap map)
	{
		return new IKeyMapping.Types.ComputerKeyboard(map);
	}

	IKeyMapping.Types.IMidiKeyboard IValueFactory<IKeyMapping.Types.IMidiKeyboard>.CreateInstance(LoroMap map)
	{
		return new IKeyMapping.Types.MidiKeyboard(map);
	}

	IKeyMapping IValueFactory<IKeyMapping>.CreateInstance(LoroMap map)
	{
		return new KeyMapping(map);
	}

	IKeyMappingDocument IValueFactory<IKeyMappingDocument>.CreateInstance(LoroMap map)
	{
		return new KeyMappingDocument(map);
	}

	ILayer.Types.IBlending.Types.IMatte.Types.IAlpha IValueFactory<ILayer.Types.IBlending.Types.IMatte.Types.IAlpha>.CreateInstance(LoroMap map)
	{
		return new ILayer.Types.IBlending.Types.IMatte.Types.Alpha(map);
	}

	ILayer.Types.IBlending.Types.IMatte.Types.ILuma IValueFactory<ILayer.Types.IBlending.Types.IMatte.Types.ILuma>.CreateInstance(LoroMap map)
	{
		return new ILayer.Types.IBlending.Types.IMatte.Types.Luma(map);
	}

	ILayer.Types.IBlending.Types.IMatte.Types.IWhite IValueFactory<ILayer.Types.IBlending.Types.IMatte.Types.IWhite>.CreateInstance(LoroMap map)
	{
		return new ILayer.Types.IBlending.Types.IMatte.Types.White(map);
	}

	ILayer.Types.IBlending.Types.IMatte IValueFactory<ILayer.Types.IBlending.Types.IMatte>.CreateInstance(LoroMap map)
	{
		return new ILayer.Types.IBlending.Types.Matte(map);
	}

	ILayer.Types.IBlending.Types.IStandard IValueFactory<ILayer.Types.IBlending.Types.IStandard>.CreateInstance(LoroMap map)
	{
		return new ILayer.Types.IBlending.Types.Standard(map);
	}

	ILayer.Types.IBlending IValueFactory<ILayer.Types.IBlending>.CreateInstance(LoroMap map)
	{
		return new ILayer.Types.Blending(map);
	}

	ILayer IValueFactory<ILayer>.CreateInstance(LoroMap map)
	{
		return new Layer(map);
	}

	ILibrary.Types.ILibraryArray IValueFactory<ILibrary.Types.ILibraryArray>.CreateInstance(LoroMap map)
	{
		return new ILibrary.Types.LibraryArray(map);
	}

	ILibrary.Types.ILibraryItems IValueFactory<ILibrary.Types.ILibraryItems>.CreateInstance(LoroMap map)
	{
		return new ILibrary.Types.LibraryItems(map);
	}

	ILibrary IValueFactory<ILibrary>.CreateInstance(LoroMap map)
	{
		return new Library(map);
	}

	ILibraryItem IValueFactory<ILibraryItem>.CreateInstance(LoroMap map)
	{
		return new LibraryItem(map);
	}

	ILocalMessage IValueFactory<ILocalMessage>.CreateInstance(LoroMap map)
	{
		return new LocalMessage(map);
	}

	ILocalTimer IValueFactory<ILocalTimer>.CreateInstance(LoroMap map)
	{
		return new LocalTimer(map);
	}

	IMacrosDocument.Types.IMacro IValueFactory<IMacrosDocument.Types.IMacro>.CreateInstance(LoroMap map)
	{
		return new IMacrosDocument.Types.Macro(map);
	}

	IMacrosDocument.Types.IMacroCollection IValueFactory<IMacrosDocument.Types.IMacroCollection>.CreateInstance(LoroMap map)
	{
		return new IMacrosDocument.Types.MacroCollection(map);
	}

	IMacrosDocument IValueFactory<IMacrosDocument>.CreateInstance(LoroMap map)
	{
		return new MacrosDocument(map);
	}

	IMedia.Types.IAudio.Types.IChannel.Types.IOutput IValueFactory<IMedia.Types.IAudio.Types.IChannel.Types.IOutput>.CreateInstance(LoroMap map)
	{
		return new IMedia.Types.IAudio.Types.IChannel.Types.Output(map);
	}

	IMedia.Types.IAudio.Types.IChannel IValueFactory<IMedia.Types.IAudio.Types.IChannel>.CreateInstance(LoroMap map)
	{
		return new IMedia.Types.IAudio.Types.Channel(map);
	}

	IMedia.Types.IAudio IValueFactory<IMedia.Types.IAudio>.CreateInstance(LoroMap map)
	{
		return new IMedia.Types.Audio(map);
	}

	IMedia.Types.IAudioProperties IValueFactory<IMedia.Types.IAudioProperties>.CreateInstance(LoroMap map)
	{
		return new IMedia.Types.AudioProperties(map);
	}

	IMedia.Types.IAudioTypeProperties IValueFactory<IMedia.Types.IAudioTypeProperties>.CreateInstance(LoroMap map)
	{
		return new IMedia.Types.AudioTypeProperties(map);
	}

	IMedia.Types.IDrawingProperties IValueFactory<IMedia.Types.IDrawingProperties>.CreateInstance(LoroMap map)
	{
		return new IMedia.Types.DrawingProperties(map);
	}

	IMedia.Types.IImageTypeProperties IValueFactory<IMedia.Types.IImageTypeProperties>.CreateInstance(LoroMap map)
	{
		return new IMedia.Types.ImageTypeProperties(map);
	}

	IMedia.Types.ILiveVideoProperties IValueFactory<IMedia.Types.ILiveVideoProperties>.CreateInstance(LoroMap map)
	{
		return new IMedia.Types.LiveVideoProperties(map);
	}

	IMedia.Types.ILiveVideoTypeProperties IValueFactory<IMedia.Types.ILiveVideoTypeProperties>.CreateInstance(LoroMap map)
	{
		return new IMedia.Types.LiveVideoTypeProperties(map);
	}

	IMedia.Types.IMetadata IValueFactory<IMedia.Types.IMetadata>.CreateInstance(LoroMap map)
	{
		return new IMedia.Types.Metadata(map);
	}

	IMedia.Types.ITransportProperties IValueFactory<IMedia.Types.ITransportProperties>.CreateInstance(LoroMap map)
	{
		return new IMedia.Types.TransportProperties(map);
	}

	IMedia.Types.IVideoDevice.Types.IAirCast IValueFactory<IMedia.Types.IVideoDevice.Types.IAirCast>.CreateInstance(LoroMap map)
	{
		return new IMedia.Types.IVideoDevice.Types.AirCast(map);
	}

	IMedia.Types.IVideoDevice IValueFactory<IMedia.Types.IVideoDevice>.CreateInstance(LoroMap map)
	{
		return new IMedia.Types.VideoDevice(map);
	}

	IMedia.Types.IVideoProperties IValueFactory<IMedia.Types.IVideoProperties>.CreateInstance(LoroMap map)
	{
		return new IMedia.Types.VideoProperties(map);
	}

	IMedia.Types.IVideoTypeProperties IValueFactory<IMedia.Types.IVideoTypeProperties>.CreateInstance(LoroMap map)
	{
		return new IMedia.Types.VideoTypeProperties(map);
	}

	IMedia.Types.IWebContentTypeProperties IValueFactory<IMedia.Types.IWebContentTypeProperties>.CreateInstance(LoroMap map)
	{
		return new IMedia.Types.WebContentTypeProperties(map);
	}

	IMedia IValueFactory<IMedia>.CreateInstance(LoroMap map)
	{
		return new Media(map);
	}

	IMessage.Types.IToken.Types.ITokenTypeClock IValueFactory<IMessage.Types.IToken.Types.ITokenTypeClock>.CreateInstance(LoroMap map)
	{
		return new IMessage.Types.IToken.Types.TokenTypeClock(map);
	}

	IMessage.Types.IToken.Types.ITokenTypeText IValueFactory<IMessage.Types.IToken.Types.ITokenTypeText>.CreateInstance(LoroMap map)
	{
		return new IMessage.Types.IToken.Types.TokenTypeText(map);
	}

	IMessage.Types.IToken.Types.ITokenTypeTimer IValueFactory<IMessage.Types.IToken.Types.ITokenTypeTimer>.CreateInstance(LoroMap map)
	{
		return new IMessage.Types.IToken.Types.TokenTypeTimer(map);
	}

	IMessage.Types.IToken IValueFactory<IMessage.Types.IToken>.CreateInstance(LoroMap map)
	{
		return new IMessage.Types.Token(map);
	}

	IMessage.Types.ITokenValue.Types.ITokenValueClock IValueFactory<IMessage.Types.ITokenValue.Types.ITokenValueClock>.CreateInstance(LoroMap map)
	{
		return new IMessage.Types.ITokenValue.Types.TokenValueClock(map);
	}

	IMessage.Types.ITokenValue.Types.ITokenValueText IValueFactory<IMessage.Types.ITokenValue.Types.ITokenValueText>.CreateInstance(LoroMap map)
	{
		return new IMessage.Types.ITokenValue.Types.TokenValueText(map);
	}

	IMessage.Types.ITokenValue.Types.ITokenValueTimer IValueFactory<IMessage.Types.ITokenValue.Types.ITokenValueTimer>.CreateInstance(LoroMap map)
	{
		return new IMessage.Types.ITokenValue.Types.TokenValueTimer(map);
	}

	IMessage.Types.ITokenValue IValueFactory<IMessage.Types.ITokenValue>.CreateInstance(LoroMap map)
	{
		return new IMessage.Types.TokenValue(map);
	}

	IMessage IValueFactory<IMessage>.CreateInstance(LoroMap map)
	{
		return new Message(map);
	}

	IMessageDocument IValueFactory<IMessageDocument>.CreateInstance(LoroMap map)
	{
		return new MessageDocument(map);
	}

	IMessageLocalDocument IValueFactory<IMessageLocalDocument>.CreateInstance(LoroMap map)
	{
		return new MessageLocalDocument(map);
	}

	IMusicKeyScale IValueFactory<IMusicKeyScale>.CreateInstance(LoroMap map)
	{
		return new MusicKeyScale(map);
	}

	IOutputDisplay.Types.IBlackmagic IValueFactory<IOutputDisplay.Types.IBlackmagic>.CreateInstance(LoroMap map)
	{
		return new IOutputDisplay.Types.Blackmagic(map);
	}

	IOutputDisplay IValueFactory<IOutputDisplay>.CreateInstance(LoroMap map)
	{
		return new OutputDisplay(map);
	}

	IPlanningCenterPlan.Types.IPlanItem.Types.IAttachment IValueFactory<IPlanningCenterPlan.Types.IPlanItem.Types.IAttachment>.CreateInstance(LoroMap map)
	{
		return new IPlanningCenterPlan.Types.IPlanItem.Types.Attachment(map);
	}

	IPlanningCenterPlan.Types.IPlanItem.Types.ISongItem.Types.ISequence IValueFactory<IPlanningCenterPlan.Types.IPlanItem.Types.ISongItem.Types.ISequence>.CreateInstance(LoroMap map)
	{
		return new IPlanningCenterPlan.Types.IPlanItem.Types.ISongItem.Types.Sequence(map);
	}

	IPlanningCenterPlan.Types.IPlanItem.Types.ISongItem IValueFactory<IPlanningCenterPlan.Types.IPlanItem.Types.ISongItem>.CreateInstance(LoroMap map)
	{
		return new IPlanningCenterPlan.Types.IPlanItem.Types.SongItem(map);
	}

	IPlanningCenterPlan.Types.IPlanItem IValueFactory<IPlanningCenterPlan.Types.IPlanItem>.CreateInstance(LoroMap map)
	{
		return new IPlanningCenterPlan.Types.PlanItem(map);
	}

	IPlanningCenterPlan IValueFactory<IPlanningCenterPlan>.CreateInstance(LoroMap map)
	{
		return new PlanningCenterPlan(map);
	}

	IPlaylist.Types.IFolderDirectory IValueFactory<IPlaylist.Types.IFolderDirectory>.CreateInstance(LoroMap map)
	{
		return new IPlaylist.Types.FolderDirectory(map);
	}

	IPlaylist.Types.IPlaylistArray IValueFactory<IPlaylist.Types.IPlaylistArray>.CreateInstance(LoroMap map)
	{
		return new IPlaylist.Types.PlaylistArray(map);
	}

	IPlaylist.Types.IPlaylistItems IValueFactory<IPlaylist.Types.IPlaylistItems>.CreateInstance(LoroMap map)
	{
		return new IPlaylist.Types.PlaylistItems(map);
	}

	IPlaylist IValueFactory<IPlaylist>.CreateInstance(LoroMap map)
	{
		return new Playlist(map);
	}

	IPlaylistDocument IValueFactory<IPlaylistDocument>.CreateInstance(LoroMap map)
	{
		return new PlaylistDocument(map);
	}

	IPlaylistItem.Types.IHeader IValueFactory<IPlaylistItem.Types.IHeader>.CreateInstance(LoroMap map)
	{
		return new IPlaylistItem.Types.Header(map);
	}

	IPlaylistItem.Types.IPlaceholder IValueFactory<IPlaylistItem.Types.IPlaceholder>.CreateInstance(LoroMap map)
	{
		return new IPlaylistItem.Types.Placeholder(map);
	}

	IPlaylistItem.Types.IPlanningCenter IValueFactory<IPlaylistItem.Types.IPlanningCenter>.CreateInstance(LoroMap map)
	{
		return new IPlaylistItem.Types.PlanningCenter(map);
	}

	IPlaylistItem.Types.IPresentation IValueFactory<IPlaylistItem.Types.IPresentation>.CreateInstance(LoroMap map)
	{
		return new IPlaylistItem.Types.Presentation(map);
	}

	IPlaylistItem IValueFactory<IPlaylistItem>.CreateInstance(LoroMap map)
	{
		return new PlaylistItem(map);
	}

	IPlaylistTemplate.Types.ITemplate IValueFactory<IPlaylistTemplate.Types.ITemplate>.CreateInstance(LoroMap map)
	{
		return new IPlaylistTemplate.Types.Template(map);
	}

	IPlaylistTemplate IValueFactory<IPlaylistTemplate>.CreateInstance(LoroMap map)
	{
		return new PlaylistTemplate(map);
	}

	IPresentation.Types.IArrangement IValueFactory<IPresentation.Types.IArrangement>.CreateInstance(LoroMap map)
	{
		return new IPresentation.Types.Arrangement(map);
	}

	IPresentation.Types.IBibleReference IValueFactory<IPresentation.Types.IBibleReference>.CreateInstance(LoroMap map)
	{
		return new IPresentation.Types.BibleReference(map);
	}

	IPresentation.Types.ICcli IValueFactory<IPresentation.Types.ICcli>.CreateInstance(LoroMap map)
	{
		return new IPresentation.Types.Ccli(map);
	}

	IPresentation.Types.ICueGroup IValueFactory<IPresentation.Types.ICueGroup>.CreateInstance(LoroMap map)
	{
		return new IPresentation.Types.CueGroup(map);
	}

	IPresentation.Types.IMultiTracksLicensing IValueFactory<IPresentation.Types.IMultiTracksLicensing>.CreateInstance(LoroMap map)
	{
		return new IPresentation.Types.MultiTracksLicensing(map);
	}

	IPresentation.Types.IMusic IValueFactory<IPresentation.Types.IMusic>.CreateInstance(LoroMap map)
	{
		return new IPresentation.Types.Music(map);
	}

	IPresentation.Types.ITimeline.Types.ICue IValueFactory<IPresentation.Types.ITimeline.Types.ICue>.CreateInstance(LoroMap map)
	{
		return new IPresentation.Types.ITimeline.Types.Cue(map);
	}

	IPresentation.Types.ITimeline IValueFactory<IPresentation.Types.ITimeline>.CreateInstance(LoroMap map)
	{
		return new IPresentation.Types.Timeline(map);
	}

	IPresentation IValueFactory<IPresentation>.CreateInstance(LoroMap map)
	{
		return new Presentation(map);
	}

	IPresentationSlide.Types.INotes IValueFactory<IPresentationSlide.Types.INotes>.CreateInstance(LoroMap map)
	{
		return new IPresentationSlide.Types.Notes(map);
	}

	IPresentationSlide IValueFactory<IPresentationSlide>.CreateInstance(LoroMap map)
	{
		return new PresentationSlide(map);
	}

	IProAudienceLook.Types.IProScreenLook IValueFactory<IProAudienceLook.Types.IProScreenLook>.CreateInstance(LoroMap map)
	{
		return new IProAudienceLook.Types.ProScreenLook(map);
	}

	IProAudienceLook IValueFactory<IProAudienceLook>.CreateInstance(LoroMap map)
	{
		return new ProAudienceLook(map);
	}

	IProGroupsDocument IValueFactory<IProGroupsDocument>.CreateInstance(LoroMap map)
	{
		return new ProGroupsDocument(map);
	}

	IProLabelsDocument IValueFactory<IProLabelsDocument>.CreateInstance(LoroMap map)
	{
		return new ProLabelsDocument(map);
	}

	IProMask IValueFactory<IProMask>.CreateInstance(LoroMap map)
	{
		return new ProMask(map);
	}

	IProPresenterCommunications IValueFactory<IProPresenterCommunications>.CreateInstance(LoroMap map)
	{
		return new ProPresenterCommunications(map);
	}

	IProPresenterLocalCommunications IValueFactory<IProPresenterLocalCommunications>.CreateInstance(LoroMap map)
	{
		return new ProPresenterLocalCommunications(map);
	}

	IProPresenterLocalWorkspace IValueFactory<IProPresenterLocalWorkspace>.CreateInstance(LoroMap map)
	{
		return new ProPresenterLocalWorkspace(map);
	}

	IProPresenterScreen.Types.ICombinedArrangement IValueFactory<IProPresenterScreen.Types.ICombinedArrangement>.CreateInstance(LoroMap map)
	{
		return new IProPresenterScreen.Types.CombinedArrangement(map);
	}

	IProPresenterScreen.Types.IEdgeBlendArrangement IValueFactory<IProPresenterScreen.Types.IEdgeBlendArrangement>.CreateInstance(LoroMap map)
	{
		return new IProPresenterScreen.Types.EdgeBlendArrangement(map);
	}

	IProPresenterScreen.Types.ISingleArrangement IValueFactory<IProPresenterScreen.Types.ISingleArrangement>.CreateInstance(LoroMap map)
	{
		return new IProPresenterScreen.Types.SingleArrangement(map);
	}

	IProPresenterScreen IValueFactory<IProPresenterScreen>.CreateInstance(LoroMap map)
	{
		return new ProPresenterScreen(map);
	}

	IProPresenterWorkspace IValueFactory<IProPresenterWorkspace>.CreateInstance(LoroMap map)
	{
		return new ProPresenterWorkspace(map);
	}

	IPropDocument.Types.IPropCollection IValueFactory<IPropDocument.Types.IPropCollection>.CreateInstance(LoroMap map)
	{
		return new IPropDocument.Types.PropCollection(map);
	}

	IPropDocument IValueFactory<IPropDocument>.CreateInstance(LoroMap map)
	{
		return new PropDocument(map);
	}

	IPropSlide IValueFactory<IPropSlide>.CreateInstance(LoroMap map)
	{
		return new PropSlide(map);
	}

	IRecording.Types.IPreset IValueFactory<IRecording.Types.IPreset>.CreateInstance(LoroMap map)
	{
		return new IRecording.Types.Preset(map);
	}

	IRecording.Types.ISettingsDocument IValueFactory<IRecording.Types.ISettingsDocument>.CreateInstance(LoroMap map)
	{
		return new IRecording.Types.SettingsDocument(map);
	}

	IRecording.Types.IStream.Types.IDestination.Types.IResi IValueFactory<IRecording.Types.IStream.Types.IDestination.Types.IResi>.CreateInstance(LoroMap map)
	{
		return new IRecording.Types.IStream.Types.IDestination.Types.Resi(map);
	}

	IRecording.Types.IStream.Types.IDestination IValueFactory<IRecording.Types.IStream.Types.IDestination>.CreateInstance(LoroMap map)
	{
		return new IRecording.Types.IStream.Types.Destination(map);
	}

	IRecording.Types.IStream.Types.IDiskDestination IValueFactory<IRecording.Types.IStream.Types.IDiskDestination>.CreateInstance(LoroMap map)
	{
		return new IRecording.Types.IStream.Types.DiskDestination(map);
	}

	IRecording.Types.IStream.Types.IEncoder IValueFactory<IRecording.Types.IStream.Types.IEncoder>.CreateInstance(LoroMap map)
	{
		return new IRecording.Types.IStream.Types.Encoder(map);
	}

	IRecording.Types.IStream.Types.IOutputScreenSource IValueFactory<IRecording.Types.IStream.Types.IOutputScreenSource>.CreateInstance(LoroMap map)
	{
		return new IRecording.Types.IStream.Types.OutputScreenSource(map);
	}

	IRecording.Types.IStream.Types.IRtmpDestination IValueFactory<IRecording.Types.IStream.Types.IRtmpDestination>.CreateInstance(LoroMap map)
	{
		return new IRecording.Types.IStream.Types.RtmpDestination(map);
	}

	IRecording.Types.IStream IValueFactory<IRecording.Types.IStream>.CreateInstance(LoroMap map)
	{
		return new IRecording.Types.Stream(map);
	}

	IRecording IValueFactory<IRecording>.CreateInstance(LoroMap map)
	{
		return new Recording(map);
	}

	IScreen.Types.IAlphaSettings.Types.IAlphaDevice IValueFactory<IScreen.Types.IAlphaSettings.Types.IAlphaDevice>.CreateInstance(LoroMap map)
	{
		return new IScreen.Types.IAlphaSettings.Types.AlphaDevice(map);
	}

	IScreen.Types.IAlphaSettings IValueFactory<IScreen.Types.IAlphaSettings>.CreateInstance(LoroMap map)
	{
		return new IScreen.Types.AlphaSettings(map);
	}

	IScreen.Types.IBlendCompensation IValueFactory<IScreen.Types.IBlendCompensation>.CreateInstance(LoroMap map)
	{
		return new IScreen.Types.BlendCompensation(map);
	}

	IScreen.Types.IColorAdjustment IValueFactory<IScreen.Types.IColorAdjustment>.CreateInstance(LoroMap map)
	{
		return new IScreen.Types.ColorAdjustment(map);
	}

	IScreen IValueFactory<IScreen>.CreateInstance(LoroMap map)
	{
		return new Screen(map);
	}

	ISlide.Types.IElement.Types.IBuild IValueFactory<ISlide.Types.IElement.Types.IBuild>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.IElement.Types.Build(map);
	}

	ISlide.Types.IElement.Types.IChildBuild IValueFactory<ISlide.Types.IElement.Types.IChildBuild>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.IElement.Types.ChildBuild(map);
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IAlternateElementFill IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IAlternateElementFill>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.AlternateElementFill(map);
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IAlternateElementText IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IAlternateElementText>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.AlternateElementText(map);
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IAudioCountdown IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IAudioCountdown>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.AudioCountdown(map);
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IAutoAdvanceTimeRemaining IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IAutoAdvanceTimeRemaining>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.AutoAdvanceTimeRemaining(map);
	}

	ISlide.Types.IElement.Types.IDataLink.Types.ICcliText IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.ICcliText>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.CcliText(map);
	}

	ISlide.Types.IElement.Types.IDataLink.Types.ICaptureStatusColor IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.ICaptureStatusColor>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.CaptureStatusColor(map);
	}

	ISlide.Types.IElement.Types.IDataLink.Types.ICaptureStatusText.Types.IElapsedTime IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.ICaptureStatusText.Types.IElapsedTime>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.ICaptureStatusText.Types.ElapsedTime(map);
	}

	ISlide.Types.IElement.Types.IDataLink.Types.ICaptureStatusText.Types.IStatusText IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.ICaptureStatusText.Types.IStatusText>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.ICaptureStatusText.Types.StatusText(map);
	}

	ISlide.Types.IElement.Types.IDataLink.Types.ICaptureStatusText IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.ICaptureStatusText>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.CaptureStatusText(map);
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IChordChart IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IChordChart>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.ChordChart(map);
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IChordProChart IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IChordProChart>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.ChordProChart(map);
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IClockText IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IClockText>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.ClockText(map);
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IColorTrigger IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IColorTrigger>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.ColorTrigger(map);
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IFileFeed IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IFileFeed>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.FileFeed(map);
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IGroupColor IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IGroupColor>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.GroupColor(map);
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IGroupName IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IGroupName>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.GroupName(map);
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IOutputScreen IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IOutputScreen>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.OutputScreen(map);
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IPcoLive IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPcoLive>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.PcoLive(map);
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerIdentifier IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerIdentifier>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.PlaybackMarkerIdentifier(map);
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerText.Types.IName IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerText.Types.IName>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerText.Types.Name(map);
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerText.Types.ITime IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerText.Types.ITime>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerText.Types.Time(map);
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerText IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerText>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.PlaybackMarkerText(map);
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IPlaylistItem IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPlaylistItem>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.PlaylistItem(map);
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IPresentation IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPresentation>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.Presentation(map);
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IPresentationNotes IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IPresentationNotes>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.PresentationNotes(map);
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IRssFeed IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IRssFeed>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.RssFeed(map);
	}

	ISlide.Types.IElement.Types.IDataLink.Types.ISlideCount IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.ISlideCount>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.SlideCount(map);
	}

	ISlide.Types.IElement.Types.IDataLink.Types.ISlideImage IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.ISlideImage>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.SlideImage(map);
	}

	ISlide.Types.IElement.Types.IDataLink.Types.ISlideLabelColor IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.ISlideLabelColor>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.SlideLabelColor(map);
	}

	ISlide.Types.IElement.Types.IDataLink.Types.ISlideLabelText IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.ISlideLabelText>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.SlideLabelText(map);
	}

	ISlide.Types.IElement.Types.IDataLink.Types.ISlideText IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.ISlideText>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.SlideText(map);
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IStageMessage IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IStageMessage>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.StageMessage(map);
	}

	ISlide.Types.IElement.Types.IDataLink.Types.ITicker.Types.IFileType IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.ITicker.Types.IFileType>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.ITicker.Types.FileType(map);
	}

	ISlide.Types.IElement.Types.IDataLink.Types.ITicker.Types.IRssType IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.ITicker.Types.IRssType>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.ITicker.Types.RssType(map);
	}

	ISlide.Types.IElement.Types.IDataLink.Types.ITicker.Types.ITextType IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.ITicker.Types.ITextType>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.ITicker.Types.TextType(map);
	}

	ISlide.Types.IElement.Types.IDataLink.Types.ITicker IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.ITicker>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.Ticker(map);
	}

	ISlide.Types.IElement.Types.IDataLink.Types.ITimecodeStatus IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.ITimecodeStatus>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.TimecodeStatus(map);
	}

	ISlide.Types.IElement.Types.IDataLink.Types.ITimecodeText IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.ITimecodeText>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.TimecodeText(map);
	}

	ISlide.Types.IElement.Types.IDataLink.Types.ITimerText IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.ITimerText>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.TimerText(map);
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IVideoCountdown IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IVideoCountdown>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.VideoCountdown(map);
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IAudioCountdownVisibility IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IAudioCountdownVisibility>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.AudioCountdownVisibility(map);
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ICaptureSessionVisibility IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ICaptureSessionVisibility>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.CaptureSessionVisibility(map);
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IElementVisibility IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IElementVisibility>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ElementVisibility(map);
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ITimerVisibility IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.ITimerVisibility>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.TimerVisibility(map);
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoCountdownVisibility IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoCountdownVisibility>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.VideoCountdownVisibility(map);
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoInputVisibility IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoInputVisibility>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.VideoInputVisibility(map);
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.Condition(map);
	}

	ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink IValueFactory<ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.IElement.Types.IDataLink.Types.VisibilityLink(map);
	}

	ISlide.Types.IElement.Types.IDataLink IValueFactory<ISlide.Types.IElement.Types.IDataLink>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.IElement.Types.DataLink(map);
	}

	ISlide.Types.IElement.Types.ITextScroller IValueFactory<ISlide.Types.IElement.Types.ITextScroller>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.IElement.Types.TextScroller(map);
	}

	ISlide.Types.IElement IValueFactory<ISlide.Types.IElement>.CreateInstance(LoroMap map)
	{
		return new ISlide.Types.Element(map);
	}

	ISlide IValueFactory<ISlide>.CreateInstance(LoroMap map)
	{
		return new Slide(map);
	}

	IStage.Types.IDocument IValueFactory<IStage.Types.IDocument>.CreateInstance(LoroMap map)
	{
		return new IStage.Types.Document(map);
	}

	IStage.Types.ILayout IValueFactory<IStage.Types.ILayout>.CreateInstance(LoroMap map)
	{
		return new IStage.Types.Layout(map);
	}

	IStage.Types.IScreenAssignment IValueFactory<IStage.Types.IScreenAssignment>.CreateInstance(LoroMap map)
	{
		return new IStage.Types.ScreenAssignment(map);
	}

	IStage IValueFactory<IStage>.CreateInstance(LoroMap map)
	{
		return new Stage(map);
	}

	ITemplate.Types.IDocument IValueFactory<ITemplate.Types.IDocument>.CreateInstance(LoroMap map)
	{
		return new ITemplate.Types.Document(map);
	}

	ITemplate.Types.ISlide IValueFactory<ITemplate.Types.ISlide>.CreateInstance(LoroMap map)
	{
		return new ITemplate.Types.Slide(map);
	}

	ITemplate IValueFactory<ITemplate>.CreateInstance(LoroMap map)
	{
		return new Template(map);
	}

	ITemplateIdentification IValueFactory<ITemplateIdentification>.CreateInstance(LoroMap map)
	{
		return new TemplateIdentification(map);
	}

	ITestPattern.Types.IBlendGrid IValueFactory<ITestPattern.Types.IBlendGrid>.CreateInstance(LoroMap map)
	{
		return new ITestPattern.Types.BlendGrid(map);
	}

	ITestPattern.Types.ICustomColor IValueFactory<ITestPattern.Types.ICustomColor>.CreateInstance(LoroMap map)
	{
		return new ITestPattern.Types.CustomColor(map);
	}

	ITestPattern.Types.IIntensityColor IValueFactory<ITestPattern.Types.IIntensityColor>.CreateInstance(LoroMap map)
	{
		return new ITestPattern.Types.IntensityColor(map);
	}

	ITestPattern IValueFactory<ITestPattern>.CreateInstance(LoroMap map)
	{
		return new TestPattern(map);
	}

	ITestPatternDefinition.Types.IBoolProperty IValueFactory<ITestPatternDefinition.Types.IBoolProperty>.CreateInstance(LoroMap map)
	{
		return new ITestPatternDefinition.Types.BoolProperty(map);
	}

	ITestPatternDefinition.Types.IColorProperty IValueFactory<ITestPatternDefinition.Types.IColorProperty>.CreateInstance(LoroMap map)
	{
		return new ITestPatternDefinition.Types.ColorProperty(map);
	}

	ITestPatternDefinition.Types.IDoubleProperty IValueFactory<ITestPatternDefinition.Types.IDoubleProperty>.CreateInstance(LoroMap map)
	{
		return new ITestPatternDefinition.Types.DoubleProperty(map);
	}

	ITestPatternDefinition.Types.IFontProperty IValueFactory<ITestPatternDefinition.Types.IFontProperty>.CreateInstance(LoroMap map)
	{
		return new ITestPatternDefinition.Types.FontProperty(map);
	}

	ITestPatternDefinition.Types.IIntProperty IValueFactory<ITestPatternDefinition.Types.IIntProperty>.CreateInstance(LoroMap map)
	{
		return new ITestPatternDefinition.Types.IntProperty(map);
	}

	ITestPatternDefinition.Types.IProperty IValueFactory<ITestPatternDefinition.Types.IProperty>.CreateInstance(LoroMap map)
	{
		return new ITestPatternDefinition.Types.Property(map);
	}

	ITestPatternDefinition.Types.ISelectorProperty IValueFactory<ITestPatternDefinition.Types.ISelectorProperty>.CreateInstance(LoroMap map)
	{
		return new ITestPatternDefinition.Types.SelectorProperty(map);
	}

	ITestPatternDefinition.Types.IStringProperty IValueFactory<ITestPatternDefinition.Types.IStringProperty>.CreateInstance(LoroMap map)
	{
		return new ITestPatternDefinition.Types.StringProperty(map);
	}

	ITestPatternDefinition IValueFactory<ITestPatternDefinition>.CreateInstance(LoroMap map)
	{
		return new TestPatternDefinition(map);
	}

	ITestPatternDocument.Types.ITestPatternData.Types.IBoolProperty IValueFactory<ITestPatternDocument.Types.ITestPatternData.Types.IBoolProperty>.CreateInstance(LoroMap map)
	{
		return new ITestPatternDocument.Types.ITestPatternData.Types.BoolProperty(map);
	}

	ITestPatternDocument.Types.ITestPatternData.Types.IColorProperty IValueFactory<ITestPatternDocument.Types.ITestPatternData.Types.IColorProperty>.CreateInstance(LoroMap map)
	{
		return new ITestPatternDocument.Types.ITestPatternData.Types.ColorProperty(map);
	}

	ITestPatternDocument.Types.ITestPatternData.Types.IDoubleProperty IValueFactory<ITestPatternDocument.Types.ITestPatternData.Types.IDoubleProperty>.CreateInstance(LoroMap map)
	{
		return new ITestPatternDocument.Types.ITestPatternData.Types.DoubleProperty(map);
	}

	ITestPatternDocument.Types.ITestPatternData.Types.IFontProperty IValueFactory<ITestPatternDocument.Types.ITestPatternData.Types.IFontProperty>.CreateInstance(LoroMap map)
	{
		return new ITestPatternDocument.Types.ITestPatternData.Types.FontProperty(map);
	}

	ITestPatternDocument.Types.ITestPatternData.Types.IIntProperty IValueFactory<ITestPatternDocument.Types.ITestPatternData.Types.IIntProperty>.CreateInstance(LoroMap map)
	{
		return new ITestPatternDocument.Types.ITestPatternData.Types.IntProperty(map);
	}

	ITestPatternDocument.Types.ITestPatternData.Types.IProperty IValueFactory<ITestPatternDocument.Types.ITestPatternData.Types.IProperty>.CreateInstance(LoroMap map)
	{
		return new ITestPatternDocument.Types.ITestPatternData.Types.Property(map);
	}

	ITestPatternDocument.Types.ITestPatternData.Types.ISelectorProperty IValueFactory<ITestPatternDocument.Types.ITestPatternData.Types.ISelectorProperty>.CreateInstance(LoroMap map)
	{
		return new ITestPatternDocument.Types.ITestPatternData.Types.SelectorProperty(map);
	}

	ITestPatternDocument.Types.ITestPatternData.Types.IStringProperty IValueFactory<ITestPatternDocument.Types.ITestPatternData.Types.IStringProperty>.CreateInstance(LoroMap map)
	{
		return new ITestPatternDocument.Types.ITestPatternData.Types.StringProperty(map);
	}

	ITestPatternDocument.Types.ITestPatternData IValueFactory<ITestPatternDocument.Types.ITestPatternData>.CreateInstance(LoroMap map)
	{
		return new ITestPatternDocument.Types.TestPatternData(map);
	}

	ITestPatternDocument.Types.ITestPatternStateData IValueFactory<ITestPatternDocument.Types.ITestPatternStateData>.CreateInstance(LoroMap map)
	{
		return new ITestPatternDocument.Types.TestPatternStateData(map);
	}

	ITestPatternDocument IValueFactory<ITestPatternDocument>.CreateInstance(LoroMap map)
	{
		return new TestPatternDocument(map);
	}

	ITestPatternRenderSettings.Types.IOutput IValueFactory<ITestPatternRenderSettings.Types.IOutput>.CreateInstance(LoroMap map)
	{
		return new ITestPatternRenderSettings.Types.Output(map);
	}

	ITestPatternRenderSettings IValueFactory<ITestPatternRenderSettings>.CreateInstance(LoroMap map)
	{
		return new TestPatternRenderSettings(map);
	}

	ITestPatternState IValueFactory<ITestPatternState>.CreateInstance(LoroMap map)
	{
		return new TestPatternState(map);
	}

	ITimer.Types.IConfiguration.Types.ITimerTypeCountdown IValueFactory<ITimer.Types.IConfiguration.Types.ITimerTypeCountdown>.CreateInstance(LoroMap map)
	{
		return new ITimer.Types.IConfiguration.Types.TimerTypeCountdown(map);
	}

	ITimer.Types.IConfiguration.Types.ITimerTypeCountdownToTime IValueFactory<ITimer.Types.IConfiguration.Types.ITimerTypeCountdownToTime>.CreateInstance(LoroMap map)
	{
		return new ITimer.Types.IConfiguration.Types.TimerTypeCountdownToTime(map);
	}

	ITimer.Types.IConfiguration.Types.ITimerTypeElapsedTime IValueFactory<ITimer.Types.IConfiguration.Types.ITimerTypeElapsedTime>.CreateInstance(LoroMap map)
	{
		return new ITimer.Types.IConfiguration.Types.TimerTypeElapsedTime(map);
	}

	ITimer.Types.IConfiguration IValueFactory<ITimer.Types.IConfiguration>.CreateInstance(LoroMap map)
	{
		return new ITimer.Types.Configuration(map);
	}

	ITimer.Types.IFormat IValueFactory<ITimer.Types.IFormat>.CreateInstance(LoroMap map)
	{
		return new ITimer.Types.Format(map);
	}

	ITimer IValueFactory<ITimer>.CreateInstance(LoroMap map)
	{
		return new Timer(map);
	}

	ITimersDocument IValueFactory<ITimersDocument>.CreateInstance(LoroMap map)
	{
		return new TimersDocument(map);
	}

	ITimersLocalDocument IValueFactory<ITimersLocalDocument>.CreateInstance(LoroMap map)
	{
		return new TimersLocalDocument(map);
	}

	ITransition.Types.IPreset IValueFactory<ITransition.Types.IPreset>.CreateInstance(LoroMap map)
	{
		return new ITransition.Types.Preset(map);
	}

	ITransition IValueFactory<ITransition>.CreateInstance(LoroMap map)
	{
		return new Transition(map);
	}

	IVideoInput IValueFactory<IVideoInput>.CreateInstance(LoroMap map)
	{
		return new VideoInput(map);
	}
}
