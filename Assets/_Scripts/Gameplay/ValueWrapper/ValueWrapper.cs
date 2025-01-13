using System;
using System.Collections.Generic;
using UnityEngine;

namespace TalesEngine
{
	[Serializable]
	public class ValueWrapper
	{
		[Header("Settings")]
		[SerializeField]
		private bool _bIsInt = true;
		public bool bIsInt => _bIsInt;

		[Header("Cached Variables")]
		[SerializeField]
		private float _baseValue;
		public float Value => GetValue();
		[SerializeField]
		private List<ValueModifier> _modifiers;

		#region ValueWrapper Methods

		///////////////////////////////////
		/// ValueWrapper Methods
		///////////////////////////////////

		public ValueWrapper(bool isInt, float baseValue)
		{
			_bIsInt = isInt;
			_baseValue = baseValue;
		}

		private float GetValue()
		{
			if(_bIsInt)
			{
				return Mathf.RoundToInt(GetModifiedValue());
			}
			else
			{
				return GetModifiedValue();
			}
		}

		private float GetModifiedValue()
		{
			float modValue = _baseValue;

			foreach(ValueModifier modifier in _modifiers)
			{
				modValue += modifier.bIsMultiplier ? modifier.Multiplier * _baseValue : modifier.Value;
			}

			return modValue;
		}

		public void AddModifier(FValueModifierSettings modSettings)
		{
			ValueModifier newMod = new ValueModifier(this, modSettings.Behaviour, modSettings.Duration, modSettings.bIsMultiplier, modSettings.Value);
			if(newMod != null)
			{
				_modifiers.Add(newMod);
			}
		}

		public void RemoveModifier(ValueModifier modifier)
		{
			if(_modifiers.Contains(modifier))
			{
				_modifiers.Remove(modifier);
			}
		}

		#endregion
	}
}