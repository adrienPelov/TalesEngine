using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace TalesEngine
{
	[CustomEditor(typeof(Character))]
	public class CharacterEditor : Editor
	{
		#region UNITY Methods

		///////////////////////////////////
		/// UNITY Methods
		///////////////////////////////////

		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			serializedObject.Update();

			Character targetScript = (Character)target;
			SerializedObject scriptSO = new SerializedObject(targetScript);

			GUIStyle labelStyle = new GUIStyle();
			labelStyle.fontStyle = FontStyle.Bold;
			labelStyle.fontSize = 14;
			labelStyle.normal.textColor = new Color(1f, 174f / 255f, 0f);

			Rect areaRect = EditorGUILayout.BeginVertical(EditorStyles.helpBox);
			EditorGUI.DrawRect(areaRect, new Color(75f / 255f, 75f / 255f, 75f / 255f));

			Rect labelRect = new Rect(areaRect.position.x, areaRect.position.y, areaRect.width, 20f);
			EditorGUI.DrawRect(labelRect, new Color(35f / 255f, 35f / 255f, 35f / 255f));
			EditorGUILayout.LabelField("Tools", labelStyle);

			if(GUILayout.Button("Add DBG Modifier"))
			{
				AddDebugModifier(targetScript);
			}

			EditorGUILayout.EndVertical();

			scriptSO.ApplyModifiedProperties();
		}

		#endregion

		#region CharacterEditor Methods

		///////////////////////////////////
		/// CharacterEditor Methods
		///////////////////////////////////

		private void AddDebugModifier(Character script)
		{
			script.Attributes[0].AddModifier(script.DBG_modifierSettings);
		}

		#endregion
	}
}
