#include "dxShaderIncludes.h"


cbuffer uniforms : register( b0 )
{
    int texSet;
    float alpha;
    float pad[2];
};

// data structure : before vertex shader (mesh info)
struct vertexInfo
{
    float3 position : POSITION;
    float2 uv: TEXCOORD0;
    float2 uv2: TEXCOORD1;
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
    if(texSet==0)
    {
        output.uv=input.uv;
    }
    else
    {
        output.uv=input.uv2;
    }    
    return output;
}

float4 pixelShader(v2p input) : SV_TARGET
{
    float4 outColor=inputTex0.Sample(linearSampler,input.uv);
    outColor.rgba*=alpha;
    return outColor;
}
