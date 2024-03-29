﻿Shader "Custom/garasu1"
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_Smoothness("Smoothness",Range(0,1)) = 1
		_Alpha("Alpha",Range(0,1)) = 0
	}
   SubShader
   {
		Tags {
		   "Queue" = "Transparent"
		   "RenderType" = "Transparent"
		}

		Blend DstColor Zero

		Pass{
		   CGPROGRAM
		   #pragma vertex vert
		   #pragma fragment frag
		   #include "UnityCG.cginc"

		   half3 _Color;
	       half _Alpha;

		   struct appdata {
			   float4 vertex : POSITION;
		   };

		   struct v2f {
			   float4 vertex : SV_POSITION;
		   };

		   v2f vert(appdata v) {
			   v2f o;

			   o.vertex = UnityObjectToClipPos(v.vertex);

			   return o;
		   }
		   fixed4 frag(v2f i) : SV_Target{
			   return fixed4(lerp(_Color,0,_Alpha),1);
		   }
			   ENDCG
	    }

		CGPROGRAM
               #pragma target 3.0
               #pragma surface surf Standard alpha

			   half _Smoothness;

		   struct Input {
			   fixed null;
		   };

		   void surf(Input IN, inout SurfaceOutputStandard o) {
			   o.Smoothness = _Smoothness;
		   }

    ENDCG
   }
    FallBack "Standard"
}
