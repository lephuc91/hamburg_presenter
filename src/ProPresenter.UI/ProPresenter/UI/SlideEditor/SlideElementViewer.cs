using System.Windows;
using Pro.Editor.Canvas.Controls;
using Pro.UI.Commands;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.UI.ViewModels.Editor;

namespace ProPresenter.UI.SlideEditor;

public class SlideElementViewer : CanvasElementViewer<SlideElementBase>
{
	public SlideElementViewer()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		base.DataContextChanged += (DependencyPropertyChangedEventHandler)delegate(object s, DependencyPropertyChangedEventArgs e)
		{
			base.CommandBindings.Add(CommonApplicationCommands.Delete, ((ISlideEditorVM)((DependencyPropertyChangedEventArgs)(ref e)).NewValue).DeleteUnlockedElementsCommand);
			base.CommandBindings.Add(CommonApplicationCommands.Copy, ((ISlideEditorVM)((DependencyPropertyChangedEventArgs)(ref e)).NewValue).CopyElementsCommand);
			base.CommandBindings.Add(CommonApplicationCommands.CutCommand, ((ISlideEditorVM)((DependencyPropertyChangedEventArgs)(ref e)).NewValue).CutElementsCommand);
			base.CommandBindings.Add(CommonApplicationCommands.Paste, ((ISlideEditorVM)((DependencyPropertyChangedEventArgs)(ref e)).NewValue).PasteElementsCommand);
		};
	}
}
