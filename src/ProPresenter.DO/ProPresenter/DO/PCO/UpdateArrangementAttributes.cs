namespace ProPresenter.DO.PCO;

public class UpdateArrangementAttributes
{
	public string Name { get; } = string.Empty;

	public float? Bpm { get; }

	public int? Length { get; }

	public string Meter { get; } = string.Empty;

	public string Notes { get; } = string.Empty;

	public string ChordChart { get; set; } = string.Empty;

	public string ChordChartFont { get; set; } = string.Empty;

	public string ChordChartKey { get; set; } = string.Empty;

	public int? ChordChartColumns { get; set; }

	public int? ChordChartFontSize { get; set; }

	public int? ChordChartChordColor { get; set; }

	public UpdateArrangementAttributes(string name, float? bpm = null, int? length = null, string? meter = null, string? notes = null)
	{
		Name = name;
		Bpm = bpm;
		Length = length;
		Meter = meter ?? string.Empty;
		Notes = notes ?? string.Empty;
	}
}
