using System;
using Pro.Common.Components;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Transitions.Descriptions;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Transitions;

public class TransitionPreset : NotifyPropertyChangedBase
{
	private string _name;

	private TransitionParameters? _parameters;

	public Guid ID { get; set; } = Guid.NewGuid();

	public bool CanRename { get; }

	public string Name
	{
		get
		{
			return _name;
		}
		set
		{
			if (!CanRename)
			{
				throw new NotSupportedException();
			}
			SetValue("Name", ref _name, value);
		}
	}

	public TransitionParameters? Parameters
	{
		get
		{
			return _parameters;
		}
		private set
		{
			SetValue("Parameters", ref _parameters, value);
		}
	}

	public static IReadOnlyObjectBinder CreateBinder(IEntityFactory entityFactory, TransitionPreset left, ITransition.Types.IPresetDoc right)
	{
		ObjectBinder<TransitionPreset, ITransition.Types.IPresetDoc> objectBinder = new ObjectBinder<TransitionPreset, ITransition.Types.IPresetDoc>(left, right);
		objectBinder.Bind((TransitionPreset l) => l.WhenPropertyChanges("Name"), (ITransition.Types.IPresetDoc r) => r.Name.WhenValueChanges, delegate(TransitionPreset l, ITransition.Types.IPresetDoc r)
		{
			r.Name.Set(l.Name);
		}, delegate(ITransition.Types.IPresetDoc r, TransitionPreset l)
		{
			l.Name = r.Name.Value;
		}).Bind((TransitionPreset l) => l.WhenPropertyChanges("ID"), (ITransition.Types.IPresetDoc r) => r.Uuid.WhenValueChanges, delegate(TransitionPreset l, ITransition.Types.IPresetDoc r)
		{
			r.Uuid.Set(l.ID);
		}, delegate(ITransition.Types.IPresetDoc r, TransitionPreset l)
		{
			l.ID = r.Uuid.Value;
		}).Bind((TransitionPreset l) => l.WhenPropertyChanges("Parameters"), (ITransition.Types.IPresetDoc r) => r.Transition.WhenValueChanges, delegate(TransitionPreset l, ITransition.Types.IPresetDoc r)
		{
			ITransition transition = entityFactory.Create<ITransition>();
			r.Transition.Set(transition);
			ObjectBinder<TransitionParameters, ITransition> objectBinder2 = TransitionParameters.CreateBinder(entityFactory, l.Parameters, transition);
			objectBinder2.InitializeRightFromLeft();
			r.RegisterLinkedDisposable(objectBinder2);
		}, delegate(ITransition.Types.IPresetDoc r, TransitionPreset l)
		{
			ObjectBinder<TransitionParameters, ITransition> objectBinder3 = TransitionParameters.CreateBinder(entityFactory, l.Parameters, r.Transition.Value);
			objectBinder3.InitializeLeftFromRight();
			r.RegisterLinkedDisposable(objectBinder3);
		});
		return objectBinder;
	}

	internal TransitionPreset(ITransitionDescriptionCollection transitionDescriptions, Transition.Types.Preset protoPreset, bool canRename)
		: this(protoPreset.Name, new TransitionParameters(transitionDescriptions, protoPreset.Transition), canRename)
	{
		ID = protoPreset.Uuid.ToGuid();
	}

	public TransitionPreset(TransitionDescription? description, bool canRename)
		: this(description?.DisplayName ?? string.Empty, new TransitionParameters(description), canRename)
	{
	}

	internal TransitionPreset(string name, TransitionParameters parameters, bool canRename)
	{
		_name = name;
		CanRename = canRename;
		UpdateParameters(parameters);
	}

	internal void UpdateParameters(TransitionParameters parameters)
	{
		parameters.Lock();
		Parameters = parameters;
	}

	public Transition.Types.Preset Serialize()
	{
		return new Transition.Types.Preset
		{
			Name = Name,
			Transition = Parameters?.Serialize(),
			Uuid = ID.ToUUID()
		};
	}
}
