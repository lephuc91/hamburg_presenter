using System;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace ProPresenter.UI.SlideEditor.Inspectors.Fills;

public partial class Media : UserControl, IComponentConnector
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static DependencyPropertyChangedEventHandler _003C_003E9__8_0;

		internal void _003C_002Ector_003Eb__8_0(object s, DependencyPropertyChangedEventArgs e)
		{
			CommandManager.InvalidateRequerySuggested();
		}
	}

	public static readonly DependencyProperty EditMediaCommandProperty = DependencyProperty.Register("EditMediaCommand", typeof(ICommand), typeof(Media));

	public static readonly DependencyProperty CreateMediaFillCommandProperty = DependencyProperty.Register("CreateMediaFillCommand", typeof(ICommand), typeof(Media));

	public ICommand? EditMediaCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(EditMediaCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(EditMediaCommandProperty, (object)value);
		}
	}

	public ICommand? CreateMediaFillCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(CreateMediaFillCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CreateMediaFillCommandProperty, (object)value);
		}
	}

	public Media()
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		InitializeComponent();
		object obj = _003C_003Ec._003C_003E9__8_0;
		if (obj == null)
		{
			DependencyPropertyChangedEventHandler val = delegate
			{
				CommandManager.InvalidateRequerySuggested();
			};
			_003C_003Ec._003C_003E9__8_0 = val;
			obj = (object)val;
		}
		base.IsVisibleChanged += (DependencyPropertyChangedEventHandler)obj;
	}
}
