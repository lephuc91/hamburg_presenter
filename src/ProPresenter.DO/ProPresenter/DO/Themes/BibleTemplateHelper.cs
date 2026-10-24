using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Mathematics;
using Pro.DO.Label;
using Pro.DO.Transitions;
using Pro.Text;
using ProPresenter.DO.Bibles;
using ProPresenter.DO.Cues;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements;

namespace ProPresenter.DO.Themes;

public static class BibleTemplateHelper
{
	public delegate void GenerateSlideProgressDelegate(bool completed, double progress);

	public delegate bool IsGenerateSlideCancelledDelegate();

	private const int MaxSingleSlideTextLength = 5000;

	private const int MinLayoutPassTextLength = 2000;

	private static string[] VerseElementAutoLinkNames { get; } = new string[2] { "Bible Text", "Verse" };

	private static string[] ReferenceElementAutoLinkNames { get; } = new string[1] { "Reference" };

	public static void GenerateSlides(TemplateSlide template, BibleReference startReference, BibleReference endReference, BibleTranslationCollection? translations, IEnumerable<BibleBase> loadedBibles, BibleSlideDisplayOptions displayOptions, Action<SlideCue> completedAction, GenerateSlideProgressDelegate? progressCallback, IsGenerateSlideCancelledDelegate isCancelledCallback, IProPresenterDOFactoryProvider factoryProvider, ITransitionDescriptionCollection transitionDescriptions)
	{
		Dictionary<BibleTranslation, VerseContent[]> dictionary = new Dictionary<BibleTranslation, VerseContent[]>();
		Dictionary<BibleTranslation, VerseContent[][]> groupedContent = new Dictionary<BibleTranslation, VerseContent[][]>();
		if (translations != null)
		{
			foreach (BibleTranslation translation2 in translations.All)
			{
				if (translation2.VerseElement != null || translation2.ReferenceElement != null || translation2 == translations.PrimaryTranslation)
				{
					VerseContent[] array = loadedBibles.FirstOrDefault((BibleBase b) => b.TrackingAbbreviation.Equals(translation2.Abbreviation, StringComparison.OrdinalIgnoreCase))?.GetVerseContentRange(startReference, endReference).ToArray();
					if (array != null && array.Any())
					{
						dictionary.Add(translation2, array);
					}
				}
			}
		}
		if (dictionary.Values.Any((VerseContent[] contentGroup) => contentGroup.Any((VerseContent vc) => vc.Key.Verse.StartNumber != vc.Key.Verse.EndNumber)))
		{
			if (displayOptions.GroupMixedRangeVerses)
			{
				Dictionary<SingleVerseKey, bool> dictionary2 = new Dictionary<SingleVerseKey, bool>();
				foreach (VerseContent item in dictionary.Values.SelectMany((VerseContent[] vc) => vc))
				{
					VerseKey key = item.Key;
					for (int i = key.Verse.StartNumber; i <= key.Verse.EndNumber; i++)
					{
						SingleVerseKey key2 = new SingleVerseKey(key.Book.Index, key.Chapter.Number, i);
						bool value;
						bool flag = dictionary2.TryGetValue(key2, out value);
						value = i == key.Verse.EndNumber;
						if (!value)
						{
							dictionary2[key2] = false;
						}
						else if (!flag)
						{
							dictionary2[key2] = true;
						}
					}
				}
				foreach (KeyValuePair<BibleTranslation, VerseContent[]> item2 in dictionary)
				{
					VerseContent[] value2 = item2.Value;
					List<VerseContent[]> groupContentGroups = new List<VerseContent[]>();
					List<VerseContent> currentGroup = new List<VerseContent>();
					VerseContent[] array2 = value2;
					foreach (VerseContent verseContent in array2)
					{
						currentGroup.Add(verseContent);
						VerseKey key3 = verseContent.Key;
						SingleVerseKey key4 = new SingleVerseKey(key3.Book.Index, key3.Chapter.Number, key3.Verse.EndNumber);
						if (dictionary2[key4])
						{
							closedCurrentGroup();
						}
					}
					closedCurrentGroup();
					groupedContent.Add(item2.Key, groupContentGroups.ToArray());
					void closedCurrentGroup()
					{
						if (currentGroup.Any())
						{
							groupContentGroups.Add(currentGroup.ToArray());
						}
						currentGroup.Clear();
					}
				}
			}
			else
			{
				Dictionary<SingleVerseKey, Dictionary<BibleTranslation, VerseContent>> dictionary3 = new Dictionary<SingleVerseKey, Dictionary<BibleTranslation, VerseContent>>();
				if (translations != null)
				{
					foreach (BibleTranslation item3 in translations.All)
					{
						if (!dictionary.ContainsKey(item3))
						{
							continue;
						}
						VerseContent[] array2 = dictionary[item3];
						foreach (VerseContent verseContent2 in array2)
						{
							VerseKey key5 = verseContent2.Key;
							for (int k = key5.Verse.StartNumber; k <= key5.Verse.EndNumber; k++)
							{
								SingleVerseKey key6 = new SingleVerseKey(key5.Book.Index, key5.Chapter.Number, k);
								if (!dictionary3.TryGetValue(key6, out var value3))
								{
									value3 = new Dictionary<BibleTranslation, VerseContent>();
									dictionary3.Add(key6, value3);
								}
								if (!value3.ContainsKey(item3))
								{
									value3.Add(item3, verseContent2);
								}
							}
						}
					}
				}
				List<SingleVerseKey> list = dictionary3.Keys.ToList();
				Dictionary<BibleTranslation, VerseContent?> currentContent = new Dictionary<BibleTranslation, VerseContent>();
				Dictionary<BibleTranslation, List<VerseContent>> pairedContent = new Dictionary<BibleTranslation, List<VerseContent>>();
				if (translations != null)
				{
					foreach (BibleTranslation item4 in translations.All)
					{
						pairedContent[item4] = new List<VerseContent>();
						currentContent[item4] = null;
					}
				}
				list.Sort();
				foreach (SingleVerseKey item5 in list)
				{
					Dictionary<BibleTranslation, VerseContent> dictionary4 = dictionary3[item5];
					bool flag2 = false;
					if (translations == null)
					{
						continue;
					}
					foreach (BibleTranslation item6 in translations.All)
					{
						if (!dictionary4.TryGetValue(item6, out var value4))
						{
							value4 = null;
						}
						VerseContent verseContent3 = currentContent[item6];
						if (!flag2 && verseContent3 != value4 && (verseContent3 == null || value4 != null))
						{
							flag2 = true;
						}
						currentContent[item6] = value4;
					}
					if (!flag2)
					{
						continue;
					}
					translations.All.ForEach(delegate(BibleTranslation t)
					{
						VerseContent verseContent4 = currentContent[t];
						if (verseContent4 != null)
						{
							pairedContent[t].Add(verseContent4);
						}
					});
				}
				pairedContent.ForEach<KeyValuePair<BibleTranslation, List<VerseContent>>>(delegate(KeyValuePair<BibleTranslation, List<VerseContent>> pc)
				{
					groupedContent.Add(pc.Key, pc.Value.Select((VerseContent v) => new VerseContent[1] { v }).ToArray());
				});
			}
		}
		else
		{
			dictionary.ForEach(delegate(KeyValuePair<BibleTranslation, VerseContent[]> uc)
			{
				groupedContent.Add(uc.Key, uc.Value.Select((VerseContent v) => new VerseContent[1] { v }).ToArray());
			});
		}
		if (translations?.PrimaryTranslation == null || !groupedContent.ContainsKey(translations.PrimaryTranslation))
		{
			return;
		}
		VerseContent[][] array3 = groupedContent[translations.PrimaryTranslation];
		if (!array3.Any())
		{
			return;
		}
		VerseContent[] array4 = array3[^1];
		bool flag3 = displayOptions.ReferenceType != ReferenceType.NoReference;
		bool flag4 = flag3 && displayOptions.ReferenceType != ReferenceType.PassageLast;
		int totalCharacters = 0;
		int processedCharacters = 0;
		foreach (KeyValuePair<BibleTranslation, VerseContent[][]> item7 in groupedContent)
		{
			foreach (VerseContent item8 in item7.Value.SelectMany((VerseContent[] c) => c))
			{
				string text = (displayOptions.DisplayNumbers ? BibleHelper.BuildVerseNumber(item8.Key.Verse) : string.Empty);
				totalCharacters += item8.Content.Text.Length + text.Length;
			}
		}
		if (displayOptions.SplitOnVerse)
		{
			for (int l = 0; l < array3.Length; l++)
			{
				VerseContent[] array5 = array3[l];
				Dictionary<BibleTranslation, List<string>> dictionary5 = new Dictionary<BibleTranslation, List<string>>();
				Dictionary<BibleTranslation, AttributeRange[][]> dictionary6 = new Dictionary<BibleTranslation, AttributeRange[][]>();
				Dictionary<BibleTranslation, string> dictionary7 = new Dictionary<BibleTranslation, string>();
				string label = string.Empty;
				foreach (KeyValuePair<BibleTranslation, VerseContent[][]> item9 in groupedContent)
				{
					BibleTranslation key7 = item9.Key;
					VerseContent[][] value5 = item9.Value;
					VerseContent[] array6 = value5[l];
					if (value5 == null || l >= value5.Length || array6 == null)
					{
						continue;
					}
					if (key7.VerseElement != null)
					{
						List<string> list2 = new List<string>();
						List<Pro.Text.Range> list3 = new List<Pro.Text.Range>();
						VerseContent[] array2 = array6;
						foreach (VerseContent verseContent5 in array2)
						{
							string text2 = (displayOptions.DisplayNumbers ? BibleHelper.BuildVerseNumber(verseContent5.Key.Verse) : string.Empty);
							list2.Add(text2 + verseContent5.Content.Text);
							if (displayOptions.DisplayNumbers)
							{
								list3.Add(new Pro.Text.Range(0, text2.Length));
							}
						}
						if (list2.Count > 0)
						{
							list2[list2.Count - 1] = list2[list2.Count - 1].TrimEnd();
						}
						dictionary5.Add(key7, list2);
						dictionary6.Add(key7, array6.Select((VerseContent vc) => BibleHelper.GetAttributeRanges(new global::_003C_003Ez__ReadOnlySingleElementList<VerseContent>(vc), displayOptions.DisplayNumbers, displayOptions.HighlightText, combine: false)).ToArray());
					}
					if (flag3 && (flag4 || array5 == array4) && (key7.ReferenceElement != null || key7.IncludeReferenceWithVerse))
					{
						string text3 = string.Empty;
						if (displayOptions.ReferenceType == ReferenceType.VerseRefs)
						{
							text3 = BuildReferenceText(array6[0].Key, array6[^1].Key);
						}
						else if (displayOptions.ReferenceType == ReferenceType.PassageEach || displayOptions.ReferenceType == ReferenceType.PassageLast)
						{
							text3 = BuildReferenceText(value5[0][0].Key, value5[^1][^1].Key);
						}
						dictionary7.Add(key7, text3 + buildTranslationText(key7));
					}
					if (key7 == translations.PrimaryTranslation)
					{
						label = BuildReferenceText(array6[0].Key, array6[^1].Key);
					}
				}
				CreateSlides(template, dictionary5, dictionary7, 0, dictionary6, flag4, label, finalSlides: true, completedAction, null, reportProgress, isCancelledCallback, factoryProvider, transitionDescriptions);
				if (isCancelledCallback != null && isCancelledCallback())
				{
					break;
				}
			}
		}
		else
		{
			string combinedContent = string.Empty;
			string text4 = string.Empty;
			int attributeOffset = 0;
			Dictionary<BibleTranslation, AttributeRange[][]> dictionary8 = new Dictionary<BibleTranslation, AttributeRange[][]>();
			Dictionary<BibleTranslation, string> dictionary9 = new Dictionary<BibleTranslation, string>();
			if (translations.PrimaryTranslation.VerseElement != null)
			{
				dictionary8[translations.PrimaryTranslation] = new AttributeRange[1][] { BibleHelper.GetAttributeRanges(array3.SelectMany((VerseContent[] c) => c), displayOptions.DisplayNumbers, displayOptions.HighlightText, combine: true) };
			}
			if (flag3 && (translations.PrimaryTranslation.ReferenceElement != null || translations.PrimaryTranslation.IncludeReferenceWithVerse))
			{
				dictionary9.Add(translations.PrimaryTranslation, BuildReferenceText(array3[0][0].Key, array3[^1][^1].Key) + buildTranslationText(translations.PrimaryTranslation));
			}
			if (!dictionary9.TryGetValue(translations.PrimaryTranslation, out var value6))
			{
				value6 = string.Empty;
			}
			int m = 0;
			while (m < array3.Length)
			{
				bool flag5 = false;
				Dictionary<BibleTranslation, List<string>> dictionary10 = new Dictionary<BibleTranslation, List<string>>();
				string text5 = combinedContent.TrimStart();
				attributeOffset += combinedContent.Length - text5.Length;
				combinedContent = text5 + text4;
				text4 = string.Empty;
				for (; m < array3.Length; m++)
				{
					flag5 = isCancelledCallback?.Invoke() ?? false;
					if (flag5 || combinedContent.Length > 5000)
					{
						break;
					}
					VerseContent[] array7 = array3[m];
					string text6 = (displayOptions.DisplayNumbers ? BibleHelper.BuildVerseNumber(array7[0].Key.Verse) : string.Empty);
					combinedContent = combinedContent + text6 + string.Join(null, array7.Select((VerseContent v) => v.Content.Text));
				}
				string text7 = combinedContent.TrimEnd();
				text4 = combinedContent.Substring(text7.Length);
				combinedContent = text7;
				if (flag5)
				{
					break;
				}
				if (translations.PrimaryTranslation.VerseElement != null)
				{
					BibleTranslation primaryTranslation = translations.PrimaryTranslation;
					int j = 1;
					List<string> list4 = new List<string>(j);
					CollectionsMarshal.SetCount(list4, j);
					Span<string> span = CollectionsMarshal.AsSpan(list4);
					int index = 0;
					span[index] = combinedContent;
					dictionary10[primaryTranslation] = list4;
				}
				bool hasMoreContent = m < array3.Length;
				CreateSlides(template, dictionary10, dictionary9, attributeOffset, dictionary8, flag4, value6, !hasMoreContent, completedAction, haltGeneration, reportProgress, isCancelledCallback, factoryProvider, transitionDescriptions);
				bool haltGeneration(int processedCount)
				{
					attributeOffset += processedCount;
					combinedContent = combinedContent.Substring(Math.Min(combinedContent.Length, processedCount));
					if (combinedContent.Length < 2000 && hasMoreContent)
					{
						return true;
					}
					return false;
				}
			}
		}
		progressCallback?.Invoke(completed: true, 1.0);
		string buildTranslationText(BibleTranslation translation)
		{
			if (!displayOptions.ShowTranslation || displayOptions.ReferenceType == ReferenceType.NoReference)
			{
				return string.Empty;
			}
			return " (" + loadedBibles.First((BibleBase b) => b.TrackingAbbreviation == translation.Abbreviation).DisplayAbbreviation + ")";
		}
		void reportProgress(int consumedCharacters)
		{
			processedCharacters += consumedCharacters;
			progressCallback?.Invoke(completed: false, ((double)processedCharacters / Math.Max(1.0, totalCharacters)).Clamp(0.0, 1.0));
		}
	}

	private static void CreateSlides(TemplateSlide template, Dictionary<BibleTranslation, List<string>> textContent, Dictionary<BibleTranslation, string> referenceContent, int initialAttributeOffset, Dictionary<BibleTranslation, AttributeRange[][]> attributeRanges, bool displayReferenceOnAllSlides, string label, bool finalSlides, Action<SlideCue> completedAction, Func<int, bool>? haltGenerationCallback, Action<int> progressCallback, IsGenerateSlideCancelledDelegate? isCancelledCallback, IProPresenterDOFactoryProvider factoryProvider, ITransitionDescriptionCollection transitionDescriptions)
	{
		if (template == null)
		{
			return;
		}
		bool haltGeneration = false;
		bool breakOnOverflow = textContent.Count <= 1 && referenceContent.Count <= 1;
		bool onBreakAddReferenceToContent = displayReferenceOnAllSlides && breakOnOverflow && (referenceContent.FirstOrDefault().Key?.IncludeReferenceWithVerse ?? false);
		CustomSlide currentSlide = null;
		Dictionary<SlideElementBase, RunSettings?> lastOriginalRunSettings = new Dictionary<SlideElementBase, RunSettings>();
		startSlide();
		foreach (KeyValuePair<BibleTranslation, List<string>> item in textContent)
		{
			if (haltGeneration)
			{
				break;
			}
			if (item.Key.VerseElement == null)
			{
				continue;
			}
			ClosedBezierPath closedBezierPath = FindElement(currentSlide, item.Key.VerseElement);
			if (closedBezierPath == null)
			{
				continue;
			}
			int num = -initialAttributeOffset;
			for (int i = 0; i < item.Value.Count; i++)
			{
				string text = item.Value[i];
				AppendText(closedBezierPath.Text, text);
				if (item.Key.VerseElement != null)
				{
					lastOriginalRunSettings[item.Key.VerseElement] = closedBezierPath.Text.GetActiveRunSettings(closedBezierPath.Text.LastCharacterIndex)?.Clone();
				}
				if (attributeRanges.TryGetValue(item.Key, out AttributeRange[][] value))
				{
					AttributeRange[] array = value[i];
					foreach (AttributeRange attributeRange in array)
					{
						switch (attributeRange.Type)
						{
						case AttributeType.WordsOfJesus:
							iterateRuns(closedBezierPath.Text, attributeRange.Range, num, delegate(RunBase r)
							{
								r.Settings.Fill = new SolidTextFill(Colors.Red);
								r.Settings.PreserveFillColor = true;
							});
							break;
						case AttributeType.SmallCaps:
							iterateRuns(closedBezierPath.Text, attributeRange.Range, num, delegate(RunBase r)
							{
								r.Settings.CapitalizationType = CapitalizationType.AllCaps;
							});
							break;
						case AttributeType.Superscript:
							iterateRuns(closedBezierPath.Text, attributeRange.Range, num, delegate(RunBase r)
							{
								r.Settings.ScriptLevel = 1;
							});
							break;
						}
					}
				}
				num += text.Length;
				int arg = closedBezierPath.Text.TrimLeft();
				haltGeneration = haltGenerationCallback?.Invoke(arg) ?? false;
				if (breakOnOverflow && breakSlide(closedBezierPath, out var consumedLength2))
				{
					progressCallback?.Invoke(consumedLength2);
					num += consumedLength2;
				}
				else
				{
					progressCallback?.Invoke(text.Length);
					haltGeneration = haltGenerationCallback?.Invoke(text.Length) ?? false;
					if (haltGeneration)
					{
						finishSlide(currentSlide, lastSlide: false);
					}
				}
				if (haltGeneration)
				{
					break;
				}
			}
		}
		if (!haltGeneration && finalSlides)
		{
			finishSlide(currentSlide, lastSlide: true);
		}
		ArrangedText arrangeElement(ClosedBezierPath element, bool stopWithPadding)
		{
			ArrangedText arrangedText2 = new ArrangedText(SharedTypefaceLibrary.Library)
			{
				OverflowMode = ((!stopWithPadding) ? OverflowMode.Stop : OverflowMode.StopWithSingleLinePadding),
				Document = element.Text,
				MaxSize = element.Size
			};
			if ((object)element.Text != null && element.Text.Settings.ScaleMode == ScaleMode.AdjustContainerHeight && currentSlide != null)
			{
				arrangedText2.MaxSize = new Vector2<double>(arrangedText2.MaxSize.X, currentSlide.Size.Y);
			}
			return arrangedText2;
		}
		bool breakSlide(ClosedBezierPath element, out int consumedLength)
		{
			consumedLength = 0;
			bool result = false;
			using ArrangedText arrangedText = arrangeElement(element, onBreakAddReferenceToContent);
			while (arrangedText.DidOverflow && arrangedText.OverflowBreakIndex >= 0)
			{
				int num2 = 0;
				result = true;
				CustomSlide slide2 = currentSlide;
				startSlide();
				CustomSlide customSlide = currentSlide;
				ClosedBezierPath closedBezierPath2 = FindElement(customSlide, element);
				if (closedBezierPath2 != null)
				{
					closedBezierPath2.Text = element.Text.SplitDocument(arrangedText.OverflowBreakIndex);
					num2 += closedBezierPath2.Text.TrimLeft();
				}
				num2 += element.Text.LastCharacterIndex;
				haltGeneration = haltGenerationCallback?.Invoke(num2) ?? false;
				element.Text.TrimRight();
				finishSlide(slide2, lastSlide: false);
				consumedLength += num2;
				if (haltGeneration)
				{
					break;
				}
				IsGenerateSlideCancelledDelegate? isGenerateSlideCancelledDelegate = isCancelledCallback;
				if (isGenerateSlideCancelledDelegate != null && isGenerateSlideCancelledDelegate())
				{
					break;
				}
				if (currentSlide != customSlide)
				{
					closedBezierPath2 = FindElement(currentSlide, element);
				}
				if (closedBezierPath2 != null)
				{
					element = closedBezierPath2;
				}
				arrangedText.Document = element.Text;
			}
			return result;
		}
		void finishSlide(CustomSlide? slide, bool lastSlide)
		{
			if (displayReferenceOnAllSlides || lastSlide)
			{
				foreach (KeyValuePair<BibleTranslation, string> item2 in referenceContent)
				{
					if (!item2.Key.IncludeReferenceWithVerse || item2.Key.VerseElement == null)
					{
						if (item2.Key.ReferenceElement != null)
						{
							ClosedBezierPath closedBezierPath3 = FindElement(slide, item2.Key.ReferenceElement);
							if (closedBezierPath3 != null)
							{
								AppendText(closedBezierPath3.Text, item2.Value);
							}
						}
					}
					else
					{
						ClosedBezierPath closedBezierPath4 = FindElement(slide, item2.Key.VerseElement, reset: false);
						if (closedBezierPath4 != null)
						{
							closedBezierPath4.Text.TrimRight();
							AppendText(closedBezierPath4.Text, "\n" + item2.Value, (item2.Key.VerseElement != null && lastOriginalRunSettings.TryGetValue(item2.Key.VerseElement, out RunSettings value2)) ? value2 : null);
							closedBezierPath4.Text.Last().Settings.Alignment = ParagraphAlignment.Right;
							if (breakOnOverflow && (!onBreakAddReferenceToContent || lastSlide))
							{
								ArrangedText arrangedText3 = arrangeElement(closedBezierPath4, stopWithPadding: false);
								if (arrangedText3.DidOverflow && arrangedText3.LineCount > 2)
								{
									CustomSlide completedSlide2 = slide;
									startSlide();
									CustomSlide customSlide2 = currentSlide;
									ClosedBezierPath closedBezierPath5 = FindElement(customSlide2, closedBezierPath4);
									if (closedBezierPath5 != null)
									{
										closedBezierPath5.Text = closedBezierPath4.Text.SplitDocument(arrangedText3.GetLastIndexOfLine(arrangedText3.LineCount - 3));
										closedBezierPath5.Text.TrimLeft();
									}
									closedBezierPath4.Text.TrimRight();
									addSlide(completedSlide2);
									slide = customSlide2;
								}
							}
						}
					}
				}
			}
			addSlide(slide);
			void addSlide(CustomSlide? completedSlide)
			{
				if (completedSlide != null && (lastSlide || !string.IsNullOrWhiteSpace(completedSlide.Text?.AllText)))
				{
					SlideCue slideCue = new SlideCue(factoryProvider, completedSlide, transitionDescriptions);
					if (!string.IsNullOrEmpty(label) && slideCue.SlideAction != null)
					{
						slideCue.SlideAction.Label = new ActionLabel(label);
					}
					completedAction(slideCue);
				}
			}
		}
		static void iterateRuns(TextDocument doc, Pro.Text.Range range, int offset, Action<RunBase> iterator)
		{
			doc.IterateRuns(new Pro.Text.Range(range.Start + offset, range.End + offset), splitRuns: true, iterator);
		}
		void startSlide()
		{
			currentSlide = new CustomSlide(factoryProvider, transitionDescriptions);
			currentSlide.ChangeSize(template.Slide.Size);
			currentSlide.ApplyTemplate(template, TemplateOptions.RetainTemplateIDs);
		}
	}

	public static ClosedBezierPath? FindElement(CustomSlide? slide, Guid elementId, string elementName, bool reset = true)
	{
		IEnumerable<ClosedBezierPath> enumerable = slide?.Elements.OfType<ClosedBezierPath>();
		ClosedBezierPath closedBezierPath = enumerable?.FirstOrDefault((ClosedBezierPath e) => e.ID == elementId) ?? enumerable?.FirstOrDefault((ClosedBezierPath e) => e.Name == elementName);
		if (reset)
		{
			ResetText(closedBezierPath);
		}
		return closedBezierPath;
	}

	public static ClosedBezierPath? FindElement(CustomSlide? slide, SlideElementBase? originalElement, bool reset = true)
	{
		return FindElement(slide?.Elements.OfType<ClosedBezierPath>(), originalElement, reset);
	}

	public static ClosedBezierPath? FindElement(IEnumerable<ClosedBezierPath>? elements, SlideElementBase? originalElement, bool reset = true, bool autoLinkVerse = false, bool autoLinkReference = false)
	{
		return finalizeElement(findByID() ?? findByMatchingName() ?? findByAutoLinkName() ?? findByAutoLinkText() ?? findClosestElement());
		ClosedBezierPath? finalizeElement(ClosedBezierPath? element)
		{
			if (reset)
			{
				ResetText(element);
			}
			return element;
		}
		ClosedBezierPath? findByAutoLinkName()
		{
			return elements?.FirstOrDefault((ClosedBezierPath e) => getAutoLinkNames().Contains<string>(e.Name, StringComparer.OrdinalIgnoreCase));
		}
		ClosedBezierPath? findByAutoLinkText()
		{
			return elements?.FirstOrDefault((ClosedBezierPath e) => getAutoLinkNames().Any((string n) => e.Text?.AllText.Contains(n, StringComparison.OrdinalIgnoreCase) ?? false));
		}
		ClosedBezierPath? findByID()
		{
			if (originalElement != null)
			{
				return elements?.FirstOrDefault((ClosedBezierPath e) => e.ID == originalElement.ID);
			}
			return null;
		}
		ClosedBezierPath? findByMatchingName()
		{
			if (originalElement != null)
			{
				return elements?.FirstOrDefault((ClosedBezierPath e) => e.Name == originalElement.Name);
			}
			return null;
		}
		ClosedBezierPath? findClosestElement()
		{
			if (originalElement != null)
			{
				return TemplateHelper.FindBestMatch(originalElement, elements) as ClosedBezierPath;
			}
			return null;
		}
		string[] getAutoLinkNames()
		{
			if (!autoLinkVerse)
			{
				if (!autoLinkReference)
				{
					return Array.Empty<string>();
				}
				return ReferenceElementAutoLinkNames;
			}
			return VerseElementAutoLinkNames;
		}
	}

	private static void ResetText(ClosedBezierPath? element)
	{
		element?.Text?.Clear();
	}

	private static void AppendText(TextDocument document, string text, RunSettings? settings = null)
	{
		document.InsertTextAndParagraphs(document.LastCharacterIndex, text, settings?.Clone());
	}

	public static string BuildReferenceText(VerseKey start, VerseKey end)
	{
		string text = $"{start.Book.Name} {start.Chapter.Number}:{start.Verse.StartNumber}";
		string text2 = $"-{end.Chapter.Number}";
		if (start.Chapter != end.Chapter)
		{
			return text + text2 + $":{end.Verse.EndNumber}";
		}
		if (start.Verse.StartNumber != end.Verse.StartNumber)
		{
			return text + $"-{end.Verse.EndNumber}";
		}
		return text;
	}
}
