using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    public Text missionText;

    float timeLeft = 30.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        Debug.Log(timeLeft);
        if (timeLeft < 0) {
            missionText.text = "Mission Objectives \nTime's up.";
        }

             
	}
}
