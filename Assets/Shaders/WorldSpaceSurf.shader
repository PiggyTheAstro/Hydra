Shader "Custom/WorldSpaceSurf"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _AmbientValue("AmbientValue", float) = 0.0
        _Tiling("Tile scale", float) = 1.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;
        float _AmbientValue;
        float _Tiling;
        struct Input
        {
            float3 worldNormal;
            float3 worldPos;
        };

        fixed4 _Color;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf(Input IN, inout SurfaceOutputStandard o)
        {
            float2 UV;
            fixed4 c;

            if (abs(IN.worldNormal.x) > 0.5)
            {
                UV = IN.worldPos.yz * _Tiling;
                c = tex2D(_MainTex, UV);
            }
            else if (abs(IN.worldNormal.z) > 0.5)
            {
                UV = IN.worldPos.xy * _Tiling;
                c = tex2D(_MainTex, UV);
            }
            else
            {
                UV = IN.worldPos.xz * _Tiling;
                c = tex2D(_MainTex, UV);
            }

            o.Albedo = c.rgb * _Color;
            o.Emission = o.Albedo;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
