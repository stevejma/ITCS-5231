using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour {
	[SerializeField] private Transform trans;
	[SerializeField] private Animator anim;
	//static Animator anim;

	private static float radiusOfSatisfaction = 0.55f;
	private static float turnSpeed = 10f;

	private Vector3 endPoint;

	public Vector3 destination;

	// Use this for initialization
	void Start () {
		//anim = GetComponent<Animator>();
		anim.SetTrigger("idle");
		endPoint = GameObject.FindWithTag("Finish").transform.position;
		SetDestination (endPoint);
	}

	// Update is called once per frame
	void Update () {
		movement ();

	}

	void movement() {
		float distToDestination = Vector3.Distance (trans.position, endPoint);

		if (distToDestination > radiusOfSatisfaction) {
			anim.SetTrigger ("isWalking");
			SetDestination (endPoint);
		}

		if (distToDestination < radiusOfSatisfaction) {
			anim.SetTrigger ("idle");
			Destroy (GameObject.FindWithTag("Player"));
		}
		Debug.DrawLine (trans.position + Vector3.up, destination, Color.blue);


		// Face Destination
		Vector3 towards = destination - trans.position;
		towards.y = 0f;
		Quaternion targetRotation = Quaternion.LookRotation (towards);
		trans.rotation = Quaternion.Lerp (trans.rotation, targetRotation, turnSpeed * Time.deltaTime);

		// Keep grounded
		if (trans.position.y != -23.97828f)
			trans.position = new Vector3(trans.position.x, -23.97828f, trans.position.z);
	}

	public void SetDestination (Vector3 dest) {
		destination = dest;
	}
}