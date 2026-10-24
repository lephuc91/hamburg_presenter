using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Mathematics;
using Pro.Common.Utility;
using Pro.UI.DragDropHelper;
using Pro.UI.Utility;
using ProPresenter.UI.ViewModels.PCO;

namespace ProPresenter.UI.PCO;

internal class AttachmentItemsControl : ItemsControl
{
	private readonly DragSource _dragSource;

	private bool _canStartDrag;

	private Vector2<double> _mouseDownPos = Vector2<double>.Zero;

	public bool IsDragging => _dragSource.IsDragging;

	public AttachmentItemsControl()
	{
		_dragSource = new DragSource((DependencyObject)(object)this);
	}

	private Visual CreateDragVisual(IAttachmentVM draggedItem)
	{
		return ((ContentPresenter)(object)base.ItemContainerGenerator.ContainerFromItem(draggedItem)).ToDragVisual(1, null);
	}

	protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		_canStartDrag = true;
		_mouseDownPos = (Vector2<double>)e.GetPosition(this);
		base.OnPreviewMouseLeftButtonDown(e);
	}

	protected override void OnPreviewMouseLeftButtonUp(MouseButtonEventArgs e)
	{
		_canStartDrag = false;
		base.OnPreviewMouseLeftButtonUp(e);
	}

	protected override void OnPreviewMouseMove(MouseEventArgs e)
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		if (_canStartDrag && e.LeftButton == MouseButtonState.Pressed && e.CanDrag(this, _mouseDownPos))
		{
			AttachmentItem attachmentItem = e.FindHitElement<AttachmentItem>(this);
			if (!(attachmentItem?.DataContext is IAttachmentVM attachmentVM))
			{
				return;
			}
			_dragSource.StartDrag(attachmentVM.RemoteFile, CreateDragVisual(attachmentVM), DragDropEffects.Copy | DragDropEffects.Move, (Vector2<double>)e.GetPosition(attachmentItem));
			_canStartDrag = false;
			e.Handled = true;
		}
		base.OnPreviewMouseMove(e);
	}
}
