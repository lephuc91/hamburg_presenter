using Pro.Serialization.Control;

namespace ProPresenter.DO.Migration.RVData;

public class RVPreferencesSynchronization
{
	[Child]
	[Alias("ReplaceFiles", typeof(bool), false)]
	public bool ReplaceFiles { get; internal set; }

	[Child]
	[Alias("Source", typeof(string), false)]
	public string? Source { get; internal set; }

	[Child]
	[Alias("SyncLibrary", typeof(bool), false)]
	public bool SyncLibrary { get; internal set; }

	[Child]
	[Alias("SyncMedia", typeof(bool), false)]
	public bool SyncMedia { get; internal set; }

	[Child]
	[Alias("SyncMode", typeof(string), false)]
	public string? SyncMode { get; internal set; }

	[Child]
	[Alias("SyncPlaylists", typeof(bool), false)]
	public bool SyncPlaylists { get; internal set; }

	[Child]
	[Alias("SyncTemplates", typeof(bool), false)]
	public bool SyncTemplates { get; internal set; }
}
