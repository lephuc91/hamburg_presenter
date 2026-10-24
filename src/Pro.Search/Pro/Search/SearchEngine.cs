using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Lucene.Net.Analysis;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Lucene.Net.Util;
using Pro.Common.Collections;
using Pro.Common.Logging;
using Pro.Common.Mathematics;

namespace Pro.Search;

public abstract class SearchEngine
{
	private const string IDFieldName = "id";

	private const Lucene.Net.Util.Version LuceneVersion = Lucene.Net.Util.Version.LUCENE_30;

	private const float DefaultBoost = 1f;

	private const string VersionFilename = "version";

	protected const int DefaultIndexVersion = -1;

	private readonly FSDirectory _directory;

	private readonly IEnumerable<IndexField> _indexFields;

	private readonly IAnalyzerFactory _analyzerFactory;

	private readonly AnalyzerType _defaultAnalyzerType;

	public string StoragePath { get; }

	protected int MaxResults { get; set; } = int.MaxValue;

	protected abstract int IndexVersion { get; }

	private string VersionFile => Path.Combine(StoragePath, "version");

	private bool StorageDirectoryExists => System.IO.Directory.Exists(StoragePath);

	protected SearchEngine(string storagePath, IEnumerable<IndexField> indexFields, AnalyzerType defaultAnalyzerType, IAnalyzerFactory? analyzerFactory = null)
	{
		if (defaultAnalyzerType == AnalyzerType.Default)
		{
			throw new ArgumentException("defaultAnalyzerType");
		}
		StoragePath = storagePath;
		_directory = FSDirectory.Open(StoragePath);
		if (GetCurrentIndexVersion() < IndexVersion)
		{
			ResetIndexDirectory();
		}
		_indexFields = indexFields;
		_defaultAnalyzerType = defaultAnalyzerType;
		_analyzerFactory = analyzerFactory ?? new AnalyzerFactory(Lucene.Net.Util.Version.LUCENE_30);
		SaveCurrentIndexVersion();
	}

	protected void Index(Guid id, Func<string, string, string> getField)
	{
		Index(id.ToString(), getField);
	}

	protected void Index(string id, Func<string, string, string> getField)
	{
		IndexRange(new string[1] { id }, getField);
	}

	protected void IndexRange(IEnumerable<string> ids, Func<string, string, string?> getField, Action? incrementCurrentIndexedCount = null, bool excludeIndexedIDs = true)
	{
		lock (_directory)
		{
			try
			{
				write();
			}
			catch (Exception)
			{
				Log.Warning("Corrupted index detected -- attempting to clean and reset index (" + StoragePath + ")");
				ResetIndexDirectory();
				write();
			}
			SaveCurrentIndexVersion();
		}
		IEnumerable<string> getFilteredIDs()
		{
			if (!excludeIndexedIDs)
			{
				return ids.Distinct();
			}
			IndexReader reader = GetIndexReader();
			try
			{
				return ids.Where((string id) => !excludeIndexedIDs || !IsIndexed(reader, id)).Distinct().ToArray();
			}
			finally
			{
				if (reader != null)
				{
					((IDisposable)reader).Dispose();
				}
			}
		}
		void write()
		{
			IEnumerable<string> enumerable = getFilteredIDs();
			Analyzer analyzer = _analyzerFactory.Get(_defaultAnalyzerType, AnalyzerType.Default);
			using IndexWriter indexWriter = new IndexWriter(_directory, analyzer, IndexWriter.MaxFieldLength.UNLIMITED);
			foreach (string item in enumerable)
			{
				incrementCurrentIndexedCount?.Invoke();
				PerFieldAnalyzerWrapper perFieldAnalyzerWrapper = new PerFieldAnalyzerWrapper(analyzer);
				Document document = new Document();
				document.Add(new Field("id", item, Field.Store.YES, Field.Index.NOT_ANALYZED_NO_NORMS));
				foreach (IndexField indexField in _indexFields)
				{
					string text = getField(item, indexField.Name);
					if (text != null)
					{
						string text2 = StripData(text);
						Analyzer analyzer2 = _analyzerFactory.Get(_defaultAnalyzerType, indexField.AnalyzerType, text2);
						perFieldAnalyzerWrapper.AddAnalyzer(indexField.Name, analyzer2);
						document.Add(new Field(indexField.Name, text2, Field.Store.YES, (analyzer2 != null) ? Field.Index.ANALYZED_NO_NORMS : Field.Index.NOT_ANALYZED_NO_NORMS));
					}
				}
				indexWriter.UpdateDocument(new Term("id", document.Get("id")), document, perFieldAnalyzerWrapper);
			}
			try
			{
				indexWriter.Optimize(doWait: true);
			}
			catch (Exception)
			{
				indexWriter.Rollback();
				throw;
			}
		}
	}

	protected void RemoveIndex(Guid id)
	{
		RemoveIndex(id.ToString());
	}

	protected void RemoveIndex(string id)
	{
		RemoveIndexIf((string s) => s == id);
	}

	protected void RemoveIndexIf(Predicate<Guid> predicate)
	{
		RemoveIndexIf(predicate, (string t) => (!Guid.TryParse(t, out var result)) ? Guid.Empty : result);
	}

	protected void RemoveIndexIf(Predicate<string> predicate)
	{
		RemoveIndexIf(predicate, (string t) => t);
	}

	protected void RemoveIndexIf<T>(Predicate<T> predicate, Func<string, T> converter)
	{
		lock (_directory)
		{
			using IndexReader indexReader = GetIndexReader(readOnly: false);
			if (indexReader == null)
			{
				return;
			}
			for (int i = 0; i < indexReader.MaxDoc; i++)
			{
				if (!indexReader.IsDeleted(i))
				{
					Document document = indexReader.Document(i);
					T obj = converter(document.Get("id"));
					if (predicate(obj))
					{
						indexReader.DeleteDocument(i);
					}
				}
			}
		}
	}

	protected bool IsIndexed(Guid id)
	{
		return IsIndexed(id.ToString());
	}

	protected bool IsIndexed(string id)
	{
		using IndexReader reader = GetIndexReader();
		return IsIndexed(reader, id);
	}

	private bool IsIndexed(IndexReader? reader, string id)
	{
		return reader?.TermDocs(new Term("id", id)).Next() ?? false;
	}

	protected SearchResult<T>[] Search<T>(string queryText, Func<Guid, T?> dataCallback)
	{
		return Search(queryText, (string t) => dataCallback(Guid.Parse(t)));
	}

	protected SearchResult<T>[] Search<T>(string queryText, Func<string, T?> dataCallback)
	{
		SearchResult<T>[] array = null;
		using (IndexSearcher indexSearcher = GetIndexSearcher())
		{
			if (indexSearcher == null)
			{
				return Array.Empty<SearchResult<T>>();
			}
			ScoreDoc[] scoreDocs = indexSearcher.Search(BuildQuery(queryText), null, MaxResults).ScoreDocs;
			array = ParseScoreDocs(scoreDocs, indexSearcher, dataCallback);
		}
		NormalizeScores(array);
		return array;
	}

	private IndexSearcher? GetIndexSearcher()
	{
		IndexReader indexReader = GetIndexReader();
		if (indexReader == null)
		{
			return null;
		}
		IndexSearcher indexSearcher = new IndexSearcher(indexReader);
		indexSearcher.SetDefaultFieldSortScoring(doTrackScores: true, doMaxScore: true);
		return indexSearcher;
	}

	private IndexReader? GetIndexReader(bool readOnly = true)
	{
		try
		{
			if (StorageDirectoryExists)
			{
				return IndexReader.Open(_directory, readOnly);
			}
		}
		catch (IOException ex)
		{
			Log.Error("IO error occurred when opening an index reader -- {0}", ex);
		}
		return null;
	}

	private static string StripData(string data)
	{
		return new string(data.Where((char c) => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c)).ToArray());
	}

	private Query BuildQuery(string queryText)
	{
		string[] array = StripData(queryText.Trim().ToLowerInvariant()).Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
		if (array.Length == 0)
		{
			return new BooleanQuery(disableCoord: false);
		}
		string currentWord = array.Last();
		string[] array2 = array.TakeWhile((string w) => w != currentWord).ToArray();
		BooleanQuery booleanQuery = new BooleanQuery();
		foreach (IndexField indexField in _indexFields)
		{
			SearchMatch[] searchMatches = indexField.SearchMatches;
			for (int i = 0; i < searchMatches.Length; i++)
			{
				SearchMatch match = searchMatches[i];
				using IEnumerator<MatchType> enumerator2 = (from m in Enum.GetValues<MatchType>()
					where m != 0 && match.MatchType.HasFlag(m)
					select m).GetEnumerator();
				while (enumerator2.MoveNext())
				{
					switch (enumerator2.Current)
					{
					case MatchType.TermExactAny:
						booleanQuery.Add(BuildTermQuery(indexField, match, array, isWildcard: false, matchAll: false), Occur.SHOULD);
						break;
					case MatchType.TermExactAll:
						booleanQuery.Add(BuildTermQuery(indexField, match, array, isWildcard: false, matchAll: true), Occur.SHOULD);
						break;
					case MatchType.TermWildcardAny:
						booleanQuery.Add(BuildTermQuery(indexField, match, array, isWildcard: true, matchAll: false), Occur.SHOULD);
						break;
					case MatchType.TermWildcardAll:
						booleanQuery.Add(BuildTermQuery(indexField, match, array, isWildcard: true, matchAll: true), Occur.SHOULD);
						break;
					case MatchType.PhraseExact:
						booleanQuery.Add(BuildPhraseQuery(indexField, match, array), Occur.SHOULD);
						break;
					case MatchType.PhraseWildcard:
					{
						WildcardQuery wildcardQuery = new WildcardQuery(new Term(indexField.Name, currentWord + "*"));
						if (array2.Length != 0)
						{
							BooleanQuery booleanQuery2 = new BooleanQuery
							{
								Boost = (float)match.Weight
							};
							if (array2.Length > 1)
							{
								booleanQuery2.Add(BuildPhraseQuery(indexField, match, array2, applyBoost: false), Occur.MUST);
							}
							else
							{
								booleanQuery2.Add(new TermQuery(new Term(indexField.Name, array2[0])), Occur.MUST);
							}
							booleanQuery2.Add(wildcardQuery, Occur.MUST);
							booleanQuery.Add(booleanQuery2, Occur.SHOULD);
						}
						else
						{
							wildcardQuery.Boost = (float)match.Weight;
							booleanQuery.Add(wildcardQuery, Occur.SHOULD);
						}
						break;
					}
					}
				}
			}
		}
		return booleanQuery;
	}

	private Query BuildTermQuery(IndexField field, SearchMatch match, string[] words, bool isWildcard, bool matchAll, bool applyBoost = true)
	{
		BooleanQuery booleanQuery = new BooleanQuery
		{
			Boost = (applyBoost ? ((float)match.Weight) : 1f)
		};
		foreach (string text in words)
		{
			Query query = (isWildcard ? ((Query)new WildcardQuery(new Term(field.Name, text + "*"))) : ((Query)new TermQuery(new Term(field.Name, text))));
			booleanQuery.Add(query, (!matchAll) ? Occur.SHOULD : Occur.MUST);
		}
		return booleanQuery;
	}

	private Query BuildPhraseQuery(IndexField field, SearchMatch match, string[] words, bool applyBoost = true)
	{
		PhraseQuery phraseQuery = new PhraseQuery
		{
			Boost = (applyBoost ? ((float)match.Weight) : 1f),
			Slop = 0
		};
		words.ForEach(delegate(string w)
		{
			phraseQuery.Add(new Term(field.Name, w));
		});
		return phraseQuery;
	}

	private SearchResult<T>[] ParseScoreDocs<T>(ScoreDoc[] scoreDocs, IndexSearcher searcher, Func<string, T?> dataCallback)
	{
		List<SearchResult<T>> list = new List<SearchResult<T>>();
		foreach (ScoreDoc scoreDoc in scoreDocs)
		{
			T item = dataCallback(searcher.Doc(scoreDoc.Doc).Get("id"));
			float score = scoreDoc.Score;
			list.Add(new SearchResult<T>(item, score));
		}
		NormalizeScores(list);
		return list.OrderByDescending((SearchResult<T> r) => r.Score).ToArray();
	}

	private void NormalizeScores<T>(IEnumerable<SearchResult<T>> results)
	{
		if (!results.Any())
		{
			return;
		}
		double max = results.Max((SearchResult<T> r) => r.Score);
		double min = results.Min((SearchResult<T> r) => r.Score);
		foreach (SearchResult<T> result in results)
		{
			result.Score = result.Score.ToFeatureRange(min, max);
		}
	}

	private int GetCurrentIndexVersion()
	{
		try
		{
			if (File.Exists(VersionFile))
			{
				return int.Parse(File.ReadAllText(VersionFile));
			}
		}
		catch (Exception ex)
		{
			Log.Error("Could not read version file, reseting {0}: {1}", StoragePath, ex);
		}
		return -1;
	}

	private void ResetIndexDirectory()
	{
		try
		{
			if (StorageDirectoryExists)
			{
				_directory.ListAll().ForEach(_directory.DeleteFile);
			}
			else
			{
				System.IO.Directory.CreateDirectory(StoragePath);
			}
		}
		catch (Exception ex)
		{
			Log.Error("Could not reset index {0}: {1}", StoragePath, ex);
		}
	}

	private void SaveCurrentIndexVersion()
	{
		try
		{
			if (StorageDirectoryExists)
			{
				File.WriteAllText(VersionFile, IndexVersion.ToString());
			}
		}
		catch (Exception)
		{
			Log.Error("Could not write version file {0}", VersionFile);
		}
	}
}
