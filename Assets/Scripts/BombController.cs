using UnityEngine;
using System.Collections;
using UnityEngine.Analytics;
using UnityAnalyticsHeatmap;

public class BombController : MonoBehaviour 
{
	public GameObject explosion;

	private GameObject gameOverController;
	private GameOverController goc;

	void Start()
	{
		gameOverController = GameObject.Find("GameOverController");
		goc = gameOverController.GetComponent<GameOverController>();
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Ground" || coll.gameObject.tag == "Player")
		{
			Destroy(gameObject);
			GameObject exp = Instantiate(explosion, transform.position, transform.rotation) as GameObject;
			Destroy(exp, 3f);
			foreach (Transform t in explosion.transform)
			{
				t.gameObject.GetComponent<Renderer>().sortingLayerName = "Particles";
				if (t.gameObject.name == "flash")
				{
					foreach (Transform t2 in t.transform)
					{
						t2.gameObject.GetComponent<Renderer>().sortingLayerName = "Particles";
					}
				}
			}


			if (coll.gameObject.tag == "Player")
			{
				HeatmapEvent.Send("PlayerDeath", coll.gameObject.transform.position, Time.timeSinceLevelLoad);
				Debug.Log("DEAD @ " + coll.gameObject.transform.position);
				Animator anim = coll.gameObject.GetComponent<Animator>();
				anim.SetBool("dead", true);
				if (GameParameters.gameStarted)
				{
					GameParameters.gameStarted = false;
					goc.ShowGameOverPanel();
				}
			}
		}
	}
}
