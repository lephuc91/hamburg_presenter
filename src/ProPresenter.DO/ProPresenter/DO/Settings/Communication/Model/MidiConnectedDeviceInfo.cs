using System.Text.Json.Serialization;

namespace ProPresenter.DO.Settings.Communication.Model;

internal sealed record MidiConnectedDeviceInfo([property: JsonPropertyName("name")] string Name, [property: JsonPropertyName("manufacturerID")] ushort ManufacturerID, [property: JsonPropertyName("productID")] ushort ProductID, [property: JsonPropertyName("driverVersion")] uint DriverVersion);
