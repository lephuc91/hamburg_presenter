using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.Common.Mathematics;
using Pro.UI.Components;
using ProPresenter.DO.Themes;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.UI.PresentationLibrary;

public partial class NewPresentationDialog : UserControl, IDialogContent, IComponentConnector
{
	public static readonly DependencyProperty DefaultThemeProperty = DependencyProperty.Register("DefaultTheme", typeof(Theme), typeof(NewPresentationDialog));

	public Theme DefaultTheme
	{
		get
		{
			return (Theme)((DependencyObject)this).GetValue(DefaultThemeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DefaultThemeProperty, (object)value);
		}
	}

	public event Action? Accept;

	public event Action? Cancel;

	public NewPresentationDialog()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		InitializeComponent();
		base.DataContextChanged += new DependencyPropertyChangedEventHandler(NewPresentationDialog_DataContextChanged);
	}

	private void NewPresentationDialog_DataContextChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		if (((DependencyPropertyChangedEventArgs)(ref e)).NewValue is INewPresentationVM newPresentationVM)
		{
			newPresentationVM.Size = (sizeSelector.DataContext as SizeSelectorVM)?.SelectedSize ?? Vector2<double>.Zero;
			newPresentationVM.CloseDialog += this.Accept;
		}
	}

	private void CancelBtn_Click(object? sender, RoutedEventArgs e)
	{
		this.Cancel?.Invoke();
		if (base.DataContext is INewPresentationVM newPresentationVM)
		{
			newPresentationVM.CanSelectPlaylist = true;
			newPresentationVM.SelectPlaylistCommand.Execute(null);
		}
	}

	private void PresentationName_GotFocus(object? sender, RoutedEventArgs e)
	{
		PresentationName.SelectAll();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
