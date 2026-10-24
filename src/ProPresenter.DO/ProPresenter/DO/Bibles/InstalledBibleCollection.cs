using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.IO.Compression;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Dispatcher;
using Pro.Common.Logging;
using ProPresenter.DO.Registration.Operations;
using ProPresenter.DO.Searching;

namespace ProPresenter.DO.Bibles;

public class InstalledBibleCollection : ImmutableObservableCollection<InstalledBible>, IInstalledBibleCollection, INotifyEnumerableChanged<InstalledBible>, IEnumerable<InstalledBible>, IEnumerable, INotifyCollectionChanged
{
	private readonly IRegistrationOperationFactory _registrationOperationFactory;

	private readonly IBibleDataStore _bibleStore;

	private readonly IUiDispatcher _dispatcher;

	private readonly List<AvailableBibleBase> _installsInProgress = new List<AvailableBibleBase>();

	public string InstallPath { get; }

	public event Action<AvailableBibleBase>? BibleInstallStarted;

	public event Action<InstalledBible>? BibleInstallCompleted;

	public event Action<AvailableBibleBase>? BibleInstallFailed;

	public event Action<InstalledBible>? BibleUninstallStarted;

	public event Action<InstalledBible>? BibleUninstallCompleted;

	public InstalledBibleCollection(IRegistrationOperationFactory registrationOperationFactory, string installPath, IUiDispatcher dispatcher, IBibleDataStore bibleStore)
	{
		_registrationOperationFactory = registrationOperationFactory;
		InstallPath = installPath;
		_bibleStore = bibleStore;
		_dispatcher = dispatcher;
		base.Collection.AddRange(_bibleStore.InstalledBibles?.Where((InstalledBible b) => Directory.Exists(Path.Combine(InstallPath, b.ID.ToString()))) ?? Enumerable.Empty<InstalledBible>());
	}

	protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
	{
		_bibleStore.InstalledBibles = base.Collection.ToArray();
	}

	public void InstallBible(AvailableBibleBase bible, Action<InstalledBible> completedCallback)
	{
		OnInstallStarted(bible);
		Guid installID;
		string biblePath = CreateInstallDirectory(out installID);
		string tempFile = Path.Combine(CommonPaths.Temp, installID.ToString());
		IDownloadOperation downloadOperation = _registrationOperationFactory.DownloadBible(bible.ID, tempFile);
		IDisposable subscription = null;
		subscription = downloadOperation.WhenDownloadProgressChanged.Subscribe(delegate
		{
		}, delegate
		{
			subscription?.Dispose();
			_dispatcher.InvokeAsync(delegate
			{
				OnInstallFailed(bible);
			});
		}, delegate
		{
			subscription?.Dispose();
			BibleFormat format = ExtractBible(tempFile, biblePath);
			InstalledBible installedBible = new InstalledBible(installID, bible.TrackingAbbreviation, bible.Name, format);
			using BibleBase bibleBase = BibleLoader.TryLoad(InstallPath, installedBible);
			if (bibleBase != null)
			{
				BibleSearchEngine.IndexBible(bibleBase);
				_dispatcher.InvokeAsync(delegate
				{
					OnInstallComplete(bible, completedCallback, installedBible);
				});
			}
		});
	}

	private void OnInstallStarted(AvailableBibleBase bible)
	{
		if (IsInstalling(bible) || IsInstalled(bible))
		{
			throw new InvalidOperationException("Bible already installed");
		}
		_installsInProgress.Add(bible);
		this.BibleInstallStarted?.Invoke(bible);
	}

	private void OnInstallComplete(AvailableBibleBase bible, Action<InstalledBible> completedCallback, InstalledBible installedBible)
	{
		base.Collection.Add(installedBible);
		_installsInProgress.Remove(bible);
		completedCallback?.Invoke(installedBible);
		this.BibleInstallCompleted?.Invoke(installedBible);
	}

	private void OnInstallFailed(AvailableBibleBase bible)
	{
		_installsInProgress.Remove(bible);
		this.BibleInstallFailed?.Invoke(bible);
	}

	internal InstalledBible InstallSideBible(AvailableSideBible bible, Func<BibleFormat, string, (string, string)> getMetadata)
	{
		Guid installID;
		string text = CreateInstallDirectory(out installID);
		BibleFormat bibleFormat = ExtractBible(bible.Filename, text);
		(string, string) tuple = getMetadata(bibleFormat, text);
		string item = tuple.Item1;
		string item2 = tuple.Item2;
		InstalledBible installedBible = new InstalledBible(installID, item, item2, bibleFormat);
		base.Collection.Add(installedBible);
		bible.UpdateMetadata(item, item2);
		return installedBible;
	}

	private string CreateInstallDirectory(out Guid installID)
	{
		installID = Guid.NewGuid();
		string text = Path.Combine(InstallPath, installID.ToString());
		Directory.CreateDirectory(text);
		return text;
	}

	private static BibleFormat ExtractBible(string bibleFile, string installPath)
	{
		ZipFile.ExtractToDirectory(bibleFile, installPath);
		string text = Directory.EnumerateFiles(installPath, "*.sqlite3", SearchOption.AllDirectories).FirstOrDefault();
		if (!string.IsNullOrWhiteSpace(text))
		{
			File.Move(text, Path.Combine(installPath, "bible.db3"));
			return BibleFormat.DB3;
		}
		return BibleFormat.USX;
	}

	public void UninstallBible(AvailableBibleBase bible)
	{
		InstalledBible installedBible = GetInstalledBible(bible);
		if (installedBible != null)
		{
			this.BibleUninstallStarted?.Invoke(installedBible);
			try
			{
				Directory.Delete(Path.Combine(InstallPath, installedBible.ID.ToString()), recursive: true);
			}
			catch (Exception exception)
			{
				Log.Error(exception);
				Log.Error("Error deleting bible: {0}", bible.Name);
			}
			base.Collection.Remove(installedBible);
			this.BibleUninstallCompleted?.Invoke(installedBible);
		}
	}

	public bool IsInstalled(AvailableBibleBase bible)
	{
		return GetInstalledBible(bible) != null;
	}

	public bool IsInstalling(AvailableBibleBase bible)
	{
		return _installsInProgress.Exists((AvailableBibleBase b) => b.TrackingAbbreviation.Equals(bible.TrackingAbbreviation, StringComparison.OrdinalIgnoreCase));
	}

	public InstalledBible? GetInstalledBible(AvailableBibleBase bible)
	{
		return base.Collection.FirstOrDefault((InstalledBible b) => b.TrackingAbbreviation.Equals(bible.TrackingAbbreviation, StringComparison.OrdinalIgnoreCase));
	}
}
