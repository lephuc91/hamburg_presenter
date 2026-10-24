using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.SourceGenerator.Attributes;
using Pro.DO;
using Pro.DO.Utility;
using Pro.Serialization.DataManagement;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.ChangeDirectory;
using ProPresenter.DO.TestPattern.Properties;
using ProPresenter.DO.TestPattern.State;

namespace ProPresenter.DO.TestPattern;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_syncedData" })]
public class TestPatternPersistence : ITestPatternPersistence, IDisposable
{
	private IProtoSyncedData<TestPatternDocument>? _syncedData;

	private TestPatternDocument? _document;

	private bool _patternsLoaded;

	private bool _stateLoaded;

	private readonly ISyncDataFactory _syncDataFactory;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public TestPatternPersistence(ISyncDataFactory syncDataFactory)
	{
		_syncDataFactory = syncDataFactory;
		SetupDocumentSyncer(loadLegacy: true);
		ChangeDirectoryPrompt.RegisterDelegate(new ChangeDirectoryListener(TeardownDocumentSyncer, SetupDocumentSyncer));
	}

	private void TeardownDocumentSyncer()
	{
		_syncedData?.Dispose();
		_syncedData = null;
	}

	private void SetupDocumentSyncer(bool loadLegacy)
	{
		_syncedData = _syncDataFactory.GetSyncedData(CommonPaths.Configuration, "TestPatterns", DataUpdated, delegate
		{
		}, (ProtoSyncedData<TestPatternDocument> s, string f, TestPatternDocument? d) => true);
	}

	private void DataUpdated(TestPatternDocument document)
	{
		_document = document;
	}

	public void LoadTestPatterns(IEnumerable<ITestPatternDefinition> testPatterns)
	{
		if (_document == null || testPatterns == null || testPatterns.Empty())
		{
			_patternsLoaded = true;
			return;
		}
		foreach (ITestPatternDefinition pattern in testPatterns)
		{
			TestPatternDocument.Types.TestPatternData testPatternData = _document.Patterns.FirstOrDefaultBy((TestPatternDocument.Types.TestPatternData t) => t.Uuid.ToGuid() == pattern.ID, (TestPatternDocument.Types.TestPatternData t) => t.NameLocalizationKey == pattern.Name);
			if (testPatternData == null)
			{
				continue;
			}
			foreach (ITestPatternProperty property in pattern.Properties)
			{
				TestPatternDocument.Types.TestPatternData.Types.Property property2 = testPatternData.Properties.FirstOrDefault((TestPatternDocument.Types.TestPatternData.Types.Property p) => p.PropertyTypeCase.ToPropertyType() == property.Type && p.NameLocalizationKey == property.Name);
				if (property2 != null)
				{
					property.DeserializeValue(property2);
				}
			}
		}
		_patternsLoaded = true;
	}

	public void LoadState(ITestPatternState state, IEnumerable<ITestPatternDefinition> testPatterns)
	{
		if (_document?.State == null || state == null)
		{
			_stateLoaded = true;
			return;
		}
		state.Deserialize(_document.State);
		ITestPatternDefinition testPatternDefinition = testPatterns.FirstOrDefaultBy((ITestPatternDefinition t) => t.ID == _document.State.TestPatternId.ToGuid(), (ITestPatternDefinition t) => t.Name == _document.State.TestPatternNameLocalizationKey);
		if (testPatternDefinition != null)
		{
			state.Pattern = testPatternDefinition;
		}
		_stateLoaded = true;
	}

	public void Save(ITestPatternState? state, IEnumerable<ITestPatternDefinition> testPatterns)
	{
		if (!_patternsLoaded || !_stateLoaded)
		{
			return;
		}
		TestPatternDocument testPatternDocument = new TestPatternDocument
		{
			State = state?.SerializeData()
		};
		foreach (ITestPatternDefinition testPattern in testPatterns)
		{
			TestPatternDocument.Types.TestPatternData testPatternData = new TestPatternDocument.Types.TestPatternData
			{
				Uuid = testPattern.ID.ToUUID(),
				NameLocalizationKey = testPattern.Name
			};
			foreach (ITestPatternProperty property2 in testPattern.Properties)
			{
				TestPatternDocument.Types.TestPatternData.Types.Property property = property2.SerializeValue();
				if (property != null)
				{
					testPatternData.Properties.Add(property);
				}
			}
			testPatternDocument.Patterns.Add(testPatternData);
		}
		_document = testPatternDocument;
		_syncedData?.UpdateData(testPatternDocument);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			OnDispose();
			_syncedData?.Dispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		ChangeDirectoryPrompt.UnregisterDelegate(new ChangeDirectoryListener(TeardownDocumentSyncer, SetupDocumentSyncer));
	}
}
