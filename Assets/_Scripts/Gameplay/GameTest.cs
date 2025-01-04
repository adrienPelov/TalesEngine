using UnityEngine;
using System;
using System.Collections.Generic;

namespace TalesEngine
{
	public enum EGameTestBehaviour
	{
		AND = 0,
		OR = 1,
		NONE = 2
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
	}
}
