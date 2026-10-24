using System;
using System.Collections;
using Pro.Common.Components.Reversibility;
using Pro.Common.Utility;
using ProPresenter.DO;
using ProPresenter.DO.Media;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Custom.Elements.Fills;

namespace ProPresenter.UI.SlideEditor.Inspectors;

public class FillPropertyWrapper : CollectionPropertyWrapperBase<ClosedBezierPath, FillType, IFill>
{
	private readonly IMediaFactory _mediaFactory;

	private readonly Func<string> _getContainerId;

	public UndoStack? UndoStack { get; set; }

	public FillPropertyWrapper(IEnumerable elements, IMediaFactory mediaFactory, Func<string> getContainerId)
		: base(elements)
	{
		_mediaFactory = mediaFactory;
		_getContainerId = getContainerId;
	}

	protected override IFill GenerateValue(FillType type)
	{
		return type.GenerateFill(_mediaFactory, _getContainerId());
	}

	protected override IFill GetValue(ClosedBezierPath item)
	{
		return item.Fill;
	}

	protected override FillType GetValueType(ClosedBezierPath item)
	{
		return item.Fill.Type;
	}

	protected override void SetValue(ClosedBezierPath item, IFill value)
	{
		item.Fill = value;
	}

	protected override void StartPropertyChanged(FillType valueType, string propertyName)
	{
		switch (valueType)
		{
		case FillType.Solid:
			if (propertyName == "Color")
			{
				UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ElementSolidColorFill));
			}
			break;
		case FillType.Gradient:
			switch (propertyName)
			{
			case "StartColor":
				UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ElementGradientFillStartColor));
				break;
			case "StopColor":
				UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ElementGradientFillStopColor));
				break;
			case "Angle":
				UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ElementGradientFillAngle));
				break;
			}
			break;
		case FillType.Media:
			switch (propertyName)
			{
			case "ScaleType":
				UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ElementMediaFillScaleType));
				break;
			case "Media":
				UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ElementMediaFillMedia));
				break;
			case "CropPosition":
				UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.MediaCropPosition));
				break;
			case "CropSize":
				UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.MediaCropSize));
				break;
			case "CropRotation":
				UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.MediaCropRotation));
				break;
			}
			break;
		case FillType.Live:
			if (!(propertyName == "VideoDevice"))
			{
				if (propertyName == "VideoMode")
				{
					UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.LiveVideoVideoMode));
				}
			}
			else
			{
				UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.LiveVideoVideoDevice));
			}
			break;
		case FillType.HTML:
			if (propertyName == "Url")
			{
				UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.WebMediaUrl));
			}
			break;
		}
	}

	protected override void EndPropertyChanged(FillType valueType, string propertyName)
	{
		UndoStack? undoStack = UndoStack;
		if (undoStack != null && undoStack.IsRecording)
		{
			UndoStack.EndCommit();
		}
	}
}
