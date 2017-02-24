using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public Transform playerTransform;
	private Vector3 _cameraStartingPosition;

	// Grab the starting camera transform to use it as a reference to move with the player and set relative to player position
	void Start ()
	{
		if (this.playerTransform == null) {
			Debug.Break ();
			throw new UnityException ("Player object not found by camera. Aborting.");
		}

		this._cameraStartingPosition = this.GetComponent<Transform> ().position;
		transform.position = this.playerTransform.position + this._cameraStartingPosition;
	}
	
	// Update the camera position based on the player's movement (only left and right with the screen)
	void Update ()
	{
		Vector3 cameraPosition = new Vector3 (
			                         this.playerTransform.position.x + this._cameraStartingPosition.x, 
			                         this._cameraStartingPosition.y,
			                         this._cameraStartingPosition.z
		                         );
		transform.position = cameraPosition;
	}
}
