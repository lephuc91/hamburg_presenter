using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Logging;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Transitions.Recent;

public class RecentTransitionCollection : TransitionCollectionBase<RecentTransition>
{
	private const int MaxRecentTransitionCount = 4;

	internal RecentTransitionCollection(ITransitionDescriptionCollection transitionDescriptions, IEnumerable<Transition.Types.Preset> recentTransitionData)
	{
		List<RecentTransition> list = new List<RecentTransition>();
		foreach (Transition.Types.Preset recentTransitionDatum in recentTransitionData)
		{
			try
			{
				list.Add(new RecentTransition(transitionDescriptions, recentTransitionDatum));
			}
			catch (Exception exception)
			{
				Log.Error(exception);
			}
		}
		base.Collection.AddRange(list);
	}

	public RecentTransition Add(string name, TransitionParameters parameters)
	{
		RecentTransition recentTransition = base.Collection.FirstOrDefault((RecentTransition t) => t.Preset.Parameters != null && t.Preset.Parameters.Equals(parameters, ignoreDuration: false, ignoreName: true) && t.Preset.Name == name);
		if (recentTransition == null)
		{
			base.Collection.RemoveIf((RecentTransition t) => parameters.TransitionDescription != null && t.Preset.Parameters?.TransitionDescription != null && t.Preset.Parameters.TransitionDescription.ID == parameters.TransitionDescription.ID);
			recentTransition = new RecentTransition(new TransitionPreset(name, parameters, canRename: true));
			base.Collection.Insert(0, recentTransition);
			while (base.Collection.Count > 4)
			{
				base.Collection.RemoveAt(base.Collection.Count - 1);
			}
		}
		else
		{
			base.Collection.Move(base.Collection.IndexOf(recentTransition), 0);
		}
		return recentTransition;
	}

	internal void Clear()
	{
		base.Collection.Clear();
	}
}
