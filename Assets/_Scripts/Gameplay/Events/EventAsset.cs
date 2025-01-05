using UnityEngine;

namespace TalesEngine
{
	[CreateAssetMenu(fileName = "EA_", menuName = "TalesEngine/ScriptableAssets/EventAsset")]
	public class EventAsset : ScriptableObject
	{
		[SerializeField]
		private LocalizedStringAsset _stringAsset;
		public LocalizedStringAsset StringAsset => _stringAsset;
	}
}
