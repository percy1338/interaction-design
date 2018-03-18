using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject gameMenu;
    public GameObject gameSettings;
    public GameObject videoSettings;
    public GameObject audioSettings;

	// Use this for initialization
	void Start ()
    {
        gameMenu.SetActive(false);
        gameSettings.SetActive(false);
        videoSettings.SetActive(false);
        audioSettings.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameMenu.active == false)
            {
                OpenMenu();
            }
            else
            {
                CloseMenu();
            }
        }
	}

    public void OpenMenu()
    {
        gameMenu.SetActive(true);
        gameSettings.SetActive(false);
        videoSettings.SetActive(false);
        audioSettings.SetActive(false);
    }

    public void CloseMenu()
    {
        gameMenu.SetActive(false);
        gameSettings.SetActive(false);
        videoSettings.SetActive(false);
        audioSettings.SetActive(false);
    }

    public void GameSettings()
    {
        gameMenu.SetActive(false);
        gameSettings.SetActive(true);
        videoSettings.SetActive(false);
        audioSettings.SetActive(false);
    }
    public void VideoSettings()
    {
        gameMenu.SetActive(false);
        gameSettings.SetActive(false);
        videoSettings.SetActive(false);
        audioSettings.SetActive(false);
    }

    public void AudioSettings()
    {
        gameMenu.SetActive(false);
        gameSettings.SetActive(false);
        videoSettings.SetActive(false);
        audioSettings.SetActive(true);
    }

}
