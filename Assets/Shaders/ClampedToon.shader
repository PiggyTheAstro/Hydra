Shader "Unlit/ClampedToon"
{
    Properties
    {
        _Color("Color", Color) = (1, 1, 1, 1)
        _MinVal("MinimumValue", Range(0, 1)) = 0.0
        _MaxVal("MaximumValue", Range(0, 1)) = 1.0
    }
        SubShader
    {
        Tags
        {
            "RenderType" = "Opaque"
            "Queue" = "Geometry"
        }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            fixed4 _Color;
            float _MinVal;
            float _MaxVal;

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float3 worldNormal : NORMAL;
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.worldNormal = UnityObjectToWorldNormal(v.normal);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float3 normal = normalize(i.worldNormal);
                float NdotL = dot(_WorldSpaceLightPos0, normal);
                float intensity = smoothstep(0, 0.8, NdotL);
                fixed4 col = _Color;
                return col * clamp(intensity, _MinVal, _MaxVal);
            }
            ENDCG
        }
    }
}
