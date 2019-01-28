Shader "Hidden/Custom/EvolutiveGrayscale"
{
	HLSLINCLUDE

#include "Packages/com.unity.postprocessing/PostProcessing/Shaders/StdLib.hlsl"

		TEXTURE2D_SAMPLER2D(_MainTex, sampler_MainTex);
	float _Blend;
	int _UnlockedColors;

	float Epsilon = 1e-10;

	float3 RGBtoHCV(in float3 RGB)
	{
		// Based on work by Sam Hocevar and Emil Persson
		float4 P = (RGB.g < RGB.b) ? float4(RGB.bg, -1.0, 2.0 / 3.0) : float4(RGB.gb, 0.0, -1.0 / 3.0);
		float4 Q = (RGB.r < P.x) ? float4(P.xyw, RGB.r) : float4(RGB.r, P.yzx);
		float C = Q.x - min(Q.w, Q.y);
		float H = abs((Q.w - Q.y) / (6 * C + Epsilon) + Q.z);
		return float3(H, C, Q.x);
	}

	float4 Frag(VaryingsDefault i) : SV_Target
	{
		float4 color = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord);
		float4 baseColor = color;
		float luminance = dot(color.rgb, float3(0.2126729, 0.7151522, 0.0721750));
		float3 hcv = RGBtoHCV(color);
		color = float4(lerp(color.rgb, luminance.xxx, _Blend.xxx), color.a); // Grayscale
		if (_UnlockedColors != 0)
		{
			if(_UnlockedColors >= 1) // Blue
				if (hcv.r > 178 / 360.0 && hcv.r < 245 / 360.0)
				{
					float value = abs(hcv.r - (200 / 360.0)) + 0.2f;
					color = float4(lerp(color.rgb, baseColor.rgb, value.xxx), color.a);
				}
			if(_UnlockedColors >= 2) // Green
				if (hcv.r > 70 / 360.0 && hcv.r < 140 / 360.0)
				{
					float value = abs(hcv.r - (120 / 360.0)) + 0.2f;
					color = float4(lerp(color.rgb, baseColor.rgb, value.xxx), color.a);
				}
			if (_UnlockedColors >= 3) // Red
				if ((hcv.r > 350 / 360.0 && hcv.r < 360 / 360.0) || (hcv.r > 0 / 360.0 && hcv.r < 20 / 360.0))
				{
					float value = abs(hcv.r - (0 / 360.0));
					float value2 = abs(hcv.r - (360 / 360.0));
					value = min(value, value2) + 0.2f;
					color = float4(lerp(color.rgb, baseColor.rgb, value.xxx), color.a);
				}
		}
		return color;
	}

		ENDHLSL

		SubShader
	{
		Cull Off ZWrite Off ZTest Always

			Pass
		{
			HLSLPROGRAM

				#pragma vertex VertDefault
				#pragma fragment Frag

			ENDHLSL
		}
	}
}