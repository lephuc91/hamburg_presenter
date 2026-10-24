using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Pro.Common.Collections;
using Pro.Common.Dispatcher;
using ProPresenter.DO.Registration.State;
using ProPresenter.DO.Registration.State.Bible;

namespace ProPresenter.DO.Bibles;

public sealed class AvailableBibleCollection : ImmutableObservableCollection<AvailableBibleBase>, IDisposable
{
	[CompilerGenerated]
	private sealed class _003CGenerateAvailablePurchasedBibles_003Ed__12 : IEnumerable<AvailablePurchasedBible>, IEnumerable, IEnumerator<AvailablePurchasedBible>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private AvailablePurchasedBible _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private Purchased p;

		public Purchased _003C_003E3__p;

		private int _003Ccount_003E5__2;

		private ActiveCopy[] _003C_003E7__wrap2;

		private int _003C_003E7__wrap3;

		AvailablePurchasedBible IEnumerator<AvailablePurchasedBible>.Current
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
		public _003CGenerateAvailablePurchasedBibles_003Ed__12(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003C_003E7__wrap2 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				if (p == null)
				{
					return false;
				}
				_003Ccount_003E5__2 = p.LicensingInfo.TotalCopies;
				if (p.LicensingInfo.IsActiveLocally)
				{
					_003Ccount_003E5__2--;
					AvailablePurchasedBible availablePurchasedBible = new AvailablePurchasedBible(p, isActive: true);
					_003C_003E2__current = availablePurchasedBible;
					_003C_003E1__state = 1;
					return true;
				}
				goto IL_0090;
			case 1:
				_003C_003E1__state = -1;
				goto IL_0090;
			case 2:
				_003C_003E1__state = -1;
				_003C_003E7__wrap3++;
				goto IL_00fb;
			case 3:
				{
					_003C_003E1__state = -1;
					_003C_003E7__wrap3++;
					break;
				}
				IL_0090:
				_003C_003E7__wrap2 = p.LicensingInfo.OtherActiveCopies;
				_003C_003E7__wrap3 = 0;
				goto IL_00fb;
				IL_00fb:
				if (_003C_003E7__wrap3 < _003C_003E7__wrap2.Length)
				{
					ActiveCopy activeCopy = _003C_003E7__wrap2[_003C_003E7__wrap3];
					_003Ccount_003E5__2--;
					_003C_003E2__current = new AvailablePurchasedBible(p, activeCopy);
					_003C_003E1__state = 2;
					return true;
				}
				_003C_003E7__wrap2 = null;
				_003C_003E7__wrap3 = 0;
				break;
			}
			if (_003C_003E7__wrap3 < _003Ccount_003E5__2)
			{
				_003C_003E2__current = new AvailablePurchasedBible(p, null);
				_003C_003E1__state = 3;
				return true;
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
		IEnumerator<AvailablePurchasedBible> IEnumerable<AvailablePurchasedBible>.GetEnumerator()
		{
			_003CGenerateAvailablePurchasedBibles_003Ed__12 _003CGenerateAvailablePurchasedBibles_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CGenerateAvailablePurchasedBibles_003Ed__ = this;
			}
			else
			{
				_003CGenerateAvailablePurchasedBibles_003Ed__ = new _003CGenerateAvailablePurchasedBibles_003Ed__12(0);
			}
			_003CGenerateAvailablePurchasedBibles_003Ed__.p = _003C_003E3__p;
			return _003CGenerateAvailablePurchasedBibles_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<AvailablePurchasedBible>)this).GetEnumerator();
		}
	}

	private const string SideLoadDirectory = "sideload";

	private readonly IInstalledBibleCollection _installedBibles;

	private readonly IUiDispatcher _dispatcher;

	private readonly IRegistrationStateProvider _registrationStateProvider;

	public AvailableBibleCollection(IRegistrationStateProvider registrationStateProvider, IInstalledBibleCollection installedBibles, IUiDispatcher dispatcher)
	{
		_registrationStateProvider = registrationStateProvider;
		_installedBibles = installedBibles;
		_dispatcher = dispatcher;
		registrationStateProvider.PropertyChanged += On_RegistrationState_PropertyChanged;
		_installedBibles.BibleInstallStarted += OnBibleInstallStarted;
		_installedBibles.BibleInstallFailed += OnBibleInstallFailed;
		_installedBibles.BibleInstallCompleted += OnBibleInstallCompleted;
		_installedBibles.BibleUninstallCompleted += OnBibleUninstalled;
		UpdateSideLoadedBibles();
		RefreshPurchasedBibles(updateInstallStatus: false);
		RefreshFreeBibles(updateInstallStatus: false);
		UpdateInstalledBiblesStatus();
	}

	public bool IsBibleAvailable(string abbreviation, bool requireActive)
	{
		return GetAvailableBible(abbreviation, requireActive) != null;
	}

	public AvailableBibleBase? GetAvailableBible(string abbreviation, bool requireActive)
	{
		return GetAvailableBibles(abbreviation, requireActive).FirstOrDefault();
	}

	public AvailableBibleBase? GetAvailableBibleByID(string id, bool requireActive)
	{
		return base.Collection.FirstOrDefault((AvailableBibleBase b) => b.ID == id && (!requireActive || b.IsActive));
	}

	public IEnumerable<AvailableBibleBase> GetAvailableBibles(string abbreviation, bool requireActive)
	{
		return base.Collection.Where((AvailableBibleBase b) => b.TrackingAbbreviation.Equals(abbreviation, StringComparison.OrdinalIgnoreCase) && (!requireActive || b.IsActive));
	}

	private void On_RegistrationState_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		string propertyName = e.PropertyName;
		if (!(propertyName == "PurchasedBibles"))
		{
			if (propertyName == "FreeBibles")
			{
				_dispatcher.InvokeAsync(delegate
				{
					RefreshFreeBibles(updateInstallStatus: true);
				});
			}
		}
		else
		{
			_dispatcher.InvokeAsync(delegate
			{
				RefreshPurchasedBibles(updateInstallStatus: true);
			});
		}
	}

	private void UpdateSideLoadedBibles()
	{
		string path = Path.Combine(_installedBibles.InstallPath, "sideload");
		if (!Directory.Exists(path))
		{
			return;
		}
		try
		{
			foreach (string item in Directory.EnumerateFiles(path, "*.rvbible", SearchOption.TopDirectoryOnly))
			{
				base.Collection.Add(new AvailableSideBible(item));
			}
		}
		catch
		{
		}
	}

	private void RefreshPurchasedBibles(bool updateInstallStatus)
	{
		AvailablePurchasedBible[] array = (from bible in base.Collection.OfType<AvailablePurchasedBible>()
			where _registrationStateProvider.PurchasedBibles.None((Purchased b) => b.Metadata.Id == bible.ID)
			select bible).ToArray();
		foreach (AvailablePurchasedBible availablePurchasedBible in array)
		{
			_installedBibles.UninstallBible(availablePurchasedBible);
			base.Collection.Remove(availablePurchasedBible);
		}
		Purchased[] purchasedBibles = _registrationStateProvider.PurchasedBibles;
		foreach (Purchased bible2 in purchasedBibles)
		{
			AvailablePurchasedBible[] array2 = GenerateAvailablePurchasedBibles(bible2)?.OrderByDescending((AvailablePurchasedBible b) => b.IsActive).ThenByDescending((AvailablePurchasedBible b) => b.IsInUse).ToArray();
			if (array2 == null || array2.Length == 0)
			{
				continue;
			}
			AvailablePurchasedBible[] array3 = (from b in base.Collection.OfType<AvailablePurchasedBible>()
				where b.ID == bible2.Metadata.Id
				select b).ToArray();
			array3.Skip(array2.Length).ForEach(delegate(AvailablePurchasedBible b)
			{
				base.Collection.Remove(b);
			});
			for (int j = 0; j < array2.Length; j++)
			{
				AvailablePurchasedBible item = array2[j];
				AvailablePurchasedBible availablePurchasedBible2 = array3.ElementAtOrDefault(j);
				if (availablePurchasedBible2 == null)
				{
					base.Collection.Add(item);
					if (item.IsActive && !_installedBibles.Any((InstalledBible b) => b.TrackingAbbreviation == item.TrackingAbbreviation))
					{
						_installedBibles.InstallBible(item, delegate
						{
						});
					}
					continue;
				}
				if (availablePurchasedBible2.IsActive != item.IsActive)
				{
					if (availablePurchasedBible2.IsActive)
					{
						_installedBibles.UninstallBible(item);
					}
					else
					{
						_installedBibles.InstallBible(item, delegate
						{
						});
					}
				}
				array3[j].UpdateSource(item);
			}
		}
		if (updateInstallStatus)
		{
			UpdateInstalledBiblesStatus();
		}
	}

	[IteratorStateMachine(typeof(_003CGenerateAvailablePurchasedBibles_003Ed__12))]
	private IEnumerable<AvailablePurchasedBible> GenerateAvailablePurchasedBibles(Purchased p)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CGenerateAvailablePurchasedBibles_003Ed__12(-2)
		{
			_003C_003E3__p = p
		};
	}

	private void RefreshFreeBibles(bool updateInstallStatus)
	{
		AvailableFreeBible[] array = (from bible in base.Collection.OfType<AvailableFreeBible>()
			where _registrationStateProvider.FreeBibles.None((Metadata b) => b.Id == bible.ID)
			select bible).ToArray();
		foreach (AvailableFreeBible item in array)
		{
			base.Collection.Remove(item);
		}
		foreach (Metadata item2 in _registrationStateProvider.FreeBibles.Where((Metadata bible) => base.Collection.None((AvailableBibleBase b) => b.ID == bible.Id)))
		{
			base.Collection.Add(new AvailableFreeBible(item2));
		}
		if (updateInstallStatus)
		{
			UpdateInstalledBiblesStatus();
		}
	}

	private void OnBibleUninstalled(InstalledBible bible)
	{
		OnInstalledBibleChanged(bible, isInstalled: false);
	}

	private void OnInstalledBibleChanged(InstalledBible bible, bool isInstalled)
	{
		GetAvailableBibles(bible.TrackingAbbreviation, requireActive: false).ForEach(delegate(AvailableBibleBase b)
		{
			b.IsInstalled = isInstalled;
		});
	}

	private void UpdateInstalledBiblesStatus()
	{
		_installedBibles.ForEach(delegate(InstalledBible b)
		{
			OnInstalledBibleChanged(b, isInstalled: true);
		});
	}

	private void OnBibleInstallStarted(AvailableBibleBase bible)
	{
		if (base.Collection.Contains(bible))
		{
			bible.IsInstalling = true;
		}
	}

	private void OnBibleInstallFailed(AvailableBibleBase bible)
	{
		bible.IsInstalling = false;
		bible.IsInstalled = false;
	}

	private void OnBibleInstallCompleted(InstalledBible bible)
	{
		OnInstalledBibleChanged(bible, isInstalled: true);
	}

	public void Dispose()
	{
		_registrationStateProvider.PropertyChanged -= On_RegistrationState_PropertyChanged;
	}
}
