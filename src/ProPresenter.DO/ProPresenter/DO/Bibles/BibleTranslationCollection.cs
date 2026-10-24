using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements;

namespace ProPresenter.DO.Bibles;

public class BibleTranslationCollection : ImmutableObservableCollection<BibleTranslation>, ICloneable<BibleTranslationCollection>
{
	private BibleTranslation? _primaryTranslation;

	public BibleTranslation PrimaryTranslation
	{
		get
		{
			if (_primaryTranslation == null)
			{
				_primaryTranslation = BibleSettings.Settings.PrimaryTranslation;
				_primaryTranslation.PropertyChanged += PrimaryTranslationChanged;
			}
			return _primaryTranslation;
		}
	}

	public IEnumerable<BibleTranslation> All => base.Collection.Prepend(PrimaryTranslation).NonNull();

	public event PropertyChangedEventHandler? TranslationPropertyChanged;

	public BibleTranslationCollection()
	{
	}

	public BibleTranslationCollection(IEnumerable<BibleTranslation> translations)
	{
		if (translations == null || translations.Empty())
		{
			return;
		}
		if (_primaryTranslation == null)
		{
			_primaryTranslation = translations.First();
			_primaryTranslation.PropertyChanged += PrimaryTranslationChanged;
		}
		foreach (BibleTranslation translation in translations)
		{
			if (translation.Abbreviation == null || !translation.Abbreviation.Equals(_primaryTranslation?.Abbreviation))
			{
				AddBibleTranslation(translation);
			}
		}
	}

	public void AddBibleTranslation(BibleBase bible)
	{
		AddBibleTranslation(new BibleTranslation(bible.TrackingAbbreviation));
	}

	public void AddBibleTranslation(BibleTranslation? translation)
	{
		if (translation != null)
		{
			translation.PropertyChanged += TranslationChanged;
			base.Collection.Add(translation);
		}
	}

	public void RemoveBibleTranslation(string abbreviation, string? nextAbbreviation)
	{
		if (abbreviation.Equals(PrimaryTranslation?.Abbreviation, StringComparison.OrdinalIgnoreCase))
		{
			BibleTranslation bibleTranslation = base.Collection.FirstOrDefault();
			if (PrimaryTranslation != null)
			{
				if (bibleTranslation != null)
				{
					PrimaryTranslation.Abbreviation = bibleTranslation.Abbreviation;
					OnRemoveTranslation(bibleTranslation);
				}
				else
				{
					PrimaryTranslation.Abbreviation = nextAbbreviation;
				}
			}
		}
		else
		{
			BibleTranslation bibleTranslation2 = base.Collection.FirstOrDefault((BibleTranslation t) => t.Abbreviation?.Equals(abbreviation, StringComparison.OrdinalIgnoreCase) ?? false);
			if (bibleTranslation2 != null)
			{
				OnRemoveTranslation(bibleTranslation2);
			}
		}
	}

	public void RemoveBibleTranslation(BibleTranslation translation)
	{
		OnRemoveTranslation(translation);
	}

	private void OnRemoveTranslation(BibleTranslation translation)
	{
		translation.PropertyChanged -= TranslationChanged;
		base.Collection.Remove(translation);
	}

	public BibleTranslationCollection Clone()
	{
		BibleTranslationCollection obj = new BibleTranslationCollection
		{
			_primaryTranslation = PrimaryTranslation?.Clone()
		};
		obj.Collection.AddRange(base.Collection.CloneItems());
		return obj;
	}

	public IEnumerable<ClosedBezierPath> GetAvailableElements(CustomSlide slide)
	{
		return from e in slide.Elements.OfType<ClosedBezierPath>()
			where All.None((BibleTranslation t) => t.VerseElement == e || t.ReferenceElement == e)
			select e;
	}

	private void PrimaryTranslationChanged(object? sender, PropertyChangedEventArgs e)
	{
		BibleSettings.Settings.PrimaryTranslation = PrimaryTranslation;
		TranslationChanged(sender, e);
	}

	private void TranslationChanged(object? sender, PropertyChangedEventArgs e)
	{
		this.TranslationPropertyChanged?.Invoke(sender, e);
	}

	public override string? ToString()
	{
		return PrimaryTranslation?.ToString() ?? base.ToString();
	}
}
