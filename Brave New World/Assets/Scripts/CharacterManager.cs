using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private int pathIndex;

    GameObject pathGO;
    Transform targetPathNode;
    int pathNodeIndex = 0;

    private static float radiusOfSatisfaction = 0.75f;
    private static float turnSpeed = 10f;
    private float moveSpeed;
    private static string path;

    // Use this for initialization
    void Start()
    {
        if (pathIndex == 0)
        {
            path = "Path1";
        }
        if (pathIndex == 1) {
            path = "Path2";
        }
        if (pathIndex == 2)
        {
            path = "Path3";
        }

        moveSpeed = Random.Range(1.0f, 2.1f);
        pathGO = GameObject.Find(path);
        anim.SetTrigger("idle");
    }

    void GetNextPathNode()
    {
        if (pathNodeIndex < pathGO.transform.childCount) {
            targetPathNode = pathGO.transform.GetChild(pathNodeIndex);
            pathNodeIndex++;
        }
        else
        {
            targetPathNode = null;
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        if (targetPathNode == null)
        {
            GetNextPathNode();
            if (targetPathNode == null)
            {
                //Ran out of path to follow
                ReachedGoal();
                return;
            }
        }
        Movement();
    }

    void Movement()
    {

        float distToDestination = Vector3.Distance(transform.position, targetPathNode.position);
        Vector3 dir = targetPathNode.position - this.transform.position;        //Vector facing the direction towards the pathNode
        float distThisFrame = moveSpeed * Time.deltaTime;                       //distance that will be covered this frame
        dir.y = 0;

        //Animation if's
        if (distToDestination > radiusOfSatisfaction)   //Far away enough to keep walking
        {   
            anim.SetTrigger("isWalking");
        }

        Debug.DrawLine(transform.position + Vector3.up, targetPathNode.position, Color.blue); //Blue is where the bots need to go, the node destination
        Debug.DrawRay(transform.position + Vector3.up, dir, Color.red);                   //Red is where they want to go, the "dir" vector
        

        //Script if's
        if (distToDestination < radiusOfSatisfaction) //if close enough to say object is at destination
        {        
            //Reached node
            targetPathNode = null;
        }
        else                   //Can still move this frame without reaching destination
        {                                            

            // Move towards destination
            transform.Translate(dir.normalized * distThisFrame, Space.World);

            //Rotate towards destination
            Quaternion targetRotation = Quaternion.LookRotation(dir.normalized);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);


            // Keep grounded
            if (transform.position.y != -23.97828f)
            {
                transform.position = new Vector3(transform.position.x, -23.97828f, transform.position.z);
            }

        }
    }

    void ReachedGoal()
    {
        Destroy(gameObject);
    }
}