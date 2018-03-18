using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Options : MonoBehaviour
{
   public GameObject gameOptions;
   public GameObject VideoOptions;
   public GameObject AudioOptions;

	// Use this for initialization
	void Start ()
    {
        gameOptions.SetActive(false);
        VideoOptions.SetActive(false);
        AudioOptions.SetActive(false);
    }
	
    public void GameOptions()
    {
        gameOptions.SetActive(true);
        VideoOptions.SetActive(false);
        AudioOptions.SetActive(false);
    }


    public void Audio()
    {
        gameOptions.SetActive(false);
        VideoOptions.SetActive(false);
        AudioOptions.SetActive(true);
    }


    public void Video()
    {
        gameOptions.SetActive(false);
        VideoOptions.SetActive(true);
        AudioOptions.SetActive(false);
    }
    public void Back()
    {
        gameOptions.SetActive(false);
        VideoOptions.SetActive(false);
        AudioOptions.SetActive(false);
    }
}
