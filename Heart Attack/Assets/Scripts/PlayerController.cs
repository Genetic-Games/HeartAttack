using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed = 1.0f;
	private Rigidbody _rbody;

	// Use this for initialization
	void Start ()
	{
		_rbody = GetComponent<Rigidbody> ();

		if (_rbody == null) {
			throw new UnityException ("Player rigidbody not found. Aborting.");
			Debug.Break ();
		}
	}
	
	// FixedUpdate is called once per frame at the end of processing all other calculations
	void FixedUpdate ()
	{

		// Movement only occurs on the X and Z axes, since the Y-axis is vertical (no player movement straight up)
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		_rbody.AddForce (speed * moveHorizontal, 0.0f, speed * moveVertical, ForceMode.VelocityChange);
	}
}
