using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using Pro.Common.Collections;
using Pro.Search;
using ProPresenter.DO;
using ProPresenter.UI.ViewModels.Settings.Search;

namespace ProPresenter.ViewModels.Settings.Search;

public class SettingsSearchEngine : SearchEngine, ISettingsSearchEngine
{
	private const string SEARCH_INDEX_FOLDER = "SettingsSearchIndex";

	private const string SEARCH_FIELD = "FieldName";

	private static readonly IEnumerable<IndexField> SearchIndexFields = new IndexField[1]
	{
		new IndexField("SEARCH_FIELD", AnalyzerType.Simple, new SearchMatch(0.8, MatchType.PhraseExact), new SearchMatch(0.3, MatchType.PhraseWildcard), new SearchMatch(0.1, MatchType.TermExactAny))
	};

	private Dictionary<string, ISettingsSearchPageField> _searchFieldMap = new Dictionary<string, ISettingsSearchPageField>();

	protected override int IndexVersion => -1;

	public SettingsSearchEngine(IEnumerable<ISettingsSearchPage> pages, IFileSystem fileSystem)
		: this(pages, fileSystem.Path.Combine(CommonPaths.Temp, "SettingsSearchIndex"))
	{
	}

	public SettingsSearchEngine(IEnumerable<ISettingsSearchPage> pages, string storagePath)
		: base(storagePath, SearchIndexFields, AnalyzerType.Standard)
	{
		DoIndexPages(pages);
	}

	private void DoIndexPages(IEnumerable<ISettingsSearchPage> pages)
	{
		_searchFieldMap = pages.NonNull().SelectMany((ISettingsSearchPage p) => p.Fields.NonNull()).ToDictionary(GenerateId);
		IndexRange(_searchFieldMap.Select<KeyValuePair<string, ISettingsSearchPageField>, string>((KeyValuePair<string, ISettingsSearchPageField> f) => f.Key), (string fieldId, string field) => _searchFieldMap.TryGetValue(fieldId, out ISettingsSearchPageField value) ? ((field == "SEARCH_FIELD") ? value.Value : string.Empty) : string.Empty);
	}

	public void IndexPages(IEnumerable<ISettingsSearchPage> pages)
	{
		ClearIndices();
		DoIndexPages(pages);
	}

	private void ClearIndices()
	{
		_searchFieldMap.ForEach<KeyValuePair<string, ISettingsSearchPageField>>(delegate(KeyValuePair<string, ISettingsSearchPageField> k)
		{
			RemoveIndex(k.Key);
		});
		_searchFieldMap.Clear();
	}

	public IEnumerable<ISettingsSearchPageField> Search(string searchTerm)
	{
		ISettingsSearchPageField value;
		return (from s in Search(searchTerm, (string id) => (!_searchFieldMap.TryGetValue(id, out value)) ? null : value)
			select s.Item).NonNull().Distinct();
	}

	private static string GenerateId(ISettingsSearchPageField field)
	{
		return $"{field.Page.ID}_{field.ID}";
	}
}
