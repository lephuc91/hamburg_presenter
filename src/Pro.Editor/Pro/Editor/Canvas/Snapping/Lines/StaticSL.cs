using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Pro.Common.Components;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.Entity;

namespace Pro.Editor.Canvas.Snapping.Lines;

public class StaticSL : ObservableObject, ISnapLine, ICloneable<StaticSL>
{
	[ObservableProperty]
	private Guid _id = Guid.NewGuid();

	[ObservableProperty]
	private double _position;

	[ObservableProperty]
	private bool _isEnabled = true;

	[ObservableProperty]
	private bool _isEditable = true;

	[ObservableProperty]
	private bool _isHorizontal;

	[ObservableProperty]
	private bool _updatePosition;

	public SnapEdge SnapEdges => SnapEdge.All;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public Guid Id
	{
		get
		{
			return _id;
		}
		set
		{
			if (!EqualityComparer<Guid>.Default.Equals(_id, value))
			{
				OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Id);
				_id = value;
				OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Id);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public double Position
	{
		get
		{
			return _position;
		}
		set
		{
			if (!EqualityComparer<double>.Default.Equals(_position, value))
			{
				OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Position);
				_position = value;
				OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Position);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsEnabled
	{
		get
		{
			return _isEnabled;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isEnabled, value))
			{
				OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsEnabled);
				_isEnabled = value;
				OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsEnabled);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsEditable
	{
		get
		{
			return _isEditable;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isEditable, value))
			{
				OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsEditable);
				_isEditable = value;
				OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsEditable);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsHorizontal
	{
		get
		{
			return _isHorizontal;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isHorizontal, value))
			{
				OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsHorizontal);
				_isHorizontal = value;
				OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsHorizontal);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool UpdatePosition
	{
		get
		{
			return _updatePosition;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_updatePosition, value))
			{
				OnPropertyChanging(__KnownINotifyPropertyChangingArgs.UpdatePosition);
				_updatePosition = value;
				OnPropertyChanged(__KnownINotifyPropertyChangedArgs.UpdatePosition);
			}
		}
	}

	public static ObjectBinder<StaticSL, IAlignmentGuide> CreateBinder(StaticSL left, IAlignmentGuide right)
	{
		ObjectBinder<StaticSL, IAlignmentGuide> objectBinder = new ObjectBinder<StaticSL, IAlignmentGuide>(left, right);
		objectBinder.Bind((StaticSL l) => l.WhenPropertyChanges("Id"), (IAlignmentGuide r) => r.Uuid.WhenValueChanges, delegate(StaticSL l, IAlignmentGuide r)
		{
			r.Uuid.Set(l.Id);
		}, delegate(IAlignmentGuide r, StaticSL l)
		{
			l.Id = r.Uuid.Value;
		}).Bind((StaticSL l) => l.WhenPropertyChanges("Position"), (IAlignmentGuide r) => r.Location.WhenValueChanges, delegate(StaticSL l, IAlignmentGuide r)
		{
			r.Location.Set(l.Position);
		}, delegate(IAlignmentGuide r, StaticSL l)
		{
			l.Position = r.Location.Value;
		}).Bind((StaticSL l) => l.WhenPropertyChanges("IsHorizontal"), (IAlignmentGuide r) => r.Orientation.WhenValueChanges, delegate(StaticSL l, IAlignmentGuide r)
		{
			r.Orientation.Set((!l.IsHorizontal) ? IAlignmentGuide.Types.GuidelineOrientation.Vertical : IAlignmentGuide.Types.GuidelineOrientation.Horizontal);
		}, delegate(IAlignmentGuide r, StaticSL l)
		{
			l.IsHorizontal = r.Orientation.Value == IAlignmentGuide.Types.GuidelineOrientation.Horizontal;
		});
		return objectBinder;
	}

	public StaticSL(bool isHorizontal, bool updatePosition = false)
	{
		IsHorizontal = isHorizontal;
		UpdatePosition = updatePosition;
	}

	public StaticSL Clone()
	{
		return new StaticSL(IsHorizontal)
		{
			Position = Position,
			IsEnabled = IsEnabled,
			IsEditable = IsEditable
		};
	}
}
