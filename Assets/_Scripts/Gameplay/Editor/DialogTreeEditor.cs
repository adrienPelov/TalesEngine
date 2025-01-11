using Microsoft.SqlServer.Server;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace TalesEngine
{
	[CustomEditor(typeof(DialogTree))]
	public class DialogTreeEditor : Editor
	{
		private List<DialogTreeNode> _allNodes;
		#region UNITY Methods

		///////////////////////////////////
		/// UNITY Methods
		///////////////////////////////////

		private void OnSceneGUI()
		{
			DialogTree targetScript = (DialogTree)target;

			if(targetScript.DBG_bDrawDebug)
			{
				_allNodes = new List<DialogTreeNode>();

				Color baseColor = Gizmos.color;

				float nodeRadius = 0.5f;
				
				Color nodeColorRoot = Color.green;
				GUIStyle styleLabelNodeRoot = new GUIStyle();
				styleLabelNodeRoot.fontStyle = FontStyle.Bold;
				styleLabelNodeRoot.fontSize = 18;
				styleLabelNodeRoot.normal.textColor = nodeColorRoot;

				Color nodeColorDefault = Color.white;
				GUIStyle styleLabelNode = new GUIStyle();
				styleLabelNode.fontStyle = FontStyle.Bold;
				styleLabelNode.fontSize = 18;
				styleLabelNode.normal.textColor = nodeColorRoot;

				int nbDialogs = 0;
				int nbConditions = 0;


				foreach(DialogTreeNode node in targetScript.RootNodes)
				{
					Handles.color = nodeColorRoot;
					Handles.DrawWireDisc(node.gameObject.transform.position, Vector3.forward, nodeRadius);
					Handles.Label(node.gameObject.transform.position, "DLG[" + node.gameObject.name + "]", styleLabelNodeRoot);
					nbDialogs++;
					_allNodes.Add(node);

					Handles.color = nodeColorDefault;

					foreach(FConditionalDialog dialog in node.Dialogs)
					{
						nbConditions = 0;
						foreach(FConditionalDialogOption option in dialog.Options)
						{
							if(option.NextNode)
							{
								Handles.DrawWireDisc(option.NextNode.transform.position, Vector3.forward, nodeRadius);
								Handles.DrawLine(node.gameObject.transform.position, option.NextNode.transform.position);
								Handles.Label(option.NextNode.transform.position, "OPT[" + nbConditions + "] >>> " + option.NextNode.gameObject.name);
								Handles.Label(option.NextNode.transform.position + new Vector3(0f, -0.2f, 0f), option.Test.DBGGetTestString());
								nbConditions++;
								_allNodes.Add(option.NextNode);
							}
						}
					}	
				}

				Handles.color = baseColor;
			}

			foreach(DialogTreeNode node in _allNodes)
			{
				EditorGUI.BeginChangeCheck();

				Vector3 nodeNewPos = Handles.DoPositionHandle(node.transform.position, node.transform.rotation);

				if(EditorGUI.EndChangeCheck())
				{
					Undo.RecordObject(node, "Move Position");
					EditorUtility.SetDirty(node);
					node.transform.position = nodeNewPos;
				}
			}
		}

		#endregion
	}
}
