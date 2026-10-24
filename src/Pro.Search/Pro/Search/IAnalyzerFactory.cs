using Lucene.Net.Analysis;

namespace Pro.Search;

public interface IAnalyzerFactory
{
	Analyzer Get(AnalyzerType defaultAnalyzerType, AnalyzerType requestedAnalyzerType);

	Analyzer Get(AnalyzerType defaultAnalyzerType, AnalyzerType requestedAnalyzerType, string fieldContent);
}
