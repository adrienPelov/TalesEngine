using System.Collections.Generic;
using UnityEngine;

namespace TalesEngine
{
	public class Character : Pawn
	{
		#region UNITY Methods

		///////////////////////////////////
		/// UNITY Methods
		///////////////////////////////////

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

		#endregion
	}
}
