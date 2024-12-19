using UnityEditor;
using UnityEditor.TerrainTools;
using UnityEngine;

namespace TalesEngine
{

	[CustomEditor(typeof(TalesManager))]
	public class TalesManagerEditor : Editor
	{
		EGameLanguage _selectedLanguage;

		#region UNITY Methods

		///////////////////////////////////
		/// EDITOR Methods
		///////////////////////////////////

		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			TalesManager tgtScript = (TalesManager)target;

			Rect areaRect = EditorGUILayout.BeginVertical(EditorStyles.helpBox);
			EditorGUI.DrawRect(areaRect, new Color(75f / 255f, 75f / 255f, 75f / 255f));

			GUIStyle labelStyle = new GUIStyle();
			labelStyle.fontStyle = FontStyle.Bold;
			labelStyle.fontSize = 14;
			labelStyle.normal.textColor = new Color(1f, 174f / 255f, 0f);

			Rect LabelRect = new Rect(areaRect.position.x, areaRect.position.y, areaRect.width, 20f);
			EditorGUI.DrawRect(LabelRect, new Color(35f / 255f, 35f / 255f, 35f / 255f));

			EditorGUILayout.LabelField("Tools", labelStyle);

			_selectedLanguage = (EGameLanguage)EditorGUILayout.EnumPopup("New Language", _selectedLanguage);

			if(GUILayout.Button("Switch Language"))
			{
				tgtScript.OnLanguageChanged(_selectedLanguage);
			}

			EditorGUILayout.EndVertical();
		}

		#endregion
	}
}
