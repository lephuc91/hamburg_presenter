using System.Collections.Generic;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Librarian;

namespace ProPresenter.DO.Events;

public record LibraryUpdated(ILibrary Library, LibraryUpdateType UpdateType, IReadOnlyList<DocumentCue> Items) : IApplicationEvent
{
	public static void Publish(ILibrary library, LibraryUpdateType updateType, IReadOnlyList<DocumentCue> items)
	{
		ApplicationEventPublisher.Publish(new LibraryUpdated(library, updateType, items));
	}
}
