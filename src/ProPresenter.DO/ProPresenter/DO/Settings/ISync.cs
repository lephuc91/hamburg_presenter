using System.ComponentModel;

namespace ProPresenter.DO.Settings;

public interface ISync : INotifyPropertyChanged
{
	string AccessToken { get; set; }

	string AccessTokenSecret { get; set; }

	int? AccountID { get; set; }

	bool AllowMultipleTransfer { get; set; }

	int? ApplicationID { get; set; }

	string AuthorizationInfoHash { get; set; }

	bool CloudSyncIncludeAudio { get; set; }

	bool CloudSyncIncludeLibraryDoc { get; set; }

	bool CloudSyncIncludeLibraryPlaylists { get; set; }

	bool CloudSyncIncludeMedia { get; set; }

	bool CloudSyncIncludeSupportFiles { get; set; }

	bool CloudSyncIncludeTemplates { get; set; }

	int? CollectionID { get; set; }

	FirstSyncActionType FirstSyncActionType { get; set; }

	FirstSyncMergeType FirstSyncMergeType { get; set; }

	string LastSyncDateTime { get; set; }

	bool LocalSyncDown { get; set; }

	bool LocalSyncIncludeLibraryDoc { get; set; }

	bool LocalSyncIncludeMedia { get; set; }

	bool LocalSyncIncludePlaylists { get; set; }

	bool LocalSyncIncludeTemplates { get; set; }

	bool LocalSyncIncludeUserData { get; set; }

	string LocalSyncSource { get; set; }

	bool LocalSyncUp { get; set; }

	bool PreventUploads { get; set; }

	bool ReplaceFiles { get; set; }

	bool SetupFinished { get; set; }
}
