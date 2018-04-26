using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class MissionGenerator : MonoBehaviour {

    public int age;
    public int loyalty;

    public string gender;
    public string ethnicity;
    public string sexID;
    public string occupation;
    public string religion;
    public string maritalStatus;

    bool isIntroFinished = false;

    public Text missionText;

    public AudioClip gameStartAudio;
    public AudioSource source;

    // Use this for initialization
    void Start () {
        source.clip = gameStartAudio;
        source.PlayDelayed(2);


    }

    // Update is called once per frame
    void Update() {

        if (source.time > 37) {
            Mission1();
        } 

    }

    void CallMission() {
        
    }
   
    void Mission1 () {
        missionText.text = "Mission Objectives: \nTarget is a political dissenter posting anti-government propaganda on the local state-sponsored university’s campus. Target may not necessarily be a student. Shows knowledge about university’s security systems. ";

        occupation = "Student";

    }
}
