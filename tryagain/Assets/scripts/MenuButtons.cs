using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    public GameObject Background;

    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject creditMenu;
    public GameObject TutorialMenu;
    public GameObject playMenu;

    public GameObject GameSettings;
    public GameObject AudioSettings;
    public GameObject videoSettings;

    public int MenuSwitchSpeed;
    public bool SmoothMenuSwitch;
    private bool switchingMenu = false;
    private GameObject currentMenu;
    private GameObject newMenu;
    private int direction;


    private void Awake()
    {

    }

    void Start ()
    {
        mainMenu.SetActive(true);
        currentMenu = mainMenu;
        optionsMenu.SetActive(false);
        creditMenu.SetActive(false);
        playMenu.SetActive(false);
        TutorialMenu.SetActive(false);
    }
	

	void Update ()
    {
        if (switchingMenu)
        {
            if (SmoothMenuSwitch)
            {
                currentMenu.transform.position += new Vector3(direction * ((Mathf.Abs(newMenu.transform.localPosition.x) / Screen.width) + 0.2f) * MenuSwitchSpeed, 0, 0);
                newMenu.transform.position += new Vector3(direction * ((Mathf.Abs(newMenu.transform.localPosition.x) / Screen.width) + 0.2f) * MenuSwitchSpeed, 0, 0);
                Background.transform.position += new Vector3((direction * ((Mathf.Abs(newMenu.transform.localPosition.x) / Screen.width) + 0.2f) * MenuSwitchSpeed) * 0.12f, 0, 0);
            }
            else
            {
                currentMenu.transform.position += new Vector3(direction * MenuSwitchSpeed, 0, 0);
                newMenu.transform.position += new Vector3(direction * MenuSwitchSpeed, 0, 0);
                Background.transform.position += new Vector3((direction * MenuSwitchSpeed) * 0.12f, 0, 0);
            }
            if (Mathf.Abs(currentMenu.transform.localPosition.x) >= Screen.width)
            {
                newMenu.transform.position = new Vector3(0, 1, 90);
                currentMenu.SetActive(false);
                currentMenu = newMenu;
                newMenu = null;
                switchingMenu = false;
            }
        }
    }

    void changeMenu(GameObject pNewMenu, int pDirection)
    {
        if (!switchingMenu) {
            newMenu = pNewMenu;
            newMenu.SetActive(true);
            newMenu.transform.localPosition = currentMenu.transform.localPosition - new Vector3(Screen.width * pDirection, 0, 0);
            direction = pDirection;
            switchingMenu = true;
        }
    }

    public void MainMenu()
    {
        changeMenu(mainMenu, 1);
    }

    public void StartGameMenu(int dir)
    {
        changeMenu(playMenu, dir);
    }

    public void Tutorialmenu()
    {
        changeMenu(TutorialMenu, -1);
    }

    public void StartGame()
    {
        Application.LoadLevel(1);
        Debug.Log("start game");
    }

    public void GameOptions()
    {
        changeMenu(optionsMenu, -1);
    }
    public void GameCredits()
    {
        changeMenu(creditMenu, -1);
    }

    public void ExitGame()
    {
        Debug.Log("exit");
        Application.Quit();
    }

    public void ChangeResolution(int res)
    {
        Screen.SetResolution(res*200+100, res*200+100,true);
    }
}
