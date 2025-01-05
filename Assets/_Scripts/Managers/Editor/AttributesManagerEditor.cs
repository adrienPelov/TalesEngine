using System.Collections.Generic;
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

			serializedObject.Update();

			AttributesManager targetScript = (AttributesManager)target;
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
			if(GUILayout.Button("Init Attributes"))
			{
				InitAttributes(targetScript, scriptSO);
			}

			EditorGUILayout.EndVertical();

			scriptSO.ApplyModifiedProperties();
		}

		private void InitAttributes(AttributesManager script, SerializedObject scriptSO)
		{
			List<AttributeAsset> foundAssets = new List<AttributeAsset>();

			string[] guids = AssetDatabase.FindAssets("", new string[] { script.AttributesFolderPath });

			if(guids.Length > 0)
			{
				List<AttributeAsset> loadedAssets = new List<AttributeAsset>();

				foreach(string guid in guids)
				{
					loadedAssets.Add(AssetDatabase.LoadAssetAtPath<AttributeAsset>(AssetDatabase.GUIDToAssetPath(guid)));
				}

				if(loadedAssets.Count > 0)
				{
					scriptSO.FindProperty("_attributeAssets").ClearArray();
					int test = 0;
					foreach(AttributeAsset asset in loadedAssets)
					{
						Debug.Log(asset.name + " | " + asset.StringAsset.GetString(Application.isPlaying ? TalesManager.Instance.CurrentLanguage : EGameLanguage.English));
						scriptSO.FindProperty("_attributeAssets").InsertArrayElementAtIndex(test);
						scriptSO.FindProperty("_attributeAssets").GetArrayElementAtIndex(test).objectReferenceValue = asset;
						test++;
					}
				}
			}
		}
	}
}