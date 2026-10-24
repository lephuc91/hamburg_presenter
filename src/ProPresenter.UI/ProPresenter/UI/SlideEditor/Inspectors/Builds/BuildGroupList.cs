using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.Common.Collections;
using Pro.Common.Mathematics;
using Pro.Common.Utility;
using Pro.UI.DragDropHelper;
using Pro.UI.Utility;
using ProPresenter.DO.Slide.Builds;
using ProPresenter.UI.ViewModels.Editor;

namespace ProPresenter.UI.SlideEditor.Inspectors.Builds;

public partial class BuildGroupList : UserControl, IComponentConnector
{
	private const double MaxBuildGroupThreshold = 5.0;

	private const double BuildStepFirstLastDropIndicatorOffset = -2.0;

	private const double BuildGroupDropIndicatorOffset = 3.8;

	private readonly DragSource _dragSource;

	private readonly DropTarget _dropTarget;

	private Vector2<double> _mouseDownPosition;

	private int _dropIndex = -1;

	private bool _isInside;

	private bool _isHead;

	private bool _isTheSameGroup;

	private bool _canStartDrag;

	private IBuildInspectorVM BuildVM => (IBuildInspectorVM)base.DataContext;

	private BuildCollection? Builds => BuildVM.Builds;

	public BuildGroupList()
	{
		InitializeComponent();
		base.AllowDrop = true;
		_dragSource = new DragSource((DependencyObject)(object)this);
		_dropTarget = new DropTarget((DependencyObject)(object)this);
		DropAction<IBuild[]> dropAction = _dropTarget.AddDropType<IBuild[]>();
		dropAction.SetIsValidDataPredicate(IsValidData);
		dropAction.SetOnDataEnteredAction(OnDataEntered);
		dropAction.SetOnDataLeftAction(OnDataLeft);
		dropAction.SetOnDataDraggedAction(OnDataDragged);
		dropAction.SetOnDataDroppedAction(OnDataDropped);
	}

	private bool IsValidData(IBuild[] draggedBuilds, DragEventArgs e)
	{
		UpdateDropIndex(draggedBuilds, e);
		int num;
		if (_dropIndex >= 0)
		{
			BuildCollection? builds = Builds;
			if (builds == null)
			{
				num = 0;
			}
			else
			{
				num = (builds.ValidateArrange(draggedBuilds, _dropIndex) ? 1 : 0);
				if (num != 0)
				{
					goto IL_0036;
				}
			}
		}
		else
		{
			num = 0;
		}
		((DependencyObject)(object)this).ResetDropIndicator();
		goto IL_0036;
		IL_0036:
		return (byte)num != 0;
	}

	private void OnDataEntered(IBuild[] draggedBuilds, DragEventArgs e)
	{
		UpdateDropIndex(draggedBuilds, e);
	}

	private void OnDataLeft(IBuild[] draggedBuilds, DragEventArgs e)
	{
		ResetDropIndex();
	}

	private void OnDataDragged(IBuild[] draggedBuilds, DragEventArgs e)
	{
		UpdateDropIndex(draggedBuilds, e);
	}

	private void OnDataDropped(IBuild[] draggedBuilds, DragEventArgs e)
	{
		((DependencyObject)(object)this).ResetDropIndicator();
		Builds?.ArrangeBuildOrder(draggedBuilds, _dropIndex, _isInside, _isHead, _isTheSameGroup);
	}

	protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		_canStartDrag = true;
		_mouseDownPosition = (Vector2<double>)e.GetPosition(this);
	}

	protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
	{
		_canStartDrag = false;
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		if (!_canStartDrag || e.LeftButton != MouseButtonState.Pressed || !e.CanDrag(this, _mouseDownPosition))
		{
			return;
		}
		BuildStep buildStep = e.FindHitElement<BuildStep>(this);
		IBuild build = buildStep?.Build;
		if (build != null)
		{
			IEnumerable<IBuild> enumerable;
			if (!BuildVM.SelectedBuilds.Contains(build))
			{
				enumerable = build.ToEnumerable();
			}
			else
			{
				IEnumerable<IBuild> enumerable2 = BuildVM.SelectedBuilds.ToArray();
				enumerable = enumerable2;
			}
			IEnumerable<IBuild> enumerable3 = enumerable;
			BuildVM.SelectBuilds(enumerable3);
			_dragSource.StartDrag(enumerable3.OrderBy((IBuild i) => Builds?.IndexOf(i) ?? (-1)).ToArray(), buildStep.ToDragVisual(enumerable3.Count(), null), DragDropEffects.Move, (Vector2<double>)e.GetPosition(buildStep));
			_canStartDrag = false;
			e.Handled = true;
		}
	}

	private void UpdateDropIndex(IBuild[] draggedBuilds, DragEventArgs e)
	{
		((DependencyObject)(object)this).ResetDropIndicator();
		_dropIndex = FindDropIndex(draggedBuilds, e, out _isInside, out _isHead, out _isTheSameGroup);
	}

	private int FindDropIndex(IBuild[] draggedBuilds, DragEventArgs e, out bool isInside, out bool isHead, out bool isTheSameGroup)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_024a: Unknown result type (might be due to invalid IL or missing references)
		//IL_024f: Unknown result type (might be due to invalid IL or missing references)
		isInside = false;
		isHead = false;
		isTheSameGroup = false;
		int num = -1;
		IEnumerable<IBuild> builds = Builds;
		IEnumerable<IBuild> source = builds ?? Enumerable.Empty<IBuild>();
		Vector2<double> vector = (Vector2<double>)e.GetPosition(this);
		BuildGroup buildGroup = e.FindHitElement<BuildGroup>(this);
		if (!(buildGroup?.IndicatorElement is FrameworkElement depObj))
		{
			return num;
		}
		BuildStep buildStep = e.FindHitElement<BuildStep>(this);
		Vector2<double> vector2 = (Vector2<double>)buildGroup.TranslatePoint(Vector2<double>.Zero, this);
		Vector2<double> vector3 = vector - vector2;
		double y = vector3.Y;
		Size desiredSize = buildGroup.DesiredSize;
		if (y < Math.Min(((Size)(ref desiredSize)).Height * 0.1, 5.0))
		{
			((DependencyObject)(object)buildStep)?.ResetDropIndicator();
			depObj.ShowDropIndicator(AdornerPosition.Top, 3.8);
			IBuild build = buildGroup.Builds?.FirstOrDefault();
			num = ((build == null) ? (-1) : source.IndexOf(build));
		}
		else
		{
			double y2 = vector3.Y;
			desiredSize = buildGroup.DesiredSize;
			double val = ((Size)(ref desiredSize)).Height * 0.9;
			desiredSize = buildGroup.DesiredSize;
			if (y2 > Math.Max(val, ((Size)(ref desiredSize)).Height - 5.0))
			{
				((DependencyObject)(object)buildStep)?.ResetDropIndicator();
				depObj.ShowDropIndicator(AdornerPosition.Bottom, 3.8);
				IBuild build2 = buildGroup.Builds?.LastOrDefault();
				num = ((build2 == null) ? (-1) : (source.IndexOf(build2) + 1));
			}
			else if (buildStep != null)
			{
				depObj.ShowDropIndicator(AdornerPosition.Inside);
				vector2 = (Vector2<double>)buildStep.TranslatePoint(Vector2<double>.Zero, this);
				vector3 = vector - vector2;
				isInside = true;
				bool flag = buildGroup.Builds?.First() == buildStep.Build;
				bool flag2 = buildGroup.Builds?.Last() == buildStep.Build;
				double y3 = vector3.Y;
				desiredSize = buildStep.DesiredSize;
				if (y3 < ((Size)(ref desiredSize)).Height / 2.0)
				{
					buildStep.ShowDropIndicator(AdornerPosition.Top, flag ? (-2.0) : 0.0);
					num = source.IndexOf<IBuild>(buildStep.Build);
				}
				else
				{
					double y4 = vector3.Y;
					desiredSize = buildStep.DesiredSize;
					if (y4 > ((Size)(ref desiredSize)).Height / 2.0)
					{
						buildStep.ShowDropIndicator(AdornerPosition.Bottom, flag2 ? (-2.0) : 0.0);
						num = source.IndexOf<IBuild>(buildStep.Build) + 1;
					}
				}
				isHead = buildGroup.Builds?.First() == source.ElementAtOrDefault(Math.Min(num, source.Count() - 1)) && num < source.Count();
			}
		}
		isTheSameGroup = buildGroup.Builds?.Contains(draggedBuilds.First()) ?? false;
		return num;
	}

	private void ResetDropIndex()
	{
		_dropIndex = -1;
		((DependencyObject)(object)this).ResetDropIndicator();
	}
}
