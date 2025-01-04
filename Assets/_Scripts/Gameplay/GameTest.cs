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

		public bool IsValid(List<Character> characters)
		{
			switch(_behaviour)
			{
				case EGameTestBehaviour.OR:
				{
					return IsValidOR(characters);
				}
				case EGameTestBehaviour.AND:
				{
					return IsValidAND(characters);
				}
				case EGameTestBehaviour.NONE:
				{
					return IsValidNONE(characters);
				}
				default:
				{
					return false;
				}
			}
		}

		private bool IsValidOR(List<Character> characters)
		{
			foreach(GameTestCondition condition in _conditions)
			{
				if(condition.IsValid(characters))
				{
					return true;
				}
			}

			return false;
		}

		private bool IsValidAND(List<Character> characters)
		{
			foreach(GameTestCondition condition in _conditions)
			{
				if(!condition.IsValid(characters))
				{
					return false;
				}
			}

			return true;
		}

		private bool IsValidNONE(List<Character> characters)
		{
			foreach(GameTestCondition condition in _conditions)
			{
				if(condition.IsValid(characters))
				{
					return false;
				}
			}

			return true;
		}

		#endregion


	}
}
