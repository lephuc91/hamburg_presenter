using System.Windows.Media;
using ProPresenter.DO.Settings;

namespace ProPresenter.DO.PanelViewSettings;

public class ThumbnailViewSettings : PanelViewSettingsBase
{
	public readonly IApp _app;

	public override PanelViewType ViewType => PanelViewType.Thumbnail;

	public ThumbnailViewSettings(IApp app)
		: this(app.ThumbnailViewByGroups, app.ThumbnailViewUseBackgroundColor, app.ThumbnailViewBackgroundColor, app)
	{
	}

	public ThumbnailViewSettings(bool byGroups, IApp app)
		: this(byGroups, app.ThumbnailViewUseBackgroundColor, app.ThumbnailViewBackgroundColor, app)
	{
	}

	public ThumbnailViewSettings(bool byGroups, bool useBackgroundColor, Color backgroundColor, IApp app)
		: base(byGroups, useBackgroundColor, backgroundColor)
	{
		_app = app;
	}

	protected override void OnByGroupsChanged(bool o, bool n)
	{
		_app.ThumbnailViewByGroups = n;
	}

	protected override void OnUseBackgroundColorChanged(bool o, bool n)
	{
		_app.ThumbnailViewUseBackgroundColor = n;
	}

	protected override void OnBackgroundColorChanged(Color o, Color n)
	{
		_app.ThumbnailViewBackgroundColor = n;
	}
}
