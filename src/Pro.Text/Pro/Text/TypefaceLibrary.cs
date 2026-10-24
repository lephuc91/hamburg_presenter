using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using Pro.Common.Collections;
using Pro.Common.Logging;
using Pro.Common.Mathematics;
using Pro.Common.Nullability;

namespace Pro.Text;

public class TypefaceLibrary : InternalBase
{
	private static class NativeMethods
	{
		[DllImport("PTW.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TypefaceLibrary_CreateTypefaceLibrary")]
		public static extern nint CreateTypefaceLibrary();

		[DllImport("PTW.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TypefaceLibrary_DestroyTypefaceLibrary")]
		public static extern void DestroyTypefaceLibrary(nint handle);
	}

	private const string ImportPrefix = "TypefaceLibrary_";

	private const string FallbackFontPath = "fonts/Unifont/unifont-10.0.04.ttf";

	private static readonly (string psName, (uint start, uint end)[])[] FallbackFontTable = new(string, (uint, uint)[])[23]
	{
		("ArialMT", new(uint, uint)[4]
		{
			(0u, 127u),
			(128u, 255u),
			(256u, 383u),
			(384u, 591u)
		}),
		("ArialMT", new(uint, uint)[5]
		{
			(1536u, 1791u),
			(1872u, 1919u),
			(2208u, 2303u),
			(64336u, 65023u),
			(65136u, 65279u)
		}),
		("ArialMT", new(uint, uint)[1] { (1424u, 1535u) }),
		("ArialMT", new(uint, uint)[2]
		{
			(880u, 1023u),
			(7936u, 8191u)
		}),
		("MicrosoftYaHei", new(uint, uint)[1] { (19968u, 40879u) }),
		("MalgunGothic", new(uint, uint)[2]
		{
			(13312u, 19903u),
			(19968u, 40959u)
		}),
		("MalgunGothic", new(uint, uint)[5]
		{
			(4352u, 4607u),
			(12592u, 12687u),
			(43360u, 43391u),
			(44032u, 55215u),
			(55216u, 55295u)
		}),
		("MalgunGothic", new(uint, uint)[2]
		{
			(12352u, 12447u),
			(12448u, 12543u)
		}),
		("ArialMT", new(uint, uint)[2]
		{
			(1024u, 1279u),
			(1280u, 3887u)
		}),
		("NirmalaUI", new(uint, uint)[2]
		{
			(2304u, 2431u),
			(43232u, 43263u)
		}),
		("NirmalaUI", new(uint, uint)[1] { (2432u, 2559u) }),
		("NirmalaUI", new(uint, uint)[1] { (2560u, 2687u) }),
		("NirmalaUI", new(uint, uint)[1] { (2688u, 2815u) }),
		("NirmalaUI", new(uint, uint)[1] { (2816u, 2943u) }),
		("NirmalaUI", new(uint, uint)[1] { (2944u, 3071u) }),
		("NirmalaUI", new(uint, uint)[1] { (3072u, 3199u) }),
		("NirmalaUI", new(uint, uint)[1] { (3200u, 3327u) }),
		("NirmalaUI", new(uint, uint)[1] { (3328u, 3455u) }),
		("NirmalaUI", new(uint, uint)[1] { (3456u, 3583u) }),
		("Tahoma", new(uint, uint)[1] { (3584u, 3711u) }),
		("Ebrima", new(uint, uint)[4]
		{
			(4608u, 4991u),
			(4992u, 5023u),
			(11648u, 11743u),
			(43776u, 43823u)
		}),
		("Ebrima", new(uint, uint)[1] { (11568u, 11647u) }),
		("Ebrima", new(uint, uint)[1] { (42240u, 42559u) })
	};

	private readonly Dictionary<FontInfo, (Font font, bool isFallbackFont)> _fuzzyFontMap = new Dictionary<FontInfo, (Font, bool)>();

	public AvailableTypefaces AvailableTypefaces { get; }

	public Font FallbackFont { get; }

	internal FallbackFontProvider FallbackFontProvider { get; } = new FallbackFontProvider();

	public TypefaceLibrary()
		: base(NativeMethods.CreateTypefaceLibrary())
	{
		FallbackFont = new Font(this, "fonts/Unifont/unifont-10.0.04.ttf", 0, (uint)CultureInfo.CurrentUICulture.LCID, FontSourceType.Unknown);
		AvailableTypefaces = new AvailableTypefaces(this);
		(string, (uint, uint)[])[] fallbackFontTable = FallbackFontTable;
		for (int i = 0; i < fallbackFontTable.Length; i++)
		{
			(string, (uint, uint)[]) tuple = fallbackFontTable[i];
			string item = tuple.Item1;
			(uint, uint)[] item2 = tuple.Item2;
			for (int j = 0; j < item2.Length; j++)
			{
				var (start2, end2) = item2[j];
				register(start2, end2, item);
				void register(uint start, uint end, string psName)
				{
					Font font = AvailableTypefaces.AllFonts.FirstOrDefault((Font f) => f.Info.PSName == psName);
					if ((object)font != null)
					{
						FallbackFontProvider.RegisterFont(start, end, font);
					}
				}
			}
		}
		FallbackFontProvider.RegisterFont(0u, uint.MaxValue, FallbackFont);
	}

	protected override void Destroy()
	{
		NativeMethods.DestroyTypefaceLibrary(base.Handle);
	}

	public Font FindFont(FontInfo fontInfo)
	{
		bool isFallbackFont;
		return FindFont(fontInfo, out isFallbackFont);
	}

	public Font FindFont(FontInfo fontInfo, out bool isFallbackFont)
	{
		Font font = AvailableTypefaces.GetFont(fontInfo);
		if ((object)font != null)
		{
			isFallbackFont = false;
			return font;
		}
		lock (_fuzzyFontMap)
		{
			if (_fuzzyFontMap.TryGetValue(fontInfo, out (Font, bool) value))
			{
				isFallbackFont = value.Item2;
				return value.Item1;
			}
			bool searchByGroup = true;
			Font[] possibleMatches = Array.Empty<Font>();
			searchPass((FontInfo info) => new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { info.FullName, info.PSName }), exactSearch: true);
			searchPass((FontInfo info) => new global::_003C_003Ez__ReadOnlyArray<string>(new string[3] { info.FullName, info.SystemFamilyName, info.PSName }));
			searchPass((FontInfo info) => new global::_003C_003Ez__ReadOnlyArray<string>(new string[2]
			{
				info.SystemFamilyName,
				info.SystemFamilyName + " " + info.SystemFaceName
			}));
			searchPass((FontInfo info) => new global::_003C_003Ez__ReadOnlyArray<string>(new string[4]
			{
				info.FullName,
				info.PSName,
				info.SystemFamilyName,
				info.SystemFamilyName + " " + info.SystemFaceName
			}));
			if (possibleMatches.Any())
			{
				font = GetBestMatch(possibleMatches, fontInfo, searchByGroup);
				isFallbackFont = false;
				return SetFuzzyMatchResult(fontInfo, font, isFallbackFont);
			}
			Log.Warning("No font match was found for " + fontInfo.DisplayName + " -- falling back to default font");
			isFallbackFont = true;
			return SetFuzzyMatchResult(fontInfo, FallbackFont, isFallbackFont);
			void searchPass(Func<FontInfo, IEnumerable<string?>> nameSelector, bool exactSearch = false)
			{
				if (possibleMatches.Empty())
				{
					possibleMatches = getPossibleMatches(nameSelector);
					searchByGroup = !exactSearch;
				}
			}
		}
		Font[] getPossibleMatches(Func<FontInfo, IEnumerable<string?>> nameSelector)
		{
			string[] names = selector(fontInfo).ToArray();
			return AvailableTypefaces.AllFonts.Where((Font f) => selector(f.Info).Intersect<string>(names, StringComparer.OrdinalIgnoreCase).Any()).ToArray();
			IEnumerable<string> selector(FontInfo info)
			{
				return from n in nameSelector(info)
					where !n.NullableIsNullOrWhiteSpace()
					select n;
			}
		}
	}

	private Font SetFuzzyMatchResult(FontInfo fontInfo, Font font, bool isFallbackFont)
	{
		_fuzzyFontMap.Add(fontInfo, (font, isFallbackFont));
		return font;
	}

	private Font GetBestMatch(Font[] possibleMatches, FontInfo fontInfo, bool searchByGroup)
	{
		Font[] source = (searchByGroup ? possibleMatches.SelectMany((Font f) => AvailableTypefaces.FindFontGroup(f)?.Fonts ?? Array.Empty<Font>()).Distinct().ToArray() : possibleMatches);
		if (source.None(matchFontWeightExactly))
		{
			return source.OrderBy(closestFontWeight).ThenByDescending(matchScore).First();
		}
		return source.OrderByDescending(matchScore).First();
		int closestFontWeight(Font font)
		{
			return (font.Info.Weight.ToOpenTypeWeight() - fontInfo.Weight.ToOpenTypeWeight()).Abs();
		}
		bool matchFontWeightExactly(Font font)
		{
			return font.Info.Weight == fontInfo.Weight;
		}
		int matchScore(Font font)
		{
			return fontInfo.GetMatchWeight(font.Info);
		}
	}
}
