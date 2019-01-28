using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(EvolutiveGrayscaleRenderer), PostProcessEvent.AfterStack, "Custom/EvolutiveGrayscale")]
public sealed class Grayscale : PostProcessEffectSettings
{
    [Range(0f, 1f), Tooltip("Grayscale effect intensity.")]
    public FloatParameter blend = new FloatParameter { value = 0.5f };
    [Range(0, 5), Tooltip("Colors Unlocked.")]
    public IntParameter unlockedColors = new IntParameter { value = 1 };
}

public sealed class EvolutiveGrayscaleRenderer : PostProcessEffectRenderer<Grayscale>
{
    public override void Render(PostProcessRenderContext context)
    {
        var sheet = context.propertySheets.Get(Shader.Find("Hidden/Custom/EvolutiveGrayscale"));

        sheet.properties.SetFloat("_Blend", settings.blend);
        sheet.properties.SetInt("_UnlockedColors", settings.unlockedColors);
        context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
    }
}