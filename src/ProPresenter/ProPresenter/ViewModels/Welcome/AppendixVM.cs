using System;
using System.CodeDom.Compiler;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.HTTP;
using ProPresenter.DO.Analytics.Events.Welcome;
using ProPresenter.DO.Web;
using ProPresenter.UI.ViewModels.Welcome;

namespace ProPresenter.ViewModels.Welcome;

public class AppendixVM : IAppendixVM
{
	private readonly IWelcomeAnalyticEventsPublisher _analytics;

	private readonly IHyperlinkService _hyperlinkService;

	private readonly IWebSourceProvider _webSourceProvider;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? tutorialsCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? userGroupCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? instagramCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? facebookCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? knowledgeBaseCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? blogCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand TutorialsCommand => tutorialsCommand ?? (tutorialsCommand = new RelayCommand(Tutorials));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand UserGroupCommand => userGroupCommand ?? (userGroupCommand = new RelayCommand(UserGroup));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand InstagramCommand => instagramCommand ?? (instagramCommand = new RelayCommand(Instagram));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand FacebookCommand => facebookCommand ?? (facebookCommand = new RelayCommand(Facebook));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand KnowledgeBaseCommand => knowledgeBaseCommand ?? (knowledgeBaseCommand = new RelayCommand(KnowledgeBase));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand BlogCommand => blogCommand ?? (blogCommand = new RelayCommand(Blog));

	public AppendixVM(IWelcomeAnalyticEventsPublisher analytics, IHyperlinkService hyperlinkService, IWebSourceProvider webSourceProvider)
	{
		_analytics = analytics;
		_hyperlinkService = hyperlinkService;
		_webSourceProvider = webSourceProvider;
	}

	[RelayCommand]
	private void Tutorials()
	{
		GotoLink(_webSourceProvider.Tutorials, _analytics.TutorialsViewedEvent);
	}

	[RelayCommand]
	private void UserGroup()
	{
		GotoLink(_webSourceProvider.UserGroup, _analytics.UserGroupViewed);
	}

	[RelayCommand]
	private void Instagram()
	{
		GotoLink(_webSourceProvider.GenerateLink(ResourceType.SMInstagram), _analytics.InstagramViewedEvent);
	}

	[RelayCommand]
	private void Facebook()
	{
		GotoLink(_webSourceProvider.GenerateLink(ResourceType.SMFacebook), _analytics.FacebookViewedEvent);
	}

	[RelayCommand]
	private void KnowledgeBase()
	{
		GotoLink(_webSourceProvider.KnowledgeBase, _analytics.KnowledgeBaseViewedEvent);
	}

	[RelayCommand]
	private void Blog()
	{
		GotoLink(_webSourceProvider.Blog, _analytics.BlogViewedEvent);
	}

	private void GotoLink(Uri link, Action analytics)
	{
		analytics();
		_hyperlinkService.Open(link);
	}
}
