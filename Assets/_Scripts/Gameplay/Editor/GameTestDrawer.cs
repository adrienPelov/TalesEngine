using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace TalesEngine
{
	[CustomPropertyDrawer(typeof(GameTest))]
	public class GameTestDrawer : PropertyDrawer
	{
		#region UNITY Methods

		///////////////////////////////////
		/// UNITY Methods
		///////////////////////////////////

		public override VisualElement CreatePropertyGUI(SerializedProperty property)
		{
			VisualElement rootContainer = new VisualElement();

			string testName = property.displayName.Contains("Element") ? "Test[" + property.displayName[property.displayName.Length - 1] + "]": property.name;
			Foldout fold = new Foldout();
			rootContainer.Add(fold);
			fold.text = testName;
			fold.style.fontSize = 13;
			fold.style.backgroundColor = new Color(35f / 255f, 35f / 255f, 35f / 255f);
			fold.Add(new PropertyField(property.FindPropertyRelative("_behaviour"), "Behaviour:"));
			fold.Add(new PropertyField(property.FindPropertyRelative("_conditions"), "Conditions:"));

			return rootContainer;
		}

		#endregion
	}
}

