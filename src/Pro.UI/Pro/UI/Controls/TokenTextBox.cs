using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Mathematics;
using Pro.Common.Utility;
using Pro.DO.Token;
using Pro.UI.Components;
using Pro.UI.Controls.Tokens;
using Pro.UI.DragDropHelper;
using Pro.UI.Utility;

namespace Pro.UI.Controls;

public abstract class TokenTextBox<T, L> : ContentControl where T : TokenBase where L : class, ITokenCollection<T>
{
	private sealed class TokenRichTextBox : RichTextBox
	{
		private readonly Action<MouseButtonEventArgs> _previewMouseLeftButtonDown;

		private readonly Action<MouseButtonEventArgs> _previewMouseLeftButtonUp;

		private readonly Action<MouseEventArgs> _previewMouseMove;

		public TokenRichTextBox(Action<MouseButtonEventArgs> previewMouseLeftButtonDown, Action<MouseButtonEventArgs> previewMouseLeftButtonUp, Action<MouseEventArgs> previewMouseMove)
		{
			_previewMouseLeftButtonDown = previewMouseLeftButtonDown;
			_previewMouseLeftButtonUp = previewMouseLeftButtonUp;
			_previewMouseMove = previewMouseMove;
			base.Style = Application.Current?.Resources[typeof(RichTextBox)] as Style;
		}

		protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
		{
			base.OnPreviewMouseLeftButtonDown(e);
			_previewMouseLeftButtonDown(e);
		}

		protected override void OnPreviewMouseLeftButtonUp(MouseButtonEventArgs e)
		{
			base.OnPreviewMouseLeftButtonUp(e);
			_previewMouseLeftButtonUp(e);
		}

		protected override void OnPreviewMouseMove(MouseEventArgs e)
		{
			base.OnPreviewMouseMove(e);
			_previewMouseMove(e);
		}
	}

	private const double DocumentPagePadding = 3.0;

	private readonly TokenRichTextBox _richTextBox;

	private readonly DragSource _dragSource;

	private readonly DropTarget _dropTarget;

	private bool _canStartDrag;

	private bool _ignoreChanges;

	private Vector2<double> _mouseDownPos;

	private bool _documentChangeStarted;

	private readonly Dictionary<T, InlineUIContainer> _containerMap = new Dictionary<T, InlineUIContainer>();

	public static readonly DependencyProperty TokensProperty = DependencyProperty.Register("Tokens", typeof(L), typeof(TokenTextBox<T, L>), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(TokensPropertyChanged)));

	public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(TokenTextBox<T, L>), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(TextPropertyChanged)));

	public static readonly DependencyProperty DocumentChangeStartedCommandProperty = DependencyProperty.Register("DocumentChangeStartedCommand", typeof(ICommand<bool>), typeof(TokenTextBox<T, L>));

	public static readonly DependencyProperty DocumentChangeEndedCommandProperty = DependencyProperty.Register("DocumentChangeEndedCommand", typeof(ICommand<bool>), typeof(TokenTextBox<T, L>));

	public L? Tokens
	{
		get
		{
			return (L)((DependencyObject)this).GetValue(TokensProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TokensProperty, (object)value);
		}
	}

	private IEnumerable<T> OrderedTokens
	{
		get
		{
			IEnumerable<T> enumerable = Tokens?.OrderBy((T t) => t.Index);
			return enumerable ?? Enumerable.Empty<T>();
		}
	}

	public string Text
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(TextProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TextProperty, (object)value);
		}
	}

	public ICommand<bool>? DocumentChangeStartedCommand
	{
		get
		{
			return (ICommand<bool>)((DependencyObject)this).GetValue(DocumentChangeStartedCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DocumentChangeStartedCommandProperty, (object)value);
		}
	}

	public ICommand<bool>? DocumentChangeEndedCommand
	{
		get
		{
			return (ICommand<bool>)((DependencyObject)this).GetValue(DocumentChangeEndedCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DocumentChangeEndedCommandProperty, (object)value);
		}
	}

	protected override int VisualChildrenCount => base.VisualChildrenCount + 1;

	private static void TokensPropertyChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		((TokenTextBox<T, L>)(object)callerObject).OnTokensPropertyChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as L, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as L);
	}

	private static void TextPropertyChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		((TokenTextBox<T, L>)(object)callerObject).RebuildDocumentFromData();
	}

	protected TokenTextBox()
	{
		base.AllowDrop = true;
		_richTextBox = new TokenRichTextBox(RichTextBox_PreviewMouseLeftButtonDown, RichTextBox_PreviewMouseLeftButtonUp, RichTextBox_PreviewMouseMove)
		{
			AllowDrop = true,
			IsDocumentEnabled = true,
			IsUndoEnabled = false
		};
		_richTextBox.TextChanged += UpdateText;
		_richTextBox.Document.PagePadding = new Thickness(3.0);
		_richTextBox.SetBinding(FrameworkElement.WidthProperty, new Binding("ActualWidth")
		{
			Source = this
		});
		AddVisualChild(_richTextBox);
		_dragSource = new DragSource((DependencyObject)(object)_richTextBox.Document);
		_dropTarget = new DropTarget((DependencyObject)(object)_richTextBox.Document);
		DropAction<DraggedItems<T>> dropAction = _dropTarget.AddDropType<DraggedItems<T>>();
		dropAction.SetOnDataDroppedAction(OnTokenDropped);
		dropAction.SetOnDataDraggedAction(OnTokensDragged);
		dropAction.SetCanCopyPredicate((DraggedItems<T> _, DragEventArgs e) => e.Effects.HasFlag(DragDropEffects.Copy));
		dropAction.SetCanMovePredicate((DraggedItems<T> _, DragEventArgs e) => e.Effects.HasFlag(DragDropEffects.Move));
		Style style = new Style
		{
			TargetType = typeof(Paragraph)
		};
		style.Setters.Add(new Setter
		{
			Property = Block.MarginProperty,
			Value = new Thickness(1.0)
		});
		_richTextBox.Resources.Add(typeof(Paragraph), style);
	}

	protected override Visual GetVisualChild(int index)
	{
		if (index != 0)
		{
			return base.GetVisualChild(index - 1);
		}
		return _richTextBox;
	}

	private void OnTokensPropertyChanged(L? oldValue, L? newValue)
	{
		_ignoreChanges = true;
		if (oldValue != null)
		{
			oldValue.CollectionChanged -= Tokens_CollectionChanged;
			OnTokensRemoved(oldValue);
		}
		if (newValue != null)
		{
			newValue.CollectionChanged += Tokens_CollectionChanged;
			OnTokensAdded(newValue);
		}
		_ignoreChanges = false;
		RebuildDocumentFromData();
	}

	private void Tokens_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		if (!_ignoreChanges)
		{
			_ignoreChanges = true;
			OnTokensRemoved(e.OldItems?.Cast<T>());
			OnTokensAdded(e.NewItems?.Cast<T>());
			_ignoreChanges = false;
		}
	}

	private void OnTokensRemoved(IEnumerable<T>? tokens)
	{
		if (tokens != null)
		{
			T[] array = tokens.ToArray();
			foreach (T val in array)
			{
				val.DataModified -= RebuildDocumentFromData;
				RemoveToken(val);
			}
		}
	}

	private void OnTokensAdded(IEnumerable<T>? tokens)
	{
		if (tokens != null)
		{
			T[] array = tokens.ToArray();
			foreach (T val in array)
			{
				val.DataModified += RebuildDocumentFromData;
				InsertToken(val);
			}
		}
	}

	protected virtual TokenControl OnGenerateToken(T tokenData)
	{
		return new TokenControl
		{
			Token = tokenData
		};
	}

	private TokenControl GenerateToken(T tokenData)
	{
		return OnGenerateToken(tokenData);
	}

	private void RebuildDocumentFromData()
	{
		if (!_ignoreChanges)
		{
			_ignoreChanges = true;
			FlowDocument document = _richTextBox.Document;
			document.Blocks.Clear();
			_containerMap.Clear();
			Text?.Split(new string[1] { "\n" }, StringSplitOptions.None).ForEach(delegate(string p)
			{
				document.Blocks.Add(new Paragraph(new Run(p)));
			});
			OrderedTokens.ForEach(InsertToken);
			_ignoreChanges = false;
		}
	}

	private void UpdateText(object? sender, TextChangedEventArgs e)
	{
		UpdateDataFromDocument(null);
	}

	private void UpdateDataFromDocument(bool? isTokenDrop = null)
	{
		if (_ignoreChanges)
		{
			return;
		}
		_ignoreChanges = true;
		StartDocumentChange(isTokenDrop.HasValue);
		string text = string.Empty;
		int num = 0;
		List<T> list = OrderedTokens.ToList();
		Paragraph[] array = _richTextBox.Document.Blocks.OfType<Paragraph>().ToArray();
		Paragraph[] array2 = array;
		foreach (Paragraph paragraph in array2)
		{
			Inline[] array3 = paragraph.Inlines.ToArray();
			foreach (Inline inline in array3)
			{
				if (inline is InlineUIContainer inlineUIContainer)
				{
					if (!((inlineUIContainer.Child as TokenControl)?.Token is T val))
					{
						continue;
					}
					val.AdjustIndex(num++, isTokenDrop == true);
					if (Tokens != null && !list.Remove(val))
					{
						if (!Tokens.Add(val))
						{
							paragraph.Inlines.Remove(inline);
						}
						else if (!_containerMap.ContainsKey(val))
						{
							_containerMap.Add(val, inlineUIContainer);
						}
					}
				}
				else if (inline is Run { Text: var text2 })
				{
					text += text2;
					num += text2.Length;
				}
			}
			if (paragraph != array.Last())
			{
				text += "\n";
				num++;
			}
		}
		foreach (T item in list)
		{
			if (_containerMap.ContainsKey(item))
			{
				_containerMap.Remove(item);
			}
			L? tokens = Tokens;
			if (tokens != null && !tokens.Remove(item))
			{
				InsertToken(item);
			}
		}
		if (isTokenDrop.HasValue)
		{
			EndDocumentChange(autoFinalize: true);
		}
		else
		{
			StartDocumentChange(isTokens: false);
		}
		IEnumerable<T> source = from i in array.SelectMany((Paragraph p) => p.Inlines).OfType<InlineUIContainer>()
			select (i.Child as TokenControl)?.Token as T;
		Tokens?.SortTokens(source.NonNull());
		((DependencyObject)this).SetCurrentValue(TextProperty, (object)text);
		_ignoreChanges = false;
		if (!isTokenDrop.HasValue)
		{
			EndDocumentChange(autoFinalize: false);
		}
	}

	private void InsertToken(T token)
	{
		InsertToken(token, GetPointer(token.Index), updateContainerValue: true);
	}

	private TextPointer InsertToken(T token, TextPointer insertPosition, bool updateContainerValue)
	{
		InlineUIContainer inlineUIContainer = new InlineUIContainer(GenerateToken(token), insertPosition);
		_containerMap[token] = inlineUIContainer;
		if (!updateContainerValue)
		{
			return inlineUIContainer.ContentEnd;
		}
		return insertPosition;
	}

	private void RemoveToken(T token)
	{
		if (_containerMap.TryGetValue(token, out InlineUIContainer container))
		{
			_containerMap.Remove(token);
			_richTextBox.Document.Blocks.OfType<Paragraph>().ToArray().ForEach(delegate(Paragraph b)
			{
				b.Inlines.Remove(container);
			});
		}
	}

	private TextPointer GetPointer(int index)
	{
		TextPointer textPointer = _richTextBox.Document.ContentStart;
		int num = 0;
		while (textPointer != null && num <= index && textPointer.CompareTo(_richTextBox.Document.ContentEnd) != 0)
		{
			textPointer = textPointer.GetNextInsertionPosition(LogicalDirection.Forward);
			num++;
		}
		return textPointer ?? _richTextBox.Document.ContentEnd;
	}

	private void OnTokensDragged(DraggedItems<T> items, DragEventArgs e)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		_richTextBox.Focus();
		_richTextBox.CaretPosition = _richTextBox.GetPositionFromPoint(e.GetPosition(_richTextBox), snapToText: true);
	}

	private void OnTokenDropped(DraggedItems<T> droppedItems, DragEventArgs e)
	{
		StartDocumentChange(isTokens: true);
		_ignoreChanges = true;
		T[] array = droppedItems.Items;
		TextPointer insertPosition = _richTextBox.CaretPosition;
		bool flag = e.Effects == DragDropEffects.Copy;
		if (Tokens != null && flag)
		{
			array = array.Select((T i) => (T)i.Clone()).Where(Tokens.Add).ToArray();
		}
		T[] array2 = array;
		foreach (T token in array2)
		{
			RemoveToken(token);
			insertPosition = InsertToken(token, insertPosition, updateContainerValue: false);
		}
		_ignoreChanges = false;
		UpdateDataFromDocument(flag);
	}

	private void RichTextBox_PreviewMouseLeftButtonDown(MouseButtonEventArgs e)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		_canStartDrag = true;
		_mouseDownPos = (Vector2<double>)e.GetPosition(_richTextBox);
	}

	private void RichTextBox_PreviewMouseLeftButtonUp(MouseButtonEventArgs e)
	{
		_canStartDrag = false;
	}

	private void RichTextBox_PreviewMouseMove(MouseEventArgs e)
	{
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		if (e.LeftButton != MouseButtonState.Pressed || !_canStartDrag || !e.CanDrag(_richTextBox, _mouseDownPos) || _dragSource.IsDragging)
		{
			return;
		}
		IEnumerable<KeyValuePair<T, InlineUIContainer>> source = _containerMap.Where<KeyValuePair<T, InlineUIContainer>>((KeyValuePair<T, InlineUIContainer> t) => IsInlineSelected(t.Value));
		if (source.Any())
		{
			TokenControl tokenControl = e.FindHitElement<TokenControl>(_richTextBox);
			if (tokenControl != null)
			{
				_dragSource.StartDrag(new DraggedItems<T>(null, (from t in source
					select t.Key into t
					orderby t.Index
					select t).ToArray()), tokenControl.ToDragVisual(source.Count(), null), DragDropEffects.Move, (Vector2<double>)e.GetPosition(tokenControl));
			}
		}
		_canStartDrag = false;
	}

	private bool IsInlineSelected(InlineUIContainer inline)
	{
		if (inline.ContentStart.CompareTo(_richTextBox.Selection.Start) >= 0)
		{
			return inline.ContentEnd.CompareTo(_richTextBox.Selection.End) <= 0;
		}
		return false;
	}

	private void StartDocumentChange(bool isTokens)
	{
		if (!_documentChangeStarted)
		{
			DocumentChangeStartedCommand?.Invoke(isTokens);
			_documentChangeStarted = true;
		}
	}

	private void EndDocumentChange(bool autoFinalize)
	{
		DocumentChangeEndedCommand?.Invoke(autoFinalize);
		_documentChangeStarted = false;
	}
}
