using System;
using System.ComponentModel;
using System.Net;
using System.Windows.Threading;
using Pro.Common.Logging;

namespace ProPresenter.DO.Web;

public class WebFileDownload
{
	public Dispatcher Dispatcher;

	public string FileSource { get; }

	private string FileDestination { get; }

	private Action<double> BytesReceivedCallback { get; }

	private Action<double>? ProgressCallback { get; }

	private Action<string, bool> CompletedCallback { get; }

	public WebFileDownload(string source, string destination, Action<double> bytesReceivedCallback, Action<double>? progressCallback, Action<string, bool> completedCallback, Dispatcher? dispatcher = null)
	{
		Dispatcher = dispatcher ?? Dispatcher.CurrentDispatcher;
		FileSource = source;
		FileDestination = destination;
		BytesReceivedCallback = bytesReceivedCallback;
		ProgressCallback = progressCallback;
		CompletedCallback = completedCallback;
	}

	public void StartDownload()
	{
		WebClient client = null;
		try
		{
			client = new WebClient();
			client.DownloadProgressChanged += delegate(object s, DownloadProgressChangedEventArgs e)
			{
				Dispatcher dispatcher = Dispatcher;
				if (dispatcher != null)
				{
					dispatcher.Invoke((Action)delegate
					{
						double num = e.BytesReceived;
						double num2 = e.TotalBytesToReceive;
						double obj = ((num2 > 0.0) ? (num / num2) : 0.0);
						BytesReceivedCallback?.Invoke(num);
						ProgressCallback?.Invoke(obj);
					});
				}
			};
			client.DownloadFileCompleted += delegate(object? s, AsyncCompletedEventArgs e)
			{
				Dispatcher dispatcher2 = Dispatcher;
				if (dispatcher2 != null)
				{
					dispatcher2.InvokeAsync((Action)delegate
					{
						ProgressCallback?.Invoke(1.0);
						CompletedCallback?.Invoke(FileDestination, !e.Cancelled && e.Error == null);
					});
				}
				client.Dispose();
			};
			client.DownloadFileAsync(new Uri(FileSource), FileDestination);
		}
		catch (Exception exception)
		{
			client?.Dispose();
			CompletedCallback?.Invoke(FileDestination, arg2: false);
			Log.Error("Error download with URL: " + FileSource);
			Log.Error(exception);
		}
	}
}
