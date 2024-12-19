using UnityEngine;

namespace TalesEngine
{
	[CreateAssetMenu(fileName = "AA_", menuName = "TalesEngine/ScriptableAssets/AttributeAsset")]
	public class AttributeAsset : ScriptableObject
	{
		[SerializeField]
		private LocalizedStringAsset _stringAsset;
		public LocalizedStringAsset StringAsset => _stringAsset;
		[SerializeField]
		private Sprite _sprite;
		public Sprite Sprite => _sprite;
		[SerializeField]
		private int _valueMin;
		public int ValueMin => _valueMin;
		[SerializeField]
		private int _valueMax;
		public int ValueMax => _valueMax;
		[SerializeField]
		private int _valueBase;
		public int ValueBase => _valueBase;
	}
}