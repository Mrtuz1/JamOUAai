using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levyeCode : MonoBehaviour, Etkilesim
{
    public GameObject target;

    public GameObject kol;

    public void Etkiles()
    {
        Debug.Log("levye");
        
        // kol objesinin animasyonu içinden leverUp değişkenini true yap
        kol.GetComponent<Animator>().SetBool("LeverUp", true);

        RotateToOpen();
    }
    public void RotateToOpen()
    {
        StartCoroutine(RotateOverTime(1f));
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
