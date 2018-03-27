using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	public float minX = -360.0f;
	public float maxX = 360.0f;
	
	public float minY = 60f;
	public float maxY = 110.0f;

	public float sensX = 50.0f;
	public float sensY = 50.0f;
	
	float rotationY = 0.0f;
	float rotationX = 95.0f;

    float minFov = 15f;
    float maxFov = 90f;
    float sensitivity = 10f;

    public Camera mainCam;
    public Camera Camera_01;
    public Camera Camera_02;
    public Camera Camera_03;
    public Camera Camera_04;
    public Camera Camera_05;


    void Start() {
        Cursor.visible = false;
        Camera_01.enabled = true;
        Camera_02.enabled = false;
        Camera_03.enabled = false;
        Camera_04.enabled = false;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            Camera_01.enabled = true;
            Camera_02.enabled = false;
            Camera_03.enabled = false;
            Camera_04.enabled = false;
            Camera_05.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            Camera_01.enabled = false;
            Camera_02.enabled = true;
            Camera_03.enabled = false;
            Camera_04.enabled = false;
            Camera_05.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            Camera_01.enabled = false;
            Camera_02.enabled = false;
            Camera_03.enabled = true;
            Camera_04.enabled = false;
            Camera_05.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4)) {
            Camera_01.enabled = false;
            Camera_02.enabled = false;
            Camera_03.enabled = false;
            Camera_04.enabled = true;
            Camera_05.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha5)) {
            Camera_01.enabled = false;
            Camera_02.enabled = false;
            Camera_03.enabled = false;
            Camera_04.enabled = false;
            Camera_05.enabled = true;
        }

        rotationX += Input.GetAxis("Mouse X") * sensX * Time.deltaTime;
        rotationY += Input.GetAxis("Mouse Y") * sensY * Time.deltaTime;
        //Sets clamp on both x and y movement
        rotationY = Mathf.Clamp(rotationY, minY, maxY);
        rotationX = Mathf.Clamp(rotationX, minX, maxX);
        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);

        float fov = Camera_01.fieldOfView;
        fov -= Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        Camera_01.fieldOfView = fov;

        float fov2 = Camera_02.fieldOfView;
        fov2 -= Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        fov2 = Mathf.Clamp(fov, minFov, maxFov);
        Camera_02.fieldOfView = fov2;

        float fov3 = Camera_03.fieldOfView;
        fov3 -= Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        fov3 = Mathf.Clamp(fov, minFov, maxFov);
        Camera_03.fieldOfView = fov3;

        float fov4 = Camera_04.fieldOfView;
        fov4 -= Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        fov4 = Mathf.Clamp(fov, minFov, maxFov);
        Camera_04.fieldOfView = fov4;

        float fov5 = Camera_04.fieldOfView;
        fov5 -= Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        fov5 = Mathf.Clamp(fov, minFov, maxFov);
        Camera_05.fieldOfView = fov5;
    }
}
