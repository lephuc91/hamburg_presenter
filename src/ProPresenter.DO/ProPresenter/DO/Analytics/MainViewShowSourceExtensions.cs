using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics;

public static class MainViewShowSourceExtensions
{
	public static MainViewShow.Types.Source ToProtoMainViewShownSource(this MainViewSource source)
	{
		return source switch
		{
			MainViewSource.Toolbar => MainViewShow.Types.Source.Toolbar, 
			MainViewSource.ApplicationMenu => MainViewShow.Types.Source.ApplicationMenu, 
			_ => MainViewShow.Types.Source.Unknown, 
		};
	}

	public static MainViewPresentationEditor.Types.Source ToProtoMainViewPresentationEditorSource(this MainViewSource source)
	{
		return source switch
		{
			MainViewSource.Toolbar => MainViewPresentationEditor.Types.Source.Toolbar, 
			MainViewSource.ApplicationMenu => MainViewPresentationEditor.Types.Source.ApplicationMenu, 
			MainViewSource.ContextMenu => MainViewPresentationEditor.Types.Source.ContextMenu, 
			_ => MainViewPresentationEditor.Types.Source.Unknown, 
		};
	}

	public static MainViewReflowEditor.Types.Source ToProtoMainViewReflowEditorShownSource(this MainViewSource source)
	{
		return source switch
		{
			MainViewSource.Toolbar => MainViewReflowEditor.Types.Source.Toolbar, 
			MainViewSource.ApplicationMenu => MainViewReflowEditor.Types.Source.ApplicationMenu, 
			MainViewSource.LibraryContextMenu => MainViewReflowEditor.Types.Source.LibraryContextMenu, 
			_ => MainViewReflowEditor.Types.Source.Unknown, 
		};
	}

	public static MainViewBible.Types.Source ToProtoMainViewBibleShownSource(this MainViewSource source)
	{
		return source switch
		{
			MainViewSource.Toolbar => MainViewBible.Types.Source.Toolbar, 
			MainViewSource.ApplicationMenu => MainViewBible.Types.Source.ApplicationMenu, 
			_ => MainViewBible.Types.Source.Unknown, 
		};
	}

	public static MainViewStageEditor.Types.StageSource ToProtoMainViewStageEditorSource(this MainViewSource source)
	{
		return source switch
		{
			MainViewSource.Toolbar => MainViewStageEditor.Types.StageSource.Toolbar, 
			MainViewSource.ApplicationMenu => MainViewStageEditor.Types.StageSource.ApplicationMenu, 
			MainViewSource.LowerRight => MainViewStageEditor.Types.StageSource.LowerRight, 
			_ => MainViewStageEditor.Types.StageSource.Unknown, 
		};
	}

	public static MainViewThemeEditor.Types.ThemeSource ToProtoMainViewThemeEditorSource(this MainViewSource source)
	{
		return source switch
		{
			MainViewSource.Toolbar => MainViewThemeEditor.Types.ThemeSource.Toolbar, 
			MainViewSource.ThemeContextMenu => MainViewThemeEditor.Types.ThemeSource.ThemeContextMenu, 
			_ => MainViewThemeEditor.Types.ThemeSource.StageSourceUnknown, 
		};
	}

	public static MainViewCopyrightEditor.Types.CopyrightSource ToProtoMainViewCopyRightEditorSource(this MainViewSource source)
	{
		return source switch
		{
			MainViewSource.Toolbar => MainViewCopyrightEditor.Types.CopyrightSource.Toolbar, 
			MainViewSource.Preference => MainViewCopyrightEditor.Types.CopyrightSource.Preference, 
			_ => MainViewCopyrightEditor.Types.CopyrightSource.Unknown, 
		};
	}

	public static MainViewPropsEditor.Types.PropsSource ToProtoMainViewPropsEditorSource(this MainViewSource source)
	{
		return source switch
		{
			MainViewSource.Toolbar => MainViewPropsEditor.Types.PropsSource.Toolbar, 
			MainViewSource.LowerRight => MainViewPropsEditor.Types.PropsSource.LowerRight, 
			_ => MainViewPropsEditor.Types.PropsSource.Unknown, 
		};
	}

	public static MainViewMaskEditor.Types.MaskSource ToProtoMainViewMaskEditorSource(this MainViewSource source)
	{
		return source switch
		{
			MainViewSource.Toolbar => MainViewMaskEditor.Types.MaskSource.Toolbar, 
			MainViewSource.LooksWindow => MainViewMaskEditor.Types.MaskSource.LooksWindow, 
			_ => MainViewMaskEditor.Types.MaskSource.Unknown, 
		};
	}
}
