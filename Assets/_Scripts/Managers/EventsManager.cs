using System;
using System.Collections.Generic;
using UnityEngine;

namespace TalesEngine
{
	[Serializable]
	public struct FEventValue
	{
		public string EventName;
		public int EventValue;
	}

	public class EventsManager : MonoBehaviour
	{
		[Header("Settings")]
		[SerializeField]
		private string _eventsFolderPath;
		public string EventsFolderPath => _eventsFolderPath;

		[Header("Cached Variables")]
		private static EventsManager _instance;
		public static EventsManager Instance => _instance;

		[SerializeField]
		private List<EventAsset> _eventsAssets;
		public List<EventAsset > EventsAssets => _eventsAssets;

		[SerializeField]
		private List<FEventValue> _eventsValues;

		#region UNITY Methods

		///////////////////////////////////
		/// UNITY Methods
		///////////////////////////////////

		void Awake()
		{
			if(_instance == null)
			{
				_instance = this;

				InitManager();
			}
			else
			{
				Debug.LogWarning("[EventsManager] Found duplicate instance on: " + gameObject.name);
				Destroy(gameObject);
			}
		}

		void Start()
		{

		}

		void Update()
		{

		}

		#endregion

		#region EventsManager Methods

		///////////////////////////////////
		/// EventsManager Methods
		///////////////////////////////////

		private void InitManager()
		{
			_eventsValues = new List<FEventValue>();

			foreach(EventAsset evtAsst in _eventsAssets)
			{
				_eventsValues.Add(new FEventValue { EventName = evtAsst.StringAsset.GetString(EGameLanguage.English), EventValue = 0});
			}
		}

		public int GetEventValue(EventAsset evtAsset)
		{
			if(_eventsAssets.Contains(evtAsset))
			{
				return _eventsValues[_eventsAssets.IndexOf(evtAsset)].EventValue;
			}
			return 0;
		}

		#endregion
	}
}
