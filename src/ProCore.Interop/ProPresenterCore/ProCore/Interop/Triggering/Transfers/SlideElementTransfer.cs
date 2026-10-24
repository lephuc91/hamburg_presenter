using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Media.Imaging;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Logging;
using Pro.SerializationInterop.RVProtoData;
using ProPresenterCore.ProCore.Interop.Triggering.Types;

namespace ProPresenterCore.ProCore.Interop.Triggering.Transfers;

public class SlideElementTransfer : TriggerTransfer, ILinkedTextTransfer
{
	private unsafe readonly ProSlideElementTransfer.__Internal* _native;

	public override ProTriggerTransferType TransferType => ProTriggerTransferType.SlideElement;

	public Guid ElementID { get; }

	public ProSlideElementLayer ElementLayer { get; }

	public string StageMessage => RenderState.StageMessage;

	public TimeSpan PresentationVideoTimeRemaining => TimeSpan.FromSeconds(((double?)RenderState.PresentationMedia?.TimeRemaining) ?? 0.0);

	public TimeSpan AnnouncementVideoTimeRemaining => TimeSpan.FromSeconds(((double?)RenderState.AnnouncementMedia?.TimeRemaining) ?? 0.0);

	public TimeSpan AudioTimeRemaining => TimeSpan.FromSeconds(((double?)RenderState.AudioMedia?.TimeRemaining) ?? 0.0);

	public bool PresentationVideoLooping => RenderState.PresentationMedia?.IsLooping ?? false;

	public bool AnnouncementVideoLooping => RenderState.AnnouncementMedia?.IsLooping ?? false;

	public bool AudioLooping => RenderState.AudioMedia?.IsLooping ?? false;

	public ResourceAddress SlideLink { get; }

	public ResourceAddress ActivePlaylistItemLink { get; }

	public int TextIndex { get; }

	public Vector RenderOffset { get; set; }

	public Vector RenderSize { get; set; }

	public List<IBitmapHandle> BitmapSourceList { get; set; }

	public bool UpdatesRequired { get; set; }

	public int[] SegmentSizes { get; set; } = Array.Empty<int>();

	public TriggerTransferRenderState RenderState { get; private set; }

	internal unsafe SlideElementTransfer(ProSlideElementTransfer.__Internal* native)
	{
		_native = native;
		ElementID = *(Guid*)(&native->elementID);
		ElementLayer = native->elementLayer;
		UnmanagedMemoryStream input = new UnmanagedMemoryStream((byte*)((IntPtr*)(&native->triggerState))->ToPointer(), native->triggerStateLength);
		RenderState = TriggerTransferRenderState.Parser.ParseFrom((Stream)input);
		SlideLink = new ResourceAddress(native->slideLink);
		ActivePlaylistItemLink = new ResourceAddress(native->activePlaylistItemLink);
		TextIndex = (int)native->textIndex;
		BitmapSourceList = new List<IBitmapHandle>();
	}

	internal unsafe override void Apply()
	{
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		if (BitmapSourceList != null && !BitmapSourceList.Empty() && !((Freezable)(BitmapSourceList[0].BitmapSource ?? throw new InvalidOperationException("Failed to render transfer slide element data. BitmapSource is null."))).IsFrozen)
		{
			throw new InvalidOperationException("Failed to render transfer slide element data. BitmapSource is not frozen.");
		}
		ProSlideElementTransferFunc delegateForFunctionPointer = Marshal.GetDelegateForFunctionPointer<ProSlideElementTransferFunc>(_native->performTransfer);
		ProSlideElementPixelCopyCallback proSlideElementPixelCopyCallback = CopyPixels;
		GCHandle gCHandle = GCHandle.Alloc(proSlideElementPixelCopyCallback);
		try
		{
			int[] segmentSizes = SegmentSizes;
			int segmentCount = ((segmentSizes != null) ? segmentSizes.Length : 0);
			fixed (int* segmentSizes2 = SegmentSizes)
			{
				nint requester = new IntPtr(_native);
				Vector val = RenderOffset;
				float xOffset = (float)((Vector)(ref val)).X;
				val = RenderOffset;
				float yOffset = (float)((Vector)(ref val)).Y;
				val = RenderSize;
				int pixelWidth = (int)((Vector)(ref val)).X;
				val = RenderSize;
				delegateForFunctionPointer(requester, xOffset, yOffset, pixelWidth, (int)((Vector)(ref val)).Y, proSlideElementPixelCopyCallback, segmentCount, segmentSizes2, IntPtr.Zero);
			}
		}
		finally
		{
			gCHandle.Free();
		}
	}

	private void CopyPixels(nint pixelCopyUserData, int pixelWidth, int pixelHeight, int pixelStride, int segmentIndex, nint pixels)
	{
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			BitmapSource bitmapSource = BitmapSourceList[segmentIndex].BitmapSource;
			if (bitmapSource != null)
			{
				if (pixelWidth > bitmapSource.PixelWidth)
				{
					pixelWidth = Math.Min(pixelWidth, bitmapSource.PixelWidth);
					Log.Error($"pixelWidth - {pixelWidth} should not be greater than bitmap source PixelWidth - {bitmapSource.PixelWidth}");
				}
				if (pixelHeight > bitmapSource.PixelHeight)
				{
					pixelHeight = Math.Min(pixelHeight, bitmapSource.PixelHeight);
					Log.Error($"pixelHeight - {pixelHeight} should not be greater than bitmap source PixelHeight - {bitmapSource.PixelHeight}");
				}
				Int32Rect sourceRect = default(Int32Rect);
				((Int32Rect)(ref sourceRect))._002Ector(0, 0, pixelWidth, pixelHeight);
				int bufferSize = pixelStride * pixelHeight;
				bitmapSource.CopyPixels(sourceRect, pixels, bufferSize, pixelStride);
			}
		}
		catch (Exception ex)
		{
			Log.FatalError("CopyPixels failed with parameters {0} {1} {2} {3}", pixelWidth, pixelHeight, pixelStride, segmentIndex);
			Log.FatalError("Exception provided stack trace: {0}", ex.StackTrace);
			throw;
		}
	}

	protected override void OnDispose(bool disposeObjects)
	{
		if (disposeObjects)
		{
			BitmapSourceList?.ForEach(delegate(IBitmapHandle b)
			{
				b.Dispose();
			});
		}
	}
}
