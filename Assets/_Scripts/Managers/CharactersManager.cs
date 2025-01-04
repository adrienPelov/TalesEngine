using System.Collections.Generic;
using UnityEngine;

namespace TalesEngine
{
	public class CharactersManager : MonoBehaviour
	{
		[Header("DEBUG - Initial Characters")]
		[SerializeField]
		public List<CharacterAsset> DBG_InitalCharacters;
		[SerializeField]
		private Transform DBG_InitalCharactersRoot;

		[Header("Cached Variables")]
		[SerializeField]
		private static CharactersManager _instance;
		public static CharactersManager Instance => _instance;

		[SerializeField]
		private List<Character> _playerCharacters;
		public List<Character> PlayerCharacters => _playerCharacters;

		[SerializeField]
		private List<Character> _npCharacters;
		public List<Character> NPCharacters => _npCharacters;

		#region UNITY Methods

		///////////////////////////////////
		/// UNITY Methods
		///////////////////////////////////

		void Awake()
		{
			if(_instance == null)
			{
				_instance = this;
			}
			else
			{
				Destroy(gameObject);
			}
		}

		void Update()
		{

		}

		#endregion

		#region CharactersManager Methods

		///////////////////////////////////
		/// CharactersManager Methods
		///////////////////////////////////

		public void InitPlayerCharacters()
		{
			_playerCharacters.Clear();

			if(DBG_InitalCharactersRoot)
			{
				Destroy(DBG_InitalCharactersRoot.gameObject);
			}

			DBG_InitalCharactersRoot = new GameObject("_CharactersRoot").transform;
			DBG_InitalCharactersRoot.transform.parent = transform;

			foreach(CharacterAsset charAsset in DBG_InitalCharacters)
			{
				Character newChar = DBG_InitalCharactersRoot.gameObject.AddComponent<Character>();
				newChar.InitCharacter(charAsset);
				_playerCharacters.Add(newChar);
			}
		}

		#endregion
	}
}
