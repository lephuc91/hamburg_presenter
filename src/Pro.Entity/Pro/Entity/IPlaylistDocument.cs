using System;
using Pro.Entity.Properties;

namespace Pro.Entity;

public interface IPlaylistDocument : IEntity, IDisposable
{
	public class Types
	{
		public enum Type
		{
			Unknown,
			Presentation,
			Media,
			Audio
		}
	}

	IObservableProperty<Types.Type> Type { get; }

	IComplexObservableProperty<IPlaylist> RootNode { get; }

	IComplexObservableProperty<IPlaylist?> LiveVideoPlaylist { get; }
}
