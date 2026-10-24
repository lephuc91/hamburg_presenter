using System;
using System.IO;
using System.Linq;
using Pro.Common.Mathematics;
using Pro.Common.Security;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.CoreApplication.Media;
using Pro.DO.Effects;
using Pro.DO.Effects.Descriptions;
using Pro.SerializationInterop.RVProtoData.MediaManagement.v1;
using Pro.SerializationInterop.RVProtoData.MediaManagement.v2;

namespace ProPresenter.DO.Media;

public class MediaMetadataRequest
{
	public string ContainerID { get; }

	public Guid TargetID { get; }

	public string Filename { get; }

	public TimeSlice Time { get; }

	public EffectsCollection? Effects { get; }

	public CropInsets Insets { get; }

	public bool FlipVertically { get; }

	public bool FlipHorizontally { get; }

	public NativeRotation NativeRotation { get; set; }

	public bool IsImport { get; }

	public bool NativeRotationInitialized { get; }

	public bool FullSizeImage { get; }

	public AlphaType AlphaType { get; }

	public Vector2<double>? ThumbnailSizeOverride { get; }

	public bool WasRequestUserInitiated { get; }

	public string? ProContentDownloadId { get; }

	public MediaMetadataRequest(string containerId, Guid targetID, string filename, TimeSlice time, EffectsCollection? effects, CropInsets insets, bool flipVertically, bool flipHorizontally, NativeRotation nativeRotation, bool isImport, bool nativeRotationInitialized = true, bool fullSizeImage = false, AlphaType alphaType = AlphaType.Straight, Vector2<double>? thumbnailSizeOverride = null, bool wasRequestUserInitiated = false, string? proContentDownloadId = null)
	{
		ContainerID = containerId;
		TargetID = targetID;
		Filename = filename;
		Time = time;
		Effects = effects;
		Insets = insets;
		FlipVertically = flipVertically;
		FlipHorizontally = flipHorizontally;
		NativeRotation = nativeRotation;
		FullSizeImage = fullSizeImage;
		IsImport = isImport;
		NativeRotationInitialized = nativeRotationInitialized;
		AlphaType = alphaType;
		ThumbnailSizeOverride = thumbnailSizeOverride;
		WasRequestUserInitiated = wasRequestUserInitiated;
		ProContentDownloadId = proContentDownloadId;
	}

	public string BuildKey()
	{
		return Filename.Hash();
	}

	public string BuildFingerprint()
	{
		string text = ((Effects != null) ? string.Join("|", from fx in Effects
			where fx.IsEnabled
			select $"{fx.EffectDescription?.ID}-{string.Join("+", fx.EffectDescription?.Parameters.Select((ParameterDescriptionBase p) => p.Name + "=" + fx.GetValueAsString(p)).ToArray() ?? Array.Empty<string>())}") : "NO_FX");
		global::_003C_003Ey__InlineArray11<object> buffer = default(global::_003C_003Ey__InlineArray11<object>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray11<object>, object>(ref buffer, 0) = text;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray11<object>, object>(ref buffer, 1) = (long)Math.Round(Time.TotalSeconds);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray11<object>, object>(ref buffer, 2) = (long)Math.Round(Insets.Left);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray11<object>, object>(ref buffer, 3) = (long)Math.Round(Insets.Top);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray11<object>, object>(ref buffer, 4) = (long)Math.Round(Insets.Right);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray11<object>, object>(ref buffer, 5) = (long)Math.Round(Insets.Bottom);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray11<object>, object>(ref buffer, 6) = FlipVertically;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray11<object>, object>(ref buffer, 7) = FlipHorizontally;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray11<object>, object>(ref buffer, 8) = (int)NativeRotation;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray11<object>, object>(ref buffer, 9) = FullSizeImage;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray11<object>, object>(ref buffer, 10) = AlphaType.ToString();
		string text2 = string.Join("|", global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray11<object>, object>(in buffer, 11));
		if (ThumbnailSizeOverride.HasValue)
		{
			text2 += $"|{ThumbnailSizeOverride.Value}";
		}
		try
		{
			FileInfo fileInfo = new FileInfo(Filename);
			string data;
			if (!fileInfo.Exists)
			{
				global::_003C_003Ey__InlineArray3<string> buffer2 = default(global::_003C_003Ey__InlineArray3<string>);
				global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray3<string>, string>(ref buffer2, 0) = text2;
				global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray3<string>, string>(ref buffer2, 1) = Filename;
				global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray3<string>, string>(ref buffer2, 2) = "NOT_FOUND";
				data = string.Join("|", global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray3<string>, string>(in buffer2, 3));
			}
			else
			{
				global::_003C_003Ey__InlineArray6<object> buffer3 = default(global::_003C_003Ey__InlineArray6<object>);
				global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray6<object>, object>(ref buffer3, 0) = text2;
				global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray6<object>, object>(ref buffer3, 1) = Filename;
				global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray6<object>, object>(ref buffer3, 2) = "EXISTS";
				global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray6<object>, object>(ref buffer3, 3) = fileInfo.Length;
				global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray6<object>, object>(ref buffer3, 4) = fileInfo.CreationTimeUtc.ToUnixTimestamp();
				global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray6<object>, object>(ref buffer3, 5) = fileInfo.LastWriteTimeUtc.ToUnixTimestamp();
				data = string.Join("|", global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray6<object>, object>(in buffer3, 6));
			}
			return data.Hash();
		}
		catch
		{
			global::_003C_003Ey__InlineArray3<string> buffer4 = default(global::_003C_003Ey__InlineArray3<string>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray3<string>, string>(ref buffer4, 0) = text2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray3<string>, string>(ref buffer4, 1) = Filename;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray3<string>, string>(ref buffer4, 2) = "INVALID_FILENAME";
			return string.Join("|", global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray3<string>, string>(in buffer4, 3)).Hash();
		}
	}

	public Pro.SerializationInterop.RVProtoData.MediaManagement.v1.AddMediaReference ToAddMediaRequestV1(bool includeTransformation)
	{
		return new Pro.SerializationInterop.RVProtoData.MediaManagement.v1.AddMediaReference
		{
			Uuid = TargetID.ToString(),
			Url = Filename,
			Priority = (WasRequestUserInitiated ? Pro.SerializationInterop.RVProtoData.MediaManagement.v1.Priority.UserInitiated : Pro.SerializationInterop.RVProtoData.MediaManagement.v1.Priority.Background),
			Transformation = (includeTransformation ? ToTransformationV1() : null)
		};
	}

	public Pro.SerializationInterop.RVProtoData.MediaManagement.v2.AddMediaReference ToAddMediaRequestV2(bool includeTransformation)
	{
		return new Pro.SerializationInterop.RVProtoData.MediaManagement.v2.AddMediaReference
		{
			Id = new ReferenceIdentifier
			{
				ContainerId = ContainerID,
				Uuid = TargetID.ToString()
			},
			Url = Filename,
			Priority = (WasRequestUserInitiated ? Pro.SerializationInterop.RVProtoData.MediaManagement.v2.Priority.UserInitiated : Pro.SerializationInterop.RVProtoData.MediaManagement.v2.Priority.Background),
			Transformation = (includeTransformation ? ToTransformationV2() : null)
		};
	}

	public Pro.SerializationInterop.RVProtoData.MediaManagement.v1.ApplyTransformation ToApplyTransformRequestV1()
	{
		return new Pro.SerializationInterop.RVProtoData.MediaManagement.v1.ApplyTransformation
		{
			Uuid = TargetID.ToString(),
			Transformation = ToTransformationV1(),
			Priority = (WasRequestUserInitiated ? Pro.SerializationInterop.RVProtoData.MediaManagement.v1.Priority.UserInitiated : Pro.SerializationInterop.RVProtoData.MediaManagement.v1.Priority.Background)
		};
	}

	public Pro.SerializationInterop.RVProtoData.MediaManagement.v2.ApplyTransformation ToApplyTransformRequestV2()
	{
		return new Pro.SerializationInterop.RVProtoData.MediaManagement.v2.ApplyTransformation
		{
			Id = new ReferenceIdentifier
			{
				ContainerId = ContainerID,
				Uuid = TargetID.ToString()
			},
			Transformation = ToTransformationV2(),
			Priority = (WasRequestUserInitiated ? Pro.SerializationInterop.RVProtoData.MediaManagement.v2.Priority.UserInitiated : Pro.SerializationInterop.RVProtoData.MediaManagement.v2.Priority.Background)
		};
	}

	public Pro.SerializationInterop.RVProtoData.MediaManagement.v1.Transformation ToTransformationV1()
	{
		Vector2<uint> vector = (ThumbnailSizeOverride?.Cast<int>() ?? (FullSizeImage ? MediaThumbnailSize.FullPreviewSize : MediaThumbnailSize.SmallPreviewSize)).Cast<uint>();
		Pro.SerializationInterop.RVProtoData.MediaManagement.v1.Transformation transformation = new Pro.SerializationInterop.RVProtoData.MediaManagement.v1.Transformation
		{
			Position = (float)Time.TotalSeconds,
			Rotation = (int)NativeRotation.GetValue(),
			Width = vector.X,
			Height = vector.Y,
			InsetsTop = (float)Insets.Top,
			InsetsRight = (float)Insets.Right,
			InsetsBottom = (float)Insets.Bottom,
			InsetsLeft = (float)Insets.Left,
			FlipHorizontally = FlipHorizontally,
			FlipVertically = FlipVertically,
			AlphaType = AlphaType.ToProtoAlphaType(),
			UseDefaultNativeRotation = !NativeRotationInitialized
		};
		if (Effects != null)
		{
			transformation.Effects.AddRange(Effects?.Select((EffectParameters e) => e.Serialize()));
		}
		return transformation;
	}

	public Pro.SerializationInterop.RVProtoData.MediaManagement.v2.Transformation ToTransformationV2()
	{
		Vector2<uint> vector = (ThumbnailSizeOverride?.Cast<int>() ?? (FullSizeImage ? MediaThumbnailSize.FullPreviewSize : MediaThumbnailSize.SmallPreviewSize)).Cast<uint>();
		Pro.SerializationInterop.RVProtoData.MediaManagement.v2.Transformation transformation = new Pro.SerializationInterop.RVProtoData.MediaManagement.v2.Transformation
		{
			Position = (float)Time.TotalSeconds,
			Rotation = (int)NativeRotation.GetValue(),
			Width = vector.X,
			Height = vector.Y,
			InsetsTop = (float)Insets.Top,
			InsetsRight = (float)Insets.Right,
			InsetsBottom = (float)Insets.Bottom,
			InsetsLeft = (float)Insets.Left,
			FlipHorizontally = FlipHorizontally,
			FlipVertically = FlipVertically,
			AlphaType = AlphaType.ToProtoAlphaType(),
			UseDefaultNativeRotation = !NativeRotationInitialized
		};
		if (Effects != null)
		{
			transformation.Effects.AddRange(Effects?.Select((EffectParameters e) => e.Serialize()));
		}
		return transformation;
	}
}
