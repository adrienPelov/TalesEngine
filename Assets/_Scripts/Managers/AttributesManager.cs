using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace TalesEngine
{
	public class AttributesManager : MonoBehaviour
	{
		private static AttributesManager _instance;
		public static AttributesManager Instance => _instance;

		[Header("Settings")]
		[SerializeField]
		private string _attributesFolderPath = "Assets/_Content/ScriptableAssets/Attributes";

		[Header("Cached Variables")]
		[SerializeField]
		private List<AttributeAsset> _attributeAssets;

		#region UNITY Methods

		///////////////////////////////////
		/// UNITY Methods
		///////////////////////////////////

		void Awake()
		{
			if(!_instance)
			{
				_instance = this;
				InitManager();
			}
			else
			{
				Debug.LogWarning("[AttributesManager] Existing isntance found on: " + this.gameObject.name);
				Destroy(this);
			}
		}

		void Start()
		{

		}

		void Update()
		{

		}

		#endregion

		#region Attributes Manager Methods

		///////////////////////////////////
		/// Attributes Manager Methods
		///////////////////////////////////

		private void InitManager()
		{
			//InitAttributes();
		}

#if UNITY_EDITOR

		public void InitAttributes()
		{
			_attributeAssets.Clear();

			//string[] guids = AssetDatabase.FindAssets("t:AttributeAsset", new string[] {_attributesFolderPath});
			string[] guids = AssetDatabase.FindAssets("", new string[] { _attributesFolderPath });

			if(guids.Length > 0)
			{
				List<AttributeAsset> loadedAssets = new List<AttributeAsset>(guids.Length);

				foreach(string guid in guids)
				{
					loadedAssets.Add(AssetDatabase.LoadAssetAtPath<AttributeAsset>(AssetDatabase.GUIDToAssetPath(guid)));
				}

				foreach(AttributeAsset asset in loadedAssets)
				{
					Debug.Log(asset.name + " | " + asset.StringAsset.GetString(Application.isPlaying ? TalesManager.Instance.CurrentLanguage : EGameLanguage.English));
					_attributeAssets.Add(asset);
				}
			}
		}

#endif

#endregion
	}
}
