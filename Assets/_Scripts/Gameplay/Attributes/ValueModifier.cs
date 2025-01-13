using System;
using UnityEngine;
using UnityEngine.Scripting;

namespace TalesEngine
{
	public enum EValueModifierTimeBehaviour
	{
		Permanent = 0,
		Discreet = 1,
		RealTimeBased = 2
	}

	[System.Serializable]
	public struct FValueModifierSettings
	{
		public EValueModifierTimeBehaviour Behaviour;
		public float Duration;
		public bool bIsMultiplier;
		public float Value;
	}

	[Serializable]
	public class ValueModifier : ITimeObserver
	{
		[Header("Settings")]
		[SerializeField]
		private EValueModifierTimeBehaviour _timeBehaviour;
		public EValueModifierTimeBehaviour TimeBehaviour => _timeBehaviour;

		[SerializeField]
		private float _durationBase = 1f;
		public float DurationBase => _durationBase;

		[SerializeField]
		private bool _bIsMultiplier = false;
		public bool bIsMultiplier => _bIsMultiplier;
		[SerializeField]
		[Tooltip("Value added to Wrapper [CURRENT] value (CAN be <= 0)")]
		private float _value = 0f;
		public float Value => _value;
		[SerializeField]
		[Tooltip("% added of Wrapper [BASE] value (CAN be <= 0)")]
		private float _multiplier = 0f;
		public float Multiplier => _multiplier;

		[Header("Cached Variables")]
		private ValueWrapper _wrapper;
		[SerializeField]
		private float _duration;
		public float Duration => _duration;

		#region Value Modifier Methods

		///////////////////////////////////
		/// Value Modifier Methods
		///////////////////////////////////

		public ValueModifier(ValueWrapper wrapper, EValueModifierTimeBehaviour timeBhv, float durationBase, bool bIsMultiplier, float value)
		{
			_wrapper = wrapper;
			_timeBehaviour = timeBhv;
			_durationBase = durationBase;
			_duration = _durationBase;
			_bIsMultiplier = bIsMultiplier;
			if(_bIsMultiplier)
			{
				_multiplier = value;
			}
			else
			{
				_value = value;
			}

			if(!(_timeBehaviour == EValueModifierTimeBehaviour.Permanent))
			{
				TimeManager.Instance.AddObserver(this, _timeBehaviour == EValueModifierTimeBehaviour.RealTimeBased);
			}
		}

		#endregion

		#region ITimeObserver Methods

		///////////////////////////////////
		/// ITimeObserver Methods
		///////////////////////////////////

		public void OnTimePassed(float deltaTime)
		{
			_duration -= deltaTime;

			if(_duration <= 0f)
			{
				_wrapper.RemoveModifier(this);
				TimeManager.Instance.RemoveObserver(this, _timeBehaviour == EValueModifierTimeBehaviour.RealTimeBased);
			}
		}

		#endregion
	}
}
