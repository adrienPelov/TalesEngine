using UnityEngine;

namespace TalesEngine
{

	public interface ILanguageObserver
	{
		public void OnLanguageChanged(EGameLanguage _newLanguage);
	}
}
