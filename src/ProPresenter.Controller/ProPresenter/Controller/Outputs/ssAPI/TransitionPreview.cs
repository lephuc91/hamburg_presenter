using System;
using System.Windows.Media.Imaging;
using Pro.Common.Components;
using Pro.Common.Mathematics;

namespace ProPresenter.Controller.Outputs.ssAPI;

public class TransitionPreview : NotifyPropertyChangedBase
{
	private bool _isLoaded;

	private BitmapSource[] _frames = new BitmapSource[0];

	public Vector2<int> TargetSize { get; }

	public bool IsLoaded
	{
		get
		{
			return _isLoaded;
		}
		private set
		{
			SetValue("IsLoaded", ref _isLoaded, value);
		}
	}

	public BitmapSource[] Frames
	{
		get
		{
			return _frames;
		}
		private set
		{
			SetValue("Frames", ref _frames, value);
		}
	}

	public event Action? FramesLoaded;

	public TransitionPreview(Vector2<int> targetSize)
	{
		TargetSize = targetSize;
	}

	internal void OnFramesLoaded(BitmapSource[] frames)
	{
		if (IsLoaded)
		{
			throw new InvalidOperationException();
		}
		Frames = frames;
		IsLoaded = true;
		this.FramesLoaded?.Invoke();
	}
}
