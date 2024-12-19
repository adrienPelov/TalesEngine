using UnityEngine;
using System.Collections.Generic;

namespace TalesEngine
{
	public enum EGameLanguage
	{
		English = 0,
		French = 1,
	}

	public class TalesManager : MonoBehaviour
	{
		private static TalesManager _instance;
		public static TalesManager Instance => _instance;

		[SerializeField]
		private EGameLanguage _currentLanguage;
		public EGameLanguage CurrentLanguage => _currentLanguage;

		private List<ILanguageObserver> _languageObservers;

		#region UNITY Methods

		///////////////////////////////////
		/// UNITY Methods
		///////////////////////////////////

		void Awake()
		{
			if(_instance == null)
			{
				_instance = this;
				InitTalesManager();
			}
			else
			{
				Debug.LogWarning("[TalesManager] Existing isntance found on: " + this.gameObject.name);
				Destroy(this.gameObject);
			}
		}

		void Update()
		{

		}

		#endregion

		#region TalesManager Methods

		///////////////////////////////////
		/// TalesManager Methods
		///////////////////////////////////

		private void InitTalesManager()
		{
			_languageObservers = new List<ILanguageObserver>();
		}

		public void RegisterLanguageObserver(ILanguageObserver observer)
		{
			if(!_languageObservers.Contains(observer))
			{
				_languageObservers.Add(observer);
			}
		}

		public void OnLanguageChanged(EGameLanguage newLanguage)
		{
			foreach(ILanguageObserver observer in _languageObservers)
			{
				observer.OnLanguageChanged(newLanguage);
			}
		}

		#endregion
	}
}
