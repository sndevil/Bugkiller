using UnityEngine;
using System.Collections;

public class AI1 : MonoBehaviour {

	public float speed = 1f;
	public bool goingright = true;
	private Rigidbody2D rbody;

	// Use this for initialization
	void Start () {
		rbody = gameObject.GetComponent<Rigidbody2D> ();
		if (!goingright)
			transform.rotation = new Quaternion (0, 180, transform.rotation.z, transform.rotation.w);
	}
	
	// Update is called once per frame
	void Update () {
		rbody.velocity = new Vector3 (speed, rbody.velocity.y, 0);
	}
}
