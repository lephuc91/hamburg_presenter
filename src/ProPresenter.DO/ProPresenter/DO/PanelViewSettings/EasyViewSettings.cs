using System.Windows.Media;
using Pro.Text;
using ProPresenter.DO.Settings;

namespace ProPresenter.DO.PanelViewSettings;

public class EasyViewSettings : PanelViewSettingsBase
{
	private readonly IApp _app;

	public override PanelViewType ViewType => PanelViewType.EasyView;

	public EasyViewSettings(IApp app)
		: base(app.EasyViewByGroups, useBackgroundColor: true, app.EasyViewBackgroundColor, app.EasyViewFont, app.EasyViewCharacterSize, app.EasyViewTextColor, app.EasyViewHorizontalAlignment, app.EasyViewVerticalAlignment, app.EasyViewTruncatingMode, app.EasyViewShowMediaActions)
	{
		_app = app;
	}

	protected override void OnByGroupsChanged(bool o, bool n)
	{
		_app.EasyViewByGroups = n;
	}

	protected override void OnBackgroundColorChanged(Color o, Color n)
	{
		_app.EasyViewBackgroundColor = n;
	}

	protected override void OnFontChanged(FontInfo o, FontInfo n)
	{
		_app.EasyViewFont = n;
	}

	protected override void OnCharacterSizeChanged(int o, int n)
	{
		_app.EasyViewCharacterSize = n;
	}

	protected override void OnTextColorChanged(Color o, Color n)
	{
		_app.EasyViewTextColor = n;
	}

	protected override void OnHorizontalAlignmentChanged(ParagraphAlignment o, ParagraphAlignment n)
	{
		_app.EasyViewHorizontalAlignment = n;
	}

	protected override void OnVerticalAlignmentChanged(DocumentAlignment o, DocumentAlignment n)
	{
		_app.EasyViewVerticalAlignment = n;
	}

	protected override void OnTruncatingModeChanged(TruncatingMode o, TruncatingMode n)
	{
		_app.EasyViewTruncatingMode = n;
	}

	protected override void OnShowMediaActionsChanged(bool o, bool n)
	{
		_app.EasyViewShowMediaActions = n;
		OnPropertyChanged("PreviewColor");
	}
}
