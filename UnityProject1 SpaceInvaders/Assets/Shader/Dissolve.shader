Shader "Custom/Dissolve" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_NoiseTex("NoiseTexture", 2D) = "noise"{}
		_DissolveFactor("DissolveFactor", Range(0,1))= 0.0
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
		_BurnColor("BurnColor", Color) = (1,0,0)
		_BurnDistance("BurnDistance", Range(0,1)) = 0.2
	}
	SubShader {
		Tags
		{ "RenderType"="Opaque"
		 "Queue" = "Transparent"
		}
		LOD 200

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows alpha:blend

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _NoiseTex;

		struct Input {
			float2 uv_MainTex;
			float2 uv_NoiseTex;
			
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;
		half _DissolveFactor;
		float _BurnDistance;
		fixed3 _BurnColor;
	// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		
		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex)*_Color ;
			fixed2 noise = tex2D (_NoiseTex,IN.uv_NoiseTex).r;
			o.Albedo = c.rgb;
		
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			float alpha = step(_DissolveFactor, noise);
			float value = smoothstep(noise -_BurnDistance, noise, _DissolveFactor);
			fixed3 color = lerp(c.rgb, _BurnColor.rgb, value);

			o.Alpha = value;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
