using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.Common.Mathematics;
using Pro.Editor.Canvas.Controls;
using Pro.Text;
using Pro.UI.Commands;
using Pro.UI.Components;
using Pro.UI.Controls;
using Pro.UI.DependencyInjection;
using Pro.UI.InputActions;
using Pro.UI.Utility;
using ProPresenter.DO;
using ProPresenter.DO.InputActionMap;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Custom.Elements.Shapes;
using ProPresenter.UI.SlideEditor.Inspectors;
using ProPresenter.UI.SlideEditor.TabStops;
using ProPresenter.UI.ViewModels.Editor;

namespace ProPresenter.UI.SlideEditor;

public partial class SlideEditorView : UserControl, IComponentConnector
{
	private const double SlideNotesCollapseThreshold = 20.0;

	private const double SlideNotesMinHeight = 200.0;

	private TextBox? _zoomInputTextBox;

	private Vector2<double> _mousePos;

	private IInputActions _inputActions;

	private static readonly DependencyProperty DefaultSlideNoteRunSettingsProperty = DependencyProperty.Register("DefaultSlideNoteRunSettings", typeof(RunSettings), typeof(SlideEditorView));

	private RunSettings? DefaultSlideNoteRunSettings
	{
		get
		{
			return (RunSettings)((DependencyObject)this).GetValue(DefaultSlideNoteRunSettingsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DefaultSlideNoteRunSettingsProperty, (object)value);
		}
	}

	private TextBox? ZoomInputTextBox
	{
		get
		{
			if (_zoomInputTextBox == null)
			{
				_zoomInputTextBox = ((DependencyObject)(object)CustomZoomFactorInput).FindVisualChild<TextBox>();
			}
			return _zoomInputTextBox;
		}
	}

	private TextInspector? TextInspector => CommandTargets.FindTarget(SlideEditorVM?.TextInspectorVM.CommandTargetType) as TextInspector;

	private ISlideEditorVM? SlideEditorVM => base.DataContext as ISlideEditorVM;

	public TextTabStopControlCollection NotesTabStops { get; } = new TextTabStopControlCollection();

	public ICommand<(TabStopType, Vector2<double>)> AddNotesTabStopCommand => new RelayCommand<(TabStopType, Vector2<double>)>(OnAddNotesTabStop);

	public event Action? Close;

	private void OnAddNotesTabStop((TabStopType, Vector2<double>) param)
	{
		throw new NotImplementedException();
	}

	public SlideEditorView()
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		_inputActions = UIServiceProvider.GetService<IInputActions>();
		InitializeComponent();
		base.DataContextChanged += new DependencyPropertyChangedEventHandler(SlideEditorView_DataContextChanged);
		base.IsVisibleChanged += new DependencyPropertyChangedEventHandler(SlideEditorView_IsVisibleChanged);
		NotesTabStops.SetTextBox(SlideNoteTextBox.EditText);
	}

	private void SlideEditorView_DataContextChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		object newValue = ((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		ISlideEditorVM slideEditorVM = newValue as ISlideEditorVM;
		if (slideEditorVM == null)
		{
			return;
		}
		EditorMenuGroup editorMenu = _inputActions.EditorMenu;
		base.CommandBindings.Add(editorMenu.InsertText.BindCommand, delegate(AddElementCommandParameters? p)
		{
			slideEditorVM.AddShapeCommand?.Execute(p ?? new AddElementCommandParameters
			{
				NewShape = ShapeType.Text
			});
		}, canAddShape, canContinueRouting);
		base.CommandBindings.Add(editorMenu.InsertShapeRectangle.BindCommand, delegate(AddElementCommandParameters? p)
		{
			slideEditorVM.AddShapeCommand?.Execute(p ?? new AddElementCommandParameters
			{
				NewShape = ShapeType.Rectangle
			});
		}, canAddShape, canContinueRouting);
		base.CommandBindings.Add(editorMenu.InsertShapeRoundedRectangle.BindCommand, delegate(AddElementCommandParameters? p)
		{
			slideEditorVM.AddShapeCommand?.Execute(p ?? new AddElementCommandParameters
			{
				NewShape = ShapeType.RoundedRectangle
			});
		}, canAddShape, canContinueRouting);
		base.CommandBindings.Add(editorMenu.InsertShapeEllipse.BindCommand, delegate(AddElementCommandParameters? p)
		{
			slideEditorVM.AddShapeCommand?.Execute(p ?? new AddElementCommandParameters
			{
				NewShape = ShapeType.Ellipse
			});
		}, canAddShape, canContinueRouting);
		base.CommandBindings.Add(editorMenu.InsertShapeIsoscelesTriangle.BindCommand, delegate(AddElementCommandParameters? p)
		{
			slideEditorVM.AddShapeCommand?.Execute(p ?? new AddElementCommandParameters
			{
				NewShape = ShapeType.IsoscelesTriangle
			});
		}, canAddShape, canContinueRouting);
		base.CommandBindings.Add(editorMenu.InsertShapeRightTriangle.BindCommand, delegate(AddElementCommandParameters? p)
		{
			slideEditorVM.AddShapeCommand?.Execute(p ?? new AddElementCommandParameters
			{
				NewShape = ShapeType.RightTriangle
			});
		}, canAddShape, canContinueRouting);
		base.CommandBindings.Add(editorMenu.InsertShapeRhombus.BindCommand, delegate(AddElementCommandParameters? p)
		{
			slideEditorVM.AddShapeCommand?.Execute(p ?? new AddElementCommandParameters
			{
				NewShape = ShapeType.Rhombus
			});
		}, canAddShape, canContinueRouting);
		base.CommandBindings.Add(editorMenu.InsertShapePolygon.BindCommand, delegate(AddElementCommandParameters? p)
		{
			slideEditorVM.AddShapeCommand?.Execute(p ?? new AddElementCommandParameters
			{
				NewShape = ShapeType.Polygon
			});
		}, canAddShape, canContinueRouting);
		base.CommandBindings.Add(editorMenu.InsertShapeStar.BindCommand, delegate(AddElementCommandParameters? p)
		{
			slideEditorVM.AddShapeCommand?.Execute(p ?? new AddElementCommandParameters
			{
				NewShape = ShapeType.Star
			});
		}, canAddShape, canContinueRouting);
		base.CommandBindings.Add(editorMenu.InsertShapeDoubleArrow.BindCommand, delegate(AddElementCommandParameters? p)
		{
			slideEditorVM.AddShapeCommand?.Execute(p ?? new AddElementCommandParameters
			{
				NewShape = ShapeType.DoubleArrow
			});
		}, canAddShape, canContinueRouting);
		base.CommandBindings.Add(editorMenu.InsertShapeArrow.BindCommand, delegate(AddElementCommandParameters? p)
		{
			slideEditorVM.AddShapeCommand?.Execute(p ?? new AddElementCommandParameters
			{
				NewShape = ShapeType.RightArrow
			});
		}, canAddShape, canContinueRouting);
		base.CommandBindings.Add(editorMenu.InsertShapeCustom.BindCommand, delegate(InsertEditorObjectSourceType p)
		{
			slideEditorVM.ActivatePenCommand?.Execute(p);
		}, canAddShape, canContinueRouting);
		base.CommandBindings.Add(editorMenu.InsertMedia.BindCommand, delegate(InsertEditorObjectSourceType p)
		{
			slideEditorVM.AddMediaCommand?.Execute(p);
		});
		base.CommandBindings.Add(editorMenu.InsertVideoInput.BindCommand, delegate(InsertEditorObjectSourceType p)
		{
			slideEditorVM.AddLiveVideoElementCommand?.Execute(p);
		});
		base.CommandBindings.Add(editorMenu.InsertWeb.BindCommand, delegate(InsertEditorObjectSourceType p)
		{
			slideEditorVM.AddHTMLElementCommand?.Execute(p);
		});
		base.CommandBindings.Add(editorMenu.InsertCurrentSlideText.BindCommand, delegate(AddElementCommandParameters? p)
		{
			slideEditorVM.AddCurrentStageSlideCommand?.Execute(p);
		});
		base.CommandBindings.Add(editorMenu.InsertCurrentSlideNote.BindCommand, delegate(AddElementCommandParameters? p)
		{
			slideEditorVM.AddCurrentStageSlideCommand?.Execute(p);
		});
		base.CommandBindings.Add(editorMenu.InsertCurrentSlideImage.BindCommand, delegate(AddElementCommandParameters? p)
		{
			slideEditorVM.AddStaticSlideImageCommand?.Execute(p);
		});
		base.CommandBindings.Add(editorMenu.InsertCurrentSlideTextAndChords.BindCommand, delegate(AddElementCommandParameters? p)
		{
			slideEditorVM.AddCurrentStageSlideCommand?.Execute(p);
		});
		base.CommandBindings.Add(editorMenu.InsertNextSlideText.BindCommand, delegate(AddElementCommandParameters? p)
		{
			slideEditorVM.AddNextStageSlideCommand?.Execute(p);
		});
		base.CommandBindings.Add(editorMenu.InsertNextSlideNote.BindCommand, delegate(AddElementCommandParameters? p)
		{
			slideEditorVM.AddNextStageSlideCommand?.Execute(p);
		});
		base.CommandBindings.Add(editorMenu.InsertNextSlideImage.BindCommand, delegate(AddElementCommandParameters? p)
		{
			slideEditorVM.AddStaticSlideImageCommand?.Execute(p);
		});
		base.CommandBindings.Add(editorMenu.InsertNextSlideTextAndChords.BindCommand, delegate(AddElementCommandParameters? p)
		{
			slideEditorVM.AddNextStageSlideCommand?.Execute(p);
		});
		base.CommandBindings.Add(editorMenu.AddScreenPreviewElement.BindCommand, delegate(AddElementCommandParameters? p)
		{
			slideEditorVM.AddScreenPreviewElementCommand?.Execute(p);
		});
		base.CommandBindings.Add(editorMenu.InsertChordChart.BindCommand, delegate(InsertEditorObjectSourceType p)
		{
			slideEditorVM.AddChordChartElementCommand?.Execute(p);
		});
		base.CommandBindings.Add(editorMenu.InsertStageMessage.BindCommand, delegate(InsertEditorObjectSourceType p)
		{
			slideEditorVM.AddMessageCommand?.Execute(p);
		});
		base.CommandBindings.Add(editorMenu.InsertPCSLive.BindCommand, delegate(InsertEditorObjectSourceType p)
		{
			slideEditorVM.AddPCOLiveElementCommand?.Execute(p);
		});
		base.CommandBindings.Add(editorMenu.AddTimerStageItem.BindCommand, delegate(AddElementCommandParameters? p)
		{
			slideEditorVM.AddTimerStageItemCommand?.Execute(p);
		});
		base.CommandBindings.Add(editorMenu.InsertSystemClock.BindCommand, delegate(InsertEditorObjectSourceType p)
		{
			slideEditorVM.AddSystemClockElementCommand?.Execute(p);
		});
		base.CommandBindings.Add(editorMenu.InsertGroupCurrentSlide.BindCommand, delegate(AddElementCommandParameters? p)
		{
			slideEditorVM.AddGroupElementCommand?.Execute(p);
		});
		base.CommandBindings.Add(editorMenu.InsertGroupNextSlide.BindCommand, delegate(AddElementCommandParameters? p)
		{
			slideEditorVM.AddGroupElementCommand?.Execute(p);
		});
		base.CommandBindings.Add(editorMenu.InsertGroupNextArrangement.BindCommand, delegate(AddElementCommandParameters? p)
		{
			slideEditorVM.AddGroupElementCommand?.Execute(p);
		});
		base.CommandBindings.Add(editorMenu.InsertLabelCurrentSlide.BindCommand, delegate(AddElementCommandParameters? p)
		{
			slideEditorVM.AddSlideLabelElementCommand?.Execute(p);
		});
		base.CommandBindings.Add(editorMenu.InsertLabelNextSlide.BindCommand, delegate(AddElementCommandParameters? p)
		{
			slideEditorVM.AddSlideLabelElementCommand?.Execute(p);
		});
		base.CommandBindings.Add(editorMenu.InsertCaptureStatus.BindCommand, delegate(InsertEditorObjectSourceType p)
		{
			slideEditorVM.AddCaptureStatusElementCommand?.Invoke(p);
		});
		base.CommandBindings.Add(editorMenu.InsertImage.BindCommand, delegate(InsertEditorObjectSourceType p)
		{
			slideEditorVM.AddMediaCommand?.Execute(p);
		});
		base.CommandBindings.Add(editorMenu.InsertVideoCountdown.BindCommand, delegate(InsertEditorObjectSourceType p)
		{
			slideEditorVM.AddStageVideoCountDownElementCommand?.Execute(p);
		});
		base.CommandBindings.Add(editorMenu.InsertAudioCountdown.BindCommand, delegate(InsertEditorObjectSourceType p)
		{
			slideEditorVM.AddAudioCountDownElementCommand?.Execute(p);
		});
		base.CommandBindings.Add(editorMenu.InsertTimecode.BindCommand, delegate(InsertEditorObjectSourceType p)
		{
			slideEditorVM.AddTimecodeElementCommand?.Execute(p);
		});
		base.CommandBindings.Add(editorMenu.InsertPlaybackMarkerFirst.BindCommand, delegate(AddElementCommandParameters? p)
		{
			slideEditorVM.AddPlaybackMarkerElementCommand?.Execute(p);
		});
		base.CommandBindings.Add(editorMenu.InsertPlaybackMarkerPrevious.BindCommand, delegate(AddElementCommandParameters? p)
		{
			slideEditorVM.AddPlaybackMarkerElementCommand?.Execute(p);
		});
		base.CommandBindings.Add(editorMenu.InsertPlaybackMarkerNext.BindCommand, delegate(AddElementCommandParameters? p)
		{
			slideEditorVM.AddPlaybackMarkerElementCommand?.Execute(p);
		});
		base.CommandBindings.Add(editorMenu.InsertPlaybackMarkerLast.BindCommand, delegate(AddElementCommandParameters? p)
		{
			slideEditorVM.AddPlaybackMarkerElementCommand?.Execute(p);
		});
		base.CommandBindings.Add(editorMenu.TextChangeFont.BindCommand, delegate
		{
			slideEditorVM.SelectedInspectorTab = InspectorTab.Text;
			TextInspector?.OpenFontSelector();
		}, CanTextPropertyUpdate);
		base.CommandBindings.Add(editorMenu.TextBold.BindCommand, delegate
		{
			if (TextInspector != null)
			{
				((DependencyObject)TextInspector).SetCurrentValue(ProPresenter.UI.SlideEditor.Inspectors.TextInspector.IsBoldEnabledProperty, (object)(!TextInspector.IsBoldEnabled));
			}
		}, CanTextPropertyUpdate);
		base.CommandBindings.Add(editorMenu.TextItalic.BindCommand, delegate
		{
			if (TextInspector != null)
			{
				((DependencyObject)TextInspector).SetCurrentValue(ProPresenter.UI.SlideEditor.Inspectors.TextInspector.IsItalicEnabledProperty, (object)(!TextInspector.IsItalicEnabled));
			}
		}, CanTextPropertyUpdate);
		base.CommandBindings.Add(editorMenu.TextUnderline.BindCommand, delegate
		{
			if (TextInspector != null)
			{
				((DependencyObject)TextInspector).SetCurrentValue(ProPresenter.UI.SlideEditor.Inspectors.TextInspector.IsUnderlineEnabledProperty, (object)(!TextInspector.IsUnderlineEnabled));
			}
		}, CanTextPropertyUpdate);
		base.CommandBindings.Add(editorMenu.TextStrikeThrough.BindCommand, delegate
		{
			if (TextInspector != null)
			{
				((DependencyObject)TextInspector).SetCurrentValue(ProPresenter.UI.SlideEditor.Inspectors.TextInspector.IsStrikethroughEnabledProperty, (object)(!TextInspector.IsStrikethroughEnabled));
			}
		}, CanTextPropertyUpdate);
		base.CommandBindings.Add(editorMenu.TextBigger.BindCommand, delegate
		{
			if (TextInspector != null)
			{
				((DependencyObject)TextInspector).SetCurrentValue(ProPresenter.UI.SlideEditor.Inspectors.TextInspector.CharacterSizeProperty, (object)(TextInspector.CharacterSize + 1));
			}
		}, CanTextPropertyUpdate);
		base.CommandBindings.Add(editorMenu.TextSmaller.BindCommand, delegate
		{
			if (TextInspector != null)
			{
				((DependencyObject)TextInspector).SetCurrentValue(ProPresenter.UI.SlideEditor.Inspectors.TextInspector.CharacterSizeProperty, (object)((TextInspector.CharacterSize <= 2) ? 1 : (TextInspector.CharacterSize - 1)));
			}
		}, CanTextPropertyUpdate);
		base.CommandBindings.Add(editorMenu.TextCharSpaceDefault.BindCommand, delegate
		{
			if (TextInspector != null)
			{
				TextInspector? textInspector = TextInspector;
				DependencyProperty characterSpacingProperty = ProPresenter.UI.SlideEditor.Inspectors.TextInspector.CharacterSpacingProperty;
				double num2 = (TextInspector.CharacterSpacing = 0.0);
				((DependencyObject)textInspector).SetCurrentValue(characterSpacingProperty, (object)num2);
			}
		}, CanTextPropertyUpdate);
		base.CommandBindings.Add(editorMenu.TextCharSpaceTighten.BindCommand, delegate
		{
			if (TextInspector != null)
			{
				((DependencyObject)TextInspector).SetCurrentValue(ProPresenter.UI.SlideEditor.Inspectors.TextInspector.CharacterSpacingProperty, (object)(TextInspector.CharacterSpacing -= 1.0));
			}
		}, CanTextPropertyUpdate);
		base.CommandBindings.Add(editorMenu.TextCharSpaceLoosen.BindCommand, delegate
		{
			if (TextInspector != null)
			{
				((DependencyObject)TextInspector).SetCurrentValue(ProPresenter.UI.SlideEditor.Inspectors.TextInspector.CharacterSpacingProperty, (object)(TextInspector.CharacterSpacing += 1.0));
			}
		}, CanTextPropertyUpdate);
		base.CommandBindings.Add(editorMenu.TextLigatureDefault.BindCommand, delegate
		{
			if (TextInspector != null)
			{
				TextInspector.LigaturesEnabled = true;
			}
		}, CanTextPropertyUpdate);
		base.CommandBindings.Add(editorMenu.TextLigatureNone.BindCommand, delegate
		{
			if (TextInspector != null)
			{
				TextInspector.LigaturesEnabled = false;
			}
		}, CanTextPropertyUpdate);
		base.CommandBindings.Add(editorMenu.TextBaselineDefault.BindCommand, delegate
		{
			TextInspector?.ApplyScriptLevel(0);
		}, CanTextPropertyUpdate);
		base.CommandBindings.Add(editorMenu.TextBaselineUseSuperscript.BindCommand, delegate
		{
			TextInspector?.ApplyScriptLevel(1);
		}, CanTextPropertyUpdate);
		base.CommandBindings.Add(editorMenu.TextBaselineUseSubscript.BindCommand, delegate
		{
			TextInspector?.ApplyScriptLevel(-1);
		}, CanTextPropertyUpdate);
		base.CommandBindings.Add(editorMenu.TextBaselineRaise.BindCommand, delegate
		{
			if (TextInspector != null)
			{
				int num3 = TextInspector.ActiveRunSettings?.ScriptLevel ?? (-1);
				TextInspector.ApplyScriptLevel(++num3);
			}
		}, CanTextPropertyUpdate);
		base.CommandBindings.Add(editorMenu.TextBaselineLower.BindCommand, delegate
		{
			if (TextInspector != null)
			{
				int num4 = TextInspector.ActiveRunSettings?.ScriptLevel ?? (-1);
				TextInspector.ApplyScriptLevel(--num4);
			}
		}, CanTextPropertyUpdate);
		base.CommandBindings.Add(editorMenu.TextCapNone.BindCommand, delegate
		{
			TextInspector? textInspector2 = TextInspector;
			if (textInspector2 != null)
			{
				((DependencyObject)textInspector2).SetCurrentValue(ProPresenter.UI.SlideEditor.Inspectors.TextInspector.CapitalizationProperty, (object)CapitalizationType.None);
			}
		}, CanTextPropertyUpdate);
		base.CommandBindings.Add(editorMenu.TextCapAll.BindCommand, delegate
		{
			TextInspector? textInspector3 = TextInspector;
			if (textInspector3 != null)
			{
				((DependencyObject)textInspector3).SetCurrentValue(ProPresenter.UI.SlideEditor.Inspectors.TextInspector.CapitalizationProperty, (object)CapitalizationType.AllCaps);
			}
		}, CanTextPropertyUpdate);
		base.CommandBindings.Add(editorMenu.TextCapTitle.BindCommand, delegate
		{
			TextInspector? textInspector4 = TextInspector;
			if (textInspector4 != null)
			{
				((DependencyObject)textInspector4).SetCurrentValue(ProPresenter.UI.SlideEditor.Inspectors.TextInspector.CapitalizationProperty, (object)CapitalizationType.TitleCase);
			}
		}, CanTextPropertyUpdate);
		base.CommandBindings.Add(editorMenu.TextCapStart.BindCommand, delegate
		{
			TextInspector? textInspector5 = TextInspector;
			if (textInspector5 != null)
			{
				((DependencyObject)textInspector5).SetCurrentValue(ProPresenter.UI.SlideEditor.Inspectors.TextInspector.CapitalizationProperty, (object)CapitalizationType.StartCase);
			}
		}, CanTextPropertyUpdate);
		base.CommandBindings.Add(editorMenu.TextAlignmentLeft.BindCommand, delegate
		{
			TextInspector? textInspector6 = TextInspector;
			if (textInspector6 != null)
			{
				((DependencyObject)textInspector6).SetCurrentValue(ProPresenter.UI.SlideEditor.Inspectors.TextInspector.ParagraphAlignmentProperty, (object)ParagraphAlignment.Left);
			}
		}, CanTextPropertyUpdate);
		base.CommandBindings.Add(editorMenu.TextAlignmentCenter.BindCommand, delegate
		{
			TextInspector? textInspector7 = TextInspector;
			if (textInspector7 != null)
			{
				((DependencyObject)textInspector7).SetCurrentValue(ProPresenter.UI.SlideEditor.Inspectors.TextInspector.ParagraphAlignmentProperty, (object)ParagraphAlignment.Center);
			}
		}, CanTextPropertyUpdate);
		base.CommandBindings.Add(editorMenu.TextAlignmentRight.BindCommand, delegate
		{
			TextInspector? textInspector8 = TextInspector;
			if (textInspector8 != null)
			{
				((DependencyObject)textInspector8).SetCurrentValue(ProPresenter.UI.SlideEditor.Inspectors.TextInspector.ParagraphAlignmentProperty, (object)ParagraphAlignment.Right);
			}
		}, CanTextPropertyUpdate);
		base.CommandBindings.Add(editorMenu.TextAlignmentJustify.BindCommand, delegate
		{
			TextInspector? textInspector9 = TextInspector;
			if (textInspector9 != null)
			{
				((DependencyObject)textInspector9).SetCurrentValue(ProPresenter.UI.SlideEditor.Inspectors.TextInspector.ParagraphAlignmentProperty, (object)ParagraphAlignment.Justified);
			}
		}, CanTextPropertyUpdate);
		base.CommandBindings.Add(editorMenu.TextAlignmentTop.BindCommand, delegate
		{
			TextInspector? textInspector10 = TextInspector;
			if (textInspector10 != null)
			{
				((DependencyObject)textInspector10).SetCurrentValue(ProPresenter.UI.SlideEditor.Inspectors.TextInspector.DocumentAlignmentProperty, (object)DocumentAlignment.Top);
			}
		}, CanTextPropertyUpdate);
		base.CommandBindings.Add(editorMenu.TextAlignmentMiddle.BindCommand, delegate
		{
			TextInspector? textInspector11 = TextInspector;
			if (textInspector11 != null)
			{
				((DependencyObject)textInspector11).SetCurrentValue(ProPresenter.UI.SlideEditor.Inspectors.TextInspector.DocumentAlignmentProperty, (object)DocumentAlignment.Middle);
			}
		}, CanTextPropertyUpdate);
		base.CommandBindings.Add(editorMenu.TextAlignmentBottom.BindCommand, delegate
		{
			TextInspector? textInspector12 = TextInspector;
			if (textInspector12 != null)
			{
				((DependencyObject)textInspector12).SetCurrentValue(ProPresenter.UI.SlideEditor.Inspectors.TextInspector.DocumentAlignmentProperty, (object)DocumentAlignment.Bottom);
			}
		}, CanTextPropertyUpdate);
		base.CommandBindings.Add(editorMenu.ArrangementAlignObjLeft.BindCommand, delegate
		{
			slideEditorVM.ShapeInspectorVM.AlignCommand?.Invoke(AlignmentType.Left);
		}, () => slideEditorVM.ShapeInspectorVM.CanElementArrange);
		base.CommandBindings.Add(editorMenu.ArrangementAlignObjCenter.BindCommand, delegate
		{
			slideEditorVM.ShapeInspectorVM.AlignCommand?.Invoke(AlignmentType.Center);
		}, () => slideEditorVM.ShapeInspectorVM.CanElementArrange);
		base.CommandBindings.Add(editorMenu.ArrangementAlignObjRight.BindCommand, delegate
		{
			slideEditorVM.ShapeInspectorVM.AlignCommand?.Invoke(AlignmentType.Right);
		}, () => slideEditorVM.ShapeInspectorVM.CanElementArrange);
		base.CommandBindings.Add(editorMenu.ArrangementAlignObjTop.BindCommand, delegate
		{
			slideEditorVM.ShapeInspectorVM.AlignCommand?.Invoke(AlignmentType.Top);
		}, () => slideEditorVM.ShapeInspectorVM.CanElementArrange);
		base.CommandBindings.Add(editorMenu.ArrangementAlignObjMiddle.BindCommand, delegate
		{
			slideEditorVM.ShapeInspectorVM.AlignCommand?.Invoke(AlignmentType.Middle);
		}, () => slideEditorVM.ShapeInspectorVM.CanElementArrange);
		base.CommandBindings.Add(editorMenu.ArrangementAlignObjBottom.BindCommand, delegate
		{
			slideEditorVM.ShapeInspectorVM.AlignCommand?.Invoke(AlignmentType.Bottom);
		}, () => slideEditorVM.ShapeInspectorVM.CanElementArrange);
		base.CommandBindings.Add(editorMenu.FlipVertical.BindCommand, delegate
		{
			slideEditorVM.ShapeInspectorVM.FlipVertically = !slideEditorVM.ShapeInspectorVM.FlipVertically;
		}, () => slideEditorVM.ShapeInspectorVM.CanElementArrange);
		base.CommandBindings.Add(editorMenu.FlipHorizontal.BindCommand, delegate
		{
			slideEditorVM.ShapeInspectorVM.FlipHorizontally = !slideEditorVM.ShapeInspectorVM.FlipHorizontally;
		}, () => slideEditorVM.ShapeInspectorVM.CanElementArrange);
		base.CommandBindings.Add(editorMenu.EventDistributeElements.BindCommand, delegate
		{
			slideEditorVM.ShapeInspectorVM.DistributeCommand?.Invoke(DistributionType.Evenly);
		});
		base.CommandBindings.Add(editorMenu.HorizontalDistributeElements.BindCommand, delegate
		{
			slideEditorVM.ShapeInspectorVM.DistributeCommand?.Invoke(DistributionType.Horizontally);
		});
		base.CommandBindings.Add(editorMenu.VerticalDistributeElements.BindCommand, delegate
		{
			slideEditorVM.ShapeInspectorVM.DistributeCommand?.Invoke(DistributionType.Vertically);
		});
		base.CommandBindings.Add(editorMenu.Lock.BindCommand, delegate
		{
			slideEditorVM.ShapeInspectorVM.IsLocked = true;
		}, () => slideEditorVM.ShapeInspectorVM.CanElementArrange);
		base.CommandBindings.Add(editorMenu.Unlock.BindCommand, slideEditorVM.ShapeInspectorVM.UnlockCommand);
		base.CommandBindings.Add(editorMenu.UnlockAll.BindCommand, delegate
		{
			slideEditorVM.ShapeInspectorVM.UnlockAllCommand?.Invoke();
		});
		base.CommandBindings.Add(editorMenu.Hide.BindCommand, delegate
		{
			slideEditorVM.ShapeInspectorVM.HideCommand?.Invoke();
		}, () => slideEditorVM.ShapeInspectorVM.CanElementArrange);
		base.CommandBindings.Add(editorMenu.ZoomIn.BindCommand, delegate
		{
			slideEditorVM.ZoomCommand?.Invoke(parameter: true);
		});
		base.CommandBindings.Add(editorMenu.ZoomOut.BindCommand, delegate
		{
			slideEditorVM.ZoomCommand?.Invoke(parameter: false);
		});
		base.CommandBindings.Add(editorMenu.ZoomActualSize.BindCommand, delegate
		{
			slideEditorVM.ZoomToActualSizeCommand?.Invoke();
		});
		base.CommandBindings.Add(editorMenu.ZoomFitSlide.BindCommand, delegate
		{
			slideEditorVM.IsScaleToFitActive = true;
		});
		base.CommandBindings.Add(editorMenu.ZoomFitCanvas.BindCommand, SlideCanvas.FitCanvas);
		base.CommandBindings.Add(editorMenu.FitToText.BindCommand, slideEditorVM.FitToTextCommand);
		base.CommandBindings.Add(editorMenu.OverlayEdit.BindCommand, slideEditorVM.OverlayEditCommand);
		base.CommandBindings.Add(editorMenu.ArrangementBringForward.BindCommand, slideEditorVM.BringForwardElementsCommand);
		base.CommandBindings.Add(editorMenu.ArrangementBringToFront.BindCommand, slideEditorVM.BringToFrontElementsCommand);
		base.CommandBindings.Add(editorMenu.ArrangementSendBackward.BindCommand, slideEditorVM.SendBackwardElementsCommand);
		base.CommandBindings.Add(editorMenu.ArrangementSendToBack.BindCommand, slideEditorVM.SendToBackElementsCommand);
		InitializeNewSlideCommand();
		bool canAddShape()
		{
			if (Keyboard.FocusedElement is SlideCanvas || (!(Keyboard.FocusedElement is FormattedTextBox) && !(Keyboard.FocusedElement is TextBoxBase)))
			{
				ICommand<AddElementCommandParameters?> addShapeCommand = slideEditorVM.AddShapeCommand;
				if (addShapeCommand == null || addShapeCommand.CanExecute(ShapeType.Text))
				{
					return !(slideEditorVM.SelectedSlideElements.FirstOrDefault() is TextShape);
				}
			}
			return false;
		}
		bool canContinueRouting()
		{
			return !canAddShape();
		}
	}

	private void SlideEditorView_IsVisibleChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		Window window = Window.GetWindow((DependencyObject)(object)this);
		object newValue = ((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		if (newValue is bool && (bool)newValue)
		{
			SlideCanvas.IsScaleToFitActive = true;
			if (window != null)
			{
				window.StateChanged += OwningWindow_StateChanged;
			}
		}
		else if (window != null)
		{
			window.StateChanged -= OwningWindow_StateChanged;
		}
	}

	private void OwningWindow_StateChanged(object? sender, EventArgs e)
	{
		if (sender is Window { WindowState: WindowState.Minimized })
		{
			SlideCanvas.IsScaleToFitActive = true;
		}
	}

	private void InitializeNewSlideCommand()
	{
		RoutedUICommand routedUICommand = new RoutedUICommand();
		routedUICommand.InputGestures.Add(VirtualKeyGesture.CreateKeyGesture(VirtualKey.Enter, (ModifierKeys)0).ToKeyGesture());
		base.CommandBindings.Add(routedUICommand, delegate
		{
			SlideEditorVM?.CreateNewSlideFromSelectedSlideCommand?.Invoke();
		}, () => !(Keyboard.FocusedElement is TextBoxBase), () => Keyboard.FocusedElement is TextBoxBase);
	}

	private bool CanTextPropertyUpdate()
	{
		if (TextInspector?.Document != null)
		{
			return !TextInspector.SettingsUpdateInProgress;
		}
		return false;
	}

	private void SlideCanvas_GotFocus(object? sender, RoutedEventArgs e)
	{
		SlideEditorVM?.CanvasGotFocusCommand?.Invoke();
	}

	private void SlideNoteTextBox_GotFocus(object? sender, RoutedEventArgs e)
	{
		SlideEditorVM?.SlideNoteTextBoxGotFocusCommand?.Invoke();
	}

	private void SlideNoteTextBox_IsVisibleChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		if (!(bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue)
		{
			SlideCanvas.Focus();
		}
	}

	private void SlideNoteTextBox_TextChanged()
	{
		DefaultSlideNoteRunSettings = SlideNoteTextBox.ActiveRunSettings;
	}

	private void BtnClose_Click(object? sender, RoutedEventArgs e)
	{
		MainLayout mainLayout = ((DependencyObject)(object)this).FindVisualParent<MainLayout>();
		if (mainLayout != null)
		{
			ISlideEditorVM? slideEditorVM = SlideEditorVM;
			if (slideEditorVM != null && slideEditorVM.EditMode == EditMode.Prop)
			{
				mainLayout.SelectedView = PopupType.Props;
			}
		}
		this.Close?.Invoke();
	}

	private void SlideNoteGridSplitter_DragDelta(object? sender, DragDeltaEventArgs e)
	{
		if (SlideEditorVM != null)
		{
			if (e.VerticalChange >= SlideNoteInputGrid.ActualHeight - 20.0)
			{
				SlideEditorVM.SlideNotesVisible = false;
			}
			else if (e.VerticalChange <= -200.0)
			{
				SlideEditorVM.SlideNotesVisible = true;
			}
		}
	}

	private void ListBox_SelectionChanged(object? sender, SelectionChangedEventArgs e)
	{
		System.Windows.Controls.ListBoxItem listBoxItem = e.AddedItems.OfType<System.Windows.Controls.ListBoxItem>().FirstOrDefault();
		if (listBoxItem != null && sender is ListBox listBox)
		{
			listBox.ScrollIntoView(listBoxItem);
		}
	}

	private void EditorPreviewItem_MouseLeftButtonUp(object? sender, MouseButtonEventArgs e)
	{
		if (sender is EditorPreviewItem editorPreviewItem)
		{
			CustomSlide source = editorPreviewItem.Source;
			if (source != null)
			{
				SlideEditorVM?.SelectSlideCommand.Invoke(source);
			}
		}
	}

	private void EditorPreviewItem_SizeChanged(object? sender, SizeChangedEventArgs e)
	{
		PresentationSlideFloatingHeader.InvalidateMeasure();
	}

	private void CustomZoomFactorInput_IsVisibleChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		if (CustomZoomFactorInput.Visibility == Visibility.Visible)
		{
			CustomZoomFactorInput.Value = SlideEditorVM?.ZoomFactor ?? 0.0;
			CustomZoomFactorInput.Focus();
			if (ZoomInputTextBox != null)
			{
				ZoomInputTextBox.IsVisibleChanged += new DependencyPropertyChangedEventHandler(ZoomInputTextBox_IsVisibleChanged);
			}
			else
			{
				CustomZoomFactorInput.GotFocus += CustomZoomFactorInput_GotFocus;
			}
		}
	}

	private void CustomZoomFactorInput_GotFocus(object? sender, RoutedEventArgs e)
	{
		TextBox? zoomInputTextBox = ZoomInputTextBox;
		if (zoomInputTextBox != null && zoomInputTextBox.IsVisible)
		{
			SetFocusOnZoomControlInputTextBox();
			CustomZoomFactorInput.GotFocus -= CustomZoomFactorInput_GotFocus;
		}
	}

	private void SetFocusOnZoomControlInputTextBox()
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		if (ZoomInputTextBox != null)
		{
			ZoomInputTextBox.Focus();
			ZoomInputTextBox.LostFocus += ZoomInputTextBox_LostFocus;
			ZoomInputTextBox.IsVisibleChanged -= new DependencyPropertyChangedEventHandler(ZoomInputTextBox_IsVisibleChanged);
		}
	}

	private void ZoomInputTextBox_IsVisibleChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		TextBox? zoomInputTextBox = ZoomInputTextBox;
		if (zoomInputTextBox != null && zoomInputTextBox.IsVisible)
		{
			SetFocusOnZoomControlInputTextBox();
		}
	}

	private void ZoomInputTextBox_LostFocus(object? sender, RoutedEventArgs e)
	{
		UpdateCustomZoom();
		if (ZoomInputTextBox != null)
		{
			ZoomInputTextBox.LostFocus -= ZoomInputTextBox_LostFocus;
		}
	}

	private void CustomZoomFactorInput_KeyDown(object? sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		if ((int)e.Key == 6)
		{
			UpdateCustomZoom();
		}
	}

	private void UpdateCustomZoom()
	{
		if (SlideEditorVM != null)
		{
			SlideEditorVM.IsCustomZoomInput = false;
			if (CustomZoomFactorInput.Value.HasValue && SlideEditorVM.ZoomFactor != CustomZoomFactorInput.Value)
			{
				SlideEditorVM.ChangeZoomFactorCommand?.Invoke(CustomZoomFactorInput.Value.Value);
			}
		}
	}

	private void GridButton_PreviewMouseDown(object? sender, MouseButtonEventArgs e)
	{
		e.Handled = SlideEditorVM?.ToggleGridCommand?.Invoke() == true;
	}

	private void GuidesButton_OnPreviewMouseDown(object? sender, MouseButtonEventArgs e)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Invalid comparison between Unknown and I4
		if ((int)Keyboard.Modifiers == 1)
		{
			e.Handled = SlideEditorVM?.ToggleAllGuidelinesCommand?.Invoke() == true;
		}
	}

	private void AddTabStopMenu_Opened(object? sender, RoutedEventArgs e)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		if (sender is ContextMenu contextMenu)
		{
			if (IsNotes(contextMenu))
			{
				_mousePos = (Vector2<double>)Mouse.GetPosition(SlideNoteTextBox);
			}
			else
			{
				_mousePos = SlideCanvas.MousePosition;
			}
		}
	}

	private void AddTabStopMenu_Closed(object? sender, RoutedEventArgs e)
	{
		_mousePos = Vector2<double>.Zero;
	}

	private void AddTabStopMenu_Click(object? sender, RoutedEventArgs e)
	{
		if (sender is MenuItem { Tag: var tag } menuItem && tag is TabStopType tabStopType)
		{
			ContextMenu contextMenu = ((DependencyObject)(object)menuItem).FindVisualParent<ContextMenu>();
			if (IsNotes(contextMenu))
			{
				NotesTabStops.AddTabStop(_mousePos, tabStopType);
			}
			else
			{
				SlideCanvas.AddTabStopCommand?.Invoke((tabStopType, _mousePos));
			}
		}
	}

	private bool IsNotes(ContextMenu? contextMenu)
	{
		if (contextMenu?.PlacementTarget is CanvasRuler { Tag: string tag })
		{
			return tag == "Notes";
		}
		return false;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
