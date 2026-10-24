using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Mathematics;
using Pro.Editor.Canvas.TabStop;
using Pro.Text;
using Pro.UI.Controls;
using ProPresenter.DO.Slide.Custom.Elements;

namespace ProPresenter.UI.SlideEditor.TabStops;

public class TextTabStopControlCollection : TabStopControlCollection
{
	private readonly LeftIndent _lefIndent;

	private readonly RightIndent _rightIndent;

	private readonly FirstLineIndent _firstLineIndent;

	private readonly List<ParagraphSettings> _settings = new List<ParagraphSettings>();

	private ParagraphSettings? _activeSettings;

	private ClosedBezierPath? _textElement;

	private IFormattedTextBox? _editTextBox;

	public override bool IsEditing => _editTextBox != null;

	public TextTabStopControlCollection()
	{
		_lefIndent = new LeftIndent(_settings);
		_rightIndent = new RightIndent(_settings);
		_firstLineIndent = new FirstLineIndent(_settings);
		AddTabStop(_lefIndent);
		AddTabStop(_rightIndent);
		AddTabStop(_firstLineIndent);
	}

	public void SetElement(ClosedBezierPath? textElement)
	{
		if (_textElement != null)
		{
			_textElement.PropertyChanged -= TextElement_PropertyChanged;
			_textElement.Text.Settings.Margins.PropertyChanged -= Margins_PropertyChanged;
		}
		_textElement = textElement;
		_lefIndent.SetElement(_textElement);
		_rightIndent.SetElement(_textElement);
		_firstLineIndent.SetElement(_textElement);
		if (_textElement != null)
		{
			_textElement.PropertyChanged += TextElement_PropertyChanged;
			_textElement.Text.Settings.Margins.PropertyChanged += Margins_PropertyChanged;
		}
		SetTextBox(_textElement?.EditTextbox);
	}

	public void SetTextBox(IFormattedTextBox? editTextBox)
	{
		if (_editTextBox != null)
		{
			_editTextBox.CaretPositionChanged -= EditTextBox_CaretPositionChanged;
		}
		_editTextBox = editTextBox;
		if (_editTextBox != null)
		{
			_editTextBox.CaretPositionChanged += EditTextBox_CaretPositionChanged;
		}
		SetActiveParagraph();
	}

	private void EditTextBox_CaretPositionChanged(Vector2<double> pos, FormattedTextBox.CaretLocation location, double height)
	{
		SetActiveParagraph();
	}

	private void SetActiveParagraph()
	{
		if (_editTextBox == null)
		{
			return;
		}
		List<ParagraphSettings> settings = new List<ParagraphSettings>();
		Pro.Text.Range[] array = _editTextBox.SelectionRanges.Sort();
		foreach (Pro.Text.Range range in array)
		{
			_editTextBox.Document?.IterateParagraphs(range, delegate(Paragraph p)
			{
				settings.Add(p.Settings);
			});
		}
		if (!_settings.ContentsMatchExactly(settings))
		{
			if (_activeSettings != null)
			{
				_activeSettings.PropertyChanged -= Settings_PropertyChanged;
				_activeSettings.TabStops.CollectionChanged -= TabStops_CollectionChanged;
			}
			_settings.Clear();
			base.Collection.OfType<TabStop>().ToArray().ForEach(base.RemoveTabStop);
			_settings.AddRange(settings);
			_activeSettings = _settings.FirstOrDefault();
			if (_activeSettings != null)
			{
				_activeSettings.PropertyChanged += Settings_PropertyChanged;
				_activeSettings.TabStops.CollectionChanged += TabStops_CollectionChanged;
			}
			SetupTabStops(_activeSettings?.TabStops);
			OnPropertyChanged("IsEditing");
			OnVisualInvalidated();
		}
	}

	private void TabStops_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		TeardownTabstop(e.OldItems?.OfType<Pro.Text.TabStop>());
		SetupTabStops(e.NewItems?.OfType<Pro.Text.TabStop>());
		OnVisualInvalidated();
	}

	private void TeardownTabstop(IEnumerable<Pro.Text.TabStop>? tabStops)
	{
		if (tabStops == null)
		{
			return;
		}
		foreach (Pro.Text.TabStop tabStop in tabStops)
		{
			tabStop.PropertyChanged -= TabStop_PropertyChanged;
			TabStop tabStop2 = base.Collection.OfType<TabStop>().FirstOrDefault((TabStop t) => t.TextTabStop == tabStop);
			if (tabStop2 != null)
			{
				RemoveTabStop(tabStop2);
			}
		}
	}

	private void SetupTabStops(IEnumerable<Pro.Text.TabStop>? tabStops)
	{
		if (tabStops == null || _textElement == null)
		{
			return;
		}
		foreach (Pro.Text.TabStop tabStop2 in tabStops)
		{
			tabStop2.PropertyChanged += TabStop_PropertyChanged;
			TabStop tabStop = new TabStop(tabStop2, _textElement);
			AddTabStop(tabStop);
		}
	}

	private void TabStop_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		string propertyName = e.PropertyName;
		if (propertyName == "Position" || propertyName == "Type")
		{
			OnVisualInvalidated();
		}
	}

	private void Settings_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		switch (e.PropertyName)
		{
		case "LeftIndent":
		case "RightIndent":
		case "FirstLineIndent":
			OnVisualInvalidated();
			break;
		}
	}

	private void TextElement_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		string propertyName = e.PropertyName;
		if (!(propertyName == "Position"))
		{
			if (propertyName == "EditTextbox")
			{
				SetTextBox(_textElement?.EditTextbox);
				notifyPropertyChanged();
			}
		}
		else
		{
			notifyPropertyChanged();
		}
		void notifyPropertyChanged()
		{
			OnVisualInvalidated();
			OnPropertyChanged("IsEditing");
		}
	}

	private void Margins_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		string propertyName = e.PropertyName;
		if (propertyName == "Left" || propertyName == "Right")
		{
			OnVisualInvalidated();
		}
	}

	public void AddTabStop(Vector2<double> mousePosition, TabStopType type)
	{
		Pro.Text.TabStop stop = new Pro.Text.TabStop(mousePosition.X - (_textElement?.Position.X ?? 0.0), type);
		_activeSettings?.TabStops.AddStop(stop);
	}

	public override void AddTabStop(Vector2<double> mousePosition)
	{
		AddTabStop(mousePosition, TabStopType.Left);
	}

	public override void RemoveTabStopData(TabStopControlBase tabStop)
	{
		if (tabStop.CanRemove && tabStop is TabStop tabStop2)
		{
			_activeSettings?.TabStops.RemoveStop(tabStop2.TextTabStop);
		}
	}

	public override void ChangeTabStopType(TabStopControlBase tabStopControl)
	{
		if (tabStopControl is TabStop tabStop)
		{
			TabStopType type = tabStop.TextTabStop.Type;
			type = (TabStopType)((int)(type + 1) % Enum.GetValues<TabStopType>().Length);
			tabStop.TextTabStop.Type = type;
		}
	}
}
