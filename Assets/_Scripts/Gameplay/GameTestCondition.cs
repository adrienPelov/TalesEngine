using System;
using System.Collections.Generic;
using UnityEngine;

namespace TalesEngine
{
	public enum EGameTestConditionTarget
	{
		None = 0,
		Attribute = 1,
		Skill = 2,
		Resource = 3,
		Event = 4,
	}

	public enum EGameTestConditionThreshold
	{
		Equal = 0,
		NotEqual = 1,
		GreaterThan = 2,
		GreaterOrEqualTo = 3,
		SmallerThan = 4,
		SmallerOrEqualTo = 5
	}

	[Serializable]
	public class GameTestCondition
	{
		[SerializeField]
		private EGameTestConditionTarget _target = EGameTestConditionTarget.None;
		public EGameTestConditionTarget Target => _target;

		[SerializeField]
		private EGameTestConditionThreshold _threshold;
		public EGameTestConditionThreshold Threshold => _threshold;

		[SerializeField]
		private float _thresholdValue;
		public float ThresholdValue => _thresholdValue;

		[Header("Attribute Settings")]
		[SerializeField]
		private AttributeAsset _attrAssetRef;

		#region GameTestCondition Methods

		///////////////////////////////////
		/// GameTestCondition Methods
		///////////////////////////////////

		public bool IsValid(List<Character> characters)
		{
			switch(_target)
			{
				case EGameTestConditionTarget.Attribute:
				{
					return IsValidAttribute(characters);
				}
				default:
				{
					return false;
				}
			}
		}

		private bool IsValidAttribute(List<Character> characters)
		{
			foreach(Character character in characters)
			{
				int attrCheckValue = character.GetAttributeValue(_attrAssetRef);
				if(IsValidTreshold(attrCheckValue, (int)_thresholdValue))
				{
					return true;
				}
			}
			return false;
		}

		private bool IsValidTreshold(int valueCheck, int valueRef)
		{
			switch(_threshold)
			{
				case EGameTestConditionThreshold.Equal:
				{
					return valueCheck == valueRef;
				}
				case EGameTestConditionThreshold.GreaterOrEqualTo:
				{
					return valueCheck >= valueRef;
				}
				case EGameTestConditionThreshold.GreaterThan:
				{
					return valueCheck > valueRef;
				}
				case EGameTestConditionThreshold.NotEqual:
				{
					return valueCheck != valueRef;
				}
				case EGameTestConditionThreshold.SmallerOrEqualTo:
				{
					return valueCheck <= valueRef;
				}
				case EGameTestConditionThreshold.SmallerThan:
				{
					return valueCheck < valueRef;
				}
			}

			return false;
		}
		#endregion
	}
}
