using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject creditMenu;
    public GameObject TutorialMenu;
    public GameObject playMenu;

    private void Awake()
    {

    }

    void Start ()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        creditMenu.SetActive(false);
        playMenu.SetActive(false);
        TutorialMenu.SetActive(false);
    }
	

	void Update ()
    {
		
	}

    public void MainMenu()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        creditMenu.SetActive(false);
        playMenu.SetActive(false);
        TutorialMenu.SetActive(false);

    }

    public void StartGameMenu()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);
        creditMenu.SetActive(false);
        playMenu.SetActive(true);
        TutorialMenu.SetActive(false);
    }

    public void Tutorialmenu()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);
        creditMenu.SetActive(false);
        playMenu.SetActive(false);
        TutorialMenu.SetActive(true);
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
        playMenu.SetActive(false);
        TutorialMenu.SetActive(false);
    }
    public void GameCredits()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);
        creditMenu.SetActive(true);
        playMenu.SetActive(false);
        TutorialMenu.SetActive(false);
    }

    public void ExitGame()
    {
        Debug.Log("exit");
    }
}
