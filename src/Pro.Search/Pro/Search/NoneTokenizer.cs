using System.IO;
using Lucene.Net.Analysis;

namespace Pro.Search;

internal class NoneTokenizer : WhitespaceTokenizer
{
	public NoneTokenizer(TextReader @in)
		: base(@in)
	{
	}

	protected override char Normalize(char c)
	{
		return char.ToLowerInvariant(c);
	}
}
