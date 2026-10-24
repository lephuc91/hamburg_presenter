using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.Localization;
using Pro.UI.Commands;
using Pro.UI.Components;
using Pro.UI.Controls;
using ProPresenter.Controller.Outputs;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;
using ProPresenter.UI.ViewModels.MediaLibrary;

namespace ProPresenter.UI.MediaLibrary;

public partial class MediaCueListView : UserControl, IComponentConnector, IStyleConnector
{
	private static readonly float PreviewWidthAspectRatio = 1.75f;

	public static readonly DependencyProperty SelectedMediaItemProperty = DependencyProperty.Register("SelectedMediaItem", typeof(IMediaCueThumbnailVM), typeof(MediaCueListView));

	public static readonly DependencyProperty SelectedMediaItemsProperty = DependencyProperty.Register("SelectedMediaItems", typeof(ObservableCollection<IMediaCueThumbnailVM>), typeof(MediaCueListView), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)new ObservableCollection<IMediaCueThumbnailVM>()));

	public static readonly DependencyProperty MediaItemsProperty = DependencyProperty.Register("MediaItems", typeof(IEnumerable<IMediaCueThumbnailVM>), typeof(MediaCueListView));

	public static readonly DependencyProperty RowCapacityProperty = DependencyProperty.Register("RowCapacity", typeof(int), typeof(MediaCueListView), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(RowCapacityPropertyChanged)));

	public static readonly DependencyProperty SelectedPlaylistProperty = DependencyProperty.Register("SelectedPlaylist", typeof(IPlaylist<MediaCue>), typeof(MediaCueListView));

	public static readonly DependencyProperty MediaContextMenuProperty = DependencyProperty.Register("MediaContextMenu", typeof(ContextMenu), typeof(MediaCueListView));

	public static readonly DependencyProperty TriggerThumbnailCommandProperty = DependencyProperty.Register("TriggerThumbnailCommand", typeof(ICommand<IMediaCueThumbnailVM>), typeof(MediaCueListView));

	public static readonly DependencyProperty ActiveMediaItemsProperty = DependencyProperty.Register("ActiveMediaItems", typeof(IEnumerable<IMediaCueThumbnailVM>), typeof(MediaCueListView));

	public static readonly DependencyProperty AddFilesCommandProperty = DependencyProperty.Register("AddFilesCommand", typeof(ICommand), typeof(MediaCueListView));

	public static readonly DependencyPropertyKey MaximumPreviewImageHeightPropertyKey = DependencyProperty.RegisterReadOnly("MaximumPreviewImageHeight", typeof(int), typeof(MediaCueListView), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)0));

	public static readonly DependencyPropertyKey MaximumPreviewImageWidthPropertyKey = DependencyProperty.RegisterReadOnly("MaximumPreviewImageWidth", typeof(int), typeof(MediaCueListView), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)0));

	public static readonly DependencyProperty OutputControllerProperty = DependencyProperty.Register("OutputController", typeof(ssAPIOutput), typeof(MediaCueListView));

	public static readonly DependencyProperty CopyCommandProperty = DependencyProperty.Register("CopyCommand", typeof(ICommand), typeof(MediaCueListView), (PropertyMetadata)(object)new FrameworkPropertyMetadata((PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((MediaCueListView)(object)s).CommandBindings.Add(CommonApplicationCommands.Copy, (ICommand)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}));

	public static readonly DependencyProperty CutCommandProperty = DependencyProperty.Register("CutCommand", typeof(ICommand), typeof(MediaCueListView), (PropertyMetadata)(object)new FrameworkPropertyMetadata((PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((MediaCueListView)(object)s).CommandBindings.Add(CommonApplicationCommands.CutCommand, (ICommand)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}));

	public static readonly DependencyProperty PasteCommandProperty = DependencyProperty.Register("PasteCommand", typeof(ICommand), typeof(MediaCueListView), (PropertyMetadata)(object)new FrameworkPropertyMetadata((PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((MediaCueListView)(object)s).CommandBindings.Add(CommonApplicationCommands.Paste, (ICommand)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}));

	public static readonly DependencyProperty DuplicateCommandProperty = DependencyProperty.Register("DuplicateCommand", typeof(ICommand), typeof(MediaCueListView), (PropertyMetadata)(object)new FrameworkPropertyMetadata((PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((MediaCueListView)(object)s).CommandBindings.Add(CommonApplicationCommands.Duplicate, (ICommand)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}));

	public static readonly DependencyProperty DeleteCommandProperty = DependencyProperty.Register("DeleteCommand", typeof(ICommand), typeof(MediaCueListView), (PropertyMetadata)(object)new FrameworkPropertyMetadata((PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((MediaCueListView)(object)s).CommandBindings.Add(CommonApplicationCommands.Delete, (ICommand)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}));

	public IMediaCueThumbnailVM? SelectedMediaItem
	{
		get
		{
			return (IMediaCueThumbnailVM)((DependencyObject)this).GetValue(SelectedMediaItemProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedMediaItemProperty, (object)value);
		}
	}

	public ObservableCollection<IMediaCueThumbnailVM>? SelectedMediaItems
	{
		get
		{
			return (ObservableCollection<IMediaCueThumbnailVM>)((DependencyObject)this).GetValue(SelectedMediaItemsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedMediaItemsProperty, (object)value);
		}
	}

	public IEnumerable<IMediaCueThumbnailVM>? MediaItems
	{
		get
		{
			return (IEnumerable<IMediaCueThumbnailVM>)((DependencyObject)this).GetValue(MediaItemsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MediaItemsProperty, (object)value);
		}
	}

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

	public int MaximumPreviewImageHeight => (int)((DependencyObject)this).GetValue(MaximumPreviewImageHeightPropertyKey.DependencyProperty);

	public int MaximumPreviewImageWidth => (int)((DependencyObject)this).GetValue(MaximumPreviewImageWidthPropertyKey.DependencyProperty);

	public ssAPIOutput? OutputController
	{
		get
		{
			return (ssAPIOutput)((DependencyObject)this).GetValue(OutputControllerProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(OutputControllerProperty, (object)value);
		}
	}

	public IPlaylist<MediaCue>? SelectedPlaylist
	{
		get
		{
			return (IPlaylist<MediaCue>)((DependencyObject)this).GetValue(SelectedPlaylistProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedPlaylistProperty, (object)value);
		}
	}

	public ContextMenu? MediaContextMenu
	{
		get
		{
			return (ContextMenu)((DependencyObject)this).GetValue(MediaContextMenuProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MediaContextMenuProperty, (object)value);
		}
	}

	public IEnumerable<IMediaCueThumbnailVM>? ActiveMediaItems
	{
		get
		{
			return (IEnumerable<IMediaCueThumbnailVM>)((DependencyObject)this).GetValue(ActiveMediaItemsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ActiveMediaItemsProperty, (object)value);
		}
	}

	public ICommand<IMediaCueThumbnailVM>? TriggerThumbnailCommand
	{
		get
		{
			return (ICommand<IMediaCueThumbnailVM>)((DependencyObject)this).GetValue(TriggerThumbnailCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TriggerThumbnailCommandProperty, (object)value);
		}
	}

	public ICommand? AddFilesCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(AddFilesCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AddFilesCommandProperty, (object)value);
		}
	}

	public ICommand? CutCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(CutCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CutCommandProperty, (object)value);
		}
	}

	public ICommand? CopyCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(CopyCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CopyCommandProperty, (object)value);
		}
	}

	public ICommand? PasteCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(PasteCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PasteCommandProperty, (object)value);
		}
	}

	public ICommand? DuplicateCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(DuplicateCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DuplicateCommandProperty, (object)value);
		}
	}

	public ICommand? DeleteCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(DeleteCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DeleteCommandProperty, (object)value);
		}
	}

	private static void RowCapacityPropertyChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		((MediaCueListView)(object)callerObject).AdjustRowHeight((int)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	public MediaCueListView()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		InitializeComponent();
		base.IsVisibleChanged += new DependencyPropertyChangedEventHandler(MediaCueListView_IsVisibleChanged);
	}

	public void RenameCue(System.Windows.Controls.DataGridRow row)
	{
		DataGridColumn dataGridColumn = CueList.Columns.FirstOrDefault((DataGridColumn c) => string.CompareOrdinal(c.Header.ToString(), LocalizedStrings.Get("MEDIA_BIN_TABLE_VIEW_COLUMN_NAME_title")) == 0);
		if (dataGridColumn != null)
		{
			CueList.CurrentCell = new DataGridCellInfo(row.Item, dataGridColumn);
			CueList.BeginEdit();
		}
	}

	private void MediaCueListView_IsVisibleChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		if ((bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue)
		{
			CueList.SetBinding(ItemsControl.ItemsSourceProperty, new Binding("MediaItems")
			{
				Source = this
			});
			CueList.SetBinding(DataGridBase<IMediaCueThumbnailVM, Pro.UI.Controls.DataGridRow>.SelectedDataGridItemProperty, new Binding("SelectedMediaItem")
			{
				Source = this
			});
			CueList.SetBinding(DataGridBase<IMediaCueThumbnailVM, Pro.UI.Controls.DataGridRow>.SelectedDataGridItemsProperty, new Binding("SelectedMediaItems")
			{
				Source = this
			});
		}
		else
		{
			BindingOperations.ClearBinding((DependencyObject)(object)CueList, ItemsControl.ItemsSourceProperty);
			BindingOperations.ClearBinding((DependencyObject)(object)CueList, DataGridBase<IMediaCueThumbnailVM, Pro.UI.Controls.DataGridRow>.SelectedDataGridItemsProperty);
			BindingOperations.ClearBinding((DependencyObject)(object)CueList, DataGridBase<IMediaCueThumbnailVM, Pro.UI.Controls.DataGridRow>.SelectedDataGridItemProperty);
		}
	}

	private void AdjustRowHeight(int rowCapacity)
	{
		float num = 1f / (float)rowCapacity * 248f;
		((DependencyObject)this).SetValue(MaximumPreviewImageHeightPropertyKey, (object)(int)num);
		((DependencyObject)this).SetValue(MaximumPreviewImageWidthPropertyKey, (object)(int)(num * PreviewWidthAspectRatio));
		OverrideMediaColumnSizing();
	}

	private void OverrideMediaColumnSizing()
	{
		DataGridColumn dataGridColumn = CueList.Columns?[2];
		if (dataGridColumn != null)
		{
			dataGridColumn.Width = DataGridLength.SizeToHeader;
			dataGridColumn.Width = DataGridLength.SizeToCells;
		}
	}

	private void CueNameTextBox_OnLoaded(object? sender, RoutedEventArgs e)
	{
		if (sender is TextBox textBox)
		{
			textBox.Focus();
			textBox.SelectAll();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
