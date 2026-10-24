using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using Pro.UI.Controls.Windowing;
using ProPresenter.DO.Playlists;

namespace ProPresenter.UI.MediaLibrary;

public partial class MediaImportDownloadDialog : ChromedWindow, IComponentConnector
{
	public static readonly DependencyProperty SelectedPlaylistProperty = DependencyProperty.Register("SelectedPlaylist", typeof(VisualPlaylist), typeof(MediaImportDownloadDialog));

	public VisualPlaylist? SelectedPlaylist
	{
		get
		{
			return (VisualPlaylist)((DependencyObject)this).GetValue(SelectedPlaylistProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedPlaylistProperty, (object)value);
		}
	}

	public MediaImportDownloadDialog()
	{
		InitializeComponent();
	}

	private void Cancel_Click(object? sender, RoutedEventArgs e)
	{
		base.DialogResult = false;
		Close();
	}

	private void Download_Click(object? sender, RoutedEventArgs e)
	{
		base.DialogResult = true;
		Close();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
