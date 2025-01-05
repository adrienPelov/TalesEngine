using System.Collections.Generic;
using UnityEngine;

namespace TalesEngine
{
	public class Pawn : MonoBehaviour
	{
		[SerializeField]
		protected string _name;
		public string Name => _name;
		[SerializeField]
		protected List<Attribute> _attributes;
		public List<Attribute> Attributes => _attributes;

		#region UNITY Methods

		///////////////////////////////////
		/// UNITY Methods
		///////////////////////////////////

		protected virtual void Start()
		{

		}

		protected virtual void Update()
		{

		}

		#endregion

		#region Pawn Methods

		///////////////////////////////////
		/// Pawn Methods
		///////////////////////////////////

		protected Attribute GetAttribute(AttributeAsset attrAsset)
		{
			foreach(Attribute attribute in _attributes)
			{
				if(attribute.AttributeAsset == attrAsset)
				{
					return attribute;
				}
			}
			return null;
		}

		public int GetAttributeValue(AttributeAsset attrAsset)
		{
			Attribute attrToCheck = GetAttribute(attrAsset);

			if(attrToCheck != null)
			{
				return attrToCheck.Value;
			}
			return 0;
		}

		#endregion
	}
}
