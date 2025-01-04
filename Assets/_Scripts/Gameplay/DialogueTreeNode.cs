using UnityEngine;
using System.Collections.Generic;
using TalesEngine;

public class DialogueTreeNode : MonoBehaviour
{
	[SerializeField]
	private GameTestCondition _conditionSolo;
	public GameTestCondition ConditionSolo => _conditionSolo;
	[SerializeField]
	private GameTestCondition[] _conditions;
	public GameTestCondition[] Conditions => _conditions;
	[SerializeField]
	private GameTest[] _tests;
	public GameTest[] Tests => _tests;

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
