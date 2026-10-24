using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.OAuth;
using ProPresenter.DO.Capture;
using ProPresenter.DO.Resi;

namespace ProPresenter.DO.Actions.Capture;

public class CaptureValidator : ICaptureValidator
{
	private readonly ICaptureSettingsDocument? _captureSettingsDocument;

	private readonly IResiService? _resiService;

	public event Action? IsValidInvalidated;

	public CaptureValidator(ICaptureSettingsDocument captureSettingsDocument, IResiService resiService)
	{
		_captureSettingsDocument = captureSettingsDocument;
		_resiService = resiService;
		ICapturePresetCollection capturePresetCollection = captureSettingsDocument?.Presets;
		if (capturePresetCollection != null)
		{
			capturePresetCollection.CollectionChanged += Presets_CollectionChanged;
			capturePresetCollection.ForEach(delegate(ICapturePreset p)
			{
				p.PropertyChanged += Preset_PropertyChanged;
			});
		}
		if (_resiService != null)
		{
			_resiService.PropertyChanged += ResiService_PropertyChanged;
		}
	}

	private void Presets_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.OfType<ICapturePreset>().ForEach(delegate(ICapturePreset p)
		{
			p.PropertyChanged -= Preset_PropertyChanged;
		});
		e.NewItems?.OfType<ICapturePreset>().ForEach(delegate(ICapturePreset p)
		{
			p.PropertyChanged += Preset_PropertyChanged;
		});
		InvalidateIsValid();
	}

	private void InvalidateIsValid()
	{
		this.IsValidInvalidated?.Invoke();
	}

	private void Preset_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		switch (e.PropertyName)
		{
		case "DefaultStream":
		case "DiskDestination":
		case "RTMPDestination":
		case "ResiDestination":
			InvalidateIsValid();
			break;
		}
	}

	private void ResiService_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		switch (e.PropertyName)
		{
		case "AuthorizationState":
		case "PluginInstalled":
		case "AccountStatus":
			InvalidateIsValid();
			break;
		}
	}

	public bool GetIsValid(ICapture capture)
	{
		if (!(capture is CaptureStart captureStart))
		{
			if (capture is CaptureStop)
			{
				return true;
			}
			return false;
		}
		return GetIsValid(captureStart);
	}

	private bool GetIsValid(CaptureStart captureStart)
	{
		if (captureStart == null)
		{
			return false;
		}
		Identifier presetIdentifier = captureStart.PresetIdentifier;
		ICapturePreset capturePreset = ((!(presetIdentifier == Identifier.Empty)) ? _captureSettingsDocument?.Presets.FirstOrDefaultBy((ICapturePreset p) => p.ID == presetIdentifier.ID, (ICapturePreset p) => p.Name == presetIdentifier.Name) : _captureSettingsDocument?.ActivePreset);
		if (capturePreset != null)
		{
			bool flag = false;
			int num;
			switch (capturePreset.DefaultStream.DestinationType)
			{
			case DestinationType.Disk:
				flag = capturePreset.DiskDestination?.Location?.IsValid == true;
				break;
			case DestinationType.RTMP:
			{
				IRtmpDestination rTMPDestination = capturePreset.RTMPDestination;
				IDiskDestination diskDestination = capturePreset.DiskDestination;
				bool num2 = rTMPDestination != null && diskDestination != null;
				flag = rTMPDestination?.Address.IsValidAddress() ?? false;
				if (num2)
				{
					flag = flag && (diskDestination.Location?.IsValid ?? false);
				}
				break;
			}
			case DestinationType.Resi:
				{
					IResiDestination resiDestination = capturePreset.ResiDestination;
					if (resiDestination != null)
					{
						IResiService? resiService = _resiService;
						if (resiService != null && resiService.AuthorizationState == CredentialState.Authorized && _resiService.PluginInstalled && _resiService.AccountStatus == AccountStatus.Active)
						{
							num = (_resiService.ResiEncoderProfiles.Any(delegate(IEncoderProfile p)
							{
								Guid iD = p.ID;
								Guid? obj = resiDestination?.Profile;
								return iD == obj;
							}) ? 1 : 0);
							goto IL_01a7;
						}
					}
					num = 0;
					goto IL_01a7;
				}
				IL_01a7:
				flag = (byte)num != 0;
				break;
			}
			return flag;
		}
		return false;
	}
}
