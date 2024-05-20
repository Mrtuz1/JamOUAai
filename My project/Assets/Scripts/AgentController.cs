using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class AgentController : MonoBehaviour
{
    [SerializeField] public NavMeshAgent agent;
    [SerializeField] Camera cam;

    public GameObject player;
    // Update is called once per frame

    // public ui image 
    public GameObject image;

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && player.activeSelf == true)
        {
            Ray movePosition = cam.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(movePosition,out RaycastHit hitInfo))
            {
                agent.SetDestination(hitInfo.point);
            }
        }
        
    }
}
