using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadHelper : MonoBehaviour
{
    public AudioSource startMusic;

    void Start()
    {
        startMusic.loop = true;
        startMusic.Play();
    }
    public void SceneLoader(bool level)
    {
        if (level)
        {
            SceneManager.LoadScene("Marbling");
        }
        else
        {
            Application.Quit();
        }
    }
}
