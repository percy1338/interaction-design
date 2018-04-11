using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCircle : MonoBehaviour {

    public Text LevelText;
    public Image LevelProgress;
    private float targetLevelProgressFill;
    private int levelUps;
    private float levelsToGain = 2.5f;
    private float levelUpSpeed = 0.01f;
    private bool finished = true;

	// Use this for initialization
	void Start () {
        //FakeLevelUp();

    }
	
	// Update is called once per frame
	void Update () {
        if (!finished)
        {
            if (levelUps <= 0)
            {
                if (LevelProgress.fillAmount < targetLevelProgressFill)
                {
                    LevelProgress.fillAmount += levelUpSpeed;
                } else
                {
                    finished = true;
                }
            }
            else
            {
                if (LevelProgress.fillAmount >= 1)
                {
                    LevelProgress.fillAmount = 0;
                    LevelText.text = "" + ((int)int.Parse(LevelText.text) + 1);
                    levelUps--;
                }
                LevelProgress.fillAmount += levelUpSpeed;
            }
        }
    }

    public void FakeLevelUp()
    {
        targetLevelProgressFill = (LevelProgress.fillAmount + levelsToGain) % 1;
        levelUps = (int)Mathf.Floor(LevelProgress.fillAmount + levelsToGain);
        finished = false;

    }

    public bool GetDone()
    {
        return finished;
    }
}
