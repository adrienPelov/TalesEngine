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

		[Header("Event Settings")]
		[SerializeField]
		private EventAsset _evtAssetRef;

		#region GameTestCondition Methods

		///////////////////////////////////
		/// GameTestCondition Methods
		///////////////////////////////////

		public FGameTestResult IsValid(List<Pawn> pawns)
		{
			switch(_target)
			{
				case EGameTestConditionTarget.Attribute:
				{
					return IsValidAttribute(pawns);
				}
				case EGameTestConditionTarget.Event:
				{
					return IsValidEvent();
				}
				default:
				{
					break;
				}
			}

			return FGameTestResult.GetNullResult();
		}

		private FGameTestResult IsValidAttribute(List<Pawn> pawns)
		{
			Debug.Log("--------> [Condition] Checking Attribute[ " + _attrAssetRef.name + "] ?" + GetConditionThresholdString() + (int)_thresholdValue);
			foreach(Pawn pawn in pawns)
			{
				int pawnAttrValue = pawn.GetAttributeValue(_attrAssetRef);
				Debug.Log("------------> [Condition] On Pawn: " + pawn.Name + " (" + pawnAttrValue + ")");
				if(IsValidTreshold(pawnAttrValue, (int)_thresholdValue))
				{
					Debug.Log("----------------> [Condition] Valid! " + GetConditionValueString(pawnAttrValue));
					return new FGameTestResult { bIsValid = true, TriggerPawn = pawn, AttributeValue = pawnAttrValue};
				}
			}
			return FGameTestResult.GetNullResult();
		}

		private FGameTestResult IsValidEvent()
		{
			FGameTestResult result = FGameTestResult.GetNullResult();
			int evtValue = EventsManager.Instance.GetEventValue(_evtAssetRef);

			Debug.Log("--------> [Condition] Checking Event[ " + _evtAssetRef.name + "] " + GetConditionValueString(evtValue) + "?");

			if(IsValidTreshold(evtValue, (int)_thresholdValue))
			{
				result.bIsValid = true;
				result.EventValue = evtValue;
				Debug.Log("----------------> [Condition] Valid! ");
			}
			return result;
		}

		private bool IsValidTreshold(int valueChecked, int valueRef)
		{
			switch(_threshold)
			{
				case EGameTestConditionThreshold.Equal:
				{
					return valueChecked == valueRef;
				}
				case EGameTestConditionThreshold.GreaterOrEqualTo:
				{
					return valueChecked >= valueRef;
				}
				case EGameTestConditionThreshold.GreaterThan:
				{
					return valueChecked > valueRef;
				}
				case EGameTestConditionThreshold.NotEqual:
				{
					return valueChecked != valueRef;
				}
				case EGameTestConditionThreshold.SmallerOrEqualTo:
				{
					return valueChecked <= valueRef;
				}
				case EGameTestConditionThreshold.SmallerThan:
				{
					return valueChecked < valueRef;
				}
			}

			return false;
		}

		public string GetConditionValueString(int checkedValue)
		{
			string thresholdString = GetConditionThresholdString();

			return checkedValue + thresholdString + (int)_thresholdValue;
		}

		public string GetConditionTestString()
		{
			switch(_target)
			{
				case EGameTestConditionTarget.Attribute:
				{
					return "[Attribute] " + _attrAssetRef.StringAsset.GetString(EGameLanguage.English) + GetConditionThresholdString() + _thresholdValue;
				}
				case EGameTestConditionTarget.Event:
				{
					return "[Event] " + _evtAssetRef.StringAsset.GetString(EGameLanguage.English) + GetConditionThresholdString() + _thresholdValue;
				}
				case EGameTestConditionTarget.Resource:
				{
					return "[Resource] ";
				}
				case EGameTestConditionTarget.Skill:
				{
					return "[Skill] ";
				}
				default:
				{
					return "[NONE] ";
				}
			}
		}

		private string GetConditionThresholdString()
		{
			switch(_threshold)
			{
				case EGameTestConditionThreshold.Equal:
				{
					return " = ";
				}
				case EGameTestConditionThreshold.GreaterOrEqualTo:
				{
					return " >= ";
				}
				case EGameTestConditionThreshold.GreaterThan:
				{
					return " > ";
				}
				case EGameTestConditionThreshold.NotEqual:
				{
					return " != ";
				}
				case EGameTestConditionThreshold.SmallerOrEqualTo:
				{
					return " <= ";
				}
				case EGameTestConditionThreshold.SmallerThan:
				{
					return " < ";
				}
			}

			return "_NoThreshold_";
		}

		#endregion
	}
}
