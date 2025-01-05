using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace TalesEngine
{
	[CustomEditor(typeof(EventsManager))]
	public class EventsManagerEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			serializedObject.Update();

			EventsManager targetScript = (EventsManager)target;
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
			if(GUILayout.Button("Init Events"))
			{
				InitEvents(targetScript, scriptSO);
			}

			EditorGUILayout.EndVertical();

			scriptSO.ApplyModifiedProperties();
		}

		private void InitEvents(EventsManager script, SerializedObject scriptSO)
		{
			List<EventAsset> foundAssets = new List<EventAsset>();

			string[] guids = AssetDatabase.FindAssets("", new string[] { script.EventsFolderPath });

			if(guids.Length > 0)
			{
				List<EventAsset> loadedAssets = new List<EventAsset>();

				foreach(string guid in guids)
				{
					loadedAssets.Add(AssetDatabase.LoadAssetAtPath<EventAsset>(AssetDatabase.GUIDToAssetPath(guid)));
				}

				if(loadedAssets.Count > 0)
				{
					scriptSO.FindProperty("_eventsAssets").ClearArray();
					int counter = 0;
					foreach(EventAsset asset in loadedAssets)
					{
						Debug.Log(asset.name + " | " + asset.StringAsset.GetString(Application.isPlaying ? TalesManager.Instance.CurrentLanguage : EGameLanguage.English));
						scriptSO.FindProperty("_eventsAssets").InsertArrayElementAtIndex(counter);
						scriptSO.FindProperty("_eventsAssets").GetArrayElementAtIndex(counter).objectReferenceValue = asset;
						counter++;
					}
				}
			}
		}
	}
}