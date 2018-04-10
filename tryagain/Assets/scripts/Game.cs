using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject gameMenu;
    public GameObject optionsMenu;
    public GameObject gameSettings;
    public GameObject videoSettings;
    public GameObject audioSettings;

    public GameObject pauseHeader;

    public WeaponWheel weaponWheel;
    public GameObject crossHair;
    public GameObject HUD;

    public GameObject HalfHealth;

    private bool _paused;

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
            if(!_paused)
            {
                OpenMenu();
                weaponWheel.ToggleWheel(false);
                crossHair.SetActive(true);
            }
            else
            {
                CloseMenu();
            }
        }
        if (!_paused) {
            if (Input.GetKeyDown(KeyCode.Mouse2))
            {
                weaponWheel.ToggleWheel(true);
                crossHair.SetActive(false);
            }
            else if (Input.GetKeyUp(KeyCode.Mouse2))
            {
                weaponWheel.ToggleWheel(false);
                crossHair.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.H))
            {
                HalfHealth.SetActive(!HalfHealth.activeSelf);
            }
        }
    }

    public void OpenMenu()
    {
        gameMenu.SetActive(true);
        optionsMenu.SetActive(false);
        gameSettings.SetActive(false);
        videoSettings.SetActive(false);
        audioSettings.SetActive(false);
        _paused = true;
        pauseHeader.SetActive(true);
    }

    public void CloseMenu()
    {
        gameMenu.SetActive(false);
        optionsMenu.SetActive(false);
        gameSettings.SetActive(false);
        videoSettings.SetActive(false);
        audioSettings.SetActive(false);
        _paused = false;
        pauseHeader.SetActive(false);
    }

    public void OptionsMenu()
    {
        gameMenu.SetActive(false);
        optionsMenu.SetActive(true);
        gameSettings.SetActive(false);
        videoSettings.SetActive(false);
        audioSettings.SetActive(false);
    }

    public void GameSettings()
    {
        gameMenu.SetActive(false);
        optionsMenu.SetActive(false);
        gameSettings.SetActive(true);
        videoSettings.SetActive(false);
        audioSettings.SetActive(false);
    }
    public void VideoSettings()
    {
        gameMenu.SetActive(false);
        optionsMenu.SetActive(false);
        gameSettings.SetActive(false);
        videoSettings.SetActive(true);
        audioSettings.SetActive(false);
    }

    public void AudioSettings()
    {
        gameMenu.SetActive(false);
        optionsMenu.SetActive(false);
        gameSettings.SetActive(false);
        videoSettings.SetActive(false);
        audioSettings.SetActive(true);
    }

    public void BackToMain()
    {
        Application.LoadLevel(0);
        Debug.Log("start game");
    }

    public void RestartLevel()
    {
        Application.LoadLevel(1);
        Debug.Log("start game");
    }

}
