using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastCode : MonoBehaviour
{
    public GameObject crosshair;
    public float maxDistance = 2f; // Raycast'in maksimum mesafesi

    void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); // Ekranın ortasından ray çıkar
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            if(hit.collider.TryGetComponent(out Etkilesim etkilesen))
            {
                crosshair.GetComponent<Image>().color = Color.red;
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log(hit.collider.name);
                    etkilesen.Etkiles();

                }
            }
            else
            {
                crosshair.GetComponent<Image>().color = Color.white;
            }
        }
        else
        {
            crosshair.GetComponent<Image>().color = Color.white;
        }
    }
}
