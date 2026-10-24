using System;
using Pro.Common.SourceGenerator.Attributes;
using ProPresenter.DO.Workspaces;
using ProPresenter.UI.ViewModels.Workspaces;

namespace ProPresenter.ViewModels.Workspaces;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(ProPresenter.UI.ViewModels.Workspaces.WorkspaceType), typeof(ProPresenter.DO.Workspaces.WorkspaceType), SourceToDestinationMethodName = "ToDOWorkspaceType", DestinationToSourceMethodName = "ToUIWorkspaceType")]
internal static class WorkspaceTypeExtensions
{
	public static ProPresenter.DO.Workspaces.WorkspaceType ToDOWorkspaceType(this ProPresenter.UI.ViewModels.Workspaces.WorkspaceType source)
	{
		return source switch
		{
			ProPresenter.UI.ViewModels.Workspaces.WorkspaceType.Local => ProPresenter.DO.Workspaces.WorkspaceType.Local, 
			ProPresenter.UI.ViewModels.Workspaces.WorkspaceType.Cloud => ProPresenter.DO.Workspaces.WorkspaceType.Cloud, 
			ProPresenter.UI.ViewModels.Workspaces.WorkspaceType.Synced => ProPresenter.DO.Workspaces.WorkspaceType.Synced, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static ProPresenter.UI.ViewModels.Workspaces.WorkspaceType ToUIWorkspaceType(this ProPresenter.DO.Workspaces.WorkspaceType source)
	{
		return source switch
		{
			ProPresenter.DO.Workspaces.WorkspaceType.Local => ProPresenter.UI.ViewModels.Workspaces.WorkspaceType.Local, 
			ProPresenter.DO.Workspaces.WorkspaceType.Cloud => ProPresenter.UI.ViewModels.Workspaces.WorkspaceType.Cloud, 
			ProPresenter.DO.Workspaces.WorkspaceType.Synced => ProPresenter.UI.ViewModels.Workspaces.WorkspaceType.Synced, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}
}
