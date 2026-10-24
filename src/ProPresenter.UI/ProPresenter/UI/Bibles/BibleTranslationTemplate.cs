using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.UI.Components;
using ProPresenter.DO.Bibles;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Themes;

namespace ProPresenter.UI.Bibles;

public partial class BibleTranslationTemplate : UserControl, IComponentConnector
{
	public static readonly DependencyProperty TranslationsProperty = DependencyProperty.Register("Translations", typeof(BibleTranslationCollection), typeof(BibleTranslationTemplate));

	public static readonly DependencyProperty LoadedBiblesProperty = DependencyProperty.Register("LoadedBibles", typeof(LoadedBibleCollection), typeof(BibleTranslationTemplate));

	public static readonly DependencyProperty TemplateSlideProperty = DependencyProperty.Register("TemplateSlide", typeof(TemplateSlide), typeof(BibleTranslationTemplate));

	public static readonly DependencyProperty ReferenceTypeProperty = DependencyProperty.Register("ReferenceType", typeof(ReferenceType), typeof(BibleTranslationTemplate));

	public static readonly DependencyProperty AddBibleTranslationCommandProperty = DependencyProperty.Register("AddBibleTranslationCommand", typeof(ICommand), typeof(BibleTranslationTemplate));

	public static readonly DependencyProperty RemoveBibleTranslationCommandProperty = DependencyProperty.Register("RemoveBibleTranslationCommand", typeof(ICommand<BibleTranslation>), typeof(BibleTranslationTemplate));

	public static readonly DependencyProperty SelectVerseElementCommandProperty = DependencyProperty.Register("SelectVerseElementCommand", typeof(ICommand<(SlideElementBase, BibleTranslation)>), typeof(BibleTranslationTemplate));

	public static readonly DependencyProperty SelectReferenceElementCommandProperty = DependencyProperty.Register("SelectReferenceElementCommand", typeof(ICommand<(SlideElementBase, BibleTranslation)>), typeof(BibleTranslationTemplate));

	public static readonly DependencyProperty SelectIncludeReferenceWithVerseCommandProperty = DependencyProperty.Register("SelectIncludeReferenceWithVerseCommand", typeof(ICommand<BibleTranslation>), typeof(BibleTranslationTemplate));

	public BibleTranslationCollection? Translations
	{
		get
		{
			return (BibleTranslationCollection)((DependencyObject)this).GetValue(TranslationsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TranslationsProperty, (object)value);
		}
	}

	public LoadedBibleCollection? LoadedBibles
	{
		get
		{
			return (LoadedBibleCollection)((DependencyObject)this).GetValue(LoadedBiblesProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LoadedBiblesProperty, (object)value);
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

	public ReferenceType? ReferenceType
	{
		get
		{
			return (ReferenceType?)((DependencyObject)this).GetValue(ReferenceTypeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ReferenceTypeProperty, (object)value);
		}
	}

	public ICommand? AddBibleTranslationCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(AddBibleTranslationCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AddBibleTranslationCommandProperty, (object)value);
		}
	}

	public ICommand<BibleTranslation>? RemoveBibleTranslationCommand
	{
		get
		{
			return (ICommand<BibleTranslation>)((DependencyObject)this).GetValue(RemoveBibleTranslationCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RemoveBibleTranslationCommandProperty, (object)value);
		}
	}

	public ICommand<(SlideElementBase, BibleTranslation)>? SelectVerseElementCommand
	{
		get
		{
			return (ICommand<(SlideElementBase, BibleTranslation)>)((DependencyObject)this).GetValue(SelectVerseElementCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectVerseElementCommandProperty, (object)value);
		}
	}

	public ICommand<(SlideElementBase, BibleTranslation)>? SelectReferenceElementCommand
	{
		get
		{
			return (ICommand<(SlideElementBase, BibleTranslation)>)((DependencyObject)this).GetValue(SelectReferenceElementCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectReferenceElementCommandProperty, (object)value);
		}
	}

	public ICommand<BibleTranslation>? SelectIncludeReferenceWithVerseCommand
	{
		get
		{
			return (ICommand<BibleTranslation>)((DependencyObject)this).GetValue(SelectIncludeReferenceWithVerseCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectIncludeReferenceWithVerseCommandProperty, (object)value);
		}
	}

	public ICommand<SlideElementBase> VerseElementCommand => new RelayCommand<SlideElementBase>(delegate(SlideElementBase e)
	{
		if (base.DataContext is BibleTranslation item && SelectVerseElementCommand != null)
		{
			SelectVerseElementCommand.Execute((e, item));
		}
	}, (SlideElementBase e) => base.DataContext is BibleTranslation item2 && SelectVerseElementCommand != null && SelectVerseElementCommand.CanExecute((e, item2)));

	public ICommand<SlideElementBase> ReferenceElementCommand => new RelayCommand<SlideElementBase>(delegate(SlideElementBase e)
	{
		if (base.DataContext is BibleTranslation item && SelectReferenceElementCommand != null)
		{
			SelectReferenceElementCommand.Execute((e, item));
		}
	}, (SlideElementBase e) => base.DataContext is BibleTranslation item2 && SelectReferenceElementCommand != null && SelectReferenceElementCommand.CanExecute((e, item2)));

	public ICommand IncludeReferenceWithVerseCommand => new RelayCommand(delegate
	{
		if (base.DataContext is BibleTranslation parameter && SelectIncludeReferenceWithVerseCommand != null)
		{
			SelectIncludeReferenceWithVerseCommand.Execute(parameter);
		}
	}, () => base.DataContext is BibleTranslation parameter2 && SelectIncludeReferenceWithVerseCommand != null && SelectIncludeReferenceWithVerseCommand.CanExecute(parameter2));

	public BibleTranslationTemplate()
	{
		InitializeComponent();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
