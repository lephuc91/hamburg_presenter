using System;
using System.CodeDom.Compiler;
using System.Text.RegularExpressions;
using System.Text.RegularExpressions.Generated;
using Pro.Common.DataStore;

namespace Pro.Common.Mathematics;

public static class AngleExtensions
{
	[GeneratedRegex("^\\{(.+)\\:(.+)\\}$")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex DecodeRegex()
	{
		return _003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__DecodeRegex_2.Instance;
	}

	public static string Encode<T>(Angle<T> angle) where T : struct
	{
		return $"{{{typeof(T).GetEncoder()(angle.Value)}:{typeof(bool).GetEncoder()(angle.IsCartesian)}}}";
	}

	public static Angle<T> Decode<T>(string value) where T : struct
	{
		Match match = DecodeRegex().Match(value);
		if (!match.Success)
		{
			throw new InvalidOperationException("Invalid or malformed data");
		}
		return new Angle<T>((T)(typeof(T).GetDecoder()(match.Groups[1].Value.Trim()) ?? ((object)default(T))), (bool)(typeof(bool).GetDecoder()(match.Groups[2].Value.Trim()) ?? ((object)false)));
	}

	public static Angle<T> Negate<T>(this Angle<T> angle)
	{
		return -angle;
	}
}
