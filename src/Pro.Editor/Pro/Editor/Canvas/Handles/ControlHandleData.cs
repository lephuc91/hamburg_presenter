using System;
using System.ComponentModel;
using Pro.Common.Mathematics;
using Pro.Editor.Canvas.ToolTips;

namespace Pro.Editor.Canvas.Handles;

public class ControlHandleData : IHandleData
{
	private readonly Func<Vector2<double>> _getLocation;

	private readonly Action<Vector2<double>, Vector2<double>, Vector2<double>> _handleDragged;

	private readonly Func<PropertyChangedEventArgs, bool> _didCornerRadiusHandleMove;

	public ShapeToolTip? ToolTip { get; }

	public ControlHandleData(Func<Vector2<double>> getLocation, Action<Vector2<double>, Vector2<double>, Vector2<double>> handleDragged, Func<PropertyChangedEventArgs, bool> didCornerRadiusHandleMove, ShapeToolTip? toolTip = null)
	{
		_getLocation = getLocation;
		_handleDragged = handleDragged;
		_didCornerRadiusHandleMove = didCornerRadiusHandleMove;
		ToolTip = toolTip;
	}

	public Vector2<double> GetLocation()
	{
		return _getLocation();
	}

	public void HandleDragged(Vector2<double> start, Vector2<double> end, Vector2<double> delta)
	{
		_handleDragged(start, end, delta);
	}

	public bool DidCornerRadiusHandleMove(PropertyChangedEventArgs args)
	{
		return _didCornerRadiusHandleMove(args);
	}
}
