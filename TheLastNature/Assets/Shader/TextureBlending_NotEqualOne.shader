Shader "Custom/YT/Stencil/TextureColor_NotEqualOne" {

Properties
{
	_Texture ("Main Texture", Texture);
}

SubShader
{
	Tags { "RenderType"="Transparent"}
	LOD 200

	Blend DstColor SrcColor//2X Multiplicative
	//Blend SrcColor DstColor 
  	//Blend One One
	Stencil
	{
		Ref 1
		Comp notequal
		Pass keep
	}
	
	CGPROGRAM
	#pragma surface surf Lambert

	sampler2D _MainTex;
	fixed4 _Color;

	struct Input
	{
		float2 uv_MainTex;
	};

	void surf (Input IN, inout SurfaceOutput o)
	{
		fixed4 c = _Color;
		o.Albedo = c.rgb;
		o.Alpha = c.a;
	}
	
	ENDCG
}

Fallback "VertexLit"
}
