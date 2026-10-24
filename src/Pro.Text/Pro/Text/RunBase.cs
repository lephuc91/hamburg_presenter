using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Nullability;
using Pro.Common.Utility;

namespace Pro.Text;

[DebuggerDisplay("{RunType}")]
public abstract class RunBase : IEquatable<RunBase>, ICloneable<RunBase>
{
	private UndoStack? _undoStack;

	private RunSettings _settings;

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
		}
	}

	public abstract RunType RunType { get; }

	public virtual int Length => PlainText.Length;

	protected internal abstract string PlainText { get; }

	public abstract bool IsEmpty { get; }

	public RunSettings Settings
	{
		get
		{
			return _settings;
		}
		[MemberNotNull("_settings")]
		private set
		{
			if ((object)_settings != null)
			{
				_settings.PropertyChanged -= SettingsChanged;
			}
			_settings = value;
			_settings.PropertyChanged += SettingsChanged;
			_settings.UndoStack = UndoStack;
			OnRunChanged();
		}
	}

	public event Action<RunBase>? RunChanged;

	protected RunBase(RunSettings settings)
	{
		Settings = settings;
	}

	protected internal abstract void Clear();

	protected internal abstract bool CanMerge(RunBase otherRun);

	protected internal abstract void MergeFrom(RunBase otherRun);

	protected internal abstract bool CanSplit(int characterIndex);

	protected internal abstract RunBase Split(int characterIndex);

	protected internal abstract void RemoveCharacter(int characterIndex);

	protected abstract bool OnEquals(RunBase other);

	public override int GetHashCode()
	{
		return HashCodeHelper.GenerateHashCode(_settings, RunType, IsEmpty);
	}

	public override bool Equals(object? obj)
	{
		if (obj is RunBase other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(RunBase? other)
	{
		if ((object)other != null && RunType == other.RunType && _settings == other._settings)
		{
			return OnEquals(other);
		}
		return false;
	}

	public abstract RunBase Clone();

	public void AssignSettings(RunSettings settings)
	{
		Settings = settings.Clone();
	}

	public void AssignTemplateSettings(RunSettings defaultSettings, RunSettings templateSettings)
	{
		foreach (TextDocumentAttributeHelper.PropertyAttributeMap runSettingsPropertiesWithAttribute in TextDocumentAttributeHelper.RunSettingsPropertiesWithAttributes)
		{
			TextAttributeType? textAttributeType = runSettingsPropertiesWithAttribute.Attribute?.Type;
			if (textAttributeType.HasValue && textAttributeType == TextAttributeType.Ignore)
			{
				continue;
			}
			object value = runSettingsPropertiesWithAttribute.Property.GetValue(Settings);
			object value2 = runSettingsPropertiesWithAttribute.Property.GetValue(defaultSettings);
			object value3 = runSettingsPropertiesWithAttribute.Property.GetValue(templateSettings);
			switch (runSettingsPropertiesWithAttribute.Attribute?.Type)
			{
			case TextAttributeType.CharacterSize:
			{
				value.ThrowWhenNull("value");
				value2.ThrowWhenNull("defaultValue");
				value3.ThrowWhenNull("templateValue");
				double a = (double)((int?)value).Value / (double)((int?)value2).Value * (double)((int?)value3).Value;
				runSettingsPropertiesWithAttribute.Property.SetValue(Settings, (int)Math.Ceiling(a));
				break;
			}
			case TextAttributeType.Font:
			{
				value.ThrowWhenNull("value");
				value2.ThrowWhenNull("defaultValue");
				value3.ThrowWhenNull("templateValue");
				FontInfo lhs2 = (FontInfo)value;
				FontInfo rhs2 = (FontInfo)value2;
				FontInfo fontInfo = (FontInfo)value3;
				if (compareFonts(lhs2, rhs2))
				{
					if (lhs2.IsBold != rhs2.IsBold && lhs2.IsBold != fontInfo.IsBold)
					{
						fontInfo = fontInfo.ToggleBold();
					}
					if (lhs2.IsItalic != rhs2.IsItalic && lhs2.IsItalic != fontInfo.IsItalic)
					{
						fontInfo = fontInfo.ToggleItalic();
					}
					runSettingsPropertiesWithAttribute.Property.SetValue(Settings, fontInfo);
				}
				break;
			}
			case TextAttributeType.StrokeColor:
				if (templateSettings.IsStrokeVisible && object.Equals(value, value2))
				{
					runSettingsPropertiesWithAttribute.Property.SetValue(Settings, value3);
				}
				break;
			case TextAttributeType.Fill:
				if (((object)Settings == null || !Settings.PreserveFillColor) && object.Equals(value, value2))
				{
					runSettingsPropertiesWithAttribute.Property.SetValue(Settings, ((TextFillBase)value3)?.Clone());
				}
				break;
			default:
				if (runSettingsPropertiesWithAttribute.Attribute != null && object.Equals(value, value2))
				{
					runSettingsPropertiesWithAttribute.Property.SetValue(Settings, value3);
				}
				break;
			}
		}
		static bool compareFonts(FontInfo lhs, FontInfo rhs)
		{
			if (!UnitTestDetector.IsInUnitTest)
			{
				return SharedTypefaceLibrary.Library.FindFont(lhs).Info.SystemFamilyName == SharedTypefaceLibrary.Library.FindFont(rhs).Info.SystemFamilyName;
			}
			return lhs.SystemFamilyName == rhs.SystemFamilyName;
		}
	}

	protected void OnRunChanged()
	{
		this.RunChanged?.Invoke(this);
	}

	private void SettingsChanged(object? sender, PropertyChangedEventArgs e)
	{
		OnRunChanged();
	}

	public static bool operator ==(RunBase? lhs, RunBase? rhs)
	{
		return lhs.NullableEquals(rhs);
	}

	public static bool operator !=(RunBase? lhs, RunBase? rhs)
	{
		return !lhs.NullableEquals(rhs);
	}
}
