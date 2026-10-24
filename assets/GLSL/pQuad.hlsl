#define vec3 float3
#define vec4 float4
#include "alpha.h"

Texture2D  inputTex0 : register(t0);
Texture2D  inputTex1 : register(t1);

SamplerState linearSampler : register(s0);

cbuffer uniforms : register( b0 )
{
    float redLevel;
    float greenLevel;
    float blueLevel;
    float alphaLevel;
    float blackLevel;
    float gamma;
    float pad[2];
};

// data structure : before vertex shader (mesh info)
struct vertexInfo
{
    float2 position : POSITION;
    float3 uv: TEXCOORD0;
};

// data structure : vertex shader to pixel shader
// also called interpolants because values interpolates through the triangle
// from one vertex to another
struct v2p
{
    float4 position : SV_POSITION;
    float3 uv : TEXCOORD0;
};

v2p vertexShader(vertexInfo input)
{
    v2p output;
    output.position = float4(input.position,0.0,1.0)*float4(1,-1,1,1);
    output.uv=input.uv;
    return output;
}

float4 pixelShader(v2p input) : SV_TARGET
{
    float4 outColor;
    float2 texCoord=input.uv.xy/input.uv.z;

    float width,height;
    inputTex0.GetDimensions(width,height);
    texCoord/=float2(width,height);

    outColor=inputTex0.Sample(linearSampler,texCoord);

#ifdef PRE_MULT
    divideAlpha(outColor);
#endif

    outColor.rgb=pow(outColor.rgb,float3(1.0+gamma,1.0+gamma,1.0+gamma));
    outColor+=float4(redLevel,greenLevel,blueLevel,0.0);
    float range=1.0-blackLevel;
    outColor.rgb*=range;
    outColor.rgb+=blackLevel;
    outColor.a += alphaLevel * (1.0 - outColor.a);

#ifdef PRE_MULT
    multiplyAlpha(outColor);
#endif

    return outColor;
}
