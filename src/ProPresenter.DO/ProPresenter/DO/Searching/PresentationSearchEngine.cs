using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Threading;
using Pro.Common.Background;
using Pro.Common.Collections;
using Pro.Common.Dispatcher;
using Pro.Common.Security;
using Pro.Common.Time;
using Pro.DO.Utility;
using Pro.Search;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Indexing;
using ProPresenter.DO.Librarian;

namespace ProPresenter.DO.Searching;

public class PresentationSearchEngine : SearchEngine
{
	private static readonly TimeSlice IndexInterval = TimeSlice.FromSeconds(0.1);

	private static readonly TimeSlice DelayTime = TimeSlice.FromSeconds(1.0);

	private static readonly IEnumerable<IndexField> IndexFields = new global::_003C_003Ez__ReadOnlyArray<IndexField>(new IndexField[9]
	{
		new IndexField("Content", AnalyzerType.Simple, new SearchMatch(0.8, Pro.Search.MatchType.PhraseExact), new SearchMatch(0.3, Pro.Search.MatchType.PhraseWildcard), new SearchMatch(0.1, Pro.Search.MatchType.TermExactAny)),
		new IndexField("Name", AnalyzerType.None, new SearchMatch(0.85, Pro.Search.MatchType.PhraseExact), new SearchMatch(0.7, Pro.Search.MatchType.PhraseWildcard), new SearchMatch(0.1, Pro.Search.MatchType.TermExactAny)),
		new IndexField("Notes", 0.2, Pro.Search.MatchType.PhraseWildcard),
		new IndexField("Title", AnalyzerType.None, new SearchMatch(0.85, Pro.Search.MatchType.PhraseExact), new SearchMatch(0.7, Pro.Search.MatchType.PhraseWildcard)),
		new IndexField("Artist", 0.05, Pro.Search.MatchType.TermWildcardAny),
		new IndexField("Author", 0.05, Pro.Search.MatchType.TermWildcardAny),
		new IndexField("Copyright", 0.05, Pro.Search.MatchType.TermExactAny),
		new IndexField("Publisher", 0.05, Pro.Search.MatchType.TermWildcardAny),
		new IndexField("SongNumber", 1.0, Pro.Search.MatchType.TermExactAll)
	});

	private readonly bool _batchIndexing;

	private readonly bool _useBackgroundIndexing;

	private readonly Dictionary<IPresentationLoadData, Pro.Common.Time.Clock>? _pendingIndexUpdates;

	private readonly IIndexingService _indexingService;

	private readonly IUiDispatcher _uiDispatcher;

	protected override int IndexVersion => 1;

	public PresentationSearchEngine(IIndexingService indexingService, IUiDispatcher uiDispatcher, string? storagePath = null)
		: this(indexingService, uiDispatcher, storagePath ?? Path.Combine(CommonPaths.Temp, "SearchIndex", CommonPaths.Libraries.Hash()), batchIndexing: true, useBackgroundIndexing: true)
	{
	}

	public PresentationSearchEngine(IIndexingService indexingService, IUiDispatcher uiDispatcher, string storagePath, bool batchIndexing, bool useBackgroundIndexing)
		: base(storagePath, IndexFields, AnalyzerType.Standard)
	{
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		_indexingService = indexingService;
		_uiDispatcher = uiDispatcher;
		_batchIndexing = batchIndexing;
		_useBackgroundIndexing = useBackgroundIndexing;
		base.MaxResults = 100;
		if (_batchIndexing)
		{
			_pendingIndexUpdates = new Dictionary<IPresentationLoadData, Pro.Common.Time.Clock>();
			DispatcherTimer val = new DispatcherTimer((DispatcherPriority)4, uiDispatcher.Dispatcher)
			{
				Interval = IndexInterval
			};
			val.Tick += delegate
			{
				ProcessQueue();
			};
			val.Start();
		}
	}

	private void ProcessQueue()
	{
		IPresentationLoadData[] array = (from p in _pendingIndexUpdates
			where p.Value.ElapsedTime >= DelayTime
			select p.Key).ToArray();
		if (array.Any())
		{
			StartIndex(array, excludeIndexedIDs: false);
			array.ForEach(delegate(IPresentationLoadData c)
			{
				_pendingIndexUpdates?.Remove(c);
			});
		}
	}

	public void IndexNonIndexedItems(IEnumerable<IPresentationLoadData?>? presentationData)
	{
		StartIndex(presentationData, excludeIndexedIDs: true);
	}

	public void IndexPresentation(IPresentationLoadData presentation)
	{
		IndexPresentations(new global::_003C_003Ez__ReadOnlySingleElementList<IPresentationLoadData>(presentation));
	}

	public void IndexPresentations(IEnumerable<IPresentationLoadData> presentations)
	{
		if (_batchIndexing && _pendingIndexUpdates != null)
		{
			foreach (IPresentationLoadData presentation in presentations)
			{
				if (_pendingIndexUpdates.TryGetValue(presentation, out Pro.Common.Time.Clock value))
				{
					value.Restart();
				}
				else
				{
					_pendingIndexUpdates.Add(presentation, new Pro.Common.Time.Clock(autoStart: true));
				}
			}
			return;
		}
		StartIndex(presentations, excludeIndexedIDs: false);
	}

	private void StartIndex(IEnumerable<IPresentationLoadData?>? presentationData, bool excludeIndexedIDs)
	{
		presentationData = presentationData?.NonNull().ToArray();
		IEnumerable<IPresentationLoadData?>? enumerable = presentationData;
		if (enumerable == null || enumerable.Empty())
		{
			return;
		}
		string[] ids = presentationData.Select((IPresentationLoadData data) => data?.PresentationID.ToString()).NotNull().Distinct()
			.ToArray();
		if (_useBackgroundIndexing)
		{
			SharedWorkerPool.Queue.AddJob(delegate
			{
				OnStartIndex(ids, presentationData, excludeIndexedIDs);
			}, "Indexing Presentations", JobPriority.Low);
		}
		else
		{
			OnStartIndex(ids, presentationData, excludeIndexedIDs);
		}
	}

	private void OnStartIndex(IEnumerable<string>? ids, IEnumerable<IPresentationLoadData?>? presentationLoadData, bool excludeIndexedIDs)
	{
		_indexingService?.SetIsIndexing(isIndexing: true, ids?.Count() ?? 0);
		OnIndexPresentationLoadData(ids, presentationLoadData, excludeIndexedIDs);
		_indexingService?.SetIsIndexing(isIndexing: false);
	}

	private void OnIndexPresentationLoadData(IEnumerable<string>? ids, IEnumerable<IPresentationLoadData?>? presentationData, bool excludeIndexedIDs)
	{
		Dictionary<string, Pro.SerializationInterop.RVProtoData.Presentation> clonedPresentations = _uiDispatcher.Invoke(() => ids?.ToDictionary((string id) => id, (string id) => presentationData?.FirstOrDefault((IPresentationLoadData data) => data?.PresentationID?.ToString() == id)?.ProtoData?.Clone()));
		IndexRange(ids?.NotNull() ?? Array.Empty<string>(), delegate(string id, string fieldName)
		{
			Pro.SerializationInterop.RVProtoData.Presentation value = null;
			if (clonedPresentations != null && !clonedPresentations.TryGetValue(id, out value))
			{
				return (string?)null;
			}
			return (value == null) ? null : (fieldName switch
			{
				"Content" => string.Join(" ", value.Cues?.SelectMany((Cue cue) => cue?.Actions.Where(delegate(Pro.SerializationInterop.RVProtoData.Action action)
				{
					if (action.ActionTypeDataCase == Pro.SerializationInterop.RVProtoData.Action.ActionTypeDataOneofCase.Slide)
					{
						Pro.SerializationInterop.RVProtoData.Action.Types.SlideType slide = action.Slide;
						if (slide == null)
						{
							return false;
						}
						return slide.SlideCase == Pro.SerializationInterop.RVProtoData.Action.Types.SlideType.SlideOneofCase.Presentation;
					}
					return false;
				}).SelectMany((Pro.SerializationInterop.RVProtoData.Action action) => action.Slide?.Presentation?.BaseSlide?.Elements?.Select((Pro.SerializationInterop.RVProtoData.Slide.Types.Element element) => element?.Element_?.Text?.GetAllText()) ?? Enumerable.Empty<string>()) ?? Enumerable.Empty<string>()) ?? Enumerable.Empty<string>()), 
				"Name" => value.Name ?? string.Empty, 
				"Notes" => value.Notes ?? string.Empty, 
				"Title" => value.Ccli?.SongTitle ?? string.Empty, 
				"Artist" => value.Ccli?.ArtistCredits ?? string.Empty, 
				"Author" => value.Ccli?.Author ?? string.Empty, 
				"Copyright" => value.Ccli?.CopyrightYear.ToString() ?? string.Empty, 
				"Publisher" => value.Ccli?.Publisher ?? string.Empty, 
				"SongNumber" => value.Ccli?.SongNumber.ToString() ?? string.Empty, 
				_ => throw new NotSupportedException(), 
			});
		}, (_indexingService != null) ? new System.Action(_indexingService.IncrementCurrentIndexedCount) : null, excludeIndexedIDs);
	}

	public void RemoveIndex(DocumentCue cue)
	{
		if (cue.DocumentAction.Presentation != null)
		{
			RemoveIndex(cue.DocumentAction.Presentation.ID);
		}
	}

	public void RemoveOrphanedIndices(IEnumerable<IPresentationLoadData?>? presentationData)
	{
		IEnumerable<Guid?> existingIDs = presentationData?.Select((IPresentationLoadData data) => data?.PresentationID) ?? Enumerable.Empty<Guid?>();
		SharedWorkerPool.Queue.AddJob(delegate
		{
			RemoveIndexIf((Guid id) => !existingIDs.Contains(id));
		});
	}

	public SearchResult<DocumentCue>[] Search(string searchTerm, IEnumerable<DocumentCue> cues)
	{
		return Search(searchTerm, (Guid id) => cues.FirstOrDefault((DocumentCue p) => p.DocumentAction.Presentation != null && p.DocumentAction.Presentation.ID == id));
	}
}
