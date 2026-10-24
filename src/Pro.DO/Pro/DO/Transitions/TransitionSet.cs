using System.Collections.Generic;
using System.Linq;
using Pro.Common.FeatureFlag;
using Pro.DO.Transitions.Descriptions;
using Pro.DO.Transitions.Favorite;
using Pro.DO.Transitions.Recent;
using Pro.DO.Transitions.Standard;
using Pro.Entity;
using Pro.Entity.Persistence;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Transitions;

public class TransitionSet : ITransitionSet
{
	public StandardTransitionCollection? StandardTransitions { get; }

	public FavoriteTransitionCollection FavoriteTransitions { get; }

	public RecentTransitionCollection RecentTransitions { get; }

	public TransitionBase? CutTransition { get; }

	public TransitionBase? AutoTransition { get; }

	public TransitionSet(ISyncDataFactory syncDataFactory, ITransitionDescriptionCollection transitionDescriptions, IEnumerable<Transition.Types.Preset> recentTransitions, IWorkspacePathProvider workspaceSwitcher, IFlagService flagService, ICollectionStorage collectionStorage, IEntityDocumentSyncerFactory entityDocumentSyncerFactory, IEntityFactory entityFactory)
	{
		StandardTransitions = new StandardTransitionCollection(transitionDescriptions);
		FavoriteTransitions = new FavoriteTransitionCollection(syncDataFactory, transitionDescriptions, workspaceSwitcher, flagService, collectionStorage, entityDocumentSyncerFactory, entityFactory);
		RecentTransitions = new RecentTransitionCollection(transitionDescriptions, recentTransitions);
		CutTransition = StandardTransitions.FirstOrDefault((StandardTransition t) => t.Preset.Parameters != null && t.Preset.Parameters.EffectDescription != null && t.Preset.Parameters.EffectDescription.ID == TransitionDescription.CutTransitionID) ?? StandardTransitions.FirstOrDefault();
		AutoTransition = StandardTransitions.FirstOrDefault((StandardTransition t) => t.Preset.Parameters != null && t.Preset.Parameters.EffectDescription != null && t.Preset.Parameters.EffectDescription.ID == TransitionDescription.AutoTransitionID) ?? StandardTransitions.FirstOrDefault();
	}
}
