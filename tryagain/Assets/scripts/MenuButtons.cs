using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject creditMenu;

    private void Awake()
    {

    }

    void Start ()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        creditMenu.SetActive(false);
    }
	

	void Update ()
    {
		
	}

    public void MainMenu()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        creditMenu.SetActive(false);

    }

    public void StartGame()
    {
        Application.LoadLevel(1);
        Debug.Log("start game");
    }

    public void GameOptions()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
        creditMenu.SetActive(false);
    }
    public void GameCredits()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);
        creditMenu.SetActive(true);
    }

    public void ExitGame()
    {
        Debug.Log("exit");
    }
}
