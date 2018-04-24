using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] npc;
    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;

    int randNPC;

	void Start () {
        StartCoroutine(WaitSpawn());
	}
	
	
	void Update () {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
	}

    IEnumerator WaitSpawn () {
        yield return new WaitForSeconds(startWait);

        while(true) {
            randNPC = Random.Range(0, npc.Length);

            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 0, Random.Range(-spawnValues.z, spawnValues.z));

            Instantiate(npc[randNPC], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);

            yield return new WaitForSeconds(spawnWait);
        }
    }
}
