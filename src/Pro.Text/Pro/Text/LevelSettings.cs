using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text.RegularExpressions.Generated;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Utility;
using Pro.Text.Reversibility;

namespace Pro.Text;

public class LevelSettings : NotifyPropertyChangedBase, IEquatable<LevelSettings>, ICloneable<LevelSettings>
{
	private const string BulletNonMatchingGroupFormat = "(?:{0})";

	private const string BulletMatchingGroupFormat = "({0})";

	private const string BulletPrefixFormat = "^(.*){0}";

	private const string BulletSuffixFormat = "{0}(.*)$";

	private const string BulletContentFormat = "^.*{0}.*$";

	private static readonly Regex BulletPrefixRegex;

	private static readonly Regex BulletSuffixRegex;

	private static readonly Regex BulletContentRegex;

	private static readonly ReadOnlyDictionary<string, BulletType> BulletLookupMap;

	private FollowType _follow = FollowType.Tab;

	private NumberingScheme _numberingScheme;

	private BulletType _bulletType;

	private bool _isBullet = true;

	private string _prefix = string.Empty;

	private string _suffix = string.Empty;

	private string _numberingFormat = string.Empty;

	private int _startNumber = 1;

	private int _levelIndex;

	private bool _updateInProgress;

	public UndoStack? UndoStack { get; set; }

	public FollowType Follow
	{
		get
		{
			return _follow;
		}
		set
		{
			SetValue("Follow", ref _follow, value, delegate(FollowType o, FollowType n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ListFollow), this, "Follow", o, n, null, null, autoFinalize: true);
			});
		}
	}

	public NumberingScheme NumberingScheme
	{
		get
		{
			return _numberingScheme;
		}
		set
		{
			SetValue("NumberingScheme", ref _numberingScheme, value, delegate(NumberingScheme o, NumberingScheme n)
			{
				UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ListNumberingScheme));
				IsBullet = false;
				UpdateNumberingFormat();
				UndoStack?.Commit(this, "NumberingScheme", o, n);
				UndoStack?.EndCommit(null, null, autoFinalize: true);
			});
		}
	}

	public BulletType BulletType
	{
		get
		{
			return _bulletType;
		}
		set
		{
			SetValue("BulletType", ref _bulletType, value, delegate(BulletType o, BulletType n)
			{
				UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ListBullet));
				IsBullet = true;
				UpdateNumberingFormat();
				UndoStack?.Commit(this, "BulletType", o, n);
				UndoStack?.EndCommit(null, null, autoFinalize: true);
			});
		}
	}

	public bool IsBullet
	{
		get
		{
			return _isBullet;
		}
		set
		{
			SetValue("IsBullet", ref _isBullet, value, delegate(bool o, bool n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ListBullet), this, "IsBullet", o, n);
				UpdateNumberingFormat();
			});
		}
	}

	public string Prefix
	{
		get
		{
			return _prefix;
		}
		set
		{
			SetValue("Prefix", ref _prefix, value, delegate(string o, string n)
			{
				UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ListPrefix));
				UpdateNumberingFormat();
				UndoStack?.Commit(this, "Prefix", o, n);
				UndoStack?.EndCommit(null, null, autoFinalize: true);
			});
		}
	}

	public string Suffix
	{
		get
		{
			return _suffix;
		}
		set
		{
			SetValue("Suffix", ref _suffix, value, delegate(string o, string n)
			{
				UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ListSuffix));
				UpdateNumberingFormat();
				UndoStack?.Commit(this, "Suffix", o, n);
				UndoStack?.EndCommit(null, null, autoFinalize: true);
			});
		}
	}

	public string NumberingFormat
	{
		get
		{
			return _numberingFormat;
		}
		set
		{
			SetValue("NumberingFormat", ref _numberingFormat, value, delegate(string o, string n)
			{
				bool num = !(UndoStack?.IsRecording ?? true);
				if (num)
				{
					UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ListNumberingFormat));
				}
				UpdatePrefixAndSuffix();
				UpdateBullet();
				if (num)
				{
					UndoStack?.Commit(this, "NumberingFormat", o, n);
					UndoStack?.EndCommit(null, null, autoFinalize: true);
				}
			});
		}
	}

	public int StartNumber
	{
		get
		{
			return _startNumber;
		}
		set
		{
			SetValue("StartNumber", ref _startNumber, value, delegate(int o, int n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ListStartNumber), this, "StartNumber", o, n, null, null, autoFinalize: true);
			});
		}
	}

	internal int LevelIndex
	{
		get
		{
			return _levelIndex;
		}
		set
		{
			_levelIndex = value;
			UpdateNumberingFormat();
		}
	}

	[GeneratedRegex("^((?(?=\\{)\\{{2}|.)*)")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex NumberingPrefixRegex()
	{
		return _003CRegexGenerator_g_003EF57B2832C340465DE9FCA1C1E54A7405D72AD510F32C0D9562DDA1404CB5DF29C__NumberingPrefixRegex_7.Instance;
	}

	[GeneratedRegex("((?(?=\\})\\}{2}|.)*)$")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex NumberingSuffixRegex()
	{
		return _003CRegexGenerator_g_003EF57B2832C340465DE9FCA1C1E54A7405D72AD510F32C0D9562DDA1404CB5DF29C__NumberingSuffixRegex_8.Instance;
	}

	static LevelSettings()
	{
		Dictionary<string, BulletType> dictionary = Enum.GetValues<BulletType>().ToArray().ToDictionary((BulletType b) => b.GetEnumDescription(), (BulletType b) => b);
		string[] value = dictionary.Keys.ToArray();
		string arg = string.Join("|", value);
		string arg2 = $"(?:{arg})";
		string arg3 = $"({arg})";
		BulletPrefixRegex = new Regex($"^(.*){arg2}", RegexOptions.Compiled);
		BulletSuffixRegex = new Regex($"{arg2}(.*)$", RegexOptions.Compiled);
		BulletContentRegex = new Regex($"^.*{arg3}.*$", RegexOptions.Compiled);
		BulletLookupMap = new ReadOnlyDictionary<string, BulletType>(dictionary);
	}

	public LevelSettings()
	{
		UpdateNumberingFormat();
	}

	public LevelSettings Clone()
	{
		return new LevelSettings
		{
			Follow = _follow,
			BulletType = _bulletType,
			IsBullet = _isBullet,
			NumberingScheme = _numberingScheme,
			NumberingFormat = _numberingFormat,
			StartNumber = _startNumber
		};
	}

	public string GetFlatText(int number)
	{
		return string.Format(GetNumberingFormat(0), NumberingProvider.GetNumberString(StartNumber + number, NumberingScheme));
	}

	private string EscapeBraces(string value)
	{
		return value.Replace("{", "{{").Replace("}", "}}");
	}

	private string UnescapeBraces(string value)
	{
		return value.Replace("{{", "{").Replace("}}", "}");
	}

	private void UpdateNumberingFormat()
	{
		if (!_updateInProgress)
		{
			_updateInProgress = true;
			NumberingFormat = GetNumberingFormat(LevelIndex);
			_updateInProgress = false;
		}
	}

	private string GetNumberingFormat(int index)
	{
		if (!IsBullet)
		{
			return $"{EscapeBraces(Prefix)}{{{index}}}{EscapeBraces(Suffix)}";
		}
		return $"{EscapeBraces(Prefix)}{BulletType.GetEnumDescription()}{EscapeBraces(Suffix)}";
	}

	private void UpdatePrefixAndSuffix()
	{
		if (!_updateInProgress)
		{
			_updateInProgress = true;
			if (IsBullet)
			{
				Prefix = UnescapeBraces(BulletPrefixRegex.Match(NumberingFormat).Groups[1].Value);
				Suffix = UnescapeBraces(BulletSuffixRegex.Match(NumberingFormat).Groups[1].Value);
			}
			else
			{
				Prefix = UnescapeBraces(NumberingPrefixRegex().Match(NumberingFormat).Groups[1].Value);
				Suffix = UnescapeBraces(NumberingSuffixRegex().Match(NumberingFormat).Groups[1].Value);
			}
			_updateInProgress = false;
		}
	}

	private void UpdateBullet()
	{
		if (!_updateInProgress)
		{
			_updateInProgress = true;
			Match match = BulletContentRegex.Match(NumberingFormat);
			if (match.Success)
			{
				BulletType = BulletLookupMap[match.Groups[1].Value];
			}
			else
			{
				BulletType = BulletType.Dash;
			}
			_updateInProgress = false;
		}
	}

	public override int GetHashCode()
	{
		return HashCodeHelper.GenerateHashCode(_follow, _numberingScheme, _bulletType, _isBullet, _prefix, _suffix, _numberingFormat, _startNumber);
	}

	public override bool Equals(object? obj)
	{
		if (obj is LevelSettings other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(LevelSettings? other)
	{
		if ((object)other != null && _follow == other._follow && _numberingScheme == other._numberingScheme && _bulletType == other._bulletType && _isBullet == other._isBullet && _prefix == other._prefix && _suffix == other._suffix && _numberingFormat == other._numberingFormat)
		{
			return _startNumber == other._startNumber;
		}
		return false;
	}

	public static bool operator ==(LevelSettings lhs, LevelSettings rhs)
	{
		return lhs.NullableEquals<LevelSettings>(rhs);
	}

	public static bool operator !=(LevelSettings lhs, LevelSettings rhs)
	{
		return !lhs.NullableEquals<LevelSettings>(rhs);
	}
}
