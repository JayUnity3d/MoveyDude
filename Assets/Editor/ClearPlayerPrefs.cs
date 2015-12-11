using UnityEngine;
using UnityEditor;
using System;


public class ClearPlayerPrefs : MonoBehaviour
{
	[MenuItem( "Tools/Clear PlayerPrefs" )]
	static void ClearPrefs()
	{
		PlayerPrefs.DeleteAll();
		Debug.Log("PlayerPrefs cleared!");
	}
}

