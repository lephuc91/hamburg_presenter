using System.ComponentModel;

namespace Pro.Common.Win32;

public enum SHFILEOPERROR : uint
{
	[Description("Success")]
	DE_SUCCESS = 0u,
	[Description("The source and destination files are the same file.")]
	DE_SAMEFILE = 113u,
	[Description("Multiple file paths were specified in the source buffer, but only one destination file path.")]
	DE_MANYSRC1DEST = 114u,
	[Description("Rename operation was specified but the destination path is a different directory. Use the move operation instead.")]
	DE_DIFFDIR = 115u,
	[Description("The source is a root directory, which cannot be moved or renamed.")]
	DE_ROOTDIR = 116u,
	[Description("The operation was canceled by the user, or silently canceled if the appropriate flags were supplied to SHFileOperation.")]
	DE_OPCANCELLED = 117u,
	[Description("The destination is a subtree of the source.")]
	DE_DESTSUBTREE = 118u,
	[Description("Security settings denied access to the source.")]
	DE_ACCESSDENIEDSRC = 120u,
	[Description("The source or destination path exceeded or would exceed MAX_PATH.")]
	DE_PATHTOODEEP = 121u,
	[Description("The operation involved multiple destination paths, which can fail in the case of a move operation.")]
	DE_MANYDEST = 122u,
	[Description("The path in the source or destination or both was invalid.")]
	DE_INVALIDFILES = 124u,
	[Description("The source and destination have the same parent folder.")]
	DE_DESTSAMETREE = 125u,
	[Description("The destination path is an existing file.")]
	DE_FLDDESTISFILE = 126u,
	[Description("The destination path is an existing folder.")]
	DE_FILEDESTISFLD = 128u,
	[Description("The name of the file exceeds MAX_PATH.")]
	DE_FILENAMETOOLONG = 129u,
	[Description("The destination is a read-only CD-ROM, possibly unformatted.")]
	DE_DEST_IS_CDROM = 130u,
	[Description("The destination is a read-only DVD, possibly unformatted.")]
	DE_DEST_IS_DVD = 131u,
	[Description("The destination is a writable CD-ROM, possibly unformatted.")]
	DE_DEST_IS_CDRECORD = 132u,
	[Description("The file involved in the operation is too large for the destination media or file system.")]
	DE_FILE_TOO_LARGE = 133u,
	[Description("The source is a read-only CD-ROM, possibly unformatted.")]
	DE_SRC_IS_CDROM = 134u,
	[Description("The source is a read-only DVD, possibly unformatted.")]
	DE_SRC_IS_DVD = 135u,
	[Description("The source is a writable CD-ROM, possibly unformatted.")]
	DE_SRC_IS_CDRECORD = 136u,
	[Description("MAX_PATH was exceeded during the operation.")]
	DE_ERROR_MAX = 183u,
	[Description("An unknown error occurred. This is typically due to an invalid path in the source or destination. This error does not occur on Windows Vista and later.")]
	DE_ERROR_UNKNOWN = 1026u,
	[Description("An unspecified error occurred on the destination.")]
	ERRORONDEST = 65536u,
	[Description("Destination is a root directory and cannot be renamed.")]
	DE_ROOTDIR_ERRORONDEST = 65652u
}
