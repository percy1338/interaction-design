using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponWheel : MonoBehaviour {

    public GameObject[] WheelComponents;
    private bool selecting = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (selecting) {
            Vector3 mousePos = Input.mousePosition;
            GameObject closestComponent = WheelComponents[0];

            for (int i = 0; i < WheelComponents.Length; i++)
            {
                WheelComponents[i].transform.localScale = new Vector3(1, 1, 1);
                if ((WheelComponents[i].transform.position - mousePos).magnitude < (closestComponent.transform.position - mousePos).magnitude)
                {
                    closestComponent = WheelComponents[i];
                }
            }
            closestComponent.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
        }
	}

    public void ToggleWheel(bool toggle)
    {
        if (toggle)
        {
            selecting = true;
            for (int i = 0; i < WheelComponents.Length; i++)
            {
                WheelComponents[i].SetActive(true);
            }
        }
        else
        {
            selecting = false;
            for (int i = 0; i < WheelComponents.Length; i++)
            {
                WheelComponents[i].SetActive(false);
            }
        }
    }
}
