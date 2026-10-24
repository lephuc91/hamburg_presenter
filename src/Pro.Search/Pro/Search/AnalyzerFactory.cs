using System;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.AR;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Util;

namespace Pro.Search;

public class AnalyzerFactory : IAnalyzerFactory
{
	private readonly Lucene.Net.Util.Version _version;

	public AnalyzerFactory(Lucene.Net.Util.Version version)
	{
		_version = version;
	}

	public Analyzer Get(AnalyzerType defaultAnalyzerType, AnalyzerType requestedAnalyzerType)
	{
		return ((requestedAnalyzerType == AnalyzerType.Default) ? defaultAnalyzerType : requestedAnalyzerType) switch
		{
			AnalyzerType.Standard => new StandardAnalyzer(_version), 
			AnalyzerType.Simple => new SimpleAnalyzer(), 
			AnalyzerType.None => new NoneAnalyzer(), 
			_ => throw new NotSupportedException(), 
		};
	}

	public Analyzer Get(AnalyzerType defaultAnalyzerType, AnalyzerType requestedAnalyzerType, string fieldContent)
	{
		return fieldContent.DetectPredominantLanguage() switch
		{
			Language.CJK => new SimpleAnalyzer(), 
			Language.Arabic => new ArabicAnalyzer(_version), 
			_ => Get(defaultAnalyzerType, requestedAnalyzerType), 
		};
	}
}
