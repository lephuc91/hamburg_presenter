using System;
using System.Text.Json.Serialization;

namespace ProPresenter.DO.Settings.Communication.Model;

internal sealed record MidiDeviceInfo([property: JsonPropertyName("id")] Guid Id, [property: JsonPropertyName("label")] string Label, [property: JsonPropertyName("reconnect")] bool Reconnect, [property: JsonPropertyName("activeInputs")] MidiConnectedDeviceInfo[] ActiveInputs, [property: JsonPropertyName("activeOutputs")] MidiConnectedDeviceInfo[] ActiveOutputs) : DeviceInfo();
