using System;
using System.Text;
using Pro.Text.RTF.Tokens;

namespace Pro.Text.RTF;

public static class CharacterSetEncodingExtensions
{
	private static Encoding ANSI { get; }

	private static Encoding MacRoman { get; }

	private static Encoding MacShiftJis { get; }

	private static Encoding MacHangul { get; }

	private static Encoding MacGB2312 { get; }

	private static Encoding MacBig5 { get; }

	private static Encoding MacHebrew { get; }

	private static Encoding MacArabic { get; }

	private static Encoding MacGreek { get; }

	private static Encoding MacTurkish { get; }

	private static Encoding MacThai { get; }

	private static Encoding MacEastEurope { get; }

	private static Encoding MacRussian { get; }

	private static Encoding ShiftJis { get; }

	private static Encoding Hangul { get; }

	private static Encoding Johab { get; }

	private static Encoding GB2312 { get; }

	private static Encoding Big5 { get; }

	private static Encoding Greek { get; }

	private static Encoding Turkish { get; }

	private static Encoding Vietnamese { get; }

	private static Encoding Hebrew { get; }

	private static Encoding Arabic { get; }

	private static Encoding Baltic { get; }

	private static Encoding Russian { get; }

	private static Encoding Thai { get; }

	private static Encoding EastEurope { get; }

	private static Encoding PC437 { get; }

	private static Encoding OEM { get; }

	static CharacterSetEncodingExtensions()
	{
		Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
		ANSI = Encoding.GetEncoding(1252);
		MacRoman = Encoding.GetEncoding(10000);
		MacShiftJis = Encoding.GetEncoding(10001);
		MacHangul = Encoding.GetEncoding(10003);
		MacGB2312 = Encoding.GetEncoding(10008);
		MacBig5 = Encoding.GetEncoding(10002);
		MacHebrew = Encoding.GetEncoding(10005);
		MacArabic = Encoding.GetEncoding(10004);
		MacGreek = Encoding.GetEncoding(10006);
		MacTurkish = Encoding.GetEncoding(10081);
		MacThai = Encoding.GetEncoding(10021);
		MacEastEurope = Encoding.GetEncoding(10029);
		MacRussian = Encoding.GetEncoding(10007);
		ShiftJis = Encoding.GetEncoding(932);
		Hangul = Encoding.GetEncoding(949);
		Johab = Encoding.GetEncoding(1361);
		GB2312 = Encoding.GetEncoding(936);
		Big5 = Encoding.GetEncoding(950);
		Greek = Encoding.GetEncoding(1253);
		Turkish = Encoding.GetEncoding(1254);
		Vietnamese = Encoding.GetEncoding(1258);
		Hebrew = Encoding.GetEncoding(1255);
		Arabic = Encoding.GetEncoding(1256);
		Baltic = Encoding.GetEncoding(1257);
		Russian = Encoding.GetEncoding(1251);
		Thai = Encoding.GetEncoding(874);
		EastEurope = Encoding.GetEncoding(1250);
		PC437 = Encoding.GetEncoding(437);
		OEM = Encoding.GetEncoding(850);
	}

	public static Encoding GetEncoding(this int characterSet)
	{
		switch (characterSet)
		{
		case 0:
			return ANSI;
		case 1:
		case 2:
			return Encoding.Default;
		case 77:
			return MacRoman;
		case 78:
			return MacShiftJis;
		case 79:
			return MacHangul;
		case 80:
			return MacGB2312;
		case 81:
			return MacBig5;
		case 83:
			return MacHebrew;
		case 84:
			return MacArabic;
		case 85:
			return MacGreek;
		case 86:
			return MacTurkish;
		case 87:
			return MacThai;
		case 88:
			return MacEastEurope;
		case 89:
			return MacRussian;
		case 128:
			return ShiftJis;
		case 129:
			return Hangul;
		case 130:
			return Johab;
		case 134:
			return GB2312;
		case 136:
			return Big5;
		case 161:
			return Greek;
		case 162:
			return Turkish;
		case 163:
			return Vietnamese;
		case 177:
			return Hebrew;
		case 178:
			return Arabic;
		case 186:
			return Baltic;
		case 204:
			return Russian;
		case 222:
			return Thai;
		case 238:
			return EastEurope;
		case 254:
			return PC437;
		case 255:
			return OEM;
		default:
			throw new ArgumentOutOfRangeException("characterSet", characterSet, "Unknown character set");
		}
	}

	public static Encoding GetEncoding(this CodePage codePage)
	{
		return Encoding.GetEncoding(codePage.Page);
	}
}
