using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraMovement : MonoBehaviour {
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

    public  string age;
    public  string loyalty;
    public  string gender;
    public  string ethnicity;
    public  string sexID;
    public  string occupation;
    public  string religion;
    public  string maritalStatus;

    public static string[] list = new string[8];

    public Text missionText;

    public AudioClip gameStartAudio;
    public AudioSource source;

    public static int mission;

    void Start() {
        source.clip = gameStartAudio;
        source.PlayDelayed(2);

        CurrentMission();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
        confirm.SetActive(false);
        Camera_01.enabled = true;
        Camera_02.enabled = false;
        Camera_03.enabled = false;
        Camera_04.enabled = false;
        Camera_05.enabled = false;

    }

    void Update() {
        

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
        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);

        float fov = currentCam.fieldOfView;
        fov -= Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        currentCam.fieldOfView = fov;

        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("Mouse is down");

            RaycastHit hitInfo = new RaycastHit();
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
            PassToCompare(mission);
        }
    }

    void PassToCompare(int compare) {
        if (compare == 2)
        {
            Mission2(list);
        } else if (compare == 1)
        {
            Mission1(list);
        } else
        {
            Mission0(list);
        }
    }

    void CurrentMission() {
        mission = Random.Range(0, 3);

        switch(mission)
        {
            case 2:
                missionText.text = "Mission Objectives: \nTarget is a political dissenter posting anti-government propaganda on the local state-sponsored university’s campus. Target may not necessarily be a student. Shows knowledge about university’s security systems. ";
                break;
            case 1:
                missionText.text = "Mission Objectives: \nTarget is a frequent financial sponsor and local leader of Queer rights groups. Historically these groups have been marginally successful disrupting social order among youth culture by promoting literature against State-Cultural laws at privately run educational institutions.";
                break;
            case 0:
                missionText.text = "Target is a local ring leader organizing musical venues that promote anti-establishment themes and values through various anonymous online postings. Shows proficiency in avoiding net censures.";
                break;
            default:
                missionText.text = "Error";
                break;
        }

    }

    void Mission2(string [] list) {

        if (list[7].Equals("Student") || list[7].Equals("Professor") || list[7].Equals("Network administrator")) {
            Debug.Log("You win!");
        } else { Debug.Log("You lose!"); }
    }

    void Mission1(string[] list)
    {

        if (list[5].Equals("Homosexual Tendencies") || list[5].Equals("Homosexual"))
        {
            Debug.Log("You win!");
        }
        else { Debug.Log("You lose!"); }
    }
    void Mission0(string[] list)
    {

        if (list[7].Equals("Musician") || list[7].Equals("Web content developer") || list[7].Equals("Network administrator"))
        {
            Debug.Log("You win!");
        }
        else { Debug.Log("You lose!"); }
    }

}
