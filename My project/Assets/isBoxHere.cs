using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isBoxHere : MonoBehaviour
{
    public GameObject target;


    // eğer alanın içinde kutu varsa
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickable"))
        {
            Debug.Log("Kutu burada");
            StartCoroutine(RotateOverTime(1f));
        }
    }

    IEnumerator RotateOverTime(float time)
    {
        Vector3 startingPosition = target.transform.position;
        Vector3 targetPosition = startingPosition + new Vector3(0, -5, 0);
        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            target.transform.position = Vector3.Lerp(startingPosition, targetPosition, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        target.transform.position = new Vector3(0, 0, 0);
        target.SetActive(false);
    }
}
