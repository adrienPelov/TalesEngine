using UnityEditor;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace TalesEngine
{
	[CustomEditor(typeof(Attribute))]
	[CanEditMultipleObjects]
	public class AttributeEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			Attribute targetScript = (Attribute)this.target;

			// ROOT - Start
			Rect areaRect = EditorGUILayout.BeginVertical(EditorStyles.helpBox);
			EditorGUI.DrawRect(areaRect, new Color(75f / 255f, 75f / 255f, 75f / 255f));

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
			float styleTextBoldWidth = 100f;

			// Style - Normal
			GUIStyle styleTextNormal = new GUIStyle();
			styleTextNormal.fontStyle = FontStyle.Normal;
			styleTextNormal.fontSize = 10;
			styleTextNormal.normal.textColor = Color.cyan;
			styleTextNormal.alignment = TextAnchor.MiddleLeft;
			float styleTextNormWidth = 50f;

			// Variables
			Rect LbVariablesRect = EditorGUILayout.BeginVertical(EditorStyles.label);
			EditorGUI.DrawRect(LbVariablesRect, new Color(35f / 255f, 35f / 255f, 35f / 255f));
			EditorGUILayout.LabelField("Variables", styleTitle);
			EditorGUILayout.EndVertical();

			AttributeAsset _asset = targetScript.AttributeAsset;
			_asset = (AttributeAsset)EditorGUILayout.ObjectField(_asset, typeof(AttributeAsset), false);

			SerializedProperty propValue = serializedObject.FindProperty("_value");
			Rect rectValue = EditorGUILayout.BeginHorizontal(EditorStyles.label);
			EditorGUILayout.LabelField("Value - Current: ", styleTextBold, GUILayout.MaxWidth(styleTextBoldWidth));
			EditorGUILayout.LabelField(propValue.intValue.ToString(), styleTextNormal, GUILayout.MaxWidth(styleTextNormWidth));
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.PropertyField(serializedObject.FindProperty("_modifiers"));

			// Tools
			/*Rect LbToolsRect = EditorGUILayout.BeginVertical(EditorStyles.label);
			EditorGUI.DrawRect(LbToolsRect, new Color(35f / 255f, 35f / 255f, 35f / 255f));
			EditorGUILayout.LabelField("Tools", styleLabel);
			EditorGUILayout.EndVertical();*/

			// ROOT - End
			EditorGUILayout.EndVertical();
		}
	}
}
