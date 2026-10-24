using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using Pro.Common.Collections;
using Pro.Localization;
using ProPresenter.DO.Slide.Builds;

namespace ProPresenter.UI.SlideEditor.Converters;

public class BuildToStartModeTextConverter : IMultiValueConverter
{
	public object Convert(object?[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		if (values.Length >= 3 && values[0] is ObservableCollection<IBuild> observableCollection && values[1] is Dictionary<IBuild, int> dictionary)
		{
			object obj = values[2];
			if (obj is StartMode)
			{
				switch ((StartMode)obj)
				{
				case StartMode.OnClick:
					return LocalizedStrings.Get("EDITOR_BUILD_START_TYPE_ON_CLICK_title");
				case StartMode.WithPrevious:
					if (observableCollection.Count != 1)
					{
						return LocalizedStrings.Get("EDITOR_BUILD_START_TYPE_WITH_PREVIOUS_BUILD_title");
					}
					return LocalizedStrings.Get("EDITOR_BUILD_START_TYPE_WITH_BUILD_title", new object[1] { GetPreviousBuild(observableCollection.First(), dictionary) });
				case StartMode.AfterPrevious:
					if (observableCollection.Count == 1)
					{
						IBuild build = observableCollection.First();
						if (build != dictionary.FirstOrDefault().Key)
						{
							return LocalizedStrings.Get("EDITOR_BUILD_START_TYPE_AFTER_BUILD_title", new object[1] { GetPreviousBuild(build, dictionary) });
						}
						return LocalizedStrings.Get("EDITOR_BUILD_START_TYPE_AFTER_TRANSITION_title");
					}
					return LocalizedStrings.Get("EDITOR_BUILD_START_TYPE_AFTER_PREVIOUS_BUILD_title");
				case StartMode.WithSlide:
					return LocalizedStrings.Get("EDITOR_BUILD_START_TYPE_WITH_SLIDE_title");
				default:
					throw new NotSupportedException();
				}
			}
		}
		return Binding.DoNothing;
	}

	public object[] ConvertBack(object? value, Type[] targetTypes, object? parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}

	private static int GetPreviousBuild(IBuild build, Dictionary<IBuild, int> indexMap)
	{
		KeyValuePair<IBuild, int>[] source = indexMap.ToArray();
		int num = source.Select((KeyValuePair<IBuild, int> kv) => kv.Key).IndexOf(build);
		return source.ElementAtOrDefault(num - 1).Value;
	}
}
