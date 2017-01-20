using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
	// Load a scene from the main menu based on its name as an input
	public void LoadScene (string sceneName)
	{
		SceneManager.LoadScene (sceneName);
	}
}
