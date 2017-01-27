Shader "Custom/YT/Example/MaskShader"
{   
	Properties
	   {
	      _Mask ("Culling Mask", 2D) = "" {}
	      _Cutoff ("Alpha Cutoff", Range(0,1)) = 0
	   }

	  

   SubShader

   {
		//Lighting On
		ZWrite On
        //Tags {"Queue" = "Geometry"}  
	
        //Blend OneMinusSrcAlpha DstAlpha
		//blend srcalpha dstalpha
		
		Pass 
		{

		Stencil
		   {
		   	Ref 2
		   	Comp always
		   	Pass replace
		   	//ZFail decrWarp
		   }

			AlphaTest LEqual [_Cutoff]
			//SetTexture [_Mask] { combine texture }
			SetTexture [_Mask] { combine texture alpha } //Uncomment to see white
		}
   }
}