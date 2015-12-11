using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour 
{
	public GameObject scoreObject;

	private Text scoreText;

	// Use this for initialization
	void Start () 
	{
		int score = 0;
		scoreText = scoreObject.GetComponent<Text>();
		if (PlayerPrefs.HasKey("Score"))
		{
			score = PlayerPrefs.GetInt("Score");
		}
		scoreText.text = score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
