using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using Pro.Common.Utility;
using Pro.UI.Components;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.ClearGroups;
using ProPresenter.UI;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels;

public class ClearGroupCollectionVM : LinkedNotifyPropertyChangedBase, IClearGroupCollectionVM, INotifyPropertyChanged
{
	private readonly DragDropPairedCollection<ClearGroup, IClearGroupItemVM> _clearGroups;

	private IClearGroupItemVM? _activeGroup;

	private bool _renameNextItem;

	private bool _isPopupOpen;

	public ClearGroupCollection ClearGroupCollection { get; }

	public INotifyEnumerableChanged<IClearGroupItemVM> ClearGroups => _clearGroups;

	public IClearGroupItemVM? ActiveGroup
	{
		get
		{
			return _activeGroup;
		}
		set
		{
			SetValue<IClearGroupItemVM>("ActiveGroup", ref _activeGroup, value, delegate(IClearGroupItemVM o, IClearGroupItemVM n)
			{
				if (o != null)
				{
					o.Item.PropertyChanged -= base.RaiseLinkedValues;
				}
				if (n != null)
				{
					n.Item.PropertyChanged += base.RaiseLinkedValues;
				}
				NotifyPropertyChanges();
			});
		}
	}

	private ClearGroup? Group => ActiveGroup?.Item;

	public ObservableCollection<IClearGroupItemVM> SelectedGroups { get; } = new ObservableCollection<IClearGroupItemVM>();

	public BitmapSource? Icon => Group?.Icon;

	public string GroupName
	{
		get
		{
			return Group?.Name ?? string.Empty;
		}
		set
		{
			if (Group != null)
			{
				Group.Name = value;
			}
			OnPropertyChanged("GroupName");
		}
	}

	public bool IsIconTinted
	{
		get
		{
			return Group?.IsIconTinted ?? false;
		}
		set
		{
			if (Group != null)
			{
				Group.IsIconTinted = value;
			}
			OnPropertyChanged("IsIconTinted");
		}
	}

	public System.Windows.Media.Color IconFill => Group?.IconFill ?? Colors.White;

	public System.Windows.Media.Color IconTint
	{
		get
		{
			return Group?.IconTint ?? Colors.White;
		}
		set
		{
			if (Group != null)
			{
				Group.IconTint = value;
			}
			OnPropertyChanged("IconTint");
		}
	}

	public bool ClearAudio
	{
		get
		{
			return Group?.ClearTargets.Contains(ClearType.Audio) ?? false;
		}
		set
		{
			if (value != ClearAudio)
			{
				Group?.ToggleClearTarget(ClearType.Audio);
				OnPropertyChanged("ClearAudio");
			}
		}
	}

	public bool ClearAudioEffects
	{
		get
		{
			return Group?.ClearTargets.Contains(ClearType.AudioEffects) ?? false;
		}
		set
		{
			if (value != ClearAudioEffects)
			{
				Group?.ToggleClearTarget(ClearType.AudioEffects);
				OnPropertyChanged("ClearAudioEffects");
			}
		}
	}

	public bool ClearMessages
	{
		get
		{
			return Group?.ClearTargets.Contains(ClearType.Messages) ?? false;
		}
		set
		{
			if (value != ClearMessages)
			{
				Group?.ToggleClearTarget(ClearType.Messages);
				OnPropertyChanged("ClearMessages");
			}
		}
	}

	public bool ClearProps
	{
		get
		{
			return Group?.ClearTargets.Contains(ClearType.Props) ?? false;
		}
		set
		{
			if (value != ClearProps)
			{
				Group?.ToggleClearTarget(ClearType.Props);
				OnPropertyChanged("ClearProps");
			}
		}
	}

	public bool ClearAnnouncements
	{
		get
		{
			return Group?.ClearTargets.Contains(ClearType.Announcement) ?? false;
		}
		set
		{
			if (value != ClearAnnouncements)
			{
				Group?.ToggleClearTarget(ClearType.Announcement);
				OnPropertyChanged("ClearAnnouncements");
			}
		}
	}

	public bool ClearPresentation
	{
		get
		{
			return Group?.ClearTargets.Contains(ClearType.Slide) ?? false;
		}
		set
		{
			if (value != ClearPresentation)
			{
				Group?.ToggleClearTarget(ClearType.Slide);
				OnPropertyChanged("ClearPresentation");
			}
		}
	}

	public bool ClearPresentationMedia
	{
		get
		{
			return Group?.ClearTargets.Contains(ClearType.Background) ?? false;
		}
		set
		{
			if (value != ClearPresentationMedia)
			{
				Group?.ToggleClearTarget(ClearType.Background);
				OnPropertyChanged("ClearPresentationMedia");
			}
		}
	}

	public bool ClearVideoInput
	{
		get
		{
			return Group?.ClearTargets.Contains(ClearType.LiveVideo) ?? false;
		}
		set
		{
			if (value != ClearVideoInput)
			{
				Group?.ToggleClearTarget(ClearType.LiveVideo);
				OnPropertyChanged("ClearPresentationMedia");
			}
		}
	}

	public bool StopAnnouncementsTimeline
	{
		get
		{
			return Group?.TimelineTargets.Contains(OutputDestination.Announcement) ?? false;
		}
		set
		{
			if (value != StopAnnouncementsTimeline)
			{
				Group?.ToggleTimelineTarget(OutputDestination.Announcement);
				OnPropertyChanged("StopAnnouncementsTimeline");
			}
		}
	}

	public bool ClearPresentationNextSlide
	{
		get
		{
			return Group?.ClearNextSlide ?? false;
		}
		set
		{
			if (value != ClearPresentationNextSlide)
			{
				if (Group != null)
				{
					Group.ClearNextSlide = value;
				}
				OnPropertyChanged("ClearPresentationNextSlide");
			}
		}
	}

	public bool StopPresentationTimeline
	{
		get
		{
			return Group?.TimelineTargets.Contains(OutputDestination.Presentation) ?? false;
		}
		set
		{
			if (value != StopPresentationTimeline)
			{
				Group?.ToggleTimelineTarget(OutputDestination.Presentation);
				OnPropertyChanged("StopPresentationTimeline");
			}
		}
	}

	public bool RenameNextItem
	{
		get
		{
			return _renameNextItem;
		}
		set
		{
			SetValue("RenameNextItem", ref _renameNextItem, value);
		}
	}

	public bool IsPopupOpen
	{
		get
		{
			return _isPopupOpen;
		}
		set
		{
			SetValue("IsPopupOpen", ref _isPopupOpen, value);
		}
	}

	public ValidationRule NameValidationRule { get; }

	public ICommand AddClearGroupCommand => new RelayCommand(OnAddClearGroupCommand);

	public ICommand DeleteClearGroupCommand => new RelayCommand(OnDeleteClearGroupCommand, () => SelectedGroups.Any());

	public ICommand<bool> ToggleVisibilityCommand => new RelayCommand<bool>(OnToggleVisibilityCommand, (bool v) => SelectedGroups.Any());

	public ICommand DuplicateClearGroupCommand => new RelayCommand(OnDuplicateClearGroupCommand, () => SelectedGroups.Any());

	public ICommand GotFocusCommand => new RelayCommand(delegate
	{
		this.StackChanged?.Invoke(ClearGroupCollection.UndoStack);
	});

	public ICommand<ImageType> SelectIconCommand => new RelayCommand<ImageType>(OnSelectIconCommand, (ImageType i) => ActiveGroup != null);

	public ICommand CutCommand => new RelayCommand(OnCutCommand, () => SelectedGroups.Any());

	public ICommand CopyCommand => new RelayCommand(OnCopyCommand, () => SelectedGroups.Any());

	public ICommand PasteCommand => new RelayCommand(OnPasteCommand, () => ClipboardManagerHelper.CanPasteIntoCollection<ClearGroup>());

	public event Action<UndoStack?>? StackChanged;

	public ClearGroupCollectionVM(ClearGroupCollection? clearGroups = null, IStringValueValidator? groupNameValidator = null)
	{
		ClearGroupCollection = clearGroups ?? DataVault.ClearGroups;
		NameValidationRule = new StringValueValidationRule(groupNameValidator ?? new GroupNameValidator(ClearGroupCollection));
		_clearGroups = new DragDropPairedCollection<ClearGroup, IClearGroupItemVM>(ClearGroupCollection, (ClearGroup c) => new ClearGroupItemVM(c, (StringValueValidationRule)NameValidationRule));
		ResetSelection(_clearGroups.FirstOrDefault());
		LinkAction("ClearTargets", NotifyPropertyChanges);
		LinkProperties(new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "IsIconTinted", "IconTint" }), "IconFill");
		LinkProperties("Icon", "Icon");
		LinkProperties("ClearNextSlide", "ClearPresentationNextSlide");
	}

	private void NotifyPropertyChanges()
	{
		OnPropertyChanged("GroupName");
		OnPropertyChanged("IsIconTinted");
		OnPropertyChanged("IconTint");
		OnPropertyChanged("IconFill");
		OnPropertyChanged("Icon");
		OnPropertyChanged("ClearAudio");
		OnPropertyChanged("ClearAudioEffects");
		OnPropertyChanged("ClearMessages");
		OnPropertyChanged("ClearProps");
		OnPropertyChanged("ClearAnnouncements");
		OnPropertyChanged("ClearPresentation");
		OnPropertyChanged("ClearPresentationMedia");
		OnPropertyChanged("ClearVideoInput");
		OnPropertyChanged("StopAnnouncementsTimeline");
		OnPropertyChanged("StopPresentationTimeline");
		OnPropertyChanged("ClearPresentationNextSlide");
	}

	private void OnAddClearGroupCommand()
	{
		RenameNextItem = true;
		ClearGroupCollection.AddClearGroup();
		ResetSelection(ClearGroups.LastOrDefault());
		ClearGroupCreateEvent.Publish();
	}

	private void OnDeleteClearGroupCommand()
	{
		IClearGroupItemVM previous = ClearGroups.GetPrevious<IClearGroupItemVM>(ActiveGroup);
		ClearGroupCollection.RemoveClearGroups(SelectedGroups.Select((IClearGroupItemVM c) => c.Item).ToArray());
		ResetSelection(previous ?? ClearGroups.FirstOrDefault());
		ClearGroupDeleteEvent.Publish();
	}

	private void OnSelectIconCommand(ImageType imageType)
	{
		IsPopupOpen = false;
		if (imageType == ImageType.Custom)
		{
			ImportCustomIcon();
			ClearGroupGroupChangeIconEvent.Publish(ChangeIconType.Custom, IsIconTinted);
		}
		else if (Group != null)
		{
			Group.Icon = null;
			Group.ImageType = imageType;
			ClearGroupGroupChangeIconEvent.Publish(ChangeIconType.Default, IsIconTinted);
		}
	}

	private void ImportCustomIcon()
	{
		OpenFileDialog openFileDialog = new OpenFileDialog
		{
			Filter = FileFilters.ImageOnlyFilter,
			Multiselect = false
		};
		if (openFileDialog.ShowDialog() != true)
		{
			return;
		}
		try
		{
			if (Group == null)
			{
				return;
			}
			int width = 64;
			int height = 64;
			using FileStream stream = new FileStream(openFileDialog.FileName, FileMode.Open);
			using System.Drawing.Image image = System.Drawing.Image.FromStream(stream);
			using Bitmap bitmap = new Bitmap(image, new Size(width, height));
			using MemoryStream memoryStream = new MemoryStream();
			bitmap.Save(memoryStream, new ImageFormat(image.RawFormat.Guid));
			Group.ImageType = ImageType.Custom;
			Group.Icon = memoryStream.ToArray().ToBitmapSource();
		}
		catch (Exception ex)
		{
			Log.Error(ex.Message);
			Log.Error(ex);
		}
	}

	private void OnToggleVisibilityCommand(bool value)
	{
		SelectedGroups.ForEach(delegate(IClearGroupItemVM c)
		{
			c.Item.IsHiddenInPreview = value;
		});
		ClearGroupGroupChangeVisibilityEvent.Publish(value ? ChangeVisibilityType.Hidden : ChangeVisibilityType.Shown);
	}

	private void OnDuplicateClearGroupCommand()
	{
		KeyValuePair<int, IClearGroupItemVM> keyValuePair = (from kvp in SelectedGroups.ToDictionary((IClearGroupItemVM v) => ClearGroupCollection.IndexOf(v.Item))
			orderby kvp.Key
			select kvp).LastOrDefault();
		ClearGroup[] clearGroups = SelectedGroups.Select((IClearGroupItemVM v) => v.Item.Clone()).ToArray();
		ClearGroupCollection.InsertClearGroups(clearGroups, keyValuePair.Key + 1);
	}

	private void OnPasteCommand()
	{
		ClearGroup[] source = SelectedGroups.Select((IClearGroupItemVM i) => i.Item).ToArray();
		int index = (source.Any() ? (source.Max((ClearGroup c) => ClearGroupCollection.IndexOf(c)) + 1) : 0);
		IEnumerable<ClearGroup> pastedGroups = ClipboardManagerHelper.PasteIntoCollection<ClearGroupCollection, ClearGroup>(ClearGroupCollection, index);
		SelectedGroups.Clear();
		SelectedGroups.AddRange(ClearGroups.Where((IClearGroupItemVM m) => pastedGroups.Contains(m.Item)));
	}

	private void OnCopyCommand()
	{
		IOrderedEnumerable<ClearGroup> orderedEnumerable = from s in SelectedGroups.Select((IClearGroupItemVM i) => i.Item).ToArray()
			orderby ClearGroupCollection.IndexOf(s)
			select s;
		if (orderedEnumerable.Any())
		{
			ClipboardManagerHelper.CopyFromCollection(orderedEnumerable);
		}
	}

	private void OnCutCommand()
	{
		OnCopyCommand();
		OnDeleteClearGroupCommand();
	}

	private void ResetSelection(IClearGroupItemVM? item)
	{
		if (item != null)
		{
			SelectedGroups.Clear();
			SelectedGroups.Add(item);
			ActiveGroup = item;
		}
	}
}
