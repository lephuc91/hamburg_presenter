using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Pro.Common.Background;
using Pro.Common.Components;
using Pro.Common.Logging;
using Pro.Common.Nullability;
using Pro.Common.Utility;
using Pro.Common.Win32;
using ProPresenter.DO.PCO;
using ProPresenter.DO.PCO.Items;
using ProPresenter.UI.ViewModels.PCO;

namespace ProPresenter.ViewModels.PCO;

public class AttachmentVM : NotifyPropertyChangedBase, IAttachmentVM, INotifyPropertyChanged
{
	private sealed class AttachmentRemoteFile : IRemoteFile
	{
		private readonly AttachmentVM _attachment;

		public string Filename => _attachment.Filename;

		public AttachmentRemoteFile(AttachmentVM attachment)
		{
			_attachment = attachment;
		}

		public void DownloadFile(Action<FileInfo> downloadComplete)
		{
			Dispatcher dispatcher = Dispatcher.CurrentDispatcher;
			_attachment._consumer.DownloadFileAsync(_attachment._attachment).ContinueWith((Func<Task, Task>)async delegate(Task downloadTask)
			{
				await downloadTask;
				dispatcher.Invoke((Action)delegate
				{
					_attachment._attachment.LocalDownloadPath.ThrowWhenNull("_attachment._attachment.LocalDownloadPath");
					downloadComplete?.Invoke(new FileInfo(_attachment._attachment.LocalDownloadPath));
				});
			}).ExecuteAsync();
		}
	}

	private readonly IPCOConsumer _consumer;

	private readonly PCOAttachmentDetails _attachment;

	private BitmapSource? _icon;

	public string Filename => _attachment.Filename;

	public BitmapSource? Icon
	{
		get
		{
			return _icon;
		}
		private set
		{
			SetValue("Icon", ref _icon, value);
		}
	}

	public IRemoteFile RemoteFile { get; }

	public AttachmentVM(IPCOConsumer consumer, PCOAttachmentDetails attachment)
	{
		_consumer = consumer;
		_attachment = attachment;
		_attachment.PropertyChanged += OnAttachmentPropertyChanged;
		RemoteFile = new AttachmentRemoteFile(this);
		UpdateIcon();
	}

	private void OnAttachmentPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "ThumbnailURL")
		{
			UpdateIcon();
		}
	}

	private void UpdateIcon()
	{
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		Icon = null;
		if (string.IsNullOrWhiteSpace(_attachment.ThumbnailURL))
		{
			string extension = Path.GetExtension(_attachment.Filename);
			try
			{
				SHFILEINFO psfi = default(SHFILEINFO);
				if (WindowsFunctions.SHGetFileInfoW(extension, FILE_ATTRIBUTE.NORMAL, ref psfi, (uint)Marshal.SizeOf(psfi), SHGFI.ICON | SHGFI.USEFILEATTRIBUTES) != IntPtr.Zero && psfi.IconHandle != IntPtr.Zero)
				{
					BitmapSource icon = Imaging.CreateBitmapSourceFromHIcon(psfi.IconHandle, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
					WindowsFunctions.DestroyIcon(psfi.IconHandle);
					Icon = icon;
				}
				return;
			}
			catch (Exception value)
			{
				Log.Error($"Failed to system icon for extension {extension} - {value}");
				return;
			}
		}
		ImageHelper.LoadImageFromURLAsync(_attachment.ThumbnailURL, delegate(BitmapSource? soure)
		{
			Icon = soure;
		});
	}
}
