using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Logging;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Effects.Descriptions;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Effects;

public class EffectParameters : NotifyPropertyChangedBase, IEquatable<EffectParameters?>
{
	private readonly Dictionary<ParameterDescriptionBase, object?> _parameterValueMap = new Dictionary<ParameterDescriptionBase, object>();

	private readonly Subject<ParameterDescriptionBase?> _whenParameterValueChanges = new Subject<ParameterDescriptionBase>();

	private int? _hashCode;

	private bool _isEnabled;

	public EffectDescription? EffectDescription { get; }

	public Guid ID { get; private set; } = Guid.NewGuid();

	public bool IsEnabled
	{
		get
		{
			return _isEnabled;
		}
		set
		{
			SetValue("IsEnabled", ref _isEnabled, value, (Action<bool, bool>?)delegate
			{
				OnParametersChanged();
			}, (Predicate<bool>?)null, referenceComparison: false);
		}
	}

	public bool IsLocked { get; private set; }

	public IObservable<ParameterDescriptionBase?> WhenParameterValueChanges => _whenParameterValueChanges;

	public event Action<EffectParameters>? ParametersChanged;

	public static ObjectBinder<EffectParameters, IEffect> CreateBinder(IEntityFactory entityFactory, EffectParameters? left, IEffect? right)
	{
		ObjectBinder<EffectParameters, IEffect> binder = new ObjectBinder<EffectParameters, IEffect>(left, right);
		binder.Bind((EffectParameters l) => l.WhenPropertyChanges("ID"), (IEffect r) => r.Uuid.WhenValueChanges, delegate(EffectParameters l, IEffect r)
		{
			r.Uuid.Set(l.ID);
		}, delegate(IEffect r, EffectParameters l)
		{
			l.ID = r.Uuid.Value;
		}).Bind((EffectParameters l) => l.WhenPropertyChanges("IsEnabled"), (IEffect r) => r.Enabled.WhenValueChanges, delegate(EffectParameters l, IEffect r)
		{
			r.Enabled.Set(l.IsEnabled);
		}, delegate(IEffect r, EffectParameters l)
		{
			l.IsEnabled = r.Enabled.Value;
		}).DoOnInitializeRightFromLeft(delegate
		{
			if ((object)binder.Left?.EffectDescription != null && binder.Right != null)
			{
				binder.Right.RenderId.Set(binder.Left.EffectDescription.ID.ToString());
				binder.Right.Variables.Clear();
				ParameterDescriptionBase[] parameters = binder.Left.EffectDescription.Parameters;
				foreach (ParameterDescriptionBase parameterDescriptionBase in parameters)
				{
					IEffect.Types.IEffectVariable effectVariable = entityFactory.Create<IEffect.Types.IEffectVariable>();
					binder.Right.Variables.Add(effectVariable);
					if (parameterDescriptionBase.ParameterType == ParameterType.Direction)
					{
						IEffect.Types.IEffectVariable.Types.IType.IDirection direction = entityFactory.Create<IEffect.Types.IEffectVariable.Types.IType.IDirection>();
						direction.Set(entityFactory.Create<IEffect.Types.IEffectVariable.Types.IEffectDirection>());
						effectVariable.Type.Set(direction);
					}
					else if (parameterDescriptionBase.ParameterType == ParameterType.Color)
					{
						IEffect.Types.IEffectVariable.Types.IType.IColor color = entityFactory.Create<IEffect.Types.IEffectVariable.Types.IType.IColor>();
						color.Set(entityFactory.Create<IEffect.Types.IEffectVariable.Types.IEffectColor>());
						effectVariable.Type.Set(color);
					}
					else if (parameterDescriptionBase.ParameterType == ParameterType.Double)
					{
						IEffect.Types.IEffectVariable.Types.IType.IDouble @double = entityFactory.Create<IEffect.Types.IEffectVariable.Types.IType.IDouble>();
						@double.Set(entityFactory.Create<IEffect.Types.IEffectVariable.Types.IEffectDouble>());
						effectVariable.Type.Set(@double);
					}
					else if (parameterDescriptionBase.ParameterType == ParameterType.Float)
					{
						IEffect.Types.IEffectVariable.Types.IType.IFloat @float = entityFactory.Create<IEffect.Types.IEffectVariable.Types.IType.IFloat>();
						@float.Set(entityFactory.Create<IEffect.Types.IEffectVariable.Types.IEffectFloat>());
						effectVariable.Type.Set(@float);
					}
					else
					{
						if (parameterDescriptionBase.ParameterType != 0)
						{
							throw new InvalidDataException($"Unhandled parameter type {parameterDescriptionBase.ParameterType}");
						}
						IEffect.Types.IEffectVariable.Types.IType.IInt @int = entityFactory.Create<IEffect.Types.IEffectVariable.Types.IType.IInt>();
						@int.Set(entityFactory.Create<IEffect.Types.IEffectVariable.Types.IEffectInt>());
						effectVariable.Type.Set(@int);
					}
					ObjectBinder<ParameterDescriptionBase, IEffect.Types.IEffectVariable.Types.IType> objectBinder = CreateVariableBinder(binder.Left, parameterDescriptionBase, effectVariable.Type.Value);
					objectBinder.InitializeRightFromLeft();
					effectVariable.RegisterLinkedDisposable(objectBinder);
				}
			}
		});
		return binder;
	}

	private static ObjectBinder<ParameterDescriptionBase, IEffect.Types.IEffectVariable.Types.IType> CreateVariableBinder(EffectParameters owningParameters, ParameterDescriptionBase left, IEffect.Types.IEffectVariable.Types.IType right)
	{
		ObjectBinder<ParameterDescriptionBase, IEffect.Types.IEffectVariable.Types.IType> objectBinder = new ObjectBinder<ParameterDescriptionBase, IEffect.Types.IEffectVariable.Types.IType>(left, right);
		IEffect.Types.IEffectVariable.Types.IType.IColor colorVariable = right as IEffect.Types.IEffectVariable.Types.IType.IColor;
		if (colorVariable != null)
		{
			objectBinder.Bind((ParameterDescriptionBase l) => owningParameters.WhenParameterValueChanges.Where((ParameterDescriptionBase p) => p == null || p == l), (IEffect.Types.IEffectVariable.Types.IType r) => colorVariable.Value.Color.WhenValueChanges, delegate(ParameterDescriptionBase l, IEffect.Types.IEffectVariable.Types.IType r)
			{
				colorVariable.Value.Color.Set(owningParameters.GetValue<System.Windows.Media.Color>(l).ToEntityColor());
			}, delegate(IEffect.Types.IEffectVariable.Types.IType r, ParameterDescriptionBase l)
			{
				owningParameters.SetValue(l, colorVariable.Value.Color.ToColor());
			});
		}
		else
		{
			IEffect.Types.IEffectVariable.Types.IType.IDirection directionVariable = right as IEffect.Types.IEffectVariable.Types.IType.IDirection;
			if (directionVariable != null)
			{
				objectBinder.Bind((ParameterDescriptionBase l) => owningParameters.WhenParameterValueChanges.Where((ParameterDescriptionBase p) => p == null || p == l), (IEffect.Types.IEffectVariable.Types.IType r) => directionVariable.Value.Direction.WhenValueChanges, delegate(ParameterDescriptionBase l, IEffect.Types.IEffectVariable.Types.IType r)
				{
					directionVariable.Value.Direction.Set(owningParameters.GetValue<Direction>(l).ToEntityDirection());
				}, delegate(IEffect.Types.IEffectVariable.Types.IType r, ParameterDescriptionBase l)
				{
					owningParameters.SetValue(l, directionVariable.Value.Direction.Value.ToDirection());
				});
			}
			else
			{
				IEffect.Types.IEffectVariable.Types.IType.IDouble doubleVariable = right as IEffect.Types.IEffectVariable.Types.IType.IDouble;
				if (doubleVariable != null)
				{
					objectBinder.Bind((ParameterDescriptionBase l) => owningParameters.WhenParameterValueChanges.Where((ParameterDescriptionBase p) => p == null || p == l), (IEffect.Types.IEffectVariable.Types.IType r) => doubleVariable.Value.Value.WhenValueChanges, delegate(ParameterDescriptionBase l, IEffect.Types.IEffectVariable.Types.IType r)
					{
						doubleVariable.Value.Value.Set(owningParameters.GetValue<double>(l));
					}, delegate(IEffect.Types.IEffectVariable.Types.IType r, ParameterDescriptionBase l)
					{
						owningParameters.SetValue(l, doubleVariable.Value.Value.Value);
					});
				}
				else
				{
					IEffect.Types.IEffectVariable.Types.IType.IFloat floatVariable = right as IEffect.Types.IEffectVariable.Types.IType.IFloat;
					if (floatVariable != null)
					{
						objectBinder.Bind((ParameterDescriptionBase l) => owningParameters.WhenParameterValueChanges.Where((ParameterDescriptionBase p) => p == null || p == l), (IEffect.Types.IEffectVariable.Types.IType r) => floatVariable.Value.Value.WhenValueChanges, delegate(ParameterDescriptionBase l, IEffect.Types.IEffectVariable.Types.IType r)
						{
							floatVariable.Value.Value.Set(owningParameters.GetValue<float>(l));
						}, delegate(IEffect.Types.IEffectVariable.Types.IType r, ParameterDescriptionBase l)
						{
							owningParameters.SetValue(l, floatVariable.Value.Value.Value);
						});
					}
					else
					{
						IEffect.Types.IEffectVariable.Types.IType.IInt intVariable = right as IEffect.Types.IEffectVariable.Types.IType.IInt;
						if (intVariable != null)
						{
							objectBinder.Bind((ParameterDescriptionBase l) => owningParameters.WhenParameterValueChanges.Where((ParameterDescriptionBase p) => p == null || p == l), (IEffect.Types.IEffectVariable.Types.IType r) => intVariable.Value.Value.WhenValueChanges, delegate(ParameterDescriptionBase l, IEffect.Types.IEffectVariable.Types.IType r)
							{
								intVariable.Value.Value.Set(owningParameters.GetValue<int>(l));
							}, delegate(IEffect.Types.IEffectVariable.Types.IType r, ParameterDescriptionBase l)
							{
								owningParameters.SetValue(l, intVariable.Value.Value.Value);
							});
						}
					}
				}
			}
		}
		return objectBinder;
	}

	public void SerializeToEntity(IEntityFactory entityFactory, IEffect effect)
	{
		effect.Uuid.Set(ID);
		effect.Enabled.Set(IsEnabled);
		effect.RenderId.Set(EffectDescription?.ID.ToString() ?? string.Empty);
		effect.Variables.Clear();
		ParameterDescriptionBase[] array = EffectDescription?.Parameters ?? Array.Empty<ParameterDescriptionBase>();
		foreach (ParameterDescriptionBase parameterDescriptionBase in array)
		{
			IEffect.Types.IEffectVariable effectVariable = entityFactory.Create<IEffect.Types.IEffectVariable>();
			effect.Variables.Add(effectVariable);
			if (parameterDescriptionBase.ParameterType == ParameterType.Direction)
			{
				IEffect.Types.IEffectVariable.Types.IType.IDirection direction = entityFactory.Create<IEffect.Types.IEffectVariable.Types.IType.IDirection>();
				direction.Set(entityFactory.Create<IEffect.Types.IEffectVariable.Types.IEffectDirection>());
				effectVariable.Type.Set(direction);
			}
			else if (parameterDescriptionBase.ParameterType == ParameterType.Color)
			{
				IEffect.Types.IEffectVariable.Types.IType.IColor color = entityFactory.Create<IEffect.Types.IEffectVariable.Types.IType.IColor>();
				color.Set(entityFactory.Create<IEffect.Types.IEffectVariable.Types.IEffectColor>());
				effectVariable.Type.Set(color);
			}
			else if (parameterDescriptionBase.ParameterType == ParameterType.Double)
			{
				IEffect.Types.IEffectVariable.Types.IType.IDouble @double = entityFactory.Create<IEffect.Types.IEffectVariable.Types.IType.IDouble>();
				@double.Set(entityFactory.Create<IEffect.Types.IEffectVariable.Types.IEffectDouble>());
				effectVariable.Type.Set(@double);
			}
			else if (parameterDescriptionBase.ParameterType == ParameterType.Float)
			{
				IEffect.Types.IEffectVariable.Types.IType.IFloat @float = entityFactory.Create<IEffect.Types.IEffectVariable.Types.IType.IFloat>();
				@float.Set(entityFactory.Create<IEffect.Types.IEffectVariable.Types.IEffectFloat>());
				effectVariable.Type.Set(@float);
			}
			else
			{
				if (parameterDescriptionBase.ParameterType != 0)
				{
					throw new InvalidDataException($"Unhandled parameter type {parameterDescriptionBase.ParameterType}");
				}
				IEffect.Types.IEffectVariable.Types.IType.IInt @int = entityFactory.Create<IEffect.Types.IEffectVariable.Types.IType.IInt>();
				@int.Set(entityFactory.Create<IEffect.Types.IEffectVariable.Types.IEffectInt>());
				effectVariable.Type.Set(@int);
			}
			effectVariable.Name.Set(parameterDescriptionBase.Name);
			effectVariable.Description.Set(parameterDescriptionBase.Description);
			SerializeVariableToEntity(parameterDescriptionBase, effectVariable.Type.Value);
		}
	}

	private void SerializeVariableToEntity(ParameterDescriptionBase parameters, IEffect.Types.IEffectVariable.Types.IType right)
	{
		if (right is IEffect.Types.IEffectVariable.Types.IType.IColor color)
		{
			color.Value.Color.Set(GetValue<System.Windows.Media.Color>(parameters).ToEntityColor());
		}
		else if (right is IEffect.Types.IEffectVariable.Types.IType.IDirection direction)
		{
			direction.Value.Direction.Set(GetValue<Direction>(parameters).ToEntityDirection());
		}
		else if (right is IEffect.Types.IEffectVariable.Types.IType.IDouble @double)
		{
			@double.Value.Value.Set(GetValue<double>(parameters));
		}
		else if (right is IEffect.Types.IEffectVariable.Types.IType.IFloat @float)
		{
			@float.Value.Value.Set(GetValue<float>(parameters));
		}
		else if (right is IEffect.Types.IEffectVariable.Types.IType.IInt @int)
		{
			@int.Value.Value.Set(GetValue<int>(parameters));
		}
	}

	public void DeserializeEntity(IEffect effect)
	{
		ID = effect.Uuid.Value;
		IsEnabled = effect.Enabled.Value;
		foreach (IEffect.Types.IEffectVariable entityVariable in effect.Variables.Items)
		{
			ParameterDescriptionBase parameterDescriptionBase = EffectDescription?.Parameters.FirstOrDefault((ParameterDescriptionBase p) => p.Name == entityVariable.Name.Value);
			if (parameterDescriptionBase != null)
			{
				DeserializeVariable(parameterDescriptionBase, entityVariable);
			}
		}
	}

	private void DeserializeVariable(ParameterDescriptionBase parameter, IEffect.Types.IEffectVariable right)
	{
		if (right is IEffect.Types.IEffectVariable.Types.IType.IColor color)
		{
			SetValue(parameter, color.Value.Color.ToColor());
		}
		else if (right is IEffect.Types.IEffectVariable.Types.IType.IDirection direction)
		{
			SetValue(parameter, direction.Value.Direction.Value.ToDirection());
		}
		else if (right is IEffect.Types.IEffectVariable.Types.IType.IDouble @double)
		{
			SetValue(parameter, @double.Value.Value.Value);
		}
		else if (right is IEffect.Types.IEffectVariable.Types.IType.IFloat @float)
		{
			SetValue(parameter, @float.Value.Value.Value);
		}
		else if (right is IEffect.Types.IEffectVariable.Types.IType.IInt @int)
		{
			SetValue(parameter, @int.Value.Value.Value);
		}
	}

	public EffectParameters(Guid id, EffectDescription? description, bool isEnabled = false, bool isLocked = false)
		: this(description, isEnabled, isLocked, loadParams: true)
	{
		ID = id;
	}

	public EffectParameters(EffectDescription? description, bool isEnabled = false, bool isLocked = false)
		: this(description, isEnabled, isLocked, loadParams: true)
	{
	}

	protected EffectParameters(EffectDescription? description, bool isEnabled, bool isLocked, bool loadParams)
	{
		EffectDescription = description;
		IsEnabled = isEnabled;
		IsLocked = isLocked;
		if (loadParams)
		{
			Reset(ignoreLock: true, raiseNotification: false);
		}
	}

	protected void OnParametersChanged()
	{
		this.ParametersChanged?.Invoke(this);
	}

	protected void ThrowIfLocked()
	{
		if (IsLocked)
		{
			throw new InvalidOperationException("The parameters are locked");
		}
	}

	private void ValidateParameterType<T>(ParameterDescriptionBase parameter)
	{
		if (EffectDescription != null && !EffectDescription.Parameters.Contains(parameter))
		{
			throw new ArgumentException("The parameter is not used by this effect", "parameter");
		}
		if (typeof(T) != parameter.BackingType)
		{
			throw new ArgumentException("The value type does not match the parameter", "T");
		}
	}

	protected object? GetValue(ParameterDescriptionBase parameter)
	{
		return _parameterValueMap[parameter];
	}

	public string GetValueAsString(ParameterDescriptionBase parameter)
	{
		return _parameterValueMap[parameter]?.ToString() ?? string.Empty;
	}

	public T? GetValue<T>(ParameterDescriptionBase parameter)
	{
		ValidateParameterType<T>(parameter);
		return (T)_parameterValueMap[parameter];
	}

	public void SetValue<T>(ParameterDescriptionBase parameter, T value)
	{
		ThrowIfLocked();
		ValidateParameterType<T>(parameter);
		if (parameter.IsValueValid(value) && !object.Equals(_parameterValueMap[parameter], value))
		{
			_parameterValueMap[parameter] = value;
			OnParametersChanged();
			_whenParameterValueChanges.OnNext(parameter);
		}
	}

	public void Lock()
	{
		IsLocked = true;
	}

	public void Reset()
	{
		Reset(ignoreLock: false, raiseNotification: true);
	}

	protected void Reset(bool ignoreLock, bool raiseNotification)
	{
		if (!ignoreLock)
		{
			ThrowIfLocked();
		}
		OnReset();
		if (raiseNotification)
		{
			OnParametersChanged();
		}
	}

	protected virtual void OnReset()
	{
		if (EffectDescription != null)
		{
			ParameterDescriptionBase[] parameters = EffectDescription.Parameters;
			foreach (ParameterDescriptionBase parameterDescriptionBase in parameters)
			{
				_parameterValueMap[parameterDescriptionBase] = GetDefaultValue(parameterDescriptionBase);
			}
			_whenParameterValueChanges.OnNext(null);
		}
	}

	protected virtual object? GetDefaultValue(ParameterDescriptionBase parameter)
	{
		return parameter.GetDefaultValue();
	}

	public override bool Equals(object? obj)
	{
		if (obj is EffectParameters)
		{
			return Equals((EffectParameters)obj);
		}
		return false;
	}

	public bool Equals(EffectParameters? other)
	{
		if (EffectDescription != other?.EffectDescription)
		{
			return false;
		}
		IEnumerable<ParameterDescriptionBase> enumerable = EffectDescription?.Parameters;
		foreach (ParameterDescriptionBase item in enumerable ?? Enumerable.Empty<ParameterDescriptionBase>())
		{
			if (!object.Equals(_parameterValueMap[item], other?._parameterValueMap[item]))
			{
				return false;
			}
		}
		return true;
	}

	public override int GetHashCode()
	{
		if (!_hashCode.HasValue)
		{
			_hashCode = GenerateHashCode();
		}
		return _hashCode.Value;
	}

	protected virtual int GenerateHashCode()
	{
		return HashCodeHelper.GenerateHashCode(new IEnumerable[1] { _parameterValueMap.Values }, EffectDescription, IsEnabled);
	}

	public virtual EffectParameters CopyFrom(EffectParameters source)
	{
		if (EffectDescription != source.EffectDescription)
		{
			throw new InvalidOperationException();
		}
		ThrowIfLocked();
		EffectDescription?.Parameters.ForEach(delegate(ParameterDescriptionBase p)
		{
			_parameterValueMap[p] = source._parameterValueMap[p];
		});
		return this;
	}

	public Effect Serialize()
	{
		if ((object)EffectDescription != null)
		{
			Effect effect = new Effect
			{
				RenderId = EffectDescription.ID.ToString().ToUpperInvariant(),
				Enabled = IsEnabled,
				Name = EffectDescription.Name,
				BehaviorDescription = EffectDescription.Description,
				Category = EffectDescription.Category,
				Uuid = ID.ToUUID()
			};
			ParameterDescriptionBase[] parameters = EffectDescription.Parameters;
			foreach (ParameterDescriptionBase parameterDescriptionBase in parameters)
			{
				Effect.Types.EffectVariable effectVariable = new Effect.Types.EffectVariable();
				effectVariable.Name = parameterDescriptionBase.Name;
				effectVariable.Description = parameterDescriptionBase.Description;
				switch (parameterDescriptionBase.ParameterType)
				{
				case ParameterType.Color:
					effectVariable.Color = new Effect.Types.EffectVariable.Types.EffectColor
					{
						DefaultColor = (parameterDescriptionBase as ColorParameterDescription)?.DefaultColor.ToProtoColor(),
						Color = GetValue<System.Windows.Media.Color>(parameterDescriptionBase).ToProtoColor()
					};
					break;
				case ParameterType.Direction:
					effectVariable.Direction = new Effect.Types.EffectVariable.Types.EffectDirection
					{
						DefaultDirection = (Effect.Types.EffectVariable.Types.EffectDirection.Types.EffectDirection)(parameterDescriptionBase as DirectionParameterDescription).DefaultDirection,
						Direction = (Effect.Types.EffectVariable.Types.EffectDirection.Types.EffectDirection)GetValue<Direction>(parameterDescriptionBase),
						AvailableDirections = (uint)(parameterDescriptionBase as DirectionParameterDescription).AllowedDirections
					};
					break;
				case ParameterType.Double:
					effectVariable.Double = new Effect.Types.EffectVariable.Types.EffectDouble
					{
						DefaultValue = (parameterDescriptionBase as DoubleParameterDescription).DefaultValue,
						Max = (parameterDescriptionBase as DoubleParameterDescription).MaxValue,
						Min = (parameterDescriptionBase as DoubleParameterDescription).MinValue,
						Value = GetValue<double>(parameterDescriptionBase)
					};
					break;
				case ParameterType.Float:
					effectVariable.Float = new Effect.Types.EffectVariable.Types.EffectFloat
					{
						DefaultValue = (parameterDescriptionBase as FloatParameterDescription).DefaultValue,
						Max = (parameterDescriptionBase as FloatParameterDescription).MaxValue,
						Min = (parameterDescriptionBase as FloatParameterDescription).MinValue,
						Value = GetValue<float>(parameterDescriptionBase)
					};
					break;
				case ParameterType.Int:
					effectVariable.Int = new Effect.Types.EffectVariable.Types.EffectInt
					{
						DefaultValue = (parameterDescriptionBase as IntParameterDescription).DefaultValue,
						Max = (parameterDescriptionBase as IntParameterDescription).MaxValue,
						Min = (parameterDescriptionBase as IntParameterDescription).MinValue,
						Value = GetValue<int>(parameterDescriptionBase)
					};
					break;
				}
				effect.Variables.Add(effectVariable);
			}
			return effect;
		}
		return new Effect
		{
			Enabled = IsEnabled,
			Uuid = ID.ToUUID()
		};
	}

	public void Deserialize(Effect protoEffect)
	{
		IsEnabled = protoEffect.Enabled;
		int val = 0;
		if (EffectDescription != null)
		{
			val = EffectDescription.Parameters.Length;
		}
		int num = Math.Min(val, protoEffect.Variables.Count);
		for (int i = 0; i < num; i++)
		{
			ParameterDescriptionBase parameterDescriptionBase = EffectDescription.Parameters[i];
			Effect.Types.EffectVariable effectVariable = protoEffect.Variables[i];
			if (parameterDescriptionBase.ParameterType == ParameterType.Int && effectVariable.TypeCase == Effect.Types.EffectVariable.TypeOneofCase.Int)
			{
				SetValue(parameterDescriptionBase, effectVariable.Int.Value);
			}
			else if (parameterDescriptionBase.ParameterType == ParameterType.Float && effectVariable.TypeCase == Effect.Types.EffectVariable.TypeOneofCase.Float)
			{
				SetValue(parameterDescriptionBase, effectVariable.Float.Value);
			}
			else if (parameterDescriptionBase.ParameterType == ParameterType.Double && effectVariable.TypeCase == Effect.Types.EffectVariable.TypeOneofCase.Double)
			{
				SetValue(parameterDescriptionBase, effectVariable.Double.Value);
			}
			else if (parameterDescriptionBase.ParameterType == ParameterType.Direction && effectVariable.TypeCase == Effect.Types.EffectVariable.TypeOneofCase.Direction)
			{
				SetValue(parameterDescriptionBase, (Direction)effectVariable.Direction.Direction);
			}
			else if (parameterDescriptionBase.ParameterType == ParameterType.Color && effectVariable.TypeCase == Effect.Types.EffectVariable.TypeOneofCase.Color)
			{
				SetValue(parameterDescriptionBase, effectVariable.Color.Color.ToColor());
			}
			else
			{
				Log.Warning("Effect parameter/variable mismatch");
			}
		}
	}

	public void Deserialize(IEffect effect)
	{
		IsEnabled = effect.Enabled.Value;
		int val = 0;
		if (EffectDescription != null)
		{
			val = EffectDescription.Parameters.Length;
		}
		int num = Math.Min(val, effect.Variables.Items.Count);
		for (int i = 0; i < num; i++)
		{
			ParameterDescriptionBase parameterDescriptionBase = EffectDescription.Parameters[i];
			IEffect.Types.IEffectVariable effectVariable = effect.Variables.Items[i];
			if (parameterDescriptionBase.ParameterType == ParameterType.Int && effectVariable is IEffect.Types.IEffectVariable.Types.IEffectInt effectInt)
			{
				SetValue(parameterDescriptionBase, effectInt.Value);
			}
			else if (parameterDescriptionBase.ParameterType == ParameterType.Float && effectVariable is IEffect.Types.IEffectVariable.Types.IEffectFloat effectFloat)
			{
				SetValue(parameterDescriptionBase, effectFloat.Value);
			}
			else if (parameterDescriptionBase.ParameterType == ParameterType.Double && effectVariable is IEffect.Types.IEffectVariable.Types.IEffectDouble effectDouble)
			{
				SetValue(parameterDescriptionBase, effectDouble.Value);
			}
			else if (parameterDescriptionBase.ParameterType == ParameterType.Direction && effectVariable is IEffect.Types.IEffectVariable.Types.IEffectDirection effectDirection)
			{
				SetValue(parameterDescriptionBase, (Direction)effectDirection.Direction.Value);
			}
			else if (parameterDescriptionBase.ParameterType == ParameterType.Color && effectVariable is IEffect.Types.IEffectVariable.Types.IEffectColor effectColor)
			{
				SetValue(parameterDescriptionBase, effectColor.Color.Value.ToColor());
			}
			else
			{
				Log.Warning("Effect parameter/variable mismatch");
			}
		}
	}

	public static bool operator ==(EffectParameters lhs, EffectParameters rhs)
	{
		return lhs.NullableEquals<EffectParameters>(rhs);
	}

	public static bool operator !=(EffectParameters lhs, EffectParameters rhs)
	{
		return !lhs.NullableEquals<EffectParameters>(rhs);
	}
}
