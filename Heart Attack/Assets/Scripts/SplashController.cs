using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashController : MonoBehaviour
{
	// Reference to scene component variables
	public Image logoImage;

	// Image and text fade variables
	public float fadeDuration = 3.0f;
	public float waitDuration = 2.0f;
	private Color _invisible = new Color (1.0f, 1.0f, 1.0f, 0.0f);
	private Color _visible = new Color (1.0f, 1.0f, 1.0f, 1.0f);
	private bool _startFadeIn = false;
	private bool _startFadeOut = false;
	private bool _fadedIn = false;
	private bool _fadedOut = false;
	private bool _waitForSceneChange = false;
	private bool _loadScene = false;
	private float _startTime;

	// Start splash logo as invisible and setup fading to begin with each new frame update
	void Start ()
	{
		logoImage.color = _invisible;
		StartCoroutine (WaitForFadeIn ());
	}

	// Wait some duration of time before beginning to fade in
	IEnumerator WaitForFadeIn ()
	{
		yield return new WaitForSeconds (waitDuration);
		_startFadeIn = true;
		_startTime = Time.time;
	}

	// After fading in, wait some duration until starting to fade out
	IEnumerator WaitForFadeOut ()
	{
		yield return new WaitForSeconds (waitDuration);
		_startFadeOut = true;
		_startTime = Time.time;
	}

	// After fading out, wait some duration until the scene can be changed
	IEnumerator WaitForChangeScene ()
	{
		yield return new WaitForSeconds (waitDuration);
		_loadScene = true;
	}

	// Update is called every frame, controlling the fading of the text and images on the screen as well as scene change
	void Update ()
	{

		// Fade in after waiting
		if (_startFadeIn && !_fadedIn) {
			float timeStep = (Time.time - _startTime) / fadeDuration;
			Color fadingColor = new Color (1.0f, 1.0f, 1.0f, Mathf.SmoothStep (0.0f, 1.0f, timeStep));
			logoImage.color = fadingColor;
			if (fadingColor == _visible) {
				_fadedIn = true;
				StartCoroutine (WaitForFadeOut ());
			}
		}

		// Fade out after fade in and waiting
		if (_fadedIn && _startFadeOut && !_fadedOut) {
			float timeStep = (Time.time - _startTime) / fadeDuration;
			Color fadingColor = new Color (1.0f, 1.0f, 1.0f, Mathf.SmoothStep (1.0f, 0.0f, timeStep));
			logoImage.color = fadingColor;
			if (fadingColor == _invisible) {
				_fadedOut = true;
			}
		}

		// Wait once faded out to change scenes
		if (_fadedOut && !_waitForSceneChange) {
			_waitForSceneChange = true;
			StartCoroutine (WaitForChangeScene ());
		}

		if (_waitForSceneChange && _loadScene) {
			SceneManager.LoadScene ("Main Menu");
		}
	}

}
