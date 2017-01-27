Shader "Custom/YT/Example/RedShader" 
{	
	Properties
	{
	  _Color ("Main Color", COLOR) = (1,1,1,1)
	  _MainTex ("Base Texture", 2D) = "white"{}
	  _SubTex ("Base Texture", 2D) = "white"{}
	}
	//Tags { "RenderType"="TransparentCutout" }

	SubShader
	{
		Tags {"Queue" = "Transparent"}
	 	Pass 
	 	{
	 		Blend SrcAlpha OneMinusSrcAlpha

	 		SetTexture[_MainTex]
	 		{
	 		 	Combine texture
	 		} 

	 		//SetTexture[_SubTex]
	 		//{
	 		//  ConstantColor[_Color]
	 		//  Combine texture lerp(texture) previous, constant
	 		//}
	 	}
	}

} 
