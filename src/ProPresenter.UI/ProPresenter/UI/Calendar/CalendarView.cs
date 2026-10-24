using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.Localization;

namespace ProPresenter.UI.Calendar;

public partial class CalendarView : UserControl, IComponentConnector
{
	public static string DateFormat { get; } = DateTimeFormatter.GetFormatPattern(FormatLength.Short, FormatLength.Medium, use24HourMode: false);

	public CalendarView()
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
