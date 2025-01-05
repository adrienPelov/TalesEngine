using System.Collections.Generic;
using UnityEngine;

namespace TalesEngine
{
	public class Character : MonoBehaviour
	{
		[SerializeField]
		private string _name;
		public string Name => _name;
		[SerializeField]
		private List<Attribute> _attributes;
		public List<Attribute> Attributes => _attributes;

		#region UNITY Methods

		///////////////////////////////////
		/// UNITY Methods
		///////////////////////////////////

		void Start()
		{

		}

		void Update()
		{

		}

		#endregion

		#region Character Methods

		///////////////////////////////////
		/// Character Methods
		///////////////////////////////////

		public void InitCharacter(CharacterAsset _charAsset)
		{
			_name = _charAsset.CharacterName;
			_attributes = new List<Attribute>();
			foreach(FInitialAttribute initAttr in _charAsset.InitialAttributes)
			{
				Attribute newAttr = new Attribute();
				newAttr.InitAttribute(initAttr.AttributeAsset, initAttr.BaseValue);
				_attributes.Add(newAttr);
			}
		}

		private Attribute GetAttribute(AttributeAsset attrAsset)
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
