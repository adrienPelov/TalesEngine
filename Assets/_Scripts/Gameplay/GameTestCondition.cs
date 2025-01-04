using System;
using UnityEngine;

namespace TalesEngine
{
	public enum EGameTestConditionTarget
	{
		None = 0,
		Test_Attribute = 1,
		Test_Skill = 2,
		Test_Resource = 3,
		Test_Event = 4,
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

		#region GameTestCondition Methods

		///////////////////////////////////
		/// GameTestCondition Methods
		///////////////////////////////////



		#endregion
	}
}
