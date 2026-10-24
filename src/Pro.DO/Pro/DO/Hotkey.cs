using System;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Components;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO;

public class Hotkey : NotifyPropertyChangedBase, IEquatable<Hotkey?>, ICloneable<Hotkey>
{
	private Key _key;

	private System.Windows.Media.Color _color = Colors.Orange;

	public Key Key
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return _key;
		}
		set
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			SetValue("Key", ref _key, value);
		}
	}

	public System.Windows.Media.Color Color
	{
		get
		{
			return _color;
		}
		set
		{
			SetValue("Color", ref _color, value);
		}
	}

	public static ObjectBinder<Hotkey, IHotKey> CreateBinder(Hotkey? left, IHotKey right)
	{
		ObjectBinder<Hotkey, IHotKey> objectBinder = new ObjectBinder<Hotkey, IHotKey>(left, right);
		objectBinder.Bind((Hotkey l) => l.WhenPropertyChanges("Key"), (IHotKey r) => r.Code.WhenValueChanges, delegate(Hotkey l, IHotKey r)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			r.Code.Set(l.Key.ToEntityKeyCode().GetValueOrDefault());
		}, delegate(IHotKey r, Hotkey l)
		{
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			l.Key = r.Code.ToKey().GetValueOrDefault();
		});
		return objectBinder;
	}

	public Hotkey(Key key)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		_key = key;
	}

	public Hotkey(Key key, System.Windows.Media.Color color)
		: this(key)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		_color = color;
	}

	public bool IsValid()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		return (int)Key > 0;
	}

	public Hotkey Clone()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		return new Hotkey(_key, _color);
	}

	public override bool Equals(object? obj)
	{
		if (obj is Hotkey)
		{
			return Equals((Hotkey)obj);
		}
		return false;
	}

	public bool Equals(Hotkey? other)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		return (Key?)_key == other?._key;
	}

	public override int GetHashCode()
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		return HashCodeHelper.GenerateHashCode(_key);
	}

	public HotKey? Serialize()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		Pro.SerializationInterop.RVProtoData.KeyCode? keyCode = Key.ToProtoKeyCode();
		if (!keyCode.HasValue)
		{
			return null;
		}
		return new HotKey
		{
			Code = keyCode.Value
		};
	}

	public void Deserialize(HotKey protoHotkey)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		Key = (protoHotkey?.Code.ToKey()).GetValueOrDefault();
	}

	public static bool operator ==(Hotkey? lhs, Hotkey? rhs)
	{
		return lhs.NullableEquals(rhs);
	}

	public static bool operator !=(Hotkey? lhs, Hotkey? rhs)
	{
		return !lhs.NullableEquals(rhs);
	}
}
