using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PickUpController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform holdPos;
    public float pickUpRadius = 2.0f;

    private GameObject pickedObject;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (pickedObject == null)
            {
                PickObject();
            }
            else
            {
                DropObject();
            }
        }
    }

    void PickObject()
    {
        // Yakındaki "Pickable" etiketli objeleri bul
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, pickUpRadius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Pickable"))
            {
                pickedObject = hitCollider.gameObject;
                pickedObject.transform.position = holdPos.position;
                pickedObject.transform.parent = holdPos;

                // NavMeshObstacle'ı devre dışı bırak
                NavMeshObstacle obstacle = pickedObject.GetComponent<NavMeshObstacle>();
                if (obstacle != null)
                {
                    obstacle.enabled = false;
                }

                // Rigidbody'yi devre dışı bırak
                Rigidbody rb = pickedObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = true;
                }

                break;
            }
        }
    }

    void DropObject()
    {
        if (pickedObject != null)
        {
            pickedObject.transform.parent = null;

            // NavMeshObstacle'i etkinleştir
            NavMeshObstacle obstacle = pickedObject.GetComponent<NavMeshObstacle>();
            if (obstacle != null)
            {
                obstacle.enabled = true;
            }

            // Rigidbody'yi etkinleştir
            Rigidbody rb = pickedObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
            }

            pickedObject = null;
        }
    }
}


