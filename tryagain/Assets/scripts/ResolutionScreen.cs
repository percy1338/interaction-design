using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ResolutionScreen : MonoBehaviour {

    public CanvasRenderer Fade;
    private UnityAction FadeEvent;
    private List<GameObject> objectsToFade = new List<GameObject>();
    private bool fadeInAndOut = false;

    public GameObject resolutionScreen;
    public LevelCircle levelCircle;
    public Image[] achievements;
    private int unlockCounter = 0;
    public Image mapUnlock;
    public GameObject TextBalloon;
    private float unlockDelay = 0.5f;
    private float lastUnlock;
    private bool finished = false;

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
    void Start () {
        resolutionScreen.SetActive(true);
        Fade.SetAlpha(1);
        Fade.gameObject.SetActive(true);
        levelCircle.FakeLevelUp();
    }
	
	// Update is called once per frame
	void Update () {
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

        if (!finished) {
            if (levelCircle.GetDone())
            {
                if (Time.time - lastUnlock >= unlockDelay)
                {
                    if (unlockCounter < achievements.Length)
                    {
                        achievements[unlockCounter].gameObject.SetActive(true);
                        unlockCounter++;
                    }
                    else
                    {
                        mapUnlock.gameObject.SetActive(true);
                        finished = true;
                    }
                    lastUnlock = Time.time;
                }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            TextBalloon.SetActive(false);
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

    public void ShowTextBalloon(string text)
    {
        TextBalloon.GetComponentInChildren<Text>().text = text;
        //TextBalloon.GetComponentInChildren()<Text>.text = text;
        TextBalloon.SetActive(true);
        TextBalloon.transform.position = Input.mousePosition;
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
