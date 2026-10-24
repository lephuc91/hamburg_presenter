using System;
using Pro.Entity.Collections;
using Pro.Entity.Merged.Collections;
using Pro.Entity.Merged.Entities;

namespace Pro.Entity.Merged.Factory;

public interface IMergedEntityFactory
{
	IMergedCollection<IMergedTimer> CreateTimerCollection(IComplexCollection<ITimer> remoteTimers, IComplexCollection<ILocalTimer> localTimers);

	IMergedTimer CreateMergedTimer(Guid id);

	IMergedCollection<IMergedScreen> CreateScreenCollection(IComplexCollection<ICloudProPresenterScreen> remoteScreens, IComplexCollection<IProPresenterScreen> localScreens);

	IMergedScreen CreateMergedScreen(Guid id, IProPresenterScreen.Types.ScreenType screenType);

	IMergedCollection<IMergedAudioInput> CreateAudioInputCollection(IComplexCollection<ICloudAudioInput> remoteAudioInputs, IComplexCollection<IAudioInput> localAudioInputs);

	IMergedAudioInput CreateMergedAudioInput(Guid id);

	IMergedCollection<IMergedVideoInput> CreateVideoInputCollection(IComplexCollection<ICloudVideoInput> remoteVideoInputs, IComplexCollection<IVideoInput> localVideoInputs);

	IMergedVideoInput CreateMergedVideoInput(Guid id);

	IMergedCollection<IMergedMessage> CreateMessageCollection(IComplexCollection<IMessage> remoteMessages, IComplexCollection<ILocalMessage> localMessages);

	IMergedMessage CreateMergedMessage(Guid id);

	IMergedProPresenterWorkspace CreateMergedProPresenterWorkspace(IProPresenterWorkspace remote, IProPresenterLocalWorkspace local);
}
