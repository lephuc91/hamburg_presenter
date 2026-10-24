using System;
using Pro.Common.Utility;

namespace Pro.Text.RTF;

public class FontData : IEquatable<FontData>
{
	private readonly int _hashCode;

	public int? CharacterSet { get; }

	public int? CodePage { get; }

	public string Name { get; }

	public FontData(int? characterSet, int? codePage, string name)
	{
		CharacterSet = characterSet;
		CodePage = codePage;
		Name = name;
		_hashCode = HashCodeHelper.GenerateHashCode(CharacterSet, CodePage, Name);
	}

	public override int GetHashCode()
	{
		return _hashCode;
	}

	public override bool Equals(object? obj)
	{
		if (obj is FontData other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(FontData? other)
	{
		if ((object)other != null && CharacterSet == other.CharacterSet && CodePage == other.CodePage)
		{
			return Name == other.Name;
		}
		return false;
	}

	public static bool operator ==(FontData lhs, FontData rhs)
	{
		return lhs.NullableEquals<FontData>(rhs);
	}

	public static bool operator !=(FontData lhs, FontData rhs)
	{
		return !lhs.NullableEquals<FontData>(rhs);
	}
}
