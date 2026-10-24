using System;
using System.IO;
using Pro.Common.Components;
using ProPresenter.DO.Migration.RVData;

namespace ProPresenter.DO.Migration;

public class MigrationLibrary : NotifyPropertyChangedBase
{
	private readonly RVLibraryFolder _sourceFolder;

	private bool _shouldImport = true;

	private string _targetName = string.Empty;

	public string SourceName => _sourceFolder.Name ?? string.Empty;

	public string SourceFolder => _sourceFolder.Location ?? string.Empty;

	public string TargetName
	{
		get
		{
			return _targetName;
		}
		set
		{
			SetValue("TargetName", ref _targetName, value);
		}
	}

	public bool ShouldImport
	{
		get
		{
			return _shouldImport;
		}
		set
		{
			SetValue("ShouldImport", ref _shouldImport, value);
		}
	}

	internal MigrationLibrary(RVLibraryFolder sourceFolder, string targetName)
	{
		_sourceFolder = sourceFolder;
		TargetName = targetName;
	}

	internal MigrationLibrary(string sourceFolder)
	{
		TargetName = Path.GetFileName(sourceFolder);
		_sourceFolder = new RVLibraryFolder
		{
			ID = Guid.NewGuid(),
			Location = sourceFolder,
			Name = TargetName
		};
	}
}
