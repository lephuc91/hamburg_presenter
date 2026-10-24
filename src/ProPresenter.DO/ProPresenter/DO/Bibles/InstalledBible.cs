using System;

namespace ProPresenter.DO.Bibles;

public class InstalledBible
{
	public Guid ID { get; }

	public string TrackingAbbreviation { get; }

	public string Name { get; }

	public BibleFormat Format { get; set; }

	public InstalledBible(Guid id, string trackingAbbreviation, string name, BibleFormat format)
	{
		ID = id;
		TrackingAbbreviation = trackingAbbreviation;
		Name = name;
		Format = format;
	}

	public static string Encode(InstalledBible bible)
	{
		global::_003C_003Ey__InlineArray4<object> buffer = default(global::_003C_003Ey__InlineArray4<object>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 0) = bible.ID;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 1) = bible.TrackingAbbreviation;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 2) = bible.Name;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 3) = (int)bible.Format;
		return string.Join("|", global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray4<object>, object>(in buffer, 4));
	}

	public static InstalledBible Decode(string encodedData)
	{
		string[] array = encodedData.Split('|');
		if (array.Length != 4)
		{
			throw new ArgumentException();
		}
		return new InstalledBible(Guid.Parse(array[0]), array[1], array[2], (BibleFormat)int.Parse(array[3]));
	}
}
