using System.ComponentModel;
using System.Windows.Media;
using Pro.Text;
using ProPresenter.DO.Settings;

namespace ProPresenter.DO.PanelViewSettings;

public class ListViewSettings : PanelViewSettingsBase
{
	private readonly IApp _app;

	public override PanelViewType ViewType => PanelViewType.List;

	public Color ControlBackgroundColor
	{
		get
		{
			return _app.ListViewControlBackgroundColor;
		}
		set
		{
			_app.ListViewControlBackgroundColor = value;
		}
	}

	public ListViewSettings(IApp app)
		: base(app.ListViewByGroups, app.ListViewUseBackgroundColor, app.ListViewBackgroundColor, app.ListViewFont, app.ListViewCharacterSize, app.ListViewTextColor, app.ListViewHorizontalAlignment, app.ListViewVerticalAlignment, app.ListViewTruncatingMode, showMediaActions: true)
	{
		_app = app;
		_app.PropertyChanged += app_PropertyChanged;
	}

	protected override void OnByGroupsChanged(bool o, bool n)
	{
		_app.ListViewByGroups = n;
	}

	protected override void OnUseBackgroundColorChanged(bool o, bool n)
	{
		_app.ListViewUseBackgroundColor = n;
	}

	protected override void OnBackgroundColorChanged(Color o, Color n)
	{
		_app.ListViewBackgroundColor = n;
	}

	protected override void OnFontChanged(FontInfo o, FontInfo n)
	{
		_app.ListViewFont = n;
	}

	protected override void OnCharacterSizeChanged(int o, int n)
	{
		_app.ListViewCharacterSize = n;
	}

	protected override void OnTextColorChanged(Color o, Color n)
	{
		_app.ListViewTextColor = n;
	}

	protected override void OnHorizontalAlignmentChanged(ParagraphAlignment o, ParagraphAlignment n)
	{
		_app.ListViewHorizontalAlignment = n;
	}

	protected override void OnVerticalAlignmentChanged(DocumentAlignment o, DocumentAlignment n)
	{
		_app.ListViewVerticalAlignment = n;
	}

	protected override void OnTruncatingModeChanged(TruncatingMode o, TruncatingMode n)
	{
		_app.ListViewTruncatingMode = n;
	}

	private void app_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "ListViewControlBackgroundColor")
		{
			OnPropertyChanged("ControlBackgroundColor");
		}
	}
}
