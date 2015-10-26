using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public int ID=0;
	public enemystatus stat = enemystatus.spawned;
	public Animator animator;
	public AI1 AIScript;
	public GameController ParentScript;


	public float HP = 1f;

	private bool killed = false;

	public void tapped()
	{
		HP -= 1f;
		if (HP <= 0)
			kill ();
	}

	public void kill()
	{
		stat = enemystatus.killed;
		ParentScript.killenemy (ID);
		AIScript.speed = 0;
	}

	// Use this for initialization
	void Start () {

	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		
		if (coll.gameObject.tag == "Finish") {
			ParentScript.enemyscaped(ID);
		}
		
	}
	// Update is called once per frame
	void Update () {
		if (killed)
			Destroy (this);
		if (stat == enemystatus.spawned) {

			if (Input.GetKey(KeyCode.Space))
			{
				tapped();
			}
			if (Input.touchCount == 1) {
				Vector3 wp = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
				Vector2 touchPos = new Vector2 (wp.x, wp.y);
				if (GetComponent<Collider2D>() == Physics2D.OverlapPoint (touchPos)) {
					tapped ();
				}
			}


		} else if (stat == enemystatus.killed) {
			//playanimation;
			killed = true;
		}
	}
}
