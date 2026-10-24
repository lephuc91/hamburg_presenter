namespace Pro.Text;

public class FontGroup
{
	public string SystemName { get; }

	public string DisplayName { get; }

	public Font[] Fonts { get; }

	public virtual bool? IsMissing => null;

	public FontGroup(string systemName, string displayName, Font[] fonts)
	{
		SystemName = systemName;
		DisplayName = displayName;
		Fonts = fonts;
	}
}
