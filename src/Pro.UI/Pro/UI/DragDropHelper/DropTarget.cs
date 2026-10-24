using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using Pro.Common.Collections;

namespace Pro.UI.DragDropHelper;

public class DropTarget
{
	private const string FileGroupDescriptorW = "FileGroupDescriptorW";

	private readonly DependencyObject _attachedObject;

	private BoxedDropAction? _fileDropAction;

	private BoxedDropAction? _webMediaDropAction;

	private readonly Dictionary<Type, BoxedDropAction> _dropActions = new Dictionary<Type, BoxedDropAction>();

	public DropTarget(DependencyObject attachedObject)
	{
		_attachedObject = attachedObject;
		DragDrop.AddDragEnterHandler(_attachedObject, OnDragEnter);
		DragDrop.AddDragLeaveHandler(_attachedObject, OnDragLeave);
		DragDrop.AddDragOverHandler(_attachedObject, OnDragOver);
		DragDrop.AddDropHandler(_attachedObject, OnDrop);
	}

	public DropAction<T> AddDropType<T>()
	{
		if (_dropActions.ContainsKey(typeof(T)))
		{
			throw new InvalidOperationException("This drop type has already been registered");
		}
		BoxedDropAction boxedDropAction = new BoxedDropAction();
		_dropActions[typeof(T)] = boxedDropAction;
		return new DropAction<T>(boxedDropAction);
	}

	public DropAction<FileInfo[]> AddFileDrop()
	{
		if (_fileDropAction != null)
		{
			throw new InvalidOperationException("This drop type has already been registered");
		}
		_fileDropAction = new BoxedDropAction();
		return new DropAction<FileInfo[]>(_fileDropAction);
	}

	public DropAction<FileInfo[]> AddWebMediaDrop()
	{
		if (_webMediaDropAction != null)
		{
			throw new InvalidOperationException("This drop type has already been registered");
		}
		_webMediaDropAction = new BoxedDropAction();
		return new DropAction<FileInfo[]>(_webMediaDropAction);
	}

	protected virtual void OnDragEnter(object? sender, DragEventArgs e)
	{
		InvokeAction(e, delegate(BoxedDropAction action, object data)
		{
			action.OnDataEnteredAction?.Invoke(data, e);
		});
		e.Handled = true;
	}

	protected virtual void OnDragLeave(object? sender, DragEventArgs e)
	{
		InvokeAction(e, delegate(BoxedDropAction action, object data)
		{
			action.OnDataLeftAction?.Invoke(data, e);
		});
		e.Handled = true;
	}

	protected virtual void OnDragOver(object? sender, DragEventArgs e)
	{
		InvokeAction(e, delegate(BoxedDropAction action, object data)
		{
			action.OnDataDraggedAction?.Invoke(data, e);
		});
		e.Handled = true;
	}

	private void InvokeAction(DragEventArgs args, Action<BoxedDropAction, object> action)
	{
		if (args.Data.GetDataPresent(DataFormats.FileDrop))
		{
			if (_fileDropAction != null)
			{
				FileInfo[] array = ((string[])args.Data.GetData(DataFormats.FileDrop)).Collect((string f) => new FileInfo(f)).ToArray();
				if (array.Any() && _fileDropAction.IsValidDataPredicate(array, args))
				{
					action(_fileDropAction, array);
				}
			}
			return;
		}
		if (args.Data.GetDataPresent(DataFormats.Html))
		{
			if (_webMediaDropAction != null)
			{
				try
				{
					string[] array2 = ((MemoryStream)args.Data.GetData("FileGroupDescriptorW")).ReadFileNames().ToArray();
					int num = 0;
					FileInfo[] array3 = new FileInfo[array2.Length];
					string[] array4 = array2;
					foreach (string path in array4)
					{
						MemoryStream fileContents = args.Data.GetFileContents(num);
						if (fileContents != null)
						{
							string text = Path.Combine(Path.GetTempPath(), path);
							using (FileStream stream = new FileStream(text, FileMode.Create))
							{
								fileContents.WriteTo(stream);
							}
							array3[num] = new FileInfo(text);
							num++;
						}
					}
					if (_webMediaDropAction.IsValidDataPredicate(array3, args))
					{
						action(_webMediaDropAction, array3);
					}
					else
					{
						SetEffects(args, isValid: false, canCopy: false, canMove: false);
					}
					return;
				}
				catch
				{
					SetEffects(args, isValid: false, canCopy: false, canMove: false);
					return;
				}
			}
			SetEffects(args, isValid: false, canCopy: false, canMove: false);
			return;
		}
		bool flag = false;
		bool canCopy = false;
		bool canMove = false;
		foreach (KeyValuePair<Type, BoxedDropAction> dropAction in _dropActions)
		{
			dropAction.Deconstruct(out var key, out var value);
			Type format = key;
			BoxedDropAction boxedDropAction = value;
			object data = args.Data.GetData(format);
			bool num2 = data != null;
			flag = num2 && boxedDropAction.IsValidDataPredicate(data, args);
			canCopy = num2 && boxedDropAction.CanCopyPredicate(data, args);
			canMove = num2 && boxedDropAction.CanMovePredicate(data, args);
			if (flag)
			{
				SetEffects(args, flag, canCopy, canMove);
				action(boxedDropAction, data);
				break;
			}
		}
		if (!flag)
		{
			SetEffects(args, flag, canCopy, canMove);
		}
	}

	protected virtual void OnDrop(object? sender, DragEventArgs e)
	{
		InvokeAction(e, delegate(BoxedDropAction action, object data)
		{
			action.OnDataDroppedAction?.Invoke(data, e);
		});
		e.Handled = true;
	}

	private void SetEffects(DragEventArgs e, bool isValid, bool canCopy, bool canMove)
	{
		canCopy = canCopy && (e.KeyStates.HasFlag(DragDropKeyStates.ControlKey) || !canMove);
		if (!isValid || (!canCopy && !canMove))
		{
			e.Effects = DragDropEffects.None;
		}
		else if (canCopy)
		{
			e.Effects = DragDropEffects.Copy;
		}
		else
		{
			e.Effects = DragDropEffects.Move;
		}
	}
}
