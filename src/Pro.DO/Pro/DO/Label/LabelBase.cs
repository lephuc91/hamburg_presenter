using System;
using System.ComponentModel;
using System.Windows.Media;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.DO.Reversibility;

namespace Pro.DO.Label;

public abstract class LabelBase<T> : LinkedNotifyPropertyChangedBase, ILabel, INotifyPropertyChanged, ICloneable<T> where T : LabelBase<T>
{
	private string? _text;

	private Color? _color;

	private T? _masterLabel;

	public T? MasterLabel
	{
		get
		{
			return _masterLabel;
		}
		set
		{
			SetValue<T>("MasterLabel", ref _masterLabel, value, delegate(T o, T n)
			{
				UndoStack?.Commit(UndoActionTypes.MasterLabel.ToAction(), this, "MasterLabel", o, n, null, null, autoFinalize: true);
				if (o != null)
				{
					o.PropertyChanged -= base.RaiseLinkedValues;
				}
				if (n != null)
				{
					n.PropertyChanged += base.RaiseLinkedValues;
				}
				OnPropertyChanged("Text");
				OnPropertyChanged("Color");
			});
		}
	}

	public string Text
	{
		get
		{
			return MasterLabel?.Text ?? _text ?? string.Empty;
		}
		set
		{
			SetValue<string>("Text", ref _text, value, delegate(string o, string n)
			{
				UndoStack?.Commit(UndoActionTypes.LabelText.ToAction(), this, "Text", o, n, null, null, autoFinalize: true);
				OnDataModified();
			});
		}
	}

	protected string OriginalText => _text ?? string.Empty;

	public Color? Color
	{
		get
		{
			return MasterLabel?.Color ?? _color;
		}
		set
		{
			SetValue("Color", ref _color, value, delegate(Color? o, Color? n)
			{
				UndoStack?.Commit(UndoActionTypes.LabelColor.ToAction(), this, "Color", o, n, null, null, autoFinalize: true);
				OnDataModified();
			});
		}
	}

	protected Color? OriginalColor => _color;

	public UndoStack? UndoStack { get; set; }

	public event Action? DataModified;

	protected LabelBase(string text)
		: this(text, (Color?)null)
	{
	}

	protected LabelBase(string text, Color? color)
	{
		_text = text;
		_color = color;
		LinkProperties("Text", "Text");
		LinkProperties("Color", "Color");
	}

	protected void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	public abstract T Clone();

	protected T CopyProperties(T clone)
	{
		clone._text = _text;
		clone._color = _color;
		clone.MasterLabel = _masterLabel;
		return clone;
	}

	protected void OnDeserialize(string text, Color? color)
	{
		_text = text;
		_color = color;
	}
}
