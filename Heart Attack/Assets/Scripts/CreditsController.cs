using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsController : MonoBehaviour
{
	public RectTransform creditsTransform;
	public float creditSpeed = 5.0f;

	private float _minimum = 0.0f;
	private float _maximum = 1.0f;
	private float _length;
	private float _startTime;

	// Start with the text below the bottom of the screen
	void Start ()
	{
		if (this.creditsTransform == null) {
			Debug.Break ();
			throw new MissingReferenceException ("Credits text not found by credits.  Aborting.");
		}

		this._length = Mathf.Abs (this.creditsTransform.anchorMax.y - this.creditsTransform.anchorMin.y);
		this.creditsTransform.anchorMin = new Vector2 (this.creditsTransform.anchorMin.x, this._minimum - this._length);
		this.creditsTransform.anchorMax = new Vector2 (this.creditsTransform.anchorMax.x, this._minimum);
		this._startTime = Time.time;
	}
	
	// Starting on the first update frame, move the credits anchors (and thus the text) from below the screen to above the screen
	void Update ()
	{
		float timeStep = (Time.time - this._startTime) / creditSpeed;
		this.creditsTransform.anchorMin = new Vector2 (this.creditsTransform.anchorMin.x, Mathf.SmoothStep (this._minimum - this._length, this._maximum, timeStep));
		this.creditsTransform.anchorMax = new Vector2 (this.creditsTransform.anchorMax.x, Mathf.SmoothStep (this._minimum, this._maximum + this._length, timeStep));
	}
}
