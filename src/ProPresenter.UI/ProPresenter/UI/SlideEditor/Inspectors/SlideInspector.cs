using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text.RegularExpressions.Generated;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.Common.FileSystem;
using Pro.UI.DragDropHelper;
using Pro.UI.Utility;
using ProPresenter.UI.ViewModels.Editor;

namespace ProPresenter.UI.SlideEditor.Inspectors;

public partial class SlideInspector : UserControl, IComponentConnector
{
	private readonly DropTarget _dropTarget;

	[GeneratedRegex("^[a-zA-Z]$")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex ValidInputRegex()
	{
		return _003CRegexGenerator_g_003EF8ACA57CDC3152D75084771C473CAD159A7649D6F35BCED21482230A547BF386A__ValidInputRegex_1.Instance;
	}

	public SlideInspector()
	{
		InitializeComponent();
		_dropTarget = new DropTarget((DependencyObject)(object)chordChartArea);
		DropAction<FileInfo[]> dropAction = _dropTarget.AddFileDrop();
		dropAction.SetIsValidDataPredicate((FileInfo[] f, DragEventArgs _) => f.All((FileInfo i) => i?.FullName.IsChordChartFile() ?? false));
		dropAction.SetOnDataDroppedAction(DropChordChart);
	}

	private void HotkeyTextBox_ValidateTextInput(object? sender, TextCompositionEventArgs e)
	{
		if (sender is TextBox textBox)
		{
			bool flag = ValidInputRegex().IsMatch(e.Text);
			((DependencyObject)textBox).SetCurrentValue(TextBox.TextProperty, (object)(flag ? string.Empty : (e.Source as TextBox)?.Text));
			e.Handled = !flag;
		}
	}

	private void HotkeyTextBox_KeyUp(object? sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		if ((int)e.Key == 6 && sender is TextBox textBox)
		{
			textBox.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
		}
	}

	private void DropChordChart(FileInfo[] files, DragEventArgs e)
	{
		if (base.DataContext is ISlideInspectorVM slideInspectorVM)
		{
			FileInfo fileInfo = files.FirstOrDefault();
			if (fileInfo != null)
			{
				slideInspectorVM.DropChordChartCommand?.Invoke(fileInfo);
			}
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
