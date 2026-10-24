using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using Pro.UI.Controls.Windowing;
using Pro.UI.Utility;

namespace Pro.UI.DialogService;

public partial class DialogTemplate : ChromedWindow, IComponentConnector
{
	private bool _isButtonClicked;

	public static readonly DependencyProperty DialogIconProperty = DependencyProperty.Register("DialogIcon", typeof(ImageSource), typeof(DialogTemplate), new PropertyMetadata((PropertyChangedCallback)null)
	{
		CoerceValueCallback = new CoerceValueCallback(CoerceDialogIconValueCallback)
	});

	public static readonly DependencyProperty HideIconProperty = DependencyProperty.Register("HideIcon", typeof(bool), typeof(DialogTemplate), new PropertyMetadata((object)false));

	public bool IsCancel { get; private set; }

	public ImageSource? DialogIcon
	{
		get
		{
			return (ImageSource)((DependencyObject)this).GetValue(DialogIconProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DialogIconProperty, (object)value);
		}
	}

	public bool HideIcon
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(HideIconProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HideIconProperty, (object)value);
		}
	}

	private static object? CoerceDialogIconValueCallback(DependencyObject d, object baseValue)
	{
		if (baseValue is ImageSource)
		{
			return baseValue;
		}
		return null;
	}

	public DialogTemplate(DependencyObject messageContent)
	{
		InitializeComponent();
		CustomContent.Content = messageContent;
	}

	private void Dialog_KeyDown(object? sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if ((int)e.Key == 13 && base.CanClose)
		{
			IsCancel = true;
			Close();
		}
	}

	private void Dialog_PreviewKeyDown(object? sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		_isButtonClicked = (int)e.Key == 6;
	}

	protected override void OnClosing(CancelEventArgs e)
	{
		if (!IsCancel && !_isButtonClicked)
		{
			IsCancel = true;
		}
		base.OnClosing(e);
	}

	protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
	{
		_isButtonClicked = e.FindHitElement<Button>(this) != null;
		base.OnPreviewMouseDown(e);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
