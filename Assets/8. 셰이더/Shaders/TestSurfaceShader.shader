Shader "Custom/TestSurfaceShader"
{
    Properties // �� ���̴����� ����� ���� ����
    { // _������([Inspector���� ǥ�� �� �̸�], �ڷ���) = [�ʱⰪ �Ҵ�] ������ ������ ;��� �ٹٲ����� ����
        _MainTex ("Main Texture", 2D) = "white" {}
        OverlabTex("Overlab Texture", 2D) = "gray" {}
        _colorAmout("Color Amount", Range(0, 1)) = 1

    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200 //Level of detail. 200 : Diffuse Level

        CGPROGRAM //c for grapics ������ ���� ����
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Lambert 
        //#pragma vertax vert // ���� ���̴� ���̺귯�� �Լ��� ����ϰڴ�.
        //#pragma fragment frag // �ȼ� ���̵� ���̺귯�� �Լ��� ����ϰڴ�.


        sampler2D _MainTex;

        sampler2D OverlabTex;
        float _colorAmout;

        struct Input
        {
            float2 uv_MainTex; // uv ������ ������ _MainTex �� ����
            float2 uvOverlabTex;
            float4 screenPos;
        };

        //_Time : float4, �� 4������ ������ ������ �Ǵµ�
        // x : t/20, y : t, z : t * 2, w : t * 3

       
        void surf (Input IN, inout SurfaceOutput o)
        {
            // ǥ�� ���̴��� �ؽ��� ���� ����
            o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb * _colorAmout;
            //o.Albedo *= tex2D(OverlabTex, IN.uvOverlabTex).rgb;

            float2 screenUV = (IN.screenPos.xy / IN.screenPos.w) * float2(10, 5);
            o.Albedo *= tex2D(OverlabTex, screenUV + _Time.y).rgb;
        }
        ENDCG
    }

    //SubShader���� ������ �߻� �� FallBack�� ����ȴ�.
    FallBack "Standard"
}
