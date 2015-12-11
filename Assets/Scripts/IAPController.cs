using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IAPController : MonoBehaviour 
{
	public GameObject gameOverPanel;
	public GameObject iapPanel;
	public Text score;

	public void AddCoins()
	{
		PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 1);
		score.text = PlayerPrefs.GetInt("Score").ToString();
	}

	public void BackButton()
	{
		gameOverPanel.SetActive(true);
		iapPanel.SetActive(false);
	}
}
