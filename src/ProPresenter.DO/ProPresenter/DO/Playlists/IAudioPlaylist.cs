using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.DO.Triggering;
using ProPresenter.DO.Cues;

namespace ProPresenter.DO.Playlists;

public interface IAudioPlaylist : IPlaylist<MediaCue>, ITriggerable, IIdentifiable, INotifyPropertyChanged, ICloneable<IPlaylist<MediaCue>>, IDragDropTreeCollection<IPlaylist<MediaCue>>, ITreeNode<IPlaylist<MediaCue>>, IEnumerable<MediaCue>, IEnumerable, IDragDropNotifyEnumerableChanged<MediaCue>, INotifyEnumerableChanged<MediaCue>, INotifyCollectionChanged, IDragDropCollection<MediaCue>
{
}
