using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner3 : MonoBehaviour
{

    public GameObject[] npc = new GameObject[3];
    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;

    int randNPC;

    void Start()
    {
        StartCoroutine(WaitSpawn3());

    }


    void Update()
    {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
    }

    IEnumerator WaitSpawn3()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            randNPC = Random.Range(0, npc.Length);

            npc[0].AddComponent<CharacterManager3>();
            npc[1].AddComponent<CharacterManager3>();
            npc[2].AddComponent<CharacterManager3>();

            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 0, Random.Range(-spawnValues.z, spawnValues.z));

            Instantiate(npc[randNPC], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);


            yield return new WaitForSeconds(spawnWait);
        }
    }
}
