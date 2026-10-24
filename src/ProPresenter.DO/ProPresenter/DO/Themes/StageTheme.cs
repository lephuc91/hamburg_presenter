using System.Windows.Media;
using Pro.Common.FeatureFlag;
using Pro.Common.Mathematics;
using Pro.Common.Utility;
using Pro.DO.Application;
using Pro.DO.Transitions;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Slide.Custom;

namespace ProPresenter.DO.Themes;

public class StageTheme : Theme
{
	protected override bool UseDefaultTemplateName => false;

	public override string ContainerId => "Stage";

	public StageTheme(IProPresenterDOFactoryProvider factoryProvider, ITransitionDescriptionCollection transitionDescriptions, IFlagService flagService)
		: base(factoryProvider, transitionDescriptions, flagService)
	{
		CustomSlide slide = new CustomSlide(factoryProvider, transitionDescriptions)
		{
			UseBackgroundColor = true,
			BackgroundColor = Colors.Black
		};
		ChangeSize(slide);
		Add(new TemplateSlide(factoryProvider, slide, flagService)
		{
			Name = "Blank Layout"
		});
		if (!ProtoHelper.TryReadFile<Stage.Types.Document>("documents/Stage", out Stage.Types.Document data) || data == null)
		{
			return;
		}
		ApplicationData applicationData = ApplicationData.Deserialize(data.ApplicationInfo);
		foreach (Stage.Types.Layout layout in data.Layouts)
		{
			CustomSlide customSlide = new CustomSlide(factoryProvider, transitionDescriptions);
			customSlide.DeserializeSlide(layout.Slide, applicationData, "Stage", null);
			ChangeSize(customSlide);
			TemplateSlide slide2 = new TemplateSlide(factoryProvider, customSlide, flagService)
			{
				Name = layout.Name
			};
			Add(slide2);
		}
	}

	private static void ChangeSize(CustomSlide slide)
	{
		slide.UndoStack?.StartIgnoring();
		slide.ChangeSize(new Vector2<double>(TargetDisplay.PrimaryDisplay.Width, TargetDisplay.PrimaryDisplay.Height));
		slide.UndoStack?.StopIgnoring();
	}
}
