using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace TalesEngine
{
	public class DialogTree : MonoBehaviour
	{
		[Header("Setup")]
		[SerializeField]
		private DialogTreeNode[] _rootNodes;
		public DialogTreeNode[] RootNodes => _rootNodes;

		[Header("Cached Variables")]
		public bool DBG_bDrawDebug = false;

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

#if UNITY_EDITOR

		/*private void OnDrawGizmos()
		{
			if(DBG_bDrawDebug)
			{
				Color baseColor = Gizmos.color;

				float nodeRadius = 0.5f;
				Color nodeColorRoot = Color.green;
				Color nodeColorDefault = Color.white;

				foreach(DialogTreeNode node in _rootNodes)
				{
					Gizmos.color = nodeColorRoot;
					Gizmos.DrawWireSphere(node.gameObject.transform.position, nodeRadius);

					foreach(FConditionalDialog dialog in node.Dialogs)
					{
						foreach(FConditionalDialogOption option in dialog.Options)
						{
							Gizmos.color = nodeColorDefault;
							if(option.NextNode)
							{
								Gizmos.DrawWireSphere(option.NextNode.gameObject.transform.position, nodeRadius);
								Gizmos.DrawLine(node.gameObject.transform.position, option.NextNode.gameObject.transform.position);
							}
						}
					}
				}

				Gizmos.color = baseColor;
			}
		}*/

#endif

		#endregion

		#region DialogueTree Methods

		///////////////////////////////////
		/// DialogueTree Methods
		///////////////////////////////////



		#endregion
	}
}
