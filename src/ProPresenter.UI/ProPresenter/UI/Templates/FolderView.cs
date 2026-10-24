using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.Common.Collections;
using Pro.UI.Components;
using ProPresenter.DO.Themes;

namespace ProPresenter.UI.Templates;

public partial class FolderView : UserControl, IComponentConnector
{
	public static readonly DependencyProperty IsMediaActionEnabledProperty = DependencyProperty.Register("IsMediaActionEnabled", typeof(bool), typeof(FolderView), new PropertyMetadata((object)true));

	public static readonly DependencyProperty EnableContextMenuOptionsProperty = DependencyProperty.Register("EnableContextMenuOptions", typeof(bool), typeof(FolderView), new PropertyMetadata((object)false));

	public static readonly DependencyProperty DeleteThemeCommandProperty = DependencyProperty.Register("DeleteThemeCommand", typeof(ICommand<Theme>), typeof(FolderView), new PropertyMetadata((PropertyChangedCallback)null));

	public static readonly DependencyProperty CurrentThemeContainerProperty = DependencyProperty.Register("CurrentThemeContainer", typeof(IThemeContainer), typeof(FolderView), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(CurrentThemeContainerChanged)));

	public static readonly DependencyProperty SelectThemeCommandProperty = DependencyProperty.Register("SelectThemeCommand", typeof(ICommand<Theme>), typeof(FolderView));

	public static readonly DependencyProperty SelectThemeFolderCommandProperty = DependencyProperty.Register("SelectThemeFolderCommand", typeof(ICommand<IThemeContainer>), typeof(FolderView));

	public static readonly DependencyProperty ShowRecentsProperty = DependencyProperty.Register("ShowRecents", typeof(bool), typeof(FolderView), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	private static readonly DependencyProperty ThemesProperty = DependencyProperty.Register("Themes", typeof(IEnumerable<IThemeContainer>), typeof(FolderView));

	private static readonly DependencyProperty SubFoldersProperty = DependencyProperty.Register("SubFolders", typeof(IEnumerable<IThemeContainer>), typeof(FolderView));

	public static readonly DependencyProperty SelectedTemplateProperty = DependencyProperty.Register("SelectedTemplate", typeof(TemplateSlide), typeof(FolderView));

	public IThemeContainer CurrentThemeContainer
	{
		get
		{
			return (IThemeContainer)((DependencyObject)this).GetValue(CurrentThemeContainerProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CurrentThemeContainerProperty, (object)value);
		}
	}

	public ICommand<Theme> SelectThemeCommand
	{
		get
		{
			return (ICommand<Theme>)((DependencyObject)this).GetValue(SelectThemeCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectThemeCommandProperty, (object)value);
		}
	}

	public ICommand<IThemeContainer> SelectThemeFolderCommand
	{
		get
		{
			return (ICommand<IThemeContainer>)((DependencyObject)this).GetValue(SelectThemeFolderCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectThemeFolderCommandProperty, (object)value);
		}
	}

	public bool ShowRecents
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowRecentsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowRecentsProperty, (object)value);
		}
	}

	private IEnumerable<IThemeContainer> Themes
	{
		get
		{
			return (IEnumerable<IThemeContainer>)((DependencyObject)this).GetValue(ThemesProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ThemesProperty, (object)value);
		}
	}

	private IEnumerable<IThemeContainer> SubFolders
	{
		get
		{
			return (IEnumerable<IThemeContainer>)((DependencyObject)this).GetValue(SubFoldersProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SubFoldersProperty, (object)value);
		}
	}

	public TemplateSlide SelectedTemplate
	{
		get
		{
			return (TemplateSlide)((DependencyObject)this).GetValue(SelectedTemplateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedTemplateProperty, (object)value);
		}
	}

	public ICommand<Theme> DeleteThemeCommand
	{
		get
		{
			return (ICommand<Theme>)((DependencyObject)this).GetValue(DeleteThemeCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DeleteThemeCommandProperty, (object)value);
		}
	}

	public bool EnableContextMenuOptions
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(EnableContextMenuOptionsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(EnableContextMenuOptionsProperty, (object)value);
		}
	}

	public bool IsMediaActionEnabled
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsMediaActionEnabledProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsMediaActionEnabledProperty, (object)value);
		}
	}

	private static void CurrentThemeContainerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is FolderView folderView)
		{
			IThemeContainer themeContainer = ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as IThemeContainer;
			((DependencyObject)folderView).SetCurrentValue(ThemesProperty, (object)themeContainer?.Children.Where((ThemeContainer c) => c.Children.Empty()).ToArray());
			((DependencyObject)folderView).SetCurrentValue(SubFoldersProperty, (object)themeContainer?.Children.Where((ThemeContainer c) => !c.Children.Empty()).ToArray());
		}
	}

	public FolderView()
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
