using System.ComponentModel;
using System.Windows.Media;
using Pro.Common.Components;
using Pro.Text;

namespace ProPresenter.DO.PanelViewSettings;

public abstract class PanelViewSettingsBase : NotifyPropertyChangedBase, IPanelViewSettings, INotifyPropertyChanged
{
	private bool _byGroups;

	private bool _showScrimItems = true;

	private bool _useBackgroundColor;

	private Color _backgroundColor = Colors.Black;

	private FontInfo _font = RunSettings.DefaultFont;

	private int _characterSize = 14;

	private Color _textColor = Colors.White;

	private ParagraphAlignment _horizontalAlignment;

	private DocumentAlignment _verticalAlignment;

	private TruncatingMode _truncatingMode = TruncatingMode.End;

	private bool _showMediaActions;

	public abstract PanelViewType ViewType { get; }

	public bool ByGroups
	{
		get
		{
			return _byGroups;
		}
		set
		{
			SetValue("ByGroups", ref _byGroups, value, OnByGroupsChanged);
		}
	}

	public bool ShowScrimItems
	{
		get
		{
			return _showScrimItems;
		}
		set
		{
			SetValue("ShowScrimItems", ref _showScrimItems, value, OnShowScrimItemsChanged);
		}
	}

	public bool UseBackgroundColor
	{
		get
		{
			return _useBackgroundColor;
		}
		set
		{
			SetValue("UseBackgroundColor", ref _useBackgroundColor, value, OnUseBackgroundColorChanged);
		}
	}

	public Color BackgroundColor
	{
		get
		{
			return _backgroundColor;
		}
		set
		{
			SetValue("BackgroundColor", ref _backgroundColor, value, OnBackgroundColorChanged);
		}
	}

	public bool UsePreviewColor
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public Color PreviewColor
	{
		get
		{
			return default(Color);
		}
		set
		{
		}
	}

	public FontInfo Font
	{
		get
		{
			return _font;
		}
		set
		{
			SetValue("Font", ref _font, value, OnFontChanged);
		}
	}

	public int CharacterSize
	{
		get
		{
			return _characterSize;
		}
		set
		{
			SetValue("CharacterSize", ref _characterSize, value, OnCharacterSizeChanged);
		}
	}

	public Color TextColor
	{
		get
		{
			return _textColor;
		}
		set
		{
			SetValue("TextColor", ref _textColor, value, OnTextColorChanged);
		}
	}

	public ParagraphAlignment HorizontalAlignment
	{
		get
		{
			return _horizontalAlignment;
		}
		set
		{
			SetValue("HorizontalAlignment", ref _horizontalAlignment, value, OnHorizontalAlignmentChanged);
		}
	}

	public DocumentAlignment VerticalAlignment
	{
		get
		{
			return _verticalAlignment;
		}
		set
		{
			SetValue("VerticalAlignment", ref _verticalAlignment, value, OnVerticalAlignmentChanged);
		}
	}

	public TruncatingMode TruncatingMode
	{
		get
		{
			return _truncatingMode;
		}
		set
		{
			SetValue("TruncatingMode", ref _truncatingMode, value, OnTruncatingModeChanged);
		}
	}

	public bool ShowMediaActions
	{
		get
		{
			return _showMediaActions;
		}
		set
		{
			SetValue("ShowMediaActions", ref _showMediaActions, value, OnShowMediaActionsChanged);
		}
	}

	protected PanelViewSettingsBase(bool byGroups, bool useBackgroundColor, Color backgroundColor, FontInfo font, int characterSize, Color textColor, ParagraphAlignment horizontalAlignment, DocumentAlignment verticalAlignment, TruncatingMode truncatingMode, bool showMediaActions)
		: this(byGroups, useBackgroundColor, backgroundColor)
	{
		_font = font;
		_characterSize = characterSize;
		_textColor = textColor;
		_horizontalAlignment = horizontalAlignment;
		_verticalAlignment = verticalAlignment;
		_truncatingMode = truncatingMode;
		_showMediaActions = showMediaActions;
	}

	protected PanelViewSettingsBase(bool byGroups, bool useBackgroundColor, Color backgroundColor)
	{
		_byGroups = byGroups;
		_useBackgroundColor = useBackgroundColor;
		_backgroundColor = backgroundColor;
	}

	protected virtual void OnByGroupsChanged(bool o, bool n)
	{
	}

	protected virtual void OnShowScrimItemsChanged(bool o, bool n)
	{
	}

	protected virtual void OnUseBackgroundColorChanged(bool o, bool n)
	{
	}

	protected virtual void OnBackgroundColorChanged(Color o, Color n)
	{
	}

	protected virtual void OnFontChanged(FontInfo o, FontInfo n)
	{
	}

	protected virtual void OnCharacterSizeChanged(int o, int n)
	{
	}

	protected virtual void OnTextColorChanged(Color o, Color n)
	{
	}

	protected virtual void OnHorizontalAlignmentChanged(ParagraphAlignment o, ParagraphAlignment n)
	{
	}

	protected virtual void OnVerticalAlignmentChanged(DocumentAlignment o, DocumentAlignment n)
	{
	}

	protected virtual void OnTruncatingModeChanged(TruncatingMode o, TruncatingMode n)
	{
	}

	protected virtual void OnShowMediaActionsChanged(bool o, bool n)
	{
	}
}
