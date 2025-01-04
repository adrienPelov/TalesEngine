using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;

namespace TalesEngine
{
	[CustomPropertyDrawer(typeof(GameTestCondition))]
	public class GameTestConditionDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			// Style - Title
			GUIStyle styleTitle = new GUIStyle();
			styleTitle.fontStyle = FontStyle.Bold;
			styleTitle.fontSize = 12;
			styleTitle.normal.textColor = Color.white;

			// Style - Array Element
			GUIStyle styleArrayElt = new GUIStyle();
			styleArrayElt.fontStyle = FontStyle.Bold;
			styleArrayElt.fontSize = 12;
			styleArrayElt.normal.textColor = Color.white;
			Color eltColor = new Color(100f / 255f, 130f / 255f, 160f / 255f);

			EditorGUI.DrawRect(position, eltColor);
			string prefixLabel = label.text.Contains("Element") ? "Cond[" + label.text[label.text.Length - 1] + "]" : label.text;
			EditorGUI.LabelField(position, prefixLabel, styleArrayElt);

			// Serialized Properties
			SerializedProperty propTarget = property.FindPropertyRelative("_target");
			EditorGUILayout.PropertyField(propTarget, new GUIContent("Target: "));

			if(propTarget.enumValueIndex != (int)EGameTestConditionTarget.None)
			{
				SerializedProperty propTreshold = property.FindPropertyRelative("_threshold");
				EditorGUILayout.PropertyField(propTreshold, new GUIContent("Treshold: "));
				SerializedProperty propTresholdValue = property.FindPropertyRelative("_thresholdValue");
				EditorGUILayout.PropertyField(propTresholdValue);
			}
		}
	}
}

