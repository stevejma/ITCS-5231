using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour {
	public float minX;
    public float maxX;
	
	public float minY;
	public float maxY;

	public float sensX = 50.0f;
	public float sensY = 50.0f;
	
	float rotationY = 0.0f;
	float rotationX = 95.0f;

    float minFov = 15f;
    float maxFov = 90f;
    float sensitivity = 10f;

    public Camera Camera_01;
    public Camera Camera_02;
    public Camera Camera_03;
    public Camera Camera_04;
    public Camera Camera_05;
    public Camera currentCam;

    public Text infoText;
    public GameObject confirm;

    public static string[] list = new string[8];

    public Text missionText;

    public AudioClip gameStartAudio;
    //public AudioClip easterStartAudio;
    public AudioClip[] newTarget;
    public AudioClip[] newPriorityTarget;
    public AudioSource source;

    private float startTime;

    public static int mission;
    public static int priorityMission;
    public static int totalCount = 1;
    public static int failCount = 0;

    void Start() {
        startTime = Time.time;
        source.clip = gameStartAudio;
        source.PlayDelayed(2);

        CurrentMission();

        Cursor.lockState = CursorLockMode.Locked;
        confirm.SetActive(false);
        Camera_01.enabled = true;
        Camera_02.enabled = false;
        Camera_03.enabled = false;
        Camera_04.enabled = false;
        Camera_05.enabled = false;

        currentCam = Camera_01;
    }

    void Update() {
        float t = Time.time;

        Debug.Log("Timer (seconds): " + (t % 60).ToString("f0"));

        if (Input.GetKeyDown(KeyCode.Alpha1)) {

                Camera_01.enabled = true;
                Camera_02.enabled = false;
                Camera_03.enabled = false;
                Camera_04.enabled = false;
                Camera_05.enabled = false;

                currentCam = Camera_01;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
                Camera_01.enabled = false;
                Camera_02.enabled = true;
                Camera_03.enabled = false;
                Camera_04.enabled = false;
                Camera_05.enabled = false;

                currentCam = Camera_02;

        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) {
                Camera_01.enabled = false;
                Camera_02.enabled = false;
                Camera_03.enabled = true;
                Camera_04.enabled = false;
                Camera_05.enabled = false;

                currentCam = Camera_03;

            }
        if (Input.GetKeyDown(KeyCode.Alpha4)) {
                Camera_01.enabled = false;
                Camera_02.enabled = false;
                Camera_03.enabled = false;
                Camera_04.enabled = true;
                Camera_05.enabled = false;

                currentCam = Camera_04;

        }
        if (Input.GetKeyDown(KeyCode.Alpha5)) {
                Camera_01.enabled = false;
                Camera_02.enabled = false;
                Camera_03.enabled = false;
                Camera_04.enabled = false;
                Camera_05.enabled = true;

                currentCam = Camera_05;

        }

        rotationX += Input.GetAxis("Mouse X") * sensX * Time.deltaTime;
        rotationY += Input.GetAxis("Mouse Y") * sensY * Time.deltaTime;
        //Sets clamp on both x and y movement
        rotationY = Mathf.Clamp(rotationY, minY, maxY);
        rotationX = Mathf.Clamp(rotationX, minX, maxX);
        currentCam.transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);

        float fov = currentCam.fieldOfView;
        fov -= Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        currentCam.fieldOfView = fov;

        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("Mouse is down");

            //RaycastHit hitInfo = new RaycastHit();
            Ray toMouse = currentCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit rhInfo;
            bool didHit = Physics.Raycast(toMouse, out rhInfo, 1000.0f);

            if (didHit) {
                if (rhInfo.transform.gameObject.tag == "xNPC") {
                    Traits getTraits = rhInfo.transform.GetComponent<Traits>();

                    list[0] = getTraits.Storing()[0];
                    list[1] = getTraits.Storing()[1];
                    list[2] = getTraits.Storing()[2];
                    list[3] = getTraits.Storing()[3];
                    list[4] = getTraits.Storing()[4];
                    list[5] = getTraits.Storing()[5];
                    list[6] = getTraits.Storing()[6];
                    list[7] = getTraits.Storing()[7];

                    infoText.text = ("Target Info \nGender: " + getTraits.Storing()[0] +
                        "\nAge: " + getTraits.Storing()[1] +
                        "\nEthnicity: " + getTraits.Storing()[2] +
                        "\nMarital Status: " + getTraits.Storing()[3] +
                        "\nReligious Affiliation: " + getTraits.Storing()[4]+
                        "\nSexual Orientation: " + getTraits.Storing()[5] +
                        "\nParty Loyalty (1-10): " + getTraits.Storing()[6] +
                        "\nOccupation: " + getTraits.Storing()[7]);
   

                    confirm.SetActive(true);
                    Debug.Log("Hit Female");

                } else if (rhInfo.transform.gameObject.tag == "yNPC") {
                    Traits getTraits = rhInfo.transform.GetComponent<Traits>();

                    list[0] = getTraits.Storing()[0];
                    list[1] = getTraits.Storing()[1];
                    list[2] = getTraits.Storing()[2];
                    list[3] = getTraits.Storing()[3];
                    list[4] = getTraits.Storing()[4];
                    list[5] = getTraits.Storing()[5];
                    list[6] = getTraits.Storing()[6];
                    list[7] = getTraits.Storing()[7];

                    infoText.text = ("Target Info \nGender: " + getTraits.Storing()[0] +
                        "\nAge: " + getTraits.Storing()[1] +
                        "\nEthnicity: " + getTraits.Storing()[2] +
                        "\nMarital Status: " + getTraits.Storing()[3] +
                        "\nReligious Affiliation: " + getTraits.Storing()[4] +
                        "\nSexual Orientation: " + getTraits.Storing()[5] +
                        "\nParty Loyalty (1-10): " + getTraits.Storing()[6] +
                        "\nOccupation: " + getTraits.Storing()[7]);

                    confirm.SetActive(true);
                    Debug.Log("Hit Male");

                } else {
                    Debug.Log("Did not hit NPC");
                    confirm.SetActive(false);
                }
            } else {
                Debug.Log("Hit empty space.");
                confirm.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (totalCount % 2 == 1) {
                PassToCompare(mission);
            } else { PickPriorityMission(); }
        }
    }

    void PassToCompare(int compare) {
        if (compare == 2) {
            Mission2(list);
        } else if (compare == 1) {
            Mission1(list);
        } else {
            Mission0(list);
        }
    }

    void CurrentMission() {
        Debug.Log("Target #" + totalCount + " Fails: " + failCount);
        mission = Random.Range(0, 3);
        
        switch(mission) {
            case 2:
                missionText.text = "Mission Objectives: \nTarget is a political dissenter posting anti-government propaganda on the local state-sponsored university’s campus. Target may not necessarily be a student. Shows knowledge about university’s security systems.";
                break;
            case 1:
                missionText.text = "Mission Objectives: \nTarget is a frequent financial sponsor and local leader of Queer rights groups. Historically these groups have been marginally successful disrupting social order among youth culture by promoting literature against State-Cultural laws at privately run educational institutions.";
                break;
            case 0:
                missionText.text = "Mission Objectives: \nTarget is a local ring leader organizing musical venues that promote anti-establishment themes and values through various anonymous online postings. Shows proficiency in avoiding net censures.";
                break;
            default:
                missionText.text = "Error";
                break;
        }
    }

    void PickPriorityMission() {
        Debug.Log("Total Missions: " + totalCount + " Fails: " + failCount);
        priorityMission = Random.Range(0, 3);

        switch (priorityMission) {
            case 2:
                missionText.text = "Mission Objectives: \nTarget is a known dirty bomb maker working for-hire by known terrorist groups. Last few jobs indicate affiliation with Islamic groups based out of Yemen, Saudi Arabia, Syria, and Oman. Travel habits indicate frequent overseas travel. Shows high technical proficiency in explosives and chemical reactivity. Possible military background.";
                PriorityMission2();
                break;
            case 1:
                missionText.text = "Mission Objectives: \nTarget is wanted for carrying out chemical weapons attacks throughout the city. Target is rumored to be in charge of several underground emergency health clinics harboring enemies of the state. Possible medical background.";
                PriorityMission1();
                break;
            case 0:
                missionText.text = "Mission Objectives: \nTarget is responsible for the death and murders of several high ranking local authorities along with releasing videos of each crime online. Strong possibility of military background. Seems to only target ruling Party members.";
                PriorityMission0();
                break;
            default:
                missionText.text = "Error";
                break;
        }
    }

    void PriorityMission2 () {
        source.clip = newPriorityTarget[Random.Range(0, newPriorityTarget.Length)];
        source.Play();


        if (list[7].Equals("Veteran (Active Duty)") || list[7].Equals("Veteran (Retired)") || list[7].Equals("Programmer") || list[2].Equals("Middle Eastern") || list[4].Equals("Muslim")) {
            totalCount++;
            source.clip = newTarget[Random.Range(0, newTarget.Length)];
            source.Play();
            CurrentMission();
            
        } else {
            failCount++;
            Debug.Log("Total Missions: " + totalCount + " Fails: " + failCount);
        }

        CheckFail();

    }

    void PriorityMission1()
    {
        source.clip = newPriorityTarget[Random.Range(0, newPriorityTarget.Length)];
        source.Play();


        if (list[7].Equals("Chemical engineer") || list[7].Equals("Doctor") || list[7].Equals("Nurse"))
        {
            totalCount++;
            source.clip = newTarget[Random.Range(0, newTarget.Length)];
            source.Play();
            CurrentMission();

        }
        else
        {
            failCount++;
            Debug.Log("Total Missions: " + totalCount + " Fails: " + failCount);
        }

        CheckFail();

    }

    void PriorityMission0()
    {
        source.clip = newPriorityTarget[Random.Range(0, newTarget.Length)];
        source.Play();


        if (list[6].Equals("1") || list[6].Equals("2") || list[6].Equals("3") || list[6].Equals("4"))
        {
            totalCount++;
            source.clip = newTarget[Random.Range(0, newPriorityTarget.Length)];
            source.Play();
            CurrentMission();

        }
        else
        {
            failCount++;
            Debug.Log("Total Missions: " + totalCount + " Fails: " + failCount);
        }

        CheckFail();

    }

    void Mission2(string [] list) {

        if (list[7].Equals("Student") || list[7].Equals("Professor") || list[7].Equals("Network administrator")) {
            totalCount++;
            if (totalCount % 2 == 0) {
                PickPriorityMission();
            } else if (totalCount % 2 == 1) {
                source.clip = newTarget[Random.Range(0, newTarget.Length)];
                source.Play();
                CurrentMission();
            }
            
        } else {
            failCount++;
            Debug.Log("Total Missions: " + totalCount + " Fails: " + failCount);
        }

        CheckFail();

    }

    void Mission1(string[] list) {

        if (list[5].Equals("Homosexual Tendencies") || list[5].Equals("Homosexual")) {
            totalCount++;
            if (totalCount % 2 == 0) {
                PickPriorityMission();
            } else if (totalCount % 2 == 1) {
                source.clip = newTarget[Random.Range(0, newTarget.Length)];
                source.Play();
                CurrentMission();
            }
        } else {
            failCount++;
            Debug.Log("Total Missions: " + totalCount + " Fails: " + failCount);
        }

        CheckFail();
        
    }
    void Mission0(string[] list) {

        if (list[7].Equals("Musician") || list[7].Equals("Web content developer") || list[7].Equals("Network administrator")) {
            totalCount++;
            if (totalCount % 2 == 0) {
                PickPriorityMission();
            } else if (totalCount % 2 == 1) {
                source.clip = newTarget[Random.Range(0, newTarget.Length)];
                source.Play();
                CurrentMission();
            }
        } else {
            failCount++;
            Debug.Log("Total Missions: " + totalCount + " Fails: " + failCount);
        }

        CheckFail();
    }

    void CheckFail() {
        
        if (failCount == 5) {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("FailState");
            
        }
    }
}
