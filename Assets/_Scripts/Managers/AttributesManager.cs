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
		public string AttributesFolderPath => _attributesFolderPath;

		[Header("Cached Variables")]
		[SerializeField]
		private List<AttributeAsset> _attributeAssets;
		public List<AttributeAsset > AttributeAssets => _attributeAssets;

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
				Debug.LogWarning("[AttributesManager] Found duplicate instance on: " + this.gameObject.name);
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

		}

#endregion
	}
}
