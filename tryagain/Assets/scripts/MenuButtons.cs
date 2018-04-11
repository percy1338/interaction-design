using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MenuButtons : MonoBehaviour
{
    public GameObject Background;
    public CanvasRenderer Fade;
    private UnityAction FadeEvent;

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

    private float fadeTime = 0.5f;
    private enum FadeState
    {
        faded,
        fadingIn,
        active,
        fadingOut
    }
    private FadeState isFading = FadeState.fadingOut;


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
        Fade.SetAlpha(1);
        Fade.gameObject.SetActive(true);
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
        if (isFading == FadeState.fadingIn)
        {
            if (!Fade.gameObject.activeSelf)
            {
                Fade.gameObject.SetActive(true);
                Fade.SetAlpha(0);
            }
            Fade.SetAlpha(Fade.GetAlpha() + ((1 / fadeTime) * Time.deltaTime));
            if (Fade.GetAlpha() >= 1)
            {
                isFading = FadeState.active;
                Fade.SetAlpha(1);
                FadeEvent.Invoke();
                emptyFadeEvent();
            }
        }
        else if (isFading == FadeState.fadingOut)
        {
            Fade.SetAlpha(Fade.GetAlpha() - ((1 / fadeTime) * Time.deltaTime));
            if (Fade.GetAlpha() <= 0)
            {
                isFading = FadeState.faded;
                Fade.SetAlpha(0);
                Fade.gameObject.SetActive(false);
            }
        }
    }

    public void FadeScreen(bool toggle)
    {
        if (!toggle)
        {
            isFading = FadeState.fadingOut;
        } else
        {
            isFading = FadeState.fadingIn;
        }
    }
    private void emptyFadeEvent()
    {
        for (int i = 0; i < FadeEvent.GetInvocationList().Length; i++)
        {
            FadeEvent.GetInvocationList()[i] = null;
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

    public void Tutorialmenu(bool toggle)
    {
        TutorialMenu.SetActive(toggle);
        //VideoOptions.SetActive(false);
        //AudioOptions.SetActive(false);
        //changeMenu(TutorialMenu, -1);
    }

    public void StartGame()
    {
        if (isFading == FadeState.active)
        {
            Application.LoadLevel(1);
            Debug.Log("start game");
        }
        else if (isFading == FadeState.faded)
        {
            FadeScreen(true);
            FadeEvent += StartGame;
        }
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
