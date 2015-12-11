using UnityEngine;
using System.Collections;
/// <summary>
/// Hatman sprite movements
/// </summary>
public class Hatman: MonoBehaviour {
	public float maxspeed = 2f; //walk speed
	public GameObject leftEdge;
	public GameObject rightEdge;
	public Camera camera;
	Animator anim;
	private bool faceright; //face side of sprite activated
	//--
	void Start () {
		faceright=true;//Default right side
		anim = this.gameObject.GetComponent<Animator> ();
		anim.SetBool ("walk", false);//Walking animation is deactivated
	}

	void Update () 
	{
		if (!GameParameters.gameStarted)
		{
			return;
		}
		float move;
		//--WALKING
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
		move = Input.GetAxis ("Horizontal");
		//END WALKING

#endif

#if UNITY_IOS && !UNITY_EDITOR
		if (Input.touchCount > 0)
		{
			//Debug.Log("Position = " + Input.GetTouch(0).position);
			//Debug.Log("Screenpos = " + camera.WorldToScreenPoint(Input.GetTouch(0).position));
			if (Input.GetTouch(0).position.x < camera.pixelWidth / 2)
			{
				move = -1f;
			}
			else
			{
				move = 1f;
			}
		}
		else
		{
			move = 0f;
		}
#endif
		GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxspeed, GetComponent<Rigidbody2D>().velocity.y);
		if(move>0)
		{//Go right
			anim.SetBool ("walk", true);//Walking animation is activated
			if(faceright==false)
			{
				Flip ();
			}
		}
		
		if(move==0)
		{//Stop
			anim.SetBool ("walk", false);
		}			
		
		if((move<0))
		{//Go left
			anim.SetBool ("walk", true);
			if(faceright==true)
			{
				Flip ();
			}
		}

		CheckEdges();
	}

	void Flip()
	{
		faceright=!faceright;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void CheckEdges()
	{
		float xPos = Mathf.Clamp(transform.position.x, leftEdge.transform.position.x, rightEdge.transform.position.x);
		transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
	}
}
