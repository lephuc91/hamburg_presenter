using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using Pro.Common.Components;
using Pro.Common.Mathematics;
using Pro.Common.MessageService;
using ProPresenter.DO.MultiTracks;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Themes;

namespace ProPresenter.DO.Import;

public class DocumentOptions : NotifyPropertyChangedBase
{
	private CustomPresentation? _workingPresentation;

	private BreakMode _breakMode;

	private string? _customDelimiter;

	private int _linesPerSlide = 1;

	private Vector2<double> _documentSize;

	private TemplateSlide? _template;

	private bool _applyTemplateMediaAction;

	private readonly IPresentationFactory _presentationFactory;

	public CCLIData? CCLIData { get; }

	public MultiTracksLicenseData? MultiTracksInfo { get; }

	public string Name { get; }

	public string PlainText { get; }

	public string Notes { get; }

	public CustomPresentation WorkingPresentation
	{
		get
		{
			EnsureDocumentValid();
			return _workingPresentation;
		}
	}

	public BreakMode BreakMode
	{
		get
		{
			return _breakMode;
		}
		set
		{
			SetValue("BreakMode", ref _breakMode, value, InvalidateDocument);
		}
	}

	public string? CustomDelimiter
	{
		get
		{
			return _customDelimiter;
		}
		set
		{
			SetValue("CustomDelimiter", ref _customDelimiter, value, InvalidateDocument);
		}
	}

	public int LinesPerSlide
	{
		get
		{
			return _linesPerSlide;
		}
		set
		{
			if (LinesPerSlide <= 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			SetValue("LinesPerSlide", ref _linesPerSlide, value, InvalidateDocument);
		}
	}

	public Vector2<double> DocumentSize
	{
		get
		{
			return _documentSize;
		}
		set
		{
			SetValue("DocumentSize", ref _documentSize, value, delegate(Vector2<double> o, Vector2<double> n)
			{
				_workingPresentation?.ChangeSize(n);
			});
		}
	}

	public TemplateSlide? Template
	{
		get
		{
			return _template;
		}
		set
		{
			SetValue<TemplateSlide>("Template", ref _template, value, delegate(TemplateSlide o, TemplateSlide n)
			{
				_workingPresentation?.ApplyTemplateToSlides(n, _applyTemplateMediaAction);
			});
		}
	}

	public bool StrictGroupMatching { get; }

	public Regex? AltHeaderPattern { get; }

	public DocumentOptions(CCLIData ccliData, string name, string plainText, string notes, IMessageService messageService, IPresentationFactory presentationFactory, bool strictGroupMatching = true, Regex? altHeaderPattern = null, MultiTracksLicenseData? multiTracksInfo = null)
	{
		CCLIData = ccliData;
		MultiTracksInfo = multiTracksInfo;
		Name = name;
		PlainText = plainText;
		Notes = notes;
		_presentationFactory = presentationFactory;
		messageService?.SubscribeToMessage<ThemePickerSettingsUpdatedMessage>(HandleSettingsUpdated);
		StrictGroupMatching = strictGroupMatching;
		AltHeaderPattern = altHeaderPattern;
		if (CCLIData == null)
		{
			return;
		}
		CCLIData.PropertyChanged += delegate(object? s, PropertyChangedEventArgs e)
		{
			if (_workingPresentation != null)
			{
				string propertyName = e.PropertyName;
				if (propertyName != null)
				{
					switch (propertyName.Length)
					{
					case 5:
						switch (propertyName[0])
						{
						case 'T':
							if (propertyName == "Title")
							{
								_workingPresentation.CCLIInfo.Title = CCLIData.Title;
							}
							break;
						case 'A':
							if (propertyName == "Album")
							{
								_workingPresentation.CCLIInfo.Album = CCLIData.Album;
							}
							break;
						}
						break;
					case 6:
						switch (propertyName[1])
						{
						case 'r':
							if (propertyName == "Artist")
							{
								_workingPresentation.CCLIInfo.Artist = CCLIData.Artist;
							}
							break;
						case 'u':
							if (propertyName == "Author")
							{
								_workingPresentation.CCLIInfo.Author = CCLIData.Author;
							}
							break;
						}
						break;
					case 9:
						switch (propertyName[0])
						{
						case 'P':
							if (propertyName == "Publisher")
							{
								_workingPresentation.CCLIInfo.Publisher = CCLIData.Publisher;
							}
							break;
						case 'C':
							if (propertyName == "Copyright")
							{
								_workingPresentation.CCLIInfo.Copyright = CCLIData.Copyright;
							}
							break;
						}
						break;
					case 10:
						if (propertyName == "SongNumber")
						{
							_workingPresentation.CCLIInfo.SongNumber = CCLIData.SongNumber;
						}
						break;
					case 7:
						if (propertyName == "Display")
						{
							_workingPresentation.CCLIInfo.Display = CCLIData.Display;
						}
						break;
					case 8:
						break;
					}
				}
			}
		};
	}

	private void HandleSettingsUpdated(IMessage message)
	{
		if (message is ThemePickerSettingsUpdatedMessage themePickerSettingsUpdatedMessage && themePickerSettingsUpdatedMessage.Model.ContextualGroup == ThemePickerGroup.ImportFile)
		{
			_applyTemplateMediaAction = themePickerSettingsUpdatedMessage.Model.MediaActionEnabled;
		}
	}

	public void InvalidateDocument()
	{
		_workingPresentation = null;
		OnPropertyChanged("WorkingPresentation");
	}

	[MemberNotNull("_workingPresentation")]
	private void EnsureDocumentValid()
	{
		if (_workingPresentation == null)
		{
			_workingPresentation = ImportHelper.GeneratePresentation(Name, PlainText, CCLIData, Notes, _template, _breakMode, _customDelimiter, _linesPerSlide, _documentSize, _presentationFactory, StrictGroupMatching, AltHeaderPattern, MultiTracksInfo, _applyTemplateMediaAction);
		}
	}
}
