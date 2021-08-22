using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    GameObject[] pauseObjects;
	void Start()
	{
		Time.timeScale = 1;
		pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPaused");
		hidePausedScreen();
	}

	// Update is called once per frame
	void Update()
	{

		//uses the p button to pause and unpause the game
		if (Input.GetKeyDown(KeyCode.P) || Input.GetKey(KeyCode.Escape))
		{
			if (Time.timeScale == 1)
			{
				Time.timeScale = 0;
				showPauseScreen();
			}
			else if (Time.timeScale == 0)
			{
				Time.timeScale = 1;
				hidePausedScreen();
			}
		}
	}

	public void Restart()
	{
		Application.LoadLevel("Marbling");
	}

	public void LoadLevel(string level)
	{
		Application.LoadLevel(level);
	}

	public void Quit()
	{
		Application.Quit();
	}

	public void pauseControl()
	{
		if (Time.timeScale == 1)
		{
			Time.timeScale = 0;
			showPauseScreen();
		}
		else if (Time.timeScale == 0)
		{
			Time.timeScale = 1;
			hidePausedScreen();
		}
	}

	public void showPauseScreen()
	{
		foreach (GameObject pauseItem in pauseObjects)
		{
			pauseItem.SetActive(true);
		}
	}

	public void hidePausedScreen()
	{
		foreach (GameObject pauseItem in pauseObjects)
		{
			pauseItem.SetActive(false);
		}
	}
}
