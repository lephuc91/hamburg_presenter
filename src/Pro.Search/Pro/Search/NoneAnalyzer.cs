using System.IO;
using Lucene.Net.Analysis;

namespace Pro.Search;

internal class NoneAnalyzer : Analyzer
{
	public override TokenStream TokenStream(string fieldName, TextReader reader)
	{
		return new NoneTokenizer(reader);
	}

	public override TokenStream ReusableTokenStream(string fieldName, TextReader reader)
	{
		Tokenizer tokenizer = (Tokenizer)PreviousTokenStream;
		if (tokenizer == null)
		{
			tokenizer = (Tokenizer)(PreviousTokenStream = new NoneTokenizer(reader));
		}
		else
		{
			tokenizer.Reset(reader);
		}
		return tokenizer;
	}
}
