using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
	public GameObject continueOption;
	public GameObject creditsOption;

	void Start ()
	{
		this.ShowContinueOption ();
		this.ShowCreditsOption ();
	}

	// Overwrite the player's previous game status with a new game
	public void NewGame ()
	{
		PlayerPrefs.SetInt ("Level", 0);
	}

	// Decide whether or not to display the option for continue based on if is already in the middle of a game
	public void ShowContinueOption ()
	{
		if (PlayerPrefs.HasKey ("Level") && PlayerPrefs.GetInt ("Level") > 0) {
			this.continueOption.SetActive (true);
		}

		this.continueOption.SetActive (false);
	}

	// Decide whether or not to display the option for credits based on if a player has already completed the game
	public void ShowCreditsOption ()
	{
		if (PlayerPrefs.HasKey ("Complete") && PlayerPrefs.GetInt ("Complete") == 1) {
			this.creditsOption.SetActive (true);
		}

		this.creditsOption.SetActive (false);
	}

	// Load a scene from the main menu based on its name as an input
	public void LoadScene (string sceneName)
	{
		SceneManager.LoadScene (sceneName);
	}

}
