using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.UI.Components;

namespace Pro.UI.InputActions;

public class InputAction : LinkedNotifyPropertyChangedBase
{
	private const string PathDelimiter = "⯈";

	private BindableRoutedCommand _command;

	private VirtualKeyGesture? _keyboardGesture;

	private string? _label;

	private bool _hasConflicts;

	private readonly IEnumerable<string>? _accessPath;

	private VirtualKeyGesture? _defaultKeyboardGesture;

	private readonly List<InputAction> _conflicts = new List<InputAction>();

	public virtual InputActionType Type => InputActionType.MenuItem;

	public ICommand BindCommand => _command;

	public VirtualKeyGesture? DefaultKeyboardGesture => _defaultKeyboardGesture;

	public VirtualKeyGesture? KeyboardGesture
	{
		get
		{
			return _keyboardGesture;
		}
		set
		{
			SetValue<VirtualKeyGesture>("KeyboardGesture", ref _keyboardGesture, value, delegate(VirtualKeyGesture o, VirtualKeyGesture n)
			{
				_command?.UpdateInputGesture(n.ToKeyGesture());
				ParentGroup?.CheckConflict();
				OnKeyboardGestureChanged(o, n);
				OnDataModified();
				OnPropertyChanged("IsCustomized");
			}, ValidateKeyGesture);
		}
	}

	protected virtual bool RequireModifiers { get; }

	public string? Label
	{
		get
		{
			return _label;
		}
		set
		{
			SetValue("Label", ref _label, value, null, false, "AccessPath");
		}
	}

	public InputActionGroupBase ParentGroup { get; }

	public string Identifier { get; private set; }

	public bool HasConflicts
	{
		get
		{
			return _hasConflicts;
		}
		private set
		{
			SetValue("HasConflicts", ref _hasConflicts, value);
		}
	}

	public IEnumerable<InputAction> Conflicts => _conflicts;

	public string AccessPath => string.Join(" ⯈ ", _accessPath?.Concat(Label.ToEnumerable()) ?? Label.ToEnumerable());

	public bool IsCustomized => DefaultKeyboardGesture != KeyboardGesture;

	public event Action? DataModified;

	public event Action<bool>? DidUpdateKeyGesture;

	public virtual ObjectBinder<InputAction, IKeyMapping> Bind(IEntityFactory entityFactory, IKeyMapping entity)
	{
		ObjectBinder<InputAction, IKeyMapping> objectBinder = new ObjectBinder<InputAction, IKeyMapping>(this, entity);
		BindKeyGesture(objectBinder);
		objectBinder.Bind((InputAction l) => l.WhenPropertyChanges("Identifier"), (IKeyMapping r) => r.TargetIdentifier.WhenValueChanges, delegate(InputAction l, IKeyMapping r)
		{
			IKeyMapping.Types.ITargetIdentifier.IMenuItem menuItem = entityFactory.Create<IKeyMapping.Types.ITargetIdentifier.IMenuItem>();
			menuItem.Set(l.Identifier ?? string.Empty);
			r.TargetIdentifier.Set(menuItem);
		}, delegate(IKeyMapping r, InputAction l)
		{
			if (r.TargetIdentifier.Value is IKeyMapping.Types.ITargetIdentifier.IMenuItem menuItem2)
			{
				l.Identifier = menuItem2.Value;
			}
			else
			{
				l.Identifier = string.Empty;
			}
		});
		return objectBinder;
	}

	protected static void BindKeyGesture(ObjectBinder<InputAction, IKeyMapping> binder)
	{
		binder.Bind((InputAction l) => l.WhenPropertyChanges("KeyboardGesture"), (IKeyMapping r) => r.Keyboard.WhenAnyValueChanges, delegate(InputAction l, IKeyMapping r)
		{
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			if (l.KeyboardGesture != null)
			{
				VirtualKeyDataAttribute data = l.KeyboardGesture.Key.GetData();
				r.Keyboard.Value.KeyEquivalentModifierFlags.Reset(l.KeyboardGesture.Modifiers.ToEntityModifierFlags());
				r.Keyboard.Value.KeyEquivalent.Set((data.IsShiftImplied && ((Enum)l.KeyboardGesture.Modifiers).HasFlag((Enum)(object)(ModifierKeys)4)) ? data.ShiftedSerializedValue : data.SerializedValue);
			}
			else
			{
				r.Keyboard.Value.KeyEquivalent.Set("");
				r.Keyboard.Value.KeyEquivalentModifierFlags.Clear();
			}
		}, delegate(IKeyMapping r, InputAction l)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			ModifierKeys val = r.Keyboard.Value.KeyEquivalentModifierFlags.Items.ToModifierKeys();
			bool hasShiftModifier;
			VirtualKey virtualKey = r.Keyboard.Value.KeyEquivalent.Value.FindVirtualKey(out hasShiftModifier);
			if (virtualKey == VirtualKey.None)
			{
				l.KeyboardGesture = null;
			}
			else
			{
				if (hasShiftModifier && !((Enum)val).HasFlag((Enum)(object)(ModifierKeys)4))
				{
					val = (ModifierKeys)(val | 4);
				}
				l.KeyboardGesture = VirtualKeyGesture.CreateKeyGesture(virtualKey, val);
			}
		});
	}

	public InputAction(string identifier, string? label, IEnumerable<VirtualKeyGesture?>? defaultGestures, InputActionGroupBase parentGroup, IEnumerable<string>? accessPath = null, bool requireModifiers = true)
	{
		Identifier = identifier;
		Label = label;
		RequireModifiers = requireModifiers;
		KeyboardGesture = (_defaultKeyboardGesture = defaultGestures?.FirstOrDefault());
		_command = new BindableRoutedCommand(label, identifier, parentGroup.GetType());
		ParentGroup = parentGroup;
		_accessPath = accessPath;
		if (defaultGestures != null)
		{
			_command.InputGestures.AddRange(defaultGestures.Select((VirtualKeyGesture g) => g.ToKeyGesture()).NotNull());
		}
	}

	private void SetCommand(BindableRoutedCommand command)
	{
		_command = command;
		OnPropertyChanged("BindCommand");
	}

	protected void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	internal void Reset()
	{
		KeyboardGesture = DefaultKeyboardGesture;
	}

	public void ChangeDefaultGesture(VirtualKeyGesture? gesture)
	{
		_defaultKeyboardGesture = gesture;
		Reset();
		OnPropertyChanged("DefaultKeyboardGesture");
		OnPropertyChanged("IsCustomized");
	}

	protected virtual bool ValidateKeyGesture(VirtualKeyGesture? virtualKeyGesture)
	{
		if (RequireModifiers)
		{
			bool flag = virtualKeyGesture.IsValid();
			this.DidUpdateKeyGesture?.Invoke(flag);
			return flag;
		}
		this.DidUpdateKeyGesture?.Invoke(obj: true);
		return true;
	}

	protected virtual void OnKeyboardGestureChanged(VirtualKeyGesture? oldValue, VirtualKeyGesture? newValue)
	{
	}

	public bool IsConflict(InputAction other)
	{
		if ((object)KeyboardGesture != null && (object)other.KeyboardGesture != null && KeyboardGesture == other.KeyboardGesture)
		{
			return OnIsConflict(other);
		}
		return false;
	}

	protected virtual bool OnIsConflict(InputAction other)
	{
		return true;
	}

	internal void ResetConflicts()
	{
		HasConflicts = false;
		_conflicts.Clear();
	}

	internal void AddConflict(InputAction inputAction)
	{
		if (!_conflicts.Contains(inputAction))
		{
			_conflicts.Add(inputAction);
		}
		HasConflicts = true;
		if (!inputAction._conflicts.Contains(this))
		{
			inputAction._conflicts.Add(this);
		}
		inputAction.HasConflicts = true;
	}
}
