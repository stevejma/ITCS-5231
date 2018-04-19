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

    public Camera Camera_01;

    void Start() {
        Cursor.visible = false;
        Camera_01.enabled = true;

    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            int layerMask = 1 << 8;
            layerMask = ~layerMask;

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask)) {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("Did Hit");
            } else {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                Debug.Log("Did not Hit");
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            Camera_01.enabled = true;
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
    }
}
