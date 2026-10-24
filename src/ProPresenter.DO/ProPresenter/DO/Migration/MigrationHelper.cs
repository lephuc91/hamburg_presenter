using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using Microsoft.Win32;
using Pro.Common.Logging;

namespace ProPresenter.DO.Migration;

public static class MigrationHelper
{
	private enum Pro6AppDataType
	{
		None,
		OnlyThisUser,
		ForAllUsers,
		CustomPath
	}

	[CompilerGenerated]
	private sealed class _003CGetPro6AppDataLocations_003Ed__14 : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private string _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private Pro6AppDataType _003Cpro6Type_003E5__2;

		string IEnumerator<string>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CGetPro6AppDataLocations_003Ed__14(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
			{
				_003C_003E1__state = -1;
				string text = string.Empty;
				_003Cpro6Type_003E5__2 = Pro6AppDataType.None;
				try
				{
					using RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Renewed Vision\\ProPresenter 6", writable: false);
					if (Enum.TryParse<Pro6AppDataType>(registryKey?.GetValue("AppDataType")?.ToString(), out _003Cpro6Type_003E5__2))
					{
						switch (_003Cpro6Type_003E5__2)
						{
						case Pro6AppDataType.OnlyThisUser:
							text = Pro6UserData;
							break;
						case Pro6AppDataType.ForAllUsers:
							text = Pro6SharedData;
							break;
						case Pro6AppDataType.CustomPath:
							text = registryKey?.GetValue("AppDataLocation")?.ToString();
							break;
						}
					}
				}
				catch
				{
				}
				if (text != null && !string.IsNullOrEmpty(text))
				{
					_003C_003E2__current = text;
					_003C_003E1__state = 1;
					return true;
				}
				Log.Warning("Failed to locate Pro6 AppData registry key - falling back to default location");
				goto IL_00fd;
			}
			case 1:
				_003C_003E1__state = -1;
				goto IL_00fd;
			case 2:
				_003C_003E1__state = -1;
				goto IL_0121;
			case 3:
				{
					_003C_003E1__state = -1;
					break;
				}
				IL_00fd:
				if (_003Cpro6Type_003E5__2 != Pro6AppDataType.OnlyThisUser)
				{
					_003C_003E2__current = Pro6UserData;
					_003C_003E1__state = 2;
					return true;
				}
				goto IL_0121;
				IL_0121:
				if (_003Cpro6Type_003E5__2 != Pro6AppDataType.ForAllUsers)
				{
					_003C_003E2__current = Pro6SharedData;
					_003C_003E1__state = 3;
					return true;
				}
				break;
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<string> IEnumerable<string>.GetEnumerator()
		{
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				return this;
			}
			return new _003CGetPro6AppDataLocations_003Ed__14(0);
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<string>)this).GetEnumerator();
		}
	}

	private const string RVPostfix = "RenewedVision";

	private const string Pro6Postfix = "ProPresenter6";

	private const string Pro6RegistrySubKey = "SOFTWARE\\Renewed Vision\\ProPresenter 6";

	private const string Pro6AppDataLocationKey = "AppDataLocation";

	private const string Pro6AppDataTypeKey = "AppDataType";

	private static readonly string Pro6UserData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "RenewedVision", "ProPresenter6");

	private static readonly string Pro6SharedData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "RenewedVision", "ProPresenter6");

	public static IEnumerable<KeyValuePair<string, Color>> DefaultGroupLabels { get; } = new Dictionary<string, Color>
	{
		{
			"Intro",
			(Color)ColorConverter.ConvertFromString("#FFFFFF00")
		},
		{
			"Verse 1",
			(Color)ColorConverter.ConvertFromString("#FF0000FF")
		},
		{
			"Verse 2",
			(Color)ColorConverter.ConvertFromString("#FF00FF7F")
		},
		{
			"Verse 3",
			(Color)ColorConverter.ConvertFromString("#FFFFA500")
		},
		{
			"Chorus 1",
			(Color)ColorConverter.ConvertFromString("#FFFF0000")
		},
		{
			"Chorus 2",
			(Color)ColorConverter.ConvertFromString("#FFEE82EE")
		},
		{
			"Chorus 3",
			(Color)ColorConverter.ConvertFromString("#FFA9A9A9")
		},
		{
			"Bridge 1",
			(Color)ColorConverter.ConvertFromString("#FFFFFFFF")
		},
		{
			"Bridge 2",
			(Color)ColorConverter.ConvertFromString("#FF996633")
		},
		{
			"Tag",
			(Color)ColorConverter.ConvertFromString("#FF000000")
		}
	};

	public static IEnumerable<KeyValuePair<string, Color>> DefaultSlideLabels { get; } = new Dictionary<string, Color>
	{
		{
			"Blank Slide",
			(Color)ColorConverter.ConvertFromString("#FFFF0000")
		},
		{
			"Instrumental",
			(Color)ColorConverter.ConvertFromString("#FFFFA500")
		},
		{
			"Repeat",
			(Color)ColorConverter.ConvertFromString("#FF0000FF")
		},
		{
			"Spoken Word",
			(Color)ColorConverter.ConvertFromString("#FF00FF7F")
		}
	};

	[IteratorStateMachine(typeof(_003CGetPro6AppDataLocations_003Ed__14))]
	public static IEnumerable<string> GetPro6AppDataLocations()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CGetPro6AppDataLocations_003Ed__14(-2);
	}
}
