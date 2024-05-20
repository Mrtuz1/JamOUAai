using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPosAndRot : MonoBehaviour
{
    public GameObject target;

    public Vector3 posDiff;

    void Start()
    {
        posDiff = target.transform.position - transform.position;
    }

    public void SetPosAndRotMethod()
    {
        transform.position = target.transform.position - posDiff;
        transform.rotation = target.transform.rotation;
    }
}
