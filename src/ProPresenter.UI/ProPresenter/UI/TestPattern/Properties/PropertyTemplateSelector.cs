using System;
using System.Windows;
using System.Windows.Controls;
using ProPresenter.UI.ViewModels.TestPattern.Property;

namespace ProPresenter.UI.TestPattern.Properties;

public class PropertyTemplateSelector : DataTemplateSelector
{
	private const string BoolPropertyView = "BoolPropertyView";

	private const string DoublePropertyView = "DoublePropertyView";

	private const string IntPropertyView = "IntPropertyView";

	private const string StringPropertyView = "StringPropertyView";

	private const string ColorPropertyView = "ColorPropertyView";

	private const string FontPropertyView = "FontPropertyView";

	private const string SelectorPropertyView = "SelectorPropertyView";

	private const string PropertyViewResources = "pack://application:,,,/ProPresenter.UI;component/TestPattern/Properties/PropertyViewResources.xaml";

	private readonly ResourceDictionary _resources;

	public PropertyTemplateSelector()
	{
		_resources = new ResourceDictionary
		{
			Source = new Uri("pack://application:,,,/ProPresenter.UI;component/TestPattern/Properties/PropertyViewResources.xaml")
		};
	}

	public override DataTemplate? SelectTemplate(object item, DependencyObject container)
	{
		if (item is ITestPatternPropertyVM testPatternPropertyVM)
		{
			object obj = ((testPatternPropertyVM is IColorPropertyVM) ? _resources["ColorPropertyView"] : ((testPatternPropertyVM is IDoublePropertyVM) ? _resources["DoublePropertyView"] : ((testPatternPropertyVM is IIntPropertyVM) ? _resources["IntPropertyView"] : ((testPatternPropertyVM is IBoolPropertyVM) ? _resources["BoolPropertyView"] : ((testPatternPropertyVM is IStringPropertyVM) ? _resources["StringPropertyView"] : ((!(testPatternPropertyVM is IFontPropertyVM)) ? null : _resources["FontPropertyView"]))))));
			return obj as DataTemplate;
		}
		return null;
	}
}
