using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reactive;
using System.Reactive.Disposables;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Pro.Common.Components;
using Pro.Common.Mathematics;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.OutputConfiguration;

public class Screen : ObservableObject, ICloneable<Screen>
{
	[CompilerGenerated]
	private sealed class _003CGetHardwareRectangles_003Ed__55 : IEnumerable<HardwareScreenRectangleOptions>, IEnumerable, IEnumerator<HardwareScreenRectangleOptions>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private HardwareScreenRectangleOptions _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public Screen _003C_003E4__this;

		HardwareScreenRectangleOptions IEnumerator<HardwareScreenRectangleOptions>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CGetHardwareRectangles_003Ed__55(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			Screen screen = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = screen._mainOutput;
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				_003C_003E2__current = screen._alphaOutput;
				_003C_003E1__state = 2;
				return true;
			case 2:
				_003C_003E1__state = -1;
				return false;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<HardwareScreenRectangleOptions> IEnumerable<HardwareScreenRectangleOptions>.GetEnumerator()
		{
			_003CGetHardwareRectangles_003Ed__55 result;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				result = this;
			}
			else
			{
				result = new _003CGetHardwareRectangles_003Ed__55(0)
				{
					_003C_003E4__this = _003C_003E4__this
				};
			}
			return result;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<HardwareScreenRectangleOptions>)this).GetEnumerator();
		}
	}

	private readonly CornerPinningOptions _cornerPinning;

	private readonly ColorAdjustmentOptions _colorAdjustment;

	private readonly BlendCompensationOptions _blendCompensation;

	private readonly HardwareScreenRectangleOptions _mainOutput;

	private readonly HardwareScreenRectangleOptions _alphaOutput;

	[ObservableProperty]
	private Rect<double> _bounds;

	[ObservableProperty]
	private AlphaBlendMode _alphaBlendMode;

	public Guid ID { get; private set; } = Guid.NewGuid();

	public bool IsConfigured => _mainOutput.IsConfigured;

	public Vector2<double> OutputSize => _mainOutput.OutputSize;

	public string OutputName => _mainOutput.OutputName;

	public IDevice? MainOutputDevice => _mainOutput.OutputDevice;

	public CornerPinningOptions CornerPinning => _cornerPinning;

	public ColorAdjustmentOptions ColorAdjustment => _colorAdjustment;

	public BlendCompensationOptions BlendCompensation => _blendCompensation;

	public HardwareScreenRectangleOptions MainOutput => _mainOutput;

	public HardwareScreenRectangleOptions AlphaOutput => _alphaOutput;

	public IEnumerable<HardwareScreenRectangleOptions> HardwareRectangles => GetHardwareRectangles();

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public Rect<double> Bounds
	{
		get
		{
			return _bounds;
		}
		set
		{
			if (!EqualityComparer<Rect<double>>.Default.Equals(_bounds, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Bounds);
				_bounds = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Bounds);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public AlphaBlendMode AlphaBlendMode
	{
		get
		{
			return _alphaBlendMode;
		}
		set
		{
			if (!EqualityComparer<AlphaBlendMode>.Default.Equals(_alphaBlendMode, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.AlphaBlendMode);
				_alphaBlendMode = value;
				OnAlphaBlendModeChanged(value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.AlphaBlendMode);
			}
		}
	}

	public event Action<Screen>? ScreenChanged;

	internal event System.Action? MainOutputSizeChanged;

	public ObjectBinder<Screen, IScreen> Bind(IEntityFactory entityFactory, IScreen entity)
	{
		ObjectBinder<Screen, IScreen> objectBinder = new ObjectBinder<Screen, IScreen>(this, entity);
		ObjectBinder<HardwareScreenRectangleOptions, IScreen> objectBinder2 = new ObjectBinder<HardwareScreenRectangleOptions, IScreen>(_mainOutput, entity);
		objectBinder2.Bind((HardwareScreenRectangleOptions l) => l.WhenPropertyChanges("OutputDevice"), (IScreen r) => r.OutputDisplay.WhenValueChanges, delegate(HardwareScreenRectangleOptions l, IScreen r)
		{
			if (l.OutputDevice != null)
			{
				IOutputDisplay outputDisplay = entityFactory.Create<IOutputDisplay>();
				ObjectBinder<IDevice, IOutputDisplay> objectBinder3 = l.OutputDevice.Bind(entityFactory, outputDisplay);
				objectBinder3.InitializeRightFromLeft();
				r.OutputDisplay.Set(outputDisplay);
				outputDisplay.RegisterLinkedDisposable(objectBinder3);
			}
			else
			{
				r.OutputDisplay.Set(null);
			}
		}, delegate(IScreen r, HardwareScreenRectangleOptions l)
		{
			if (r.OutputDisplay.Value != null)
			{
				DeviceBase deviceBase = CreateOutputDevice(r.OutputDisplay.Value);
				if (deviceBase != null)
				{
					ObjectBinder<IDevice, IOutputDisplay> objectBinder4 = deviceBase.Bind(entityFactory, r.OutputDisplay.Value);
					objectBinder4.InitializeLeftFromRight();
					r.OutputDisplay.Value.RegisterLinkedDisposable(objectBinder4);
				}
				l.OutputDevice = deviceBase;
			}
			else
			{
				l.OutputDevice = null;
			}
		}).Bind((HardwareScreenRectangleOptions l) => l.WhenPropertyChanges("Subrect"), (IScreen r) => r.SubscreenUnitRect.WhenValueChanges, delegate(HardwareScreenRectangleOptions l, IScreen r)
		{
			r.SubscreenUnitRect.Set(l.Subrect.Scale(l.OutputSize.Invert()).ToRect());
		}, delegate(IScreen r, HardwareScreenRectangleOptions l)
		{
			l.Subrect = r.SubscreenUnitRect.Value.ToRectd().Clamp(Vector2<double>.Zero, Vector2<double>.One).Scale(l.OutputSize);
		});
		objectBinder.Bind((Screen l) => l.WhenPropertyChanges("ID"), (IScreen r) => r.Uuid.WhenValueChanges, delegate(Screen l, IScreen r)
		{
			r.Uuid.Set(l.ID);
		}, delegate(IScreen r, Screen l)
		{
			l.ID = r.Uuid.Value;
		}).Bind((Screen l) => l.WhenPropertyChanges("Bounds"), (IScreen r) => r.Bounds.WhenValueChanges, delegate(Screen l, IScreen r)
		{
			r.Bounds.Set(l.Bounds.ToRect());
		}, delegate(IScreen r, Screen l)
		{
			l.Bounds = r.Bounds.Value.ToRectd();
		}).Bind((Screen l) => l.CornerPinning.WhenPropertyChanges("IsEnabled"), (IScreen r) => r.CornerPinningEnabled.WhenValueChanges, delegate(Screen l, IScreen r)
		{
			r.CornerPinningEnabled.Set(l.CornerPinning.IsEnabled);
		}, delegate(IScreen r, Screen l)
		{
			l.CornerPinning.IsEnabled = r.CornerPinningEnabled.Value;
		})
			.Bind((Screen l) => l.WhenPropertyChanges("CornerPinning"), (IScreen r) => r.CornerValues.WhenValueChanges, delegate(Screen l, IScreen r)
			{
				ICornerValues cornerValues = entityFactory.Create<ICornerValues>();
				ObjectBinder<CornerPinningOptions, ICornerValues> objectBinder5 = l.CornerPinning.Bind(cornerValues);
				objectBinder5.InitializeRightFromLeft();
				cornerValues.RegisterLinkedDisposable(objectBinder5);
				r.CornerValues.Set(cornerValues);
			}, delegate(IScreen r, Screen l)
			{
				ObjectBinder<CornerPinningOptions, ICornerValues> objectBinder6 = l.CornerPinning.Bind(r.CornerValues.Value);
				objectBinder6.InitializeLeftFromRight();
				r.CornerValues.Value.RegisterLinkedDisposable(objectBinder6);
			})
			.Bind((Screen l) => l.WhenPropertyChanges("ColorAdjustment"), (IScreen r) => r.ColorAdjustment.WhenValueChanges, delegate(Screen l, IScreen r)
			{
				IScreen.Types.IColorAdjustment colorAdjustment = entityFactory.Create<IScreen.Types.IColorAdjustment>();
				ObjectBinder<ColorAdjustmentOptions, IScreen.Types.IColorAdjustment> objectBinder7 = l.ColorAdjustment.Bind(colorAdjustment);
				objectBinder7.InitializeRightFromLeft();
				colorAdjustment.RegisterLinkedDisposable(objectBinder7);
				r.ColorAdjustment.Set(colorAdjustment);
			}, delegate(IScreen r, Screen l)
			{
				ObjectBinder<ColorAdjustmentOptions, IScreen.Types.IColorAdjustment> objectBinder8 = l.ColorAdjustment.Bind(r.ColorAdjustment.Value);
				objectBinder8.InitializeLeftFromRight();
				r.ColorAdjustment.Value.RegisterLinkedDisposable(objectBinder8);
			})
			.Bind((Screen l) => l.WhenPropertyChanges("BlendCompensation"), (IScreen r) => r.BlendCompensation.WhenValueChanges, delegate(Screen l, IScreen r)
			{
				IScreen.Types.IBlendCompensation blendCompensation = entityFactory.Create<IScreen.Types.IBlendCompensation>();
				ObjectBinder<BlendCompensationOptions, IScreen.Types.IBlendCompensation> objectBinder9 = l.BlendCompensation.Bind(blendCompensation);
				objectBinder9.InitializeRightFromLeft();
				blendCompensation.RegisterLinkedDisposable(objectBinder9);
				r.BlendCompensation.Set(blendCompensation);
			}, delegate(IScreen r, Screen l)
			{
				ObjectBinder<BlendCompensationOptions, IScreen.Types.IBlendCompensation> objectBinder10 = l.BlendCompensation.Bind(r.BlendCompensation.Value);
				objectBinder10.InitializeLeftFromRight();
				r.BlendCompensation.Value.RegisterLinkedDisposable(objectBinder10);
			})
			.Bind<Unit, Unit>(null, (IScreen r) => r.AlphaSettings.WhenValueChanges.ToUnit(), delegate(Screen l, IScreen r)
			{
				IScreen.Types.IAlphaSettings alphaSettings = entityFactory.Create<IScreen.Types.IAlphaSettings>();
				r.AlphaSettings.Set(alphaSettings);
				ObjectBinder<Screen, IScreen.Types.IAlphaSettings> objectBinder11 = CreateAlphaSettingsBinder(entityFactory, r);
				objectBinder11.InitializeRightFromLeft();
				alphaSettings.RegisterLinkedDisposable(objectBinder11);
			}, delegate(IScreen r, Screen l)
			{
				ObjectBinder<Screen, IScreen.Types.IAlphaSettings> objectBinder12 = CreateAlphaSettingsBinder(entityFactory, r);
				objectBinder12.InitializeLeftFromRight();
				r.AlphaSettings.Value.RegisterLinkedDisposable(objectBinder12);
			})
			.DoOnInitializeLeftFromRight(objectBinder2.InitializeLeftFromRight)
			.DoOnInitializeRightFromLeft(objectBinder2.InitializeRightFromLeft)
			.RegisterChildDisposable(new CompositeDisposable { objectBinder2 });
		return objectBinder;
	}

	private ObjectBinder<Screen, IScreen.Types.IAlphaSettings> CreateAlphaSettingsBinder(IEntityFactory entityFactory, IScreen right)
	{
		ObjectBinder<HardwareScreenRectangleOptions, IScreen.Types.IAlphaSettings.Types.IAlphaDevice> alphaDeviceBinder = new ObjectBinder<HardwareScreenRectangleOptions, IScreen.Types.IAlphaSettings.Types.IAlphaDevice>(_alphaOutput, right.AlphaSettings.Value.AlphaDevice.Value);
		alphaDeviceBinder.Bind((HardwareScreenRectangleOptions l) => l.WhenPropertyChanges("OutputDevice"), (IScreen.Types.IAlphaSettings.Types.IAlphaDevice r) => r.Display.WhenValueChanges, delegate(HardwareScreenRectangleOptions l, IScreen.Types.IAlphaSettings.Types.IAlphaDevice r)
		{
			if (l.OutputDevice != null)
			{
				IOutputDisplay outputDisplay = entityFactory.Create<IOutputDisplay>();
				ObjectBinder<IDevice, IOutputDisplay> objectBinder = l.OutputDevice.Bind(entityFactory, outputDisplay);
				objectBinder.InitializeRightFromLeft();
				outputDisplay.RegisterLinkedDisposable(objectBinder);
				r.Display.Set(outputDisplay);
			}
		}, delegate(IScreen.Types.IAlphaSettings.Types.IAlphaDevice r, HardwareScreenRectangleOptions l)
		{
			DeviceBase deviceBase = CreateOutputDevice(r.Display.Value);
			if (deviceBase != null)
			{
				ObjectBinder<IDevice, IOutputDisplay> objectBinder2 = deviceBase.Bind(entityFactory, r.Display.Value);
				objectBinder2.InitializeLeftFromRight();
				r.Display.Value.RegisterLinkedDisposable(objectBinder2);
			}
			l.OutputDevice = deviceBase;
		}).Bind((HardwareScreenRectangleOptions l) => l.WhenPropertyChanges("Subrect"), (IScreen.Types.IAlphaSettings.Types.IAlphaDevice r) => r.SubscreenUnitRect.WhenValueChanges, delegate(HardwareScreenRectangleOptions l, IScreen.Types.IAlphaSettings.Types.IAlphaDevice r)
		{
			r.SubscreenUnitRect.Set(l.Subrect.Scale(l.OutputSize.Invert()).ToRect());
		}, delegate(IScreen.Types.IAlphaSettings.Types.IAlphaDevice r, HardwareScreenRectangleOptions l)
		{
			l.Subrect = r.SubscreenUnitRect.Value.ToRectd().Clamp(Vector2<double>.Zero, Vector2<double>.One).Scale(l.OutputSize);
		});
		ObjectBinder<Screen, IScreen.Types.IAlphaSettings> objectBinder3 = new ObjectBinder<Screen, IScreen.Types.IAlphaSettings>(this, right.AlphaSettings.Value);
		objectBinder3.Bind((Screen l) => l.WhenPropertyChanges("AlphaBlendMode"), (IScreen.Types.IAlphaSettings r) => r.Mode.WhenValueChanges, delegate(Screen l, IScreen.Types.IAlphaSettings r)
		{
			r.Mode.Set(l.AlphaBlendMode.ToEntity());
		}, delegate(IScreen.Types.IAlphaSettings r, Screen l)
		{
			l.AlphaBlendMode = right.ToAlphaBlendMode();
		}).DoOnInitializeLeftFromRight(alphaDeviceBinder.InitializeLeftFromRight).DoOnInitializeRightFromLeft(alphaDeviceBinder.InitializeRightFromLeft)
			.RegisterChildDisposable(() => alphaDeviceBinder);
		return objectBinder3;
	}

	private static DeviceBase? CreateOutputDevice(IOutputDisplay outputDisplay)
	{
		switch (outputDisplay.Type.Value)
		{
		case IOutputDisplay.Types.Type.Custom:
			return new PlaceholderDevice(outputDisplay.Bounds.Value.ToRectd().Size.Cast<int>());
		case IOutputDisplay.Types.Type.Screen:
		case IOutputDisplay.Types.Type.Card:
			return PhysicalDevice.FromEntityOutputDisplay(outputDisplay);
		case IOutputDisplay.Types.Type.Ndi:
			return new SoftDevice();
		default:
			return null;
		}
	}

	public Screen()
		: this(new HardwareScreenRectangleOptions(), new HardwareScreenRectangleOptions(), new ColorAdjustmentOptions(), new BlendCompensationOptions(), Rect<double>.Empty, AlphaBlendMode.None)
	{
	}

	private Screen(HardwareScreenRectangleOptions mainOutput, HardwareScreenRectangleOptions alphaOutput, ColorAdjustmentOptions colorAdjustment, BlendCompensationOptions blendCompensation, Rect<double> bounds, AlphaBlendMode alphaBlendMode)
	{
		_mainOutput = mainOutput;
		_alphaOutput = alphaOutput;
		_cornerPinning = new CornerPinningOptions(_mainOutput);
		_colorAdjustment = colorAdjustment;
		_blendCompensation = blendCompensation;
		Bounds = bounds;
		AlphaBlendMode = alphaBlendMode;
		CornerPinning.CornerPinningChanged += OnChange;
		ColorAdjustment.ColorAdjustmentChanged += OnChange;
		BlendCompensation.BlendCompensationChanged += OnChange;
		_mainOutput.PropertyChanged += MainOutput_PropertyChanged;
		_alphaOutput.PropertyChanged += AlphaOutput_PropertyChanged;
		_mainOutput.OutputDataChanged += OnScreenChanged;
		_mainOutput.OutputDeviceChanged += MainOutputScreenChanged;
		_alphaOutput.OutputDataChanged += OnScreenChanged;
	}

	public Screen Clone()
	{
		Screen screen = new Screen(_mainOutput.Clone(), _alphaOutput.Clone(), ColorAdjustment.Clone(), BlendCompensation.Clone(), Bounds, AlphaBlendMode);
		screen.CornerPinning.CopyProperties(CornerPinning);
		return screen;
	}

	public AlphaKeyOutputDevice GetAlphaKeyOutputDevice()
	{
		if (AlphaBlendMode == AlphaBlendMode.None)
		{
			return AlphaKeyOutputDevice.None;
		}
		IDevice? outputDevice = MainOutput.OutputDevice;
		if (outputDevice != null && outputDevice.SupportsAlphaBlending)
		{
			return AlphaKeyOutputDevice.Self;
		}
		return AlphaKeyOutputDevice.Other;
	}

	public Pro.SerializationInterop.RVProtoData.Screen Serialize()
	{
		OutputDisplay outputDisplay = _mainOutput.OutputDevice?.Serialize();
		if (outputDisplay?.Blackmagic != null)
		{
			outputDisplay.Blackmagic.Enabled = AlphaBlendMode.ToEnabled();
		}
		return new Pro.SerializationInterop.RVProtoData.Screen
		{
			Uuid = ID.ToUUID(),
			Bounds = Bounds.ToProtoRect(),
			SubscreenUnitRect = _mainOutput.Subrect.Scale(_mainOutput.OutputSize.Invert()).ToProtoRect(),
			CornerPinningEnabled = CornerPinning.IsEnabled,
			CornerValues = CornerPinning.Serialize(),
			ColorAdjustment = ColorAdjustment.Serialize(),
			BlendCompensation = BlendCompensation.Serialize(),
			OutputDisplay = outputDisplay,
			AlphaSettings = new Pro.SerializationInterop.RVProtoData.Screen.Types.AlphaSettings
			{
				Mode = AlphaBlendMode.ToProto(),
				AlphaDevice = new Pro.SerializationInterop.RVProtoData.Screen.Types.AlphaSettings.Types.AlphaDevice
				{
					Display = _alphaOutput.OutputDevice?.Serialize(),
					SubscreenUnitRect = _alphaOutput.Subrect.Scale(_alphaOutput.OutputSize.Invert()).ToProtoRect()
				}
			}
		};
	}

	public void Deserialize(Pro.SerializationInterop.RVProtoData.Screen screen)
	{
		if (screen != null)
		{
			SetId(screen.Uuid?.ToGuid() ?? ID);
			Bounds = screen.Bounds.ToRect().MaxPosition(Vector2<double>.Zero).MaxSize(Vector2<double>.Zero);
			_mainOutput.OutputDevice = DeserializeOutputDevice(screen.OutputDisplay);
			_mainOutput.Subrect = screen.SubscreenUnitRect.ToRect().Clamp(Vector2<double>.Zero, Vector2<double>.One).Scale(_mainOutput.OutputSize);
			if (screen.AlphaSettings?.AlphaDevice != null)
			{
				_alphaOutput.OutputDevice = DeserializeOutputDevice(screen.AlphaSettings.AlphaDevice.Display);
				_alphaOutput.Subrect = screen.AlphaSettings.AlphaDevice.SubscreenUnitRect.ToRect().Clamp(Vector2<double>.Zero, Vector2<double>.One).Scale(_alphaOutput.OutputSize);
			}
			CornerPinning.Deserialize(screen.CornerValues, screen.CornerPinningEnabled);
			ColorAdjustment.Deserialize(screen.ColorAdjustment);
			BlendCompensation.Deserialize(screen.BlendCompensation);
			AlphaBlendMode = screen.ToAlphaBlendMode();
		}
	}

	private static DeviceBase? DeserializeOutputDevice(OutputDisplay outputDisplay)
	{
		if (outputDisplay == null)
		{
			return null;
		}
		Rect<double> rect = outputDisplay.Bounds.ToRect();
		DeviceBase deviceBase = null;
		switch (outputDisplay.Type)
		{
		case OutputDisplay.Types.Type.Custom:
			deviceBase = new PlaceholderDevice(rect.Size.Cast<int>());
			deviceBase.Deserialize(outputDisplay);
			break;
		case OutputDisplay.Types.Type.Screen:
		case OutputDisplay.Types.Type.Card:
			deviceBase = PhysicalDevice.FromProtoOutputDisplay(outputDisplay);
			break;
		case OutputDisplay.Types.Type.Ndi:
			deviceBase = SoftDevice.FromProtoOutputDisplay(outputDisplay);
			break;
		}
		return deviceBase;
	}

	private void OnScreenChanged()
	{
		this.ScreenChanged?.Invoke(this);
	}

	private void OnOutputPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		string propertyName = e.PropertyName;
		if (!(propertyName == "IsAttached"))
		{
			if (propertyName == "Name")
			{
				OnScreenChanged();
				OnPropertyChanged("OutputName");
			}
		}
		else
		{
			OnPropertyChanged("IsConfigured");
			OnPropertyChanged("OutputName");
		}
	}

	private void OnChange(CornerPinningOptions cornerPinning)
	{
		OnScreenChanged();
	}

	private void OnChange(ColorAdjustmentOptions colorAdjustment)
	{
		OnScreenChanged();
	}

	private void OnChange(BlendCompensationOptions blendCompensation)
	{
		OnScreenChanged();
	}

	private void MainOutput_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		string propertyName = e.PropertyName;
		if (propertyName == null)
		{
			return;
		}
		switch (propertyName.Length)
		{
		default:
			return;
		case 12:
			switch (propertyName[0])
			{
			case 'I':
				if (propertyName == "IsConfigured")
				{
					OnScreenChanged();
					OnPropertyChanged("IsConfigured");
				}
				break;
			case 'O':
				if (propertyName == "OutputDevice")
				{
					OnPropertyChanged("MainOutputDevice");
					OnScreenChanged();
				}
				break;
			}
			return;
		case 10:
			switch (propertyName[6])
			{
			case 'S':
				if (propertyName == "OutputSize")
				{
					OnPropertyChanged("OutputSize");
					this.MainOutputSizeChanged?.Invoke();
				}
				break;
			case 'N':
				if (propertyName == "OutputName")
				{
					OnPropertyChanged("OutputName");
				}
				break;
			}
			return;
		case 7:
			if (propertyName == "Subrect")
			{
				OnScreenChanged();
			}
			return;
		case 18:
			if (!(propertyName == "SubrectTargetIndex"))
			{
				return;
			}
			break;
		case 17:
			if (!(propertyName == "SubrectTargetMode"))
			{
				return;
			}
			break;
		}
		OnScreenChanged();
	}

	private void AlphaOutput_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		switch (e.PropertyName)
		{
		case "Subrect":
		case "IsConfigured":
		case "OutputDevice":
		case "SubrectTargetMode":
		case "SubrectTargetIndex":
			OnScreenChanged();
			break;
		}
	}

	private void MainOutputScreenChanged(IDevice? oldDevice, IDevice? newDevice)
	{
		if ((newDevice != null && newDevice.SupportsAlphaBlending) || (oldDevice != null && oldDevice.SupportsAlphaBlending))
		{
			_alphaOutput.OutputDevice = null;
		}
		if (oldDevice != null && oldDevice.SupportsAlphaBlending && newDevice != null && !newDevice.SupportsAlphaBlending)
		{
			AlphaBlendMode = AlphaBlendMode.None;
		}
		OnScreenChanged();
	}

	[IteratorStateMachine(typeof(_003CGetHardwareRectangles_003Ed__55))]
	private IEnumerable<HardwareScreenRectangleOptions> GetHardwareRectangles()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CGetHardwareRectangles_003Ed__55(-2)
		{
			_003C_003E4__this = this
		};
	}

	internal void SetId(Guid id)
	{
		ID = id;
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnAlphaBlendModeChanged(AlphaBlendMode value)
	{
		if (value == AlphaBlendMode.None)
		{
			_alphaOutput.OutputDevice = null;
		}
		OnScreenChanged();
	}
}
