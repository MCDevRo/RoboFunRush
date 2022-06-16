Shader "UniStorm/Clouds/Cloud Computing"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader
	{
        Tags{ "Queue" = "Transparent-400" "RenderType" = "Transparent" "IgnoreProjector" = "True" }
		LOD 100
        Blend One OneMinusSrcAlpha
        ZWrite Off

		Pass
		{
			CGPROGRAM
			#pragma enable_d3d11_debug_symbols
			#pragma multi_compile_instancing
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;

				UNITY_VERTEX_INPUT_INSTANCE_ID //Insert
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;

				UNITY_VERTEX_INPUT_INSTANCE_ID //Insert
				UNITY_VERTEX_OUTPUT_STEREO //Insert
			};

			UNITY_DECLARE_TEX2D(_MainTex); //sampler2D _MainTex;
			float4 _MainTex_ST;
			
			v2f vert (appdata v)
			{
				v2f o;

				UNITY_SETUP_INSTANCE_ID(v); //Insert
				UNITY_INITIALIZE_OUTPUT(v2f, o); //Insert
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o); //Insert

                float s = _ProjectionParams.z;

                float4x4 mvNoTranslation =
                    float4x4(
                        float4(UNITY_MATRIX_V[0].xyz, 0.0f),
                        float4(UNITY_MATRIX_V[1].xyz, 0.0f),
                        float4(UNITY_MATRIX_V[2].xyz, 0.0f),
                        float4(0, 0, 0, 1.1)
                    );
                    
                
                o.vertex = mul(mul(UNITY_MATRIX_P, mvNoTranslation), v.vertex * float4(s, s, s, 1));
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				UNITY_SETUP_INSTANCE_ID(i);
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(i); //Insert

				// sample the texture
				fixed4 col = UNITY_SAMPLE_TEX2D(_MainTex, i.uv); //tex2D
				return col;
			}
			ENDCG
		}
	}
}
