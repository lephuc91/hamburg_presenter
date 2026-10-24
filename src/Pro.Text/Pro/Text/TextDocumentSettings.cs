using System;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Utility;
using Pro.Text.Reversibility;

namespace Pro.Text;

public class TextDocumentSettings : NotifyPropertyChangedBase, IEquatable<TextDocumentSettings>, ICloneable<TextDocumentSettings>
{
	public const double DefaultLayoutWidth = 612.0;

	private DocumentAlignment _alignment;

	private TextTransform _transform;

	private string _transformDelimiter;

	private ScaleMode _scaleMode;

	private double _layoutWidth = 612.0;

	private int? _hashCode;

	private UndoStack? _undoStack;

	public DocumentAlignment Alignment
	{
		get
		{
			return _alignment;
		}
		set
		{
			SetValue("Alignment", ref _alignment, value, delegate(DocumentAlignment o, DocumentAlignment n)
			{
				UndoStack?.Commit(UndoActionTypes.DocumentAlignment.ToAction(), this, "Alignment", o, n, null, null, autoFinalize: true);
				OnSettingsChanged();
			});
		}
	}

	public TextTransform Transform
	{
		get
		{
			return _transform;
		}
		set
		{
			SetValue("Transform", ref _transform, value, delegate(TextTransform o, TextTransform n)
			{
				UndoStack?.Commit(UndoActionTypes.DocumentTransform.ToAction(), this, "Transform", o, n, null, null, autoFinalize: true);
				OnSettingsChanged();
			});
		}
	}

	public string TransformDelimiter
	{
		get
		{
			return _transformDelimiter;
		}
		set
		{
			SetValue("TransformDelimiter", ref _transformDelimiter, value, delegate(string o, string n)
			{
				UndoStack?.Commit(UndoActionTypes.DocumentTransformDelimiter.ToAction(), this, "TransformDelimiter", o, n, null, null, autoFinalize: true);
				OnSettingsChanged();
			});
		}
	}

	public ScaleMode ScaleMode
	{
		get
		{
			return _scaleMode;
		}
		set
		{
			SetValue("ScaleMode", ref _scaleMode, value, delegate(ScaleMode o, ScaleMode n)
			{
				UndoStack?.Commit(UndoActionTypes.DocumentScaleBehavior.ToAction(), this, "ScaleMode", o, n, null, null, autoFinalize: true);
				OnSettingsChanged();
			});
		}
	}

	public double LayoutWidth
	{
		get
		{
			return _layoutWidth;
		}
		set
		{
			SetValue("LayoutWidth", ref _layoutWidth, value, OnSettingsChanged);
		}
	}

	public Margins Margins { get; }

	public Shadow Shadow { get; }

	public ChordPro ChordPro { get; }

	public UndoStack? UndoStack
	{
		get
		{
			return _undoStack;
		}
		set
		{
			Margins margins = Margins;
			Shadow shadow = Shadow;
			UndoStack undoStack2 = (ChordPro.UndoStack = value);
			UndoStack undoStack4 = (shadow.UndoStack = undoStack2);
			UndoStack undoStack6 = (margins.UndoStack = undoStack4);
			_undoStack = undoStack6;
		}
	}

	public event Action? SettingsChanged;

	public TextDocumentSettings()
		: this(DocumentAlignment.Middle, TextTransform.None, Delimiters.Default[0], ScaleMode.None)
	{
	}

	public TextDocumentSettings(DocumentAlignment alignment, TextTransform transform, string transformDelimiter, ScaleMode scaleMode, Margins? margins = null, Shadow? shadow = null, ChordPro? chordPro = null)
	{
		_alignment = alignment;
		_transform = transform;
		_transformDelimiter = transformDelimiter;
		_scaleMode = scaleMode;
		Margins = margins ?? new Margins();
		Margins.PropertyChanged += delegate
		{
			OnSettingsChanged();
		};
		Shadow = shadow ?? new Shadow();
		Shadow.PropertyChanged += delegate
		{
			OnSettingsChanged();
		};
		ChordPro = chordPro ?? new ChordPro();
		ChordPro.PropertyChanged += delegate
		{
			OnSettingsChanged();
		};
	}

	private TextDocumentSettings(TextDocumentSettings settings)
		: this(settings.Alignment, settings.Transform, settings.TransformDelimiter, settings.ScaleMode, settings.Margins.Clone(), settings.Shadow.Clone(), settings.ChordPro.Clone())
	{
		_layoutWidth = settings._layoutWidth;
	}

	public override int GetHashCode()
	{
		if (!_hashCode.HasValue)
		{
			_hashCode = HashCodeHelper.GenerateHashCode(_alignment, _transform, _transformDelimiter, _scaleMode, Margins, Shadow, ChordPro);
		}
		return _hashCode.Value;
	}

	public override bool Equals(object? obj)
	{
		if (obj is TextDocumentSettings other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(TextDocumentSettings? other)
	{
		if ((object)other != null && _alignment == other._alignment && _scaleMode == other._scaleMode && _transform == other._transform && _transformDelimiter == other._transformDelimiter && _layoutWidth == other._layoutWidth && Margins == other.Margins && Shadow == other.Shadow)
		{
			return ChordPro == other.ChordPro;
		}
		return false;
	}

	public TextDocumentSettings Clone()
	{
		return new TextDocumentSettings(this);
	}

	private void OnSettingsChanged()
	{
		this.SettingsChanged?.Invoke();
	}

	public static bool operator ==(TextDocumentSettings? lhs, TextDocumentSettings? rhs)
	{
		return lhs.NullableEquals(rhs);
	}

	public static bool operator !=(TextDocumentSettings? lhs, TextDocumentSettings? rhs)
	{
		return !lhs.NullableEquals(rhs);
	}
}
