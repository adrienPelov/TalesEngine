using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace TalesEngine
{
	[System.Serializable]
	public class Attribute
	{
		[Header("Settings")]
		[SerializeField]
		private AttributeAsset _attributeAsset;
		public AttributeAsset AttributeAsset => _attributeAsset;

		[Header("Cached Variables")]
		[SerializeField]
		private int _value;
		public int Value => _value;

		[SerializeField]
		private List<AttributeModifier> _modifiers;

		#region Attribute Methods

		///////////////////////////////////
		/// Attribute Methods
		///////////////////////////////////

		public void InitAttribute(AttributeAsset attributeAsset, int baseValue)
		{
			_attributeAsset = attributeAsset;
			_value = baseValue;
		}

		#endregion
	}
}
