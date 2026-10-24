using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO.Abstractions;
using Pro.Common.FeatureFlag;
using Pro.Common.FileSystem;
using Pro.Common.SourceGenerator.Attributes;
using Pro.DO;
using Pro.DO.Transitions;
using Pro.Serialization.DataManagement;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.CommonPathsWrapper;
using ProPresenter.DO.DependencyInjection;

namespace ProPresenter.DO.Themes;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_syncedData" })]
public sealed class ThemeProtoSyncer : IDataSyncer<Theme>, IDisposable
{
	private readonly IProtoSyncedFileData<Template.Types.Document, Theme> _syncedData;

	private readonly IProPresenterDOFactoryProvider _factoryProvider;

	private readonly ITransitionDescriptionCollection _transitionDescriptions;

	private readonly IFlagService _flagService;

	private readonly IFileSystem _fileSystem;

	private readonly Action<Theme> _onAdd;

	private readonly Action<Theme> _onRemove;

	private readonly Action<string, Theme> _updateTheme;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public ThemeProtoSyncer(ISyncDataFactory syncDataFactory, ICommonPathsWrapper commonPathsWrapper, IProPresenterDOFactoryProvider factoryProvider, ITransitionDescriptionCollection transitionDescriptions, IFlagService flagService, IFileSystem fileSystem, IFileWatcherFactory fileWatcherFactory, Action<Theme> onAdd, Action<Theme> onRemove, Action<string, Theme> updateTheme, System.Action refresh, Func<IEnumerable<Theme>> getThemes, Action<string, string> renameContainer)
	{
		_factoryProvider = factoryProvider;
		_transitionDescriptions = transitionDescriptions;
		_flagService = flagService;
		_fileSystem = fileSystem;
		_onAdd = onAdd;
		_onRemove = onRemove;
		_updateTheme = updateTheme;
		_syncedData = syncDataFactory.GetSyncedFileData<Template.Types.Document, Theme>(string.Empty, commonPathsWrapper.Themes, SyncedFileParse, SyncedFileLoaded, SyncedFileDeleted, SyncedFileRenamed, SyncedFileUpdated, null, GetFilePrefix);
		new ThemeFolderWatcher(fileWatcherFactory, fileSystem, refresh, _syncedData.AddSyncedFile, Remove, getThemes, delegate(string n, Theme t)
		{
			_syncedData.UpdateSyncedFile(n, t);
		}, renameContainer);
	}

	public void Add(Theme model)
	{
		model.DataModified += OnDataModified;
		model.Renamed += OnThemeRenamed;
		string themeFilename = GetThemeFilename(model);
		_syncedData.AddSyncedFile(themeFilename, model.Serialize(), model);
	}

	private void OnDataModified(string propName, Theme model, TemplateSlide? slide)
	{
		_syncedData.UpdateSyncedFile(model.Serialize(), model);
		_updateTheme(propName, model);
	}

	private void OnThemeRenamed(Theme theme)
	{
		_syncedData?.RenameSyncedFile(theme, theme.Name);
	}

	public void Remove(Theme model)
	{
		model.DataModified -= OnDataModified;
		model.Renamed -= OnThemeRenamed;
		_syncedData.DeleteSyncedFile(model);
	}

	private Theme SyncedFileParse(IProtoSyncedFileData<Template.Types.Document, Theme> sender, string filename, Template.Types.Document data)
	{
		Theme theme = new Theme(_factoryProvider, _transitionDescriptions, _flagService, filename.GetDirectoryNameWithoutPath() ?? string.Empty, GetFilePrefix(filename), null);
		theme.Deserialize(data);
		return theme;
	}

	private void SyncedFileLoaded(IProtoSyncedFileData<Template.Types.Document, Theme> sender, Theme model)
	{
		AddTheme(model);
	}

	private void SyncedFileDeleted(IProtoSyncedFileData<Template.Types.Document, Theme> sender, string filename, Theme model)
	{
		RemoveTheme(model);
	}

	private void SyncedFileRenamed(IProtoSyncedFileData<Template.Types.Document, Theme> sender, string oldFilename, string newFilename, Theme model)
	{
		string themeFilename = GetThemeFilename(model);
		if (newFilename != themeFilename)
		{
			RemoveTheme(model);
		}
		else
		{
			AddTheme(model);
		}
	}

	private void AddTheme(Theme model)
	{
		model.DataModified += OnDataModified;
		model.Renamed += OnThemeRenamed;
		_onAdd(model);
	}

	private void RemoveTheme(Theme model)
	{
		model.DataModified -= OnDataModified;
		model.Renamed -= OnThemeRenamed;
		_onRemove(model);
	}

	private void SyncedFileUpdated(IProtoSyncedFileData<Template.Types.Document, Theme> sender, string filename, Template.Types.Document data, Theme model)
	{
		model.DataModified -= OnDataModified;
		model.Deserialize(data);
		model.DataModified += OnDataModified;
	}

	private string GetFilePrefix(string filename)
	{
		return _fileSystem.Path.GetDirectoryName(filename) ?? string.Empty;
	}

	private string GetThemeFilename(Theme theme)
	{
		return _fileSystem.Path.Combine(theme.Path, "Theme").Replace(_fileSystem.Path.DirectorySeparatorChar, _fileSystem.Path.AltDirectorySeparatorChar);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			_syncedData.Dispose();
		}
	}
}
