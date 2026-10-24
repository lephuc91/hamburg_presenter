using System;
using System.Globalization;
using System.Windows.Data;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Slide.Custom.Elements.Shapes;
using ProPresenter.DO.Slide.Links;
using ProPresenter.DO.Slide.Links.Text.Slide;
using ProPresenter.DO.Timer;
using ProPresenter.UI.SlideEditor;
using ProPresenter.UI.ViewModels.Editor;

namespace ProPresenter.UI.Converters;

public class AddElementCommandParameterConverter : IMultiValueConverter
{
	public object? Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
	{
		if (values.Length != 2 && values.Length != 1)
		{
			return null;
		}
		AddElementCommandParameters addElementCommandParameters = new AddElementCommandParameters();
		object obj = values[0];
		if (!(obj is ShapeType value))
		{
			if (!(obj is SlideMenuTextMode value2))
			{
				if (!(obj is SlideTargetSourceMode value3))
				{
					if (!(obj is ScreenArrangementBase screenArrangementBase))
					{
						if (!(obj is TimerData timerData))
						{
							if (!(obj is PlaybackMarkerIdentifierType value4))
							{
								if (obj is GroupSourceType value5)
								{
									addElementCommandParameters.GroupSourceType = value5;
								}
							}
							else
							{
								addElementCommandParameters.PlaybackMarkerIdentifierType = value4;
							}
						}
						else
						{
							addElementCommandParameters.TimerData = timerData;
						}
					}
					else
					{
						addElementCommandParameters.ScreenArrangementBase = screenArrangementBase;
					}
				}
				else
				{
					addElementCommandParameters.SlideTargetSourceMode = value3;
				}
			}
			else
			{
				addElementCommandParameters.SlideMenuTextMode = value2;
			}
		}
		else
		{
			addElementCommandParameters.NewShape = value;
		}
		if (values.Length == 2 && values[1] is InsertEditorObjectSourceType insertionSource)
		{
			addElementCommandParameters.InsertionSource = insertionSource;
		}
		return addElementCommandParameters;
	}

	public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
