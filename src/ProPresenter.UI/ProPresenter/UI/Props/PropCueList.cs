using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.FileSystem;
using Pro.Common.Utility;
using Pro.UI;
using Pro.UI.Components;
using Pro.UI.Controls;
using Pro.UI.Utility;
using ProPresenter.DO.Cues;
using ProPresenter.UI.ViewModels.MediaLibrary;
using ProPresenter.UI.ViewModels.Props;

namespace ProPresenter.UI.Props;

public class PropCueList : DragDropListBox<IPropCueVM>
{
	public static readonly DependencyProperty RowCapacityProperty = DependencyProperty.Register("RowCapacity", typeof(int), typeof(PropCueList), new PropertyMetadata(new PropertyChangedCallback(RowCapacity_Changed)));

	public static readonly DependencyProperty ThumbnailWidthProperty = DependencyProperty.Register("ThumbnailWidth", typeof(double), typeof(PropCueList), new PropertyMetadata((object)100.0));

	public static readonly DependencyProperty DragDropCollectionProperty = DependencyProperty.Register("DragDropCollection", typeof(IDragDropCollection<IPropCueVM>), typeof(PropCueList));

	public static readonly DependencyProperty DropActionCommandProperty = DependencyProperty.Register("DropActionCommand", typeof(ICommand<PropsDropParameter>), typeof(PropCueList));

	public IDragDropCollection<IPropCueVM> DragDropCollection
	{
		get
		{
			return (IDragDropCollection<IPropCueVM>)((DependencyObject)this).GetValue(DragDropCollectionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DragDropCollectionProperty, (object)value);
		}
	}

	protected override IDragDropCollection<IPropCueVM> SourceCollection => DragDropCollection;

	public int RowCapacity
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(RowCapacityProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RowCapacityProperty, (object)value);
		}
	}

	public double ThumbnailWidth
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(ThumbnailWidthProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ThumbnailWidthProperty, (object)value);
		}
	}

	public ICommand<PropsDropParameter> DropActionCommand
	{
		get
		{
			return (ICommand<PropsDropParameter>)((DependencyObject)this).GetValue(DropActionCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DropActionCommandProperty, (object)value);
		}
	}

	public PropCueList()
	{
		AddDropType(null, null, null, (DraggedItems<IPropCueVM> _, DragEventArgs _) => true);
		AddDropType((IEnumerable<MediaCue> c, DragEventArgs _) => c, (IDragDropCollection<IPropCueVM>? d) => (IDragDropCollection<MediaCue>?)null, null, null, OnDropData, insideOnly: false, canDropInside: true);
		AddDropType((IEnumerable<IMediaCueThumbnailVM> c, DragEventArgs d) => c.Select((IMediaCueThumbnailVM v) => v.MediaCue), (IDragDropCollection<IPropCueVM>? d) => (IDragDropCollection<MediaCue>?)null, null, null, OnDropMediaBinCue, insideOnly: false, canDropInside: true);
		AddFileDrop(OnFileDrop, null, CanDropFile, canDropInside: true);
		AddWebDropType(OnFileDrop, (FileInfo[] f, DragEventArgs e) => f.All((FileInfo i) => i.FullName.IsImageFile()), canDropInside: true);
	}

	private static void RowCapacity_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (((DependencyPropertyChangedEventArgs)(ref e)).NewValue != null && !((DependencyPropertyChangedEventArgs)(ref e)).NewValue.Equals(((DependencyPropertyChangedEventArgs)(ref e)).OldValue))
		{
			int num = Convert.ToInt32(((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
			((PropCueList)(object)d).ThumbnailWidth = 355.0 - (double)num * 62.21;
		}
	}

	protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
	{
		base.OnItemsChanged(e);
		if (base.IsLoaded)
		{
			IPropCueVM propCueVM = e.NewItems?.Cast<IPropCueVM>().FirstOrDefault();
			if (propCueVM != null)
			{
				ScrollIntoView(propCueVM);
			}
		}
	}

	protected override bool CanSelect(IPropCueVM item, MouseButtonEventArgs? e)
	{
		return KeyboardHelper.IsModifierPressed((ModifierKeys)2);
	}

	private void OnDropData<T>(DraggedItems<T> items, int dropIndex, bool dropInside, DragEventArgs e)
	{
		DoDrop(items.Items, dropIndex, dropInside);
	}

	private void OnDropMediaBinCue(DraggedItems<IMediaCueThumbnailVM> items, int dropIndex, bool dropInside, DragEventArgs e)
	{
		DoDrop(items.Items.Select((IMediaCueThumbnailVM v) => v.MediaCue), dropIndex, dropInside);
	}

	private bool CanDropFile(FileInfo[] files, DragEventArgs e)
	{
		return files.All((FileInfo f) => f.FullName.IsMediaFile());
	}

	private void OnFileDrop(FileInfo[] files, int dropIndex, bool dropInside)
	{
		DoDrop(files, dropIndex, dropInside);
	}

	private void DoDrop(IEnumerable dropData, int dropIndex, bool dropInside)
	{
		IPropCueVM item = base.ItemsSource.OfType<IPropCueVM>().ElementAtOrDefault(dropIndex);
		FrameworkElement frameworkElement = base.ItemContainerGenerator.ContainerFromItem(item) as FrameworkElement;
		bool dropBefore = true;
		if (frameworkElement != null && frameworkElement.DataContext is IPropCueVM targetItem)
		{
			dropBefore = base.Items.OfType<IPropCueVM>().IndexOf(targetItem) == dropIndex;
		}
		DropActionCommand?.Invoke(new PropsDropParameter(dropData, dropIndex, frameworkElement, dropBefore, !dropInside));
	}
}
