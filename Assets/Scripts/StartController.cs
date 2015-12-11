using UnityEngine;
using System.Collections;
using UnityEngine.Analytics;
using System.Collections.Generic;

public class StartController : MonoBehaviour 
{
	public GameObject startPanel;
	public GameObject gameOverPanel;
	public GameObject iapPanel;
	
	private bool check = true;
	// Update is called once per frame
	
	void Start ()
	{
		gameOverPanel.SetActive(false);
		iapPanel.SetActive(false);
	}
	void Update () 
	{
		if (!check)
		{
			return;
		}
		#if UNITY_EDITOR || UNITY_STANDALONE_WIN
		if (Input.GetKey(KeyCode.Space))
		{
			check = false;
			GameParameters.gameStarted = true;
			startPanel.SetActive(false);
			Everyplay.StartRecording();
		}
		#endif
		
		#if UNITY_IOS && !UNITY_EDITOR
		if (Input.touchCount > 0 && !GameParameters.gameStarted)
		{
			check = false;
			GameParameters.gameStarted = true;
			startPanel.SetActive(false);
			Everyplay.StartRecording();
		}
		#endif
	}
}