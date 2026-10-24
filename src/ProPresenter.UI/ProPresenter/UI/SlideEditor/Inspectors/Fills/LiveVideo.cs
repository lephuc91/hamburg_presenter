using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using ProPresenter.DO.LiveVideo;
using ProPresenter.DO.Media;

namespace ProPresenter.UI.SlideEditor.Inspectors.Fills;

public partial class LiveVideo : UserControl, IComponentConnector
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static DependencyPropertyChangedEventHandler _003C_003E9__12_0;

		internal void _003C_002Ector_003Eb__12_0(object s, DependencyPropertyChangedEventArgs e)
		{
			CommandManager.InvalidateRequerySuggested();
		}
	}

	public static readonly DependencyProperty AvailableInputsProperty = DependencyProperty.Register("AvailableInputs", typeof(LiveVideoInputCollection), typeof(LiveVideo));

	public static readonly DependencyProperty LiveVideoMediaProperty = DependencyProperty.Register("LiveVideoMedia", typeof(LiveVideoMedia), typeof(LiveVideo));

	public static readonly DependencyProperty OpenSetupCommandProperty = DependencyProperty.Register("OpenSetupCommand", typeof(ICommand), typeof(LiveVideo));

	public LiveVideoInputCollection? AvailableInputs
	{
		get
		{
			return (LiveVideoInputCollection)((DependencyObject)this).GetValue(AvailableInputsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AvailableInputsProperty, (object)value);
		}
	}

	public LiveVideoMedia? LiveVideoMedia
	{
		get
		{
			return (LiveVideoMedia)((DependencyObject)this).GetValue(LiveVideoMediaProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LiveVideoMediaProperty, (object)value);
		}
	}

	public ICommand? OpenSetupCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(OpenSetupCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(OpenSetupCommandProperty, (object)value);
		}
	}

	public LiveVideo()
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		InitializeComponent();
		object obj = _003C_003Ec._003C_003E9__12_0;
		if (obj == null)
		{
			DependencyPropertyChangedEventHandler val = delegate
			{
				CommandManager.InvalidateRequerySuggested();
			};
			_003C_003Ec._003C_003E9__12_0 = val;
			obj = (object)val;
		}
		base.IsVisibleChanged += (DependencyPropertyChangedEventHandler)obj;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
