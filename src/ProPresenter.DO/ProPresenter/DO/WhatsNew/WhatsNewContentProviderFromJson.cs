using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Media;
using Pro.Common.Logging;
using Pro.Common.Utility;
using ProPresenter.DO.WhatsNew.Model;

namespace ProPresenter.DO.WhatsNew;

public class WhatsNewContentProviderFromJson : IWhatsNewContentProviderFromJson
{
	private readonly WhatsNewModel? _whatsNewModel;

	public Color AccentColor { get; } = Colors.Orange;

	public Version? Version { get; }

	public IEnumerable<IFeatureItem> GetFeatures()
	{
		List<IFeatureItem> list = new List<IFeatureItem>();
		if (_whatsNewModel != null)
		{
			foreach (FeatureItem feature in _whatsNewModel.Features)
			{
				list.Add(feature);
			}
		}
		return list;
	}

	public WhatsNewContentProviderFromJson(Stream stream)
	{
		try
		{
			string json;
			using (StreamReader streamReader = new StreamReader(stream))
			{
				json = streamReader.ReadToEnd();
			}
			JsonSerializerOptions options = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			};
			_whatsNewModel = JsonSerializer.Deserialize<WhatsNewModel>(json, options);
			if (_whatsNewModel != null && _whatsNewModel.AccentColor != null)
			{
				AccentColor = ColorExtensions.FromNormalizedRGBA(_whatsNewModel.AccentColor.Red, _whatsNewModel.AccentColor.Green, _whatsNewModel.AccentColor.Blue, _whatsNewModel.AccentColor.Alpha);
			}
			if (_whatsNewModel != null && !string.IsNullOrEmpty(_whatsNewModel.Version))
			{
				Version = new Version(_whatsNewModel.Version);
			}
		}
		catch (Exception exception)
		{
			Log.Error(exception);
		}
	}
}
