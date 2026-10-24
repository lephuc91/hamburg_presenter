using System.Collections.Generic;

namespace ProPresenter.DO.Audio;

public interface IAudioInputProvider
{
	IEnumerable<AudioInput> GetAvailableInputs();
}
