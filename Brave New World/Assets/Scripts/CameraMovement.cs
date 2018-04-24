using UnityEngine;
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

    void Start() {
        Screen.lockCursor = true;
        Cursor.visible = true;
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

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse is down");

            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(currentCam.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit)
            {
                Debug.Log("Hit " + hitInfo.transform.gameObject.name);
                if (hitInfo.transform.gameObject.tag == "xNPC")
                {
                    Debug.Log("Hit Female");
                }
                else if (hitInfo.transform.gameObject.tag == "yNPC")
                {
                    Debug.Log("Hit Male");
                } else
                {
                    Debug.Log("Nope.");
                }
            }

        }
    }
}
