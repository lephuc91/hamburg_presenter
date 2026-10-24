using System;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Nullability;
using Pro.Serialization.Control;

namespace ProPresenter.DO.Migration.RVData;

public class RVColoredLabel
{
	[Child]
	[Alias("HotKeyValue", typeof(string), false)]
	public string? HotKeyValue { get; internal set; }

	[Child]
	[Alias("ID", typeof(Guid), false)]
	public Guid ID { get; internal set; }

	[Child]
	[Alias("Label", typeof(string), false)]
	public string? Label { get; internal set; }

	[Child]
	[Alias("LabelColorValue", typeof(string), false)]
	public string? LabelColorValue { get; internal set; }

	public void Deconstruct(out string text, out Color color, out Key key)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected I4, but got Unknown
		Key? val = (Key?)((TypeConverter)new KeyConverter()).ConvertFromString(HotKeyValue ?? string.Empty);
		val.ThrowWhenNull("convertedKey");
		key = (Key)(int)val.Value;
		text = Label ?? string.Empty;
		color = (Color)ColorConverter.ConvertFromString(LabelColorValue);
	}
}
