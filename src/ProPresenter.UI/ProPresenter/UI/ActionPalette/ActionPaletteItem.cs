using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.Common.Mathematics;
using Pro.DO.Triggering;
using Pro.UI;
using Pro.UI.DragDropHelper;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Media;

namespace ProPresenter.UI.ActionPalette;

public partial class ActionPaletteItem : UserControl, IComponentConnector
{
	private DragSource _dragSource;

	public ActionPaletteItem()
	{
		InitializeComponent();
		_dragSource = new DragSource((DependencyObject)(object)this);
	}

	protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		if (e.ChangedButton == MouseButton.Left)
		{
			Point position = Mouse.GetPosition(this);
			if (base.DataContext is ClearType context)
			{
				StartDrag(context, position);
			}
			else if (base.DataContext is ActionType context2)
			{
				StartDrag(context2, position);
			}
			else if (base.DataContext is MediaType context3)
			{
				StartDrag(context3, position);
			}
		}
	}

	private void StartDrag<T>(T context, Point pos)
	{
		_dragSource.StartDrag(new DraggedItems<T>(null, new T[1] { context }), new ActionPaletteItem
		{
			DataContext = context
		}, DragDropEffects.Move, new Vector2<double>(((Point)(ref pos)).X, ((Point)(ref pos)).Y));
	}
}
