using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class MissionGenerator : MonoBehaviour
{

    public static string objAge;
    public static string objLyalty;

    public static string objGender;
    public static string objEthnicity;
    public static string objSexID;
    public static string objOccupation;
    public static string objReligion;
    public static string obJmaritalStatus;

    bool isIntroFinished = false;

    public Text missionText;

    public AudioClip gameStartAudio;
    public AudioSource source;

    // Use this for initialization
    void Start()
    {
        source.clip = gameStartAudio;
        source.PlayDelayed(2);


    }

    // Update is called once per frame
    void Update()
    {

        if (source.time > 37)
        {
            CallMission();
        }

    }

    void CallMission()
    {

    }
}