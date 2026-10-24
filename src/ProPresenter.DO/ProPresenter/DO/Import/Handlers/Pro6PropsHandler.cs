using System.IO;
using Pro.Common.FileSystem;
using Pro.Common.Nullability;
using ProPresenter.DO.Import.Requests;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.DO.Import.Handlers;

internal class Pro6PropsHandler : Pro6DocumentHandler
{
	protected override ProMigrationType MigrationType => ProMigrationType.Prop;

	protected override string FileExtension => string.Empty;

	protected override bool CanHandleDocument(IImportRequest request)
	{
		string text = (request as FileImportRequest)?.Filename;
		if (!text.NullableIsNullOrWhiteSpace())
		{
			if (text.IsPro6DocumentFile())
			{
				return Path.GetFileNameWithoutExtension(text).Equals("Props");
			}
			return false;
		}
		return false;
	}
}
