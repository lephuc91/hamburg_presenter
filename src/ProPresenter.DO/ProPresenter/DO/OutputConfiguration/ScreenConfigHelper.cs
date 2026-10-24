using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Strings;
using Pro.Common.Utility;
using Pro.Localization;
using Pro.UI.DialogService;

namespace ProPresenter.DO.OutputConfiguration;

public static class ScreenConfigHelper
{
	public static void UpdatePlaceholderDeviceName(IEnumerable<PlaceholderDevice> placeholderDevices, PlaceholderDevice? targetDevice, PlaceholderDevice? newDevice)
	{
		IEnumerable<PlaceholderDevice> enumerable = placeholderDevices;
		int num = (from d in enumerable
			group d by d).FirstOrDefault((IGrouping<PlaceholderDevice, PlaceholderDevice> g) => g.Key == targetDevice)?.Count() ?? 0;
		if (targetDevice != null && num == 1)
		{
			enumerable = enumerable.Except<PlaceholderDevice>(targetDevice);
		}
		if (newDevice != null && !enumerable.Contains<PlaceholderDevice>(newDevice))
		{
			newDevice.PlaceholderDeviceName = newDevice.PlaceholderDeviceName.DuplicateName(enumerable, (PlaceholderDevice d) => d.Name);
		}
	}

	public static AssignOutputButtons? ShowConflictDialog()
	{
		return MessageDialogService.ShowDialog(LocalizedStrings.Get("SCREEN_CONFIGURATION_CONFLICT_ALERT_title"), LocalizedStrings.Get("SCREEN_CONFIGURATION_CONFLICT_ALERT_subtext"), AssignOutputButtons.Cancel | AssignOutputButtons.AssignToAll | AssignOutputButtons.ReassignToNew, AssignOutputButtons.ReassignToNew);
	}

	public static bool CanAssignDevice(IDevice? device, IDeviceMode? mode, HardwareScreenRectangleOptions? targetRectangle)
	{
		if (device != null)
		{
			if (device == targetRectangle?.OutputDevice)
			{
				if (device == targetRectangle.OutputDevice)
				{
					return device.DeviceMode != mode;
				}
				return false;
			}
			return true;
		}
		return false;
	}

	public static void AssignDevice(IEnumerable<ScreenArrangementBase> screenArrangements, IEnumerable<IDevice> tempDevices, ScreenTargetType? screenTargetType, HardwareScreenRectangleOptions? targetRectangle, IDevice device, IDeviceMode? mode, Action<IDevice> addArrangementCallback, AssignOutputButtons defaultConflict = AssignOutputButtons.Cancel)
	{
		UpdatePlaceholderDeviceName(screenArrangements.GetDevices().Concat(tempDevices).OfType<PlaceholderDevice>(), targetRectangle?.OutputDevice as PlaceholderDevice, device as PlaceholderDevice);
		HardwareScreenRectangleOptions[] conflictingRectangles = screenArrangements.GetConflictingRectangles(device, targetRectangle);
		if (conflictingRectangles.Any() && (screenArrangements.Any((ScreenArrangementBase a) => a.Screens.SelectMany((Screen s) => s.HardwareRectangles).Contains<HardwareScreenRectangleOptions>(targetRectangle)) || screenTargetType.HasValue))
		{
			AssignOutputButtons? assignOutputButtons = defaultConflict;
			if (!UnitTestDetector.IsInUnitTest)
			{
				assignOutputButtons = ShowConflictDialog();
			}
			if (!assignOutputButtons.HasValue || assignOutputButtons.Value == AssignOutputButtons.Cancel)
			{
				return;
			}
			if (assignOutputButtons.Value == AssignOutputButtons.ReassignToNew)
			{
				conflictingRectangles.ForEach(delegate(HardwareScreenRectangleOptions s)
				{
					s.OutputDevice = null;
				});
			}
			assignDevice();
		}
		else
		{
			assignDevice();
		}
		void assignDevice()
		{
			if (screenTargetType.HasValue)
			{
				addArrangementCallback?.Invoke(device);
			}
			else if (targetRectangle != null)
			{
				targetRectangle.OutputDevice = device;
			}
			if (device.DeviceType != DeviceType.Placeholder && mode is DeviceMode mode2)
			{
				device.ChangeMode(mode2);
			}
		}
	}

	public static IEnumerable<IDevice> GetDevices(this IEnumerable<ScreenArrangementBase> screenArrangements)
	{
		return (from r in screenArrangements.GetConfiguredHardwareRectanglesIncludingPlaceholders()
			select r.OutputDevice).NonNull();
	}

	public static IEnumerable<HardwareScreenRectangleOptions> GetConfiguredHardwareRectangles(this IEnumerable<ScreenArrangementBase> screenArrangements)
	{
		return from r in screenArrangements.GetConfiguredHardwareRectanglesIncludingPlaceholders()
			where !(r.OutputDevice is PlaceholderDevice)
			select r;
	}

	public static HardwareScreenRectangleOptions[] GetConflictingRectangles(this IEnumerable<ScreenArrangementBase> screenArrangements, IDevice device, HardwareScreenRectangleOptions? targetRectangle)
	{
		return (from s in screenArrangements.GetConfiguredHardwareRectangles()
			where s.OutputDevice == device && s != targetRectangle
			select s).ToArray();
	}

	private static IEnumerable<HardwareScreenRectangleOptions> GetConfiguredHardwareRectanglesIncludingPlaceholders(this IEnumerable<ScreenArrangementBase> screenArrangements)
	{
		return from r in screenArrangements.SelectMany((ScreenArrangementBase a) => a.Screens).SelectMany((Screen s) => s.HardwareRectangles)
			where r.IsConfigured
			select r;
	}
}
