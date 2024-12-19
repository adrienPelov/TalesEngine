using UnityEditor;
using UnityEngine;

namespace TalesEngine
{
	[CustomEditor(typeof(AttributesManager))]
	public class AttributesManagerEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			AttributesManager targetScript = (AttributesManager)target;

			Rect areaRect = EditorGUILayout.BeginVertical(EditorStyles.helpBox);
			EditorGUI.DrawRect(areaRect, new Color(75f / 255f, 75f / 255f, 75f / 255f));
			
			GUIStyle labelStyle = new GUIStyle();
			labelStyle.fontStyle = FontStyle.Bold;
			labelStyle.fontSize = 14;
			labelStyle.normal.textColor = new Color(1f, 174f / 255f, 0f);
			Rect labelRect = new Rect(areaRect.position.x, areaRect.position.y, areaRect.width, 20f);
			EditorGUI.DrawRect(labelRect, new Color(35f / 255f, 35f / 255f, 35f / 255f));
			EditorGUILayout.LabelField("Tools", labelStyle);

			if(GUILayout.Button("Init Attributes"))
			{
				targetScript.InitAttributes();
			}

			EditorGUILayout.EndVertical();
		}
	}
}