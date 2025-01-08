using UnityEngine;
using System.Collections.Generic;
using System;

namespace TalesEngine
{
	[Serializable]
	public struct FConditionalDialog
	{
		public string DBGName;
		public LocalizedStringAsset StringAsset;
		public FConditionalDialogOption[] Options;
		public GameTest Test;

		public void RefreshName(string newName)
		{
			DBGName = newName;
		}
	}

	[Serializable]
	public struct FConditionalDialogOption
	{
		public string DBGName;
		public LocalizedStringAsset StringAsset;
		public DialogTreeNode NextNode;
		public GameTest Test;

		public void RefreshName(string newName)
		{
			DBGName = newName;
		}
	}

	public class DialogTreeNode : MonoBehaviour
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
		private FConditionalDialog[] _dialogs;
		public FConditionalDialog[] Dialogs => _dialogs;

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
