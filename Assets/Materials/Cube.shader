Shader "Custom/Cube" {
	Properties {
		_Albedo("Albedo", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200

		CGPROGRAM
		#pragma surface surf Standard fullforwardshadows
		#pragma target 3.0

		struct Input {
			float2 uv_Albedo;
		};


		sampler2D _Albedo;
		half _Glossiness;
		half _Metallic;


		void surf (Input input, inout SurfaceOutputStandard output) {
			fixed4 color = tex2D(_Albedo, input.uv_Albedo);

			output.Albedo = color.rgb;
			output.Metallic = _Metallic;
			output.Smoothness = _Glossiness;
			output.Alpha = color.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
