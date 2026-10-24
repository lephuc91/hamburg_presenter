using System;
using System.Collections.Generic;
using Pro.Serialization.Control;

namespace ProPresenter.DO.Migration.RVData;

public class RVPreferencesGeneral
{
	private string? _ccliDisplayPositionStr;

	[Child]
	[Alias("CCLIDisplayPosition", typeof(string), false)]
	public string CCLIDisplayPositionStr
	{
		get
		{
			return _ccliDisplayPositionStr ?? string.Empty;
		}
		internal set
		{
			_ccliDisplayPositionStr = value;
			if (Enum.TryParse<CCLIDisplayPosition>(value, out var result))
			{
				CCLIDisplayPosition = result;
			}
		}
	}

	public CCLIDisplayPosition CCLIDisplayPosition { get; internal set; }

	[Child]
	[Alias("CCLINumber", typeof(string), false)]
	public string? CCLINumber { get; internal set; }

	[Child]
	[Alias("CheckForUpdates", typeof(bool), false)]
	public bool CheckForUpdates { get; internal set; }

	[Child]
	[Alias("DeinterlacedVideoPlayback", typeof(bool), false)]
	public bool DeinterlacedVideoPlayback { get; internal set; }

	[Child]
	[Alias("DisableCrashReport", typeof(bool), false)]
	public bool DisableCrashReport { get; internal set; }

	[Child]
	[Alias("EnableCCLIDisplay", typeof(bool), false)]
	public bool EnableCCLIDisplay { get; internal set; }

	[Child]
	[Alias("HasMigrationOccurred", typeof(bool), false)]
	public bool HasMigrationOccurred { get; internal set; }

	[Child]
	[Alias("HighQualityVideoback", typeof(bool), false)]
	public bool HighQualityVideoback { get; internal set; }

	[Child]
	[Alias("IsDefaultMediaLocationSet", typeof(bool), false)]
	public bool IsDefaultMediaLocationSet { get; internal set; }

	[Child]
	[Alias("IsSongSelectLogin", typeof(bool), false)]
	public bool IsSongSelectLogin { get; internal set; }

	[Child]
	[Alias("IsSyncFileBiDirectional", typeof(bool), false)]
	public bool IsSyncFileBiDirectional { get; internal set; }

	[Child]
	[Alias("IsSyncFileDown", typeof(bool), false)]
	public bool IsSyncFileDown { get; internal set; }

	[Child]
	[Alias("IsSyncFileUp", typeof(bool), false)]
	public bool IsSyncFileUp { get; internal set; }

	[Child]
	[Alias("IsTemplatesInstalled", typeof(bool), false)]
	public bool IsTemplatesInstalled { get; internal set; }

	[Child]
	[Alias("IsVIBSamplesInstalled", typeof(bool), false)]
	public bool IsVIBSamplesInstalled { get; internal set; }

	[Child]
	[Alias("IsWelcomeDocumentInstalled", typeof(bool), false)]
	public bool IsWelcomeDocumentInstalled { get; internal set; }

	[Child]
	[Alias("LastSelectedPresentationName", typeof(string), false)]
	public string? LastSelectedPresentationName { get; internal set; }

	[Collection]
	[Alias("LibraryFolders", typeof(RVLibraryFolder), false)]
	public List<RVLibraryFolder>? Folders { get; internal set; }

	[Child]
	[Alias("MediaRepositoryPath", typeof(string), false)]
	public string? MediaFolder { get; internal set; }

	[Child]
	[Alias("LogoPath", typeof(string), false)]
	public string? LogoPath { get; internal set; }

	[Child]
	[Alias("LogoPreserveAspectRatio", typeof(bool), false)]
	public bool LogoPreserveAspectRatio { get; internal set; }

	[Child]
	[Alias("ManageMediaAutomatically", typeof(bool), false)]
	public bool ManageMediaAutomatically { get; internal set; }

	[Child]
	[Alias("MaxColumn", typeof(int), false)]
	public int MaxColumn { get; internal set; }

	[Collection]
	[Alias("MediaFileSearchPaths", typeof(RVSearchPath), false)]
	public List<RVSearchPath>? MediaFileSearchPaths { get; internal set; }

	[Child]
	[Alias("OpenDefaultResourceHome", typeof(bool), false)]
	public bool OpenDefaultResourceHome { get; internal set; }

	[Child]
	[Alias("OpenInfoCenterAtLaunch", typeof(bool), false)]
	public bool OpenInfoCenterAtLaunch { get; internal set; }

	[Child]
	[Alias("PlayEveryFrameVideoPlayback", typeof(bool), false)]
	public bool PlayEveryFrameVideoPlayback { get; internal set; }

	[Child]
	[Alias("RevertButtonVisibility", typeof(string), false)]
	public string? RevertButtonVisibility { get; internal set; }

	[Child]
	[Alias("SelectedLibraryFolder", typeof(RVLibraryFolder), false)]
	public RVLibraryFolder? SelectedLibraryFolder { get; internal set; }

	[Child]
	[Alias("SongSelectToken", typeof(string), false)]
	public string? SongSelectToken { get; internal set; }

	[Child]
	[Alias("SongSelectTokenSecret", typeof(string), false)]
	public string? SongSelectTokenSecret { get; internal set; }

	[Child]
	[Alias("SongSelectVerifier", typeof(string), false)]
	public string? SongSelectVerifier { get; internal set; }

	[Child]
	[Alias("VersionToSkip", typeof(string), false)]
	public string? VersionToSkip { get; internal set; }
}
