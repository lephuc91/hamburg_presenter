using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.Common.Background;
using Pro.UI.DragDropHelper;
using ProPresenter.UI.ViewModels.UserAttachments;

namespace ProPresenter.UI.UserAttachments;

public partial class UserAttachmentListControl : UserControl, IComponentConnector
{
	private DropTarget _dropTarget;

	public static readonly DependencyProperty AttachmentInProgressProperty = DependencyProperty.Register("AttachmentInProgress", typeof(bool), typeof(UserAttachmentListControl), new PropertyMetadata((object)false));

	public bool AttachmentInProgress
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(AttachmentInProgressProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AttachmentInProgressProperty, (object)value);
		}
	}

	public UserAttachmentListControl()
	{
		InitializeComponent();
		base.AllowDrop = true;
		_dropTarget = new DropTarget((DependencyObject)(object)this);
		_dropTarget.AddFileDrop().SetOnDataDroppedAction(OnFileDropped);
	}

	private void OnFileDropped(FileInfo[] droppedFiles, DragEventArgs e)
	{
		if (base.DataContext is IUserAttachmentsVM userAttachmentsVM)
		{
			userAttachmentsVM.Attachments.AddAsync(droppedFiles.Select((FileInfo f) => f.FullName).ToArray()).ExecuteAsync();
		}
	}
}
