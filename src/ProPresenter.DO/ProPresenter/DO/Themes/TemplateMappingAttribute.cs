using System;

namespace ProPresenter.DO.Themes;

[AttributeUsage(AttributeTargets.Field)]
public class TemplateMappingAttribute : Attribute
{
	private string _name;

	private bool _isCustomToken;

	public string Name => _name;

	public bool IsCustomToken => _isCustomToken;

	public TemplateMappingAttribute(string name, bool isCustomToken = false)
	{
		_name = name;
		_isCustomToken = isCustomToken;
	}
}
