using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Analytics;
using System.Collections.Generic;

public class CoinController : MonoBehaviour 
{
	public GameObject scoreText;

	private Text text;

	// Use this for initialization
	void Start () 
	{
		scoreText = GameObject.Find("Score");
		text = scoreText.GetComponent<Text>();
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		Destroy(gameObject);
		if (coll.gameObject.tag == "Player")
		{
			int i = PlayerPrefs.GetInt("Score") + 1;
			Analytics.CustomEvent("CoinCollected",
				new Dictionary<string, object>
				{
					{ "event", "inGameCoinCollected" },
					{ "coinsGiven", "1" }
				});
			PlayerPrefs.SetInt("Score", i);
			text.text = PlayerPrefs.GetInt("Score").ToString();
		}
	}
}
