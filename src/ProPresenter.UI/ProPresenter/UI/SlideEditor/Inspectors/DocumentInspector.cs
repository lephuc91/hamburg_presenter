using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media.Imaging;
using Pro.Common.Collections;
using Pro.Common.FileSystem;
using Pro.Common.Utility;
using Pro.UI.DependencyInjection;
using Pro.UI.DragDropHelper;
using ProPresenter.UI.ViewModels.Editor;

namespace ProPresenter.UI.SlideEditor.Inspectors;

public partial class DocumentInspector : UserControl, IComponentConnector
{
	private readonly IImageLoader _imageLoader;

	private static DependencyProperty RemoveTransitionCommandProperty = DependencyProperty.Register("RemoveTransitionCommand", typeof(ICommand), typeof(DocumentInspector));

	public ICommand? RemoveTransitionCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(RemoveTransitionCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RemoveTransitionCommandProperty, (object)value);
		}
	}

	public DocumentInspector()
	{
		InitializeComponent();
		_imageLoader = UIServiceProvider.GetService<IImageLoader>();
		DropAction<FileInfo[]> dropAction = new DropTarget((DependencyObject)(object)ArtworkBorder).AddFileDrop();
		dropAction.SetIsValidDataPredicate((FileInfo[] f, DragEventArgs e) => f.AllOf((FileInfo f) => f.FullName.IsImageFile()));
		dropAction.SetOnDataDroppedAction(OnDropFile);
	}

	private void OnDropFile(FileInfo[] files, DragEventArgs e)
	{
		if (!(base.DataContext is IDocumentInspectorVM { Presentation: not null } documentInspectorVM))
		{
			return;
		}
		FileInfo fileInfo = files.FirstOrDefault();
		if (fileInfo != null)
		{
			BitmapSource bitmapSource = _imageLoader.LoadImageFromURL(fileInfo.FullName);
			if (bitmapSource != null)
			{
				byte[] artworkImageData = _imageLoader.ToByteArray(bitmapSource);
				documentInspectorVM.Presentation.CCLIInfo.ArtworkImageData = artworkImageData;
			}
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
