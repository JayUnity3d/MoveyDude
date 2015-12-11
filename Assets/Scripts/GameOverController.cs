using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using UnityEngine.Analytics;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour 
{
	public GameObject gameOverPanel;
	public GameObject iapPanel;
	
	private Text text;
	public void ShowGameOverPanel()
	{
		StartCoroutine("ShowPanel");
	}
	public void Restart()
	{
		//Application.LoadLevel(Application.loadedLevel);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	
	IEnumerator ShowPanel()
	{
		yield return new WaitForSeconds(3f);
		gameOverPanel.SetActive(true);
	}
	
	public void ShowRewardedAd()
	{
		if (Advertisement.IsReady("rewardedVideo"))
		{
			var options = new ShowOptions { resultCallback = HandleShowResult };
			Advertisement.Show("rewardedVideo", options);
		}
	}
	
	public void ShowEveryplay()
	{
		Everyplay.SetMetadata("Coins", PlayerPrefs.GetInt("Score"));
		Everyplay.ShowSharingModal();
	}

	public void ShowIAP()
	{
		iapPanel.SetActive(true);
		gameOverPanel.SetActive(false);
	}
	
	private void HandleShowResult(ShowResult result)
	{
		switch (result)
		{
		case ShowResult.Finished:
			Debug.Log("The ad was successfully shown.");
			PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 10);
			
			GameObject textGo = GameObject.Find("Score");
			text = textGo.GetComponent<Text>();
			text.text = PlayerPrefs.GetInt("Score").ToString();
			Analytics.CustomEvent("AdReward",
				new Dictionary<string, object>
				{
					{ "event", "AdReward" },
					{ "coinsGiven", "10" }
				});
			break;
		case ShowResult.Skipped:
			Debug.Log("The ad was skipped before reaching the end.");
			break;
		case ShowResult.Failed:
			Debug.LogError("The ad failed to be shown.");
			break;
		}
	}
}