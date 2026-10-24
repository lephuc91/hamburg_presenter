using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using ProPresenter.UI.ViewModels.Workspaces;

namespace ProPresenter.UI.Converters;

[ValueConversion(typeof(WorkspaceType), typeof(Visibility))]
public class WorkspaceToVisibilityConverter : IMultiValueConverter
{
	public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
	{
		if (parameter is WorkspaceOperation workspaceOperation)
		{
			WorkspaceType? workspaceType = ((values.Length != 0 && values[0] is WorkspaceType value) ? new WorkspaceType?(value) : ((WorkspaceType?)null));
			bool flag2 = values.Length > 1 && values[1] is bool flag && flag;
			return workspaceOperation switch
			{
				WorkspaceOperation.Publish => (!(workspaceType == WorkspaceType.Local && flag2)) ? Visibility.Collapsed : Visibility.Visible, 
				WorkspaceOperation.OpenRemote => (!(workspaceType == WorkspaceType.Cloud && flag2)) ? Visibility.Collapsed : Visibility.Visible, 
				WorkspaceOperation.Rename => Visibility.Visible, 
				WorkspaceOperation.Duplicate => (workspaceType != WorkspaceType.Local && workspaceType != WorkspaceType.Synced) ? Visibility.Collapsed : Visibility.Visible, 
				WorkspaceOperation.OpenInExplorer => (workspaceType == WorkspaceType.Cloud) ? Visibility.Collapsed : Visibility.Visible, 
				WorkspaceOperation.DownloadCloudWorkspace => (!(workspaceType == WorkspaceType.Cloud && flag2)) ? Visibility.Collapsed : Visibility.Visible, 
				WorkspaceOperation.Delete => (workspaceType == WorkspaceType.Cloud) ? Visibility.Collapsed : Visibility.Visible, 
				WorkspaceOperation.ConvertSyncedToLocal => (!(workspaceType == WorkspaceType.Synced && flag2)) ? Visibility.Collapsed : Visibility.Visible, 
				_ => Visibility.Visible, 
			};
		}
		return Visibility.Visible;
	}

	public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
