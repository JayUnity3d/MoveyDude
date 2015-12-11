using UnityEngine;
using System.Collections;

public class ExplosionController : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		Destroy(gameObject, 3.0f);
	}
}
