Shader "Custom/YT/Example/PragmaTestShader" {
	Properties
	{
	  _Color ("Main Color", COLOR) = (1,1,1,1)
	  _MainTex ("Base Texture", 2D) = "white"{}
	  _SubTex ("Base Texture", 2D) = "white"{}
	}
	//Tags { "RenderType"="TransparentCutout" }

	   SubShader {
        Tags { "RenderType"="Opaque" "Queue"="Geometry+2"}
        Pass {

            Stencil 
            {
                Ref 254
                Comp Less
                Pass replace 
                Fail Zero
                ZFail Zero
              
            }
        
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            struct appdata {
                float4 vertex : POSITION;
            };
            struct v2f {
                float4 pos : SV_POSITION;
            };
            v2f vert(appdata v) {
                v2f o;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                return o;
            }
            half4 frag(v2f i) : SV_Target {
                return half4(0,0,1,1);
            }
            ENDCG
        }
    }
} 
