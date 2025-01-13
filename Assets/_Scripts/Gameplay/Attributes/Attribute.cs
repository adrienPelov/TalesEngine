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
		[SerializeField]
		private ValueWrapper _valueWrapper;
		public int Value => (int)_valueWrapper.Value;

		#region Attribute Methods

		///////////////////////////////////
		/// Attribute Methods
		///////////////////////////////////

		public void InitAttribute(AttributeAsset attributeAsset, int baseValue)
		{
			_attributeAsset = attributeAsset;
			_valueWrapper = new ValueWrapper(true, baseValue);
		}

		public void AddModifier(FValueModifierSettings modSettings)
		{
			_valueWrapper.AddModifier(modSettings);
		}

		#endregion
	}
}
