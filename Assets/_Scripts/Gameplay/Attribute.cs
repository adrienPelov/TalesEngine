using System;
using UnityEngine;

namespace TalesEngine
{
	[System.Serializable]
	public class Attribute
	{
		[Header("Settings")]
		[SerializeField]
		private AttributeAsset _attributeAsset;

		[Header("Cached Variables")]
		[SerializeField]
		private int _value;
		public int Value => _value;

		#region AttributeAsset Methods

		///////////////////////////////////
		/// AttributeAsset Methods
		///////////////////////////////////

		public void InitAttribute(AttributeAsset attributeAsset)
		{
			_attributeAsset = attributeAsset;
			_value = _attributeAsset.ValueBase;
		}

		#endregion
	}
}
