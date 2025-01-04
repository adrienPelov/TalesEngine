using System.Collections.Generic;
using UnityEngine;

namespace TalesEngine
{
	[System.Serializable]
	public struct FInitialAttribute
	{
		public AttributeAsset AttributeAsset;
		public int BaseValue;
	}
	[CreateAssetMenu(fileName = "CA_", menuName = "TalesEngine/ScriptableAssets/CharacterAsset")]
	public class CharacterAsset : ScriptableObject
	{
		[SerializeField]
		private List<FInitialAttribute> _initialAttributes;
		public List<FInitialAttribute> InitialAttributes => _initialAttributes;
	}
}