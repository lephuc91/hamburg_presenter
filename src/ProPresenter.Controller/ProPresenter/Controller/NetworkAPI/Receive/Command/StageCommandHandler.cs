using System.Collections.Generic;
using System.Linq;
using Pro.DO.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Presentation;

namespace ProPresenter.Controller.NetworkAPI.Receive.Command;

public class StageCommandHandler : CommandHandlerBase
{
	private readonly StagePresentation _layouts;

	private readonly StageScreenArrangementCollection _stageScreens;

	public StageCommandHandler(ITriggering triggering, StagePresentation layouts, StageScreenArrangementCollection stageScreens)
		: base(triggering)
	{
		_layouts = layouts;
		_stageScreens = stageScreens;
	}

	public override void Handle(Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action command)
	{
		Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Stage stage = command.Stage;
		switch (stage.StageActionCase)
		{
		case Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Stage.StageActionOneofCase.Layouts:
			ChangeStageLayouts(stage.Layouts.Layouts.ParseIdentifierPairs());
			break;
		case Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Stage.StageActionOneofCase.Message:
			SendStageMessage(stage.Message);
			break;
		}
	}

	private void SendStageMessage(Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Stage.Types.StageMessage message)
	{
		switch (message.ActionCase)
		{
		case Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Stage.Types.StageMessage.ActionOneofCase.ShowMessage:
			base.Triggering.SendStageMessage(message.ShowMessage.Message);
			break;
		case Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Stage.Types.StageMessage.ActionOneofCase.HideMessage:
			base.Triggering.HideStageMessage();
			break;
		}
	}

	private void ChangeStageLayouts(IEnumerable<KeyValuePair<string, string>> layouts)
	{
		if (_layouts == null || _stageScreens == null)
		{
			return;
		}
		List<Stage.Types.ScreenAssignment> list = new List<Stage.Types.ScreenAssignment>();
		foreach (KeyValuePair<string, string> layout in layouts)
		{
			string screenId = layout.Key;
			string layoutId = layout.Value;
			int result;
			ScreenArrangementBase screenArrangementBase = (int.TryParse(screenId, out result) ? _stageScreens.ElementAtOrDefault(result) : _stageScreens.FirstOrDefault((ScreenArrangementBase s) => s.Name == screenId));
			if (screenArrangementBase != null)
			{
				int result2;
				ArrangedCue arrangedCue = (int.TryParse(layoutId, out result2) ? _layouts.DefaultArrangement.ArrangedCues.ElementAtOrDefault(result2) : _layouts.DefaultArrangement.ArrangedCues.FirstOrDefault((ArrangedCue s) => s.Name == layoutId));
				if (arrangedCue != null)
				{
					Stage.Types.ScreenAssignment item = new Stage.Types.ScreenAssignment
					{
						Screen = new CollectionElementType
						{
							ParameterUuid = new UUID
							{
								String = screenArrangementBase.ID.ToString()
							},
							ParameterName = screenArrangementBase.Name
						},
						Layout = new CollectionElementType
						{
							ParameterUuid = new UUID
							{
								String = arrangedCue.Source.ID.ToString()
							},
							ParameterName = arrangedCue.Source.Name
						}
					};
					list.Add(item);
				}
			}
		}
		base.Triggering.TriggerStageAction(list);
	}
}
