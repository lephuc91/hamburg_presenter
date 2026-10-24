using System;
using System.ComponentModel;
using Pro.Common.Components;
using Pro.Common.Mathematics;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.OutputConfiguration;

public class CornerPinningOptions : NotifyPropertyChangedBase
{
	private const double SizeCapScalar = 0.25;

	private readonly IOutputSizeProvider _outputSizeProvider;

	private bool _isEnabled;

	private Vector2<double> _topLeft = Vector2<double>.Zero;

	private Vector2<double> _topRight = Vector2<double>.Zero;

	private Vector2<double> _bottomLeft = Vector2<double>.Zero;

	private Vector2<double> _bottomRight = Vector2<double>.Zero;

	public bool IsEnabled
	{
		get
		{
			return _isEnabled;
		}
		set
		{
			SetValue("IsEnabled", ref _isEnabled, value, OnCornerPinningChanged);
		}
	}

	public Vector2<double> TopLeft
	{
		get
		{
			return _topLeft;
		}
		set
		{
			SetValue("TopLeft", ref _topLeft, ClampValue(value), OnCornerPinningChanged);
		}
	}

	public Vector2<double> TopRight
	{
		get
		{
			return _topRight;
		}
		set
		{
			SetValue("TopRight", ref _topRight, ClampValue(value), OnCornerPinningChanged);
		}
	}

	public Vector2<double> BottomLeft
	{
		get
		{
			return _bottomLeft;
		}
		set
		{
			SetValue("BottomLeft", ref _bottomLeft, ClampValue(value), OnCornerPinningChanged);
		}
	}

	public Vector2<double> BottomRight
	{
		get
		{
			return _bottomRight;
		}
		set
		{
			SetValue("BottomRight", ref _bottomRight, ClampValue(value), OnCornerPinningChanged);
		}
	}

	public double MaximumWidth => _outputSizeProvider.OutputSize.X * 0.25;

	public double MinimumWidth => 0.0 - MaximumWidth;

	public double MaximumHeight => _outputSizeProvider.OutputSize.Y * 0.25;

	public double MinimumHeight => 0.0 - MaximumHeight;

	public event Action<CornerPinningOptions>? CornerPinningChanged;

	public ObjectBinder<CornerPinningOptions, ICornerValues> Bind(ICornerValues right)
	{
		ObjectBinder<CornerPinningOptions, ICornerValues> objectBinder = new ObjectBinder<CornerPinningOptions, ICornerValues>(this, right);
		objectBinder.Bind((CornerPinningOptions l) => l.WhenPropertyChanges("TopLeft"), (ICornerValues r) => r.TopLeft.WhenValueChanges, delegate(CornerPinningOptions l, ICornerValues r)
		{
			r.TopLeft.Set(l.TopLeft.ToPoint());
		}, delegate(ICornerValues r, CornerPinningOptions l)
		{
			l.TopLeft = r.TopLeft.Value.ToVector2d();
		}).Bind((CornerPinningOptions l) => l.WhenPropertyChanges("TopRight"), (ICornerValues r) => r.TopRight.WhenValueChanges, delegate(CornerPinningOptions l, ICornerValues r)
		{
			r.TopRight.Set(l.TopRight.ToPoint());
		}, delegate(ICornerValues r, CornerPinningOptions l)
		{
			l.TopRight = r.TopRight.Value.ToVector2d();
		}).Bind((CornerPinningOptions l) => l.WhenPropertyChanges("BottomLeft"), (ICornerValues r) => r.BottomLeft.WhenValueChanges, delegate(CornerPinningOptions l, ICornerValues r)
		{
			r.BottomLeft.Set(l.BottomLeft.ToPoint());
		}, delegate(ICornerValues r, CornerPinningOptions l)
		{
			l.BottomLeft = r.BottomLeft.Value.ToVector2d();
		})
			.Bind((CornerPinningOptions l) => l.WhenPropertyChanges("BottomRight"), (ICornerValues r) => r.BottomRight.WhenValueChanges, delegate(CornerPinningOptions l, ICornerValues r)
			{
				r.BottomRight.Set(l.BottomRight.ToPoint());
			}, delegate(ICornerValues r, CornerPinningOptions l)
			{
				l.BottomRight = r.BottomRight.Value.ToVector2d();
			});
		return objectBinder;
	}

	public CornerPinningOptions(IOutputSizeProvider outputSizeProvider)
	{
		_outputSizeProvider = outputSizeProvider;
		_outputSizeProvider.PropertyChanged += OutputSizeProvider_PropertyChanged;
	}

	public void CopyProperties(CornerPinningOptions other)
	{
		IsEnabled = other.IsEnabled;
		TopLeft = other.TopLeft;
		TopRight = other.TopRight;
		BottomLeft = other.BottomLeft;
		BottomRight = other.BottomRight;
	}

	public void ResetAll()
	{
		TopLeft = Vector2<double>.Zero;
		TopRight = Vector2<double>.Zero;
		BottomLeft = Vector2<double>.Zero;
		BottomRight = Vector2<double>.Zero;
	}

	private void OnCornerPinningChanged()
	{
		this.CornerPinningChanged?.Invoke(this);
	}

	protected internal CornerValues Serialize()
	{
		return new CornerValues
		{
			TopLeft = TopLeft.ToProtoPoint(),
			TopRight = TopRight.ToProtoPoint(),
			BottomLeft = BottomLeft.ToProtoPoint(),
			BottomRight = BottomRight.ToProtoPoint()
		};
	}

	protected internal void Deserialize(CornerValues cornerPinning, bool isEnabled)
	{
		IsEnabled = isEnabled;
		if (cornerPinning != null)
		{
			TopLeft = cornerPinning.TopLeft.ToVector();
			TopRight = cornerPinning.TopRight.ToVector();
			BottomLeft = cornerPinning.BottomLeft.ToVector();
			BottomRight = cornerPinning.BottomRight.ToVector();
		}
	}

	private Vector2<double> ClampValue(Vector2<double> value)
	{
		return new Vector2<double>(value.X.Clamp(MinimumWidth, MaximumWidth), value.Y.Clamp(MinimumHeight, MaximumHeight));
	}

	private void OutputSizeProvider_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "OutputSize")
		{
			OnOutputSizeChanged();
		}
	}

	private void OnOutputSizeChanged()
	{
		OnPropertyChanged("MinimumWidth");
		OnPropertyChanged("MinimumHeight");
		OnPropertyChanged("MaximumWidth");
		OnPropertyChanged("MaximumHeight");
		TopLeft = _topLeft;
		TopRight = _topRight;
		BottomLeft = _bottomLeft;
		BottomRight = _bottomRight;
	}
}
