using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class AdaptPostProcess : MonoBehaviour
{
    PostProcessVolume ppVolume;
    Vignette vignette;


    // Start is called before the first frame update
    void Start()
    {
        ppVolume = GetComponent<PostProcessVolume>();
        vignette = ppVolume.sharedProfile.GetSetting<Vignette>();
        FloatParameter intensity = new FloatParameter();
        intensity.value = 0.5f - ((float)GameManager.Instance.UnlockedColors * 0.1f);
        vignette.intensity = intensity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
