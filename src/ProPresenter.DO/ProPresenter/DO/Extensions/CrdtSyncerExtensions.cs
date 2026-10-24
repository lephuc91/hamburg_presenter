using System;
using Pro.Common.ObjectBinding;
using Pro.Entity;
using Pro.Entity.Persistence;

namespace ProPresenter.DO.Extensions;

internal static class CrdtSyncerExtensions
{
	public static IEntityDocumentSyncer<TDocument> CreateConfigurationSyncer<TDocument>(this IEntityDocSyncerFactory<TDocument> factory, string fileName, Func<TDocument, IReadOnlyObjectBinder> bind, Func<byte[]> serialize, Action<byte[]> deserialize, Action loadDefaults, bool loadLegacy) where TDocument : IEntityDocument
	{
		return factory.CreateFileSyncer(CommonPaths.Configuration, fileName, bind, serialize, deserialize, loadDefaults, loadLegacy);
	}

	public static IEntityDocumentSyncer<TDocument> CreateFileSyncer<TDocument>(this IEntityDocSyncerFactory<TDocument> factory, string containingFolder, string fileName, Func<TDocument, IReadOnlyObjectBinder> bind, Func<byte[]> serialize, Action<byte[]> deserialize, Action loadDefaults, bool loadLegacy) where TDocument : IEntityDocument
	{
		if (!loadLegacy)
		{
			return factory.CreateSyncerFromCrdt(containingFolder, fileName, string.Empty, delegate(TDocument doc, bool fromModel)
			{
				IReadOnlyObjectBinder readOnlyObjectBinder = bind(doc);
				doc.RegisterLinkedDisposable(readOnlyObjectBinder);
				if (fromModel)
				{
					readOnlyObjectBinder.InitializeRightFromLeft();
				}
				else
				{
					readOnlyObjectBinder.InitializeLeftFromRight();
				}
			}, serialize, loadDefaults);
		}
		return factory.CreateSyncerFromLegacy(containingFolder, fileName, string.Empty, delegate(TDocument doc)
		{
			IReadOnlyObjectBinder readOnlyObjectBinder2 = bind(doc);
			doc.RegisterLinkedDisposable(readOnlyObjectBinder2);
			readOnlyObjectBinder2.InitializeRightFromLeft();
		}, serialize, delegate(byte[] data)
		{
			deserialize(data);
			return (Guid?)null;
		}, loadDefaults);
	}
}
