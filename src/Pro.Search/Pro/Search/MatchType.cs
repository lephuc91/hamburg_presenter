using System;

namespace Pro.Search;

[Flags]
public enum MatchType
{
	None = 0,
	TermExactAny = 1,
	TermExactAll = 2,
	PhraseExact = 4,
	TermWildcardAny = 8,
	TermWildcardAll = 0x10,
	PhraseWildcard = 0x20
}
