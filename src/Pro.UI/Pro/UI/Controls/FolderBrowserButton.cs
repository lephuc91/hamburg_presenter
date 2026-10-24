using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.Common.Utility;
using Pro.UI.Utility;

namespace Pro.UI.Controls;

public partial class FolderBrowserButton : Button, IComponentConnector
{
	public static readonly DependencyProperty TargetPathProperty = DependencyProperty.Register("TargetPath", typeof(string), typeof(FolderBrowserButton), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)string.Empty));

	public static readonly DependencyProperty CanChooseFolderProperty = DependencyProperty.Register("CanChooseFolder", typeof(bool), typeof(FolderBrowserButton), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty IsChoosingFolderProperty = DependencyProperty.Register("IsChoosingFolder", typeof(bool), typeof(FolderBrowserButton));

	public string TargetPath
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(TargetPathProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TargetPathProperty, (object)value);
		}
	}

	public bool CanChooseFolder
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(CanChooseFolderProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanChooseFolderProperty, (object)value);
		}
	}

	public bool IsChoosingFolder
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsChoosingFolderProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsChoosingFolderProperty, (object)value);
		}
	}

	public FolderBrowserButton()
	{
		InitializeComponent();
	}

	protected override void OnClick()
	{
		base.OnClick();
		if (CanChooseFolder)
		{
			string selectedPath;
			if (!IsChoosingFolder)
			{
				ProcessHelper.ShowFileInExplorer(TargetPath);
			}
			else if (DialogHelper.SelectFolderPath(out selectedPath))
			{
				((DependencyObject)this).SetValue(TargetPathProperty, (object)selectedPath);
			}
		}
	}
}
