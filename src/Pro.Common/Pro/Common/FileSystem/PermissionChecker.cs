using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using Pro.Common.Utility;

namespace Pro.Common.FileSystem;

public static class PermissionChecker
{
	private static readonly SecurityIdentifier? _currentUser;

	private static readonly IdentityReference[] _currentUserGroups;

	static PermissionChecker()
	{
		WindowsIdentity current = WindowsIdentity.GetCurrent();
		_currentUser = current.User;
		_currentUserGroups = current.Groups?.ToArray() ?? Array.Empty<IdentityReference>();
	}

	public static bool HasReadPermission(string? directoryPath)
	{
		return HasPermission(directoryPath, FileSystemRights.Read);
	}

	public static bool HasWritePermission(string? directoryPath)
	{
		return HasPermission(directoryPath, FileSystemRights.Write);
	}

	public static bool HasReadWritePermission(string? directoryPath)
	{
		return HasPermission(directoryPath, FileSystemRights.Read | FileSystemRights.Write);
	}

	public static bool HasPermission(string? directoryPath, FileSystemRights rights)
	{
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		if (string.IsNullOrWhiteSpace(directoryPath))
		{
			return false;
		}
		try
		{
			FileSystemAccessRule[] array = ((IEnumerable)(object)new FileInfo(directoryPath).GetAccessControl().GetAccessRules(includeExplicit: true, includeInherited: true, typeof(SecurityIdentifier))).OfType<FileSystemAccessRule>().ToArray();
			foreach (FileSystemAccessRule fileSystemAccessRule in array)
			{
				if (!(fileSystemAccessRule.IdentityReference == _currentUser) && !_currentUserGroups.Contains(fileSystemAccessRule.IdentityReference))
				{
					continue;
				}
				switch (fileSystemAccessRule.AccessControlType)
				{
				case AccessControlType.Allow:
					if (fileSystemAccessRule.FileSystemRights.HasFlag(rights))
					{
						if (!fileSystemAccessRule.IsInherited)
						{
							flag = true;
						}
						else
						{
							flag3 = true;
						}
					}
					break;
				case AccessControlType.Deny:
					if (fileSystemAccessRule.FileSystemRights.AnyFlags(rights))
					{
						if (!fileSystemAccessRule.IsInherited)
						{
							flag2 = true;
						}
						else
						{
							flag4 = true;
						}
					}
					break;
				}
			}
		}
		catch
		{
			return false;
		}
		if (!flag || flag2)
		{
			if (!flag2 && flag3)
			{
				return !flag4;
			}
			return false;
		}
		return true;
	}
}
