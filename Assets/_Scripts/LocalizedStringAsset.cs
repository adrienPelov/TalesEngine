using System;
using UnityEngine;

[System.Serializable]
public struct LocalizedString
{
	public EGameLanguage _language;
	public string _text;
}

[CreateAssetMenu(fileName = "LSA_", menuName = "TalesEngine/Assets/LocalizedStringAsset")]
public class LocalizedStringAsset : ScriptableObject
{
	[SerializeField]
	private LocalizedString[] _localizedStrings;

	#region LocalizedStringAsset Methods

	///////////////////////////////////
	/// LocalizedString Methods
	///////////////////////////////////

	public string GetString(EGameLanguage _language)
	{
		foreach(LocalizedString locString in _localizedStrings)
		{
			if(locString._language == _language)
			{
				return locString._text;
			}
		}

		return "ERROR: no string found for language: " + _language.ToString();
	}

	#endregion
}
