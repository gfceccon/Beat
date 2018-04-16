Shader "Unlit/Cube2"
{
	Properties
	{
		_Albedo("Albedo", 2D) = "white" {}
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct AppData
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct VertexData
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			sampler2D _Albedo;
			float4 _Albedo_ST;
			
			VertexData vert (AppData input)
			{
				VertexData output;
				output.vertex = UnityObjectToClipPos(input.vertex);
				output.uv = TRANSFORM_TEX(input.uv, _Albedo);
				UNITY_TRANSFER_FOG(output, output.vertex);
				return output;
			}
			
			fixed4 frag (VertexData input) : SV_Target
			{
				fixed4 output = tex2D(_Albedo, input.uv);
				UNITY_APPLY_FOG(input.fogCoord, col);
				return output;
			}
			ENDCG
		}
	}
}
