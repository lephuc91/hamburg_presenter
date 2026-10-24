using System;
using System.Collections;
using Pro.Common.Collections;
using Pro.Common.Mathematics;
using Pro.Common.Utility;
using Pro.Text;
using ProPresenter.DO.Slide;

namespace ProPresenter.Rendering;

internal class TextDocumentKey : IEquatable<TextDocumentKey>
{
	private TextDocument _document;

	private readonly Vector2<double> _containerSize;

	private readonly RevealType _revealType;

	private readonly Pro.Text.Range[]? _buildRanges;

	private readonly bool _skipIfCompositingIsPossible;

	private readonly int _hashCode;

	public TextDocument Document => _document;

	public TextDocumentKey(TextDocument document, Vector2<double> containerSize, RevealType revealType, Pro.Text.Range[]? buildRanges, bool skipIfCompositingIsPossible)
	{
		_document = document;
		_containerSize = containerSize;
		_revealType = revealType;
		_buildRanges = buildRanges;
		_skipIfCompositingIsPossible = skipIfCompositingIsPossible;
		IEnumerable[] collections = new Pro.Text.Range[1][] { _buildRanges };
		_hashCode = HashCodeHelper.GenerateHashCode(collections, _document, _containerSize, _revealType, _skipIfCompositingIsPossible);
	}

	public override int GetHashCode()
	{
		return _hashCode;
	}

	public override bool Equals(object? obj)
	{
		if (obj is TextDocumentKey other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(TextDocumentKey? other)
	{
		if ((object)other != null && _document == other._document && _containerSize == other._containerSize && _revealType == other._revealType && _skipIfCompositingIsPossible == other._skipIfCompositingIsPossible)
		{
			return _buildRanges.NullableEquals(other._buildRanges, IEnumerableExtensions.ContentsMatchExactly);
		}
		return false;
	}

	public void LockDocument()
	{
		_document = _document.Clone();
	}

	public static bool operator ==(TextDocumentKey lhs, TextDocumentKey rhs)
	{
		return lhs.NullableEquals<TextDocumentKey>(rhs);
	}

	public static bool operator !=(TextDocumentKey lhs, TextDocumentKey rhs)
	{
		return !lhs.NullableEquals<TextDocumentKey>(rhs);
	}
}
