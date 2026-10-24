using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO.Abstractions;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Dispatcher;
using Pro.Common.FeatureFlag;
using Pro.Common.FileSystem;
using Pro.Common.Mathematics;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Utility;
using Pro.DO;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using Pro.Entity.Persistence;
using ProPresenter.DO.ChangeDirectory;
using ProPresenter.DO.CommonPathsWrapper;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Slide.Custom;

namespace ProPresenter.DO.Themes;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_syncer" })]
public class ThemeCollection : ImmutableObservableCollection<Theme>, IThemeCollection, IImmutableObservableCollection<Theme>, IReadOnlyList<Theme>, IEnumerable<Theme>, IEnumerable, IReadOnlyCollection<Theme>, INotifyEnumerableChanged<Theme>, INotifyCollectionChanged, INotifyPropertyChanged, IDisposable
{
	private readonly Lazy<Theme> _defaultTheme;

	private readonly Lazy<Theme> _bibleTheme;

	private readonly Lazy<Theme> _stageTheme;

	private readonly ISyncDataFactory _syncDataFactory;

	private readonly IProPresenterDOFactoryProvider _factoryProvider;

	private readonly ITransitionDescriptionCollection _transitionDescriptions;

	private readonly IFlagService _flagService;

	private readonly IUiScheduler _scheduler;

	private readonly IActionBinderFactory _actionBinderFactory;

	private readonly ICommonPathsWrapper _commonPathsWrapper;

	private readonly IFileSystem _fileSystem;

	private readonly IFileWatcherFactory _fileSystemWatcherFactory;

	private readonly ICollectionStorage _collectionStorage;

	private ThemeContainer? _themeTree;

	private IDataSyncer<Theme>? _syncer;

	private int _themeCount;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public Theme DefaultTheme => _defaultTheme.Value;

	public Theme DefaultBibleTheme => _bibleTheme.Value;

	public Theme StageTheme => _stageTheme.Value;

	public ThemeContainer? ThemeTree
	{
		get
		{
			return _themeTree;
		}
		[MemberNotNull("_themeTree")]
		private set
		{
			SetValue("ThemeTree", ref _themeTree, value);
		}
	}

	public event Action<Theme, TemplateSlide?>? ThemeDataModified;

	public ThemeCollection(ISyncDataFactory syncDataFactory, IProPresenterDOFactoryProvider factoryProvider, ITransitionDescriptionCollection transitionDescriptions, IFlagService flagService, IUiScheduler scheduler, IActionBinderFactory actionBinderFactory, ICommonPathsWrapper commonPathsWrapper, IFileSystem fileSystem, IFileWatcherFactory fileSystemWatcherFactory, ICollectionStorage collectionStorage, bool loadLegacy)
	{
		ThemeCollection themeCollection = this;
		_syncDataFactory = syncDataFactory;
		_factoryProvider = factoryProvider;
		_transitionDescriptions = transitionDescriptions;
		_flagService = flagService;
		_scheduler = scheduler;
		_actionBinderFactory = actionBinderFactory;
		_commonPathsWrapper = commonPathsWrapper;
		_fileSystem = fileSystem;
		_fileSystemWatcherFactory = fileSystemWatcherFactory;
		_collectionStorage = collectionStorage;
		_stageTheme = new Lazy<Theme>(() => new StageTheme(factoryProvider, transitionDescriptions, flagService));
		_defaultTheme = new Lazy<Theme>(() => TemplateHelper.GenerateDefaultTheme(themeCollection._factoryProvider, themeCollection._transitionDescriptions, themeCollection._flagService));
		_bibleTheme = new Lazy<Theme>(() => TemplateHelper.GenerateDefaultBibleTheme(themeCollection._factoryProvider, themeCollection._transitionDescriptions, themeCollection._flagService));
		SetupDocumentSyncer(loadLegacy);
		ChangeDirectoryPrompt.RegisterDelegate(new ChangeDirectoryListener(TeardownDocumentSyncer, SetupDocumentSyncer));
	}

	private void HandleDataModified(string propName, Theme theme, TemplateSlide? slide)
	{
		this.ThemeDataModified?.Invoke(theme, slide);
	}

	private void TeardownDocumentSyncer()
	{
		_syncer?.Dispose();
		_syncer = null;
	}

	private void SetupDocumentSyncer(bool loadLegacy)
	{
		IDataSyncer<Theme> syncer;
		if (!_flagService.IsFlagEnabled(Flag.Cloud))
		{
			IDataSyncer<Theme> dataSyncer = new ThemeProtoSyncer(_syncDataFactory, _commonPathsWrapper, _factoryProvider, _transitionDescriptions, _flagService, _fileSystem, _fileSystemWatcherFactory, delegate(Theme t)
			{
				if (!base.Collection.Any((Theme i) => i.Name == t.Name))
				{
					base.Collection.Add(t);
					OnAddTheme(t);
				}
			}, OnRemoveTheme, UpdateTheme, Refresh, () => base.Collection, delegate(string o, string n)
			{
				ThemeTree?.RenameContainer(o, _fileSystem.Path.GetFileName(n));
				Sort();
			});
			syncer = dataSyncer;
		}
		else
		{
			IDataSyncer<Theme> dataSyncer = new ThemeEntitySyncer(_factoryProvider, _transitionDescriptions, _flagService, _commonPathsWrapper, _fileSystem, _scheduler, _actionBinderFactory, _collectionStorage, delegate(Theme t)
			{
				base.Collection.Add(t);
				OnAddTheme(t);
			}, OnRemoveTheme, loadLegacy);
			syncer = dataSyncer;
		}
		_syncer = syncer;
		InitializeTree();
	}

	[MemberNotNull("ThemeTree")]
	private void InitializeTree()
	{
		BuildTree();
	}

	[MemberNotNull("ThemeTree")]
	public void BuildTree()
	{
		ThemeContainer themeTree = ThemeContainer.GenerateContainers(this);
		ThemeTree = themeTree;
	}

	public TemplateSlide? FindTemplate(Guid id, string name = "", bool useDefault = true)
	{
		TemplateSlide templateSlide = base.Collection.SelectMany((Theme p) => p).FirstOrDefault((TemplateSlide t) => t.Slide.ID == id);
		if (templateSlide == null && !string.IsNullOrWhiteSpace(name))
		{
			templateSlide = base.Collection.SelectMany((Theme p) => p).FirstOrDefault((TemplateSlide t) => t.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
		}
		if (templateSlide == null && useDefault)
		{
			templateSlide = DefaultTheme[0];
		}
		return templateSlide;
	}

	public bool DoesTemplateSlideExist(Guid templateSlideID)
	{
		return FindTemplate(templateSlideID, "", useDefault: false) != null;
	}

	public bool DoesThemeExist(string name)
	{
		return base.Collection.Any((Theme g) => g.Name == name);
	}

	public void Add(string themeName, string? path = null)
	{
		Add(themeName, new global::_003C_003Ez__ReadOnlySingleElementList<TemplateSlide>(new TemplateSlide(_factoryProvider, _transitionDescriptions, _flagService, addDefaultShape: true)), path);
	}

	public void Add(string themeName, IEnumerable<TemplateSlide> templateSlides, string? path = null)
	{
		Insert(base.Collection.Count, themeName, templateSlides, path);
	}

	public void Add(string themeName, IEnumerable<CustomSlide> slides, string? path = null)
	{
		Add(themeName, slides.Select((CustomSlide s) => new TemplateSlide(_factoryProvider, s, _flagService)), path);
	}

	public void Insert(int index, string themeName, IEnumerable<TemplateSlide> templateSlides, string? path = null)
	{
		if (index.IsInRangeInclusive(0, base.Collection.Count))
		{
			path = path ?? themeName;
			Theme theme = new Theme(_factoryProvider, _transitionDescriptions, _flagService, themeName, path, null);
			theme.UndoStack.StartIgnoring();
			theme.Add(templateSlides);
			_syncer?.Add(theme);
			base.Collection.Insert(index, theme);
			OnAddTheme(theme);
			theme.UndoStack.StopIgnoring();
		}
	}

	private void OnAddTheme(Theme theme)
	{
		theme.DataModified += HandleDataModified;
		Sort();
	}

	private void OnRemoveTheme(Theme theme)
	{
		theme.DataModified -= HandleDataModified;
		theme.Dispose();
		base.Collection.Remove(theme);
	}

	private void UpdateTheme(string propName, Theme theme)
	{
		int num = this.Sum((Theme t) => t.Count);
		if (_themeCount != num)
		{
			OnPropertyChanged(propName);
		}
		_themeCount = num;
	}

	public void Remove(Theme theme)
	{
		if (theme != null)
		{
			OnRemoveTheme(theme);
			_syncer?.Remove(theme);
		}
	}

	public void Refresh()
	{
		TeardownDocumentSyncer();
		SetupDocumentSyncer(loadLegacy: true);
		OnRefresh();
	}

	protected virtual void OnRefresh()
	{
	}

	public void Sort()
	{
		NaturalStringComparer comparer = new NaturalStringComparer();
		base.Collection.SelectionSort((Theme lhs, Theme rhs) => comparer.Compare(lhs.Path, rhs.Path) > 0, base.Collection.Move);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			OnDispose();
			_syncer?.Dispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		ChangeDirectoryPrompt.UnregisterDelegate(new ChangeDirectoryListener(TeardownDocumentSyncer, SetupDocumentSyncer));
	}
}
