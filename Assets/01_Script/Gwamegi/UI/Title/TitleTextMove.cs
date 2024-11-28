using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class TitleTextMove : MonoBehaviour
{
    public Volume Volume;

    private float faidFloat;

    private float ming;

    private float startTime;
    private float DELAY_TIME = 1f;

    private bool @bool;

    private void Awake()
    {
        Volume = GetComponent<Volume>();
        startTime = Time.time;
    }


    public void ToggleMixer(float inten)
    {
        Vignette vignette;

        if (Volume.profile.TryGet(out vignette))
        {
            vignette.intensity.value = inten;
        }
    }

    public void Faid(bool faid)
    {
        if (faid)
        {
            faidFloat = Mathf.Lerp(0,1, ming);
        }
        if (!faid)
        {
            faidFloat = Mathf.Lerp(1,0, Time.time);
        }
    }

    private void Update()
    {

        if (@bool && startTime + DELAY_TIME < Time.time)
        {
            Faid(true);
            ToggleMixer(faidFloat);
            ming += 0.005f;
        }

        if(ming > 1f)
        {
            SceneManager.LoadScene("MainScene");
        }

        if (Input.GetMouseButton(0))
        {
            @bool = true;
        }
    }
}
