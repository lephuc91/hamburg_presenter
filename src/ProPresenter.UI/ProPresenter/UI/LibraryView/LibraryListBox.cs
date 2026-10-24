using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.ErrorReporting;
using Pro.Common.FileSystem;
using Pro.Common.Mathematics;
using Pro.UI;
using Pro.UI.Controls;
using Pro.UI.DependencyInjection;
using Pro.UI.Utility;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Presentation;
using ProPresenter.UI.ViewModels.Library;
using ProPresenter.UI.ViewModels.Library.Cue;

namespace ProPresenter.UI.LibraryView;

public class LibraryListBox : DragDropListBox<ILibrary>
{
	private FrameworkElement? _dropTarget;

	private int _dropIndex;

	protected override IDragDropCollection<ILibrary>? SourceCollection => base.ItemsSource as IDragDropCollection<ILibrary>;

	private ILibraryVM? LibraryVM => base.DataContext as ILibraryVM;

	public LibraryListBox()
	{
		AddDropType<ILibrary>();
		UIServiceProvider.GetService<IErrorReporter>();
		UIServiceProvider.GetService<IProPresenterCueVMFactory>();
		AddDropType((IEnumerable<IProPresenterCueVM> i, DragEventArgs e) => (e.Effects != DragDropEffects.Copy) ? i.Select((IProPresenterCueVM c) => c.Cue).CloneItems() : (from p in (from IDocumentCueVM d in i
				where d.DocumentAction.Presentation != null
				select d.DocumentAction.Presentation).CloneItems()
			select new DocumentCue(p, supportsArrangement: false, newID: false)), (IDragDropCollection<ILibrary>? l) => l as LibraryCollection, (DraggedItems<IProPresenterCueVM> i, DragEventArgs e) => i.Items.AllOf<IDocumentCueVM>() && e.FindHitElement<ListBoxItem>(this)?.DataContext is ILibrary source && !source.Any((DocumentCue d) => i.Items.OfType<IDocumentCueVM>().Any((IDocumentCueVM c) => c.Cue == d)), (DraggedItems<IProPresenterCueVM> i, DragEventArgs e) => i.Items.AllOf<IDocumentCueVM>(), OnDocumentsDropped, insideOnly: true);
		AddFileDrop(OnFileDrop, OnFileDrag, IsFileValid);
		AddRemoteFileDrop(OnRemoteFileDrop, OnRemoteFileDrag, IsRemoteFileValid);
	}

	private bool IsValid(IEnumerable<string> filenames)
	{
		return filenames.All((string f) => f.IsProDocumentFile() || f.IsProBundleFile() || f.IsPowerPointFile());
	}

	private bool IsFileValid(FileInfo[] files, DragEventArgs e)
	{
		return IsValid(files.Select((FileInfo f) => f.FullName));
	}

	private bool IsRemoteFileValid(IRemoteFile remoteFile, DragEventArgs e)
	{
		return IsValid(new global::_003C_003Ez__ReadOnlySingleElementList<string>(remoteFile.Filename));
	}

	private void OnFileDrag(FileInfo[] files, DragEventArgs e)
	{
		OnDrag(e);
	}

	private void OnRemoteFileDrag(IRemoteFile remoteFile, DragEventArgs e)
	{
		OnDrag(e);
	}

	private void OnDrag(DragEventArgs e)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		((DependencyObject)(object)this).ResetDropIndicator();
		if (!(VisualTreeHelper.HitTest(this, e.GetPosition(this))?.VisualHit is DropIndicator))
		{
			_dropIndex = FindDropIndex(e);
			_dropTarget = base.ItemContainerGenerator.ContainerFromIndex(_dropIndex.Clamp(0, base.Items.Count - 1)) as ListBoxItem;
			_dropTarget?.ShowDropIndicator(AdornerPosition.Inside);
		}
	}

	private void OnFileDrop(FileInfo[] files, int dropIndex, bool dropInside)
	{
		LibraryVM?.DropFilesCommand?.Invoke(new DropFilesCommandParameters(files.Select((FileInfo f) => f.FullName), _dropIndex, null, _dropTarget?.DataContext as ILibrary));
	}

	private void OnRemoteFileDrop(IRemoteFile remoteFile, int dropIndex, bool dropInside)
	{
		LibraryVM?.DropFilesCommand?.Invoke(new DropFilesCommandParameters(remoteFile, _dropIndex, null, _dropTarget?.DataContext as ILibrary));
	}

	private void OnDocumentsDropped(DraggedItems<IProPresenterCueVM> draggedItems, int index, bool dropInside, DragEventArgs e)
	{
		LibraryVM?.DropPresentationsCommand?.Invoke((draggedItems.Items.OfType<IDocumentCueVM>(), index, e.Effects.HasFlag(DragDropEffects.Copy)));
	}
}
