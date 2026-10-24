using System.Text.Json.Serialization;

namespace ProPresenter.DO.Settings.Communication.Model;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(MidiDeviceInfo), 1)]
internal record DeviceInfo;
