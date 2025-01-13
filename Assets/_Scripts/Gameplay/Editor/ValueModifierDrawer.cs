using UnityEditor;
using UnityEngine;

namespace TalesEngine
{
	//[CustomPropertyDrawer(typeof(ValueModifier))]
	public class ValueModifierDrawer : PropertyDrawer
	{
		ValueModifier _targetScript;
		GUIStyle _styleTextLabel;
		float _styleTextLabelWidth;
		GUIStyle _styleTextValue;
		float _styleTextValueWidth;

		#region UNITY Methods

		///////////////////////////////////
		/// UNITY Methods
		///////////////////////////////////

		/*public override void OnInspectorGUI()
		{
			serializedObject.Update();

			_targetScript = (AttributeModifier)target;

			// ROOT - Start
			Rect areaRect = EditorGUILayout.BeginVertical(EditorStyles.helpBox);
			EditorGUI.DrawRect(areaRect, new Color(75f / 255f, 75f / 255f, 75f / 255f));

			// Style - Title
			GUIStyle styleTitle = new GUIStyle();
			styleTitle.fontStyle = FontStyle.Bold;
			styleTitle.fontSize = 14;
			styleTitle.normal.textColor = new Color(1f, 174f / 255f, 0f);

			// Style - Label
			_styleTextLabel = new GUIStyle();
			_styleTextLabel.fontStyle = FontStyle.Italic;
			_styleTextLabel.fontSize = 12;
			_styleTextLabel.normal.textColor = new Color(255f, 255f, 255f);
			_styleTextLabel.alignment = TextAnchor.MiddleLeft;
			_styleTextLabelWidth = 130f;

			// Style - Value
			_styleTextValue = new GUIStyle();
			_styleTextValue.fontStyle = FontStyle.BoldAndItalic;
			_styleTextValue.fontSize = 12;
			_styleTextValue.normal.textColor = Color.cyan;
			_styleTextValue.alignment = TextAnchor.MiddleLeft;
			_styleTextValueWidth = 50f;

			// Settings
			Rect LbVariablesRect = EditorGUILayout.BeginVertical(EditorStyles.label);
			EditorGUI.DrawRect(LbVariablesRect, new Color(35f / 255f, 35f / 255f, 35f / 255f));
			EditorGUILayout.LabelField("Settings", styleTitle);
			EditorGUILayout.EndVertical();

			// PROP - Permanent
			SerializedProperty propPermanent = serializedObject.FindProperty("_bPermanent");
			if(propPermanent != null)
			{
				bool bPermanent = propPermanent.boolValue;
				bPermanent = EditorGUILayout.Toggle("Permanent?", bPermanent);
				propPermanent.boolValue = bPermanent;

				if(!propPermanent.boolValue)
				{
					// PROP - Duration
					//DrawProperty("Duration: ", _targetScript.Duration.ToString());
					SerializedProperty propDuration = serializedObject.FindProperty("_durationBase");
					if(propDuration != null)
					{
						propDuration.floatValue = DrawFloatProperty("Duration: ", propDuration.floatValue);
					}
				}
			}

			// PROP - Is Value

			SerializedProperty propIsValue = serializedObject.FindProperty("_bIsValue");
			if(propIsValue != null)
			{
				bool bIsValue = propIsValue.boolValue;
				bIsValue = EditorGUILayout.Toggle("Is Value?", bIsValue);
				propIsValue.boolValue = bIsValue;
				if(bIsValue)
				{
					// PROP - Value
					SerializedProperty propValue = serializedObject.FindProperty("_value");
					if(propValue != null)
					{
						propValue.floatValue = DrawFloatProperty("Value: ", propValue.floatValue);
					}
				}
				else
				{
					// PROP - Multiplier
					SerializedProperty propMultiplier = serializedObject.FindProperty("_multiplier");
					if(propMultiplier != null)
					{
						propMultiplier.floatValue = DrawFloatProperty("Multiplier: ", propMultiplier.floatValue);
					}
				}
			}

			EditorGUILayout.EndVertical();

			serializedObject.ApplyModifiedProperties();
		}

		private void DrawProperty(string propLabel, string propValue)
		{
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField(propLabel, _styleTextLabel, GUILayout.MaxWidth(_styleTextLabelWidth));
			EditorGUILayout.LabelField(propValue, _styleTextValue, GUILayout.MaxWidth(_styleTextValueWidth));
			EditorGUILayout.EndHorizontal();
		}

		private float DrawFloatProperty(string propLabel, float propValue)
		{
			EditorGUILayout.BeginHorizontal();
			float newValue = EditorGUILayout.FloatField(propLabel, propValue);
			EditorGUILayout.EndHorizontal();

			return newValue;
		}*/

		#endregion
	}
}
