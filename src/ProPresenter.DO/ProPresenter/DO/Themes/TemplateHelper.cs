using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.Common.FeatureFlag;
using Pro.Common.Logging;
using Pro.Common.Mathematics;
using Pro.DO.Storage;
using Pro.DO.Transitions;
using Pro.Editor.Canvas;
using Pro.Editor.Canvas.Snapping.Lines;
using Pro.Localization;
using Pro.Text;
using Pro.UI.DialogService;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Media;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Slide.Builds;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Custom.Elements.Fills;
using ProPresenter.DO.Slide.Custom.Elements.Shapes;
using ProPresenter.DO.Slide.Links;

namespace ProPresenter.DO.Themes;

public static class TemplateHelper
{
	private static Vector2<double> DefaultSlideSize = new Vector2<double>(1920.0, 1080.0);

	private const int GuidStringLength = 36;

	public static void ApplyTemplate(this CustomSlide slide, TemplateSlide template, TemplateOptions options = TemplateOptions.None)
	{
		if (template != null)
		{
			slide.UndoStack?.BeginCommit(UndoActionTypes.ApplyTemplate.ToAction());
			MapSlideElements(template, slide, options);
			AssignTemplateProperties(template, slide);
			slide.UndoStack?.EndCommit(null, null, autoFinalize: true);
		}
	}

	public static void ApplyTemplate(this SlideCue slideCue, TemplateSlide template, TemplateOptions options = TemplateOptions.None, bool applyMediaAction = true)
	{
		if (template != null && slideCue?.SlideAction?.Slide is CustomSlide slide)
		{
			slide.ApplyTemplate(template, options);
			if (applyMediaAction)
			{
				slideCue.ApplyTemplateMediaAction(template);
			}
		}
	}

	public static void ApplyTemplateMediaAction(this SlideCue slideCue, TemplateSlide? template)
	{
		if (template?.MediaAction == null || slideCue == null)
		{
			return;
		}
		MediaAction mediaAction = template.MediaAction;
		MediaAction[] array = (from c in slideCue.Actions.OfType<MediaAction>()
			where c.IsGraphicMedia
			select c).ToArray();
		if (!array.Any((MediaAction a) => a.TriggerLayer == TriggerLayer.Foreground))
		{
			if (array.Where((MediaAction a) => a.TriggerLayer == TriggerLayer.Background).Any())
			{
				slideCue.RemoveActions(array);
			}
			MediaAction mediaAction2 = mediaAction.Clone() as MediaAction;
			if (template.CopyMediaAssetFilesOnApply && mediaAction2?.Media is FileMediaBase fileMediaBase)
			{
				string targetFile = Path.Combine(CommonPaths.MediaAssets, fileMediaBase.SourceFile.Filename ?? string.Empty);
				CopyTemplateMediaAsset(fileMediaBase, targetFile);
			}
			if (mediaAction2 != null)
			{
				slideCue.AddAction(mediaAction2);
			}
		}
	}

	private static void AssignTemplateProperties(TemplateSlide template, CustomSlide slide)
	{
		if (template != null)
		{
			slide.UseBackgroundColor = template.Slide.UseBackgroundColor;
			slide.ChangeSlideBackgroundColor(slide.BackgroundColor, template.Slide.BackgroundColor);
			slide.StaticGuides.RemoveStaticSLs(slide.StaticGuides.Where((StaticSL g) => !g.IsEditable).ToArray());
			slide.StaticGuides.AddStaticSLs(template.Slide.StaticGuides.Collect(delegate(StaticSL g)
			{
				StaticSL staticSL = g.Clone();
				staticSL.Scale(template.Slide.Size, slide.Size);
				staticSL.IsEditable = false;
				return staticSL;
			}));
		}
	}

	public static void AssignTemplateToSelectedPresentation(TemplateSlide template, CustomPresentation[] presentations, bool applyMediaAction)
	{
		if (presentations.Length == 1)
		{
			presentations[0].ApplyTemplateToSlides(template, applyMediaAction);
		}
		else if (MessageDialogService.ShowSimpleContent(string.Empty, LocalizedStrings.Get("THEMES_ALERT_APPLY_TO_ALL_PRESENTATIONS_message")))
		{
			for (int i = 0; i < presentations.Length; i++)
			{
				presentations[i].ApplyTemplateToSlides(template, applyMediaAction);
			}
		}
	}

	internal static T? FindBestMatch<T>(T element, IEnumerable<T>? elements) where T : SlideElementBase
	{
		double targetArea = area(element);
		if (elements == null)
		{
			return null;
		}
		return (from e in elements
			orderby (area(e) - targetArea).Abs(), e.ZOrder descending
			select e).FirstOrDefault();
		static double area(T e)
		{
			return e.Size.X * e.Size.Y;
		}
	}

	internal static Theme GenerateDefaultTheme(IProPresenterDOFactoryProvider factoryProvider, ITransitionDescriptionCollection transitionDescriptions, IFlagService flagService)
	{
		CustomSlide customSlide = new CustomSlide(factoryProvider, transitionDescriptions);
		customSlide.ChangeSize(DefaultSlideSize);
		TemplateSlide slide = new TemplateSlide(factoryProvider, customSlide, flagService, addDefaultShape: true)
		{
			Name = LocalizedStrings.Get("THEMES_SLIDE_DEFAULT_NAME_name")
		};
		return new Theme(factoryProvider, transitionDescriptions, flagService) { slide };
	}

	internal static Theme GenerateDefaultBibleTheme(IProPresenterDOFactoryProvider factoryProvider, ITransitionDescriptionCollection transitionDescriptions, IFlagService flagService)
	{
		Theme theme = new Theme(factoryProvider, transitionDescriptions, flagService);
		CustomSlide customSlide = new CustomSlide(factoryProvider, transitionDescriptions);
		customSlide.ChangeSize(DefaultSlideSize);
		TextShape element = new TextShape(factoryProvider, "")
		{
			Name = "Verse",
			Position = new Vector2<double>(86.0, 703.0),
			Size = new Vector2<double>(1666.0, 205.0)
		};
		TextShape element2 = new TextShape(factoryProvider, "")
		{
			Name = "Reference",
			Position = new Vector2<double>(966.0, 931.0),
			Size = new Vector2<double>(782.0, 70.0)
		};
		customSlide.AddElement(element, userInitiated: false, repositionElement: false);
		customSlide.AddElement(element2, userInitiated: false, repositionElement: false);
		TemplateSlide slide = new TemplateSlide(factoryProvider, customSlide, flagService)
		{
			Name = LocalizedStrings.Get("GLOBAL_DEFAULT")
		};
		theme.Add(slide);
		return theme;
	}

	private static void MapSlideElements(TemplateSlide template, CustomSlide slide, TemplateOptions options)
	{
		Dictionary<SlideElementBase, SlideElementBase> clonedTemplateElements = template.Slide.Elements.ToDictionary((SlideElementBase e) => e, (SlideElementBase e) => PrepareTemplateElement(e, template, slide, options));
		Dictionary<SlideElementBase, SlideElementBase> templateMatchMap = new Dictionary<SlideElementBase, SlideElementBase>();
		List<SlideElementBase> shapesToAdd = new List<SlideElementBase>();
		bool slideHasBuilds = slide.Builds.Any();
		Guid?[] buildOrder = slide.Builds.Select((IBuild b) => b?.ID).Concat(template.Slide.Builds.Select(getTemplateBuildID)).ToArray();
		List<ClosedBezierPath> templateTextElements = clonedTemplateElements.Values.OfType<ClosedBezierPath>().Where(delegate(ClosedBezierPath e)
		{
			TextLink textLink = e.TextLink;
			return (textLink == null || !textLink.IsEnabled) && isTextElement(e);
		}).ToList();
		slide.RemoveElements(slide.Elements.Where(delegate(SlideElementBase e)
		{
			if (e.IsFromTemplate)
			{
				if (isTextElement(e))
				{
					ClosedBezierPath obj = e as ClosedBezierPath;
					if (obj == null)
					{
						return false;
					}
					return obj.TextLink?.IsEnabled == true;
				}
				return true;
			}
			return false;
		}).ToArray(), updateDataLinks: false);
		List<ClosedBezierPath> slideTextElements = slide.Elements.OfType<ClosedBezierPath>().Where(isTextElement).ToList();
		mapElementsByName();
		mapElementsByBestMatch();
		if (!options.HasFlag(TemplateOptions.RetainTemplateText))
		{
			clonedTemplateElements.Values.Except(shapesToAdd).OfType<ClosedBezierPath>().ForEach(delegate(ClosedBezierPath e)
			{
				e.Text?.Clear();
			});
		}
		if (options.HasFlag(TemplateOptions.RefreshAllSlideIDs))
		{
			refreshSlideIDs();
		}
		addElementsToSlide();
		slide.Elements.ForEach(delegate(SlideElementBase element)
		{
			element.UpdateElementLinks((Guid id) => templateMatchMap.Keys.Select((SlideElementBase k) => k.ID).Contains(id) || clonedTemplateElements.Keys.Select((SlideElementBase k) => k.ID).Contains(id), (Guid id) => templateMatchMap.FirstOrDefault<KeyValuePair<SlideElementBase, SlideElementBase>>((KeyValuePair<SlideElementBase, SlideElementBase> kv) => kv.Key.ID == id).Value ?? clonedTemplateElements.FirstOrDefault<KeyValuePair<SlideElementBase, SlideElementBase>>((KeyValuePair<SlideElementBase, SlideElementBase> kv) => kv.Key.ID == id).Value);
		});
		slide.Builds.Reset(buildOrder.NotNull(), slide.Elements);
		void addElementsToSlide()
		{
			SlideElementBase[] selectedElements = slide.Elements.ToArray();
			slide.AddElements(shapesToAdd.Union(clonedTemplateElements.Values), userInitiated: true, repositionElements: false, resetZIndex: false, addMediaReferences: true);
			ElementOrdonnance.ChangeElementZOrder(slide.Elements, selectedElements, ZOrderDirection.Back);
			ElementOrdonnance.ChangeElementZOrder(slide.Elements, clonedTemplateElements.Values.Where(notTextElement), ZOrderDirection.Back);
			ElementOrdonnance.ChangeElementZOrder(slide.Elements, shapesToAdd.Union(templateTextElements), ZOrderDirection.Front);
			ElementOrdonnance.ChangeElementZOrder(slide.Elements, slide.Elements, 0);
		}
		Guid? getTemplateBuildID(IBuild build)
		{
			SlideElementBase slideElementBase = clonedTemplateElements[build.Element];
			if (build is Build build2)
			{
				return (build2.IsBuildIn ? slideElementBase.BuildIn : slideElementBase.BuildOut)?.ID;
			}
			ChildBuild childBuild = build as ChildBuild;
			if (childBuild == null)
			{
				throw new NotSupportedException();
			}
			return (slideElementBase as ClosedBezierPath)?.ChildBuilds.FirstOrDefault((ChildBuild b) => b.Index == childBuild.Index)?.ID ?? Guid.Empty;
		}
		static bool isTextElement(SlideElementBase element)
		{
			if (!element.AdditionalInfo.HasFlag(AdditionalInfo.Text))
			{
				if (element is ClosedBezierPath closedBezierPath)
				{
					return closedBezierPath.Text?.HasText ?? false;
				}
				return false;
			}
			return true;
		}
		void mapElement(ClosedBezierPath slideElement, ClosedBezierPath templateElement)
		{
			slide.RemoveElement(slideElement, updateDataLinks: false);
			templateTextElements.Remove(templateElement);
			slideTextElements.Remove(slideElement);
			templateElement.FinalizeName();
			TextDocument textDocument = slideElement.Text?.Clone();
			if (textDocument != null)
			{
				templateElement.Text?.ApplyAttributes(textDocument);
				templateElement.Text = textDocument;
			}
			if (options.HasFlag(TemplateOptions.MaintainOriginalSlideBuild) && slideHasBuilds)
			{
				slideElement.CopyBuildProperties(templateElement);
			}
			shapesToAdd.Add(templateElement);
			templateMatchMap.Add(slideElement, templateElement);
			for (int i = 0; i < buildOrder.Count(); i++)
			{
				Guid? guid = slideElement.BuildIn?.ID;
				Guid? guid2 = buildOrder[i];
				if (guid.HasValue == guid2.HasValue && (!guid.HasValue || guid.GetValueOrDefault() == guid2.GetValueOrDefault()) && templateElement.BuildIn != null)
				{
					buildOrder[i] = templateElement.BuildIn.ID;
				}
				else
				{
					guid2 = slideElement.BuildOut?.ID;
					guid = buildOrder[i];
					if (guid2.HasValue == guid.HasValue && (!guid2.HasValue || guid2.GetValueOrDefault() == guid.GetValueOrDefault()) && templateElement.BuildOut != null)
					{
						buildOrder[i] = templateElement.BuildOut.ID;
					}
				}
			}
		}
		void mapElementsByBestMatch()
		{
			foreach (ClosedBezierPath item in slideTextElements.ToList())
			{
				ClosedBezierPath closedBezierPath3 = FindBestMatch(item, templateTextElements);
				if (closedBezierPath3 != null)
				{
					mapElement(item, closedBezierPath3);
				}
			}
		}
		void mapElementsByName()
		{
			foreach (ClosedBezierPath slideElement2 in slideTextElements.ToList())
			{
				ClosedBezierPath closedBezierPath2 = templateTextElements.FirstOrDefault((ClosedBezierPath t) => t.Name == slideElement2.Name);
				if (closedBezierPath2 != null)
				{
					mapElement(slideElement2, closedBezierPath2);
				}
			}
		}
		static bool notTextElement(SlideElementBase element)
		{
			if (element is ClosedBezierPath)
			{
				return !isTextElement(element);
			}
			return true;
		}
		void refreshSlideIDs()
		{
			SlideElementBase[] array = slide.Elements.ToArray();
			foreach (SlideElementBase slideElementBase2 in array)
			{
				SlideElementBase slideElementBase3 = slideElementBase2.Clone();
				shapesToAdd.Add(slideElementBase3);
				templateMatchMap.Add(slideElementBase2, slideElementBase3);
				slide.RemoveElement(slideElementBase2);
			}
		}
	}

	private static SlideElementBase PrepareTemplateElement(SlideElementBase element, TemplateSlide template, CustomSlide slide, TemplateOptions options)
	{
		SlideElementBase obj = (options.HasFlag(TemplateOptions.RetainTemplateIDs) ? element.CloneWithID() : element.Clone());
		obj.IsFromTemplate = true;
		obj.ZOrder = element.ZOrder;
		MediaFill mediaFill = (obj as ClosedBezierPath)?.Fill as MediaFill;
		if (template.CopyMediaAssetFilesOnApply && mediaFill?.Media != null)
		{
			CopyTemplateMediaAsset(mediaFill.Media, template.Slide.ID);
		}
		obj.Scale(slide.Size.ComponentwiseQuotient(template.Slide.Size));
		return obj;
	}

	private static void CopyTemplateMediaAsset(FileMediaBase media, Guid templateID)
	{
		string targetFile = Path.Combine(CommonPaths.MediaAssets, templateID.ToString() + media.SourceFile.Filename);
		CopyTemplateMediaAsset(media, targetFile);
	}

	private static void CopyTemplateMediaAsset(MediaBase? media, string targetFile)
	{
		if (!(media is FileMediaBase fileMediaBase))
		{
			return;
		}
		if (!File.Exists(targetFile) && fileMediaBase.SourceFile.IsValid)
		{
			try
			{
				File.Copy(fileMediaBase.SourceFile.FullPath ?? string.Empty, targetFile, overwrite: true);
			}
			catch (Exception exception)
			{
				Log.Error("Unable to copy file " + fileMediaBase.SourceFile.FullPath + " to " + targetFile);
				Log.Error(exception);
			}
		}
		fileMediaBase.UpdateSource(userInitiated: true, new RelativePath(targetFile), didFileChange: false);
	}

	public static void ApplyAttributes(this TextDocument source, TextDocument target)
	{
		if ((object)source != null && (object)target != null)
		{
			TextDocumentAttributes defaultAttributes = target.Attributes.Clone();
			target.AssignSettings(source.Settings, source.Attributes);
			target.IterateParagraphs(Pro.Text.Range.All, delegate(Paragraph p)
			{
				p.AssignTemplateSettings(defaultAttributes.ParagraphSettings, source.Attributes.ParagraphSettings);
			});
			target.IterateRuns(Pro.Text.Range.All, splitRuns: true, delegate(RunBase r)
			{
				r.AssignTemplateSettings(defaultAttributes.RunSettings, source.Attributes.RunSettings);
			});
		}
	}
}
