using UnityEngine;
using System;
using System.Collections.Generic;

namespace TalesEngine
{
	public enum EGameTestBehaviour
	{
		OR = 0,
		AND = 1,
		NONE = 2,
	}

	public struct FGameTestResult
	{
		public bool bIsValid;
		public Pawn TriggerPawn;
		public int AttributeValue;
		public int SkillValue;
		public int ResourceValue;
		public int EventValue;

		public static FGameTestResult GetNullResult()
		{
			return new FGameTestResult { bIsValid = false, TriggerPawn = null, AttributeValue = 0, SkillValue = 0, ResourceValue = 0, EventValue = 0 };
		}
	}

	[Serializable]
	public class GameTest
	{
		[SerializeField]
		private EGameTestBehaviour _behaviour;
		public EGameTestBehaviour Behaviour => _behaviour;
		[SerializeField]
		private List<GameTestCondition> _conditions;
		public List<GameTestCondition> Conditions => _conditions;

		#region GameTest Methods

		///////////////////////////////////
		/// GameTest Methods
		///////////////////////////////////

		public FGameTestResult IsValid(List<Pawn> pawns)
		{
			switch(_behaviour)
			{
				case EGameTestBehaviour.OR:
				{
					return IsValidOR(pawns);
				}
				case EGameTestBehaviour.AND:
				{
					return IsValidAND(pawns);
				}
				case EGameTestBehaviour.NONE:
				{
					return IsValidNONE(pawns);
				}
				default:
				{
					break;
				}
			}

			return FGameTestResult.GetNullResult();
		}

		private FGameTestResult IsValidOR(List<Pawn> pawns)
		{
			foreach(GameTestCondition condition in _conditions)
			{
				FGameTestResult condResult = condition.IsValid(pawns);
				if(condResult.bIsValid)
				{
					return condResult;
				}
			}

			return FGameTestResult.GetNullResult();
		}

		private FGameTestResult IsValidAND(List<Pawn> pawns)
		{
			foreach(GameTestCondition condition in _conditions)
			{
				FGameTestResult condResult = condition.IsValid(pawns);
				if(!condResult.bIsValid)
				{
					return condResult;
				}
			}

			FGameTestResult result = FGameTestResult.GetNullResult();
			result.bIsValid = true;
			return result;
		}

		private FGameTestResult IsValidNONE(List<Pawn> pawns)
		{
			FGameTestResult result = FGameTestResult.GetNullResult();

			foreach(GameTestCondition condition in _conditions)
			{
				FGameTestResult condResult = condition.IsValid(pawns);
				if(condResult.bIsValid)
				{
					condResult.bIsValid = false;
					return condResult;
				}
			}

			result.bIsValid = true;
			return result;
		}

		public string DBGGetTestString()
		{
			string testString = "";
			string testBHV = "";

			switch(_behaviour)
			{
				case EGameTestBehaviour.AND:
				{
					testBHV = " && ";
					break;
				}
				case EGameTestBehaviour.OR:
				{
					testBHV = " || ";
					break;
				}
				case EGameTestBehaviour.NONE:
				{
					testBHV = " &!= ";
					break;
				}
			}

			int condIndex = 0;

			foreach(GameTestCondition condition in _conditions)
			{
				if(condIndex < _conditions.Count - 1)
				{
					testString += condition.GetConditionTestString() + testBHV;
				}
				else
				{
					testString += condition.GetConditionTestString();
				}
				condIndex++;
			}

			return testString;
		}

		#endregion


	}
}
