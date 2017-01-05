Shader "VideoPlayer/AlphaVideo" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
	}
	SubShader {
      Tags { "RenderType" = "Opaque" }
      Blend SrcAlpha OneMinusSrcAlpha

      CGPROGRAM
      #pragma surface surf Lambert
      struct Input {
          float2 uv_MainTex;         
      };
      sampler2D _MainTex;
      void surf (Input IN, inout SurfaceOutput o) {
      	  float2 upTex = IN.uv_MainTex;
      	  float2 downTex = IN.uv_MainTex;
      	  upTex.y = upTex.y * 0.5 + 0.5;
      	  downTex.y *= 0.5;
          
          half4 alpha = tex2D (_MainTex, upTex);
          half4 result = tex2D (_MainTex, downTex);
          
          o.Alpha = alpha.r;
          o.Albedo = result.rgb;
      }
		ENDCG
	} 
	FallBack "Diffuse"
}
