 Shader "Custom/BInfiniteFog" {
     Properties { 
         _MainColour("Colour",Color)=(1,1,1,1)
         _MainTex ("Base (RGB)", 2D) = "white" {}
         _CutoffTex ("Alpha Guide", 2D) = "white" {}
         _ScrollDir("Scroll Direction",Vector)=(1,0,0,0.1)
         _FadeMul("Fading Multiplier",Range(0,3))=1
     }
     SubShader {
         Tags { "RenderType"="Transparent" "RenderQueue"="Transparent"}
         LOD 200
         
         CGPROGRAM
         #pragma surface surf WrapLambert alpha
         half4 LightingWrapLambert (SurfaceOutput s, half3 lightDir, half atten) {
            //half NdotL = dot (s.Normal, lightDir);
            half4 c;
            c.rgb = s.Albedo * _LightColor0.rgb * (atten * 2);
            c.a = s.Alpha;
            return c;
         }
 
         sampler2D _MainTex;
         sampler2D _CutoffTex;
         fixed4 _ScrollDir;
         fixed4 _MainColour;
         half _FadeMul;
         struct Input {
             float2 uv_MainTex;
             float2 uv_CutoffTex;
             float4 screenPos;
         };
 
         void surf (Input IN, inout SurfaceOutput o) {
             half4 c = tex2D (_MainTex, IN.uv_MainTex+_ScrollDir.xy*_ScrollDir.w*_Time.y)*_MainColour;
             o.Emission = c.rgb;
             o.Alpha=tex2D(_CutoffTex,IN.uv_CutoffTex).r*c.a;
             o.Alpha*=clamp(IN.screenPos.z*0.4*_FadeMul,0,1);
         }
         ENDCG
     } 
     FallBack "Diffuse"
 }