using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Pro.UI.Controls;
using ProPresenter.Controller;
using ProPresenter.UI.ViewModels.Preview;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.ViewModels.Preview;

public class OutputPreviewVM : ObservableObject, IOutputPreviewVM, INotifyPropertyChanged
{
	private readonly RenderViewType _renderViewType;

	private readonly ICoreManager _coreManager;

	[ObservableProperty]
	private double _aspectRatio = 1.7777777777777777;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<RequestRenderParameter>? requestRenderCommand;

	public bool IsLegacyRenderMode => _renderViewType != RenderViewType.Inspector;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public double AspectRatio
	{
		get
		{
			return _aspectRatio;
		}
		set
		{
			if (!EqualityComparer<double>.Default.Equals(_aspectRatio, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.AspectRatio);
				_aspectRatio = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.AspectRatio);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<RequestRenderParameter> RequestRenderCommand => requestRenderCommand ?? (requestRenderCommand = new RelayCommand<RequestRenderParameter>(RequestRender));

	public OutputPreviewVM(RenderViewType renderViewType, ICoreManager coreManager)
	{
		_renderViewType = renderViewType;
		_coreManager = coreManager;
	}

	public nint LoadPreview(nint hostHandle)
	{
		CreateRenderViewParameters createRenderViewParameters = new CreateRenderViewParameters(_renderViewType, hostHandle);
		_coreManager.CreateRenderView(createRenderViewParameters);
		return createRenderViewParameters.RenderViewHandle;
	}

	public void UnloadPreview(nint renderViewHandle)
	{
		DestroyRenderViewParameters destroyParams = new DestroyRenderViewParameters(renderViewHandle);
		_coreManager.DestroyRenderView(destroyParams);
	}

	[RelayCommand]
	private void RequestRender(RequestRenderParameter renderParam)
	{
		_coreManager.ProCore.RenderOutputPreview(ToProRenderViewType(_renderViewType), renderParam.Texture, renderParam.TextureSize.X, renderParam.TextureSize.Y);
	}

	private static ProRenderViewType ToProRenderViewType(RenderViewType renderViewType)
	{
		return renderViewType switch
		{
			RenderViewType.Preview => ProRenderViewType.LeadingSidebar, 
			RenderViewType.Inspector => ProRenderViewType.Inspector, 
			RenderViewType.InputPreferenceTab => ProRenderViewType.VideoInputPreferenceTab, 
			_ => ProRenderViewType.Unknown, 
		};
	}
}
