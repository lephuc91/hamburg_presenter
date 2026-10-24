
Texture2D  inputTex0 : register(t0);
Texture2D  inputTex1 : register(t1);

SamplerState linearSampler : register(s0);

cbuffer uniforms : register( b0 )
{
    float redLevel;
    float greenLevel;
    float blueLevel;
    float blackLevel;
    float gamma;
    float pad[3];
};

// data structure : before vertex shader (mesh info)
struct vertexInfo
{
    float3 position : POSITION;
    float2 uv: TEXCOORD0;
};

// data structure : vertex shader to pixel shader
// also called interpolants because values interpolates through the triangle
// from one vertex to another
struct v2p
{
    float4 position : SV_POSITION;
    float2 uv : TEXCOORD0;
};

v2p vertexShader(vertexInfo input)
{
    v2p output;
    output.position = float4(input.position,1.0);
    output.uv=input.uv;
    return output;
}

float4 pixelShader(v2p input) : SV_TARGET
{
    float4 outColor;
    outColor=inputTex0.Sample(linearSampler,input.uv);

    outColor.rgb=pow(outColor.rgb,float3(1.0+gamma,1.0+gamma,1.0+gamma));
    outColor+=float4(redLevel,greenLevel,blueLevel,0.0);
    float range=1.0-blackLevel;
    outColor.rgb*=range;
    outColor.rgb+=blackLevel;
    return outColor;
}
