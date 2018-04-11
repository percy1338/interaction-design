using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobbingImage : MonoBehaviour {

    public float BobDelay;
    public Vector3 BobDistance;
    public float BobTime;
    public float BobInterval;
    public bool upAndDown;

    private Vector3 startPos;

    private bool bobPhase = true;
    private float prevBob = 0;

	// Use this for initialization
	void Start () {
        startPos = transform.localPosition;

    }
	
	// Update is called once per frame
	void Update () {
        if (Time.timeSinceLevelLoad >= BobDelay)
        {
            if (Time.time - prevBob >= BobInterval)
            {
                bob();
            }
        }
	}

    void bob()
    {
        if (bobPhase)
        {
            transform.localPosition += (BobDistance / (BobTime / Time.deltaTime));
            if ((startPos - transform.localPosition).magnitude >= BobDistance.magnitude)
            {
                bobPhase = false;
                if (!upAndDown)
                {
                    prevBob = Time.time;
                }
            }
        }
        else
        {
            transform.localPosition -= (BobDistance / (BobTime / Time.deltaTime));
            if ((startPos - transform.localPosition).magnitude <= (BobDistance / (BobTime / Time.deltaTime)).magnitude)
            {
                bobPhase = true;
                prevBob = Time.time;
            }
        }
    }
}
