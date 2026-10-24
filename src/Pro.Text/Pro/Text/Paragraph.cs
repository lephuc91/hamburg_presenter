using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.Common.Logging;
using Pro.Common.Utility;
using Pro.Text.Reversibility;

namespace Pro.Text;

[DebuggerDisplay("{AllText}")]
public class Paragraph : IEquatable<Paragraph>, IEnumerable<RunBase>, IEnumerable
{
	private readonly List<RunBase> _runs = new List<RunBase>();

	private ParagraphSettings _settings;

	private int? _hashCode;

	private UndoStack? _undoStack;

	public UndoStack? UndoStack
	{
		get
		{
			return _undoStack;
		}
		set
		{
			_undoStack = value;
			if ((object)Settings != null)
			{
				Settings.UndoStack = value;
			}
			this.ForEach(delegate(RunBase r)
			{
				r.UndoStack = value;
			});
		}
	}

	public string AllText => string.Join("", this.Select((RunBase r) => r.PlainText));

	public int TextLength => _runs.CountMany((RunBase r) => r.Length);

	public int RunCount => _runs.Count;

	public RunBase this[int index] => _runs[index];

	public ParagraphSettings Settings
	{
		get
		{
			return _settings;
		}
		[MemberNotNull("_settings")]
		private set
		{
			UndoStack?.Commit(UndoActionTypes.ParagraphSettings.ToAction(), this, "Settings", _settings, value);
			if ((object)_settings != null)
			{
				_settings.PropertyChanged -= SettingsChanged;
				_settings.TabStops.TabStopsChanged -= TabStopsChanged;
			}
			_settings = value;
			_settings.PropertyChanged += SettingsChanged;
			_settings.TabStops.TabStopsChanged += TabStopsChanged;
			_settings.UndoStack = UndoStack;
			OnParagraphChanged();
		}
	}

	public event Action<Paragraph>? ParagraphChanged;

	public Paragraph(ParagraphSettings settings)
	{
		Settings = settings;
	}

	public override int GetHashCode()
	{
		if (!_hashCode.HasValue)
		{
			_hashCode = HashCodeHelper.GenerateHashCode(new IEnumerable[1] { _runs }, _settings);
		}
		return _hashCode.Value;
	}

	public override bool Equals(object? obj)
	{
		if (obj is Paragraph other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(Paragraph? other)
	{
		if ((object)other != null && _runs.Count == other._runs.Count && _settings == other._settings)
		{
			return _runs.ContentsMatchExactly(other._runs);
		}
		return false;
	}

	public IEnumerator<RunBase> GetEnumerator()
	{
		return _runs.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public void AddRun(RunBase run)
	{
		InsertRun(run, _runs.Count);
	}

	public void InsertRun(RunBase run, int index)
	{
		if (index < 0 || index > _runs.Count)
		{
			Log.Error("Tried to insert run at invalid index {0} for paragraph '{1}'", index, AllText);
			return;
		}
		run.RunChanged += RunChanged;
		run.UndoStack = UndoStack;
		_runs.Insert(index, run);
		UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.Text), delegate
		{
			RemoveRunAt(index);
		}, delegate
		{
			InsertRun(run, index);
		}, null, null, autoFinalize: true);
		OnParagraphChanged();
	}

	public void RemoveRun(RunBase run)
	{
		RemoveRunAt(GetRunIndex(run));
	}

	public void RemoveRunAt(int index)
	{
		if (index < 0 || index >= _runs.Count)
		{
			Log.Error("Tried to remove run at invalid index {0} for paragraph '{1}'", index, AllText);
			return;
		}
		RunBase run = _runs[index];
		_runs[index].RunChanged -= RunChanged;
		_runs.RemoveAt(index);
		UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.Text), delegate
		{
			InsertRun(run, index);
		}, delegate
		{
			RemoveRunAt(index);
		});
		OnParagraphChanged();
	}

	public int GetRunIndex(RunBase run)
	{
		return _runs.FindIndex((RunBase r) => (object)r == run);
	}

	public void Clear()
	{
		if (!_runs.Empty())
		{
			_runs.First().Clear();
			_runs.Skip(1).ForEach(delegate(RunBase r)
			{
				r.RunChanged -= RunChanged;
			});
			_runs.RemoveRange(1, _runs.Count - 1);
			OnParagraphChanged();
		}
	}

	public void AssignSettings(ParagraphSettings settings)
	{
		Settings = settings.Clone();
	}

	public void AssignTemplateSettings(ParagraphSettings defaultSettings, ParagraphSettings templateSettings)
	{
		foreach (TextDocumentAttributeHelper.PropertyAttributeMap paragraphSettingsPropertiesWithAttribute in TextDocumentAttributeHelper.ParagraphSettingsPropertiesWithAttributes)
		{
			TextDocumentAttribute attribute = paragraphSettingsPropertiesWithAttribute.Attribute;
			if (attribute == null || attribute.Type != TextAttributeType.Ignore)
			{
				object value = paragraphSettingsPropertiesWithAttribute.Property.GetValue(Settings);
				object value2 = paragraphSettingsPropertiesWithAttribute.Property.GetValue(defaultSettings);
				object value3 = paragraphSettingsPropertiesWithAttribute.Property.GetValue(templateSettings);
				if (object.Equals(value, value2))
				{
					paragraphSettingsPropertiesWithAttribute.Property.SetValue(Settings, value3);
				}
			}
		}
	}

	private void SettingsChanged(object? sender, PropertyChangedEventArgs e)
	{
		OnParagraphChanged();
	}

	private void TabStopsChanged(TabStopCollection tabStops)
	{
		OnParagraphChanged();
	}

	private void RunChanged(RunBase run)
	{
		OnParagraphChanged();
	}

	private void OnParagraphChanged()
	{
		this.ParagraphChanged?.Invoke(this);
	}

	public static bool operator ==(Paragraph? lhs, Paragraph? rhs)
	{
		return lhs.NullableEquals(rhs);
	}

	public static bool operator !=(Paragraph? lhs, Paragraph? rhs)
	{
		return !lhs.NullableEquals(rhs);
	}
}
