using System.Collections.Generic;
using UnityEngine;

namespace TalesEngine
{
	public class TimeManager : MonoBehaviour
	{
		private static TimeManager _instance;
		public static TimeManager Instance => _instance;

		[Header("Cached Variables")]
		[SerializeField]
		private bool _bUpdateRealTime = false;
		[SerializeField]
		private float _sessionTimeStart;
		public float SessionTimeStart => _sessionTimeStart;
		[SerializeField]
		private float _sessionTimeElapsed;
		public float SessionTimeElapsed => _sessionTimeElapsed;
		[SerializeField]
		private List<ITimeObserver> _observersDiscreet;
		[SerializeField]
		private List<ITimeObserver> _observersRealTime;

		#region UNITY Methods

		///////////////////////////////////
		/// UNITY Methods
		///////////////////////////////////

		private void Awake()
		{
			InitManager();
		}
		void Start()
		{
			
		}

		void Update()
		{
			DBG_UpdateRealTime();
		}

		#endregion

		#region TimeManager Methods

		///////////////////////////////////
		/// TimeManager Methods
		///////////////////////////////////

		private void InitManager()
		{
			if(_instance == null)
			{
				_instance = this;
				_sessionTimeElapsed = 0f;
				_observersDiscreet = new List<ITimeObserver>();
				_observersRealTime = new List<ITimeObserver>();
			}
			else
			{
				Debug.LogWarning("[TimeManager] Found duplicate instance on: " + this.gameObject.name);
				Destroy(this.gameObject);
			}
		}

		private void NotifyTimePassed(float deltaTime, bool bRealTime)
		{
			List<ITimeObserver> observers = bRealTime ? _observersRealTime : _observersDiscreet;

			for(int i = 0; i < observers.Count; i++)
			{ 
				ITimeObserver observer = observers[i];
				if(observer != null)
				{
					observer.OnTimePassed(deltaTime);
				}
			}
		}

		public void AddObserver(ITimeObserver observer, bool bRealTime)
		{
			List<ITimeObserver> observers = bRealTime ? _observersRealTime : _observersDiscreet;

			if(!observers.Contains(observer))
			{
				observers.Add(observer);
			}
		}

		public void RemoveObserver(ITimeObserver observer, bool bRealTime)
		{
			List<ITimeObserver> observers = bRealTime ? _observersRealTime : _observersDiscreet;

			if(observers.Contains(observer))
			{
				observers.Remove(observer);
			}
		}

		public void AddTime(float deltaTime, bool bRealTime)
		{
			_sessionTimeElapsed += deltaTime;
			NotifyTimePassed(deltaTime, bRealTime);
		}

		private void DBG_UpdateRealTime()
		{
			if(_bUpdateRealTime)
			{
				AddTime(Time.deltaTime, true);
			}
		}

		#endregion
	}
}
