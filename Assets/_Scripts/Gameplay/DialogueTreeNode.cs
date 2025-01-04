using UnityEngine;
using System.Collections.Generic;
using System;

namespace TalesEngine
{
	[Serializable]
	public struct FConditionalDialog
	{
		public DialogueTreeNode NextNode;
		public GameTest Test;
	}
	public class DialogueTreeNode : MonoBehaviour
	{
		/*[SerializeField]
		private GameTestCondition _conditionSolo;
		public GameTestCondition ConditionSolo => _conditionSolo;*/
		/*[SerializeField]
		private GameTestCondition[] _conditions;
		public GameTestCondition[] Conditions => _conditions;*/
		/*[SerializeField]
		private GameTest[] _tests;
		public GameTest[] Tests => _tests;*/

		[SerializeField]
		private FConditionalDialog _dialogIntro;

		#region UNITY Methods

		///////////////////////////////////
		/// UNITY Methods
		///////////////////////////////////

		void Start()
		{

		}

		void Update()
		{

		}

		#endregion

		#region DialogueTreeNode Methods

		///////////////////////////////////
		/// DialogueTreeNode Methods
		///////////////////////////////////


		#endregion
	}
}
