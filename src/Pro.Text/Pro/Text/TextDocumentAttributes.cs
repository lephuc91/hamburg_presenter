using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;

namespace Pro.Text;

public class TextDocumentAttributes
{
	private ParagraphSettings _paragraphSettings;

	private RunSettings _runSettings;

	private bool _suppressOnSettingsChanged;

	public ParagraphSettings ParagraphSettings
	{
		get
		{
			return _paragraphSettings;
		}
		[MemberNotNull("_paragraphSettings")]
		set
		{
			if ((object)_paragraphSettings == value)
			{
				return;
			}
			if (_paragraphSettings != null)
			{
				_paragraphSettings.PropertyChanged -= OnSettingsChanged;
				_paragraphSettings.TabStops.CollectionChanged -= TabStops_CollectionChanged;
				_paragraphSettings.TabStops.ForEach(delegate(TabStop t)
				{
					t.PropertyChanged -= TabStops_PropertyChanged;
				});
			}
			_paragraphSettings = value;
			_paragraphSettings.PropertyChanged += OnSettingsChanged;
			_paragraphSettings.TabStops.CollectionChanged += TabStops_CollectionChanged;
			_paragraphSettings.TabStops.ForEach(delegate(TabStop t)
			{
				t.PropertyChanged += TabStops_PropertyChanged;
			});
			OnSettingsChanged(this, null);
		}
	}

	public RunSettings RunSettings
	{
		get
		{
			return _runSettings;
		}
		[MemberNotNull("_runSettings")]
		set
		{
			if ((object)_runSettings != null)
			{
				_runSettings.PropertyChanged -= OnSettingsChanged;
			}
			if ((object)_runSettings != value)
			{
				_runSettings = value;
			}
			_runSettings.PropertyChanged += OnSettingsChanged;
			if ((object)_runSettings != value)
			{
				OnSettingsChanged(this, new PropertyChangedEventArgs("RunSettings"));
			}
		}
	}

	public event Action? SettingsChanged;

	public TextDocumentAttributes(UndoStack? undoStack)
	{
		ParagraphSettings = new ParagraphSettings
		{
			UndoStack = undoStack
		};
		RunSettings = new RunSettings
		{
			UndoStack = undoStack
		};
	}

	private TextDocumentAttributes(TextDocumentAttributes source)
	{
		ParagraphSettings = source.ParagraphSettings.Clone();
		RunSettings = source.RunSettings.Clone();
	}

	public TextDocumentAttributes Clone()
	{
		return new TextDocumentAttributes(this);
	}

	public void BeginSuppressOnSettingsChanged()
	{
		_suppressOnSettingsChanged = true;
	}

	public void EndSuppressOnSettingsChanged()
	{
		_suppressOnSettingsChanged = false;
	}

	public override bool Equals(object? obj)
	{
		if (obj is TextDocumentAttributes textDocumentAttributes && textDocumentAttributes.ParagraphSettings.Equals(ParagraphSettings))
		{
			return textDocumentAttributes.RunSettings.Equals(RunSettings);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return ParagraphSettings.GetHashCode() + RunSettings.GetHashCode();
	}

	public void SetUndoStack(UndoStack? undoStack)
	{
		ParagraphSettings.UndoStack = undoStack;
		RunSettings.UndoStack = undoStack;
	}

	private void OnSettingsChanged(object? sender, PropertyChangedEventArgs? e)
	{
		OnDocumentSettingsChanged();
	}

	private void TabStops_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.OfType<TabStop>().ForEach(delegate(TabStop t)
		{
			t.PropertyChanged -= TabStops_PropertyChanged;
		});
		e.NewItems?.OfType<TabStop>().ForEach(delegate(TabStop t)
		{
			t.PropertyChanged += TabStops_PropertyChanged;
		});
		OnDocumentSettingsChanged();
	}

	private void TabStops_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		string propertyName = e.PropertyName;
		if (propertyName == "Position" || propertyName == "Type")
		{
			OnDocumentSettingsChanged();
		}
	}

	private void OnDocumentSettingsChanged()
	{
		if (!_suppressOnSettingsChanged)
		{
			this.SettingsChanged?.Invoke();
		}
	}
}
