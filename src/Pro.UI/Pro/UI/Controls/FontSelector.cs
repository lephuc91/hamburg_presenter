using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using Pro.Text;

namespace Pro.UI.Controls;

public partial class FontSelector : UserControl, IComponentConnector
{
	private class MissingFontGroup : FontGroup
	{
		public override bool? IsMissing => true;

		public MissingFontGroup(string fontName)
			: base(fontName, fontName, Array.Empty<Font>())
		{
		}
	}

	private static readonly DependencyProperty FontGroupsProperty = DependencyProperty.Register("FontGroups", typeof(FontGroup[]), typeof(FontSelector), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)SharedTypefaceLibrary.Library.AvailableTypefaces.FontGroups, new PropertyChangedCallback(OnFontGroupsOrMissingFontChanged)));

	private static readonly DependencyProperty UnicodeCapableFontProperty = DependencyProperty.Register("UnicodeCapableFont", typeof(Font), typeof(FontSelector), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)SharedTypefaceLibrary.Library.FallbackFont));

	public static readonly DependencyProperty CharacterSizeEnabledProperty = DependencyProperty.Register("CharacterSizeEnabled", typeof(bool), typeof(FontSelector), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty SelectedFontGroupProperty = DependencyProperty.Register("SelectedFontGroup", typeof(FontGroup), typeof(FontSelector), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnSelectedFontGroupChanged)));

	public static readonly DependencyProperty SelectedFontInfoProperty = DependencyProperty.Register("SelectedFontInfo", typeof(FontInfo), typeof(FontSelector), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)RunSettings.DefaultFont));

	public static readonly DependencyProperty MissingFontProperty = DependencyProperty.Register("MissingFont", typeof(string), typeof(FontSelector), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnFontGroupsOrMissingFontChanged)));

	public static readonly DependencyProperty SelectedCharacterSizeProperty = DependencyProperty.Register("SelectedCharacterSize", typeof(int), typeof(FontSelector));

	public static readonly DependencyProperty FontFamilyDropDownOpenProperty = DependencyProperty.Register("FontFamilyDropDownOpen", typeof(bool), typeof(FontSelector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(FontFamilyDropDownOpenChanged)));

	public static readonly DependencyProperty CanChangeCharacterSizeProperty = DependencyProperty.Register("CanChangeCharacterSize", typeof(bool), typeof(FontSelector), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty CustomFontOptionsProperty = DependencyProperty.Register("CustomFontOptions", typeof(IEnumerable), typeof(FontSelector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null));

	public static readonly DependencyProperty SelectedCustomOptionProperty = DependencyProperty.Register("SelectedCustomOption", typeof(object), typeof(FontSelector), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public static readonly DependencyProperty IsEditorModeProperty = DependencyProperty.Register("IsEditorMode", typeof(bool), typeof(FontSelector), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true, new PropertyChangedCallback(OnFontGroupsOrMissingFontChanged)));

	private static readonly DependencyPropertyKey EnhancedFontGroupsPropertyKey = DependencyProperty.RegisterReadOnly("EnhancedFontGroups", typeof(FontGroup[]), typeof(FontSelector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null));

	public static readonly DependencyProperty EnhancedFontGroupsProperty = EnhancedFontGroupsPropertyKey.DependencyProperty;

	public static readonly DependencyProperty DropdownBackgroundProperty = DependencyProperty.Register("DropdownBackground", typeof(Brush), typeof(FontSelector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null));

	public static FontInfo FallbackFont => RunSettings.DefaultFont;

	private FontGroup[] FontGroups
	{
		get
		{
			return (FontGroup[])((DependencyObject)this).GetValue(FontGroupsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FontGroupsProperty, (object)value);
		}
	}

	private Font UnicodeCapableFont
	{
		get
		{
			return (Font)((DependencyObject)this).GetValue(UnicodeCapableFontProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(UnicodeCapableFontProperty, (object)value);
		}
	}

	public bool CharacterSizeEnabled
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(CharacterSizeEnabledProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CharacterSizeEnabledProperty, (object)value);
		}
	}

	public FontGroup SelectedFontGroup
	{
		get
		{
			return (FontGroup)((DependencyObject)this).GetValue(SelectedFontGroupProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedFontGroupProperty, (object)value);
		}
	}

	public FontInfo SelectedFontInfo
	{
		get
		{
			return (FontInfo)((DependencyObject)this).GetValue(SelectedFontInfoProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedFontInfoProperty, (object)value);
		}
	}

	public string MissingFont
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(MissingFontProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MissingFontProperty, (object)value);
		}
	}

	public int SelectedCharacterSize
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(SelectedCharacterSizeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedCharacterSizeProperty, (object)value);
		}
	}

	public bool FontFamilyDropDownOpen
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(FontFamilyDropDownOpenProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FontFamilyDropDownOpenProperty, (object)value);
		}
	}

	public bool CanChangeCharacterSize
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(CanChangeCharacterSizeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanChangeCharacterSizeProperty, (object)value);
		}
	}

	public IEnumerable? CustomFontOptions
	{
		get
		{
			return (IEnumerable)((DependencyObject)this).GetValue(CustomFontOptionsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CustomFontOptionsProperty, (object)value);
		}
	}

	public object? SelectedCustomOption
	{
		get
		{
			return ((DependencyObject)this).GetValue(SelectedCustomOptionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedCustomOptionProperty, value);
		}
	}

	public bool IsEditorMode
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsEditorModeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsEditorModeProperty, (object)value);
		}
	}

	public FontGroup[] EnhancedFontGroups
	{
		get
		{
			return (FontGroup[])((DependencyObject)this).GetValue(EnhancedFontGroupsProperty);
		}
		private set
		{
			((DependencyObject)this).SetValue(EnhancedFontGroupsPropertyKey, (object)value);
		}
	}

	public Brush DropdownBackground
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(DropdownBackgroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DropdownBackgroundProperty, (object)value);
		}
	}

	private static void FontFamilyDropDownOpenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((FontSelector)(object)d).OnFontFamilyDropDownOpenChanged((bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void OnFontGroupsOrMissingFontChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((FontSelector)(object)d).UpdateEnhancedFontGroups();
	}

	private static void OnSelectedFontGroupChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		FontSelector fontSelector = (FontSelector)(object)d;
		if (((DependencyPropertyChangedEventArgs)(ref e)).NewValue is MissingFontGroup)
		{
			((DependencyObject)fontSelector).SetCurrentValue(SelectedFontGroupProperty, ((DependencyPropertyChangedEventArgs)(ref e)).OldValue);
		}
		else
		{
			fontSelector.UpdateEnhancedFontGroups();
		}
	}

	public FontSelector()
	{
		InitializeComponent();
		UpdateEnhancedFontGroups();
	}

	private void OnFontFamilyDropDownOpenChanged(bool isOpen)
	{
		ComboBox comboBox = ((CustomFontOptions != null) ? customFontOptions : fontFamily);
		if (comboBox != null)
		{
			comboBox.IsDropDownOpen = isOpen;
		}
	}

	private void UpdateEnhancedFontGroups()
	{
		FontGroup[] array = FontGroups ?? Array.Empty<FontGroup>();
		if (!ShouldAddMissingFont())
		{
			EnhancedFontGroups = array;
		}
		else
		{
			EnhancedFontGroups = CreateFontGroupsWithMissingFont(array, MissingFont);
		}
	}

	private bool ShouldAddMissingFont()
	{
		if (IsEditorMode && !string.IsNullOrEmpty(MissingFont) && !FontAlreadyExists(MissingFont))
		{
			return !HasValidFontSelection();
		}
		return false;
	}

	private bool FontAlreadyExists(string fontName)
	{
		return (FontGroups ?? Array.Empty<FontGroup>()).Any((FontGroup fg) => string.Equals(fg.DisplayName, fontName, StringComparison.OrdinalIgnoreCase));
	}

	private bool HasValidFontSelection()
	{
		if (((DependencyObject)this).GetValue(SelectedFontGroupProperty) is FontGroup { IsMissing: var isMissing })
		{
			return isMissing != true;
		}
		return false;
	}

	private FontGroup[] CreateFontGroupsWithMissingFont(FontGroup[] fontGroups, string missingFont)
	{
		int num = FindAlphabeticalInsertIndex(fontGroups, missingFont);
		List<FontGroup> list = new List<FontGroup>(fontGroups.Length + 1);
		for (int i = 0; i < fontGroups.Length; i++)
		{
			if (i == num)
			{
				list.Add(new MissingFontGroup(missingFont));
			}
			list.Add(fontGroups[i]);
		}
		if (num >= fontGroups.Length)
		{
			list.Add(new MissingFontGroup(missingFont));
		}
		return list.ToArray();
	}

	private int FindAlphabeticalInsertIndex(FontGroup[] fontGroups, string missingFont)
	{
		for (int i = 0; i < fontGroups.Length; i++)
		{
			if (string.Compare(missingFont, fontGroups[i].DisplayName, StringComparison.OrdinalIgnoreCase) < 0)
			{
				return i;
			}
		}
		return fontGroups.Length;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
