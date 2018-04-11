using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Game : MonoBehaviour
{
    public CanvasRenderer Fade;
    private UnityAction FadeEvent;
    private List<GameObject> objectsToFade = new List<GameObject>();
    private bool fadeInAndOut = false;

    public GameObject startScreen;
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
    private float fadeTime = 0.5f;
    private enum FadeState
    {
        faded,
        fadingIn,
        active,
        fadingOut
    }
    private FadeState isFading = FadeState.fadingOut;

    // Use this for initialization
    void Start ()
    {
        startScreen.SetActive(true);
        _paused = true;
        gameMenu.SetActive(false);
        gameSettings.SetActive(false);
        videoSettings.SetActive(false);
        audioSettings.SetActive(false);
        Fade.SetAlpha(1);
        Fade.gameObject.SetActive(true);
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
                if (startScreen.activeSelf)
                {
                    ToggleStartScreen(false);
                }
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
                FadeEvent += handleObjectsToFadeList;
                FadeEvent.Invoke();
                emptyFadeEvent();
                if (fadeInAndOut)
                {
                    isFading = FadeState.fadingOut;
                }
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

    public void ToggleStartScreen(bool toggle)
    {
        if (!toggle)
        {
            //isFading = FadeState.fadingIn;
            objectsToFade.Add(startScreen);
            fadeInAndOut = true;
            FadeScreen(true);
            _paused = false;
        }
        else
        {
            //startScreen.SetActive(true);
            objectsToFade.Add(startScreen);
            fadeInAndOut = true;
            FadeScreen(true);
            _paused = true;
        }
    }

    public void FadeScreen(bool toggle)
    {
        if (!toggle)
        {
            isFading = FadeState.fadingOut;
        }
        else
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
    private void handleObjectsToFadeList()
    {
        for (int i = 0; i < objectsToFade.Count; i++)
        {
            objectsToFade[i].SetActive(!objectsToFade[i].activeSelf);
        }
        objectsToFade.Clear();
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
        if (isFading == FadeState.active)
        {
            Application.LoadLevel(0);
            Debug.Log("back to main");
        }
        else if (isFading == FadeState.faded)
        {
            fadeInAndOut = false;
            FadeScreen(true);
            FadeEvent += BackToMain;
        }
    }

    public void RestartLevel()
    {
        if (isFading == FadeState.active)
        {
            Application.LoadLevel(1);
            Debug.Log("start game");
        }
        else if (isFading == FadeState.faded)
        {
            fadeInAndOut = false;
            FadeScreen(true);
            FadeEvent += RestartLevel;
        }
    }

}
