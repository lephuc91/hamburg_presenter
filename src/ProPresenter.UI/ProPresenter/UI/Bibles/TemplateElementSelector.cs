using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.UI.Components;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Themes;

namespace ProPresenter.UI.Bibles;

public partial class TemplateElementSelector : UserControl, IComponentConnector
{
	public static readonly DependencyProperty SelectedElementProperty = DependencyProperty.Register("SelectedElement", typeof(SlideElementBase), typeof(TemplateElementSelector));

	public static readonly DependencyProperty TemplateSlideProperty = DependencyProperty.Register("TemplateSlide", typeof(TemplateSlide), typeof(TemplateElementSelector));

	public static readonly DependencyProperty SelectElementCommandProperty = DependencyProperty.Register("SelectElementCommand", typeof(ICommand<SlideElementBase>), typeof(TemplateElementSelector));

	public static readonly DependencyProperty AllowReferenceWithVerseProperty = DependencyProperty.Register("AllowReferenceWithVerse", typeof(bool), typeof(TemplateElementSelector), new PropertyMetadata((object)false));

	public static readonly DependencyProperty IsReferenceWithVerseActiveProperty = DependencyProperty.Register("IsReferenceWithVerseActive", typeof(bool), typeof(TemplateElementSelector), new PropertyMetadata((object)false));

	public static readonly DependencyProperty SelectReferenceWithVerseCommandProperty = DependencyProperty.Register("SelectReferenceWithVerseCommand", typeof(ICommand), typeof(TemplateElementSelector));

	public SlideElementBase? SelectedElement
	{
		get
		{
			return (SlideElementBase)((DependencyObject)this).GetValue(SelectedElementProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedElementProperty, (object)value);
		}
	}

	public TemplateSlide? TemplateSlide
	{
		get
		{
			return (TemplateSlide)((DependencyObject)this).GetValue(TemplateSlideProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TemplateSlideProperty, (object)value);
		}
	}

	public ICommand<SlideElementBase>? SelectElementCommand
	{
		get
		{
			return (ICommand<SlideElementBase>)((DependencyObject)this).GetValue(SelectElementCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectElementCommandProperty, (object)value);
		}
	}

	public bool AllowReferenceWithVerse
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(AllowReferenceWithVerseProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AllowReferenceWithVerseProperty, (object)value);
		}
	}

	public bool IsReferenceWithVerseActive
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsReferenceWithVerseActiveProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsReferenceWithVerseActiveProperty, (object)value);
		}
	}

	public ICommand? SelectReferenceWithVerseCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(SelectReferenceWithVerseCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectReferenceWithVerseCommandProperty, (object)value);
		}
	}

	public TemplateElementSelector()
	{
		InitializeComponent();
	}
}
