using TMPro;
using UnityEngine;

[System.Serializable]
public class TestSwitch : MonoBehaviour, ILanguageObserver
{
	[SerializeField]
	private LocalizedStringAsset _stringAsset;

	[SerializeField]
	private TextMeshProUGUI _testTMP;
	#region UNITY Methods
	
	///////////////////////////////////
	/// UNITY Methods
	///////////////////////////////////
	
    void Start()
    {
        TalesManager.Instance.RegisterLanguageObserver(this);
		UpdateText(_stringAsset.GetString(TalesManager.Instance.CurrentLanguage));
	}

    void Update()
    {
        
    }

	#endregion

	#region ILanguageObserver Methods

	///////////////////////////////////
	/// ILanguageObserver Methods
	///////////////////////////////////

	public void OnLanguageChanged(EGameLanguage _newLanguage)
	{
		if(_stringAsset && _testTMP)
		{
			UpdateText(_stringAsset.GetString(_newLanguage));
		}
		else
		{
			Debug.LogError("No Asset found");
		}
	}

	private void UpdateText(string newText)
	{
		_testTMP.text = newText;
	}

	#endregion
}
