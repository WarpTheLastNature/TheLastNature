Shader "Custom/YT/Example/MaskStudyShader" 
{	
	Properties
	{
	  _Color ("Main Color", COLOR) = (1,1,1,1)
	  _MainTex ("Base Texture", 2D) = "white"{}
	}

	SubShader
	{
		Stencil
		{
		 	Ref 1
		 	Comp Always
		 	Pass replace
		 	Fail decrWrap
		 	ZFail decrWrap
		}
	 	Pass 
	 	{

	 	}
	}

} 
