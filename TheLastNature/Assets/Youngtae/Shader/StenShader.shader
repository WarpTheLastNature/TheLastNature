Shader "Custom/YT/Example/StenShader" {
	Properties {
		_Color ("Color", Color) = (1,0,0,0)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
	}
	SubShader {
		LOD 200

	   Stencil
          {
          	Ref 255
          	Pass replace
          }
		
		CGPROGRAM
		#pragma surface surf Standard fullforwardshadows
		#pragma target 5.0

		sampler2D _MainTex; 

		struct Input {
			float2 uv_MainTex;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;

		void surf (Input IN, inout SurfaceOutputStandard o) {
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
