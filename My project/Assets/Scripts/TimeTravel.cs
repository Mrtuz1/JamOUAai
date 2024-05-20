using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class TimeTravel : MonoBehaviour
{

    public GameObject camera1;
    public GameObject camera2;

    public float fadeDuration = 1.0f;

    public GameObject fakeBox;
    public GameObject fakeBox2;



    public PostProcessVolume m_Volume;
    public ColorGrading m_ColorGrading;
    public LensDistortion m_LensDistortion;

    public ChromaticAberration m_ChromaticAberration;

    public Grain m_Grain;
    public Vignette m_Vignette;

    // Start is called before the first frame update
    void Start()
    {
        camera1.SetActive(true);
        camera2.SetActive(false);

        m_ColorGrading = m_Volume.profile.GetSetting<ColorGrading>();
        m_LensDistortion = m_Volume.profile.GetSetting<LensDistortion>();
        m_Grain = m_Volume.profile.GetSetting<Grain>();
        m_ChromaticAberration = m_Volume.profile.GetSetting<ChromaticAberration>();
        m_Vignette = m_Volume.profile.GetSetting<Vignette>();
    }    

    // p tuşuna basılırsa
    void Update()
    {
        camera2.transform.rotation = camera1.transform.rotation;

        if (Input.GetKeyDown(KeyCode.P))
        {
            if(camera1.activeSelf == true)
            {
                StartCoroutine(CammeraEffect(camera2, camera1));
            }
            else
            {
                StartCoroutine(CammeraEffectBack(camera1, camera2));

            }
        }
    }

    IEnumerator CammeraEffect(GameObject cam, GameObject cam2)
    {
        float startAlpha = 0;
        float targetAlpha = -100f; // Hedef değeri pozitif bir değere değiştirdim.

        float t = 0.0f;
        float fadeDuration = 1f; // fadeDuration tanımlandı.

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float normalizedTime = t / fadeDuration;
            m_ColorGrading.contrast.value = Mathf.Lerp(startAlpha, 100, normalizedTime);
            m_ColorGrading.postExposure.value = Mathf.Lerp(startAlpha, -0.5f, normalizedTime);
            m_LensDistortion.intensity.value = Mathf.Lerp(startAlpha, targetAlpha, normalizedTime);
            m_Grain.intensity.value = Mathf.Lerp(0, 1, normalizedTime);
            m_ChromaticAberration.intensity.value = Mathf.Lerp(0, 1, normalizedTime);
            m_Vignette.intensity.value = Mathf.Lerp(0, 0.55f, normalizedTime);

            yield return null;
        }

        SetPosAndRot script = fakeBox.GetComponent<SetPosAndRot>();
        script.SetPosAndRotMethod();

        SetPosAndRot script2 = fakeBox2.GetComponent<SetPosAndRot>();
        script2.SetPosAndRotMethod();

        cam.SetActive(true);
        cam2.SetActive(false);

        t = 0.0f;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float normalizedTime = t / fadeDuration;
            m_ColorGrading.contrast.value = Mathf.Lerp(100, startAlpha, normalizedTime);
            m_ColorGrading.postExposure.value = Mathf.Lerp(-0.5f, startAlpha, normalizedTime);
            m_LensDistortion.intensity.value = Mathf.Lerp(targetAlpha, startAlpha - 30, normalizedTime);

            yield return null;
        }
    }

    IEnumerator CammeraEffectBack(GameObject cam, GameObject cam2)
    {
        float startAlpha = 0;
        float targetAlpha = -100f; // Hedef değeri pozitif bir değere değiştirdim.

        float t = 0.0f;
        float fadeDuration = 1f; // fadeDuration tanımlandı.

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float normalizedTime = t / fadeDuration;
            m_ColorGrading.contrast.value = Mathf.Lerp(startAlpha, 100, normalizedTime);
            m_ColorGrading.postExposure.value = Mathf.Lerp(startAlpha, -0.5f, normalizedTime);
            m_LensDistortion.intensity.value = Mathf.Lerp(startAlpha - 30, targetAlpha, normalizedTime);
            m_Grain.intensity.value = Mathf.Lerp(1, 0, normalizedTime);
            m_ChromaticAberration.intensity.value = Mathf.Lerp(1, 0, normalizedTime);
            m_Vignette.intensity.value = Mathf.Lerp(0.55f, 0, normalizedTime);

            yield return null;
        }

        SetPosAndRot script = fakeBox.GetComponent<SetPosAndRot>();
        script.SetPosAndRotMethod();

        SetPosAndRot script2 = fakeBox2.GetComponent<SetPosAndRot>();
        script2.SetPosAndRotMethod();

        cam.SetActive(true);
        cam2.SetActive(false);

        t = 0.0f;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float normalizedTime = t / fadeDuration;
            m_ColorGrading.contrast.value = Mathf.Lerp(100, startAlpha, normalizedTime);
            m_ColorGrading.postExposure.value = Mathf.Lerp(-0.5f, startAlpha, normalizedTime);
            m_LensDistortion.intensity.value = Mathf.Lerp(targetAlpha, startAlpha, normalizedTime);

            yield return null;
        }
    }
}
