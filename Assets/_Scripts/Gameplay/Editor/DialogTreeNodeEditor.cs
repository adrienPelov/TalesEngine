using System;
using System.Linq;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace TalesEngine
{
	[CustomEditor(typeof(DialogTreeNode))]
	public class DialogTreeNodeEditor : Editor
	{
		#region UNITY Methods

		///////////////////////////////////
		/// UNITY Methods
		///////////////////////////////////

		/*public override void OnInspectorGUI()
		{
			Debug.LogWarning("[DTN editor] Create InspectorGUI");

			// Style - Title
			GUIStyle styleTitle = new GUIStyle();
			styleTitle.fontStyle = FontStyle.Bold;
			styleTitle.fontSize = 14;
			styleTitle.normal.textColor = new Color(1f, 174f / 255f, 0f);

			// Style - Bold
			GUIStyle styleTextBold = new GUIStyle();
			styleTextBold.fontStyle = FontStyle.Bold;
			styleTextBold.fontSize = 10;
			styleTextBold.normal.textColor = new Color(255f, 255f, 255f);
			styleTextBold.alignment = TextAnchor.MiddleLeft;

			// Style - Normal
			GUIStyle styleTextNormal = new GUIStyle();
			styleTextNormal.fontStyle = FontStyle.Normal;
			styleTextNormal.fontSize = 10;
			styleTextNormal.normal.textColor = Color.cyan;
			styleTextNormal.alignment = TextAnchor.MiddleLeft;

			serializedObject.Update();

			DialogueTreeNode nodeScript = target as DialogueTreeNode;
			if(nodeScript != null)
			{
				EditorGUILayout.BeginVertical();

				EditorGUILayout.LabelField("Condition SOLO: ", styleTitle);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("_conditionSolo"));

				SerializedProperty propConditions = serializedObject.FindProperty("_conditions");
				if(propConditions != null)
				{
					EditorGUILayout.LabelField("Conditions: ", styleTitle);
					EditorGUILayout.PropertyField(propConditions);
				}

				SerializedProperty propTests = serializedObject.FindProperty("_tests");
				if(propTests != null)
				{
					EditorGUILayout.LabelField("Tests: ", styleTitle);
					EditorGUILayout.PropertyField(propTests);
				}
			}

			serializedObject.ApplyModifiedProperties();

			EditorGUILayout.EndVertical();
		}*/

		public override VisualElement CreateInspectorGUI()
		{
			//Debug.LogWarning("[DTN editor] Create InspectorGUI");

			serializedObject.Update();

			VisualElement rootContainer = new VisualElement();
			//rootContainer.Add(new PropertyField(serializedObject.FindProperty("_conditionSolo")));
			//rootContainer.Add(new PropertyField(serializedObject.FindProperty("_conditions")));
			//rootContainer.Add(new PropertyField(serializedObject.FindProperty("_tests")));
			rootContainer.Add(new PropertyField(serializedObject.FindProperty("_testSolo")));
			rootContainer.Add(new PropertyField(serializedObject.FindProperty("_dialogs")));

			Button bRefreshNames = new Button();
			bRefreshNames.text = "Refresh Names";
			bRefreshNames.clicked += RefreshNames;
			rootContainer.Add(bRefreshNames);

			serializedObject.ApplyModifiedProperties();

			return rootContainer;
		}

		#endregion

		#region DialogueTreeNodeEditor Methods

		///////////////////////////////////
		/// DialogueTreeNodeEditor Methods
		///////////////////////////////////

		private void RefreshNames()
		{
			DialogTreeNode treeNode = target as DialogTreeNode;

			for(int i = 0; i < treeNode.Dialogs.Length; i++)
			{
				string dlgName = "Dialog[" + i +"]";
				if(treeNode.Dialogs[i].StringAsset)
				{
					treeNode.Dialogs[i].RefreshName(treeNode.Dialogs[i].StringAsset.GetString(EGameLanguage.English));
					dlgName = treeNode.Dialogs[i].StringAsset.GetString(EGameLanguage.English);
				}
				else
				{
					Debug.LogError("[DTN]" + treeNode.gameObject.name + " | Error: No StringAsset on " + dlgName);
				}

				for(int j = 0; j < treeNode.Dialogs[i].Options.Length; j++)
				{
					string dlgOptionName = "Option["+j+"]";
					if(treeNode.Dialogs[i].Options[j].StringAsset)
					{
						treeNode.Dialogs[i].Options[j].RefreshName(treeNode.Dialogs[i].Options[j].StringAsset.GetString(EGameLanguage.English));
					}
					else
					{
						Debug.LogError("[DTN]" + treeNode.gameObject.name + " | Error: No StringAsset on " + dlgName + " -> " + dlgOptionName);
					}
				}
			}
		}

		#endregion
	}
}
