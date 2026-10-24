using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reactive.Subjects;
using Pro.Common.Collections.Concurrency.Locking;
using Pro.Common.Dispatcher;
using Pro.Common.FileSystem;
using Pro.Common.SourceGenerator.Attributes;
using Pro.DO.Triggering;
using Pro.Text;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Import.Requests;
using ProPresenter.DO.Import.Results;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Themes;

namespace ProPresenter.DO.Import;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_missingFontsSubject", "_expectedPresentationNames", "_detectedPresentations", "_themesToCheck", "_expectedThemeNames" })]
public class FontDetectionSession : IFontDetectionSession, IDisposable
{
	private readonly IFontDetector _fontDetector;

	private readonly IUiDispatcher _dispatcher;

	private readonly IProPresenterResourceService _resourceService;

	private readonly ReplaySubject<IEnumerable<MissingFontInfo>> _missingFontsSubject;

	private readonly LockingHashSet<string> _expectedPresentationNames;

	private readonly LockingHashSet<IPresentation> _detectedPresentations = new LockingHashSet<IPresentation>();

	private readonly LockingHashSet<Theme> _themesToCheck = new LockingHashSet<Theme>();

	private readonly LockingHashSet<string> _expectedThemeNames = new LockingHashSet<string>();

	private bool _fontDetectionCompleted;

	private bool _importCanceled;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public IObservable<IEnumerable<MissingFontInfo>> WhenMissingFontsDetected => _missingFontsSubject;

	public IReadOnlyCollection<MissingFontInfo> DetectedMissingFonts { get; private set; } = (IReadOnlyCollection<MissingFontInfo>)(object)Array.Empty<MissingFontInfo>();

	public bool HasMissingFonts => DetectedMissingFonts.Count > 0;

	public bool IsDetectionComplete => _fontDetectionCompleted;

	public FontDetectionSession(IFontDetector fontDetector, IUiDispatcher dispatcher, IProPresenterResourceService resourceService)
	{
		_fontDetector = fontDetector;
		_dispatcher = dispatcher;
		_resourceService = resourceService;
		_missingFontsSubject = new ReplaySubject<IEnumerable<MissingFontInfo>>(1);
		_expectedPresentationNames = new LockingHashSet<string>(StringComparer.OrdinalIgnoreCase);
		HookIntoAllEvents();
	}

	public void TrackPresentation(IImportRequest request, IImportResult? result)
	{
		if (!(result is MemoryImportResult))
		{
			if (!(result is FileImportResult))
			{
				if (result is ThemeImportResult && request is FileImportRequest themeRequest)
				{
					HandleThemeImportCompletion(themeRequest);
				}
			}
			else if (request is FileImportRequest fileRequest)
			{
				TryAddExpectedPresentationName(fileRequest);
			}
		}
		else if (request is GeneratedPresentationRequest generatedPresentationRequest)
		{
			TryAddDetectedPresentation(generatedPresentationRequest.Presentation);
		}
	}

	private void HandleThemeImportCompletion(FileImportRequest themeRequest)
	{
		_expectedThemeNames.Add(themeRequest.Name);
	}

	public void Cancel()
	{
		_importCanceled = true;
		UnhookFromAllEvents();
		_fontDetectionCompleted = true;
		if (!_missingFontsSubject.IsDisposed)
		{
			_missingFontsSubject.OnCompleted();
		}
	}

	private void TryAddExpectedPresentationName(FileImportRequest fileRequest)
	{
		bool flag = fileRequest.ParentRequest is FileImportRequest fileImportRequest && fileImportRequest.Filename.IsProThemeFile();
		if (fileRequest.Filename.IsProPresentationFile() || flag)
		{
			_expectedPresentationNames.Add(fileRequest.FinalName);
		}
	}

	private void TryAddDetectedPresentation(IPresentation presentation)
	{
		if (_detectedPresentations.Add(presentation))
		{
			TryRunDeferredFontDetection();
		}
	}

	private void HookIntoAllEvents()
	{
		_dispatcher.Invoke(delegate
		{
			HookIntoLibraryCollectionEvents();
			HookIntoIndividualLibraryEvents();
			HookIntoThemeEvents();
		});
	}

	private void UnhookFromAllEvents()
	{
		_dispatcher.Invoke(delegate
		{
			UnhookFromLibraryCollectionEvents();
			UnhookFromIndividualLibraryEvents();
			UnhookFromThemeEvents();
		});
	}

	private void HookIntoLibraryCollectionEvents()
	{
		_resourceService.LibraryCollection.LibraryCollectionChanged += OnAnyLibraryCollectionChanged;
		INotifyCollectionChanged libraryCollection = _resourceService.LibraryCollection;
		if (libraryCollection != null)
		{
			libraryCollection.CollectionChanged += OnLibrariesCollectionChanged;
		}
	}

	private void UnhookFromLibraryCollectionEvents()
	{
		_resourceService.LibraryCollection.LibraryCollectionChanged -= OnAnyLibraryCollectionChanged;
		INotifyCollectionChanged libraryCollection = _resourceService.LibraryCollection;
		if (libraryCollection != null)
		{
			libraryCollection.CollectionChanged -= OnLibrariesCollectionChanged;
		}
	}

	private void HookIntoIndividualLibraryEvents()
	{
		foreach (ILibrary item in _resourceService.LibraryCollection)
		{
			HookIntoSingleLibraryEvents(item);
		}
	}

	private void UnhookFromIndividualLibraryEvents()
	{
		foreach (ILibrary item in _resourceService.LibraryCollection)
		{
			UnhookFromSingleLibraryEvents(item);
		}
	}

	private void HookIntoSingleLibraryEvents(ILibrary library)
	{
		if (library != null)
		{
			library.CollectionChanged += OnLibraryCollectionChanged;
		}
		if (library is Library library2)
		{
			library2.CueUpdated += OnCueUpdated;
		}
	}

	private void UnhookFromSingleLibraryEvents(ILibrary library)
	{
		if (library != null)
		{
			library.CollectionChanged -= OnLibraryCollectionChanged;
		}
		if (library is Library library2)
		{
			library2.CueUpdated -= OnCueUpdated;
		}
	}

	private void HookIntoThemeEvents()
	{
		INotifyCollectionChanged themes = _resourceService.Themes;
		if (themes != null)
		{
			themes.CollectionChanged += OnThemeCollectionChanged;
		}
	}

	private void UnhookFromThemeEvents()
	{
		INotifyCollectionChanged themes = _resourceService.Themes;
		if (themes != null)
		{
			themes.CollectionChanged -= OnThemeCollectionChanged;
		}
	}

	private void OnLibrariesCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		if (e.OldItems != null)
		{
			foreach (ILibrary oldItem in e.OldItems)
			{
				UnhookFromSingleLibraryEvents(oldItem);
			}
		}
		if (e.NewItems == null)
		{
			return;
		}
		foreach (ILibrary newItem in e.NewItems)
		{
			HookIntoSingleLibraryEvents(newItem);
		}
	}

	private void OnAnyLibraryCollectionChanged(ILibrary library, NotifyCollectionChangedEventArgs e)
	{
		OnLibraryCollectionChanged(library, e);
	}

	private void OnLibraryCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		if (!ShouldProcessEvents() || e.Action != 0 || e.NewItems == null)
		{
			return;
		}
		foreach (DocumentCue item in e.NewItems.OfType<DocumentCue>())
		{
			IPresentation presentation = item.DocumentAction?.Presentation;
			if (presentation != null)
			{
				TryTrackPresentationFromCue(presentation);
			}
		}
	}

	private void OnThemeCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		if (!ShouldProcessEvents() || e.Action != 0 || e.NewItems == null)
		{
			return;
		}
		foreach (Theme item in e.NewItems.OfType<Theme>())
		{
			_themesToCheck.Add(item);
			_expectedThemeNames.Remove(item.Name);
		}
		if (_expectedThemeNames.Count == 0)
		{
			TryRunDeferredFontDetection();
		}
	}

	private void OnCueUpdated(Cue cue)
	{
		if (ShouldProcessEvents() && cue is DocumentCue documentCue)
		{
			IDocumentAction documentAction = documentCue.DocumentAction;
			if (documentAction != null && documentAction.Presentation != null)
			{
				TryTrackPresentationFromCue(documentCue.DocumentAction.Presentation);
			}
		}
	}

	private bool ShouldProcessEvents()
	{
		if (!_fontDetectionCompleted)
		{
			return !_importCanceled;
		}
		return false;
	}

	private void TryTrackPresentationFromCue(IPresentation presentation)
	{
		if (_expectedPresentationNames.Contains(presentation.Name) && _detectedPresentations.Add(presentation))
		{
			TryRunDeferredFontDetection();
		}
	}

	private void TryRunDeferredFontDetection()
	{
		if (ShouldProcessEvents() && ShouldRunDetection())
		{
			_fontDetectionCompleted = true;
			RunFontDetection();
		}
	}

	private bool ShouldRunDetection()
	{
		if (_expectedThemeNames.Count > 0)
		{
			return false;
		}
		if (_expectedPresentationNames.Count != 0)
		{
			return AllExpectedPresentationsFound();
		}
		return HasContentToProcess();
	}

	private bool HasContentToProcess()
	{
		if (_detectedPresentations.Count <= 0)
		{
			return _themesToCheck.Count > 0;
		}
		return true;
	}

	private bool AllExpectedPresentationsFound()
	{
		HashSet<string> hashSet = _detectedPresentations.Select((IPresentation p) => p.Name).ToHashSet<string>(StringComparer.OrdinalIgnoreCase);
		return _expectedPresentationNames.All(hashSet.Contains);
	}

	private void RunFontDetection()
	{
		UnhookFromAllEvents();
		List<MissingFontInfo> list = new List<MissingFontInfo>();
		IReadOnlyCollection<MissingFontInfo> collection = _fontDetector.DetectMissingFonts(_detectedPresentations.ToArray());
		list.AddRange(collection);
		IReadOnlyCollection<MissingFontInfo> collection2 = DetectMissingFontsInThemes(_themesToCheck);
		list.AddRange(collection2);
		DetectedMissingFonts = list;
		_dispatcher.InvokeAsync(delegate
		{
			if (!_missingFontsSubject.IsDisposed)
			{
				_missingFontsSubject.OnNext(DetectedMissingFonts);
				_missingFontsSubject.OnCompleted();
			}
		});
	}

	private IReadOnlyCollection<MissingFontInfo> DetectMissingFontsInThemes(IEnumerable<Theme> themes)
	{
		List<MissingFontInfo> list = new List<MissingFontInfo>();
		foreach (Theme theme in themes)
		{
			foreach (KeyValuePair<FontInfo, int> item2 in ExtractMissingFontsFromTheme(theme))
			{
				item2.Deconstruct(out var key, out var value);
				FontInfo fontInfo = key;
				int usageCount = value;
				FontInfo? suggestedReplacement = _fontDetector.SuggestReplacement(fontInfo);
				MissingFontInfo item = new MissingFontInfo(fontInfo, suggestedReplacement, theme.Name, usageCount, MissingFontSource.Theme);
				list.Add(item);
			}
		}
		return list;
	}

	private Dictionary<FontInfo, int> ExtractMissingFontsFromTheme(Theme theme)
	{
		Dictionary<FontInfo, int> dictionary = new Dictionary<FontInfo, int>();
		foreach (TemplateSlide item in theme)
		{
			foreach (ClosedBezierPath item2 in item.Slide.Elements.OfType<ClosedBezierPath>())
			{
				foreach (RunSettings allRunSetting in item2.GetAllRunSettings())
				{
					FontInfo? missingFont = GetMissingFont(allRunSetting);
					if (missingFont.HasValue)
					{
						IncrementFontUsageCount(dictionary, missingFont.Value);
					}
				}
			}
		}
		return dictionary;
	}

	private FontInfo? GetMissingFont(RunSettings runSettings)
	{
		if (runSettings.IsFontMissing && runSettings.OriginalFont.HasValue)
		{
			FontInfo value = runSettings.OriginalFont.Value;
			if (_fontDetector.IsFontAvailable(value))
			{
				return null;
			}
			return value;
		}
		if (_fontDetector.IsFontAvailable(runSettings.Font))
		{
			return null;
		}
		return runSettings.Font;
	}

	private static void IncrementFontUsageCount(Dictionary<FontInfo, int> fontUsageMap, FontInfo font)
	{
		fontUsageMap[font] = fontUsageMap.GetValueOrDefault(font, 0) + 1;
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
			_missingFontsSubject.Dispose();
			_expectedPresentationNames.Dispose();
			_detectedPresentations.Dispose();
			_themesToCheck.Dispose();
			_expectedThemeNames.Dispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		UnhookFromAllEvents();
		_missingFontsSubject.OnCompleted();
	}
}
