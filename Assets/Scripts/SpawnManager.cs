using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour 
{
	public GameObject bomb;
	public GameObject coin;
	public GameObject spawnYPos;
	public GameObject leftPos;
	public GameObject rightPos;
	public GameObject explosion;
	public int bombLimit = 10;
	public float minSpawnTime = 0.3f;
	public float objectsToSpawn = 3;

	private float spawnTime = 1f;
	private int bombCount = 0;


	// Use this for initialization
	void Start () 
	{
		StartCoroutine("Spawn");
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	IEnumerator Spawn()
	{
		yield return new WaitForSeconds(spawnTime);
		if (GameParameters.gameStarted)
		{
			for (int i = 0; i < objectsToSpawn; i++)
			{
				GameObject go;
				int x = Random.Range(1, 100);
				Vector3 pos = new Vector3(Random.Range(leftPos.transform.position.x, rightPos.transform.position.x), spawnYPos.transform.position.y, 0f);
				if (x < 33) //I'll spawn a coin
				{
					go = Instantiate(coin, pos, Quaternion.identity) as GameObject;
				}
				else
				{
					go = Instantiate(bomb, pos, Quaternion.identity) as GameObject;
				}
				go.GetComponent<SpriteRenderer>().sortingLayerName = "Foreground";
				go.GetComponent<SpriteRenderer>().sortingOrder = 2;
			}
			bombCount++;
			if (bombCount == 10)
			{
				bombCount = 0;
				if (spawnTime > minSpawnTime)
				{
					spawnTime -= 0.1f;
				}
			}
		}
		StartCoroutine("Spawn");
	}
}
