using System.IO;

namespace ProPresenter.DO.Bibles;

public class AvailableSideBible : AvailableBibleBase
{
	private string _name;

	private string _abbreviation;

	public override string Name => _name;

	public override string TrackingAbbreviation => _abbreviation;

	public override string DisplayAbbreviation => _abbreviation;

	public override bool IsActive => true;

	public string Filename { get; }

	public AvailableSideBible(string filename)
		: base(string.Empty, string.Empty, string.Empty, string.Empty)
	{
		_name = Path.GetFileName(filename);
		_abbreviation = Path.GetFileNameWithoutExtension(filename);
		Filename = filename;
	}

	internal void UpdateMetadata(string name, string abbreviation)
	{
		_name = name;
		_abbreviation = abbreviation;
		OnPropertyChanged("Name");
		OnPropertyChanged("TrackingAbbreviation");
		OnPropertyChanged("DisplayAbbreviation");
	}
}
