using Pro.Common.Components;
using Pro.DO.Storage;
using ProPresenter.DO.Actions;

namespace ProPresenter.DO.Cues;

public interface IMediaCue : IFileResource, IHasMediaContainerId
{
	string Name { get; }

	MediaAction? MediaAction { get; }
}
