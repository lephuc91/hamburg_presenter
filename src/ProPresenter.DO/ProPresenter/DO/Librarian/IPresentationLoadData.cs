using System;
using Pro.Common.FileSystem;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.Librarian;

public interface IPresentationLoadData
{
	string? Filename { get; set; }

	Pro.SerializationInterop.RVProtoData.Presentation? ProtoData { get; }

	Guid? PresentationID { get; }

	PresentationType PresentationType { get; }

	OutputDestination? PresentationDestination { get; }

	string? PresentationActiveArrangementName { get; }

	DateTime? PresentationLastUsed { get; }

	DateTime? PresentationLastModified { get; }

	byte[]? CopyrightInfoData { get; }

	FileIOResult WriteProtoData(string filename);

	void UpdateProtoData(Pro.SerializationInterop.RVProtoData.Presentation protoData);
}
