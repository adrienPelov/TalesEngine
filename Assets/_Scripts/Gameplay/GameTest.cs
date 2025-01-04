using UnityEngine;
using System;
using System.Collections.Generic;

namespace TalesEngine
{
	public enum GameTestBehaviour
	{
		AND = 0,
		OR = 1,
		NONE = 2
	}

	[Serializable]
	public class GameTest
	{
		[SerializeField]
		private GameTestBehaviour _behaviour;
		public GameTestBehaviour Behaviour => _behaviour;
		[SerializeField]
		private List<GameTestCondition> _conditions;
		public List<GameTestCondition> Conditions => _conditions;
	}
}
